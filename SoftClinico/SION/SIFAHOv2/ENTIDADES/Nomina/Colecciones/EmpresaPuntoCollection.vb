Imports Microsoft.SqlServer.Server

Public Class EmpresaPuntoCollection
    Inherits List(Of EmpresaPunto)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator

        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                               New SqlMetaData("idEmpleado", SqlDbType.Int),
                                               New SqlMetaData("codigoEP", SqlDbType.Int)})
        For Each item As EmpresaPunto In Me
            sqlDataRecord.SetSqlInt32(0, item.idEmpresa)
            sqlDataRecord.SetSqlInt32(1, item.codigoEP)
            Yield sqlDataRecord
        Next

    End Function

End Class