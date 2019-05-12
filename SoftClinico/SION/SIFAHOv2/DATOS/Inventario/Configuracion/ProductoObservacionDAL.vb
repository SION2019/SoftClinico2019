Imports System.Data.SqlClient
Public Class ProductoObservacionDAL

    Public Shared Sub GuardarObservacion(objObservaciones As Observacion)

        Try
            If String.IsNullOrEmpty(objObservaciones.codigo) Then
                Using Consulta As New SqlCommand("PROC_OBSERVACIONES_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@observacion", SqlDbType.NVarChar))
                    Consulta.Parameters("@observacion").Value = objObservaciones.descripcion
                    Consulta.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar))
                    Consulta.Parameters("@usuario").Value = objObservaciones.usuario

                    objObservaciones.codigo = CType(Consulta.ExecuteScalar, String)
                End Using
            Else
                Using Consulta As New SqlCommand("PROC_OBSERVACIONES_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar))
                    Consulta.Parameters("@codigo").Value = objObservaciones.codigo
                    Consulta.Parameters.Add(New SqlParameter("@observacion", SqlDbType.NVarChar))
                    Consulta.Parameters("@observacion").Value = objObservaciones.descripcion
                    Consulta.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar))
                    Consulta.Parameters("@usuario").Value = objObservaciones.usuario

                    Consulta.ExecuteNonQuery()
                End Using
            End If

        Catch ex As Exception
            general.manejoErrores(ex) 
            Throw ex
        End Try
    End Sub

End Class
