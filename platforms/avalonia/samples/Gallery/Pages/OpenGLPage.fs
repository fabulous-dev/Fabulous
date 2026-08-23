namespace Gallery

open System
open System.Diagnostics
open System.Numerics
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Avalonia
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.OpenGL
open Avalonia.OpenGL.Controls
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

open Microsoft.FSharp.NativeInterop

#nowarn "9"

[<StructLayout(LayoutKind.Sequential, Pack = 4)>]
type Vertex =
    struct
        val mutable Position: Vector3

        [<DefaultValue>]
        val mutable Normal: Vector3

        new(position: Vector3, _: Vector3) = { Position = position }
    end

type OpenGlPageControl() =
    inherit OpenGlControlBase()

    let mutable _yaw: float = 0.
    let mutable _pitch: float = 0.
    let mutable _roll: float = 0.
    let mutable _disco: float = 0.

    let mutable _vertexShader: int = 0
    let mutable _fragmentShader: int = 0
    let mutable _shaderProgram: int = 0
    let mutable _vertexBufferObject: int = 0
    let mutable _indexBufferObject: int = 0
    let mutable _vertexArrayObject: int = 0
    let mutable _info: string = ""

    let mutable _points: Vertex array = [||]
    let mutable _indices: uint16 array = [||]
    let mutable _minY = 0.
    let mutable _maxY = 0.

    static let StartNew = Stopwatch.StartNew()

    do
        let name =
            typeof<OpenGlPageControl>.Assembly
                .GetManifestResourceNames()
            |> Array.find(fun x -> x.Contains("teapot.bin"))

        use sr =
            new System.IO.BinaryReader(
                typeof<OpenGlPageControl>.Assembly
                    .GetManifestResourceStream(name)
            )

        let mutable buf: byte array = Array.zeroCreate(sr.ReadInt32())
        sr.Read(buf, 0, buf.Length) |> ignore
        let points: float32 array = Array.zeroCreate(buf.Length / 4)
        Buffer.BlockCopy(buf, 0, points, 0, buf.Length)
        buf <- Array.zeroCreate(sr.ReadInt32())
        sr.Read(buf, 0, buf.Length) |> ignore
        _indices <- Array.zeroCreate(buf.Length / 2)
        Buffer.BlockCopy(buf, 0, _indices, 0, buf.Length)
        _points <- Array.zeroCreate(points.Length / 3)

        for i in 0 .. points.Length - 1 do
            if (i < (points.Length / 3)) then
                let srci = i * 3
                _points[i] <- Vertex(Position = Vector3(float32 points[srci], float32 points[srci + 1], float32 points[srci + 2]))

        for i in 0 .. (_indices.Length - 1) do
            // Check if the index is out of bounds for + 2
            if i + 2 <= _points.Length then
                let a = _points[int _indices[i]].Position
                let b = _points[int _indices[i + 1]].Position
                let c = _points[int _indices[i + 2]].Position
                let normal = Vector3.Normalize(Vector3.Cross(c - b, a - b))
                _points[int _indices[i]].Normal <- _points[int _indices[i]].Normal + normal
                _points[int _indices[i + 1]].Normal <- _points[int _indices[i + 1]].Normal + normal
                _points[int _indices[i + 2]].Normal <- _points[int _indices[i + 2]].Normal + normal

        for i in 0 .. (_points.Length - 1) do
            _points[i].Normal <- Vector3.Normalize(_points[i].Normal)
            _maxY <- Math.Max(_maxY, float _points[i].Position.Y)
            _minY <- Math.Min(_minY, float _points[i].Position.Y)

    member this.Yaw
        with get () = _yaw
        and set value = _yaw <- value

    static member YawProperty: DirectProperty<OpenGlPageControl, float> =
        AvaloniaProperty.RegisterDirect<OpenGlPageControl, float>("Yaw", (fun o -> o.Yaw), (fun o v -> o.Yaw <- v))

    member this.Pitch
        with get () = _pitch
        and set value = _pitch <- value

    static member PitchProperty: DirectProperty<OpenGlPageControl, float> =
        AvaloniaProperty.RegisterDirect<OpenGlPageControl, float>("Pitch", (fun o -> o.Pitch), (fun o v -> o.Pitch <- v))

    member this.Roll
        with get () = _roll
        and set value = _roll <- value

    static member RollProperty: DirectProperty<OpenGlPageControl, float> =
        AvaloniaProperty.RegisterDirect<OpenGlPageControl, float>("Roll", (fun o -> o.Roll), (fun o v -> o.Roll <- v))

    member this.Disco
        with get () = _disco
        and set value = _disco <- value

    static member DiscoProperty: DirectProperty<OpenGlPageControl, float> =
        AvaloniaProperty.RegisterDirect<OpenGlPageControl, float>("Disco", (fun o -> o.Disco), (fun o v -> o.Disco <- v))

    member this.Info
        with get () = _info
        and set value = _info <- value

    static member InfoProperty: DirectProperty<OpenGlPageControl, string> =
        AvaloniaProperty.RegisterDirect<OpenGlPageControl, string>("Info", (fun o -> o.Info), (fun o v -> o.Info <- v))

    member this.GetShader(fragment: bool, shader: string) =
        let mutable shader = shader

        let version =
            if this.GlVersion.Type = GlProfileType.OpenGL then
                if RuntimeInformation.IsOSPlatform(OSPlatform.OSX) then
                    150
                else
                    120
            else
                100

        let mutable data = "#version " + string version + "\n"

        if this.GlVersion.Type = GlProfileType.OpenGLES then
            data <- data + "precision mediump float;\n"

        if version >= 150 then
            shader <- shader.Replace("attribute", "in")

            if fragment then
                shader <-
                    shader
                        .Replace("varying", "in")
                        .Replace("//DECLAREGLFRAG", "out vec4 outFragColor;")
                        .Replace("gl_FragColor", "outFragColor")
            else
                shader <- shader.Replace("varying", "out")

        data <- data + shader

        data

    member this.VertexShaderSource =
        this.GetShader(
            false,
            "
attribute vec3 aPos;
attribute vec3 aNormal;
uniform mat4 uModel;
uniform mat4 uProjection;
uniform mat4 uView;

varying vec3 FragPos;
varying vec3 VecPos;  
varying vec3 Normal;
uniform float uTime;
uniform float uDisco;
void main()
{
    float discoScale = sin(uTime * 10.0) / 10.0;
    float distortionX = 1.0 + uDisco * cos(uTime * 20.0) / 10.0;
    
    float scale = 1.0 + uDisco * discoScale;
    
    vec3 scaledPos = aPos;
    scaledPos.x = scaledPos.x * distortionX;
    
    scaledPos *= scale;
    gl_Position = uProjection * uView * uModel * vec4(scaledPos, 1.0);
    FragPos = vec3(uModel * vec4(aPos, 1.0));
    VecPos = aPos;
    Normal = normalize(vec3(uModel * vec4(aNormal, 1.0)));
}
    "
        )

    member this.FragmentShaderSource =
        this.GetShader(
            true,
            "
        varying vec3 FragPos; 
        varying vec3 VecPos; 
        varying vec3 Normal;
        uniform float uMaxY;
        uniform float uMinY;
        uniform float uTime;
        uniform float uDisco;
        //DECLAREGLFRAG

        void main()
        {
            float y = (VecPos.y - uMinY) / (uMaxY - uMinY);
            float c = cos(atan(VecPos.x, VecPos.z) * 20.0 + uTime * 40.0 + y * 50.0);
            float s = sin(-atan(VecPos.z, VecPos.x) * 20.0 - uTime * 20.0 - y * 30.0);

            vec3 discoColor = vec3(
                0.5 + abs(0.5 - y) * cos(uTime * 10.0),
                0.25 + (smoothstep(0.3, 0.8, y) * (0.5 - c / 4.0)),
                0.25 + abs((smoothstep(0.1, 0.4, y) * (0.5 - s / 4.0))));

            vec3 objectColor = vec3((1.0 - y), 0.40 +  y / 4.0, y * 0.75 + 0.25);
            objectColor = objectColor * (1.0 - uDisco) + discoColor * uDisco;

            float ambientStrength = 0.3;
            vec3 lightColor = vec3(1.0, 1.0, 1.0);
            vec3 lightPos = vec3(uMaxY * 2.0, uMaxY * 2.0, uMaxY * 2.0);
            vec3 ambient = ambientStrength * lightColor;


            vec3 norm = normalize(Normal);
            vec3 lightDir = normalize(lightPos - FragPos);  

            float diff = max(dot(norm, lightDir), 0.0);
            vec3 diffuse = diff * lightColor;

            vec3 result = (ambient + diffuse) * objectColor;
            gl_FragColor = vec4(result, 1.0);

        }
    "
        )

    member this.CheckError(gl: GlInterface) =
        let mutable err = gl.GetError()

        while err <> GlConsts.GL_NO_ERROR do
            Console.WriteLine(err)
            err <- gl.GetError()

    override this.OnOpenGlInit(GL: GlInterface) =

        this.CheckError GL

        this.Info <- $"Renderer: {GL.GetString(GlConsts.GL_RENDERER)} Version: {GL.GetString(GlConsts.GL_VERSION)}"

        // Load the source of the vertex shader and compile it.
        _vertexShader <- GL.CreateShader(GlConsts.GL_VERTEX_SHADER)
        Console.WriteLine(GL.CompileShaderAndGetError(_vertexShader, this.VertexShaderSource))

        // Load the source of the fragment shader and compile it.
        _fragmentShader <- GL.CreateShader(GlConsts.GL_FRAGMENT_SHADER)
        Console.WriteLine(GL.CompileShaderAndGetError(_fragmentShader, this.FragmentShaderSource))

        // Create the shader program, attach the vertex and fragment shaders and link the program.
        _shaderProgram <- GL.CreateProgram()
        GL.AttachShader(_shaderProgram, _vertexShader)
        GL.AttachShader(_shaderProgram, _fragmentShader)
        let positionLocation = 0
        let normalLocation = 1
        GL.BindAttribLocationString(_shaderProgram, positionLocation, "aPos")
        GL.BindAttribLocationString(_shaderProgram, normalLocation, "aNormal")
        Console.WriteLine(GL.LinkProgramAndGetError(_shaderProgram))
        this.CheckError(GL)

        // Create the vertex buffer object (VBO) for the vertex data.
        _vertexBufferObject <- GL.GenBuffer()
        // Bind the VBO and copy the vertex data into it.
        GL.BindBuffer(GlConsts.GL_ARRAY_BUFFER, _vertexBufferObject)
        this.CheckError(GL)

        let vertexSize = Marshal.SizeOf<Vertex>()
        use pdata = fixed _points
        GL.BufferData(GlConsts.GL_ARRAY_BUFFER, IntPtr(_points.Length * vertexSize), NativePtr.toNativeInt(pdata), GlConsts.GL_STATIC_DRAW)

        _indexBufferObject <- GL.GenBuffer()
        GL.BindBuffer(GlConsts.GL_ELEMENT_ARRAY_BUFFER, _indexBufferObject)
        this.CheckError(GL)

        use pdata = fixed _indices
        GL.BufferData(GlConsts.GL_ELEMENT_ARRAY_BUFFER, IntPtr(_indices.Length * sizeof<int>), NativePtr.toNativeInt(pdata), GlConsts.GL_STATIC_DRAW)
        this.CheckError(GL)
        _vertexArrayObject <- GL.GenVertexArray()
        GL.BindVertexArray(_vertexArrayObject)
        this.CheckError(GL)
        GL.VertexAttribPointer(positionLocation, 3, GlConsts.GL_FLOAT, 0, vertexSize, IntPtr.Zero)
        GL.VertexAttribPointer(normalLocation, 3, GlConsts.GL_FLOAT, 0, vertexSize, IntPtr(12))
        GL.EnableVertexAttribArray(positionLocation)
        GL.EnableVertexAttribArray(normalLocation)
        this.CheckError(GL)

    override this.OnOpenGlDeinit(GL: GlInterface) =
        // Unbind everything
        GL.BindBuffer(GlConsts.GL_ARRAY_BUFFER, 0)
        GL.BindBuffer(GlConsts.GL_ELEMENT_ARRAY_BUFFER, 0)
        GL.BindVertexArray(0)
        GL.UseProgram(0)

        // Delete all resources.
        GL.DeleteBuffer(_vertexBufferObject)
        GL.DeleteBuffer(_indexBufferObject)
        GL.DeleteVertexArray(_vertexArrayObject)
        GL.DeleteProgram(_shaderProgram)
        GL.DeleteShader(_fragmentShader)
        GL.DeleteShader(_vertexShader)

    override this.OnOpenGlRender(gl: GlInterface, _: int) =
        gl.ClearColor(float32 0, float32 0, float32 0, float32 0)
        gl.Clear(GlConsts.GL_COLOR_BUFFER_BIT ||| GlConsts.GL_DEPTH_BUFFER_BIT)
        gl.Enable(GlConsts.GL_DEPTH_TEST)
        gl.Viewport(0, 0, int this.Bounds.Width, int this.Bounds.Height)
        let mutable GL = gl

        GL.BindBuffer(GlConsts.GL_ARRAY_BUFFER, _vertexBufferObject)
        GL.BindBuffer(GlConsts.GL_ELEMENT_ARRAY_BUFFER, _indexBufferObject)
        GL.BindVertexArray(_vertexArrayObject)
        GL.UseProgram(_shaderProgram)
        this.CheckError(GL)

        let projection =
            Matrix4x4.CreatePerspectiveFieldOfView(float32(Math.PI / float 4), float32(this.Bounds.Width / this.Bounds.Height), 0.01f, float32 1000)

        let view =
            Matrix4x4.CreateLookAt(Vector3(float32 25, float32 25, float32 25), Vector3(), Vector3(float32 0, float32 1, float32 0))

        let model =
            Matrix4x4.CreateFromYawPitchRoll(float32 _yaw, float32 _pitch, float32 _roll)

        let modelLoc = GL.GetUniformLocationString(_shaderProgram, "uModel")
        let viewLoc = GL.GetUniformLocationString(_shaderProgram, "uView")
        let projectionLoc = GL.GetUniformLocationString(_shaderProgram, "uProjection")
        let maxYLoc = GL.GetUniformLocationString(_shaderProgram, "uMaxY")
        let minYLoc = GL.GetUniformLocationString(_shaderProgram, "uMinY")
        let timeLoc = GL.GetUniformLocationString(_shaderProgram, "uTime")
        let discoLoc = GL.GetUniformLocationString(_shaderProgram, "uDisco")

        let pinnedModel = GCHandle.Alloc(model, GCHandleType.Pinned)
        let pinnedProjection = GCHandle.Alloc(projection, GCHandleType.Pinned)
        let pinnedView = GCHandle.Alloc(view, GCHandleType.Pinned)

        try
            let modeData = pinnedModel.AddrOfPinnedObject()
            GL.UniformMatrix4fv(modelLoc, 1, false, NativePtr.toVoidPtr<Matrix4x4>(NativePtr.ofNativeInt(modeData)))
            let viewData = pinnedView.AddrOfPinnedObject()
            GL.UniformMatrix4fv(viewLoc, 1, false, NativePtr.toVoidPtr<Matrix4x4>(NativePtr.ofNativeInt(viewData)))
            let projectData = pinnedProjection.AddrOfPinnedObject()
            GL.UniformMatrix4fv(projectionLoc, 1, false, NativePtr.toVoidPtr<Matrix4x4>(NativePtr.ofNativeInt(projectData)))
        finally
            pinnedModel.Free()
            pinnedProjection.Free()
            pinnedView.Free()

        GL.Uniform1f(maxYLoc, float32 _maxY)
        GL.Uniform1f(minYLoc, float32 _minY)
        GL.Uniform1f(timeLoc, float32(StartNew.Elapsed.TotalSeconds))
        GL.Uniform1f(discoLoc, float32 _disco)
        this.CheckError(GL)
        GL.DrawElements(GlConsts.GL_TRIANGLES, _indices.Length, GlConsts.GL_UNSIGNED_SHORT, IntPtr.Zero)

        this.CheckError(GL)

        this.RequestNextFrameRendering()

