Public Class ConfigPromedioDiaEstanciaDALvb
    Public Shared Function guardarConfigDiaFactura(objDiaFactura As FacturacionDiaria)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objDiaFactura.sqlGuardarConfigDiaFactura
                comando.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = objDiaFactura.usuario
                comando.Parameters.Add(New SqlParameter("@TablaCDF", SqlDbType.Structured)).Value = objDiaFactura.dtConfigDiaFactura
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objDiaFactura
    End Function
End Class
