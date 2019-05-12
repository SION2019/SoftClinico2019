Imports System.Data.SqlClient

Public Class CuentaClasificacionDAL

    Public Shared Sub actualizarClasificacionCuentas(objClasificacionCuentaHC As ClasificacionCuentaHC)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CUENTAS_UCI_ACTUALIZAR"

                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@codigo_puc", SqlDbType.Int))
                dbCommand.Parameters.Add(New SqlParameter("@codigo_cuenta", SqlDbType.Int))
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_grupo_hc", SqlDbType.Int))
                dbCommand.Parameters.Add(New SqlParameter("@Tipo_Movimiento", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_area_servicio", SqlDbType.Int))
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int))

                'Valores
                dbCommand.Parameters("@codigo_puc").Value = objClasificacionCuentaHC.codigoPuc
                dbCommand.Parameters("@codigo_cuenta").Value = objClasificacionCuentaHC.codigoCuenta
                dbCommand.Parameters("@Codigo_grupo_hc").Value = objClasificacionCuentaHC.codigoGrupoHC
                dbCommand.Parameters("@Tipo_Movimiento").Value = objClasificacionCuentaHC.tipoMovimiento
                dbCommand.Parameters("@Codigo_area_servicio").Value = objClasificacionCuentaHC.codigoAreaServicio
                dbCommand.Parameters("@usuario").Value = SesionActual.idUsuario

                dbCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
