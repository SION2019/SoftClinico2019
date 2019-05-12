Public Class Pem
    Public Property codigoPem As String
    Public Property codigoPedido As String
    Public Property razon As Double
    Public Property volumenTotal As Double
    Public Property idPaciente As Integer
    Public Property idEPS As Integer
    Public Property idContrato As String
    Public Property fechaPem As DateTime
    Public Property estado As Boolean = False
    Public Property swtManual As Boolean = False
    Public Property listaAreaServicios As List(Of String)
    Public Property tablaMedicamentos As DataTable
    Public Property tablaInfusiones As DataTable
    Public Property dtTablaMezclas As DataSet
    Public Property tablaNutricion As DataTable
    Public Property tablaInsumosEnfermeria As DataTable
    Public Property tablaInsumosFisioterapia As DataTable
    Public Property tablaImpregnaciones As DataTable
    Public Property tablaProcedimientos As DataTable
    Public Property tablaDiagnosticos As DataTable
    Public Property tablaAreas As DataTable

    Sub New()
        listaAreaServicios = New List(Of String)
        tablaAreas = New DataTable
        tablaMedicamentos = New DataTable
        tablaInfusiones = New DataTable
        dtTablaMezclas = New DataSet
        tablaNutricion = New DataTable
        tablaInsumosEnfermeria = New DataTable
        tablaInsumosFisioterapia = New DataTable
        tablaImpregnaciones = New DataTable
        tablaProcedimientos = New DataTable
        tablaDiagnosticos = New DataTable

        tablaAreas.Columns.Add("codigo", Type.GetType("System.Int32"))
        tablaAreas.Columns.Add("Descripcion", Type.GetType("System.String"))

        tablaDiagnosticos.Columns.Add("CodigoDiagnosico", Type.GetType("System.String"))
        tablaDiagnosticos.Columns.Add("Descripcion", Type.GetType("System.String"))

        tablaProcedimientos.Columns.Add("Codigo", Type.GetType("System.String"))
        tablaProcedimientos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaProcedimientos.Columns.Add("Cantidad", Type.GetType("System.Int32"))

        tablaProcedimientos.Columns("Cantidad").DefaultValue = 0

        tablaMedicamentos.Columns.Add("Codigo_interno", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("Concentracion", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("ConcentracionMedicamento", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("Aplica_disolvente", Type.GetType("System.Boolean"))
        tablaMedicamentos.Columns.Add("UnidadMedicamento", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("DosisUnitaria", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("cantidadDosisUnitaria", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("CantidadReconstituyente", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("CodigoReconstituyente", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("Reconstituyente", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("TotalDisolvente", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("UnidadReconstituyente", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("TotalDisolventeMedicamento", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("VolumenJeringa", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("CantidadDisolvente", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("codigoDisolvente", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("Disolvente", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("TotalDisusion", Type.GetType("System.Double"))
        tablaMedicamentos.Columns.Add("UnidadDilusion", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("TotalDisusionMedicamento", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("ConcentracionFinal", Type.GetType("System.String"))
        tablaMedicamentos.Columns.Add("Frecuencia", Type.GetType("System.Int32"))
        tablaMedicamentos.Columns.Add("HoraInicio", Type.GetType("System.Int32"))

        tablaMedicamentos.Columns("TotalDisolventeMedicamento").Expression = "IIF(TotalDisolvente > 0 and  CodigoReconstituyente > '" & Constantes.CODIGO_NO_VALIDO & "',Convert(TotalDisolvente,'System.String') + ' ' + UnidadReconstituyente ,'0 ML')"
        tablaMedicamentos.Columns("TotalDisusionMedicamento").Expression = "IIF(TotalDisusion > 0 and codigoDisolvente > '" & Constantes.CODIGO_NO_VALIDO & "',Convert(TotalDisusion,'System.String') + ' ' + UnidadDilusion , '0 ML')"
        tablaMedicamentos.Columns("VolumenJeringa").Expression = "IIF(Concentracion>0,(DosisUnitaria * TotalDisolvente)/Concentracion,0)"

        tablaMedicamentos.Columns("CantidadReconstituyente").DefaultValue = 0
        tablaMedicamentos.Columns("CantidadDisolvente").DefaultValue = 0
        tablaMedicamentos.Columns("DosisUnitaria").DefaultValue = 0
        tablaMedicamentos.Columns("cantidadDosisUnitaria").DefaultValue = 0
        tablaMedicamentos.Columns("Frecuencia").DefaultValue = 0
        tablaMedicamentos.Columns("HoraInicio").DefaultValue = 0
        tablaMedicamentos.Columns("ConcentracionFinal").DefaultValue = 0
        tablaMedicamentos.Columns("VolumenJeringa").DefaultValue = 0
        tablaMedicamentos.Columns("TotalDisolvente").DefaultValue = 0
        tablaMedicamentos.Columns("TotalDisusion").DefaultValue = 0
        tablaMedicamentos.Columns("TotalDisolventeMedicamento").DefaultValue = "0 ML"
        tablaMedicamentos.Columns("TotalDisusionMedicamento").DefaultValue = "0 ML"
        tablaMedicamentos.Columns("CodigoReconstituyente").DefaultValue = -1
        tablaMedicamentos.Columns("codigoDisolvente").DefaultValue = -1
        tablaMedicamentos.Columns("Reconstituyente").DefaultValue = Constantes.DISOLVENTE_POR_DEFECTO
        tablaMedicamentos.Columns("Disolvente").DefaultValue = Constantes.DISOLVENTE_POR_DEFECTO


        tablaInfusiones.Columns.Add("Consecutivo", Type.GetType("System.Int32"))
        tablaInfusiones.Columns.Add("Codigo_interno", Type.GetType("System.Int32"))
        tablaInfusiones.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaInfusiones.Columns.Add("Concentracion", Type.GetType("System.Double"))
        tablaInfusiones.Columns.Add("ConcentracionMedicamento", Type.GetType("System.String"))
        tablaInfusiones.Columns.Add("Aplica_disolvente", Type.GetType("System.Boolean"))
        tablaInfusiones.Columns.Add("UnidadMedicamento", Type.GetType("System.String"))
        tablaInfusiones.Columns.Add("Dosis", Type.GetType("System.Double"))
        tablaInfusiones.Columns.Add("Velocidad", Type.GetType("System.Double"))
        tablaInfusiones.Columns.Add("Producto_Disolvente", Type.GetType("System.Int32"))
        tablaInfusiones.Columns.Add("Disolvente", Type.GetType("System.String"))
        tablaInfusiones.Columns.Add("TotalDisolvente", Type.GetType("System.Double"))
        tablaInfusiones.Columns.Add("UnidadDisolvente", Type.GetType("System.String"))
        tablaInfusiones.Columns.Add("TotalDisolventeInfusion", Type.GetType("System.String"))
        tablaInfusiones.Columns.Add("CantidadDisolvente", Type.GetType("System.Int32"))

        tablaInfusiones.Columns("CantidadDisolvente").DefaultValue = 0
        tablaInfusiones.Columns("Dosis").DefaultValue = 0
        tablaInfusiones.Columns("Velocidad").DefaultValue = 0
        tablaInfusiones.Columns("Concentracion").DefaultValue = 0
        tablaInfusiones.Columns("TotalDisolvente").DefaultValue = 0
        tablaInfusiones.Columns("Disolvente").DefaultValue = Constantes.DISOLVENTE_POR_DEFECTO
        tablaInfusiones.Columns("Producto_Disolvente").DefaultValue = -1
        tablaInfusiones.Columns("TotalDisolventeInfusion").Expression = "IIF(TotalDisolvente > 0 AND Disolvente <> '" & Constantes.DISOLVENTE_POR_DEFECTO & "',Convert(TotalDisolvente,'System.String') + ' ' + UnidadDisolvente , Convert(0,'System.String') + ' ML')"

        tablaImpregnaciones.Columns.Add("Codigo_interno", Type.GetType("System.Int32"))
        tablaImpregnaciones.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaImpregnaciones.Columns.Add("Concentracion", Type.GetType("System.Double"))
        tablaImpregnaciones.Columns.Add("ConcentracionMedicamento", Type.GetType("System.String"))
        tablaImpregnaciones.Columns.Add("Aplica_disolvente", Type.GetType("System.Boolean"))
        tablaImpregnaciones.Columns.Add("UnidadMedicamento", Type.GetType("System.String"))
        tablaImpregnaciones.Columns.Add("Dosis", Type.GetType("System.Double"))
        tablaImpregnaciones.Columns.Add("Velocidad", Type.GetType("System.Double"))
        tablaImpregnaciones.Columns.Add("Producto_Disolvente", Type.GetType("System.Int32"))
        tablaImpregnaciones.Columns.Add("Disolvente", Type.GetType("System.String"))
        tablaImpregnaciones.Columns.Add("TotalDisolvente", Type.GetType("System.Double"))
        tablaImpregnaciones.Columns.Add("UnidadDisolvente", Type.GetType("System.String"))
        tablaImpregnaciones.Columns.Add("TotalDisolventeImpregnacion", Type.GetType("System.String"))
        tablaImpregnaciones.Columns.Add("CantidadDisolvente", Type.GetType("System.Int32"))
        tablaImpregnaciones.Columns.Add("Hora_Inicial", Type.GetType("System.Int32"))

        tablaImpregnaciones.Columns("CantidadDisolvente").DefaultValue = 0
        tablaImpregnaciones.Columns("Dosis").DefaultValue = 0
        tablaImpregnaciones.Columns("Velocidad").DefaultValue = 0
        tablaImpregnaciones.Columns("Concentracion").DefaultValue = 0
        tablaImpregnaciones.Columns("Producto_Disolvente").DefaultValue = -1
        tablaImpregnaciones.Columns("Disolvente").DefaultValue = Constantes.DISOLVENTE_POR_DEFECTO
        tablaImpregnaciones.Columns("TotalDisolventeImpregnacion").Expression = "IIF(TotalDisolvente > 0  AND Disolvente <> '" & Constantes.DISOLVENTE_POR_DEFECTO & "',Convert(TotalDisolvente,'System.String') + ' ' + UnidadDisolvente , Convert(0,'System.String') + ' ML')"

        tablaNutricion.Columns.Add("Codigo_interno", Type.GetType("System.Int32"))
        tablaNutricion.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaNutricion.Columns.Add("Requerimiento", Type.GetType("System.Double"))
        tablaNutricion.Columns.Add("Volumenes", Type.GetType("System.Double"))
        tablaNutricion.Columns("Requerimiento").DefaultValue = 0
        tablaNutricion.Columns("Volumenes").DefaultValue = 0

        tablaInsumosFisioterapia.Columns.Add("Codigo_interno", Type.GetType("System.Int32"))
        tablaInsumosFisioterapia.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaInsumosFisioterapia.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tablaInsumosFisioterapia.Columns("Cantidad").DefaultValue = 0

        tablaInsumosEnfermeria.Columns.Add("Codigo_interno", Type.GetType("System.Int32"))
        tablaInsumosEnfermeria.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaInsumosEnfermeria.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tablaInsumosEnfermeria.Columns("Cantidad").DefaultValue = 0

    End Sub
    Public Sub agregarTabla(ByVal pNombreTabla As String)
        If IsTablaExistente(pNombreTabla) = False Then
            dtTablaMezclas.Tables.Add(pNombreTabla)
            dtTablaMezclas.Tables(pNombreTabla).Columns.Add("Consecutivo", Type.GetType("System.Int32"))
            dtTablaMezclas.Tables(pNombreTabla).Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
            dtTablaMezclas.Tables(pNombreTabla).Columns.Add("Descripcion", Type.GetType("System.String"))
            dtTablaMezclas.Tables(pNombreTabla).Columns.Add("Dosis", Type.GetType("System.Double"))
            dtTablaMezclas.Tables(pNombreTabla).Columns.Add("Cantidad", Type.GetType("System.Int32"))
            dtTablaMezclas.Tables(pNombreTabla).Columns("Dosis").DefaultValue = 0
            dtTablaMezclas.Tables(pNombreTabla).Columns("Cantidad").DefaultValue = 0
        End If
    End Sub
    Public Sub quitarTablas(ByVal pNombreTabla As String)
        If IsTablaExistente(pNombreTabla) Then
            dtTablaMezclas.Tables.RemoveAt(pNombreTabla)
        End If
    End Sub
    Function IsTablaExistente(ByVal pNombreTabla As String)
        If dtTablaMezclas.Tables.Contains(pNombreTabla) Then
            Return True
        End If
        Return False
    End Function
    Public Function nombrarMezclaInfusion(ByVal fila As Integer) As String
        Dim nombreTabla As String = ""
        If Funciones.filaValida(fila) Then
            nombreTabla = If(tablaInfusiones.Rows(fila).Item("Consecutivo").ToString = "",
                             fila,
                             tablaInfusiones.Rows(fila).Item("Consecutivo")) & tablaInfusiones.Rows(fila).Item("Codigo_interno")
        End If
        Return nombreTabla
    End Function
End Class