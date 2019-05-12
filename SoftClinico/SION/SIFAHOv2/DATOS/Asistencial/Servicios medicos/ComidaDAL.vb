Imports System.Data.SqlClient
Public Class ComidaDAL
    Public Sub guardarComida(obj As Comida)


        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Clear()
                comando.CommandText = "[PROC_COMIDA_CREAR]"
                comando.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.NVarChar)).Value = obj.SetGetNombreComida
                comando.Parameters.Add(New SqlParameter("@pCosto", SqlDbType.Float)).Value = obj.SetGetCosto
                comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.Parameters.Add(New SqlParameter("@codigoPunto", SqlDbType.Int)).Value = obj.SetGetPuntoComida
                obj.SetGetCodigoComida = CType(comando.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub actualizarComida(obj As Comida)

        Try
            Using comida = New SqlCommand()
                comida.Connection = FormPrincipal.cnxion
                comida.CommandType = CommandType.StoredProcedure

                comida.Parameters.Clear()
                comida.CommandText = "[PROC_COMIDA_MODIFICAR]"
                comida.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = obj.SetGetCodigoComida
                comida.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.NVarChar)).Value = obj.SetGetNombreComida
                comida.Parameters.Add(New SqlParameter("@pCosto", SqlDbType.Float)).Value = obj.SetGetCosto
                comida.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                obj.SetGetCodigoComida = CType(comida.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
