Public Class FormCambiarClave
    Dim objClave As New CambiarClave
    Private Sub FormCambiarClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SesionActual.idUsuario = 0 Then
            txtContrasenaActual.ReadOnly = True
            txtcontrasenaNueva.ReadOnly = True
            contraconfirmar.ReadOnly = True
            btguardar.Enabled = False
            Exit Sub
        End If

        txtusuario.Text = SesionActual.usuario
        General.cargarImagen(SesionActual.usuario, SesionActual.idEmpresa, foto)
    End Sub

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txtContrasenaActual.Leave
        objClave.contrasenaActual = txtContrasenaActual.Text
        If String.IsNullOrEmpty(objClave.contrasenaActual) Then Exit Sub
        If Not objClave.verificarContrasena() Then

            MsgBox("Contraseña incorrecta", MsgBoxStyle.Exclamation)
            txtContrasenaActual.Focus()
            erroractual.Visible = True
            erroractual.Image = My.Resources.borrartxt1

            txtContrasenaActual.ResetText()

        Else
            erroractual.Visible = True
            erroractual.Image = My.Resources.OK
            txtContrasenaActual.ReadOnly = True
        End If

    End Sub

    Private Sub FormCambiarClave_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub txtcontrasenaNueva_Leave(sender As Object, e As EventArgs) Handles txtcontrasenaNueva.Leave
        If String.IsNullOrEmpty(txtcontrasenaNueva.Text) Then Exit Sub
        If txtcontrasenaNueva.Text = txtContrasenaActual.Text Then
            MsgBox("Esta contraseña no puede ser igual a la actual", MsgBoxStyle.Exclamation)
            txtcontrasenaNueva.ResetText()
            txtcontrasenaNueva.Focus()
            nuevo.Visible = True
            nuevo.Image = My.Resources.borrartxt1
        ElseIf txtcontrasenaNueva.Text = "" Then
            MsgBox("Digite una nueva contraseña", MsgBoxStyle.Exclamation)
            txtcontrasenaNueva.Focus()
            nuevo.Visible = True
        ElseIf (txtcontrasenaNueva.Text.Length < 4 Or txtcontrasenaNueva.Text.Length > 15) Then
            MsgBox("¡ Por favor digite una contraseña de usuario válida (entre 6-15 caracteres)!", MsgBoxStyle.Exclamation)
            nuevo.Visible = True
            txtcontrasenaNueva.Focus()

        Else
            nuevo.Visible = True
            nuevo.Image = My.Resources.OK
        End If
    End Sub


    Public Function validarControles()
        objClave.contrasenaActual = txtContrasenaActual.Text
        If Not objClave.verificarContrasena() Then
            MsgBox("Contraseña incorrecta", MsgBoxStyle.Exclamation)
            erroractual.Visible = True
            erroractual.Image = My.Resources.borrartxt1
            txtContrasenaActual.ResetText()
            txtContrasenaActual.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(contraconfirmar.Text) Then
            MsgBox("Confirme su contraseña", MsgBoxStyle.Exclamation)
            contraconfirmar.Focus()
            Return False
        ElseIf contraconfirmar.Text <> txtcontrasenaNueva.Text Then
            MsgBox("La contraseña no coinciden", MsgBoxStyle.Exclamation)
            contraconfirmar.ResetText()
            confirmar.Visible = True
            contraconfirmar.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtcontrasenaNueva.Text) Then
            MsgBox("Digite su contraseña nueva", MsgBoxStyle.Exclamation)
            txtcontrasenaNueva.Focus()
            Return False
        Else
            confirmar.Image = My.Resources.OK
            confirmar.Visible = True
        End If
        Return True
    End Function

    Public Sub guardar()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objClave.nombreUsuario = SesionActual.idUsuario
                objClave.contrasenaConfirmar = contraconfirmar.Text
                objClave.guardarClave()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                txtContrasenaActual.Focus()
                txtContrasenaActual.ReadOnly = False
                nuevo.Visible = False
                confirmar.Visible = False
                erroractual.Visible = False
                txtContrasenaActual.Clear()
                txtcontrasenaNueva.Clear()
                erroractual.Visible = False
                contraconfirmar.Clear()
            End If
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarControles() Then
            guardar()
        End If
    End Sub

    Private Sub txtcontrasenaNueva_TextChanged(sender As Object, e As EventArgs) Handles txtcontrasenaNueva.TextChanged
        If txtcontrasenaNueva.Text = "" Then
            nuevo.Visible = False
        End If
    End Sub

End Class