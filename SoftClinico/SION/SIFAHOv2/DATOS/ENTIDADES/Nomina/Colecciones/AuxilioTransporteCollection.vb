Imports Microsoft.SqlServer.Server

Public Class AuxilioTransporteCollection
    Inherits List(Of EmpleadoAuxilio)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator
        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                              New SqlMetaData("idAuxTransporte", SqlDbType.Int),
                                              New SqlMetaData("idEmpresa", SqlDbType.Int),
                                              New SqlMetaData("idEmpleado", SqlDbType.Int),
                                              New SqlMetaData("valor", SqlDbType.Decimal)})
        For Each item As EmpleadoAuxilio In Me
            sqlDataRecord.SetInt32(0, item.idAuxilio)
            sqlDataRecord.SetInt32(1, item.idEmpresa)
            sqlDataRecord.SetInt32(2, item.idEmpleado)
            sqlDataRecord.SetDecimal(3, item.valor)
            Yield sqlDataRecord
        Next
    End Function
End Class
