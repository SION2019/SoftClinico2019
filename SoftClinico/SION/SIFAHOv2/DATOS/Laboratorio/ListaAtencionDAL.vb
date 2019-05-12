Imports System.Data.SqlClient
Public Class ListaAtencionDAL
    Public Shared Sub cargarMenuPadres(objLista As ListaAtencion)
        Try
            Using dbCommand As New SqlCommand(objLista.consultaPendiente & objLista.codigoAtencion & "", FormPrincipal.cnxion2doPlano)
                Using daCuentaPadre As New SqlDataAdapter(dbCommand)
                    daCuentaPadre.Fill(objLista.dsLista)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
