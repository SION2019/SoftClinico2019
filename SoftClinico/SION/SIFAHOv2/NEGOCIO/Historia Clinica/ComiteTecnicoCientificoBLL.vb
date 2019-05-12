Public Class ComiteTecnicoCientificoBLL
    Public Shared Function guardarCTC(objComite As ComiteCTC)
        ComiteTecnicoCientificoDAL.guardarCTC(objComite)
        Return objComite
    End Function


End Class
