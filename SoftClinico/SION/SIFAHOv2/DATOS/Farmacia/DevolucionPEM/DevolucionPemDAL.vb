Imports System.Data.SqlClient
Public Class DevolucionPemDAL
    Public Sub guardarDevolucionPem(ByRef objDevolucion As DevolucionPem,
                                    ByVal usuario As Integer,
                                    ByVal punto As Integer)

        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DEVOLUCION_PEM_CREAR]"
                    comando.Parameters.Add(New SqlParameter("@pCodigo_Pem", SqlDbType.Int)).Value = objDevolucion.codigoPem
                    comando.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = punto
                    comando.Parameters.Add(New SqlParameter("@pCodigoTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_DEVOLUCION_PEM
                    comando.Parameters.Add(New SqlParameter("@pFechaDevolcion", SqlDbType.DateTime)).Value = objDevolucion.fechaDevolucion
                    comando.Parameters.Add(New SqlParameter("@pObservacion", SqlDbType.NVarChar)).Value = objDevolucion.observacion
                    comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    objDevolucion.codigoDevolucion = CStr(comando.ExecuteScalar)

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DEVOLUCION_PEM_CREAR_DETALLES]"
                    comando.Parameters.Add(New SqlParameter("@pCodigoDevolucion", SqlDbType.Int)).Value = objDevolucion.codigoDevolucion
                    comando.Parameters.Add(New SqlParameter("@pTablaMed", SqlDbType.Structured)).Value = objDevolucion.tablaMedicamentos
                    comando.Parameters.Add(New SqlParameter("@pTablaIns", SqlDbType.Structured)).Value = objDevolucion.tablaInsumos
                    comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AnularDevolucionPem(ByRef objDevolucion As DevolucionPem,
                                    ByVal usuario As Integer)

        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DEVOLUCION_PEM_ANULAR]"
                    comando.Parameters.Add(New SqlParameter("@pCodigo_Devolucion", SqlDbType.Int)).Value = objDevolucion.codigoDevolucion
                    comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarAnular(ByRef objDevolucion As DevolucionPem) As Boolean
        Dim valor As Boolean = False
        Dim params As New List(Of String)
        params.Add(objDevolucion.codigoDevolucion)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.DEVOLUCION_VERIFICAR_ANULAR, params)
        If Not IsNothing(fila) Then
            If fila.Item(0) = 0 Then
                valor = True
            End If
        End If
        Return valor
    End Function
    Public Function verificarBodegaDestino(ByRef objDevolucion As DevolucionPem, ByVal filaActula As Integer) As Boolean
        Dim valor As Boolean = False
        Dim params As New List(Of String)
        params.Add(objDevolucion.codigoPem)
        params.Add(objDevolucion.tablaMedicamentos.Rows(filaActula).Item("Codigo"))
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.DEVOLUCION_VERIFICAR_DESTINO_BODEGA, params)
        If Not IsNothing(fila) Then
            If fila.Item(0) = True Then
                valor = True
            End If
        End If
        Return valor
    End Function
End Class
