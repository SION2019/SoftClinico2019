Imports System.Threading
Public Class Form_justificacion_antibiotico
    Private codigoEquivalenciaUno As String
    Dim dtDiagnostico, dtAntibiotico, dtMedicamentos As New DataTable
    Dim consulta, nombreUsuario, pNuevo, permisoGeneral, pEditar, pBuscar, pAnular, codigoTemporal, moduloTemporal As String
    Public usuarioInforme, contadorDiag, nRegistro, usuarioActual As Integer
    Dim activoAM, activoAF, respuestan As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim guardarEn2doPlano As Thread
    Dim objAntibiotico As New JustificacionMedicamento
    Dim vFormPadre As Form_Historia_clinica
    Private tipoDetalleOM As Integer = -1
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_justificacion_antiviotico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(moduloTemporal) Then
            moduloTemporal = Tag.modulo
        End If
        txtjustificacion.ReadOnly = True


        If String.IsNullOrEmpty(txtregistro.Text) Then
            Texttipomuestra.ReadOnly = True
            Textaislamiento.ReadOnly = True
            rsi.Enabled = False
            rno.Enabled = False
            textfechamuestra.Enabled = False
            objAntibiotico = GeneralHC.fabricaHC.crear(Constantes.CODIGO_ANTIBIOTICO & Tag.modulo)
            Label1.Text = objAntibiotico.titulo
        End If

        cargarPermisos()
        textfechamuestra.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        With dgvmedicamentos
            .Columns("codigo").ReadOnly = True
            .Columns.Item("codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("codigo").DataPropertyName = "Codigo_Interno"

            .Columns("Antibiotico1").ReadOnly = True
            .Columns.Item("Antibiotico1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Antibiotico1").DataPropertyName = "Descripcion"

            .Columns("uso").ReadOnly = True
            .Columns.Item("uso").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("uso").DataPropertyName = "Dias"
        End With

        With dgvantibiotico
            .Columns("Antibiotico").ReadOnly = True
            .Columns.Item("Antibiotico").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Antibiotico").DataPropertyName = "Antibiotico anterior"

            .Columns("tiempo").ReadOnly = True
            .Columns.Item("tiempo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("tiempo").DataPropertyName = "Tiempo uso"
        End With

        If Not String.IsNullOrEmpty(txtregistro.Text) Then
            cargarDiagnosticosEvo()
            cargarDatosPacientes()
            cargarMedicamentos()
        End If

    End Sub

    Public Sub cargarPermisos()
        permisoGeneral = perG.buscarPermisoGeneral(Name, moduloTemporal)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pBuscar = permisoGeneral & "pp" & "03"
        pAnular = permisoGeneral & "pp" & "04"
    End Sub


    Public Sub cargarDiagnosticosSol()
        objAntibiotico.cargarDiagnosticosSol()
        dgvdiagnostico.DataSource = objAntibiotico.dtDiagnosticos
        dgvdiagnostico.Columns("codigo_evo").Visible = False
        dgvdiagnostico.Columns("codigo").Visible = False
        dgvdiagnostico.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dgvdiagnostico.Columns(2).Width = 290
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(objAntibiotico.consultaBuscar, params,
                                           AddressOf cargarBusqueda,
                                           TitulosForm.BUSQUEDA_JUSTIFICACION,
                                           False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarBusqueda(pCodigo As Integer)
        Dim dt As New DataTable
        Dim param As New List(Of String)
        param.Add(pCodigo)
        General.llenarTabla(objAntibiotico.cargarBusqueda, param, dt)
        Textcodigo.Text = pCodigo
        objAntibiotico.codigo = Textcodigo.Text
        txtregistro.Text = dt.Rows(0).Item("N_Registro")
        objAntibiotico.nRegistro = txtregistro.Text
        txtorden.Text = dt.Rows(0).Item("Codigo_Orden")
        Textcodigointerno.Text = dt.Rows(0).Item("Codigo_med_especial")
        textfechamuestra.Text = dt.Rows(0).Item("fecha_muestra")

        txtjustificacion.Text = dt.Rows(0).Item("Justificacion")
        Textmedicamento.Text = dt.Rows(0).Item("medicamento especial")
        Textnombre.Text = dt.Rows(0).Item("Nombre_Completo")

        If dt.Rows(0).Item("Tomó_Muestra") = True Then
            rsi.Checked = True
        Else
            rno.Checked = True
        End If

        Texttipomuestra.Text = dt.Rows(0).Item("Tipo_muestra")

        txtarea.Text = dt.Rows(0).Item("Area Servicio")
        Textidentificacion.Text = dt.Rows(0).Item("Documento_paciente")
        Textempresa.Text = dt.Rows(0).Item("Nombre_EPS")
        Textaislamiento.Text = dt.Rows(0).Item("Aislamiento")

        cargarDiagnosticosSol()
        cargarAntibioticos()
        General.deshabilitarControles(Me)
        dgvmedicamentos.Visible = False
        dgvantibiotico.Visible = True
        bteditar.Enabled = True
        btanular.Enabled = True
        btimprimir.Enabled = True
    End Sub


    Private Sub rno_CheckedChanged(sender As Object, e As EventArgs) Handles rno.CheckedChanged
        If rno.Checked = True Then
            Textaislamiento.ReadOnly = True
            Texttipomuestra.ReadOnly = True
            txtjustificacion.ReadOnly = True
            Textaislamiento.Clear()
            Texttipomuestra.Clear()
            txtjustificacion.Clear()
        Else
            Textaislamiento.ReadOnly = False
            Texttipomuestra.ReadOnly = False
            txtjustificacion.ReadOnly = False
        End If
    End Sub


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular ) Then

            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                objAntibiotico.anulaJustificacion()
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                Textcodigo.Clear()
                dtAntibiotico.Clear()
                dtDiagnostico.Clear()
                dtMedicamentos.Clear()
                btguardar.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub Form_justificacion_antibiotico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If String.IsNullOrEmpty(Textcodigo.Text) AndAlso Not IsNothing(vFormPadre) Then
            Select Case tipoDetalleOM

                Case Constantes.OM_MEDICAMENTO
                    If IsNothing(vFormPadre.dgvMedicamento.Rows(vFormPadre.dgvMedicamento.CurrentRow.Index).Cells("dgDescripcionMed").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Case Constantes.OM_IMPREGNACION
                    If IsNothing(vFormPadre.dgvImpregnacion.Rows(vFormPadre.dgvImpregnacion.CurrentRow.Index).Cells("dgDescripcionImpre").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Case Constantes.OM_INFUSION
                    If IsNothing(vFormPadre.dgvInfusion.Rows(vFormPadre.dgvInfusion.CurrentRow.Index).Cells("dgDescripcionInfu").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Case Constantes.OM_MEZCLA
                    If IsNothing(vFormPadre.dgvMezcla.Rows(vFormPadre.dgvMezcla.CurrentRow.Index).Cells("dgDescripcionMezcla").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select


        End If

        If (btbuscar.Enabled = True Or Not String.IsNullOrEmpty(Textcodigo.Text)) Then

            If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
        If String.IsNullOrEmpty(Textcodigo.Text) And btguardar.Enabled = True Then

            If MsgBox(Mensajes.QUITAR_MEDICAMENTO, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            Else
                quitarMedicamentoOM()
            End If
        End If
    End Sub

    Private Sub quitarMedicamentoOM()
        Select Case tipoDetalleOM
            Case Constantes.OM_MEDICAMENTO
                vFormPadre.eliminaFilaDt(vFormPadre.dgvMedicamento.DataSource, vFormPadre.dgvMedicamento.CurrentRow.Index)
            Case Constantes.OM_IMPREGNACION
                vFormPadre.eliminaFilaDt(vFormPadre.dgvImpregnacion.DataSource, vFormPadre.dgvImpregnacion.CurrentRow.Index)
            Case Constantes.OM_INFUSION
                vFormPadre.eliminaFilaDt(vFormPadre.dgvInfusion.DataSource, vFormPadre.dgvInfusion.CurrentRow.Index)
            Case Constantes.OM_MEZCLA
                Dim NombreTablaMezcla As String
                NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(vFormPadre.dgvInfusion.DataSource, vFormPadre.dgvInfusion.DataSource)
                vFormPadre.eliminaFilaDt(vFormPadre.dgvMezcla.DataSource, vFormPadre.dgvMezcla.CurrentRow.Index)
        End Select
    End Sub

    Private Sub dgvmedicamentos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvmedicamentos.DataError

    End Sub

    Private Sub dgvantibiotico_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvantibiotico.DataError

    End Sub

    Private Sub rsi_CheckedChanged(sender As Object, e As EventArgs) Handles rsi.CheckedChanged

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = False
            btanular.Enabled = False
            dtAntibiotico.Clear()
            btimprimir.Enabled = False
            btbuscar.Enabled = True
            btguardar.Enabled = False
            General.limpiarControles(Me)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            objAntibiotico.codigo = Textcodigo.Text
            objAntibiotico.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Public Sub deshabilitarControles()
        Textcodigo.ReadOnly = True
        txtarea.ReadOnly = True
        Textnombre.ReadOnly = True
        Textidentificacion.ReadOnly = True
        textfechamuestra.Enabled = False
        Textempresa.ReadOnly = True
        txtorden.ReadOnly = True
        txtregistro.ReadOnly = True
        Textcodigo.ReadOnly = True
        txtregistro.ReadOnly = True
        txtorden.ReadOnly = True
        dgvdiagnostico.Columns(0).ReadOnly = False
        dgvdiagnostico.Columns(1).ReadOnly = False
        dgvdiagnostico.Columns(2).ReadOnly = False
    End Sub

    Public Sub guardarAntibioticos(Optional pSegundoPlano As Boolean = False)

        dgvmedicamentos.EndEdit()
        dtMedicamentos.AcceptChanges()
        dgvdiagnostico.EndEdit()
        dtDiagnostico.AcceptChanges()
        Try
            If (pSegundoPlano = False AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes) OrElse pSegundoPlano = True Then

                Dim muestra As Boolean
                If rsi.Checked = True Then
                    muestra = Constantes.MUESTRA_SI
                Else
                    muestra = Constantes.MUESTRA_NO
                End If

                objAntibiotico.codigo = Textcodigo.Text
                objAntibiotico.codigoOrden = txtorden.Text
                objAntibiotico.nRegistro = txtregistro.Text
                objAntibiotico.codigoInterno = codigoEquivalenciaUno

                If objAntibiotico.dtMedicamentos.Rows.Count > 0 Then
                    objAntibiotico.antibiotico = dgvmedicamentos.Rows(dgvmedicamentos.CurrentCell.RowIndex).Cells("codigo").Value
                    objAntibiotico.tiempoUso = dgvmedicamentos.Rows(dgvmedicamentos.CurrentCell.RowIndex).Cells("uso").Value
                Else
                    objAntibiotico.antibiotico = 0
                    objAntibiotico.tiempoUso = ""
                End If
                objAntibiotico.aislamiento = Textaislamiento.Text
                objAntibiotico.fechaMuestra = textfechamuestra.Text
                objAntibiotico.justificacion = txtjustificacion.Text
                objAntibiotico.tipoMuestra = Texttipomuestra.Text
                objAntibiotico.timoMuestra = muestra
                objAntibiotico.usuario = SesionActual.idUsuario
                objAntibiotico.codigoEP = SesionActual.codigoEP

                objAntibiotico.guardarJustificacion()

                Textcodigo.Text = objAntibiotico.codigo
                codigoTemporal = Textcodigo.Text
                usuarioActual = SesionActual.idUsuario
                nRegistro = txtregistro.Text
                If pSegundoPlano = False Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    bteditar.Enabled = True
                    btbuscar.Enabled = True
                    btanular.Enabled = True
                    btimprimir.Enabled = True
                End If
                'guardarSegundoPlano()
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarMedicamentos()
        objAntibiotico.nRegistro = txtregistro.Text
        objAntibiotico.cargarMedicamentos()
        dgvmedicamentos.DataSource = objAntibiotico.dtMedicamentos
    End Sub

    Public Function validarControles()
        dgvdiagnostico.EndEdit()
        objAntibiotico.dtDiagnosticos.AcceptChanges()
        dgvmedicamentos.EndEdit()
        objAntibiotico.dtMedicamentos.AcceptChanges()

        If objAntibiotico.dtDiagnosticos.Select("Seleccion=1", "").Count = 0 Then
            MsgBox("Debe seleccionar algun Diagnostico", MsgBoxStyle.Exclamation)
            dgvdiagnostico.Focus()
            Return False
        ElseIf objAntibiotico.dtMedicamentos.Rows.Count >= 1 AndAlso dgvmedicamentos.Visible = True AndAlso objAntibiotico.dtMedicamentos.Select("Seleccion=1", "").Count = 0 Then
            MsgBox("Debe seleccionar algun Medicamentos", MsgBoxStyle.Exclamation)
            dgvdiagnostico.Focus()
            Return False
        ElseIf rsi.Checked = True And String.IsNullOrEmpty(Texttipomuestra.Text) Then
            MsgBox("El campo tipo muestra se encuentra vacio", MsgBoxStyle.Exclamation)
            Texttipomuestra.Focus()
            Return False
        ElseIf rsi.Checked = True And String.IsNullOrEmpty(Textaislamiento.Text) Then
            MsgBox("El campo aislamiento se encuentra vacio", MsgBoxStyle.Exclamation)
            Textaislamiento.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvmedicamentos.EndEdit()
        dgvantibiotico.EndEdit()

        If validarControles() Then

            If String.IsNullOrEmpty(Textcodigo.Text) Then
                Select Case tipoDetalleOM
                    Case Constantes.OM_MEDICAMENTO
                        vFormPadre.dgvMedicamento.Rows(vFormPadre.dgvMedicamento.CurrentRow.Index).Cells("dgDescripcionMed").Tag = Me
                    Case Constantes.OM_IMPREGNACION
                        vFormPadre.dgvImpregnacion.Rows(vFormPadre.dgvImpregnacion.CurrentRow.Index).Cells("dgDescripcionImpre").Tag = Me
                    Case Constantes.OM_INFUSION
                        vFormPadre.dgvInfusion.Rows(vFormPadre.dgvInfusion.CurrentRow.Index).Cells("dgDescripcionInfu").Tag = Me
                    Case Constantes.OM_MEZCLA
                        vFormPadre.dgvMezcla.Rows(vFormPadre.dgvMezcla.CurrentRow.Index).Cells("dgDescripcionMezcla").Tag = Me
                End Select

                Visible = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Exit Sub
            Else
                guardarAntibioticos()
            End If
        End If
    End Sub

    Public Sub habilitarControles()
        Texttipomuestra.ReadOnly = False
        Textaislamiento.ReadOnly = False
        txtjustificacion.ReadOnly = False
        textfechamuestra.Enabled = True
        rsi.Enabled = True
        rno.Enabled = True
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar ) Then
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btimprimir.Enabled = False
            bteditar.Enabled = False
            btbuscar.Enabled = False
            btanular.Enabled = False
            btguardar.Enabled = True
            habilitarControles()
            deshabilitarControles()
            textfechamuestra.Enabled = True

            dgvdiagnostico.ReadOnly = False
            dgvdiagnostico.Columns(0).ReadOnly = True
            dgvdiagnostico.Columns(1).ReadOnly = True
            dgvdiagnostico.Columns(2).ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If

    End Sub

    Public Sub cargarDatosPacientes()
        objAntibiotico.cargarDatosPacientes()
        Textnombre.Text = objAntibiotico.nombreCompleto
        Textidentificacion.Text = objAntibiotico.identificacion
        Textempresa.Text = objAntibiotico.EPS
        txtarea.Text = objAntibiotico.areaServicio
    End Sub

    Public Sub cargarAntibioticos()

        objAntibiotico.cargarAntibioticos()
        dgvantibiotico.DataSource = objAntibiotico.dtAntibiotico
        dgvantibiotico.Columns("codigo anterior").Visible = False
    End Sub

    Public Sub cargarDatos(ByRef vFormPadre As Form_Historia_clinica, codigoEquivalencia As String, nombreMedicamentoJ As String, tipo As String)
        Me.vFormPadre = vFormPadre
        Tag = vFormPadre.Tag.Modulo
        moduloTemporal = Tag
        tipoDetalleOM = tipo
        txtregistro.Text = vFormPadre.txtRegistro.Text
        txtorden.Text = vFormPadre.txtCodigoOrden.Text
        Textcodigointerno.Text = codigoEquivalencia
        codigoEquivalenciaUno = codigoEquivalencia
        Textmedicamento.Text = nombreMedicamentoJ
        objAntibiotico = GeneralHC.fabricaHC.crear(Constantes.CODIGO_ANTIBIOTICO & Tag)
        objAntibiotico.nRegistro = txtregistro.Text
        Label1.Text = objAntibiotico.titulo
        btguardar.Enabled = True
        textfechamuestra.Enabled = True
        rsi.Enabled = True
        rno.Enabled = True
        txtjustificacion.ReadOnly = True
        textfechamuestra.Enabled = True
        btbuscar.Enabled = False
        ShowDialog()

    End Sub

    Public Sub cargarDiagnosticosEvo()
        objAntibiotico.nRegistro = txtregistro.Text
        objAntibiotico.cargarDiagnosticosEvo()
        dgvdiagnostico.DataSource = objAntibiotico.dtDiagnosticos
        dgvdiagnostico.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dgvdiagnostico.Columns(2).Width = 290
        dgvdiagnostico.Columns("Codigo").Visible = False
        dgvdiagnostico.Columns("Codigo_evo").Visible = False
    End Sub
End Class