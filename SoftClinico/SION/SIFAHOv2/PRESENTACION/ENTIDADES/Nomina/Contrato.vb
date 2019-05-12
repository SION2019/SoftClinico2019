Public Class Contrato

    Property codigo As String
    Property inicio As Date
    Property fin As Date
    Property codigo_min As String
    Property tipo As String
    Property salario As String
    Property auxilio As String
    Property id_empleado As String
    Property id_cuenta As String = ""
    Property id_aux As String = ""

    Public Sub llenarDatosContratante(ByRef dtdatoscontratante As DataTable)
        ContratoLaboralDAL.llenarDatosContratante(dtdatoscontratante)
    End Sub

    Public Sub cargarMinuta(tempfileurl As String)
        Try
            Using consulta As New SqlCommand("SELECT * FROM D_CONTRATO_MINUTA WHERE Codigo_minuta = '" + codigo + "'", FormPrincipal.cnxion)
                Using resultado = consulta.ExecuteReader()
                    If resultado.HasRows = True Then
                        resultado.Read()
                        File.WriteAllBytes(tempfileurl + ".docx", resultado("Documento"))
                        resultado.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
