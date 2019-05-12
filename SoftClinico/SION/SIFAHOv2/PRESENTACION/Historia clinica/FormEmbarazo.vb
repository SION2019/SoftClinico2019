Public Class FormEmbarazo
    Dim objEmbarazo As New PartoRecienNacido
    Dim vFormPadre As Form_Historia_clinica
    Dim modulo As String
    Dim reporte As New ftp_reportes
    Private Sub FormParto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(gbAntecedente)
        cargarAntecedentesMadre()
    End Sub

    Private Sub cargarInfoIngreso()
        Try
            If Not SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                objEmbarazo.usuarioReal = SesionActual.idUsuario
            End If
            cargarAntecedentesMadre()
            General.deshabilitarControles(gbAntecedente)
            General.deshabilitarBotones(ToolStrip1)
            bteditar.Enabled = True
            btanular.Enabled = True
        Catch ex As Exception
            MsgBox("No se encontraron datos.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atención")
        End Try
    End Sub
    Private Sub cargarAntecedentesMadre()
        objEmbarazo.cargarDetalle()
        cargarDatosInfoIngresoMadre()
        bteditar.Enabled = True
    End Sub
    Private Sub cargarDatosInfoIngresoMadre()
        If IsNothing(objEmbarazo.vih) Then Exit Sub
        txtVIH.Text = objEmbarazo.vih
        txtEdadGestN.Text = objEmbarazo.edadGestacional
        txtFumN.Text = objEmbarazo.fumador
        txtObstetricosN.Text = objEmbarazo.antecedentesObstetricos
        txtHemMN.Text = objEmbarazo.hemoclasificacionMadre
        txtControlPN.Text = objEmbarazo.control
        txtMedDurEmbN.Text = objEmbarazo.medicamentos
        txtHabitosN.Text = objEmbarazo.habito
        txtInfeccionesN.Text = objEmbarazo.infeccion
        txtDiabeteGN.Text = objEmbarazo.diabeteG
        txtDiabeteMN.Text = objEmbarazo.diabeteM
        txtHiperGN.Text = objEmbarazo.hipertencion
        txtPreeclampciaN.Text = objEmbarazo.preclampcia
        txtEnferTN.Text = objEmbarazo.enfermedad
        txtVacunacionN.Text = objEmbarazo.vacunacion
        txtTorch.Text = objEmbarazo.torch
        btanular.Enabled = True
        btimprimir.Enabled = True
    End Sub

    Public Sub iniciarDatos(ByRef form_Historia_clinica As Form_Historia_clinica, pModulo As String)
        vFormPadre = form_Historia_clinica
        objEmbarazo.codigoEP = SesionActual.codigoEP
        objEmbarazo = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_INFO_INGRESO_PARTO & pModulo)
        Me.modulo = pModulo
        txtHC.Text = vFormPadre.txtHC.Text
        txtNombre.Text = vFormPadre.txtNombre.Text
        txtSexo.Text = vFormPadre.txtSexo.Text
        txtEdad.Text = vFormPadre.txtEdad.Text
        txtEstancia.Text = vFormPadre.txtEstancia.Text
        txtContrato.Text = vFormPadre.txtContrato.Text
        txtNombreContrato.Text = vFormPadre.txtNombreContrato.Text
        txtAdmision.Text = vFormPadre.txtAdmision.Text
        objEmbarazo.nRegistro = vFormPadre.txtRegistro.Text
        txtRegistro.Text = objEmbarazo.nRegistro

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtVIH.Text) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_INFO_INGRESO)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objEmbarazo.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                objEmbarazo.usuarioReal = SesionActual.idUsuario
                txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
            End If
        End If
        habilitarCampos()
    End Sub
    Private Sub txtNombreUsuarioInf_MouseDoubleClick(sender As Object, e As EventArgs) Handles txtNombreUsuarioINFN.MouseDoubleClick
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso btguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_ORDEN_MEDICA, objEmbarazo.usuarioReal)
        End If
    End Sub
    Private Sub cambiarUsuario(listaCargo As String, ByRef usuario As Object)
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(listaCargo)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            usuario = tbl(0)
            txtNombreUsuarioInforme.Text = tbl(1)
        End If

    End Sub
    Private Sub habilitarCampos()
        General.habilitarControles(gbAntecedente)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(gbDatos)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        txtNombreUsuarioINFN.ReadOnly = True

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            guardarInfoIngreso()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub guardarInfoIngreso()

        If txtVIH.Text = "" Then
            MsgBox("Por favor ingrese VIH.", MsgBoxStyle.Exclamation)
            txtVIH.Focus()
        ElseIf txtEdadGestN.Text = "" Then
            MsgBox("Por favor ingrese edad gestacional.", MsgBoxStyle.Exclamation)
            txtEdadGestN.Focus()
        ElseIf txtFumN.Text = "" Then
            MsgBox("Por favor ingrese FUM.", MsgBoxStyle.Exclamation)
            txtFumN.Focus()
        ElseIf txtObstetricosN.Text = "" Then
            MsgBox("Por favor ingrese antecedentes obstétricos.", MsgBoxStyle.Exclamation)
            txtObstetricosN.Focus()
        ElseIf txtHemMN.Text = "" Then
            MsgBox("Por favor ingrese hemoclasificación de la madre.", MsgBoxStyle.Exclamation)
            txtHemMN.Focus()
        ElseIf txtControlPN.Text = "" Then
            MsgBox("Por favor ingrese control prenatal.", MsgBoxStyle.Exclamation)
            txtControlPN.Focus()
        ElseIf txtMedDurEmbN.Text = "" Then
            MsgBox("Por favor ingrese medicamentos durante el embarazo.", MsgBoxStyle.Exclamation)
            txtMedDurEmbN.Focus()
        ElseIf txtHabitosN.Text = "" Then
            MsgBox("Por favor ingrese hábitos.", MsgBoxStyle.Exclamation)
            txtHabitosN.Focus()
        ElseIf txtInfeccionesN.Text = "" Then
            MsgBox("Por favor ingrese infecciones en el embarazo.", MsgBoxStyle.Exclamation)
            txtInfeccionesN.Focus()
        ElseIf txtDiabeteGN.Text = "" Then
            MsgBox("Por favor ingrese diabete gestacional.", MsgBoxStyle.Exclamation)
            txtDiabeteGN.Focus()
        ElseIf txtDiabeteMN.Text = "" Then
            MsgBox("Por favor ingrese diabete mellitus.", MsgBoxStyle.Exclamation)
            txtDiabeteMN.Focus()
        ElseIf txtHiperGN.Text = "" Then
            MsgBox("Por favor ingrese hipertención gestacional.", MsgBoxStyle.Exclamation)
            txtHiperGN.Focus()
        ElseIf txtPreeclampciaN.Text = "" Then
            MsgBox("Por favor ingrese preeclampcia.", MsgBoxStyle.Exclamation)
            txtPreeclampciaN.Focus()
        ElseIf txtEnferTN.Text = "" Then
            MsgBox("Por favor ingrese enfermedad tiroidea.", MsgBoxStyle.Exclamation)
            txtEnferTN.Focus()
        ElseIf txtVacunacionN.Text = "" Then
            MsgBox("Por favor ingrese vacunación.", MsgBoxStyle.Exclamation)
            txtVacunacionN.Focus()
        ElseIf txtTorch.Text = "" Then
            MsgBox("Por favor ingrese Torch.", MsgBoxStyle.Exclamation)
            txtTorch.Focus()
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardarInfoIngresoAN()
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            cargarInfoIngreso()
        End If
    End Sub
    Private Sub guardarInfoIngresoAN()
        Try
            btimprimir.Enabled = False
            objEmbarazo.usuario = SesionActual.idUsuario
            objEmbarazo.codigoEP = SesionActual.codigoEP
            precargarDatosInfoIngresoNeonato()
            objEmbarazo.guardarEmbarazo()
        Catch ex As Exception
            Throw ex
        End Try
        btimprimir.Enabled = True
    End Sub
    Private Sub precargarDatosInfoIngresoNeonato()
        objEmbarazo.vih = txtVIH.Text
        objEmbarazo.edadGestacional = txtEdadGestN.Text
        objEmbarazo.fumador = txtFumN.Text
        objEmbarazo.antecedentesObstetricos = txtObstetricosN.Text
        objEmbarazo.hemoclasificacionMadre = txtHemMN.Text
        objEmbarazo.control = txtControlPN.Text
        objEmbarazo.medicamentos = txtMedDurEmbN.Text
        objEmbarazo.habito = txtHabitosN.Text
        objEmbarazo.infeccion = txtInfeccionesN.Text
        objEmbarazo.diabeteG = txtDiabeteGN.Text
        objEmbarazo.diabeteM = txtDiabeteMN.Text
        objEmbarazo.hipertencion = txtHiperGN.Text
        objEmbarazo.preclampcia = txtPreeclampciaN.Text
        objEmbarazo.enfermedad = txtEnferTN.Text
        objEmbarazo.vacunacion = txtVacunacionN.Text
        objEmbarazo.torch = txtTorch.Text
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If

        cargarInfoIngreso()
        General.deshabilitarControles(gbDatos)
        General.deshabilitarControles(gbAntecedente)
        General.deshabilitarBotones(ToolStrip1)
        bteditar.Enabled = True
        btanular.Enabled = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objEmbarazo.anularEmbarazo()
                General.posAnularForm(Me, ToolStrip1, btanular, bteditar)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_EMBARAZO
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtRegistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarSonda()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarSonda()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_EMBARAZO, txtRegistro.Text, New rptEmbarazoParto,
                                    txtRegistro.Text, "{VISTA_EMBAZARO_Y_PARTO.N_registro_madre} = " & txtRegistro.Text & "",
                                    ConstantesHC.NOMBRE_PDF_EMBARAZO, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class