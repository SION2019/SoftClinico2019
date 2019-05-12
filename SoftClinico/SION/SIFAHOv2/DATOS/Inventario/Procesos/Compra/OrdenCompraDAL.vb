Imports System.Data.SqlClient
Public Class OrdenCompraDAL
    Public Sub guardarCompra(ByRef objOrdenCompra As Compra,
                             ByVal usuario As Integer,
                             ByVal punto As Integer)

        Try

            Using sentencia = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_ORDEN_COMPRA_CREAR]"
                    sentencia.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.Int)).Value = punto
                    sentencia.Parameters.Add(New SqlParameter("@Id_proveedor", SqlDbType.Int)).Value = objOrdenCompra.codigoProveedor
                    sentencia.Parameters.Add(New SqlParameter("@Fecha_Orden", SqlDbType.DateTime)).Value = objOrdenCompra.fechaCompra
                    sentencia.Parameters.Add(New SqlParameter("@Fecha_Entrega", SqlDbType.DateTime)).Value = objOrdenCompra.fechaEntrega
                    sentencia.Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.NVarChar)).Value = objOrdenCompra.observacionCompra
                    sentencia.Parameters.Add(New SqlParameter("@estado", SqlDbType.NVarChar)).Value = Constantes.PENDIENTE
                    sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objOrdenCompra.tablaProductos
                    sentencia.Parameters.Add(New SqlParameter("@lista", SqlDbType.Bit)).Value = objOrdenCompra.actualizarLista
                    sentencia.Parameters.Add(New SqlParameter("@CuentaCobro", SqlDbType.Bit)).Value = objOrdenCompra.cuentaCobro
                    objOrdenCompra.codigoCompra = CType(sentencia.ExecuteScalar, String)

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_ORDEN_COMPRA_ACTUALIZAR_CONSECUTIVO_PUNTO]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = punto
                    sentencia.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_ORDEN_COMPRA
                    sentencia.Parameters.Add(New SqlParameter("@CodigoOrdenInterno", SqlDbType.Int)).Value = objOrdenCompra.codigoCompra
                    objOrdenCompra.codigoCompraPunto = CType(sentencia.ExecuteScalar, String)


                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef objOrdenCompra As Compra,
                          ByVal usuario As Integer)

        Try

            Using sentencia = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_ORDEN_COMPRA_ACTUALIZAR]"
                    sentencia.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objOrdenCompra.codigoCompra
                    sentencia.Parameters.Add(New SqlParameter("@Proveedor", SqlDbType.Int)).Value = objOrdenCompra.codigoProveedor
                    sentencia.Parameters.Add(New SqlParameter("@Fecha_Orden", SqlDbType.DateTime)).Value = objOrdenCompra.fechaCompra
                    sentencia.Parameters.Add(New SqlParameter("@Fecha_Entrega", SqlDbType.DateTime)).Value = objOrdenCompra.fechaEntrega
                    sentencia.Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.NVarChar)).Value = objOrdenCompra.observacionCompra
                    sentencia.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objOrdenCompra.tablaProductos
                    sentencia.Parameters.Add(New SqlParameter("@lista", SqlDbType.Bit)).Value = objOrdenCompra.actualizarLista
                    sentencia.Parameters.Add(New SqlParameter("@cuenta_Cobro", SqlDbType.Bit)).Value = objOrdenCompra.cuentaCobro
                    sentencia.ExecuteNonQuery()

                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub anularCompra(ByRef objOrdenCompra As Compra,
                            ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                consulta.Connection = FormPrincipal.cnxion
                consulta.CommandType = CommandType.StoredProcedure
                consulta.Parameters.Clear()

                consulta.CommandText = "[PROC_ORDEN_COMPRA_ANULAR]"
                consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                consulta.Parameters("@codigo").Value = objOrdenCompra.codigoCompra
                consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                consulta.Parameters("@Usuario").Value = usuario
                consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function isTerminada(ByRef objOrdenCompra As Compra) As Boolean
        Dim valor As Boolean = False
        Using comando As New SqlCommand("PROC_ORDEN_COMPRA_VERIFICACION '" & objOrdenCompra.codigoCompra & "'", FormPrincipal.cnxion)
            Using lector = comando.ExecuteReader
                If lector.HasRows Then
                    lector.Read()
                    If lector.Item("Estado") = Constantes.PENDIENTE Then
                        valor = True
                    Else
                        valor = False
                    End If
                End If
            End Using
        End Using

        Return valor
    End Function
End Class
