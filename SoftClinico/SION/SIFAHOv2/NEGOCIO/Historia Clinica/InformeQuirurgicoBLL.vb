Public Class InformeQuirurgicoBLL
    Dim cmd As New InformeQuirurgicoDAL
    Private dtTabla As New DataTable
    Public Shared Function guardarInformeQx(objInforme As InformeQx)
        InformeQuirurgicoDAL.guardarInformeQx(objInforme)
        Return objInforme
    End Function
    Public Sub cargarValoresPredeterminados(codigoProcedimiento As String,
                                                   ByRef controles As Control,
                                             formulario As String)
        Try
            If dtTabla.Rows.Count > 0 Then
                For Each controlTxt In controles.Controls
                    If (TypeOf controlTxt Is TextBox) Then
                        agregarDatos(dtTabla, controlTxt)
                    ElseIf (TypeOf controlTxt Is GroupBox) Then
                        cargarValoresPredeterminados(codigoProcedimiento, controlTxt, formulario)
                    ElseIf (TypeOf controlTxt Is TabPage) Then
                        cargarValoresPredeterminados(codigoProcedimiento, controlTxt, formulario)
                    End If
                Next
            Else
                llenarDt(codigoProcedimiento, formulario)
                If dtTabla.Rows.Count = 0 Then Exit Sub
                cargarValoresPredeterminados(codigoProcedimiento, controles, formulario)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarDt(codigoProcedimiento As String, formulario As String)
        Dim params As New List(Of String)
        params.Add(codigoProcedimiento)
        params.Add(formulario)
        General.llenarTabla(Consultas.CONSULTA_VALOR_PREDETERMINADO, params, dtTabla)
    End Sub
    Private Sub agregarDatos(dtTabla As DataTable, txt As Control)
        Try
            For nFila = 0 To dtTabla.Rows.Count - 1
                If txt.Tag = dtTabla.Rows(nFila).Item(0) Then
                    txt.Text = dtTabla.Rows(nFila).Item(1).ToString
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
