Public Class PedidoComida
    Public Property codigo As String
    Public Property codigoProveedor As String
    Public Property areaServicio As String
    Public Property fechaPedido As DateTime
    Public Property tipoComida As String
    Public Property tblComida As DataTable
    Sub New()
        tblComida = New DataTable
        tblComida.Columns.Add("Codigo_orden", Type.GetType("System.String"))
        tblComida.Columns.Add("Paciente", Type.GetType("System.String"))
        tblComida.Columns.Add("Cama", Type.GetType("System.String"))
        tblComida.Columns.Add("Edad", Type.GetType("System.String"))
        tblComida.Columns.Add("Codigo_comidaDes", Type.GetType("System.String"))
        tblComida.Columns.Add("Codigo_comidaAlm", Type.GetType("System.String"))
        tblComida.Columns.Add("Codigo_comidaCen", Type.GetType("System.String"))
        tblComida.Columns.Add("Desayuno", Type.GetType("System.String"))
        tblComida.Columns.Add("Almuerzo", Type.GetType("System.String"))
        tblComida.Columns.Add("Cena", Type.GetType("System.String"))
        tblComida.Columns.Add("ValorDesayuno", Type.GetType("System.Double"))
        tblComida.Columns.Add("ValorAlmuerzo", Type.GetType("System.Double"))
        tblComida.Columns.Add("ValorCena", Type.GetType("System.Double"))
        tblComida.Columns("ValorDesayuno").DefaultValue = 0
        tblComida.Columns("ValorAlmuerzo").DefaultValue = 0
        tblComida.Columns("ValorCena").DefaultValue = 0
        fechaPedido = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
    End Sub
End Class
