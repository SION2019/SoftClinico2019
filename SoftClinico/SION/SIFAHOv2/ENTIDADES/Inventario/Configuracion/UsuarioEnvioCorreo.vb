Public Class UsuarioEnvioCorreo
    Public Property CodigoConfiguracion As String
    Public Property email As String
    Public Property asunto As String
    Public Property contreseña As String
    Public Property idTerceroAsignado As Integer
    Public Property fechaConf As DateTime
    Public Property tblFormularios As DataTable
    Public Property configuracionEnvio As ConfiguracionEnvioCorreo

    Sub New()

        tblFormularios = New DataTable


        tblFormularios.Columns.Add("codigo_Menu", Type.GetType("System.String"))
        tblFormularios.Columns.Add("Descripcion_menu", Type.GetType("System.String"))
        tblFormularios.Columns.Add("formulario", Type.GetType("System.String"))
        tblFormularios.Columns.Add("Modulo", Type.GetType("System.String"))
        tblFormularios.Columns.Add("Asignar", Type.GetType("System.Boolean"))
        tblFormularios.Columns("Asignar").DefaultValue = False


    End Sub
End Class
