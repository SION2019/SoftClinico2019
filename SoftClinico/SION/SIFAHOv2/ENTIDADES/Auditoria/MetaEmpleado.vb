Public Class MetaEmpleado
    Public Property dsMeta As New DataSet
    Public Property bsMeta As New BindingSource
    Public Property bsMetaDetalle As New BindingSource
    Public Property bsMetaDetalleDia As New BindingSource
    Public Property dtConsolidado As New DataTable
    Public Property dtConsolidadoModulo As New DataTable
    Public Property dtConsolidadoDia As New DataTable
    Public Property dtConsolidadoPeriodo As New DataTable
    Public Property dtMetas As New DataTable
    Public Property dtHC As New DataTable
    Public Property dtAM As New DataTable
    Public Property dtAF As New DataTable
    Public Property fechaInicio As Date
    Public Property fechaFin As Date
    Public Property CTC As Boolean
    Public Property todo As Boolean
    Public Property CodigoCargo As String
    Public Property diferencia As Double
    Public Property porcentaje As Double
    Public Property idEmpleado As String

    Public Sub New()
        enlazarTabla(dtHC)
        enlazarTabla(dtAM)
        enlazarTabla(dtAF)
        dtConsolidadoPeriodo.Columns.Add("Bandera", Type.GetType("System.String"))
        enlazarTabla(dtConsolidadoPeriodo)
        dtConsolidadoPeriodo.Columns.Remove("Id_Empleado")
        dtConsolidadoPeriodo.Columns.Remove("Empleado")
        dtConsolidadoModulo.Columns.Add("Bandera", Type.GetType("System.String"))
        enlazarTabla(dtConsolidadoModulo)
        enlazarTabla(dtConsolidado, True)
        dtConsolidado.Columns.Add("Meta_Alcanzada", Type.GetType("System.String"))
        dtConsolidado.Columns.Add("Porcentaje_Alcanzado", Type.GetType("System.String"))
        dtConsolidadoDia.Columns.Add("Paciente", Type.GetType("System.String"))
        dtConsolidadoDia.Columns.Add("Bandera", Type.GetType("System.String"))
        dtConsolidadoDia.Columns.Add("Fecha", Type.GetType("System.String"))
        dtConsolidadoDia.Columns.Add("AporteMedicamentosN", Type.GetType("System.Double")).DefaultValue = 0
        enlazarTabla(dtConsolidadoDia, True)
        dtHC.TableName = "Table" : dsMeta.Tables.Add(dtHC)
        dtAM.TableName = "Table1" : dsMeta.Tables.Add(dtAM)
        dtAF.TableName = "Table2" : dsMeta.Tables.Add(dtAF)
        dtConsolidado.TableName = "Table3" : dsMeta.Tables.Add(dtConsolidado)
        dtConsolidadoModulo.TableName = "Table4" : dsMeta.Tables.Add(dtConsolidadoModulo)
        dtConsolidadoDia.TableName = "Table5" : dsMeta.Tables.Add(dtConsolidadoDia)
        dtConsolidadoPeriodo.TableName = "Table6" : dsMeta.Tables.Add(dtConsolidadoPeriodo)
        bsMeta.DataSource = dtConsolidado
        bsMetaDetalle.DataSource = dtConsolidadoModulo
        bsMetaDetalleDia.DataSource = dtConsolidadoDia
    End Sub
    Private Sub enlazarTabla(dt As DataTable, Optional totalAportes As Boolean = False)
        dt.Columns.Add("Id_Empleado", Type.GetType("System.Int32"))
        dt.Columns.Add("Empleado", Type.GetType("System.String"))
        dt.Columns.Add("AporteEstancia", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteTraslados", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteOxigeno", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteParaclinicos", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteHemoderivados", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteProcedimientos", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteMedicamentos", Type.GetType("System.Double")).DefaultValue = 0
        dt.Columns.Add("AporteInsumos", Type.GetType("System.Double")).DefaultValue = 0
        If totalAportes Then
            dt.Columns.Add("TotalAportes", Type.GetType("System.Double")).DefaultValue = 0
            dt.Columns.Add("% Aporte", Type.GetType("System.Double")).DefaultValue = 0
        End If
    End Sub
    Public Sub cargarMeta()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(Format(fechaInicio, Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(fechaFin, Constantes.FORMATO_FECHA_GEN))
        params.Add(CTC)
        params.Add(todo)
        params.Add(IIf(String.IsNullOrEmpty(CodigoCargo), Constantes.VALOR_PREDETERMINADO, CodigoCargo))
        params.Add(IIf(String.IsNullOrEmpty(idEmpleado), Constantes.VALOR_PREDETERMINADO, idEmpleado))
        General.llenarDataSet(ConsultasNom.EMPLEADO_META_PERIODO_CARGAR, params, dsMeta)
        calcularTotales()
        calcularMetaAlcanzada()
    End Sub
    Private Sub calcularTotales()
        If dtConsolidado.Rows.Count = 0 Then Exit Sub
        If dtConsolidadoPeriodo.Rows(0).Item("TotalAportes") = 0 Then
            diferencia = dtConsolidadoPeriodo.Rows(2).Item("TotalAportes")
            porcentaje = 100
        Else
            diferencia = (dtConsolidadoPeriodo.Rows(2).Item("TotalAportes") - dtConsolidadoPeriodo.Rows(0).Item("TotalAportes"))
            porcentaje = ((dtConsolidadoPeriodo.Rows(2).Item("TotalAportes") * 100) / dtConsolidadoPeriodo.Rows(0).Item("TotalAportes")) - 100
        End If
    End Sub
    Private Sub calcularMetaAlcanzada()
        cargarMetaDetalle()
        For i = 0 To dtConsolidado.Rows.Count - 1

            Dim dt As New DataTable
            dt = calcularDimensiones(dtConsolidado.Rows(i).Item("totalAportes"), dtConsolidado.Rows(i).Item("ID_EMPLEADO"))
            For j = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item("Superada") = True Then
                    dtConsolidado.Rows(i).Item("Meta_Alcanzada") = dt.Rows(j).Item("Meta")
                    dtConsolidado.Rows(i).Item("Porcentaje_Alcanzado") = dt.Rows(j).Item("Porcentaje")
                End If
            Next
        Next
    End Sub
    Public Sub cargarMetaDetalle(Optional idEmpleado As String = "")
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(Format(fechaInicio, Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(fechaFin, Constantes.FORMATO_FECHA_GEN))
        params.Add(CTC)
        params.Add(todo)
        params.Add(IIf(String.IsNullOrEmpty(CodigoCargo), Constantes.VALOR_PREDETERMINADO, CodigoCargo))
        params.Add(IIf(String.IsNullOrEmpty(idEmpleado), Constantes.VALOR_PREDETERMINADO, idEmpleado))
        General.llenarTabla(ConsultasNom.EMPLEADO_META_EMPLEADO_CARGAR, params, dtMetas)

    End Sub
    Public Function calcularDimensiones(aporteActual As Double, idEmpleado As Integer)
        Dim tablaLocalizacionMeta As New DataTable
        tablaLocalizacionMeta.Columns.Add("Meta")
        tablaLocalizacionMeta.Columns.Add("Valor")
        tablaLocalizacionMeta.Columns.Add("Porcentaje")
        tablaLocalizacionMeta.Columns.Add("Localizacion")
        tablaLocalizacionMeta.Columns.Add("Superada")
        Dim filas As DataRow()
        Dim dtNueva As New DataTable
        dtNueva = dtMetas.Clone
        filas = dtMetas.Select("id_empleado = " & idEmpleado)
        For Each row As DataRow In filas
            dtNueva.ImportRow(row)
        Next
        If dtNueva.Rows.Count > 0 Then
            Dim distancia As Integer
            If dtNueva.Rows.Count > 1 Then
                distancia = 317 / (dtNueva.Rows.Count - 1)
            End If

            Dim localizacionSostenimiento As Integer
            Dim superada As Boolean
            If aporteActual >= dtNueva.Rows(0).Item("Valor") Then
                superada = True
            Else
                superada = False
            End If
            localizacionSostenimiento = 393

            tablaLocalizacionMeta.Rows.Add(1, dtNueva.Rows(0).Item("Valor"), dtNueva.Rows(0).Item("Porcentaje"),
                                               localizacionSostenimiento, superada)
            For i = 1 To dtNueva.Rows.Count - 1
                localizacionSostenimiento = localizacionSostenimiento - distancia
                If aporteActual >= dtNueva.Rows(i).Item("Valor") Then
                    superada = True
                Else
                    superada = False
                End If
                tablaLocalizacionMeta.Rows.Add(i + 1, dtNueva.Rows(i).Item("Valor"), dtNueva.Rows(i).Item("Porcentaje"),
                localizacionSostenimiento, superada)
            Next
        End If
        Return tablaLocalizacionMeta
    End Function
    Public Sub guardarMeta(ByRef dtMetaAlcanzada As DataTable)
        Try
            Dim fechaMeta As Date
            fechaMeta = fechaFin.AddDays(fechaFin.Day * -1 + 1)
            MetaEmpleadoDAL.guardarMeta(dtMetaAlcanzada, fechaMeta)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
