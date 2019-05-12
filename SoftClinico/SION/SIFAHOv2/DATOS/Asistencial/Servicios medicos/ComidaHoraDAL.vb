Imports System.Data.SqlClient
Public Class ComidaHoraDAL
    Public Sub guardar(ByRef objComida As ComidasHoras,
                       ByVal usuario As String,
                       ByVal punto As Integer)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_COMIDA_HORA_CREAR]"
                sentencia.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.NVarChar)).Value = objComida.descripcion
                sentencia.Parameters.Add(New SqlParameter("@pDesdeDesayuno", SqlDbType.DateTime)).Value = objComida.hDesdeDesayuno
                sentencia.Parameters.Add(New SqlParameter("@pHastaDesayuno", SqlDbType.DateTime)).Value = objComida.hHastaDesayuno
                sentencia.Parameters.Add(New SqlParameter("@pDesdeAlmuerzo", SqlDbType.DateTime)).Value = objComida.hDesdeAlmuerzo
                sentencia.Parameters.Add(New SqlParameter("@pHastaAlmuerzo", SqlDbType.DateTime)).Value = objComida.hHastaAlmuerzo
                sentencia.Parameters.Add(New SqlParameter("@pDesdeCena", SqlDbType.DateTime)).Value = objComida.hDesdeCena
                sentencia.Parameters.Add(New SqlParameter("@pHsataCena", SqlDbType.DateTime)).Value = objComida.hHastaCena
                sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                sentencia.Parameters.Add(New SqlParameter("@pCodigoPuntoActual", SqlDbType.Int)).Value = punto
                objComida.codigo = CType(sentencia.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef objComida As ComidasHoras,
                          ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_COMIDA_HORA_ACTUALIZAR]"
                sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.NVarChar)).Value = objComida.codigo
                sentencia.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.NVarChar)).Value = objComida.descripcion
                sentencia.Parameters.Add(New SqlParameter("@pDesdeDesayuno", SqlDbType.DateTime)).Value = objComida.hDesdeDesayuno
                sentencia.Parameters.Add(New SqlParameter("@pHastaDesayuno", SqlDbType.DateTime)).Value = objComida.hHastaDesayuno
                sentencia.Parameters.Add(New SqlParameter("@pDesdeAlmuerzo", SqlDbType.DateTime)).Value = objComida.hDesdeAlmuerzo
                sentencia.Parameters.Add(New SqlParameter("@pHastaAlmuerzo", SqlDbType.DateTime)).Value = objComida.hHastaAlmuerzo
                sentencia.Parameters.Add(New SqlParameter("@pDesdeCena", SqlDbType.DateTime)).Value = objComida.hDesdeCena
                sentencia.Parameters.Add(New SqlParameter("@pHsataCena", SqlDbType.DateTime)).Value = objComida.hHastaCena
                sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                objComida.codigo = CType(sentencia.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef objComida As ComidasHoras,
                      ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_COMIDA_HORA_ANULAR]"
                sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objComida.codigo
                sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
