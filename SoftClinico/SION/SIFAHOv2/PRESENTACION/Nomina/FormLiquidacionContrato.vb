Public Class FormLiquidacionContrato
    Dim dtLiquidacion As New DataTable
    Dim dgvAsignada As New BindingSource
    Dim comprobante As Boolean
    Dim reporte As New ftp_reportes
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_empleado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Public Sub llenarDgvLiquidacion()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        comprobante = True
        General.llenarTabla(Consultas.LIQUIDACION_LISTAR, params, dtLiquidacion)
        If dtLiquidacion.Rows.Count > 0 Then
            dgvLiquidacion.DataSource = dtLiquidacion
            dgvAsignada.DataSource = dtLiquidacion
            dgvLiquidacion.ReadOnly = True
            dgvLiquidacion.Columns(0).Width = 70
            dgvLiquidacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvLiquidacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvLiquidacion.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(8).Visible = False
            dgvLiquidacion.Columns(9).Visible = False
            dgvLiquidacion.Columns(10).Visible = False
            dgvLiquidacion.Columns(11).Visible = False
            dgvLiquidacion.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            dgvLiquidacion.Columns(15).Visible = False
            dgvLiquidacion.Columns(14).Visible = True
            dgvLiquidacion.Columns(14).HeaderText = "Seleccionar"
            checkTodos.Visible = True
            checkTodos.Enabled = True
            Textfiltro.ReadOnly = False
        End If
    End Sub
    Public Sub cargarDgvLiquidacion(ByVal fecha As Date)
        Dim params As New List(Of String)
        params.Add(fecha)
        fechaLiq.Value = fecha
        comprobante = True
        General.llenarTabla(Consultas.LIQUIDACION_CARGAR, params, dtLiquidacion)
        If dtLiquidacion.Rows.Count > 0 Then
            dgvLiquidacion.DataSource = dtLiquidacion
            dgvLiquidacion.ReadOnly = True
            dgvLiquidacion.Columns(0).Width = 70
            dgvLiquidacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvLiquidacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvLiquidacion.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvLiquidacion.Columns(8).Visible = False
            dgvLiquidacion.Columns(9).Visible = False
            dgvLiquidacion.Columns(10).Visible = False
            dgvLiquidacion.Columns(11).Visible = False
            dgvLiquidacion.Columns(14).HeaderText = "Seleccionar"
            dgvLiquidacion.Columns(14).Visible = True
            dgvLiquidacion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            Textfiltro.ReadOnly = False
            checkTodos.Visible = True
            checkTodos.Enabled = True
            fechaLiq.Enabled = True
            General.habilitarBotones(ToolStrip1)
            btguardar.Enabled = False
            btcancelar.Enabled = False
        End If
    End Sub
    Private Sub Textfiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles Textfiltro.TextChanged
        dgvAsignada.Filter = "[Empleado] LIKE '%" + Textfiltro.Text.Trim() + "%'"
    End Sub
    Private Sub dgvLiquidacion_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvLiquidacion.CellFormatting
        Dim posicion As Integer = e.ColumnIndex
        If posicion <> 0 And posicion <> 1 And posicion <> 2 And posicion <> 3 And posicion <> 4 And posicion <> 14 And posicion <> 15 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(2)
        params.Add("")
        General.buscarElemento(Consultas.LIQUIDACION_BUSCAR,
                               params,
                               AddressOf cargarDgvLiquidacion,
                               TitulosForm.BUSQUEDA_LIQUIDACIONES,
                               False, 0, True)
    End Sub
    Private Sub dgvLiquidacion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLiquidacion.CellEnter
        If comprobante = True Then
            dgvLiquidacion.ReadOnly = False
            dgvLiquidacion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = If(Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Liquidar", dgvLiquidacion) = False, True, False)
            dgvLiquidacion.EndEdit()
        End If
    End Sub
    Public Function crearLiquidacion() As LiquidacionContrato
        Dim objLiquidacionContrato As New LiquidacionContrato
        Dim filas As DataRow()
        objLiquidacionContrato.dtLiquidacion.Clear()
        filas = dtLiquidacion.Select("Liquidar ='True'", "")
        objLiquidacionContrato.idEmpresa = SesionActual.idEmpresa
        objLiquidacionContrato.codigoDocumento = Constantes.COMPROBANTE_DE_CAUSACION
        objLiquidacionContrato.fecha = fechaLiq.Value
        objLiquidacionContrato.usuario = SesionActual.idUsuario

        For Each fila As DataRow In filas
            objLiquidacionContrato.dtLiquidacion.ImportRow(fila)
        Next
        objLiquidacionContrato.llenarCuentas()
        Return objLiquidacionContrato
    End Function
    Private Sub checkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles checkTodos.CheckedChanged
        If checkTodos.Checked = True Then
            For indice = 0 To dgvLiquidacion.Rows.Count - 1
                dgvLiquidacion.Rows(indice).Cells(14).Value = True
            Next
        Else
            For indice = 0 To dgvLiquidacion.Rows.Count - 1
                dgvLiquidacion.Rows(indice).Cells(14).Value = False
            Next
        End If
        dtLiquidacion.AcceptChanges()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objLiquidacionContrato_D As New LiquidacionContratoBLL
            Try
                dgvLiquidacion.EndEdit()
                dtLiquidacion.AcceptChanges()
                objLiquidacionContrato_D.guardarLiquidacionContrato(crearLiquidacion())
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                cargarDgvLiquidacion(fechaLiq.Value)
                imprimirReporte()
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub imprimirReporte()
        Try
            Dim rpt As New rptLiquidacion
            Try
                Cursor = Cursors.WaitCursor
                Funciones.getReporteNoFTP(rpt, "{VISTA_LIQUIDACION.fecha_creacion} = '" & Format(fechaLiq.Value.Date, "yyyy-MM-dd") & "'", ConstantesHC.NOMBRE_PDF_LIQUIDACION)
                Cursor = Cursors.Default
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    'Private Sub primerSem_CheckedChanged(sender As Object, e As EventArgs)
    '    Dim fechaInicio As Date = "01-01-" & Now.Year
    '    Dim fechaFin As Date = "30-06-" & Now.Year
    'End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        checkTodos.Visible = False
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        llenarDgvLiquidacion()
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        Textfiltro.Focus()
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimirReporte()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        Try

            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    dgvLiquidacion.EndEdit()
                    dtLiquidacion.AcceptChanges()
                    Dim filas As DataRow()
                    filas = dtLiquidacion.Select("Liquidar ='True'", "")

                    For Each fila As DataRow In filas
                        respuesta = General.anularRegistro(Consultas.LIQUIDACION_ANULAR & SesionActual.idUsuario & "," & fila.Item(0).ToString & "")
                    Next

                    If respuesta = True Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    cargarDgvLiquidacion(fechaLiq.Value)
                End If
                End If

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

End Class