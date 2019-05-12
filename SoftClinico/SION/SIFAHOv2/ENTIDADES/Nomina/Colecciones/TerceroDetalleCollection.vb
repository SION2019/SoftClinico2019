Imports Microsoft.SqlServer.Server

Public Class TerceroDetalleCollection
    Inherits List(Of TerceroDetalle)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator

        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                               New SqlMetaData("idTercero", SqlDbType.Int),
                                               New SqlMetaData("idEmpresa", SqlDbType.Int),
                                               New SqlMetaData("codigoPuc", SqlDbType.Int),
                                               New SqlMetaData("codigoCIIU", SqlDbType.NVarChar, 20),
                                               New SqlMetaData("cuentaEmpleado", SqlDbType.NVarChar, 20),
                                               New SqlMetaData("cuentaProveedor", SqlDbType.NVarChar, 20),
                                               New SqlMetaData("cuentaCliente", SqlDbType.NVarChar, 20)})
        For Each item As TerceroDetalle In Me
            sqlDataRecord.SetSqlInt32(0, item.idTercero)
            sqlDataRecord.SetSqlInt32(1, item.idEmpresa)
            sqlDataRecord.SetSqlInt32(2, item.codigoPuc)
            sqlDataRecord.SetValue(3, item.codigoCIIU)
            sqlDataRecord.SetValue(4, item.cuentaEmpleado)
            sqlDataRecord.SetValue(5, item.cuentaProveedor)
            sqlDataRecord.SetValue(6, item.cuentaCliente)
            Yield sqlDataRecord
        Next

    End Function

End Class
