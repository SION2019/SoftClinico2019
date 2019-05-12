Public Class OxigenoConfBLL
    Dim cmd As New OxigenoConfDAL

    Public Sub guardarOxigeno(ByRef txtCodigo As Object, ByVal descripcion As String,
                                   ByVal factor As Double,
                                   ByVal porcentaje As Double,
                                   ByVal codigoEquivalencia As Integer)
        cmd.guardarOxigeno(txtCodigo, descripcion, factor, porcentaje, codigoEquivalencia)

    End Sub
    Public Sub actualizarOxigeno(ByVal codigo As Integer,
                                  ByVal descripcion As String,
                                  ByVal factor As Double,
                                  ByVal porcentaje As Double,
                                  ByVal codigoEquivalencia As Integer)
        cmd.actualizarOxigeno(codigo, descripcion, factor, porcentaje, codigoEquivalencia)
    End Sub
End Class
