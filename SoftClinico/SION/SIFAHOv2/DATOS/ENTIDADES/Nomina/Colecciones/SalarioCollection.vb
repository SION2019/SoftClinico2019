Imports Microsoft.SqlServer.Server

Public Class SalarioCollection
    Inherits List(Of EmpleadoSalario)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator
        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                               New SqlMetaData("idSalario", SqlDbType.Int),
                                               New SqlMetaData("idEmpresa", SqlDbType.Int),
                                               New SqlMetaData("idEmpleado", SqlDbType.Int),
                                               New SqlMetaData("valor", SqlDbType.Decimal)})
        For Each item As EmpleadoSalario In Me
            sqlDataRecord.SetSqlInt32(0, Funciones.castToSqlInt32(item.idSalario))
            sqlDataRecord.SetSqlInt32(1, item.idEmpresa)
            sqlDataRecord.SetSqlInt32(2, item.idEmpleado)
            sqlDataRecord.SetDecimal(3, item.valor)
            Yield sqlDataRecord
        Next
    End Function
End Class
