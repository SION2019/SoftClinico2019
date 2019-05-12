Imports System.Data.SqlClient
Public Class ProductoDAL
    Public Sub guardar(ByVal objPrducto As Producto, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "PROC_PRODUCTO_CREAR"
                    consulta.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objPrducto.nombre
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Marca", SqlDbType.NVarChar)).Value = objPrducto.codigoMarca
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Interno", SqlDbType.NVarChar)).Value = objPrducto.codigoInterno
                    consulta.Parameters.Add(New SqlParameter("@Codigo_CUM", SqlDbType.NVarChar)).Value = objPrducto.codigoCum
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Barra", SqlDbType.NVarChar)).Value = objPrducto.codigoBarras
                    consulta.Parameters.Add(New SqlParameter("@Iva", SqlDbType.Decimal)).Value = objPrducto.iva
                    consulta.Parameters.Add(New SqlParameter("@Registro_Sanitario", SqlDbType.NVarChar)).Value = objPrducto.regSanitario
                    consulta.Parameters.Add(New SqlParameter("@presentacion", SqlDbType.NVarChar)).Value = objPrducto.Presentacion
                    consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar)).Value = usuario
                    objPrducto.codigo = CType(consulta.ExecuteScalar, String)

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_BODEGA_CREAR_ASIGNACION]"
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_PRODUCTO", SqlDbType.NVarChar)).Value = objPrducto.codigo
                    consulta.Parameters.Add(New SqlParameter("@TBL", SqlDbType.Structured)).Value = objPrducto.tblBodegas
                    consulta.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub actualizar(ByVal objPrducto As Producto, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "PROC_PRODUCTO_ACTUALIZAR"
                    consulta.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objPrducto.codigo
                    consulta.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objPrducto.nombre
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Marca", SqlDbType.NVarChar)).Value = objPrducto.codigoMarca
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Interno", SqlDbType.NVarChar)).Value = objPrducto.codigoInterno
                    consulta.Parameters.Add(New SqlParameter("@Codigo_CUM", SqlDbType.NVarChar)).Value = objPrducto.codigoCum
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Barra", SqlDbType.NVarChar)).Value = objPrducto.codigoBarras
                    consulta.Parameters.Add(New SqlParameter("@Iva", SqlDbType.Decimal)).Value = objPrducto.iva
                    consulta.Parameters.Add(New SqlParameter("@Registro_Sanitario", SqlDbType.NVarChar)).Value = objPrducto.regSanitario
                    consulta.Parameters.Add(New SqlParameter("@presentacion", SqlDbType.NVarChar)).Value = objPrducto.Presentacion
                    consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar)).Value = usuario
                    consulta.ExecuteNonQuery()


                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_BODEGA_CREAR_ASIGNACION]"
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_PRODUCTO", SqlDbType.NVarChar)).Value = objPrducto.codigo
                    consulta.Parameters.Add(New SqlParameter("@TBL", SqlDbType.Structured)).Value = objPrducto.tblBodegas
                    consulta.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Function verificar_asignacion(ByVal codigo_producto As String, ByVal codigo_bodega As Integer) As Boolean
        Using consultor2 As New SqlCommand("[PROC_PRODUCTOS_VERIFICAR_ASIGNACION] @CODIGO_PRODUCTO='" & codigo_producto & "',@CODIGO_BODEGA='" & codigo_bodega & "'", FormPrincipal.cnxion)
            Using lector = consultor2.ExecuteReader
                If lector.HasRows = True Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using

    End Function
    Public Function anular_Producto(ByVal obj As Producto, ByVal usuario As Integer) As Boolean
        Try
            Using Consulta As New SqlCommand("[PROC_PRODUCTO_ANULAR]")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = obj.codigo
                Consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int))
                Consulta.Parameters("@Usuario").Value = usuario
                Consulta.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Public Function verificar_existencia_producto(ByVal Codigo_producto As String, ByVal Codigo_Bodega As String) As Boolean
        Dim stock As Integer = 0
        Using consultor As New SqlCommand("[PROC_PRODUCTOS_VERIFICAR_EXISTENCIA_BODEGA] '" & Codigo_producto & "','" & Codigo_Bodega & "'", FormPrincipal.cnxion)
            If Not IsDBNull(consultor.ExecuteScalar) Then
                stock = consultor.ExecuteScalar
            End If

        End Using

        If stock > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
