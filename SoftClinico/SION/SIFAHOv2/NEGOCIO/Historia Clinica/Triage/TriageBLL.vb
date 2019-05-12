Public Class TriageBLL
    Dim objTriageDAL As New TriageDAL
    Sub guardarTriage(ByRef objTriage As Triage)
        Try
            objTriageDAL.guardarTriage(objTriage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
