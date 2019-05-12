Imports System.Threading

Public Class FormPEM
    Dim objPem As Pem
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pNuevo, pEditar, pAnular, pBuscar, pBuscarPedido, pBuscarPaciente As String
    Dim validacion As ValidacionPEM
    Private Sub FormPEM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
#Region "Metodos"
    Sub inicializarForm()
        CheckForIllegalCrossThreadCalls = False
        objPem = New Pem
        validacion = New ValidacionPEM
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        pBuscarPedido = permisoGeneral & "pp" & "05"
        pBuscarPaciente = permisoGeneral & "pp" & "06"
        configurarDatagrisviews()
        General.posLoadForm(Me, ToolStrip1, btnuevo, Nothing)
        btbuscar.Enabled = True
        If SesionActual.codigoEnlace = 2 Then
            chkExterno.Visible = False
        End If
        tiCTC.Start()
    End Sub
    Sub configurarDatagrisviews()
        configurarDgvMedicamentos()
        configurarDgvInsumosEnfermeria()
        configurarDgvInsumosFisio()
        configurarDgvNutricion()
        configurarDgvInfusiones()
        configurarDgvImpregnacion()
        configurarDgvDianosticos()
    End Sub
    Sub cargarDatosPaciente(ByVal codigoPaciente As Integer)
        Dim fila As DataRow
        Dim params As New List(Of String)
        objPem.idPaciente = codigoPaciente
        params.Add(objPem.idPaciente)
        fila = General.cargarItem(Consultas.PEMS_BUSQUEDA_TODOS_PACIENTES_INDIVIDUAL, params)
        txtNumeroDocumento.Text = fila.Item(1)
        txtPaciente.Text = fila.Item(2)
        txtEdad.Text = fila.Item(3)

        If objPem.swtManual = True Then
            cargarContratoEpsPaciente()
        End If
    End Sub
    Sub cargarContratoEpsPaciente()
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(objPem.idPaciente)
        fila = General.cargarItem(Consultas.PEMS_BUSQUEDA_CONTRATOS_EPS, params)
        txtCodigoContrato.ResetText()
        If Not IsNothing(fila) Then
            objPem.idEPS = fila.Item(0)

            txtContrato.Text = fila.Item(1)
            params.Clear()
            params.Add(objPem.idEPS)
            General.cargarCombo(Consultas.PEMS_BUSQUEDA_CLIENTE_EPS, params, "Cliente", "Id_cliente", cmbCliente)
            If cmbCliente.Items.Count <= 2 Then
                cmbCliente.SelectedIndex = 1
                cmbCliente.Enabled = False
            Else
                cmbCliente.Enabled = True
            End If
        Else
            objPem.idEPS = -1
            limpiarDatatables()
        End If

    End Sub
    Sub cargarInformacionPedido(ByVal fila As DataRow)
        objPem.codigoPedido = fila.Item("Código")
        objPem.tipoPedido = Funciones.getCodigoTipoPedido(fila.Item("Tipo"))
        cargarEncabezadoPEMS()
        llenarMedicamentos()
        llenarInfusiones()
        llenarImpregnacion()
        llenarNutricion()
        llenarInsumosEnf()
        llenarInsumosFis()
        llenarDiagnosticos()
        empalmarObjetoAlDiseño()
        NombrarTabs()
        verificarCantidadesDosis()
    End Sub
    Function verificarCantidadesDosis()
        objPem.tablaAdvertencia.Clear()
        verificarInfusiones()
        verificarImpregnaciones()
        configurarGrillaAdvertencia()
        mostrarPanelAdvertencias()
        If pnlAdvertencia.Visible = True Then
            Exec.SacudirCrtl(pnlAdvertencia)
        End If
        If objPem.tablaAdvertencia.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Sub configurarGrillaAdvertencia()
        dgvAdvertencias.DataSource = objPem.tablaAdvertencia
        If dgvAdvertencias.Columns.Contains("Cantidad") Then
            dgvAdvertencias.Columns("Cantidad").DefaultCellStyle.Font = New Drawing.Font("Arial", 12, FontStyle.Bold)
            dgvAdvertencias.Columns("Cantidad").DefaultCellStyle.ForeColor = Color.Red
        End If
        dgvAdvertencias.ReadOnly = True
    End Sub
    Sub verificarInfusiones()
        Dim velocidad As Double = 0
        Dim concentracion As Double = 0
        Dim cantidadProducto As Integer = 0
        For indicefila = 0 To objPem.tablaInfusiones.Rows.Count - 1
            velocidad = 0
            concentracion = 0
            cantidadProducto = 0
            If objPem.tablaInfusiones.Rows(indicefila).Item("Producto_Disolvente") = 0 Then
                velocidad = objPem.tablaInfusiones.Rows(indicefila).Item("Velocidad")
                concentracion = objPem.tablaInfusiones.Rows(indicefila).Item("Concentracion")
                cantidadProducto = Math.Ceiling((velocidad * Constantes.NUMEROS_DE_HORAS_DIA) / concentracion)
                If cantidadProducto >= Constantes.CANTIDAD_MEDICAMENTOS_LIMITE_ADVERTENCIA Then
                    objPem.tablaAdvertencia.Rows.Add()
                    Dim numeroFila As Integer = objPem.tablaAdvertencia.Rows.Count - 1
                    objPem.tablaAdvertencia.Rows(numeroFila).Item("Descripcion") = objPem.tablaInfusiones.Rows(indicefila).Item("Descripcion")
                    objPem.tablaAdvertencia.Rows(numeroFila).Item("Cantidad") = cantidadProducto
                    objPem.tablaAdvertencia.Rows(numeroFila).Item("Tipo") = "INFUSION"
                End If
            End If
        Next
    End Sub
    Sub verificarImpregnaciones()
        Dim velocidad As Double = 0
        Dim concentracion As Double = 0
        Dim cantidadProducto As Integer = 0
        For indicefila = 0 To objPem.tablaImpregnaciones.Rows.Count - 1
            velocidad = 0
            concentracion = 0
            cantidadProducto = 0
            If objPem.tablaImpregnaciones.Rows(indicefila).Item("Producto_Disolvente") = 0 Then
                velocidad = objPem.tablaImpregnaciones.Rows(indicefila).Item("Velocidad")
                concentracion = objPem.tablaImpregnaciones.Rows(indicefila).Item("Concentracion")
                cantidadProducto = Math.Ceiling((velocidad / concentracion))
                If cantidadProducto >= Constantes.CANTIDAD_MEDICAMENTOS_LIMITE_ADVERTENCIA Then
                    objPem.tablaAdvertencia.Rows.Add()
                    Dim numeroFila As Integer = objPem.tablaAdvertencia.Rows.Count - 1
                    objPem.tablaAdvertencia.Rows(numeroFila).Item("Descripcion") = objPem.tablaImpregnaciones.Rows(indicefila).Item("Descripcion")
                    objPem.tablaAdvertencia.Rows(numeroFila).Item("Cantidad") = cantidadProducto
                    objPem.tablaAdvertencia.Rows(numeroFila).Item("Tipo") = "IMPRESION"
                End If
            End If
        Next
    End Sub
    Sub mostrarPanelAdvertencias()
        pnlAdvertencia.BringToFront()
        If objPem.tablaAdvertencia.Rows.Count > 0 Then
            pnlAdvertencia.Visible = Not pnlAdvertencia.Visible
        End If
    End Sub
    Sub cargarEncabezadoPEMS()
        Dim params As New List(Of String)

        Dim fila As DataRow
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim consulta As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_ENCABEZADO_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_ENCABEZADO)
        fila = General.cargarItem(consulta, params)

        txtHistoriaClinica.Text = fila.Item(0)
        txtNumeroDocumento.Text = fila.Item(1)
        txtPaciente.Text = fila.Item(2)
        txtCama.Text = fila.Item(4)
        txtEdad.Text = fila.Item(5)
        txtContrato.Text = fila.Item(7)
        llenarComboClienteGeneral(fila.Item(6))
        cmbCliente.SelectedValue = fila.Item(8)
        objPem.idPaciente = (fila.Item(10))
        cargarAreasServicios(fila.Item(6))
        establecerAreasContratadas(fila.Item(9))
        objPem.idContrato = fila.Item(6)
        If objPem.tipoPedido = Constantes.PENDIENTE Then
            LbConteo.Text = fila.Item(11)
        End If
    End Sub
    Public Sub establecerAreasContratadas(ByVal parametro As String)
        For indiceNodo = 0 To arbolAreasServicios.Nodes.Count - 1
            If arbolAreasServicios.Nodes(indiceNodo).Name <> parametro Then
                arbolAreasServicios.Nodes(indiceNodo).Checked = False
            End If
        Next
    End Sub
    Sub llenarComboClienteGeneral(ByVal codigoContrato As String)
        Dim params As New List(Of String)
        params.Add(codigoContrato)
        General.cargarCombo(Consultas.PEMS_BUSQUEDA_CLIENTE_CONTRATO_ASOCIADO, params, "Cliente", "Id_cliente", cmbCliente)
    End Sub
    Sub cargarAreasServicios(ByVal codigocliente As String)
        Dim params As New List(Of String)
        params.Add(codigocliente)
        General.llenarTabla(Consultas.PEMS_BUSQUEDA_AREAS_SERVICIO, params, objPem.tablaAreas)

        Dim coleccionFilas As DataRowCollection
        coleccionFilas = objPem.tablaAreas.Rows
        arbolAreasServicios.Nodes.Clear()
        'desactivarPestañas()
        For Each filaUnitaria In coleccionFilas
            Dim nodo As New System.Windows.Forms.TreeNode
            nodo.Name = filaUnitaria("codigo").ToString()
            nodo.Text = filaUnitaria("Descripcion").ToString()
            arbolAreasServicios.Nodes.Add(nodo)
            nodo.Checked = True
        Next
        If objPem.swtManual = True Then
            arbolAreasServicios.Enabled = True
        Else
            arbolAreasServicios.Enabled = False
        End If
    End Sub
    Sub llenarMedicamentos()
        Dim params As New List(Of String)
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim consulta As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_MEDICAMENTOS_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_MEDICAMENTOS)
        cargarDatosGeneralesTablas(consulta, objPem.tablaMedicamentos, params)
        For indiceFila = 0 To objPem.tablaMedicamentos.Rows.Count - 1
            calcularConcentracionFinal(indiceFila)
        Next
    End Sub
    Sub llenarInfusiones()
        Dim params As New List(Of String)
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim consulta As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INFUSIONES_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INFUSIONES)
        cargarDatosGeneralesTablas(consulta, objPem.tablaInfusiones, params)
        llenarMezcla()
    End Sub
    Sub llenarMezcla()
        Dim lectorMezclas As DataRow
        Dim params As New List(Of String)
        For indiceFila = 0 To objPem.tablaInfusiones.Rows.Count - 1
            lectorMezclas = Nothing
            params.Clear()
            params.Add(objPem.codigoPedido)
            params.Add(objPem.tablaInfusiones.Rows(indiceFila).Item("Consecutivo"))
            params.Add(objPem.tipoPedido)
            Dim consulta As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INFUSIONES_MEZCLAS_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INFUSIONES_MEZCLAS)
            lectorMezclas = General.cargarItem(consulta, params)
            If Not IsNothing(lectorMezclas) Then
                objPem.agregarTabla(objPem.nombrarMezclaInfusion(indiceFila))

                cargarDatosGeneralesTablas(consulta, objPem.dtTablaMezclas.Tables(objPem.nombrarMezclaInfusion(indiceFila)), params)

                General.IsExistente(dgvInfusion, "Mezcla", indiceFila)
            Else
                General.IsNotExistente(dgvInfusion, "Mezcla", indiceFila)
            End If
        Next
    End Sub
    Sub llenarImpregnacion()
        Dim params As New List(Of String)
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim consulta As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_IMPREGNACIONES_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_IMPREGNACIONES)
        cargarDatosGeneralesTablas(consulta, objPem.tablaImpregnaciones, params)
    End Sub
    Sub llenarNutricion()
        Dim params As New List(Of String)
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim fila As DataRow
        Dim cadena, cadenaDetalle As String
        cadena = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_NUTRICION_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_NUTRICION)
        cadenaDetalle = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_NUTRICION_DETALLE_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_NUTRICION_DETALLE)
        fila = General.cargarItem(cadena, params)
        objPem.razon = If(fila Is Nothing, 0, fila.Item(0))
        params.Clear()
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        cargarDatosGeneralesTablas(cadenaDetalle, objPem.tablaNutricion, params)
    End Sub
    Sub llenarInsumosEnf()
        Dim params As New List(Of String)
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim cadena As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INSUMOS_ENFERMERIA_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INSUMOS_ENFERMERIA)
        cargarDatosGeneralesTablas(cadena, objPem.tablaInsumosEnfermeria, params)
    End Sub
    Sub llenarInsumosFis()
        Dim params As New List(Of String)
        params.Add(objPem.codigoPedido)
        params.Add(objPem.tipoPedido)
        Dim cadena As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INSUMOS_FISIOTERAPIA_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_INSUMOS_FISIOTERAPIA)
        cargarDatosGeneralesTablas(cadena, objPem.tablaInsumosFisioterapia, params)
    End Sub
    Sub llenarDiagnosticos()
        Dim params As New List(Of String)
        params.Add(txtHistoriaClinica.Text)
        Dim cadena As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_DIAGNOSTICOS_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_DIAGNOSTICOS)
        cargarDatosGeneralesTablas(cadena, objPem.tablaDiagnosticos, params)
    End Sub
    Sub cargarDatosGeneralesTablas(ByVal query As String,
                                   ByRef datatable As DataTable,
                                   ByVal params As List(Of String))
        General.llenarTabla(query, params, datatable)
    End Sub
    Sub empalmarObjetoAlDiseño()
        txtCodigo.Text = objPem.codigoPem
        txtCodigoPedido.Text = objPem.codigoPedido
        txtRazón.Text = objPem.razon
        txtCodigoContrato.Text = objPem.idContrato
        txtVolumenTotal.Text = calcularVolumenTotal()
    End Sub
    Sub NombrarTabs(Optional limpiar As Boolean = False)
        'If objPem.swtManual = True Then
        '    Dim cantidadLimpiar As Integer
        '    If limpiar = True Then
        '        cantidadLimpiar = 0
        '    Else
        '        cantidadLimpiar = 1
        '    End If

        '    tabMedicacion.Text = "Medicación (" & objPem.tablaMedicamentos.Rows.Count - cantidadLimpiar & ")"
        '    tabImpreganacion.Text = "Impregnación (" & objPem.tablaImpregnaciones.Rows.Count - cantidadLimpiar & ")"
        '    tabInfusion.Text = "Infusión (" & objPem.tablaInfusiones.Rows.Count - cantidadLimpiar & ")"
        '    TabNutricion.Text = "Nutrición (" & objPem.tablaNutricion.Rows.Count - cantidadLimpiar & ")"
        '    Insumos.Text = "Insumos (" & (objPem.tablaInsumosEnfermeria.Rows.Count - cantidadLimpiar) + (objPem.tablaInsumosFisioterapia.Rows.Count - cantidadLimpiar) & ")"
        'Else
        tabMedicacion.Text = "Medicación (" & objPem.tablaMedicamentos.Rows.Count & ")"
        tabImpreganacion.Text = "Impregnación (" & objPem.tablaImpregnaciones.Rows.Count & ")"
        tabInfusion.Text = "Infusión (" & objPem.tablaInfusiones.Rows.Count & ")"
        TabNutricion.Text = "Nutrición (" & objPem.tablaNutricion.Rows.Count & ")"
        Insumos.Text = "Insumos (" & (objPem.tablaInsumosEnfermeria.Rows.Count) + (objPem.tablaInsumosFisioterapia.Rows.Count) & ")"
        ' End If
    End Sub
    Sub configurarDgvMedicamentos()
        With dgvMedicacion
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Concentracion").ReadOnly = True
            .Columns("Concentracion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Concentracion").DataPropertyName = "ConcentracionMedicamento"
            .Columns("ConcentracionDosis").ReadOnly = True
            .Columns("ConcentracionDosis").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionDosis").DataPropertyName = "DosisUnitaria"
            .Columns("Cant_Dosis").ReadOnly = True
            .Columns("Cant_Dosis").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cant_Dosis").DataPropertyName = "cantidadDosisUnitaria"
            .Columns("Cantidad_Reconstituyente").ReadOnly = True
            .Columns("Cantidad_Reconstituyente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad_Reconstituyente").DataPropertyName = "CantidadReconstituyente"
            .Columns("Reconstituyente").ReadOnly = True
            .Columns("Reconstituyente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Reconstituyente").DataPropertyName = "Reconstituyente"
            .Columns("Total_Disolvente").ReadOnly = True
            .Columns("Total_Disolvente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total_Disolvente").DataPropertyName = "TotalDisolventeMedicamento"
            .Columns("Vol_jeringa").ReadOnly = True
            .Columns("Vol_jeringa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Vol_jeringa").DataPropertyName = "VolumenJeringa"
            .Columns("Cant_diluyente").ReadOnly = True
            .Columns("Cant_diluyente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cant_diluyente").DataPropertyName = "CantidadDisolvente"
            .Columns("Disolvente").ReadOnly = True
            .Columns("Disolvente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Disolvente").DataPropertyName = "Disolvente"
            .Columns("total_dilucion").ReadOnly = True
            .Columns("total_dilucion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("total_dilucion").DataPropertyName = "TotalDisusionMedicamento"
            .Columns("Concentracion_final").ReadOnly = True
            .Columns("Concentracion_final").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Concentracion_final").DataPropertyName = "ConcentracionFinal"
            .Columns("Frecuencia").ReadOnly = True
            .Columns("Frecuencia").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Frecuencia").DataPropertyName = "Frecuencia"
            .Columns("Hora_Inicial").ReadOnly = True
            .Columns("Hora_Inicial").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Hora_Inicial").DataPropertyName = "HoraInicio"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaMedicamentos
        End With
    End Sub
    Sub configurarDgvInfusiones()
        With dgvInfusion
            .Columns("DescripcionInf").ReadOnly = True
            .Columns("DescripcionInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionInf").DataPropertyName = "Descripcion"
            .Columns("ConcentracioInf").ReadOnly = True
            .Columns("ConcentracioInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracioInf").DataPropertyName = "ConcentracionMedicamento"
            .Columns("DosisInf").ReadOnly = True
            .Columns("DosisInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DosisInf").DataPropertyName = "Dosis"
            .Columns("Velocidad").ReadOnly = True
            .Columns("Velocidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Velocidad").DataPropertyName = "Velocidad"
            .Columns("Descripcion_Disolvente").ReadOnly = True
            .Columns("Descripcion_Disolvente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion_Disolvente").DataPropertyName = "Disolvente"
            .Columns("TotalDisolventeInf").ReadOnly = True
            .Columns("TotalDisolventeInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("TotalDisolventeInf").DataPropertyName = "TotalDisolventeInfusion"
            .Columns("CantidadDisolventeInf").ReadOnly = True
            .Columns("CantidadDisolventeInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDisolventeInf").DataPropertyName = "CantidadDisolvente"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaInfusiones
        End With
    End Sub
    Sub configurarDgvNutricion()
        With dgvNutricion
            .Columns("DescripcionNut").ReadOnly = True
            .Columns("DescripcionNut").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionNut").DataPropertyName = "Descripcion"
            .Columns("Requerimiento").ReadOnly = True
            .Columns("Requerimiento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Requerimiento").DataPropertyName = "Requerimiento"
            .Columns("Volumenes").ReadOnly = True
            .Columns("Volumenes").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Volumenes").DataPropertyName = "Volumenes"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaNutricion
        End With
    End Sub
    Sub configurarDgvInsumosFisio()
        With dgvInsumosFisioterapia
            .Columns("DescripcionFisio").ReadOnly = True
            .Columns("DescripcionFisio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionFisio").DataPropertyName = "Descripcion"
            .Columns("CantidadFisio").ReadOnly = True
            .Columns("CantidadFisio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadFisio").DataPropertyName = "Cantidad"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaInsumosFisioterapia
        End With
    End Sub
    Sub configurarDgvInsumosEnfermeria()
        With dgvInsumosEnfermeria
            .Columns("DescripcionInsEnf").ReadOnly = True
            .Columns("DescripcionInsEnf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionInsEnf").DataPropertyName = "Descripcion"
            .Columns("CantidadEnf").ReadOnly = True
            .Columns("CantidadEnf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadEnf").DataPropertyName = "Cantidad"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaInsumosEnfermeria
        End With
    End Sub
    Sub configurarDgvImpregnacion()
        With dgvImpregnacion
            .Columns("descripcionImp").ReadOnly = True
            .Columns("descripcionImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("descripcionImp").DataPropertyName = "Descripcion"
            .Columns("ConcentracionImp").ReadOnly = True
            .Columns("ConcentracionImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionImp").DataPropertyName = "ConcentracionMedicamento"
            .Columns("DosisImp").ReadOnly = True
            .Columns("DosisImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DosisImp").DataPropertyName = "Dosis"
            .Columns("VelocidadImp").ReadOnly = True
            .Columns("VelocidadImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("VelocidadImp").DataPropertyName = "Velocidad"
            .Columns("DisolventeImp").ReadOnly = True
            .Columns("DisolventeImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DisolventeImp").DataPropertyName = "Disolvente"
            .Columns("TotalDisolventeImp").ReadOnly = True
            .Columns("TotalDisolventeImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("TotalDisolventeImp").DataPropertyName = "TotalDisolventeImpregnacion"
            .Columns("CantidadDisolventeImp").ReadOnly = True
            .Columns("CantidadDisolventeImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDisolventeImp").DataPropertyName = "CantidadDisolvente"
            .Columns("Hora_InicialImp").ReadOnly = True
            .Columns("Hora_InicialImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Hora_InicialImp").DataPropertyName = "Hora_Inicial"
            .Columns("Hora_InicialImp").Visible = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaImpregnaciones
        End With
    End Sub
    Sub configurardgvMezclas(ByVal pNombreTabla As String)
        With dgvMezcla
            .Columns("DescripcionMez").ReadOnly = True
            .Columns("DescripcionMez").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionMez").DataPropertyName = "Descripcion"
            .Columns("DosisMez").ReadOnly = True
            .Columns("DosisMez").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DosisMez").DataPropertyName = "Dosis"
            .Columns("CantidadMez").ReadOnly = True
            .Columns("CantidadMez").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadMez").DataPropertyName = "Cantidad"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.dtTablaMezclas.Tables(pNombreTabla)
        End With
    End Sub
    Sub configurarDgvDianosticos()
        With dgvDiagnostico
            .Columns("Diagnostico").ReadOnly = True
            .Columns("Diagnostico").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Diagnostico").DataPropertyName = "Descripcion"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPem.tablaDiagnosticos
        End With
    End Sub
    Sub buscarLiquidosDiluyentes(ByVal codigo As String,
                                 ByVal descripcion As String,
                                 ByVal indiceFila As Integer,
                                 ByRef tabla As DataTable,
                                 Optional ConcentracionDiluyente As String = "",
                                 Optional siglaDiluyente As String = "")
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
        Dim fila As DataRow
        Dim form As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_MEDICAMENTOS_DILUYENTES, params, TitulosForm.BUSQUEDA_MEDICAMENTO, False)
        fila = form.rowResultados
        If Not IsNothing(fila) Then
            tabla.Rows(indiceFila).Item(codigo) = fila.Item(0)
            tabla.Rows(indiceFila).Item(descripcion) = fila.Item(1)
            If ConcentracionDiluyente <> "" Then
                tabla.Rows(indiceFila).Item(ConcentracionDiluyente) = fila.Item(2)
            End If
            If siglaDiluyente <> "" Then
                tabla.Rows(indiceFila).Item(siglaDiluyente) = fila.Item(5)
            End If
        End If
        tabla.AcceptChanges()
    End Sub
    Sub visualizacionPanelMezclas()
        If panelMezcla.Visible = True Then
            panelMezcla.Visible = False
        Else
            panelMezcla.Visible = True
            dgvMezcla.Focus()
        End If
    End Sub
    Sub pemsAutomatico()
        txtNumeroDocumento.ReadOnly = True
        txtPaciente.ReadOnly = True
        txtCama.ReadOnly = True
        txtHistoriaClinica.ReadOnly = True
        txtEdad.ReadOnly = True
        cmbCliente.Enabled = False
        txtCodigoContrato.ReadOnly = True
        txtContrato.ReadOnly = True
        dgvDiagnostico.ReadOnly = True
        btbuscarPedido.Enabled = True
        btnBuscarPaciente.Enabled = False
    End Sub
    Sub pemsManual()
        txtNumeroDocumento.ReadOnly = False
        txtPaciente.ReadOnly = True
        txtCama.ReadOnly = True
        txtHistoriaClinica.ReadOnly = True
        txtEdad.ReadOnly = True
        cmbCliente.Enabled = False
        txtCodigoContrato.ReadOnly = True
        txtContrato.ReadOnly = True
        dgvDiagnostico.ReadOnly = True
        btbuscarPedido.Enabled = False
        btnBuscarPaciente.Enabled = True
        txtNumeroDocumento.ReadOnly = True
    End Sub
    Sub colocarFilas()
        limpiarDatatables()
        objPem.tablaMedicamentos.Rows.Add()
        objPem.tablaInfusiones.Rows.Add()
        objPem.tablaNutricion.Rows.Add()
        objPem.tablaInsumosEnfermeria.Rows.Add()
        objPem.tablaInsumosFisioterapia.Rows.Add()
        objPem.tablaImpregnaciones.Rows.Add()
        objPem.tablaProcedimientos.Rows.Add()

        objPem.tablaMedicamentos.AcceptChanges()
        objPem.tablaInfusiones.AcceptChanges()
        objPem.tablaNutricion.AcceptChanges()
        objPem.tablaInsumosEnfermeria.AcceptChanges()
        objPem.tablaInsumosFisioterapia.AcceptChanges()
        objPem.tablaImpregnaciones.AcceptChanges()
        objPem.tablaProcedimientos.AcceptChanges()
    End Sub
    Sub limpiarDatatables()
        objPem.tablaMedicamentos.Clear()
        objPem.tablaInfusiones.Clear()
        objPem.tablaNutricion.Clear()
        objPem.tablaInsumosEnfermeria.Clear()
        objPem.tablaInsumosFisioterapia.Clear()
        objPem.tablaImpregnaciones.Clear()
        objPem.tablaProcedimientos.Clear()
    End Sub
    Sub definirTipoPems()
        'If MsgBox(Mensajes.MSM_PEMS_MANUAL, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    objPem.swtManual = True
        '    pemsManual()
        'Else
        objPem.swtManual = False
        pemsAutomatico()
        'End If
        txtVolumenTotal.ReadOnly = True
        txtRazón.ReadOnly = True
    End Sub
    Sub buscarMedicamentosManual(ByRef dgv As DataGridView,
                                   ByRef tabla As DataTable,
                                   ByVal columnaInicio As Integer,
                                   ByVal columnaFin As Integer,
                                   ByVal nombreColumna As String,
                                   ByVal columnaNoRepetible As Integer)
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(txtCodigoContrato.Text)
        params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
        General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO_GENERAL,
                              params,
                              TitulosForm.BUSQUEDA_MEDICAMENTO,
                              dgv,
                              tabla,
                              columnaInicio,
                              columnaFin,
                              dgv.Columns(nombreColumna).Index,
                              False,
                              True,
                              columnaNoRepetible,,
                              Nothing)
    End Sub
    Sub buscarInsumosManual(ByRef dgv As DataGridView,
                              ByRef tabla As DataTable,
                              ByVal columnaInicio As Integer,
                              ByVal columnaFin As Integer,
                              ByVal nombreColumna As String)
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
        General.busquedaItems(Consultas.BUSQUEDA_INSUMOS_GENERAL,
                              params,
                              TitulosForm.BUSQUEDA_INSUMOS,
                              dgv,
                              tabla,
                              columnaInicio,
                              columnaFin,
                              dgv.Columns(nombreColumna).Index,
                              False,
                              True,
                              0,,
                              Nothing)
    End Sub
    Sub quitarFila(ByVal tabla As DataTable,
                   ByVal fila As Integer)
        Funciones.quitarFilas(tabla, fila)
        NombrarTabs()
    End Sub
    Sub calcularConcentracionFinal(ByVal fila As Integer)
        Dim totalConcentracion As Double = If(IsDBNull(objPem.tablaMedicamentos.Rows(fila).Item("DosisUnitaria")), 0, objPem.tablaMedicamentos.Rows(fila).Item("DosisUnitaria"))
        Dim sigla As String = ""
        If objPem.tablaMedicamentos.Rows(fila).Item("CantidadDisolvente") > 0 AndAlso Not IsDBNull(objPem.tablaMedicamentos.Rows(fila).Item("DosisUnitaria")) Then
            totalConcentracion = objPem.tablaMedicamentos.Rows(fila).Item("DosisUnitaria") / (objPem.tablaMedicamentos.Rows(fila).Item("TotalDisusion") * objPem.tablaMedicamentos.Rows(fila).Item("CantidadDisolvente"))
            sigla = objPem.tablaMedicamentos.Rows(fila).Item("UnidadDilusion")
        ElseIf Not IsDBNull(objPem.tablaMedicamentos.Rows(fila).Item("DosisUnitaria")) AndAlso objPem.tablaMedicamentos.Rows(fila).Item("CantidadReconstituyente") > 0 Then
            totalConcentracion = objPem.tablaMedicamentos.Rows(fila).Item("Concentracion") / (objPem.tablaMedicamentos.Rows(fila).Item("TotalDisolvente") * objPem.tablaMedicamentos.Rows(fila).Item("CantidadReconstituyente"))
            sigla = objPem.tablaMedicamentos.Rows(fila).Item("UnidadReconstituyente")
        End If
        objPem.tablaMedicamentos.Rows(fila).Item("ConcentracionFinal") = totalConcentracion.ToString & "  " & If(sigla = "", objPem.tablaMedicamentos.Rows(fila).Item("UnidadMedicamento"), objPem.tablaMedicamentos.Rows(fila).Item("UnidadMedicamento") & "/" & sigla)
    End Sub
    Sub asignarNoAplicaDiluyente(ByVal tabla As DataTable, fila As Integer, nombreColumna As String)
        tabla.Rows(fila).Item(nombreColumna) = "NO APLICA"
    End Sub
    Sub isCeldaActiva(ByRef dgv As DataGridView, e As DataGridViewCellEventArgs, nombreColumna As String)
        If Funciones.filaValida(e.RowIndex) Then
            If (Funciones.verificacionPosicionActual(dgv, e, nombreColumna) AndAlso objPem.swtManual = True) Then
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Sub confirmarCambiosEnDatgridview(ByRef dgv As DataGridView)
        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
    Sub quitarLiquido(ByRef tbl As DataTable,
                      nombreCodigoColumna As String,
                      nombreDescripcionColumna As String,
                      nombreColumnaCantidad As String,
                      nombreColumnaConcentracion As String,
                      Fila As Integer,
                      ByRef dgv As DataGridView,
                      nombreColumnaFoco As String)
        If Funciones.filaValida(Fila) AndAlso MsgBox(Mensajes.QUITAR_LIQUIDO, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            tbl.Rows(Fila).Item(nombreCodigoColumna) = Constantes.CODIGO_NO_VALIDO
            tbl.Rows(Fila).Item(nombreDescripcionColumna) = Constantes.DISOLVENTE_POR_DEFECTO
            tbl.Rows(Fila).Item(nombreColumnaCantidad) = 0
            tbl.Rows(Fila).Item(nombreColumnaConcentracion) = 0
            tbl.AcceptChanges()
            confirmarCambiosEnDatgridview(dgv)
            validacion.celdaFocoSeleccionada(dgv, nombreColumnaFoco)
        End If
    End Sub
    Sub desactivarPestañas()
        tabMedicacion.Parent = Nothing
        tabInfusion.Parent = Nothing
        tabImpreganacion.Parent = Nothing
        TabNutricion.Parent = Nothing
        Insumos.Parent = Nothing
    End Sub
    Sub empalmarDiseñoAlObjeto()
        objPem.codigoPedido = txtCodigoPedido.Text
        objPem.razon = If(txtRazón.Text = "", 0, txtRazón.Text)
        objPem.volumenTotal = If(txtVolumenTotal.Text = "", 0, txtVolumenTotal.Text)
        objPem.idContrato = txtCodigoContrato.Text
        objPem.fechaPem = dtpFechaPEM.Value
        objPem.listaAreaServicios.Clear()
        For indiceDiagnostico = 0 To arbolAreasServicios.Nodes.Count - 1
            If arbolAreasServicios.Nodes(indiceDiagnostico).Checked Then
                objPem.listaAreaServicios.Add(arbolAreasServicios.Nodes(indiceDiagnostico).Name)
            End If
        Next
    End Sub
    Sub estabecerAreasPermitidas()
        Dim tablaConfiguracionAreasServicio As New DataTable
        Dim params As New List(Of String)
        'desactivarPestañas()
        'For indiceNodo = 0 To arbolAreasServicios.Nodes.Count - 1
        '    If arbolAreasServicios.Nodes(indiceNodo).Checked Then
        '        params.Clear()
        '        params.Add(arbolAreasServicios.Nodes(indiceNodo).Name)
        '        General.llenarTabla(Consultas.PEMS_BUSQUEDA_CONFIGURACION_AREA_SERVICIO, params, tablaConfiguracionAreasServicio)
        '        For indiceFilaActual = 0 To tablaConfiguracionAreasServicio.Rows.Count - 1
        '            If tablaConfiguracionAreasServicio.Rows(indiceFilaActual).Item("Codigo_GrupoServicio") = Constantes.SERVICIO_FARMACEUTICO Then
        '                tabMedicacion.Parent = tabGeneral
        '                tabInfusion.Parent = tabGeneral
        '                tabImpreganacion.Parent = tabGeneral
        '                TabNutricion.Parent = tabGeneral
        '                Insumos.Parent = tabGeneral
        '            End If
        '        Next
        '    End If
        'Next
        colocarNumeroAreas()
    End Sub
    Sub colocarNumeroAreas()
        Dim contador As Integer = 0
        Dim area As String = ""
        For indiceNodo = 0 To arbolAreasServicios.Nodes.Count - 1
            If arbolAreasServicios.Nodes(indiceNodo).Checked Then
                area = arbolAreasServicios.Nodes(indiceNodo).Text
                contador += 1
                If contador > 1 Then
                    area = Constantes.VARIAS_AREAS_SERVICIO
                    Exit For
                End If
            End If
        Next
        lblAreaServico.Text = area
    End Sub
    Sub validarNumerosReales(ByRef evento As DataGridViewEditingControlShowingEventArgs)
        AddHandler evento.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Sub cargarDatosGuardadosPemsEXT(ByVal filaDevelta As DataRow)
        limpiarDatatables()
        chkExterno.Checked = True
        objPem.codigoPem = filaDevelta.Item(0)
        objPem.tipoPedido = Funciones.getCodigoTipoPedido(filaDevelta.Item(5))
        cargarEncabezadoPem(objPem.codigoPem)
        cargarMedicamentosGuardados(objPem.codigoPem)
        cargardiagnosticosGuardados(objPem.codigoPem)
        cargarInfusionesGuardados(objPem.codigoPem)
        'cargarProcedimientosGuardados(objPem.codigoPem)
        cargarInsumosEnfermeriaGuardados(objPem.codigoPem)
        cargarInsumosFisioterapiaGuardados(objPem.codigoPem)
        cargarImpregnacionesGuardados(objPem.codigoPem)
        cargarNutricionGuardados(objPem.codigoPem)
        NombrarTabs()
        empalmarObjetoAlDiseño()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, Nothing, bteditar, btanular)
        btbuscar.Enabled = True
    End Sub
    Sub cargarDatosGuardadosPems(ByVal filaDevelta As DataRow)
        limpiarDatatables()
        chkExterno.Checked = False
        objPem.codigoPem = filaDevelta.Item(0)
        objPem.tipoPedido = Funciones.getCodigoTipoPedido(filaDevelta.Item(5))
        cargarEncabezadoPem(objPem.codigoPem)
        cargarMedicamentosGuardados(objPem.codigoPem)
        cargardiagnosticosGuardados(objPem.codigoPem)
        cargarInfusionesGuardados(objPem.codigoPem)
        'cargarProcedimientosGuardados(objPem.codigoPem)
        cargarInsumosEnfermeriaGuardados(objPem.codigoPem)
        cargarInsumosFisioterapiaGuardados(objPem.codigoPem)
        cargarImpregnacionesGuardados(objPem.codigoPem)
        cargarNutricionGuardados(objPem.codigoPem)
        NombrarTabs()
        empalmarObjetoAlDiseño()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, Nothing, bteditar, btanular)
        btbuscar.Enabled = True
    End Sub
    Sub cargarEncabezadoPem(ByVal pem As Integer)
        Dim params As New List(Of String)
        Dim fila As DataRow
        params.Add(pem)
        params.Add(objPem.tipoPedido)
        Dim cadena As String = getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_ENCABEZADO_EXT, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_ENCABEZADO)

        fila = General.cargarItem(cadena, params)
        objPem.codigoPedido = fila(0).ToString
        objPem.fechaPem = fila(1).ToString
        objPem.codigoPedido = fila(2).ToString
        objPem.idPaciente = fila(3).ToString
        txtPaciente.Text = fila(4).ToString
        txtHistoriaClinica.Text = fila(5).ToString
        txtCama.Text = fila(6).ToString
        txtEdad.Text = fila(7).ToString
        txtNumeroDocumento.Text = fila(8)
        objPem.idContrato = fila(9).ToString
        txtContrato.Text = fila(10).ToString
        cmbCliente.Text = fila(11).ToString
        cargarAreasServicios(objPem.idContrato)
    End Sub
    Sub cargardiagnosticosGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaDiagnosticos, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_DIAGNOSTICOS)
    End Sub
    Sub cargarMedicamentosGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaMedicamentos, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_MEDICAMENTOS)
    End Sub
    Sub cargarInfusionesGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaInfusiones, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_INFUSIONES)
    End Sub
    Sub cargarImpregnacionesGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaImpregnaciones, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_IMPREGNACIONES)
    End Sub
    Sub cargarProcedimientosGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaProcedimientos, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_PROCEDIMIENTOS)
    End Sub
    Sub cargarInsumosEnfermeriaGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaInsumosEnfermeria, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_INSUMOS_ENFERMERIA)
    End Sub
    Sub cargarInsumosFisioterapiaGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaInsumosFisioterapia, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_INSUMOS_FISIOTERAPIA)
    End Sub
    Sub cargarNutricionGuardados(ByVal codigoPem As Integer)
        llenarTablasGuardadas(codigoPem, objPem.tablaNutricion, Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_NUTRICION)
    End Sub
    Sub llenarTablasGuardadas(ByVal codigoPem As Integer, ByVal tabla As DataTable, ByVal consultas As String)
        Dim params As New List(Of String)
        params.Add(codigoPem)
        General.llenarTabla(consultas, params, tabla)
    End Sub
    Sub cargarCTCPendientes()
        Dim fileResultado As DataRow
        fileResultado = General.cargarItem(Consultas.CTC_PENDIENTES)

        If Not IsNothing(fileResultado) Then
            lblHC.Text = fileResultado.Item("HC")
            lblAM.Text = fileResultado.Item("AM")
            lblAF.Text = fileResultado.Item("AF")
        Else
            lblHC.Text = 0
            lblAM.Text = 0
            lblAF.Text = 0
        End If
        If lblHC.Text <> "0" OrElse lblAM.Text <> "0" OrElse lblAF.Text <> "0" Then
            btnCTC.BackColor = Color.Yellow
            btnCTC.ForeColor = Color.Red
        Else
            btnCTC.BackColor = Color.Green
            btnCTC.ForeColor = Color.Black
        End If
    End Sub
    Function getCadenaBusqueda(ByVal cadenaExter As String, ByVal cadenaInter As String) As String
        If chkExterno.Checked Then
            Return cadenaExter
        Else
            Return cadenaInter
        End If
    End Function
