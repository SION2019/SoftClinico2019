Public Class CierrePeriosdosBLL
    Dim objcierre As New CierrePeriodosDAL
    Public Sub cerrarMes(ByVal objcierreContable As CierrePeriodos)
        objcierre.cerrarMes(objcierreContable)
    End Sub

End Class
