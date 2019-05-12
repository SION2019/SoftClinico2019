Public Class CitaSemana
    Inherits CitaPrevia
    Property fechaActual As String
    Private nombre As String
    Private complemento As String
    Private idCita As Integer
    Private complementoEtiqueta As String
    Property nombreHora As String
    Property nombreFecha As String
    Property dia As String
    Private incrementoLabel As Integer
    Public Sub New()
        altura = 78
        anchura = 164
        incrementoLabel = 19
    End Sub
    Public Function crearPanelSemana(posicionPanelX As Integer,
                                   posicionPanelY As Integer,
                                    dt() As DataRow) As Panel
        Dim panel As New Panel
        Try
            panel.Location = New Point(posicionPanelX, posicionPanelY)
            panel.Size = New Point(anchura, altura)
            panel.BorderStyle = BorderStyle.FixedSingle
            panel.AutoScroll = True
            If nombreFecha = fechaActual Then
                armarEtiqueta(dt, panel)
            Else
                panel.BackColor = Control.DefaultBackColor
            End If
            AddHandler panel.DoubleClick, AddressOf UtlidadCitaBLL.llamarFormularioCita
            panel.Show()
        Catch ex As Exception
            Throw ex
        End Try
        Return panel
    End Function
    Private Function crearEtiquetaSemana(posicionLabelY) As Label
        Dim etiqueta As New Label
        Dim mensaje As New ToolTip
        Try
            etiqueta.Location = New Point(1, posicionLabelY)
            etiqueta.Size = New Point(142, 17)
            etiqueta.BorderStyle = BorderStyle.FixedSingle
            etiqueta.BackColor = colorLabel()
            etiqueta.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 6, FontStyle.Bold)
            etiqueta.Text = nombre
            etiqueta.Tag = idCita
            AddHandler etiqueta.DoubleClick, AddressOf UtlidadCitaBLL.llamarFormularioCita
            mensaje.SetToolTip(etiqueta, complemento)
        Catch ex As Exception
            Throw ex
        End Try
        Return etiqueta
    End Function
    Private Sub armarEtiqueta(dt As DataRow(), panel As Panel)
        Dim contador As Integer
        contador = 1 '... Posicion Inicial 
        Try
            For fil = 0 To dt.Count - 1
                idCita = dt(fil).Item("codigo_cita")
                nombre = dt(fil).Item("Hora") & " - " & dt(fil).Item("paciente")
                complemento = "Fecha: " & dt(fil).Item("Fecha_cita") & " - #" & dt(fil).Item("Documento_Paciente") & " - " & vbNewLine &
                               dt(fil).Item("paciente") & " - " & vbNewLine & dt(fil).Item("procedimientos")
                estado = dt(fil).Item("Estado_Atencion")
                panel.Controls.Add(crearEtiquetaSemana(contador))
                contador = contador + incrementoLabel
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
