Public Class FormProgramacionCitaMedica
    Dim objProgramCita As ProgramacionCitaMedica
    Dim objProgramacionCitaBLL As New ProgramacionCitaMedicaBLL
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormProgramacionCitaMedica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProgramCita = New ProgramacionCitaMedica
        Try
            cargarHorarioCita()
            objProgramacionCitaBLL.cargarComboVista(comboAreaServicio)
            objProgramacionCitaBLL.SiglaDias(CDate(dFecha.Value.Date), objProgramCita, dgvHorarioCita)
            contenedorPrincipal.Panel2Collapsed = True
            cargarDatosCitas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub cargarHorarioCita()
        objProgramacionCitaBLL.cargarHorarioCita(dgvHorarioCita, Convert.ToDateTime(dFecha.Value), objProgramCita)
    End Sub
    Public Sub cargarHorarioCitaDetalle()
        objProgramacionCitaBLL.cargarHorarioCitaDetalle(dgDetalles, calendarioMes.SelectionStart, objProgramCita)
    End Sub
    Private Sub cargarDatosCitas()
        Dim dtDatos As New DataTable
        If Not IsNothing(objProgramCita) And Not String.IsNullOrEmpty(comboAreaServicio.ValueMember) Then
            dtDatos = objProgramacionCitaBLL.cargarHorarioCitaDatos(CDate(dFecha.Value).Date,
                                                                        objProgramCita,
                                                                        comboAreaServicio.SelectedValue)
            tsConteoPendiente.Text = dtDatos.Rows(0).Item("Pendientes")
            tsConteoCancelado.Text = dtDatos.Rows(0).Item("Cancelados")
            tsConteoRealizado.Text = dtDatos.Rows(0).Item("Realizados")
        End If
    End Sub
    Private Sub dgvHorarioCita_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvHorarioCita.RowPostPaint
        Using Pinceles As New SolidBrush(dgvHorarioCita.RowHeadersDefaultCellStyle.ForeColor)
            Dim nombre As String
            nombre = objProgramCita.dtProgramCita.Rows(e.RowIndex).Item("Hora")
            e.Graphics.DrawString(nombre,
                                  dgvHorarioCita.Rows(e.RowIndex).Cells(0).InheritedStyle.Font,
                                  Pinceles, e.RowBounds.Location.X + 14,
                                  e.RowBounds.Location.Y + 4)

        End Using
    End Sub
    Private Sub dgvHorarioCita_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorarioCita.CellDoubleClick
        'Dim formCitaMedica As New FormCitaMedica

        'If validaciones(e.ColumnIndex) = True Then
        '    MsgBox("¡Fecha no hábil para dar citas!", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If

        'formCitaMedica.objFormularioProgram = Me
        'formCitaMedica.fechaHora = FechaModificada()
        'formCitaMedica.ShowDialog()
    End Sub
    Private Function validaciones(e As Integer) As Boolean
        Dim bandera As Boolean
        Dim fecha As Date = FechaModificada()
        If fecha < CDate(Funciones.Fecha(23)) Then
            bandera = True
        ElseIf dgvHorarioCita.Columns(e).HeaderCell.Style.ForeColor = Color.Red Then
            bandera = True
        End If
        Return bandera
    End Function
    Private Function FechaModificada() As DateTime
        Dim hora As Integer
        Dim dia As Byte
        Dim fechaModific As DateTime
        dia = objProgramacionCitaBLL.extraeNumero(dgvHorarioCita.Columns(dgvHorarioCita.CurrentCell.ColumnIndex).HeaderText)
        hora = dgvHorarioCita.Rows(dgvHorarioCita.CurrentCell.RowIndex).Cells("Hora").Value
        fechaModific = Convert.ToDateTime(dFecha.Value)
        fechaModific = fechaModific.AddDays(-fechaModific.Day).AddDays(dia)
        fechaModific = fechaModific.AddHours(-fechaModific.Hour).AddHours(hora)
        Return fechaModific
    End Function
    Private Sub comboAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedIndexChanged
        Try
            objProgramacionCitaBLL.cargarModoVista(objProgramCita, comboAreaServicio, Convert.ToDateTime(dFecha.Value), dgvHorarioCita)
            cargarDatosCitas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btSiguiente_Click(sender As Object, e As EventArgs) Handles btSiguiente.Click
        Try
            objProgramacionCitaBLL.verificarVistaSelec(+1, comboAreaServicio, Convert.ToDateTime(dFecha.Value), objProgramCita, dgvHorarioCita)
            cargarDatosCitas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btAnterior_Click(sender As Object, e As EventArgs) Handles btAnterior.Click
        Try
            objProgramacionCitaBLL.verificarVistaSelec(+1, comboAreaServicio, Convert.ToDateTime(dFecha.Value), objProgramCita, dgvHorarioCita)
            cargarDatosCitas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dFecha_ValueChanged(sender As Object, e As EventArgs) Handles dFecha.ValueChanged
        Try
            objProgramacionCitaBLL.cargarModoVista(objProgramCita, comboAreaServicio, Convert.ToDateTime(dFecha.Value), dgvHorarioCita)
            cargarDatosCitas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvHorarioCita_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvHorarioCita.CellFormatting
        If objProgramCita.dtProgramCita.Rows.Count > 0 Then
            If Not IsDBNull(objProgramCita.dtProgramCita.Rows(e.RowIndex).Item(e.ColumnIndex)) Then
                objProgramacionCitaBLL.validarColores(dgvHorarioCita, e.RowIndex, e.ColumnIndex, objProgramCita)
            End If
        End If
    End Sub
    Private Sub chDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles chDetalle.CheckedChanged
        If chDetalle.Checked = True Then
            contenedorPrincipal.Panel2Collapsed = False
            calendarioMes.SelectionStart = dFecha.Value
            objProgramacionCitaBLL.cargarHorarioCitaDetalle(dgDetalles, calendarioMes.SelectionStart, objProgramCita)
        Else
            contenedorPrincipal.Panel2Collapsed = True
        End If
    End Sub
    Private Sub calendarioMes_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calendarioMes.DateChanged
        objProgramacionCitaBLL.cargarHorarioCitaDetalle(dgDetalles, calendarioMes.SelectionStart, objProgramCita)
    End Sub
    Private Sub dgDetalles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetalles.CellClick
        'Dim formCitaMedica As FormCitaMedica
        'If objProgramCita.dtProgramCitaDetalle.Rows.Count > 0 Then
        '    If e.ColumnIndex = 0 Then
        '        formCitaMedica = New FormCitaMedica
        '        formCitaMedica.bandera = True
        '        formCitaMedica.objFormularioProgram = Me
        '        formCitaMedica.cargarPaciente(dgDetalles.Rows(dgDetalles.CurrentCell.RowIndex).Cells("Codigo_Cita").Value)
        '        formCitaMedica.ShowDialog()
        '    End If
        'End If
    End Sub
End Class