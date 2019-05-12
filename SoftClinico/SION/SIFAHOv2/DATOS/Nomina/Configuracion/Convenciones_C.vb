Imports System.Data.SqlClient
Imports System.IO
Public Class Convenciones_C
    Public Function guardar_convencion(pConvencion As Convencion) As String
        Dim codigo_convencion As String = ""


        Try

            Using Consulta As New SqlCommand("SP_CONVENCION_CREAR")
                Using trnsccion = form_principal.cnxion.BeginTransaction()

                    Consulta.Transaction = trnsccion
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion

                    Consulta.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.NVarChar)).Value = pConvencion.Codigo
                    Consulta.Parameters.Add(New SqlParameter("@pEmpresa", SqlDbType.NVarChar)).Value = form_principal.idEmpresa
                    Consulta.Parameters.Add(New SqlParameter("@pCod_EP", SqlDbType.Int)).Value = form_principal.codigoPuntoActual
                    Consulta.Parameters.Add(New SqlParameter("@pNombre", SqlDbType.NVarChar)).Value = pConvencion.Nombre
                    Consulta.Parameters.Add(New SqlParameter("@pSimbolo", SqlDbType.NVarChar)).Value = pConvencion.Simbolo
                    Consulta.Parameters.Add(New SqlParameter("@pColor", SqlDbType.Int)).Value = pConvencion.Argcolor
                    Consulta.Parameters.Add(New SqlParameter("@pEntrar", SqlDbType.DateTime)).Value = pConvencion.Entrar
                    Consulta.Parameters.Add(New SqlParameter("@pSMinutos", SqlDbType.BigInt)).Value = pConvencion.stMinutos
                    Consulta.Parameters.Add(New SqlParameter("@pDescansar", SqlDbType.DateTime)).Value = pConvencion.Descansar
                    Consulta.Parameters.Add(New SqlParameter("@pMinutosDescanso", SqlDbType.BigInt)).Value = pConvencion.dMinutos
                    Consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.NVarChar)).Value = form_principal.usuarioActual

                    codigo_convencion = CType(Consulta.ExecuteScalar, Integer)
                    trnsccion.Commit()
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return codigo_convencion
    End Function
End Class
