Imports System.Data.SqlClient
Public Class Form_Proveedores
    Dim suspen, bloq, r_fuente, r_ica, r_iva As Boolean
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim dtPlazo As New DataTable
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pdevolucion, Pplazo, Pvencimiento, Pentrega, idProveedor As String
    Dim codigoPuc As Integer
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btOpcionListaPrecio.Click
        If Textcodigo.Text <> "" Then
            FormPrincipal.Cursor = Cursors.WaitCursor
            form_lista_precio_proveedor.MdiParent = FormPrincipal
            General.limpiarControles(form_lista_precio_proveedor)
            form_lista_precio_proveedor.setTipoLista(Constantes.PROVEEDOR, Textcodigo.Text, textrazonsocial.Text)
            form_lista_precio_proveedor.Show()
            form_lista_precio_proveedor.Focus()
            If form_lista_precio_proveedor.WindowState = FormWindowState.Minimized Then
                form_lista_precio_proveedor.WindowState = FormWindowState.Normal
            End If
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox("Debe escoger el proveedor")
        End If
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub llenarComboTipoPago()
        Dim dtTipoPago As New DataTable
        dtTipoPago.Columns.Add("Codigo")
        dtTipoPago.Columns.Add("Nombre")
        dtTipoPago.Rows.Add()
        dtTipoPago.Rows(0).Item("Codigo") = 0
        dtTipoPago.Rows(0).Item("Nombre") = "-- Seleccione --"
        dtTipoPago.Rows.Add()
        dtTipoPago.Rows(1).Item("Codigo") = "F"
        dtTipoPago.Rows(1).Item("Nombre") = "Factura"
        dtTipoPago.Rows.Add()
        dtTipoPago.Rows(2).Item("Codigo") = "C"
        dtTipoPago.Rows(2).Item("Nombre") = "Cuenta de Cobro"
        comboTipopago.Items.Clear()
        comboTipopago.DataSource = Nothing
        comboTipopago.DataSource = dtTipoPago
        comboTipopago.DisplayMember = "Nombre"
        comboTipopago.ValueMember = "Codigo"
    End Sub

    Public Sub llenarComboUbicacion()
        Dim dtUbicacion As New DataTable
        dtUbicacion.Columns.Add("Codigo")
        dtUbicacion.Columns.Add("Nombre")
        dtUbicacion.Rows.Add()
        dtUbicacion.Rows(0).Item("Codigo") = -1
        dtUbicacion.Rows(0).Item("Nombre") = "-- Seleccione --"
        dtUbicacion.Rows.Add()
        dtUbicacion.Rows(1).Item("Codigo") = "1"
        dtUbicacion.Rows(1).Item("Nombre") = "Nacional"
        dtUbicacion.Rows.Add()
        dtUbicacion.Rows(2).Item("Codigo") = "2"
        dtUbicacion.Rows(2).Item("Nombre") = "Exterior"
        comboubicacion.Items.Clear()
        comboubicacion.DataSource = Nothing
        comboubicacion.DataSource = dtUbicacion
        comboubicacion.DisplayMember = "Nombre"
        comboubicacion.ValueMember = "Codigo"
    End Sub
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
        dtFormaPago.Rows(2).Item("Codigo") = "0"
        dtFormaPago.Rows(2).Item("Nombre") = "Credito"
        combofpago.Items.Clear()
        combofpago.DataSource = Nothing
        combofpago.DataSource = dtFormaPago
        combofpago.DisplayMember = "Nombre"
        combofpago.ValueMember = "Codigo"
    End Sub
    Private Sub habilitarBotones()
        btOpcionDevolucion.Enabled = True
        btOpcionEntrega.Enabled = True
        btOpcionPlazo.Enabled = True
        btOpcionVencimiento.Enabled = True
    End Sub
    Private Sub dgvcartera_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvplazo.EditingControlShowing,
            dgvplazo.EditingControlShowing
        If dgvplazo.CurrentCell.ColumnIndex = 2 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub
    Private Sub Form_Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plazo, descripcion, descuento, estado As New DataColumn
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pplazo = permiso_general & "pp" & "05"
        Pentrega = permiso_general & "pp" & "06"
        Pdevolucion = permiso_general & "pp" & "07"
        Pvencimiento = permiso_general & "pp" & "08"
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        habilitarBotones()
        llenarComboTipoPago()
        comboTipopago.SelectedIndex = 0
        llenarComboUbicacion()
        comboubicacion.SelectedIndex = 0
        llenarComboFormaPago()
        combofpago.SelectedIndex = 0

        plazo.ColumnName = "codplazo"
        plazo.DataType = Type.GetType("System.String")
        dtPlazo.Columns.Add(plazo)

        descripcion.ColumnName = "Descripcion"
        descripcion.DataType = Type.GetType("System.String")
        dtPlazo.Columns.Add(descripcion)

        descuento.ColumnName = "descuento"
        descuento.DataType = Type.GetType("System.Double")
        descuento.DefaultValue = 0
        dtPlazo.Columns.Add(descuento)

        estado.ColumnName = "Estado"
        estado.DataType = Type.GetType("System.String")
        dtPlazo.Columns.Add(estado)

        With dgvplazo
            .Columns.Item("codplazo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("codplazo").DataPropertyName = "codplazo"

            .Columns.Item("descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("descripcion").DataPropertyName = "Descripcion"

            .Columns.Item("descuento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("descuento").DataPropertyName = "descuento"

            .Columns("Estado").DataPropertyName = "Estado"
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = False
        End With

        dgvplazo.AutoGenerateColumns = False
        dgvplazo.DataSource = dtPlazo
        cargarCombos()

        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub dgvplazo_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvplazo.KeyDown
        If dgvplazo.Rows.Count > 0 Then
            If e.KeyCode = Keys.F3 And btcancelar.Enabled = True Then
                General.agregarItems(Consultas.PLAZO_LISTAR, TitulosForm.BUSQUEDA_INSUMOS, dgvplazo, dtPlazo)
            End If
        End If
    End Sub
    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub
    Public Sub llenarDgvPlazo()
        Dim params As New List(Of String)
        params.Add(Textcodigo.Text)
        General.llenarTabla(Consultas.PLAZO_PROVEEDOR_CARGAR, params, dtPlazo)
        For indice = 0 To dtPlazo.Rows.Count - 1
            dtPlazo.Rows(indice).Item("Estado") = Constantes.ITEM_CARGADO
        Next
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
    Private Sub btbuscarrepresentante_Click(sender As Object, e As EventArgs) Handles btbuscarproveedor.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_TERCERO_PROVEEDOR,
                               params,
                               AddressOf cargarTercero,
                              TitulosForm.BUSQUEDA_TERCERO,
                               True, 0, True)

    End Sub

    Public Sub cargarTercero(pCodigo As String)
        Dim dtTercero As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.CARGAR_TERCERO_PROVEEDOR, params, dtTercero)
        Textcodigo.Text = pCodigo
        Textnit.Text = dtTercero.Rows(0).Item("nit").ToString
        Textdv.Text = dtTercero.Rows(0).Item("dv").ToString
        textrazonsocial.Text = dtTercero.Rows(0).Item("RazonSocial").ToString
        Combopais.SelectedValue = dtTercero.Rows(0).Item("codigo_pais").ToString
        Combodepartamento.SelectedValue = dtTercero.Rows(0).Item("codigo_departamento").ToString
        Combociudad.SelectedValue = dtTercero.Rows(0).Item("codigo_municipio").ToString
        Texttelefono.Text = dtTercero.Rows(0).Item("Telefono1").ToString
        Textcelular.Text = dtTercero.Rows(0).Item("Telefono2").ToString
        Textdireccion.Text = dtTercero.Rows(0).Item("Direccion").ToString
        Textemail.Text = dtTercero.Rows(0).Item("email").ToString
        comboregimen.Focus()
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
        Dim params = {""}.ToList
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
    Sub cargarCombos()
        codigoPuc = FuncionesContables.obtenerPucActivo
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        Combopais.SelectedIndex = 0
        General.cargarCombo(Consultas.RETEIVA_LISTAR & "" & codigoPuc & "", "Nombre", "Código", cmbIVA)
        General.cargarCombo(Consultas.RETEICA_LISTAR & "" & codigoPuc & "", "Nombre", "Código", cmbICA)
        General.cargarCombo(Consultas.RETEFUENTE_LISTAR & "" & codigoPuc & "", "Nombre", "Código", cmbFuente)
        General.cargarCombo(Consultas.BANCO_LISTAR, "Descripción", "Código", combobanco)
        General.cargarCombo(Consultas.TCUENTA_LISTAR, "Descripción", "Código", Combocuenta)
        General.cargarCombo(Consultas.REGIMEN_PROVEEDOR_LISTAR, "Descripción", "Código", comboregimen)
        General.cargarCombo(Consultas.DIAS_ENTREGA_LISTAR, "Descripción", "Código", combodentrega)
        General.cargarCombo(Consultas.DIAS_DEVOLUCION_LISTAR, "Descripción", "Código", comboddevolucion)
        General.cargarCombo(Consultas.DIAS_VENCIMIENTO_LISTAR, "Descripción", "Código", combodvencimiento)
    End Sub
    Function valiv(ByVal sender As Object) As String
        Return If(IsNumeric(sender), CDbl(sender).ToString().Replace(", ", "."), 0)
    End Function
    Function vali100x(ByVal sender As Object) As String
        If Not IsNumeric(sender) Then
            Return "0"
        ElseIf CDec(sender.ToString.Replace(".", ", ")) > 100 Then
            Return "100"
        Else
            Return sender
        End If
    End Function
    Private Sub btdevolucion_Click(sender As Object, e As EventArgs) Handles btOpcionDevolucion.Click
        If SesionActual.tienePermiso(Pdevolucion) Then
            Dim devolucion As New FormDevolucion
            devolucion.comboDevolucion = comboddevolucion
            devolucion.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btvencimiento_Click(sender As Object, e As EventArgs) Handles btOpcionVencimiento.Click
        If SesionActual.tienePermiso(Pvencimiento) Then
            Dim vencimiento As New FormVencimiento
            vencimiento.comboVencimiento = combodvencimiento
            vencimiento.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btplazo_Click(sender As Object, e As EventArgs) Handles btOpcionPlazo.Click
        If SesionActual.tienePermiso(Pplazo) Then
            Dim plazo As New FormPlazo
            plazo.comboPlazo = Comboplazo
            plazo.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btentrega_Click(sender As Object, e As EventArgs) Handles btOpcionEntrega.Click
        If SesionActual.tienePermiso(Pentrega) Then
            Dim entrega As New FormEntrega
            entrega.comboEntrega = combodentrega
            entrega.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub text30dias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        ValidacionDigitacion.validarDinero(sender, e)
    End Sub

    Private Sub textcedula_nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textcuenta.KeyPress, textcedula_nit.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub


    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            General.deshabilitarControles(Groupinfo)
            btbuscarproveedor.Enabled = True
            dtPlazo.Rows.Add()
            idProveedor = String.Empty
            dgvplazo.ReadOnly = False
            cmbICA.Enabled = False
            cmbIVA.Enabled = False
            cmbFuente.Enabled = False
            textpuc.ReadOnly = True
            Textcodigociiu.ReadOnly = True
            Textcuentapuc.ReadOnly = True
            textciiu.ReadOnly = True
            If dgvplazo.ColumnCount > 0 Then
                dgvplazo.Columns(0).ReadOnly = True
                dgvplazo.Columns(1).ReadOnly = True
            End If

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvplazo_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvplazo.CellDoubleClick
        Dim respuesta As Boolean
        Try
            If Not btguardar.Enabled Then
                Exit Sub
            End If

            Dim filaActualGrilla As DataGridViewRow = dgvplazo.Rows(e.RowIndex)
            Dim filaActualTabla As DataRow = dtPlazo.Rows(e.RowIndex)
            If (filaActualGrilla.Cells("codplazo").Selected = True OrElse filaActualGrilla.Cells("descripcion").Selected = True) AndAlso filaActualTabla.Item("Estado").ToString = "" Then
                General.agregarItems(Consultas.PLAZO_LISTAR, TitulosForm.BUSQUEDA_PLAZOS, dgvplazo, dtPlazo)
            ElseIf Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "anular", dgvplazo) Then
                If filaActualTabla.Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    dtPlazo.Rows.RemoveAt(e.RowIndex)
                ElseIf filaActualTabla.Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                        respuesta = General.anularRegistro(Consultas.PLAZO_PROVEEDOR_ELIMINAR & "'" & Textcodigo.Text & "','" & filaActualTabla.Item("codplazo") & "'," & SesionActual.codigoEP & "")
                        If respuesta Then
                            llenarDgvPlazo()
                            dtPlazo.Rows.Add()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Function validarInformacion()
        If (Textnit.Text = "") Then
            MsgBox("¡ Por favor elija un proveedor!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(comboregimen)
            comboregimen.Focus()
            Return False
        ElseIf (comboregimen.SelectedIndex < 1) Then
            MsgBox("¡ Por favor elija algun tipo de regimen!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(comboregimen)
            comboregimen.Focus()
            Return False
        ElseIf (comboTipopago.SelectedIndex = 0 OrElse (comboTipopago.SelectedValue = "")) Then
            MsgBox("¡ Por favor elija el tipo de pago!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(comboTipopago)
            comboTipopago.Focus()
            Return False
        ElseIf (comboubicacion.SelectedIndex = 0) Then
            MsgBox("¡ Por favor elija alguna ubicacion!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(comboubicacion)
            comboubicacion.Focus()
            Return False
        ElseIf (combofpago.SelectedIndex < 1) Then
            MsgBox("¡ Por favor elija alguna forma de pago", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(combofpago)
            combofpago.Focus()
            Return False
        ElseIf (combodentrega.SelectedIndex = 0) OrElse (combodentrega.SelectedValue = "") Then
            MsgBox("¡ Por favor elija algun dia de entrega!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(combodentrega)
            combodentrega.Focus()
            Return False
        ElseIf (combodvencimiento.SelectedIndex = 0) OrElse (combodvencimiento.SelectedValue = "") Then
            MsgBox("¡ Por favor eliga los dias para la devolucion por vencimiento !", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(combodvencimiento)
            combodvencimiento.Focus()
            Return False
        ElseIf (comboddevolucion.SelectedIndex = 0) OrElse (comboddevolucion.SelectedValue = "") Then
            MsgBox("¡ Por favor elija algun dia de devolucion!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(comboddevolucion)
            comboddevolucion.Focus()
            Return False
        ElseIf (Textcuentapuc.Text = "") Then
            MsgBox("¡ Por favor elija una cuenta para el proveedor!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(btpuc)
            btpuc.Focus()
            Return False
        ElseIf (textciiu.Text = "") Then
            MsgBox("¡ Por favor elija un codigo CIIU para el proveedor!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(btciiu)
            btciiu.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btPorveedorLab.Click
        If Textcodigo.Text <> "" Then
            FormPrincipal.Cursor = Cursors.WaitCursor
            FormProveedorLab.MdiParent = FormPrincipal
            General.limpiarControles(FormProveedorLab)
            FormProveedorLab.Show()
            FormProveedorLab.setTipoLista(Constantes.PROVEEDOR, Textcodigo.Text, Textnit.Text, textrazonsocial.Text)
            FormProveedorLab.Focus()
            If FormProveedorLab.WindowState = FormWindowState.Minimized Then
                FormProveedorLab.WindowState = FormWindowState.Normal
            End If
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox("Debe escoger el proveedor")
        End If
    End Sub

    Public Function crearProveedor() As Proveedor
        Dim objProveedor As New Proveedor
        objProveedor.idProveedor = idProveedor
        objProveedor.codigoProveedor = Textcodigo.Text
        objProveedor.formaPago = combofpago.SelectedValue
        objProveedor.regimen = comboregimen.SelectedValue
        objProveedor.ubicacion = comboubicacion.SelectedValue
        objProveedor.codigoDiaEntrega = combodentrega.SelectedValue
        objProveedor.codigoDiaVencimiento = combodvencimiento.SelectedValue
        objProveedor.codigoDiaDevolucion = comboddevolucion.SelectedValue
        objProveedor.observacion = Textobservacion.Text
        objProveedor.suspendido = suspen
        objProveedor.bloqueado = bloq
        objProveedor.codigoEp = SesionActual.codigoEP
        objProveedor.tipoPago = comboTipopago.SelectedValue
        objProveedor.banco = combobanco.SelectedValue
        objProveedor.TipocuentaBancaria = Combocuenta.SelectedValue
        objProveedor.numeroCuenta = textcuenta.Text
        objProveedor.identificacionProveedor = textcedula_nit.Text
        objProveedor.reteIca = r_ica
        objProveedor.reteFuente = r_fuente
        objProveedor.reteIva = r_iva
        objProveedor.ctaReteIca = cmbICA.SelectedValue
        objProveedor.ctaReteIva = cmbIVA.SelectedValue
        objProveedor.ctaReteFuente = cmbFuente.SelectedValue
        objProveedor.idEmpresa = SesionActual.idEmpresa
        objProveedor.cuentaPuc = Textcuentapuc.Text
        objProveedor.codigoCiiu = Textcodigociiu.Text
        objProveedor.dtPlazo = dtPlazo
        objProveedor.usuario = SesionActual.idUsuario
        objProveedor.codigoPuc = codigoPuc
        Return objProveedor
    End Function
    Private Sub guardarProveedor()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                Dim objProveedorBLL As New ProveedorBLL
                objProveedorBLL.guardarProveedor(crearProveedor())
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            llenarDgvPlazo()
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarProveedor()
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarControles(Groupinfo)
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                If cbreteica.Checked = True Then
                    cmbICA.Enabled = True
                Else
                    cmbICA.Enabled = False
                End If
                If cbreteiva.Checked = True Then
                    cmbIVA.Enabled = True
                Else
                    cmbIVA.Enabled = False
                End If
                If cbretefuente.Checked = True Then
                    cmbFuente.Enabled = True
                Else
                    cmbFuente.Enabled = False
                End If
                idProveedor = Textcodigo.Text
                dtPlazo.Rows.Add()
                textpuc.ReadOnly = True
                Textcodigociiu.ReadOnly = True
                Textcuentapuc.ReadOnly = True
                textciiu.ReadOnly = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim objProveedorBLL As New ProveedorBLL
                Dim objProveedor As New Proveedor
                objProveedor.codigoProveedor = Textcodigo.Text
                objProveedor.usuario = SesionActual.idUsuario
                objProveedor.idEmpresa = SesionActual.idEmpresa
                Try
                    objProveedorBLL.proveedorAnular(objProveedor)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cbreteica_CheckedChanged(sender As Object, e As EventArgs) Handles cbreteica.CheckedChanged
        If cbreteica.Checked = True Then
            r_ica = True
            cmbICA.Enabled = True
        Else
            r_ica = False
            cmbICA.Enabled = False
            cmbICA.SelectedIndex = 0
        End If
    End Sub
    Private Sub cbreteiva_CheckedChanged(sender As Object, e As EventArgs) Handles cbreteiva.CheckedChanged
        If cbreteiva.Checked = True Then
            r_iva = True
            cmbIVA.Enabled = True
        Else
            r_iva = False
            cmbIVA.Enabled = False
            cmbIVA.SelectedIndex = 0
        End If
    End Sub
    Private Sub cbretefuente_CheckedChanged(sender As Object, e As EventArgs) Handles cbretefuente.CheckedChanged
        If cbretefuente.Checked = True Then
            r_fuente = True
            cmbFuente.Enabled = True
        Else
            r_fuente = False
            cmbFuente.Enabled = False
            cmbFuente.SelectedIndex = 0
        End If
    End Sub
    Private Sub Checksus_CheckedChanged(sender As Object, e As EventArgs)
        If Checksus.Checked = True Then
            suspen = True
        Else
            suspen = False
        End If
    End Sub
    Private Sub CheckBlo_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBlo.Checked = True Then
            bloq = True
        Else
            bloq = False
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(Consultas.BUSQUEDA_PROVEEDOR,
                                   params,
                                   AddressOf cargarProveedor,
                                    TitulosForm.BUSQUEDA_PROVEEDOR,
                                   True, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarProveedor(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.PROVEEDOR_DATOS_CARGAR, params, dt)
        Textcodigo.Text = pCodigo
        Textnit.Text = dt.Rows(0).Item("NIT").ToString
        Textdv.Text = dt.Rows(0).Item("DV").ToString
        textrazonsocial.Text = dt.Rows(0).Item("PROVEEDOR").ToString
        combofpago.SelectedValue = dt.Rows(0).Item("Forma_Pago").ToString
        comboregimen.SelectedValue = dt.Rows(0).Item("Codigo_tipo_regimen").ToString
        comboubicacion.SelectedValue = dt.Rows(0).Item("Ubicacion").ToString
        combodentrega.SelectedValue = dt.Rows(0).Item("Codigo_dia_entrega").ToString
        combodvencimiento.SelectedValue = dt.Rows(0).Item("Codigo_dia_vencimiento").ToString
        comboddevolucion.SelectedValue = dt.Rows(0).Item("Codigo_dia_devolucion").ToString
        Textobservacion.Text = dt.Rows(0).Item("Observaciones").ToString
        Checksus.Checked = dt.Rows(0).Item("Suspendido").ToString
        CheckBlo.Checked = dt.Rows(0).Item("Bloqueado").ToString
        comboTipopago.SelectedValue = dt.Rows(0).Item("Tipo_pago").ToString
        If Not IsDBNull(dt.Rows(0).Item("Tipo_Cuenta")) Then
            Combocuenta.SelectedValue = dt.Rows(0).Item("Tipo_Cuenta").ToString
        Else
            Combocuenta.SelectedValue = Constantes.VALOR_PREDETERMINADO
        End If
        If Not IsDBNull(dt.Rows(0).Item("Codigo_Banco")) Then
            combobanco.SelectedValue = dt.Rows(0).Item("Codigo_Banco").ToString
        Else
            combobanco.SelectedValue = Constantes.VALOR_PREDETERMINADO
        End If
        textcuenta.Text = dt.Rows(0).Item("Numero_Cuenta").ToString
        textcedula_nit.Text = dt.Rows(0).Item("Cedula_cuenta").ToString
        If Not IsDBNull(dt.Rows(0).Item("RetenerIVA")) Then
            cbreteiva.Checked = dt.Rows(0).Item("RetenerIVA")
        Else
            cbreteiva.Checked = False
        End If
        If Not IsDBNull(dt.Rows(0).Item("RetenerFuente")) Then
            cbretefuente.Checked = dt.Rows(0).Item("RetenerFuente")
        Else
            cbretefuente.Checked = False
        End If
        If Not IsDBNull(dt.Rows(0).Item("RetenerICA")) Then
            cbreteica.Checked = dt.Rows(0).Item("RetenerICA")
        Else
            cbreteica.Checked = False
        End If

        If Not IsDBNull(dt.Rows(0).Item("CTAreteICA")) Then
            cmbICA.SelectedValue = dt.Rows(0).Item("CTAreteICA").ToString
        Else
            cmbICA.SelectedValue = Constantes.VALOR_PREDETERMINADO
        End If
        If Not IsDBNull(dt.Rows(0).Item("CTAreteIVA")) Then
            cmbIVA.SelectedValue = dt.Rows(0).Item("CTAreteIVA").ToString
        Else
            cmbIVA.SelectedValue = Constantes.VALOR_PREDETERMINADO
        End If
        If Not IsDBNull(dt.Rows(0).Item("CTAreteFuente")) Then
            cmbFuente.SelectedValue = dt.Rows(0).Item("CTAreteFuente").ToString
        Else
            cmbFuente.SelectedValue = Constantes.VALOR_PREDETERMINADO
        End If
        Combopais.SelectedValue = dt.Rows(0).Item("Codigo_Pais").ToString
        Combodepartamento.SelectedValue = dt.Rows(0).Item("Codigo_Departamento").ToString
        Combociudad.SelectedValue = dt.Rows(0).Item("Codigo_Municipio").ToString
        Textdireccion.Text = dt.Rows(0).Item("DIRECCION").ToString
        Textemail.Text = dt.Rows(0).Item("email").ToString
        Texttelefono.Text = dt.Rows(0).Item("Telefono").ToString
        Textcelular.Text = dt.Rows(0).Item("celular").ToString
        textciiu.Text = dt.Rows(0).Item("descripcion").ToString
        Textcodigociiu.Text = dt.Rows(0).Item("codigo_ciiu").ToString
        Textcuentapuc.Text = dt.Rows(0).Item("cuenta_proveedor").ToString
        textpuc.Text = dt.Rows(0).Item("nombre_cuenta").ToString
        llenarDgvPlazo()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btOpcionListaPrecio.Enabled = True
        btPorveedorLab.Enabled = True
    End Sub
End Class