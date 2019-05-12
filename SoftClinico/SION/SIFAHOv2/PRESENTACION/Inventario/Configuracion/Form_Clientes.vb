Imports System.Data.SqlClient
Public Class Form_Clientes

    Dim suspen, bloq, r_fuente, r_ica, r_iva As Boolean
    Dim cmd As New ClienteBLL
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim codigoPuc As Integer
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Plinea, Pcualidad, Pgrupo, Pprese, Pviaadmin, codigo As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub llenarComboFormaPago()
        Dim dtFormaPago As New DataTable
        dtFormaPago.Columns.Add("Codigo")
        dtFormaPago.Columns.Add("Nombre")
        dtFormaPago.Rows.Add()
        dtFormaPago.Rows(0).Item("Codigo") = -1
        dtFormaPago.Rows(0).Item("Nombre") = "-- Seleccione --"
        dtFormaPago.Rows.Add()
        dtFormaPago.Rows(1).Item("Codigo") = "1"
        dtFormaPago.Rows(1).Item("Nombre") = "Contado"
        dtFormaPago.Rows.Add()
        dtFormaPago.Rows(2).Item("Codigo") = "2"
        dtFormaPago.Rows(2).Item("Nombre") = "Credito"
        combofpago.Items.Clear()
        combofpago.DataSource = Nothing
        combofpago.DataSource = dtFormaPago
        combofpago.DisplayMember = "Nombre"
        combofpago.ValueMember = "Codigo"
    End Sub
    Public Sub llenarComboUbicacion()
        Dim dtUbicacion As New DataTable
        dtUbicacion.Columns.Add("Codigo")
        dtUbicacion.Columns.Add("Nombre")
        dtUbicacion.Rows.Add()
        dtUbicacion.Rows(0).Item("Codigo") = -1
        dtUbicacion.Rows(0).Item("Nombre") = "-- Seleccione --"
        dtUbicacion.Rows.Add()
        dtUbicacion.Rows(1).Item("Codigo") = "L"
        dtUbicacion.Rows(1).Item("Nombre") = "Local"
        dtUbicacion.Rows.Add()
        dtUbicacion.Rows(2).Item("Codigo") = "N"
        dtUbicacion.Rows(2).Item("Nombre") = "Nacional"
        comboubicacion.Items.Clear()
        comboubicacion.DataSource = Nothing
        comboubicacion.DataSource = dtUbicacion
        comboubicacion.DisplayMember = "Nombre"
        comboubicacion.ValueMember = "Codigo"
    End Sub
    Private Sub Form_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plazo, descuento As New DataColumn
        codigoPuc = FuncionesContables.obtenerPucActivo
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)

        llenarComboUbicacion()
        comboubicacion.SelectedIndex = 0

        llenarComboFormaPago()
        combofpago.SelectedIndex = 0

        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        Combopais.SelectedIndex = 0
        General.cargarCombo(Consultas.REGIMEN_PROVEEDOR_LISTAR, "Descripción", "Código", comboregimen)
        General.cargarCombo(Consultas.PLAZO_LLENAR_COMBO & "", "Descripción", "Código", comboplazos)
        General.cargarCombo(Consultas.DIAS_ENTREGA_LISTAR, "Descripción", "Código", combodentrega)
        General.cargarCombo(Consultas.DIAS_DEVOLUCION_LISTAR, "Descripción", "Código", comboddevolucion)
        General.cargarCombo(Consultas.TIPO_CLIENTE_LISTAR, "Descripción", "Código", ComboTipoCliente)
        General.deshabilitarControles(Me)
        btopcionDevolucion.Enabled = True
        btopcionEntrega.Enabled = True
        btopcionListaPrecio.Enabled = True
        btopcionPlazo.Enabled = True
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub btpuc_Click(sender As System.Object, e As System.EventArgs) Handles btpuc.Click
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add("")
        General.buscarItem(Consultas.BUSQUEDA_CUENTAS_DETALLE_PUC,
                       params,
                        AddressOf cargarPuc,
                        TitulosForm.BUSQUEDA_PUC,
                        False)
    End Sub

    Private Sub btciiu_Click(sender As System.Object, e As System.EventArgs) Handles btciiu.Click
        Dim params = {String.Empty}.ToList
        General.buscarItem(Consultas.BUSQUEDA_CIIU,
                        params,
                        AddressOf cargarCiiu,
                        TitulosForm.BUSQUEDA_CIIU,
                        False)
    End Sub
    Private Sub cargarPuc(pFila As DataRow)
        Textcuentapuc.Text = pFila.Item(0)
        textpuc.Text = pFila.Item(1)
    End Sub
    Private Sub cargarCiiu(pFila As DataRow)
        Textcodigociiu.Text = pFila.Item(0)
        textciiu.Text = pFila.Item(1)
    End Sub
    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub

    Private Sub btentrega_Click(sender As Object, e As EventArgs) Handles btopcionEntrega.Click
        Dim objDiaEntrega As New FormEntrega
        General.cargarForm(objDiaEntrega)
    End Sub
    Private Sub BtnListaPrecio_Click(sender As Object, e As EventArgs) Handles btopcionListaPrecio.Click
        If Textcodigo.Text <> "" Then
            FormPrincipal.Cursor = Cursors.WaitCursor
            form_lista_precio_proveedor.MdiParent = FormPrincipal
            General.limpiarControles(form_lista_precio_proveedor)
            form_lista_precio_proveedor.setTipoLista(Constantes.CLIENTE, Textcodigo.Text, textrazonsocial.Text)
            form_lista_precio_proveedor.Show()
            form_lista_precio_proveedor.Focus()
            If form_lista_precio_proveedor.WindowState = FormWindowState.Minimized Then
                form_lista_precio_proveedor.WindowState = FormWindowState.Normal
            End If
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox("Debe escoger el cliente")
        End If

    End Sub

    Private Sub btdevolucion_Click(sender As Object, e As EventArgs) Handles btopcionDevolucion.Click
        Dim FormDevolucion As New FormDevolucion
        General.cargarForm(FormDevolucion)
    End Sub
    Private Sub form_Clientes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Sub btbuscarrepresentante_Click(sender As Object, e As EventArgs) Handles btbuscarrepresentante.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_TERCERO_CLIENTE,
                               params,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               True, 0, True)
    End Sub
    Function valiv(ByVal sender As Object) As String
        Return If(IsNumeric(sender), CDbl(sender).ToString().Replace(",", "."), 0)
    End Function
    Function vali100x(ByVal sender As Object) As String
        If Not IsNumeric(sender) Then
            Return "0"
        ElseIf CDec(sender.ToString.Replace(".", ",")) > 100 Then
            Return "100"
        Else
            Return sender
        End If
    End Function
    Private Sub btplazo_Click(sender As Object, e As EventArgs) Handles btopcionPlazo.Click
        Dim objPlazo As New FormPlazo
        General.cargarForm(objPlazo)
    End Sub
    Private Sub text30dias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        ValidacionDigitacion.validarDinero(sender, e)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            General.habilitarControles(Me)
            General.deshabilitarControles(GroupBox2)

            btbuscarrepresentante.Enabled = True
            codigo = String.Empty
            Textcodigociiu.ReadOnly = True
            Textcuentapuc.ReadOnly = True
            textciiu.ReadOnly = True
            textpuc.ReadOnly = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Function validarInformacion() As Boolean
        If (Textnit.Text = "") Then
            MsgBox("¡ Por favor Seleccione un tercero!", MsgBoxStyle.Exclamation)
            btbuscarrepresentante.Focus()
            Return False
        ElseIf (comboregimen.SelectedValue < 1) Then
            MsgBox("¡ Por favor elija algun tipo de regimen!", MsgBoxStyle.Exclamation)
            comboregimen.Focus()
            Return False

        ElseIf (comboplazos.SelectedIndex < 1) Or (comboplazos.SelectedValue = "") Then
            MsgBox("¡ Por favor elija un plazo!", MsgBoxStyle.Exclamation)
            comboplazos.Focus()
            Return False
        ElseIf (comboubicacion.SelectedIndex < 1) Then
            MsgBox("¡ Por favor elija alguna ubicacion!", MsgBoxStyle.Exclamation)
            comboubicacion.Focus()
            Return False
        ElseIf (combofpago.SelectedIndex < 1) Then
            MsgBox("¡ Por favor elija alguna forma de pago", MsgBoxStyle.Exclamation)
            combofpago.Focus()
            Return False
        ElseIf (combodentrega.SelectedIndex < 1) Or (combodentrega.SelectedValue = "") Then
            MsgBox("¡ Por favor elija algun dia de entrega!", MsgBoxStyle.Exclamation)
            combodentrega.Focus()
            Return False
        ElseIf (comboddevolucion.SelectedIndex < 1) Or (comboddevolucion.SelectedValue = "") Then
            MsgBox("¡ Por favor elija algun dia de devolucion!", MsgBoxStyle.Exclamation)
            comboddevolucion.Focus()
            Return False
        ElseIf (Textcuentapuc.Text = "") Then
            MsgBox("¡ Por favor elija una cuenta para el cliente!", MsgBoxStyle.Exclamation)
            btpuc.Focus()
            Return False
        ElseIf (textciiu.Text = "") Then
            MsgBox("¡ Por favor elija un codigo CIIU para el cliente!", MsgBoxStyle.Exclamation)
            btciiu.Focus()
            Return False
        End If
        Return True
    End Function
    Public Function crearCliente() As Cliente
        Dim objCliente As New Cliente
        objCliente.codigo = codigo
        objCliente.IdCliente = Textcodigo.Text
        objCliente.formapago = combofpago.SelectedValue
        objCliente.codigoregimen = comboregimen.SelectedValue
        objCliente.ubicacion = comboubicacion.SelectedValue
        objCliente.idEmpresa = SesionActual.idEmpresa
        objCliente.codigoplazo = comboplazos.SelectedValue
        objCliente.codigoentrega = combodentrega.SelectedValue
        objCliente.codigodevolucion = comboddevolucion.SelectedValue
        objCliente.observacion = Textobservacion.Text
        objCliente.suspendido = suspen
        objCliente.bloqueado = bloq
        objCliente.codigoep = SesionActual.codigoEP
        objCliente.usuario = SesionActual.idUsuario
        objCliente.cuentaPuc = Textcuentapuc.Text
        objCliente.codigoCiiu = Textcodigociiu.Text
        objCliente.codigoPuc = codigoPuc
        objCliente.tipoCliente = ComboTipoCliente.SelectedValue
        Return objCliente
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objCliente As New ClienteBLL
                Try
                    objCliente.Guardarcliente(crearCliente())
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False

                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(GroupBox2)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                Textcodigociiu.ReadOnly = True
                Textcuentapuc.ReadOnly = True
                textciiu.ReadOnly = True
                textpuc.ReadOnly = True
                ComboTipoCliente.Enabled = True
            End If
            codigo = Textcodigo.Text
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.CLIENTE_ANULAR & SesionActual.idUsuario & "," & CInt(Textcodigo.Text) & "")

                    If respuesta = True Then
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarTercero(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.TERCERO_CARGAR, params, dt)
        Textcodigo.Text = pCodigo
        Textnit.Text = dt.Rows(0).Item("NIT").ToString()
        Textdv.Text = dt.Rows(0).Item("DV").ToString()
        textrazonsocial.Text = dt.Rows(0).Item("Tercero").ToString()
        Combopais.SelectedValue = dt.Rows(0).Item("Codigo_Pais").ToString()
        Combodepartamento.SelectedValue = dt.Rows(0).Item("Codigo_Departamento").ToString()
        Combociudad.SelectedValue = dt.Rows(0).Item("Codigo_Municipio").ToString()
        Textdireccion.Text = dt.Rows(0).Item("DIRECCION").ToString()
        Textemail.Text = dt.Rows(0).Item("email").ToString()
        Texttelefono.Text = dt.Rows(0).Item("Telefono1").ToString()
        Textcelular.Text = dt.Rows(0).Item("Telefono2").ToString()
        comboregimen.Focus()
    End Sub
    Private Sub cargarDatos(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Textcodigo.Text = pCodigo
        General.llenarTabla(Consultas.CLIENTES_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            combofpago.SelectedValue = dt.Rows(0).Item("Forma_Pago").ToString()
            comboregimen.SelectedValue = dt.Rows(0).Item("Codigo_tipo_regimen").ToString()
            comboubicacion.SelectedValue = dt.Rows(0).Item("Ubicacion").ToString()
            combodentrega.SelectedValue = dt.Rows(0).Item("Codigo_dia_entrega").ToString()
            comboddevolucion.SelectedValue = dt.Rows(0).Item("Codigo_dia_devolucion").ToString()
            Textobservacion.Text = dt.Rows(0).Item("Observaciones").ToString()
            comboplazos.SelectedValue = dt.Rows(0).Item("Codigo_plazo").ToString()
            textciiu.Text = dt.Rows(0).Item("descripcion").ToString
            Textcodigociiu.Text = dt.Rows(0).Item("codigo_ciiu").ToString
            Textcuentapuc.Text = dt.Rows(0).Item("cuenta_Cliente").ToString
            textpuc.Text = dt.Rows(0).Item("nombre_cuenta").ToString
            ComboTipoCliente.SelectedValue = dt.Rows(0).Item("Tipo_Cliente").ToString
            cargarTercero(Textcodigo.Text)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_CLIENTES,
                               params,
                               AddressOf cargarDatos,
                               TitulosForm.BUSQUEDA_CLIENTES,
                               True, 0, True)
    End Sub

End Class