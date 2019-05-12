Public Class CitaMes
    Inherits CitaPrevia
    Property dia As String
    Property nombreFecha As String
    Property fechaActual As String
    Private nombre As String
    Private complemento As String
    Private idCita As Integer
    Private incrementoLabel As Integer

    Public Sub New()
        anchura = 176
        altura = 75
        incrementoLabel = 17 '--- incremento label vertical
    End Sub
    Public Function crearPanelMes(posicionPanelY As Integer,
                                  posicionPanelX As Integer,
                                  dt() As DataRow,
                                  fila As DataTable) As Panel
        Dim panel As New Panel
        Try
            panel.Location = New Point(posicionPanelX, posicionPanelY)
            panel.Size = New Point(anchura, altura)
            panel.AutoScroll = True
            panel.BorderStyle = BorderStyle.FixedSingle
            panel.Name = nombreFecha
            panel.Controls.Add(crearEtiquetaMes(fila.Select(" DiaF='" & CInt(dia) & "'"), panel))
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
    Public Function crearEtiquetaMes(dtFestivo As DataRow(), panel As Panel) As Label
        Dim etiqueta As New Label
        Try
            etiqueta.Location = New Point(0, 0)
            etiqueta.Size = New Point(21, 15)
            etiqueta.BorderStyle = BorderStyle.FixedSingle
            etiqueta.BackColor = Control.DefaultBackColor
            If dtFestivo.Count > 0 Then
                If CInt(dia) = dtFestivo(0).Item("DiaF") Then
                    etiqueta.ForeColor = Color.Red
                    panel.BackColor = Control.DefaultBackColor
                End If
            End If
            etiqueta.Text = dia
        Catch ex As Exception
            Throw ex
        End Try
        Return etiqueta
    End Function
    Private Function crearEtiquetaMesRegistro(posicionLabelY As Integer) As Label
        Dim etiqueta As New Label
        Dim mensaje As New ToolTip
        Try
            etiqueta.Location = New Point(2, posicionLabelY)
            etiqueta.Size = New Point(154, 15)
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
        Try
            contador = incrementoLabel
            For fil = 0 To dt.Count - 1
                idCita = dt(fil).Item("codigo_cita")
                nombre = dt(fil).Item("Hora") & " - " & dt(fil).Item("paciente")
                complemento = "Fecha: " & dt(fil).Item("Fecha_cita") & " - #" & dt(fil).Item("Documento_Paciente") & " - " & dt(fil).Item("paciente")
                estado = dt(fil).Item("Estado_Atencion")
                panel.Controls.Add(crearEtiquetaMesRegistro(contador))
                contador = contador + incrementoLabel
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
