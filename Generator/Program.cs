// dotnet build Generator\Generator.csproj && dotnet  Generator\bin\Debug\netcoreapp2.0\Generator.dll Generator\bindings.json Elmish.XamarinForms\DynamicXaml.fs && fsc -a -r:packages\androidapp\Xamarin.Forms\lib\netstandard1.0\Xamarin.Forms.Core.dll Elmish.XamarinForms\XamlElement.fs Elmish.XamarinForms\DynamicXamlConverters.fs Elmish.XamarinForms\DynamicXaml.fs

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Newtonsoft.Json;

namespace Generator
{
    class Bindings
    {
        // Input
        public List<string> Assemblies { get; set; }
        public List<TypeBinding> Types { get; set; }
        public string OutputNamespace { get; set; }

        // Output
        public List<AssemblyDefinition> AssemblyDefinitions { get; set; }

        public TypeDefinition GetTypeDefinition(string name) =>
            (from a in AssemblyDefinitions
             from m in a.Modules
             from tdef in m.Types
             where tdef.FullName == name
             select tdef).First();

        public TypeBinding FindType (string name) => Types.FirstOrDefault (x => x.Name == name);
    }

    class TypeBinding
    {
        // Input
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string CustomType { get; set; }
        public List<MemberBinding> Members { get; set; }

        // Output
        public string BoundCode { get; set; }
        public TypeDefinition Definition { get; set; }

        public string BoundName => "XamlElement"; // Definition.Name + "Description";
    }

    class MemberBinding
    {
        /// The name of the property in the target
        public string Name { get; set; }
        
        /// A unique name of the property in the model
        public string UniqueName { get; set; }

        /// Indicates if the "property" is actually passed as a fixed parameter to the constructor
        public bool IsParam { get; set; }

        /// The bound name of the type of the parameter if it is an element requiring creation
        public string ParamTypeBoundName { get; set; }

        /// The lowercase name used as a parameter in the API
        public string ShortName { get; set; }
        
        /// The input type type of the property as seen in the API
        public string InputType { get; set; }

        /// The default value when applying to the target
        public string DefaultValue { get; set; }

        /// The function used to compute equality between previous and subsequent values
        public string Equality { get; set; }

        /// Converts the input type to the model type
        public string ConvToModel { get; set; }

        /// The expression to convert the model type to the value to be assigned to the property in the target
        public string ConvToValue { get; set; }

        /// The full code for incrementally assigning to the property in the target
        public string UpdateCode { get; set; }

        /// The type as stored in the model
        /// 
        public string ModelType { get; set; }

        /// The element type of the collection property
        public string ElementType { get; set; }

        /// The attached properties for items in the collection property
        public List<MemberBinding> Attached { get; set; }

        // Output
        public MemberReference Definition { get; set; }

        public TypeReference BoundType =>
            (Definition is PropertyDefinition p) 
              ? p.PropertyType
              : (Definition is EventDefinition e)
              ? e.EventType
              : null;

