Imports System.Threading
Public Class FormContratoLaboral
    Dim objContrato As New Contrato
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pterminar, Pempleado, Ptercero, PMinuta, PEditarSueldo, PeditarAuxTra As String
    Dim objContratoBLL As New ContratoLaboralBLL
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormContratoLaboral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        cargarPermiso()
        objContrato.idEmpresa = SesionActual.idEmpresa
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        objContratoBLL.cargarComboTipoContrato(combotipo)
        General.cargarCombo(Consultas.ESPECIALIDAD_LISTAR, "Descripción", "Código", cbEspecialidad)
        cargarDatatable()
        TabPage2.Parent = Nothing
        TabPage4.Parent = Nothing
        For i = 0 To dgvPuntoContrato.ColumnCount - 1
            dgvPuntoContrato.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub cargarPermiso()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pterminar = permiso_general & "pp" & "05"
        Pempleado = permiso_general & "pp" & "06"
        Ptercero = permiso_general & "pp" & "07"
        PMinuta = permiso_general & "pp" & "08"
        PEditarSueldo = permiso_general & "pp" & "09"
        PeditarAuxTra = permiso_general & "pp" & "10"
    End Sub
    Private Sub btbuscartercero_Click(sender As Object, e As EventArgs) Handles btbuscartercero.Click
        General.buscarElemento(Consultas.BUSQUEDA_SIN_CONTRATO_LABORAL_EMP & objContrato.idEmpresa,
                               Nothing,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_CONTRATO_LABORALES,
                               True, Constantes.TAMANO_MEDIANO, True)
    End Sub
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarEmpresa.Click
        If Funciones.consultaContratoFecha(objContrato.idEmpleado,
                                           objContrato.idEmpresa,
                                           dtFechaInic.Value.Date,
                                           dtFechaClaus.Value.Date) = False Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(objContrato.idEmpleado)
            params.Add(dtFechaInic.Value)
            params.Add(dtFechaClaus.Value)
            General.buscarElemento(Consultas.BUSQUEDA_EMPRESA_CONTRATO,
                                      params,
                                      AddressOf cargarEmpresa,
                                      TitulosForm.BUSQUEDA_EMPRESA, True, 0, True)
        Else
            MsgBox("El rango de fechas, no es valido hay un contrao vigente en esta fecha ", MsgBoxStyle.Exclamation)
            dtFechaInic.Focus()
        End If
    End Sub
    Private Sub cargarEmpresa(pCodigo As String)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        dFila = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR, params)
        objContrato.idEmpresaPagar = pCodigo
        If Not IsNothing(dFila) Then
            textNit.Text = dFila("Nit")
            textDV.Text = dFila("DV")
            textEmpresa.Text = dFila("Razon_Social")
        End If
        validarTipoContrato()
    End Sub
    Private Sub cargarTercero(pCodigo As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(objContrato.idEmpresa)
        params.Add(pCodigo)
        params.Add(combotipo.SelectedValue.ToString)
        Try
            drTercero = General.cargarItem(Consultas.CARGAR_EMPLEADO_SIN_CONTRATO, params)
            objContrato.idEmpleado = pCodigo
            txtidentificacion.Text = drTercero.Item("Nit")
            txtEmpleado.Text = drTercero.Item("Empleado")
            textsalario.Text = drTercero.Item("Valor_Salario").ToString()
            dtFechaInic.Value = drTercero.Item("Fecha_Comienzo").ToString()
            dtFechaClaus.Value = drTercero.Item("Fecha_Fin").ToString()
            cargarFotoEmpleado(If(IsDBNull(drTercero.Item("Foto")), Nothing, drTercero.Item("Foto")), pictureFoto)
            cargarFotoEmpleado(If(IsDBNull(drTercero.Item("Firma")), Nothing, drTercero.Item("Firma")), pictureFirma)
            btbuscarEmpresa.Enabled = True
            btbuscarEmpresa.Focus()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarFotoEmpleado(bites As Byte(), pImagen As PictureBox)
        If IsNothing(bites) = True Then
            pImagen.Image = Nothing
        Else
            If (bites IsNot DBNull.Value AndAlso bites.Length > 0) Then
                Dim ms As New MemoryStream(DirectCast(bites, Byte()))
                pImagen.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            End If
        End If
    End Sub
    Private Function validarCampos() As Boolean
        Dim ValOk As Boolean
        If (combotipo.SelectedIndex = 0) Then
            Exec.SavingMsg("¡ Por favor digite el tipo de contrato!", combotipo)
        ElseIf (IsNothing(objContrato.idEmpleado)) Then
            Exec.SavingMsg("¡ Por favor seleccione el empleado!", btbuscartercero)
        ElseIf String.IsNullOrEmpty(textNit.Text) Then
            Exec.SavingMsg("¡ Por favor seleccione la empresa que paga !", btbuscarEmpresa)
        ElseIf (textsalario.ReadOnly = False And combotipo.SelectedIndex = 1) And
            (Not IsNumeric(textsalario.Text)) OrElse (textsalario.Text = "") Then
            'OrElse (textsalario.Text <= 0)) OrElse (textsalario.Text = "") Then
            TabControl1.SelectedIndex = 0
            Exec.SavingMsg("¡ Por favor digite el salario del empleado!", textsalario)
        ElseIf (textAuxTrans.Enabled And combotipo.SelectedIndex = 1) _
            And (Not IsNumeric(textAuxTrans.Text) _
            OrElse (textAuxTrans.Text < 0)) _
            OrElse (textAuxTrans.Text = "") Then
            TabControl1.SelectedIndex = 0
            Exec.SavingMsg("¡ Por favor digite el Auxilio de Transporte!", textAuxTrans)
        ElseIf (objContrato.codigoMinuta < 1) Then
            Exec.SavingMsg("¡ Por favor digite la minuta del contrato!", textminuta)
        ElseIf objContrato.dtPunto.Rows.Count = 1 Then
            Exec.SavingMsg("¡ Por favor seleccione un punto donde labora !", dgvPuntoContrato)
        ElseIf String.IsNullOrEmpty(txtcodigo.Text) _
            And Funciones.consultarPeriodoContratoActivo(objContrato.idEmpleado, dtFechaInic.Value, dtFechaClaus.Value, objContrato.idEmpresaPagar) = True Then
            Exec.SavingMsg("¡ Existe un contrato Activo en este Periodo, Termine o Elimine el contrato para poder continuar. !", dtFechaInic)
        ElseIf CDate(dtFechaInic.Value).Date > CDate(dtFechaClaus.Value).Date Then
            Exec.SavingMsg("¡ La fecha de Inicio del contrato, no puede ser mayor que la de clausura !", dtFechaInic)
        Else
            ValOk = True
        End If
        Return ValOk
    End Function
    Private Sub cargarObjeto()
        objContrato.codigo = txtcodigo.Text
        objContrato.inicio = dtFechaInic.Value.Date
        objContrato.fin = dtFechaClaus.Value.Date
        objContrato.codigoMinuta = txtCodigoMinuta.Text
        objContrato.tipo = combotipo.SelectedValue
        objContrato.salario = CDbl(textsalario.Text)
        objContrato.auxilio = CDbl(textAuxTrans.Text)
        objContrato.diasPrueba = domDiaPrueba.Text
        objContrato.numeroGrupo = txtNumeroGrupo.Text
        objContrato.sena = If(rbSI.Checked = True, True, False)
        objContrato.nitCentro = If(String.IsNullOrEmpty(txtNitCentroF.Text), Nothing, txtNitCentroF.Text)
        objContrato.dvCentro = If(String.IsNullOrEmpty(txtDVCentro.Text), Nothing, txtDVCentro.Text)
        objContrato.centro = txtCentroF.Text
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            dtFechaClaus.Enabled = True
            dtFechaInic.Enabled = True
            combotipo.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscarminuta.Enabled = True
            objContrato.dtPunto.Rows.Add()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validarCampos() = True Then
                cargarObjeto()
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    objContratoBLL.guardar_contrato(objContrato)
                    txtcodigo.Text = objContrato.codigo
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    btbuscar.Enabled = True
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                objContrato.dtPunto.Rows.Add()
                btguardar.Enabled = True
                btcancelar.Enabled = True
                btbuscarEmpresa.Enabled = True
                btbuscarminuta.Enabled = True
                dtFechaClaus.Enabled = True
                textAuxTrans.ReadOnly = False
                textsalario.ReadOnly = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub combotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotipo.SelectedIndexChanged
        If Not String.IsNullOrEmpty(combotipo.ValueMember) Then
            If btguardar.Enabled = False Then Exit Sub
            btbuscartercero.Enabled = True
            btbuscartercero.Focus()
            If Not String.IsNullOrEmpty(txtEmpleado.Text) Then
                cargarTercero(objContrato.idEmpleado)
                validarTipoContrato()
            End If
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btnuevo) = True Then
            btbuscar.Enabled = True
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR & ":" & txtcodigo.Text.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_CONTRATO & txtcodigo.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub btbuscarminuta_Click(sender As Object, e As EventArgs) Handles btbuscarminuta.Click
        If combotipo.SelectedIndex = 0 Then
            MsgBox("Favor seleccionar el tipo de contrato", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(combotipo.SelectedValue)
        General.buscarElemento(Consultas.BUSQUEDA_CNTT_LBRLS_MINUTAS, params,
                               AddressOf cargarMinuta,
                               TitulosForm.BUSQUEDA_CNTT_LBRLS_MINUTAS, True)

    End Sub
    Sub cargarMinuta(pcodigo As Integer)
        Cursor = Cursors.WaitCursor
        txtCodigoMinuta.Text = pcodigo
        objContrato.codigoMinuta = pcodigo
        objContrato.cargarMinuta()
        objContrato.txtMinuta = textminuta
        txtDescripcionMinuta.Text = objContrato.nombreMinuta
        Cursor = Cursors.Default
    End Sub

    Private Sub textsalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textsalario.KeyPress
        If SesionActual.tienePermiso(PEditarSueldo) Then
            Dim digitacion As New ValidarDigito
            digitacion.validar_solo_numeros(e)
        Else
            e.Handled = True
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub textAuxTrans_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textAuxTrans.KeyPress
        If SesionActual.tienePermiso(PeditarAuxTra) Then
            Dim digitacion As New ValidarDigito
            digitacion.validar_solo_numeros(e)
        Else
            e.Handled = True
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub MostrarActivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarActivosToolStripMenuItem.Click
        buscarContrato(Consultas.BUSQUEDA_CONTRATO_LABORAL)
    End Sub
    Private Sub MostrarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarTodosToolStripMenuItem.Click
        buscarContrato(Consultas.BUSQUEDA_TODO_CONTRATO_LABORAL)
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim nombreArchivo, ruta, formula, nombreReporte As String
        Dim reporte As New ftp_reportes
        Try
            nombreReporte = Constantes.NOMBRE_CONTRATO

            Cursor = Cursors.WaitCursor

            nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR & objContrato.codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo

            formula = "{D_EMPLEADO_CONTRATO.Codigo_Contrato}= " & objContrato.codigo

            reporte.crearReportePDF(nombreReporte, objContrato.codigo, New rptContratoLaboral,
                                  objContrato.codigo, formula,
                                  nombreReporte, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub buscarContrato(Consulta As String)
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consulta & SesionActual.idEmpresa,
                                   Nothing,
                                   AddressOf cargarEmpleadoContrato,
                                   TitulosForm.BUSQUEDA_CONTRATO_LABORALES,
                                   False,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarEmpleadoContrato(pCodigo As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Try
            drTercero = General.cargarItem(Consultas.CARGAR_EMPLEADO_CONTRATO, params)
            objContrato.codigo = pCodigo
            txtcodigo.Text = pCodigo
            objContrato.idEmpleado = drTercero.Item("Id_empleado")
            objContrato.idEmpresaPagar = drTercero.Item("Id_empresa_nomina")
            objContrato.codigoMinuta = drTercero.Item("Codigo_minuta")
            txtCodigoMinuta.Text = objContrato.codigoMinuta
            cargarMinuta(objContrato.codigoMinuta)
            txtidentificacion.Text = drTercero.Item("Nit")
            txtEmpleado.Text = drTercero.Item("Empleado")
            textsalario.Text = drTercero.Item("Valor_Salario").ToString()
            dtFechaInic.Value = drTercero.Item("Fecha_Comienzo").ToString()
            dtFechaClaus.Value = drTercero.Item("Fecha_Fin").ToString()
            textAuxTrans.Text = If(drTercero.Item("valor_auxilio").ToString() = "", 0,
                                   drTercero.Item("valor_auxilio"))
            cargarFotoEmpleado(If(IsDBNull(drTercero.Item("Foto")), Nothing, drTercero.Item("Foto")), pictureFoto)
            cargarFotoEmpleado(If(IsDBNull(drTercero.Item("Firma")), Nothing, drTercero.Item("Firma")), pictureFirma)
            combotipo.SelectedValue = drTercero.Item("Tipo_Contrato").ToString()
            domDiaPrueba.Text = drTercero.Item("Dias_prueba").ToString()
            txtNumeroGrupo.Text = drTercero.Item("Numero_grupo").ToString()
            txtNitCentroF.Text = drTercero.Item("NitCentro").ToString()
            txtDVCentro.Text = drTercero.Item("dvCentro").ToString()
            txtCentroF.Text = drTercero.Item("Formacion").ToString()
            cbEspecialidad.SelectedValue = If(combotipo.SelectedValue = Constantes.CONTRATO_APREDIZAJE,
                                              drTercero.Item("Codigo_Especialidad").ToString(), Constantes.PENDIENTE)

            If drTercero.Item("sena") = True Then
                rbSI.Checked = True
            Else
                RbNo.Checked = True
            End If
            cargarPuntosContrato(pCodigo)
            cargarEmpresa(objContrato.idEmpresaPagar)

            General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, bteditar, btanular)

            btbuscar.Enabled = True
            btTerminar.Enabled = True
            btimprimir.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub validarTipoContrato()
        habilitacionInicial()
        TabPage4.Parent = Nothing
        Select Case combotipo.SelectedValue
            Case Constantes.CONTRATO_lABORAL
                textsalario.ReadOnly = False
                textAuxTrans.ReadOnly = False
            Case Constantes.CONTRATO_APREDIZAJE
                TabPage4.Parent = TabControl1
                General.habilitarControles(gbAprendiz)
                cbEspecialidad.Enabled = False
        End Select
    End Sub
    Private Sub habilitacionInicial()
        textsalario.ReadOnly = True
        textAuxTrans.ReadOnly = True
        'textAuxTrans.Text = Constantes.VALOR_NO_APLICA
        If combotipo.SelectedValue <> Constantes.CONTRATO_lABORAL Then
            textsalario.Text = 0
            textAuxTrans.Text = 0
        End If
    End Sub
    Private Sub txtNitCentroF_TextChanged(sender As Object, e As EventArgs)
        Dim DV As New DigitoVerificacion
        Dim num As Integer
        num = DV.CalculaNit(txtNitCentroF.Text)
        txtDVCentro.Text = CType(num, String)
        If txtNitCentroF.Text = Nothing Then
            txtDVCentro.Text = Nothing
        End If
    End Sub
    Private Sub dtFechaClaus_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaInic.ValueChanged, dtFechaClaus.ValueChanged
        If btguardar.Enabled = False Then Exit Sub
        domDiaPrueba.Text = objContratoBLL.calcularPruebaDias(dtFechaInic.Value, dtFechaClaus.Value)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            If String.IsNullOrEmpty(textsalario.Text) Then
                MsgBox("Favor Colocar un valor en el salario", MsgBoxStyle.Exclamation)
                TabControl1.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub generarContrato()
        Try
            btimprimir.Enabled = False
            cargarObjeto()
            objContrato.cargarMinuta()
            objContrato.txtMinuta = textminuta
            txtDescripcionMinuta.Text = objContrato.nombreMinuta
            procesoSegundoPlano(objContrato)
        Catch ex As Exception
            General.manejoErrores(ex)
            objContratoBLL.cerrar_doc()
            btimprimir.Enabled = True
        End Try
    End Sub
    Public Sub procesoSegundoPlano(objContrato As Contrato)
        Try
            objContrato.hilo = New Thread(AddressOf crearDocumento)
            objContrato.hilo.Start(objContrato)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub crearDocumento(objContrato As Contrato)
        Try
            objContrato.pictImagen = pictureFirma
            objContratoBLL.llenar_minuta(objContrato)
            objContratoBLL.bytes_to_rtf(objContrato, objContrato.txtMinuta)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
    End Sub
    Private Sub textsalario_Leave(sender As Object, e As EventArgs) Handles textsalario.Leave
        validarValorMoneda()
    End Sub
    Private Sub validarValorMoneda()
        Dim textsalario1 As String = textsalario.Text.TrimStart(",").TrimEnd(",")
        If textsalario.Enabled And IsNumeric(textsalario1) Then
            textsalario.Text = textsalario1
        Else
            textsalario.Text = "0,00"
        End If
    End Sub
    Private Sub Form_Contrato_laboral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btTerminar_Click(sender As Object, e As EventArgs) Handles btTerminar.Click
        If SesionActual.tienePermiso(Pterminar) Then
            If MsgBox("¿Desea terminar este contrato " & txtcodigo.Text.ToString & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Terminar") = MsgBoxResult.Yes Then
                If MsgBox("¿Se quitarán el empleado del horario, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Terminar") = MsgBoxResult.Yes Then
                    panelRazon.Visible = True
                    txtRazones.ReadOnly = False
                    btContinuar.Enabled = True
                    btCancelarRazon.Enabled = True
                    panelRazon.BringToFront()
                    panelRazon.Focus()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btContinuar_Click(sender As Object, e As EventArgs) Handles btContinuar.Click
        Dim respuesta As Boolean
        If txtRazones.Text = String.Empty Then
            Exec.SavingMsg("Favor digitar la razón para terminar el Contrato ", txtRazones)
        Else
            Dim vRazon As String = txtRazones.Text.ToString
            respuesta = General.anularRegistro(Consultas.TERMINAR_CONTRATO & txtcodigo.Text &
                                               ConstantesHC.NOMBRE_PDF_SEPARADOR3 & "'" &
                                                vRazon & "'" &
            ConstantesHC.NOMBRE_PDF_SEPARADOR3 & SesionActual.idUsuario)
            If respuesta = True Then
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                panelRazon.Visible = False
                MsgBox("Contrato terminado con éxito", MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Sub btCancelarRazon_Click(sender As Object, e As EventArgs) Handles btCancelarRazon.Click
        panelRazon.Visible = False
    End Sub

    Private Sub cargarDatatable()
        With dgvPuntoContrato
            .Columns("codigoPunto").DataPropertyName = "codigo"
            .Columns("descrip").DataPropertyName = "Nombre"
            .Columns("anular").DisplayIndex = 2
            .DataSource = objContrato.dtPunto
        End With
    End Sub
    Private Sub cargarPuntosContrato(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla("PROC_CONTRATO_LABORAL_PUNTO", params, objContrato.dtPunto)
        dgvPuntoContrato.DataSource = objContrato.dtPunto
    End Sub
    Private Sub buscarPuntoServicio()
        If Not String.IsNullOrEmpty(dgvPuntoContrato.Rows(dgvPuntoContrato.CurrentCell.RowIndex).Cells(1).Value.ToString) Then Exit Sub
        General.agregarItems("[PROC_BUSQUEDA_TODOS_PUNTO] '',",
                               TitulosForm.BUSQUEDA_PUNTO_SERVICIO,
                               dgvPuntoContrato,
                               objContrato.dtPunto)
    End Sub
    Private Sub dgvPuntoContrato_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPuntoContrato.KeyDown
        If btguardar.Enabled = False Then Exit Sub
        If e.KeyCode = Keys.F3 Then
            buscarPuntoServicio()
        End If
    End Sub
    Private Sub dgvPuntoContrato_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuntoContrato.CellDoubleClick
        If btguardar.Enabled = False Then Exit Sub
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(objContrato.dtPunto.Rows(dgvPuntoContrato.CurrentCell.RowIndex).Item("codigo")) Then
                objContrato.dtPunto.Rows.RemoveAt(dgvPuntoContrato.CurrentCell.RowIndex)
            End If
        Else
            buscarPuntoServicio()
        End If
    End Sub
    Private Sub btOpcionEmpleado_Click(sender As Object, e As EventArgs) Handles btOpcionEmpleado.Click
        If SesionActual.tienePermiso(Pempleado) Then
            Dim form_empleado1 As New Form_empleado()
            General.cargarForm(form_empleado1)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btOpcionTercero_Click(sender As Object, e As EventArgs) Handles btOpcionTercero.Click
        If SesionActual.tienePermiso(Ptercero) Then
            General.cargarForm(FormTercero)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btpuntos_Click(sender As Object, e As EventArgs) Handles btOpcionMinuta.Click
        If SesionActual.tienePermiso(PMinuta) Then
            Dim Form_minutas1 As New Form_minutas
            General.cargarForm(Form_minutas1)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class