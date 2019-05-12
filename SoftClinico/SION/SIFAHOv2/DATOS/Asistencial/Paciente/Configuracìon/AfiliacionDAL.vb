﻿Imports System.Data.SqlClient
Public Class AfiliacionDAL
    Public Shared Function guardarAfiliacion(objConfiguracion As ConfiguracionGeneral)
        Try

            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.Clear()
                comando.CommandText = Consultas.AFILIACION_GUARDAR
                comando.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = objConfiguracion.codigo
                comando.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objConfiguracion.descripcion
                comando.Parameters.Add(New SqlParameter("@Codigo_Regimen", SqlDbType.Int)).Value = objConfiguracion.codigoComplemento
                comando.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = objConfiguracion.idUsuario
                objConfiguracion.codigo = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objConfiguracion
    End Function

End Class
