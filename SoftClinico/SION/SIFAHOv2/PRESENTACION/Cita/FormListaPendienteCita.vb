Public Class FormListaPendienteCita
    Dim objlistaCita As ListaCita
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormListaPendienteCita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objlistaCita = New ListaCita
        cargarCitasPendiente()
        marcarDiaCita()
    End Sub
    Public Sub cargarCitasPendiente()
        Try
            Dim params As New List(Of String)
            params.Add(calendarioCita.SelectionStart.Date)
            params.Add(SesionActual.codigoEP)
            params.Add(SesionActual.idUsuario)
            General.llenarTabla("[PROC_LISTA_CITA_CARGAR]", params, objlistaCita.dtLista)
            dglIistaPendiente.DataSource = objlistaCita.dtLista
            validarDgv()
            ubicarScrollInicial()
            conteoRegistro()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ubicarScrollInicial()
        For posicion = 0 To objlistaCita.dtLista.Rows.Count - 1
            If Not IsDBNull(objlistaCita.dtLista.Rows(posicion).Item("codigo_procedimiento")) Then
                dglIistaPendiente.FirstDisplayedScrollingRowIndex = posicion
                Exit For
            End If
        Next
    End Sub
    Private Sub conteoRegistro()
        txtCancelado.Text = objlistaCita.dtLista.Select("Estado='C'").Count
        txtEspera.Text = objlistaCita.dtLista.Select("Estado='P'").Count
        txtPendiente.Text = objlistaCita.dtLista.Select("Estado='R' and Realizado='False'").Count
        txtRealizado.Text = objlistaCita.dtLista.Select("Realizado='True'").Count
    End Sub
    Private Sub validarDgv()
        With dglIistaPendiente
            .AutoGenerateColumns = False
            .Columns("Id").Visible = False
            .Columns("Codigo_Procedimiento").Visible = False
            .Columns("Estado").Visible = False
            .Columns("Hora").ReadOnly = True
            .Columns("Paciente").ReadOnly = True
            .Columns("Procedimiento").ReadOnly = True
            .Columns("Hora").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Paciente").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Procedimiento").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Item("Hora").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Paciente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Procedimiento").SortMode = DataGridViewColumnSortMode.NotSortable
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        End With
    End Sub
    Private Sub calendarioCita_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calendarioCita.DateChanged
        cargarCitasPendiente()
    End Sub
    Private Sub dglIistaPendiente_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dglIistaPendiente.CellFormatting
        Dim celda As DataGridViewButtonCell
        If objlistaCita.dtLista.Rows.Count > 0 Then
            Try
                If Not IsDBNull(dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value) Then
                    If (TypeOf dglIistaPendiente.Rows(e.RowIndex).Cells("Resultado") IsNot DataGridViewButtonCell) And
                       dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value = "R" Then
                        celda = New DataGridViewButtonCell
                        celda.UseColumnTextForButtonValue = True
                        celda.ToolTipText = "Resultado"
                        dglIistaPendiente.Rows(e.RowIndex).Cells("Resultado") = celda
                    End If
                    If dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value = "C" Then
                        dglIistaPendiente.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192)
                    ElseIf dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value = "P" Then
                        dglIistaPendiente.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192)
                    ElseIf dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value = "R" Then
                        dglIistaPendiente.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255)
                    End If
                    If dglIistaPendiente.Rows(e.RowIndex).Cells("Realizado").Value = True Then
                        dglIistaPendiente.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub dglIistaPendiente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dglIistaPendiente.CellDoubleClick
        If objlistaCita.dtLista.Rows.Count > 0 Then
            Try
                If e.ColumnIndex = 5 Then
                    If Not IsDBNull(dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value) Then
                        If dglIistaPendiente.Rows(e.RowIndex).Cells("Estado").Value = "R" Then
                            Dim form As New Form_resultado
                            form.cargarResultado(dglIistaPendiente.Rows(e.RowIndex).Cells("Id").Value,
                                                 dglIistaPendiente.Rows(e.RowIndex).Cells("Codigo_Procedimiento").Value,
                                                 dglIistaPendiente.Rows(e.RowIndex).Cells("Procedimiento").Value, Constantes.DC,
                                                 ConstantesHC.CODIGO_IMAGEN_DCM,
                                                 "A")
                            form.formListaCita = Me
                            form.MdiParent = FormPrincipal
                            form.Show()
                            form.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub marcarDiaCita()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        Try
            params.Add(SesionActual.idUsuario)
            params.Add(SesionActual.codigoEP)
            General.llenarTabla("[PROC_LISTA_FECHA_CITA_CARGAR]", params, dt)
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Select
                    calendarioCita.AddBoldedDate(fila("Fecha"))
                    calendarioCita.UpdateBoldedDates()
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class