Public Class FormAntencionAmb
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Ppaciente As String
    Dim idPaciente As Integer
    Dim dtdesglose As New DataTable() ''estos dt deben ir en el objeto
    Dim objAtencionAM As AtencionAM

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Modulos_perfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Public Sub verificarTotales()

    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            btcancelar.Enabled = True
            btbuscarPaciente.Enabled = True
            btbuscarSolicitud.Enabled = True
            objAtencionAM.codAtencion = ""
            LinkLabel1.Enabled = True
            LinkLabel3.Enabled = True
            'General.cargarItem(ConsultasAmbu.SOLICITUD_CARGAR_AM, Nothing)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscarSolicitud_Click(sender As Object, e As EventArgs) Handles btbuscarSolicitud.Click
        General.buscarItem(Consultas.BUSCAR_AM_SOLICITUD,
                              Nothing,
                              AddressOf cargarSolicitudAM,
                              TitulosForm.BUSQUEDA_PACIENTE,
                              True) ' permite traer todos los elementos de la consulta
    End Sub
    Public Sub cargarSolicitudAM(sCodigo As DataRow)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        General.limpiarControles(Me)
        habControl()
        objAtencionAM.codigoSolicitudServicio = sCodigo.Item(1)
        textSolicitud.Text = objAtencionAM.codigoSolicitudServicio
        params.Add(sCodigo.Item(1))
        drFila = General.cargarItem(ConsultasAmbu.SOLICITUD_CARGAR_AM, params)
        objAtencionAM.identiPaciente = drFila.Item(0)
        textPaciente.Text = drFila.Item(1)
        textNombre.Text = drFila.Item(2)
        TextSexo.Text = drFila.Item(3)
        textEPS.Text = drFila.Item(4)
        textedad.Text = drFila.Item(5)
        TextCodEPS.Text = drFila.Item(6)
        objAtencionAM.idEPS = drFila.Item(7)
        cargarComboCliente()
    End Sub
    Private Sub habControl()
        mTextSalida.Text = DateTime.Now.ToString("ddMMyyyyHHmm")
        mTextLlegada.Text = DateTime.Now.ToString("ddMMyyyyHHmm")

        inicializardgvValorDesglosado()
        CmbEPS.Enabled = True
        General.habilitarControles(gbTiempoTraslado)
        General.habilitarControles(GroupBox4)
        General.habilitarControles(GroupBox5)
        General.habilitarControles(gbListaTraslado)
        dgvDiagnostico.ReadOnly = True
        dgvTraslado.ReadOnly = True
        General.habilitarControles(gbValorDesglosado)
        General.habilitarControles(GroupBox8)
        GroupBox9.Enabled = False
        General.habilitarControles(gbTripulacion)
        General.habilitarControles(GroupBox12)
        General.habilitarControles(GroupBox13)
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        btnVlrTripulacion.Enabled = True
        btnAnexo3.Enabled = True
    End Sub

    Private Sub btbuscarcliente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        General.buscarElemento(Consultas.PACIENTE_BUSQUEDA,
                               Nothing,
                               AddressOf cargarPacienteAM,
                               TitulosForm.BUSQUEDA_PACIENTE,
                               True, 0, True) ' permite traer el primer elemento de la consulta

    End Sub
    Private Sub validarDgv(dgvdiag As DataGridView, dtDiag As DataTable)
        Try
            With dgvdiag
                .ReadOnly = True
                .DataSource = dtDiag
                .AutoGenerateColumns = False
                .Columns(0).DisplayIndex = 3
                .Columns("Estado").Visible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            End With
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub verificaRecargoNocturno()
        If dgvValorDesglosado.ReadOnly = False Then
            Try
                Dim horaSalidaNocturna, horaLlegadaNocturna, horaRetornoNocturno, horaRegresoNocturna As Boolean
                Dim params As New List(Of String)
                If mTextSalida.MaskCompleted Then
                    params.Add(Format(CDate(mTextSalida.Text), Constantes.FORMATO_FECHA_HORA_GEN))
                    horaSalidaNocturna = General.getEstadoVF(ConsultasAmbu.VERIFICAR_RECARGO_NOCTURNO, params)
                End If
                If mTextLlegada.MaskCompleted Then
                    params.Clear()
                    params.Add(Format(CDate(mTextLlegada.Text), Constantes.FORMATO_FECHA_HORA_GEN))
                    horaLlegadaNocturna = General.getEstadoVF(ConsultasAmbu.VERIFICAR_RECARGO_NOCTURNO, params)
                End If
                If mTextRegreso.MaskCompleted Then
                    params.Clear()
                    params.Add(Format(CDate(mTextRegreso.Text), Constantes.FORMATO_FECHA_HORA_GEN))
                    horaRetornoNocturno = General.getEstadoVF(ConsultasAmbu.VERIFICAR_RECARGO_NOCTURNO, params)
                End If
                If mTextRetorno.MaskCompleted Then
                    params.Clear()
                    params.Add(Format(CDate(mTextRetorno.Text), Constantes.FORMATO_FECHA_HORA_GEN))
                    horaRegresoNocturna = General.getEstadoVF(ConsultasAmbu.VERIFICAR_RECARGO_NOCTURNO, params)
                End If
                If horaSalidaNocturna Or horaLlegadaNocturna Or horaRetornoNocturno Or horaRegresoNocturna Then
                    objAtencionAM.recargoNocturno = 1
                Else
                    objAtencionAM.recargoNocturno = 0
                End If
                dgvValorDesglosado.Rows(1).Cells(0).Value = objAtencionAM.recargoNocturno
                '' ESTO SE DEBE CAMBIAR, CONFIGURAR, 
                '' If textEPS.Text.Split("|")(0).Trim() = "CCF015" Then dgvValorDesglosado.Rows(1).Cells(0).Value = 0
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Public Sub horasAdicionales()
        If dgvValorDesglosado.ReadOnly = False Then 'DataGridView1.Rows(2).Cells(0).ReadOnly = False
            If mTextSalida.Text.Trim.Length < 16 Or mTextRegreso.ReadOnly Or mTextRegreso.Text.Trim.Length < 16 Then
                dgvValorDesglosado.Rows(2).Cells(0).Value = 0
            Else
                Dim mintrasfecha, maxtrasfecha, minnormafecha As DateTime
                mintrasfecha = mTextSalida.Text
                maxtrasfecha = mTextRegreso.Text
                minnormafecha = mintrasfecha.Add(TimeSpan.FromHours(2))
                mintrasfecha = If(minnormafecha > mintrasfecha, minnormafecha, mintrasfecha)
                If mintrasfecha > maxtrasfecha Then
                    objAtencionAM.cantidadHoraAdicional = 0
                    dgvValorDesglosado.Rows(2).Cells(0).Value = 0
                Else
                    objAtencionAM.cantidadHoraAdicional = Math.Truncate(maxtrasfecha.Subtract(minnormafecha).TotalHours * 10) / 10
                    dgvValorDesglosado.Rows(2).Cells(0).Value = Math.Truncate(maxtrasfecha.Subtract(minnormafecha).TotalHours * 10) / 10
                End If
            End If
        End If
    End Sub
    Private Function buscarFestivos(Fecha As Date) As Boolean
        Dim params As New List(Of String)
        params.Add(Fecha)
        Dim dFila As DataRow
        dFila = General.cargarItem(ConsultasAmbu.FESTIVOS_BUSCAR, params)
        Return dFila.Item(0)
    End Function

    Private Sub cargarObjetoAtencionAM()
        Dim Fsis As Date
        Dim dfestivo As Boolean
        Dim dSemana As Integer
        Fsis = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dfestivo = buscarFestivos(Fsis)
        dSemana = Fsis.DayOfWeek
        objAtencionAM.salida = Convert.ToDateTime(mTextSalida.Text)
        objAtencionAM.llegada = Convert.ToDateTime(mTextLlegada.Text)
        objAtencionAM.retorno = Convert.ToDateTime(If(mTextRetorno.Text = "  /  /       :", "01/01/1900 00:00", mTextRetorno.Text))
        objAtencionAM.regreso = Convert.ToDateTime(If(mTextRegreso.Text = "  /  /       :", "01/01/1900 00:00", mTextRegreso.Text))

        objAtencionAM.usuario = SesionActual.idUsuario
        objAtencionAM.observaciones = TextBox3.Text
        objAtencionAM.tipoDia = If(dfestivo = True, ConstantesAm.DIA_FESTIVO, ConstantesAm.DIA_HABIL)
        If objAtencionAM.dtTablaDiagnostico.Rows.Count > 0 Then
            objAtencionAM.dtTablaDiagnostico.Rows.RemoveAt(objAtencionAM.dtTablaDiagnostico.Rows.Count - 1)
        Else
            MsgBox("No ha seleccionado un Diagnostico", MsgBoxStyle.Exclamation)
        End If
        objAtencionAM.codigoSolicitudServicio = textSolicitud.Text
        objAtencionAM.dtTablaTripulacion.Clear()
        ''aqui se llena la tabla de la tripulacion que componen el traslado, por ahora. mientras se piensa en como se haría en un futuro utulizando DGV
        ''las constantes deben ser quienes componen una tripulacion de ambulancia
        If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
            objAtencionAM.dtTablaTripulacion.Rows.Add(1, objAtencionAM.idAdministrador, "")
        End If
        If Not String.IsNullOrEmpty(objAtencionAM.idMedico) Then
            objAtencionAM.dtTablaTripulacion.Rows.Add(2, objAtencionAM.idMedico, "")
        End If
        If Not String.IsNullOrEmpty(objAtencionAM.idParamedico) Then
            objAtencionAM.dtTablaTripulacion.Rows.Add(3, objAtencionAM.idParamedico, "")
        End If
        If Not String.IsNullOrEmpty(objAtencionAM.idFisioterapeuta) Then
            objAtencionAM.dtTablaTripulacion.Rows.Add(4, objAtencionAM.idFisioterapeuta, "")
        End If
        If Not String.IsNullOrEmpty(objAtencionAM.idConductor) Then
            objAtencionAM.dtTablaTripulacion.Rows.Add(5, objAtencionAM.idConductor, "")
        End If
        If Not String.IsNullOrEmpty(objAtencionAM.idContacto) Then
            objAtencionAM.dtTablaTripulacion.Rows.Add(6, objAtencionAM.idContacto, "")
        End If
    End Sub

    Private Function validar()
        ''convertir a CONSTANTES en MensajesAmbu (crear clase en caaso no exista)
        If CmbEPS.SelectedIndex < 1 Then
            MsgBox("Por favor seleccione cliente a quien se factura", MsgBoxStyle.Exclamation)
            CmbEPS.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(objAtencionAM.idTarifa) Then
            MsgBox("¡No ha Escogido un Traslado aún!", MsgBoxStyle.Exclamation)
            dgvTraslado.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(objAtencionAM.idTripulacion) Then
            MsgBox("¡No ha Escogido un Tripulacion aún!", MsgBoxStyle.Exclamation)
            TabControl1.SelectedTab = TabPage2
            Return False
        Else
            If String.IsNullOrEmpty(objAtencionAM.idAdministrador) AndAlso String.IsNullOrEmpty(objAtencionAM.idMedico) AndAlso
                String.IsNullOrEmpty(objAtencionAM.idParamedico) AndAlso String.IsNullOrEmpty(objAtencionAM.idFisioterapeuta) AndAlso
                String.IsNullOrEmpty(objAtencionAM.idConductor) AndAlso String.IsNullOrEmpty(objAtencionAM.idContacto) Then
                MsgBox("¡Seleccione por lo menos un tripulante!", MsgBoxStyle.Exclamation)
                TabControl1.SelectedTab = TabPage2
                Return False
            End If
        End If
        If (mTextSalida.Text.Trim.Length < 16) Then
            MsgBox("Por favor digite una Fecha de Salida Valida..", MsgBoxStyle.Exclamation)
            mTextSalida.Focus()
            Return False
        End If
        If (mTextLlegada.Text.Trim.Length < 16) Then
            MsgBox("Por favor digite una Fecha de llegada Valida..", MsgBoxStyle.Exclamation)
            mTextLlegada.Focus()
            Return False
        End If
        If GroupBox9.Enabled = False Then
            objAtencionAM.retorno = "01/01/1900"
            objAtencionAM.regreso = "01/01/1900"
        Else
            If (mTextRetorno.Text.Trim.Length < 16) Then
                MsgBox("Por favor digite una Fecha de Retorno Valida..", MsgBoxStyle.Exclamation)
                mTextRetorno.Focus()
                Return False
            End If
            If (mTextRegreso.Text.Trim.Length < 16) Then
                MsgBox("Por favor digite una Fecha de Regreso Valida..", MsgBoxStyle.Exclamation)
                mTextRegreso.Focus()
                Return False
            End If
            objAtencionAM.retorno = Convert.ToDateTime(mTextRetorno.Text)
            objAtencionAM.regreso = Convert.ToDateTime(mTextRegreso.Text)
        End If
        objAtencionAM.salida = Convert.ToDateTime(mTextSalida.Text)
        objAtencionAM.llegada = Convert.ToDateTime(mTextLlegada.Text)
        Return True
    End Function
    Public Sub cargarPacienteAM(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        General.limpiarControles(Me)
        habControl()
        btOpcionPaciente.Enabled = True
        params.Add(pCodigo)
        drFila = General.cargarItem(ConsultasAmbu.PACIENTE_CARGAR_AM, params)
        objAtencionAM.identiPaciente = drFila.Item(0)
        textPaciente.Text = drFila.Item(1)
        textNombre.Text = drFila.Item(2)
        TextSexo.Text = drFila.Item(3)
        textEPS.Text = drFila.Item(4)
        textedad.Text = drFila.Item(5)
        TextCodEPS.Text = drFila.Item(6)
        objAtencionAM.idEPS = drFila.Item(7)
        objAtencionAM.N_Registro = If(IsDBNull(drFila.Item(8)), 0, drFila.Item(8))
        cargarComboCliente()
    End Sub
    Private Sub cargarComboCliente()
        'llena combobox a facturar
        Dim params As New List(Of String)
        params.Add(objAtencionAM.idEPS)
        General.cargarCombo(ConsultasAmbu.EPS_AM_BUSCAR, params, "RazonSocial", "Codigo", CmbEPS)
        CmbEPS.Tag = CmbEPS.Text
    End Sub

    Public Sub cargarValoresAM(pcod As Integer)
        Dim dfila As DataRow
        Dim params2 As New List(Of String)
        params2.Add(pcod)
        dfila = General.cargarItem(ConsultasAmbu.CONTRATO_INF_AM_CARGAR, params2)
        textValNormal.Text = Format(0, "c")
        textValTotal.Text = Format(0, "c")
        If Not IsNothing(dfila) Then
            dgvValorDesglosado.ReadOnly = False
            dgvValorDesglosado.Rows(1).Cells(0).ReadOnly = True
            dgvValorDesglosado.Rows(2).Cells(0).ReadOnly = True
            objAtencionAM.TipoCodRef = dfila.Item(0)
            objAtencionAM.factor = dfila.Item(1)
        End If

    End Sub
    Private Sub cargarManualTarifarioAmDetalle(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(objAtencionAM.TipoCodRef)
        params.Add(objAtencionAM.codigoContrato)
        objAtencionAM.idTarifa = pCodigo
        General.llenarTabla(ConsultasAmbu.ATENCION_AM_TARIFA_D_CARGAR, params, objAtencionAM.dtTablaTraslado)
        dgvTraslado.DataSource = objAtencionAM.dtTablaTraslado
        dgvTraslado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTraslado.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
        dgvTraslado.AutoGenerateColumns = False
        dgvTraslado.ReadOnly = True
        objAtencionAM.codProcedimiento = objAtencionAM.dtTablaTraslado.Rows(0).Item("Codigo_Procedimiento")
        objAtencionAM.valorTrasladoMasTarifa = objAtencionAM.dtTablaTraslado.Rows(0).Item("Valor").ToString
        objAtencionAM.valorTrasladoSimpleMasTarifa = objAtencionAM.dtTablaTraslado.Rows(0).Item("ValorSimple").ToString
        objAtencionAM.valorKmsMayor25 = objAtencionAM.dtTablaTraslado.Rows(0).Item("Valor25").ToString
        objAtencionAM.valorKmsMayor300 = objAtencionAM.dtTablaTraslado.Rows(0).Item("Valor300").ToString
        objAtencionAM.redondo = objAtencionAM.dtTablaTraslado.Rows(0).Item("Redondo").ToString
        If objAtencionAM.redondo = True Then
            GroupBox9.Enabled = True
            If mTextRetorno.Text = "  /  /       :" Then
                mTextRetorno.Text = DateTime.Now.ToString("ddMMyyyyHHmm")
                mTextRegreso.Text = DateTime.Now.ToString("ddMMyyyyHHmm")
            End If
        End If
        cargarTarifaTripulacion()
        verificaRecargoNocturno()
        horasAdicionales()
        calcularTotales()
    End Sub
    Private Sub cargarTarifaTripulacionAM(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        objAtencionAM.idTripulacion = pCodigo
        Try
            dFila = General.cargarItem(ConsultasAmbu.TARIFA_TRIPULACION_CARGAR, params)
            If Not IsNothing(dFila) Then
                If objAtencionAM.redondo = True Then
                    objAtencionAM.valorAdministrativo = dFila.Item(8)
                    objAtencionAM.valorConductor = dFila.Item(10)
                    objAtencionAM.valorParamedico = dFila.Item(12)
                    objAtencionAM.valorMedico = dFila.Item(14)
                    objAtencionAM.valorFisioterapeuta = dFila.Item(17)
                Else
                    objAtencionAM.valorAdministrativo = dFila.Item(7)
                    objAtencionAM.valorConductor = dFila.Item(9)
                    objAtencionAM.valorParamedico = dFila.Item(11)
                    objAtencionAM.valorMedico = dFila.Item(13)
                    objAtencionAM.valorFisioterapeuta = dFila.Item(16)
                End If
                objAtencionAM.valorContacto = dFila.Item(15)
                If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
                    txtVlrAdministrador.Text = Format(objAtencionAM.valorAdministrativo, "C")
                End If
                If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
                    txtVlrConductor.Text = Format(objAtencionAM.valorConductor, "C")
                End If
                If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
                    txtVlrParamed.Text = Format(objAtencionAM.valorParamedico, "C")
                End If
                If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
                    txtVlrMedico.Text = Format(objAtencionAM.valorMedico, "C")
                End If
                If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
                    txtVlrFisioterapeuta.Text = Format(objAtencionAM.valorFisioterapeuta, "C")
                End If
                If Not String.IsNullOrEmpty(objAtencionAM.idAdministrador) Then
                    txtVlrContacto.Text = Format(objAtencionAM.valorContacto, "C")
                End If
                txtTarifaTras.Text = pCodigo
                General.habilitarControles(gbTripulacion)
                iniciarTripulacion()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarTarifaTripulacion()
        Dim dfila As DataRow
        Dim params3 As New List(Of String)
        If String.IsNullOrEmpty(objAtencionAM.codAtencion) Then
            params3.Add(objAtencionAM.idTarifa)
            dfila = General.cargarItem(ConsultasAmbu.TARIFA_TRIPULACION_AM_D_CARGAR, params3)
        Else
            params3.Add(objAtencionAM.idTripulacion)
            dfila = General.cargarItem(ConsultasAmbu.TARIFA_TRIPULACION_AM_D_POSTCARGAR, params3)
        End If
        If Not IsNothing(dfila) Then
            If objAtencionAM.redondo = True Then
                objAtencionAM.valorAdministrativo = dfila.Item(1)
                objAtencionAM.valorConductor = dfila.Item(3)
                objAtencionAM.valorParamedico = dfila.Item(5)
                objAtencionAM.valorMedico = dfila.Item(7)
                objAtencionAM.valorFisioterapeuta = dfila.Item(9)
            Else
                objAtencionAM.valorAdministrativo = dfila.Item(0)
                objAtencionAM.valorConductor = dfila.Item(2)
                objAtencionAM.valorParamedico = dfila.Item(4)
                objAtencionAM.valorMedico = dfila.Item(6)
                objAtencionAM.valorFisioterapeuta = dfila.Item(8)
            End If
            objAtencionAM.valorContacto = dfila.Item(10)
            objAtencionAM.idTripulacion = dfila.Item(11)
            General.habilitarControles(gbTripulacion)
            iniciarTripulacion()
        Else
            General.deshabilitarControles(gbTripulacion)
            objAtencionAM.idTripulacion = ""
        End If
    End Sub

    Private Sub iniciarTripulacion()
        txtAdministrativo.ReadOnly = True
        txtMedico.ReadOnly = True
        txtParamedico.ReadOnly = True
        txtFisioterapeuta.ReadOnly = True
        txtConductor.ReadOnly = True
        txtContacto.ReadOnly = True
        btBusquedaAdm.Enabled = False
        btBusquedaMed.Enabled = False
        btBusquedaPara.Enabled = False
        btBusquedaFisio.Enabled = False
        btBusquedaCond.Enabled = False
        btBusquedaCont.Enabled = False
    End Sub

    Sub calcularTotales()
        Dim horasAdicionales As String
        horasAdicionales = dgvValorDesglosado.Rows(2).Cells(0).Value
        objAtencionAM.cantidadHoraAdicional = If(horasAdicionales Is Nothing, 0, horasAdicionales.ToString())
        objAtencionAM.calcularDetalleTraslado()
        objAtencionAM.calcularPrecioTraslado()
        dgvValorDesglosado.Rows(0).Cells(1).Value = Format(objAtencionAM.valorTotalKmsAdicional, "c")
        dgvValorDesglosado.Rows(1).Cells(1).Value = Format(objAtencionAM.valorTotalRecargoNocturno, "c")
        dgvValorDesglosado.Rows(2).Cells(1).Value = Format(objAtencionAM.valorTotalHorasAdicionales, "c")

        textValNormal.Text = Format(objAtencionAM.valorTrasladoMasTarifa, "c")
        textValTotal.Text = Format((objAtencionAM.valorTotalAtencion), "c")
    End Sub

    Private Sub CmbEPS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEPS.SelectedIndexChanged
        If CmbEPS.Tag <> " - - - Seleccione - - - " Then
            Exit Sub
        End If
        If CmbEPS.SelectedIndex > 0 Then
            If btguardar.Enabled = True Then
                limpiarDgvTraslado()
                GroupBox9.Enabled = False
                mTextRegreso.Text = ""
                mTextRetorno.Text = ""
                objAtencionAM.idTarifa = ""
                dgvValorDesglosado.Rows(0).Cells(0).Value = 0
                dgvValorDesglosado.Rows(0).Cells(1).Value = 0
                dgvValorDesglosado.Rows(1).Cells(1).Value = 0
                dgvValorDesglosado.Rows(2).Cells(1).Value = 0
                objAtencionAM.kmAdicional = 0
                objAtencionAM.codigoContrato = CmbEPS.SelectedValue
                cargarValoresAM(CmbEPS.SelectedValue)
            End If
        Else
            objAtencionAM.idTarifa = ""
            objAtencionAM.codigoContrato = ""
        End If
    End Sub
    Sub limpiarDgvTraslado()
        dgvTraslado.Enabled = True
        objAtencionAM.dtTablaTraslado.Clear()
        objAtencionAM.dtTablaTraslado.Rows.Add()
        objAtencionAM.dtTablaDiagnostico.Clear()
        objAtencionAM.dtTablaDiagnostico.Rows.Add()
    End Sub

    Private Sub btnHrSalida_Click(sender As Object, e As EventArgs) Handles btnHrSalida.Click
        Cmenu.Show(mTextSalida, New Point(0, mTextSalida.Height), ToolStripDropDownDirection.BelowRight)
        objAtencionAM.controlAgregarMinuto = 0
    End Sub

    Private Sub FormAntencionAmb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            objAtencionAM = New AtencionAM
            objAtencionAM.usuario = SesionActual.idUsuario
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True '--Nuevo--
            btbuscar.Enabled = True '--Buscar--
            LinkLabel1.Enabled = False
            LinkLabel3.Enabled = False
            'permisos de uso de boton
            permiso_general = perG.buscarPermisoGeneral(Name)
            Pnuevo = permiso_general & "pp" & "01"
            Peditar = permiso_general & "pp" & "02"
            Panular = permiso_general & "pp" & "03"
            PBuscar = permiso_general & "pp" & "04"
            iniciarCombos()
            inicializardgvValorDesglosado()
            btOpcionPaciente.Enabled = True
            Me.mTextSalida.ValidatingType = GetType(Date)
            Me.mTextLlegada.ValidatingType = GetType(Date)
            Me.mTextRetorno.ValidatingType = GetType(Date)
            Me.mTextRegreso.ValidatingType = GetType(Date)
            validarDgv(dgvDiagnostico, objAtencionAM.dtTablaDiagnostico)
            enlazarDgvTraslado()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub iniciarCombos()
        'llena combobox de cargos para Tripulacion
        textValNormal.Text = Format(0, "c")
        textValTotal.Text = Format(0, "c")
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", CmbCargoAdmi)
        params.Clear()
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", CmbCargoMed)
        params.Clear()
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", CmbCargoParam)
        params.Clear()
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", CmbCargoFisio)
        params.Clear()
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", CmbCargoCond)
        params.Clear()
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", CmbCargoCont)
    End Sub

    Sub enlazarDgvTraslado()
        With dgvTraslado
            .Columns("CodPaisO").DataPropertyName = "Codigo_Pais_Origen"
            .Columns("PaisOrigen").DataPropertyName = "Descripcion_Pais_origen"
            .Columns("CodDptoO").DataPropertyName = "Codigo_Dpto_Origen"
            .Columns("DptoOrigen").DataPropertyName = "Descripcion_Dpto_origen"
            .Columns("CodMunO").DataPropertyName = "Codigo_Municipio_Origen"
            .Columns("Mun_Origen").DataPropertyName = "Descripcion_Municipio_origen"
            .Columns("CodEntO").DataPropertyName = "Codigo_Institucion_Origen"
            .Columns("EntidadOrigen").DataPropertyName = "Descripcion_Institucion_Origen"
            .Columns("CodPaisD").DataPropertyName = "Codigo_Pais_Destino"
            .Columns("PaisDestino").DataPropertyName = "Descripcion_Pais_Destino"
            .Columns("CodDptoD").DataPropertyName = "Codigo_Dpto_Destino"
            .Columns("DptoDestino").DataPropertyName = "Descripcion_Dpto_Destino"
            .Columns("CodMunD").DataPropertyName = "Codigo_Municipio_Destino"
            .Columns("MunDestino").DataPropertyName = "Descripcion_Municipio_Destino"
            .Columns("CodEntD").DataPropertyName = "Codigo_Institucion_Destino"
            .Columns("EntidadDestino").DataPropertyName = "Descripcion_Institucion_Destino"
            .Columns("CodTras").DataPropertyName = "Codigo_Procedimiento"
            .Columns("Traslado").DataPropertyName = "Descripcion_Procedimiento"
            .Columns("ValorT").DataPropertyName = "Valor"
            .Columns("Medico").DataPropertyName = "Valor_Medico"
            .Columns("Paramedico").DataPropertyName = "Valor_Paramedico"
            .Columns("Fisioterapeuta").DataPropertyName = "Valor_Fisioterapeuta"
            .Columns("Conductor").DataPropertyName = "Valor_Conductor"
            .Columns("Contacto").DataPropertyName = "Valor_Contacto"
            .Columns("Observaciones").DataPropertyName = "Observaciones"
            .Columns("CodInt").DataPropertyName = "Codigo"
            .DataSource = objAtencionAM.dtTablaTraslado
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
        End With
    End Sub

    Private Sub btnHrLlegada_Click(sender As Object, e As EventArgs) Handles btnHrLlegada.Click
        Cmenu.Show(mTextLlegada, New Point(0, mTextLlegada.Height), ToolStripDropDownDirection.BelowRight)
        objAtencionAM.controlAgregarMinuto = 1
    End Sub

    Private Sub btnHrRetorno_Click(sender As Object, e As EventArgs) Handles btnHrRetorno.Click
        Cmenu.Show(mTextRetorno, New Point(0, mTextRetorno.Height), ToolStripDropDownDirection.BelowRight)
        objAtencionAM.controlAgregarMinuto = 2
    End Sub

    Private Sub dgvDiagnostico_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagnostico.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Cells("Codigo").Selected = True Or dgvDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) And
            objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvDiagnostico, objAtencionAM.dtTablaDiagnostico)
            If dgvDiagnostico.RowCount > 1 Then
                dgvDiagnostico.Rows(dgvDiagnostico.RowCount - 2).Cells(1).Selected = True
            End If
        ElseIf dgvDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Cells("quitarDiag").Selected = True And objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objAtencionAM.dtTablaDiagnostico.Rows.RemoveAt(e.RowIndex)
            ElseIf objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objAtencionAM.dtTablaDiagnostico.Rows.RemoveAt(dgvDiagnostico.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub btHrRegreso_Click(sender As Object, e As EventArgs) Handles btHrRegreso.Click
        Cmenu.Show(mTextRegreso, New Point(0, mTextRegreso.Height), ToolStripDropDownDirection.BelowRight)
        objAtencionAM.controlAgregarMinuto = 3
    End Sub

    Private Sub dgvValorDesglosado_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvValorDesglosado.RowPostPaint
        Using b As New SolidBrush(dgvDiagnostico.RowHeadersDefaultCellStyle.ForeColor)
            Select Case e.RowIndex
                Case 0
                    e.Graphics.DrawString("Kilómetros Adicionales", dgvDiagnostico.ColumnHeadersDefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 2)
                Case 1
                    e.Graphics.DrawString("Recargo Nocturno", dgvDiagnostico.ColumnHeadersDefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 2)
                Case 2
                    e.Graphics.DrawString("Horas Adicionales", dgvDiagnostico.ColumnHeadersDefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 2)
            End Select
        End Using
    End Sub

    Private Sub dgvTraslado_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTraslado.CellDoubleClick
        If String.IsNullOrEmpty(objAtencionAM.codigoContrato) Then
            If btguardar.Enabled = True Then
                MsgBox("Por favor seleccione cliente a quien se factura", MsgBoxStyle.Exclamation)
                CmbEPS.Focus()
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(objAtencionAM.codigoContrato) 'Codigo de Aquien se Facturara
        params.Add(objAtencionAM.TipoCodRef)
        General.buscarElemento(objAtencionAM.sqlBuscarManualTarifarioAM,
                              params,
                              AddressOf cargarManualTarifarioAmDetalle,
                              TitulosForm.BUSQUEDA_MANUAL_TARIFARIO,
                              False, Constantes.TAMANO_MEDIANO, True)
    End Sub
    Private Function cargarIdenTripulacion(tCod As Integer) As Integer
        Dim paramsTR As New List(Of String)
        Dim dFilaTR As DataRow
        paramsTR.Add(tCod)
        dFilaTR = General.cargarItem(ConsultasAmbu.IDENTIFICACION_AM_BUSCAR, paramsTR)
        Return dFilaTR.Item(0)
    End Function


    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btOpcionPaciente.Enabled = False
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            CmbEPS.Tag = " - - - Seleccione - - - "
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVlrTripulacion.Click
        Dim TarifaTripulacion As New FormTarifaTripulacion
        TarifaTripulacion.ShowDialog()
    End Sub

    Private Sub btnAnexo3_Click(sender As Object, e As EventArgs) Handles btnAnexo3.Click
        Dim Anexo3 As New FormAnexo3
        Anexo3.txtregistro.Text = objAtencionAM.N_Registro
        Anexo3.txtpaciente.Text = textNombre.Text
        Anexo3.txtidentificacion.Text = textPaciente.Text
        Anexo3.txtcontrato.Text = textEPS.Text
        Anexo3.VerificarRegistro()
        Anexo3.txttipoinforme.Text = Constantes.AUTORIZACION_SERVICIO
        Anexo3.ShowDialog()
        FormPrincipal.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If MsgBox("Se quitara la tarifa de tripulacion al traslado ¿Esta seguro que desea continuar?", 32 + 1, "Atencion") = 2 Then Return
        txtVlrAdministrador.Text = Format(0, "c")
        txtVlrMedico.Text = Format(0, "c")
        txtVlrParamed.Text = Format(0, "c")
        txtVlrFisioterapeuta.Text = Format(0, "c")
        txtVlrConductor.Text = Format(0, "c")
        txtVlrContacto.Text = Format(0, "c")
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'Guarda en base de datos de la Atención ambulancia
        If validar() = False Then
            Exit Sub
        End If

        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjetoAtencionAM()
                AtencionAmBLL.guardarAtencionAM(objAtencionAM)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                If String.IsNullOrEmpty(textCodTraslado.Text) Then
                    textEstadoAtencion.Text = ConstantesAm.ATENDIDO
                End If
                textCodTraslado.Text = objAtencionAM.codAtencion
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(objAtencionAM.sqlBuscarAtencionAM,
                              params,
                              AddressOf cargarAtencionAM,
                              TitulosForm.BUSQUEDA_ATENCION_AM,
                              False, Constantes.TAMANO_MEDIANO, True)
            dgvTraslado.Enabled = False
            LinkLabel1.Enabled = False
            LinkLabel3.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarAtencionAM(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objAtencionAM.sqlCargarAtencionAM, params)

            objAtencionAM.codAtencion = pCodigo
            objAtencionAM.identiPaciente = dFila.Item(0)
            cargarPacienteAM(objAtencionAM.identiPaciente)
            CmbEPS.SelectedValue = dFila.Item(1)
            CmbEPS.Tag = CmbEPS.Text
            objAtencionAM.codigoContrato = dFila.Item(1)
            TextBox3.Text = If(IsDBNull(dFila.Item(6)), " ", dFila.Item(6)) 'OBSERVACIONES
            cargarDiagnostico(pCodigo)
            mTextSalida.Text = If(IsDBNull(dFila.Item(2)), Nothing, CDate(dFila.Item(2)).ToString("ddMMyyyyHHmmss"))
            mTextLlegada.Text = If(IsDBNull(dFila.Item(3)), Nothing, CDate(dFila.Item(3)).ToString("ddMMyyyyHHmmss"))
            mTextRegreso.Text = If(IsDBNull(dFila.Item(4)), Nothing, CDate(dFila.Item(4)).ToString("ddMMyyyyHHmmss"))
            mTextRetorno.Text = If(IsDBNull(dFila.Item(5)), Nothing, CDate(dFila.Item(5)).ToString("ddMMyyyyHHmmss"))
            textCodTraslado.Text = pCodigo
            If IsDBNull(dFila.Item(8)) = False Then
                cargarTripulacionAM(dFila.Item(8), txtIdAdministrador, CmbCargoAdmi)
            End If
            If IsDBNull(dFila.Item(9)) = False Then
                cargarTripulacionAM(dFila.Item(9), txtIdMedico, CmbCargoMed)
            End If
            If IsDBNull(dFila.Item(10)) = False Then
                cargarTripulacionAM(dFila.Item(10), txtIdParamed, CmbCargoParam)
            End If
            If IsDBNull(dFila.Item(11)) = False Then
                cargarTripulacionAM(dFila.Item(11), txtIdFisioterapeuta, CmbCargoFisio)
            End If
            If IsDBNull(dFila.Item(12)) = False Then
                cargarTripulacionAM(dFila.Item(12), txtIdConductor, CmbCargoCond)
            End If
            If IsDBNull(dFila.Item(13)) = False Then
                cargarTripulacionAM(dFila.Item(13), txtIdContacto, CmbCargoCont)
            End If
            objAtencionAM.idAdministrador = dFila.Item(8).ToString
            objAtencionAM.idMedico = dFila.Item(9).ToString
            objAtencionAM.idParamedico = dFila.Item(10).ToString
            objAtencionAM.idFisioterapeuta = dFila.Item(11).ToString
            objAtencionAM.idConductor = dFila.Item(12).ToString
            objAtencionAM.idContacto = dFila.Item(13).ToString
            txtTarifaTras.Text = dFila.Item(14)
            objAtencionAM.idTripulacion = dFila.Item(14)
            cargarManualTarifarioAmDetalle(dFila.Item(7))
            cargarValoresAM(CmbEPS.SelectedValue)
            objAtencionAM.kmAdicional = dFila.Item(15)
            objAtencionAM.recargoNocturno = dFila.Item(16)
            objAtencionAM.cantidadHoraAdicional = CDbl(dFila.Item(17)).ToString("n1")
            dgvValorDesglosado.Rows(0).Cells(0).Value = objAtencionAM.kmAdicional
            dgvValorDesglosado.Rows(1).Cells(0).Value = If(objAtencionAM.recargoNocturno = True, 1, 0)
            dgvValorDesglosado.Rows(2).Cells(0).Value = objAtencionAM.cantidadHoraAdicional
            textEstadoAtencion.Text = dFila.Item(20)
            txtAdministrativo.Text = dFila.Item(21).ToString
            txtMedico.Text = dFila.Item(22).ToString
            txtParamedico.Text = dFila.Item(23).ToString
            txtFisioterapeuta.Text = dFila.Item(24).ToString
            txtConductor.Text = dFila.Item(25).ToString
            txtContacto.Text = dFila.Item(26).ToString
            calcularTotales()
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            txtVlrAdministrador.Text = IIf(String.IsNullOrEmpty(objAtencionAM.idAdministrador), "", Format(objAtencionAM.valorAdministrativo, "C"))
            txtVlrConductor.Text = IIf(String.IsNullOrEmpty(objAtencionAM.idConductor), "", Format(objAtencionAM.valorConductor, "C"))
            txtVlrParamed.Text = IIf(String.IsNullOrEmpty(objAtencionAM.idParamedico), "", Format(objAtencionAM.valorParamedico, "C"))
            txtVlrMedico.Text = IIf(String.IsNullOrEmpty(objAtencionAM.idMedico), "", Format(objAtencionAM.valorMedico, "C"))
            txtVlrFisioterapeuta.Text = IIf(String.IsNullOrEmpty(objAtencionAM.idFisioterapeuta), "", Format(objAtencionAM.valorFisioterapeuta, "C"))
            txtVlrContacto.Text = IIf(String.IsNullOrEmpty(objAtencionAM.idContacto), "", Format(objAtencionAM.valorContacto, "C"))
            If Not textEstadoAtencion.Text.ToUpper.Contains(ConstantesAm.ATENDIDO) Then ' LA VARIABLE ATENDIDO SE DEB CONVERTIR EN CONSTANTE, YA QUE SE ESTÁ USANDO EN VARIAS PARTES
                bteditar.Enabled = False
                btanular.Enabled = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarTripulacionAM(ByVal Tparams As Integer, TxtNombre As TextBox, cbComboCar As ComboBox)
        If Tparams <> 0 Then
            Dim dFilaTR As DataRow
            Dim paramsTR As New List(Of String)
            paramsTR.Add(Tparams)
            dFilaTR = General.cargarItem(ConsultasAmbu.IDENTIFICACION_AM_BUSCAR, paramsTR)
            TxtNombre.Text = dFilaTR.Item(0)
            cbComboCar.SelectedValue = dFilaTR.Item(1)
        End If
    End Sub

    Private Sub cargarDiagnostico(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Try
            General.llenarTabla(ConsultasAmbu.ATENCION_AM_DIAG_CARGAR, params, objAtencionAM.dtTablaDiagnostico)
            dgvDiagnostico.DataSource = objAtencionAM.dtTablaDiagnostico
            dgvDiagnostico.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDiagnostico.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    objAtencionAM.AnularAtencionAM()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            'Actualiza en base de datos los datos en Atencion Ambulancia
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            General.deshabilitarControles(GpInfGeneral)
            objAtencionAM.dtTablaDiagnostico.Rows.Add()
            dgvTraslado.Enabled = True
            LinkLabel1.Enabled = True
            LinkLabel3.Enabled = True
            CmbEPS.Enabled = True
            txtAdministrativo.ReadOnly = True
            txtMedico.ReadOnly = True
            txtParamedico.ReadOnly = True
            txtFisioterapeuta.ReadOnly = True
            txtConductor.ReadOnly = True
            txtContacto.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Sub inicializardgvValorDesglosado()
        dtdesglose.Columns.Clear()

        dtdesglose.Clear()
        dtdesglose.Rows.Add()
        dtdesglose.Rows.Add()
        dtdesglose.Rows.Add()
        dgvValorDesglosado.DataSource = dtdesglose
        dgvValorDesglosado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvValorDesglosado.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvValorDesglosado.ClearSelection()
    End Sub

    Private Sub dgvValorDesglosado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvValorDesglosado.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub


    Private Sub dgvValorDesglosado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvValorDesglosado.CellFormatting
        If e.ColumnIndex = 1 Then
            e.Value = Format(CDbl(e.Value).ToString("C"), "")
        ElseIf e.RowIndex = 0 Then
            e.Value = Format(e.Value & " Km(s)", "")
        ElseIf e.RowIndex = 1 Then
            If e.Value = 1 Then
                e.Value = Format("SI", "")
            Else
                e.Value = Format("NO", "")
            End If
        ElseIf e.RowIndex = 2 Then
            e.Value = Format(e.Value & " Hora(s)", "")
        End If
    End Sub

    Private Sub btBusquedaAdm_Click(sender As Object, e As EventArgs) Handles btBusquedaAdm.Click

        Dim params As New List(Of String)
        params.Add(CmbCargoAdmi.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarAdministrador,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub btBusquedaMed_Click(sender As Object, e As EventArgs) Handles btBusquedaMed.Click

        Dim params As New List(Of String)
        params.Add(CmbCargoMed.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarMedico,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub btBusquedaPara_Click(sender As Object, e As EventArgs) Handles btBusquedaPara.Click

        Dim params As New List(Of String)
        params.Add(CmbCargoParam.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarParamedico,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub btBusquedaFisio_Click(sender As Object, e As EventArgs) Handles btBusquedaFisio.Click

        Dim params As New List(Of String)
        params.Add(CmbCargoFisio.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarFisioterapeuta,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub btBusquedaCond_Click(sender As Object, e As EventArgs) Handles btBusquedaCond.Click

        Dim params As New List(Of String)
        params.Add(CmbCargoCond.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarConductor,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub btBusquedaCont_Click(sender As Object, e As EventArgs) Handles btBusquedaCont.Click

        Dim params As New List(Of String)
        params.Add(CmbCargoCont.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR,
                               params,
                               AddressOf cargarContacto,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               True)
    End Sub
    Private Sub cargarAdministrador(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            objAtencionAM.idAdministrador = pcodigo
            txtAdministrativo.Text = dw("Tercero").ToString()
            txtVlrAdministrador.Text = Format(objAtencionAM.valorAdministrativo, "C")
        End Using
    End Sub
    Private Sub cargarMedico(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            objAtencionAM.idMedico = pcodigo
            txtMedico.Text = dw("Tercero").ToString()
            txtVlrMedico.Text = Format(objAtencionAM.valorMedico, "C")
        End Using
    End Sub
    Private Sub cargarParamedico(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            objAtencionAM.idParamedico = pcodigo
            txtParamedico.Text = dw("Tercero").ToString()
            txtVlrParamed.Text = Format(objAtencionAM.valorParamedico, "C")
        End Using
    End Sub
    Private Sub cargarFisioterapeuta(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            objAtencionAM.idFisioterapeuta = pcodigo
            txtFisioterapeuta.Text = dw("Tercero").ToString()
            txtVlrFisioterapeuta.Text = Format(objAtencionAM.valorFisioterapeuta, "C")
        End Using
    End Sub
    Private Sub cargarConductor(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            objAtencionAM.idConductor = pcodigo
            txtConductor.Text = dw("Tercero").ToString()
            txtVlrConductor.Text = Format(objAtencionAM.valorConductor, "C")

        End Using
    End Sub

    Private Sub cargarContacto(pcodigo As String)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Using dt As New DataTable
            General.llenarTabla(Consultas.CARGAR_TERCERO_PS, params, dt)
            Dim dw = dt(0)
            objAtencionAM.idContacto = pcodigo
            txtContacto.Text = dw("Tercero").ToString()
            txtVlrContacto.Text = Format(objAtencionAM.valorContacto, "C")

        End Using
    End Sub

    Private Sub CmbCargoAdmi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargoAdmi.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            objAtencionAM.idContacto = ""
            txtAdministrativo.Text = "-NO APLICA-"
            txtVlrAdministrador.Clear()
            btBusquedaAdm.Enabled = False
        Else
            btBusquedaAdm.Enabled = True
        End If
    End Sub

    Private Sub CmbCargoMed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargoMed.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            objAtencionAM.idMedico = ""
            txtMedico.Text = "-NO APLICA-"
            txtVlrMedico.Clear()
            btBusquedaMed.Enabled = False
        Else
            btBusquedaMed.Enabled = True
        End If
    End Sub

    Private Sub CmbCargoParam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargoParam.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            objAtencionAM.idParamedico = ""
            txtParamedico.Text = "-NO APLICA-"
            txtVlrParamed.Clear()
            btBusquedaPara.Enabled = False
        Else
            btBusquedaPara.Enabled = True
        End If
    End Sub

    Private Sub CmbCargoFisio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargoFisio.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            objAtencionAM.idFisioterapeuta = ""
            txtFisioterapeuta.Text = "-NO APLICA-"
            txtVlrFisioterapeuta.Clear()
            btBusquedaFisio.Enabled = False
        Else
            btBusquedaFisio.Enabled = True
        End If
    End Sub

    Private Sub CmbCargoCond_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargoCond.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            objAtencionAM.idConductor = ""
            txtConductor.Text = "-NO APLICA-"
            txtVlrConductor.Clear()
            btBusquedaCond.Enabled = False
        Else
            btBusquedaCond.Enabled = True
        End If
    End Sub

    Private Sub CmbCargoCont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargoCont.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            objAtencionAM.idContacto = ""
            txtContacto.Text = "-NO APLICA-"
            txtVlrContacto.Clear()
            btBusquedaCont.Enabled = False
        Else
            btBusquedaCont.Enabled = True
        End If
    End Sub

    Private Sub mTextSalida_Leave(sender As Object, e As EventArgs) Handles mTextSalida.Leave
        ValidarFechaMaskedTextbox(mTextSalida, objAtencionAM.salida)
    End Sub

    Private Sub mTextLlegada_Leave(sender As Object, e As EventArgs) Handles mTextLlegada.Leave
        ValidarFechaMaskedTextbox(mTextLlegada, objAtencionAM.llegada)
    End Sub

    Private Sub mTextRetorno_Leave(sender As Object, e As EventArgs) Handles mTextRetorno.Leave
        ValidarFechaMaskedTextbox(mTextRetorno, objAtencionAM.retorno)
    End Sub

    Private Sub mTextRegreso_Leave(sender As Object, e As EventArgs) Handles mTextRegreso.Leave
        ValidarFechaMaskedTextbox(mTextRegreso, objAtencionAM.regreso)
        verificaRecargoNocturno()
        horasAdicionales()
        calcularTotales()
    End Sub

    Private Sub mTextSalida_Enter(sender As Object, e As EventArgs) Handles mTextSalida.Enter
        objAtencionAM.salida = Convert.ToDateTime(mTextSalida.Text)
    End Sub

    Private Sub mTextLlegada_Enter(sender As Object, e As EventArgs) Handles mTextLlegada.Enter
        objAtencionAM.llegada = Convert.ToDateTime(mTextLlegada.Text)
    End Sub

    Private Sub mTextRetorno_Enter(sender As Object, e As EventArgs) Handles mTextRetorno.Enter
        objAtencionAM.retorno = Convert.ToDateTime(mTextRetorno.Text)
    End Sub

    Private Sub mTextRegreso_Enter(sender As Object, e As EventArgs) Handles mTextRegreso.Enter
        objAtencionAM.regreso = Convert.ToDateTime(mTextRegreso.Text)
    End Sub

    Private Sub ValidarFechaMaskedTextbox(fecha As MaskedTextBox, objetoFecha As DateTime)
        If IsDate(fecha.Text) = False Then
            MsgBox("Fecha Invalida", MsgBoxStyle.Exclamation)
            fecha.Text = Convert.ToDateTime(objetoFecha).ToString("ddMMyyyyHHmmss")
        End If
    End Sub

    Private Sub txtVlrAdministrador_Enter(sender As Object, e As EventArgs) Handles txtVlrAdministrador.Enter,
                                                                                    txtVlrConductor.Enter,
                                                                                    txtVlrContacto.Enter,
                                                                                    txtVlrFisioterapeuta.Enter,
                                                                                    txtVlrMedico.Enter,
                                                                                    txtVlrParamed.Enter
        txtVlrAdministrador.ReadOnly = True
        txtVlrConductor.ReadOnly = True
        txtVlrContacto.ReadOnly = True
        txtVlrFisioterapeuta.ReadOnly = True
        txtVlrMedico.ReadOnly = True
        txtVlrParamed.ReadOnly = True
    End Sub

    Private Sub dgvTraslado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvTraslado.KeyDown
        If e.KeyCode = Keys.F3 Then
            If String.IsNullOrEmpty(objAtencionAM.codigoContrato) Then
                If btguardar.Enabled = True Then
                    MsgBox("Por favor seleccione cliente a quien se factura", MsgBoxStyle.Exclamation)
                    CmbEPS.Focus()
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(objAtencionAM.codigoContrato) 'Codigo de Aquien se Facturara
            params.Add(objAtencionAM.TipoCodRef)
            General.buscarElemento(objAtencionAM.sqlBuscarManualTarifarioAM,
                                  params,
                                  AddressOf cargarManualTarifarioAmDetalle,
                                  TitulosForm.BUSQUEDA_MANUAL_TARIFARIO,
                                  False, Constantes.TAMANO_MEDIANO, True)
        End If
    End Sub

    Private Sub dgvDiagnostico_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDiagnostico.KeyDown
        If e.KeyCode = Keys.F3 And objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item(0).ToString = "" Then
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Cells("Codigo").Selected = True Or dgvDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) And
                objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
                General.agregarDiagnosticosCIE(dgvDiagnostico, objAtencionAM.dtTablaDiagnostico)
                If dgvDiagnostico.RowCount > 1 Then
                    dgvDiagnostico.Rows(dgvDiagnostico.RowCount - 2).Cells(1).Selected = True
                End If
            ElseIf dgvDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Cells("quitarDiag").Selected = True And objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
                If objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    objAtencionAM.dtTablaDiagnostico.Rows.RemoveAt(dgvDiagnostico.CurrentCell.RowIndex)
                ElseIf objAtencionAM.dtTablaDiagnostico.Rows(dgvDiagnostico.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        objAtencionAM.dtTablaDiagnostico.Rows.RemoveAt(dgvDiagnostico.CurrentCell.RowIndex)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btOpcionPaciente_Click(sender As Object, e As EventArgs) Handles btOpcionPaciente.Click
        If SesionActual.tienePermiso(Ppaciente) Then
            Dim vFormPaciente As New Form_paciente

            If idPaciente <> -1 Then
                vFormPaciente.cargarPaciente(idPaciente)
            Else
                vFormPaciente.btnuevo_Click(sender, e)
            End If
            vFormPaciente.Show()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvValorDesglosado_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvValorDesglosado.CellEndEdit
        If e.ColumnIndex <> 0 Then Return
        Select Case e.RowIndex
            Case 0
                If Not IsNumeric(dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
                objAtencionAM.kmAdicional = dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Case 1
                objAtencionAM.recargoNocturno = dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex) = New DataGridViewTextBoxCell()
            Case 2
                If Not IsNumeric(dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
                objAtencionAM.cantidadHoraAdicional = dgvValorDesglosado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End Select
        calcularTotales()
    End Sub

    Private Sub Cmenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles Cmenu.ItemClicked
        Select Case e.ClickedItem.Name
            Case Item5minD.Name
                agregarMinutos(5)
            Case Item15minD.Name
                agregarMinutos(15)
            Case Item30minD.Name
                agregarMinutos(30)
            Case Item60minD.Name
                agregarMinutos(60)
            Case Item120minD.Name
                agregarMinutos(120)
            Case ItemFechaActual.Name
                Select Case objAtencionAM.controlAgregarMinuto
                    Case 0
                        mTextSalida.Text = DateTime.Now.ToString("ddMMyyyyHHmm")
                    Case 2
                        mTextRetorno.Text = DateTime.Now.ToString("ddMMyyyyHHmm")
                End Select
            Case ItemLimpiar.Name
                Select Case objAtencionAM.controlAgregarMinuto
                    Case 0
                        mTextSalida.Text = ""
                        mTextSalida.Focus()
                    Case 1
                        mTextLlegada.Text = ""
                        mTextLlegada.Focus()
                    Case 2
                        mTextRetorno.Text = ""
                        mTextRetorno.Focus()
                    Case 3
                        mTextRegreso.Text = ""
                        mTextRegreso.Focus()
                End Select
        End Select
    End Sub
    Private Sub agregarMinutos(ByVal mm As Integer)
        Select Case objAtencionAM.controlAgregarMinuto
            Case 0
                mTextSalida.Text = DateTime.Now.AddMinutes(mm).ToString("ddMMyyyyHHmm")
            Case 1
                mTextLlegada.Text = CDate(mTextSalida.Text).AddMinutes(mm).ToString("ddMMyyyyHHmm")
            Case 2
                mTextRetorno.Text = DateTime.Now.AddMinutes(mm).ToString("ddMMyyyyHHmm")
            Case 3
                mTextRegreso.Text = CDate(mTextRetorno.Text).AddMinutes(mm).ToString("ddMMyyyyHHmm")
        End Select
        verificaRecargoNocturno()
        horasAdicionales()
        calcularTotales()
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        General.buscarElemento(objAtencionAM.sqlTarifaTripulacionAM,
                                      Nothing,
                                      AddressOf cargarTarifaTripulacionAM,
                                      TitulosForm.BUSQUEDA_MANUAL_TARIFARIO,
                                      False)
    End Sub
End Class