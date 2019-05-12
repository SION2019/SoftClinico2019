Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports SIONBD
Imports System.Diagnostics
Public Class FormPrincipal
    Private dtAlertas As New DataTable
    Private dtNotas As New DataTable
    Private fprincipal As New PrincipalDAL
    Private identificador As Integer
    Public mnuMenuUsuario As New MenuStrip
    Public dtPermisos As New DataTable
    Private permiso_general As String
    Public codigoEntrada As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim objPrincipal As New Principal

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")>
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function
    Public ReadOnly Property cnxion2doPlano As SqlConnection
        Get
            Dim conexion As SqlConnection = Connection.conn
            conexion.Open()
            Return conexion
        End Get
    End Property
    Public ReadOnly Property cnxion As SqlConnection
        Get
            If SIONBD.Connection.conn.State <> ConnectionState.Open Then
                Return SIONBD.Connection.conn
            Else
                Return SIONBD.Connection.conn
            End If
        End Get
    End Property
    'Dim conexion As New SqlConnection("Data Source=tcp:192.168.2.20;Initial Catalog=CELER_2018_HOSP;uid=sa;password=G8liatPrueba;Pooling=true;Min Pool Size=1; Max Pool Size=5;")
    'Dim conexion2 As New SqlConnection("Data Source=tcp:192.168.2.20;Initial Catalog=CELER_2018_HOSP;uid=sa;password=G8liatPrueba;Pooling=true;Min Pool Size=1; Max Pool Size=5;")
    'Public ReadOnly Property cnxion2doPlano As SqlConnection
    '    Get
    '        If Not conexion2.State = ConnectionState.Open Then
    '            conexion2.Open()
    '        End If
    '        Return conexion2
    '    End Get
    'End Property
    'Public ReadOnly Property cnxion As SqlConnection
    '    Get
    '        If Not conexion.State = ConnectionState.Open Then
    '            conexion.Open()
    '        End If
    '        Return conexion
    '    End Get
    'End Property

    ' "DESACTIVO EL PUTO SOBRE ESE QUE ESPABILA PARA QUE NO JODA, NO BORRAR CODIGO COMENTADO EN ESTE FORM"

    Sub click_Global(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not IsNothing(Me.ActiveMdiChild) AndAlso ActiveMdiChild.WindowState = FormWindowState.Maximized Then
            ActiveMdiChild.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub FormPrincipal_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If fprincipal.estaAbiertoTipo(Form_Historia_clinica) Then
            MsgBox(Mensajes.VENTANA_ACTIVA, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("¿Realmente desea salir de Celer?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            If (SesionActual.codigoPerfil = Constantes.AMBUQ Or SesionActual.codigoPerfil = Constantes.COMFACOR Or SesionActual.codigoPerfil = Constantes.NUEVA_EPS) AndAlso
                cnxion.State = ConnectionState.Open Then
                Dim params As New List(Of String)
                params.Add(Constantes.ITEM_DGV_SELECCIONE_VALOR)
                params.Add(Nothing)
                params.Add(0)
                General.ejecutarSQL(ConsultasHC.VISTA_PREVIA_ACTUALIZAR, params)
                Dim lista As New List(Of String)
                lista.Add(SesionActual.codigoPerfil)
                General.ejecutarSQL(Consultas.AUDITOR_EXTERNO_GET_CODIGO_ENTRADA, lista)

            End If

            cnxion.Close()
            Inicio.Close()
            Me.Dispose()
            Inicio.Dispose()
            Close()
            InicioSesion.Close()
        Else
            e.Cancel = True
        End If
    End Sub


    Private Sub FormPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ctl As Control
        Dim ctlMDI As MdiClient
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)
                ctlMDI.BackColor = Me.BackColor
            Catch exc As InvalidCastException
            End Try
        Next
        Me.barraestadopp.Text = "Bienvenidos a SION"


        If SesionActual.idUsuario <> -1 Then

            dtPermisos = fprincipal.cargarOpciones(SesionActual.codigoPerfil, SesionActual.idEmpresa)
            SesionActual.dtPermisos = fprincipal.cargarOpciones(SesionActual.codigoPerfil, SesionActual.idEmpresa)


            fprincipal.CreaOpciones(SesionActual.idEmpresa, SesionActual.codigoPerfil)

            Me.Text = System.String.Format(Me.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

            Dim fileCreatedDate As DateTime = File.GetCreationTime(My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe")
            Dim fso, archivo As Object
            fso = CreateObject("Scripting.FileSystemObject")
            archivo = fso.GetFile(My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe")
            fileCreatedDate = archivo.DateLastModified
            Me.Text = Me.Text & " - " & Format(fileCreatedDate, Constantes.FORMATO_FECHA_HORA_GEN4)
            lblSede.Text = SesionActual.nombreSede
            guardarVersionEquipos()
            Funciones.obtenerDatosEmpresaActual(SesionActual.idEmpresa)
            fprincipal.cargarImagenEmpresa(SesionActual.idEmpresa)
            Dim params As New List(Of String)
            params.Add(SesionActual.idUsuario)
            Label3.Text = General.getValorConsulta(Consultas.MENSAJE_DIARIO, params)
            Label3.Visible = True
            Timer2.Start()
            TimerDiario.Start()
            Timer_CerraxInactividad.Start()
        End If

        Panel2.Visible = False
        Timer_rojo.Start()
        'el identificador de la ventana sobre la que vamos a actuar
        ''DisableCloseButton(Me.Handle)
        'General.agregarDicc(SpellChecker1)
        'General.agregarEventoDevExp(Me, MemoEdit1)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Panel1.Visible = False
    End Sub


    Public Function guardarVersion() As Principal

        Dim equipo, version, observacion As String
        equipo = My.Computer.Name.ToString
        version = String.Format("Versión {0}", My.Application.Info.Version.ToString)

        If Inicio.version_actu > Inicio.num_version Then
            observacion = "¡¡Equipo desactualizado!!"
        Else
            observacion = "Este equipo se encuenta actualizado."
        End If
        Dim objPrincipal = New Principal
        objPrincipal.nombre = equipo

        objPrincipal.version = version
        objPrincipal.fecha = Now.Date
        objPrincipal.observacion = observacion
        objPrincipal.usuario = SesionActual.idUsuario
        Return objPrincipal

    End Function

    Public Sub guardarVersionEquipos()
        Dim objPrincipal As New Principal
        Dim objPrincipalBLL As New PrincipalBLL
        Try
            objPrincipal = guardarVersion()
            objPrincipalBLL.guardarVersion(objPrincipal)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Public Sub guardarAuditor()
        Dim objPrincipal As New Principal
        Try
            objPrincipal.idEmpresa = SesionActual.idEmpresa
            objPrincipal.codigoPerfil = SesionActual.codigoPerfil
            objPrincipal.idEmpleado = SesionActual.idUsuario
            PrincipalDAL.registroAuditorExterno(objPrincipal)
            codigoEntrada = objPrincipal.codigoEntrada
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub TimerDiario_Tick(sender As Object, e As EventArgs) Handles TimerDiario.Tick
        TimerDiario.Stop()
        Label3.Visible = False
        'TimerDiarioEspera.Start()
    End Sub

    Private Sub TimerDiarioEspera_Tick(sender As Object, e As EventArgs) Handles TimerDiarioEspera.Tick
        TimerDiarioEspera.Stop()
        'Dim params As New List(Of String)
        'params.Add(SesionActual.idUsuario)
        'Label3.Text = General.getValorConsulta(Consultas.MENSAJE_DIARIO, params)
        'TimerDiario.Start()
    End Sub
    Private Sub ConsultarNotaAuditoriaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim formNotaAuditoria As New FormNotaAuditoria
        formNotaAuditoria.MdiParent = Me
        formNotaAuditoria.Show()
        formNotaAuditoria.Focus()
    End Sub

    Private Sub Textnombre_completo_Click(sender As Object, e As EventArgs) Handles Textnombre_completo.Click
        Dim formInterconsulta As New FormListadoInterconsula
        formInterconsulta.MdiParent = Me
        formInterconsulta.Show()
        formInterconsulta.Focus()
    End Sub

    Private Sub Timer_CerraxInactividad_Tick(sender As Object, e As EventArgs) Handles Timer_CerraxInactividad.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalMinutes > 15) Then
            Timer_CerraxInactividad.Stop()
            If MsgBox("Se Cerrará la Aplicación por inactividad en el equipo", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Cerrar Sesión") = 1 Then
                If (SesionActual.codigoPerfil = Constantes.AMBUQ Or SesionActual.codigoPerfil = Constantes.COMFACOR Or SesionActual.codigoPerfil = Constantes.NUEVA_EPS) AndAlso
                cnxion.State = ConnectionState.Open Then
                    Dim objPrincipal As New Principal
                    objPrincipal.codigoEntrada = codigoEntrada
                    PrincipalDAL.salidaAuditorExterno(objPrincipal)
                End If
                End
            End If
        End If
    End Sub
    Private Sub FormNotaAuditoria_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.PrintScreen Then
            Dim Imagen As Bitmap = RecorteImagen.capturarPantalla(Me)
            If Imagen Is Nothing Then Return
            Clipboard.SetDataObject(Imagen)
        End If
    End Sub

End Class



