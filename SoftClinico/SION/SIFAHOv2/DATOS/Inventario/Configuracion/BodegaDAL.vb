Imports System.Data.SqlClient
Public Class Bodegas_C

    Sub guardarBodega(ByRef objBodega As BodegaE, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_BODEGA_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.NVarChar))
                    consulta.Parameters("@Codigo_EP").Value = objBodega.codigPunto
                    consulta.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar))
                    consulta.Parameters("@Descripcion").Value = objBodega.descripcion
                    consulta.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.NVarChar))
                    consulta.Parameters("@Direccion").Value = objBodega.direccion
                    consulta.Parameters.Add(New SqlParameter("@telefono", SqlDbType.NVarChar))
                    consulta.Parameters("@telefono").Value = objBodega.telefono
                    consulta.Parameters.Add(New SqlParameter("@codigo_tipo_bodega", SqlDbType.NVarChar))
                    consulta.Parameters("@codigo_tipo_bodega").Value = objBodega.codigoTipoBodega
                    consulta.Parameters.Add(New SqlParameter("@cuenta", SqlDbType.NVarChar))
                    consulta.Parameters("@cuenta").Value = objBodega.noCuenta
                    consulta.Parameters.Add(New SqlParameter("@estado", SqlDbType.Bit))
                    consulta.Parameters("@estado").Value = objBodega.estado
                    consulta.Parameters.Add(New SqlParameter("@id_responsable", SqlDbType.Int))
                    consulta.Parameters("@id_responsable").Value = objBodega.responsable
                    consulta.Parameters.Add(New SqlParameter("@porcentaje", SqlDbType.Int))
                    consulta.Parameters("@porcentaje").Value = objBodega.incremento
                    consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.Int))
                    consulta.Parameters("@Usuario_creacion").Value = usuario
                    objBodega.codigo = CType(consulta.ExecuteScalar, String)
                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub actualizarBodega(ByRef objBodega As BodegaE, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()

                    consulta.CommandText = "[PROC_BODEGA_ACTUALIZAR]"
                    consulta.Parameters.Add(New SqlParameter("@IDCODIGO", SqlDbType.NVarChar))
                    consulta.Parameters("@IDCODIGO").Value = objBodega.codigo
                    consulta.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.NVarChar))
                    consulta.Parameters("@Codigo_EP").Value = objBodega.codigPunto
                    consulta.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar))
                    consulta.Parameters("@Descripcion").Value = objBodega.descripcion
                    consulta.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.NVarChar))
                    consulta.Parameters("@Direccion").Value = objBodega.direccion
                    consulta.Parameters.Add(New SqlParameter("@telefono", SqlDbType.NVarChar))
                    consulta.Parameters("@telefono").Value = objBodega.telefono
                    consulta.Parameters.Add(New SqlParameter("@codigo_tipo_bodega", SqlDbType.NVarChar))
                    consulta.Parameters("@codigo_tipo_bodega").Value = objBodega.codigoTipoBodega
                    consulta.Parameters.Add(New SqlParameter("@cuenta", SqlDbType.NVarChar))
                    consulta.Parameters("@cuenta").Value = objBodega.noCuenta
                    consulta.Parameters.Add(New SqlParameter("@estado", SqlDbType.Bit))
                    consulta.Parameters("@estado").Value = objBodega.estado
                    consulta.Parameters.Add(New SqlParameter("@id_responsable", SqlDbType.Int))
                    consulta.Parameters("@id_responsable").Value = objBodega.responsable
                    consulta.Parameters.Add(New SqlParameter("@porcentaje", SqlDbType.Int))
                    consulta.Parameters("@porcentaje").Value = objBodega.incremento
                    consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.Int))
                    consulta.Parameters("@Usuario_creacion").Value = SesionActual.idUsuario
                    consulta.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function verificar_formulario(form As Windows.Forms.Form) As Boolean
        Dim valor As Boolean = False
        For Each f As Windows.Forms.Form In Application.OpenForms
            If f.Name = form.Name Then
                valor = True
            End If
        Next
        Return valor
    End Function

End Class
