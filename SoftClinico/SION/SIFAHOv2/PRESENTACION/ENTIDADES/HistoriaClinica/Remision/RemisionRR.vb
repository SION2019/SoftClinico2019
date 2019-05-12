Public Class RemisionRR
    Inherits Remision
    Public Sub New()
        nombreReporte = ConstantesHC.NOMBRE_PDF_REMISIONRR
        moduloReporte = Constantes.REPORTE_AF
        remisionListar = Consultas.REMISIONES_LISTAR_RR
        remisionCargar = Consultas.REMISION_CARGARRR
    End Sub

    Public Overrides Sub guardarRemision()
        Try
            HistoriaClinicaBLL.guardarRemisionRR(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub anularRemision()
        Dim params As New List(Of String)
        params.Add(usuario)
        params.Add(codigoRemision)
        General.ejecutarSQL(Consultas.ANULAR_REMISIONRR, params)
        consultaVerificar = Consultas.REMISION_VERIFICARRR
    End Sub
End Class
