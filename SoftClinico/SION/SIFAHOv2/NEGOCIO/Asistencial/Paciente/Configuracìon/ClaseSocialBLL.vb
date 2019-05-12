Imports System.Data.SqlClient
Public Class ClaseSocialBLL
    Dim cmd As New ClaseSocialDAL
    Public Shared Function guardarClaseSocial(objConfiguracion As ConfiguracionGeneral)
        ClaseSocialDAL.guardarClaseSocial(objConfiguracion)
        Return objConfiguracion
    End Function
End Class