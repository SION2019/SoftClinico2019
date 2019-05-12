Imports Microsoft.SqlServer.Server
Imports System.Data.SqlTypes

Public Class CuentaBancariaCollection
    Inherits List(Of EmpleadoCuentaBancaria)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator
        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                                New SqlMetaData("idCuentaBancaria", SqlDbType.Int),
                                                New SqlMetaData("codigoTipoCuenta", SqlDbType.Int),
                                                New SqlMetaData("idEmpresa", SqlDbType.Int),
                                                New SqlMetaData("idEmpleado", SqlDbType.Int),
                                                New SqlMetaData("codigoBanco", SqlDbType.Int),
                                                New SqlMetaData("numeroCuenta", SqlDbType.NVarChar, 26),
                                                New SqlMetaData("ccCuenta", SqlDbType.NVarChar, 26)})

        For Each item As EmpleadoCuentaBancaria In Me
            sqlDataRecord.SetSqlInt32(0, Funciones.castToSqlInt32(item.idCuentaBancaria))
            sqlDataRecord.SetSqlInt32(1, item.codigoTipoCuenta)
            sqlDataRecord.SetInt32(2, item.idEmpresa)
            sqlDataRecord.SetInt32(3, item.idEmpleado)
            sqlDataRecord.SetInt32(4, item.CodigoBanco)
            sqlDataRecord.SetString(5, item.numerocuenta)
            sqlDataRecord.SetString(6, item.ccCuenta)

            Yield sqlDataRecord
        Next

    End Function
End Class
