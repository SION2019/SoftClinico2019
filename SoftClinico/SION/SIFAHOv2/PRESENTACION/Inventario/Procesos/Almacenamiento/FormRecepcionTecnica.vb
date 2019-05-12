Imports System.Data.SqlClient

Public Class FormRecepcionTecnica
    Dim objRecepcion As RecepcionTecnicaTraslado
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pbuscar_proveedor As String
    Private Sub FormRecepcionTecnica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#Region "Metodos"
    Sub inicializarForm()
        objRecepcion = New RecepcionTecnicaTraslado
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        configurarDgvProductos()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub configurarDgvProductos()
        With dgvproductos
            .Columns("Codigo_producto").ReadOnly = True
            .Columns("Codigo_producto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_producto").DataPropertyName = "Codigo_producto"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Marca").ReadOnly = True
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("CantPed").ReadOnly = True
            .Columns("CantPed").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantPed").DataPropertyName = "CantPed"
            .Columns("CantEnv").ReadOnly = True
            .Columns("CantEnv").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantEnv").DataPropertyName = "CantEnv"
            .Columns("CantFal").ReadOnly = True
            .Columns("CantFal").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantFal").DataPropertyName = "CantFal"
            .Columns("Confirmacion").ReadOnly = False
            .Columns("Confirmacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Confirmacion").DataPropertyName = "Confirmacion"
            .AutoGenerateColumns = False
            .DataSource = objRecepcion.tblProdcutos
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub cargarLotesTraslado(ByVal codigoProducto As Integer, ByVal nombreTabla As String)
        Dim params As New List(Of String)
        params.Add(objRecepcion.codigoTraslado)
        params.Add(codigoProducto)
        General.llenarTabla(Consultas.RECEPCION_TECNI_TRASLADO_CARGAR_LOTES_RECEPCIONADOS, params, objRecepcion.tblLotes.Tables(nombreTabla))
    End Sub
    Public Sub cargarLotesRecepcion(ByVal codigoProducto As Integer, ByVal nombreTabla As String)
        Dim params As New List(Of String)
        params.Add(objRecepcion.codigoRecepcion)
        params.Add(codigoProducto)
        General.llenarTabla(Consultas.RECEPCION_TECNI_TRASLADO_CARGAR_LOTES_TRASLADADOS, params, objRecepcion.tblLotes.Tables(nombreTabla))
    End Sub
    Sub configurarDgvLotes(ByVal nombreTabla As String)
        With dgvLotes
            .Columns("Reg_lote").ReadOnly = True
            .Columns("Reg_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Reg_lote").DataPropertyName = "Reg_lote"
            .Columns("Num_lote").ReadOnly = True
            .Columns("Num_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Num_lote").DataPropertyName = "Num_lote"
            .Columns("Fecha").ReadOnly = True
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha_vence"
            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "CantEnv"
            .Columns("Costo").ReadOnly = True
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Costo"
            .Columns("Excepcion").ReadOnly = True
            .Columns("Excepcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Excepcion").DataPropertyName = "Excepcion"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objRecepcion.tblLotes.Tables(nombreTabla)
        End With
    End Sub
    Sub colocarSoloLecturaTexboxPanel()
        TxtDescripcionProducto.ReadOnly = True
        TxtCantidadProducto.ReadOnly = True
    End Sub
    Public Sub cargarRecepcion(ByVal pCodigoRecepcion As Integer)
        objRecepcion.codigoRecepcion = pCodigoRecepcion
        Dim params As New List(Of String)
        params.Add(objRecepcion.codigoRecepcion)
        Dim fila As DataRow = General.cargarItem(Consultas.RECEPCION_TECNI_TRASLADO_BUSCAR_INDIVIDUAL, params)
        objRecepcion.codigoTraslado = fila.Item("Codigo_Traslado")
        objRecepcion.codigoTrasladoPunto = fila.Item("Codigo_Traslado_punto")
        objRecepcion.fechaRecepcion = fila.Item("Fecha_Recepcion_Traslado")
        cargarDatosTrasladoRecepcion(objRecepcion.codigoTraslado)
        cargarDetalleRecepcion(objRecepcion.codigoRecepcion)
        empalmarObjetoToDiseno()
        cargarLotes()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
        calcularTotalRecepcion()
    End Sub
    Sub cargarLotes()
        objRecepcion.tblLotes.Clear()
        Dim nombretabla As String = ""
        Dim filas As DataRowCollection = objRecepcion.tblProdcutos.Rows
        For indicePro = 0 To filas.Count - 1
            nombretabla = objRecepcion.nombrarTabla(filas(indicePro).Item("Codigo_Producto"), indicePro)
            If Not objRecepcion.verificarExistenciaTabla(nombretabla) Then
                objRecepcion.agregarTabla(nombretabla)
                objRecepcion.colocarColumnasTabla(nombretabla)
            End If
            cargarLotesRecepcionados(filas(indicePro).Item("Codigo_Producto"), nombretabla)
        Next
    End Sub
    Sub calcularTotalRecepcion()
        Dim total As Double = 0
        Dim nombreTabla As String
        Dim filas As DataRowCollection = objRecepcion.tblProdcutos.Rows
        Dim tablas As DataTableCollection = objRecepcion.tblLotes.Tables
        Dim operacion As String = "Sum(CantEnv) * Sum(Costo)"
        For indiceFila = 0 To filas.Count - 1
            nombreTabla = objRecepcion.nombrarTabla(filas(indiceFila).Item("Codigo_Producto"), indiceFila)
            If Not objRecepcion.verificarExistenciaTabla(nombreTabla) Then
                objRecepcion.agregarTabla(nombreTabla)
            End If

            cargarLotesRecepcion(filas(indiceFila).Item("Codigo_Producto"), nombreTabla)
            If IsDBNull(tablas(nombreTabla).Compute(operacion, "")) Then
                total += 0
            Else
                total += tablas(nombreTabla).Compute(operacion, "") / tablas(nombreTabla).Rows.Count
            End If

        Next
        txtTotalTraslado.Text = FormatCurrency(total, 2)
    End Sub
    Sub empalmarDisenoToObjeto()
        objRecepcion.codigoRecepcion = TxtCodigo.Text
        objRecepcion.fechaRecepcion = txtFechaRecepcion.Value
        'objRecepcion.codigoTraslado = txtcodigoTraslado.Text
    End Sub
    Sub empalmarObjetoToDiseno()
        TxtCodigo.Text = objRecepcion.codigoRecepcion
        txtFechaRecepcion.Value = objRecepcion.fechaRecepcion
        txtcodigoTraslado.Text = objRecepcion.codigoTrasladoPunto
    End Sub
    Public Sub cargarDatosTrasladoRecepcion(ByVal codigo_tarslado As Integer)
        Using consultor As New SqlCommand(Consultas.RECEPCION_TECNI_TRASLADO_CARGAR_TRASLADO & codigo_tarslado, FormPrincipal.cnxion)
            Using lector = consultor.ExecuteReader
                If lector.HasRows = True Then
                    lector.Read()
                    txtcodigoTraslado.Text = codigo_tarslado
                    txtFechaTraslado.Text = lector.Item("Fecha_Traslado")
                    txtGuia.Text = lector.Item("No_Guia")
                    txtTransportadora.Text = lector.Item("TRANSPORTADORA")
                    txtBodegaTraslado.Text = lector.Item("Bodega_traslado")
                    txtBodegaRecepcion.Text = lector.Item("Bodega_Recepcion")
                End If
            End Using
        End Using
    End Sub
    Public Sub cargarDetalleRecepcion(ByVal pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.RECPECION_TECNI_TRASLADO_CARGAR_DETALLE, params, objRecepcion.tblProdcutos)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btanular, Nothing, btimprimir)
    End Sub
    Sub deshabiliarControlesTraslados()
        txtcodigoTraslado.ReadOnly = True
        txtBodegaTraslado.ReadOnly = True
        txtBodegaRecepcion.ReadOnly = True
        txtFechaTraslado.Enabled = False
        txtGuia.ReadOnly = True
        txtTransportadora.ReadOnly = True
    End Sub
    Public Sub cargarTraslado(pCodigo As DataRow)
        cargarDatosTraslado(pCodigo)
    End Sub
    Public Sub cargarDatosTraslado(ByVal codigo_traslado As DataRow)
        objRecepcion.codigoTraslado = codigo_traslado.Item(0)
        objRecepcion.codigoTrasladoPunto = codigo_traslado.Item(1)
        Dim params As New List(Of String)
        params.Add(objRecepcion.codigoTraslado)

        Dim lector As DataRow = General.cargarItem("[PROC_RECEPCION_TECNICA_TRASLADO_CARGAR_BUSQUEDA_TRASLADO]", params)
        txtcodigoTraslado.Text = objRecepcion.codigoTrasladoPunto
        txtFechaTraslado.Text = lector.Item("Fecha_Traslado")
        txtGuia.Text = lector.Item("No_Guia")
        txtTransportadora.Text = lector.Item("TRANSPORTADORA")
        txtBodegaTraslado.Text = lector.Item("Bodega_traslado")
        txtBodegaRecepcion.Text = lector.Item("Bodega_Recepcion")
        params.Clear()
        params.Add(objRecepcion.codigoTraslado)
        General.llenarTabla("[PROC_RECEPCION_TECNICA_TRASLADO_CARGAR_BUSQUEDA_TRASLADO_DETALLE] ", params, objRecepcion.tblProdcutos)
    End Sub