type IFabMvuOpenGlPageControl =
    inherit IFabControl

module OpenGlPageControl =
    let WidgetKey = Widgets.register<OpenGlPageControl>()

    let Data =
        Attributes.defineSimpleScalarWithEquality<struct (float * float * float * float)> "OpenGlPageControl_Data" (fun _ newValueOpt node ->
            let target = node.Target :?> OpenGlPageControl

            match newValueOpt with
            | ValueNone ->
                target.ClearValue(OpenGlPageControl.YawProperty)
                target.ClearValue(OpenGlPageControl.PitchProperty)
                target.ClearValue(OpenGlPageControl.RollProperty)
                target.ClearValue(OpenGlPageControl.DiscoProperty)
            | ValueSome(x, y, z, v) ->
                target.SetValue(OpenGlPageControl.YawProperty, x)
                target.SetValue(OpenGlPageControl.PitchProperty, y)
                target.SetValue(OpenGlPageControl.RollProperty, z)
                target.SetValue(OpenGlPageControl.DiscoProperty, v))

[<AutoOpen>]
module OpenGLWidgetBuilders =
    type Fabulous.Avalonia.View with

        static member OpenGlPageControl(yaw: float, pitch: float, roll: float, disco: float) =
            WidgetBuilder<'msg, IFabMvuOpenGlPageControl>(OpenGlPageControl.WidgetKey, OpenGlPageControl.Data.WithValue(struct (yaw, pitch, roll, disco)))

