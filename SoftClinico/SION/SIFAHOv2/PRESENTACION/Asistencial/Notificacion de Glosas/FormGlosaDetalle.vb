Public Class FormGlosaDetalle
    Dim dtDetalle As New DataTable
    Dim identificador As String
    Dim objDetalleGlosa As New DetalleGlosa
    Public Property objFormNotificacion As FormNotificacionGlosa
    Public Property objFormDevolucion As FormDevolucionGlosa
    Public Property formulario As Integer
    Public Sub llenarCodificacionGeneral(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        codigogeneral.Text = pCodigo
        General.llenarTabla(Consultas.DETALLE_GLOSA_CODIFICACION_GENERAL_LLENAR, params, dt)
        If dt.Rows.Count > 0 Then
            nombregeneral.Text = dt.Rows(0).Item("Descripcion").ToString()
        End If
    End Sub
    Public Sub llenarDvgGlosas(numGlosa As Integer, numFactura As String, nomPaciente As String, registroNuevo As Boolean)

        Dim params, params1 As New List(Of String)
        params.Add(numGlosa)
        params.Add(numFactura)
        params.Add(codigogeneral.Text)
        params1.Add(codigogeneral.Text)
        nombrepaciente.Text = nomPaciente
        codigofactura.Text = numFactura
        codigo.Text = numGlosa
        If registroNuevo = True Then
            General.llenarTabla(Consultas.DETALLE_GLOSA_CARGAR, params1, dtDetalle)
            identificador = String.Empty
        Else
            General.llenarTabla(Consultas.DETALLE_GLOSA_CARGAR_REGISTROS, params, dtDetalle)
            identificador = codigo.Text
        End If
        dgvDetalleGlosa.DataSource = dtDetalle
        dgvDetalleGlosa.Columns(1).ReadOnly = True
        dgvDetalleGlosa.Columns(2).ReadOnly = True
        dgvDetalleGlosa.Columns(3).ReadOnly = False
        dgvDetalleGlosa.Columns(4).ReadOnly = False
        dgvDetalleGlosa.Columns(5).ReadOnly = False
        dgvDetalleGlosa.Columns(6).ReadOnly = False
        dgvDetalleGlosa.Columns(7).ReadOnly = True
        dgvDetalleGlosa.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalleGlosa.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(2).Width = 430
        dgvDetalleGlosa.Columns(7).Width = 210
        dgvDetalleGlosa.Columns(1).Width = 70
        dgvDetalleGlosa.Columns(4).Width = 300
        dgvDetalleGlosa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalleGlosa.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        For i = 0 To dgvDetalleGlosa.Columns.Count - 1 Step +1
            dgvDetalleGlosa.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        calcularValores()
        dgvDetalleGlosa.Columns("motivo_glosa").Visible = False
        dgvDetalleGlosa.Columns("responsable").Visible = False
        dgvDetalleGlosa.Columns("motivo_aceptacion").Visible = False
        dgvDetalleGlosa.Columns("Departamento").Visible = False
    End Sub

    Private Sub dgvdetalleglosa_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetalleGlosa.CellFormatting
        If e.ColumnIndex = 3 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub
    Private Sub dgvDetalleGlosa_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGlosa.CellDoubleClick
        Dim indiceFila = e.RowIndex
        Dim indiceColumna = e.ColumnIndex
        If indiceColumna = 7 Then
            ExamenLaboratorioBLL.abrirJustificacion(dgvDetalleGlosa, objDetalleGlosa.dtGlosa, Panel2, txtcomentarioHemo, "Observacion")
        ElseIf indiceColumna = 0 Then
            Dim rptAceptacionGlosa As New rptDetalleAceptacionGlosa
            Try
                Cursor = Cursors.WaitCursor
                Funciones.getReporteNoFTP(rptAceptacionGlosa, "{VISTA_ACEPTACION_GLOSA.Codigo_General} = " & codigogeneral.Text & " AND {VISTA_ACEPTACION_GLOSA.Codigo_Factura}='" & codigofactura.Text & "' AND {VISTA_ACEPTACION_GLOSA.Codigo_especifico}='" & dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentCell.RowIndex).Cells(1).Value & "' AND {VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa & "", "Motivo Glosa")
                Cursor = Cursors.Default
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default
        ElseIf indiceColumna = 2 And dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentCell.RowIndex).Cells("Valor glosa").Value > 0 Then
            Dim formPadre As New FormDetalleGlosa
            formPadre.iniciarForm(dtDetalle, dgvDetalleGlosa.CurrentCell.RowIndex)
            formPadre.ShowDialog()
        End If
    End Sub
    Private Sub dgvDetalleGlosa_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGlosa.CellClick
        Dim indiceColumna = e.ColumnIndex
        If indiceColumna = 4 Then
            Dim celda As New DataGridViewComboBoxCell
            Dim cadena As String = ""
            Dim dt = New DataTable
            If celda.Items.Count = 0 Then
                General.llenarTabla(Consultas.CODIGO_RESPUESTA_GLOSA_LLENAR, Nothing, dt)
                celda.DataSource = dt
                celda.DisplayMember = "Descripcion"
                dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(4) = celda
            End If
        End If
    End Sub
    Private Sub dgvDetalleGlosa_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGlosa.CellEndEdit
        If e.ColumnIndex = 4 Then
            dgvDetalleGlosa.EndEdit()
            dtDetalle.AcceptChanges()
            If dtDetalle.Rows(dgvDetalleGlosa.CurrentRow.Index).Item(4).ToString <> "" Then
                If dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(e.ColumnIndex).Value.ToString.Substring(0, 4) = "9.96" Or dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(e.ColumnIndex).Value.ToString.Substring(0, 4) = "9.99" Or dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(e.ColumnIndex).Value.ToString.Substring(0, 4) = "9.98" Then

                ElseIf dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(e.ColumnIndex).Value.ToString.Substring(0, 4) = "9.97" Then
                    dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(5).Value = dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(3).Value
                End If
            End If
        End If
        If IsDBNull(dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(3).Value) Then
            dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(3).Value = 0
        End If
        If IsDBNull(dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(5).Value) Then
            dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(5).Value = 0
        End If
        If IsDBNull(dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(6).Value) Then
            dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(6).Value = 0
        End If
        dgvDetalleGlosa.EndEdit()
        dtDetalle.AcceptChanges()
        calcularValores()
    End Sub
    Private Sub calcularValores()
        Dim valorGlosa, totalValorGlosa, valorGlosaAceptado, totalValorGlosaAceptado, valorGlosaDefinitiva, totalValorGlosaDefinitiva As Double
        For indice = 0 To dgvDetalleGlosa.Rows.Count - 1
            valorGlosa = CDbl(dgvDetalleGlosa.Rows(indice).Cells(3).Value)
            totalValorGlosa = totalValorGlosa + valorGlosa
            valorGlosaAceptado = CDbl(dgvDetalleGlosa.Rows(indice).Cells(5).Value)
            totalValorGlosaAceptado = totalValorGlosaAceptado + valorGlosaAceptado
            valorGlosaDefinitiva = CDbl(dgvDetalleGlosa.Rows(indice).Cells(6).Value)
            totalValorGlosaDefinitiva = valorGlosaDefinitiva + totalValorGlosaDefinitiva
        Next
        total.Text = CDbl(totalValorGlosa).ToString("C2")
        totalA.Text = CDbl(totalValorGlosaAceptado).ToString("C2")
        TotalDef.Text = CDbl(totalValorGlosaDefinitiva).ToString("C2")
    End Sub
    Private Sub txtcomentarioHemo_Leave(sender As Object, e As EventArgs) Handles txtcomentarioHemo.Leave
        Try
            If Panel2.Visible = True Then
                Panel2.Visible = False
                dgvDetalleGlosa.Rows(dgvDetalleGlosa.CurrentRow.Index).Cells(7).Value = txtcomentarioHemo.Text
                dgvDetalleGlosa.EndEdit()
                objDetalleGlosa.dtGlosa.AcceptChanges()
                txtcomentarioHemo.Clear()
            End If
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Private Sub dgvDetalleGlosa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvDetalleGlosa.KeyPress
        If btguardar.Enabled = False Then Exit Sub
        ExamenLaboratorioBLL.abrirJustificacion(dgvDetalleGlosa, objDetalleGlosa.dtGlosa, Panel2, txtcomentarioHemo, "Observacion")
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click

        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            txtcomentarioHemo_Leave(sender, e)
            dgvDetalleGlosa.EndEdit()
            dtDetalle.AcceptChanges()
            Dim objDetalleGlosaBll As New DetalleGlosaBLL
            Try
                objDetalleGlosa.sumaTotalGlosas = total.Text
                objDetalleGlosa.sumaTotalGlosaAceptada = totalA.Text
                objDetalleGlosaBll.guardarDetalleGlosa(crearDetalleGlosa())
                If formulario = 1 Then
                    objFormDevolucion.dgvGlosas.Rows(objFormDevolucion.dgvGlosas.CurrentRow.Index).Cells(objFormDevolucion.dgvGlosas.CurrentCell.ColumnIndex).Value = objDetalleGlosa.sumaTotalGlosas
                    objFormDevolucion.dgvGlosas.Rows(objFormDevolucion.dgvGlosas.CurrentRow.Index).Cells(objFormDevolucion.dgvGlosas.CurrentCell.ColumnIndex + 1).Value = objDetalleGlosa.sumaTotalGlosaAceptada
                    objFormDevolucion.dgvGlosas.EndEdit()
                    objFormDevolucion.objDetalleGlosa = objDetalleGlosa
                    objFormDevolucion.guardarDesdeGlosaDetalle()
                Else
                    objFormNotificacion.dgvGlosas.Rows(objFormNotificacion.dgvGlosas.CurrentRow.Index).Cells(objFormNotificacion.dgvGlosas.CurrentCell.ColumnIndex).Value = objDetalleGlosa.sumaTotalGlosas
                    objFormNotificacion.dgvGlosas.Rows(objFormNotificacion.dgvGlosas.CurrentRow.Index).Cells(objFormNotificacion.dgvGlosas.CurrentCell.ColumnIndex + 16).Value = objDetalleGlosa.sumaTotalGlosaAceptada
                    objFormNotificacion.dgvGlosas.EndEdit()
                    objFormNotificacion.objDetalleGlosa = objDetalleGlosa
                    objFormNotificacion.guardarDesdeGlosaDetalle()
                End If

                btguardar.Enabled = False
                Me.Close()
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Function crearDetalleGlosa() As DetalleGlosa
        Dim objDetalleGlosa As New DetalleGlosa
        objDetalleGlosa.identificador = identificador
        For Each drFila As DataRow In dtDetalle.Rows
            'If drFila.Item("Valor Glosa").ToString <> 0 Then
            Dim drCuenta As DataRow = objDetalleGlosa.dtGlosa.NewRow
                drCuenta.Item("Codigo_Glosa") = codigo.Text
                drCuenta.Item("Codigo_factura") = codigofactura.Text
                drCuenta.Item("Codigo_general") = codigogeneral.Text
                drCuenta.Item("Codigo_especifico") = drFila.Item("Codigo Específico")
                drCuenta.Item("Valor") = drFila.Item("Valor Glosa")
                drCuenta.Item("codigo_respuesta") = drFila.Item("Codigo de respuesta").Substring(2, 3)
                drCuenta.Item("valor_Aceptado") = drFila.Item("Valor Glosa Aceptada")
                drCuenta.Item("valor_definitiva") = drFila.Item("Valor definitiva")
                drCuenta.Item("observacion") = drFila.Item("Observacion")
                drCuenta.Item("motivo_glosa") = drFila.Item("motivo_glosa")
                drCuenta.Item("responsable") = drFila.Item("responsable")
                drCuenta.Item("motivo_aceptacion") = drFila.Item("motivo_aceptacion")
                drCuenta.Item("Departamento") = drFila.Item("Departamento")
                objDetalleGlosa.dtGlosa.Rows.Add(drCuenta)
            'End If
        Next
        Return objDetalleGlosa
    End Function
    Private Sub dgvDetalleGlosa_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetalleGlosa.DataError
        'siempre hay que poner este evento para que no se totee
    End Sub

    Private Sub FormGlosaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btguardar.Enabled = True
    End Sub

    Private Sub dgvDetalleGlosa_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvDetalleGlosa.EditingControlShowing
        If dgvDetalleGlosa.CurrentCell.ColumnIndex = 3 Or dgvDetalleGlosa.CurrentCell.ColumnIndex = 5 Or dgvDetalleGlosa.CurrentCell.ColumnIndex = 6 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub
End Class