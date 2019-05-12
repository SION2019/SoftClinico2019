Public Class FormCuerpoMedico
    Dim objCuerpoMedico As New CuerpoMedico
    Dim dtAux As DataTable
    Private Sub FormCuerpoMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objCuerpoMedico.registro = txtRegistro.Text
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        General.limpiarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", cmbCargo)
        enlazarDgvTarifasMedica()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Sub enlazarDgvTarifasMedica()
        With dgvTarifaMedica
            .Columns("CMCodigo").DataPropertyName = "Codigo"
            .Columns("CMProcedimiento").DataPropertyName = "Descripcion"
            .Columns("CMValor").DataPropertyName = "Valor"
            .AutoGenerateColumns = False
            .DataSource = objCuerpoMedico.dtCuerpoMedico
        End With
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            objCuerpoMedico.dtCuerpoMedico.Rows.Clear()
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.limpiarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btcancelar.Enabled = True
        cmbCargo.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim params As New List(Of String)
        params.Add(cmbCargo.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarEspecialista,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub cargarEspecialista(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            If (dw("Tercero").ToString) IsNot DBNull.Value Then
                txtEmpleado.Text = dw("Tercero").ToString()
                txtIdEmpleado.Text = dw("Id_tercero").ToString()
                If objCuerpoMedico.dtCuerpoMedico.Rows.Count = 0 Then
                    objCuerpoMedico.dtCuerpoMedico.Rows.Add()
                End If
                dgvTarifaMedica.ReadOnly = False
                btguardar.Enabled = True
            End If
        End Using
    End Sub

    Private Sub cmbCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCargo.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            txtEmpleado.Text = "-NO APLICA-"
            btnBuscar.Enabled = False
        Else
            btnBuscar.Enabled = True
        End If
    End Sub

    Private Sub dgvTarifaMedica_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTarifaMedica.CellDoubleClick
        Dim valCell As String
        valCell = dgvTarifaMedica.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Cells(dgvTarifaMedica.CurrentCell.ColumnIndex).Value.ToString
        If dgvTarifaMedica.ReadOnly = False And (String.IsNullOrWhiteSpace(valCell) Or valCell = "System.Drawing.Bitmap") Then
            If dgvTarifaMedica.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Cells("CMAnular").Selected = True AndAlso dgvTarifaMedica.CurrentCell.RowIndex <> dgvTarifaMedica.RowCount - 1 Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    dtAux.Rows(e.RowIndex).Item(3) = 1
                    dgvTarifaMedica.DataSource.Rows.RemoveAt(dgvTarifaMedica.CurrentCell.RowIndex)
                End If
            Else
                cargarProcedimientoH()
            End If
        End If
    End Sub
    Private Sub cargarProcedimientoH()
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(10)
        params.Add("")
        params.Add(objCuerpoMedico.registro)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objCuerpoMedico.sqlBuscarProcedimientoH, params, TitulosForm.BUSQUEDA_TARIFA_CUERPO_MEDICO, False)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objCuerpoMedico.dtCuerpoMedico.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Item(0) = tbl(0)
            objCuerpoMedico.dtCuerpoMedico.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Item(1) = tbl(1)
            If objCuerpoMedico.dtCuerpoMedico.Columns.Count > 2 Then
                objCuerpoMedico.dtCuerpoMedico.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Item(2) = Constantes.ITEM_NUEVO
            End If
            objCuerpoMedico.dtCuerpoMedico.Rows.Add()
            dgvTarifaMedica.Rows(dgvTarifaMedica.RowCount - 1).Cells(1).Selected = True
            If dtAux IsNot Nothing Then
                dtAux.Rows.Add()
                dtAux.Rows(dtAux.Rows.Count - 1).Item(0) = tbl(0)
                dtAux.Rows(dtAux.Rows.Count - 1).Item(1) = tbl(1)
                dtAux.Rows(dtAux.Rows.Count - 1).Item(2) = 0
                dtAux.Rows(dtAux.Rows.Count - 1).Item(3) = 0
            Else
                dtAux = objCuerpoMedico.dtCuerpoMedico.Copy
                For i = 0 To dtAux.Rows.Count - 1
                    If dtAux.Rows(i).Item(0) Is DBNull.Value Then
                        dtAux.Rows(i).Delete()
                    End If
                Next
            End If

        End If
    End Sub
    Private Sub dgvTarifaMedica_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTarifaMedica.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If ValidarDatos() = True Then Exit Sub
        If objCuerpoMedico.dtCuerpoMedico.Rows.Count = 0 Then
            MsgBox("No ha ingresado una tarifa para esta Especialidad...", MsgBoxStyle.Exclamation)
            objCuerpoMedico.dtCuerpoMedico.Rows.Add()
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            objCuerpoMedico.dtCuerpoMedico.AcceptChanges()
            dgvTarifaMedica.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvTarifaMedica.EndEdit()
            cargarObjetosTarifaMedica()
            objCuerpoMedico.dtCuerpoMedico = dtAux.Copy
            Try
                CuerpoMedioBLL.guardarTarifaMedica(objCuerpoMedico)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                txtCodigo.Text = objCuerpoMedico.Codigo
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try

        End If
    End Sub
    Private Function ValidarDatos() As Boolean
        Dim res As Boolean
        For Each celda As DataGridViewRow In dgvTarifaMedica.Rows
            If String.IsNullOrEmpty(dgvTarifaMedica.Rows(celda.Index).Cells(0).Value.ToString) = False Then
                For Each Cell In celda.Cells
                    Dim indexCol = Cell.ColumnIndex
                    Dim Col = dgvTarifaMedica.Columns(indexCol)
                    Dim vSimbolo = Cell.Value.ToString.Trim.ToUpper
                    If vSimbolo = "" And indexCol < 0 Then
                        res = True
                        MsgBox("Uno o más Celdas de la lista estan en Blanco...", MsgBoxStyle.Exclamation)
                        Return res
                    End If
                Next
            Else
                objCuerpoMedico.dtCuerpoMedico.Rows(celda.Index).Delete()
            End If
        Next
        Return res
    End Function
    Sub cargarObjetosTarifaMedica()
        objCuerpoMedico.Codigo = txtCodigo.Text
        objCuerpoMedico.idEmpleado = txtIdEmpleado.Text
        objCuerpoMedico.usuario = SesionActual.idUsuario
        objCuerpoMedico.Activo = chkActivo.CheckState
    End Sub

    Private Sub dgvTarifaMedica_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTarifaMedica.CellEndEdit
        If e.ColumnIndex = 2 Then
            objCuerpoMedico.dtCuerpoMedico.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Item(3) = 0
            dtAux.Rows(dtAux.Rows.Count - 1).Item(2) = objCuerpoMedico.dtCuerpoMedico.Rows(dgvTarifaMedica.CurrentCell.RowIndex).Item(2)
            dtAux.Rows(dtAux.Rows.Count - 1).Item(3) = 0
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(objCuerpoMedico.sqlBuscarTarifaMedia,
                          Nothing,
                          AddressOf cargarTarifaMedica,
                          TitulosForm.BUSQUEDA_EMPLEADO_HC,
                          False, 0, True)
    End Sub

    Private Sub cargarTarifaMedica(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Try
            txtIdEmpleado.Text = pCodigo
            dFila = General.cargarItem(objCuerpoMedico.sqlCargarTarifaMedica, params)
            txtCodigo.Text = dFila(0)
            objCuerpoMedico.Codigo = dFila(0)
            txtIdEmpleado.Text = dFila(1)
            cmbCargo.SelectedValue = dFila(2)
            txtEmpleado.Text = dFila(3)
            chkActivo.Checked = dFila(4)
            cargarTarifaMedicaDetalle(dFila(0))
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btnBuscar.Enabled = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarTarifaMedicaDetalle(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.TARIFA_MEDICA_CARGAR_D, params, objCuerpoMedico.dtCuerpoMedico)
        dgvTarifaMedica.DataSource = objCuerpoMedico.dtCuerpoMedico
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        dtAux = objCuerpoMedico.dtCuerpoMedico.Copy
        objCuerpoMedico.dtCuerpoMedico.Rows.Add()
        cmbCargo.Enabled = False
        txtEmpleado.Enabled = False
        btnBuscar.Enabled = False
        chkActivo.Enabled = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Try
                objCuerpoMedico.usuario = SesionActual.idUsuario
                objCuerpoMedico.AnularTarifaMedica()
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                btbuscar.Enabled = True
                btnuevo.Enabled = True
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
End Class