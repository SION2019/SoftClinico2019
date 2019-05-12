Imports System.Data.SqlClient
Public Class PermisoDAL

    Sub guardar(ByRef pPermiso As Permiso)
        Try
            Using dbCommand As New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    dbCommand.Connection = FormPrincipal.cnxion
                    dbCommand.Transaction = trnsccion
                    dbCommand.CommandType = CommandType.StoredProcedure
                    dbCommand.CommandText = "PROC_PERMISO_CREAR"

                    'Parametros
                    dbCommand.Parameters.Add(New SqlParameter("@pHorario", SqlDbType.NVarChar)).Value = pPermiso.horario
                    dbCommand.Parameters.Add(New SqlParameter("@pPunto", SqlDbType.Int)).Value = SesionActual.codigoEP
                    dbCommand.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                    dbCommand.Parameters.Add(New SqlParameter("@pEmpresa", SqlDbType.NVarChar)).Value = SesionActual.idEmpresa
                    dbCommand.Parameters.Add(New SqlParameter("@tabla_permiso", SqlDbType.Structured)).Value = pPermiso._indt
                    Using da As New SqlDataAdapter(dbCommand)

                        pPermiso._outdt = New DataTable

                        da.Fill(pPermiso._outdt)

                        trnsccion.Commit()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
