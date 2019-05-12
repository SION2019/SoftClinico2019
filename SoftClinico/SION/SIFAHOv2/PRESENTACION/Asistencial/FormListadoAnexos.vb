Public Class FormListadoAnexos
    Dim dtAnexo As New DataTable
    Dim opcion As Integer
    Dim codigoProceInterconsulta As String
    Dim dgvAsignada As New BindingSource

    Private Sub FormListadoAnexos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thisDay As DateTime = DateTime.Today
        fechaInicio.Value = thisDay.ToString("d")
        fechaFin.Value = thisDay.ToString("d")
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','" & Constantes.VALOR_PREDETERMINADO & "',''", "Descripción", "Código", cmbAreaServicio)
        Dim dtNuevo As DataTable
        dtNuevo = cmbAreaServicio.DataSource.copy
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        cmbAreaServicio.DataSource = dtNuevo
        llenarComboAnexo()
        dgvAnexos.Columns("dgEnviar").Visible = False
    End Sub
    Private Sub llenarComboAnexo()
        Dim dtComboAnexo As New DataTable
        dtComboAnexo.Columns.Add("Codigo")
        dtComboAnexo.Columns.Add("Nombre")
        dtComboAnexo.Rows.Add()
        dtComboAnexo.Rows(0).Item("Codigo") = -1
        dtComboAnexo.Rows(0).Item("Nombre") = "Todos"
        dtComboAnexo.Rows.Add()
        dtComboAnexo.Rows(1).Item("Codigo") = "1"
        dtComboAnexo.Rows(1).Item("Nombre") = "Anexo 2"
        dtComboAnexo.Rows.Add()
        dtComboAnexo.Rows(2).Item("Codigo") = "2"
        dtComboAnexo.Rows(2).Item("Nombre") = "Anexo 3"
        dtComboAnexo.Rows.Add()
        dtComboAnexo.Rows(3).Item("Codigo") = "3"
        dtComboAnexo.Rows(3).Item("Nombre") = "Anexo 9"
        ComboAnexo.Items.Clear()
        ComboAnexo.DataSource = Nothing
        ComboAnexo.DataSource = dtComboAnexo
        ComboAnexo.DisplayMember = "Nombre"
        ComboAnexo.ValueMember = "Codigo"
    End Sub

    Private Function seleccionarItemCombobox()
        If cmbAreaServicio.SelectedIndex <= 0 Then
            dgvAnexos.DataSource = Nothing
        Else
            Return True
        End If
        Return False
    End Function

    Private Sub TextBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles textBusqueda.TextChanged
        If seleccionarItemCombobox() Then
            dgvAsignada.Filter = "[Paciente] LIKE '%" + textBusqueda.Text.Trim() + "%'"
        End If
    End Sub
    Private Sub rbRealizados_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbRealizados.CheckedChanged
        If rbRealizados.Checked = True Then
            opcion = 0
        End If
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, opcion)
        End If
    End Sub
    Private Sub rbPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPendientes.CheckedChanged
        If rbPendientes.Checked = True Then
            opcion = 1
        End If
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, opcion)
        End If
    End Sub


    Private Sub llenardgv(servicio As Integer, fechaInicio As Date, fechaFin As Date, opcion As Integer)
        Dim params As New List(Of String)
        params.Add(servicio)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(opcion)
        params.Add(ComboAnexo.SelectedValue)
        'General.llenarTabla(Consultas.ANEXOS_LISTAR, params, dtAnexo)
        dgvAnexos.DataSource = dtAnexo
        dgvAsignada.DataSource = dtAnexo

        If dtAnexo.Rows.Count > 0 Then
            With dgvAnexos
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).Width = 60
                .Columns(3).Width = 70
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(7).Width = 70
                .Columns(6).Width = 500
                .Columns(8).Visible = False
                If rbRealizados.Checked = True Then
                    .Columns("dgEnviar").Visible = False
                Else
                    .Columns("dgEnviar").Visible = True
                End If
            End With
            General.diseñoDGV(dgvAnexos)
            dgvAnexos.Columns("dgEnviar").DisplayIndex = CInt(dgvAnexos.ColumnCount - 1)
        End If
    End Sub

    Private Sub btGenerar_Click(sender As Object, e As EventArgs) Handles btGenerar.Click
        textBusqueda.ResetText()
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, opcion)
        End If
    End Sub

    Private Sub dgvAnexos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnexos.CellDoubleClick
        Dim admision As New FormAdmision
        If dgvAnexos.RowCount > 0 Then
            Admision.Show()
            Admision.cargarAdmision(dgvAnexos.Rows(dgvAnexos.CurrentRow.Index).Cells(3).Value)
        End If
    End Sub
End Class