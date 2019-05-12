Public Class EmpleadoCuentaBancaria
    Public Property idCuentaBancaria As Integer
    Public Property codigoTipoCuenta As Integer
    Public Property CodigoBanco As Integer
    Public Property numerocuenta As String
    Public Property ccCuenta As String

    Sub New()

    End Sub

    Sub New(drCuentaBancaria As DataRow)
        idCuentaBancaria = Funciones.castDBItem(drCuentaBancaria.Item("id_cuenta_bancaria"))
        codigoTipoCuenta = Funciones.castDBItem(drCuentaBancaria.Item("codigo_tipo_cuenta"))
        CodigoBanco = Funciones.castDBItem(drCuentaBancaria.Item("codigo_banco"))
        numerocuenta = Funciones.castDBItem(drCuentaBancaria.Item("numero_cuenta"))
        ccCuenta = Funciones.castDBItem(drCuentaBancaria.Item("cc_cuenta"))
    End Sub


End Class
