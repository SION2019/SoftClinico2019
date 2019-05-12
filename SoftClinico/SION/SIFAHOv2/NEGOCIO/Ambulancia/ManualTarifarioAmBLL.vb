Public Class ManualTarifarioAmBLL
    Public Shared Sub guardarManualTarifario(objManualTarifa As ManualTarifarioAM)
        ManualTarifarioAmDAL.guardarManualTarifario(objManualTarifa)
    End Sub
    Public Shared Sub agregarFilaManualTarifario(dttable As DataTable)
        dttable.Rows.Add()
    End Sub
End Class
