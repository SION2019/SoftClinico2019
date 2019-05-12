Imports System.Data.SqlClient
Public Class form_eps
    Dim cmd As New EpsBLL
    Public buscar_eps As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pconfiguracion As String
    Public comboeps As ComboBox
    Dim dtConfiguracion As DataTable
    Dim codigoGrupo As Integer
    Public Property objFormRips As New FormRips
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pconfiguracion = permiso_general & "pp" & "05"
        llenarCombo()
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        deshabilitarControles()
        dtConfiguracion = New DataTable
        dtConfiguracion.Columns.Add("Codigo")
        dtConfiguracion.Columns.Add("id_tercero")
        General.cargarCombo(Consultas.RIPS_FORMATO_CARGAR, "Descripcion", "Codigo_grupo", cbFormato)

    End Sub

    Public Sub deshabilitarControles()
        cbFormato.Enabled = False
        Textestancia.Enabled = False
        ComboFormato.Enabled = False
        rgeneral.Enabled = False
        rpersonalizado.Enabled = False
    End Sub
    Public Sub generarArchivos(ByRef pElemento As Object)
        'Recorrer checkbox del groupbox que contienen los archivos checkeados

        For Each vItem In pElemento.Controls
            If (TypeOf vItem Is CheckBox) AndAlso (vItem.checked = True) AndAlso (vItem.tag <> -1) Then
                dtConfiguracion.Rows.Add(vItem.tag)
            ElseIf (TypeOf vItem Is GroupBox) Or (vItem.hasChildren) Then
                generarArchivos(vItem)
            End If
        Next
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los documentos y actualiza: 
        'Autor: POSEIDON
        'fecha_creacion: 31/05/2016

        If String.IsNullOrWhiteSpace(txtnombre.Text) Then
            Exec.SavingMsg("¡ Por favor digite el nombre de la eps !", txtnombre)
        Else
            Try
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    generarArchivos(gbTipoArchivos)
                    codigoGrupo = cbFormato.SelectedValue
                    If cmd.guardar_eps(txtcodigo.Text, txtnombre.Text, Textcodigo_eps.Text, ComboFormato.SelectedValue, Textestancia.Value, dtConfiguracion, codigoGrupo) = True Then
                        General.deshabilitarBotones(ToolStrip1)
                        General.deshabilitarControles(Me)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        bteditar.Enabled = True
                        btanular.Enabled = True
                        If Not IsNothing(comboeps) Then
                            General.cargarCombo(Consultas.EPS_LISTAR, "Nombre", "Código", comboeps)
                        End If
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        dtConfiguracion.Clear()
                        objFormRips.cargarConfiguracion()
                        objFormRips.txtcodigogrupo.Text = cbFormato.SelectedValue
                        objFormRips.txtnombreformato.Text = cbFormato.Text
                    End If
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: POSEIDON
        'fecha_creacion: 31/05/2016
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    If cmd.anular_eps(txtcodigo.Text) = True Then
                        General.deshabilitarBotones(ToolStrip1)
                        General.deshabilitarControles(Me)
                        General.limpiarControles(Me)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click

        General.deshabilitarBotones(ToolStrip1)
        ComboFormato.Enabled = True
        Textestancia.Enabled = True
        btcancelar.Enabled = True '--Cancelar--
        btguardar.Enabled = True '--Guardar--
        cbFormato.Enabled = True
        General.habilitarControles(Me)

        txtnombre.ReadOnly = True
        Textcodigo_eps.ReadOnly = True

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        rgeneral.Checked = True
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click

        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Nothing)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.EPS_LISTAR, params, TitulosForm.BUSQUEDA_EPS, True, 0, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            Try
                txtcodigo.Text = tbl(0)
                cargar()
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                lipiarCheck()
                cargarConfiguracion()
                epsConfiguracionCargar()
                btcancelar.Enabled = False
                ComboFormato.Enabled = False
                Textestancia.Enabled = False
                If cbFormato.SelectedValue = 0 Then
                    rgeneral.Checked = True
                Else
                    rpersonalizado.Checked = True
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Public Sub epsConfiguracionCargar()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtcodigo.Text)
        General.llenarTabla(Consultas.EPS_RIPS_CONFIGURACION_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            cbFormato.SelectedValue = dt.Rows(0).Item("Codigo_grupo").ToString
        End If

    End Sub

    Public Sub lipiarCheck()
        af.Checked = False
        ac.Checked = False
        at.Checked = False
        us.Checked = False
        au.Checked = False
        an.Checked = False
        ah.Checked = False
        ad.Checked = False
        ct.Checked = False
        am.Checked = False
        ap.Checked = False
    End Sub
    Private Sub rpersonalizado_CheckedChanged(sender As Object, e As EventArgs) Handles rpersonalizado.CheckedChanged
        cargarConfiguracion()
        If btguardar.Enabled = True Then
            habilitarCheck()
        End If
    End Sub

    Public Sub habilitarCheck()
        af.Enabled = True
        ac.Enabled = True
        at.Enabled = True
        us.Enabled = True
        au.Enabled = True
        an.Enabled = True
        ah.Enabled = True
        ad.Enabled = True
        ct.Enabled = True
        am.Enabled = True
        ap.Enabled = True
    End Sub
    Public Sub deshabilitarCheck()
        af.Enabled = False
        ac.Enabled = False
        at.Enabled = False
        us.Enabled = False
        au.Enabled = False
        an.Enabled = False
        ah.Enabled = False
        ad.Enabled = False
        ct.Enabled = False
        am.Enabled = False
        ap.Enabled = False
    End Sub
    Private Sub rgeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rgeneral.CheckedChanged
        If rgeneral.Checked = True Then
            deshabilitarCheck()
            ct.Checked = True
            af.Checked = True
            us.Checked = True
            ac.Checked = True
            ap.Checked = True
            ah.Checked = True
            am.Checked = True
            at.Checked = True
        End If
    End Sub

    Public Sub cargarConfiguracion()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtcodigo.Text)
        General.llenarTabla(Consultas.EPS_CONFIGURACION_RIPS, params, dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("Codigo_tipo_rip").ToString = 0 Then
                    am.Checked = True
                ElseIf dt.Rows(i).Item("Codigo_tipo_rip").ToString = 1 Then
                    af.Checked = True
                ElseIf dt.Rows(i).Item("Codigo_tipo_rip").ToString = 2 Then
                    us.Checked = True
                ElseIf dt.Rows(i).Item("Codigo_tipo_rip").ToString = 3 Then
                    ac.Checked = True
                ElseIf dt.Rows(i).Item("Codigo_tipo_rip").ToString = 4 Then
                    ap.Checked = True
                ElseIf dt.Rows(i).Item("Codigo_tipo_rip").ToString = 5 Then
                    ah.Checked = True
                ElseIf dt.Rows(i).Item("Codigo_tipo_rip").ToString = 6 Then
                    at.Checked = True
                End If
            Next
        End If
    End Sub

    Private Sub btOpcionFormato_Click(sender As Object, e As EventArgs) Handles btOpcionFormato.Click
        Dim formrips As New FormConfiguracionRips
        FormPrincipal.Cursor = Cursors.WaitCursor

        General.limpiarControles(formrips)
        formrips.ShowDialog()
        formrips.Focus()
        If formrips.WindowState = FormWindowState.Minimized Then
            formrips.WindowState = FormWindowState.Normal
        End If
        FormPrincipal.Cursor = Cursors.Default
    End Sub

    Private Sub cargar()
        Dim dt As New DataTable
        General.llenarTablaYdgv("[PROC_EPS_CARGAR] " & txtcodigo.Text, dt)
        txtnombre.Text = dt.Rows(0).Item("Nombre_EPS")
        Textcodigo_eps.Text = dt.Rows(0).Item("Codigo_EPS")
        ComboFormato.SelectedValue = dt.Rows(0).Item("Codigo_Reporte")
        Textestancia.Text = If(IsDBNull(dt.Rows(0).Item("Estancia")), 0, dt.Rows(0).Item("Estancia"))
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Public Sub llenarCombo()
        ComboFormato.Items.Clear()
        ComboFormato.DataSource = Nothing
        ComboFormato.DataSource = cmd.cargarComboFormato
        ComboFormato.DisplayMember = "Nombre"
        ComboFormato.ValueMember = "Codigo"
    End Sub
End Class