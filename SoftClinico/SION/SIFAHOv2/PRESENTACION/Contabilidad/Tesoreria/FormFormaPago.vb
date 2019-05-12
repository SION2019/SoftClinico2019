Option Explicit On
Public Class FormFormaPago
    Dim inp As New config()
    Dim resultado As New config()
    Dim todos As Boolean
    Dim cuenta As String
    Dim dtPuc As New DataTable()
    Public Property objFormProgramacionNomina As FormProgramacionPagoNomina
    Sub asisgnarSeleccion()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        If todos = True Then
            For indice = 0 To objFormProgramacionNomina.dgvEmpleados.Rows.Count - 1
                objFormProgramacionNomina.dgvEmpleados.Rows(indice).Cells(objFormProgramacionNomina.dgvEmpleados.CurrentCell.ColumnIndex).Value = dgvPuc.SelectedRows(0).Cells(1).Value.ToString
                objFormProgramacionNomina.dgvEmpleados.Rows(indice).Cells(objFormProgramacionNomina.dgvEmpleados.CurrentCell.ColumnIndex + 1).Value = dgvPuc.SelectedRows(0).Cells(0).Value.ToString
                objFormProgramacionNomina.dgvEmpleados.Rows(indice).Cells(objFormProgramacionNomina.dgvEmpleados.CurrentCell.ColumnIndex + 2).Value = If(rbtransferencia.Checked, "2", If(rbcheque.Checked, "3#" & textnumero.Text.ToString(), "1"))
            Next
        Else
            objFormProgramacionNomina.dgvEmpleados.Rows(objFormProgramacionNomina.dgvEmpleados.CurrentRow.Index).Cells(objFormProgramacionNomina.dgvEmpleados.CurrentCell.ColumnIndex).Value = dgvPuc.SelectedRows(0).Cells(1).Value.ToString
            objFormProgramacionNomina.dgvEmpleados.Rows(objFormProgramacionNomina.dgvEmpleados.CurrentRow.Index).Cells(objFormProgramacionNomina.dgvEmpleados.CurrentCell.ColumnIndex + 1).Value = dgvPuc.SelectedRows(0).Cells(0).Value.ToString
            objFormProgramacionNomina.dgvEmpleados.Rows(objFormProgramacionNomina.dgvEmpleados.CurrentRow.Index).Cells(objFormProgramacionNomina.dgvEmpleados.CurrentCell.ColumnIndex + 2).Value = If(rbtransferencia.Checked, "2", If(rbcheque.Checked, "3#" & textnumero.Text.ToString(), "1"))
        End If
        Me.Close()
    End Sub
    Sub llenarDgv(cuenta As String)
        Dim dtCuenta As New DataTable
        Dim params As New List(Of String)
        params.Add(cuenta)
        General.llenarTabla(ConsultasNom.PROGRAMACION_FORMA_PAGO, params, dtCuenta)
        dgvPuc.DataSource = dtCuenta
    End Sub

    Structure config
        Dim cuenta As String
        Dim nombre As String
        Dim medio As String
    End Structure

    Private Sub FormFormaPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dgvPuc.DataSource = dtPuc
        If inp.cuenta = "" OrElse inp.medio = "" Then
            rbcuentacorriente.Checked = True
            rbtransferencia.Checked = True
        Else
            Select Case Microsoft.VisualBasic.Left(inp.medio, 1)
                Case "1"
                    tbnota.Checked = True
                Case "2"
                    rbtransferencia.Checked = True
                Case "3"
                    rbcheque.Checked = True
                    Try
                        textnumero.Text = inp.medio.Split("#")(1).Trim
                    Catch ex As Exception
                    End Try
            End Select
            Select Case Microsoft.VisualBasic.Left(inp.cuenta, 4)
                Case Constantes.CUENTA_CORRIENTE
                    rbcuentacorriente.Checked = True
                Case Constantes.CUENTA_DE_AHORRO
                    rbcuentaahorro.Checked = True
                Case Constantes.CUENTA_CAJA
                    rbcaja.Checked = True
            End Select
            dgvPuc.ClearSelection()
            For Each fila As DataGridViewRow In dgvPuc.Rows
                If fila.Cells("Codigo").Value.ToString.Trim = inp.cuenta.Trim Then
                    dgvPuc.CurrentCell = fila.Cells("Codigo")
                    fila.Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub rbcuentacorriente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbcuentacorriente.CheckedChanged
        If rbcuentacorriente.Checked Then
            llenarDgv(Constantes.CUENTA_CORRIENTE)
        End If
    End Sub

    Private Sub rbcuentaahorro_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbcuentaahorro.CheckedChanged
        If rbcuentaahorro.Checked Then
            llenarDgv(Constantes.CUENTA_DE_AHORRO)
        End If
    End Sub

    Private Sub rbcaja_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbcaja.CheckedChanged
        If rbcaja.Checked Then
            llenarDgv(Constantes.CUENTA_CAJA)
        End If
    End Sub

    Private Sub rbcheque_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbcheque.CheckedChanged
        textnumero.Enabled = rbcheque.Checked
    End Sub

    Private Sub textnumero_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles textnumero.EnabledChanged
        textnumero.BackColor = If(textnumero.Enabled, Color.FromArgb(255, 254, 215), System.Drawing.SystemColors.Control)
    End Sub

    Private Sub textnumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles textnumero.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub btaplicar_DropDownOpening(sender As System.Object, e As System.EventArgs) Handles btaplicar.DropDownOpening
        AplicarATodosLosPagosToolStripMenuItem.Enabled = Not textnumero.Enabled
    End Sub

    Private Sub btaplicar_ButtonClick(sender As System.Object, e As System.EventArgs) Handles btaplicar.ButtonClick, AplicarAlPagoActualToolStripMenuItem.Click
        If rbcheque.Checked AndAlso textnumero.Text.Trim = "" Then
            MsgBox("Por favor Coloque el numero del Cheque.", MsgBoxStyle.Exclamation, "Atencion")
        Else
            asisgnarSeleccion()
        End If
    End Sub

    Private Sub AplicarATodosLosPagosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AplicarATodosLosPagosToolStripMenuItem.Click
        todos = True
        asisgnarSeleccion()
    End Sub

    Private Sub btnoaplicar_Click(sender As System.Object, e As System.EventArgs) Handles btnoaplicar.Click
        Me.Close()
    End Sub

    Private Sub link_fmp_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Close()
    End Sub
End Class