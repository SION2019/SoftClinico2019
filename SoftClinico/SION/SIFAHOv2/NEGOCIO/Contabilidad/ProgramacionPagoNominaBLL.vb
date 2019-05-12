Public Class ProgramacionPagoNominaBLL
    Dim objProgramacionPagoNomina As New ProgramacionPagoNominaDAL
    Public Sub guardarProgramacionPagoNomina(ByVal objProgramacion As ProgramacionPagoNomina)
        objProgramacionPagoNomina.crearProgramacionPagoNomina(objProgramacion)
    End Sub
End Class
