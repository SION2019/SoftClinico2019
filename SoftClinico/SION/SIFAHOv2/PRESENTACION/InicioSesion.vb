Imports System.Data.SqlClient


Public Class InicioSesion
    Dim dt, dt2 As DataTable
    Dim id, cadenap As String
    Dim inicios As New InicioSesionDAL

    Private Sub ENTERKeyPress(ByVal s As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles Textusuario.KeyPress, Textcontraseña.KeyPress, Combopunto.KeyPress, ComboEmpresa.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Textusuario.Text = "" Then
                MsgBox("Digite el nombre de usuario", MsgBoxStyle.Information)
                limpiarFoto()
                Textusuario.Focus()
            ElseIf Textcontraseña.Text = "" Then
                MsgBox("Digite la contraseña", MsgBoxStyle.Information)
                Textcontraseña.Focus()
            ElseIf ComboEmpresa.SelectedIndex = 0 Then
                MsgBox("Elija Una empresa", MsgBoxStyle.Information)
                ComboEmpresa.Focus()
            ElseIf Combopunto.SelectedIndex = 0 Then
                MsgBox("Elija un punto de servicio", MsgBoxStyle.Information)
                Combopunto.Focus()
            Else
                Ok_Click(s, e)
            End If
        End If
    End Sub

    Private Sub textcontraseña_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textcontraseña.Enter
        Me.barraestadopp.Text = "Digite la Contraseña"
    End Sub

    Public Sub textusuario_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textusuario.Leave
        Timer1.Start()
    End Sub


    Private Sub Ok_Click(sender As Object, e As EventArgs) Handles Ok.Click

        If ComboEmpresa.SelectedIndex = 0 Then
            MsgBox("Elija una empresa", MsgBoxStyle.Information)
            ComboEmpresa.Focus()
        ElseIf Combopunto.SelectedIndex = 0 Then
            MsgBox("Elija un punto de la empresa", MsgBoxStyle.Information)
            Combopunto.Focus()
        ElseIf Textusuario.Text = "" Then
            MsgBox("Hace falta el usuario", MsgBoxStyle.Information)
            limpiarFoto()
            Textusuario.Focus()
        ElseIf Textcontraseña.Text = "" Then
            MsgBox("Hace falta la contraseña", MsgBoxStyle.Information)
            Textcontraseña.Focus()
        Else
            inicios.iniciarSesion(Textusuario.Text.Trim, Textcontraseña.Text.Trim)

        End If
    End Sub

    Private Sub CANCEL_Click_1(sender As Object, e As EventArgs) Handles CANCEL.Click
        Inicio.Close()
        Close()
        FormPrincipal.cnxion.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        dt = inicios.buscarEmpresasEmpleado(Textusuario.Text)
        If dt.Rows.Count > 1 Then
            ComboEmpresa.DataSource = dt
            ComboEmpresa.DisplayMember = "Razon_Social"
            ComboEmpresa.ValueMember = "Id_empresa"
            ComboEmpresa.SelectedIndex = 1
            General.cargarImagen(Textusuario.Text, ComboEmpresa.SelectedValue, foto)
        ElseIf Textusuario.Text <> "" Then
            Textusuario.ResetText()
            dt.Clear()
            MsgBox("Usuario No Existente", MsgBoxStyle.Information)
            Textusuario.Focus()
            limpiarFoto()
        End If

    End Sub
    Private Sub limpiarFoto()
        foto.Image = My.Resources.usuario
    End Sub

    Private Sub Textusuario_TextChanged(sender As Object, e As EventArgs) Handles Textusuario.TextChanged
        Textusuario.Text = Funciones.validarComillaSimple(Textusuario.Text)
    End Sub

    Private Sub Textcontraseña_TextChanged(sender As Object, e As EventArgs) Handles Textcontraseña.TextChanged
        Textcontraseña.Text = Funciones.validarComillaSimple(Textcontraseña.Text)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub ComboEmpresa_SelectedvalueChanged(sender As Object, e As EventArgs) Handles ComboEmpresa.SelectedValueChanged
        If (Textusuario.TextLength) <> 0 Then
            If ComboEmpresa.SelectedIndex = 0 Then
                Exit Sub
            Else
                dt2 = inicios.llenar_punto(ComboEmpresa.SelectedValue.ToString.Trim, Textusuario.Text)
            End If
            Combopunto.DataSource = dt2
            Combopunto.DisplayMember = "Nombre"
            Combopunto.ValueMember = "Codigo_EP"
            If dt2.Rows.Count > 1 Then
                Combopunto.SelectedIndex = 1
            End If
        End If

    End Sub

    Private Sub InicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SesionActual.cargarError()
        GeneralHC.cargarHT()

        Dim dt3 As DataTable
        dt3 = inicios.buscar_empresas()
        If dt3.Rows.Count = 0 Then
            MsgBox("ha ocurrido un error, por favor contáctese con el administrador", MsgBoxStyle.Critical)
            Inicio.Close()
            Close()
        ElseIf dt3.Rows.Count = 1 Then
            Hide()
            Bienvenido.Show()
        End If
    End Sub




End Class