
Public Class DiagnosticoBLL
    Public Shared Function guardarDiagnoticos(objDiagnostico As ConfiguracionDiagnostico)
        DiagnosticoDAL.guardarDiagnostico(objDiagnostico)
        Return objDiagnostico
    End Function

End Class