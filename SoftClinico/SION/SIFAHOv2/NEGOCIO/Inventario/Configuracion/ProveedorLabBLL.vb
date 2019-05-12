Public Class ProveedorLabBLL
    Public Shared Function guardarProveedorLab(objPorveedorLab As ProveedorLab) As ProveedorLab
        ProveedorLabDAL.guardarProveedorLab(objPorveedorLab)
        Return objPorveedorLab
    End Function
End Class
