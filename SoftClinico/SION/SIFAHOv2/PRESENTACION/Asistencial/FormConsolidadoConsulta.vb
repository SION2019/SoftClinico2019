Public Class FormConsolidadoConsulta
    Dim idEmpleado As Integer
    Dim dgvAsignada As New BindingSource
    Private Sub FormConsolidadoConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thisDay As DateTime = DateTime.Today
        dtInicio.Value = thisDay.ToString("d")
        dtFin.Value = thisDay.ToString("d")
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','" & Constantes.VALOR_PREDETERMINADO & "',''", "Descripción", "Código", cmbAreaServicio)
        Dim dtNuevo As DataTable
        dtNuevo = cmbAreaServicio.DataSource.copy
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        cmbAreaServicio.DataSource = dtNuevo
    End Sub
    Private Function seleccionarItemCombobox()
        If cmbAreaServicio.SelectedIndex <= 0 Then
            dgvConsolidado.DataSource = Nothing
            LblNumero.Text = 0
        Else
            Return True
        End If
        Return False
    End Function
    Private Sub Comboentorno_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbAreaServicio.SelectedValueChanged
        textBusqueda.ResetText()
        If seleccionarItemCombobox() Then
            If rbGeneral.Checked = True Then
                llenarDatosGeneral(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value, idEmpleado)
            Else
                llenarDatosConsolidado(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value)
            End If
        End If
    End Sub
    Private Sub btBusquedaEmpleado_Click(sender As Object, e As EventArgs) Handles btBusquedaEmpleado.Click
        Dim tblEmpleado As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_ADMISIONISTA & "," & Constantes.CARGO_AUXILIAR_DE_FARMACIA & "," _
            & Constantes.CARGO_JEFE_DE_ENFERMERIA & "," & Constantes.CARGO_ADMISIONISTA_AUXILIAR)
        params.Add(SesionActual.idEmpresa)
        params.Add(String.Empty)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.CARGOS_EMPLEADOS_LISTAR, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True, False, True)
        tblEmpleado = formBusqueda.rowResultados
        If tblEmpleado IsNot Nothing Then
            idEmpleado = tblEmpleado(0)
            txtEmpleado.Text = tblEmpleado(1)
            lbQuitar.Visible = True
        End If

        If seleccionarItemCombobox() Then
            llenarDatosGeneral(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value, idEmpleado)
        End If
    End Sub
    Private Sub TextBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles textBusqueda.TextChanged
        If seleccionarItemCombobox() Then
            If rbGeneral.Checked = True Then
                dgvAsignada.Filter = "[Paciente] LIKE '%" + textBusqueda.Text.Trim() + "%'"
            Else
                dgvAsignada.Filter = "[Responsable] LIKE '%" + textBusqueda.Text.Trim() + "%'"
            End If
        End If
    End Sub
    Private Sub llenarDatosGeneral(servicio As Integer, fechaInicio As Date, fechaFin As Date, idEmpleado As Integer)
        Dim dtConsultaGeneral As New DataTable
        Dim params As New List(Of String)
        params.Add(servicio)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(idEmpleado)
        General.llenarTabla(Consultas.CONSOLIDADO_DE_CONSULTAS_POR_PACIENTE, params, dtConsultaGeneral)
        dgvConsolidado.DataSource = dtConsultaGeneral
        dgvAsignada.DataSource = dtConsultaGeneral
        LblCantidad.Text = "Total Admisiones"
        LblNumero.Text = dtConsultaGeneral.Rows.Count
        If dtConsultaGeneral.Rows.Count > 0 Then
            With dgvConsolidado
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            General.diseñoDGV(dgvConsolidado)
        End If
    End Sub
    Private Sub dgvFactura_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvConsolidado.CellFormatting
        If e.ColumnIndex = 3 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
        If e.ColumnIndex = 1 And rbConsolidado.Checked = True Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub
    Private Sub lbQuitar_Click(sender As Object, e As EventArgs) Handles lbQuitar.Click
        lbQuitar.Visible = False
        idEmpleado = Nothing
        txtEmpleado.Text = ""
        If seleccionarItemCombobox() Then
            llenarDatosGeneral(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value, idEmpleado)
        End If
    End Sub
    Private Sub llenarDatosConsolidado(servicio As Integer, fechaInicio As Date, fechaFin As Date)
        Dim dtConsultaConsolidado As New DataTable
        Dim params As New List(Of String)
        params.Add(servicio)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        General.llenarTabla(Consultas.CONSOLIDADO_DE_CONSULTAS, params, dtConsultaConsolidado)
        dgvConsolidado.DataSource = dtConsultaConsolidado
        dgvAsignada.DataSource = dtConsultaConsolidado
        LblCantidad.Text = "Valor total"
        LblNumero.Text = dtConsultaConsolidado.Compute("Sum([Valor Consulta])", "").ToString
        If dtConsultaConsolidado.Rows.Count > 0 Then
            With dgvConsolidado
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            General.diseñoDGV(dgvConsolidado)
        End If
    End Sub
    Private Sub rbConsolidado_CheckedChanged(sender As Object, e As EventArgs) Handles rbConsolidado.CheckedChanged
        If rbConsolidado.Checked = True Then
            If cmbAreaServicio.SelectedIndex > 0 Then
                llenarDatosConsolidado(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value)
            End If
            txtEmpleado.Visible = False
            btBusquedaEmpleado.Visible = False
            lblFiltro.Text = "Filtro Empleado"
        End If
    End Sub
    Private Sub rbGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rbGeneral.CheckedChanged
        If rbGeneral.Checked = True Then
            txtEmpleado.Visible = True
            btBusquedaEmpleado.Visible = True
            lblFiltro.Text = "Filtro Paciente"
            If cmbAreaServicio.SelectedIndex > 0 Then
                llenarDatosGeneral(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value, idEmpleado)
            End If
        End If
    End Sub

    Private Sub dtInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio.ValueChanged
        If seleccionarItemCombobox() Then
            llenarDatosGeneral(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value, idEmpleado)
        End If
    End Sub
    Private Sub dtFin_ValueChanged(sender As Object, e As EventArgs) Handles dtFin.ValueChanged
        If seleccionarItemCombobox() Then
            llenarDatosGeneral(cmbAreaServicio.SelectedValue, dtInicio.Value, dtFin.Value, idEmpleado)
        End If
    End Sub
End Class