type OpenGLWidgetModifiers =
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuOpenGlPageControl>, value: ViewRef<OpenGlPageControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

module OpenGLPage =
    type Model =
        { GLInfo: string
          Yaw: float
          Pitch: float
          Roll: float
          Disco: float }

    type Msg =
        | YawChanged of float
        | PitchChanged of float
        | RollChanged of float
        | DiscoChanged of float
        | Loaded of RoutedEventArgs

    let openGlRef = ViewRef<OpenGlPageControl>()

    let init () =
        { GLInfo = ""
          Yaw = 0.
          Pitch = 0.
          Roll = 0.
          Disco = 0. },
        Cmd.none

    let update msg model =
        match msg with
        | YawChanged v -> { model with Yaw = v }, Cmd.none
        | PitchChanged v -> { model with Pitch = v }, Cmd.none
        | RollChanged v -> { model with Roll = v }, Cmd.none
        | DiscoChanged v -> { model with Disco = v }, Cmd.none
        | Loaded _ ->
            { model with
                GLInfo = openGlRef.Value.Info },
            Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("OpenGLPage") {
            let! model = Context.Mvu program

            (Grid() {
                UserControl(
                    View
                        .OpenGlPageControl((model.Yaw, model.Pitch, model.Roll, model.Disco))
                        .reference(openGlRef)
                )

                VStack() { TextBlock(model.GLInfo) }

                (Grid(coldefs = [ Star; Auto ], rowdefs = [ Star ]) {
                    (VStack() {
                        TextBlock("Yaw")
                        Slider(0., 10., model.Yaw, YawChanged)
                        TextBlock("Pitch")
                        Slider(0., 10., model.Pitch, PitchChanged)
                        TextBlock("Roll")
                        Slider(0., 10., model.Roll, RollChanged)

                        HStack() {
                            TextBlock("D")
                                .fontWeight(FontWeight.Bold)
                                .foreground(Brushes.Crimson)

                            TextBlock("I")
                                .fontWeight(FontWeight.Bold)
                                .foreground(Brushes.Cyan)

                            TextBlock("S")
                                .fontWeight(FontWeight.Bold)
                                .foreground(Brushes.Green)

                            TextBlock("C")
                                .fontWeight(FontWeight.Bold)
                                .foreground(Brushes.Orange)

                            TextBlock("O")
                                .fontWeight(FontWeight.Bold)
                                .foreground(Brushes.Cyan)

                        }

                        Slider(0., 1., model.Disco, DiscoChanged)
                    })
                        .gridColumn(1)
                        .minWidth(300.)
                })
                    .margin(20.)
            })
                .onLoaded(Loaded)
        }
