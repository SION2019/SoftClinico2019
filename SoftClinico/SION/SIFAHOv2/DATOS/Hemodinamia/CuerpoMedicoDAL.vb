Public Class CuerpoMedicoDAL
    Public Shared Function guardarTarifaMedica(objCuerpoMedico As CuerpoMedico)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = objCuerpoMedico.sqlGuardarTarifaMedica
                    comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objCuerpoMedico.Codigo
                    comando.Parameters.Add(New SqlParameter("@Id_Empleado", SqlDbType.Int)).Value = objCuerpoMedico.idEmpleado
                    comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objCuerpoMedico.usuario
                    comando.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = objCuerpoMedico.Activo
                    comando.Parameters.Add(New SqlParameter("@TablaLPre", SqlDbType.Structured)).Value = objCuerpoMedico.dtCuerpoMedico
                    objCuerpoMedico.Codigo = CType(comando.ExecuteScalar, String)
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objCuerpoMedico
    End Function

    Public Shared Function guardarCuerpoMedico(objCuerpoMedico As CuerpoMedico)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = objCuerpoMedico.sqlGuardarCuerpoMedico
                    'comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objCuerpoMedico.CodigoCM
                    'comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objCuerpoMedico.usuario
                    comando.Parameters.Add(New SqlParameter("@TABLA_PARTICIPANTES", SqlDbType.Structured)).Value = objCuerpoMedico.dtParticipantes
                    objCuerpoMedico.Codigo = CType(comando.ExecuteScalar, String)
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objCuerpoMedico
    End Function
End Class
