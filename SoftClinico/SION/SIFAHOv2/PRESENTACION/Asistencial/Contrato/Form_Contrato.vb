
Imports System.Data.SqlClient

Public Class Form_Contrato
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Public dtAreasServicio As New DataTable
    Public dtEPS As New DataTable
    Public idrepresentante As Integer
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, cadenaBuscar As String
    Dim elementoAEliminar As New List(Of String)
    Dim idEps As Integer
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Property objFormContrato As Form_Tarifas_Servicios
    Private Sub btplanes_Click(sender As Object, e As EventArgs) Handles btopcionAreaServicio.Click
        Dim objAreaServicio As New Area_Servicio
        General.cargarForm(objAreaServicio)
    End Sub
    Private Sub bttarifa_Click(sender As Object, e As EventArgs) Handles btopcionTarifa.Click
        Dim objFormContrato As New Form_Tarifas_Servicios
        objFormContrato.ShowDialog()
    End Sub
    Private Sub btlistmed_Click(sender As Object, e As EventArgs) Handles btopcionListaMed.Click
        Dim formListaPrecioMedicamento As New Form_Lista_Precio_Medicamento
        General.cargarForm(formListaPrecioMedicamento)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            elementoAEliminar.Clear()
            Textnit.ReadOnly = True
            Textdv.ReadOnly = True
            Textnombre.ReadOnly = True
            dtAreasServicio.Rows.Add()
            dtEPS.Rows.Add()
            dgventorno.ReadOnly = True
            dgvEPS.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub dgventorno_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgventorno.KeyDown
        If dgventorno.ReadOnly And btguardar.Enabled = True Then
            If e.KeyCode = Keys.F3 Then
                General.agregarAreasDeServicios(dgventorno, dtAreasServicio, SesionActual.codigoEP)
            End If
        End If
    End Sub
    Private Sub btbuscarrepresentante_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(String.Empty)

            General.buscarElemento(Consultas.BUSQUEDA_TERCERO,
                                             params,
                                             AddressOf cargarResponsable,
                                             TitulosForm.BUSQUEDA_RESPONSABLE,
                                             False)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarResponsable(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.TERCERO_CARGAR,
                                              params)
        idrepresentante = dr.Item(0)
        Textcedula.Text = dr.Item(2)
        Textnombrerepresentante.Text = dr.Item(8)
    End Sub
    Private Function validarInformacion()
        If (Textnit.Text = "") Then
            MsgBox("¡ Por favor elija un cliente!", MsgBoxStyle.Exclamation,)
            btbuscarcliente.Focus()
            Return False
        ElseIf Textcedula.Text = "" Then
            MsgBox("Digite la identificación del representante legal", MsgBoxStyle.Exclamation)
            Textcedula.Focus()
            Return False
        ElseIf Textnombrerepresentante.Text = "" Then
            MsgBox("Digite el nombre del representante legal", MsgBoxStyle.Exclamation)
            Textnombrerepresentante.Focus()
            Return False
        ElseIf textnumcontrato.Text = "" Then
            MsgBox("Digite el Numero del Contrato", MsgBoxStyle.Exclamation)
            textnumcontrato.Focus()
            Return False
        ElseIf (dgvEPS.RowCount = 1) Then
            MsgBox("Favor Especificar la EPS ", MsgBoxStyle.Exclamation)
            Return False
        ElseIf combotipocontrato.SelectedIndex < 1 Then
            MsgBox("Favor Especificar el Tipo de Contrato ", MsgBoxStyle.Exclamation)
            combotipocontrato.Focus()
            Return False
        ElseIf combotarifamed.SelectedIndex < 1 And combotarifamed.SelectedIndex < 1 Then
            MsgBox("Favor Especificar la Tarifa de Medicamento ", MsgBoxStyle.Exclamation)
            combotarifamed.Focus()
            Return False
        ElseIf combotarifaproce.SelectedIndex < 1 Then
            MsgBox("Favor Especificar la Tarifa de Servicio ", MsgBoxStyle.Exclamation)
            combotarifaproce.Focus()
            Return False
        ElseIf Combotarifalab.SelectedIndex < 1 Then
            MsgBox("Favor Especificar la Tarifa de Servicio ", MsgBoxStyle.Exclamation)
            Combotarifalab.Focus()
            Return False
        ElseIf Combotarifaimag.SelectedIndex < 1 Then
            MsgBox("Favor Especificar la Tarifa de Servicio ", MsgBoxStyle.Exclamation)
            Combotarifaimag.Focus()
            Return False
        ElseIf Combocodref.SelectedIndex < 1 Then
            MsgBox("Favor Especificar el Codigo de Referencia ", MsgBoxStyle.Exclamation)
            Combocodref.Focus()
            Return False
        ElseIf textvaloroxigeno.Text = "" Then
            MsgBox("Digite el Valor del Oxigeno ", MsgBoxStyle.Exclamation)
            textvaloroxigeno.Focus()
            Return False
        ElseIf textnumafiliados.Text = "" Then
            MsgBox("Digite el Numero de Afiliados ", MsgBoxStyle.Exclamation)
            textnumafiliados.Focus()
            Return False
        ElseIf Gpevento.Enabled = True And textvalorevento.Text = "" Then
            MsgBox("Favor Digite el valor de contrato por evento", MsgBoxStyle.Exclamation)
            textvalorevento.Focus()
            Return False
        ElseIf Gpevento.Enabled = True And Fecha_Ini_Evento.Value.ToString >= Fecha_final_Evento.Value.ToString Then
            MsgBox("La fecha final no debe de ser Igual o menor a la fecha Inicio", MsgBoxStyle.Exclamation)
            Fecha_final_Evento.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarContrato()
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                elementoAEliminar.Clear()
                Textnit.ReadOnly = True
                Textdv.ReadOnly = True
                Textnombre.ReadOnly = True
                Textcedula.ReadOnly = True
                Textnombrerepresentante.ReadOnly = True
                dtAreasServicio.Rows.Add()
                dtEPS.Rows.Add()
                btguardar.Enabled = True
                btcancelar.Enabled = True
                btotrosi.Enabled = True
                dgventorno.ReadOnly = True
                dgvEPS.ReadOnly = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Function crearContratoEps() As ContratoEps
        Dim valorCapitado, valorEvento As Double
        Dim objContratoEps As New ContratoEps
        valorEvento = textvalorevento.Text
        valorCapitado = textvalorcapitado.Text
        objContratoEps.codigoContrato = txtcodigo.Text
        objContratoEps.idCliente = Textidcliente.Text
        objContratoEps.codigoEPS = idEps
        objContratoEps.codigoListaPrecio = combotarifamed.SelectedValue
        objContratoEps.codigoListaPrecioVentaDirecta = cmbListaVentaDirecta.SelectedValue
        objContratoEps.codigoManual = Combomanual.SelectedValue
        objContratoEps.codigoHAP = combotarifaproce.SelectedValue
        objContratoEps.codigoHAL = Combotarifalab.SelectedValue
        objContratoEps.codigoHAI = Combotarifaimag.SelectedValue
        objContratoEps.codigoTipoContrato = combotipocontrato.SelectedValue
        objContratoEps.cedulaRepresentante = Textcedula.Text
        objContratoEps.nombreRepresentante = Textnombrerepresentante.Text
        objContratoEps.numContrato = textnumcontrato.Text
        objContratoEps.valorOxigeno = textvaloroxigeno.Text
        objContratoEps.valorEvento = valorEvento
        objContratoEps.fechaIniEvento = Fecha_Ini_Evento.Value
        objContratoEps.fechaFinalEvento = Fecha_final_Evento.Value
        objContratoEps.valorCapitado = valorCapitado
        objContratoEps.fechaIniCapit = Fecha_Ini_capitado.Value
        objContratoEps.fechaFinalCapit = Fecha_final_capitado.Value
        objContratoEps.numAfiliados = textnumafiliados.Text
        objContratoEps.estado = Ckinactivo.Checked
        objContratoEps.Usuario = SesionActual.idUsuario
        objContratoEps.codigoEp = SesionActual.codigoEP
        objContratoEps.dtAreasServicio = dtAreasServicio
        objContratoEps.dtEPS = dtEPS
        objContratoEps.codigoHabilitacion = ""
        Return objContratoEps
    End Function
    Private Sub guardarContrato()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objContrato As New ContratoBLL
                txtcodigo.Text = objContrato.guardarContrato(crearContratoEps(),
                                                             elementoAEliminar)

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                cargarContrato(txtcodigo.Text)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                tsddbBuscar.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub enlazarTabla()
        Dim codigo, descripcion, estado As New DataColumn

        codigo.ColumnName = "Codigo"
        codigo.DataType = Type.GetType("System.String")
        dtAreasServicio.Columns.Add(codigo)

        descripcion.ColumnName = "Descripcion"
        descripcion.DataType = Type.GetType("System.String")
        dtAreasServicio.Columns.Add(descripcion)

        estado.ColumnName = "Estado"
        estado.DataType = Type.GetType("System.String")
        dtAreasServicio.Columns.Add(estado)

        codigo = Nothing : descripcion = Nothing : estado = Nothing

        dgventorno.DataSource = dtAreasServicio
        dgventorno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        With dgventorno
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = False
            .Columns("Codigo").Width = 55
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 190
            .Columns("Estado").DataPropertyName = "Estado"
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = False
            .Columns("anular").ReadOnly = True
            .Columns("anular").DisplayIndex = CInt(dgventorno.ColumnCount - 1)
            .Columns("anular").Width = 80
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Private Sub enlazarTablaeps()
        Dim codigo, descripcion, estado As New DataColumn

        codigo.ColumnName = "Codigo"
        codigo.DataType = Type.GetType("System.String")
        dtEPS.Columns.Add(codigo)

        descripcion.ColumnName = "Descripcion"
        descripcion.DataType = Type.GetType("System.String")
        dtEPS.Columns.Add(descripcion)

        estado.ColumnName = "Estado"
        estado.DataType = Type.GetType("System.String")
        dtEPS.Columns.Add(estado)

        codigo = Nothing : descripcion = Nothing : estado = Nothing

        dgvEPS.DataSource = dtEPS
        dgvEPS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        With dgvEPS
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = False
            .Columns("Codigo").Width = 55
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 190
            .Columns("Estado").DataPropertyName = "Estado"
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = False
            .Columns("anularEps").ReadOnly = True
            .Columns("anularEps").DisplayIndex = CInt(dgvEPS.ColumnCount - 1)
            .Columns("anularEps").Width = 80
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Private Sub Form_Contrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        enlazarTabla()
        enlazarTablaeps()

        Dim cadena As String = ""
        General.cargarCombo(Consultas.MANUAL_BUSCAR, "Descripción", "Código", Combomanual)
        Combomanual.SelectedIndex = 0
        General.cargarCombo(Consultas.LISTA_PRECIO_BUSCAR & "'" & SesionActual.codigoEP & "'", "Nombre", "Código", combotarifamed)
        General.cargarCombo(Consultas.TIPO_CODIGO_REFERENCIA_BUSCAR, "Nombre", "Código", Combocodref)
        General.cargarCombo(Consultas.TIPO_CONTRATO_BUSCAR, "Nombre", "Código", combotipocontrato)
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.cargarCombo(Consultas.LISTAR_LISTAS_VENTA_DIRECTA, params, "Nombre", "Código", cmbListaVentaDirecta)
        General.deshabilitarControles(Me)
        cadenaBuscar = Consultas.BUSQUEDA_CONTRATO_EPS
    End Sub

    Private Sub btterminar_Click(sender As Object, e As EventArgs) Handles btterminar.Click
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.TERMINAR_CONTRATO_EPS & SesionActual.idUsuario & "," & CInt(txtcodigo.Text) & "")
                If respuesta = True Then
                    MsgBox("Este contrato ha sido terminado", MsgBoxStyle.Information)
                    General.limpiarControles(Me)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, Nothing)
                    tsddbBuscar.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btotrosi_Click(sender As Object, e As EventArgs) Handles btotrosi.Click
        Dim form_otro_si1 As New Form_Otro_Si
        form_otro_si1.iniciarForm(Me)
        form_otro_si1.cargarInformacionContrato(txtcodigo.Text, Textnombre.Text)
        form_otro_si1.ShowDialog()
    End Sub

    Private Sub dgventorno_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgventorno.CellDoubleClick
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgventorno.Rows(dgventorno.CurrentCell.RowIndex).Cells("Codigo").Selected = True _
                    Or dgventorno.Rows(dgventorno.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) _
                                    And dtAreasServicio.Rows(dgventorno.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
                General.agregarAreasDeServicios(dgventorno, dtAreasServicio, SesionActual.codigoEP)
            ElseIf dgventorno.Rows(dgventorno.CurrentCell.RowIndex).Cells("anular").Selected = True _
                And dtAreasServicio.Rows(dgventorno.CurrentCell.RowIndex).Item("Estado").ToString <> String.Empty Then
                If dtAreasServicio.Rows(dgventorno.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    dtAreasServicio.Rows.RemoveAt(e.RowIndex)
                ElseIf dtAreasServicio.Rows(dgventorno.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        elementoAEliminar.Add(Consultas.ANULAR_AREA_SERVICIO_CONTRATO & "'" & txtcodigo.Text &
                                              "','" & dtAreasServicio.Rows(dgventorno.CurrentCell.RowIndex).Item("Codigo") & "'")
                        dtAreasServicio.Rows.RemoveAt(e.RowIndex)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub dgvePS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEPS.CellDoubleClick
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvEPS.Rows(dgvEPS.CurrentCell.RowIndex).Cells("Codigo").Selected = True _
                    Or dgvEPS.Rows(dgvEPS.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) _
                                    And dtEPS.Rows(dgvEPS.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
                General.agregarEPS(dgvEPS, dtEPS)
            ElseIf dgvEPS.Rows(dgvEPS.CurrentCell.RowIndex).Cells("anularEPS").Selected = True _
                And dtEPS.Rows(dgvEPS.CurrentCell.RowIndex).Item("Estado").ToString <> String.Empty Then
                If dtEPS.Rows(dgvEPS.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    dtEPS.Rows.RemoveAt(e.RowIndex)
                ElseIf dtEPS.Rows(dgvEPS.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        elementoAEliminar.Add(Consultas.ANULAR_AREA_SERVICIO_CONTRATO_EPS & "'" & txtcodigo.Text &
                                              "','" & dtEPS.Rows(dgvEPS.CurrentCell.RowIndex).Item("Codigo") & "'")
                        dtEPS.Rows.RemoveAt(e.RowIndex)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub Combocodref_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combocodref.SelectedValueChanged
        If Combocodref.SelectedIndex <> 0 Then
            General.cargarCombo(Consultas.TARIFA_SERVICIO_BUSCAR & "'" & Combocodref.SelectedValue & "'", "Descripción tarifa", "Código", Combotarifaimag)
            General.cargarCombo(Consultas.TARIFA_SERVICIO_BUSCAR & "'" & Combocodref.SelectedValue & "'", "Descripción tarifa", "Código", Combotarifalab)
            General.cargarCombo(Consultas.TARIFA_SERVICIO_BUSCAR & "'" & Combocodref.SelectedValue & "'", "Descripción tarifa", "Código", combotarifaproce)
        End If
    End Sub

    Private Sub combotipocontrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotipocontrato.SelectedIndexChanged
        If combotipocontrato.SelectedIndex = 1 Then
            Gpevento.Enabled = True
            Gpcapitado.Enabled = False
            textvalorevento.Focus()
            textvalorcapitado.Text = 0
        ElseIf combotipocontrato.SelectedIndex = 2 Then
            Gpevento.Enabled = False
            Gpcapitado.Enabled = True
            textvalorcapitado.Focus()
            textvalorevento.Text = 0
        Else
            Gpcapitado.Enabled = False
            Gpevento.Enabled = False
            textvalorcapitado.Clear()
            textvalorevento.Clear()
        End If
    End Sub

    Private Sub cargarContrato(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.BUSQUEDA_CONTRATO_CARGAR,
                                              params)
        txtcodigo.Text = pCodigo
        Textidcliente.Text = dr.Item("id_cliente").ToString
        Textnit.Text = dr.Item("Nit").ToString
        Textdv.Text = dr.Item("DV").ToString
        Textnombre.Text = dr.Item("Cliente").ToString
        combotipocontrato.SelectedValue = dr.Item("Codigo_tipo_contrato").ToString
        combotarifamed.SelectedValue = dr.Item("Codigo_lista_precio").ToString
        cmbListaVentaDirecta.SelectedValue = dr.Item("Codigo_lista_precio_Venta").ToString
        Combomanual.SelectedValue = dr.Item("Codigo_manual").ToString
        Combocodref.SelectedValue = dr.Item("Codigo_Tipo_Codigo").ToString
        combotarifaproce.SelectedValue = dr.Item("Codigo_HAP").ToString
        Combotarifalab.SelectedValue = dr.Item("Codigo_HAL").ToString
        Combotarifaimag.SelectedValue = dr.Item("Codigo_HAI").ToString
        Textcedula.Text = dr.Item("cedula_representante_legal").ToString
        Textnombrerepresentante.Text = dr.Item("nombre_representante_legal").ToString
        textnumcontrato.Text = dr.Item("num_contrato").ToString
        textvaloroxigeno.Text = dr.Item("valor_oxigeno").ToString
        If Not IsDBNull(dr.Item("valor_evento")) Then
            textvalorevento.Text = CDbl(dr.Item("valor_evento").ToString).ToString("C2")
        Else
            textvalorevento.Text = 0
        End If
        If Not IsDBNull(dr.Item("fecha_ini_evento")) Then
            Fecha_Ini_Evento.Value = dr.Item("fecha_ini_evento").ToString
        Else
            Fecha_Ini_Evento.Value = Date.Now
        End If
        If Not IsDBNull(dr.Item("fecha_final_evento").ToString) Then
            Fecha_final_Evento.Value = dr.Item("fecha_final_evento").ToString
        Else
            Fecha_final_Evento.Value = Date.Now
        End If
        If Not IsDBNull(dr.Item("valor_capitado")) Then
            textvalorcapitado.Text = CDbl(dr.Item("valor_capitado").ToString).ToString("C2")
        Else
            textvalorcapitado.Text = 0
        End If
        If Not IsDBNull(dr.Item("fecha_ini_capit")) Then
            Fecha_Ini_capitado.Value = dr.Item("fecha_ini_capit").ToString
        Else
            Fecha_Ini_capitado.Value = Date.Now
        End If
        If Not IsDBNull(dr.Item("fecha_final_capit")) Then
            Fecha_final_capitado.Value = dr.Item("fecha_final_capit")
        Else
            Fecha_final_capitado.Value = Date.Now
        End If
        If Not IsDBNull(dr.Item("valor")) Then
            Textvalor_si.Text = CDbl(dr.Item("valor").ToString).ToString("C2")
            fecha_ini_si.Value = dr.Item("fecha_expedicion").ToString
            fecha_fin_si.Value = dr.Item("fecha_vencimiento").ToString
        Else
            Textvalor_si.Clear()
        End If
        textnumafiliados.Text = dr.Item("Num_Afiliados").ToString
        Ckinactivo.Checked = dr.Item("Estado").ToString

        General.llenarTabla(Consultas.AREAS_SERVICIO_CONTRATO_CARGAR, params, dtAreasServicio)
        General.llenarTabla(Consultas.EPS_CONTRATO_CARGAR, params, dtEPS)
        dgventorno.DataSource = dtAreasServicio
        dgventorno.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgventorno.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvEPS.DataSource = dtEPS
        dgvEPS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvEPS.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        General.posBuscarForm(Me, ToolStrip1, btnuevo, Nothing, bteditar, btanular)
        btterminar.Enabled = True
        tsddbBuscar.Enabled = True
    End Sub
    Private Sub Textvalor_si_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Textvalor_si.KeyPress, textnumafiliados.KeyPress, textvaloroxigeno.KeyPress, textvalorevento.KeyPress, textvalorcapitado.KeyPress, Textcedula.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, Nothing)
        tsddbBuscar.Enabled = True
        elementoAEliminar.Clear()
    End Sub


    Private Sub tsImprimirHoja_Click(sender As Object, e As EventArgs) Handles tsImprimirHoja.Click, tsImprimirTodas.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            If Not tsImprimirTodas.Pressed Then
                cadenaBuscar = Consultas.BUSQUEDA_CONTRATO_ACTIVO_EPS
            Else
                cadenaBuscar = Consultas.BUSQUEDA_CONTRATO_EPS
            End If
            General.buscarElemento(cadenaBuscar,
                                             params,
                                             AddressOf cargarContrato,
                                             TitulosForm.BUSQUEDA_CONTRATO,
                                             False, Constantes.TAMANO_MEDIANO)


        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_CONTRATO_EPS & "" & SesionActual.idUsuario & "," & CInt(txtcodigo.Text) & "")
                If respuesta = True Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, Nothing)
                    tsddbBuscar.Enabled = True
                End If
            End If
        End If
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
    Private Sub btbuscarcliente_Click(sender As Object, e As EventArgs) Handles btbuscarcliente.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(Consultas.BUSQUEDA_CLIENTES_CONTRATO,
                                             params,
                                             AddressOf cargarCliente,
                                             TitulosForm.BUSQUEDA_CLIENTES,
                                             True, 0, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarCliente(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_CLIENTES,
                                              params)
        Textidcliente.Text = pCodigo
        Textnit.Text = dr.Item(0)
        Textdv.Text = dr.Item(1)
        Textnombre.Text = dr.Item(2)
        Textcedula.Focus()
    End Sub
End Class