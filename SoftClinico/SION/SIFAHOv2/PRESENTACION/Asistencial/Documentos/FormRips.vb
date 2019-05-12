Imports System.IO
Public Class FormRips
    Public objRips As New Rips

    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, Pconfiguracion As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btbuscarl_Click(sender As Object, e As EventArgs) Handles btbuscarl.Click
        If objRips.Modulo = Constantes.CODIGO_MENU_ASIS Then
            General.buscarElemento(Consultas.RIPS_EPS_BUSCAR,
                         Nothing,
                         AddressOf cargar,
                         TitulosForm.BUSQUEDA_EPS,
                         True, 0, True)
            validarNumeroAutorizacion()
        Else
            General.buscarElemento(Consultas.RIPS_AMBULANCIA_EPS_BUSCAR,
                         Nothing,
                         AddressOf cargarAm,
                         TitulosForm.BUSQUEDA_EPS,
                         True, 0, True)
            validarNumeroAutorizacion()
        End If
    End Sub

    Public Sub cargar(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.RIPS_EPS_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txteps.Text = dt.Rows(0).Item("eps")
            txtidtercero.Text = pCodigo
            txttelefono.Text = dt.Rows(0).Item("telefono1")
            txtciudad.Text = dt.Rows(0).Item("ciudad")
            txtnit.Text = dt.Rows(0).Item("nit")
            txtdireccion.Text = dt.Rows(0).Item("direccion")
            txtdv.Text = dt.Rows(0).Item("dv")
            txtcodigoeps.Text = dt.Rows(0).Item("codigo_eps")
            objRips.idEPS = pCodigo
            objRips.dtFactura.Clear()
            objRips.dtNew.Clear()
        End If
        epsConfiguracionCargar()
        cargarConfiguracion()
        caragrFacturas()
        dgvRips.Columns("codigo factura").ReadOnly = True
        dgvRips.Columns("paciente").ReadOnly = True
        dgvRips.Columns("fecha factura").ReadOnly = True
        dgvRips.Columns("valor factura").ReadOnly = True
        dgvRips.Columns("agregar").ReadOnly = False
        If (txtcodigoeps.Text = Constantes.CODIGO_EPS_MED Or txtcodigoeps.Text = Constantes.CODIGO_EPS_MEDIMAS) Then
            tt.Visible = True
        Else
            tt.Visible = False
        End If
    End Sub

    Public Sub cargarAm(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.RIPS_EPS_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txteps.Text = dt.Rows(0).Item("eps")
            txtidtercero.Text = pCodigo
            txttelefono.Text = dt.Rows(0).Item("telefono1")
            txtciudad.Text = dt.Rows(0).Item("ciudad")
            txtnit.Text = dt.Rows(0).Item("nit")
            txtdireccion.Text = dt.Rows(0).Item("direccion")
            txtdv.Text = dt.Rows(0).Item("dv")
            txtcodigoeps.Text = dt.Rows(0).Item("codigo_eps")
            objRips.dtFactura.Clear()
            objRips.dtNew.Clear()
        End If
        epsConfiguracionCargar()
        caragrFacturas()
        dgvRips.Columns("codigo factura").ReadOnly = True
        dgvRips.Columns("paciente").ReadOnly = True
        dgvRips.Columns("fecha factura").ReadOnly = True
        dgvRips.Columns("valor factura").ReadOnly = True
        dgvRips.Columns("agregar").ReadOnly = False
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
    Private Sub FormRips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tag.modulo
        objRips.Modulo = Tag.modulo
        If objRips.Modulo = Constantes.CODIGO_MENU_AMBU Then
            us.Checked = True
            ac.Checked = False
            af.Checked = True
            at.Checked = True
            ap.Checked = False
            am.Checked = False
            ah.Checked = False
            ct.Checked = True
            btOpcionEPS.Visible = False
            af.Tag = Constantes.AAF
            us.Tag = Constantes.AUS
            at.Tag = Constantes.AAT
            permiso_general = perG.buscarPermisoGeneral(Name)
            Pnuevo = permiso_general & "pp" & "01"
            Pconfiguracion = permiso_general & "pp" & "02"
            txtfechaini.Value = DateSerial(Year(Date.Today), Now.Month - 1, 21)
            txtfechafinal.Value = DateSerial(Year(Date.Today), Now.Month, 20)
            Datefechaexp.Enabled = False
            dgvRips.DataSource = objRips.dtFactura
            dgvRips.Columns("Registro").Visible = False
            dgvRips.Columns("idempresa").Visible = False
            dgvRips.Columns("autorizacion").Visible = False
            txtruta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dgvRips.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRips.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            General.deshabilitarControles(Me)
        Else
            permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
            Pnuevo = permiso_general & "pp" & "01"
            Pconfiguracion = permiso_general & "pp" & "02"
            ct.Checked = True
            txtfechaini.Value = DateSerial(Year(Date.Today), Now.Month - 1, 21)
            txtfechafinal.Value = DateSerial(Year(Date.Today), Now.Month, 20)
            Datefechaexp.Enabled = False
            dgvRips.DataSource = objRips.dtFactura
            dgvRips.Columns("Registro").Visible = False
            dgvRips.Columns("idempresa").Visible = False
            dgvRips.Columns("autorizacion").Visible = False
            txtruta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            dgvRips.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRips.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            General.deshabilitarControles(Me)
        End If
    End Sub
    Sub dechecarAll()
        am.Checked = False
        af.Checked = False
        us.Checked = False
        ac.Checked = False
        ap.Checked = False
        ah.Checked = False
        at.Checked = False
    End Sub
    Public Sub cargarConfiguracion()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtidtercero.Text)
        General.llenarTabla(Consultas.EPS_CONFIGURACION_RIPS, params, dt)
        dechecarAll()

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

    Public Sub caragrFacturas()
        objRips.fecha = txtfechaini.Value.Date
        objRips.fecha2 = txtfechafinal.Value.Date
        objRips.codigoEPS = txtcodigoeps.Text
        objRips.cargarFacturas()
        If objRips.dtFactura.Rows.Count > 0 Then
            btguardar.Enabled = True
        Else
            btguardar.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = 1 Then
            txtruta.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btvia_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(Pconfiguracion ) Then
            Dim formRips As New FormConfiguracionRips
            formRips.formRips = Me
            General.cargarForm(formRips)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub limpiarControles()
        txtciudad.Clear()
        txtcodigoeps.Clear()

        txtdireccion.Clear()
        txtdv.Clear()
        txtnit.Clear()
        txteps.Clear()
        txttelefono.Clear()
    End Sub

    Public Sub deshabilitarControles()
        txtciudad.ReadOnly = True
        txtcodigoeps.ReadOnly = True
        Datefechaexp.Enabled = False
        txtdireccion.ReadOnly = True
        txtdv.ReadOnly = True
        txtnit.ReadOnly = True
        txtruta.ReadOnly = True
        txteps.ReadOnly = True
        txttelefono.ReadOnly = True
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            limpiarControles()
            btguardar.Enabled = False
            btnuevo.Enabled = True
            objRips.dtFactura.Clear()
        End If
    End Sub

    Private Sub dgvRips_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRips.CellFormatting
        If e.ColumnIndex = 3 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c0")
            Else
                e.Value = Format(Val(e.Value), "c0")
            End If
        End If
    End Sub

    Private Sub rgeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rgeneral.CheckedChanged
        If rgeneral.Checked = True Then
            deshabilitarCheck()
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

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        habilitarCheck()
    End Sub

    Private Sub rtodos_CheckedChanged(sender As Object, e As EventArgs) Handles rtodos.CheckedChanged
        If rtodos.Checked = True Then
            For i = 0 To objRips.dtFactura.Rows.Count - 1
                objRips.dtFactura.Rows(i).Item("agregar") = 1
            Next
        End If
        objRips.dtNew.Clear()
    End Sub

    Private Sub relegir_CheckedChanged(sender As Object, e As EventArgs) Handles relegir.CheckedChanged
        If relegir.Checked = True Then
            For i = 0 To objRips.dtFactura.Rows.Count - 1
                objRips.dtFactura.Rows(i).Item("agregar") = 0
            Next
        End If
        objRips.dtNew.Clear()
    End Sub

    Public Sub generarArchivos(ByRef pElemento As Object)
        'Recorrer checkbox del groupbox que contienen los archivos checkeados

        For Each vItem In pElemento.Controls
            If (TypeOf vItem Is CheckBox) AndAlso (vItem.checked = True) AndAlso (vItem.tag <> -1) Then
                If objRips.Modulo = Constantes.CODIGO_MENU_ASIS Then
                    objRips.codigoTipoRips = vItem.tag
                    objRips.codigoGrupo = txtcodigogrupo.Text
                    objRips.ripsDinamico()
                Else
                    objRips.codigoTipoRips = vItem.tag
                    objRips.codigoGrupo = txtcodigogrupo.Text

                    If objRips.codigoTipoRips = Constantes.AAF Then
                        objRips.guardarAfAmbulancia()
                    ElseIf objRips.codigoTipoRips = Constantes.AAT Then
                        objRips.guardarAtAmbulancia()
                    ElseIf objRips.codigoTipoRips = Constantes.AUS Then
                        objRips.guardarUsAmbulancia()
                    End If
                End If
            ElseIf (TypeOf vItem Is GroupBox) Or (vItem.hasChildren) Then
                generarArchivos(vItem)
            End If
        Next
    End Sub

    Public Sub epsConfiguracionCargar()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtidtercero.Text)
        General.llenarTabla(Consultas.EPS_RIPS_CONFIGURACION_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txtcodigogrupo.Text = dt.Rows(0).Item("Codigo_grupo").ToString
            txtnombreformato.Text = dt.Rows(0).Item("Descripcion").ToString
        End If

    End Sub

    Public Sub guardar()
        Try
            If String.IsNullOrEmpty(txtcodigogrupo.Text) Then
                MsgBox("Por favor debe seleccionar un formato para la EPS", MsgBoxStyle.Exclamation)
            Else
                dgvRips.EndEdit()
                objRips.dtFactura.AcceptChanges()

                If MsgBox(Mensajes.GENERAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    objRips.consecutivo = txtconsecutivo.Text
                    objRips.ruta = txtruta.Text
                    objRips.fechaExp = Format(Datefechaexp.Value, Constantes.FORMATO_FECHA_GEN)
                    objRips.codigoHabilitacion()
                    objRips.consecutivo = txtconsecutivo.Text
                    objRips.rus = us.Checked
                    objRips.rac = ac.Checked
                    objRips.raf = af.Checked
                    objRips.rat = at.Checked
                    objRips.rap = ap.Checked
                    objRips.ram = am.Checked
                    objRips.rah = ah.Checked
                    objRips.rct = ct.Checked
                    objRips.Modulo = Tag.modulo
                    If objRips.Modulo = Constantes.CODIGO_MENU_ASIS Then
                        generarArchivos(gbTipoArchivos)
                        objRips.generarArchivoCT()
                        objRips.dtArchivos.Clear()
                    Else
                        generarArchivos(gbTipoArchivos)
                        objRips.generarArchivoCT()
                        objRips.dtArchivos.Clear()
                    End If
                    MsgBox(Mensajes.RIPS, MsgBoxStyle.Information)
                    Process.Start("file://" + txtruta.Text.Trim())
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cbFormato_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btOpcionEPS.Click
        If SesionActual.tienePermiso(Pconfiguracion ) Then
            Dim formEps As New form_eps
            General.cargarForm(formEps)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub validarNumeroAutorizacion()
        For i = 0 To objRips.dtFactura.Rows.Count - 1
            If objRips.dtFactura.Rows(i).Item("agregar") = True And String.IsNullOrEmpty(objRips.dtFactura.Rows(i).Item("autorizacion")) Then
                MsgBox("El codigo factura: " & objRips.dtFactura.Rows(i).Item("Codigo factura") & " Paciente " & objRips.dtFactura.Rows(i).Item("Paciente") &
                       " no tiene numero de autorizacion", MsgBoxStyle.Exclamation)
            End If
        Next
    End Sub

    Private Sub dgvRips_DoubleClick(sender As Object, e As EventArgs) Handles dgvRips.DoubleClick
        validarNumeroAutorizacion()
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvRips.EndEdit()
        guardar()
    End Sub

    Private Sub txtfechaini_ValueChanged(sender As Object, e As EventArgs) Handles txtfechaini.ValueChanged
        objRips.dtFactura.Clear()
        objRips.dtNew.Clear()
        caragrFacturas()

    End Sub

    Private Sub txtfechafinal_ValueChanged(sender As Object, e As EventArgs) Handles txtfechafinal.ValueChanged
        objRips.dtFactura.Clear()
        objRips.dtNew.Clear()
        caragrFacturas()
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.habilitarControles(Me)
            deshabilitarControles()
            deshabilitarCheck()
            btnuevo.Enabled = False
            btcancelar.Enabled = True
            txtnombreformato.ReadOnly = True
            txtconsecutivo.ReadOnly = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class