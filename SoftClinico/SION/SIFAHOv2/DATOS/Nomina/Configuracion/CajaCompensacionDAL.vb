Imports System.Data.SqlClient
Imports System.IO
Public Class CajaCompensacionDAL
    Public Function crearCajaCompensacion(objCajaComp As CajaCompensacion) As String
        Dim codigo As String = ""
        Try
            Using dbCommand As New SqlCommand("PROC_CAJA_CREAR")
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                dbCommand.Parameters("@DESCRIPCION").Value = objCajaComp.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar))
                dbCommand.Parameters("@Usuario_creacion").Value = objCajaComp.usuario
                objCajaComp.codigo = CType(dbCommand.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
        Return objCajaComp.codigo
    End Function
    Public Sub actualizarCajaCompensacion(objCajaComp As CajaCompensacion)
        Try
            Using dbCommand As New SqlCommand("PROC_CAJA_ACTUALIZAR")
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                dbCommand.Parameters("@DESCRIPCION").Value = objCajaComp.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                dbCommand.Parameters("@CODIGO").Value = objCajaComp.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                dbCommand.Parameters("@Usuario").Value = objCajaComp.usuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

End Class
