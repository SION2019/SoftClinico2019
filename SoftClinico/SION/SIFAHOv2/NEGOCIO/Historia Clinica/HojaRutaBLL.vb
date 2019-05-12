Public Class HojaRutaBLL

    Public Shared Function guardarHojaRuta(objHojaRuta As HojaRuta)
        HojaRutaDAL.guardarHojaRuta(objHojaRuta)
        Return objHojaRuta
    End Function
    Public Shared Function guardarTareasProgramas(objHojaRuta As HojaRuta)
        HojaRutaDAL.guardarTareasProgramas(objHojaRuta)
        Return objHojaRuta
    End Function
    Public Shared Function codigoEstadoAtencion(atendido As RadioButton,
                                                cerrado As RadioButton) As Integer
        Dim codigo As Integer

        If atendido.Checked = True Then
            codigo = Constantes.ESTADO_ATENCION_INICIADO
        ElseIf cerrado.Checked = True Then
            codigo = Constantes.ESTADO_ATENCION_CERRADO
        End If

        Return codigo
    End Function
    Public Shared Sub abrirJustificacion(dgv As DataGridView,
                                          dt As DataTable,
                                           panel As Panel,
                                            txtJustificacion As RichTextBox,
                                             nombreColumna As String, estado As Boolean)
        Dim texto As String
        If dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Selected = True Then
            panel.Visible = True
            txtJustificacion.ReadOnly = estado
            texto = dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Value.ToString
            txtJustificacion.Text = texto
            txtJustificacion.Focus()
            txtJustificacion.SelectionStart = txtJustificacion.TextLength
        End If
    End Sub

    Public Shared Sub identificarRegistro(dgv As DataGridView, dt As DataTable)
        If dt.Rows.Count > 0 Then
            If dt.Rows(dgv.CurrentCell.RowIndex).Item("Estado") = 1 Then
                dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgRevisado").Value = My.Resources.OK
            Else
                dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgRevisado").Value = My.Resources._new
            End If
        End If
    End Sub
    Public Shared Sub identificarRegistros(dgv As DataGridView, dt As DataTable)
        If dt.Rows.Count > 0 Then
            For j = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item("Estado") = 1 Then
                    dgv.Rows(j).Cells("dgRevisado").Value = My.Resources.OK
                Else
                    dgv.Rows(j).Cells("dgRevisado").Value = My.Resources._new
                End If
            Next
        End If
    End Sub
End Class
