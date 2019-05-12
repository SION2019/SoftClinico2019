Public Class ProgramacionPagoProveedorBLL

    Public Shared Sub guardarProgramacion(programacion As ProgramacionPagoProveedor, fechaCorte As Date, fechaDoc As Date)
        ProgramacionPagoProveedorDAL.guardarProgramacion(programacion, fechaCorte, fechaDoc)
    End Sub

End Class
