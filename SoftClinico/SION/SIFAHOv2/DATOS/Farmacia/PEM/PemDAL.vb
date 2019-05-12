Public Class PemDAL
    Public Sub guardarPem(ByRef objPem As Pem,
                          ByVal usuario As Integer,
                          ByVal codigoEP As Integer)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    'se guarda el pem general 
                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PEM_CREAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoPedidoFarmacia", SqlDbType.NVarChar)).Value = objPem.codigoPedido
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoContrato", SqlDbType.Int)).Value = objPem.idContrato
                    sentencia.Parameters.Add(New SqlParameter("@pFechaPem", SqlDbType.DateTime)).Value = objPem.fechaPem
                    sentencia.Parameters.Add(New SqlParameter("@pRazon", SqlDbType.Float)).Value = objPem.razon
                    sentencia.Parameters.Add(New SqlParameter("@pVolumenTotal", SqlDbType.Float)).Value = objPem.volumenTotal
                    sentencia.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = objPem.tipoPedido
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@pTablaDiagnosticos", SqlDbType.Structured)).Value = objPem.tablaDiagnosticos
                    sentencia.Parameters.Add(New SqlParameter("@pTablaMedicamentos", SqlDbType.Structured)).Value = objPem.tablaMedicamentos
                    sentencia.Parameters.Add(New SqlParameter("@pTablaImpregnaciones", SqlDbType.Structured)).Value = objPem.tablaImpregnaciones
                    sentencia.Parameters.Add(New SqlParameter("@pTablaNutricion", SqlDbType.Structured)).Value = objPem.tablaNutricion
                    sentencia.Parameters.Add(New SqlParameter("@pTablaInsumosEnfermeria", SqlDbType.Structured)).Value = objPem.tablaInsumosEnfermeria
                    sentencia.Parameters.Add(New SqlParameter("@pTablaInsumosFisioterapia", SqlDbType.Structured)).Value = objPem.tablaInsumosFisioterapia
                    objPem.codigoPem = CType(sentencia.ExecuteScalar, String)


                    ' se guardan los areas Servicio asociados al pem
                    'For indiceAreaServicio = 0 To objPem.listaAreaServicios.Count - 1
                    '    sentencia.Parameters.Clear()
                    '    sentencia.CommandText = "[PROC_PEM_CREAR_DETALLE_AREAS_SERVICIO]"
                    '    sentencia.Parameters.Add(New SqlParameter("@pCodigoPem", SqlDbType.Int)).Value = objPem.codigoPem
                    '    sentencia.Parameters.Add(New SqlParameter("@pCodigoArea", SqlDbType.Int)).Value = objPem.listaAreaServicios(indiceAreaServicio)
                    '    sentencia.ExecuteNonQuery()
                    'Next

                    'Se guarda las infusiones
                    Dim limiteFilasInfusion As Integer = (objPem.tablaInfusiones.Rows.Count - If(objPem.swtManual = True, 2, 1))
                    Dim consecutivo As Integer

                    For indiceFila = 0 To limiteFilasInfusion
                        sentencia.Parameters.Clear()

                        sentencia.CommandText = "[PROC_PEM_CREAR_DETALLE_INFUSION]"
                        ' si la infusion exite la guardamos y comprobamos que tenga mezcla
                        sentencia.Parameters.Add(New SqlParameter("@pCodigoPem", SqlDbType.Int)).Value = objPem.codigoPem
                        sentencia.Parameters.Add(New SqlParameter("@pCodigoInterno", SqlDbType.Int)).Value = objPem.tablaInfusiones(indiceFila).Item("Codigo_interno")
                        sentencia.Parameters.Add(New SqlParameter("@pDosis", SqlDbType.Float)).Value = objPem.tablaInfusiones(indiceFila).Item("Dosis")
                        sentencia.Parameters.Add(New SqlParameter("@pVelocidad", SqlDbType.Float)).Value = objPem.tablaInfusiones(indiceFila).Item("Velocidad")
                        sentencia.Parameters.Add(New SqlParameter("@pProductoDisolvente", SqlDbType.Int)).Value = objPem.tablaInfusiones(indiceFila).Item("Producto_Disolvente")
                        sentencia.Parameters.Add(New SqlParameter("@pTotalDisolvente", SqlDbType.NVarChar)).Value = objPem.tablaInfusiones(indiceFila).Item("TotalDisolvente")
                        sentencia.Parameters.Add(New SqlParameter("@pCantidadDisolvente", SqlDbType.Int)).Value = objPem.tablaInfusiones(indiceFila).Item("CantidadDisolvente")
                        sentencia.Parameters.Add(New SqlParameter("@pVolumenTotal", SqlDbType.NVarChar)).Value = objPem.tablaInfusiones(indiceFila).Item("TotalDisolventeInfusion")
                        consecutivo = CType(sentencia.ExecuteScalar, String)


                        If objPem.dtTablaMezclas.Tables.Contains(objPem.nombrarMezclaInfusion(indiceFila)) Then
                            sentencia.Parameters.Clear()
                            sentencia.CommandText = "[PROC_PEM_CREAR_DETALLE_INFUSION_MEZCLAS]"
                            sentencia.Parameters.Add(New SqlParameter("@pCodigoPem", SqlDbType.Int)).Value = objPem.codigoPem
                            sentencia.Parameters.Add(New SqlParameter("@pCodigoConsecutivo", SqlDbType.Int)).Value = consecutivo
                            sentencia.Parameters.Add(New SqlParameter("@pTablaMezclas", SqlDbType.Structured)).Value = objPem.dtTablaMezclas.Tables(objPem.nombrarMezclaInfusion(indiceFila))
                            sentencia.ExecuteNonQuery()
                        End If

                    Next

                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub anular(ByRef objPem As Pem,
               ByVal usuario As Integer)

        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PEMS_ANULAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoPem", SqlDbType.Int)).Value = objPem.codigoPem
                    sentencia.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Int)).Value = usuario
                    sentencia.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarDespachoDePem(ByRef objPem As Pem) As Boolean
        Dim resp As Boolean = False
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(objPem.codigoPem)
        fila = General.cargarItem("PROC_VERIFICAR_PEM_DESPACHADO", params)
        If Not IsNothing(fila) Then
            If fila.Item(0) = 0 Then
                resp = True
            End If
        End If
        Return resp
    End Function
End Class
