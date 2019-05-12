Public Class Productos
    '_____________________________________________________________
    '| Descripcion: Creación general del formulario de productos |
    '| Autor: trululu                                            |
    '| fecha_creacion: 25/05/2016 09:29 a.m.                     |
    '|___________________________________________________________|

    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pmarcas As String
    Dim objProducto As Producto
    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Sub inicializarForm()
        objProducto = New Producto
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pmarcas = permiso_general & "pp" & "05"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        llenar_marcas()
        cargarBodegas()
        deshabiliarControlesEquivalencia()
        Me.dgvvias.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable
        Me.dgvBodegas.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
#Region "Botones"
    Private Sub btBuscarEquivalencia_Click(sender As Object, e As EventArgs) Handles btBuscarEquivalencia.Click
        General.buscarElemento(Consultas.LISTAR_EQUIVALENCIAS,
                                 Nothing,
                                 AddressOf cargarEquivalencia,
                                 TitulosForm.BUSQUEDA_EQUIVALENCIA,
                                 False, 0, True)
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarControlesEquivalencia()
    End Sub
    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btOpcionMarca.Click
        If SesionActual.tienePermiso(Pmarcas) Then
            Dim objMarcasForm As New Marcas
            objMarcasForm.formProductos = Me
            objMarcasForm.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        nuevo()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardar()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        editar()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        buscar()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        anular()
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
#End Region
#Region "Metodos"
    Sub guardar()
        Try
            If validarGuardar() = True Then
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    emplamarDiseñoToObeto()
                    Dim objProductoBll As New ProductoBLL
                    objProductoBll.guardar(objProducto, SesionActual.idUsuario)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    cargarProducto(objProducto.codigo)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub anular()
        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Dim objProductoBll As New ProductoBLL
                    If objProductoBll.anular_Producto(objProducto, SesionActual.idUsuario) = True Then
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub buscar()
        If SesionActual.tienePermiso(PBuscar ) Then
            cargarBodegas()
            Dim params As New List(Of String)
            params.Add("")
            General.buscarElemento(Consultas.PRODUCTO_BUSCAR_PRODUCTOS, params,
                                   AddressOf cargarProducto,
                                   TitulosForm.BUSQUEDA_PRODUCTOS,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub Nuevo()
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            deshabiliarControlesEquivalencia()
            cargarBodegas()
            limpiar_dgv()
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub editar()
        If SesionActual.tienePermiso(Peditar ) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                txtnombre.Focus()
                deshabiliarControlesEquivalencia()
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cargarBodegas()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.CARGAR_BODEGAS_PRODUCTOS, params, objProducto.tblBodegas)
        dgvBodegas.DataSource = objProducto.tblBodegas
        dgvBodegas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        If dgvBodegas.Columns.Count > 0 Then
            dgvBodegas.Columns("id").ReadOnly = True
            dgvBodegas.Columns("Bodegas").ReadOnly = True
        End If

        dgvBodegas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Sub llenar_marcas()
        General.cargarCombo(Consultas.MARCAS_LISTAR, "nombre", "Codigo_marca", cmbMarca)
    End Sub
    Sub cargarVias(ByVal pCodigoInterno As Integer)
        Dim tblVias As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigoInterno)
        General.llenarTabla(Consultas.LISTAR_VIAS_EQUIVALENCIAS, params, tblVias)
        dgvvias.DataSource = tblVias
        dgvvias.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Sub cargarEquivalencia(pCodigo As String)
        objProducto.codigoInterno = pCodigo
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim fila As DataRow = General.cargarItem(Consultas.PRODUCTO_CARGAR_EQUIVALENCIA_ASOCIADA, params)
        If Not IsNothing(fila) Then
            txtCodigoInterno.Text = fila.Item("Codigo_Interno")
            txtNombreEqui.Text = fila.Item("Descripcion")
            txtLinea.Text = fila.Item("Linea")
            TxtGrupo.Text = fila.Item("Grupo")
            txtpresen.Text = fila.Item("Presentacion")
            txtCategoria.Text = fila.Item("Categoria")
        End If
        cargarVias(objProducto.codigo)
    End Sub
    Public Sub cargarProducto(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim fila As DataRow = General.cargarItem("[PROC_PRODUCTOS_CARGAR_DATOS]", params)
        objProducto.codigo = pCodigo
        objProducto.nombre = fila.Item("Descripcion").ToString
        objProducto.codigoMarca = fila.Item("Codigo_Marca").ToString
        objProducto.regSanitario = fila.Item("Registro_Sanitario").ToString
        objProducto.codigoBarras = fila.Item("Codigo_Barra").ToString
        objProducto.codigoCum = fila.Item("Codigo_CUM").ToString
        objProducto.iva = fila.Item("Iva").ToString
        objProducto.Presentacion = fila.Item("Presentacion").ToString
        objProducto.codigoInterno = fila.Item("Codigo_interno").ToString

        limpiar_dgv()
        cargarBodegas()
        params.Clear()
        Dim tblTemp As New DataTable
        params.Add(pCodigo)
        General.llenarTabla("PROC_BODEGA_CARGAR_DATOS_BOEGAS_ASIGNADAS", params, tblTemp)
        For indiceTablaTemp = 0 To tblTemp.Rows.Count - 1
            For indiceGrilla = 0 To dgvBodegas.RowCount - 1
                If dgvBodegas.Rows(indiceGrilla).Cells("id").Value = tblTemp.Rows(indiceTablaTemp).Item("Codigo_Bodega") Then
                    dgvBodegas.Rows(indiceGrilla).Cells("OK").Value = True
                End If
            Next
        Next
        cargarVias(objProducto.codigoInterno)
        cargarEquivalencia(objProducto.codigoInterno)
        emplamarObetoToDiseño()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Sub emplamarObetoToDiseño()
        txtCodigo.Text = objProducto.codigo
        txtnombre.Text = objProducto.nombre
        txtRegSanitario.Text = objProducto.regSanitario
        cmbMarca.SelectedValue = objProducto.codigoMarca
        txtBarras.Text = objProducto.codigoBarras
        txtCUM.Text = objProducto.codigoCum
        txtEmbalaje.Text = objProducto.Presentacion
        NumIVA.Value = objProducto.iva
    End Sub
    Sub emplamarDiseñoToObeto()
        objProducto.codigo = txtCodigo.Text
        objProducto.nombre = txtnombre.Text
        objProducto.regSanitario = txtRegSanitario.Text
        objProducto.codigoMarca = cmbMarca.SelectedValue
        objProducto.codigoBarras = txtBarras.Text
        objProducto.codigoCum = txtCUM.Text
        objProducto.Presentacion = txtEmbalaje.Text
        objProducto.iva = NumIVA.Value
        objProducto.tblBodegas.AcceptChanges()
    End Sub
    Private Sub dgvvias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvvias.CellClick
        dgvvias.ReadOnly = True
        dgvvias.Enabled = True
    End Sub
    Sub limpiar_dgv()
        For i As Integer = 0 To dgvBodegas.RowCount - 1
            dgvBodegas.Rows(i).Cells("OK").Value = False
            dgvBodegas.Rows(i).Cells("OK").ReadOnly = False
        Next
    End Sub
    Sub deshabiliarControlesEquivalencia()
        txtCodigoInterno.Enabled = False
        txtNombreEqui.Enabled = False
        txtLinea.Enabled = False
        TxtGrupo.Enabled = False
        txtpresen.Enabled = False
        txtCategoria.Enabled = False
    End Sub
    Sub limpiarControlesEquivalencia()
        txtCodigoInterno.ResetText()
        txtNombreEqui.ResetText()
        txtLinea.ResetText()
        TxtGrupo.ResetText()
        txtpresen.ResetText()
        txtCategoria.ResetText()
    End Sub
#End Region
#Region "Funciones"
    Function validarGuardar() As Boolean
        dgvBodegas.EndEdit()
        dgvBodegas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        If txtCodigoInterno.Text.Trim = "" Then
            MsgBox("Debe escoger la equivalencia antes de guardar !!", MsgBoxStyle.Information)
            txtCodigoInterno.Focus()
            Return False
        ElseIf txtnombre.Text.Trim = "" Then
            MsgBox("Debe colocar el nombre del productos  antes de guardar !!", MsgBoxStyle.Information)
            txtnombre.Focus()
            Return False
        ElseIf txtRegSanitario.Text.Trim = "" Then
            MsgBox("Debe colocar el registro sanitario del productos  antes de guardar !!", MsgBoxStyle.Information)
            txtRegSanitario.Focus()
            Return False
        ElseIf cmbMarca.SelectedIndex < 1 Then
            MsgBox("Debe escoger la marca del productos  antes de guardar !!", MsgBoxStyle.Information)
            cmbMarca.Focus()
            Return False
        ElseIf txtCUM.Text.Trim = "" Then
            MsgBox("Debe colocar el código CUM del productos  antes de guardar !!", MsgBoxStyle.Information)
            txtCUM.Focus()
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Eventos Datagridview"
    Private Sub dgvBodegas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBodegas.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            Dim objProductoBll As New ProductoBLL
            If Funciones.filaValida(e.RowIndex) And Funciones.verificacionPosicionActual(dgvBodegas, e, "OK") Then
                If objProductoBll.verificar_existencia_producto(txtCodigo.Text, dgvBodegas.Rows(e.RowIndex).Cells("Id").Value) Then
                    dgvBodegas.Rows(e.RowIndex).Cells("OK").ReadOnly = True
                    dgvBodegas.Rows(e.RowIndex).Cells("OK").Value = True
                Else
                    dgvBodegas.Rows(e.RowIndex).Cells("OK").ReadOnly = False
                End If
            Else
                dgvBodegas.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
#End Region
End Class