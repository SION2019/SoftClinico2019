Imports System.Net
Imports System.Net.Mail
Public Class FormCorreoElectronico
    Private correos As New MailMessage
    Private envios As New SmtpClient
    Private Sub btEnviar_Click(sender As Object, e As EventArgs) Handles btEnviar.Click
        Try
            correos.To.Clear()
            correos.Body = ""
            correos.Subject = ""
            correos.Body = txtmensaje.Text
            correos.Subject = txtasunto.Text
            correos.IsBodyHtml = True
            correos.To.Add(Trim(txtdestinario.Text))

            If txtruta.Text <> "" Then
                Dim archivo As Net.Mail.Attachment = New Net.Mail.Attachment(txtruta.Text)
                correos.Attachments.Add(archivo)
            End If

            correos.From = New MailAddress(txtemisor.Text)
            envios.Credentials = New NetworkCredential(txtemisor.Text, txtPass.Text)

            'Datos importantes no modificables para tener acceso a las cuentas


            envios.Host = "smtp.live.com"
            envios.Port = 25
            envios.EnableSsl = True


            envios.Send(correos)
            MsgBox("El mensaje fue enviado correctamente. ", MsgBoxStyle.Information, "Mensaje")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensajeria 1.0 vb.net ®", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub limpiarControles()
        txtemisor.Clear()
        txtPass.Clear()
        txtasunto.Clear()
        txtmensaje.Clear()
        txtruta.Clear()
        Btbuscar.Enabled = False
    End Sub
    Private Sub Btbuscar_Click(sender As Object, e As EventArgs) Handles Btbuscar.Click
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then
                txtruta.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormCorreoElectronico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtemisor_TextChanged(sender As Object, e As EventArgs) Handles txtemisor.TextChanged
        If Not String.IsNullOrEmpty(txtemisor.Text) Then
            txtPass.ReadOnly = False
        Else
            txtPass.ReadOnly = True
        End If
    End Sub

    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged
        If Not String.IsNullOrEmpty(txtPass.Text) Then
            txtdestinario.ReadOnly = False
        Else
            txtdestinario.ReadOnly = True
        End If
    End Sub

    Private Sub txtdestinario_TextChanged(sender As Object, e As EventArgs) Handles txtdestinario.TextChanged
        If Not String.IsNullOrEmpty(txtdestinario.Text) Then
            txtasunto.ReadOnly = False
            Btbuscar.Enabled = True
            txtmensaje.ReadOnly = False
        Else
            txtasunto.ReadOnly = True
            Btbuscar.Enabled = False
            txtmensaje.ReadOnly = True
        End If
    End Sub
End Class