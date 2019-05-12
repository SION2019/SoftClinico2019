Public Class ArchivohcBLL
    Public Shared Function guardarArchivo(objArchivo As ArchivoHC)
        BloqueDAL.guardarBloque(objArchivo)
        Return objArchivo
    End Function
End Class
