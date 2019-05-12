Imports System.Threading
Public Class Form_hemodialisis
    Dim objHemodialisis As New Hemodialisis
    Dim reporteParams As New ReporteParams
    Dim usuarioActual As String
    Dim nRegistro As String
    Dim vFormPadre As Form_Historia_clinica
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pNueva, pEditar, pAnular As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(objHemodialisis.sqlBuscarRegistro,
                           params,
                           AddressOf cargarHemodialisis,
                           objHemodialisis.titulo,
                           True, Constantes.TAMANO_MEDIANO, True)
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvMedicamentos.EndEdit()
        dgvSigno.EndEdit()
        If validarCampos() = True Then
            If String.IsNullOrEmpty(objHemodialisis.CodigoOrden) Then
                Dim filaActual As DataGridViewRow = vFormPadre.dgvProcedimiento.CurrentRow
                filaActual.Cells("dgCodigoProce").Tag = Me
                Visible = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Exit Sub
            Else
                guardarInforme()
            End If

        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        'Dim ruta, nombreArchivo As String
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try

            objHemodialisis.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Function validarCampos()
        Dim resultado As Boolean
        If String.IsNullOrEmpty(txtidentificacion.Text) Then
            MsgBox("¡Por favor seleccione el paciente!", MsgBoxStyle.Exclamation)
            txtidentificacion.Focus()
        ElseIf String.IsNullOrEmpty(txtnota.Text) Then
            TabControl1.SelectedTab = TabPage5
            MsgBox("¡Por favor digitar la nota del hemodialisis!", MsgBoxStyle.Exclamation)
            txtnota.Focus()

        ElseIf String.IsNullOrEmpty(txtresultado.Text) AndAlso Not String.IsNullOrEmpty(objHemodialisis.codigo) Then
            TabControl1.SelectedTab = TabPage6
            MsgBox("¡Por favor digitar el resultado de la hemodialisis!", MsgBoxStyle.Exclamation)
            txtresultado.Focus()

        Else
            resultado = True
        End If
        Return resultado
    End Function

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objHemodialisis.anularHemodialisis(reporteParams.activoAM, reporteParams.activoAF)
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

    Public Sub guardarInforme(Optional pSegundoPlano As Boolean = False,
                              Optional pCodigoOrden As Integer = Constantes.VALOR_PREDETERMINADO)

        Try
            If (pSegundoPlano = False AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes) OrElse pSegundoPlano = True Then
                If pCodigoOrden > 0 Then
                    objHemodialisis.CodigoOrden = pCodigoOrden
                End If
                btimprimir.Enabled = False
                objHemodialisis.fechaRegistro = dtfecha.Text
                objHemodialisis.usuario = SesionActual.idUsuario
                objHemodialisis.usuarioReal = IIf(String.IsNullOrEmpty(objHemodialisis.usuarioReal), objHemodialisis.usuario, objHemodialisis.usuarioReal)
                objHemodialisis.nota = txtnota.Text
                objHemodialisis.resultado = txtresultado.Text
                objHemodialisis.guardarRegistro()
                reporteParams.codigoTemporal = objHemodialisis.codigo
                usuarioActual = objHemodialisis.usuario
                nRegistro = objHemodialisis.nRegistro

                If pSegundoPlano = False Then
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)

                    cargarHemodialisis(reporteParams.codigoTemporal)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    'guardarReporte(reporteParams)
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                End If

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If reporteParams.moduloTemporal = Constantes.AM OrElse reporteParams.moduloTemporal = Constantes.AF Then
                If buscarUsuarioReal() = False Then
                    Exit Sub
                End If
            End If
            iniciarForm()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub iniciarForm()
        Try
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            General.deshabilitarControles(GroupDatos)
            General.deshabilitarControles(GroupOtrosD)
            cargarInsumosAuditoria()
            btcancelar.Enabled = True
            btguardar.Enabled = True
            dtfecha.Enabled = True
        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.deshabilitarControles(Me)
        General.limpiarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        objHemodialisis.codigo = String.Empty
        reporteParams.codigoTemporal = String.Empty
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        btbuscarPaciente.Enabled = False
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNueva) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                If buscarUsuarioReal() = False Then
                    Exit Sub
                End If
            Else
                objHemodialisis.usuarioReal = SesionActual.idUsuario
            End If
            General.limpiarControles(Me)
            objHemodialisis.codigo = String.Empty
            iniciarForm()
            btbuscarPaciente.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub
    Private Function buscarUsuarioReal() As Boolean
        Dim bandera As Boolean
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_ORDEN_INSUMO_ENFER)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objHemodialisis.usuarioReal = tbl(0)
            bandera = True
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
        End If
        Return bandera
    End Function
    Public Sub cargarDatosParaSolicitud(ByRef vFormPadre As Form_Historia_clinica, descripcionArea As String, pUsuarioInforme As Integer)
        Dim objInformeBLL As New InformeQuirurgicoBLL
        Me.vFormPadre = vFormPadre
        Tag = vFormPadre.Tag
        reporteParams.moduloTemporal = Tag.Modulo
        Try
            objHemodialisis = GeneralHC.fabricaHC.crear(Constantes.CODIGO_HEMODIALISIS & reporteParams.moduloTemporal)
            If buscarUsuarioReal() = True Then
                objHemodialisis.idEmpresa = SesionActual.codigoEP
                objHemodialisis.usuario = SesionActual.idUsuario
                objHemodialisis.usuarioReal = pUsuarioInforme
                objHemodialisis.CodigoProcedimiento = vFormPadre.dgvProcedimiento.DataSource.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).item("Código").ToString
                objHemodialisis.banderaVerificarSolic = True
                Label1.Text = objHemodialisis.titulo
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                '-----------------------------------------------------------------------
                lblentorno.Text = descripcionArea
                cargarDatos()

                validarGrillaSigno()
                validarGrillaMedicamento()
                dgvSigno.AutoGenerateColumns = False
                dgvSigno.DataSource = objHemodialisis.dtSigno
                dgvMedicamentos.AutoGenerateColumns = False
                dgvMedicamentos.DataSource = objHemodialisis.dtMedicamento

                asignarCodigoFormato()
                '---------------------------------------------------------------------
                cargarInsumosAuditoria()
                objInformeBLL.cargarValoresPredeterminados(objHemodialisis.CodigoProcedimiento,
                                                        TabControl1,
                                                        Name)
                ShowDialog()
            Else
                Exit Sub
            End If

        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
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
        dtfecha.Text = Format(vFormPadre.fechaOrdenMedica.Value, Constantes.FORMATO_FECHA_HORA_GEN)
        objHemodialisis.codigoArea = Funciones.consultarCodigoAreaServicio(txtregistro.Text)
        btAgregar.Enabled = True
        btbuscarPaciente.Visible = False
        btnuevo.Visible = False
        ToolStripSeparator1.Visible = False
    End Sub

    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)

        General.buscarItem(objHemodialisis.sqlBuscarPaciente,
                     params,
                     AddressOf cargarPacientes,
                     TitulosForm.BUSQUEDA_PACIENTE, False,, Constantes.TAMANO_MEDIANO)
    End Sub
    Private Sub cargarPacientes(drRegistros As DataRow)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        Dim objInformeBLL As New InformeQuirurgicoBLL
        Try

            objHemodialisis.CodigoOrden = drRegistros.Item(0)
            objHemodialisis.CodigoProcedimiento = drRegistros.Item(1)

            params.Add(objHemodialisis.CodigoOrden)
            params.Add(objHemodialisis.CodigoProcedimiento)

            drFila = General.cargarItem(objHemodialisis.sqlCargarPaciente, params)
            txtregistro.Text = drFila.Item("Registro")
            txtidentificacion.Text = drFila.Item("Documento")
            txtfechaingreso.Text = Format(CDate(drFila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = drFila.Item("Paciente").ToString
            txtsexo.Text = drFila.Item("Genero").ToString
            txtedad.Text = drFila.Item("Edad").ToString
            txtcodigocontrato.Text = drFila.Item("Codigo_EPS").ToString
            txtcontrato.Text = drFila.Item("Contrato").ToString
            lblentorno.Text = drFila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = drFila.Item("Cama").ToString
            Txtexamen.Text = drFila.Item("Descripcion")
            txtCodigoOrden.Text = objHemodialisis.CodigoOrden
            dtfecha.Text = Format(drFila.Item("Fecha"), Constantes.FORMATO_FECHA_HORA_GEN)
            objHemodialisis.codigoArea = drFila.Item("Codigo_Area_Servicio")
            objHemodialisis.nRegistro = txtregistro.Text
            btAgregar.Enabled = True
            cargarInsumosAuditoria()
            objInformeBLL.cargarValoresPredeterminados(objHemodialisis.CodigoProcedimiento,
                                                    TabControl1,
                                                    Name)
        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Form_hemodialisis_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
                                  objHemodialisis.dtMedicamento, 0, 1, dgvMedicamentos.Columns("dgCodigoMed").Index, True, True, 0,, AddressOf llenarMedicamento)
        ElseIf dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgQuitarMed").Selected = True And
                 Not IsDBNull(dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgCodigoMed").Value) Then
            objHemodialisis.dtMedicamento.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub
    Private Sub dgvMedicamentos_DataError(sender As DataGridView, e As DataGridViewDataErrorEventArgs) Handles dgvMedicamentos.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
        sender.CancelEdit()
    End Sub
    Private Sub dgvMedicamentos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMedicamentos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivoNo0
    End Sub
    Private Sub llenarMedicamento()
        objHemodialisis.dtMedicamento.Rows(dgvMedicamentos.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO
        For i = 0 To dgvMedicamentos.ColumnCount - 1
            dgvMedicamentos.Columns(i).ReadOnly = True
        Next
        dgvMedicamentos.Columns("dgCantidad").ReadOnly = False
        dgvMedicamentos.Rows(dgvMedicamentos.RowCount - 1).Cells("dgCantidad").ReadOnly = True
    End Sub
    Public Sub cargarHemodialisis(pCodigo As String)
        Dim params As New List(Of String)
        Dim drFila As DataRow
        Try
            objHemodialisis.codigo = pCodigo
            reporteParams.codigoTemporal = pCodigo
            params.Add(reporteParams.codigoTemporal)
            params.Add(0) '-------------------Representa una bandera en sql
            drFila = General.cargarItem(objHemodialisis.sqlCargarRegistro, params)

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
            Txtexamen.Text = drFila.Item("Descripcion")
            dtfecha.Text = drFila.Item("Fecha_examen")
            txtnota.Text = drFila.Item("nota")
            txtresultado.Text = drFila.Item("Resultado")
            txtCodigoOrden.Text = drFila.Item("Codigo_Orden")
            objHemodialisis.CodigoOrden = txtCodigoOrden.Text
            objHemodialisis.CodigoProcedimiento = drFila.Item("codigo_procedimiento")
            objHemodialisis.nRegistro = txtregistro.Text
            objHemodialisis.codigoArea = drFila.Item("Codigo_area_servicio")
            params.Clear()
            params.Add(reporteParams.codigoTemporal)
            params.Add(1) '-------------------Representa una bandera en sql 
            General.llenarTabla(objHemodialisis.sqlCargarRegistro, params, objHemodialisis.dtSigno)
            dgvSigno.DataSource = objHemodialisis.dtSigno

            params.Clear()
            params.Add(reporteParams.codigoTemporal)
            params.Add(2) '-------------------Representa una bandera en sql
            General.llenarTabla(objHemodialisis.sqlCargarRegistro, params, objHemodialisis.dtMedicamento)
            dgvMedicamentos.DataSource = objHemodialisis.dtMedicamento

            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btimprimir.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click

        If objHemodialisis.dtSigno.Rows.Count > 0 Then
            If objHemodialisis.dtSigno.Rows(dgvSigno.Rows.Count - 1).Item("Hora") = 23 Then Exit Sub
            objHemodialisis.dtSigno.Rows.Add(objHemodialisis.dtSigno.Rows(dgvSigno.Rows.Count - 1).Item("Hora") + 1)
            dgvSigno.Rows(dgvSigno.RowCount - 1).Cells(1).Selected = True
        Else
            objHemodialisis.dtSigno.Rows.Add(CDate(Funciones.Fecha(Constantes.FORMATO_HORA_NUMERO)).Hour)
        End If

    End Sub

    Private Sub dgvSigno_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSigno.CellClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If objHemodialisis.dtSigno.Rows.Count > 0 Then
            If dgvSigno.Rows(dgvSigno.CurrentCell.RowIndex).Cells("dgQuitarSigno").Selected = True Then
                objHemodialisis.dtSigno.Rows.RemoveAt(dgvSigno.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub Form_hemodialisis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If String.IsNullOrEmpty(reporteParams.moduloTemporal) Then
            reporteParams.moduloTemporal = Tag.modulo
        End If

        asignarCodigoFormato()

        permisoGeneral = perG.buscarPermisoGeneral(Name, reporteParams.moduloTemporal)
        reporteParams.activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        reporteParams.activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
        pNueva = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"

        If String.IsNullOrEmpty(lblentorno.Text) Then
            objHemodialisis = GeneralHC.fabricaHC.crear(Constantes.CODIGO_HEMODIALISIS & Tag.modulo)
            objHemodialisis.idEmpresa = SesionActual.codigoEP
            objHemodialisis.usuario = SesionActual.idUsuario
            Label1.Text = objHemodialisis.titulo
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If

        If objHemodialisis.banderaVerificarSolic = False Then
            validarGrillaSigno()
            validarGrillaMedicamento()
            dgvSigno.AutoGenerateColumns = False
            dgvSigno.DataSource = objHemodialisis.dtSigno
            dgvMedicamentos.AutoGenerateColumns = False
            dgvMedicamentos.DataSource = objHemodialisis.dtMedicamento
        End If

        If Not String.IsNullOrEmpty(lblentorno.Text) Then
            iniciarForm()
            btcancelar.Enabled = False
        End If
    End Sub
    Private Sub validarGrillaSigno()
        With dgvSigno
            .Columns.Item("dgHora").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgHora").DataPropertyName = "HORA"
            .Columns.Item("dgta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgta").DataPropertyName = "TA"
            .Columns.Item("dgfc").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfc").DataPropertyName = "FC"
            .Columns.Item("dgfr").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfr").DataPropertyName = "FR"
            .Columns.Item("dgtam").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgtam").DataPropertyName = "TAM"
            .Columns.Item("dgspo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgspo").DataPropertyName = "SPO3%"
            .Columns.Item("dgtemp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgtemp").DataPropertyName = "TEMP"
        End With
    End Sub
    Private Sub validarGrillaMedicamento()
        With dgvMedicamentos
            .ReadOnly = True
            .Columns.Item("dgCodigoMed").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigoMed").DataPropertyName = "Codigo"
            .Columns.Item("dginsumo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dginsumo").DataPropertyName = "Medicamento"
            .Columns.Item("dgCantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCantidad").DataPropertyName = "Cantidad"
        End With
    End Sub
    Private Sub cargarInsumosAuditoria()
        Try
            Dim params As New List(Of String)
            params.Add(objHemodialisis.codigoArea)
            params.Add(objHemodialisis.CodigoProcedimiento)
            params.Add(txtcodigocontrato.Text)

            General.llenarTabla(objHemodialisis.sqlCargarInsumoConfig, params, objHemodialisis.dtMedicamento)
            dgvMedicamentos.DataSource = objHemodialisis.dtMedicamento
            For i = 0 To dgvMedicamentos.ColumnCount - 1
                dgvMedicamentos.Columns(i).ReadOnly = True
            Next
            dgvMedicamentos.Columns("dgCantidad").ReadOnly = False
            objHemodialisis.dtMedicamento.Rows.Add()
            dgvMedicamentos.Rows(dgvMedicamentos.RowCount - 1).Cells("dgCantidad").ReadOnly = True
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Private Sub asignarCodigoFormato()
        txtnota.Tag = Constantes.COD_FORMATO_NOTA_PROCED
        txtresultado.Tag = Constantes.COD_FORMATO_RESULTADO
    End Sub
End Class