        public string BoundUniqueName => string.IsNullOrEmpty(UniqueName) ? Name : UniqueName;
        public string LowerBoundUniqueName => char.ToLowerInvariant (BoundUniqueName[0]) + BoundUniqueName.Substring (1);
        public string BoundShortName => string.IsNullOrEmpty(ShortName) ? Name : ShortName;
        public string LowerBoundShortName => char.ToLowerInvariant(BoundShortName[0]) + BoundShortName.Substring(1);
        public string GetInputType(Bindings bindings, IEnumerable<Tuple<TypeReference, TypeDefinition>> hierarchy)
        {
            if (!string.IsNullOrWhiteSpace(InputType))
            {
                return InputType;
            }
            return this.GetModelType(bindings, hierarchy);
        }
        public string GetModelType(Bindings bindings, IEnumerable<Tuple<TypeReference, TypeDefinition>> hierarchy)
        {
            if (!string.IsNullOrWhiteSpace(ModelType))
            {
                return ModelType;
            }
            if (this.BoundType == null)
            {
                throw new Exception($"no type for {this.Name}");
            }
            return GetModelTypeInner(bindings, this.BoundType, hierarchy);
        }
        public static string GetModelTypeInner(Bindings bindings, TypeReference tref, IEnumerable<Tuple<TypeReference, TypeDefinition>> hierarchy)
        {
            if (tref.IsGenericParameter)
            {
                if (hierarchy != null)
                {
                    var r = Program.ResolveGenericParameter(tref, hierarchy);
                    return GetModelTypeInner(bindings, r, hierarchy);
                }
                else
                {
                    return "XamlElement";
                }
            }
            if (tref.IsGenericInstance)
            {
                var n = tref.Name.Substring(0, tref.Name.IndexOf('`'));
                var ns = tref.Namespace;
                if (tref.IsNested)
                {
                    n = tref.DeclaringType.Name + "." + n;
                    ns = tref.DeclaringType.Namespace;
                }
                var args = string.Join(", ", ((GenericInstanceType)tref).GenericArguments.Select(s => GetModelTypeInner(bindings, s, hierarchy)));
                return $"{ns}.{n}<{args}>";
            }
            switch (tref.FullName)
            {
                case "System.String": return "string";
                case "System.Boolean": return "bool";
                case "System.Int32": return "int";
                case "System.Double": return "double";
                case "System.Single": return "single";
                default:
                    if (bindings.Types.FirstOrDefault(x => x.Name == tref.FullName) is TypeBinding tb)
                        return tb.BoundName;
                    return tref.FullName.Replace('/', '.');
            }
        }
        public string GetElementType(IEnumerable<Tuple<TypeReference, TypeDefinition>> hierarchy)
        {
            if (!string.IsNullOrWhiteSpace(ElementType))
            {
                return ElementType;
            }
            return GetElementTypeInner(this.BoundType, hierarchy);
        }
        static string GetElementTypeInner(TypeReference tref, IEnumerable<Tuple<TypeReference, TypeDefinition>> hierarchy)
        {
            var r = Program.ResolveGenericParameter(tref, hierarchy);
            if (r == null)
                return null;
            if (r.FullName == "System.String")
                return null;
            if (r.Name == "IList`1" && r.IsGenericInstance)
            {
                var args = ((GenericInstanceType)r).GenericArguments;
                var elementType = Program.ResolveGenericParameter(args[0], hierarchy);
                return elementType.Name;
            }
            else
            {
                var bs = r.Resolve().Interfaces;
                return bs.Select(b => GetElementTypeInner(b.InterfaceType, hierarchy)).FirstOrDefault(b => b != null);
            }
        }

    }

    class Program
    {
        static int Main(string[] args)
        {
            try {
                if (args.Length < 2)
                {
                    Console.Error.WriteLine("usage: generator <outputPath>");
                    Environment.Exit(1);
                }
                var bindingsPath = args[0];
                var outputPath = args[1];

                var bindings = JsonConvert.DeserializeObject<Bindings> (File.ReadAllText (bindingsPath));

                bindings.AssemblyDefinitions = bindings.Assemblies.Select(LoadAssembly).ToList();

                foreach (var x in bindings.Types)
                    x.Definition = bindings.GetTypeDefinition (x.Name);
                foreach (var x in bindings.Types) {
                    foreach (var m in x.Members) {
                        if (FindProperty (m.Name, x.Definition) is PropertyDefinition p) {
                            m.Definition = p;
                        }
                        else if (FindEvent (m.Name, x.Definition) is EventDefinition e) {
                            m.Definition = e;
                        }
                        else if (string.IsNullOrWhiteSpace(m.UpdateCode)) {
                            Console.WriteLine($"Could not find member '{m.Name}'");
                        }
                    }
                }
                var code = BindTypes (bindings);

                File.WriteAllText (outputPath, code);
                return 0;
            }
            catch (Exception ex) {
                System.Console.WriteLine(ex);
                return 1;
            }
        }

