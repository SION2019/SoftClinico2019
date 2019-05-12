Imports System.Data.SqlClient
Public Class EquivalenciaDAL

    Public Shared Sub GuardarEquivalencia(objEquivalencia As EquivalenciaInventario, DTvias As DataTable)


        Try
            If String.IsNullOrEmpty(objEquivalencia.osmolalidad) Then
                objEquivalencia.osmolalidad = 0
            End If

            Using consulta As New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    If Not String.IsNullOrEmpty(objEquivalencia.codigoint) Then
                        consulta.Parameters.Clear()
                        consulta.CommandType = CommandType.StoredProcedure
                        consulta.CommandText = "PROC_EQUIVALENCIA_ACTUALIZAR"
                        consulta.Parameters.Add(New SqlParameter("@CODIGOE", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOE").Value = objEquivalencia.codigopos
                        consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                        consulta.Parameters("@DESCRIPCION").Value = objEquivalencia.descripcion
                        consulta.Parameters.Add(New SqlParameter("@CODIGOGRUPO", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOGRUPO").Value = objEquivalencia.grupo
                        consulta.Parameters.Add(New SqlParameter("@CATEGORIA", SqlDbType.NVarChar))
                        consulta.Parameters("@CATEGORIA").Value = objEquivalencia.rboption
                        consulta.Parameters.Add(New SqlParameter("@CODIGOLINEA", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOLINEA").Value = objEquivalencia.linea
                        consulta.Parameters.Add(New SqlParameter("@CODIGOPRESE", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOPRESE").Value = objEquivalencia.comboprese
                        consulta.Parameters.Add(New SqlParameter("@OBSERVACION", SqlDbType.NVarChar))
                        consulta.Parameters("@OBSERVACION").Value = objEquivalencia.descripcionpro
                        consulta.Parameters.Add(New SqlParameter("@Disolvente", SqlDbType.Bit))
                        consulta.Parameters("@Disolvente").Value = objEquivalencia.Checkdislvente
                        consulta.Parameters.Add(New SqlParameter("@CANTICONSE", SqlDbType.Float))
                        consulta.Parameters("@CANTICONSE").Value = objEquivalencia.Numconce
                        consulta.Parameters.Add(New SqlParameter("@CODIGOUNI", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOUNI").Value = objEquivalencia.combonum
                        consulta.Parameters.Add(New SqlParameter("@APLICADISOL", SqlDbType.Bit))
                        consulta.Parameters("@APLICADISOL").Value = objEquivalencia.Checkaplica
                        consulta.Parameters.Add(New SqlParameter("@TEMMIN", SqlDbType.Float))
                        consulta.Parameters("@TEMMIN").Value = objEquivalencia.Numerictempmin
                        consulta.Parameters.Add(New SqlParameter("@TEMMAX", SqlDbType.Float))
                        consulta.Parameters("@TEMMAX").Value = objEquivalencia.Numeritemmax
                        consulta.Parameters.Add(New SqlParameter("@CODIGOSETEMINI", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOSETEMINI").Value = objEquivalencia.combotemconse
                        consulta.Parameters.Add(New SqlParameter("@Descripcion_atc", SqlDbType.NVarChar))
                        consulta.Parameters("@Descripcion_atc").Value = objEquivalencia.descripcionATC
                        consulta.Parameters.Add(New SqlParameter("@grupo_atc", SqlDbType.NVarChar))
                        consulta.Parameters("@grupo_atc").Value = objEquivalencia.grupoATC
                        consulta.Parameters.Add(New SqlParameter("@DURACIONINI", SqlDbType.Int))
                        consulta.Parameters("@DURACIONINI").Value = objEquivalencia.duracion
                        consulta.Parameters.Add(New SqlParameter("@DURACIONFIN", SqlDbType.Int))
                        consulta.Parameters("@DURACIONFIN").Value = objEquivalencia.duracionmax
                        consulta.Parameters.Add(New SqlParameter("@OSMOLALIDAD", SqlDbType.Float))
                        consulta.Parameters("@OSMOLALIDAD").Value = objEquivalencia.osmolalidad
                        consulta.Parameters.Add(New SqlParameter("@MESPECIAL", SqlDbType.Bit))
                        consulta.Parameters("@MESPECIAL").Value = objEquivalencia.Checkmespecial
                        consulta.Parameters.Add(New SqlParameter("@CODIGOCUAL", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOCUAL").Value = objEquivalencia.Combocualidad
                        consulta.Parameters.Add(New SqlParameter("@ESTERILIZACION", SqlDbType.Bit))
                        consulta.Parameters("@ESTERILIZACION").Value = objEquivalencia.Checkestirilizacion

                        consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                        consulta.Parameters("@USUARIO").Value = objEquivalencia.usuario
                        consulta.Parameters.Add(New SqlParameter("@CODIGO_RIESGO", SqlDbType.Int))
                        consulta.Parameters("@CODIGO_RIESGO").Value = objEquivalencia.Comboriesgo
                        consulta.Parameters.Add(New SqlParameter("@IDCODIGO", SqlDbType.Int))
                        consulta.Parameters("@IDCODIGO").Value = objEquivalencia.codigoint

                        consulta.Parameters.Add(New SqlParameter("@MEZCLA", SqlDbType.Bit))
                        consulta.Parameters("@MEZCLA").Value = objEquivalencia.Checkmezcla
                        consulta.Parameters.Add(New SqlParameter("@ENFERMERIA", SqlDbType.Bit))
                        consulta.Parameters("@ENFERMERIA").Value = objEquivalencia.Checkenfermeria
                        consulta.Parameters.Add(New SqlParameter("@FISIOTERAPIA", SqlDbType.Bit))
                        consulta.Parameters("@FISIOTERAPIA").Value = objEquivalencia.Checkfisio

                        consulta.ExecuteNonQuery()

                        consulta.Parameters.Clear()
                        consulta.CommandText = "PROC_EQUIVALENCIA_VIA_LIMPIAR"
                        consulta.Parameters.Add(New SqlParameter("@CODIGOINT", SqlDbType.Int))
                        consulta.Parameters("@CODIGOINT").Value = objEquivalencia.codigoint
                        consulta.ExecuteNonQuery()
                        For i As Int32 = 0 To DTvias.Rows.Count - 1
                            consulta.Parameters.Clear()

                            consulta.CommandText = "PROC_EQUIVALENCIA_VIA_ASIGNAR"
                            consulta.Parameters.Add(New SqlParameter("@CODIGOINT", SqlDbType.NVarChar))
                            consulta.Parameters("@CODIGOINT").Value = objEquivalencia.codigoint
                            consulta.Parameters.Add(New SqlParameter("@CODIGOVIAS", SqlDbType.NVarChar))
                            consulta.Parameters("@CODIGOVIAS").Value = DTvias.Rows(i).Item("Codigo_via").ToString
                            consulta.ExecuteNonQuery()
                        Next
                    Else
                        consulta.Parameters.Clear()
                        consulta.CommandType = CommandType.StoredProcedure
                        consulta.CommandText = "PROC_EQUIVALENCIA_CREAR"
                        consulta.Parameters.Add(New SqlParameter("@CODIGOE", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGOE").Value = objEquivalencia.codigopos
                        consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                        consulta.Parameters("@DESCRIPCION").Value = objEquivalencia.descripcion
                        consulta.Parameters.Add(New SqlParameter("@CODIGOGRUPO", SqlDbType.Int))
                        consulta.Parameters("@CODIGOGRUPO").Value = objEquivalencia.grupo
                        consulta.Parameters.Add(New SqlParameter("@CATEGORIA", SqlDbType.NVarChar))
                        consulta.Parameters("@CATEGORIA").Value = objEquivalencia.rboption
                        consulta.Parameters.Add(New SqlParameter("@CODIGOLINEA", SqlDbType.Int))
                        consulta.Parameters("@CODIGOLINEA").Value = objEquivalencia.linea
                        consulta.Parameters.Add(New SqlParameter("@CODIGOPRESE", SqlDbType.Int))
                        consulta.Parameters("@CODIGOPRESE").Value = objEquivalencia.comboprese
                        consulta.Parameters.Add(New SqlParameter("@OBSERVACION", SqlDbType.NVarChar))
                        consulta.Parameters("@OBSERVACION").Value = objEquivalencia.descripcionpro
                        consulta.Parameters.Add(New SqlParameter("@Disolvente", SqlDbType.Bit))
                        consulta.Parameters("@Disolvente").Value = objEquivalencia.Checkdislvente
                        consulta.Parameters.Add(New SqlParameter("@CANTICONSE", SqlDbType.Float))
                        consulta.Parameters("@CANTICONSE").Value = objEquivalencia.Numconce
                        consulta.Parameters.Add(New SqlParameter("@CODIGOUNI", SqlDbType.Int))
                        consulta.Parameters("@CODIGOUNI").Value = objEquivalencia.combonum
                        consulta.Parameters.Add(New SqlParameter("@APLICADISOL", SqlDbType.Bit))
                        consulta.Parameters("@APLICADISOL").Value = objEquivalencia.Checkaplica
                        consulta.Parameters.Add(New SqlParameter("@TEMMIN", SqlDbType.Float))
                        consulta.Parameters("@TEMMIN").Value = objEquivalencia.Numerictempmin
                        consulta.Parameters.Add(New SqlParameter("@TEMMAX", SqlDbType.Float))
                        consulta.Parameters("@TEMMAX").Value = objEquivalencia.Numeritemmax
                        consulta.Parameters.Add(New SqlParameter("@CODIGOSETEMINI", SqlDbType.Int))
                        consulta.Parameters("@CODIGOSETEMINI").Value = objEquivalencia.combotemconse
                        consulta.Parameters.Add(New SqlParameter("@Descripcion_atc", SqlDbType.NVarChar))
                        consulta.Parameters("@Descripcion_atc").Value = objEquivalencia.descripcionATC
                        consulta.Parameters.Add(New SqlParameter("@grupo_atc", SqlDbType.NVarChar))
                        consulta.Parameters("@grupo_atc").Value = objEquivalencia.grupoATC
                        consulta.Parameters.Add(New SqlParameter("@DURACIONINI", SqlDbType.Int))
                        consulta.Parameters("@DURACIONINI").Value = objEquivalencia.duracion
                        consulta.Parameters.Add(New SqlParameter("@DURACIONFIN", SqlDbType.Int))
                        consulta.Parameters("@DURACIONFIN").Value = objEquivalencia.duracionmax
                        consulta.Parameters.Add(New SqlParameter("@OSMOLALIDAD", SqlDbType.Float))
                        consulta.Parameters("@OSMOLALIDAD").Value = objEquivalencia.osmolalidad
                        consulta.Parameters.Add(New SqlParameter("@MESPECIAL", SqlDbType.Bit))
                        consulta.Parameters("@MESPECIAL").Value = objEquivalencia.Checkmespecial
                        consulta.Parameters.Add(New SqlParameter("@CODIGOCUAL", SqlDbType.Int))
                        consulta.Parameters("@CODIGOCUAL").Value = objEquivalencia.Combocualidad
                        consulta.Parameters.Add(New SqlParameter("@ESTERILIZACION", SqlDbType.Bit))
                        consulta.Parameters("@ESTERILIZACION").Value = objEquivalencia.Checkestirilizacion
                        consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Int))
                        consulta.Parameters("@USUARIO").Value = objEquivalencia.usuario
                        consulta.Parameters.Add(New SqlParameter("@CODIGO_RIESGO", SqlDbType.Int))
                        consulta.Parameters("@CODIGO_RIESGO").Value = objEquivalencia.Comboriesgo
                        consulta.Parameters.Add(New SqlParameter("@MEZCLA", SqlDbType.Bit))
                        consulta.Parameters("@MEZCLA").Value = objEquivalencia.Checkmezcla
                        consulta.Parameters.Add(New SqlParameter("@ENFERMERIA", SqlDbType.Bit))
                        consulta.Parameters("@ENFERMERIA").Value = objEquivalencia.Checkenfermeria
                        consulta.Parameters.Add(New SqlParameter("@FISIOTERAPIA", SqlDbType.Bit))
                        consulta.Parameters("@FISIOTERAPIA").Value = objEquivalencia.Checkfisio
                        objEquivalencia.codigoint = CType(consulta.ExecuteScalar, String)

                        consulta.Parameters.Clear()
                        consulta.CommandText = "PROC_EQUIVALENCIA_VIA_LIMPIAR"
                        consulta.Parameters.Add(New SqlParameter("@CODIGOINT", SqlDbType.Int))
                        consulta.Parameters("@CODIGOINT").Value = objEquivalencia.codigoint
                        consulta.ExecuteNonQuery()

                        For i As Int32 = 0 To DTvias.Rows.Count - 1
                            consulta.Parameters.Clear()
                            consulta.CommandText = "PROC_EQUIVALENCIA_VIA_ASIGNAR"
                            consulta.Parameters.Add(New SqlParameter("@CODIGOINT", SqlDbType.NVarChar))
                            consulta.Parameters("@CODIGOINT").Value = objEquivalencia.codigoint
                            consulta.Parameters.Add(New SqlParameter("@CODIGOVIAS", SqlDbType.NVarChar))
                            consulta.Parameters("@CODIGOVIAS").Value = DTvias.Rows(i).Item("Codigo_via").ToString
                            consulta.ExecuteNonQuery()
                        Next
                    End If
                    Try
                        trnsccion.Commit()
                    Catch ex As Exception

                        trnsccion.Rollback()
                        General.manejoErrores(ex)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