#End Region
#Region "Funciones"
    Function calcularVolumenTotal() As Double
        Dim valor As Double
        valor = If(IsDBNull(objPem.tablaNutricion.Compute("Sum(Volumenes)", "")), 0, objPem.tablaNutricion.Compute("Sum(Volumenes)", ""))
        Return valor
    End Function
    Function isValidForm(ByRef objPem As Pem) As Boolean
        Dim paramsInf, paramsImp As New List(Of Object)
        If objPem.tablaInfusiones.Rows.Count > 1 Then
            paramsInf = validacion.verificarDgvInfImp(objPem.tablaInfusiones, dgvInfusion, "Dosis", "Velocidad", "CantidadDisolvente", "DosisInf", "Velocidad", "CantidadDisolventeInf", "disolventeInf", "Infusión")
        End If
        If objPem.tablaImpregnaciones.Rows.Count > 1 Then
            paramsImp = validacion.verificarDgvInfImp(objPem.tablaImpregnaciones, dgvImpregnacion, "Dosis", "Velocidad", "CantidadDisolvente", "DosisImp", "VelocidadImp", "CantidadDisolventeImp", "DisolventeImpBtn", "Impreganción")
        End If

        If txtNumeroDocumento.Text = "" Then
            MsgBox("No ha seleccionado ningun paciente!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf txtCodigoContrato.Text = "" Then
            MsgBox("No hay ningún contrato seleccionado por favor verifique!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf cmbCliente.SelectedValue = -1 Then
            MsgBox("No ha seleccionado ningun cliente!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf verificarDgvMedicamentos(objPem) = False Then
            Return False
        ElseIf objPem.tablaInfusiones.Rows.Count > 1 AndAlso paramsInf.Count > 0 Then
            If paramsInf.Item(1) = False Then
                MsgBox(paramsInf(0), MsgBoxStyle.Exclamation)
                Return False
            End If
        ElseIf objPem.tablaImpregnaciones.Rows.Count > 1 AndAlso paramsImp.Count > 0 Then
            If paramsImp.Item(1) = False Then
                MsgBox(paramsInf(0), MsgBoxStyle.Exclamation)
                Return False
            End If
        ElseIf verificarCantidadesDosis() = False Then
            Return False
        End If
        Return True
    End Function
    Function verificarDgvMedicamentos(ByRef objPem As Pem) As Boolean
        Dim filasMed As DataRowCollection = objPem.tablaMedicamentos.Rows
        Dim totalFilas = If(objPem.swtManual = True, filasMed.Count - 2, filasMed.Count - 1)
        For indiceFilaActual = 0 To totalFilas
            If filasMed(indiceFilaActual).Item("DosisUnitaria") <= 0 Then
                MsgBox("colocar la concentracion e la dosis!", MsgBoxStyle.Exclamation)
                validacion.celdaFocoSeleccionada(dgvMedicacion, "ConcentracionDosis", indiceFilaActual)
                Return False
            ElseIf filasMed(indiceFilaActual).Item("cantidadDosisUnitaria") <= 0 Then
                MsgBox("Colocar la cantidad uniaria de la dosis!", MsgBoxStyle.Exclamation)
                validacion.celdaFocoSeleccionada(dgvMedicacion, "Cant_Dosis", indiceFilaActual)
                Return False
            ElseIf filasMed(indiceFilaActual).Item("CodigoReconstituyente") > 0 AndAlso filasMed(indiceFilaActual).Item("CantidadReconstituyente") = 0 Then
                MsgBox("Colocar la cantidad de el reconstituyente!", MsgBoxStyle.Exclamation)
                validacion.celdaFocoSeleccionada(dgvMedicacion, "Cantidad_Reconstituyente", indiceFilaActual)
                Return False
            ElseIf filasMed(indiceFilaActual).Item("codigoDisolvente") > 0 AndAlso filasMed(indiceFilaActual).Item("CantidadDisolvente") = 0 Then
                MsgBox("Colocar la cantidad de el diluyente!", MsgBoxStyle.Exclamation)
                validacion.celdaFocoSeleccionada(dgvMedicacion, "Cant_diluyente", indiceFilaActual)
                Return False
            ElseIf filasMed(indiceFilaActual).Item("Aplica_disolvente") = True Then
                If filasMed(indiceFilaActual).Item("CodigoReconstituyente") = -1 AndAlso
                    MsgBox("Debe escger el recontituyente!", MsgBoxStyle.Exclamation) Then
                    validacion.celdaFocoSeleccionada(dgvMedicacion, "SeleccionReconstituyente", indiceFilaActual)
                    Return False
                ElseIf filasMed(indiceFilaActual).Item("codigoDisolvente") = -1 Then
                    MsgBox("Debe escger el diluyente!", MsgBoxStyle.Exclamation)
                    validacion.celdaFocoSeleccionada(dgvMedicacion, "SeleccionDisolvente", indiceFilaActual)
                    Return False
                End If
            End If
        Next
        Return True
    End Function
#End Region
#Region "Botones"
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        mostrarPanelAdvertencias()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            Dim objPemBLL As New PemBLL
            If objPemBLL.VeriificarDespachoDePem(objPem) Then
                If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                    pemsAutomatico()
                    btnAreasServiciosContratadas.Enabled = False
                End If
            Else
                MsgBox("El pem ha sido desapchado!", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            definirTipoPems()
            NombrarTabs()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, Nothing) Then
            btbuscar.Enabled = True
            NombrarTabs(True)
        End If
    End Sub
    Private Sub btbuscarPedido_Click(sender As Object, e As EventArgs) Handles btbuscarPedido.Click
        pnlAdvertencia.Visible = False
        If SesionActual.tienePermiso(pBuscarPedido) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarItem(getCadenaBusqueda(Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA_EXT, Consultas.PEMS_BUSQUEDA_PEDIDO_FARMACIA),
                                  params,
                                  AddressOf cargarInformacionPedido,
                                   TitulosForm.BUSQUEDA_PEDIDO_FARMACIA,
                                   False,
                                    True,
                                   Constantes.TAMANO_MEDIANO
                                   )
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnBuscarPaciente_Click(sender As Object, e As EventArgs) Handles btnBuscarPaciente.Click
        If SesionActual.tienePermiso(pBuscarPaciente) Then
            Dim params As New List(Of String)
            params.Add("")
            General.buscarElemento(Consultas.PEMS_BUSQUEDA_TODOS_PACIENTES,
                                   params,
                                   AddressOf cargarDatosPaciente,
                                   TitulosForm.BUSQUEDA_PACIENTE,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        If objPem.swtManual = True And cmbCliente.SelectedIndex > 0 Then
            Dim params As New List(Of String)
            params.Add(cmbCliente.SelectedValue)
            params.Add(objPem.idEPS)
            Dim fila As DataRow = General.cargarItem(Consultas.PEMS_BUSQUEDA_CLIENTE_EPS_CONTRATO, params)
            If Not IsNothing(fila) Then
                colocarFilas()
                txtCodigoContrato.Text = fila.Item(0)
            Else
                txtCodigoContrato.Text = ""
                limpiarDatatables()
                MsgBox(Mensajes.MSM_CONTRATOS_SIN_VIGENCIA, MsgBoxStyle.Information)
            End If
            cargarAreasServicios(txtCodigoContrato.Text)
            NombrarTabs(True)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If isValidForm(objPem) AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                Dim objPemBLL As New PemBLL
                empalmarDiseñoAlObjeto()
                objPemBLL.guardarPem(objPem, SesionActual.idUsuario, SesionActual.codigoEP)
                empalmarObjetoAlDiseño()
                General.posGuardarForm(Me, ToolStrip1, btnuevo, Nothing, bteditar, btanular, btImprimir)
                btbuscar.Enabled = True
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub btnAreasServiciosContratadas_Click(sender As Object, e As EventArgs) Handles btnAreasServiciosContratadas.Click
        If panelAreasServicios.Visible = True Then
            panelAreasServicios.Visible = False
        Else
            panelAreasServicios.Visible = True
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim objPemBLL As New PemBLL
        If objPemBLL.VeriificarDespachoDePem(objPem) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If SesionActual.tienePermiso(pAnular) Then
                    Try

                        objPemBLL.anularPem(objPem, SesionActual.idUsuario)
                        General.posAnularForm(Me, ToolStrip1, btnuevo, Nothing)
                        btbuscar.Enabled = True
                        NombrarTabs()
                    Catch ex As Exception
                        General.manejoErrores(ex)
                    End Try
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            End If
        Else
            MsgBox(Mensajes.NO_ANULAR_PEM, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        quitarLiquido(objPem.tablaImpregnaciones, "Producto_Disolvente", "Disolvente", "CantidadDisolvente", "TotalDisolvente", dgvImpregnacion.CurrentRow.Index, dgvImpregnacion, "DisolventeImpBtn")
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        quitarLiquido(objPem.tablaInfusiones, "Producto_Disolvente", "Disolvente", "CantidadDisolvente", "TotalDisolvente", dgvInfusion.CurrentRow.Index, dgvInfusion, "disolventeInf")
    End Sub
    Private Sub QuitarLiquidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarLiquidoToolStripMenuItem.Click
        quitarLiquido(objPem.tablaMedicamentos, "CodigoReconstituyente", "Reconstituyente", "CantidadReconstituyente", "TotalDisolvente", dgvMedicacion.CurrentRow.Index, dgvMedicacion, "SeleccionReconstituyente")
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        quitarLiquido(objPem.tablaMedicamentos, "codigoDisolvente", "Disolvente", "CantidadDisolvente", "TotalDisusion", dgvMedicacion.CurrentRow.Index, dgvMedicacion, "SeleccionDisolvente")
    End Sub
    Private Sub arbolAreasServicios_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles arbolAreasServicios.AfterCheck
        estabecerAreasPermitidas()
    End Sub
#End Region
#Region "Eventos de datagridview"
    Private Sub dgvMedicacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicacion.CellDoubleClick

        If Funciones.filaValida(e.RowIndex) Then
            If objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvMedicacion.CurrentCell.ColumnIndex, dgvMedicacion.CurrentRow.Index, "Descripcion", dgvMedicacion) Then
                buscarMedicamentosManual(dgvMedicacion, objPem.tablaMedicamentos, 0, 5, "Descripcion", 0)
                NombrarTabs()
            ElseIf btguardar.Enabled = True AndAlso Funciones.verificacionPosicionActual(dgvMedicacion, e, "QuitarMed") And PemBLL.verificarUltimaLineaManual(objPem.tablaMedicamentos, e.RowIndex, objPem) = False Then
                quitarFila(objPem.tablaMedicamentos, e.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvInfusion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellDoubleClick
        If objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvInfusion.CurrentCell.ColumnIndex, dgvInfusion.CurrentRow.Index, "DescripcionInf", dgvInfusion) Then
            buscarMedicamentosManual(dgvInfusion, objPem.tablaInfusiones, 1, 6, "DescripcionInf", 1)
            NombrarTabs()
        ElseIf Funciones.validarColumnaActual(dgvInfusion.CurrentCell.ColumnIndex, dgvInfusion.CurrentRow.Index, "QuitarInf", dgvInfusion) AndAlso btguardar.Enabled = True AndAlso Funciones.isFilaActiva(objPem.tablaInfusiones.Rows(e.RowIndex).Item("Codigo_Interno").ToString) Then
            If Funciones.quitarFilasSinRestriccion(objPem.tablaInfusiones, e.RowIndex) Then
                objPem.quitarTablas(objPem.nombrarMezclaInfusion(e.RowIndex))
            End If
        End If
    End Sub
    Private Sub dgvImpregnacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvImpregnacion.CurrentCell.ColumnIndex, dgvImpregnacion.CurrentRow.Index, "descripcionImp", dgvImpregnacion) Then
                buscarMedicamentosManual(dgvImpregnacion, objPem.tablaImpregnaciones, 0, 5, "descripcionImp", 0)
                NombrarTabs()
            ElseIf Funciones.verificacionPosicionActual(dgvImpregnacion, e, "QuitarImp") And PemBLL.verificarUltimaLineaManual(objPem.tablaImpregnaciones, e.RowIndex, objPem) = False Then
                quitarFila(objPem.tablaImpregnaciones, e.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvNutricion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNutricion.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvNutricion.CurrentCell.ColumnIndex, dgvNutricion.CurrentRow.Index, "DescripcionNut", dgvNutricion) Then
                buscarMedicamentosManual(dgvNutricion, objPem.tablaNutricion, 0, 1, "DescripcionNut", 0)
                NombrarTabs()
            ElseIf btguardar.Enabled = True AndAlso Funciones.verificacionPosicionActual(dgvNutricion, e, "QuitarNut") AndAlso PemBLL.verificarUltimaLineaManual(objPem.tablaNutricion, e.RowIndex, objPem) = False Then
                quitarFila(objPem.tablaNutricion, e.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvInsumosEnfermeria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosEnfermeria.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvInsumosEnfermeria.CurrentCell.ColumnIndex, dgvInsumosEnfermeria.CurrentRow.Index, "DescripcionInsEnf", dgvInsumosEnfermeria) Then
                buscarInsumosManual(dgvInsumosEnfermeria, objPem.tablaInsumosEnfermeria, 0, 1, "DescripcionInsEnf")
                NombrarTabs()
            ElseIf btguardar.Enabled = True AndAlso Funciones.verificacionPosicionActual(dgvInsumosEnfermeria, e, "QuitarEnf") And PemBLL.verificarUltimaLineaManual(objPem.tablaInsumosEnfermeria, e.RowIndex, objPem) = False Then
                quitarFila(objPem.tablaInsumosEnfermeria, e.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvInsumosFisioterapia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosFisioterapia.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If Funciones.verificacionPosicionActual(dgvInsumosFisioterapia, e, "QuitarFisio") And PemBLL.verificarUltimaLineaManual(objPem.tablaInsumosFisioterapia, e.RowIndex, objPem) = False Then
                quitarFila(objPem.tablaInsumosFisioterapia, e.RowIndex)
            ElseIf btguardar.Enabled = True AndAlso objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvInsumosFisioterapia.CurrentCell.ColumnIndex, dgvInsumosFisioterapia.CurrentRow.Index, "DescripcionFisio", dgvInsumosFisioterapia) Then
                buscarInsumosManual(dgvInsumosFisioterapia, objPem.tablaInsumosFisioterapia, 0, 1, "DescripcionFisio")
                NombrarTabs()
            End If
        End If
    End Sub
    Private Sub dgvMezcla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMezcla.CellDoubleClick
        If objPem.swtManual = True AndAlso Funciones.validarColumnaActual(dgvMezcla.CurrentCell.ColumnIndex, dgvMezcla.CurrentRow.Index, "DescripcionMez", dgvMezcla) Then
            buscarMedicamentosManual(dgvMezcla, objPem.dtTablaMezclas.Tables(objPem.nombrarMezclaInfusion(dgvInfusion.CurrentRow.Index)), 1, 2, "DescripcionMez", 1)
        End If
    End Sub
    Private Sub dgvMedicacion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicacion.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            If (Funciones.verificacionPosicionActual(dgvMedicacion, e, "Cantidad_Reconstituyente") OrElse
                Funciones.verificacionPosicionActual(dgvMedicacion, e, "Cant_diluyente")) And btguardar.Enabled = True Then
                dgvMedicacion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvMedicacion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub

    Private Sub dgvMedicacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicacion.CellContentClick
        If Funciones.filaValida(e.RowIndex) Then
            If btguardar.Enabled = True AndAlso Funciones.validarColumnaActual(dgvMedicacion.CurrentCell.ColumnIndex, dgvMedicacion.CurrentRow.Index, "SeleccionReconstituyente", dgvMedicacion) Then
                If PemBLL.verifcarCantidadesEnCero(dgvMedicacion, e.RowIndex, "Cant_Dosis", "SeleccionReconstituyente", "Reconstituyente", True) Then
                    MsgBox(Mensajes.MSM_DILUYENTE_DOSIS_UNITARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                If objPem.tablaMedicamentos.Rows(dgvMedicacion.CurrentRow.Index).Item("Aplica_disolvente").ToString = "True" Then
                    buscarLiquidosDiluyentes("CodigoReconstituyente", "Reconstituyente", dgvMedicacion.CurrentRow.Index, objPem.tablaMedicamentos, "TotalDisolvente", "UnidadReconstituyente")
                    validacion.celdaFocoSeleccionada(sender, "Cantidad_Reconstituyente", dgvMedicacion.CurrentRow.Index)
                Else
                    asignarNoAplicaDiluyente(objPem.tablaMedicamentos, e.RowIndex, "Reconstituyente")
                End If
            ElseIf btguardar.Enabled = True And Funciones.validarColumnaActual(dgvMedicacion.CurrentCell.ColumnIndex, dgvMedicacion.CurrentRow.Index, "SeleccionDisolvente", dgvMedicacion) Then
                If PemBLL.verifcarCantidadesEnCero(dgvMedicacion, e.RowIndex, "Cant_Dosis", "SeleccionDisolvente", "Disolvente", True) Then
                    MsgBox(Mensajes.MSM_DILUYENTE_DOSIS_UNITARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                If objPem.tablaMedicamentos.Rows(dgvMedicacion.CurrentRow.Index).Item("Aplica_disolvente").ToString = "True" Then
                    buscarLiquidosDiluyentes("codigoDisolvente", "Disolvente", dgvMedicacion.CurrentRow.Index, objPem.tablaMedicamentos, "TotalDisusion", "UnidadDilusion")
                    validacion.celdaFocoSeleccionada(sender, "Cant_diluyente", dgvMedicacion.CurrentRow.Index)
                Else
                    asignarNoAplicaDiluyente(objPem.tablaMedicamentos, e.RowIndex, "Disolvente")
                End If
            End If
            confirmarCambiosEnDatgridview(dgvMedicacion)
        End If
    End Sub
    Private Sub dgvMedicacion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicacion.CellEndEdit
        If Funciones.validarColumnaActual(dgvMedicacion.CurrentCell.ColumnIndex, dgvMedicacion.CurrentRow.Index, "Cant_Dosis", dgvMedicacion) Then
            If PemBLL.verifcarCantidadesEnCero(dgvMedicacion, e.RowIndex, "ConcentracionDosis", "Cant_Dosis") Then
                MsgBox(Mensajes.MSM_DOSIS_NECESARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        ElseIf Funciones.validarColumnaActual(dgvMedicacion.CurrentCell.ColumnIndex, dgvMedicacion.CurrentRow.Index, "Cantidad_Reconstituyente", dgvMedicacion) Then
            If PemBLL.existeDisolvente(dgvMedicacion.CurrentRow.Index, "CodigoReconstituyente", "CantidadReconstituyente", objPem.tablaMedicamentos) Then
                MsgBox(Mensajes.MSM_RECONSTITUYENTE_NECESARIO_PEMS, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        ElseIf Funciones.validarColumnaActual(dgvMedicacion.CurrentCell.ColumnIndex, dgvMedicacion.CurrentRow.Index, "Cant_diluyente", dgvMedicacion) Then
            If PemBLL.existeDisolvente(dgvMedicacion.CurrentRow.Index, "codigoDisolvente", "CantidadDisolvente", objPem.tablaMedicamentos) Then
                MsgBox(Mensajes.MSM_DILUYENTE_NECESARIO_PEMS, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        calcularConcentracionFinal(e.RowIndex)
        confirmarCambiosEnDatgridview(dgvMedicacion)
    End Sub
    Private Sub dgvMezcla_Leave(sender As Object, e As EventArgs) Handles dgvMezcla.Leave
        visualizacionPanelMezclas()
    End Sub
    Private Sub dgvInfusion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellContentClick
        If Funciones.filaValida(e.RowIndex) Then
            If Funciones.validarColumnaActual(dgvInfusion.CurrentCell.ColumnIndex, dgvInfusion.CurrentRow.Index, "disolventeInf", dgvInfusion) AndAlso objPem.swtManual = True Then
                If PemBLL.verifcarCantidadesEnCero(dgvInfusion, e.RowIndex, "Velocidad", "disolventeInf", "Descripcion_Disolvente", True) Then
                    MsgBox(Mensajes.MSM_VELOCIDAD_NECESARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                If objPem.tablaInfusiones.Rows(dgvInfusion.CurrentRow.Index).Item("Aplica_disolvente").ToString = "True" Then
                    buscarLiquidosDiluyentes("Producto_Disolvente", "Disolvente", dgvInfusion.CurrentRow.Index, objPem.tablaInfusiones, "TotalDisolvente", "UnidadDisolvente")
                Else
                    asignarNoAplicaDiluyente(objPem.tablaInfusiones, e.RowIndex, "Disolvente")
                End If
            ElseIf Funciones.validarColumnaActual(dgvInfusion.CurrentCell.ColumnIndex, dgvInfusion.CurrentRow.Index, "disolventeInf", dgvInfusion) Then

            End If
        End If
    End Sub
    Private Sub dgvImpregnacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellContentClick
        If Funciones.filaValida(e.RowIndex) Then
            If Funciones.validarColumnaActual(dgvImpregnacion.CurrentCell.ColumnIndex, dgvImpregnacion.CurrentRow.Index, "DisolventeImpBtn", dgvImpregnacion) AndAlso objPem.swtManual = True Then
                If PemBLL.verifcarCantidadesEnCero(dgvImpregnacion, e.RowIndex, "VelocidadImp", "DisolventeImpBtn", "descripcionImp", True) Then
                    MsgBox(Mensajes.MSM_VELOCIDAD_NECESARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                If objPem.tablaImpregnaciones.Rows(dgvImpregnacion.CurrentRow.Index).Item("Aplica_disolvente").ToString = "True" Then
                    buscarLiquidosDiluyentes("Producto_Disolvente", "Disolvente", dgvImpregnacion.CurrentRow.Index, objPem.tablaImpregnaciones, "TotalDisolvente", "UnidadDisolvente")
                Else
                    asignarNoAplicaDiluyente(objPem.tablaImpregnaciones, e.RowIndex, "Disolvente")
                End If
            End If
        End If
    End Sub
    Private Sub dgvInfusion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            If Funciones.isFilaActiva(objPem.tablaInfusiones.Rows(dgvInfusion.CurrentRow.Index).Item("Codigo_interno").ToString) AndAlso
                   e.ColumnIndex = dgvInfusion.Columns("Mezcla").Index Then

                If objPem.swtManual = True Then
                    If objPem.IsTablaExistente(objPem.nombrarMezclaInfusion(e.RowIndex)) = False Then
                        objPem.agregarTabla(objPem.nombrarMezclaInfusion(e.RowIndex))
                        objPem.dtTablaMezclas.Tables(objPem.nombrarMezclaInfusion(e.RowIndex)).Rows.Add()
                    End If
                End If
                configurardgvMezclas(objPem.nombrarMezclaInfusion(e.RowIndex))
                visualizacionPanelMezclas()
            End If
        End If
    End Sub
    Private Sub dgvMedicacion_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicacion.CellLeave
        confirmarCambiosEnDatgridview(dgvMedicacion)
    End Sub
    Private Sub dgvInfusion_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellLeave
        confirmarCambiosEnDatgridview(dgvInfusion)
    End Sub
    Private Sub dgvImpregnacion_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellLeave
        confirmarCambiosEnDatgridview(dgvImpregnacion)
    End Sub
    Private Sub dgvImpregnacion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellEndEdit
        If Funciones.validarColumnaActual(dgvImpregnacion.CurrentCell.ColumnIndex, dgvImpregnacion.CurrentRow.Index, "VelocidadImp", dgvImpregnacion) Then
            If PemBLL.verifcarCantidadesEnCero(dgvImpregnacion, e.RowIndex, "DosisImp", "VelocidadImp") Then
                MsgBox(Mensajes.MSM_DOSIS_NECESARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        ElseIf Funciones.validarColumnaActual(dgvImpregnacion.CurrentCell.ColumnIndex, dgvImpregnacion.CurrentRow.Index, "CantidadDisolventeImp", dgvImpregnacion) Then
            If PemBLL.existeDisolvente(dgvImpregnacion.CurrentRow.Index, "Producto_Disolvente", "CantidadDisolvente", objPem.tablaImpregnaciones) Then
                MsgBox(Mensajes.MSM_DILUYENTE_NECESARIO_PEMS, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        confirmarCambiosEnDatgridview(dgvImpregnacion)
    End Sub
    Private Sub dgvInfusion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellEndEdit
        If Funciones.validarColumnaActual(dgvInfusion.CurrentCell.ColumnIndex, dgvInfusion.CurrentRow.Index, "Velocidad", dgvInfusion) Then
            If PemBLL.verifcarCantidadesEnCero(dgvInfusion, e.RowIndex, "DosisInf", "Velocidad") Then
                MsgBox(Mensajes.MSM_DOSIS_NECESARIA, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        ElseIf Funciones.validarColumnaActual(dgvInfusion.CurrentCell.ColumnIndex, dgvInfusion.CurrentRow.Index, "CantidadDisolventeInf", dgvInfusion) Then
            If PemBLL.existeDisolvente(dgvInfusion.CurrentRow.Index, "Producto_Disolvente", "CantidadDisolvente", objPem.tablaInfusiones) Then
                MsgBox(Mensajes.MSM_DILUYENTE_NECESARIO_PEMS, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        confirmarCambiosEnDatgridview(dgvInfusion)
    End Sub
    Private Sub dgvMedicacion_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMedicacion.EditingControlShowing,
                                                                                                                               dgvMezcla.EditingControlShowing,
                                                                                                                               dgvInfusion.EditingControlShowing,
                                                                                                                               dgvImpregnacion.EditingControlShowing,
                                                                                                                               dgvNutricion.EditingControlShowing,
                                                                                                                               dgvInsumosEnfermeria.EditingControlShowing,
                                                                                                                               dgvInsumosFisioterapia.EditingControlShowing
        validarNumerosReales(e)
    End Sub
    Private Sub dgvMezcla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMezcla.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            If (Funciones.verificacionPosicionActual(dgvMezcla, e, "DosisMez") OrElse
                                                     Funciones.verificacionPosicionActual(dgvMezcla, e, "CantidadMez") And objPem.swtManual = True) Then
                dgvMezcla.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvMezcla.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvMezcla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMezcla.CellClick
        If Funciones.validarColumnaActual(dgvMezcla.CurrentCell.ColumnIndex, dgvMezcla.CurrentRow.Index, "QuitarMez", dgvMezcla) AndAlso btguardar.Enabled = True AndAlso Funciones.isFilaActiva(objPem.tablaInfusiones.Rows(e.RowIndex).Item("Codigo_Interno").ToString) Then
            If objPem.IsTablaExistente(objPem.nombrarMezclaInfusion(dgvInfusion.CurrentRow.Index)) Then
                Funciones.quitarFilasSinRestriccion(objPem.dtTablaMezclas.Tables(objPem.nombrarMezclaInfusion(dgvInfusion.CurrentRow.Index)), e.RowIndex)
            End If
        End If
    End Sub

    Private Sub btNotaAuditoriaNotif_Click(sender As Object, e As EventArgs) Handles btNotaAuditoriaNotif.Click
        Dim formCtc As New Form_Comite_Cientifico
        formCtc.modulo = Constantes.HC
        formCtc.pem = Me
        formCtc.ShowDialog()
    End Sub

    Private Sub btnCTC_Click(sender As Object, e As EventArgs) Handles btnCTC.Click
        pnlCTC.Visible = Not pnlCTC.Visible
    End Sub

    Private Sub tiCTC_Tick(sender As Object, e As EventArgs) Handles tiCTC.Tick
        Dim hiloNuevo As New Thread(AddressOf cargarCTCPendientes)
        hiloNuevo.Start()
    End Sub

    Private Sub PEMInternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PEMInternoToolStripMenuItem.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add("")

            General.buscarItem(Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS,
                                   params,
                                   AddressOf cargarDatosGuardadosPems,
                                   TitulosForm.BUSQUEDA_PEMS,
                                   False,
                                   True,
                                   Constantes.TAMANO_MEDIANO)

            btnAreasServiciosContratadas.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PEMExternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PEMExternoToolStripMenuItem.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)

            params.Add("")

            General.buscarItem(Consultas.PEMS_BUSQUEDA_PEMS_GUARDADOS_EXT,
                                   params,
                                   AddressOf cargarDatosGuardadosPemsEXT,
                                   TitulosForm.BUSQUEDA_PEMS,
                                   False,
                                   False,
                                   Constantes.TAMANO_MEDIANO)

            btnAreasServiciosContratadas.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvInsumosEnfermeria_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosEnfermeria.CellEnter
        isCeldaActiva(dgvInsumosEnfermeria, e, "CantidadEnf")
    End Sub
    Private Sub dgvInsumosFisioterapia_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosFisioterapia.CellEnter
        isCeldaActiva(dgvInsumosFisioterapia, e, "CantidadFisio")
    End Sub
    Private Sub dgvNutricion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNutricion.CellEnter
        isCeldaActiva(dgvNutricion, e, "Requerimiento")
    End Sub

    Private Sub dgvImpregnacion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            If (Funciones.verificacionPosicionActual(dgvImpregnacion, e, "DosisImp") OrElse Funciones.verificacionPosicionActual(dgvImpregnacion, e, "VelocidadImp") OrElse
               (Funciones.verificacionPosicionActual(dgvImpregnacion, e, "CantidadDisolventeImp") And objPem.swtManual = True)) Then
                dgvImpregnacion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvImpregnacion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvInfusion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            If (Funciones.verificacionPosicionActual(dgvInfusion, e, "DosisInf") OrElse
                                                  Funciones.verificacionPosicionActual(dgvInfusion, e, "Velocidad") OrElse
                                                 (Funciones.verificacionPosicionActual(dgvInfusion, e, "CantidadDisolventeInf") And objPem.swtManual = True)) Then
                dgvInfusion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvInfusion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvMedicacion_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMedicacion.DataError,
                                                                                                       dgvInfusion.DataError,
                                                                                                       dgvImpregnacion.DataError,
                                                                                                       dgvInsumosEnfermeria.DataError,
                                                                                                       dgvInsumosFisioterapia.DataError
        e.Cancel = False
    End Sub

#End Region
End Class