        static string BindTypes (Bindings bindings)
        {
            var w = new StringWriter();
            var head = "";

            w.WriteLine("namespace rec " + bindings.OutputNamespace);
            w.WriteLine();
            w.WriteLine("#nowarn \"67\" // cast always holds");
            w.WriteLine();

            w.WriteLine($"    /// Produce a new visual element with an adjusted attribute");
            w.WriteLine($"[<AutoOpen>]");
            w.WriteLine($"module XamlElementExtensions = ");
            w.WriteLine();
            w.WriteLine($"    type XamlElement with");
            foreach (var type in bindings.Types)
            {
                var tdef = type.Definition;
                var hierarchy = GetHierarchy(type.Definition).ToList();
                var ctor = tdef.Methods
                    .Where(x => x.IsConstructor && x.IsPublic)
                    .OrderBy(x => x.Parameters.Count)
                    .FirstOrDefault();

                w.WriteLine();
                if (string.IsNullOrWhiteSpace(type.ModelName))
                {
                    w.WriteLine($"        /// Create a {tdef.FullName} from the view description");
                    w.WriteLine($"        member x.CreateAs{tdef.Name}() : {tdef.FullName} =");
                    w.WriteLine($"            match x.Create() with");
                    w.WriteLine($"            | :? {tdef.FullName} as res -> res");
                    w.WriteLine($"            | obj -> failwithf \"Incorrect element type in view, expected a '{tdef.FullName}' but got a '%s')\" (obj.GetType().ToString()) ");
                }
            }
            var allMembersInAllTypes = new List<MemberBinding>();
            foreach (var type in bindings.Types)
            {
                if (type.Members != null)
                {
                    foreach (var y in type.Members)
                    {
                        allMembersInAllTypes.Add(y);
                        if (y.Attached != null)
                        {
                            foreach (var ap in y.Attached)
                                allMembersInAllTypes.Add(ap);
                        }
                    }
                }
            }
            var allMembersInAllTypesGroupedByName = allMembersInAllTypes.GroupBy(y => y.BoundUniqueName);
            foreach (var ms in allMembersInAllTypesGroupedByName)
            {
                var m = ms.First();
                if (!m.IsParam)
                {
                    w.WriteLine();
                    w.WriteLine($"        /// Try to get the {m.BoundUniqueName} property in the visual element");
                    var modelType = m.GetModelType(bindings, null);
                    w.WriteLine("        member x.Try" + m.BoundUniqueName + " = match x.Attributes.TryFind(\"" + m.BoundUniqueName + "\") with Some v -> USome(unbox<" + modelType + ">(v)) | None -> UNone");
                }
            }
            foreach (var ms in allMembersInAllTypesGroupedByName)
            {
                var m = ms.First();
                if (!m.IsParam)
                {
                    w.WriteLine();
                    w.WriteLine($"        /// Adjusts the {m.BoundUniqueName} property in the visual element");
                    var conv = string.IsNullOrWhiteSpace(m.ConvToModel) ? "" : m.ConvToModel;
                    var inputType = m.GetInputType(bindings, null);
                    w.WriteLine("        member x." + m.BoundUniqueName + "(value: " + inputType + ") = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add(\"" + m.BoundUniqueName + "\", box (" + conv + "(value))))");
                }
            }
            w.WriteLine();
            foreach (var ms in allMembersInAllTypesGroupedByName)
            {
                var m = ms.First();
                if (!m.IsParam)
                {
                    var inputType = m.GetInputType(bindings, null);
                    w.WriteLine();
                    w.WriteLine($"    /// Adjusts the {m.BoundUniqueName} property in the visual element");
                    w.WriteLine("    let with" + m.BoundUniqueName + " (value: " + inputType + ") (x: XamlElement) = x." + m.BoundUniqueName + "(value)");
                    w.WriteLine();
                    w.WriteLine($"    /// Adjusts the {m.BoundUniqueName} property in the visual element");
                    w.WriteLine("    let " + m.LowerBoundUniqueName + " (value: " + inputType + ") (x: XamlElement) = x." + m.BoundUniqueName + "(value)");
                }
            }
            w.WriteLine();
            w.WriteLine("type Xaml() =");
            foreach (var type in bindings.Types)
            {
                var tdef = type.Definition;
                var nameOfCreator = string.IsNullOrWhiteSpace(type.ModelName) ? tdef.Name : type.ModelName;
                var customTypeToCreate = string.IsNullOrWhiteSpace(type.CustomType) ? tdef.FullName : type.CustomType;
                var hierarchy = GetHierarchy(type.Definition).ToList();
                var boundHierarchy = 
                    hierarchy.Select(x => bindings.Types.FirstOrDefault(y => y.Name == x.Item2.FullName))
                    .Where(x => x != null)
                    .ToList();

                var baseType = boundHierarchy.Count > 1 ? boundHierarchy[1] : null;

                // All properties and events apart from the attached ones
                var allBaseMembers = (from x in boundHierarchy.Skip(1) from y in x.Members select y).ToList();
                var allImmediateMembers = type.Members.ToList();
                var allMembers = allImmediateMembers.Concat(allBaseMembers);

                // Emit the constructor
                w.WriteLine();
                w.WriteLine($"    /// Describes a {nameOfCreator} in the view");
                w.Write($"    static member {nameOfCreator}(");
                head = "";
                foreach (var m in allMembers)
                {
                    var inputType = m.GetInputType(bindings, null);

                    w.Write($"{head}?{m.LowerBoundShortName}: {inputType}");
                    head = ", ";
                }
                w.WriteLine($") = ");
                w.WriteLine($"        let attribs = [| ");
                foreach (var m in allMembers)
                {
                    var conv = string.IsNullOrWhiteSpace(m.ConvToModel) ? "" : m.ConvToModel;
                    w.WriteLine("            match " + m.LowerBoundShortName + " with None -> () | Some v -> yield (\"" + m.BoundUniqueName + "\"" + $", box (" + conv + "(v))) ");
                }
                w.WriteLine($"          |]");

                var ctor = tdef.Methods
                    .Where(x => x.IsConstructor && x.IsPublic)
                    .OrderBy(x => x.Parameters.Count)
                    .FirstOrDefault();

                w.WriteLine();
                w.WriteLine($"        let create () =");
                if (!tdef.IsAbstract && ctor != null && ctor.Parameters.Count == 0)
                {
                    if (allMembers.Any(m => m.IsParam))
                    {
                        w.Write($"            match ");
                        head = "";
                        foreach (var m in allMembers)
                        {
                            if (m.IsParam)
                            {
                                w.Write($"{head}{m.LowerBoundShortName}");
                                head = ", ";
                            }
                        }
                        w.WriteLine($" with");
                        w.Write($"            | ");
                        head = "";
                        foreach (var m in allMembers)
                        {
                            if (m.IsParam)
                            {
                                w.Write($"{head}Some {m.LowerBoundShortName}");
                                head = ", ";
                            }
                        }
                        w.WriteLine($" ->");
                        w.Write($"                box (new {customTypeToCreate}(");
                        head = "";
                        foreach (var m in allMembers)
                        {
                            if (m.IsParam)
                            {
                                var bt = m.ParamTypeBoundName;
                                if (bt != null)
                                {
                                    w.Write($"{head}{m.LowerBoundShortName}.CreateAs{bt}()");
                                }
                                else
                                {
                                    w.Write($"{head}{m.LowerBoundShortName}");
                                }
                                head = ", ";
                            }
                        }
                        w.WriteLine($"))");
                        w.Write($"            | _ -> box (new {customTypeToCreate}())");
                    }
                    else
                    {
                        w.Write($"            box (new {customTypeToCreate}())");
                    }
                }
                else
                {
                    w.WriteLine($"            failwith \"can't create {tdef.FullName}\"");
                }
                w.WriteLine();
                w.WriteLine($"        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = ");

                if (baseType == null && type.Members.Count() == 0)
                {
                    w.WriteLine($"            ()");
                }
                else
                {
                    w.WriteLine($"            let target = (target :?> {tdef.FullName})");
                    foreach (var m in allMembers)
                    {
                        var hasApply = !string.IsNullOrWhiteSpace(m.ConvToValue) || !string.IsNullOrWhiteSpace(m.UpdateCode);

                        var bt = ResolveGenericParameter(m.BoundType, hierarchy);
                        string elementType = m.GetElementType(hierarchy);
                        if (m.IsParam) 
                        {
                        }
                        else if (elementType != null && elementType != "obj" && !hasApply)
                        {
                            w.WriteLine($"            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.Try{m.BoundUniqueName}");
                            w.WriteLine($"            let collOpt = source.Try{m.BoundUniqueName}");
                            w.WriteLine($"            updateIList prevCollOpt collOpt target.{m.Name}");
                            w.WriteLine($"                (fun (x:XamlElement) -> x.CreateAs{elementType}())");
                            if (m.Attached != null)
                            {
                                w.WriteLine($"                (fun prevChildOpt newChild targetChild -> ");
                                foreach (var ap in m.Attached)
                                {
                                    w.WriteLine($"                    // Adjust the attached properties");
                                    w.WriteLine($"                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.Try{ap.BoundUniqueName}), newChild.Try{ap.BoundUniqueName} with");
                                    w.WriteLine($"                    | USome prev, USome v when prev = v -> ()");
                                    var apApply = string.IsNullOrWhiteSpace(ap.ConvToValue) ? "" : ap.ConvToValue + " ";
                                    w.WriteLine($"                    | prevOpt, USome value -> {tdef.FullName}.Set{ap.Name}(targetChild, {apApply}value)");
                                    w.WriteLine($"                    | USome _, UNone -> {tdef.FullName}.Set{ap.Name}(targetChild, {ap.DefaultValue}) // TODO: not always perfect, should set back to original default?");
                                    w.WriteLine($"                    | _ -> ()");
                                }
                                w.WriteLine($"                    ())");
                            }
                            else
                            {
                                w.WriteLine($"                (fun _ _ _ -> ())");
                            }
                            w.WriteLine($"                canReuseDefault");
                            w.WriteLine($"                updateDefault");
                        }
                        else
                        {
                            if (bt != null && bindings.FindType(bt.FullName) is TypeBinding b && !hasApply)
                            {
                                if (bt.IsValueType)
                                {
                                    w.WriteLine($"            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.Try{m.BoundUniqueName}");
                                    w.WriteLine($"            match prevChildOpt, source.Try{m.BoundUniqueName} with");
                                    w.WriteLine($"            // For structured objects, dependsOn on reference equality");
                                    w.WriteLine($"            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()");
                                    w.WriteLine($"            | _, USome newChild ->");
                                    w.WriteLine($"                target.{m.Name} <- newChild.CreateAs{bt.Name}()");
                                    w.WriteLine($"            | USome _, UNone ->");
                                    w.WriteLine($"                target.{m.Name} <- Unchecked.defaultof<_>");
                                    w.WriteLine($"            | UNone, UNone -> ()");
                                }
                                else
                                {
                                    w.WriteLine($"            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.Try{m.BoundUniqueName}");
                                    w.WriteLine($"            match prevChildOpt, source.Try{m.BoundUniqueName} with");
                                    w.WriteLine($"            // For structured objects, dependsOn on reference equality");
                                    w.WriteLine($"            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()");
                                    w.WriteLine($"            | USome prevChild, USome newChild ->");
                                    w.WriteLine($"                newChild.UpdateIncremental(prevChild, target.{m.Name})");
                                    w.WriteLine($"            | UNone, USome newChild ->");
                                    w.WriteLine($"                target.{m.Name} <- newChild.CreateAs{bt.Name}()");
                                    w.WriteLine($"            | USome _, UNone ->");
                                    w.WriteLine($"                target.{m.Name} <- null;");
                                    w.WriteLine($"            | UNone, UNone -> ()");
                                }
                            }
                            else if (bt != null && (bt.Name.EndsWith("Handler") || bt.Name.EndsWith("Handler`1") || bt.Name.EndsWith("Handler`2")) &&  !hasApply)
                            {
                                w.WriteLine($"            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.Try{m.BoundUniqueName}");
                                w.WriteLine($"            match prevValueOpt, source.Try{m.BoundUniqueName} with");
                                w.WriteLine($"            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()");
                                w.WriteLine($"            | USome prevValue, USome value -> target.{m.Name}.RemoveHandler(prevValue); target.{m.Name}.AddHandler(value)");
                                w.WriteLine($"            | UNone, USome value -> target.{m.Name}.AddHandler(value)");
                                w.WriteLine($"            | USome prevValue, UNone -> target.{m.Name}.RemoveHandler(prevValue)");
                                w.WriteLine($"            | UNone, UNone -> ()");
                            }
                            else
                            {
                                w.WriteLine($"            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.Try{m.BoundUniqueName}");
                                w.WriteLine($"            let valueOpt = source.Try{m.BoundUniqueName}");
                                if (!string.IsNullOrWhiteSpace(m.UpdateCode))
                                {
                                    w.WriteLine($"            {m.UpdateCode} prevValueOpt valueOpt target");
                                    if (m.Attached != null)
                                    {
                                        w.WriteLine($"                (fun prevChildOpt newChild targetChild -> ");
                                        foreach (var ap in m.Attached)
                                        {
                                            w.WriteLine($"                    // Adjust the attached properties");
                                            w.WriteLine($"                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.Try{ap.BoundUniqueName}), newChild.Try{ap.BoundUniqueName} with");
                                            w.WriteLine($"                    | USome prev, USome v when prev = v -> ()");
                                            var apApply = string.IsNullOrWhiteSpace(ap.ConvToValue) ? "" : ap.ConvToValue + " ";
                                            w.WriteLine($"                    | prevOpt, USome value -> {tdef.FullName}.Set{ap.Name}(targetChild, {apApply}value)");
                                            w.WriteLine($"                    | USome _, UNone -> {tdef.FullName}.Set{ap.Name}(targetChild, {ap.DefaultValue}) // TODO: not always perfect, should set back to original default?");
                                            w.WriteLine($"                    | _ -> ()");
                                        }
                                        w.WriteLine($"                    ())");
                                    }
                                }
                                else 
                                {
                                    var update = string.IsNullOrWhiteSpace(m.ConvToValue) ? "" : m.ConvToValue + " ";
                                    //var equality = string.IsNullOrWhiteSpace(m.Equality) ? "" : m.Equality + " ";

                                    w.WriteLine($"            match prevValueOpt, valueOpt with");
                                    w.WriteLine($"            | USome prevValue, USome value when prevValue = value -> ()");
                                    w.WriteLine($"            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine(\"Setting {nameOfCreator}::{m.Name} \"); target.{m.Name} <- {update} value");
                                    w.WriteLine($"            | USome _, UNone -> target.{m.Name} <- {m.DefaultValue}");
                                    w.WriteLine($"            | UNone, UNone -> ()");
                                }
                            }
                        }
                    }
                }
                                
                w.WriteLine($"        new XamlElement(typeof<{tdef.FullName}>, create, update, Map.ofArray attribs)");

            }
            w.WriteLine($"[<AutoOpen>]");
            w.WriteLine($"module XamlCreateExtensions = ");
            foreach (var type in bindings.Types)
            {
                var tdef = type.Definition;
                var tname = string.IsNullOrWhiteSpace(type.ModelName) ? tdef.Name : type.ModelName;
                var hierarchy = GetHierarchy(type.Definition).ToList();
                var boundHierarchy = hierarchy.Select(x => bindings.Types.FirstOrDefault(y => y.Name == x.Item2.FullName))
                            .Where(x => x != null)
                            .ToList();

                var ctor = tdef.Methods
                    .Where(x => x.IsConstructor && x.IsPublic)
                    .OrderBy(x => x.Parameters.Count)
                    .FirstOrDefault();

                if (!tdef.IsAbstract && ctor != null && ctor.Parameters.Count == 0)
                {
                    w.WriteLine();
                    w.WriteLine($"    /// Specifies a {tname} in the view description, initially with default attributes");
                    w.WriteLine($"    let {Char.ToLower(tname[0])}{tname.Substring(1)} = Xaml.{tname}()");
                }
            }
            return w.ToString ();
        }

