Imports System.Data.SqlClient
Public Class FormTercero

    Dim objTercero As New TerceroI
    Dim respuesta As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Tercero_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        Combopais.SelectedIndex = 0
        General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", cboidentificacion)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)

    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda una linea y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 05/05/2016

        If txtidentificacion.Text = "" Then
            MsgBox("¡ Por favor digite la identificacion !", MsgBoxStyle.Exclamation)
            txtidentificacion.Focus()
        ElseIf txtdv.Text = "" Then
            MsgBox("¡ Por favor digite el DV !", MsgBoxStyle.Exclamation)
            txtdv.Focus()
        ElseIf cboidentificacion.SelectedValue = 10 And String.IsNullOrEmpty(txtrazon.Text) Then
            MsgBox("¡ Por favor digite una razon social!", MsgBoxStyle.Exclamation)
            txtrazon.Focus()
        ElseIf cboidentificacion.SelectedValue = 10 And String.IsNullOrEmpty(txtpnombre.Text) Then
            MsgBox("¡ Por favor digite la sigla!", MsgBoxStyle.Exclamation)
            txtpnombre.Focus()
        ElseIf cboidentificacion.SelectedValue <> 10 And String.IsNullOrEmpty(txtpnombre.Text) Then
            MsgBox("¡ Por favor digite el primer nombre!", MsgBoxStyle.Exclamation)
            txtpnombre.Focus()
        ElseIf cboidentificacion.SelectedValue <> 10 And String.IsNullOrEmpty(txtpapellido.Text) Then
            MsgBox("¡ Por favor digite el primer apellido!", MsgBoxStyle.Exclamation)
            txtpapellido.Focus()
        ElseIf cboidentificacion.SelectedValue <> 10 And String.IsNullOrEmpty(txtsapellido.Text) Then
            MsgBox("¡ Por favor digite el segundo apellido!", MsgBoxStyle.Exclamation)
            txtsapellido.Focus()
        ElseIf txttelefono.Text = "" Then
            MsgBox("¡ Por favor digite el telefono !", MsgBoxStyle.Exclamation)
            txttelefono.Focus()
        ElseIf txtdireccion.Text = "" Then
            MsgBox("¡ Por favor digite la direccion !", MsgBoxStyle.Exclamation)
            txtdireccion.Focus()
        ElseIf (Combopais.SelectedValue < 1) Then
            MsgBox("¡  Por favor digite el pais donde se encuentra la empresa!", MsgBoxStyle.Exclamation)
            Combopais.Focus()
        ElseIf (Combodepartamento.SelectedValue < 1) Then
            MsgBox("¡  Por favor escoja el departamento donde se encuentra  la empresa!", MsgBoxStyle.Exclamation)
            Combodepartamento.Focus()
        ElseIf (Combociudad.SelectedValue < 1) Then
            MsgBox("¡  Por favor escoja la ciudad donde se encuentra  la empresa!", MsgBoxStyle.Exclamation)
            Combociudad.Focus()
        ElseIf (cboidentificacion.SelectedValue < 1) Then
            MsgBox("¡  Por favor seleccione tipo identificacion !", MsgBoxStyle.Exclamation)
            Combociudad.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                objTercero.cboidentificacion = cboidentificacion.SelectedValue
                objTercero.identificacion = txtidentificacion.Text
                objTercero.dv = txtdv.Text
                objTercero.razon = txtrazon.Text
                objTercero.pnombre = txtpnombre.Text
                objTercero.nombre = txtsnombre.Text
                objTercero.papellido = txtpapellido.Text
                objTercero.sapellido = txtsapellido.Text
                objTercero.telefono = txttelefono.Text
                objTercero.telefono2 = txttelefono2.Text
                objTercero.whatsapp = txtwhatsapp.Text
                objTercero.email = txtemail.Text
                objTercero.Combopais = Combopais.SelectedValue
                objTercero.Combodepartamento = Combodepartamento.SelectedValue
                objTercero.Combociudad = Combociudad.SelectedValue
                objTercero.direccion = txtdireccion.Text
                objTercero.usuario = SesionActual.idUsuario
                objTercero.codigo = txtcodigo.Text.ToString()
                Dim params As New List(Of String)
                params.Add(objTercero.identificacion)
                params.Add(objTercero.cboidentificacion)
                params.Add(txtcodigo.Text)
                If General.getEstadoVF(Consultas.TERCERO_VERIFICAR, params) Then
                    MsgBox(" Ya existe un registro con el tipo Documento: " & cboidentificacion.Text & "   y la Identificacion: " & txtidentificacion.Text & "", MsgBoxStyle.Exclamation)
                    txtidentificacion.Focus()
                    txtidentificacion.Clear()
                Else
                    objTercero.guardarTercero()
                    txtcodigo.Text = objTercero.codigo
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar-
                    btanular.Enabled = True

                End If
            End If
        End If

    End Sub

    Public Sub validarRazonSocial()
        If cboidentificacion.SelectedValue = 10 Then
            Label7.Enabled = False
            Label8.Enabled = False
            Label9.Enabled = False
            txtpapellido.Enabled = False
            txtsapellido.Enabled = False
            txtsnombre.Enabled = False
            Label6.Text = "Sigla:"
            Label5.Enabled = True
            txtrazon.Enabled = True
        Else
            Label7.Enabled = True
            Label8.Enabled = True
            Label9.Enabled = True
            txtpapellido.Enabled = True
            txtsapellido.Enabled = True
            txtsnombre.Enabled = True
            Label6.Text = "Primer Nombre:"
            Label5.Enabled = False
            txtrazon.Enabled = False
            If Label6.Text = "Sigla:" Then
                txtpnombre.Clear()
                txtrazon.Clear()
            End If
        End If
    End Sub

    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue?.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub
    Private Sub Combodepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtidentificacion.ReadOnly = True
            txtdv.ReadOnly = True
            Label7.Enabled = True
            Label8.Enabled = True
            Label9.Enabled = True
            txtpapellido.Enabled = True
            txtsapellido.Enabled = True
            txtsnombre.Enabled = True
            Label6.Text = "Primer Nombre:"
            Label5.Enabled = True
            txtrazon.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--  
            txtpnombre.Focus()
            validarRazonSocial()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 06/05/2016
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_TERCERO, params)

                General.limpiarControles(Me)
                General.deshabilitarControles(Me)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        Label7.Enabled = True
        Label8.Enabled = True
        Label9.Enabled = True
        txtpapellido.Enabled = True
        txtsapellido.Enabled = True
        txtsnombre.Enabled = True
        Label6.Text = "Primer Nombre:"
        Label5.Enabled = True
        txtrazon.Enabled = True
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(String.Empty)

            General.buscarElemento(Consultas.BUSQUEDA_TERCERO,
                           params,
                           AddressOf cargarTercero,
                           TitulosForm.BUSQUEDA_TERCERO,
                           True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarTercero()

        Dim params As New List(Of String)
        params.Add(txtidentificacion.Text)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.TERCERO_CARGAR_VERIFICAR, params, dt)
        If dt.Rows.Count > 0 Then
            cboidentificacion.SelectedValue = dt.Rows(0).Item("Codigo_tipo_identificacion")
            txtidentificacion.Text = Funciones.castFromDbItem(dt.Rows(0).Item("NIT"))
            txtdv.Text = Funciones.castFromDbItem(dt.Rows(0).Item("dv"))
            txtpnombre.Text = Funciones.castFromDbItem(dt.Rows(0).Item("nombre"))
            txtsnombre.Text = Funciones.castFromDbItem(dt.Rows(0).Item("snombre"))
            txtpapellido.Text = Funciones.castFromDbItem(dt.Rows(0).Item("Apellido"))
            txtsapellido.Text = Funciones.castFromDbItem(dt.Rows(0).Item("sapellido"))
            txtrazon.Text = Funciones.castFromDbItem(dt.Rows(0).Item("RazonSocial"))
            txttelefono.Text = Funciones.castFromDbItem(dt.Rows(0).Item("Telefono1"))
            txttelefono2.Text = Funciones.castFromDbItem(dt.Rows(0).Item("telefono2"))
            txtwhatsapp.Text = Funciones.castFromDbItem(dt.Rows(0).Item("whatsapp"))
            Combopais.SelectedValue = Funciones.castFromDbItem(dt.Rows(0).Item("Codigo_Pais"))
            Combodepartamento.SelectedValue = Funciones.castFromDbItem(dt.Rows(0).Item("Codigo_Departamento"))
            Combociudad.SelectedValue = Funciones.castFromDbItem(dt.Rows(0).Item("Codigo_Municipio"))
            txtdireccion.Text = Funciones.castFromDbItem(dt.Rows(0).Item("Direccion"))
            txtemail.Text = Funciones.castFromDbItem(dt.Rows(0).Item("email"))
            txtcodigo.Text = Funciones.castFromDbItem(dt.Rows(0).Item("Id_tercero"))

            General.deshabilitarControles(Me)
            bteditar.Enabled = True
            btcancelar.Enabled = False
            btanular.Enabled = True
            btanular.Enabled = True
            btbuscar.Enabled = True
            btguardar.Enabled = False
            btnuevo.Enabled = True
            txtidentificacion.ReadOnly = True

            If String.IsNullOrEmpty(txtrazon.Text) Then
                Label5.Enabled = False
                txtrazon.Enabled = False
            Else
                Label5.Enabled = True
                txtrazon.Enabled = True
            End If
        End If
    End Sub


    Public Sub cargarTercero(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drFila = General.cargarItem(Consultas.TERCERO_CARGAR, params)

        cboidentificacion.SelectedValue = drFila(0)
        txtidentificacion.Text = drFila(2).ToString()
        txtdv.Text = drFila.Item(3).ToString()
        txtpnombre.Text = drFila.Item(4).ToString()
        txtsnombre.Text = drFila.Item(5).ToString()
        txtpapellido.Text = drFila.Item(6).ToString()
        txtsapellido.Text = drFila.Item(7).ToString()
        txtrazon.Text = drFila.Item(8).ToString()
        txttelefono.Text = drFila.Item(9).ToString()
        txttelefono2.Text = drFila.Item(10).ToString()
        txtwhatsapp.Text = drFila.Item(11).ToString()
        Combopais.SelectedValue = drFila.Item(12).ToString()
        Combodepartamento.SelectedValue = drFila.Item(14).ToString()
        Combociudad.SelectedValue = drFila.Item(16).ToString()
        txtdireccion.Text = drFila.Item(18).ToString()
        txtemail.Text = drFila.Item(19).ToString()
        txtcodigo.Text = drFila.Item(21).ToString()

        If txtcodigo.Text <> "" Then
            bteditar.Enabled = True
            btcancelar.Enabled = False
            btanular.Enabled = True
            txtidentificacion.ReadOnly = True
        End If
        If String.IsNullOrEmpty(txtrazon.Text) Then
            Label5.Enabled = False
            txtrazon.Enabled = False
        Else
            Label5.Enabled = True
            txtrazon.Enabled = True
        End If
    End Sub

    Private Sub txtidentificacion_TextChanged(sender As Object, e As EventArgs) Handles txtidentificacion.TextChanged
        Dim DV As New DigitoVerificacion
        Dim n As Integer

        n = DV.CalculaNit(txtidentificacion.Text)
        txtdv.Text = CType(n, String)
        If txtidentificacion.Text = Nothing Then
            txtdv.Text = Nothing
        End If
    End Sub

    Private Sub txtidentificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidentificacion.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub

    Private Sub txttelefono2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono2.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub

    Private Sub txtwhatsapp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtwhatsapp.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub

    Private Sub txtpnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpnombre.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub

    Private Sub txtsnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsnombre.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub
    Private Sub txtsapellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsapellido.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub

    Private Sub txtpapellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpapellido.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub txtrazon_TextChanged(sender As Object, e As EventArgs) Handles txtrazon.TextChanged

    End Sub

    Private Sub txtpnombre_TextChanged(sender As Object, e As EventArgs) Handles txtpnombre.TextChanged

    End Sub

    Private Sub txtsnombre_TextChanged(sender As Object, e As EventArgs) Handles txtsnombre.TextChanged

    End Sub

    Private Sub txtidentificacion_Leave(sender As Object, e As EventArgs) Handles txtidentificacion.Leave
        If txtidentificacion.Text <> String.Empty And String.IsNullOrEmpty(txtcodigo.Text) Then
            cargarTercero()
        End If
    End Sub

    Private Sub cboidentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboidentificacion.SelectedIndexChanged
        If cboidentificacion.SelectedIndex <> 0 Then
            txtidentificacion.ReadOnly = False
            If cboidentificacion.SelectedValue = 10 Then
                Label7.Enabled = False
                Label8.Enabled = False
                Label9.Enabled = False
                txtpapellido.Enabled = False
                txtsapellido.Enabled = False
                txtsnombre.Enabled = False
                txtpapellido.Clear()
                txtsapellido.Clear()
                txtsnombre.Clear()
                Label6.Text = "Sigla:"
                Label5.Enabled = True
                txtrazon.Enabled = True
            Else
                Label7.Enabled = True
                Label8.Enabled = True
                Label9.Enabled = True
                txtpapellido.Enabled = True
                txtsapellido.Enabled = True
                txtsnombre.Enabled = True
                Label6.Text = "Primer Nombre:"
                Label5.Enabled = False
                txtrazon.Enabled = False
                txtrazon.Clear()
                txtpnombre.Clear()
            End If
        Else
            txtidentificacion.ReadOnly = True
            Label7.Enabled = True
            Label8.Enabled = True
            Label9.Enabled = True
            txtpapellido.Enabled = True
            txtsapellido.Enabled = True
            txtsnombre.Enabled = True
            Label6.Text = "Primer Nombre:"
            Label5.Enabled = True
            txtrazon.Enabled = True
            txtrazon.Clear()
            txtpnombre.Clear()
            txtpapellido.Clear()
            txtsapellido.Clear()
            txtsnombre.Clear()
        End If
    End Sub
End Class