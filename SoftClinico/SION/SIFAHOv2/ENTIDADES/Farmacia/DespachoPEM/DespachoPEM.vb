Public Class DespachoPEM
    Inherits Despacho
    Public Property codigoDespachoPEMPunto As String
    Public Property codigoDespachoPEM As String
    Public Property codigoPEMInicio As Integer
    Public Property codigoPemFin As Integer
    Public Property tblPemInicio As DataTable
    Public Property tblPemFin As DataTable
    Public Property tablaListadoDetalladoPEM As DataTable
    Public Property fechaDespachoPEM As DateTime
    Public Property tablainsumos As DataTable
    Public Property tablaMedicamentos As DataTable
    Public Property tablaBodegaVirtual As DataTable
    Public Property tablaBodegaVirtualPreparacion As DataTable
    Public Property tablaBusqueda As DataTable
    Public Property tablaBusquedaPreparacion As DataTable
    Public Property tablaDespachosMedicamentos As DataTable
    Public Property tablaSobranteMed As DataTable
    Public Property swtGrilla As Integer
    Public Property cantidadDespachada As Double
    Public Property ConcentracionDespachada As Double
    Public Property tablahas As Hashtable
    Public Property tablaTipoPedido As DataTable
    Public Property codigoAreaServicio As String
    Public Property puntoBodegaBuscar As Integer
    Sub New()
        puntoBodegaBuscar = SesionActual.codigoEP
        tablahas = New Hashtable()
        tblLotes = New DataSet
        tablaTipoPedido = New DataTable
        tablaListadoDetalladoPEM = New DataTable
        tablainsumos = New DataTable
        tablaMedicamentos = New DataTable
        tablaBodegaVirtual = New DataTable
        tablaBodegaVirtualPreparacion = New DataTable
        tablaBusqueda = New DataTable
        tablaBusquedaPreparacion = New DataTable
        tablaDespachosMedicamentos = New DataTable
        tablaSobranteMed = New DataTable


        tablaTipoPedido.Columns.Add("Codigo", Type.GetType("System.Int32"))
        tablaTipoPedido.Columns.Add("Descripcion", Type.GetType("System.String"))

        tablaBusqueda.Columns.Add("Codigo", Type.GetType("System.Int32"))
        tablaBusqueda.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaBusqueda.Columns.Add("Concentracion", Type.GetType("System.Double"))
        tablaBusqueda.Columns.Add("Codigo_Bodega", Type.GetType("System.Int32"))
        tablaBusqueda.Columns.Add("Bodega", Type.GetType("System.String"))
        tablaBusqueda.Columns.Add("RegLote", Type.GetType("System.Int32"))
        tablaBusqueda.Columns.Add("Lote", Type.GetType("System.String"))
        tablaBusqueda.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        tablaBusqueda.Columns.Add("Stock", Type.GetType("System.Int32"))
        tablaBusqueda.Columns.Add("CantidadDespachada", Type.GetType("System.Int32"))
        tablaBusqueda.Columns.Add("ConcentracionDespachada", Type.GetType("System.Double"))

        tablaBusquedaPreparacion.Columns.Add("CodigoP", Type.GetType("System.Int32"))
        tablaBusquedaPreparacion.Columns.Add("DescripcionP", Type.GetType("System.String"))
        tablaBusquedaPreparacion.Columns.Add("Concentracion", Type.GetType("System.Double"))
        tablaBusquedaPreparacion.Columns.Add("Codigo_Bodega", Type.GetType("System.Int32"))
        tablaBusquedaPreparacion.Columns.Add("Bodega", Type.GetType("System.String"))
        tablaBusquedaPreparacion.Columns.Add("RegLote", Type.GetType("System.Int32"))
        tablaBusquedaPreparacion.Columns.Add("Lote", Type.GetType("System.String"))
        tablaBusquedaPreparacion.Columns.Add("Fecha", Type.GetType("System.String"))
        tablaBusquedaPreparacion.Columns.Add("ConcentracionDispP", Type.GetType("System.Double"))
        tablaBusquedaPreparacion.Columns.Add("concentracionDesp", Type.GetType("System.Double"))
        tablaBusquedaPreparacion.Columns.Add("Tipo", Type.GetType("System.String"))

        tablaBusqueda.Columns("Stock").DefaultValue = 0
        tablaBusqueda.Columns("ConcentracionDespachada").Expression = "CantidadDespachada * Concentracion "
        tablaBusqueda.Columns("ConcentracionDespachada").DefaultValue = 0
        tablaBusqueda.Columns("CantidadDespachada").DefaultValue = 0


        tablaBusquedaPreparacion.Columns("ConcentracionDispP").DefaultValue = 0
        tablaBusquedaPreparacion.Columns("concentracionDesp").DefaultValue = 0

        tablaBodegaVirtual = tablaBusqueda.Clone
        tablaBodegaVirtualPreparacion = tablaBusquedaPreparacion.Clone

        Dim columnaAutoincrementable, columnaAutoincrementableP As New DataColumn
        With columnaAutoincrementable
            .ColumnName = "id"
            .DataType = Type.GetType("System.Int32")
            '.AutoIncrement = True
            '.AutoIncrementSeed = 0
            '.AutoIncrementStep = 1
        End With
        With columnaAutoincrementableP
            .ColumnName = "id"
            .DataType = Type.GetType("System.Int32")
            .AutoIncrement = True
            .AutoIncrementSeed = 0
            .AutoIncrementStep = 1
        End With


        tablaBodegaVirtual.Columns.Add(columnaAutoincrementable)
        tablaBodegaVirtual.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns.Add("Stock_actual", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns.Add("fila", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns.Add("Tipo", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns("Stock_actual").Expression = "Stock - CantidadDespachada"
        tablaBodegaVirtual.Columns("ConcentracionDespachada").Expression = "CantidadDespachada * Concentracion "


        tablaBodegaVirtual.Columns("Stock_actual").DefaultValue = 0
        tablaBodegaVirtual.Columns("CantidadDespachada").DefaultValue = 0
        tablaBodegaVirtual.Columns("ConcentracionDespachada").DefaultValue = 0

        tablaBusquedaPreparacion.Columns.Add(columnaAutoincrementableP)
        tablaBusquedaPreparacion.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablaBusquedaPreparacion.Columns.Add("Stock_actual", Type.GetType("System.Int32"))

        tablainsumos.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablainsumos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablainsumos.Columns.Add("CantidadPedida", Type.GetType("System.Int32"))
        tablainsumos.Columns.Add("CantidadDespachada", Type.GetType("System.Int32"))
        tablainsumos.Columns.Add("CantidadFaltante", Type.GetType("System.Int32"))

        tablainsumos.Columns("CantidadPedida").DefaultValue = 0
        tablainsumos.Columns("CantidadDespachada").DefaultValue = 0
        tablainsumos.Columns("CantidadFaltante").Expression = "iif(CantidadPedida - CantidadDespachada < 0,0, (CantidadPedida-CantidadDespachada))"
        tablainsumos.Columns("CantidadFaltante").DefaultValue = 0

        tablaMedicamentos.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("ConcentracionMedicamento", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Concen_Ped", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Cant_Ped", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Unidad", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("Cant_Desp", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Concen_Desp", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Concen_Sob", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Concen_Falt", Type.GetType("System.Double"))


        tablaMedicamentos.Columns("Concen_Sob").Expression = "iif(Concen_Ped - Concen_Desp <= 0,(Concen_Ped-Concen_Desp) * -1, 0)"
        tablaMedicamentos.Columns("Concen_Falt").Expression = "iif(Concen_Ped - Concen_Desp >= 0,Concen_Ped-Concen_Desp, 0)"
        tablaMedicamentos.Columns("Concen_Ped").DefaultValue = 0
        tablaMedicamentos.Columns("Cant_Ped").DefaultValue = 0
        tablaMedicamentos.Columns("Cant_Desp").DefaultValue = 0
        tablaMedicamentos.Columns("Concen_Desp").DefaultValue = 0
        tablaMedicamentos.Columns("Concen_Sob").DefaultValue = 0
        tablaMedicamentos.Columns("Concen_Falt").DefaultValue = 0

        llenarTablaTipoPedido()


    End Sub
    Sub llenarTablaTipoPedido()
        tablaTipoPedido.Rows.Add(-1, "-- Seleccione -- ")
        tablaTipoPedido.Rows.Add(0, "Pedido Farmacia")
        tablaTipoPedido.Rows.Add(1, "Solicitud Lab.")
        If SesionActual.codigoEnlace <> 2 Then
            tablaTipoPedido.Rows.Add(2, "Pedido Farmacia Externo")
        End If
    End Sub
    Public Sub agregarProductoDespachado(ByRef tabla As DataTable,
                                              ByVal fila As Integer,
                                              ByVal CodigoInterno As Integer,
                                              ByVal filaPadre As Integer)

        Dim filaAgregar As DataRow = tabla.Rows(fila)
        Dim tblTemp As DataTable = tablaBodegaVirtual
        Dim ultimaFila As Integer
        Dim filaActual As DataRow

        tblTemp.Rows.Add()
        ultimaFila = tblTemp.Rows.Count - 1
        filaActual = tblTemp.Rows(ultimaFila)

        filaActual.Item("id") = filaPadre
        filaActual.Item("Codigo_interno") = CodigoInterno
        filaActual.Item("Codigo") = filaAgregar.Item("Codigo")
        filaActual.Item("Descripcion") = filaAgregar.Item("Descripcion")
        filaActual.Item("Concentracion") = filaAgregar.Item("Concentracion")
        filaActual.Item("Codigo_Bodega") = filaAgregar.Item("Codigo_Bodega")
        filaActual.Item("Bodega") = filaAgregar.Item("Bodega")
        filaActual.Item("RegLote") = filaAgregar.Item("RegLote")
        filaActual.Item("Lote") = filaAgregar.Item("Lote")
        filaActual.Item("Fecha") = filaAgregar.Item("Fecha")
        filaActual.Item("Stock") = filaAgregar.Item("Stock")
        filaActual.Item("CantidadDespachada") = filaAgregar.Item("CantidadDespachada")
        filaActual.Item("fila") = filaPadre
        filaActual.Item("Tipo") = If(swtGrilla = Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS)
        'Return tblTemp.Rows(ultimaFila).Item("id")
    End Sub
    Public Sub agregarProductoDespachadoPre(ByRef tabla As DataTable,
                                            ByVal fila As Integer,
                                            ByVal CodigoInterno As Integer,
                                            ByVal filaPadre As Integer)

        Dim filaAgregar As DataRow = tabla.Rows(fila)
        Dim tblTemp As DataTable = tablaBodegaVirtualPreparacion
        Dim ultimaFila As Integer
        Dim filaActual As DataRow

        tblTemp.Rows.Add()
        ultimaFila = tblTemp.Rows.Count - 1
        filaActual = tblTemp.Rows(ultimaFila)

        filaActual.Item("id") = filaPadre
        filaActual.Item("Codigo_interno") = CodigoInterno
        filaActual.Item("Codigo") = filaAgregar.Item("Codigo")
        filaActual.Item("Descripcion") = filaAgregar.Item("Descripcion")
        filaActual.Item("Concentracion") = filaAgregar.Item("Concentracion")
        filaActual.Item("Codigo_Bodega") = filaAgregar.Item("Codigo_Bodega")
        filaActual.Item("Bodega") = filaAgregar.Item("Bodega")
        filaActual.Item("RegLote") = filaAgregar.Item("RegLote")
        filaActual.Item("Lote") = filaAgregar.Item("Lote")
        filaActual.Item("Fecha") = filaAgregar.Item("Fecha")
        filaActual.Item("Stock") = filaAgregar.Item("Stock")
        filaActual.Item("CantidadDespachada") = filaAgregar.Item("CantidadDespachada")
        filaActual.Item("fila") = filaPadre
        filaActual.Item("Tipo") = If(swtGrilla = Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS)
        'Return tblTemp.Rows(ultimaFila).Item("id")
    End Sub
    Public Sub calcularConcentracionesDespachada(ByVal filaActual As Integer,
                                                 ByVal codigoEquivalencia As Integer,
                                                 ByVal tipo As Integer)
        Dim nombreTabla As String = nombrarTabla(codigoEquivalencia, filaActual, tipo)
        If verificarExistenciaTabla(nombreTabla) Then
            Dim accionCantidad As String = "SUM(cantidadDespachada)"
            Dim accionConcentracion As String = "SUM(ConcentracionDesp)"
            Dim filtro As String = "Codigo_Interno = '" & codigoEquivalencia & "'"
            Dim tblsTemp As DataTableCollection = tblLotes.Tables
            Dim cantidadResultado As Object = tblsTemp(nombreTabla).Compute(accionCantidad, filtro)
            Dim concentracionResultado As Object = tblsTemp(nombreTabla).Compute(accionConcentracion, filtro)

            cantidadDespachada = If(IsDBNull(cantidadResultado), 0, cantidadResultado)
            ConcentracionDespachada = If(IsDBNull(concentracionResultado), 0, concentracionResultado)
        End If
    End Sub
    Sub configurarTablaLote(ByVal nombreTabla As String)
        If tblLotes.Tables(nombreTabla).Columns.Count = 0 Then
            Dim columnsDataset As DataColumnCollection = tblLotes.Tables(nombreTabla).Columns
            With columnsDataset
                .Add("Codigo_Bodega", Type.GetType("System.Int32"))
                .Add("Bodega", Type.GetType("System.String"))
                .Add("Codigo", Type.GetType("System.Int32"))
                .Add("Descripcion", Type.GetType("System.String"))
                .Add("Concentracion", Type.GetType("System.Double"))
                .Add("Codigo_Interno", Type.GetType("System.Int32"))
                .Add("reg_lote", Type.GetType("System.Int32"))
                .Add("Lote", Type.GetType("System.String"))
                .Add("Fecha", Type.GetType("System.DateTime"))
                .Add("stock", Type.GetType("System.Int32"))
                .Add("CantidadPed", Type.GetType("System.Int32"))
                .Add("cantidadDespachada", Type.GetType("System.Int32"))
                .Add("CantidadFaltante", Type.GetType("System.Int32"))
                .Add("CantidadSobrante", Type.GetType("System.Int32"))
                .Add("ConcentracionPed", Type.GetType("System.Double"))
                .Add("ConcentracionDesp", Type.GetType("System.Double"))
                .Add("ConcentracionFalt", Type.GetType("System.Double"))
                .Add("ConcentracionSobr", Type.GetType("System.Double"))
            End With
        End If

    End Sub
    Sub guardarDespachoTemporal(ByVal indiceFila As Integer,
                                ByVal codigo As Integer,
                                ByVal cantidadPedida As Integer,
                                ByVal concentracionPedida As Double,
                                ByVal tipo As Integer)

        Dim tblTemp As DataTable = tablaBusqueda
        Dim tablas As DataTableCollection = tblLotes.Tables
        Dim nombreTablaLotes As String = nombrarTabla(codigo, indiceFila, tipo)
        Dim ultimaFila As Integer
        Dim cantidadFaltante, cantidadSobrante As Integer
        Dim concentracionFaltante, concentracionSobrante As Double

        agregarTabla(nombreTablaLotes)
        configurarTablaLote(nombreTablaLotes)
        tablas(nombreTablaLotes).Clear()



        For indice = 0 To tblTemp.Rows.Count - 1
            If tblTemp.Rows(indice).Item("CantidadDespachada") > 0 Then
                'calacula la cantidad faltante y la cantidad sobrante 
                cantidadFaltante = cantidadPedida - tblTemp.Rows(indice).Item("cantidadDespachada")
                cantidadSobrante = tblTemp.Rows(indice).Item("cantidadDespachada") - cantidadPedida

                'calacula la concentracion faltante y la concentracion sobrante 
                concentracionFaltante = concentracionPedida - tblTemp.Rows(indice).Item("ConcentracionDespachada")
                concentracionSobrante = tblTemp.Rows(indice).Item("ConcentracionDespachada") - concentracionPedida
                tblTemp.AcceptChanges()

                'se adiciona el registro de cada despacho a su tabla correspondiente 
                tablas(nombreTablaLotes).Rows.Add()
                ultimaFila = tablas(nombreTablaLotes).Rows.Count - 1
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Codigo_Bodega") = tblTemp.Rows(indice).Item("Codigo_Bodega")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Bodega") = tblTemp.Rows(indice).Item("Bodega")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Codigo") = tblTemp.Rows(indice).Item("Codigo")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Descripcion") = tblTemp.Rows(indice).Item("Descripcion")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Concentracion") = tblTemp.Rows(indice).Item("Concentracion")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Codigo_Interno") = codigo
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("reg_lote") = tblTemp.Rows(indice).Item("RegLote")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("stock") = tblTemp.Rows(indice).Item("Stock")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Lote") = tblTemp.Rows(indice).Item("Lote")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Fecha") = tblTemp.Rows(indice).Item("Fecha")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("CantidadPed") = cantidadPedida
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("cantidadDespachada") = tblTemp.Rows(indice).Item("cantidadDespachada")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("CantidadFaltante") = If(cantidadFaltante <= 0, 0, cantidadFaltante)
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("CantidadSobrante") = If(cantidadSobrante <= 0, 0, cantidadSobrante)
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionPed") = concentracionPedida
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionDesp") = tblTemp.Rows(indice).Item("ConcentracionDespachada")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionFalt") = If(concentracionFaltante <= 0, 0, concentracionFaltante)
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionSobr") = If(concentracionSobrante <= 0, 0, concentracionSobrante)

            End If
        Next
    End Sub

    Sub guardarDespachoTemporalPre(ByVal indiceFila As Integer,
                                ByVal codigo As Integer,
                                ByVal cantidadPedida As Integer,
                                ByVal concentracionPedida As Double,
                                ByVal tipo As Integer)

        Dim tblTemp As DataTable = tablaBusqueda
        Dim tablas As DataTableCollection = tblLotes.Tables
        Dim nombreTablaLotes As String = nombrarTabla(codigo, indiceFila, tipo)
        Dim ultimaFila As Integer
        Dim cantidadFaltante, cantidadSobrante As Integer
        Dim concentracionFaltante, concentracionSobrante As Double

        agregarTabla(nombreTablaLotes)
        configurarTablaLote(nombreTablaLotes)
        tablas(nombreTablaLotes).Clear()



        For indice = 0 To tblTemp.Rows.Count - 1
            If tblTemp.Rows(indice).Item("CantidadDespachada") > 0 Then
                'calacula la cantidad faltante y la cantidad sobrante 
                cantidadFaltante = cantidadPedida - tblTemp.Rows(indice).Item("cantidadDespachada")
                cantidadSobrante = tblTemp.Rows(indice).Item("cantidadDespachada") - cantidadPedida

                'calacula la concentracion faltante y la concentracion sobrante 
                concentracionFaltante = concentracionPedida - tblTemp.Rows(indice).Item("ConcentracionDespachada")
                concentracionSobrante = tblTemp.Rows(indice).Item("ConcentracionDespachada") - concentracionPedida
                tblTemp.AcceptChanges()

                'se adiciona el registro de cada despacho a su tabla correspondiente 
                tablas(nombreTablaLotes).Rows.Add()
                ultimaFila = tablas(nombreTablaLotes).Rows.Count - 1
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Codigo_Bodega") = tblTemp.Rows(indice).Item("Codigo_Bodega")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Bodega") = tblTemp.Rows(indice).Item("Bodega")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Codigo") = tblTemp.Rows(indice).Item("Codigo")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Descripcion") = tblTemp.Rows(indice).Item("Descripcion")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Concentracion") = tblTemp.Rows(indice).Item("Concentracion")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Codigo_Interno") = codigo
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("reg_lote") = tblTemp.Rows(indice).Item("RegLote")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("stock") = tblTemp.Rows(indice).Item("Stock")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Lote") = tblTemp.Rows(indice).Item("Lote")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("Fecha") = tblTemp.Rows(indice).Item("Fecha")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("CantidadPed") = cantidadPedida
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("cantidadDespachada") = tblTemp.Rows(indice).Item("cantidadDespachada")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("CantidadFaltante") = If(cantidadFaltante <= 0, 0, cantidadFaltante)
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("CantidadSobrante") = If(cantidadSobrante <= 0, 0, cantidadSobrante)
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionPed") = concentracionPedida
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionDesp") = tblTemp.Rows(indice).Item("ConcentracionDespachada")
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionFalt") = If(concentracionFaltante <= 0, 0, concentracionFaltante)
                tablas(nombreTablaLotes).Rows(ultimaFila).Item("ConcentracionSobr") = If(concentracionSobrante <= 0, 0, concentracionSobrante)

            End If
        Next
    End Sub
    Function validarCantidadIngresada(ByVal stock As Integer,
                                      ByVal cantidadIngresada As Integer,
                                      ByVal stockDisponibleVirtual As Integer) As Boolean
        If cantidadIngresada > stockDisponibleVirtual Then
            Return False
        End If
        Return True
    End Function
    Function validarCantidadPermitida(ByVal stock As Double,
                                       ByVal cantidadIngresada As Double) As Boolean
        If stock < cantidadIngresada Then
            Return False
        End If
        Return True
    End Function
    Sub distribucionDeConcentracionesDeapchadasPem(ByVal codigoInterno As Integer,
                                                   ByVal concentracionDisponible As Double,
                                                   ByVal aumentar As Boolean)
        If aumentar Then
            aumentarDistribuconPems(codigoInterno, concentracionDisponible)
        Else
            disminuirDistribucionPems(codigoInterno, concentracionDisponible)
        End If
    End Sub
    Sub aumentarDistribuconPems(ByVal codigoInterno As Integer,
                                ByVal concentracionDisponible As Double)

        Dim tblTemp As DataTable = tablaListadoDetalladoPEM


        For indice = 0 To tblTemp.Rows.Count - 1
            If tblTemp.Rows(indice).Item("Código Equivalencia") = codigoInterno AndAlso tblTemp.Rows(indice).Item("Cantidad Despachada") < tblTemp.Rows(indice).Item("Concentración Pedida") Then
                If tblTemp.Rows(indice).Item("Concentración Pedida") < concentracionDisponible AndAlso
                   tblTemp.Rows(indice).Item("Cantidad Despachada") < concentracionDisponible Then

                    Dim cantidadConcentracionDespachada As Double = 0
                    If tblTemp.Rows(indice).Item("Cantidad Despachada") = 0 Then
                        tblTemp.Rows(indice).Item("Cantidad Despachada") = tblTemp.Rows(indice).Item("Concentración Pedida")
                        concentracionDisponible -= tblTemp.Rows(indice).Item("Concentración Pedida")
                    Else
                        cantidadConcentracionDespachada = Math.Abs(tblTemp.Rows(indice).Item("Cantidad Despachada") - concentracionDisponible)
                        tblTemp.Rows(indice).Item("Cantidad Despachada") = cantidadConcentracionDespachada
                        concentracionDisponible -= cantidadConcentracionDespachada
                    End If
                ElseIf tblTemp.Rows(indice).Item("Concentración Pedida") >= concentracionDisponible Then

                    tblTemp.Rows(indice).Item("Cantidad Despachada") = concentracionDisponible
                    concentracionDisponible = 0
                    Exit For

                End If
            End If
        Next
    End Sub
    Sub disminuirDistribucionPems(ByVal codigoInterno As Integer,
                                  ByVal concentracionDisponible As Double)

        Dim tblTemp As DataTable = tablaListadoDetalladoPEM

        For indice = 0 To tblTemp.Rows.Count - 1
            If tblTemp.Rows(indice).Item("Código Equivalencia") = codigoInterno Then
                If concentracionDisponible = tblTemp.Rows(indice).Item("Concentración Pedida") Then
                    tblTemp.Rows(indice).Item("Concentración Pedida") = 0
                    concentracionDisponible = 0
                    Exit For
                ElseIf concentracionDisponible < tblTemp.Rows(indice).Item("Concentración Pedida") Then
                    tblTemp.Rows(indice).Item("Concentración Pedida") = concentracionDisponible
                    concentracionDisponible = 0
                    Exit For
                ElseIf concentracionDisponible > tblTemp.Rows(indice).Item("Concentración Pedida") Then
                    tblTemp.Rows(indice).Item("Concentración Pedida") = 0
                    concentracionDisponible = tblTemp.Rows(indice).Item("Concentración Pedida") - concentracionDisponible
                End If
            End If
        Next
    End Sub

End Class
