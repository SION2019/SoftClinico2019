Imports System.Data.SqlClient
Imports System.IO
Public Class ConvencionHorario
    Public Function guardar_convencion(pConvencion As Convencion) As String
        Dim codigo_convencion As String = ""


        Try

            Using Consulta As New SqlCommand("PROC_CONVENCION_CREAR")
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()

                    Consulta.Transaction = trnsccion
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion

                    Consulta.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.NVarChar)).Value = pConvencion.Codigo
                    Consulta.Parameters.Add(New SqlParameter("@pEmpresa", SqlDbType.NVarChar)).Value = SesionActual.idEmpresa
                    Consulta.Parameters.Add(New SqlParameter("@pCod_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    Consulta.Parameters.Add(New SqlParameter("@pNombre", SqlDbType.NVarChar)).Value = pConvencion.Nombre
                    Consulta.Parameters.Add(New SqlParameter("@pSimbolo", SqlDbType.NVarChar)).Value = pConvencion.Simbolo
                    Consulta.Parameters.Add(New SqlParameter("@pColor", SqlDbType.Int)).Value = pConvencion.Argcolor
                    Consulta.Parameters.Add(New SqlParameter("@pHora_Entrada", SqlDbType.DateTime)).Value = pConvencion.Entrar
                    Consulta.Parameters.Add(New SqlParameter("@pSMinutos", SqlDbType.BigInt)).Value = pConvencion.stMinutos
                    Consulta.Parameters.Add(New SqlParameter("@pHora_Descanso", SqlDbType.DateTime)).Value = pConvencion.Descansar
                    Consulta.Parameters.Add(New SqlParameter("@pMinutosDescanso", SqlDbType.BigInt)).Value = pConvencion.dMinutos
                    Consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.NVarChar)).Value = SesionActual.idUsuario

                    codigo_convencion = CType(Consulta.ExecuteScalar, Integer)
                    trnsccion.Commit()
                End Using
            End Using

        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

        Return codigo_convencion
    End Function
End Class
