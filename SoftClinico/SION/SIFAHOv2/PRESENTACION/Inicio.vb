Imports System.Net
Imports System.IO
Imports System.Security
Imports System.Net.NetworkInformation
Imports System.Data.SqlClient
Imports sifahosys
Imports System.Threading
Public Class Inicio

    Public nombre_servidor As String
    Public servidor As String
    Public num_version As String
    Public version_actu As String
    Dim conta As Integer = 0
    Public bndra As Boolean
    Dim inicioc As InicioDAL
    Private Sub cargarImagen()
        PrincipalDAL.cargarLogoFormulario()
    End Sub
    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SesionActual.cargarError()

        Version.Text = String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Copyright.Text = "Copyright © Celer - Medical Soft."

        conectarServidor()
        Timer1.Start()
    End Sub

    Private Sub limpiarTemporales()
        Dim aplicacioncorriendo As Process() = Process.GetProcessesByName("celer")

        If aplicacioncorriendo.Length > 1 Then Exit Sub
        Dim temporales As String
        temporales = Path.GetTempPath
        For Each item As String In Directory.GetFiles(temporales)
            Try
                File.Delete(item)
            Catch ex As Exception
            End Try
        Next
        For Each item As String In Directory.GetDirectories(temporales)
            Try
                My.Computer.FileSystem.DeleteDirectory(item, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        conectarServidor()
    End Sub

    Public Function verificarConexion(nombreServidor As String) As Boolean
        Dim MyPing As New System.Net.NetworkInformation.Ping
        Dim Myreply As System.Net.NetworkInformation.PingReply

        If My.Computer.Network.IsAvailable = False Then
            Return False
        Else
            'Equipos que trabajan fuera de la red local de la UCI
            Try
                Myreply = MyPing.Send(nombreServidor)
            Catch
                Return False
            End Try
        End If

        Return True

    End Function

    Private Sub conectarServidor()
        'esto se debe cambiar a futuro
        'If verificarConexion("192.168.1.5") Then
        Try
            conectar()
        Catch ex As Exception
            General.manejoErrores(ex)
            Me.Close()
        End Try

        'Else
        'MsgBox("No es posible conectarse con alguno de los servidores de SIFAHO. ¿Desea intentar nuevamente?", MsgBoxStyle.Critical)
        'Me.Close()
        ' End If

    End Sub

    Public Sub conectar()
        Dim ProcesosLocales As Process() = Process.GetProcessesByName("sifaho")
        InicioSesion.Show()
        GeneralHC.cargarHT()
        Me.Visible = False
    End Sub
    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

    Sub guardarImagen(ByVal bmp As Bitmap, nombreImagen As String)
        Dim ruta As String
        ruta = Directory.GetCurrentDirectory() & nombreImagen 'Ruta donde guardaremos la imagen
        bmp.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg) 'Guardamos la imagen
    End Sub

    Sub aplicarFondo(ruta As String)
        Try
            Dim SPI_SETDESKWALLPAPER As Integer = 20
            Dim SPIF_UPDATEINIFILE As Integer = 1
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, ruta, 0)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

End Class