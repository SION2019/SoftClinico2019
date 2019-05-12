Imports Microsoft.SqlServer.Server

Public Class AreaServicioCollection
    Inherits List(Of EmpleadoAreaServicio)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator

        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                               New SqlMetaData("idEmpresa", SqlDbType.Int),
                                               New SqlMetaData("idEmpleado", SqlDbType.Int),
                                               New SqlMetaData("codigoAreaServicio", SqlDbType.Int)})
        For Each item As EmpleadoAreaServicio In Me
            sqlDataRecord.SetSqlInt32(0, item.idEmpresa)
            sqlDataRecord.SetSqlInt32(1, item.idEmpleado)
            sqlDataRecord.SetSqlInt32(2, item.codigoAreaServicio)
            Yield sqlDataRecord
        Next

    End Function

End Class