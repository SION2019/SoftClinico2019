Imports System.Data.SqlClient
Public Class InformeCateterismoDAL
    Public Sub guardarCateterismo(ByRef objCateterismo As CateterismoCardiaco)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.Parameters.Clear()
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = "PROC_CATETERISMO_CARDIACO_CREAR"
                    comando.Parameters.Add(New SqlParameter("@CodigoCateterismo", SqlDbType.NVarChar)).Value = objCateterismo.codigoCateterismo
                    comando.Parameters.Add(New SqlParameter("@CodigoOrden", SqlDbType.Int)).Value = objCateterismo.codigoOrden
                    comando.Parameters.Add(New SqlParameter("@CodigoProcedimiento", SqlDbType.NVarChar)).Value = objCateterismo.codigoProcedimiento
                    comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objCateterismo.usuarioReal
                    comando.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@IdAnestesiologo", SqlDbType.Int)).Value = objCateterismo.idAnestesiologo
                    comando.Parameters.Add(New SqlParameter("@CodigoPuncion", SqlDbType.Int)).Value = objCateterismo.tipoPuncion
                    comando.Parameters.Add(New SqlParameter("@CodigoEp", SqlDbType.Int)).Value = SesionActual.codigoEP
                    comando.Parameters.Add(New SqlParameter("@nRegistro", SqlDbType.Int)).Value = objCateterismo.registro
                    comando.Parameters.Add(New SqlParameter("@Fecha_Informe", SqlDbType.DateTime)).Value = objCateterismo.fechaCateterismo
                    comando.Parameters.Add(New SqlParameter("@Cateterismo", SqlDbType.Structured)).Value = objCateterismo.tblResultadosInforme
                    objCateterismo.codigoCateterismo = CType(comando.ExecuteScalar, String)
                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizarCateterismo(ByRef objCateterismo As CateterismoCardiaco)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.Parameters.Clear()
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = "PROC_CATETERISMO_CARDIACO_ACTUALIZAR"
                    comando.Parameters.Add(New SqlParameter("@codigoCateterismo", SqlDbType.NVarChar)).Value = objCateterismo.codigoCateterismo
                    comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objCateterismo.usuarioReal
                    comando.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@IdAnestesiologo", SqlDbType.Int)).Value = objCateterismo.idAnestesiologo
                    comando.Parameters.Add(New SqlParameter("@CodigoPuncion", SqlDbType.Int)).Value = objCateterismo.tipoPuncion
                    comando.Parameters.Add(New SqlParameter("@Codigo_Ep", SqlDbType.Int)).Value = SesionActual.codigoEP
                    comando.Parameters.Add(New SqlParameter("@Fecha_Informe", SqlDbType.DateTime)).Value = objCateterismo.fechaCateterismo
                    comando.Parameters.Add(New SqlParameter("@Cateterismo", SqlDbType.Structured)).Value = objCateterismo.tblResultadosInforme
                    comando.ExecuteNonQuery()
                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '-------------------
    Public Sub guardarCateterismoAM(ByRef objCateterismo As CateterismoCardiacoR)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.Parameters.Clear()
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = "PROC_CATETERISMO_CARDIACO_CREAR_R"
                    comando.Parameters.Add(New SqlParameter("@CodigoCateterismo", SqlDbType.NVarChar)).Value = objCateterismo.codigoCateterismo
                    comando.Parameters.Add(New SqlParameter("@CodigoOrden", SqlDbType.Int)).Value = objCateterismo.codigoOrden
                    comando.Parameters.Add(New SqlParameter("@CodigoProcedimiento", SqlDbType.NVarChar)).Value = objCateterismo.codigoProcedimiento
                    comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objCateterismo.usuarioReal
                    comando.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@IdAnestesiologo", SqlDbType.Int)).Value = objCateterismo.idAnestesiologo
                    comando.Parameters.Add(New SqlParameter("@CodigoPuncion", SqlDbType.Int)).Value = objCateterismo.tipoPuncion
                    comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    comando.Parameters.Add(New SqlParameter("@nRegistro", SqlDbType.Int)).Value = objCateterismo.registro
                    comando.Parameters.Add(New SqlParameter("@Fecha_Informe", SqlDbType.DateTime)).Value = objCateterismo.fechaCateterismo
                    comando.Parameters.Add(New SqlParameter("@Cateterismo", SqlDbType.Structured)).Value = objCateterismo.tblResultadosInforme
                    objCateterismo.codigoCateterismo = CType(comando.ExecuteScalar, String)
                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizarCateterismoAM(ByRef objCateterismo As CateterismoCardiacoR)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.Parameters.Clear()
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = "PROC_CATETERISMO_CARDIACO_ACTUALIZAR_R"
                    comando.Parameters.Add(New SqlParameter("@CodigoCateterismo", SqlDbType.NVarChar)).Value = objCateterismo.codigoCateterismo
                    comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objCateterismo.usuarioReal
                    comando.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@IdAnestesiologo", SqlDbType.Int)).Value = objCateterismo.idAnestesiologo
                    comando.Parameters.Add(New SqlParameter("@CodigoPuncion", SqlDbType.Int)).Value = objCateterismo.tipoPuncion
                    comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    comando.Parameters.Add(New SqlParameter("@EDITADO", SqlDbType.Bit)).Value = 1
                    comando.Parameters.Add(New SqlParameter("@Fecha_Informe", SqlDbType.DateTime)).Value = objCateterismo.fechaCateterismo
                    comando.Parameters.Add(New SqlParameter("@Cateterismo", SqlDbType.Structured)).Value = objCateterismo.tblResultadosInforme
                    comando.ExecuteNonQuery()
                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarCateterismoAF(ByRef objCateterismo As CateterismoCardiacoRR)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.Parameters.Clear()
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = "PROC_CATETERISMO_CARDIACO_CREAR_RR"
                    comando.Parameters.Add(New SqlParameter("@CodigoCateterismo", SqlDbType.NVarChar)).Value = objCateterismo.codigoCateterismo
                    comando.Parameters.Add(New SqlParameter("@CodigoOrden", SqlDbType.Int)).Value = objCateterismo.codigoOrden
                    comando.Parameters.Add(New SqlParameter("@CodigoProcedimiento", SqlDbType.NVarChar)).Value = objCateterismo.codigoProcedimiento
                    comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objCateterismo.usuarioReal
                    comando.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@IdAnestesiologo", SqlDbType.Int)).Value = objCateterismo.idAnestesiologo
                    comando.Parameters.Add(New SqlParameter("@CodigoPuncion", SqlDbType.Int)).Value = objCateterismo.tipoPuncion
                    comando.Parameters.Add(New SqlParameter("@nRegistro", SqlDbType.Int)).Value = objCateterismo.registro
                    comando.Parameters.Add(New SqlParameter("@Fecha_Informe", SqlDbType.DateTime)).Value = objCateterismo.fechaCateterismo
                    comando.Parameters.Add(New SqlParameter("@Cateterismo", SqlDbType.Structured)).Value = objCateterismo.tblResultadosInforme
                    objCateterismo.codigoCateterismo = CType(comando.ExecuteScalar, String)

                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizarCateterismoAF(ByRef objCateterismo As CateterismoCardiacoRR)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.Parameters.Clear()
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = "PROC_CATETERISMO_CARDIACO_ACTUALIZAR_RR"
                    comando.Parameters.Add(New SqlParameter("@CodigoCateterismo", SqlDbType.NVarChar)).Value = objCateterismo.codigoCateterismo
                    comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objCateterismo.usuarioReal
                    comando.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@IdAnestesiologo", SqlDbType.Int)).Value = objCateterismo.idAnestesiologo
                    comando.Parameters.Add(New SqlParameter("@CodigoPuncion", SqlDbType.Int)).Value = objCateterismo.tipoPuncion
                    comando.Parameters.Add(New SqlParameter("@EDITADO", SqlDbType.Bit)).Value = 1
                    comando.Parameters.Add(New SqlParameter("@Fecha_Informe", SqlDbType.DateTime)).Value = objCateterismo.fechaCateterismo
                    comando.Parameters.Add(New SqlParameter("@Cateterismo", SqlDbType.Structured)).Value = objCateterismo.tblResultadosInforme
                    comando.ExecuteNonQuery()

                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

