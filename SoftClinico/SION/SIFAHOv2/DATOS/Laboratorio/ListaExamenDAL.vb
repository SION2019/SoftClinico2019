Public Class ListaExamenDAL
    Public Shared Function guardarListaExamen(objListaExamen As Object) As Object
        Try
            Using comando As New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = ""
                comando.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objListaExamen.codigo
                comando.Parameters.Add(New SqlParameter("@Fecha_Max", SqlDbType.Int)).Value = objListaExamen.fechaMax
                comando.Parameters.Add(New SqlParameter("@Fecha_Min", SqlDbType.Int)).Value = objListaExamen.fechaMin
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objListaExamen
    End Function
End Class
