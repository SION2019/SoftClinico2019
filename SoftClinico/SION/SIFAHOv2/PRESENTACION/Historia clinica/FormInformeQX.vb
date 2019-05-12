Imports System.Threading
Public Class FormInformeQX
    Dim activoAM, activoAF As Boolean
    Dim informeQX As New InformeQx
    Dim codigoTemporal As String
    Dim vFormPadre As Form_Historia_clinica
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pNueva, pEditar, pAnular, usuarioActual, nRegistro, moduloTemporal As String

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub cargarDatosParaSolicitud(ByRef vFormPadre As Form_Historia_clinica, descripcionArea As String, pUsuarioInforme As Integer)
        Dim objInformeBLL As New InformeQuirurgicoBLL
        Tag = vFormPadre.Tag
        moduloTemporal = Tag.Modulo
        Try

            informeQX = GeneralHC.fabricaHC.crear(Constantes.CODIGO_INFORME_QX & moduloTemporal)
            informeQX.idEmpresa = SesionActual.codigoEP
            informeQX.usuario = SesionActual.idUsuario
            informeQX.usuarioReal = pUsuarioInforme
            informeQX.CodigoProcedimiento = vFormPadre.dgvProcedimiento.DataSource.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).item("Código").ToString

            Me.vFormPadre = vFormPadre
            Label1.Text = informeQX.titulo
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            '-----------------------------------------------------------------------
            lblentorno.Text = descripcionArea
            cargarDatos()
            asignarCodigoFormato()

            validarDgv(dgvdiagpre, informeQX.dtDiagPre)
            validarDgv(dgvdiagpos, informeQX.dtDiagpos)
            validarDgv(dgvMedicamentos, informeQX.dtMedicamento, True)
            validarDgv(dgvprocedimiento, informeQX.dtProcedimiento)

            informeQX.banderaVerificarSolic = True
            '-------------------------------------------------------------------------------------------------------------------------------
            llenarDiagnoticos()
            cargarInsumosAuditoria()
            cargarParaclinicoAuditoria()
            objInformeBLL.cargarValoresPredeterminados(informeQX.CodigoProcedimiento,
                                                      pagControles,
                                                      Name)
            ShowDialog()

        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNueva) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                If usuarioReal() = False Then
                    Return
                End If
            Else
                informeQX.usuarioReal = SesionActual.idUsuario
            End If
            General.limpiarControles(Me)
            informeQX.codigo = String.Empty
            iniciarForm()
            btbuscarPaciente.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        informeQX.codigo = String.Empty
        codigoTemporal = String.Empty
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) And
                moduloTemporal <> Constantes.HC Then
                If usuarioReal() = False Then
                    Return
                End If
            End If
            Try
                iniciarForm()
                cargarInsumosAuditoria()
                cargarParaclinicoAuditoria()
                informeQX.dtDiagpos.Rows.Add()
            Catch ex As Exception
                General.mensajeError(ex.Message)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub iniciarForm()
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(TabControl1)
        'General.deshabilitarControles(Groupaneste)
        dgvdiagpre.ReadOnly = True
        dgvdiagpos.ReadOnly = True
        dgvprocedimiento.ReadOnly = True
        btguardar.Enabled = True
        btcancelar.Enabled = True
    End Sub
    Private Sub dgvdiagpos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdiagpos.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvdiagpos.Rows(dgvdiagpos.CurrentCell.RowIndex).Cells("dgcodigopos").Selected = True _
            Or dgvdiagpos.Rows(dgvdiagpos.CurrentCell.RowIndex).Cells("dgdiagnosticopos").Selected = True) _
            And String.IsNullOrEmpty(dgvdiagpos.Rows(dgvdiagpos.CurrentCell.RowIndex).Cells("dgcodigopos").Value.ToString) Then
            General.agregarDiagnosticosCIE(dgvdiagpos, informeQX.dtDiagpos)
        ElseIf dgvdiagpos.Rows(dgvdiagpos.CurrentCell.RowIndex).Cells("dgquitardiag").Selected = True And
                Not IsDBNull(dgvdiagpos.Rows(dgvdiagpos.CurrentCell.RowIndex).Cells("dgcodigopos").Value) Then
            informeQX.dtDiagpos.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub dgvprocedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("dgcodigo").Selected = True _
            Or dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("dgprocedimiento").Selected = True) _
            And IsDBNull(dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("dgcodigo").Value) Then
            General.agregarItemsQx(Consultas.LISTA_PROCEDIMIENTOS_CUPS & txtregistro.Text &
                                   ConstantesHC.NOMBRE_PDF_SEPARADOR3, TitulosForm.BUSQUEDA_PROCEDIMIENTOS_CUPS,
                                  dgvprocedimiento, informeQX.dtProcedimiento)
        ElseIf dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("dgquitar").Selected = True And
            Not IsDBNull(dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("dgcodigo").Value) Then
            informeQX.dtProcedimiento.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub
    Private Function ValidarGuardar() As Boolean
        dgvMedicamentos.EndEdit()

        Dim resultado As Boolean = False

        If txtidentificacion.Text = String.Empty Then
            TabControl1.SelectedTab = TabPage1
            Exec.SavingMsg("¡ Por favor seleccione el paciente!", txtidentificacion)
        ElseIf cmbTipoAnestesia.SelectedValue > 1 And txtAnestesiologo.Text = "" Then
            TabControl1.SelectedTab = TabPage1
            Exec.SavingMsg("¡ Por favor seleccionar el anestesiologo!")
            btBusquedaAnestesiologo.Focus()
        ElseIf cmbTipoAnestesia.SelectedIndex = 0 Then
            TabControl1.SelectedTab = TabPage1
            Exec.SavingMsg("¡ Por favor seleccionar la anestesia!", cmbTipoAnestesia)
            cmbTipoAnestesia.Focus()
        ElseIf txtAyudante.Text = "" Then
            TabControl1.SelectedTab = TabPage1
            Exec.SavingMsg("¡ Por favor seleccionar un ayudante!")
            btBusquedaAyudante.Focus()
        ElseIf txtViaAbordajeAnestesia.text = "" Then
            TabControl1.SelectedTab = TabPage1
            Exec.SavingMsg("¡ Por favor seleccionar una via!")
            btBusquedaViaAbordaje.Focus()
        ElseIf txtViaQX.text = "" Then
            TabControl1.SelectedTab = TabPage1
            Exec.SavingMsg("¡ Por favor seleccionar una via!")
            btBusquedaQX.Focus()
        ElseIf Txthallazgos.Text = String.Empty Then
            TabControl1.SelectedTab = TabPage3
            Exec.SavingMsg("¡ Por favor digitar el hallazgos!", Txthallazgos)
            Txthallazgos.Focus()
        ElseIf Txtjustificacion.Text = String.Empty Then
            TabControl1.SelectedTab = TabPage3
            Exec.SavingMsg("¡ Por favor digitar la justificacion del procedimiento!", Txtjustificacion)
            Txtjustificacion.Focus()
        ElseIf Txtdescripcion.Text = String.Empty Then
            TabControl1.SelectedTab = TabPage3
            Exec.SavingMsg("¡ Por favor digitar la descripción del procedimiento !", Txtdescripcion)
            Txtdescripcion.Focus()
        ElseIf Txtconducta.Text = String.Empty Then
            TabControl1.SelectedTab = TabPage3
            Exec.SavingMsg("¡ Por favor digitar la conducta a seguir del procedimiento!", Txtconducta)
            Txtconducta.Focus()
        ElseIf dtFechaInicio.Value > dtFechaFin.Value Then
            Exec.SavingMsg("¡ La fecha fin, No puede ser Inferior a la fecha de inicio !", dtFechaInicio)
            dtFechaInicio.Focus()
        Else
            dgvMedicamentos.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Dim dt As New DataTable
            informeQX.dtMedicamento.AcceptChanges()
            dt = informeQX.dtMedicamento.Copy
            If dt.Select("Cantidad=0 and Codigo <> ''", "").Count > 0 Then
                TabControl1.SelectedTab = TabPage4
                Exec.SavingMsg(Mensajes.CANTIDAD_VALIDA, dgvMedicamentos)
            Else
                resultado = True
            End If
        End If
        Return resultado
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvMedicamentos.EndEdit()
        dgvprocedimiento.EndEdit()
        If Not ValidarGuardar() Then Return
        If String.IsNullOrEmpty(informeQX.CodigoOrden) Then
            vFormPadre.dgvProcedimiento.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).Cells("dgCodigoProce").Tag = Me
            Visible = False
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Exit Sub
        Else
            guardarInforme()
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click

        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try

            informeQX.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Public Sub guardarInforme(Optional pSegundoPlano As Boolean = False, Optional pCodigoOrden As Integer = Constantes.VALOR_PREDETERMINADO)
        Try
            If (pSegundoPlano = False _
                    AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes) _
                    OrElse pSegundoPlano = True Then

                If pCodigoOrden > 0 Then
                    informeQX.CodigoOrden = pCodigoOrden
                End If
                btimprimir.Enabled = False
                informeQX.nRegistro = txtregistro.Text
                informeQX.usuario = SesionActual.idUsuario
                informeQX.fechaInicio = dtFechaInicio.Value
                informeQX.fechaFin = dtFechaFin.Value
                informeQX.setGetCodigoMedicamento = cmbTipoAnestesia.SelectedValue
                informeQX.hallazgo = Txthallazgos.Text
                informeQX.justificacionProcedimiento = Txtjustificacion.Text
                informeQX.descripcionProcedimiento = Txtdescripcion.Text
                informeQX.conductaSeguir = Txtconducta.Text
                informeQX.usuarioReal = IIf(String.IsNullOrEmpty(informeQX.usuarioReal), informeQX.usuario, informeQX.usuarioReal)
                informeQX.guardarRegistro()
                codigoTemporal = informeQX.codigo
                nRegistro = informeQX.nRegistro
                usuarioActual = informeQX.usuario

                If pSegundoPlano = False Then
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    cargarRegistrosQx(codigoTemporal)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    'guardarReporte()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    informeQX.anularInformeQX(activoAM, activoAF)
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(informeQX.sqlBuscarRegistro,
                               params,
                               AddressOf cargarRegistrosQx,
                               informeQX.titulo,
                               True, Constantes.TAMANO_MEDIANO, True)
    End Sub

    Private Sub dgvMedicamentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicamentos.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgCodigoMed").Selected = True _
            Or dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgInsumo").Selected = True) _
            And IsDBNull(dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgCodigoMed").Value) Then
            Dim params As New List(Of String)
            params.Add(txtregistro.Text)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_INSUMO)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvMedicamentos,
                                  informeQX.dtMedicamento, 0, 1, dgvMedicamentos.Columns("dgCodigoMed").Index, True, True, 0,, AddressOf llenarMedicamento)
        ElseIf dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgQuitarMed").Selected = True And
                 Not IsDBNull(dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgCodigoMed").Value) Then
            informeQX.dtMedicamento.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub llenarMedicamento()
        informeQX.dtMedicamento.Rows(dgvMedicamentos.Rows.Count - 2).Item("cantidad") = Constantes.VALOR_VALIDO
        For i = 0 To dgvMedicamentos.ColumnCount - 1
            dgvMedicamentos.Columns(i).ReadOnly = True
        Next
        dgvMedicamentos.Columns("cantidad").ReadOnly = False
        dgvMedicamentos.Rows(dgvMedicamentos.RowCount - 1).Cells("cantidad").ReadOnly = True
    End Sub

    Private Sub cargarDatos()

        txtregistro.Text = vFormPadre.txtRegistro.Text
        txtidentificacion.Text = vFormPadre.txtHC.Text
        txtfechaingreso.Text = vFormPadre.txtAdmision.Text
        txtpaciente.Text = vFormPadre.txtNombreContrato.Text
        txtsexo.Text = vFormPadre.txtSexo.Text
        txtedad.Text = vFormPadre.txtEdad.Text
        txtcodigocontrato.Text = vFormPadre.txtContrato.Text
        txtcontrato.Text = vFormPadre.txtNombreContrato.Text
        txtcama.Text = If(String.IsNullOrEmpty(vFormPadre.txtCama.Text), vFormPadre.txtCamaN.Text, vFormPadre.txtCama.Text)
        Txtexamen.Text = vFormPadre.dgvProcedimiento.DataSource.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).item("Descripción").ToString
        dtFechaInicio.Text = Format(vFormPadre.fechaOrdenMedica.Value, Constantes.FORMATO_FECHA_HORA_GEN)
        dtFechaFin.Text = Format(Convert.ToDateTime(vFormPadre.fechaOrdenMedica.Value).AddHours(+1), Constantes.FORMATO_FECHA_HORA_GEN)
        informeQX.codigoArea = Funciones.consultarCodigoAreaServicio(txtregistro.Text)
        btbuscarPaciente.Visible = False
        btnuevo.Visible = False
        ToolStripSeparator1.Visible = False
    End Sub

    Private Sub Form_Informe_QX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If String.IsNullOrEmpty(moduloTemporal) Then
            moduloTemporal = Tag.modulo
        End If

        asignarCodigoFormato()

        permisoGeneral = perG.buscarPermisoGeneral(Name, moduloTemporal)
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")

        pNueva = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"

        If String.IsNullOrEmpty(lblentorno.Text) Then
            informeQX = GeneralHC.fabricaHC.crear(Constantes.CODIGO_INFORME_QX & Tag.modulo)
            informeQX.idEmpresa = SesionActual.codigoEP
            informeQX.usuario = SesionActual.idUsuario
            Label1.Text = informeQX.titulo
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If

        General.cargarCombo(Consultas.TIPO_ANESTESIA_LISTAR,
        "Descripción", "Codigo_Tipo_Anestesia", cmbTipoAnestesia)

        If informeQX.banderaVerificarSolic = False Then
            validarDgv(dgvdiagpre, informeQX.dtDiagPre)
            validarDgv(dgvdiagpos, informeQX.dtDiagpos)
            validarDgv(dgvMedicamentos, informeQX.dtMedicamento, True)
            validarDgv(dgvprocedimiento, informeQX.dtProcedimiento)
            llenarDiagnoticos()
        End If

        If Not String.IsNullOrEmpty(lblentorno.Text) Then
            iniciarForm()
            btcancelar.Enabled = False
        End If

    End Sub
    Private Sub btBusquedaQX_Click(sender As Object, e As EventArgs) Handles btBusquedaQX.Click
        Dim tblViaQX As DataRow = Nothing

        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_VIAS_QX, Nothing, TitulosForm.BUSQUEDA_VIA, True)
        tblViaQX = formBusqueda.rowResultados
        If tblViaQX IsNot Nothing Then
            informeQX.idViaAbordQX = tblViaQX(0)
            txtViaQX.Text = tblViaQX(1)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub
    Private Sub btBusquedaViaAbordaje_Click(sender As Object, e As EventArgs) Handles btBusquedaViaAbordaje.Click
        Dim tblViaAbordaje As DataRow = Nothing

        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_BUSCAR_EQUIVALENCIA_QX, Nothing, TitulosForm.BUSQUEDA_VIA, True)
        tblViaAbordaje = formBusqueda.rowResultados
        If tblViaAbordaje IsNot Nothing Then
            informeQX.idViaAbrdAnestesia = tblViaAbordaje(0)
            txtViaAbordajeAnestesia.Text = tblViaAbordaje(1)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub btBusquedaAnestesiologo_Click(sender As Object, e As EventArgs) Handles btBusquedaAnestesiologo.Click
        Dim tblAnestesiologo As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_ANESTESIOLOGO)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.CARGO_EMPLEADO_LISTAR, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
        tblAnestesiologo = formBusqueda.rowResultados
        If tblAnestesiologo IsNot Nothing Then
            informeQX.idAnestesiologo = tblAnestesiologo(0)
            txtAnestesiologo.Text = tblAnestesiologo(1)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub
    Private Sub btBusquedaAyudante_Click(sender As Object, e As EventArgs) Handles btBusquedaAyudante.Click
        Dim tblAyudante As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_AYUDANTE_QX)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
        tblAyudante = formBusqueda.rowResultados
        If tblAyudante IsNot Nothing Then
            informeQX.idAyudante = tblAyudante(0)
            txtAyudante.Text = tblAyudante(1)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

    End Sub
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.codigoEP)
        General.buscarItem(informeQX.sqlBuscarPaciente,
                           params,
                           AddressOf cargarPacientes,
                           TitulosForm.BUSQUEDA_PACIENTE, False, True, Constantes.TAMANO_MEDIANO)
    End Sub
    Public Sub cargarPacientes(pFila As DataRow)
        Dim params As New List(Of String)
        Dim objInformeBLL As New InformeQuirurgicoBLL
        Dim fila As DataRow
        General.limpiarControles(Me)
        informeQX.CodigoOrden = pFila.Item(0)
        informeQX.CodigoProcedimiento = pFila.Item(1)
        params.Add(informeQX.CodigoOrden)
        params.Add(informeQX.CodigoProcedimiento)
        Try
            fila = General.cargarItem(informeQX.sqlCargarPaciente, params)
            txtregistro.Text = fila.Item("Registro")
            txtidentificacion.Text = fila.Item("Documento")
            txtfechaingreso.Text = Format(CDate(fila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = fila.Item("Paciente").ToString
            txtsexo.Text = fila.Item("Genero").ToString
            txtedad.Text = fila.Item("Edad").ToString
            txtcodigocontrato.Text = fila.Item("Codigo_EPS").ToString
            txtcontrato.Text = fila.Item("Contrato").ToString
            lblentorno.Text = fila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = fila.Item("Cama").ToString
            Txtexamen.Text = fila.Item("Descripcion")
            txtCodigoOrden.Text = fila.Item("Codigo_Orden")
            dtFechaFin.Text = Format(Convert.ToDateTime(fila.Item("Fecha_Orden")).AddHours(+1), Constantes.FORMATO_FECHA_HORA_GEN)
            dtFechaInicio.Text = Format(fila.Item("Fecha_Orden"), Constantes.FORMATO_FECHA_HORA_GEN)
            informeQX.nRegistro = txtregistro.Text
            informeQX.codigoArea = fila.Item("Codigo_Area_Servicio")

            llenarDiagnoticos()

            cargarInsumosAuditoria()
            cargarParaclinicoAuditoria()
            objInformeBLL.cargarValoresPredeterminados(informeQX.CodigoProcedimiento,
                                                  pagControles,
                                                  Name)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub llenarDiagnoticos()
        Dim params As New List(Of String)

        params.Add(txtregistro.Text)

        General.llenarTabla(informeQX.sqlcargarDiagUltimaEvo, params, informeQX.dtDiagPre)

        dgvdiagpre.DataSource = informeQX.dtDiagPre
        dgvdiagpos.DataSource = informeQX.dtDiagpos
        dgvMedicamentos.DataSource = informeQX.dtMedicamento

        informeQX.dtDiagpos.Rows.Add()
        informeQX.dtProcedimiento.Rows.Add()

        For i = 0 To dgvMedicamentos.ColumnCount - 1
            dgvMedicamentos.Columns(i).ReadOnly = True
        Next

        informeQX.dtMedicamento.Rows.Add()

        If informeQX.dtMedicamento.Rows.Count > 0 Then
            dgvMedicamentos.Rows(dgvMedicamentos.RowCount - 1).Cells("cantidad").ReadOnly = True
        End If

    End Sub
    Private Sub cargarRegistrosQx(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)

        informeQX.codigo = pCodigo
        codigoTemporal = pCodigo
        params.Add(codigoTemporal)
        params.Add(0) '--- Representa una bandera que se encuantra en el procedimiento sql
        drFila = General.cargarItem(informeQX.sqlCargarRegistro, params)
        Try
            txtregistro.Text = drFila.Item("Registro")
            txtidentificacion.Text = drFila.Item("Documento")
            txtfechaingreso.Text = Format(CDate(drFila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = drFila.Item("Paciente").ToString
            txtsexo.Text = drFila.Item("Genero").ToString
            txtedad.Text = drFila.Item("Edad").ToString
            txtcodigocontrato.Text = drFila.Item("Codigo_Contrato").ToString
            txtcontrato.Text = drFila.Item("Contrato").ToString
            lblentorno.Text = drFila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = drFila.Item("Cama").ToString
            Txtexamen.Text = drFila.Item("Descripcion_procedimiento")
            txtCodigoOrden.Text = drFila.Item("Codigo_Orden")
            dtFechaFin.Text = drFila.Item("Fecha_fin")
            dtFechaInicio.Text = drFila.Item("Fecha_ini")
            informeQX.codigoArea = drFila.Item("Codigo_Area_Servicio")
            informeQX.codigoAnestesia = drFila.Item("codigo_tipo_anastesia").ToString
            cmbTipoAnestesia.SelectedValue = informeQX.codigoAnestesia
            informeQX.idAnestesiologo = drFila.Item("Id_empleado_anestesiologo").ToString
            informeQX.idAyudante = drFila.Item("Id_empleado_ayudante").ToString
            informeQX.idViaAbrdAnestesia = drFila.Item("via").ToString
            informeQX.idViaAbordQX = drFila.Item("Id_Via_QX").ToString
            txtAnestesiologo.Text = drFila.Item("Anestesiologo").ToString
            txtAyudante.Text = drFila.Item("Ayudante").ToString
            txtViaAbordajeAnestesia.Text = drFila.Item("nombreVia").ToString
            txtViaQX.Text = drFila.Item("nombreViaQX").ToString
            Txthallazgos.Text = drFila.Item("Hallazgos")
            Txtdescripcion.Text = drFila.Item("Descripcion")
            Txtjustificacion.Text = drFila.Item("Justificacion")
            Txtconducta.Text = drFila.Item("Conducta")
            informeQX.CodigoProcedimiento = drFila.Item("Codigo_procedimiento")
            informeQX.CodigoOrden = drFila.Item("Codigo_Orden")
            informeQX.nRegistro = txtregistro.Text

            params.Clear()
            params.Add(codigoTemporal)
            params.Add(1) '--- Representa una bandera que se encuantra en el procedimiento sql
            General.llenarTabla(informeQX.sqlCargarRegistro, params, informeQX.dtProcedimiento)
            dgvprocedimiento.DataSource = informeQX.dtProcedimiento

            params.Clear()
            params.Add(codigoTemporal)
            params.Add(2) '--- Representa una bandera que se encuantra en el procedimiento sql
            General.llenarTabla(informeQX.sqlCargarRegistro, params, informeQX.dtDiagPre)
            dgvdiagpre.DataSource = informeQX.dtDiagPre

            params.Clear()
            params.Add(codigoTemporal)
            params.Add(3) '--- Representa una bandera que se encuantra en el procedimiento sql
            General.llenarTabla(informeQX.sqlCargarRegistro, params, informeQX.dtDiagpos)
            dgvdiagpos.DataSource = informeQX.dtDiagpos

            params.Clear()
            params.Add(codigoTemporal)
            params.Add(4) '--- Representa una bandera que se encuantra en el procedimiento sql
            General.llenarTabla(informeQX.sqlCargarRegistro, params, informeQX.dtMedicamento)
            dgvMedicamentos.DataSource = informeQX.dtMedicamento

            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btimprimir.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvMedicamentos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMedicamentos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivoNo0
    End Sub



    Private Sub dgvMedicamentos_DataError(sender As DataGridView, e As DataGridViewDataErrorEventArgs) Handles dgvMedicamentos.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
        sender.CancelEdit()
    End Sub

    Private Sub Form_Informe_QX_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If String.IsNullOrEmpty(txtCodigoOrden.Text) AndAlso Not IsNothing(vFormPadre) Then
            If IsNothing(vFormPadre.dgvProcedimiento.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).Cells("dgCodigoProce").Tag) = False Then
                Visible = False
                e.Cancel = True
                Exit Sub
            End If
        End If
        If Not String.IsNullOrEmpty(txtCodigoOrden.Text) OrElse btbuscar.Enabled = True OrElse btnuevo.Visible = True Then
            If btguardar.Enabled = True Then
                e.Cancel = True
                MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        Else
            If MsgBox(Mensajes.QUITAR_PROCEDIMIENTO, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            Else
                vFormPadre.eliminaFilaDt(vFormPadre.dgvProcedimiento.DataSource, vFormPadre.dgvProcedimiento.CurrentRow.Index)
            End If
        End If
    End Sub
    Private Sub validarDgv(ByRef dgv As DataGridView, dtTable As DataTable, Optional bdra As Boolean = False)
        With dgv
            .Columns(0).DataPropertyName = "Codigo"
            .Columns(1).DataPropertyName = If(bdra = True, "Medicamento", "Descripcion")
            If bdra = True Then
                .Columns(2).DataPropertyName = "Cantidad"
            End If
            .DataSource = dtTable
            .AutoGenerateColumns = False
        End With
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub cargarInsumosAuditoria()
        Try
            Dim params As New List(Of String)
            params.Add(informeQX.codigoArea)
            params.Add(informeQX.CodigoProcedimiento)
            params.Add(txtcodigocontrato.Text)
            informeQX.dtMedicamento.Clear()
            General.llenarTabla(informeQX.sqlCargarInsumoConfig, params, informeQX.dtMedicamento)
            dgvMedicamentos.DataSource = informeQX.dtMedicamento
            For i = 0 To dgvMedicamentos.ColumnCount - 1
                dgvMedicamentos.Columns(i).ReadOnly = True
            Next
            dgvMedicamentos.Columns("cantidad").ReadOnly = False
            informeQX.dtMedicamento.Rows.Add()
            dgvMedicamentos.Rows(dgvMedicamentos.RowCount - 1).Cells("cantidad").ReadOnly = True
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub cargarParaclinicoAuditoria()
        Try
            Dim params As New List(Of String)
            params.Add(informeQX.codigoArea)
            params.Add(informeQX.CodigoProcedimiento)
            params.Add(txtcodigocontrato.Text)
            params.Add(txtregistro.Text)
            informeQX.dtProcedimiento.Clear()
            General.llenarTabla(informeQX.sqlCargarParaclinicoConfig, params, informeQX.dtProcedimiento)
            dgvprocedimiento.DataSource = informeQX.dtProcedimiento
            For i = 0 To dgvprocedimiento.ColumnCount - 1
                dgvprocedimiento.Columns(i).ReadOnly = True
            Next
            informeQX.dtProcedimiento.Rows.Add()
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub asignarCodigoFormato()
        Txthallazgos.Tag = Constantes.COD_FORMATO_HALLAZGO
        Txtdescripcion.Tag = Constantes.COD_FORMATO_DESCRIP_PROCED
        Txtjustificacion.Tag = Constantes.COD_FORMATO_JUSTIF_DESCRICION
        Txtconducta.Tag = Constantes.COD_FORMATO_CONDUCTA
    End Sub
    Private Function usuarioReal() As Boolean
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        Dim estado As Boolean
        params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            informeQX.usuarioReal = tbl(0)
            estado = True
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
        End If
        Return estado
    End Function
End Class