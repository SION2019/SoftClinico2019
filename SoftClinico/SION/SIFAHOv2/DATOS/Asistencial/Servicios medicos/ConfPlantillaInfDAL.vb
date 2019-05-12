Public Class ConfPlantillaInfDAL
    Public Shared Function guardarConfPlanillaInf(objConfPlantillaInf As ConfPlantillaInfo)
        'AQUI SE PASAN LOS PARAMETROS AL PROCEDIMIENTO ALMACENADO PARA LUEGO GUARDAR EN LA TABLA
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objConfPlantillaInf.sqlGuardarConfPlantillaInf
                comando.Parameters.Add(New SqlParameter("@CodigoPlantilla", SqlDbType.NVarChar)).Value = objConfPlantillaInf.codigoPlantilla
                comando.Parameters.Add(New SqlParameter("@CodigoArea", SqlDbType.Int)).Value = objConfPlantillaInf.codigoAreaServicio
                comando.Parameters.Add(New SqlParameter("@CodigoProcedimiento", SqlDbType.NVarChar)).Value = objConfPlantillaInf.codigoProcedimiento
                comando.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = objConfPlantillaInf.nombreDiag
                comando.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objConfPlantillaInf.descripcionDiag
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objConfPlantillaInf.usarioCreacion
                objConfPlantillaInf.codigoPlantilla = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objConfPlantillaInf
    End Function

    Public Shared Sub guardarInformePlantillaR(objPlantillaInfo As ConfPlantillaInfo)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objPlantillaInfo.sqlGuardarPlantillaInfR
                comando.Parameters.Add(New SqlParameter("@Respuesta", SqlDbType.Int)).Value = objPlantillaInfo.Respuesta
                comando.Parameters.Add(New SqlParameter("@CodOrden", SqlDbType.Int)).Value = objPlantillaInfo.codigoOrden
                comando.Parameters.Add(New SqlParameter("@tblPlantilla", SqlDbType.Structured)).Value = objPlantillaInfo.dtPlantilla
                comando.Parameters.Add(New SqlParameter("@IdEmpleado", SqlDbType.Int)).Value = objPlantillaInfo.idEmpleado
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objPlantillaInfo.usarioCreacion
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub guardarInformePlantillaRR(objPlantillaInfo As ConfPlantillaInfo)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objPlantillaInfo.sqlGuardarPlantillaInfRR
                comando.Parameters.Add(New SqlParameter("@Respuesta", SqlDbType.Int)).Value = objPlantillaInfo.Respuesta
                comando.Parameters.Add(New SqlParameter("@CodOrden", SqlDbType.Int)).Value = objPlantillaInfo.codigoOrden
                comando.Parameters.Add(New SqlParameter("@tblPlantilla", SqlDbType.Structured)).Value = objPlantillaInfo.dtPlantilla
                comando.Parameters.Add(New SqlParameter("@IdEmpleado", SqlDbType.Int)).Value = objPlantillaInfo.idEmpleado
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objPlantillaInfo.usarioCreacion
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
