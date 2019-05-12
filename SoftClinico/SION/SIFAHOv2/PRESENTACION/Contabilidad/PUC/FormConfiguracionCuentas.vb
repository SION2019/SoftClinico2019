Public Class FormConfiguracionCuentas
    Dim dgvAsignada As New BindingSource
    Dim dtCuentas As New DataTable
    Private Sub Textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextFiltro.TextChanged
        dgvAsignada.Filter = "[Cuenta] LIKE '" + TextFiltro.Text.Trim() + "%' or [Nombre] LIKE '%" + TextFiltro.Text.Trim() + "%'"
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub cargarCuentas()
        Dim params As New List(Of String)
        params.Add(FuncionesContables.obtenerPucActivo)
        General.llenarTabla(Consultas.CUENTAS_PUC_LISTAR, params, dtCuentas)
        dgvAsignada.DataSource = dtCuentas
        dgvcuentas.DataSource = dgvAsignada
        dgvcuentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvcuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvcuentas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvcuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub
    Private Sub bloquearColumnas()
        With dgvcuentas
            .Columns("Cuenta").ReadOnly = True
            .Columns("Nombre").ReadOnly = False
        End With
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        cargarCuentas()
        bloquearColumnas()
    End Sub

    Private Sub FormConfiguracionCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        General.cargarCombo(Consultas.INFORMES_DIAN_LISTAR, "Descripción", "Código", comboInforme)
    End Sub

    Private Sub comboInforme_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboInforme.SelectedValueChanged
        If comboInforme.SelectedIndex > 0 Then
            General.cargarCombo(Consultas.CONCEPTOS_DIAN_LISTAR & "'" & comboInforme.SelectedValue & "'", "Descripción", "Código", ComboConcepto)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        bloquearColumnas()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Public Function crearConfiguracion() As ConfiguracionConceptosDian
        Dim objConcepto As New ConfiguracionConceptosDian
        Dim filas As DataRow()
        objConcepto.dtCuentas.Clear()
        objConcepto.codigoConcepto = ComboConcepto.SelectedValue
        filas = dtCuentas.Select("Seleccionar ='True'", "")
        For Each drFila As DataRow In dtCuentas.Rows
            If drFila.Item("Seleccionar") = True Then
                Dim drCuenta As DataRow = objConcepto.dtCuentas.NewRow
                drCuenta.Item("Concepto") = ComboConcepto.SelectedValue
                drCuenta.Item("Cuenta") = drFila.Item("Cuenta")
                drCuenta.Item("Iva") = drFila.Item("Registra Iva")
                drCuenta.Item("Retencion.Prac") = drFila.Item("Retencion.Prac")
                drCuenta.Item("Retencion.Asum") = drFila.Item("Retencion.Asum")
                drCuenta.Item("IngPropios") = drFila.Item("Ingresos.Propios")
                drCuenta.Item("IngPorConsorcios") = drFila.Item("Ingresos Por Consorcios")
                drCuenta.Item("Devolucion") = drFila.Item("Devolucion")
                objConcepto.dtCuentas.Rows.Add(drCuenta)
            End If
        Next
        Return objConcepto
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objConceptos_D As New ConfiguracionConceptosDianBLL
                Try
                    dgvcuentas.EndEdit()
                    dtCuentas.AcceptChanges()
                    objConceptos_D.guardarConcepto(crearConfiguracion())
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    cargarDatos()
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Function validarInformacion()
        If comboInforme.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el Informe que desea configurar!", MsgBoxStyle.Exclamation)
            comboInforme.Focus()
            Return False
        ElseIf ComboConcepto.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el Concepto que desea configurar!", MsgBoxStyle.Exclamation)
            ComboConcepto.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub cargarDatos()
        Dim params As New List(Of String)
        params.Add(ComboConcepto.SelectedValue)
        General.llenarTabla(Consultas.CONFIGURACION_CONCEPTOS_CARGAR, params, dtCuentas)
        dgvAsignada.DataSource = dtCuentas
        dgvcuentas.DataSource = dtCuentas
        dgvcuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvcuentas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvcuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        TextFiltro.ReadOnly = False
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim tbl As DataRow = Nothing
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.CONFIGURACION_CONCEPTOS_BUSCAR, Nothing, TitulosForm.BUSQUEDA_CONFIGURACION_AUDITORIA, False)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            General.habilitarBotones(ToolStrip1)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            comboInforme.SelectedValue = tbl(0)
            ComboConcepto.SelectedValue = tbl(1)
            cargarDatos()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ChTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChTodos.CheckedChanged
        If ChTodos.Checked = True Then
            For indice = 0 To dgvcuentas.Rows.Count - 1
                dgvcuentas.Rows(indice).Cells("Seleccionar").Value = True
            Next
        Else
            For indice = 0 To dgvcuentas.Rows.Count - 1
                dgvcuentas.Rows(indice).Cells("Seleccionar").Value = False
            Next
        End If
        dtCuentas.AcceptChanges()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        FormPYG.MdiParent = FormPrincipal
        General.cargarForm(FormPYG)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        Try

            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.CONFIGURACION_CONCEPTOS_ANULAR & "'" & ComboConcepto.SelectedValue & "'")

                If respuesta = True Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                End If
            End If
        Catch ex As Exception
        General.manejoErrores(ex)
        End Try
    End Sub
End Class