        static public TypeReference ResolveGenericParameter (TypeReference tref, IEnumerable<Tuple<TypeReference, TypeDefinition>> hierarchy)
        {
            if (tref == null)
                return null;
            if (!tref.IsGenericParameter)
                return tref;
            var q =
                from b in hierarchy where b.Item1.IsGenericInstance
                let ps = b.Item2.GenericParameters
                let p = ps.FirstOrDefault(x => x.Name == tref.Name)
                where p != null
                let pi = ps.IndexOf(p)
                let args = ((GenericInstanceType)b.Item1).GenericArguments
                select ResolveGenericParameter (args[pi], hierarchy);
            return q.First ();
        }


        static PropertyDefinition FindProperty(string name, TypeDefinition type)
        {
            var q =
                from tdef in GetHierarchy(type)
                from p in tdef.Item2.Properties
                where p.Name == name
                select p;
            return q.FirstOrDefault ();
        }

        static EventDefinition FindEvent(string name, TypeDefinition type)
        {
            var q =
                from tdef in GetHierarchy(type)
                from p in tdef.Item2.Events
                where p.Name == name
                select p;
            return q.FirstOrDefault ();
        }

        static IEnumerable<Tuple<TypeReference, TypeDefinition>> GetHierarchy (TypeDefinition type)
        {
            var d = type;
            yield return Tuple.Create ((TypeReference)d, d);
            while (d.BaseType != null) {
                var r = d.BaseType;
                d = r.Resolve();
                yield return Tuple.Create (r, d);
            }
        }

        static AssemblyDefinition LoadAssembly (string path)
        {
            //if (path.StartsWith("packages")) {
            //    var user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //    path = Path.Combine (user, ".nuget", path);
           // }
            return AssemblyDefinition.ReadAssembly(path);
        }
    }
}
