Imports System.Data.SqlClient
Public Class RecepcionDAL
    Public Sub CargarLotesRecepcion(ByVal codigo As Integer, ByVal Codigo_producto As Integer, ByVal Codigo_bodega As Integer, ByRef tbl As DataTable)
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(Codigo_producto)
        params.Add(Codigo_bodega)
        General.llenarTabla("[PROC_RECEPCION_CARGAR_LOTES]", params, tbl)
    End Sub
    Public Function verificarBodegaIndividual(ByVal codigo As Integer) As String
        Dim resultado As String = ""
        Dim cantidad As Integer = 0

        Using consultor As New SqlCommand("[PROC_RECEPCION_VERICAR_CANTIDAD_BODEGAS_ASIGNADAS] " & SesionActual.codigoEP & "," & codigo, FormPrincipal.cnxion)
            cantidad = consultor.ExecuteScalar
        End Using

        If cantidad = 0 Then
            resultado = Constantes.NO_TIENE
        ElseIf cantidad = 1 Then
            Using consultor_bodega As New SqlCommand("[PROC_RECEPCION_ASIGNAR_BODEGA_POR_DEFECTO] " & SesionActual.codigoEP & "," & codigo, FormPrincipal.cnxion)
                Using lector = consultor_bodega.ExecuteReader
                    If lector.HasRows = True Then
                        lector.Read()
                        resultado = lector.Item("Nombre")
                    Else
                        resultado = Constantes.SELECCIONE_BODEGA
                    End If
                End Using
            End Using
        ElseIf cantidad > 1 Then
            resultado = Constantes.SELECCIONE_BODEGA
        End If
        Return resultado
    End Function
    Public Sub guardarRecepcion(ByRef objRecepcion As RecepcionTecnica,
                                ByVal Punto As Integer,
                                ByVal usuario As Integer)


        Dim codigoLote As String = ""
        Dim nombreTabla As String = ""
        Dim consecutivo As Integer

        Try
            Using consultor_consecutivo As New SqlCommand()
                consultor_consecutivo.Connection = FormPrincipal.cnxion
                consultor_consecutivo.CommandType = CommandType.StoredProcedure
                consultor_consecutivo.Parameters.Clear()
                consultor_consecutivo.CommandText = "[PROC_LOTE_ULTIMO_CONSECUTIVO]"
                consecutivo = consultor_consecutivo.ExecuteScalar
                If consecutivo >= 0 Then
                    consecutivo += 1
                End If
            End Using

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_RECEPCION_TECNICA_CREAR]"

                    consulta.Parameters.Add(New SqlParameter("@Codigo_orden", SqlDbType.Int))
                    consulta.Parameters("@Codigo_orden").Value = objRecepcion.codigoOrden
                    consulta.Parameters.Add(New SqlParameter("@Fecha_Recepcion", SqlDbType.Date))
                    consulta.Parameters("@Fecha_Recepcion").Value = objRecepcion.fechaRecepcion
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Transportadora", SqlDbType.Int))
                    consulta.Parameters("@Codigo_Transportadora").Value = objRecepcion.codigoTransportadora
                    consulta.Parameters.Add(New SqlParameter("@N_Factura", SqlDbType.NVarChar))
                    consulta.Parameters("@N_Factura").Value = objRecepcion.noFactura
                    consulta.Parameters.Add(New SqlParameter("@N_Guia", SqlDbType.NVarChar))
                    consulta.Parameters("@N_Guia").Value = objRecepcion.guia
                    consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    consulta.Parameters("@USUARIO").Value = usuario
                    objRecepcion.codigoRecepcion = CType(consulta.ExecuteScalar, String)



                    For indiceFila = 0 To objRecepcion.tblProductos.Rows.Count - 1
                        '--------  asignamos el codigo de la bodega -------------

                        Dim codigoBodega As String = objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo_Bodega")
                        Dim tblLotes As DataTableCollection = objRecepcion.tblLotes.Tables

                        '---------   Guardar lotes -------------
                        nombreTabla = objRecepcion.nombrarTabla(objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo"), indiceFila) ' Nombre de la tabla en el dataset

                        If objRecepcion.verificarExistenciaTabla(nombreTabla) Then
                            For indiceFilaLotes = 0 To tblLotes(nombreTabla).Rows.Count - 1
                                If tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Cantidad") > 0 Then

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int)).Value = consecutivo
                                    consulta.Parameters.Add(New SqlParameter("@N_LOTE", SqlDbType.NVarChar)).Value = tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Num_lote")
                                    consulta.Parameters.Add(New SqlParameter("@FECHA_VENCE", SqlDbType.Date)).Value = tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Fecha")
                                    consulta.Parameters.Add(New SqlParameter("@STOCK", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@CODIGO_BODEGA", SqlDbType.Int)).Value = codigoBodega
                                    consulta.Parameters.Add(New SqlParameter("@CODIGO_PRODUCTO", SqlDbType.Int)).Value = objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo")
                                    consulta.Parameters.Add(New SqlParameter("@RECEP", SqlDbType.NVarChar)).Value = objRecepcion.codigoRecepcion
                                    consulta.Parameters.Add(New SqlParameter("@RECEP_T", SqlDbType.NVarChar)).Value = ""
                                    consulta.Parameters.Add(New SqlParameter("@CONTEO", SqlDbType.NVarChar)).Value = ""
                                    consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Excepcion")
                                    consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar)).Value = usuario
                                    consulta.ExecuteNonQuery()

                                    '---------   Guardar detalle de la recepcion -------------
                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_RECEPCION_TECNICA_CREAR_DETALLE]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Recepcion", SqlDbType.Int)).Value = objRecepcion.codigoRecepcion
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo")
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = codigoBodega
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = consecutivo
                                    consulta.Parameters.Add(New SqlParameter("@Cant", SqlDbType.Int)).Value = objRecepcion.tblProductos.Rows(indiceFila).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@CantRec", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@CantFalt", SqlDbType.Int)).Value = objRecepcion.tblProductos.Rows(indiceFila).Item("Cantidad_Faltante")
                                    consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                                    consulta.ExecuteNonQuery()

                                    '---------   Guardar el movimiento en  kaxdex -------------
                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = codigoBodega
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = consecutivo
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceFilaLotes).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = 0
                                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                                    consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "R"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.NVarChar))
                                    consulta.Parameters("@Codigo_movimiento").Value = objRecepcion.codigoRecepcion
                                    consulta.ExecuteNonQuery()
                                    consecutivo += 1
                                End If
                            Next
                        End If
                    Next

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_RECEPCION_TECNICA_ACTUALIZAR_CONSECUTIVO_PUNTO]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = Punto
                    consulta.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_RECEPCION
                    consulta.Parameters.Add(New SqlParameter("@CodigoOrdenInterno", SqlDbType.Int)).Value = objRecepcion.codigoRecepcion
                    objRecepcion.codigoRecepcionPunto = CType(consulta.ExecuteScalar, String)

                    trnsccion.Commit()
                    actualizarEstado(objRecepcion, usuario)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub actualizarEstado(ByRef objRecepcionTecnica As RecepcionTecnica, ByVal usuario As Integer)
        Try
            Using actualizador As New SqlCommand()
                actualizador.Connection = FormPrincipal.cnxion
                actualizador.CommandType = CommandType.StoredProcedure
                actualizador.Parameters.Clear()
                actualizador.CommandText = "[PROC_RECEPCION_ACTUALIZAR_ESTADO_ORDEN_COMPRA]"
                actualizador.Parameters.Add(New SqlParameter("@CODIGO_ORDEN", SqlDbType.Int))
                actualizador.Parameters("@CODIGO_ORDEN").Value = objRecepcionTecnica.codigoOrden
                actualizador.Parameters.Add(New SqlParameter("@CODIGO_RECEPCION", SqlDbType.Int))
                actualizador.Parameters("@CODIGO_RECEPCION").Value = objRecepcionTecnica.codigoRecepcion
                actualizador.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Public Function verificacionAnularRecepcion(ByRef objRecepcionTecnica As RecepcionTecnica, ByVal usuario As Integer) As Boolean
        Dim resp As String

        Using consultor As New SqlCommand()
            consultor.Connection = FormPrincipal.cnxion
            consultor.CommandType = CommandType.StoredProcedure
            consultor.Parameters.Clear()
            consultor.CommandText = "[PROC_RECEPCION_VERIFICAR_ANULAR]"
            consultor.Parameters.Add(New SqlParameter("@CODIGO_RECEPCION", SqlDbType.Int))
            consultor.Parameters("@CODIGO_RECEPCION").Value = objRecepcionTecnica.codigoRecepcion
            resp = CType(consultor.ExecuteScalar, String)
        End Using


        If resp = 1 Then '1 si es posible anular
            Return True
        Else
            Return False
        End If
    End Function
    Public Function anular(ByRef objRecepcionTecnica As RecepcionTecnica, ByVal usuario As Integer) As Boolean
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()

                    consulta.CommandText = "[PROC_RECEPCION_ANULAR]"
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    consulta.Parameters("@codigo").Value = objRecepcionTecnica.codigoRecepcion
                    consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                    consulta.Parameters("@Usuario").Value = usuario
                    consulta.ExecuteNonQuery()

                    Try
                        trnsccion.Commit()
                        Return True
                    Catch ex As Exception
                        Return False
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function
End Class
