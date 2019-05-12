Public Class FormatoIngresoBLL
    Public Shared Function guardarFormatoIngreso(objFormato As FormatoIngreso)

        FormatoIngresoDAL.guardarFormatoIngreso(objFormato)
        Return objFormato
    End Function
End Class
