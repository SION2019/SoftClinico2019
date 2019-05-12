Public Class FormEstadisticaNotasAuditoria
    Dim sw As Boolean = False
    Dim dgvAsignadaAutor, dgvAsignadaRespon As New BindingSource
    Private Sub FormEstadisticaNotasAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.cargarCombo(Consultas.NOTA_AUDITORIA_CARGOS_LISTAR, "Cargo", "Codigo", comboCargo, " - - - TODOS - - - ")
        fechaInicio.Value = Format(fechaInicio.Value, Constantes.FORMATO_FECHA_AÑO_MES) & "-01"
        llenardgv(txtBusqueda.Text, fechaInicio.Value, fechaFin.Value, comboCargo.SelectedValue)
        sw = True
    End Sub

    Private Sub rbCreador_CheckedChanged(sender As Object, e As EventArgs) Handles rbCreador.CheckedChanged
        txtBusqueda.ResetText()
        If rbCreador.Checked = True Then
            If sw = True Then
                llenardgv(txtBusqueda.Text, fechaInicio.Value, fechaFin.Value, comboCargo.SelectedValue)
            End If

            comboCargo.Visible = False
            lbCargo.Visible = False
        End If
    End Sub
    Private Sub dgvInformeNota_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvInformeNota.CellFormatting
        If e.ColumnIndex = 4 Then
            e.Value = Format(Val(e.Value) / 100, "P")
        End If
    End Sub
    Private Sub rbResponsable_CheckedChanged(sender As Object, e As EventArgs) Handles rbResponsable.CheckedChanged
        txtBusqueda.ResetText()
        If rbResponsable.Checked = True Then
            If sw = True Then
                llenardgv(txtBusqueda.Text, fechaInicio.Value, fechaFin.Value, comboCargo.SelectedValue)
            End If

            comboCargo.Visible = True
            lbCargo.Visible = True
        End If
    End Sub
    Private Sub TextBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBusqueda.TextChanged
        If rbCreador.Checked = True Then
            dgvAsignadaAutor.Filter = "[Autor] LIKE '%" + txtBusqueda.Text.Trim() + "%'"
        Else
            dgvAsignadaRespon.Filter = "[Responsable] LIKE '%" + txtBusqueda.Text.Trim() + "%'"
        End If
    End Sub
    Private Sub llenardgv(cadena As String, fechaInicio As Date, fechaFin As Date, cargo As Integer)
        Dim totalNotas, totalPacientes As Integer
        Dim promedioPaciente As Double
        Dim dtAutor, dtResponsable As New DataTable
        Dim consulta As String
        Dim params As New List(Of String)
        params.Add(txtBusqueda.Text)
        params.Add(Format(fechaInicio, Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(fechaFin, Constantes.FORMATO_FECHA_GEN))
        params.Add(comboCargo.SelectedValue)
        params.Add(SesionActual.codigoEP)
        txtBusqueda.ResetText()
        If rbCreador.Checked = True Then
            dgvInformeNota.DataSource = Nothing
            dgvAsignadaAutor.DataSource = Nothing
            consulta = Consultas.INFORME_NOTA_AUDITORIA_AUTORES
            General.llenarTabla(consulta, params, dtAutor)
            dgvInformeNota.DataSource = dtAutor
            dgvAsignadaAutor.DataSource = dtAutor
            dgvInformeNota.Columns("dgDetalle").DisplayIndex = CInt(dgvInformeNota.ColumnCount - 1)
            dgvInformeNota.Columns(1).Visible = False
            dgvInformeNota.Columns("totalNotas").Visible = False
            dgvInformeNota.Columns("TotalPacientes").Visible = False
            dgvInformeNota.Columns("PromedioPaciente").Visible = False
        Else
            dgvInformeNota.DataSource = Nothing
            dgvAsignadaRespon.DataSource = Nothing
            consulta = Consultas.INFORME_NOTA_AUDITORIA_RESPONSABLE
            General.llenarTabla(consulta, params, dtResponsable)
            dgvInformeNota.DataSource = dtResponsable
            dgvAsignadaRespon.DataSource = dtResponsable
            dgvInformeNota.Columns("dgDetalle").DisplayIndex = CInt(dgvInformeNota.ColumnCount - 1)
            dgvInformeNota.Columns(1).Visible = False
            dgvInformeNota.Columns("totalNotas").Visible = False
            dgvInformeNota.Columns("TotalPacientes").Visible = False
            dgvInformeNota.Columns("PromedioPaciente").Visible = False
        End If

        If dtAutor.Rows.Count > 0 Or dtResponsable.Rows.Count > 0 Then
            With dgvInformeNota
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Notas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Pacientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Promedio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("dgDetalle").Visible = True
                .Columns("Porcentaje").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Notas").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Pacientes").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Promedio").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            General.diseñoDGV(dgvInformeNota)
            totalNotas = dgvInformeNota.Rows(0).Cells("totalNotas").Value
            totalPacientes = dgvInformeNota.Rows(0).Cells("TotalPacientes").Value
            promedioPaciente = dgvInformeNota.Rows(0).Cells("PromedioPaciente").Value
            lbNotas.Text = "Total notas  " & totalNotas
            lbTotlPacientes.Text = "Total pacientes " & totalPacientes
            lbPromedio.Text = "Promedio de " & promedioPaciente & " notas por paciente"
        Else
            lbNotas.Text = ""
        End If
        dgvNotaAuditoria.DataSource = Nothing
        lbNombreResponsable.Visible = False
        dgvNotaAuditoria.Columns("dgVer").Visible = False
    End Sub

    Private Sub fechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles fechaInicio.ValueChanged
        If sw = True Then
            llenardgv(txtBusqueda.Text, fechaInicio.Value, fechaFin.Value, comboCargo.SelectedValue)
        End If
    End Sub

    Private Sub comboCargo_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboCargo.SelectedValueChanged
        If sw = True Then
            llenardgv(txtBusqueda.Text, fechaInicio.Value, fechaFin.Value, comboCargo.SelectedValue)
        End If
    End Sub

    Private Sub dgvInformeNota_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInformeNota.CellContentClick
        If dgvInformeNota.RowCount > 0 Then
            If e.ColumnIndex = 0 Then
                Cursor = Cursors.WaitCursor
                llenardgvDetalleNotas(dgvInformeNota.Rows(dgvInformeNota.CurrentRow.Index).Cells(1).Value)
                Button1.Visible = True
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub llenardgvDetalleNotas(idEmpleado As Integer)
        Dim dtAutorDetalle, dtResponsableDetalle As New DataTable
        Dim consulta As String
        Dim params As New List(Of String)
        params.Add(Format(fechaInicio.Value, Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(fechaFin.Value, Constantes.FORMATO_FECHA_GEN))
        params.Add(idEmpleado)
        params.Add(SesionActual.codigoEP)
        If rbCreador.Checked = True Then
            dgvNotaAuditoria.DataSource = Nothing
            dtAutorDetalle.Clear()
            consulta = Consultas.INFORME_NOTA_AUDITORIA_AUTORES_DETALLE
            General.llenarTabla(consulta, params, dtAutorDetalle)
            dgvNotaAuditoria.DataSource = dtAutorDetalle
            lbNombreResponsable.Text = "Notas realizadas por " & dgvInformeNota.Rows(dgvInformeNota.CurrentRow.Index).Cells(2).Value.ToString.ToLower
            dgvNotaAuditoria.Columns("dgVer").DisplayIndex = CInt(dgvNotaAuditoria.ColumnCount - 1)
        Else
            dgvNotaAuditoria.DataSource = Nothing
            dtResponsableDetalle.Clear()
            consulta = Consultas.INFORME_NOTA_AUDITORIA_RESPONSABLE_DETALLE
            General.llenarTabla(consulta, params, dtResponsableDetalle)
            dgvNotaAuditoria.DataSource = dtResponsableDetalle
            lbNombreResponsable.Text = "Notas dirigidas a " & dgvInformeNota.Rows(dgvInformeNota.CurrentRow.Index).Cells(2).Value.ToString.ToLower
            dgvNotaAuditoria.Columns("dgVer").DisplayIndex = CInt(dgvNotaAuditoria.ColumnCount - 1)
        End If

        With dgvNotaAuditoria
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(1).Visible = False
            .Columns(4).Visible = False
            .Columns("dgVer").Visible = True
        End With
        lbNombreResponsable.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dgvNotaAuditoria.DataSource = Nothing
        lbNombreResponsable.Visible = False
        dgvNotaAuditoria.Columns("dgVer").Visible = False
        Button1.Visible = False
    End Sub

    Private Sub fechaFin_ValueChanged(sender As Object, e As EventArgs) Handles fechaFin.ValueChanged
        If sw = True Then
            llenardgv(txtBusqueda.Text, fechaInicio.Value, fechaFin.Value, comboCargo.SelectedValue)
        End If
    End Sub

    Private Sub FormEstadisticaNotasAuditoria_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvNotaAuditoria_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotaAuditoria.CellContentClick
        If dgvNotaAuditoria.RowCount > 0 Then
            If e.ColumnIndex = 0 Then
                FormNotaAuditoria.sw = True
                FormNotaAuditoria.cargarPaciente(dgvNotaAuditoria.Rows(dgvNotaAuditoria.CurrentRow.Index).Cells(4).Value)
                FormNotaAuditoria.cargarDatos(dgvNotaAuditoria.Rows(dgvNotaAuditoria.CurrentRow.Index).Cells(1).Value)
                FormNotaAuditoria.ShowDialog()
            End If
        End If
    End Sub
End Class