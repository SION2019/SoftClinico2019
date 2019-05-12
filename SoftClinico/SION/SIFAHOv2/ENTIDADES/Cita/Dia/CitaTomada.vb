Public Class CitaTomada
    Inherits CitaPrevia
    Property idCita As String
    Property nombre As String
    Property cedula As String
    Property fechaCita As DateTime
    Public Sub New()
        altura = Constantes.ALTURA_CITA_TOMADA
        anchura = Constantes.ANCHURA_CITA_TOMADA
    End Sub
    Public Function crearPanel(posicionX As Integer,
                          posicionY As Integer,
                               pendiente As Integer) As Panel
        Dim panel As New Panel
        Try
            panel.Location = New Point(posicionX, posicionY)
            panel.Size = New Point(anchura, altura)
            panel.BackColor = If(pendiente = Constantes.PENDIENTE, Control.DefaultBackColor, colorLabel())
            panel.Controls.Add(creaCajaTexto(4, 3, idCita, "Paciente: " & nombre & vbNewLine & " # " & cedula))
            panel.Controls.Add(creaCajaTexto(4, 36, idCita, "Fecha: " & CStr(fechaCita)))
            panel.Tag = hora & "-" & idCita
            panel.Cursor = Cursors.Hand
            panel.Show()
        Catch ex As Exception
            Throw ex
        End Try
        Return panel
    End Function
    Private Function creaCajaTexto(posicionX As Integer,
                                   posicionY As Integer,
                                   idCita As String, Texto As String) As TextBox
        Dim txtbox As New TextBox
        Try
            txtbox.BorderStyle = BorderStyle.None
            txtbox.Size = New Point(179, 29)
            txtbox.Location = New Point(posicionX, posicionY)
            txtbox.TextAlign = HorizontalAlignment.Center
            txtbox.BackColor = Color.White
            txtbox.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            txtbox.BorderStyle = BorderStyle.FixedSingle
            txtbox.Cursor = Cursors.Hand
            txtbox.Multiline = True
            txtbox.ReadOnly = True
            txtbox.Text = Texto
            txtbox.Tag = hora & "-" & idCita
            AddHandler txtbox.DoubleClick, AddressOf UtlidadCitaBLL.llamarFormularioCita
        Catch ex As Exception
            Throw ex
        End Try
        Return txtbox
    End Function
End Class
