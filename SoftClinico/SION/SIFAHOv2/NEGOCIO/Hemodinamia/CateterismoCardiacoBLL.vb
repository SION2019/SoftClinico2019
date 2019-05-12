Public Class CateterismoCardiacoBLL
    Dim objCateterismoDAL As New InformeCateterismoDAL
    Public Sub guardarCateterismo(ByRef objCateterismo As CateterismoCardiaco)
        If String.IsNullOrEmpty(objCateterismo.codigoCateterismo) Then
            objCateterismoDAL.guardarCateterismo(objCateterismo)
        Else
            objCateterismoDAL.actualizarCateterismo(objCateterismo)
        End If
    End Sub
    Public Sub guardarCateterismoR(ByRef objCateterismo As CateterismoCardiacoR)
        If String.IsNullOrEmpty(objCateterismo.codigoCateterismo) Then
            objCateterismoDAL.guardarCateterismoAM(objCateterismo)
        Else
            objCateterismoDAL.actualizarCateterismoAM(objCateterismo)
        End If
    End Sub
    Public Sub guardarCateterismoRR(ByRef objCateterismo As CateterismoCardiacoRR)
        If String.IsNullOrEmpty(objCateterismo.codigoCateterismo) Then
            objCateterismoDAL.guardarCateterismoAF(objCateterismo)
        Else
            objCateterismoDAL.actualizarCateterismoAF(objCateterismo)
        End If
    End Sub
End Class
