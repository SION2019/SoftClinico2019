Public Class Fom_consolidado_comida
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, pDetallado, pTodasAreas As String
    Dim objConsolidadoComidas As ConsolidadoComida
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Fom_consolidado_comida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Private Sub CmbFecha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFecha.SelectedIndexChanged
        llenarInformacionComidas()
        CmbFecha.Focus()
    End Sub
    Private Sub cmbAño_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged
        llenarInformacionComidas()
        cmbAnio.Focus()
    End Sub
    Private Sub cmbAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreaServicio.SelectedIndexChanged
        llenarInformacionComidas()
        cmbAreaServicio.Focus()
    End Sub
#Region "Metodos"

    Sub inicializarForm()
        objConsolidadoComidas = New ConsolidadoComida
        permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
        pDetallado = permiso_general & "pp" & "01"
        pTodasAreas = permiso_general & "pp" & "02"
        Dim objConsolidadoControlador As New ConsolidadoComidasBLL
        configurarDatagridviewDesayuno(objConsolidadoControlador)
        configurarDatagridviewAlmuerzo(objConsolidadoControlador)
        configurarDatagridviewCena(objConsolidadoControlador)
        cargarCmbAnio()
        llenarCmbMeses()
        llenarComboAreas()
        General.comboSoloEleccion(cmbAnio)
        General.comboSoloEleccion(CmbFecha)
        General.comboSoloEleccion(cmbAreaServicio)
        cmbAnio.SelectedItem = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date.Year
        CmbFecha.SelectedValue = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date.Month
        cmbAreaServicio.Focus()
    End Sub
    Sub llenarComboAreas()
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)
        General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", cmbAreaServicio)
        If SesionActual.tienePermiso(pTodasAreas ) Then
            cmbAreaServicio.DataSource.Rows.Add()
            cmbAreaServicio.DataSource.Rows(cmbAreaServicio.DataSource.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
            cmbAreaServicio.DataSource.Rows(cmbAreaServicio.DataSource.Rows.Count - 1).Item(1) = "TODOS"
        End If
    End Sub
    Sub configurarDatagridviewDesayuno(ByRef objConsolidadoControlador As ConsolidadoComidasBLL)
        Dim listaColumnas As List(Of String)
        listaColumnas = configurarDgvComida("NombreD", "CantidadD", "ValorD", "TotalD")
        objConsolidadoControlador.enlazardgv(dgvDesayuno, objConsolidadoComidas.tblDesayunos, listaColumnas)
    End Sub
    Sub configurarDatagridviewAlmuerzo(ByRef objConsolidadoControlador As ConsolidadoComidasBLL)
        Dim listaColumnas As List(Of String)
        listaColumnas = configurarDgvComida("NombreA", "CantidadA", "ValorA", "TotalA")
        objConsolidadoControlador.enlazardgv(dgvAlmuerzo, objConsolidadoComidas.tblAlmuerzos, listaColumnas)
    End Sub
    Sub configurarDatagridviewCena(ByRef objConsolidadoControlador As ConsolidadoComidasBLL)
        Dim listaColumnas As List(Of String)
        listaColumnas = configurarDgvComida("NombreC", "CantidadC", "ValorC", "TotalC")
        objConsolidadoControlador.enlazardgv(dgvCena, objConsolidadoComidas.tblCenas, listaColumnas)
    End Sub
    Sub cargarCmbAnio()
        cmbAnio.Items.Clear()
        cmbAnio.Items.Add("-- Año --")
        For h As Integer = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Year To CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Year - 30 Step -1
            cmbAnio.Items.Add(h)
        Next
    End Sub
    Sub llenarCmbMeses()
        Dim tablaMeses As New BindingSource
        tablaMeses.DataSource = Funciones.llenarMesesAnio
        CmbFecha.DataSource = tablaMeses
        CmbFecha.ValueMember = "Key"
        CmbFecha.DisplayMember = "Value"
    End Sub
    Sub llenarInformacionComidas()
        If Funciones.indiceValidoListas(cmbAnio.SelectedIndex) AndAlso Funciones.indiceValidoListas(CmbFecha.SelectedIndex) AndAlso Funciones.indiceValidoListas(cmbAreaServicio.SelectedIndex) Then
            llenarDesayuno()
            llenarAlmuerzo()
            llenarCena()
            txtCantidadTotalesComidas.Text = calcularTotalCantidadesComidas()
            txtCostosTotalesComidas.Text = FormatCurrency(calcularTotalCostosComidas(), 2)
        End If

    End Sub
    Private Sub llenarDesayuno()
        llenarTablaComida(Constantes.DESAYUNO, objConsolidadoComidas.tblDesayunos)
        txtCantidadDesayunos.Text = contarCantidadesComidas(objConsolidadoComidas.tblDesayunos)
        txtCostosDesayunos.Text = FormatCurrency(calcularCostosComidas(objConsolidadoComidas.tblDesayunos), 2)
    End Sub

    Private Sub llenarAlmuerzo()
        llenarTablaComida(Constantes.ALMUERZO, objConsolidadoComidas.tblAlmuerzos)
        txtCantidadAlmuerzos.Text = contarCantidadesComidas(objConsolidadoComidas.tblAlmuerzos)
        txtCostosAlmuerzos.Text = FormatCurrency(calcularCostosComidas(objConsolidadoComidas.tblAlmuerzos), 2)
    End Sub
    Private Sub llenarCena()
        llenarTablaComida(Constantes.CENA, objConsolidadoComidas.tblCenas)
        txtCantidadCenas.Text = contarCantidadesComidas(objConsolidadoComidas.tblCenas)
        txtCostoCenas.Text = FormatCurrency(calcularCostosComidas(objConsolidadoComidas.tblCenas), 2)
    End Sub
    Sub llenarTablaComida(ByVal tipoComida As Integer,
                          ByRef tbl As DataTable)

        Dim params As New List(Of String)
        params.Add(tipoComida)
        params.Add(cmbAnio.SelectedItem)
        params.Add(CmbFecha.SelectedValue)
        params.Add(cmbAreaServicio.SelectedValue)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CONSOLIDADO_COMIDAS, params, tbl)
    End Sub
    Sub guardarRegistrosTemporales()
        Try
            Dim objConsolidadoControlador As New ConsolidadoComidasBLL
            objConsolidadoControlador.guardar(objConsolidadoComidas, SesionActual.idUsuario)
            'Cursor = Cursors.WaitCursor
            btimprimir.Enabled = False
            Try
                imprimir()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
            'Cursor = Cursors.Default
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    'Sub imprimir()
    '    Dim reporte As New ftp_reportes
    '    Try

    '        reporte.crearYGuardarReporte(ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS, "", New rptConsolidadoComidas1,
    '                                    "", "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa,
    '                                     ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS, IO.Path.GetTempPath, "", True)

    '    Catch ex As Exception
    '        general.manejoErrores(ex)
    '    End Try
    'End Sub
    Sub imprimir()
        Cursor = Cursors.WaitCursor
        Dim reporte As New rptConsolidadoComidas1
        Try
            Funciones.getReporteNoFTP(reporte, "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa, "", Constantes.FORMATO_PDF)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
#End Region
#Region "Funciones"
    Function contarCantidadesComidas(ByRef tbl As DataTable) As Integer
        Return If(IsDBNull(tbl.Compute("SUM(Cantidad)", "")), 0, tbl.Compute("SUM(Cantidad)", ""))
    End Function
    Function calcularTotalCantidadesComidas() As Integer
        Return CInt(txtCantidadDesayunos.Text) + CInt(txtCantidadAlmuerzos.Text) + CInt(txtCantidadCenas.Text)
    End Function
    Function calcularCostosComidas(ByRef tbl As DataTable) As Double
        Return If(IsDBNull(tbl.Compute("SUM(Valor_total)", "")), 0, tbl.Compute("SUM(Valor_total)", ""))
    End Function
    Function calcularTotalCostosComidas() As Double
        Return CInt(txtCostosDesayunos.Text) + CInt(txtCostosAlmuerzos.Text) + CInt(txtCostoCenas.Text)
    End Function
    Function configurarDgvComida(colNombre As String, colCantidad As String, colValor As String, colTotal As String)
        Dim listaColumnas As New List(Of String)
        listaColumnas.Add(colNombre)
        listaColumnas.Add(colCantidad)
        listaColumnas.Add(colValor)
        listaColumnas.Add(colTotal)
        Return listaColumnas
    End Function

    Private Sub Fom_consolidado_comida_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub btOpcionDetallado_Click(sender As Object, e As EventArgs) Handles btOpcionDetallado.Click
        If SesionActual.tienePermiso(pDetallado ) Then
            Dim consolidado As New Form_consolidado_comida_detallado
            consolidado.Tag = Me.Tag
            General.cargarForm(consolidado)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        guardarRegistrosTemporales()
    End Sub
#End Region
End Class