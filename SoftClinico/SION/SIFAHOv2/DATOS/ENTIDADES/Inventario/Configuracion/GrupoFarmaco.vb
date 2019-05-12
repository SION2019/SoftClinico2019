Public Class GrupoFarmaco
    Public Property codigo As String
    Public Property nombre As String
    Public Property combofarmaco As Integer
    Public Property usuario As Integer

    Public Sub guardarFarmaco()
        FarmacologicoDAL.guardarFarmacologico(Me)
    End Sub
End Class
