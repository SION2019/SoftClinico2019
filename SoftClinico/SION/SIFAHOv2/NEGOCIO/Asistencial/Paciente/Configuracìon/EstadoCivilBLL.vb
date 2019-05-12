Imports System.Data.SqlClient
Public Class EstadoCivilBLL
    Public Shared Function guardarEstadoCivil(objConfiguracion As ConfiguracionGeneral)
        EstadoCivilDAL.guardarEstadoCivil(objConfiguracion)
        Return objConfiguracion
    End Function


End Class