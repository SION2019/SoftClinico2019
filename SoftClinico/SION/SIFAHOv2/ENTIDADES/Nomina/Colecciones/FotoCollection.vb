Imports Microsoft.SqlServer.Server

Public Class FotoCollection
    Inherits List(Of EmpleadoFoto)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator
        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                            New SqlMetaData("idEmpleado", SqlDbType.Int),
                                            New SqlMetaData("foto", SqlDbType.Image)})
        For Each item As EmpleadoFoto In Me
            sqlDataRecord.SetInt32(0, item.idEmpleado)
            sqlDataRecord.SetValue(1, Funciones.convertirImagenToByte(item.foto))
            Yield sqlDataRecord
        Next
    End Function
End Class
