Public Class FormManualTarifario
    Dim cmd As New CausaExternaBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim contfila As Integer = 0
    Dim onSelecting As Boolean
    Dim objManualTarifa As ManualTarifarioAM
    Dim navegador As New BindingSource
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub Modulos_perfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        txtBusqueda.Focus()
        txtBusqueda.Text = ""
    End Sub
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
        'filtra los datos que se encuentra en el datagrillview
        navegador.Filter = "Descripcion_Pais_origen LIKE '%" & txtBusqueda.Text & "%' OR Descripcion_Dpto_origen LIKE '%" & txtBusqueda.Text &
                                         "%' OR  Descripcion_Municipio_origen LIKE '%" & txtBusqueda.Text & "%' OR  Descripcion_Pais_Destino LIKE '%" & txtBusqueda.Text &
                                         "%' OR  Descripcion_Dpto_Destino LIKE '%" & txtBusqueda.Text & "%' OR  Descripcion_Municipio_Destino LIKE '%" & txtBusqueda.Text &
                                         "%' OR  Descripcion_Institucion_Origen LIKE '%" & txtBusqueda.Text & "%' OR  Descripcion_Institucion_Origen LIKE '%" & txtBusqueda.Text &
                                         "%' OR  Descripcion_Institucion_Destino LIKE '%" & txtBusqueda.Text & "%' OR  Descripcion_Procedimiento LIKE '%" & txtBusqueda.Text & "%'"
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            'Me.dgvManualTarifario.ReadOnly = True
            Me.dgvManualTarifario.Columns("PaisOrigen").ReadOnly = True
            Me.dgvManualTarifario.Columns("DptoOrigen").ReadOnly = True
            Me.dgvManualTarifario.Columns("Mun_Origen").ReadOnly = True
            Me.dgvManualTarifario.Columns("EntidadOrigen").ReadOnly = True
            Me.dgvManualTarifario.Columns("PaisDestino").ReadOnly = True
            Me.dgvManualTarifario.Columns("DptoDestino").ReadOnly = True
            Me.dgvManualTarifario.Columns("MunDestino").ReadOnly = True
            Me.dgvManualTarifario.Columns("EntidadDestino").ReadOnly = True
            Me.dgvManualTarifario.Columns("Traslado").ReadOnly = True
            Me.dgvManualTarifario.BackgroundColor = Color.White
            objManualTarifa.dtTablaManualTarifario.Rows.Add()
            Me.btnDuplicarLista.Enabled = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub FormManualTarifario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objManualTarifa = New ManualTarifarioAM
        objManualTarifa.Usuario = SesionActual.idUsuario
        validaddgvManualTarifario()
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        'Oculta campos inecesarios en del dgvManualTarifario
        Medico.Visible = False
        Paramedico.Visible = False
        Fisioterapeuta.Visible = False
        Conductor.Visible = False
        Contacto.Visible = False
        'permisos de uso de boton
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.cargarCombo(Consultas.MANUAL_EPS_LISTAR, "Nombre_EPS", "Codigo", cmbEPS) 'Nombre_EPS: valor a mostrar; Codigo: Valor a Buscar
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'Guarda en base de datos los valores de tarifa de tripulantes Ambulancia
        If ValidarDatos() = True Then Exit Sub
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            objManualTarifa.dtTablaManualTarifario.AcceptChanges()
            dgvManualTarifario.CommitEdit(DataGridViewDataErrorContexts.Commit)
            cargarObjetoManualTarifario()
            Try
                ManualTarifarioAmBLL.guardarManualTarifario(objManualTarifa)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                TxtCodigo.Text = objManualTarifa.CodigoManual
                cargarManualTarifarioAmDetalle(TxtCodigo.Text)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btAgregarFila_Click(sender As Object, e As EventArgs) Handles btAgregarFila.Click
        If btguardar.Enabled = False Then Exit Sub
        ManualTarifarioAmBLL.agregarFilaManualTarifario(objManualTarifa.dtTablaManualTarifario)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(objManualTarifa.sqlBuscarManualTarifarioAM,
                              params,
                              AddressOf cargarManualTarifarioAM,
                              TitulosForm.BUSQUEDA_MANUAL_TARIFARIO,
                              False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarManualTarifarioAM(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objManualTarifa.sqlCargarManualTarifarioAM, params)
            objManualTarifa.CodigoManual = pCodigo
            TxtCodigo.Text = pCodigo
            TxtNombreManual.Text = dFila(0)
            cmbEPS.SelectedValue = dFila(1)
            cargarManualTarifarioAmDetalle(pCodigo)
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btnDuplicarLista.Enabled = True
            txtBusqueda.ReadOnly = False
            btAgregarFila.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarManualTarifarioAmDetalle(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasAmbu.MANUAL_TARIFARIO_AM_D_CARGAR, params, objManualTarifa.dtTablaManualTarifario)
        navegador.DataSource = objManualTarifa.dtTablaManualTarifario
        dgvManualTarifario.DataSource = navegador
        dgvManualTarifario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvManualTarifario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvManualTarifario.AutoGenerateColumns = False
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            contfila = 0
            'Edita en base de datos los valores del Manual Tarifario Ambulancia
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    objManualTarifa.AnularManualTarifario()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnDuplicarLista_Click(sender As Object, e As EventArgs) Handles btnDuplicarLista.Click
        If MsgBox("¿Esta seguro que desea duplicar este manual?", 32 + 1, "Duplicar") = 2 Then Return
        TxtCodigo.Text = ""
        General.formDuplicar(Me, ToolStrip1, btguardar, btcancelar)
    End Sub
    Private Function ValidarDatos() As Boolean
        Dim res As Boolean
        If String.IsNullOrEmpty(TxtNombreManual.Text) Then
            res = True
            MsgBox("El Nombre del Manual esta en Blanco...", MsgBoxStyle.Exclamation)
            TxtNombreManual.Focus()
        ElseIf cmbEPS.SelectedValue = -1 Then
            res = True
            MsgBox("No ha Seleccionado una EPS...", MsgBoxStyle.Exclamation)
            cmbEPS.Focus()
        ElseIf IsDBNull(dgvManualTarifario.Rows(0).Cells(0).Value) Then
            res = True
            MsgBox("Lista de Precio esta en Blanco...", MsgBoxStyle.Exclamation)
        Else
            For Each celda As DataGridViewRow In dgvManualTarifario.Rows
                If String.IsNullOrEmpty(dgvManualTarifario.Rows(celda.Index).Cells(0).Value.ToString) = False Then
                    For Each Cell In celda.Cells
                        Dim indexCol = Cell.ColumnIndex
                        Dim Col = dgvManualTarifario.Columns(indexCol)
                        Dim vSimbolo = Cell.Value.ToString.Trim.ToUpper
                        If vSimbolo = "" And indexCol < 19 Then
                            res = True
                            MsgBox("Uno o más Celdas de la lista estan en Blanco...", MsgBoxStyle.Exclamation)
                            Return res
                        End If
                    Next
                Else
                    objManualTarifa.dtTablaManualTarifario.Rows(celda.Index).Delete()
                End If
            Next
        End If
        Return res
    End Function
    Sub cargarObjetoManualTarifario()
        objManualTarifa.CodigoManual = TxtCodigo.Text
        objManualTarifa.Descripcion = TxtNombreManual.Text
        objManualTarifa.IdTercero = cmbEPS.SelectedValue
        objManualTarifa.IdEmpresa = SesionActual.idEmpresa
        objManualTarifa.Usuario = SesionActual.idUsuario
    End Sub

    Private Sub dgvManualTarifario_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvManualTarifario.DataError
        Select Case dgvManualTarifario.CurrentCell.ColumnIndex
            Case 18
                MsgBox("Valor Tarifa esta en Blanco...", MsgBoxStyle.Exclamation)
            Case Else
        End Select
    End Sub

    Private Sub dgvManualTarifario_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManualTarifario.CellEndEdit
        Select Case dgvManualTarifario.CurrentCell.ColumnIndex
            Case 18
                If dgvManualTarifario.Rows.Count - 1 = dgvManualTarifario.CurrentCell.RowIndex Then
                    objManualTarifa.dtTablaManualTarifario.Rows.Add()
                End If
                If IsDBNull(dgvManualTarifario.CurrentRow.Cells("CodInt").Value) Then
                    dgvManualTarifario.CurrentRow.Cells("CodInt").Value = contfila
                    contfila = contfila + 1
                End If
            Case Else
        End Select
    End Sub

    Private Sub dgvManualTarifario_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvManualTarifario.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub

    Private Sub dgvManualTarifario_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManualTarifario.CellEnter
        Select Case dgvManualTarifario.CurrentCell.ColumnIndex
            Case 18
                dgvManualTarifario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Case 19
                dgvManualTarifario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Case Else
                dgvManualTarifario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        End Select
    End Sub

    Sub cargardgvManualTarifario(pCodigo As String)
        Dim F As Integer
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Select Case dgvManualTarifario.CurrentCell.ColumnIndex
            Case 5
                F = 0
                params.Add(objManualTarifa.dtTablaManualTarifario.Rows(dgvManualTarifario.CurrentCell.RowIndex).Item("Codigo_Pais_Origen"))
                params.Add(objManualTarifa.dtTablaManualTarifario.Rows(dgvManualTarifario.CurrentCell.RowIndex).Item("Codigo_Dpto_Origen"))
            Case 11
                F = 0
                params.Add(objManualTarifa.dtTablaManualTarifario.Rows(dgvManualTarifario.CurrentCell.RowIndex).Item("Codigo_Pais_Destino"))
                params.Add(objManualTarifa.dtTablaManualTarifario.Rows(dgvManualTarifario.CurrentCell.RowIndex).Item("Codigo_Dpto_Destino"))
            Case Else
                F = 1
        End Select
        params.Add(pCodigo)


        Try
            dFila = General.cargarItem(objManualTarifa.sqlCargarElemento, params)
            dgvManualTarifario.Rows(dgvManualTarifario.CurrentCell.RowIndex).Cells(dgvManualTarifario.CurrentCell.ColumnIndex - 1).Value = pCodigo
            dgvManualTarifario.Rows(dgvManualTarifario.CurrentCell.RowIndex).Cells(dgvManualTarifario.CurrentCell.ColumnIndex).Value = dFila(F)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Sub validaddgvManualTarifario()
        With dgvManualTarifario
            .Columns("CodPaisO").DataPropertyName = "Codigo_Pais_Origen"
            .Columns("PaisOrigen").DataPropertyName = "Descripcion_Pais_origen"
            .Columns("CodDptoO").DataPropertyName = "Codigo_Dpto_Origen"
            .Columns("DptoOrigen").DataPropertyName = "Descripcion_Dpto_origen"
            .Columns("CodMunO").DataPropertyName = "Codigo_Municipio_Origen"
            .Columns("Mun_Origen").DataPropertyName = "Descripcion_Municipio_origen"
            .Columns("CodPaisD").DataPropertyName = "Codigo_Pais_Destino"
            .Columns("PaisDestino").DataPropertyName = "Descripcion_Pais_Destino"
            .Columns("CodDptoD").DataPropertyName = "Codigo_Dpto_Destino"
            .Columns("DptoDestino").DataPropertyName = "Descripcion_Dpto_Destino"
            .Columns("CodMunD").DataPropertyName = "Codigo_Municipio_Destino"
            .Columns("MunDestino").DataPropertyName = "Descripcion_Municipio_Destino"
            .Columns("CodEntO").DataPropertyName = "Codigo_Institucion_Origen"
            .Columns("EntidadOrigen").DataPropertyName = "Descripcion_Institucion_Origen"
            .Columns("CodEntD").DataPropertyName = "Codigo_Institucion_Destino"
            .Columns("EntidadDestino").DataPropertyName = "Descripcion_Institucion_Destino"
            .Columns("CodTras").DataPropertyName = "Codigo_Procedimiento"
            .Columns("Traslado").DataPropertyName = "Descripcion_Procedimiento"
            .Columns("Valor").DataPropertyName = "Valor"
            .Columns("Medico").DataPropertyName = "Valor_Medico"
            .Columns("Paramedico").DataPropertyName = "Valor_Paramedico"
            .Columns("Fisioterapeuta").DataPropertyName = "Valor_Fisioterapeuta"
            .Columns("Conductor").DataPropertyName = "Valor_Conductor"
            .Columns("Contacto").DataPropertyName = "Valor_Contacto"
            .Columns("Observaciones").DataPropertyName = "Observaciones"
            .Columns("CodInt").DataPropertyName = "Codigo"
            .DataSource = objManualTarifa.dtTablaManualTarifario
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
        End With
    End Sub

    Private Sub txtComentario_Leave(sender As Object, e As EventArgs) Handles txtComentario.Leave
        Try
            If Panel7.Visible = True Then
                Panel7.Visible = False
                dgvManualTarifario.Rows(dgvManualTarifario.CurrentRow.Index).Cells("Observaciones").Value = txtComentario.Text
                txtComentario.Clear()
                objManualTarifa.dtTablaManualTarifario.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvManualTarifario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManualTarifario.CellDoubleClick
        If btguardar.Enabled = False Or e.RowIndex < 0 Then
            Exit Sub
        End If
        Dim params As New List(Of String)
        objManualTarifa.CodigoElemnto = Nothing
        Select Case dgvManualTarifario.CurrentCell.ColumnIndex
            Case 1
                objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarPais
                objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarPais
            Case 3
                    If IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("PaisOrigen").Value) Then
                    MsgBox("Debe elegir Primero el País de Origen ", MsgBoxStyle.Exclamation)
                    Exit Sub
                    Else
                        params.Add(objManualTarifa.dtTablaManualTarifario.Rows(e.RowIndex).Item("Codigo_Pais_Origen"))
                        objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarDpto
                        objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarDpto
                    End If
                Case 5
                    If IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("DptoOrigen").Value) Then
                    MsgBox("Debe elegir Primero el Departamento de Origen ", MsgBoxStyle.Exclamation)
                    Exit Sub
                    Else
                        params.Add(objManualTarifa.dtTablaManualTarifario.Rows(e.RowIndex).Item("Codigo_Dpto_Origen"))
                        objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarMun
                        objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarMun
                    End If
                Case 13
                    If IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("PaisOrigen").Value) Or IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("DptoOrigen").Value) Or IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("Mun_Origen").Value) Then
                    MsgBox("Debe elegir Primero el Pais, Departamento y Municipio de Origen ", MsgBoxStyle.Exclamation)
                    Exit Sub
                    Else
                        objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarInst
                        objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarInst
                    End If
                Case 7
                    objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarPais
                    objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarPais
                Case 9
                    If IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("PaisDestino").Value) Then
                    MsgBox("Debe elegir Primero el País de Destino ", MsgBoxStyle.Exclamation)
                    Exit Sub
                    Else
                        params.Add(objManualTarifa.dtTablaManualTarifario.Rows(e.RowIndex).Item("Codigo_Pais_Destino"))
                        objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarDpto
                        objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarDpto
                    End If
                Case 11
                    If IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("DptoDestino").Value) Then
                    MsgBox("Debe elegir Primero el Municipio de Destino ", MsgBoxStyle.Exclamation)
                    Exit Sub
                    Else
                        params.Add(objManualTarifa.dtTablaManualTarifario.Rows(e.RowIndex).Item("Codigo_Dpto_Destino"))
                        objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarMun
                        objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarMun
                    End If
                Case 15
                    If IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("PaisDestino").Value) Or IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("DptoDestino").Value) Or IsDBNull(dgvManualTarifario.Rows(e.RowIndex).Cells("MunDestino").Value) Then
                    MsgBox("Debe elegir Primero el Pais, Departamento y Municipio de Destino ", MsgBoxStyle.Exclamation)
                    Exit Sub
                    Else
                        objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarInst
                        objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarInst
                    End If
                Case 17
                    objManualTarifa.sqlBuscarElemento = objManualTarifa.sqlBuscarTras
                    objManualTarifa.sqlCargarElemento = objManualTarifa.sqlCargarTras
                Case 24
                    ExamenLaboratorioBLL.abrirJustificacion(dgvManualTarifario, objManualTarifa.dtTablaManualTarifario, Panel7, txtComentario, "Observaciones")
                Case Else

            End Select
        If (dgvManualTarifario.CurrentCell.ColumnIndex <> 18 And dgvManualTarifario.CurrentCell.ColumnIndex <> 24) Then
            General.buscarElemento(objManualTarifa.sqlBuscarElemento,
                                  params,
                                  AddressOf cargardgvManualTarifario,
                                  TitulosForm.BUSQUEDA_MANUAL_TARIFARIO,
                                  False)
        End If
    End Sub
End Class