Imports System.Data.Sql
Public Class ProgramacionOrdenComprasDAL
    Public Sub guardarProgramacionOrdenCompra(ByRef objProgramacionOrdenCompra As ProgramacionOrdenCompras,
                                              ByVal usuario As Integer,
                                              ByVal punto As Integer)
        Dim nombreTabla As String = ""
        Dim codigoOdenCompra As Integer
        Try
            Using sentencia = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PROGRAMACION_ORDEN_COMPRA_GUARDAR]"
                    sentencia.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.Int)).Value = punto
                    sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@pFechaProgramacion", SqlDbType.DateTime)).Value = objProgramacionOrdenCompra.fechaProgramacion
                    objProgramacionOrdenCompra.codigoProgramacion = CType(sentencia.ExecuteScalar, String)

                    For indiceProveedor = 0 To objProgramacionOrdenCompra.tblProveedores.Rows.Count - 1
                        nombreTabla = objProgramacionOrdenCompra.nombrarTabla(objProgramacionOrdenCompra.tblProveedores.Rows(indiceProveedor).Item("Id"))
                        If objProgramacionOrdenCompra.verificarExistenciaTabla(nombreTabla) Then

                            sentencia.Parameters.Clear()
                            sentencia.CommandText = "[PROC_PROGRAMACION_ORDEN_COMPRA_GUARDAR_D]"
                            sentencia.Parameters.Add(New SqlParameter("@vCodigoProgramacion", SqlDbType.Int)).Value = objProgramacionOrdenCompra.codigoProgramacion
                            sentencia.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.Int)).Value = punto
                            sentencia.Parameters.Add(New SqlParameter("@Id_proveedor", SqlDbType.Int)).Value = objProgramacionOrdenCompra.tblProveedores.Rows(indiceProveedor).Item("Id")
                            sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objProgramacionOrdenCompra.tblLotes.Tables(nombreTabla)
                            sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                            codigoOdenCompra = CType(sentencia.ExecuteScalar, String)

                            sentencia.Parameters.Clear()
                            sentencia.CommandText = "[PROC_ORDEN_COMPRA_ACTUALIZAR_CONSECUTIVO_PUNTO]"
                            sentencia.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = punto
                            sentencia.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_ORDEN_COMPRA
                            sentencia.Parameters.Add(New SqlParameter("@CodigoOrdenInterno", SqlDbType.Int)).Value = codigoOdenCompra
                            sentencia.ExecuteNonQuery()

                        End If
                    Next


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
    Public Function verificarExistenciaProgramacionMesActual() As Boolean
        Dim res As Boolean = False
        Try
            Using sentencia = New SqlCommand()
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure

                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PROGRAMACION_ORDEN_VERIFACAR_EXISTENCIA_MES_ACTUAL]"
                sentencia.Parameters.Add(New SqlParameter("@pCodigoEP", SqlDbType.Int)).Value = SesionActual.codigoEP
                res = CType(sentencia.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return res
    End Function
    Public Function VerificarExistenciaOrdenesRescepcionadas() As Boolean
        Dim res As Boolean = False
        Try
            Using sentencia = New SqlCommand()
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure

                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PROGRAMACION_ORDEN_VERIFACAR_ORDENES_RECEPCIONADAS]"
                res = CType(sentencia.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return res
    End Function

    Public Sub anularProgramacionOrdenCompra(ByRef objProgramacionOrden As ProgramacionOrdenCompras,
                                             ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                consulta.Connection = FormPrincipal.cnxion
                consulta.CommandType = CommandType.StoredProcedure
                consulta.Parameters.Clear()

                consulta.CommandText = "[PROC_PROGRAMACION_ORDEN_ANULAR]"
                consulta.Parameters.Add(New SqlParameter("@pCodigoProgramacion", SqlDbType.Int)).Value = objProgramacionOrden.codigoProgramacion
                consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.NVarChar)).Value = usuario
                consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
