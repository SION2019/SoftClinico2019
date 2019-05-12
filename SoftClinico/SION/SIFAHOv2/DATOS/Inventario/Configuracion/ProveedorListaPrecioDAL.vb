Imports System.Data.SqlClient
Public Class ProveedorListaPrecioDAL
    Public Function validarExistencia(objListaPrecio As ListaPrecioProveedorCliente) As Boolean
        Dim params As New List(Of String)
        params.Add(objListaPrecio.tipoLista)
        params.Add(SesionActual.idEmpresa)
        params.Add(objListaPrecio.idTercero)
        Dim fila As DataRow = General.cargarItem(Consultas.LISTA_PRECIO_PRODUCOT_VERIFIVAR_EXISTENCIA, params)
        If Not IsNothing(fila) Then
            objListaPrecio.codigoLista = fila.Item(0)
            objListaPrecio.nombreLista = fila.Item(1)
            Return True
        End If
        Return False
    End Function
    Public Sub guardarLista(ByRef objListaProveedor As ListaPrecioProveedorCliente)
        Try

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_LISTA_PRECIO_PROVEEDOR_CLIENTE_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@pid_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    consulta.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.NVarChar)).Value = objListaProveedor.nombreLista
                    consulta.Parameters.Add(New SqlParameter("@pUsuario_Creacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    consulta.Parameters.Add(New SqlParameter("@pId_cliente_proveedor", SqlDbType.Int)).Value = objListaProveedor.idTercero
                    consulta.Parameters.Add(New SqlParameter("@pTipo_lista", SqlDbType.Int)).Value = objListaProveedor.tipoLista
                    objListaProveedor.codigoLista = CType(consulta.ExecuteScalar, String)


                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_LISTA_PRECIO_PROVEEDOR_CLIENTE_CREAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_lista", SqlDbType.Int)).Value = objListaProveedor.codigoLista
                    consulta.Parameters.Add(New SqlParameter("@pOrdenCompra", SqlDbType.Bit)).Value = False
                    consulta.Parameters.Add(New SqlParameter("@pTabla", SqlDbType.Structured)).Value = objListaProveedor.tblProductos
                    consulta.ExecuteNonQuery()


                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        Throw ex
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
            general.manejoErrores(ex) 
        End Try
    End Sub


    Public Sub ActualizarLista(ByRef objListaProveedor As ListaPrecioProveedorCliente)
        Try

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure


                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_LISTA_PRECIO_PROVEEDOR_CLIENTE_ACTUALIZAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigoLista", SqlDbType.Int)).Value = objListaProveedor.codigoLista
                    consulta.Parameters.Add(New SqlParameter("@pid_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    consulta.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.NVarChar)).Value = objListaProveedor.nombreLista
                    consulta.Parameters.Add(New SqlParameter("@pUsuario_Creacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    consulta.Parameters.Add(New SqlParameter("@pId_cliente_proveedor", SqlDbType.Int)).Value = objListaProveedor.idTercero
                    consulta.Parameters.Add(New SqlParameter("@pTipo_lista", SqlDbType.Int)).Value = objListaProveedor.tipoLista
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_LISTA_PRECIO_PROVEEDOR_CLIENTE_CREAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_lista", SqlDbType.Int)).Value = objListaProveedor.codigoLista
                    consulta.Parameters.Add(New SqlParameter("@pOrdenCompra", SqlDbType.Bit)).Value = False
                    consulta.Parameters.Add(New SqlParameter("@pTabla", SqlDbType.Structured)).Value = objListaProveedor.tblProductos
                    consulta.ExecuteNonQuery()


                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        Throw ex
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
            general.manejoErrores(ex) 
        End Try
    End Sub

End Class

