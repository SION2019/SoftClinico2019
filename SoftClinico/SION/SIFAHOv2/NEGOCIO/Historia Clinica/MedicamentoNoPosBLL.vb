Public Class MedicamentoNoPosBLL


    Public Shared Sub guardarMedicamentosNOPOS(Modulo As String, objMedicamentos As SolicitudMedicamentosNoPos, dtDiagnosticos As DataTable)

        Dim dtNew As New DataTable
        Dim filas As DataRow()
        dtNew = dtDiagnosticos.Clone
        filas = dtDiagnosticos.Select("Seleccion=1")

        For Each row As DataRow In filas
            dtNew.ImportRow(row)
        Next

        If Modulo = Constantes.AM Then
            If String.IsNullOrEmpty(objMedicamentos.Codigo) Then
                objMedicamentos.Codigo = Constantes.VALOR_PREDETERMINADO
                MedicamentoNoPosDAL.guardarMedicamentosNOPOSAM(objMedicamentos, dtNew)
            Else
                MedicamentoNoPosDAL.actualizarMedicamentosNOPOSAM(objMedicamentos, dtNew)
            End If
        ElseIf Modulo = Constantes.AF Then
            If String.IsNullOrEmpty(objMedicamentos.Codigo) Then
                objMedicamentos.Codigo = Constantes.VALOR_PREDETERMINADO
                MedicamentoNoPosDAL.guardarMedicamentosNOPOSAF(objMedicamentos, dtNew)
            Else
                MedicamentoNoPosDAL.actualizarMedicamentosNOPOSAF(objMedicamentos, dtNew)
            End If
        Else
            If String.IsNullOrEmpty(objMedicamentos.Codigo) Then
                MedicamentoNoPosDAL.guardarMedicamentosNOPOSHc(objMedicamentos, dtNew)
            Else
                MedicamentoNoPosDAL.actualizarMedicamentosNOPOSHc(objMedicamentos, dtNew)
            End If
        End If

    End Sub

End Class
