Public Class Deduccion
    Property codigo As String
    Property empleado As Integer
    Property tipo As Integer
    Property Fecha As Date
    Property Fecha_Nomina As Date
    Property Valor As Decimal = 0
    Property Interes ' As Decimal 
    Property Base_Interes ' As String
    Property Cuotas ' As Integer
    Property Abono ' As Decimal
    Property Entidad ' As Integer
    Property dtAnticipoDeuda As DataTable
    Property dtExceptuarMes As DataTable






    Sub genRowNcod(pcodigo As String)

        Dim ncodigo As Integer = pcodigo

        For Each dw As DataRow In dtAnticipoDeuda.Rows
            If (dw("Codigo") = "" AndAlso dw("Anulado") = False) Then
                ncodigo += 1
                dw("Nuevo_Codigo") = ncodigo
            End If
        Next

        For Each dw As DataRow In dtExceptuarMes.Rows
            If (dw("Codigo") = "" AndAlso dw("Anulado") = False) Then
                ncodigo += 1
                dw("Nuevo_Codigo") = ncodigo
            End If
        Next

    End Sub






    Sub updtCodigo()

        For Indc As Integer = (dtAnticipoDeuda.Rows.Count - 1) To 0 Step -1
            Dim dw = dtAnticipoDeuda.Rows(Indc)
            dw("Codigo_Deduccion") = codigo
            If (dw("Anulado") = True) Then
                dtAnticipoDeuda.Rows.Remove(dw)
            ElseIf (dw("Codigo") = "" AndAlso dw("Anulado") = False) Then
                dw("Codigo") = dw("Nuevo_Codigo")
            End If
        Next

        For Indc As Integer = (dtExceptuarMes.Rows.Count - 1) To 0 Step -1
            Dim dw = dtExceptuarMes.Rows(Indc)
            dw("Codigo_Deduccion") = codigo
            If (dw("Anulado") = True) Then
                dtExceptuarMes.Rows.Remove(dw)
            ElseIf (dw("Codigo") = "" AndAlso dw("Anulado") = False) Then
                dw("Codigo") = dw("Nuevo_Codigo")
            End If
        Next

    End Sub

End Class
