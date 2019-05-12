Public Class TerceroDetalle
    Public Property idTercero As Integer
    Public Property idEmpresa As Integer
    Public Property codigoPuc As Integer
    Public Property codigoCIIU As String
    Public Property cuentaEmpleado As String
    Public Property cuentaProveedor As String
    Public Property cuentaCliente As String

    Public Sub New()

    End Sub

    Public Sub New(tercero As Tercero, idEmpresa As Integer)
        idTercero = tercero.idTercero
        Me.idEmpresa = idEmpresa
    End Sub

    Public Sub New(drTerceroDetalle As DataRow)
        idTercero = Funciones.castFromDbItem(drTerceroDetalle.Item("id_tercero"))
        idEmpresa = Funciones.castFromDbItem(drTerceroDetalle.Item("id_empresa"))
        codigoPuc = Funciones.castFromDbItem(drTerceroDetalle.Item("codigo_puc"))
        codigoCIIU = Funciones.castFromDbItem(drTerceroDetalle.Item("codigo_ciiu"))
        cuentaEmpleado = Funciones.castFromDbItem(drTerceroDetalle.Item("cuenta_empleado"))
        cuentaProveedor = Funciones.castFromDbItem(drTerceroDetalle.Item("cuenta_proveedor"))
        cuentaCliente = Funciones.castFromDbItem(drTerceroDetalle.Item("cuenta_cliente"))
    End Sub

End Class
