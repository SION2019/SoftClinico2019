Public Class EpicrisisBLL
    Dim objEpicrisisDAL As New EpicrisisDAL
    Public Sub guardarEpicrisis(ByRef objEpicrisis As Epicrisis)
        objEpicrisisDAL.guardarEpicrisisHc(objEpicrisis)
    End Sub
    Public Sub guardarEpicrisisR(ByRef objEpicrisis As EpicrisisR)
        objEpicrisisDAL.guardarEpicrisisAm(objEpicrisis)
    End Sub
    Public Sub guardarEpicrisisRR(ByRef objEpicrisis As EpicrisisRR)
        objEpicrisisDAL.guardarEpicrisisAf(objEpicrisis)
    End Sub
End Class
