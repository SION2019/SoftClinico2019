Public Class Horario
    Public Property codigo As String
    Public Property Terceros As String
    Public Property bndNovedad As Integer = 0
    Public Property fecha As DateTime
    Public Property fechaInicio As DateTime
    Public Property fechaFin As DateTime
    Public Property fechaNovedad As DateTime
    Public Property Id_Empleado As Integer
    Public Property ConvencionAnt As String
    Public Property ConvencionNue As String
    Public Property ColDia As String
    Public Property empresa As String
    Public Property puntoE As String
    Public Property punto As Integer
    Public Property area As Integer
    Public Property cargo As String
    Public Property usuario As Integer
    Public Property descripcion As String
    Public Property dtDetalle As DataTable
    Public Property dsDetalle As BindingSource
    Public Property dtDetallePunto As DataTable
    Public Property dtPuntoDias As DataTable
    Public Property dtNovedades As DataTable
    Public Property dtFestivos As DataTable
    Public Property dtEliminarPunto As DataTable
    Public Property ds As New DataSet
    Public Property filtro As BindingSource = New BindingSource
    Public Property opcionCancelar As Boolean

    Sub New()

        dtDetalle = New DataTable()
        dsDetalle = New BindingSource
        dtDetalle.Columns.Add("Codigo_Horario", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Id_tercero", Type.GetType("System.Int32"))
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
        dtDetalle.Columns.Add("Codigo_EP", Type.GetType("System.Int32"))
        dtDetalle.Columns.Add("Turnos", Type.GetType("System.Double"))
        dtDetalle.Columns.Add("Minutos_Programados", Type.GetType("System.Double"))
        dtDetalle.Columns.Add("Anulado", Type.GetType("System.Boolean"))
        dsDetalle.DataSource = dtDetalle

        dtPuntoDias = New DataTable
        dtPuntoDias.Columns.Add("Id_empleado", Type.GetType("System.Int32"))
        dtPuntoDias.Columns.Add("Id_empresa", Type.GetType("System.Int32"))
        dtPuntoDias.Columns.Add("Codigo_punto", Type.GetType("System.Int32"))
        dtPuntoDias.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        dtPuntoDias.Columns.Add("Dia", Type.GetType("System.String"))
        dtPuntoDias.Columns.Add("Dia_Asignado", Type.GetType("System.Boolean"))
        dtPuntoDias.Columns.Add("Codigo_Horario", Type.GetType("System.String"))

        dtEliminarPunto = New DataTable
        dtEliminarPunto.Columns.Add("Codigo_Horario", Type.GetType("System.Int32"))
        dtEliminarPunto.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        dtEliminarPunto.Columns.Add("Id_empleado", Type.GetType("System.Int32"))
        dtEliminarPunto.Columns.Add("Codigo_punto", Type.GetType("System.Int32"))

        dtDetallePunto = New DataTable
        dtNovedades = New DataTable
        dtFestivos = New DataTable
    End Sub


    Public Function agregarDetalle(pDw As DataRow) As Boolean
        Dim NewRow = dtDetalle.NewRow
        If pDw.Item("Anulado") = False Then
            For Each dc As DataColumn In dtDetalle.Columns
                If dc.ColumnName <> "Codigo_Horario" AndAlso dc.ColumnName <> "Codigo_EP" Then
                    NewRow.Item(dc) = pDw.Item(dc.ColumnName)
                End If
            Next

            NewRow.Item("Codigo_Horario") = codigo
            NewRow.Item("Codigo_EP") = punto

            dtDetalle.Rows.Add(NewRow)
            Return True
        End If

        Return False
    End Function

    Public Function agregarPuntoDias(pDw As DataRow) As Boolean
        Try
            If pDw.Item("Dia_Asignado") <> True Then Return False
            Dim NewRow = dtPuntoDias.NewRow

            For Each dc As DataColumn In dtPuntoDias.Columns
                If dc.ColumnName <> "Codigo_Horario" AndAlso dc.ColumnName <> "Fecha" Then
                    NewRow.Item(dc) = pDw.Item(dc.ColumnName)
                End If
            Next

            NewRow.Item("Codigo_Horario") = codigo

            NewRow.Item("Fecha") = Exec.varcharDate(fecha.ToString("yyyyMM") & CInt(Strings.Right(NewRow.Item("Dia"), 2)).ToString("00"))

            dtPuntoDias.Rows.Add(NewRow)

            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try

    End Function

    Public Class ConvencionColorMM
        Property Minutos As Int64
        Property Color As Color
        Property Anulado As Int64
        Property fechaActualizacion As Date
    End Class
    Public Sub cargarFestivosMes()
        Dim params As New List(Of String)
        params.Add(fechaInicio)
        params.Add(fechafin)
        General.llenarTabla(Consultas.HORARIOFESTIVOS_CARGAR, params, dtFestivos)
    End Sub
    Public Sub cargarNovedades()
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(Terceros)
        General.llenarTabla(Consultas.HORARIONOV_CARGAR, params, dtNovedades)
    End Sub

    Public Sub cargarHorario()
        General.llenarDataSet(Consultas.HORARIO_CARGAR & codigo, ds)

    End Sub



End Class
