Imports Microsoft.SqlServer.Server

Public Class TerceroUsuarioCollection
    Inherits List(Of TerceroUsuario)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator

        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                               New SqlMetaData("idEmpleado", SqlDbType.Int),
                                               New SqlMetaData("idEmpresa", SqlDbType.Int),
                                               New SqlMetaData("codigoPerfil", SqlDbType.Int),
                                               New SqlMetaData("usuario", SqlDbType.NVarChar, 50),
                                               New SqlMetaData("clave", SqlDbType.NVarChar, 100),
                                               New SqlMetaData("estado", SqlDbType.Int)})
        For Each item As TerceroUsuario In Me
            sqlDataRecord.SetSqlInt32(0, item.idTercero)
            sqlDataRecord.SetSqlInt32(1, item.idEmpresa)
            sqlDataRecord.SetSqlInt32(2, item.codigoPerfil)
            sqlDataRecord.SetString(3, item.usuario)
            sqlDataRecord.SetValue(4, item.clave)
            sqlDataRecord.SetInt32(5, item.estado)
            Yield sqlDataRecord
        Next

    End Function

End Class
