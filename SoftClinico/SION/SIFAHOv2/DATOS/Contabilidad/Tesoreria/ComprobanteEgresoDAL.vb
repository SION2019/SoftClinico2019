Imports System.Data.SqlClient
Public Class ComprobanteEgresoDAL

    Public Shared Sub guardarComprobante(objComprobante As PagosDirecto)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "PROC_COMPROBANTE_EGRESO_CREAR"
                comando.Parameters.Add(New SqlParameter("@comprobante", SqlDbType.NVarChar)).Value = objComprobante.comprobante
                comando.Parameters.Add(New SqlParameter("@Id_empresa", SqlDbType.Int)).Value = objComprobante.idempresa
                comando.Parameters.Add(New SqlParameter("@Id_tercero", SqlDbType.Int)).Value = objComprobante.idtercero
                comando.Parameters.Add(New SqlParameter("@No_Entrada", SqlDbType.NVarChar)).Value = objComprobante.entrada
                comando.Parameters.Add(New SqlParameter("@Codigo_Documento", SqlDbType.Int)).Value = objComprobante.documento
                comando.Parameters.Add(New SqlParameter("@Fecha_recibo", SqlDbType.Date)).Value = objComprobante.fecharec
                comando.Parameters.Add(New SqlParameter("@Fecha_pago", SqlDbType.Date)).Value = objComprobante.fecha
                comando.Parameters.Add(New SqlParameter("@detalle_mov", SqlDbType.NVarChar)).Value = objComprobante.movimiento
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objComprobante.usuario
                comando.Parameters.Add(New SqlParameter("@DETALLE", SqlDbType.Structured)).Value = objComprobante.dtComprobante
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
