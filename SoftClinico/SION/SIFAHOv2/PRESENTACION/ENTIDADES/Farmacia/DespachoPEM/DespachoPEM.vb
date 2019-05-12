Public Class DespachoPEM
    Inherits Despacho
    Public Property codigoDespachoPEM As Integer
    Public Property codigoPEMInicio As Integer
    Public Property codigoPemFin As Integer
    Public Property tblPemInicio As DataTable
    Public Property tblPemFin As DataTable
    Public Property tablaListadoDetalladoPEM As DataTable
    Public Property fechaPEM As DateTime
    Public Property tablainsumos As DataTable
    Public Property tablaMedicamentos As DataTable
    Public Property tablaBodegaVirtual As DataTable
    Public Property tablaBusqueda As DataTable
    Public Property tablaDespachosMedicamentos As DataTable
    Public Property tablaBusquedaPreparacion As DataTable
    Public Property swtGrilla As Integer
    Public Property cantidadDespachada As Double
    Public Property ConcentracionDespachada As Double

    Sub New()
        tblLotes = New DataSet
        tablaListadoDetalladoPEM = New DataTable
        tablainsumos = New DataTable
        tablaMedicamentos = New DataTable
        tablaBodegaVirtual = New DataTable
        tablaBusqueda = New DataTable
        tablaDespachosMedicamentos = New DataTable
        tablaBusquedaPreparacion = New DataTable

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


        tablaBusqueda.Columns("Stock").DefaultValue = 0
        tablaBusqueda.Columns("ConcentracionDespachada").Expression = "CantidadDespachada * Concentracion "
        tablaBusqueda.Columns("ConcentracionDespachada").DefaultValue = 0
        tablaBusqueda.Columns("CantidadDespachada").DefaultValue = 0

        tablaBodegaVirtual = tablaBusqueda.Clone
        tablaBodegaVirtual.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns.Add("Stock_actual", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns.Add("Tipo", Type.GetType("System.Int32"))
        tablaBodegaVirtual.Columns("Stock_actual").Expression = "Stock - CantidadDespachada"
        tablaBodegaVirtual.Columns("ConcentracionDespachada").Expression = "CantidadDespachada * Concentracion "

        tablaBodegaVirtual.Columns("Stock_actual").DefaultValue = 0
        tablaBodegaVirtual.Columns("CantidadDespachada").DefaultValue = 0
        tablaBodegaVirtual.Columns("ConcentracionDespachada").DefaultValue = 0

        tablainsumos.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablainsumos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablainsumos.Columns.Add("CantidadPedida", Type.GetType("System.Int32"))
        tablainsumos.Columns.Add("CantidadDespachada", Type.GetType("System.Int32"))
        tablainsumos.Columns.Add("CantidadFaltante", Type.GetType("System.Int32"))

        tablainsumos.Columns("CantidadPedida").DefaultValue = 0
        tablainsumos.Columns("CantidadDespachada").DefaultValue = 0
        tablainsumos.Columns("CantidadFaltante").DefaultValue = 0
        tablainsumos.Columns("CantidadFaltante").Expression = "iif(CantidadPedida - CantidadDespachada <= 0,(CantidadPedida-CantidadDespachada) * -1, 0)"

        tablaMedicamentos.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("ConcentracionMedicamento", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Concen_Ped", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("Cant_Ped", Type.GetType("System.Int32"))
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

        tablaListadoDetalladoPEM.Columns.Add("CodigoPem", Type.GetType("System.Int32"))
        tablaListadoDetalladoPEM.Columns.Add("codigo_interno", Type.GetType("System.Int32"))
        tablaListadoDetalladoPEM.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaListadoDetalladoPEM.Columns.Add("Concen_Ped", Type.GetType("System.Double"))
        tablaListadoDetalladoPEM.Columns.Add("Concen_Des", Type.GetType("System.Double"))

        tablaListadoDetalladoPEM.Columns("Concen_Ped").DefaultValue = 0
        tablaListadoDetalladoPEM.Columns("Concen_Des").DefaultValue = 0
    End Sub
    Sub agregarProductoDespachado(ByRef tabla As DataTable,
                                  ByVal fila As Integer,
                                  ByVal CodigoInterno As Integer)
        'Dim posisionRegistro As Integer
        'For indiceFila = 0 To tablaBodegaVirtual.Rows.Count - 1
        '    If tablaBodegaVirtual.Rows(indiceFila).Item("Codigo") = tabla.Rows(fila).Item("Codigo") AndAlso tablaBodegaVirtual.Rows(indiceFila).Item("Lote") = tabla.Rows(fila).Item("Lote") Then
        '        posisionRegistro = indiceFila
        '        Exit For
        '    End If
        'Next
        'If tablaBodegaVirtual.Select("Codigo = '" & tabla.Rows(fila).Item("Codigo") & "' and Codigo_Bodega ='" & tabla.Rows(fila).Item("Codigo_Bodega") & "' and lote ='" & tabla.Rows(fila).Item("lote") & "'").Count = 0 Then
        Dim filaAgregar As DataRow = tabla.Rows(fila)
        tablaBodegaVirtual.Rows.Add()
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Codigo_interno") = CodigoInterno
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Codigo") = filaAgregar.Item("Codigo")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Descripcion") = filaAgregar.Item("Descripcion")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Concentracion") = filaAgregar.Item("Concentracion")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Codigo_Bodega") = filaAgregar.Item("Codigo_Bodega")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Bodega") = filaAgregar.Item("Bodega")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("RegLote") = filaAgregar.Item("RegLote")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Lote") = filaAgregar.Item("Lote")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Fecha") = filaAgregar.Item("Fecha")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Stock") = filaAgregar.Item("Stock")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("CantidadDespachada") = filaAgregar.Item("CantidadDespachada")
        tablaBodegaVirtual.Rows(tablaBodegaVirtual.Rows.Count - 1).Item("Tipo") = If(swtGrilla = Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS)
        'posisionRegistro = tablaBodegaVirtual.Rows.Count - 1
        ' Else
        'tablaBodegaVirtual.Rows(posisionRegistro).Item("CantidadDespachada") += tabla.Rows(fila).Item("CantidadDespachada")
        ' End If
    End Sub
    Sub quitarProductosDespachados(ByVal codigoInterno As Integer)

        Dim tablaTemp As New DataTable
        Dim filas As DataRow()
        tablaTemp = tablaBodegaVirtual.Clone()
        filas = tablaBodegaVirtual.Select("Codigo_interno <>'" & codigoInterno & "' and Tipo='" & If(swtGrilla = Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS) & "' ", "")
        For Each fila In filas
            tablaTemp.ImportRow(fila)
        Next
        tablaBodegaVirtual.Clear()
        tablaBodegaVirtual.Merge(tablaTemp)

    End Sub
    Public Sub calcularConcentracionesDespachada(ByVal filaActual As Integer,
                                                 ByVal codigoEquivalencia As Integer)
        Dim nombreTabla As String = nombrarTabla(codigoEquivalencia, filaActual)
        If verificarExistenciaTabla(nombreTabla) Then
            cantidadDespachada = If(IsDBNull(tblLotes.Tables(nombreTabla).Compute("SUM(cantidadDespachada) ", "Codigo_Interno = '" & codigoEquivalencia & "'")), 0, tblLotes.Tables(nombreTabla).Compute("SUM(cantidadDespachada) ", "Codigo_Interno = '" & codigoEquivalencia & "'"))
            ConcentracionDespachada = If(IsDBNull(tblLotes.Tables(nombreTabla).Compute("SUM(ConcentracionDesp) ", "Codigo_Interno = '" & codigoEquivalencia & "'")), 0, tblLotes.Tables(nombreTabla).Compute("SUM(ConcentracionDesp) ", "Codigo_Interno = '" & codigoEquivalencia & "'"))
        End If
    End Sub
    Sub configurarTablaLote(ByVal nombreTabla As String)
        If tblLotes.Tables(nombreTabla).Columns.Count = 0 Then
            Dim columnsDataset As DataColumnCollection = tblLotes.Tables(nombreTabla).Columns
            columnsDataset.Add("Codigo_Bodega", Type.GetType("System.Int32"))
            columnsDataset.Add("Bodega", Type.GetType("System.String"))
            columnsDataset.Add("Codigo", Type.GetType("System.Int32"))
            columnsDataset.Add("Descripcion", Type.GetType("System.String"))
            columnsDataset.Add("Concentracion", Type.GetType("System.Double"))
            columnsDataset.Add("Codigo_Interno", Type.GetType("System.Int32"))
            columnsDataset.Add("reg_lote", Type.GetType("System.Int32"))
            columnsDataset.Add("Lote", Type.GetType("System.String"))
            columnsDataset.Add("Fecha", Type.GetType("System.DateTime"))
            columnsDataset.Add("stock", Type.GetType("System.Int32"))
            columnsDataset.Add("CantidadPed", Type.GetType("System.Int32"))
            columnsDataset.Add("cantidadDespachada", Type.GetType("System.Int32"))
            columnsDataset.Add("CantidadFaltante", Type.GetType("System.Int32"))
            columnsDataset.Add("CantidadSobrante", Type.GetType("System.Int32"))
            columnsDataset.Add("ConcentracionPed", Type.GetType("System.Double"))
            columnsDataset.Add("ConcentracionDesp", Type.GetType("System.Double"))
            columnsDataset.Add("ConcentracionFalt", Type.GetType("System.Double"))
            columnsDataset.Add("ConcentracionSobr", Type.GetType("System.Double"))
        End If
    End Sub
    Sub guardarDespachoTemporal(ByVal indiceFila As Integer,
                                ByVal codigo As Integer,
                                      cantidadPedida As Integer,
                                      concentracionPedida As Double)

        Dim nombreTablaLotes As String = nombrarTabla(codigo, indiceFila)
        agregarTabla(nombreTablaLotes)
        configurarTablaLote(nombreTablaLotes)

        tblLotes.Tables(nombreTablaLotes).Clear()

        Dim cantidadFaltante, cantidadSobrante As Integer
        Dim concentracionFaltante, concentracionSobrante As Double

        For indice = 0 To tablaBusqueda.Rows.Count - 1
            If tablaBusqueda.Rows(indice).Item("CantidadDespachada") > 0 Then
                'calacula la cantidad faltante y la cantidad sobrante 
                cantidadFaltante = cantidadPedida - tablaBusqueda.Rows(indice).Item("cantidadDespachada")
                cantidadSobrante = tablaBusqueda.Rows(indice).Item("cantidadDespachada") - cantidadPedida

                'calacula la concentracion faltante y la concentracion sobrante 
                concentracionFaltante = concentracionPedida - tablaBusqueda.Rows(indice).Item("ConcentracionDespachada")
                concentracionSobrante = tablaBusqueda.Rows(indice).Item("ConcentracionDespachada") - concentracionPedida
                tablaBusqueda.AcceptChanges()
                'se adiciona el registro de cada despacho a su tabla correspondiente 
                tblLotes.Tables(nombreTablaLotes).Rows.Add()
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Codigo_Bodega") = tablaBusqueda.Rows(indice).Item("Codigo_Bodega")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Bodega") = tablaBusqueda.Rows(indice).Item("Codigo_Bodega")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Codigo") = tablaBusqueda.Rows(indice).Item("Codigo")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Descripcion") = tablaBusqueda.Rows(indice).Item("Descripcion")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Concentracion") = tablaBusqueda.Rows(indice).Item("Concentracion")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Codigo_Interno") = codigo
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("reg_lote") = tablaBusqueda.Rows(indice).Item("RegLote")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("stock") = tablaBusqueda.Rows(indice).Item("Stock")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Lote") = tablaBusqueda.Rows(indice).Item("Lote")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("Fecha") = tablaBusqueda.Rows(indice).Item("Fecha")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("CantidadPed") = cantidadPedida
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("cantidadDespachada") = tablaBusqueda.Rows(indice).Item("cantidadDespachada")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("CantidadFaltante") = If(cantidadFaltante <= 0, 0, cantidadFaltante)
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("CantidadSobrante") = If(cantidadSobrante <= 0, 0, cantidadSobrante)
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("ConcentracionPed") = concentracionPedida
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("ConcentracionDesp") = tablaBusqueda.Rows(indice).Item("ConcentracionDespachada")
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("ConcentracionFalt") = If(concentracionFaltante <= 0, 0, concentracionFaltante)
                tblLotes.Tables(nombreTablaLotes).Rows(tblLotes.Tables(nombreTablaLotes).Rows.Count - 1).Item("ConcentracionSobr") = If(concentracionSobrante <= 0, 0, concentracionSobrante)

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
    Function validarCantidadPermiitica(ByVal stock As Integer,
                                       ByVal cantidadIngresada As Integer) As Boolean
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
        For indice = 0 To tablaListadoDetalladoPEM.Rows.Count - 1
            If tablaListadoDetalladoPEM.Rows(indice).Item("codigo_interno") = codigoInterno AndAlso tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") < tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Ped") Then
                If tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Ped") < concentracionDisponible AndAlso
                   tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") < concentracionDisponible Then

                    Dim cantidadConcentracionDespachada As Double = 0
                    If tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = 0 Then
                        tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Ped")
                        concentracionDisponible -= tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Ped")
                    Else
                        cantidadConcentracionDespachada = Math.Abs(tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") - concentracionDisponible)
                        tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = cantidadConcentracionDespachada
                        concentracionDisponible -= cantidadConcentracionDespachada
                    End If
                ElseIf tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Ped") >= concentracionDisponible Then

                    tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = concentracionDisponible
                    concentracionDisponible = 0
                    Exit For

                End If
            End If
        Next
    End Sub
    Sub disminuirDistribucionPems(ByVal codigoInterno As Integer,
                                  ByVal concentracionDisponible As Double)

        For indice = 0 To tablaListadoDetalladoPEM.Rows.Count - 1
            If tablaListadoDetalladoPEM.Rows(indice).Item("codigo_interno") = codigoInterno Then
                If concentracionDisponible = tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") Then
                    tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = 0
                    concentracionDisponible = 0
                    Exit For
                ElseIf concentracionDisponible < tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") Then
                    tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = concentracionDisponible
                    concentracionDisponible = 0
                    Exit For
                ElseIf concentracionDisponible > tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") Then
                    tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") = 0
                    concentracionDisponible = tablaListadoDetalladoPEM.Rows(indice).Item("Concen_Des") - concentracionDisponible
                End If
            End If
        Next
    End Sub

End Class
