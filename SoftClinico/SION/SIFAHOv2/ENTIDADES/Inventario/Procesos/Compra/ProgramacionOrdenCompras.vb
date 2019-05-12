Public Class ProgramacionOrdenCompras
    Inherits Despacho
    Public Property codigoProgramacion As String
    Public Property fechaProgramacion As DateTime
    Public Property tblProveedores As DataTable
    Public Property tblProveedoresCorreos As DataTable
    Public Property rutaTemporales As String
    Public Property objEnviocorreo As UsuarioEnvioCorreo

    Sub New()
        objEnviocorreo = New UsuarioEnvioCorreo
        tblLotes = New DataSet
        tblProveedoresCorreos = New DataTable
        tblProveedores = New DataTable
        tblProveedores.Columns.Add("Id", Type.GetType("System.Int32"))
        tblProveedores.Columns.Add("proveedor", Type.GetType("System.String"))

        tblProveedoresCorreos = tblProveedores.Clone()
        tblProveedoresCorreos.Columns.Add("Mail", Type.GetType("System.String"))
        tblProveedoresCorreos.Columns.Add("Verificacion", Type.GetType("System.Boolean"))
        tblProveedoresCorreos.Columns("Verificacion").DefaultValue = True
        rutaTemporales = Path.GetTempPath & "\Ordenes" '"C:\Ordenes" 

    End Sub
End Class
