Public Class PedidoServicioBLL
    Dim cmd As New Pedido_Servicio_C
    Public Sub guardar(obj As Pedido_Servicio)
        cmd.guardar(obj)
    End Sub

    Public Sub cargarDatos(ByRef obj As Pedido_Servicio, codigo As String)
        cmd.cargarDatos(obj, codigo)
    End Sub
    Public Sub actualizar(obj As Pedido_Servicio)
        cmd.actualizar(obj)
    End Sub
    Public Sub anular(obj As Pedido_Servicio)
        cmd.anular(obj)
    End Sub
End Class
