Imports System.Data.SqlClient
Public Class DespachoPemDAL
    Public Sub guardarDespachoPem(ByRef objDespacho As DespachoPEM,
                                   ByVal usuario As Integer,
                                   ByVal punto As Integer)

        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DESPACHO_PEM_CREAR]"
                    comando.Parameters.Add(New SqlParameter("@pPunto", SqlDbType.Int)).Value = punto
                    comando.Parameters.Add(New SqlParameter("@pMovimiento", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_DESPACHO_PEM
                    comando.Parameters.Add(New SqlParameter("@pCodigoPemInicio", SqlDbType.Int)).Value = objDespacho.codigoPEMInicio
                    comando.Parameters.Add(New SqlParameter("@pCodigoPemFin", SqlDbType.Int)).Value = objDespacho.codigoPemFin
                    comando.Parameters.Add(New SqlParameter("@pCodigoAreaServicio", SqlDbType.Int)).Value = objDespacho.codigoAreaServicio
                    comando.Parameters.Add(New SqlParameter("@pFechaDepacho", SqlDbType.DateTime)).Value = objDespacho.fechaDespachoPEM
                    comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    objDespacho.codigoDespachoPEM = CStr(comando.ExecuteScalar)

                    Dim nombreTabla As String
                    Dim filas As DataRowCollection = objDespacho.tablainsumos.Rows
                    For indiceFilaProductos = 0 To filas.Count - 1
                        nombreTabla = objDespacho.nombrarTabla(filas(indiceFilaProductos).Item("Codigo_Interno"), indiceFilaProductos, Constantes.GRILLA_INSUMOS)
                        If objDespacho.verificarExistenciaTabla(nombreTabla) Then
                            comando.Parameters.Clear()
                            comando.CommandText = "[PROC_DESPACHO_PEM_CREAR_DETELLE_INSUMOS]"
                            comando.Parameters.Add(New SqlParameter("@pCodigoDespacho", SqlDbType.Int)).Value = objDespacho.codigoDespachoPEM
                            comando.Parameters.Add(New SqlParameter("@pTablaInsumos", SqlDbType.Structured)).Value = objDespacho.tblLotes.Tables(nombreTabla)
                            comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                            comando.ExecuteNonQuery()
                        End If
                    Next
                    filas.Clear()
                    filas = objDespacho.tablaMedicamentos.Rows
                    For indiceFilaProducto = 0 To filas.Count - 1
                        nombreTabla = objDespacho.nombrarTabla(filas(indiceFilaProducto).Item("Codigo_Interno"), indiceFilaProducto, Constantes.GRILLA_MEDICAMENTOS)
                        If objDespacho.verificarExistenciaTabla(nombreTabla) Then
                            comando.Parameters.Clear()
                            comando.CommandText = "[PROC_DESPACHO_PEM_CREAR_DETELLE_MEDICAMENTOS]"
                            comando.Parameters.Add(New SqlParameter("@pCodigoDespacho", SqlDbType.Int)).Value = objDespacho.codigoDespachoPEM
                            comando.Parameters.Add(New SqlParameter("@pTablaMedicamentos", SqlDbType.Structured)).Value = objDespacho.tblLotes.Tables(nombreTabla)
                            comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                            comando.ExecuteNonQuery()
                        End If
                    Next

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DESPACHO_PEM_CREAR_DETELLE_INSUMOS_DETALLADO]"
                    comando.Parameters.Add(New SqlParameter("@pCodigoDespacho", SqlDbType.Int)).Value = objDespacho.codigoDespachoPEM
                    comando.Parameters.Add(New SqlParameter("@pTablaInsumos", SqlDbType.Structured)).Value = objDespacho.tablaListadoDetalladoPEM
                    comando.ExecuteNonQuery()


                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DESPACHO_PEM_CREAR_DETELLE_MEDICAMENTOS_DETALLADO]"
                    comando.Parameters.Add(New SqlParameter("@pCodigoDespacho", SqlDbType.Int)).Value = objDespacho.codigoDespachoPEM
                    comando.Parameters.Add(New SqlParameter("@pTablaMedicamentos", SqlDbType.Structured)).Value = objDespacho.tablaListadoDetalladoPEM
                    comando.ExecuteNonQuery()

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DESPACHO_PEM_ACTUALIZAR_ESTADOS_PEM]"
                    comando.Parameters.Add(New SqlParameter("@pCodigoDespacho", SqlDbType.Int)).Value = objDespacho.codigoDespachoPEM
                    comando.ExecuteNonQuery()

                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub anularDespachoPem(ByRef objDespacho As DespachoPEM,
                          ByVal usuario As Integer)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_DESPACHO_PEM_ANULAR]"
                    comando.Parameters.Add(New SqlParameter("@pCodigoDespacho", SqlDbType.Int)).Value = objDespacho.codigoDespachoPEM
                    comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
