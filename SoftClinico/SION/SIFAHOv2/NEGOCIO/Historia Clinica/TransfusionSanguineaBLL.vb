Public Class TransfusionSanguineaBLL
    Dim objTransfusion_C As New TransfusionSanguineaDAL

    Public Function crearTransfusion(Modulo As String, objTransfusion As TransfusionSanguinea)

        Select Case Modulo
            Case Constantes.HC
                If String.IsNullOrEmpty(objTransfusion.CodigoTransfusion) Then
                    objTransfusion_C.crearTransfusion(objTransfusion)
                Else
                    objTransfusion_C.actualizarTransfusion(objTransfusion)
                End If
            Case Constantes.AM
                If String.IsNullOrEmpty(objTransfusion.CodigoTransfusion) Then
                    objTransfusion.CodigoTransfusion = Constantes.VALOR_PREDETERMINADO
                    objTransfusion_C.crearTransfusionR(objTransfusion)
                Else
                    objTransfusion_C.actualizarTransfusionR(objTransfusion)
                End If
            Case Constantes.AF
                If String.IsNullOrEmpty(objTransfusion.CodigoTransfusion) Then
                    objTransfusion.CodigoTransfusion = Constantes.VALOR_PREDETERMINADO
                    objTransfusion_C.crearTransfusionRR(objTransfusion)
                Else
                    objTransfusion_C.actualizarTransfusionRR(objTransfusion)
                End If
        End Select
        Return objTransfusion
    End Function

    Public Function crearLaboratorio(modulo As String, objTransfusion As TransfusionSanguinea)
        Select Case modulo
            Case Constantes.HC
                If objTransfusion.CodigoTransfusion <> "" Then
                    objTransfusion_C.actualizarLaboratorio(objTransfusion)
                    objTransfusion_C.actualizarLaboratorio2(objTransfusion)
                End If
            Case Constantes.AM
                If objTransfusion.CodigoTransfusion <> "" Then
                    objTransfusion_C.actualizarLaboratorioR(objTransfusion)
                    objTransfusion_C.actualizarLaboratorio2R(objTransfusion)
                End If
            Case Constantes.AF
                If objTransfusion.CodigoTransfusion <> "" Then
                    objTransfusion_C.actualizarLaboratorioRR(objTransfusion)
                    objTransfusion_C.actualizarLaboratorio2RR(objTransfusion)
                End If
        End Select

        Return objTransfusion
    End Function

    Public Function crearEnfermera(modulo As String, objTransfusion As TransfusionSanguinea)
        If modulo = Constantes.HC Then
            If objTransfusion.CodigoTransfusion <> "" Then
                objTransfusion_C.actualizarEnfermera(objTransfusion)
                objTransfusion_C.actualizarEnfermera2(objTransfusion)
            End If
        ElseIf modulo = Constantes.AM Then
            If objTransfusion.CodigoTransfusion <> "" Then
                objTransfusion_C.actualizarEnfermeraR(objTransfusion)
                objTransfusion_C.actualizarEnfermera2R(objTransfusion)
            End If
        ElseIf modulo = Constantes.AF Then
            If objTransfusion.CodigoTransfusion <> "" Then
                objTransfusion_C.actualizarEnfermeraRR(objTransfusion)
                objTransfusion_C.actualizarEnfermera2RR(objTransfusion)
            End If
        End If
        Return objTransfusion
    End Function

End Class
