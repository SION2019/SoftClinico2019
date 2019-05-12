Imports System.Data.SqlClient
Public Class CotizacionDAL
    Sub definirTipoDePersistenciaDeDatos(ByRef obj As Cotizacion, ByVal usuario As Integer)
        If obj.codigoCotizacionPunto = "" Then
            guardar(obj, usuario)
        Else
            actualizar(obj, usuario)
        End If
    End Sub
    Public Sub guardar(ByRef obj As Cotizacion,
                       ByVal usuario As Integer)

        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_COTIZACION_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCliente", SqlDbType.Int)).Value = obj.codigoCliente
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    consulta.Parameters.Add(New SqlParameter("@pFecha", SqlDbType.DateTime)).Value = obj.fecha
                    consulta.Parameters.Add(New SqlParameter("@pObservacion", SqlDbType.NVarChar)).Value = obj.observacion
                    consulta.Parameters.Add(New SqlParameter("@estado", SqlDbType.Bit)).Value = obj.estado
                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    consulta.Parameters.Add(New SqlParameter("@pTabla", SqlDbType.Structured)).Value = obj.tblProductos
                    obj.codigoCotizacion = CType(consulta.ExecuteScalar, String)

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_COTIZACION_ACTUALIZAR_CONSECUTIVO_PUNTO]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    consulta.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_COTIZACION
                    consulta.Parameters.Add(New SqlParameter("@CodigoOrdenInterno", SqlDbType.Int)).Value = obj.codigoCotizacion
                    obj.codigoCotizacionPunto = CType(consulta.ExecuteScalar, String)
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub actualizar(ByRef obj As Cotizacion,
                          ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_COTIZACION_ACTUALIZAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = obj.codigoCotizacion
                    consulta.Parameters.Add(New SqlParameter("@pFecha", SqlDbType.DateTime)).Value = obj.fecha
                    consulta.Parameters.Add(New SqlParameter("@pObservacion", SqlDbType.NVarChar)).Value = obj.observacion
                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    consulta.Parameters.Add(New SqlParameter("@pTabla", SqlDbType.Structured)).Value = obj.tblProductos
                    consulta.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarAnular(ByVal codigo As Integer) As Boolean
        Using cmd As New SqlCommand(Consultas.BUSQUEDA_VERIFICAR_COTIZACION & " " & codigo, FormPrincipal.cnxion)
            Using lector = cmd.ExecuteReader
                lector.Read()
                If CBool(lector.Item("Estado")) = Constantes.PENDIENTE Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function
    Public Function verificarAnularIndividual(ByVal codigo As Integer) As Boolean
        Using cmd As New SqlCommand(Consultas.BUSQUEDA_VERIFICAR_COTIZACION_INDIVIDUAL & " " & codigo, FormPrincipal.cnxion)
            Using lector = cmd.ExecuteReader
                lector.Read()
                If lector.Item("Cantidad") = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function
End Class
