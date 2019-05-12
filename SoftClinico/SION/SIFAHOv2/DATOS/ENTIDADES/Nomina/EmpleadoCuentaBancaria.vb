Public Class EmpleadoCuentaBancaria
    Public Property idCuentaBancaria As Integer?
    Public Property codigoTipoCuenta As Integer
    Public Property idEmpresa As Integer
    Public Property idEmpleado As Integer
    Public Property CodigoBanco As Integer
    Public Property numerocuenta As String
    Public Property ccCuenta As String

    Sub New()

    End Sub

    Sub New(tercero As Tercero, empresa As Integer)
        idEmpleado = tercero.idTercero
        idEmpresa = idEmpresa
    End Sub

    Sub New(drCuentaBancaria As DataRow)
        idCuentaBancaria = Funciones.castFromDbItem(drCuentaBancaria.Item("id_cuenta_bancaria"))
        codigoTipoCuenta = Funciones.castFromDbItem(drCuentaBancaria.Item("codigo_tipo_cuenta"))
        idEmpresa = Funciones.castFromDbItem(drCuentaBancaria.Item("id_empresa"))
        idEmpleado = Funciones.castFromDbItem(drCuentaBancaria.Item("id_empleado"))
        CodigoBanco = Funciones.castFromDbItem(drCuentaBancaria.Item("codigo_banco"))
        numerocuenta = Funciones.castFromDbItem(drCuentaBancaria.Item("numero_cuenta"))
        ccCuenta = Funciones.castFromDbItem(drCuentaBancaria.Item("cc_cuenta"))
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otraCuenta As EmpleadoCuentaBancaria = CType(obj, EmpleadoCuentaBancaria)
        If otraCuenta.codigoTipoCuenta <> Me.codigoTipoCuenta Or
           otraCuenta.CodigoBanco <> Me.CodigoBanco Or
           otraCuenta.numerocuenta <> Me.numerocuenta Or
           otraCuenta.ccCuenta <> Me.ccCuenta Then
            Return False
        End If

        Return True
    End Function




End Class
