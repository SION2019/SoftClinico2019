Public Class Horario
    Public Property codigo As String
    Public Property fecha As Date
    Public Property punto As Integer
    Public Property area As Integer
    Public Property cargo As Integer
    Public Property usuario As Integer
    Public Property descripcion As String
    Public Property dtDetalle As DataTable
    Public Property dtPuntoDias As DataTable

    Sub New()

        dtDetalle = New DataTable()

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
        dtDetalle.Columns.Add("Minutos_Programados", Type.GetType("System.Int64"))

        dtPuntoDias = New DataTable

        dtPuntoDias.Columns.Add("Id_empleado", Type.GetType("System.Int32"))
        dtPuntoDias.Columns.Add("Id_empresa", Type.GetType("System.Int32"))
        dtPuntoDias.Columns.Add("Codigo_punto", Type.GetType("System.Int32"))
        dtPuntoDias.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        dtPuntoDias.Columns.Add("Dia", Type.GetType("System.String"))
        dtPuntoDias.Columns.Add("Dia_Asignado", Type.GetType("System.Boolean"))
        dtPuntoDias.Columns.Add("Codigo_Horario", Type.GetType("System.String"))

    End Sub


    Public Function agregarDetalle(pDw As DataRow) As Boolean
        Dim NewRow = dtDetalle.NewRow

        For Each dc As DataColumn In dtDetalle.Columns
            If dc.ColumnName <> "Codigo_Horario" AndAlso dc.ColumnName <> "Codigo_EP" Then
                NewRow.Item(dc) = pDw.Item(dc.ColumnName)
            End If
        Next

        NewRow.Item("Codigo_Horario") = codigo
        NewRow.Item("Codigo_EP") = punto

        dtDetalle.Rows.Add(NewRow)

        Return True

    End Function

    Public Function agregarPuntoDias(pDw As DataRow) As Boolean
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
    End Function

    Public Class ConvencionColorMM
        Property Minutos As Int64
        Property Color As Color
    End Class

End Class
