Imports System.Data.SqlClient

Public Class CuentaPucDAL

    Public Shared Sub crearCuentaPUC(objCuentaPUC As CuentaPUC,
                                   pUsuario As Integer)

        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_PUC_DETALLE_GUARDAR"

                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@codigo_puc", SqlDbType.Int))
                dbCommand.Parameters.Add(New SqlParameter("@codigo_cuenta", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@tipo", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@nivel", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@naturaleza", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@clasificacion", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@padre", SqlDbType.NVarChar))
                dbCommand.Parameters.Add(New SqlParameter("@visible", SqlDbType.Bit))
                dbCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Bit))

                'Valores
                dbCommand.Parameters("@codigo_puc").Value = objCuentaPUC.getCodigoPUC
                dbCommand.Parameters("@codigo_cuenta").Value = objCuentaPUC.getCodigo
                dbCommand.Parameters("@nombre").Value = objCuentaPUC.getDescripcion
                dbCommand.Parameters("@tipo").Value = objCuentaPUC.getTipo
                dbCommand.Parameters("@nivel").Value = objCuentaPUC.getNivel
                dbCommand.Parameters("@naturaleza").Value = objCuentaPUC.getNaturaleza
                dbCommand.Parameters("@clasificacion").Value = objCuentaPUC.getClasificacion
                dbCommand.Parameters("@padre").Value = objCuentaPUC.getCuentaPadre
                dbCommand.Parameters("@visible").Value = objCuentaPUC.getVisible
                dbCommand.Parameters("@usuario").Value = pUsuario

                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub cargarCuentasPadre(ByVal pCodigo As String,
                                         ByRef dsCuentas As DataSet)

        Try
            Using dbCommand As New SqlCommand("PROC_PUC_DETALLE_CUENTAS_CARGAR " & pCodigo, FormPrincipal.cnxion)
                Using daCuentaPadre As New SqlDataAdapter(dbCommand)
                    daCuentaPadre.Fill(dsCuentas, "Padre")
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub cargarCuentasHijas(ByVal pCodigo As String,
                                  ByRef dsCuentas As DataSet)

        Try
            Using dbCommand As New SqlCommand("PROC_PUC_DETALLE_SUBCUENTAS_CARGAR " & pCodigo, FormPrincipal.cnxion)
                Using daCuentaHija As New SqlDataAdapter(dbCommand)
                    daCuentaHija.Fill(dsCuentas, "Hijas")
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
