Public Class HorarioLaboral
    Public Property codigo As String
    Public Property fecha As DateTime
    Public Property fechaInicio As DateTime
    Public Property fechaFin As DateTime
    Public Property fechaNovedad As DateTime
    Public Property descripcion As String
    Public Property dtDatosHorario As New DataTable
    Public Property dtHorario As New DataTable
    Public Property bsHorario As New BindingSource
    Public Property dsHorarioLaboral As New DataSet
    Public Property dtPuntoDias As New DataTable
    Public Property dtNovedades As New DataTable
    Public Property dtNovedadesDetalle As New DataTable
    Public Property dtConvenciones As New DataTable
    Public Property dtFestivos As New DataTable
    Public Property folderTmp As String
    Public Property NomArchCopia As String
    Public Property dtcopia As New DataTable
    Public Property dtpegarpunto As New DataTable
    Public Property cargando As Boolean
    Public Property ultimaFila As Integer
    Public Property ultimaColumna As Integer
    Public Property dtHorarioAGuardar As New DataTable
    Public Property dtHorarioTotalAGuardar As New DataTable
    Public Property soloCarga As Boolean

    Sub New()
        crearColumnas(dtHorario)
        crearColumnas(dtNovedades)
        crearColumnas(dtPuntoDias)

        dtcopia.Columns.Add("id_empleado", Type.GetType("System.String"))
        dtcopia.Columns.Add("Dia", Type.GetType("System.Int32"))
        dtcopia.Columns.Add("Valor", Type.GetType("System.String"))
        dtcopia.Columns.Add("Puntos", Type.GetType("System.String"))

        dtpegarpunto.Columns.Add("id_empleado", Type.GetType("System.String"))
        dtpegarpunto.Columns.Add("Dia", Type.GetType("System.String"))
        dtpegarpunto.Columns.Add("Punto", Type.GetType("System.String"))

        dtHorarioAGuardar.Columns.Add("id_empleado", Type.GetType("System.Int32"))
        dtHorarioAGuardar.Columns.Add("Dia", Type.GetType("System.DateTime"))
        dtHorarioAGuardar.Columns.Add("Convencion", Type.GetType("System.String"))
        dtHorarioAGuardar.Columns.Add("Punto", Type.GetType("System.String"))

        dtHorario.TableName = "Table" : dsHorarioLaboral.Tables.Add(dtHorario)
        dtPuntoDias.TableName = "Table1" : dsHorarioLaboral.Tables.Add(dtPuntoDias)
        dtNovedades.TableName = "Table2" : dsHorarioLaboral.Tables.Add(dtNovedades)
        dtNovedadesDetalle.TableName = "Table3" : dsHorarioLaboral.Tables.Add(dtNovedadesDetalle)
        bsHorario.DataSource = dtHorario
    End Sub
    Private Sub crearColumnas(ByRef dtDetalle As DataTable)
        dtDetalle.Columns.Add("Nombre", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Cargo", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Id_Empleado", Type.GetType("System.Int32"))
        dtDetalle.Columns.Add("Cedula", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia01", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia02", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia03", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia04", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia05", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia06", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia07", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia08", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia09", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia10", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia11", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia12", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia13", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia14", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia15", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia16", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia17", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia18", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia19", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia20", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia21", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia22", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia23", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia24", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia25", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia26", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia27", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia28", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia29", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia30", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Dia31", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Guardado", Type.GetType("System.Boolean"))
        dtDetalle.Columns.Add("Estado", Type.GetType("System.String"))
    End Sub

    Public Sub cargarConvenciones()
        General.llenarTablaYdgv(String.Format(Consultas.CARGAR_CONVENCION, SesionActual.idUsuario, SesionActual.idEmpresa), dtConvenciones)
    End Sub
    Public Class ConvencionColorMM
        Property Minutos As Int64
        Property Color As Color
    End Class
    Public Sub cargarFestivosMes()
        Dim params As New List(Of String)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        General.llenarTabla(Consultas.HORARIO_LABORAL_FESTIVOS_CARGAR, params, dtFestivos)
    End Sub

    Public Sub cargarHorario()
        If String.IsNullOrEmpty(codigo) Then
            codigo = "-2"
        End If
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(SesionActual.idEmpresa)
        params.Add(Format(fecha, Constantes.FORMATO_FECHA2))
        params.Add(soloCarga)
        General.llenarDataSet(Consultas.HORARIO_LABORAL_CARGAR, params, dsHorarioLaboral)
        For i = 0 To dtHorario.Rows.Count - 1
            dtHorario.Rows(i).Item("Estado") = Constantes.ITEM_CARGADO
        Next
        If dtDatosHorario.Rows.Count > 0 Then
            fecha = dtDatosHorario.Rows(0).Item("Fecha_Horario")
        End If
    End Sub
    Public Sub cargarFechaHorario()
        If String.IsNullOrEmpty(codigo) Then
            codigo = "-2"
        End If
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.HORARIO_LABORAL_DATOS_CARGAR, params, dtDatosHorario)
    End Sub
    Public Function redisenarTabla() As Boolean
        Dim dtHorarioEditado, dtPuntoEditado, dtNovedadEditado As New DataTable
        HistoriaClinicaBLL.filasEditada(dtHorario, dtHorarioEditado)
        HistoriaClinicaBLL.filasEditada(dtPuntoDias, dtPuntoEditado)
        HistoriaClinicaBLL.filasEditada(dtNovedades, dtNovedadEditado)
        dtHorarioAGuardar.Clear()
        dtHorarioTotalAGuardar.Clear()
        Dim filaempleado As Integer
        Dim dw_novedad As DataRow()
        Dim filaEmpleadoRow As DataRow
        For i = 0 To dtHorarioEditado.Rows.Count - 1
            Dim id_Empleado = dtHorarioEditado.Rows(i).Item("Id_Empleado").ToString
            For j = 1 To 31
                Dim columnaDia = IIf(j < 10, "Dia0", "Dia") & j
                Dim dia = Format(fecha, "yyyy-MM-") & Format(j, "00")
                Dim convencion = IIf(String.IsNullOrEmpty(dtHorarioEditado.Rows(i).Item(columnaDia).ToString.Trim),
                                     DBNull.Value,
                                     dtHorarioEditado.Rows(i).Item(columnaDia).ToString.Trim)
                dw_novedad = dtPuntoEditado.Select("Id_Empleado='" & id_Empleado & "'", "")
                filaEmpleadoRow = dw_novedad(0)
                filaempleado = dtPuntoEditado.Rows.IndexOf(filaEmpleadoRow)
                Dim punto = dtPuntoEditado.Rows(filaempleado).Item(columnaDia).ToString

                dw_novedad = dtNovedadEditado.Select("Id_Empleado='" & id_Empleado & "'", "")
                filaEmpleadoRow = dw_novedad(0)
                filaempleado = dtNovedadEditado.Rows.IndexOf(filaEmpleadoRow)
                Dim novedad = dtNovedadEditado.Rows(filaempleado).Item(columnaDia).ToString
                If (String.IsNullOrEmpty(novedad) OrElse CDbl(novedad) < 1 OrElse novedad = codigo) And IsDate(dia) Then
                    dtHorarioAGuardar.Rows.Add(id_Empleado, dia, convencion, punto)
                End If
            Next
        Next
        dtHorarioEditado.Columns.Remove("Nombre")
        dtHorarioEditado.Columns.Remove("Cargo")
        dtHorarioEditado.Columns.Remove("Cedula")
        dtHorarioEditado.Columns.Remove("Areas")
        dtHorarioEditado.Columns.Remove("Puntos")
        For i = 1 To 33
            dtHorarioEditado.Columns.RemoveAt(1)
        Next
        dtHorarioTotalAGuardar = dtHorarioEditado.Copy

        If dtHorarioAGuardar.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub guardarHorario()
        HorarioDAL.guardarHorario(Me)
    End Sub

    Public Function cargarFechaNuevoHorario() As Date
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        Return General.getValorConsulta(Consultas.HORARIO_LABORAL_NUEVO_CARGAR, params)
    End Function
End Class