#End Region
#Region "Botones"
    Private Sub BtGuardarLotes_Click(sender As Object, e As EventArgs) Handles BtGuardarLotes.Click
        objRecepcion.tblProdcutos.Rows(dgvproductos.CurrentRow.Index).Item("Confirmacion") = True
        objRecepcion.tblProdcutos.EndInit()
        PnlLotes.Visible = False
    End Sub
    '------------- Voy por aqui
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If objRecepcion.tblProdcutos.Select("Confirmacion = 'True'").Count = 0 Then
            MsgBox("Debe verificar por lo menos un producto trasladado ! ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            dgvproductos.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    Dim cmd As New RecepcionTecnicaTrasladoBLL
                    empalmarDisenoToObjeto()
                    cmd.guardarRecepciontralado(objRecepcion, SesionActual.idUsuario, SesionActual.codigoEP)
                    cargarRecepcion(objRecepcion.codigoRecepcion)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            PnlLotes.Visible = False
            'General.limpiarControles(Me)
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(Consultas.RECEPCION_TECNI_TRASLADO_BUSCAR_RECEPCIONES,
                                    params,
                                    AddressOf cargarRecepcion,
                                    TitulosForm.BUSQUEDA_RECEPCION,
                                    False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            Dim cmd As New RecepcionTecnicaTrasladoBLL
            If cmd.verificacion_anular_recepcion(objRecepcion.codigoRecepcion) AndAlso MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    cmd.anular(objRecepcion.codigoRecepcion)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            Else
                MsgBox("No se puede anular la recepción por que alguno de sus lotes tuvo movimiento !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            deshabiliarControlesTraslados()
            txtFechaRecepcion.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
            txtFechaRecepcion.Enabled = True
            TxtCodigo.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click

    End Sub
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        PnlLotes.Visible = False
    End Sub

    Private Sub btBuscarTraslado_Click(sender As Object, e As EventArgs) Handles btBuscarTraslado.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)

        General.buscarItem(Consultas.RECEPCION_TECNI_TRASLADO_BUSCAR_TRASLADOS,
                           params,
                           AddressOf cargarTraslado,
                           "Busqueda de Traslados",
                            True,
                            0,
                            True)
    End Sub
#End Region
#Region "Eventos Grillas"
    Private Sub dgvproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellContentClick
        Dim filas As DataRowCollection = objRecepcion.tblProdcutos.Rows
        Dim filaActual As Integer = dgvproductos.CurrentRow.Index
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Lote", dgvproductos) Then
            TxtDescripcionProducto.Text = filas(filaActual).Item("Descripcion")
            TxtCantidadProducto.Text = filas(filaActual).Item("CantEnv")
            colocarSoloLecturaTexboxPanel()
            Dim nombreTabla As String = objRecepcion.nombrarTabla(filas(filaActual).Item("Codigo_Producto"), e.RowIndex)

            If Not objRecepcion.verificarExistenciaTabla(nombreTabla) Then
                objRecepcion.agregarTabla(nombreTabla)
                objRecepcion.colocarColumnasTabla(nombreTabla)
            End If
            If TxtCodigo.Text = "" Then
                cargarLotesTraslado(filas(filaActual).Item("Codigo_Producto"), nombreTabla)
                BtGuardarLotes.Visible = True
                btSalir.Visible = False
            Else
                cargarLotesRecepcionados(filas(filaActual).Item("Codigo_Producto"), nombreTabla)
                BtGuardarLotes.Visible = False
                btSalir.Visible = True
            End If
            configurarDgvLotes(nombreTabla)
            PnlLotes.Visible = True
        ElseIf Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, TitulosForm.ANULAR, dgvproductos) Then
            If TxtCodigo.Text = "" Then
                If MsgBox("Desea quitar este registro ? ", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                    filas(filaActual).Item("Confirmacion") = False
                    objRecepcion.tblProdcutos.EndInit()
                End If
            Else
                MsgBox("Aqui se anula si no tiene movimiento este lote")
            End If
        End If
    End Sub
    Sub cargarLotesRecepcionados(ByVal codigoProducto As String, ByVal nombreTabla As String)
        cargarLotesRecepcion(codigoProducto, nombreTabla)
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        dgvproductos.ReadOnly = True
    End Sub
#End Region
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
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
End Class