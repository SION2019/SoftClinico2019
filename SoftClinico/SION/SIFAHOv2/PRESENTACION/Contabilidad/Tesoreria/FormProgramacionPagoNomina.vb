Public Class FormProgramacionPagoNomina
    Dim dtProgramacion As New DataTable
    Dim totalEmpleados, total, totalAbono, responsable As New StatusBarPanel()
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Plinea, Pcualidad, Pgrupo, Pprese, Pviaadmin As String
    Dim dgvAsignada As New BindingSource
    Public Property objformaPago As FormFormaPago
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormProgramacionPagoNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        inicializarBarra()

    End Sub

    Private Sub Form_programacionPagoNominaClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvEmpleados_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvEmpleados.CellFormatting
        If e.ColumnIndex = 6 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If

    End Sub
    Private Sub Textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles Textdescripcion.TextChanged
        dgvAsignada.Filter = "[Empleado] LIKE '%" + Textdescripcion.Text.Trim() + "%'"
    End Sub
    Private Sub dgvEmpleados_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpleados.CellDoubleClick
        If btcancelar.Enabled AndAlso e.RowIndex >= 0 AndAlso e.ColumnIndex = 7 Then
            Dim objFormFormaPago As New FormFormaPago
            objFormFormaPago.MdiParent = FormPrincipal
            objFormFormaPago.objFormProgramacionNomina = Me
            objFormFormaPago.Show()
        End If
    End Sub


    'Private Sub dgvEmpleados_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpleados.CellContentClick
    '    If e.RowIndex = -1 OrElse e.ColumnIndex = -1 Then Return
    '    If dgvEmpleados.Columns(e.ColumnIndex).Name = colSeleccion.Name Then
    '        If dgvEmpleados.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> 0 Then
    '            dgvEmpleados.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
    '            dgvEmpleados.Rows(e.RowIndex).Cells(colAbono.Name).Value = ""
    '        Else
    '            dgvEmpleados.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
    '            dgvEmpleados.Rows(e.RowIndex).Cells(colAbono.Name).Value = dgvEmpleados.Rows(e.RowIndex).Cells(colSubtotal.Name).Value
    '        End If
    '        calcularTotales()
    '    End If
    'End Sub
    Private Sub dgvEmpleados_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpleados.CellEndEdit
        'If Not IsNumeric(dgvEmpleados.CurrentCell.Value) OrElse dgvEmpleados.CurrentCell.Value = 0 Then
        '    dgvEmpleados.CurrentCell.Value = ""
        '    dgvEmpleados.CurrentRow.Cells(colSeleccion.Name).Value = 0
        'Else
        '    If dgvEmpleados.Rows(e.RowIndex).Cells(colAbono.Name).Value >= dgvEmpleados.Rows(e.RowIndex).Cells(colSubtotal.Name).Value Then
        '        dgvEmpleados.Rows(e.RowIndex).Cells(colAbono.Name).Value = dgvEmpleados.Rows(e.RowIndex).Cells(colSubtotal.Name).Value
        '        dgvEmpleados.CurrentRow.Cells(colSeleccion.Name).Value = 1
        '    Else
        '        dgvEmpleados.CurrentRow.Cells(colSeleccion.Name).Value = 2
        '    End If
        'End If
        calcularTotales()
    End Sub
    Private Sub inicializarBarra()
        responsable.AutoSize = 2
        totalEmpleados.AutoSize = 3
        totalEmpleados.BorderStyle = 2
        total.AutoSize = 3
        totalAbono.AutoSize = 3
        StatusBar1.Panels.Clear()
        StatusBar1.Panels.Add(responsable)
        StatusBar1.Panels.Add(totalEmpleados)
        StatusBar1.Panels.Add(total)
        StatusBar1.Panels.Add(totalAbono)
        limpiarPaneles()
    End Sub
    Sub limpiarPaneles()
        totalEmpleados.Text = " Empleados: 0  "
        total.Text = " Total: $ 0,00 "
        totalAbono.Text = " T. Abono: $ 0,00 "
    End Sub
    Public Function crearProgramacionPago() As ProgramacionPagoNomina
        Dim objProgramacionPago As New ProgramacionPagoNomina
        Dim filas As DataRow()
        objProgramacionPago.dtProgramacion.Clear()
        filas = dtProgramacion.Select("Pago = True and subTotal <> 0", "")
        objProgramacionPago.idEmpresa = SesionActual.idEmpresa
        objProgramacionPago.codigoDocumento = Constantes.COMPROBANTE_DE_EGRESO
        objProgramacionPago.fecha = fecha_doc.Value
        objProgramacionPago.nomina = textnomina.Text
        objProgramacionPago.usuario = SesionActual.idUsuario
        objProgramacionPago.dtProgramacion = dtProgramacion.Clone
        For Each fila As DataRow In filas
            objProgramacionPago.dtProgramacion.ImportRow(fila)
        Next
        objProgramacionPago.llenarCuentas()
        Return objProgramacionPago
    End Function
    Sub mostrarInfo(pSmg As String, pColorFuenteLetra As Color, pColorFondoPanel As Color, Optional pOcultar As Boolean = False)
        If InvokeRequired Then
            Invoke(New MethodInvoker(Sub() mostrarInfo(pSmg, pColorFuenteLetra, pColorFondoPanel, pOcultar)))
        Else
            If pOcultar Then
                PnlInfo.Visible = False
            Else
                lbinfo.Text = pSmg.ToUpper : lbinfo.ForeColor = pColorFuenteLetra : PictureBox2.Image = My.Resources.Gifs_ANimados_Señalas_Viales__31_
                PnlInfo.BackColor = pColorFondoPanel : PnlInfo.BringToFront() : PnlInfo.Visible = True

            End If
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If FuncionesContables.verificarFecha(fecha_doc.Value) Then
            mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objProgramacionPagoNominaBLL As New ProgramacionPagoNominaBLL
                Try
                    dgvEmpleados.EndEdit()
                    dtProgramacion.AcceptChanges()
                    objProgramacionPagoNominaBLL.guardarProgramacionPagoNomina(crearProgramacionPago())
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvcuentas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvEmpleados.EditingControlShowing,
            dgvEmpleados.EditingControlShowing
        If dgvEmpleados.CurrentCell.OwningColumn.Name = colAbono.Name Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub
    Private Sub dgvEmpleados_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvEmpleados.DataError

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            params.Add("")
            General.buscarElemento(ConsultasNom.PROGRAMACION_NOMINA_BUSCAR,
                                   params,
                                   AddressOf cargarDgvEmpleados,
                                   TitulosForm.BUSQUEDA_NOMINA,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub llenarCausacion(pCodigo As String)
        Dim drNomina As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drNomina = General.cargarItem(ConsultasNom.PROGRAMACION_NOM_CARGAR, params)
        Txtcodigo.Text = pCodigo
        textnomina.Text = drNomina.Item("Codigo_Nomina").ToString
        FechaCorte.Value = drNomina.Item("Fecha_Creacion").ToString
        fecha_doc.Value = drNomina.Item("Fecha_Doc").ToString
    End Sub
    Private Sub cargarDgvEmpleados(codigo As String)
        Dim dtNomina As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        llenarCausacion(codigo)
        General.llenarTabla(ConsultasNom.PROGRAMACION_NOMINA_CARGAR, params, dtNomina)
        dgvAsignada.DataSource = dtNomina
        dgvEmpleados.DataSource = dtNomina
        dgvEmpleados.Columns("colSeleccion").Visible = False
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False
        If dgvEmpleados.RowCount > 0 Then
            dgvEmpleados.ClearSelection()
            calcularTotales()
            totalEmpleados.Text = " Empleados: " & dgvEmpleados.RowCount & "  "
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click

    End Sub

    Sub calcularTotales()
        Dim valorAbono As Double = 0
        For Each filaDgvEmpleados As DataGridViewRow In dgvEmpleados.Rows
            If IsNumeric(filaDgvEmpleados.Cells(colAbono.Name).Value) Then valorAbono += filaDgvEmpleados.Cells(colAbono.Name).Value
        Next
        totalAbono.Text = " T. Abono: " & valorAbono.ToString("C2") & " "
        'diferencia.Text = " Diferencia: " & (CDbl(total.Text.Replace("(", "-").Replace(")", "").Replace("Total: $", "").Replace("Total: -$", "-").Replace("- ", "-")) - valorAbono).ToString("C2") & " "
        btguardar.Enabled = (Txtcodigo.Text = "" And Fix(valorAbono) > 0) Or (Txtcodigo.Text <> "" And btcancelar.Enabled = True)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(Pnuevo) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            params.Add("")
            General.buscarElemento(ConsultasNom.NOMINA_CAUSADA_BUSCAR,
                                 params,
                                 AddressOf cargarNomina,
                                 TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
                                 False)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Function validarCuentas() As Boolean
        For Each filas As DataGridViewRow In dgvEmpleados.Rows
            If filas.Cells(colSeleccion.Name).Value > 0 AndAlso filas.Cells(colNombreCuenta.Name).Value.ToString.Trim = "" Then
                MsgBox("Por favor coloque la forma de pago para el empleado " & filas.Cells(colEmpleado.Name).Value.ToString & ", comprobante " & filas.Cells(colComprobante.Name).Value.ToString & ".", MsgBoxStyle.Exclamation, "Atencion")
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub cargarCodigoNomina(pCodigo)
        Dim drNomina As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drNomina = General.cargarItem("PROC_CODIGO_NOMINA_CAUSADA_CARGAR", params)
        textnomina.Text = drNomina.Item("Codigo_Nomina").ToString
    End Sub
    Private Sub cargarNomina(codigo As String)
        Dim params As New List(Of String)
        params.Add(codigo)
        cargarCodigoNomina(codigo)
        General.llenarTabla(ConsultasNom.NOMINA_CAUSADA_CARGAR, params, dtProgramacion)
        dgvAsignada.DataSource = dtProgramacion
        dgvEmpleados.DataSource = dtProgramacion
        dgvEmpleados.Columns("colAbono").ReadOnly = False
        dgvEmpleados.Columns("colSeleccion").Visible = True
        For indice = 0 To dtProgramacion.Rows.Count - 1
            If dtProgramacion.Rows(indice).Item("Pago") = True Then
                dtProgramacion.Rows(indice).Item("Seleccionar") = True
                dtProgramacion.Rows(indice).Item("Abono") = dtProgramacion.Rows(indice).Item("Subtotal")
            End If
        Next
        PnlInfo.Visible = False
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        If dgvEmpleados.RowCount > 0 Then
            dgvEmpleados.ClearSelection()
            totalEmpleados.Text = " Empleados: " & dgvEmpleados.RowCount & "  "
        End If
    End Sub
End Class