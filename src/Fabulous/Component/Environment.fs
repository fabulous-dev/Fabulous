namespace Fabulous

open System.ComponentModel
open System.Runtime.CompilerServices
  
type Environment<'T> = delegate of unit -> EnvironmentKey<'T>

[<Struct>]
type EnvironmentValue<'T> =
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public Environment: EnvironmentContext
    
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public Key: EnvironmentKey<'T>
    
    new(env, key) = { Environment = env; Key = key }
    
    member inline this.Current =
        this.Environment.Get(this.Key)
    
    member inline this.Set(value: 'T) =
        this.Environment.Set(this.Key, value)

[<AutoOpen>]
module EnvironmentHelpers =
    let inline Environment (key: EnvironmentKey<'T>) = Environment<'T>(fun () -> key)
        
type EnvironmentAttrValue =
    { Key: string
      Value: obj }

module EnvironmentAttrs =
    let Environment = Attributes.defineSimpleScalar "Environment" ScalarAttributeComparers.noCompare (fun prevOpt currOpt node ->
        match struct(prevOpt, currOpt) with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueNone ->
            node.EnvironmentContext.RemoveInternal(prev.Key, true)
            
        | _, ValueSome curr ->
            node.EnvironmentContext.SetInternal(curr.Key, curr.Value, true)
    )
    
[<Extension>]
type EnvironmentExtensions =
    [<Extension>]
    static member inline Bind(_: ComponentBuilder, [<InlineIfLambda>] value: Environment<'T>, [<InlineIfLambda>] continuation: EnvironmentValue<'T> -> ComponentBodyBuilder<'marker>) =
        ComponentBodyBuilder(fun bindings env ctx ->
            let envKey = value.Invoke()
            
            // Listen to changes in the environment
            ctx.AddDisposable(
                envKey.Key,
                env.ValueChanged.Subscribe(fun args ->
                    if args.Key = envKey.Key then
                        ctx.NeedsRender()
                )
            )
            
            let state = EnvironmentValue<'T>(env, envKey)
            (continuation state).Invoke(bindings, env, ctx)
        )

[<Extension>]
type EnvironmentModifiers =
    [<Extension>]
    static member inline environment(this: WidgetBuilder<unit, 'marker>, key: EnvironmentKey<'T>, value: 'T) =
        this.AddScalar(EnvironmentAttrs.Environment.WithValue({ Key = key.Key; Value = box value }))