Imports System.Data.SqlClient
Public Class TarifaTripulacionDAL
    Public Shared Function guardarTarifaTripulacion(objTripulacion As Tripulante)
        'AQUI SE PASAN LOS PARAMETROS AL PROCEDIMIENTO ALMACENADO PARA LUEGO GUARDAR EN LA TABLA
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objTripulacion.sqlGuardarTarifaTripulacion
                comando.Parameters.Add(New SqlParameter("@Codigo_Tarifa_Tripulacion", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Tarifa_Tripulacion
                comando.Parameters.Add(New SqlParameter("@Codigo_Pais_Origen", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Pais_Origen
                comando.Parameters.Add(New SqlParameter("@Codigo_Dpto_Origen", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Dpto_Origen
                comando.Parameters.Add(New SqlParameter("@Codigo_Municipio_Origen", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Municipio_Origen
                comando.Parameters.Add(New SqlParameter("@Codigo_Pais_Destino", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Pais_Destino
                comando.Parameters.Add(New SqlParameter("@Codigo_Dpto_Destino", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Dpto_Destino
                comando.Parameters.Add(New SqlParameter("@Codigo_Municipio_Destino", SqlDbType.NVarChar)).Value = objTripulacion.Codigo_Municipio_Destino
                comando.Parameters.Add(New SqlParameter("@Valor_Administrativo_S", SqlDbType.Decimal)).Value = objTripulacion.Valor_Administrativo_S
                comando.Parameters.Add(New SqlParameter("@Valor_Administrativo_R", SqlDbType.Decimal)).Value = objTripulacion.Valor_Administrativo_R
                comando.Parameters.Add(New SqlParameter("@Valor_Conductor_S", SqlDbType.Decimal)).Value = objTripulacion.Valor_Conductor_S
                comando.Parameters.Add(New SqlParameter("@Valor_Conductor_R", SqlDbType.Decimal)).Value = objTripulacion.Valor_Conductor_R
                comando.Parameters.Add(New SqlParameter("@Valor_Paramedico_S", SqlDbType.Decimal)).Value = objTripulacion.Valor_Paramedico_S
                comando.Parameters.Add(New SqlParameter("@Valor_Paramedico_R", SqlDbType.Decimal)).Value = objTripulacion.Valor_Paramedico_R
                comando.Parameters.Add(New SqlParameter("@Valor_Medico_S", SqlDbType.Decimal)).Value = objTripulacion.Valor_Medico_S
                comando.Parameters.Add(New SqlParameter("@Valor_Medico_R", SqlDbType.Decimal)).Value = objTripulacion.Valor_Medico_R
                comando.Parameters.Add(New SqlParameter("@Valor_Contacto", SqlDbType.Decimal)).Value = objTripulacion.Valor_Contacto
                comando.Parameters.Add(New SqlParameter("@Valor_Fisioterapeuta_S", SqlDbType.Decimal)).Value = objTripulacion.Valor_Fisioterapeuta_S
                comando.Parameters.Add(New SqlParameter("@Valor_Fisioterapeuta_R", SqlDbType.Decimal)).Value = objTripulacion.Valor_Fisioterapeuta_R
                comando.Parameters.Add(New SqlParameter("@Recargo_Nocturno", SqlDbType.Decimal)).Value = objTripulacion.Recargo_Nocturno
                comando.Parameters.Add(New SqlParameter("@Viceversa", SqlDbType.Bit)).Value = objTripulacion.viceversa
                comando.Parameters.Add(New SqlParameter("@id_tercero_responsable", SqlDbType.Int)).Value = objTripulacion.id_tercero_responsable
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objTripulacion.Usuario
                objTripulacion.Codigo_Tarifa_Tripulacion = CType(comando.ExecuteNonQuery, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objTripulacion
    End Function
End Class
