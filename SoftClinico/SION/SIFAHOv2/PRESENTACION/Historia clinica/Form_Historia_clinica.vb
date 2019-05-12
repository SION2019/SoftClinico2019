Imports System.Threading
Imports Microsoft.Office.Interop
'' <summary>
'' 
'' </summary>
Public Class Form_Historia_clinica
    Dim dtParticipantes As New DataTable
    Dim codigoEvo As Integer
    Dim reporte As New ftp_reportes
    Dim perG As New Buscar_Permisos_generales
    Dim usuarioInformeTemporal, area, nRegistro, nRegistroTemporal, codEps, usuarioActual, codigoEntrada As Integer
    Dim respuesta, servicioNeonatal, seguir, buscar, editadoAM, editadoAF, activoAM, activoAF, primeraVez, diaSeleccionado, comidaSeleccionada As Boolean
    Dim fechaTemporal As DateTime
    Shared hilo As Thread
    Dim descripcionArea, modulo, CodigoTemporal, permisoGeneral, pEditarInfoIngreso, pAnularDiagnostico, pNuevaOm, pEditarOm, pAnularOm, pDuplicarOm, PTrasladar,
           pTrabajarOm, pTrabajarComida, pEditarHoras, pNuevaEm, pEditarEm, pAnularEm, pNotaAuditoria, pDuplicarEm, pVerListaChequeo,
           pNuevaIc, pEditarIc, pAnularIc, pDuplicarIc, pNuevaRm, pEditarRm, pAnularRm, pDuplicarRm,
           pNuevaOx, pEditarOx, pAnularOx, pEditarTp, pNuevaOi, pEditarOi, pAnularOi, pAnularI, pDuplicarOi,
           pNuevaNf, pEditarNf, pAnularNf, pDuplicarNf, pNuevaOie, pEditarOie, pAnularOie, pAnularIe, pDuplicarOie,
           pNuevaNe, pEditarNe, pAnularNe, pDuplicarNe, pSolicitudLab, pVerResultadoP, pIngresarResulP, pVerResultadoH,
           pIngresarInterH, pIngresarArchivoH, pNuevaHg, pEditarHg, pAnularHg, pAnularG, pDuplicarHg, pPedidoFarm, pEpicrisis, pCorreo,
           pRecetario, pVisorNotaAuditoria, pParametrosv, pSabana, pTrasladoC, pVerPrefactura, pPrefacturar, pVisado, pConsolidado, pCrearExamen, procedimientoInterconsulta, procedimientoTerapia, consulta, seleccionados, ruta,
           consultaVerificar, areaInforme, nombreArchivo, mensajeError, opcionFisioSeleccionado, opcionEnferSeleccionado, opcionGlucomSeleccionado, pIntervalo4horas, pDocumentoIntermedio, pHojaRuta, pParto As String
    Dim objHistoriaClinica As HistoriaClinica
    Dim objFormato As New FormatoIngreso
    Dim objListachequeo As New ListaCheck
    Dim objAuditorEx As New AuditorExterno
    Dim fPadre As Form_Listado_Paciente
    Private cerrar, abierto As Boolean
    Shared codigoRemision As Integer
    Dim objPrincipal As New Principal

    Public Sub datosPrincipales(params As List(Of String), dgvPadre As Form_Listado_Paciente)
        area = params(0)
        Name = params(1)
        MdiParent = FormPrincipal
        txtRegistro.Text = params(2)
        txtHC.Text = params(3)
        txtNombre.Text = params(4)
        txtAdmision.Text = Format(CDate(params(5)), Constantes.FORMATO_FECHA_HORA_GEN)
        txtEstancia.Text = params(6)
        txtContrato.Text = params(7)
        txtNombreContrato.Text = params(8)
        txtSexo.Text = params(9)
        txtEdad.Text = params(10)
        Tag = dgvPadre.Tag
        modulo = params(11)
        Label1.Text = params(12)
        descripcionArea = params(13)
        fPadre = dgvPadre
    End Sub

    Private Sub dgvEstancia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEstancia.CellDoubleClick
        General.abrirJustificacion(dgvEstancia, objHistoriaClinica.objOrdenMedica.dtEstancias, PanelJustificacionEstancia, txtJustificacionEstancia, "dgJustificacion", Not (tsordenguardar.Enabled AndAlso
                                   String.IsNullOrEmpty(objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("N_Registro").ToString) = False AndAlso
                                   objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("N_Registro").ToString = nRegistro))
        If tsordenguardar.Enabled = False OrElse (String.IsNullOrEmpty(objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("N_Registro").ToString) = False AndAlso objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("N_Registro").ToString <> nRegistro) Then
            Exit Sub
        End If

        If (dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgCodigo").Selected = True _
                OrElse dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgDescripcion").Selected = True) _
                And objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            mensajeError = HistoriaClinicaBLL.verificarEstancia(modulo, objHistoriaClinica.objInfoIngreso.diasEstancia, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, False, nRegistro)
            If mensajeError = "" Then
                Dim params As New List(Of String)
                params.Add(nRegistro)
                params.Add(Constantes.GRUPO_ESTANCIA)
                params.Add(Nothing)
                General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_ESTANCIA, dgvEstancia,
                                  objHistoriaClinica.objOrdenMedica.dtEstancias, 0, 1, dgvEstancia.Columns("dgDescripcion").Index,
                                  False,,, True, AddressOf llenarEstancia)
                If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Count > 0 AndAlso objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 1).Item("Estado").ToString <> "" Then
                    objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
                End If
                dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgDiaEstancia").Selected = True
            Else
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                mensajeError = ""
            End If
        ElseIf dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("anularEstancia").Selected = True And objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_ESTANCIA, modulo, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, txtCodigoOrden.Text, nRegistro))


        End If
        bloquearDgvEstancia()
    End Sub

    Public Function consolidadoPendiente() As Boolean
        Dim respuesta As Boolean
        If ((Not IsNothing(objHistoriaClinica)) AndAlso (Not IsNothing(objHistoriaClinica.objConsolidado)) AndAlso objHistoriaClinica.objConsolidado.Generando = True) Then
            respuesta = True
        Else
            respuesta = False
        End If
        Return respuesta
    End Function

    Private Sub bloquearDgvEstancia()
        If dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgDiaEstancia").Selected = True Then
            If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgDiaEstancia").ReadOnly = False
            Else
                dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgDiaEstancia").ReadOnly = True
            End If

        End If
    End Sub
    Private Sub dgvEstancia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvEstancia.KeyPress
        General.abrirJustificacion(dgvEstancia, objHistoriaClinica.objOrdenMedica.dtEstancias, PanelJustificacionEstancia, txtJustificacionEstancia, "dgJustificacion", Not tsordenguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub tsordenguardar_Click(sender As Object, e As EventArgs) Handles tsordenguardar.Click
        objHistoriaClinica.objOrdenMedica.opcionCancelar = False
        Try

            ordenes.Focus()
            Try
                txtJustificacionEstancia_Leave(sender, e)
            Catch ex As Exception
                Label167.Text = "1004"
                Throw ex
            End Try
            btAceptarMezcla_Click(sender, e)
            Try
                txtJustificacionComida_Leave(sender, e)
                txtJustificacionOxigeno_Leave(sender, e)
                txtJustificacionParaclinico_Leave(sender, e)
                txtJustificacionHemoderivado_Leave(sender, e)
                txtJustificacionProcedimiento_Leave(sender, e)
                dgvMezcla_Leave(sender, e)
            Catch ex As Exception
                Label167.Text = "1005"
                Throw ex
            End Try
            objHistoriaClinica.objOrdenMedica.fechaOrden = fechaOrdenMedica.Value
            If validarOrdenMedica() = False Then Exit Sub
            calculaFrecuencia(objHistoriaClinica.objOrdenMedica.dtGlucometrias)
            calculaFrecuencia(objHistoriaClinica.objOrdenMedica.dtMedicamentos)
            calculaDosis()
            calculaDisolvente()
            establecerObjetoNutricion()
            guardarOrdenMedica()
            verificarSoat()
            gbEstancia.Focus()
        Catch ex As Exception
            Label166.Text = "Error 1"
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub calculaFrecuencia(ByRef dt As DataTable)
        If IsNothing(dt) = False Then
            HistoriaClinicaBLL.calcularFrecuencia(dt)
        End If
    End Sub
    Private Sub calculaDosis()
        If IsNothing(objHistoriaClinica) = False Then
            HistoriaClinicaBLL.calcularTotalDosis(objHistoriaClinica.objOrdenMedica.dtInfusiones)
        End If
    End Sub

    Private Sub calculaDisolvente()
        If IsNothing(objHistoriaClinica) = False Then
            HistoriaClinicaBLL.calcularTotalDisolvente(objHistoriaClinica.objOrdenMedica.dtImpregnaciones)
        End If

    End Sub

    Private Sub tsevovista_Click(sender As Object, e As EventArgs) Handles tsevovista.Click
        Try
            objHistoriaClinica.objEvolucionMedica.opcionCancelar = False
            If tsevoguardar.Enabled = True Then
                MsgBox("Por favor guarde la información de la evolución del paciente.", MsgBoxStyle.Information)
                Exit Sub
            ElseIf Listaevoluciones.Items.Count < 2 Then
                MsgBox("Este paciente no tiene evoluciones.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            tsevovista.Enabled = False
            objHistoriaClinica.objEvolucionMedica.imprimirEvolucion(Listaevoluciones.SelectedIndex)

        Catch ex As Exception
            Label166.Text = "Error 2"
            General.manejoErrores(ex)
        End Try
        tsevovista.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub tsinfovista_Click(sender As Object, e As EventArgs) Handles tsinfovista.Click
        Try
            If txtPeso.Text = "" And txtGramos.Text = "" Or tsinfoguardar.Enabled = True Then
                MsgBox("Por favor guarde la información de ingreso del paciente", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            tsinfovista.Enabled = False
            objHistoriaClinica.objInfoIngreso.imprimirHoja()


        Catch ex As Exception
            Label166.Text = "Error 4"
            General.manejoErrores(ex)
        End Try
        tsinfovista.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub txtJustificacionEstancia_Leave(sender As Object, e As EventArgs) Handles txtJustificacionEstancia.Leave
        Try
            If PanelJustificacionEstancia.Visible = True Then
                PanelJustificacionEstancia.Visible = False
                dgvEstancia.Rows(dgvEstancia.CurrentRow.Index).Cells("dgJustificacion").Value = txtJustificacionEstancia.Text
                txtJustificacionEstancia.Clear()
                objHistoriaClinica.objOrdenMedica.dtEstancias.AcceptChanges()
            End If
        Catch ex As Exception
            Label166.Text = "Error 3"
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub fechaOrdenMedica_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechaOrdenMedica.Validating
        If objHistoriaClinica.objOrdenMedica.opcionCancelar = True OrElse (verificarSolicitudLab(txtCodigoOrden.Text) And
            SesionActual.tienePermiso(pEditarHoras)) Then
            Exit Sub
        End If
        Dim paramsPermisos As New List(Of String)
        paramsPermisos.Add(pIntervalo4horas)
        paramsPermisos.Add(pDocumentoIntermedio)
        mensajeError = GeneralHC.validarFecha(modulo, nRegistro, fechaOrdenMedica, CDate(txtAdmision.Text), paramsPermisos)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            e.Cancel = True
            'fechaOrdenMedica.Focus()
        End If
    End Sub

    Private Sub tsordenvista_Click(sender As Object, e As EventArgs) Handles tsordenvista.Click
        Try
            objHistoriaClinica.objOrdenMedica.opcionCancelar = False
            If tsordenguardar.Enabled = True Then
                MsgBox("Por favor guarde la información de la interconsulta.", MsgBoxStyle.Information)
                Exit Sub
            ElseIf listaordenes.Items.Count < 2 Then
                MsgBox("Este paciente no tiene ordenes médicas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            tsordenvista.Enabled = False
            objHistoriaClinica.objOrdenMedica.imprimirOrden(listaordenes.SelectedIndex)

        Catch ex As Exception
            Label166.Text = "Error 5"
            General.manejoErrores(ex)
        End Try
        tsordenvista.Enabled = True
        Cursor = Cursors.Default

    End Sub

    Private Function fechaEvolucion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechaEvolucion.Validating
        If objHistoriaClinica.objEvolucionMedica.opcionCancelar = True Then
            Return True
        End If
        Dim paramsPermisos As New List(Of String)
        paramsPermisos.Add(pIntervalo4horas)
        paramsPermisos.Add(pDocumentoIntermedio)
        mensajeError = GeneralHC.validarFecha(modulo, nRegistro, fechaEvolucion, CDate(txtAdmision.Text), paramsPermisos)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            If Not IsNothing(e) Then
                e.Cancel = True
            End If
            fechaEvolucion.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub fechaRemision_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechaRemision.Validating
        If objHistoriaClinica.objRemision.opcionCancelar = True Then
            Exit Sub
        End If
        Dim paramsPermisos As New List(Of String)
        paramsPermisos.Add(pIntervalo4horas)
        paramsPermisos.Add(pDocumentoIntermedio)
        mensajeError = GeneralHC.validarFecha(modulo, nRegistro, fechaRemision, CDate(txtAdmision.Text), paramsPermisos)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            e.Cancel = True
            fechaRemision.Focus()
        End If
    End Sub

    Private Sub MorseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MorseToolStripMenuItem.Click
        Form_EscalaM.cargarModulo(Tag.modulo)
        General.cargarForm(Form_EscalaM)
        Form_EscalaM.txtregistro.Text = txtRegistro.Text
        Form_EscalaM.txtpnombre.Text = txtNombre.Text
        Form_EscalaM.cargarDatos()
        Form_EscalaM.Focus()

    End Sub

    Private Sub SondaVesicalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SondaVesicalToolStripMenuItem.Click
        Form_Sonda_Vesical.cargarModulo(Tag.modulo)
        General.cargarForm(Form_Sonda_Vesical)
        Form_Sonda_Vesical.txtregistro.Text = txtRegistro.Text
        Form_Sonda_Vesical.txtpnombre.Text = txtNombre.Text
        Form_Sonda_Vesical.txtfecha.Text = txtAdmision.Text
        Form_Sonda_Vesical.txteps.Text = txtNombreContrato.Text
        Form_Sonda_Vesical.Label1.Text = Constantes.TITULO_SONDA
        Form_Sonda_Vesical.tipoEntrada = Constantes.SONDA_VESICAL
        Form_Sonda_Vesical.llenarSondaVesical()
        Form_Sonda_Vesical.Focus()
    End Sub

    Private Sub VenopunciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VenopunciónToolStripMenuItem.Click
        Form_Sonda_Vesical.cargarModulo(Tag.modulo)
        General.cargarForm(Form_Sonda_Vesical)
        Form_Sonda_Vesical.txtregistro.Text = txtRegistro.Text
        Form_Sonda_Vesical.txtpnombre.Text = txtNombre.Text
        Form_Sonda_Vesical.txtfecha.Text = txtAdmision.Text
        Form_Sonda_Vesical.txteps.Text = txtNombreContrato.Text
        Form_Sonda_Vesical.Label1.Text = Constantes.TITULO_VENOPUNCION
        Form_Sonda_Vesical.tipoEntrada = Constantes.VENOPUNCION
        Form_Sonda_Vesical.Label7.Text = Constantes.CODIGO_VENO
        Form_Sonda_Vesical.llenarVenopuncion()
        Form_Sonda_Vesical.Focus()

    End Sub

    Private Sub dgvEstancia_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvEstancia.KeyDown
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_ESTANCIA)
            params.Add(Nothing)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_ESTANCIA, dgvEstancia,
                                  objHistoriaClinica.objOrdenMedica.dtEstancias, 0, 1, dgvEstancia.Columns("dgDescripcion").Index,
                                  False,,, True, AddressOf llenarEstancia)
            If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Count > 0 AndAlso objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 1).Item("Estado").ToString <> "" Then
                objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
            End If
        End If
    End Sub
    Private Sub llenarEstancia()
        objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 2).Item("Dia") = fechaOrdenMedica.Text
        objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 2).Item("Justificación") = ""
        objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 2).Item("N_Registro") = nRegistro
        dgvEstancia.Columns("dgDiaEstancia").ReadOnly = False
        For i = 0 To dgvEstancia.Rows.Count - 2
            dgvEstancia.Rows(i).Cells("dgDiaEstancia").ReadOnly = True
        Next
        dgvEstancia.Rows(dgvEstancia.Rows.Count - 1).Cells("dgDiaEstancia").ReadOnly = True
        dgvEstancia.Rows(dgvEstancia.Rows.Count - 2).Cells("dgDiaEstancia").Selected = True

    End Sub
    Private Sub llenarComida()
        objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item(2) = False
        objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item(3) = False
        objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item(4) = False
        objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item(5) = ""
        objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item(6) = False
        dgvComida.Columns(3).ReadOnly = False
        dgvComida.Columns(4).ReadOnly = False
        dgvComida.Columns(5).ReadOnly = False
        dgvComida.Columns(7).ReadOnly = False
        dgvComida.Rows(dgvComida.Rows.Count - 1).Cells(3).ReadOnly = True
        dgvComida.Rows(dgvComida.Rows.Count - 1).Cells(4).ReadOnly = True
        dgvComida.Rows(dgvComida.Rows.Count - 1).Cells(5).ReadOnly = True
        dgvComida.Rows(dgvComida.Rows.Count - 1).Cells(7).ReadOnly = True
        dgvComida.Rows(dgvComida.RowCount - 1).Cells(2).Selected = True
    End Sub
    Private Sub agregarPerfil(vPerfil As Integer, Titulo As String)
        Try
            Dim objAsigPerfil As New ConfiguracionPerfilParaclinico
            objAsigPerfil.CodigoTipo = vPerfil
            objAsigPerfil.Titulo = Titulo
            objAsigPerfil.codigoAreaServicio = area
            Dim ConfPPA As New Form_Perfil_Paraclinico_Asignar
            If objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Count > 0 Then
                For I = 0 To objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Count - 1
                    objAsigPerfil.dtParaclinicoC.Rows.Add()
                    objAsigPerfil.dtParaclinicoC.Rows(I).Item(0) = objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(I).Item(0)
                Next
            End If
            ConfPPA.objPP = objAsigPerfil
            ConfPPA.ShowDialog()

            If objAsigPerfil.dtProcedimiento.Rows.Count > 0 Then
                Dim ultimaFila As Integer
                For i = 0 To objAsigPerfil.dtProcedimiento.Rows.Count - 1
                    If objAsigPerfil.dtProcedimiento.Rows(i).Item(2) = True Then
                        ultimaFila = objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Count - 1
                        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(ultimaFila).Item(0) = objAsigPerfil.dtProcedimiento.Rows(i).Item(0)
                        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(ultimaFila).Item(1) = objAsigPerfil.dtProcedimiento.Rows(i).Item(1)
                        If Not IsNothing(objHistoriaClinica.objOrdenMedica.dtParaclinicos.Columns("Estado")) Then
                            objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(ultimaFila).Item("Estado") = Constantes.ITEM_NUEVO
                        End If
                        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Add()
                        llenarParaclinico()
                    End If
                Next
            End If
        Catch ex As Exception
            Label166.Text = "Error 6"
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub llenarParaclinico()
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO_CUPS
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 2).Item("Indicación") = ""
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 2).Item("Justificación") = ""
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 2).Item("Resultado") = Constantes.VALOR_VALIDO
        dgvParaclinico.Columns("dgCantidadPara").ReadOnly = False
        dgvParaclinico.Rows(dgvParaclinico.Rows.Count - 1).Cells("dgCantidadPara").ReadOnly = True
        dgvParaclinico.Rows(dgvParaclinico.Rows.Count - 2).Cells("dgCantidadPara").Selected = True
        abrirFormatoParaclinicos()
    End Sub

    Private Sub llenarInsumosFisio()
        dgvInsumosFisio.DataSource.Rows(dgvInsumosFisio.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO
        dgvInsumosFisio.Columns("dgCantidadInsuFisio").ReadOnly = False
        dgvInsumosFisio.Rows(dgvInsumosFisio.Rows.Count - 2).Cells("dgCantidadInsuFisio").ReadOnly = False
        dgvInsumosFisio.Rows(dgvInsumosFisio.Rows.Count - 1).Cells("dgCantidadInsuFisio").ReadOnly = True
        dgvInsumosFisio.Rows(dgvInsumosFisio.Rows.Count - 2).Cells("dgCantidadInsuFisio").Selected = True
    End Sub
    Private Sub llenarInsumosEnfer()
        dgvInsumosEnfer.DataSource.Rows(dgvInsumosEnfer.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO
        dgvInsumosEnfer.Columns("dgCantidadInsuEnfer").ReadOnly = False
        dgvInsumosEnfer.Rows(dgvInsumosEnfer.Rows.Count - 2).Cells("dgCantidadInsuEnfer").ReadOnly = False
        dgvInsumosEnfer.Rows(dgvInsumosEnfer.Rows.Count - 1).Cells("dgCantidadInsuEnfer").ReadOnly = True
        dgvInsumosEnfer.Rows(dgvInsumosEnfer.Rows.Count - 2).Cells("dgCantidadInsuEnfer").Selected = True
    End Sub
    Private Sub llenarHemoderivado()
        objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.Rows.Count - 2).Item("Indicación") = ""
        objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.Rows.Count - 2).Item("Justificación") = ""
        objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.Rows.Count - 2).Item("Resultado") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.Rows.Count - 2).Item("Formato") = Constantes.VALOR_VALIDO
        dgvHemoderivado.Columns("dgCantidadHemo").ReadOnly = False
        dgvHemoderivado.Rows(dgvHemoderivado.Rows.Count - 1).Cells("dgCantidadHemo").ReadOnly = True
        dgvHemoderivado.Rows(dgvHemoderivado.Rows.Count - 2).Cells("dgCantidadHemo").Selected = True
        abrirSolicitudTS(True)
    End Sub
    Private Sub llenarGlucometria()
        objHistoriaClinica.objOrdenMedica.dtGlucometrias.Rows(dgvGlucometria.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO
        dgvGlucometria.Columns("dgCantidadGlu").ReadOnly = False
        dgvGlucometria.Columns("dgInicioGlu").ReadOnly = False
        dgvGlucometria.Rows(dgvGlucometria.Rows.Count - 1).Cells("dgCantidadGlu").ReadOnly = True
        dgvGlucometria.Rows(dgvGlucometria.Rows.Count - 1).Cells("dgInicioGlu").ReadOnly = True
        dgvGlucometria.Rows(dgvGlucometria.Rows.Count - 2).Cells("dgInicioGlu").Value = Constantes.ITEM_dgv_SELECCIONE
        dgvGlucometria.Rows(dgvGlucometria.Rows.Count - 2).Cells("dgCantidadGlu").Selected = True
        If Not SesionActual.tienePermiso(pEditarHoras) Then
            dgvGlucometria.Columns("dgInicioGlu").ReadOnly = True
        End If
    End Sub
    Private Sub llenarProcedimiento()
        objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO_CUPS
        objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("Indicación") = ""
        objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("Justificación") = ""
        objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("Resultado") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("Formato") = Constantes.VALOR_VALIDO
        If Not objHistoriaClinica.objOrdenMedica.dtProcedimientos.Columns.Contains("grupo") Then
            objHistoriaClinica.objOrdenMedica.dtProcedimientos.Columns.Add("grupo")
        End If

        Dim params As New List(Of String)
        params.Add(objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("Código"))
        Dim fila As DataRow = General.cargarItem(ConsultasHC.ORDEN_MEDICA_CARGA_GRUPO_PROCEDIMIENTO, params)
        If Not IsNothing(fila) Then
            objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 2).Item("grupo") = fila.Item("grupo")
        End If


        dgvProcedimiento.Columns("dgCantidadProce").ReadOnly = False
        dgvProcedimiento.Rows(dgvProcedimiento.Rows.Count - 1).Cells("dgCantidadProce").ReadOnly = True
        dgvProcedimiento.Rows(dgvProcedimiento.Rows.Count - 2).Cells("dgCantidadProce").Selected = True
        If dgvProcedimiento.Columns.Contains("grupo") Then
            dgvProcedimiento.Columns("grupo").Visible = False
        End If


        abrirFormato()
    End Sub
    Private Sub llenarImpregnacion()
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("Dosis") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("Velocidad") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("TotalDisolvente") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("CódigoDisolvente") = Constantes.VALOR_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("DescripciónDisolvente") = Constantes.TEXTO_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("Suspender") = False
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("Dias") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("Cantidad") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.Rows.Count - 2).Item("UnidadDisolvente") = "NP"

        dgvImpregnacion.Columns("dgCantidadImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgDosisImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgVelocidadImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgInicioImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgSuspenderImpre").ReadOnly = False
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgCantidadImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgDosisImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgVelocidadImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgInicioImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 2).Cells("dgInicioImpre").Value = If(modulo = Constantes.CODIGO_MENU_HISTC, Constantes.ITEM_dgv_SELECCIONE, CInt(Format(fechaOrdenMedica.Value, Constantes.FORMATO_HORA_CADENA)))
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgSuspenderImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 2).Cells("dgDosisImpre").Selected = True
        dgvImpregnacionDisplayIndex()
        If Not SesionActual.tienePermiso(pEditarHoras) Then
            dgvImpregnacion.Columns("dgInicioImpre").ReadOnly = True
        End If
        abrirSolicitudNOPOSoJustificacion(Constantes.OM_IMPREGNACION)
    End Sub
    Private Sub llenarInfusion()
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("Dosis") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("Velocidad") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("TotalDosis") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("CódigoDisolvente") = Constantes.VALOR_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("DescripciónDisolvente") = Constantes.TEXTO_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("Suspender") = False
        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.Rows.Count - 2).Item("Dias") = Constantes.VALOR_VALIDO
        dgvInfusion.Columns("dgDosisInfu").ReadOnly = False
        dgvInfusion.Columns("dgVelocidadInfu").ReadOnly = False
        dgvInfusion.Columns("dgInicioInfu").ReadOnly = False
        dgvInfusion.Columns("dgSuspenderInfu").ReadOnly = False
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgDosisInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgVelocidadInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgInicioInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 2).Cells("dgInicioInfu").Value = If(modulo = Constantes.CODIGO_MENU_HISTC, Constantes.ITEM_dgv_SELECCIONE, CInt(Format(fechaOrdenMedica.Value, Constantes.FORMATO_HORA_CADENA)))
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgSuspenderInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 2).Cells("dgDosisInfu").Selected = True
        dgvInfusionDisplayIndex()
        If Not SesionActual.tienePermiso(pEditarHoras) Then
            dgvInfusion.Columns("dgInicioInfu").ReadOnly = True
        End If
        abrirSolicitudNOPOSoJustificacion(Constantes.OM_INFUSION)
    End Sub
    Private Sub llenarMedicamento()
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 2).Item("Dosis") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 2).Item("CódigoVia") = Constantes.VALOR_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 2).Item("DescripciónVia") = Constantes.TEXTO_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 2).Item("Suspender") = False
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 2).Item("Dias") = Constantes.VALOR_VALIDO
        dgvMedicamento.Columns("dgDosisMed").ReadOnly = False
        dgvMedicamento.Columns("dgHorarioMed").ReadOnly = False
        dgvMedicamento.Columns("dgInicioMed").ReadOnly = False
        dgvMedicamento.Columns("dgSuspenderMed").ReadOnly = False
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgDosisMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgHorarioMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 2).Cells("dgHorarioMed").Value = Constantes.ITEM_dgv_SELECCIONE
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgInicioMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 2).Cells("dgInicioMed").Value = If(modulo = Constantes.CODIGO_MENU_HISTC, Constantes.ITEM_dgv_SELECCIONE, CInt(Format(fechaOrdenMedica.Value, Constantes.FORMATO_HORA_CADENA)))
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgSuspenderMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 2).Cells("dgDosisMed").Selected = True
        dgvMedicamentoDisplayIndex()
        If Not SesionActual.tienePermiso(pEditarHoras) Then
            dgvMedicamento.Columns("dgInicioMed").ReadOnly = True
        End If
        abrirSolicitudNOPOSoJustificacion(Constantes.OM_MEDICAMENTO)
    End Sub

    Private Sub llenarMezcla()
        Dim NombreTablaMezcla As String
        NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
        objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(dgvMezcla.Rows.Count - 2).Item("Dosis") = Constantes.VALOR_VALIDO
        dgvMezcla.Columns("dgDosisMezcla").ReadOnly = False
        dgvMezcla.Rows(dgvMezcla.Rows.Count - 1).Cells("dgDosisMezcla").ReadOnly = True
        dgvMezcla.Rows(dgvMezcla.Rows.Count - 2).Cells("dgDosisMezcla").Selected = True
        abrirSolicitudNOPOSoJustificacion(Constantes.OM_MEZCLA)
    End Sub
    Private Sub CPISToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPISToolStripMenuItem.Click
        Form_CPIS.cargarModulo(Tag.modulo)
        General.cargarForm(Form_CPIS)
        Form_CPIS.textregistro.Text = txtRegistro.Text
        Form_CPIS.txtpnombre.Text = txtNombre.Text
        Form_CPIS.cargarDatos()
        Form_CPIS.Focus()

    End Sub

    Private Sub dgvComida_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComida.CellDoubleClick

        General.abrirJustificacion(dgvComida, objHistoriaClinica.objOrdenMedica.dtComidas, PanelJustificacionComida, txtJustificacionComida, "dgJustificacionComida", Not tsordenguardar.Enabled)
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvComida.Rows(dgvComida.CurrentCell.RowIndex).Cells("dgDescripcionComida").Selected = True _
                And objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            If objHistoriaClinica.objOrdenMedica.dtComidas.Rows.Count > 1 Then Exit Sub
            General.busquedaItems(Consultas.BUSQUEDA_COMIDA, Nothing, TitulosForm.BUSQUEDA_COMIDA, dgvComida,
                                  objHistoriaClinica.objOrdenMedica.dtComidas, 0, 1, dgvComida.Columns("dgDescripcionComida").Index,
                                  True,,, True, AddressOf llenarComida)
        ElseIf dgvComida.Rows(dgvComida.CurrentCell.RowIndex).Cells("anularComida").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_COMIDA, modulo, objHistoriaClinica.objOrdenMedica.dtComidas, dgvComida, txtCodigoOrden.Text, nRegistro))
        End If
    End Sub


    Private Sub dgvComida_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvComida.KeyDown
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            If objHistoriaClinica.objOrdenMedica.dtComidas.Rows.Count > 1 Then Exit Sub
            General.busquedaItems(Consultas.BUSQUEDA_COMIDA, Nothing, TitulosForm.BUSQUEDA_COMIDA, dgvComida,
                                  objHistoriaClinica.objOrdenMedica.dtComidas, 0, 1, dgvComida.Columns("dgDescripcionComida").Index,
                                  True,,, True, AddressOf llenarComida)
        End If
    End Sub

    Private Sub dgvComida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvComida.KeyPress
        General.abrirJustificacion(dgvComida, objHistoriaClinica.objOrdenMedica.dtComidas, PanelJustificacionComida, txtJustificacionComida, "dgJustificacionComida", Not tsordenguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub txtJustificacionComida_Leave(sender As Object, e As EventArgs) Handles txtJustificacionComida.Leave
        Try
            If PanelJustificacionComida.Visible = True Then
                PanelJustificacionComida.Visible = False
                dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgJustificacionComida").Value = txtJustificacionComida.Text
                txtJustificacionComida.Clear()
                objHistoriaClinica.objOrdenMedica.dtComidas.AcceptChanges()
            End If
        Catch ex As Exception
            Label166.Text = "Error 7"
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub dgvComida_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComida.CellContentClick
        If dgvComida.DataSource Is Nothing OrElse objHistoriaClinica.objOrdenMedica.opcionCancelar = True OrElse tsordenguardar.Enabled = False OrElse dgvComida.CurrentRow.Index = dgvComida.RowCount - 1 Then
            Exit Sub
        End If
        comidaSeleccionada = False
        If dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgDesayuno").Selected = True OrElse
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgAlmuerzo").Selected = True OrElse
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgCena").Selected = True Then
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgDesayuno").ReadOnly = False
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgAlmuerzo").ReadOnly = False
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgCena").ReadOnly = False
            comidaSeleccionada = True
            dgvComida.EndEdit()
            If objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentRow.Index).Item("Estado") = Constantes.ITEM_CARGADO Then
                objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentRow.Index).Item("Estado") = Constantes.ITEM_MODIFICADO
            End If
            If modulo = Constantes.CODIGO_MENU_HISTC AndAlso Not servicioNeonatal AndAlso dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgCodigoComida").Value <> ConstantesHC.COMIDA_NADA_VIA_ORAL Then
                mensajeError = HistoriaClinicaBLL.verificarSeleccionComida(dgvComida, comidaSeleccionada,
                                                                      dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgDesayuno").Value,
                                                                      dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgAlmuerzo").Value,
                                                                      dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgCena").Value)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    dgvComida.Rows(dgvComida.CurrentRow.Index).Cells(dgvComida.CurrentCell.ColumnIndex).Value = False
                End If

            End If

        End If

    End Sub

    Private Sub dgvOxigeno_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOxigeno.CellDoubleClick
        General.abrirJustificacion(dgvOxigeno, objHistoriaClinica.objOrdenMedica.dtOxigenos, PanelJustificacionOxigeno, txtJustificacionOxigeno, "dgJustificacionOxigeno", Not tsordenguardar.Enabled)
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvOxigeno.Rows(dgvOxigeno.CurrentCell.RowIndex).Cells("dgDescripcionOxigeno").Selected = True _
                And objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows(dgvOxigeno.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            If objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows.Count > 2 Then Exit Sub
            General.busquedaItems(Consultas.BUSQUEDA_OXIGENO, Nothing, TitulosForm.BUSQUEDA_OXIGENO, dgvOxigeno,
                                  objHistoriaClinica.objOrdenMedica.dtOxigenos, 0, 2, dgvOxigeno.Columns("dgDescripcionOxigeno").Index,
                                  True,,, True)
        ElseIf dgvOxigeno.Rows(dgvOxigeno.CurrentCell.RowIndex).Cells("anularOxigeno").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows(dgvOxigeno.CurrentCell.RowIndex).Item("Estado").ToString <> "" And Not String.IsNullOrEmpty(txtCodigoOrden.Text) Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_OXIGENO, modulo, objHistoriaClinica.objOrdenMedica.dtOxigenos, dgvOxigeno, txtCodigoOrden.Text, nRegistro))
        ElseIf dgvOxigeno.Rows(dgvOxigeno.CurrentCell.RowIndex).Cells("anularOxigeno").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows(dgvOxigeno.CurrentCell.RowIndex).Item("Estado").ToString <> "" And String.IsNullOrEmpty(txtCodigoOrden.Text) Then
            dgvOxigeno.DataSource.Rows.RemoveAt(dgvOxigeno.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub dgvOxigeno_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvOxigeno.KeyDown
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows(dgvOxigeno.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            If objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows.Count > 1 Then Exit Sub
            General.busquedaItems(Consultas.BUSQUEDA_OXIGENO, Nothing, TitulosForm.BUSQUEDA_OXIGENO, dgvOxigeno,
                                  objHistoriaClinica.objOrdenMedica.dtOxigenos, 0, 2, dgvOxigeno.Columns("dgDescripcionOxigeno").Index,
                                  True,,, True)
        End If
    End Sub

    Private Sub dgvOxigeno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvOxigeno.KeyPress
        General.abrirJustificacion(dgvOxigeno, objHistoriaClinica.objOrdenMedica.dtOxigenos, PanelJustificacionOxigeno, txtJustificacionOxigeno, "dgJustificacionOxigeno", Not tsordenguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub txtJustificacionOxigeno_Leave(sender As Object, e As EventArgs) Handles txtJustificacionOxigeno.Leave
        Try
            If PanelJustificacionOxigeno.Visible = True Then
                PanelJustificacionOxigeno.Visible = False
                dgvOxigeno.Rows(dgvOxigeno.CurrentRow.Index).Cells("dgJustificacionOxigeno").Value = txtJustificacionOxigeno.Text
                txtJustificacionOxigeno.Clear()
                objHistoriaClinica.objOrdenMedica.dtOxigenos.AcceptChanges()
            End If
        Catch ex As Exception
            Label166.Text = "Error 8"
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvEstancia_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvEstancia.DataError
        e.Cancel = True
    End Sub

    Private Sub InfecciónIntrahospitalariaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfecciónIntrahospitalariaToolStripMenuItem.Click
        General.cargarForm(Form_Infeccion_IH)
        Form_Infeccion_IH.cargarInformacionPaciente(txtRegistro.Text)
        Form_Infeccion_IH.TabControl1.TabPages.RemoveAt(2)
        Form_Infeccion_IH.Focus()

    End Sub

    Private Sub dgvParaclinico_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinico.CellDoubleClick
        General.abrirJustificacion(dgvParaclinico, objHistoriaClinica.objOrdenMedica.dtParaclinicos, PanelJustificacionParaclinico, txtJustificacionParaclinico, "dgIndicacionPara", Not tsordenguardar.Enabled)
        General.abrirJustificacion(dgvParaclinico, objHistoriaClinica.objOrdenMedica.dtParaclinicos, PanelJustificacionParaclinico, txtJustificacionParaclinico, "dgJustificacionPara", Not tsordenguardar.Enabled)
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("dgDescripcionPara").Selected = True _
                And objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_PARACLINICO)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinico,
                                  objHistoriaClinica.objOrdenMedica.dtParaclinicos, 0, 1, dgvParaclinico.Columns("dgDescripcionPara").Index,
                                  False, True, 0,, AddressOf llenarParaclinico)
        ElseIf dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("anularPara").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_PARACLINICO, modulo, objHistoriaClinica.objOrdenMedica.dtParaclinicos, dgvParaclinico, txtCodigoOrden.Text, nRegistro))
        End If
    End Sub
    Private Sub dgvParaclinicoEvo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicoEvo.CellDoubleClick
        General.abrirJustificacion(dgvParaclinicoEvo, objHistoriaClinica.objEvolucionMedica.dtParaclinicos, PanelJustificacionParaclinicoEvo, txtJustificacionParaclinicoEvo, "dgInterpretacionParaEvo", Not tsevoguardar.Enabled)

    End Sub
    Private Sub dgvInsumosFisio_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosFisio.CellDoubleClick
        If tsfisioguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvInsumosFisio.Rows(dgvInsumosFisio.CurrentCell.RowIndex).Cells("dgDescripcionInsuFisio").Selected = True Then
            Dim params As New List(Of String)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasHC.FISIOTERAPIA_INSUMO_BUSQUEDA, params, TitulosForm.BUSQUEDA_INSUMOS, dgvInsumosFisio,
            dgvInsumosFisio.DataSource, 0, 1, dgvInsumosFisio.Columns("dgDescripcionInsuFisio").Index,
                                False, True, 0,, AddressOf llenarInsumosFisio)
        ElseIf dgvInsumosFisio.Rows(dgvInsumosFisio.CurrentCell.RowIndex).Cells("anularInsuFisio").Selected = True AndAlso dgvInsumosFisio.CurrentCell.RowIndex <> dgvInsumosFisio.RowCount - 1 Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvInsumosFisio.DataSource.Rows.RemoveAt(dgvInsumosFisio.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvInsumosEnfer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosEnfer.CellDoubleClick
        If tsenferguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvInsumosEnfer.Rows(dgvInsumosEnfer.CurrentCell.RowIndex).Cells("dgDescripcionInsuEnfer").Selected = True Then
            Dim params As New List(Of String)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasHC.ENFERMERIA_INSUMO_BUSQUEDA, params, TitulosForm.BUSQUEDA_INSUMOS, dgvInsumosEnfer,
            dgvInsumosEnfer.DataSource, 0, 1, dgvInsumosEnfer.Columns("dgDescripcionInsuEnfer").Index,
                                False, True, 0,, AddressOf llenarInsumosEnfer)
        ElseIf dgvInsumosEnfer.Rows(dgvInsumosEnfer.CurrentCell.RowIndex).Cells("anularInsuEnfer").Selected = True AndAlso dgvInsumosEnfer.CurrentCell.RowIndex <> dgvInsumosEnfer.RowCount - 1 Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvInsumosEnfer.DataSource.Rows.RemoveAt(dgvInsumosEnfer.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvInfusion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellDoubleClick
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If dgvInfusion.Rows(dgvInfusion.CurrentCell.RowIndex).Cells("dgDescripcionInfu").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Estado").ToString = "" _
                 AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            params.Add(Nothing)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvInfusion,
                                  objHistoriaClinica.objOrdenMedica.dtInfusiones, 0, 2, dgvInfusion.Columns("dgDescripcionInfu").Index, False,, 0,, AddressOf llenarInfusion)
        ElseIf dgvInfusion.Rows(dgvInfusion.CurrentCell.RowIndex).Cells("dgDisolventeInfu").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
            AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Código"))
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_MEDICAMENTO_DISOLVENTE, params, TitulosForm.BUSQUEDA_MEDICAMENTO, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("CódigoDisolvente") = tbl(0)
                objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("DescripciónDisolvente") = tbl(1)
            End If
        ElseIf dgvInfusion.Rows(dgvInfusion.CurrentCell.RowIndex).Cells("anularInfu").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
                 AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim consultaEliminar As String
            consultaEliminar = HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_MEZCLA_TABLA, modulo, objHistoriaClinica.objOrdenMedica.dsMezcla, dgvInfusion, txtCodigoOrden.Text)
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(consultaEliminar)
            consultaEliminar = HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_INFUSION, modulo, objHistoriaClinica.objOrdenMedica.dtInfusiones, dgvInfusion, txtCodigoOrden.Text)
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(consultaEliminar)

        End If
        calculaDosis()
    End Sub
    Private Sub dgvMedicamento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicamento.CellDoubleClick
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("dgDescripcionMed").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString = "" _
              AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvMedicamento,
                                  objHistoriaClinica.objOrdenMedica.dtMedicamentos, 0, 2, dgvMedicamento.Columns("dgDescripcionMed").Index, True, True, 0,, AddressOf llenarMedicamento)
        ElseIf dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("dgViaMed").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
             AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Código"))
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_VIA, params, TitulosForm.BUSQUEDA_VIA, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("CódigoVia") = tbl(0)
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("DescripciónVia") = tbl(1)
            End If
        ElseIf dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("anularMed").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
             AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim consultaEliminar As String
            consultaEliminar = HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_MEDICAMENTO, modulo, objHistoriaClinica.objOrdenMedica.dtMedicamentos, dgvMedicamento, txtCodigoOrden.Text)
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(consultaEliminar)
        End If

        calculaFrecuencia(objHistoriaClinica.objOrdenMedica.dtMedicamentos)
    End Sub
    Private Sub dgvParaclinico_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvParaclinico.KeyDown
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_PARACLINICO)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinico,
                                  objHistoriaClinica.objOrdenMedica.dtParaclinicos, 0, 1, dgvParaclinico.Columns("dgDescripcionPara").Index,
                                  False, True, 0,, AddressOf llenarParaclinico)
        End If
    End Sub
    Private Sub dgvInsumosFisio_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvInsumosFisio.KeyDown
        If tsfisioguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 Then
            Dim params As New List(Of String)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasHC.FISIOTERAPIA_INSUMO_BUSQUEDA, params, TitulosForm.BUSQUEDA_INSUMOS, dgvInsumosFisio,
                                  dgvInsumosFisio.DataSource, 0, 1, dgvInsumosFisio.Columns("dgDescripcionInsuFisio").Index,
                                  False, True, 0,, AddressOf llenarInsumosFisio)
        End If
    End Sub
    Private Sub dgvInsumosEnfer_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvInsumosEnfer.KeyDown
        If tsenferguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 Then
            Dim params As New List(Of String)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasHC.ENFERMERIA_INSUMO_BUSQUEDA, params, TitulosForm.BUSQUEDA_INSUMOS, dgvInsumosEnfer,
                                  dgvInsumosEnfer.DataSource, 0, 1, dgvInsumosEnfer.Columns("dgDescripcionInsuEnfer").Index,
                                  False, True, 0,, AddressOf llenarInsumosEnfer)
        End If
    End Sub

    Private Sub dgvVerificaEdicion(sender As Object, e As DataGridViewCellEventArgs) Handles _
        dgvComida.CellDoubleClick, dgvParaclinico.CellDoubleClick,
        dgvMedicamento.CellDoubleClick,
        dgvInfusion.CellDoubleClick, dgvProcedimiento.CellEnter, dgvProcedimiento.CellEndEdit,
        dgvProcedimiento.CellDoubleClick, dgvProcedimiento.CellClick, dgvParaclinico.CellEnter, dgvParaclinico.CellEndEdit, dgvParaclinico.CellClick, dgvMezcla.CellEnter, dgvMezcla.CellEndEdit, dgvMezcla.CellDoubleClick, dgvMezcla.CellClick, dgvMedicamento.CellEnter, dgvMedicamento.CellEndEdit, dgvInfusion.CellEnter, dgvInfusion.CellEndEdit, dgvImpregnacion.CellEnter, dgvImpregnacion.CellEndEdit, dgvImpregnacion.CellDoubleClick, dgvHemoderivado.CellEnter, dgvHemoderivado.CellEndEdit, dgvHemoderivado.CellDoubleClick, dgvHemoderivado.CellClick, dgvGlucometria.CellEnter, dgvGlucometria.CellEndEdit, dgvGlucometria.CellDoubleClick, dgvComida.CellEnter, dgvComida.CellEndEdit

        'dgvOxigeno.CellDoubleClick,
        '     dgvOxigeno.CellEnter, dgvOxigeno.CellEndEdit, dgvOxigeno.CellClick,
        HistoriaClinicaBLL.verificaEdicion(sender, False, tsordenguardar.Enabled, primeraVez)

    End Sub

    Private Sub dgvVerResultados(sender As DataGridView, e As DataGridViewCellEventArgs) Handles dgvParaclinico.CellClick
        Dim form As Object
        Dim respuestaExamen As Boolean
        Dim verificarTipo As Integer

        If objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Count > 0 And Not String.IsNullOrEmpty(txtCodigoOrden.Text) Then
            Try
                If e.ColumnIndex = dgvParaclinico.Columns("dgBtResultadoOM").Index Then
                    verificarTipo = Funciones.consultarAplicaParaclinico(objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows _
                                                                         (dgvParaclinico.CurrentCell.RowIndex).Item("CodigoTipoExamen"))

                    If verificarTipo = ConstantesHC.CODIGO_APLICA_LABORATORIO Then
                        form = New FormExamenParaclinicosNuevo
                        form.historiaClinica = Me
                        respuestaExamen = form.cargarPaciente(txtCodigoOrden.Text,
                                              objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Código"),
                                              Tag.modulo, objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Resultado"),
                                                              Constantes.TipoEXAM)
                        If respuestaExamen = False Then
                            form.ShowDialog()
                            Dim dtNuevos As New DataTable
                            HistoriaClinicaBLL.filasNuevas(objHistoriaClinica.objOrdenMedica.dtParaclinicos, dtNuevos)
                            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_PARACLINICO, objHistoriaClinica.objOrdenMedica.paraclinicoCargar, objHistoriaClinica.objOrdenMedica.dtParaclinicos, dgvParaclinico, txtCodigoOrden.Text)

                            For Each row As DataRow In dtNuevos.Rows
                                objHistoriaClinica.objOrdenMedica.dtParaclinicos.ImportRow(row)
                            Next
                            If tsordenguardar.Enabled Then
                                objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Add()
                            End If

                        Else
                            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Else
                        form = New Form_resultado
                        respuestaExamen = form.cargarResultado(txtCodigoOrden.Text,
                                         objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Código"),
                                         objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Descripción"),
                                         Tag.modulo,
                                         If(verificarTipo = ConstantesHC.CODIGO_APLICA_IMAGEN, 1, 0), Constantes.TipoEXAM, txtRegistro.Text)
                        If respuestaExamen = True Then
                            form.MdiParent = FormPrincipal
                            form.Show()
                            form.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                Label166.Text = "Error 9"
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub dgvVerResultadosEvo(sender As DataGridView, e As DataGridViewCellEventArgs) Handles dgvParaclinicoEvo.CellClick
        Dim form As Object
        Dim respuestaExamen As Boolean
        Dim verificarTipo As Integer

        If objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows.Count > 0 And e.RowIndex >= 0 Then
            Try
                If e.ColumnIndex = dgvParaclinicoEvo.Columns("dgResultadosParaEvo").Index Then
                    verificarTipo = Funciones.consultarAplicaParaclinico(objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows _
                                                                         (dgvParaclinicoEvo.CurrentCell.RowIndex).Item("CodigoTipoExamen"))

                    If verificarTipo = ConstantesHC.CODIGO_APLICA_LABORATORIO Then
                        form = New FormExamenParaclinicosNuevo
                        form.historiaClinica = Me
                        respuestaExamen = form.cargarPaciente(objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(dgvParaclinicoEvo.CurrentCell.RowIndex).Item("Codigo_Orden"),
                                              objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(dgvParaclinicoEvo.CurrentCell.RowIndex).Item("Código"),
                                              Tag.modulo, objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(dgvParaclinicoEvo.CurrentCell.RowIndex).Item("Resultado"),
                                                              Constantes.TipoEXAM)
                        If respuestaExamen = False Then
                            form.ShowDialog()
                        Else
                            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Else
                        form = New Form_resultado
                        respuestaExamen = form.cargarResultado(objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(dgvParaclinicoEvo.CurrentCell.RowIndex).Item("Codigo_Orden"),
                                         objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(dgvParaclinicoEvo.CurrentCell.RowIndex).Item("Código"),
                                         objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(dgvParaclinicoEvo.CurrentCell.RowIndex).Item("Descripción"),
                                         Tag.modulo,
                                         If(verificarTipo = ConstantesHC.CODIGO_APLICA_IMAGEN, 1, 0), Constantes.TipoEXAM, txtRegistro.Text)
                        If respuestaExamen = True Then
                            form.MdiParent = FormPrincipal
                            form.Show()
                            form.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                Label166.Text = "Error 10"
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub dgvParaclinico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvParaclinico.KeyPress
        General.abrirJustificacion(dgvParaclinico, objHistoriaClinica.objOrdenMedica.dtParaclinicos, PanelJustificacionParaclinico, txtJustificacionParaclinico, "dgIndicacionPara", Not tsordenguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgvParaclinico, objHistoriaClinica.objOrdenMedica.dtParaclinicos, PanelJustificacionParaclinico, txtJustificacionParaclinico, "dgJustificacionPara", Not tsordenguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub dgvParaclinicoEvo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvParaclinicoEvo.KeyPress
        General.abrirJustificacion(dgvParaclinicoEvo, objHistoriaClinica.objEvolucionMedica.dtParaclinicos, PanelJustificacionParaclinicoEvo, txtJustificacionParaclinicoEvo, "dgInterpretacionParaEvo", Not tsevoguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub CateterCentralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CateterCentralToolStripMenuItem.Click
        Form_CateterCentral.cargarModulo(Tag.modulo)
        General.cargarForm(Form_CateterCentral)
        Form_CateterCentral.cargarPaciente(txtRegistro.Text, txtNombre.Text)
        Form_CateterCentral.Focus()
    End Sub

    Private Sub CuracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuracionesToolStripMenuItem.Click
        Form_Curaciones.cargarModulo(Tag.modulo)
        General.cargarForm(Form_Curaciones)
        Form_Curaciones.cargarPaciente(txtRegistro.Text, txtNombre.Text, txtNombreContrato.Text, txtAdmision.Text)
    End Sub

    Private Sub dgvHemoderivado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHemoderivado.CellDoubleClick
        General.abrirJustificacion(dgvHemoderivado, objHistoriaClinica.objOrdenMedica.dtHemoderivados, PanelJustificacionHemoderivado, txtJustificacionHemoderivado, "dgIndicacionHemo", Not tsordenguardar.Enabled)
        General.abrirJustificacion(dgvHemoderivado, objHistoriaClinica.objOrdenMedica.dtHemoderivados, PanelJustificacionHemoderivado, txtJustificacionHemoderivado, "dgJustificacionHemo", Not tsordenguardar.Enabled)
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvHemoderivado.Rows(dgvHemoderivado.CurrentCell.RowIndex).Cells("dgDescripcionHemo").Selected = True _
                And objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_HEMODERIVADO & "," & Constantes.GRUPO_TRANSFUSION)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_HEMODERIVADO, dgvHemoderivado,
                                  objHistoriaClinica.objOrdenMedica.dtHemoderivados, 0, 1, dgvHemoderivado.Columns("dgDescripcionHemo").Index,
                                  False, True, 0,, AddressOf llenarHemoderivado)
        ElseIf dgvHemoderivado.Rows(dgvHemoderivado.CurrentCell.RowIndex).Cells("anularHemo").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_HEMODERIVADO, modulo, objHistoriaClinica.objOrdenMedica.dtHemoderivados, dgvHemoderivado, txtCodigoOrden.Text, nRegistro))
        End If
    End Sub
    Private Sub dgvProcedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProcedimiento.CellDoubleClick
        General.abrirJustificacion(dgvProcedimiento, objHistoriaClinica.objOrdenMedica.dtProcedimientos, PanelJustificacionProcedimiento, txtJustificacionProcedimiento, "dgIndicacionProce", Not tsordenguardar.Enabled)
        General.abrirJustificacion(dgvProcedimiento, objHistoriaClinica.objOrdenMedica.dtProcedimientos, PanelJustificacionProcedimiento, txtJustificacionProcedimiento, "dgJustificacionProce", Not tsordenguardar.Enabled)
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dgDescripcionProce").Selected = True _
                And objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_HEMODINAMICO & "," & Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgvProcedimiento,
                                  objHistoriaClinica.objOrdenMedica.dtProcedimientos, 0, 1, dgvProcedimiento.Columns("dgDescripcionProce").Index,
                                  False, True, 0,, AddressOf llenarProcedimiento)
        ElseIf dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("anularProce").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_PROCEDIMIENTO, modulo, objHistoriaClinica.objOrdenMedica.dtProcedimientos, dgvProcedimiento, txtCodigoOrden.Text, nRegistro))
        End If
    End Sub

    Private Sub dgvHemoderivado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvHemoderivado.KeyDown
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_HEMODERIVADO & "," & Constantes.GRUPO_TRANSFUSION)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_HEMODERIVADO, dgvHemoderivado,
                                  objHistoriaClinica.objOrdenMedica.dtHemoderivados, 0, 1, dgvHemoderivado.Columns("dgDescripcionHemo").Index,
                                  False, True, 0,, AddressOf llenarHemoderivado)
        End If
    End Sub

    Private Sub dgvHemoderivado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvHemoderivado.KeyPress
        General.abrirJustificacion(dgvHemoderivado, objHistoriaClinica.objOrdenMedica.dtHemoderivados, PanelJustificacionHemoderivado, txtJustificacionHemoderivado, "dgIndicacionHemo", Not tsordenguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgvHemoderivado, objHistoriaClinica.objOrdenMedica.dtHemoderivados, PanelJustificacionHemoderivado, txtJustificacionHemoderivado, "dgJustificacionHemo", Not tsordenguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub dgvProcedimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvProcedimiento.KeyPress
        General.abrirJustificacion(dgvProcedimiento, objHistoriaClinica.objOrdenMedica.dtProcedimientos, PanelJustificacionProcedimiento, txtJustificacionProcedimiento, "dgIndicacionProce", Not tsordenguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgvProcedimiento, objHistoriaClinica.objOrdenMedica.dtProcedimientos, PanelJustificacionProcedimiento, txtJustificacionProcedimiento, "dgJustificacionProce", Not tsordenguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub txtJustificacionHemoderivado_Leave(sender As Object, e As EventArgs) Handles txtJustificacionHemoderivado.Leave
        Try
            If PanelJustificacionHemoderivado.Visible = True Then
                PanelJustificacionHemoderivado.Visible = False
                If dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgJustificacionHemo").Selected = True Then
                    dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgJustificacionHemo").Value = txtJustificacionHemoderivado.Text
                Else
                    dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgIndicacionHemo").Value = txtJustificacionHemoderivado.Text
                End If
                txtJustificacionHemoderivado.Clear()
                dgvHemoderivado.EndEdit()
            End If
        Catch ex As Exception
            Label166.Text = "Error 11"
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub txtJustificacionProcedimiento_Leave(sender As Object, e As EventArgs) Handles txtJustificacionProcedimiento.Leave
        Try
            If PanelJustificacionProcedimiento.Visible = True Then
                PanelJustificacionProcedimiento.Visible = False
                If dgvProcedimiento.Rows(dgvProcedimiento.CurrentRow.Index).Cells("dgJustificacionProce").Selected = True Then
                    dgvProcedimiento.Rows(dgvProcedimiento.CurrentRow.Index).Cells("dgJustificacionProce").Value = txtJustificacionProcedimiento.Text
                Else
                    dgvProcedimiento.Rows(dgvProcedimiento.CurrentRow.Index).Cells("dgIndicacionProce").Value = txtJustificacionProcedimiento.Text
                End If
                txtJustificacionProcedimiento.Clear()
                dgvProcedimiento.EndEdit()
            End If
        Catch ex As Exception
            Label166.Text = "Error 12"
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btEstanciaProlongada_Click(sender As Object, e As EventArgs) Handles btEstanciaProlongada.Click

        'Dim dt As New DataTable
        'Dim lista As New List(Of String)
        'lista.Add(txtRegistro.Text)
        'General.llenarTabla(Consultas.ESTANCIA_PRO_CODIGOEVO_CARGAR, lista, dt)
        'If dt.Rows.Count > 0 Then
        '    objHistoriaClinica.objEstancia.codigoevo = dt.Rows(0).Item("Codigo_Evo").ToString
        'Else
        '    objHistoriaClinica.objEstancia.codigoevo = Constantes.VALOR_PREDETERMINADO
        '    If objHistoriaClinica.objInfoIngreso.diasEstancia > 0 Then
        '        Dim param As New List(Of String)
        '        param.Add(txtRegistro.Text)

        '        Dim dt2 As New DataTable
        '        General.llenarTabla(Consultas.ESTANCIA_PROLONGADA_ULTIMAEVO, param, dt2)
        '        If dt2.Rows.Count > 0 Then
        '            objHistoriaClinica.objEstancia.codigoevo = dt2.Rows(0).Item("Codigo_Evo").ToString
        '        End If

        '        If objHistoriaClinica.objEstancia.codigoevo = Constantes.VALOR_PREDETERMINADO Then
        '            MsgBox("este paciente aun no tiene evolución para el dia 12 de estancia", MsgBoxStyle.Exclamation)
        '            Exit Sub
        '        End If
        '    Else
        '        MsgBox("este paciente aun no tiene formato de estancia prolongada", MsgBoxStyle.Exclamation)
        '        Exit Sub
        '    End If
        'End If

        'Dim formEstancia As New Form_Estancia_Prolongada
        'General.cargarForm(formEstancia)
        'formEstancia.preCargarDatosEstancia(objHistoriaClinica)
        'formEstancia.cargarDatos()
        'formEstancia.cargarPaciente(Me)
        'formEstancia.Focus()
    End Sub

    Private Sub dgvGlucometria_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvGlucometria.KeyDown
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtGlucometrias.Rows(dgvGlucometria.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_GLUCOMETRIA)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_GLUCOMETRIA, dgvGlucometria,
                                  objHistoriaClinica.objOrdenMedica.dtGlucometrias, 0, 1, dgvGlucometria.Columns("dgDescripcionGlu").Index,
                                  True, True, 0, True, AddressOf llenarGlucometria)
        End If
    End Sub


    Private Sub dgvGlucometria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlucometria.CellDoubleClick

        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If dgvGlucometria.Rows(dgvGlucometria.CurrentCell.RowIndex).Cells("dgDescripcionGlu").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtGlucometrias.Rows(dgvGlucometria.CurrentCell.RowIndex).Item("Estado").ToString = "" _
             AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_GLUCOMETRIA)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_GLUCOMETRIA, dgvGlucometria,
                                  objHistoriaClinica.objOrdenMedica.dtGlucometrias, 0, 1, dgvGlucometria.Columns("dgDescripcionGlu").Index,
                                  True, True, 0, True, AddressOf llenarGlucometria)
        ElseIf dgvGlucometria.Rows(dgvGlucometria.CurrentCell.RowIndex).Cells("anularGlu").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtGlucometrias.Rows(dgvGlucometria.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
            AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_GLUCOMETRIA, modulo, objHistoriaClinica.objOrdenMedica.dtGlucometrias, dgvGlucometria, txtCodigoOrden.Text, nRegistro))
        End If
    End Sub

    Private Sub ValoraciónNutricionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValoraciónNutricionalToolStripMenuItem.Click
        Form_ValoracionNutricional.cargarModulo(Tag.modulo)
        General.cargarForm(Form_ValoracionNutricional)
        Form_ValoracionNutricional.cargarPaciente(txtRegistro.Text, txtNombre.Text, txtAdmision.Text, txtNombreContrato.Text)
    End Sub

    Private Sub txtJustificacionParaclinico_Leave(sender As Object, e As EventArgs) Handles txtJustificacionParaclinico.Leave
        Try
            If PanelJustificacionParaclinico.Visible = True Then
                PanelJustificacionParaclinico.Visible = False
                If dgvParaclinico.Rows(dgvParaclinico.CurrentRow.Index).Cells("dgJustificacionPara").Selected = True Then
                    dgvParaclinico.Rows(dgvParaclinico.CurrentRow.Index).Cells("dgJustificacionPara").Value = txtJustificacionParaclinico.Text
                Else
                    dgvParaclinico.Rows(dgvParaclinico.CurrentRow.Index).Cells("dgIndicacionPara").Value = txtJustificacionParaclinico.Text
                End If
                txtJustificacionParaclinico.Clear()
                dgvParaclinico.EndEdit()
            End If
        Catch ex As Exception
            Label166.Text = "Error 14"
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub txtJustificacionParaclinicoEvo_Leave(sender As Object, e As EventArgs) Handles txtJustificacionParaclinicoEvo.Leave
        Try
            If PanelJustificacionParaclinicoEvo.Visible = True Then
                PanelJustificacionParaclinicoEvo.Visible = False
                dgvParaclinicoEvo.Rows(dgvParaclinicoEvo.CurrentRow.Index).Cells("dgInterpretacionParaEvo").Value = txtJustificacionParaclinicoEvo.Text
                txtJustificacionParaclinicoEvo.Clear()
                dgvParaclinicoEvo.EndEdit()
            End If
        Catch ex As Exception
            Label166.Text = "Error 15"
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvParaclinico_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvProcedimiento.EditingControlShowing, dgvParaclinico.EditingControlShowing, dgvInsumosFisio.EditingControlShowing, dgvInsumosEnfer.EditingControlShowing, dgvHemoderivado.EditingControlShowing, dgvGlucometria.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvInfusion_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMezcla.EditingControlShowing, dgvMedicamento.EditingControlShowing, dgvInfusion.EditingControlShowing, dgvImpregnacion.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos

    End Sub

    Private Sub dgvImpregnacion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvImpregnacion.KeyDown
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 AndAlso dgvImpregnacion.Rows(dgvImpregnacion.CurrentCell.RowIndex).Cells("dgDescripcionImpre").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvImpregnacion,
                                  objHistoriaClinica.objOrdenMedica.dtImpregnaciones, 0, 2, dgvImpregnacion.Columns("dgDescripcionImpre").Index, False, True, 0,, AddressOf llenarImpregnacion)
        ElseIf e.KeyCode = Keys.F3 AndAlso dgvImpregnacion.Rows(dgvImpregnacion.CurrentCell.RowIndex).Cells("dgDisolventeImpre").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Código"))
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_MEDICAMENTO_DISOLVENTE, params, TitulosForm.BUSQUEDA_MEDICAMENTO, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("CódigoDisolvente") = tbl(0)
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("DescripciónDisolvente") = tbl(1)
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("UnidadDisolvente") = tbl(2)
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("ConcentracionDisolvente") = tbl(3)

            End If
        ElseIf e.KeyCode = Keys.Delete AndAlso dgvImpregnacion.Rows(dgvImpregnacion.CurrentCell.RowIndex).Cells("dgDisolventeImpre").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If MsgBox(Mensajes.QUITAR_DISOLVENTE, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("CódigoDisolvente") = Constantes.VALOR_NO_APLICA
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("DescripciónDisolvente") = Constantes.TEXTO_NO_APLICA
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("UnidadDisolvente") = Constantes.VALOR_NO_APLICA
                Dim consultaEliminar As String
                consultaEliminar = HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_MEZCLA_TABLA, modulo, objHistoriaClinica.objOrdenMedica.dsMezcla, dgvImpregnacion, txtCodigoOrden.Text)
                objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(consultaEliminar)
            End If

        End If
        calculaDisolvente()
    End Sub
    Private Sub dgvInfusion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvInfusion.KeyDown
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 AndAlso dgvInfusion.Rows(dgvInfusion.CurrentCell.RowIndex).Cells("dgDescripcionInfu").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            params.Add(Nothing)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvInfusion,
                                  objHistoriaClinica.objOrdenMedica.dtInfusiones, 0, 2, dgvInfusion.Columns("dgDescripcionInfu").Index, False,, 0,, AddressOf llenarInfusion)
        ElseIf e.KeyCode = Keys.F3 AndAlso dgvInfusion.Rows(dgvInfusion.CurrentCell.RowIndex).Cells("dgDisolventeInfu").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Código"))
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_MEDICAMENTO_DISOLVENTE, params, TitulosForm.BUSQUEDA_MEDICAMENTO, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("CódigoDisolvente") = tbl(0)
                objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("DescripciónDisolvente") = tbl(1)
            End If
        ElseIf e.KeyCode = Keys.Delete AndAlso dgvInfusion.Rows(dgvInfusion.CurrentCell.RowIndex).Cells("dgDisolventeInfu").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If MsgBox(Mensajes.QUITAR_DISOLVENTE, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("CódigoDisolvente") = Constantes.VALOR_NO_APLICA
                objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("DescripciónDisolvente") = Constantes.TEXTO_NO_APLICA
                dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Value = My.Resources._new
                dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Style.BackColor = Color.White
                Dim consultaEliminar As String
                consultaEliminar = HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_MEZCLA_TABLA, modulo, objHistoriaClinica.objOrdenMedica.dsMezcla, dgvInfusion, txtCodigoOrden.Text)
                objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(consultaEliminar)
            End If

        End If
        calculaDosis()
    End Sub
    Private Sub dgvMEDICAMENTO_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvMedicamento.KeyDown
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 AndAlso dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("dgDescripcionMed").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvMedicamento,
                                  objHistoriaClinica.objOrdenMedica.dtMedicamentos, 0, 2, dgvMedicamento.Columns("dgDescripcionMed").Index, True, True, 0,, AddressOf llenarMedicamento)
        ElseIf e.KeyCode = Keys.F3 AndAlso dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("dgViaMed").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Código"))
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_VIA, params, TitulosForm.BUSQUEDA_VIA, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("CódigoVia") = tbl(0)
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("DescripciónVia") = tbl(1)
            End If
        ElseIf e.KeyCode = Keys.Delete AndAlso dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("dgViaMed").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("CódigoVia") = Constantes.VALOR_NO_APLICA
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("DescripciónVia") = Constantes.TEXTO_NO_APLICA

        End If
        calculaFrecuencia(objHistoriaClinica.objOrdenMedica.dtMedicamentos)
    End Sub

    Private Sub dgvInfusion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellContentClick

        If dgvInfusion.CurrentRow.Index >= 0 AndAlso e.ColumnIndex = dgvInfusion.Columns("dgMezclaInfu").Index AndAlso (dgvInfusion.CurrentRow.Index <> dgvInfusion.RowCount - 1 Or tsordenguardar.Enabled = False) Then
            gbEstancia.Enabled = False
            gbDietas.Enabled = False
            gbGlucometrias.Enabled = False
            gbHemoderivados.Enabled = False
            gbImpregnacion.Enabled = False
            gbIndicaciones.Enabled = False
            dgvInfusion.Enabled = False
            gbMedicamentos.Enabled = False
            gbNutricion.Enabled = False
            gbOxigeno.Enabled = False
            gbParaclinicos.Enabled = False
            gbProcedimientos.Enabled = False
            panelMezcla.Visible = True

            HistoriaClinicaBLL.asignarTabla(dgvInfusion, dgvMezcla, objHistoriaClinica.objOrdenMedica.dsMezcla)
            btAceptarMezcla.Enabled = True
            If dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgCodigoDisolventeInfu").Value = 0 Then
                tituloMezcla.Text = "Mezcla de " & dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgDescripcionInfu").Value & " con:"
            Else
                tituloMezcla.Text = "Mezcla de " & dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgDescripcionInfu").Value & " y " & dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgDisolventeInfu").Value & " con:"
            End If
            panelMezcla.Focus()
        End If
    End Sub
    Private Sub dgvHemoderivado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHemoderivado.CellContentClick
        If SesionActual.tienePermiso(pIngresarArchivoH) Then
            If dgvHemoderivado.CurrentRow.Index >= 0 AndAlso e.ColumnIndex = dgvHemoderivado.Columns("dgFormatoHemo").Index AndAlso (dgvHemoderivado.CurrentRow.Index <> dgvHemoderivado.RowCount - 1 Or tsordenguardar.Enabled = False) Then
                If IsNothing(dgvHemoderivado.Rows(e.RowIndex).Cells("dgFormatoHemo").Tag) Then
                    abrirSolicitudTS()
                Else
                    dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgFormatoHemo").Tag.ShowDialog()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub abrirFormatoParaclinicos()
        Dim dt As New DataTable
        Dim param As New List(Of String)
        Dim nombreParaclinico, codigoCUPS As String
        codigoCUPS = objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentRow.Index).Item("Código").ToString
        nombreParaclinico = objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentRow.Index).Item("Descripción").ToString
        param.Add(codigoCUPS)
        param.Add(area)
        General.llenarTabla(Consultas.PLANTILLA_INFO_VERIFICAR, param, dt)
        If dt.Rows.Count > 0 And modulo <> Constantes.HC And codigoCUPS <> "895101" Then
            If MsgBox(nombreParaclinico & vbNewLine & Mensajes.FORMATO_OBLIGATORIO_PLANTILLA & vbNewLine, MsgBoxStyle.YesNo + MsgBoxStyle.Question, TitulosForm.TITULO_INFORME_PLANTILLA) = MsgBoxResult.Yes Then
                Dim solicitudPlantilla As New FormPlantillaInforme
                solicitudPlantilla.CargarPlantilla(Me)
                solicitudPlantilla.ShowDialog()
            End If
        End If
    End Sub

    Private Sub abrirFormato()
        Dim dt As New DataTable
        Dim param As New List(Of String)
        Dim nombreProcedimiento, codigoCUPS As String
        codigoCUPS = objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentRow.Index).Item("Código").ToString
        nombreProcedimiento = objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentRow.Index).Item("Descripción").ToString
        param.Add(codigoCUPS)
        General.llenarTabla(Consultas.VERIFICA_INFORME_QX, param, dt)
        If dt.Rows.Count > 0 Then
            If MsgBox(nombreProcedimiento & vbNewLine & Mensajes.FORMATO_OBLIGATORIO & vbNewLine, MsgBoxStyle.YesNo + MsgBoxStyle.Question, TitulosForm.TITULO_INFORME_QUIRURGICO) = MsgBoxResult.Yes Then
                Dim solicitudInformeQX As New FormInformeQX
                solicitudInformeQX.cargarDatosParaSolicitud(Me, descripcionArea, objHistoriaClinica.objOrdenMedica.usuarioReal)
            Else
                eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtProcedimientos, dgvProcedimiento.CurrentRow.Index)
            End If
        Else
            dt.Reset()
            General.llenarTabla(Consultas.VERIFICA_INFORME_HEMODIALISIS, param, dt)
            If dt.Rows.Count > 0 Then
                If MsgBox(nombreProcedimiento & vbNewLine & Mensajes.FORMATO_OBLIGATORIO & vbNewLine, MsgBoxStyle.YesNo + MsgBoxStyle.Question, TitulosForm.TITULO_JUSTIFICACION_ANT) = MsgBoxResult.Yes Then
                    Dim solicitudHemodialisis As New Form_hemodialisis
                    solicitudHemodialisis.cargarDatosParaSolicitud(Me, descripcionArea, objHistoriaClinica.objOrdenMedica.usuarioReal)
                Else
                    eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtProcedimientos, dgvProcedimiento.CurrentRow.Index)
                End If
            Else

                For I = 0 To dgvProcedimiento.RowCount - 2
                    If Not IsNothing(dgvProcedimiento.Rows(I).Cells("dgCodigoProce").Tag) Then
                        If dgvProcedimiento.Rows(I).Cells("dgCodigoProce").Tag.name = FormRemisionAnexo.Name Then
                            Exit Sub
                        End If
                    End If
                Next
                dt.Reset()
                param.Clear()
                param.Add(nRegistro)
                param.Add(Format(fechaOrdenMedica.Value, Constantes.FORMATO_FECHA_ACTUAL))
                General.llenarTabla(objHistoriaClinica.objRemision.consultaSolicitudVerificar, param, dt)
                If dt.Rows.Count > 0 Then
                    Exit Sub
                End If
                dt.Reset()
                param.Clear()
                param.Add(codigoCUPS)
                General.llenarTabla(Consultas.VERIFICA_INFORME_CATETERISMO, param, dt)
                If dt.Rows.Count > 0 AndAlso IsNothing(cuerpo.Parent) Then
                    If MsgBox(nombreProcedimiento & vbNewLine & Mensajes.FORMATO_OBLIGATORIO & vbNewLine, MsgBoxStyle.YesNo + MsgBoxStyle.Question, TitulosForm.TITULO_CATETERISMO) = MsgBoxResult.Yes Then
                        Dim remision As New FormRemisionAnexo
                        remision.cargarDatosParaSolicitud(Me, codEps, descripcionArea, objHistoriaClinica.objOrdenMedica.usuarioReal, objHistoriaClinica)
                    Else
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtProcedimientos, dgvProcedimiento.CurrentRow.Index)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub abrirSolicitudNOPOSoJustificacion(tipo As Integer)
        Dim dt As New DataTable
        Dim param As New List(Of String)
        Dim nombreEquivalencia As String = ""
        Dim codigoEquivalencia As Integer = Constantes.VALOR_PREDETERMINADO
        Select Case tipo
            Case Constantes.OM_MEDICAMENTO
                codigoEquivalencia = objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentRow.Index).Item("Código").ToString
                param.Add(codigoEquivalencia)
                nombreEquivalencia = objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.CurrentRow.Index).Item("Descripción").ToString
            Case Constantes.OM_IMPREGNACION
                codigoEquivalencia = objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentRow.Index).Item("Código").ToString
                param.Add(codigoEquivalencia)
                nombreEquivalencia = objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentRow.Index).Item("Descripción").ToString
            Case Constantes.OM_INFUSION
                codigoEquivalencia = objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentRow.Index).Item("Código").ToString
                param.Add(codigoEquivalencia)
                nombreEquivalencia = objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentRow.Index).Item("Descripción").ToString
            Case Constantes.OM_MEZCLA
                Dim NombreTablaMezcla As String
                NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                codigoEquivalencia = objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(dgvMezcla.CurrentRow.Index).Item("Código").ToString
                param.Add(codigoEquivalencia)
                nombreEquivalencia = objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(dgvMezcla.CurrentRow.Index).Item("Descripción").ToString
        End Select
        objHistoriaClinica.objOrdenMedica.fechaOrden = fechaOrdenMedica.Value
        param.Add(nRegistro)
        param.Add(Format(objHistoriaClinica.objOrdenMedica.fechaOrden, Constantes.FORMATO_FECHA_GEN))
        param.Add(modulo)
        General.llenarTabla(Consultas.VERIFICA_EQUIVALENCIA_NO_POS, param, dt)
        If dt.Rows.Count > 0 Then
            If General.getEstadoVF(objHistoriaClinica.objEvolucionMedica.consultaVerificar & nRegistro) = False Then
                MsgBox(Mensajes.NO_POS_NO_EVOLUCIONES, MsgBoxStyle.Exclamation)
                Select Case tipo
                    Case Constantes.OM_MEDICAMENTO
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtMedicamentos, dgvMedicamento.CurrentRow.Index)
                    Case Constantes.OM_IMPREGNACION
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtImpregnaciones, dgvImpregnacion.CurrentRow.Index)
                    Case Constantes.OM_INFUSION
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtInfusiones, dgvInfusion.CurrentRow.Index)
                    Case Constantes.OM_MEZCLA
                        Dim NombreTablaMezcla As String
                        NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla), dgvMezcla.CurrentRow.Index)
                End Select
                Exit Sub
            End If
            Dim msgResult As MsgBoxResult
            msgResult = MsgBox(nombreEquivalencia & vbNewLine & Mensajes.SOLICITUD_NO_POS & vbNewLine, MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, TitulosForm.TITULO_SOL_MED_NO_POS)
            If msgResult = MsgBoxResult.Yes Then
                Dim solicitudNOPOS As New Form_Medicamentos_NoPos
                solicitudNOPOS.cargarDatosParaSolicitud(objHistoriaClinica.objOrdenMedica.usuarioReal, codigoEquivalencia, nombreEquivalencia, tipo, Me)
            ElseIf msgResult = MsgBoxResult.Cancel Then
                suspenderMed(tipo)
            Else
                Select Case tipo
                    Case Constantes.OM_MEDICAMENTO
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtMedicamentos, dgvMedicamento.CurrentRow.Index)
                    Case Constantes.OM_IMPREGNACION
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtImpregnaciones, dgvImpregnacion.CurrentRow.Index)
                    Case Constantes.OM_INFUSION
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtInfusiones, dgvInfusion.CurrentRow.Index)
                    Case Constantes.OM_MEZCLA
                        Dim NombreTablaMezcla As String
                        NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla), dgvMezcla.CurrentRow.Index)
                End Select
            End If

        End If
        dt.Reset()
        General.llenarTabla(Consultas.VERIFICA_EQUIVALENCIA_ESPECIAL, param, dt)
        If dt.Rows.Count > 0 Then

            Dim msgResult As MsgBoxResult
            msgResult = MsgBox(nombreEquivalencia & vbNewLine & Mensajes.JUSTIFICACION_ANTIBIOTICO & vbNewLine, MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, TitulosForm.TITULO_JUSTIFICACION_ANT)
            If msgResult = MsgBoxResult.Yes Then
                Dim justificacionAntibiotico As New Form_justificacion_antibiotico
                justificacionAntibiotico.cargarDatos(Me, codigoEquivalencia, nombreEquivalencia, tipo)
            ElseIf msgResult = MsgBoxResult.Cancel Then
                suspenderMed(tipo)
            Else
                Select Case tipo
                    Case Constantes.OM_MEDICAMENTO
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtMedicamentos, dgvMedicamento.CurrentRow.Index)
                    Case Constantes.OM_IMPREGNACION
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtImpregnaciones, dgvImpregnacion.CurrentRow.Index)
                    Case Constantes.OM_INFUSION
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtInfusiones, dgvInfusion.CurrentRow.Index)
                    Case Constantes.OM_MEZCLA
                        Dim NombreTablaMezcla As String
                        NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla), dgvMezcla.CurrentRow.Index)
                End Select
            End If
        End If

    End Sub

    Private Sub suspenderMed(tipo As Integer)
        Select Case tipo
            Case Constantes.OM_MEDICAMENTO
                dgvMedicamento.Rows(dgvMedicamento.CurrentRow.Index).Cells("dgSuspenderMed").Value = True
            Case Constantes.OM_IMPREGNACION
                dgvImpregnacion.Rows(dgvImpregnacion.CurrentRow.Index).Cells("dgSuspenderImpre").Value = True
            Case Constantes.OM_INFUSION
                dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgSuspenderInfu").Value = True
            Case Constantes.OM_MEZCLA
                Dim NombreTablaMezcla As String
                NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla), dgvMezcla.CurrentRow.Index)
        End Select
    End Sub
    Private Sub abrirSolicitudTS(Optional trabajarOrden As Boolean = False)
        Dim dt As New DataTable
        Dim param As New List(Of String)
        param.Add(dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgCodigoHemo").Value)
        General.llenarTabla(Consultas.VERIFICA_GRUPO_HEMODERIVADO, param, dt)
        If dt.Rows.Count > 0 Then
            Dim transfusion As New Form_TransfusionSanguinea
            transfusion.datosPrincipales(Me, nRegistro)
            If objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows(dgvHemoderivado.CurrentRow.Index).Item("Formato").ToString = 1 Then

                transfusion.instanciaModulo(modulo, dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgCodigoHemo").Value,
                                            dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgCantidadHemo").Value,
                                            dt.Rows(0).Item(0))
                transfusion.cargarDatosPaciente(txtCodigoOrden.Text, txtHC.Text, txtNombre.Text, txtEdad.Text)
                transfusion.txtsolicita.Focus()
                transfusion.ShowDialog()

                Exit Sub
            End If
            If Not trabajarOrden Then Exit Sub
            Dim cantidadHemo As String
            Do

                cantidadHemo = InputBox(dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgDescripcionHemo").Value & vbNewLine & "Este procedimiento hace necesario la realización de la solicitud. " & vbNewLine & "Digite la cantidad a realizar:", "Solicitud de transfuciones")

                If IsNumeric(cantidadHemo) AndAlso cantidadHemo > 0 AndAlso cantidadHemo <= 100 Then
                    dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgCantidadHemo").Value = cantidadHemo
                    transfusion.instanciaModulo(modulo, dgvHemoderivado.Rows(dgvHemoderivado.CurrentRow.Index).Cells("dgCodigoHemo").Value,
                                            cantidadHemo,
                                            dt.Rows(0).Item(0))
                    transfusion.cargarDatosPaciente(txtCodigoOrden.Text, txtHC.Text, txtNombre.Text, txtEdad.Text)
                    transfusion.ShowDialog()
                    transfusion.txtsolicita.Focus()
                    cantidadHemo = ""
                Else
                    If IsNumeric(cantidadHemo) AndAlso cantidadHemo > 100 Then
                        MsgBox("No puede digitar una cantidad mayor a 100", MsgBoxStyle.Exclamation)
                        cantidadHemo = 0
                    ElseIf MsgBox(Mensajes.CANTIDAD_VALIDA & vbNewLine & " Si continua no se enviará este hemoderivado ¿Desea continuar?  ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        cantidadHemo = 0
                    Else
                        eliminaFilaDt(objHistoriaClinica.objOrdenMedica.dtHemoderivados, dgvHemoderivado.CurrentRow.Index)
                        cantidadHemo = ""
                    End If
                End If
            Loop While (IsNumeric(cantidadHemo))
        End If
    End Sub
    Public Sub eliminaFilaDt(ByRef dt As DataTable, fila As Integer)
        dt.Rows.RemoveAt(fila)
    End Sub


    Private Sub dgvMezcla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMezcla.CellDoubleClick
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        Dim NombreTablaMezcla As String
        NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)

        If dgvMezcla.Rows(dgvMezcla.CurrentCell.RowIndex).Cells("dgDescripcionMezcla").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(dgvMezcla.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvMezcla,
                                  dgvMezcla.DataSource, 0, 2, dgvMezcla.Columns("dgDescripcionMezcla").Index, True, True, 0,, AddressOf llenarMezcla)
        ElseIf dgvMezcla.Rows(dgvMezcla.CurrentCell.RowIndex).Cells("anularMezcla").Selected = True _
            And objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(dgvMezcla.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_MEZCLA, modulo, objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla), dgvMezcla, txtCodigoOrden.Text, objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows(dgvInfusion.CurrentCell.RowIndex).Item("Consecutivo").ToString))
        End If
    End Sub

    Private Sub dgvMezcla_Leave(sender As Object, e As EventArgs) Handles dgvMezcla.Leave
        Try
            If primeraVez = False Or btAceptarMezcla.Focused = True Then
                primeraVez = True
                Exit Sub
            End If
            If panelMezcla.Visible = True Then
                mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvMezcla)
                If mensajeError <> "" And objHistoriaClinica.objOrdenMedica.opcionCancelar = False Then
                    primeraVez = False
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                habilitarGbOrdenMedica()
                panelMezcla.Visible = False
                dgvMezcla.EndEdit()
                If dgvMezcla.RowCount > 1 Then
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Value = My.Resources.OK
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Style.BackColor = Color.LightGreen
                Else
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Value = My.Resources._new
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Style.BackColor = Color.White
                End If
                Dim NombreTablaMezcla As String
                NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows.RemoveAt(dgvMezcla.RowCount - 1)
            End If
        Catch ex As Exception
            Label166.Text = "Error 16"
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub tsHojaIngreso_Click(sender As Object, e As EventArgs) Handles tsHojaIngreso.Click
        Cursor = Cursors.WaitCursor
        tsHojaIngreso.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_HOJA
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtRegistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_HOJA, txtRegistro.Text, New rptHojaIngreso,
                                    txtRegistro.Text, "{VISTA_RPT_HOJA_INGRESO.N_Registro} = " & txtRegistro.Text & "",
                                    ConstantesHC.NOMBRE_PDF_HOJA, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        tsHojaIngreso.Enabled = True
        Cursor = Cursors.Default
    End Sub



    Private Sub dgvProcedimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProcedimiento.KeyDown
        If tsordenguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_HEMODINAMICO & "," & Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgvProcedimiento,
                                  objHistoriaClinica.objOrdenMedica.dtProcedimientos, 0, 1, dgvProcedimiento.Columns("dgDescripcionProce").Index,
                                  False, True, 0,, AddressOf llenarProcedimiento)
        End If
    End Sub

    Private Sub dgvMezcla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMezcla.CellContentClick

    End Sub

    Private Sub dgvMezcla_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvMezcla.KeyDown
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And dgvMezcla.DataSource.Rows(dgvMezcla.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvMezcla,
                                  dgvMezcla.DataSource, 0, 2, dgvMezcla.Columns("dgDescripcionMezcla").Index, False, True, 0,, AddressOf llenarMezcla)
        End If
    End Sub

    Private Sub dgvParaclinico_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvProcedimiento.DataError, dgvParaclinico.DataError, dgvMezcla.DataError, dgvMedicamento.DataError, dgvInsumosFisio.DataError, dgvInsumosEnfer.DataError, dgvInfusion.DataError, dgvImpregnacion.DataError, dgvHemoderivado.DataError, dgvGlucometria.DataError
        If Not sender.Columns(e.ColumnIndex).Name.Contains("Inicio") AndAlso Not sender.Columns(e.ColumnIndex).Name.Contains("Horario") And mensajeError = "" Then
            MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
            mensajeError = Mensajes.CANTIDAD_VALIDA
        End If
    End Sub

    Private Sub btAceptarMezcla_Click(sender As Object, e As EventArgs) Handles btAceptarMezcla.Click
        Try
            If panelMezcla.Visible = True Then
                mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvMezcla)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                habilitarGbOrdenMedica()
                panelMezcla.Visible = False
                dgvMezcla.EndEdit()
                If dgvMezcla.RowCount > 1 Then
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Value = My.Resources.OK
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Style.BackColor = Color.LightGreen
                Else
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Value = My.Resources._new
                    dgvInfusion.Rows(dgvInfusion.CurrentRow.Index).Cells("dgMezclaInfu").Style.BackColor = Color.White
                End If
                Dim NombreTablaMezcla As String
                NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(dgvInfusion, dgvInfusion.DataSource)
                objHistoriaClinica.objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows.RemoveAt(dgvMezcla.RowCount - 1)
            End If
        Catch ex As Exception
            Label166.Text = "Error 17"
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub habilitarGbOrdenMedica()
        gbEstancia.Enabled = True
        gbDietas.Enabled = True
        gbGlucometrias.Enabled = True
        gbHemoderivados.Enabled = True
        gbImpregnacion.Enabled = True
        gbIndicaciones.Enabled = True
        dgvInfusion.Enabled = True
        gbMedicamentos.Enabled = True
        gbNutricion.Enabled = True
        gbOxigeno.Enabled = True
        gbParaclinicos.Enabled = True
        gbProcedimientos.Enabled = True
    End Sub

    Private Sub dgvGlucometria_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlucometria.CellEndEdit, dgvGlucometria.CellValueChanged
        If tsordenguardar.Enabled = False Then Exit Sub

        calculaFrecuencia(sender.datasource)

    End Sub

    Private Sub dgvImpregnacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellDoubleClick
        If tsordenguardar.Enabled = False OrElse Not SesionActual.tienePermiso(pTrabajarOm) Then
            Exit Sub
        End If
        If dgvImpregnacion.Rows(dgvImpregnacion.CurrentCell.RowIndex).Cells("dgDescripcionImpre").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Estado").ToString = "" _
            AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(Consultas.BUSQUEDA_MEDICAMENTO, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvImpregnacion,
                                  objHistoriaClinica.objOrdenMedica.dtImpregnaciones, 0, 2, dgvImpregnacion.Columns("dgDescripcionImpre").Index, False, True, 0,, AddressOf llenarImpregnacion)
        ElseIf dgvImpregnacion.Rows(dgvImpregnacion.CurrentCell.RowIndex).Cells("dgDisolventeImpre").Selected = True _
            AndAlso objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
             AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Código"))
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_MEDICAMENTO_DISOLVENTE, params, TitulosForm.BUSQUEDA_MEDICAMENTO, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("CódigoDisolvente") = tbl(0)
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("DescripciónDisolvente") = tbl(1)
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("UnidadDisolvente") = tbl(2)
                objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("ConcentracionDisolvente") = tbl(3)

            End If
        ElseIf dgvImpregnacion.Rows(dgvImpregnacion.CurrentCell.RowIndex).Cells("anularImpre").Selected = True _
                AndAlso objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows(dgvImpregnacion.CurrentCell.RowIndex).Item("Estado").ToString <> "" _
                 AndAlso Not verificarSolicitudLab(txtCodigoOrden.Text) Then
            Dim consultaEliminar As String
            consultaEliminar = HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_IMPREGNACION, modulo, objHistoriaClinica.objOrdenMedica.dtImpregnaciones, dgvImpregnacion, txtCodigoOrden.Text)
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(consultaEliminar)
        End If
        calculaDisolvente()
    End Sub
    Private Sub dgvImpregnacion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellEndEdit, dgvImpregnacion.CellValueChanged
        If tsordenguardar.Enabled = False Then Exit Sub
        calculaDisolvente()
    End Sub
    Private Sub dgvInfusion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellEndEdit, dgvInfusion.CellValueChanged
        If tsordenguardar.Enabled = False Then Exit Sub
        calculaDosis()
    End Sub
    Private Sub dgvMedicamento_CellEndEdit(sender As DataGridView, e As DataGridViewCellEventArgs) Handles dgvMedicamento.CellEndEdit, dgvMedicamento.CellValueChanged
        If tsordenguardar.Enabled = False Then Exit Sub
        calculaFrecuencia(sender.DataSource)
    End Sub

    Private Sub tsintervista_Click(sender As Object, e As EventArgs) Handles tsintervista.Click
        Try
            objHistoriaClinica.objInterconsulta.opcionCancelar = False
            If tsinterguardar.Enabled = True Then
                MsgBox("Por favor guarde la información de la interconsulta.", MsgBoxStyle.Information)
                Exit Sub
            ElseIf ListaInterconsultas.Items.Count < 2 Then
                MsgBox("Este paciente no tiene interconsultas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            tsintervista.Enabled = False
            objHistoriaClinica.objInterconsulta.imprimirInterconsulta(ListaInterconsultas.SelectedIndex)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        tsintervista.Enabled = True
        Cursor = Cursors.Default
    End Sub



    Private Sub dgvComida_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvComida.CellValidating
        If objHistoriaClinica.objOrdenMedica.opcionCancelar = True OrElse tsordenguardar.Enabled = False OrElse primeraVez = True OrElse dgvComida.CurrentRow.Index = dgvComida.RowCount - 1 Then
            Exit Sub
        End If
        primeraVez = True
        comidaSeleccionada = False
        If dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgDesayuno").Selected = True OrElse
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgAlmuerzo").Selected = True OrElse
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgCena").Selected = True Then
            comidaSeleccionada = True
        End If
        dgvComida.EndEdit()
        objHistoriaClinica.objOrdenMedica.dtComidas.AcceptChanges()
        If objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentRow.Index).Item("Estado") = Constantes.ITEM_CARGADO Then
            objHistoriaClinica.objOrdenMedica.dtComidas.Rows(dgvComida.CurrentRow.Index).Item("Estado") = Constantes.ITEM_MODIFICADO
        End If
        mensajeError = HistoriaClinicaBLL.verificarSeleccionComida(dgvComida, comidaSeleccionada)
        If mensajeError <> "" And comidaSeleccionada = True Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            e.Cancel = True
            dgvComida.Rows(dgvComida.CurrentRow.Index).Cells("dgDesayuno").Selected = True
        End If
        primeraVez = False
    End Sub

    Private Sub listaordenes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaordenes.SelectedIndexChanged
        Try
            If listaordenes.DisplayMember = Nothing Then Exit Sub
            If listaordenes.SelectedIndex = 0 Then
                General.limpiarControles(ordenes)
                General.deshabilitarBotones_HC(TSOrdenes)
                valoresNutricionPorDefecto()
                tsordennuevo.Enabled = True
                HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_ESTANCIA, objHistoriaClinica.objOrdenMedica.estanciaCargar, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, nRegistro)
            Else
                cargarOrdenMedica()
                edicionSegunRegistro(listaordenes, TSOrdenes)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub ConsentimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsentimientoToolStripMenuItem.Click
        Dim area As String = ConstantesHC.NOMBRE_PDF_CONSETIMIENTO

        Cursor = Cursors.WaitCursor

        Try
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtRegistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(area, txtRegistro.Text, New rptConsetimiento,
                                         txtRegistro.Text, "{VISTA_PACIENTES.N_Registro}=" & txtRegistro.Text &
                                         " And {VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa,
                                        area, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DisentimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisentimientoToolStripMenuItem.Click
        Dim area As String = ConstantesHC.NOMBRE_PDF_DISENTIMIENTO

        Cursor = Cursors.WaitCursor

        Try
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtRegistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(area, txtRegistro.Text, New rptDisentimiento,
                                   txtRegistro.Text, "{VISTA_PACIENTES.N_Registro}=" & txtRegistro.Text &
                                   " And {VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa,
                                  area, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvEstancia_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvEstancia.CellValidating
        If objHistoriaClinica.objOrdenMedica.opcionCancelar = True OrElse tsordenguardar.Enabled = False OrElse primeraVez = True OrElse dgvEstancia.CurrentRow.Index = dgvEstancia.RowCount - 1 Then
            primeraVez = False
            Exit Sub
        End If
        primeraVez = True
        diaSeleccionado = False
        diaSeleccionado = dgvEstancia.Rows(dgvEstancia.CurrentRow.Index).Cells("dgDiaEstancia").Selected
        dgvEstancia.EndEdit()
        objHistoriaClinica.objOrdenMedica.dtEstancias.AcceptChanges()
        If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentRow.Index).Item("Estado") = Constantes.ITEM_CARGADO Then
            objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentRow.Index).Item("Estado") = Constantes.ITEM_MODIFICADO
        End If
        mensajeError = HistoriaClinicaBLL.verificarEstanciaPost(modulo, nRegistro, CDate(txtAdmision.Text).Date, dgvEstancia, CDate(fechaOrdenMedica.Text).Date, diaSeleccionado)
        If mensajeError <> "" And diaSeleccionado = True Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            e.Cancel = True
            If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.CurrentRow.Index).Item("Estado") <> Constantes.ITEM_NUEVO Then
                objHistoriaClinica.objOrdenMedica.elementoAEliminar.Add(HistoriaClinicaBLL.eliminarDetalle(Constantes.OM_ESTANCIA, modulo, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, txtCodigoOrden.Text, nRegistro))
            Else
                dgvEstancia.Rows(dgvEstancia.CurrentRow.Index).Cells("dgDiaEstancia").Selected = True
                dgvEstancia.Rows(dgvEstancia.CurrentRow.Index).Cells("dgDiaEstancia").ReadOnly = False
            End If
            mensajeError = ""
        End If
        primeraVez = False
    End Sub

    Private Sub lista_terapias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaTerapias.SelectedIndexChanged
        Try
            If listaTerapias.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaTerapias.SelectedIndex) Then
                txtCodigoFisioterapia.Clear()
                tsfisionuevo.Enabled = False
                tsfisioduplicar.Enabled = False
                If Not IsNothing(dgvTerapias.DataSource) Then
                    dgvTerapias.DataSource.clear
                End If
                tsfisioeditar.Enabled = False
                tsfisioanular.Enabled = False
            Else
                cargarTerapiaFyR()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub listaOrdenInsumo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaInsumosfisio.SelectedIndexChanged
        Try
            If listaInsumosfisio.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaInsumosfisio.SelectedIndex) Then
                txtCodigoFisioterapia.Clear()
                tsfisionuevo.Enabled = True
                tsfisioduplicar.Enabled = True
                If Not IsNothing(dgvInsumosFisio.DataSource) Then
                    dgvInsumosFisio.DataSource.clear
                End If
                tsfisioduplicar.Enabled = False
                tsfisioeditar.Enabled = False
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaFisioterapia)
            Else
                cargarInsumoFisio()

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub listaOrdenInsumoEnfer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaInsumosEnfer.SelectedIndexChanged
        Try
            If listaInsumosEnfer.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaInsumosEnfer.SelectedIndex) Then
                txtCodigoEnfermeria.Clear()
                tsenferNuevo.Enabled = True
                tsenferduplicar.Enabled = True
                If Not IsNothing(dgvInsumosEnfer.DataSource) Then
                    dgvInsumosEnfer.DataSource.clear
                End If
                tsenferduplicar.Enabled = False
                tsenfereditar.Enabled = False
                tsenferanular.Enabled = False
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                cargarInsumoEnfer()
                edicionSegunRegistro(listaInsumosEnfer, TSEnfermeria)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub listaNotaFisio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaNotasfisio.SelectedIndexChanged
        Try
            If listaNotasfisio.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaNotasfisio.SelectedIndex) Then
                txtCodigoFisioterapia.Clear()
                tsfisionuevo.Enabled = True
                tsfisioduplicar.Enabled = True
                txtNotaFisio.Clear()
                tsfisioduplicar.Enabled = False
                tsfisioeditar.Enabled = False
                tsfisioanular.Enabled = False
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaFisioterapia)
            Else
                cargarNotaFisio()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub listaNotaEnfer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaNotasEnfer.SelectedIndexChanged
        Try
            If listaNotasEnfer.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaNotasEnfer.SelectedIndex) Then
                txtCodigoEnfermeria.Clear()
                tsenferNuevo.Enabled = True
                tsenferduplicar.Enabled = True
                txtNotaEnfer.Clear()
                tsenferduplicar.Enabled = False
                tsenfereditar.Enabled = False
                tsenferanular.Enabled = False
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                cargarNotaEnfer()
                edicionSegunRegistro(listaNotasEnfer, TSEnfermeria)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub cargarTerapiaFyR()
        Dim codigos As String()
        codigos = Split(listaTerapias.Text, " | ")
        txtCodigoFisioterapia.Text = listaTerapias.SelectedValue
        procedimientoTerapia = codigos(1)
        objHistoriaClinica.objFisioterapia.codigoOrden = txtCodigoFisioterapia.Text
        objHistoriaClinica.objFisioterapia.cargarDetalleTerapia(procedimientoTerapia)
        If dgvTerapias.DataSource Is Nothing Then
            With dgvTerapias
                .Columns("dgCodigoFisio").DataPropertyName = "Codigo_Procedimiento"
                .Columns("dgDescripcionFisio").DataPropertyName = "Descripcion"
                .Columns("dgAplicaFisio").DataPropertyName = "Realizado"
            End With
            dgvTerapias.DataSource = objHistoriaClinica.objFisioterapia.objTerapiaFyR.dtTerapiaFyR
            dgvTerapias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvTerapias.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End If
        General.deshabilitarBotones_HC(TSFisioterapias)
        dgvTerapias.ReadOnly = False
        dgvTerapias.Columns("dgCodigoFisio").ReadOnly = True
        dgvTerapias.Columns("dgDescripcionFisio").ReadOnly = True
        dgvTerapias.Columns("dgAplicaFisio").ReadOnly = True
        tsfisioeditar.Enabled = True
        tsfisioanular.Enabled = True
    End Sub

    Private Sub cargarInsumoFisio()
        If listaInsumosfisio.SelectedIndex = 0 Then
            txtCodigoFisioterapia.Clear()
        Else
            txtCodigoFisioterapia.Text = listaInsumosfisio.SelectedValue
            fechaFisioterapia.Text = objHistoriaClinica.objFisioterapia.listInsumo.Rows(listaInsumosfisio.SelectedIndex - 1).Item("Fecha_orden")
            txtNombreUsuarioInforme.Text = objHistoriaClinica.objFisioterapia.listInsumo.Rows(listaInsumosfisio.SelectedIndex - 1).Item("UsuarioCreacion")
            objHistoriaClinica.objFisioterapia.objInsumosFisio.usuarioReal = objHistoriaClinica.objFisioterapia.listInsumo.Rows(listaInsumosfisio.SelectedIndex - 1).Item("Usuario_Real")
            If listaInsumosfisio.DataSource.columns.count > 5 Then
                cambiarDiseno(listaInsumosfisio.DataSource.rows(listaInsumosfisio.SelectedIndex).item("EDITADO"), txtCodigoFisioterapia)
            End If
        End If

        objHistoriaClinica.objFisioterapia.codigoOrden = txtCodigoFisioterapia.Text
        objHistoriaClinica.objFisioterapia.cargarOrdenInsumoFisio()

        If dgvInsumosFisio.DataSource Is Nothing Then
            With dgvInsumosFisio
                .Columns("dgCodigoInsuFisio").DataPropertyName = "Código"
                .Columns("dgDescripcionInsuFisio").DataPropertyName = "Descripción"
                .Columns("dgCantidadInsuFisio").DataPropertyName = "Cantidad"
            End With
        End If
        dgvInsumosFisio.DataSource = objHistoriaClinica.objFisioterapia.objInsumosFisio.dtInsumosFisio
        dgvInsumosFisio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvInsumosFisio.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        General.deshabilitarBotones_HC(TSFisioterapias)
        dgvInsumosFisio.ReadOnly = False
        dgvInsumosFisio.Columns("dgCodigoInsuFisio").ReadOnly = True
        dgvInsumosFisio.Columns("dgDescripcionInsuFisio").ReadOnly = True
        dgvInsumosFisio.Columns("dgCantidadInsuFisio").ReadOnly = True
        tsfisionuevo.Enabled = True
        tsfisioduplicar.Enabled = True
        tsfisioeditar.Enabled = True
        tsfisioanular.Enabled = True
    End Sub
    Private Sub cargarNotaFisio()
        If listaNotasfisio.SelectedIndex = 0 Then
            txtCodigoFisioterapia.Clear()
            txtNotaFisio.Clear()
        Else
            txtCodigoFisioterapia.Text = listaNotasfisio.SelectedValue
            txtNotaFisio.Text = objHistoriaClinica.objFisioterapia.listNota.Rows(listaNotasfisio.SelectedIndex - 1).Item("Nota")
            fechaFisioterapia.Text = objHistoriaClinica.objFisioterapia.listNota.Rows(listaNotasfisio.SelectedIndex - 1).Item("Fecha_Nota")
            txtNombreUsuarioInforme.Text = objHistoriaClinica.objFisioterapia.listNota.Rows(listaNotasfisio.SelectedIndex - 1).Item("UsuarioCreacion")
            objHistoriaClinica.objFisioterapia.objNotaFisio.usuarioReal = objHistoriaClinica.objFisioterapia.listNota.Rows(listaNotasfisio.SelectedIndex - 1).Item("Usuario_Real")
        End If

        General.deshabilitarBotones_HC(TSFisioterapias)
        tsfisionuevo.Enabled = True
        tsfisioduplicar.Enabled = True
        tsfisioeditar.Enabled = True
        tsfisioanular.Enabled = True
    End Sub
    Private Sub cargarInsumoEnfer()
        If listaInsumosEnfer.SelectedIndex = 0 Then
            txtCodigoEnfermeria.Clear()
        Else
            txtCodigoEnfermeria.Text = listaInsumosEnfer.SelectedValue
            fechaEnfermeria.Text = objHistoriaClinica.objEnfermeria.listInsumo.Rows(listaInsumosEnfer.SelectedIndex - 1).Item("Fecha_Orden")
            txtNombreUsuarioInforme.Text = objHistoriaClinica.objEnfermeria.listInsumo.Rows(listaInsumosEnfer.SelectedIndex - 1).Item("UsuarioCreacion")
            objHistoriaClinica.objEnfermeria.objInsumosEnfer.usuarioReal = objHistoriaClinica.objEnfermeria.listInsumo.Rows(listaInsumosEnfer.SelectedIndex - 1).Item("Usuario_Real")
            If listaInsumosEnfer.DataSource.columns.count > 6 Then
                cambiarDiseno(listaInsumosEnfer.DataSource.rows(listaInsumosEnfer.SelectedIndex).item("EDITADO"), txtCodigoEnfermeria)
            End If
        End If

        objHistoriaClinica.objEnfermeria.codigoOrden = txtCodigoEnfermeria.Text
        objHistoriaClinica.objEnfermeria.cargarOrdenInsumoEnfer()

        If dgvInsumosEnfer.DataSource Is Nothing Then
            With dgvInsumosEnfer
                .Columns("dgCodigoInsuEnfer").DataPropertyName = "Código"
                .Columns("dgDescripcionInsuEnfer").DataPropertyName = "Descripción"
                .Columns("dgCantidadInsuEnfer").DataPropertyName = "Cantidad"
            End With
        End If
        dgvInsumosEnfer.DataSource = objHistoriaClinica.objEnfermeria.objInsumosEnfer.dtInsumosEnfer
        dgvInsumosEnfer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvInsumosEnfer.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        General.deshabilitarBotones_HC(TSEnfermeria)
        dgvInsumosEnfer.ReadOnly = False
        dgvInsumosEnfer.Columns("dgCodigoInsuEnfer").ReadOnly = True
        dgvInsumosEnfer.Columns("dgDescripcionInsuEnfer").ReadOnly = True
        dgvInsumosEnfer.Columns("dgCantidadInsuEnfer").ReadOnly = True
        tsenferNuevo.Enabled = True
        tsenferduplicar.Enabled = True
        tsenfereditar.Enabled = True
        tsenferanular.Enabled = True
    End Sub
    Private Sub cargarNotaEnfer()
        If listaNotasEnfer.SelectedIndex = 0 Then
            txtCodigoEnfermeria.Text = ""
            txtNotaEnfer.Clear()
        Else
            txtCodigoEnfermeria.Text = listaNotasEnfer.SelectedValue
            txtNotaEnfer.Text = objHistoriaClinica.objEnfermeria.listNota.Rows(listaNotasEnfer.SelectedIndex - 1).Item("Nota")
            fechaEnfermeria.Text = objHistoriaClinica.objEnfermeria.listNota.Rows(listaNotasEnfer.SelectedIndex - 1).Item("Fecha_Nota")
            txtNombreUsuarioInforme.Text = objHistoriaClinica.objEnfermeria.listNota.Rows(listaNotasEnfer.SelectedIndex - 1).Item("UsuarioCreacion")
            objHistoriaClinica.objEnfermeria.objNotaEnfer.usuarioReal = objHistoriaClinica.objEnfermeria.listNota.Rows(listaNotasEnfer.SelectedIndex - 1).Item("Usuario_Real")
        End If

        General.deshabilitarBotones_HC(TSEnfermeria)
        tsenferNuevo.Enabled = True
        tsenferduplicar.Enabled = True
        tsenfereditar.Enabled = True
        tsenferanular.Enabled = True
    End Sub
    Private Sub cargarGlucomEnfer()
        If listaGlucometria.SelectedIndex = 0 Then
            txtCodigoEnfermeria.Clear()
        Else
            txtCodigoEnfermeria.Text = listaGlucometria.SelectedValue
            fechaEnfermeria.Text = objHistoriaClinica.objEnfermeria.listGlucometria.Rows(listaGlucometria.SelectedIndex - 1).Item("Fecha")
            txtNombreUsuarioInforme.Text = objHistoriaClinica.objEnfermeria.listGlucometria.Rows(listaGlucometria.SelectedIndex - 1).Item("UsuarioCreacion")
            objHistoriaClinica.objEnfermeria.objGlucomEnfer.usuarioReal = objHistoriaClinica.objEnfermeria.listGlucometria.Rows(listaGlucometria.SelectedIndex - 1).Item("Usuario_Real")
        End If

        objHistoriaClinica.objEnfermeria.codigoOrden = txtCodigoEnfermeria.Text
        objHistoriaClinica.objEnfermeria.cargarOrdenGlucomEnfer()

        If dgvGlucometriaEnfer.DataSource Is Nothing Then
            With dgvGlucometriaEnfer
                .Columns("dgConsecutivo").DataPropertyName = "consecutivo"
                .Columns("dgHoraDia").DataPropertyName = "HoraDia"
                .Columns("dgDescripcionGlucom").DataPropertyName = "Descripcion"
                .Columns("dgGlicemia").DataPropertyName = "Glicemia"
                .Columns("dgUnidadMedida").DataPropertyName = "UnidadMedida"
                .Columns("dgDosisInsulina").DataPropertyName = "DosisInsulina"
                .Columns("dgIniciales").DataPropertyName = "Iniciales"
                .Columns("dgUsuario").DataPropertyName = "Usuario"
            End With
        End If

        dgvGlucometriaEnfer.DataSource = objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer
        dgvGlucometriaEnfer.Columns("dgQuitarGlucom").DisplayIndex = 7
        dgvGlucometriaEnfer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGlucometriaEnfer.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        General.deshabilitarBotones_HC(TSEnfermeria)
        dgvGlucometriaEnfer.ReadOnly = False
        dgvGlucometriaEnfer.Columns("dgHoraDia").ReadOnly = True
        dgvGlucometriaEnfer.Columns("dgGlicemia").ReadOnly = True
        dgvGlucometriaEnfer.Columns("dgDescripcionGlucom").ReadOnly = True
        dgvGlucometriaEnfer.Columns("dgDosisInsulina").ReadOnly = True
        dgvGlucometriaEnfer.Columns("dgUnidadMedida").ReadOnly = True
        dgvGlucometriaEnfer.Columns("dgIniciales").ReadOnly = True
        tsenfereditar.Enabled = True
    End Sub
    Public Sub cargarParaclinico()
        If listaParaclinicos.SelectedIndex = 0 Then
            txtCodigoEnfermeria.Clear()
        Else
            txtCodigoEnfermeria.Text = listaParaclinicos.SelectedValue
            fechaEnfermeria.Text = objHistoriaClinica.objEnfermeria.listExamenes.Rows(listaParaclinicos.SelectedIndex - 1).Item("Fecha_Orden")
        End If

        objHistoriaClinica.objEnfermeria.objParaclinico.codigoOrden = txtCodigoEnfermeria.Text
        objHistoriaClinica.objEnfermeria.objParaclinico.cargarParaclEnfer()

        If dgvExamenParaclinicos.DataSource Is Nothing Then
            With dgvExamenParaclinicos
                .ReadOnly = True
                .Columns(0).DataPropertyName = "CodigoTipoExamen"
                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(1).DataPropertyName = "Codigo"
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(2).DataPropertyName = "Examen"
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("dgEstadoP").DataPropertyName = "Estado"
            End With
        End If
        dgvExamenParaclinicos.DataSource = objHistoriaClinica.objEnfermeria.objParaclinico.dtParaclinicoEnfer
        For fila = 0 To objHistoriaClinica.objEnfermeria.objParaclinico.dtParaclinicoEnfer.Rows.Count - 1
            If objHistoriaClinica.objEnfermeria.objParaclinico.dtParaclinicoEnfer.Rows(fila).Item("Estado") = Constantes.PENDIENTE Then
                dgvExamenParaclinicos.Rows(fila).Cells("dgVerificar").Value = My.Resources._new
            Else
                dgvExamenParaclinicos.Rows(fila).Cells("dgVerificar").Value = My.Resources.OK
            End If
        Next
        dgvExamenParaclinicos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExamenParaclinicos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Sub cargarHemoderivados()
        If listaHemoderivados.SelectedIndex = 0 Then
            txtCodigoEnfermeria.Clear()
        Else
            txtCodigoEnfermeria.Text = listaHemoderivados.SelectedValue
            fechaEnfermeria.Text = objHistoriaClinica.objEnfermeria.listExamenes.Rows(listaHemoderivados.SelectedIndex - 1).Item("Fecha_Orden")
        End If

        objHistoriaClinica.objEnfermeria.objHemoderivado.codigoOrden = txtCodigoEnfermeria.Text
        objHistoriaClinica.objEnfermeria.objHemoderivado.cargarHemodEnfer()

        If dgvExamenHemoderivados.DataSource Is Nothing Then
            With dgvExamenHemoderivados
                .ReadOnly = True
                .Columns(0).DataPropertyName = "CodigoTipoExamenH"
                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(1).DataPropertyName = "CodigoH"
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(2).DataPropertyName = "ExamenH"
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("dgEstadoH").DataPropertyName = "EstadoH"
            End With
        End If
        dgvExamenHemoderivados.DataSource = objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer
        For fila = 0 To objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer.Rows.Count - 1
            If objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer.Rows(fila).Item("EstadoH") = Constantes.PENDIENTE Then
                dgvExamenHemoderivados.Rows(fila).Cells("dgVerificarH").Value = My.Resources._new
            Else
                dgvExamenHemoderivados.Rows(fila).Cells("dgVerificarH").Value = My.Resources.OK
            End If
        Next
        dgvExamenHemoderivados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExamenHemoderivados.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Sub cargarCuerpoMedico()
        dtParticipantes.Clear()
        If listaProcedimientos.SelectedIndex <> 0 Then
            objHistoriaClinica.objCuerpoMedico.Codigo = listaProcedimientos.SelectedValue
            objHistoriaClinica.objCuerpoMedico.CodigoOrden = objHistoriaClinica.objCuerpoMedico.dtProcedimientos.Rows(listaProcedimientos.SelectedIndex - 1).Item(0)
            objHistoriaClinica.objCuerpoMedico.CargarCuerpoMedico()
        End If
        Dim params As New List(Of String)
        params.Clear()
        params.Add(objHistoriaClinica.objCuerpoMedico.CodigoOrden)
        params.Add(objHistoriaClinica.objCuerpoMedico.Codigo)
        'General.llenarTabla(Consultas.PARTICIPANTES_CARGAR, params, dtParticipantes)
        dgvCuerpoM.DataSource = dtParticipantes
        General.deshabilitarBotones_HC(TScuerpom)
        If dtParticipantes.Rows.Count > 0 Then
            chkAplica.Checked = dtParticipantes.Rows(0).Item("tarifa")
            'txtCodCM.Text = objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(0).Item("Codigo")
            'dgvCuerpoM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvCuerpoM.Columns("tarifa").Visible = False
            dgvCuerpoM.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            tscuerpoeditar.Enabled = True
            tscuerpoanular.Enabled = True
            tscuerpotarifa.Enabled = True
        Else
            txtCodCM.Text = ""
            tscuerponuevo.Enabled = True
            tscuerpotarifa.Enabled = True
            tscuerpotarifa.Enabled = True
        End If
        'dgvCuerpoM.Columns("Anulado").Visible = False
        cargarValoresCM(Nothing)
    End Sub
    Public Sub calcularTotal()
        objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Clear()
        objHistoriaClinica.objCuerpoMedico.CargarCuerpoMedico()
        If objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows.Count > 0 Then
            chkAplica.Checked = objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(0).Item("tarifa")
            cargarValoresCM(Nothing)
            txtTotal.Text += CInt(txtSubTotal.Text)
            txtTotal.Text = FormatCurrency(txtTotal.Text)
            txtSubTotal.Text = FormatCurrency(0)
        End If
    End Sub
    Private Sub tsfisiocancelar_Click(sender As Object, e As EventArgs) Handles tsfisiocancelar.Click
        objHistoriaClinica.objFisioterapia.opcionCancelar = True
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        listarFisioterapia()
    End Sub

    Private Sub tsfisioguardar_Click(sender As Object, e As EventArgs) Handles tsfisioguardar.Click
        TabHistoriaC.SelectedIndex = TabHistoriaC.TabPages("fisioterapia").TabIndex
        objHistoriaClinica.objFisioterapia.opcionCancelar = False
        Try
            dgvInsumosFisio.EndEdit()
            If dgvOxigenoFisio.Enabled = True Then
                guardarOxigenoFisioterapia(True)
                opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION
                listaOxigeno.Focus()
            ElseIf dgvNebulizacion.Enabled = True Then
                guardarNebulizacionFisioterapia()
                opcionFisioSeleccionado = ConstantesHC.NEBULIZACION_SELECCION
                listaNebulizacion.Focus()
            ElseIf dgvTerapias.Enabled = True Then
                guardarTerapias()
                opcionFisioSeleccionado = ConstantesHC.TERAPIA_SELECCION
                listaTerapias.Focus()
            ElseIf dgvInsumosFisio.Enabled = True Then
                If validarFisioterapia() = False Then Exit Sub
                guardarInsumoFisio()
                opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION
                listaInsumosfisio.Focus()
            ElseIf txtNotaFisio.Enabled = True Then
                If txtNotaFisio.Text.Length > 0 Then
                    guardarNotaFisio()
                    opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION
                    listaNotasfisio.Focus()
                Else
                    MsgBox("Por favor diligencie la nota a guardar.", MsgBoxStyle.Information)
                End If
            End If
            verificarSoat()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub guardarTerapias()
        dgvTerapias.EndEdit()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                CodigoTemporal = listaTerapias.SelectedValue
                objHistoriaClinica.objFisioterapia.objTerapiaFyR.codigoOrden = CodigoTemporal
                objHistoriaClinica.objFisioterapia.objTerapiaFyR.codigoProcedimiento = procedimientoTerapia
                objHistoriaClinica.objFisioterapia.objTerapiaFyR.empresa = SesionActual.idEmpresa
                objHistoriaClinica.objFisioterapia.objTerapiaFyR.usuario = SesionActual.idUsuario
                objHistoriaClinica.objFisioterapia.objTerapiaFyR.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objFisioterapia.guardarDetalleTerapia()

                postGuardarFisio()

                listaTerapias.Focus()
                listaTerapias.SelectedValue = objHistoriaClinica.objFisioterapia.objTerapiaFyR.codigoOrden
                tsfisionuevo.Enabled = False
                tsfisioduplicar.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarInsumoFisio()
        dgvInsumosFisio.EndEdit()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim dtInsumos As New DataTable

                dtInsumos = dgvInsumosFisio.DataSource.COPY
                dtInsumos.Rows.RemoveAt(dtInsumos.Rows.Count - 1)
                CodigoTemporal = txtCodigoFisioterapia.Text
                objHistoriaClinica.objFisioterapia.objInsumosFisio.codigoOrden = CodigoTemporal
                objHistoriaClinica.objFisioterapia.objInsumosFisio.fechaOrden = fechaFisioterapia.Value
                objHistoriaClinica.objFisioterapia.objInsumosFisio.codigoEP = SesionActual.idEmpresa
                objHistoriaClinica.objFisioterapia.objInsumosFisio.usuario = usuarioActual
                objHistoriaClinica.objFisioterapia.objInsumosFisio.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objFisioterapia.objInsumosFisio.nRegistro = nRegistro
                objHistoriaClinica.objFisioterapia.objInsumosFisio.dtInsumosFisio = dtInsumos
                objHistoriaClinica.objFisioterapia.guardarOrdenInsumoFisio()

                postGuardarFisio()

                listaInsumosfisio.Focus()
                listaInsumosfisio.SelectedValue = objHistoriaClinica.objFisioterapia.objInsumosFisio.codigoOrden
                tsfisionuevo.Enabled = True
                tsfisioduplicar.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarOxigenoFisioterapia(ByVal opcionGuardar As Boolean)
        Try
            If opcionGuardar Then
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    guardarOxigenoFisio()
                End If
            Else
                guardarOxigenoFisio(False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub guardarOxigenoFisio(Optional opcionGuardar As Boolean = True)
        CodigoTemporal = listaOxigeno.SelectedValue
        objHistoriaClinica.objFisioterapia.objOxigeno.codigoOrden = listaOxigeno.SelectedValue
        objHistoriaClinica.objFisioterapia.objOxigeno.usuario = SesionActual.idUsuario
        objHistoriaClinica.objFisioterapia.objOxigeno.codigoEP = SesionActual.codigoEP
        objHistoriaClinica.objFisioterapia.guardarOxigeno()
        'guardarInforme(ConstantesHC.IDENTIFICADOR_OXIGENO_FISIOTERAPIA)
        If opcionGuardar Then
            postGuardarFisio()
            listaOxigeno.SelectedIndex = 0
            tsfisionuevo.Enabled = False
            tsfisioduplicar.Enabled = False
        End If
    End Sub
    Private Sub postGuardarFisio()
        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
        General.deshabilitarBotones_HC(TSEnfermeria)
        tsfisionuevo.Enabled = True
        tsfisioeditar.Enabled = True
        tsfisioduplicar.Enabled = True
        listaNebulizacion.Enabled = True
        listaOxigeno.Enabled = True
        listaTerapias.Enabled = True
        listaInsumosfisio.Enabled = True
        listaNotasfisio.Enabled = True
        listarFisioterapia()
    End Sub
    Public Sub guardarNotaFisio()

        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                tsfisiovista.Enabled = False
                CodigoTemporal = txtCodigoFisioterapia.Text
                objHistoriaClinica.objFisioterapia.objNotaFisio.codigoNota = CodigoTemporal
                objHistoriaClinica.objFisioterapia.objNotaFisio.fechaNota = fechaFisioterapia.Value
                objHistoriaClinica.objFisioterapia.objNotaFisio.codigoEP = SesionActual.idEmpresa
                objHistoriaClinica.objFisioterapia.objNotaFisio.usuario = usuarioActual
                objHistoriaClinica.objFisioterapia.objNotaFisio.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objFisioterapia.objNotaFisio.nRegistro = nRegistro
                objHistoriaClinica.objFisioterapia.objNotaFisio.nota = txtNotaFisio.Text
                objHistoriaClinica.objFisioterapia.guardarNotaFisio()

                postGuardarFisio()
                ' guardarInforme(ConstantesHC.IDENTIFICADOR_NOTA_FISIOTERAPIA)
                listaNotasfisio.Focus()
                listaNotasfisio.SelectedValue = objHistoriaClinica.objFisioterapia.objNotaFisio.codigoNota
                tsfisionuevo.Enabled = True
                tsfisioduplicar.Enabled = True
            End If

        Catch ex As Exception
            tsfisiovista.Enabled = True
            Throw ex
        End Try
    End Sub
    Public Sub guardarInsumoEnfer()
        dgvInsumosEnfer.EndEdit()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim dtInsumos As New DataTable

                dtInsumos = dgvInsumosEnfer.DataSource.COPY
                dtInsumos.Rows.RemoveAt(dtInsumos.Rows.Count - 1)
                CodigoTemporal = txtCodigoEnfermeria.Text
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.codigoOrden = CodigoTemporal
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.fechaOrden = fechaEnfermeria.Value
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.codigoEP = SesionActual.idEmpresa
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.usuario = usuarioActual
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.nRegistro = nRegistro
                objHistoriaClinica.objEnfermeria.objInsumosEnfer.dtInsumosEnfer = dtInsumos
                objHistoriaClinica.objEnfermeria.guardarOrdenInsumoEnfer()

                postGuardarEnfer()

                listaInsumosEnfer.Focus()
                listaInsumosEnfer.SelectedValue = objHistoriaClinica.objEnfermeria.objInsumosEnfer.codigoOrden
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarGlucometriaEnfer()
        dgvGlucometriaEnfer.EndEdit()
        Try
            If objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Select("[Glicemia] <> 0 ").Count = 0 Then
                MsgBox("¡ Favor digitar el resultado de la prueba !", MsgBoxStyle.Exclamation)
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    tsenfervista.Enabled = False
                    Dim dtGlucometria As New DataTable
                    dgvGlucometriaEnfer.EndEdit()
                    objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.AcceptChanges()
                    dtGlucometria = dgvGlucometriaEnfer.DataSource.COPY
                    dtGlucometria.Columns.RemoveAt(dtGlucometria.Columns.Count - 1)
                    CodigoTemporal = txtCodigoEnfermeria.Text
                    objHistoriaClinica.objEnfermeria.objGlucomEnfer.usuario = SesionActual.idUsuario
                    objHistoriaClinica.objEnfermeria.objGlucomEnfer.codigoEP = SesionActual.codigoEP
                    objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer = dtGlucometria
                    objHistoriaClinica.objEnfermeria.guardarGlucometriaEnfe()
                    'guardarInforme(ConstantesHC.IDENTIFICADOR_GLUCOMETRIA)
                    postGuardarEnfer()
                    listaGlucometria.Focus()
                    listaGlucometria.SelectedValue = objHistoriaClinica.objEnfermeria.objGlucomEnfer.codigoOrden
                End If
            End If
        Catch ex As Exception

            Throw ex
        End Try
        tsenfervista.Enabled = True
    End Sub

    Private Sub postGuardarEnfer()
        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
        General.deshabilitarBotones_HC(TSEnfermeria)
        tsfisionuevo.Enabled = True
        tsfisioeditar.Enabled = True
        tsfisioduplicar.Enabled = True
        listaNebulizacion.Enabled = True
        listaOxigeno.Enabled = True
        listaTerapias.Enabled = True
        listaInsumosfisio.Enabled = True
        listaNotasfisio.Enabled = True
        listarEnfermeria()
    End Sub
    Public Sub guardarNotaEnfer()

        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                CodigoTemporal = txtCodigoEnfermeria.Text
                objHistoriaClinica.objEnfermeria.objNotaEnfer.codigoNota = CodigoTemporal
                objHistoriaClinica.objEnfermeria.objNotaEnfer.fechaNota = fechaEnfermeria.Value
                objHistoriaClinica.objEnfermeria.objNotaEnfer.codigoEP = SesionActual.idEmpresa
                objHistoriaClinica.objEnfermeria.objNotaEnfer.usuario = usuarioActual
                objHistoriaClinica.objEnfermeria.objNotaEnfer.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objEnfermeria.objNotaEnfer.nRegistro = nRegistro
                objHistoriaClinica.objEnfermeria.objNotaEnfer.nota = txtNotaEnfer.Text
                objHistoriaClinica.objEnfermeria.guardarNotaEnfer()

                postGuardarEnfer()

                listaNotasfisio.Focus()
                listaNotasfisio.SelectedValue = objHistoriaClinica.objEnfermeria.objNotaEnfer.codigoNota

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub habilitarGroupBoxFisio()
        groupBoxOxigeno.Enabled = True
        groupBoxNeb.Enabled = True
        gbTerapia.Enabled = True
        gbInsumoFisio.Enabled = True
        gbNotaFisio.Enabled = True
    End Sub

    Private Sub habilitarGroupBoxEnfer()
        GroupBoxInsuEnfer.Enabled = True
        GroupBoxNotaEnfer.Enabled = True
        GroupBoxResultados.Enabled = True
        GroupBoxGluco.Enabled = True
    End Sub

    Private Sub BradenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BradenToolStripMenuItem.Click
        Form_Braden.cargarModulo(Tag.modulo)
        General.cargarForm(Form_Braden)
        Form_Braden.textregistro.Text = txtRegistro.Text
        Form_Braden.txtpnombre.Text = txtNombre.Text
        Form_Braden.cargarDatos()

    End Sub

    Private Sub tsremvista_Click(sender As Object, e As EventArgs) Handles tsremvista.Click
        Try
            objHistoriaClinica.objRemision.opcionCancelar = False
            If tsremguardar.Enabled = True Then
                MsgBox("Por favor guarde la información de la remisión.", MsgBoxStyle.Information)
                Exit Sub
            ElseIf Listaremisiones.Items.Count < 2 Then
                MsgBox("Este paciente no tiene remisiones.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            tsremvista.Enabled = False
            objHistoriaClinica.objRemision.imprimirRemision(Listaremisiones.SelectedIndex)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        tsremvista.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub TabHistoriaC_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabHistoriaC.Selecting
        If modulo = Constantes.HC Then
            If servicioNeonatal = True Then
                respuesta = General.getEstadoVF(Consultas.VERIFICA_INFO_INGRESON & txtRegistro.Text)
            Else
                respuesta = General.getEstadoVF(Consultas.VERIFICA_INFO_INGRESO & txtRegistro.Text)
            End If
        ElseIf modulo = Constantes.AM Then
            If servicioNeonatal = True Then
                respuesta = General.getEstadoVF(Consultas.VERIFICA_INFO_INGRESONR & txtRegistro.Text)
            Else
                respuesta = General.getEstadoVF(Consultas.VERIFICA_INFO_INGRESOR & txtRegistro.Text)
            End If
        ElseIf modulo = Constantes.AF Then
            If servicioNeonatal = True Then
                respuesta = General.getEstadoVF(Consultas.VERIFICA_INFO_INGRESONRR & txtRegistro.Text)
            Else
                respuesta = General.getEstadoVF(Consultas.VERIFICA_INFO_INGRESORR & txtRegistro.Text)
            End If
        End If

        If respuesta = False And (TabHistoriaC.SelectedIndex = 1 Or TabHistoriaC.SelectedIndex = 2 Or TabHistoriaC.SelectedIndex = 3 Or TabHistoriaC.SelectedIndex = 4 Or TabHistoriaC.SelectedIndex = 5 Or TabHistoriaC.SelectedIndex = 6 Or TabHistoriaC.SelectedIndex = 7) Then
            MsgBox("Por favor diligencie por completo la información de ingreso de paciente para poder continuar", MsgBoxStyle.Exclamation, "Atención")
            e.Cancel = True
        End If


    End Sub

    Private Sub listaOxigeno_Click(sender As Object, e As EventArgs) Handles listaOxigeno.Click
        opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION
    End Sub
    Private Sub listaNebulizacion_Click(sender As Object, e As EventArgs) Handles listaNebulizacion.Click
        opcionFisioSeleccionado = ConstantesHC.NEBULIZACION_SELECCION
    End Sub
    Private Sub listaTerapias_Click(sender As Object, e As EventArgs) Handles listaTerapias.Click
        opcionFisioSeleccionado = ConstantesHC.TERAPIA_SELECCION
    End Sub

    Private Sub listaInsumosfisio_Click(sender As Object, e As EventArgs) Handles listaInsumosfisio.Click
        opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION
    End Sub

    Private Sub listaNotasfisio_Click(sender As Object, e As EventArgs) Handles listaNotasfisio.Click
        opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION
    End Sub
    Private Sub listaInsumosEnfer_Click(sender As Object, e As EventArgs) Handles listaInsumosEnfer.Click
        opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION
    End Sub

    Private Sub listaNotasEnfer_Click(sender As Object, e As EventArgs) Handles listaNotasEnfer.Click
        opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION
    End Sub
    Private Sub tsinfocancelar_Click(sender As Object, e As EventArgs) Handles tsinfocancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        txtJustificacion.Clear()
        txtJustificacionN.Clear()
        txtJustificacionR.Clear()
        txtJustificacionRN.Clear()
        PanelJustificacion.Visible = False
        PanelJustificacionN.Visible = False
        PanelJustificacionR.Visible = False
        PanelJustificacionRN.Visible = False
        cargarInfoIngreso()
        General.deshabilitarControles(ingreso)
        General.deshabilitarBotones_HC(TSinfoingreso)
        tsinfoeditar.Enabled = True
    End Sub
    Private Sub dgvImpresionN_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvImpresionN.KeyDown
        If tsinfoguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresionN, objHistoriaClinica.objInfoIngreso.dtDiagImpresion)
        End If
    End Sub
    Private Sub dgvImpresionN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpresionN.CellDoubleClick
        General.abrirJustificacion(dgvImpresionN, objHistoriaClinica.objInfoIngreso.dtDiagImpresion, PanelJustificacionN, txtJustificacionN, "Observacion", Not tsinfoguardar.Enabled)
        If tsinfoguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresionN, objHistoriaClinica.objInfoIngreso.dtDiagImpresion)
        ElseIf dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("anulardiagevoN").Selected = True And objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.RemoveAt(e.RowIndex)
            ElseIf objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    If modulo = Constantes.HC Then
                        consulta = Consultas.ANULAR_DIAGINFON
                        consulta = consulta & CInt(txtRegistro.Text) & ",'" & objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                    ElseIf modulo = Constantes.AM Then
                        consulta = Consultas.ANULAR_DIAGINFONR
                        consulta = consulta & CInt(txtRegistro.Text) & ",'" & objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                    ElseIf modulo = Constantes.AF Then
                        consulta = Consultas.ANULAR_DIAGINFONRR
                        consulta = consulta & CInt(txtRegistro.Text) & ",'" & objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                    End If
                    objHistoriaClinica.objInfoIngreso.elementoAEliminar.Add(consulta)
                    objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.RemoveAt(dgvImpresionN.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub tsfisiovista_Click(sender As Object, e As EventArgs) Handles tsfisiovista.Click
        objHistoriaClinica.objFisioterapia.opcionCancelar = False
        If tsfisioguardar.Enabled = True Then
            MsgBox("Por favor guarde la información antes de imprimir.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION AndAlso listaInsumosfisio.Items.Count < 2 Then
            MsgBox("Este paciente no tiene ordenes de insumos.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION AndAlso listaNotasfisio.Items.Count < 2 Then
            MsgBox("Este paciente no tiene notas.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION AndAlso listaOxigeno.Items.Count < 2 Then
            MsgBox("Este paciente no tiene notas.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionFisioSeleccionado = ConstantesHC.NEBULIZACION_SELECCION AndAlso listaNebulizacion.Items.Count < 2 Then
            MsgBox("Este paciente no tiene nebulizaciones.", MsgBoxStyle.Information)
            Exit Sub
        End If
        imprimirFisioterapia()
    End Sub

    Private Sub imprimirFisioterapia()
        Try
            Cursor = Cursors.WaitCursor
            tsfisiovista.Enabled = False
            objHistoriaClinica.objFisioterapia.registro = nRegistro
            objHistoriaClinica.objFisioterapia.codigoOrden = txtCodigoFisioterapia.Text
            If opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION Then
                objHistoriaClinica.objFisioterapia.imprimirOrdenInsumoFisio(listaInsumosfisio.SelectedIndex)
            ElseIf opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION Then
                objHistoriaClinica.objFisioterapia.imprimirNotaFisio(listaNotasfisio.SelectedIndex)
            ElseIf opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION Then
                objHistoriaClinica.objFisioterapia.objOxigeno.imprimirOxigeno()
            ElseIf opcionFisioSeleccionado = ConstantesHC.NEBULIZACION_SELECCION Then
                objHistoriaClinica.objFisioterapia.objnebulizacion.imprimirNebulizacion(listaNebulizacion)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        tsfisiovista.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvImpresion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvImpresion.KeyDown
        If tsinfoguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresion, objHistoriaClinica.objInfoIngreso.dtDiagImpresion)
        End If
    End Sub

    Private Sub dgvImpresion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpresion.CellDoubleClick
        General.abrirJustificacion(dgvImpresion, objHistoriaClinica.objInfoIngreso.dtDiagImpresion, PanelJustificacion, txtJustificacion, "Observacion", Not tsinfoguardar.Enabled)
        If tsinfoguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresion, objHistoriaClinica.objInfoIngreso.dtDiagImpresion)
        ElseIf dgvImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Cells("anulardiagevoA").Selected = True And objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.RemoveAt(e.RowIndex)
            ElseIf objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    If modulo = Constantes.HC Then
                        consulta = Consultas.ANULAR_DIAGINFO
                        consulta = consulta & CInt(txtRegistro.Text) & ",'" & objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                    ElseIf modulo = Constantes.AM Then
                        consulta = Consultas.ANULAR_DIAGINFOR
                        consulta = consulta & CInt(txtRegistro.Text) & ",'" & objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                    ElseIf modulo = Constantes.AF Then
                        consulta = Consultas.ANULAR_DIAGINFORR
                        consulta = consulta & CInt(txtRegistro.Text) & ",'" & objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                    End If
                    objHistoriaClinica.objInfoIngreso.elementoAEliminar.Add(consulta)
                    objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.RemoveAt(dgvImpresion.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub txtGestacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartos.KeyPress, txtNacidoV.KeyPress, txtNacidoM.KeyPress, txtGestacion.KeyPress, txtCesarea.KeyPress, txtAbortos.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txtGramos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGramos.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub

    Private Sub tsinfoguardar_Click(sender As Object, e As EventArgs) Handles tsinfoguardar.Click
        ingreso.Focus()
        txtJustificacion_Leave(sender, e)
        txtJustificacionN_Leave(sender, e)
        txtJustificacionR_Leave(sender, e)
        txtJustificacionRN_Leave(sender, e)
        guardarInfoIngreso()
    End Sub

    Private Sub tsenferguardar_Click(sender As Object, e As EventArgs) Handles tsenferguardar.Click
        TabHistoriaC.SelectedIndex = TabHistoriaC.TabPages("enfermeria").TabIndex
        objHistoriaClinica.objEnfermeria.opcionCancelar = False
        Try
            dgvInsumosEnfer.EndEdit()
            dgvGlucometriaEnfer.EndEdit()

            If dgvInsumosEnfer.Enabled = True Then
                If validarEnfermeria() = False Then Exit Sub
                guardarInsumoEnfer()
                opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION
                listaInsumosEnfer.Focus()
            ElseIf txtNotaEnfer.Enabled = True Then
                If txtNotaEnfer.Text.Length > 0 Then
                    guardarNotaEnfer()
                    opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION
                    listaNotasEnfer.Focus()
                Else
                    MsgBox("Por favor diligencie la nota a guardar.", MsgBoxStyle.Information)
                End If
            ElseIf dgvGlucometriaEnfer.Enabled = True Then
                guardarGlucometriaEnfer()
                opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION
                listaGlucometria.Focus()
            End If
            verificarSoat()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub rbambuSI_CheckedChanged(sender As Object, e As EventArgs) Handles rbambuSI.CheckedChanged
        If rbambuSI.Checked = True Then
            btServicioAmb.Enabled = True
        Else
            txtServicioAmb.Clear()
            objHistoriaClinica.objRemision.traslados = ""
            btServicioAmb.Enabled = False
        End If
    End Sub

    Private Sub tsenfercancelar_Click(sender As Object, e As EventArgs) Handles tsenfercancelar.Click
        objHistoriaClinica.objEnfermeria.opcionCancelar = True
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        listarEnfermeria()
    End Sub

    Private Sub tsenfervista_Click(sender As Object, e As EventArgs) Handles tsenfervista.Click
        objHistoriaClinica.objEnfermeria.opcionCancelar = False
        If tsenferguardar.Enabled = True Then
            MsgBox("Por favor guarde la información antes de imprimir.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION AndAlso listaInsumosEnfer.Items.Count < 2 Then
            MsgBox("Este paciente no tiene ordenes de insumos.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION AndAlso listaNotasEnfer.Items.Count < 2 Then
            MsgBox("Este paciente no tiene notas.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION AndAlso listaGlucometria.Items.Count < 2 Then
            MsgBox("Este paciente no tiene Ordenes de glucometrias hechas.", MsgBoxStyle.Information)
            Exit Sub
        End If
        imprimirEnfermeria()
    End Sub

    Private Sub imprimirEnfermeria()
        Try
            Cursor = Cursors.WaitCursor
            tsenfervista.Enabled = False
            objHistoriaClinica.objEnfermeria.registro = nRegistro
            objHistoriaClinica.objEnfermeria.codigoOrden = txtCodigoEnfermeria.Text
            If opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION Then
                objHistoriaClinica.objEnfermeria.imprimirOrdenInsumoEnfer(listaInsumosEnfer.SelectedIndex)
            ElseIf opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION Then
                objHistoriaClinica.objEnfermeria.imprimirNotaEnfer(listaNotasEnfer.SelectedIndex)
            ElseIf opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION Then
                objHistoriaClinica.objEnfermeria.imprimirGlucometria(listaGlucometria.SelectedIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        tsenfervista.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub rboxigenoSI_CheckedChanged(sender As Object, e As EventArgs) Handles rboxigenoSI.CheckedChanged
        If rboxigenoSI.Checked = True Then
            btReferenciaOx.Enabled = True
        Else
            txtReferenciaOx.Clear()
            objHistoriaClinica.objRemision.especialidad = ""
            btReferenciaOx.Enabled = False
        End If
    End Sub

    Private Sub tsordencancelar_Click(sender As Object, e As EventArgs) Handles tsordencancelar.Click
        objHistoriaClinica.objOrdenMedica.opcionCancelar = True
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        objHistoriaClinica.objOrdenMedica.elementoAEliminar.Clear()
        dgvMedicamento.CancelEdit()
        dgvImpregnacion.CancelEdit()
        dgvInfusion.CancelEdit()
        General.deshabilitarControles(ordenes)
        General.deshabilitarBotones_HC(TSOrdenes)
        tsordennuevo.Enabled = True
        PanelJustificacionEstancia.Visible = False
        txtJustificacionEstancia.Clear()
        PanelJustificacionComida.Visible = False
        txtJustificacionComida.Clear()
        PanelJustificacionOxigeno.Visible = False
        txtJustificacionOxigeno.Clear()
        PanelJustificacionParaclinico.Visible = False
        txtJustificacionParaclinico.Clear()
        PanelJustificacionHemoderivado.Visible = False
        txtJustificacionHemoderivado.Clear()
        dgvMezcla_Leave(sender, e)
        gbEstancia.Focus()
        General.limpiarControles(ordenes)
        valoresNutricionPorDefecto()
        mensajeError = ""
        HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_ESTANCIA, objHistoriaClinica.objOrdenMedica.estanciaCargar, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, nRegistro)
        listaordenes.Enabled = True
        listaordenes.SelectedIndex = 0
    End Sub
    Private Sub dgv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvImpresion.KeyPress
        General.abrirJustificacion(dgvImpresion, objHistoriaClinica.objInfoIngreso.dtDiagImpresion, PanelJustificacion, txtJustificacion, "Observacion", Not tsinfoguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub txtJustificacion_Leave(sender As Object, e As EventArgs) Handles txtJustificacion.Leave
        Try
            If PanelJustificacion.Visible = True Then
                PanelJustificacion.Visible = False
                dgvImpresion.Rows(dgvImpresion.CurrentRow.Index).Cells("Observacion").Value = txtJustificacion.Text
                txtJustificacion.Clear()
                objHistoriaClinica.objInfoIngreso.dtDiagImpresion.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub txtJustificacionEVO_Leave(sender As Object, e As EventArgs) Handles txtJustificacionEvo.Leave
        Try
            If PanelJustificacionEvo.Visible = True Then
                PanelJustificacionEvo.Visible = False
                dgvDIAGEVO.Rows(dgvDIAGEVO.CurrentRow.Index).Cells("Observacion").Value = txtJustificacionEvo.Text
                txtJustificacionEvo.Clear()
                objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub txtJustificacionR_Leave(sender As Object, e As EventArgs) Handles txtJustificacionR.Leave
        Try
            If PanelJustificacionR.Visible = True Then
                PanelJustificacionR.Visible = False
                txtJustificacionR.Clear()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub txtJustificacionRN_Leave(sender As Object, e As EventArgs) Handles txtJustificacionRN.Leave
        Try
            If PanelJustificacionRN.Visible = True Then
                PanelJustificacionRN.Visible = False
                txtJustificacionRN.Clear()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvImpresionN.KeyPress
        General.abrirJustificacion(dgvImpresionN, objHistoriaClinica.objInfoIngreso.dtDiagImpresion, PanelJustificacionN, txtJustificacionN, "Observacion", Not tsinfoguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub dgvEVO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvDIAGEVO.KeyPress
        General.abrirJustificacion(dgvDIAGEVO, objHistoriaClinica.objEvolucionMedica.dtDiagnosticos, PanelJustificacionEvo, txtJustificacionEvo, "Observacion", Not tsevoguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub txtJustificacionN_Leave(sender As Object, e As EventArgs) Handles txtJustificacionN.Leave
        Try
            If PanelJustificacionN.Visible = True Then
                PanelJustificacionN.Visible = False
                dgvImpresionN.Rows(dgvImpresionN.CurrentRow.Index).Cells("Observacion").Value = txtJustificacionN.Text
                txtJustificacionN.Clear()
                objHistoriaClinica.objInfoIngreso.dtDiagImpresion.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub cargarConsolidado(pConsolidadoV)
        pConsolidado = pConsolidadoV
        verificarActivoYEdicion()
        servicioNeonatal = General.getEstadoVF(Consultas.AREA_SERVICIO_VERIFICAR & area)
        verificarYCargarOpcDefecto()
        Dim params As New List(Of String)
        params.Add(modulo)
        params.Add(servicioNeonatal)
        params.Add(txtRegistro.Text)
        If IsNothing(objHistoriaClinica) Then
            objHistoriaClinica = New HistoriaClinica(params)
        End If

        nRegistro = txtRegistro.Text
        objHistoriaClinica.nRegistro = nRegistro
    End Sub
    Public Sub guardarAuditor()
        Dim objPrincipal As New Principal
        Try
            objPrincipal.idEmpresa = SesionActual.idEmpresa
            objPrincipal.codigoPerfil = SesionActual.codigoPerfil
            objPrincipal.idEmpleado = SesionActual.idUsuario
            PrincipalDAL.registroAuditorExterno(objPrincipal)
            codigoEntrada = objPrincipal.codigoEntrada
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub tsConsolidado_Click(sender As Object, e As EventArgs) Handles tsConsolidado.Click
        If SesionActual.tienePermiso(pConsolidado) Then
            Cursor = Cursors.WaitCursor
            tsConsolidado.Enabled = False
            tsConsolidado.Text = "Generando..."
            Try
                If (Not IsNothing(objHistoriaClinica.objConsolidado)) AndAlso objHistoriaClinica.objConsolidado.Generando = True Then
                    MsgBox(Mensajes.REPORTE_EN_PROGRESO, MsgBoxStyle.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                ElseIf Not Visible Then
                    ' MsgBox(Mensajes.SEGUNDO_PLANO, MsgBoxStyle.Information)
                End If
                If IsNothing(objHistoriaClinica.objConsolidado) OrElse objHistoriaClinica.objConsolidado.Generando = False Then
                    If (SesionActual.codigoPerfil = Constantes.AMBUQ Or SesionActual.codigoPerfil = Constantes.COMFACOR Or SesionActual.codigoPerfil = Constantes.NUEVA_EPS) Then

                        'If objPrincipal.registro <> 0 Then 'And objPrincipal.registro <> txtRegistro.Text Then
                        'objPrincipal.codigoEntrada = codigoEntrada
                        'PrincipalDAL.salidaAuditorExterno(objPrincipal)
                        'End If
                        guardarAuditor()
                        objPrincipal.codigoEntrada = codigoEntrada
                        objPrincipal.registro = txtRegistro.Text
                        PrincipalDAL.AuditorExternoRegistroPaciente(objPrincipal)
                    End If
                End If

                objHistoriaClinica.crearConsolidado()
                Dim dgv As DataGridView
                If Visible Then
                    pnlConsolidado.Visible = True
                    dgv = dgvConsolidado
                Else
                    fPadre.pnlConsolidado.Visible = True
                    dgv = fPadre.dgvConsolidado
                    'fPadre.GroupBox1.Enabled = False
                End If

                dgv.DataSource = objHistoriaClinica.objConsolidado.dtProcesos
                dgv.Enabled = False
                dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgv.Columns(0).Width = 150
                dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgv.Columns(1).Width = 71
                btOpcionConsolidado.Enabled = True
                objHistoriaClinica.objConsolidado.iniciarProcesos()
                Dim guardarEn2doPlano As Thread
                guardarEn2doPlano = New Thread(AddressOf generarVistaPrevia)
                guardarEn2doPlano.Name = "Generar Vista Previa"
                guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
                guardarEn2doPlano.Start()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsremcancelar_Click(sender As Object, e As EventArgs) Handles tsremcancelar.Click
        objHistoriaClinica.objRemision.opcionCancelar = True
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        General.deshabilitarControles(remisiones)
        General.deshabilitarBotones_HC(TSRemisiones)
        tsremnuevo.Enabled = True
        General.limpiarControles(remisiones)
        Listaremisiones.SelectedIndex = 0
        GroupBoxAnexo9.Focus()
        Listaremisiones.Enabled = True
    End Sub


    Private Sub tsintercancelar_Click(sender As Object, e As EventArgs) Handles tsintercancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        General.deshabilitarControles(interconsultas)
        General.deshabilitarBotones_HC(TSInterconsultas)
        tsinternuevo.Enabled = True
        General.limpiarControles(interconsultas)
        ListaInterconsultas.SelectedIndex = 0
        GroupBoxInfoInterconsulta.Focus()
        ListaInterconsultas.Enabled = True
    End Sub
    Private Sub ListaInterconsultas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListaInterconsultas.SelectedIndexChanged
        Try
            If ListaInterconsultas.DisplayMember = Nothing Then Exit Sub
            If ListaInterconsultas.SelectedIndex = 0 Then
                General.limpiarControles(interconsultas)
                General.deshabilitarBotones_HC(TSInterconsultas)
                tsinternuevo.Enabled = True
            Else
                cargarInterconsulta()
                edicionSegunRegistro(ListaInterconsultas, TSInterconsultas)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub



    Private Sub tsevocancelar_Click(sender As Object, e As EventArgs) Handles tsevocancelar.Click
        objHistoriaClinica.objEvolucionMedica.opcionCancelar = True
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        txtJustificacionEvo.Clear()
        PanelJustificacionEvo.Visible = False
        objHistoriaClinica.objEvolucionMedica.elementoAEliminar.Clear()
        General.deshabilitarControles(evoluciones)
        General.deshabilitarBotones_HC(TSevoluciones)
        tsevonuevo.Enabled = True
        tsevovista.Enabled = True
        General.limpiarControles(evoluciones)
        Listaevoluciones.Enabled = True
        Listaevoluciones.SelectedIndex = 0
        GroupBoxProblemas.Focus()
    End Sub

    Private Sub dgvDIAGEVO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDIAGEVO.CellDoubleClick
        General.abrirJustificacion(dgvDIAGEVO, objHistoriaClinica.objEvolucionMedica.dtDiagnosticos, PanelJustificacionEvo, txtJustificacionEvo, "Observacion", Not tsevoguardar.Enabled)
        If tsevoguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvDIAGEVO.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvDIAGEVO.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvDIAGEVO, objHistoriaClinica.objEvolucionMedica.dtDiagnosticos)
        ElseIf dgvDIAGEVO.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Cells("anulardiagevo").Selected = True And objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows.RemoveAt(e.RowIndex)
            ElseIf objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    If Not String.IsNullOrEmpty(txtcodigoevolucion.Text) Then
                        If modulo = Constantes.HC Then
                            consulta = Consultas.ANULAR_DIAGEVO
                            consulta = consulta & CInt(txtcodigoevolucion.Text) & ",'" & objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                        ElseIf modulo = Constantes.AM Then
                            consulta = Consultas.ANULAR_DIAGEVOR
                            consulta = consulta & CInt(txtcodigoevolucion.Text) & ",'" & objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                        ElseIf modulo = Constantes.AF Then
                            consulta = Consultas.ANULAR_DIAGEVORR
                            consulta = consulta & CInt(txtcodigoevolucion.Text) & ",'" & objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                        End If
                    End If
                    objHistoriaClinica.objEvolucionMedica.elementoAEliminar.Add(consulta)
                    objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows.RemoveAt(dgvDIAGEVO.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub
    Private Sub dgvDIAGEVO_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDIAGEVO.KeyDown
        If tsevoguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows(dgvDIAGEVO.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvDIAGEVO, objHistoriaClinica.objEvolucionMedica.dtDiagnosticos)
        End If
    End Sub
    Private Sub Listaremisiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Listaremisiones.SelectedIndexChanged
        Try
            If Listaremisiones.DisplayMember = Nothing Then Exit Sub
            If Listaremisiones.SelectedIndex = 0 Then
                General.limpiarControles(remisiones)
                General.deshabilitarBotones_HC(TSRemisiones)
                tsremnuevo.Enabled = True
            Else
                cargarRemision()
                edicionSegunRegistro(Listaremisiones, TSRemisiones)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub Listaevoluciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Listaevoluciones.SelectedIndexChanged
        Try
            If Listaevoluciones.DisplayMember = Nothing Then Exit Sub
            If Listaevoluciones.SelectedIndex = 0 Then
                General.limpiarControles(evoluciones)
                General.deshabilitarBotones_HC(TSevoluciones)
                tsevonuevo.Enabled = True
            Else
                cargarEvolucion()
                edicionSegunRegistro(Listaevoluciones, TSevoluciones)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub Form_Historia_clinica_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If validaOpcionGuardar() = False Then
            If validaOpcionGuardar2doPlano() = False Then
                If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
                    'Dim principal As New PrincipalDAL
                    'Dim objForm As Form
                    'For Each objForm In My.Application.OpenForms
                    '    If objForm.GetType = Form_Listado_Paciente.GetType Then
                    '        Dim formPacienteListar As Form_Listado_Paciente = objForm
                    '        formPacienteListar.listarPacienteActual()
                    '    End If
                    'Next
                    Me.Dispose()
                Else
                    e.Cancel = True
                End If
            Else
                e.Cancel = True
                MsgBox(Mensajes.CAMBIOS_2DO_SIN_GUARDAR, MsgBoxStyle.Critical)
            End If
        Else
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function validaOpcionGuardar() As Boolean
        If tsinfoguardar.Enabled = True OrElse tsordenguardar.Enabled = True OrElse tsevoguardar.Enabled = True OrElse
            tsinterguardar.Enabled = True OrElse tsremguardar.Enabled = True OrElse tsfisioguardar.Enabled = True OrElse
            tsenferguardar.Enabled = True OrElse tscuerpoguardar.Enabled = True Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function validaOpcionGuardar2doPlano() As Boolean
        If tsordenvista.Enabled = False OrElse tsevovista.Enabled = False OrElse tsremvista.Enabled = False OrElse
            tsintervista.Enabled = False Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TabHistoriaC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabHistoriaC.SelectedIndexChanged
        Try
            Dim opcionCuerpoMedico As Integer
            If IsNothing(cuerpo.Parent) Then
                opcionCuerpoMedico = -100
            Else
                opcionCuerpoMedico = TabHistoriaC.TabPages("Cuerpo").TabIndex
            End If

            Select Case TabHistoriaC.SelectedTab.TabIndex
                Case TabHistoriaC.TabPages("ordenes").TabIndex
                    If tsordennuevo.Enabled = True Then
                        listarOrdenes()
                    End If
                Case TabHistoriaC.TabPages("evoluciones").TabIndex
                    descripcion_evo.Text = "Paciente " & txtSexo.Text.ToLower & ", " & txtEdad.Text.ToLower & " de edad, con " & objHistoriaClinica.objInfoIngreso.diasEstancia & " días de estancia y diagnostico(s) de:"
                    If tsevonuevo.Enabled = True Then
                        listarEvoluciones()
                        btEstanciaProlongada.Enabled = True
                        btVisorHojaRuta.Enabled = True
                    End If
                Case TabHistoriaC.TabPages("interconsultas").TabIndex
                    If tsinternuevo.Enabled = True Then
                        listarInterconsultas()
                    End If
                Case TabHistoriaC.TabPages("remisiones").TabIndex
                    If tsremnuevo.Enabled = True Then
                        listarRemisiones()
                    End If
                Case TabHistoriaC.TabPages("fisioterapia").TabIndex
                    If tsfisioguardar.Enabled = False Then
                        listarFisioterapia()
                    End If
                Case TabHistoriaC.TabPages("enfermeria").TabIndex
                    If tsenferguardar.Enabled = False Then
                        listarEnfermeria()
                        If objHistoriaClinica.modulo <> Constantes.HC Then
                            btsolitudLab.Visible = False
                        Else
                            btsolitudLab.Enabled = True
                        End If
                    End If
                Case opcionCuerpoMedico
                    If tscuerpoguardar.Enabled = False Then
                        listarCuerpoMedico()
                    End If
                    enlazarCuerpoMedico()
            End Select
            cargarSOAT()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarRemision()
        objHistoriaClinica.objRemision.codigoRemision = Listaremisiones.SelectedValue
        objHistoriaClinica.objRemision.codigoEP = SesionActual.codigoEP
        If Listaremisiones.DataSource.columns.count > 3 Then
            cambiarDiseno(Listaremisiones.DataSource.rows(Listaremisiones.SelectedIndex).item("EDITADO"), txtcodigoRemision)
        End If
        objHistoriaClinica.objRemision.cargarRemision()
        txtcodigoRemision.Text = Listaremisiones.SelectedValue
        If SesionActual.tienePermiso(pCorreo) Then
            If Listaremisiones.Items.Count > 0 Then
                btCorreo.Visible = True
                CheckEnviado.Visible = True
                CheckEnviado.Enabled = False
            Else
                btCorreo.Visible = False
                CheckEnviado.Visible = False
            End If
        Else
            CheckEnviado.Visible = False
        End If

        cargarModalidadApoyo(objHistoriaClinica.objRemision.modalidad)
        txtdatos.Text = objHistoriaClinica.objRemision.datosMedicos
        fechaRemision.Text = objHistoriaClinica.objRemision.fechaRemision
        Comboprioridad.SelectedValue = objHistoriaClinica.objRemision.prioridad
        Combocomplejidad.SelectedValue = objHistoriaClinica.objRemision.complejidad
        txtotras.Text = objHistoriaClinica.objRemision.otras
        txtantecedentes.Text = objHistoriaClinica.objRemision.antecedentes
        txtglasgow.Text = objHistoriaClinica.objRemision.glasgow
        txtdescripglasgow.Text = objHistoriaClinica.objRemision.descripglasgow
        txtpresionsis.Text = objHistoriaClinica.objRemision.presionsis
        txtpresiondias.Text = objHistoriaClinica.objRemision.presiondias
        txtfreccar.Text = objHistoriaClinica.objRemision.freccar
        txtfrecresp.Text = objHistoriaClinica.objRemision.frecresp
        cmbRemisionDestino.SelectedValue = objHistoriaClinica.objRemision.remisionExterna
        If objHistoriaClinica.objRemision.ambulancia = True Then
            rbambuSI.Checked = True
            cargarServicioAmbu(objHistoriaClinica.objRemision.traslados)
        Else
            rbambuNO.Checked = True
            objHistoriaClinica.objRemision.traslados = Constantes.VALOR_PREDETERMINADO
        End If
        If objHistoriaClinica.objRemision.oxigeno = True Then
            rboxigenoSI.Checked = True
            cargarEspecialidad(objHistoriaClinica.objRemision.especialidad)
        Else
            rboxigenoNO.Checked = True
            objHistoriaClinica.objRemision.especialidad = Constantes.VALOR_PREDETERMINADO
        End If
        txtNombreUsuarioInforme.Text = objHistoriaClinica.objRemision.usuarioNombre
        General.deshabilitarControles(remisiones)
        General.deshabilitarBotones_HC(TSRemisiones)
        CheckEnviado.Checked = objHistoriaClinica.objRemision.enviado
        If CheckEnviado.Checked = True Then
            CheckEnviado.Enabled = False

            btCorreo.Enabled = True
            Dim image As Image = My.Resources.Mail_icon
            btCorreo.Image = New Bitmap(image)
        Else
            CheckEnviado.Enabled = False

            btCorreo.Enabled = True
        End If
        Listaremisiones.Enabled = True
        tsremnuevo.Enabled = True
        tsremeditar.Enabled = True
        tsremduplicar.Enabled = True
        tsremanular.Enabled = True
    End Sub
    Private Sub cambiarDiseno(cambiar As Boolean, ByRef txt As ToolStripTextBox)
        If cambiar Then
            txt.ForeColor = Color.Red
        Else
            txt.ForeColor = Color.Black
        End If
    End Sub
    Public Sub cargarOrdenMedica()
        txtCodigoOrden.Text = listaordenes.SelectedValue
        objHistoriaClinica.objOrdenMedica.codigoOrden = txtCodigoOrden.Text
        If listaordenes.DataSource.columns.count > 4 Then
            cambiarDiseno(listaordenes.DataSource.rows(listaordenes.SelectedIndex).item("EDITADO"), txtCodigoOrden)
        End If
        Try
            txtUsuario.Text = listaordenes.DataSource.rows(listaordenes.SelectedIndex).item("Usuario")
            objHistoriaClinica.objOrdenMedica.cargarOrdenMedica()
        Catch ex As Exception
            Label166.Text = "Error 180"
            Throw ex
        End Try

        txtNombreUsuarioInforme.Text = objHistoriaClinica.objOrdenMedica.usuarioNombre
        txtNombreUsuarioOM.Text = objHistoriaClinica.objOrdenMedica.usuarioCreacion
        txtNombreUsuarioOM.ReadOnly = True

        fechaOrdenMedica.Value = objHistoriaClinica.objOrdenMedica.fechaOrden
        txtIndicacion.Text = objHistoriaClinica.objOrdenMedica.indicacion
        Try
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_ESTANCIA, objHistoriaClinica.objOrdenMedica.estanciaCargar, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, nRegistro)
        Catch ex As Exception
            Label166.Text = "Error 1180"
            Throw ex
        End Try
        Try
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_COMIDA, objHistoriaClinica.objOrdenMedica.comidaCargar, objHistoriaClinica.objOrdenMedica.dtComidas, dgvComida, txtCodigoOrden.Text)
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_OXIGENO, objHistoriaClinica.objOrdenMedica.oxigenoCargar, objHistoriaClinica.objOrdenMedica.dtOxigenos, dgvOxigeno, txtCodigoOrden.Text)
        Catch ex As Exception
            Label166.Text = "Error 1181"
            Throw ex
        End Try
        Try
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_PARACLINICO, objHistoriaClinica.objOrdenMedica.paraclinicoCargar, objHistoriaClinica.objOrdenMedica.dtParaclinicos, dgvParaclinico, txtCodigoOrden.Text)
        Catch ex As Exception
            Label166.Text = "Error 1182"
            Throw ex
        End Try
        Try
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_HEMODERIVADO, objHistoriaClinica.objOrdenMedica.hemoderivadoCargar, objHistoriaClinica.objOrdenMedica.dtHemoderivados, dgvHemoderivado, txtCodigoOrden.Text)
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_GLUCOMETRIA, objHistoriaClinica.objOrdenMedica.glucometriaCargar, objHistoriaClinica.objOrdenMedica.dtGlucometrias, dgvGlucometria, txtCodigoOrden.Text)
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_PROCEDIMIENTO, objHistoriaClinica.objOrdenMedica.procedimientoCargar, objHistoriaClinica.objOrdenMedica.dtProcedimientos, dgvProcedimiento, txtCodigoOrden.Text)
        Catch ex As Exception
            Label166.Text = "Error 182"
            Throw ex
        End Try
        Try
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_MEDICAMENTO, objHistoriaClinica.objOrdenMedica.medicamentoCargar, objHistoriaClinica.objOrdenMedica.dtMedicamentos, dgvMedicamento, txtCodigoOrden.Text)
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_IMPREGNACION, objHistoriaClinica.objOrdenMedica.impregnacionCargar, objHistoriaClinica.objOrdenMedica.dtImpregnaciones, dgvImpregnacion, txtCodigoOrden.Text)
            HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_INFUSION, objHistoriaClinica.objOrdenMedica.infusionCargar, objHistoriaClinica.objOrdenMedica.dtInfusiones, dgvInfusion, txtCodigoOrden.Text)
            HistoriaClinicaBLL.cargarMezcla(objHistoriaClinica.objOrdenMedica.mezclaCargar, dgvInfusion, objHistoriaClinica.objOrdenMedica.dsMezcla)
        Catch ex As Exception
            Label166.Text = "Error 183"
            Throw ex
        End Try
        Try
            dgvParaclinico.Columns("dgResultadoPara").DisplayIndex = 6
            cargarNutricion()
            dgvInfusionDisplayIndex()
            dgvImpregnacionDisplayIndex()
            dgvMedicamentoDisplayIndex()
            General.deshabilitarControles(ordenes)
            General.deshabilitarBotones_HC(TSOrdenes)
        Catch ex As Exception
            Label166.Text = "Error 184"
            Throw ex
        End Try
        listaordenes.Enabled = True
        tsordennuevo.Enabled = True
        tsordeneditar.Enabled = True
        tsordenduplicar.Enabled = True
        tsordenanular.Enabled = True
    End Sub
    Sub cargarNutricion()
        Try
            enlazarNutricion()
            objHistoriaClinica.objOrdenMedica.cargarOrdenNutricion()
            ' objHistoriaClinica.objOrdenMedica.objetoNutricion.cargarNutricion()
            If objHistoriaClinica.objOrdenMedica.objetoNutricion.codigoOrden > -1 Then
                NDPesoPacienteNutricion.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.peso
                cmbHoraInicialNutricion.SelectedItem = objHistoriaClinica.objOrdenMedica.objetoNutricion.horaInicial.ToString
                NDTasaHidrica.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.TasaHidrica
                NDFactorAjustes.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.FactorAjustes
                NDAlimentacion.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.alimentacion
                NDMedicacion.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.medicacion
                NDOtros.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.otros
                NDTasaHidricaTotal.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.tht
                NDVolumenTotal.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.volumen
                NDRasarRazon.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.razon
                dgvNutricion.DataSource = objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion
                calcularNutricion()
            Else
                valoresNutricionPorDefecto()
            End If
        Catch ex As Exception
            Label166.Text = "Error 19"
            General.manejoErrores(ex)
        End Try


    End Sub
    Private Sub dgvInfusionDisplayIndex()
        dgvInfusion.Columns("dgMezclaInfu").DisplayIndex = 9
        dgvInfusion.Columns("dgUnidadInfu").DisplayIndex = 3
        dgvInfusion.Columns("anularInfu").DisplayIndex = 14
    End Sub
    Private Sub dgvMedicamentoDisplayIndex()
        dgvMedicamento.Columns("dgUnidadMed").DisplayIndex = 5
        dgvMedicamento.Columns("anularMed").DisplayIndex = 12
    End Sub
    Private Sub dgvImpregnacionDisplayIndex()
        dgvImpregnacion.Columns("dgUnidadImpre").DisplayIndex = 3
        dgvImpregnacion.Columns("anularImpre").DisplayIndex = 13
    End Sub

    Private Sub cargarEvolucion()
        objHistoriaClinica.objEvolucionMedica.codigoEvolucion = Listaevoluciones.SelectedValue
        objHistoriaClinica.objEvolucionMedica.cargarEvolucionMedica()
        txtcodigoevolucion.Text = Listaevoluciones.SelectedValue
        txtUsuario.Text = Listaevoluciones.DataSource.rows(Listaevoluciones.SelectedIndex).item("Usuario")
        If Listaevoluciones.DataSource.columns.count > 4 Then
            cambiarDiseno(Listaevoluciones.DataSource.rows(Listaevoluciones.SelectedIndex).item("EDITADO"), txtcodigoevolucion)
        End If
        TXTSUBJETIVO.Text = objHistoriaClinica.objEvolucionMedica.subjetivo
        TXTSIG_VITALES.Text = objHistoriaClinica.objEvolucionMedica.signoVital
        TXTCAB_CUELLO.Text = objHistoriaClinica.objEvolucionMedica.cabezaCuello
        TXTTORAX.Text = objHistoriaClinica.objEvolucionMedica.torax
        TXTCARDIO.Text = objHistoriaClinica.objEvolucionMedica.cardioPulmonar
        TXTABDOMEN.Text = objHistoriaClinica.objEvolucionMedica.abdomen
        TXTGENTURINARIO.Text = objHistoriaClinica.objEvolucionMedica.genturinario
        TXTEXTREM.Text = objHistoriaClinica.objEvolucionMedica.extremidades
        TXTSNERV.Text = objHistoriaClinica.objEvolucionMedica.sistemaNervioso
        TXTANALISIS.Text = objHistoriaClinica.objEvolucionMedica.analisis
        TXTPLAN.Text = objHistoriaClinica.objEvolucionMedica.planTratamiento
        txtNombreUsuarioInforme.Text = objHistoriaClinica.objEvolucionMedica.usuarioNombre
        txtNombreUsuarioEVO.Text = objHistoriaClinica.objEvolucionMedica.usuarioCreacion
        txtNombreUsuarioEVO.ReadOnly = True
        fechaEvolucion.Text = objHistoriaClinica.objEvolucionMedica.fechaEvolucion
        dgvDIAGEVO.DataSource = objHistoriaClinica.objEvolucionMedica.dtDiagnosticos
        dgvDIAGEVO.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDIAGEVO.Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dgvDIAGEVO.Columns("Observacion").Width = 250
        dgvDIAGEVO.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        For i = 0 To dgvDIAGEVO.ColumnCount - 1
            dgvDIAGEVO.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_PARACLINICO_EVO, objHistoriaClinica.objEvolucionMedica.paraclinicoCargar, objHistoriaClinica.objEvolucionMedica.dtParaclinicos, dgvParaclinicoEvo, txtcodigoevolucion.Text, nRegistro, objHistoriaClinica.objEvolucionMedica.fechaEvolucion)

        General.deshabilitarControles(evoluciones)
        General.deshabilitarBotones_HC(TSevoluciones)
        btEstanciaProlongada.Enabled = True
        Listaevoluciones.Enabled = True
        tsevonuevo.Enabled = True
        tsevoeditar.Enabled = True
        tsevoduplicar.Enabled = True
        tsevoanular.Enabled = True
        dgvDIAGEVO.Columns("anulardiagevo").DisplayIndex = 4
        dgvDIAGEVO.Columns("Estado").Visible = False
        dgvParaclinicoEvo.Columns("Resultado").Visible = False
        dgvParaclinicoEvo.Columns("codigo_orden").Visible = False
        dgvParaclinicoEvo.Columns("obligatorio").Visible = False
        dgvParaclinicoEvo.Columns("dgResultadosParaEvo").DisplayIndex = 8
        dgvParaclinicoEvo.ReadOnly = True
    End Sub

    Private Sub cargarInfoIngreso()
        Try
            Dim objEpicrisis As Epicrisis
            objEpicrisis = GeneralHC.fabricaHC.crear(Constantes.CODIGO_EPICRISIS & Tag.modulo)
            Dim dt As New DataTable
            Dim params As New List(Of String)
            params.Add(nRegistro)
            General.llenarTabla(objEpicrisis.cargaEpicrisis, params, dt)
            objHistoriaClinica.cargarInfoIngreso()
            objHistoriaClinica.objInfoIngreso.codigoEP = SesionActual.codigoEP
            If servicioNeonatal = False Then
                cargarDatosInfoIngresoAdulto()
                If txtEstadoAtencion.Text.ToUpper.Contains("FAC") And SesionActual.tienePermiso(pVisado) Then
                    tsmVisado.Visible = True
                End If
            Else
                cargarDatosInfoIngresoNeonato()
                If txtEstadoAtencionN.Text.ToUpper.Contains("FAC") And SesionActual.tienePermiso(pVisado) Then
                    tsmVisado.Visible = True
                End If
            End If
            If SesionActual.tienePermiso(pEpicrisis) Then
                tssEpicrisis.Visible = dt.Rows.Count > 0
                tsEpicrisis.Visible = dt.Rows.Count > 0
            End If
            txtNombreUsuarioInforme.Text = objHistoriaClinica.objInfoIngreso.usuarioNombre
            codEps = objHistoriaClinica.objInfoIngreso.codEps

            If Not SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                objHistoriaClinica.objInfoIngreso.usuarioReal = SesionActual.idUsuario
                ocultarEspeciales()
            End If
            cargarDiagnosticosRemision()
            cargarDiagnosticosImpresion()
            consultaVisado(GeneralHC.consultaVisado(nRegistro, ConstantesHC.CONSULTAR_VISADO))
            General.deshabilitarControles(ingreso)
            General.deshabilitarBotones_HC(TSinfoingreso)
            tsinfoeditar.Enabled = True
            tsmFormatoIngreso.Enabled = True
            tsHojaIngreso.Enabled = True
            tsEpicrisis.Enabled = True
            tsPrefactura.Enabled = True
            tsConsolidado.Enabled = True
        Catch ex As Exception
            MsgBox("No se encontraron datos.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atención")
        End Try
    End Sub
    Private Sub cargarSOAT()
        verificarSoat()
    End Sub

    Private Sub ocultarEspeciales()
        '------ordenes
        tssOE.Visible = False
        tsordeneditar.Visible = False
        tssOD.Visible = False
        tsordenduplicar.Visible = False
        '------evoluciones
        tssEE.Visible = False
        tsevoeditar.Visible = False
        tssED.Visible = False
        tsevoduplicar.Visible = False
        '------remisiones
        tssEE.Visible = False
        tsevoeditar.Visible = False
        tssED.Visible = False
        tsevoduplicar.Visible = False
        '------remisiones
        tssRE.Visible = False
        tsremeditar.Visible = False
        tssRD.Visible = False
        tsremduplicar.Visible = False
        '------fisioterapias
        tssFE.Visible = False
        tsfisioeditar.Visible = False
        tssFD.Visible = False
        tsfisioduplicar.Visible = False
        '------enfermeria
        tssEnE.Visible = False
        tsenfereditar.Visible = False
        tssEnD.Visible = False
        tsenferduplicar.Visible = False
    End Sub

    Private Sub cargarDatosInfoIngresoNeonato()
        txtEstadoAtencionN.Text = objHistoriaClinica.objInfoIngreso.estadoAtencion
        txtAutorizacionN.Text = objHistoriaClinica.objInfoIngreso.autorizacion
        txtInstitucionN.Text = objHistoriaClinica.objInfoIngreso.institucion
        txtViaIngresoN.Text = objHistoriaClinica.objInfoIngreso.viaIngreso
        txtCausaExternaN.Text = objHistoriaClinica.objInfoIngreso.causaExterna
        txtCamaN.Text = objHistoriaClinica.objInfoIngreso.cama
        txtGramos.Text = objHistoriaClinica.objInfoIngreso.peso
        txtPesoU.Text = objHistoriaClinica.objInfoIngreso.pesoUltimo
        txtAnamnesisN.Text = objHistoriaClinica.objInfoIngreso.motivo
        txtTipoParto.Text = objHistoriaClinica.objInfoIngreso.tParto
        txtTRupturaM.Text = objHistoriaClinica.objInfoIngreso.tRupturaM
        txtInduccionP.Text = objHistoriaClinica.objInfoIngreso.induccionParto
        txtCaractLiquidoN.Text = objHistoriaClinica.objInfoIngreso.caracteristicasLiquidas
        txtApgar1N.Text = objHistoriaClinica.objInfoIngreso.apgar1
        txtApgar2.Text = objHistoriaClinica.objInfoIngreso.apgar5
        txtRmacionN.Text = objHistoriaClinica.objInfoIngreso.reanimacion
        txtEdadMadreN.Text = objHistoriaClinica.objInfoIngreso.edadMadre
        txtEdadGestN.Text = objHistoriaClinica.objInfoIngreso.edadGestacional
        txtFumN.Text = objHistoriaClinica.objInfoIngreso.fumador
        txtObstetricosN.Text = objHistoriaClinica.objInfoIngreso.antecedentesObstetricos
        txtHemMN.Text = objHistoriaClinica.objInfoIngreso.hemoclasificacionMadre
        txtHemPN.Text = objHistoriaClinica.objInfoIngreso.hemoclasificacionPadre
        txtControlPN.Text = objHistoriaClinica.objInfoIngreso.control
        txtMedDurEmbN.Text = objHistoriaClinica.objInfoIngreso.medicamentos
        txtHabitosN.Text = objHistoriaClinica.objInfoIngreso.habito
        txtInfeccionesN.Text = objHistoriaClinica.objInfoIngreso.infeccion
        txtDiabeteGN.Text = objHistoriaClinica.objInfoIngreso.diabeteG
        txtDiabeteMN.Text = objHistoriaClinica.objInfoIngreso.diabeteM
        txtHiperGN.Text = objHistoriaClinica.objInfoIngreso.hipertencion
        txtPreeclampciaN.Text = objHistoriaClinica.objInfoIngreso.preclampcia
        txtEnferTN.Text = objHistoriaClinica.objInfoIngreso.enfermedad
        txtVacunacionN.Text = objHistoriaClinica.objInfoIngreso.vacunacion
        txtTorch.Text = objHistoriaClinica.objInfoIngreso.torch
        txtHemoclasificacionN.Text = objHistoriaClinica.objInfoIngreso.hemoclasificacion
        txtVDRLN.Text = objHistoriaClinica.objInfoIngreso.vdrl
        txtTSHN.Text = objHistoriaClinica.objInfoIngreso.tsh
        txtGlucometriasN.Text = objHistoriaClinica.objInfoIngreso.glucometria
        txtGeneralesN.Text = objHistoriaClinica.objInfoIngreso.generales
        txtSig_vitalesN.Text = objHistoriaClinica.objInfoIngreso.signosVitales
        txtCab_cuelloN.Text = objHistoriaClinica.objInfoIngreso.cabezaYCuello
        txtToraxN.Text = objHistoriaClinica.objInfoIngreso.torax
        txtCardioN.Text = objHistoriaClinica.objInfoIngreso.cardio
        txtAbdomenN.Text = objHistoriaClinica.objInfoIngreso.abdomen
        txtGenitoN.Text = objHistoriaClinica.objInfoIngreso.gentoUrinario
        txtExtremidadesN.Text = objHistoriaClinica.objInfoIngreso.extremidades
        txtS_NervN.Text = objHistoriaClinica.objInfoIngreso.sistemaNervioso
        txtAnalisisN.Text = objHistoriaClinica.objInfoIngreso.analisis
        txtPronosticoN.Text = objHistoriaClinica.objInfoIngreso.pronostico
        txtNombreUsuarioINFN.Text = objHistoriaClinica.objInfoIngreso.usuarioCreacion
        txtNombreUsuarioINFN.ReadOnly = True
    End Sub

    Private Sub cargarDatosInfoIngresoAdulto()
        txtEstadoAtencion.Text = objHistoriaClinica.objInfoIngreso.estadoAtencion
        txtAutorizacion.Text = objHistoriaClinica.objInfoIngreso.autorizacion
        txtInstitucion.Text = objHistoriaClinica.objInfoIngreso.institucion
        txtViaIngreso.Text = objHistoriaClinica.objInfoIngreso.viaIngreso
        txtCausaExterna.Text = objHistoriaClinica.objInfoIngreso.causaExterna
        txtCama.Text = objHistoriaClinica.objInfoIngreso.cama
        txtPeso.Text = objHistoriaClinica.objInfoIngreso.peso
        txtPesoU.Text = objHistoriaClinica.objInfoIngreso.pesoUltimo
        txtAnamnesis.Text = objHistoriaClinica.objInfoIngreso.motivo
        txtAnteM.Text = objHistoriaClinica.objInfoIngreso.antecedentes
        txtAnteQ.Text = objHistoriaClinica.objInfoIngreso.antecedentesQuirurgicos
        txtAnteT.Text = objHistoriaClinica.objInfoIngreso.antecedentesTraumaticos
        txtAnteTr.Text = objHistoriaClinica.objInfoIngreso.antecedentesTransfusionales
        txtAnteA.Text = objHistoriaClinica.objInfoIngreso.antecedentesAlergicos
        txtAnteTo.Text = objHistoriaClinica.objInfoIngreso.antecedentesToxicos
        txtAnteF.Text = objHistoriaClinica.objInfoIngreso.antecedentesFamiliares
        txtRevision.Text = objHistoriaClinica.objInfoIngreso.revisionSistema
        txtInfoSigV.Text = objHistoriaClinica.objInfoIngreso.signosVitales
        txtInfoCabCu.Text = objHistoriaClinica.objInfoIngreso.cabezaYCuello
        txtInfoTorax.Text = objHistoriaClinica.objInfoIngreso.torax
        txtInfoCardio.Text = objHistoriaClinica.objInfoIngreso.cardio
        txtInfoAbdomen.Text = objHistoriaClinica.objInfoIngreso.abdomen
        txtInfoGenito.Text = objHistoriaClinica.objInfoIngreso.gentoUrinario
        txtInfoExtrem.Text = objHistoriaClinica.objInfoIngreso.extremidades
        txtInfoSNerv.Text = objHistoriaClinica.objInfoIngreso.sistemaNervioso
        txtInfoParaclinico.Text = objHistoriaClinica.objInfoIngreso.paraclinico
        txtInfoAnalisis.Text = objHistoriaClinica.objInfoIngreso.analisis
        txtInfoPronos.Text = objHistoriaClinica.objInfoIngreso.pronostico
        txtNombreUsuarioINF.Text = objHistoriaClinica.objInfoIngreso.usuarioCreacion
        txtNombreUsuarioINF.ReadOnly = True
    End Sub

    Private Sub cargarInterconsulta()
        Dim dt As New DataTable
        Dim codigos As String()
        codigos = Split(ListaInterconsultas.Text, " | ")
        TXTCODIGOINTERCONSULTA.Text = ListaInterconsultas.SelectedValue
        procedimientoInterconsulta = codigos(1)
        objHistoriaClinica.objInterconsulta.codigoEP = SesionActual.codigoEP
        objHistoriaClinica.objInterconsulta.codigoOrden = TXTCODIGOINTERCONSULTA.Text
        objHistoriaClinica.objInterconsulta.codigoProcedimiento = procedimientoInterconsulta
        objHistoriaClinica.objInterconsulta.cargarInterconsultaMedica()
        txtInterconsultante.Text = objHistoriaClinica.objInterconsulta.Interconsultante
        txtInterconsultado.Text = objHistoriaClinica.objInterconsulta.Interconsultado
        txtMotivo.Text = objHistoriaClinica.objInterconsulta.Motivo
        txtRespuesta.Text = objHistoriaClinica.objInterconsulta.Respuesta
        fechaInterconsulta.Text = objHistoriaClinica.objInterconsulta.fechaInterconsulta
        txtNombreUsuarioInforme.Text = objHistoriaClinica.objInterconsulta.usuarioNombre
        txtNombreUsuarioINT.Text = objHistoriaClinica.objInterconsulta.usuarioCreacion
        txtNombreUsuarioINT.ReadOnly = True
        General.deshabilitarControles(interconsultas)
        General.deshabilitarBotones_HC(TSInterconsultas)
        ListaInterconsultas.Enabled = True
        tsinternuevo.Enabled = True
        tsintereditar.Enabled = True
        tsinteranular.Enabled = True
    End Sub

    Private Sub cargarDiagnosticosRemision()
        objHistoriaClinica.objInfoIngreso.cargarDetalleRemision()
        If servicioNeonatal = False Then
            dgvdiagRem.DataSource = objHistoriaClinica.objInfoIngreso.dtDiagRemision
            dgvdiagRem.Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvdiagRem.Columns("Observacion").Width = 250
            dgvdiagRem.Columns("Observacion").HeaderText = "Observación"
            dgvdiagRem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvdiagRem.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            For i = 0 To dgvdiagRem.ColumnCount - 1
                dgvdiagRem.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            dgvdiagRemN.DataSource = objHistoriaClinica.objInfoIngreso.dtDiagRemision
            dgvdiagRemN.Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvdiagRemN.Columns("Observacion").Width = 250
            dgvdiagRemN.Columns("Observacion").HeaderText = "Observación"
            dgvdiagRemN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvdiagRemN.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            For i = 0 To dgvdiagRemN.RowCount - 1
                dgvdiagRemN.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If

    End Sub
    Private Sub cargarDiagnosticosImpresion()
        objHistoriaClinica.objInfoIngreso.cargarDetalleImpresion()
        If servicioNeonatal = False Then
            dgvImpresion.DataSource = objHistoriaClinica.objInfoIngreso.dtDiagImpresion
            dgvImpresion.Columns("Estado").Visible = False
            dgvImpresion.Columns("anulardiagevoA").DisplayIndex = 4
            dgvImpresion.Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvImpresion.Columns("Observacion").Width = 250
            dgvImpresion.Columns("Observacion").HeaderText = "Observación"
            dgvImpresion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvImpresion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            For i = 0 To dgvImpresion.ColumnCount - 1
                dgvImpresion.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            dgvImpresionN.DataSource = objHistoriaClinica.objInfoIngreso.dtDiagImpresion
            dgvImpresionN.Columns("Estado").Visible = False
            dgvImpresionN.Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvImpresionN.Columns("Observacion").Width = 250
            dgvImpresionN.Columns("Observacion").HeaderText = "Observación"
            dgvImpresionN.Columns("anulardiagevoN").DisplayIndex = 4
            dgvImpresionN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvImpresionN.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            For i = 0 To dgvImpresionN.ColumnCount - 1
                dgvImpresionN.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If
        For I = 0 To objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.Count - 1
            objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows(I).Item("Estado") = Constantes.ITEM_CARGADO
        Next
    End Sub
    Private Sub edicionSegunRegistro(ByRef lista As ListBox, ByRef barraOpciones As ToolStrip)

        If lista.DataSource.rows(lista.SelectedIndex).item("N_Registro").ToString <> nRegistro Then

            For i = 0 To barraOpciones.Items.Count - 1
                If lista.Name.Contains("ordenes") Then
                    Dim params As New List(Of String)
                    params.Add(lista.DataSource.rows(lista.SelectedIndex).item("Codigo_Orden").ToString)
                    If Not IsNothing(cuerpo.Parent) AndAlso
                        General.getEstadoVF(ConsultasHC.ORDEN_PROCEDIMIENTO_HEMO_VERIFICAR, params) Then
                        Exit For
                    End If
                End If

                If (barraOpciones.Items(i).Text.Contains("Editar") OrElse barraOpciones.Items(i).Text.Contains("Anular")) Then
                    barraOpciones.Items(i).Enabled = False
                End If
            Next
        End If
    End Sub

    Private Sub listarOrdenes()

        valoresNutricionPorDefecto()
        objHistoriaClinica.cargarOrden(listaordenes)
        listaordenes.SelectedIndex = 0
        HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_ESTANCIA, objHistoriaClinica.objOrdenMedica.estanciaCargar, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, nRegistro)
        agregarPerfilesParaclinicos()

    End Sub

    Private Sub agregarPerfilesParaclinicos()
        Dim objAsigPerfil As New ConfiguracionPerfilParaclinico
        objAsigPerfil.codigoAreaServicio = area
        objAsigPerfil.llenarTablaBotones()
        Dim btn As Button
        Dim i As Integer
        Dim cont As Integer = 0
        Dim X As Double = 10
        Dim Y As Double = -1
        For i = 0 To objAsigPerfil.dtBotonesParaclinicos.Rows.Count - 1
            btn = New Button
            btn.Name = "btn" + Trim(objAsigPerfil.dtBotonesParaclinicos.Rows(i).Item(1))
            btn.Text = objAsigPerfil.dtBotonesParaclinicos.Rows(i).Item(1)
            btn.Font = New Font("Microsoft Sans Serif", 6, FontStyle.Bold)
            btn.Tag = objAsigPerfil.dtBotonesParaclinicos.Rows(i).Item(0)
            Dim tamaño As Integer = Len(btn.Text) * Int(btn.Font.Size) + 20
            btn.SetBounds(X, Y, tamaño, 23)
            btn.Visible = True
            btn.Enabled = False
            X = X + tamaño + 5
            cont = i
            If i = 10 Then
                cont = 0
                X = 10
                Y = Y + 24
            End If
            Panel8.Controls.Add(btn)
            AddHandler btn.Click, AddressOf APerfil
        Next
    End Sub

    Sub APerfil(sender As Object, e As EventArgs)
        agregarPerfil(CType(sender, Windows.Forms.Button).Tag, CType(sender, Windows.Forms.Button).Text)
    End Sub
    Private Sub listarEvoluciones()
        If IsNothing(dgvParaclinicoEvo.DataSource) Then
            HistoriaClinicaBLL.enlazarTabla(dgvParaclinicoEvo, objHistoriaClinica.objEvolucionMedica.dtParaclinicos, Constantes.OM_PARACLINICO_EVO)
        End If
        dgvParaclinicoEvo.Columns("Resultado").Visible = False
        objHistoriaClinica.cargarEvolucion(Listaevoluciones)
        objHistoriaClinica.objEvolucionMedica.codigoEP = SesionActual.codigoEP
        Listaevoluciones.SelectedIndex = 0
    End Sub
    Private Sub listarInterconsultas()
        objHistoriaClinica.cargarInterconsulta(ListaInterconsultas)
        ListaInterconsultas.SelectedIndex = 0
        ListaInterconsultas.Enabled = True
        GroupBoxInfoInterconsulta.Focus()
    End Sub
    Private Sub listarRemisiones()
        objHistoriaClinica.cargarRemision(Listaremisiones)
        Listaremisiones.SelectedIndex = 0
        GroupBoxAnexo9.Focus()
    End Sub
    Private Sub listaGlucometria_Click(sender As Object, e As EventArgs) Handles listaGlucometria.Click
        opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION
        tsenferNuevo.Enabled = False
    End Sub

    Private Sub listarFisioterapia()
        General.limpiarControles(fisioterapia)
        opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION
        txtCodigoFisioterapia.Clear()
        HistoriaClinicaBLL.configurarDgvoxigeno(dgvOxigenoFisio, objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno)
        cargarOxigeno()
        objHistoriaClinica.cargarFisioterapia()

        GeneralHC.cargarListBox(listaTerapias, objHistoriaClinica.objFisioterapia.listTerapiaFyR, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaInsumosfisio, objHistoriaClinica.objFisioterapia.listInsumo, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaNotasfisio, objHistoriaClinica.objFisioterapia.listNota, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaOxigeno, objHistoriaClinica.objFisioterapia.listOxigeno, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaNebulizacion, objHistoriaClinica.objFisioterapia.listNebulizacion, "Nombre", "Codigo_orden")
        If Not IsNothing(dgvInsumosFisio.DataSource) Then
            dgvInsumosFisio.DataSource.clear
        End If
        dgvInsumosFisio.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        txtNotaFisio.Clear()
        General.deshabilitarControles(fisioterapia)
        General.deshabilitarBotones_HC(TSFisioterapias)
        habilitarGroupBoxFisio()
        tsfisionuevo.Enabled = True
        tsfisioeditar.Enabled = True
        listaOxigeno.Focus()
    End Sub
    Private Sub listaGlucometria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaGlucometria.SelectedIndexChanged
        Try
            If listaGlucometria.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaGlucometria.SelectedIndex) Then
                txtCodigoEnfermeria.Clear()
                If Not IsNothing(dgvGlucometriaEnfer.DataSource) Then
                    dgvGlucometriaEnfer.DataSource.clear
                End If
                dgvGlucometriaEnfer.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
                tsenferduplicar.Enabled = False
                tsenfereditar.Enabled = False
                tsenferanular.Enabled = False
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                cargarGlucomEnfer()
                edicionSegunRegistro(listaGlucometria, TSEnfermeria)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvGlucometriaEnfer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlucometriaEnfer.CellDoubleClick
        General.abrirJustificacion(dgvGlucometriaEnfer, objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer, Panel7, txtDosisInsulina, "dgDosisInsulina", Not tsenferguardar.Enabled)
    End Sub
    Private Sub dgvGlucometriaEnfer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvGlucometriaEnfer.KeyPress
        General.abrirJustificacion(dgvGlucometriaEnfer, objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer, Panel7, txtDosisInsulina, "dgDosisInsulina", Not tsenferguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub txtDosisInsulina_Leave(sender As Object, e As EventArgs) Handles txtDosisInsulina.Leave
        Try
            If Panel7.Visible = True Then
                Panel7.Visible = False
                dgvGlucometriaEnfer.Rows(dgvGlucometriaEnfer.CurrentRow.Index).Cells("dgDosisInsulina").Value = txtDosisInsulina.Text
                txtDosisInsulina.Clear()
                objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvGlucometriaEnfer_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvGlucometriaEnfer.EditingControlShowing
        If dgvGlucometriaEnfer.Rows(dgvGlucometriaEnfer.CurrentCell.RowIndex).Cells("dgHoraDia").Selected = True _
            OrElse dgvGlucometriaEnfer.Rows(dgvGlucometriaEnfer.CurrentCell.RowIndex).Cells("dgGlicemia").Selected = True Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        Else
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarAlfanumerico
        End If
    End Sub
    Private Sub dgvGlucometriaEnfer_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlucometriaEnfer.CellEndEdit
        objHistoriaClinica.objEnfermeria.objGlucomEnfer.empresa = SesionActual.idEmpresa
        HistoriaClinicaBLL.algunaValidaciones(dgvGlucometriaEnfer, objHistoriaClinica, e.ColumnIndex, e.RowIndex, fechaEnfermeria.Value)
    End Sub
    Private Sub listarEnfermeria()
        'General.limpiarControles(enfermeria)
        General.deshabilitarControles(enfermeria)
        opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION
        txtCodigoEnfermeria.Clear()
        objHistoriaClinica.cargarEnfermeria()
        GeneralHC.cargarListBox(listaInsumosEnfer, objHistoriaClinica.objEnfermeria.listInsumo, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaNotasEnfer, objHistoriaClinica.objEnfermeria.listNota, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaGlucometria, objHistoriaClinica.objEnfermeria.listGlucometria, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaParaclinicos, objHistoriaClinica.objEnfermeria.listExamenes, "Nombre", "Codigo_orden")
        GeneralHC.cargarListBox(listaHemoderivados, objHistoriaClinica.objEnfermeria.listExamenesHemo, "Nombre", "Codigo_orden")
        If Not IsNothing(dgvInsumosEnfer.DataSource) Then
            dgvInsumosEnfer.DataSource.clear
        ElseIf Not IsNothing(dgvGlucometriaEnfer.DataSource) Then
            dgvGlucometriaEnfer.DataSource.clear
        End If

        txtNotaEnfer.Clear()


        General.deshabilitarBotones_HC(TSEnfermeria)
        habilitarGroupBoxEnfer()
        tsenferNuevo.Enabled = True
        listaInsumosEnfer.Focus()
    End Sub

    Private Sub listarCuerpoMedico()
        Dim i As Integer
        Dim params As New List(Of String)
        Dim objCuerpo = objHistoriaClinica.objCuerpoMedico
        General.limpiarControles(cuerpo)
        objHistoriaClinica.cargarCuerpoMedico()
        GeneralHC.cargarListBox(listaProcedimientos, objCuerpo.dtProcedimientos, "Nombre_Procedimiento", "Codigo_Procedimiento")
        If listaProcedimientos.SelectedIndex <> 0 Then
            objCuerpo.CodigoOrden = objCuerpo.dtProcedimientos.Rows(listaProcedimientos.SelectedIndex - 1).Item(0)
        End If
        txtCantidad.Text = listaProcedimientos.Items.Count - 1
        txtTotal.Text = FormatCurrency(0)
        For i = 1 To listaProcedimientos.Items.Count - 1
            objCuerpo.Codigo = objCuerpo.dtProcedimientos.Rows(i - 1).Item("Codigo_Procedimiento")
            objCuerpo.CodigoOrden = objCuerpo.dtProcedimientos.Rows(i - 1).Item("Codigo_Orden")
            calcularTotal()
        Next

    End Sub
    Private Sub enlazarCuerpoMedico()
        Dim colIdentificador, colDescripcion, colIdEmpleado, colNombreEmpleado, colValor As New DataColumn

        colIdentificador.ColumnName = "Identificador"
        colIdentificador.DataType = Type.GetType("System.String")
        dtParticipantes.Columns.Add(colIdentificador)

        colDescripcion.ColumnName = "Descripcion"
        colDescripcion.DataType = Type.GetType("System.String")
        dtParticipantes.Columns.Add(colDescripcion)

        colIdEmpleado.ColumnName = "idEmpleado"
        colIdEmpleado.DataType = Type.GetType("System.Int32")
        dtParticipantes.Columns.Add(colIdEmpleado)

        colNombreEmpleado.ColumnName = "Nombre"
        colNombreEmpleado.DataType = Type.GetType("System.String")
        dtParticipantes.Columns.Add(colNombreEmpleado)

        colValor.ColumnName = "Valor"
        colValor.DataType = Type.GetType("System.Double")
        colValor.DefaultValue = 0
        dtParticipantes.Columns.Add(colValor)

        With dgvCuerpoM
            .Columns.Item("dgIdentificador").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgIdentificador").DataPropertyName = "Identificador"

            .Columns.Item("dgParticipante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgParticipante").DataPropertyName = "Descripcion"
            .Columns.Item("dgParticipante").ReadOnly = True

            .Columns.Item("dgIdEmpleado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgIdEmpleado").DataPropertyName = "idEmpleado"

            .Columns.Item("dgNombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgNombre").DataPropertyName = "Nombre"
            .Columns.Item("dgNombre").ReadOnly = True

            .Columns.Item("dgValor").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgValor").DataPropertyName = "Valor"
            .Columns.Item("dgValor").ReadOnly = True

            .Columns.Item("anular").ReadOnly = True
            .Columns.Item("anular").Width = 80
        End With
        dgvCuerpoM.DataSource = dtParticipantes
        dgvCuerpoM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCuerpoM.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Function validarOrdenMedica() As Boolean
        Try
            If mensajeError <> "" Then
                If mensajeError <> Mensajes.CANTIDAD_VALIDA AndAlso
                    mensajeError <> Mensajes.FALTA_ESTANCIA AndAlso
                    mensajeError <> Mensajes.MAYOR_REGISTRO_ESTANCIA AndAlso
                    mensajeError <> Mensajes.JUSTIFICAR_ESTANCIA AndAlso
                    mensajeError <> Mensajes.FECHA_MAYOR_EPICRISIS AndAlso
                    mensajeError <> Mensajes.CANTIDAD_VALIDA AndAlso
                    mensajeError <> Mensajes.COMIDA_NO_SELECCIONADA AndAlso
                    mensajeError <> Mensajes.HORA_INICIO_MED_INVALIDA AndAlso
                    mensajeError <> Mensajes.HORA_INICIO_IMP_INVALIDA AndAlso
                    mensajeError <> Mensajes.HORA_INICIO_INF_INVALIDA AndAlso
                    mensajeError <> Mensajes.OXIGENO_INCORRECTO AndAlso
                    mensajeError <> Mensajes.PESO_INVALIDO AndAlso
                    mensajeError <> Mensajes.HORARIO_INVALIDO AndAlso
                    mensajeError <> Mensajes.CANTIDAD_DE_AGUA_INVALIDA AndAlso
                    mensajeError <> Mensajes.HORA_INICIO_INVALIDA AndAlso
                    mensajeError <> Mensajes.JUSTIFICACION_TERAPIA_FISICA Then

                    If mensajeError.Contains(Mensajes.COMIDA_HORA_NO_PERMITIDA) = True Then
                        mensajeError = ""
                    Else
                        If mensajeError <> Mensajes.INTERVALO_MAYOR_HORAS And
                           mensajeError <> Mensajes.INTERMEDIO_MAYOR_HORAS And
                           mensajeError <> Mensajes.FECHA_MAYOR_PERMITIDA Then
                            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                        End If

                        If fechaOrdenMedica.Focused = True Then
                            fechaOrdenMedica.Focus()
                        ElseIf dgvEstancia.Focused = True Then
                            dgvEstancia.Focus()
                        End If
                        Return False
                    End If


                Else
                    mensajeError = ""
                End If


            ElseIf (Not IsDate(fechaOrdenMedica.Text)) Then
                MsgBox("La fecha de la orden no es valida. Por favor, corrijala.", MsgBoxStyle.Exclamation)
                fechaOrdenMedica.Focus()
                Return False
            End If
            If IsNothing(cuerpo.Parent) Then
                mensajeError = HistoriaClinicaBLL.verificarEstancia(modulo, objHistoriaClinica.objInfoIngreso.diasEstancia, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, True, nRegistro)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Return False
                End If
            End If
            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvHemoderivado)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvParaclinico)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvGlucometria)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvProcedimiento)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            ' -- Cambios en justifcación de las terapias fisicas
            mensajeError = HistoriaClinicaBLL.verificarJustificacionTerapiaFisica(dgvProcedimiento)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvMedicamento)

            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            For i = 0 To dgvMedicamento.RowCount - 2
                If dgvMedicamento.Rows(i).Cells("dgHorarioMed").Value = Constantes.ITEM_dgv_SELECCIONE Then
                    mensajeError = Mensajes.HORARIO_INVALIDO
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next

            If objHistoriaClinica.objOrdenMedica.verificarHoraAplicacion(objHistoriaClinica.objOrdenMedica.dtMedicamentos, CDate(txtAdmision.Text)) Then
                mensajeError = Mensajes.HORA_INICIO_MED_INVALIDA
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If

            If objHistoriaClinica.objOrdenMedica.verificarHoraAplicacion(objHistoriaClinica.objOrdenMedica.dtImpregnaciones, CDate(txtAdmision.Text)) Then
                mensajeError = Mensajes.HORA_INICIO_IMP_INVALIDA
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            If objHistoriaClinica.objOrdenMedica.verificarHoraAplicacion(objHistoriaClinica.objOrdenMedica.dtInfusiones, CDate(txtAdmision.Text)) Then
                mensajeError = Mensajes.HORA_INICIO_INF_INVALIDA
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If

            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvImpregnacion)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvInfusion)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If
            If IsNothing(cuerpo.Parent) Then
                mensajeError = HistoriaClinicaBLL.verificarEstanciaPost(modulo, nRegistro, CDate(txtAdmision.Text).Date, dgvEstancia, CDate(fechaOrdenMedica.Text).Date)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Return False
                End If
            End If

            If HistoriaClinicaBLL.GetNumeroMedicamentosOrdenadosNutricion(objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion) > 0 Then
                mensajeError = HistoriaClinicaBLL.validarHorarioEInicio(cmbHoraInicialNutricion)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Return False
                End If
                mensajeError = HistoriaClinicaBLL.PesoPacienteRequerido(NDPesoPacienteNutricion)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Return False
                End If
                mensajeError = HistoriaClinicaBLL.volumenAguaDestiladaValida(NDAguaDestilada)
                If mensajeError <> "" Then
                    MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                    Return False
                End If

            End If
            Dim cantidadOxigenosSuspendidos As Integer = HistoriaClinicaBLL.verificarNumerosSuspendidos(objHistoriaClinica.objOrdenMedica.dtOxigenos)
            If cantidadOxigenosSuspendidos > 1 OrElse (cantidadOxigenosSuspendidos = 0 AndAlso objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows.Count > 2) Then
                mensajeError = Mensajes.OXIGENO_INCORRECTO
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                Return False
            End If

            mensajeError = HistoriaClinicaBLL.verificarSeleccionComida(dgvComida)
            If mensajeError <> "" Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                For i = 0 To dgvComida.RowCount - 2
                    If dgvComida.Rows(i).Cells("dgDesayuno").Value = False AndAlso
                        dgvComida.Rows(i).Cells("dgAlmuerzo").Value = False AndAlso
                        dgvComida.Rows(i).Cells("dgCena").Value = False Then
                        dgvComida.Rows(i).Cells("dgDesayuno").Selected = True
                        Exit For
                    End If
                Next
                Return False
            End If
            If agregaMedicamentoAutomatico() Then
                MsgBox(Mensajes.MEDICAMENTOS_AUTOMATICOS, MsgBoxStyle.Information)
                dgvMedicamento.Focus()
                Return False
            End If
            agregarProcedimientoAutomatico()
            If agregaMedicamentoAutomaticoAuditoria() Then
                dgvMedicamento.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Label167.Text = "1000"
            Throw ex
        End Try

    End Function
    Private Function validarFisioterapia() As Boolean
        If dgvInsumosFisio.RowCount < 2 Then
            MsgBox("¡Orden vacia, seleccione un insumo!", MsgBoxStyle.Exclamation)
            Return False
        End If
        If mensajeError <> "" Then
            If mensajeError <> Mensajes.CANTIDAD_VALIDA Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                If fechaFisioterapia.Focused = True Then
                    fechaFisioterapia.Focus()
                ElseIf dgvInsumosFisio.Focused = True Then
                    dgvInsumosFisio.Focus()
                End If
                Return False
            Else
                mensajeError = ""
            End If
        ElseIf (Not IsDate(fechaFisioterapia.Text)) Then
            MsgBox("¡La fecha de la orden no es valida. Por favor, corrijala!", MsgBoxStyle.Exclamation)
            fechaFisioterapia.Focus()
            Return False
        End If
        mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvInsumosFisio)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Function validarEnfermeria() As Boolean
        If dgvInsumosEnfer.RowCount < 2 Then
            MsgBox("¡Orden vacia, seleccione un insumo!", MsgBoxStyle.Exclamation)
            Return False
        End If
        If mensajeError <> "" Then
            If mensajeError <> Mensajes.CANTIDAD_VALIDA Then
                MsgBox(mensajeError, MsgBoxStyle.Exclamation)
                If fechaEnfermeria.Focused = True Then
                    fechaEnfermeria.Focus()
                ElseIf dgvInsumosEnfer.Focused = True Then
                    dgvInsumosEnfer.Focus()
                End If
                Return False
            Else
                mensajeError = ""
            End If


        ElseIf (Not IsDate(fechaEnfermeria.Text)) Then
            MsgBox("La fecha de la orden no es valida. Por favor, corrijala.", MsgBoxStyle.Exclamation)
            fechaEnfermeria.Focus()
            Return False
        End If
        mensajeError = HistoriaClinicaBLL.verificarValorPermitido(dgvInsumosEnfer)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Sub guardarOrdenMedica()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                tsordenvista.Enabled = False
                Dim paramsDgv As New List(Of DataGridView)
                paramsDgv.Add(dgvInfusion)
                paramsDgv.Add(dgvHemoderivado)
                paramsDgv.Add(dgvProcedimiento)
                paramsDgv.Add(dgvMedicamento)
                paramsDgv.Add(dgvImpregnacion)
                paramsDgv.Add(dgvMezcla)
                paramsDgv.Add(dgvParaclinico)
                objHistoriaClinica.objOrdenMedica.usuario = usuarioActual
                usuarioInformeTemporal = objHistoriaClinica.objOrdenMedica.usuarioReal
                objHistoriaClinica.objOrdenMedica.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objOrdenMedica.fechaOrden = fechaOrdenMedica.Value
                objHistoriaClinica.objOrdenMedica.indicacion = txtIndicacion.Text
                Try
                    HistoriaClinicaBLL.guardarOrdenMedica(objHistoriaClinica.objOrdenMedica, paramsDgv)
                Catch ex As Exception
                    Label167.Text = "1001"
                    Throw ex
                End Try
                If listaordenes.SelectedIndex = 0 Then
                    nRegistroTemporal = nRegistro
                Else
                    nRegistroTemporal = listaordenes.DataSource.rows(listaordenes.SelectedIndex).item("N_Registro").ToString
                End If

                'guardarInforme(Constantes.REMISION)
                txtCodigoOrden.Text = objHistoriaClinica.objOrdenMedica.codigoOrden
                CodigoTemporal = txtCodigoOrden.Text
                fechaTemporal = fechaOrdenMedica.Value
                Cursor = Cursors.WaitCursor
                Try
                    guardarReporteOrdenMedicaOxigeno()
                Catch ex As Exception
                    Label167.Text = "1002"
                    Throw ex
                End Try
                Try
                    guardarReporteOrdenMedica()
                Catch ex As Exception
                    Label167.Text = "1003"
                    Throw ex
                End Try
                ' guardarInforme(Constantes.ORDEN_MEDICA)

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(ordenes)
                General.deshabilitarBotones_HC(TSOrdenes)

                deshabilitarControlesNutricion()
                listarOrdenes()
                listaordenes.SelectedValue = objHistoriaClinica.objOrdenMedica.codigoOrden


            End If
        Catch ex As Exception
            tsordenvista.Enabled = True
            Throw ex
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarInfoIngreso()
        Try
            If servicioNeonatal = False Then
                If txtPeso.Text = "" OrElse CDbl(txtPeso.Text) <= Constantes.PESO_KILOGRAMO_MINIMO Then
                    MsgBox(Mensajes.DIGITE_PESO_PACIENTE, MsgBoxStyle.Exclamation)
                    txtPeso.Focus()
                ElseIf txtAnamnesis.Text = "" Then
                    MsgBox("Por favor digite la anamnesis del paciente.", MsgBoxStyle.Exclamation)
                    txtAnamnesis.Focus()
                ElseIf dgvImpresion.RowCount <= 1 Then
                    MsgBox("Por favor ingrese impresión diagnóstica del paciente.", MsgBoxStyle.Exclamation)
                    dgvImpresion.Focus()
                ElseIf txtAnteM.Text = "" Then
                    MsgBox("Por favor digite los antecedentes médicos del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteM.Focus()
                ElseIf txtAnteQ.Text = "" Then
                    MsgBox("Por favor digite los antecedentes quirúrgicos del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteQ.Focus()
                ElseIf txtAnteT.Text = "" Then
                    MsgBox("Por favor digite los antecedentes traumáticos del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteT.Focus()
                ElseIf txtAnteTr.Text = "" Then
                    MsgBox("Por favor digite los antecedentes transfucionales del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteTr.Focus()
                ElseIf txtAnteA.Text = "" Then
                    MsgBox("Por favor digite los antecedentes alérgicos del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteA.Focus()
                ElseIf txtAnteTo.Text = "" Then
                    MsgBox("Por favor digite los antecedentes tóxicos del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteTo.Focus()
                ElseIf txtAnteF.Text = "" Then
                    MsgBox("Por favor digite los antecedentes familiares del paciente.", MsgBoxStyle.Exclamation)
                    txtAnteF.Focus()
                ElseIf txtRevision.Text = "" Then
                    MsgBox("Por favor digite la revisión por sistemas del paciente.", MsgBoxStyle.Exclamation)
                    txtRevision.Focus()
                ElseIf txtInfoSigV.Text = "" Then
                    MsgBox("Por favor digite información de signos vitales del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoSigV.Focus()
                ElseIf txtInfoCabCu.Text = "" Then
                    MsgBox("Por favor digite información de cabeza y cuello del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoCabCu.Focus()
                ElseIf txtInfoTorax.Text = "" Then
                    MsgBox("Por favor digite información de toráx del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoTorax.Focus()
                ElseIf txtInfoCardio.Text = "" Then
                    MsgBox("Por favor digite información cardio-pulmonar del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoCardio.Focus()
                ElseIf txtInfoAbdomen.Text = "" Then
                    MsgBox("Por favor digite información de abdomen del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoAbdomen.Focus()
                ElseIf txtInfoGenito.Text = "" Then
                    MsgBox("Por favor digite información genito urinario del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoGenito.Focus()
                ElseIf txtInfoExtrem.Text = "" Then
                    MsgBox("Por favor digite información de extremidades del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoExtrem.Focus()
                ElseIf txtInfoSNerv.Text = "" Then
                    MsgBox("Por favor digite información de S. Nerv. Central del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoSNerv.Focus()
                ElseIf txtInfoParaclinico.Text = "" Then
                    MsgBox("Por favor digite información de paraclínicos del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoParaclinico.Focus()
                ElseIf txtInfoAnalisis.Text = "" Then
                    MsgBox("Por favor digite el análisis del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoAnalisis.Focus()
                ElseIf txtInfoPronos.Text = "" Then
                    MsgBox("Por favor digite pronóstico del paciente.", MsgBoxStyle.Exclamation)
                    txtInfoPronos.Focus()
                ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    guardarInfoIngresoAN()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    cargarInfoIngreso()
                End If
            Else
                If txtGramos.Text = "" OrElse CDbl(txtGramos.Text) <= Constantes.PESO_GRAMO_MINIMO Then
                    MsgBox("Por favor digite el peso del paciente.", MsgBoxStyle.Exclamation)
                    txtGramos.Focus()
                ElseIf txtAnamnesisN.Text = "" Then
                    MsgBox("Por favor digite la anamnesis del paciente.", MsgBoxStyle.Exclamation)
                    txtAnamnesisN.Focus()
                ElseIf dgvImpresionN.RowCount <= 1 Then
                    MsgBox("Por favor ingrese impresión diagnóstica del paciente.", MsgBoxStyle.Exclamation)
                    dgvImpresionN.Focus()
                ElseIf txtTipoParto.Text = "" Then
                    MsgBox("Por favor ingrese tipo de parto.", MsgBoxStyle.Exclamation)
                    txtTipoParto.Focus()
                ElseIf txtTRupturaM.Text = "" Then
                    MsgBox("Por favor ingrese tipo de ruptura membr.", MsgBoxStyle.Exclamation)
                    txtTRupturaM.Focus()
                ElseIf txtInduccionP.Text = "" Then
                    MsgBox("Por favor ingrese indución parto.", MsgBoxStyle.Exclamation)
                    txtInduccionP.Focus()
                ElseIf txtCaractLiquidoN.Text = "" Then
                    MsgBox("Por favor ingrese caracteristicas líquidas.", MsgBoxStyle.Exclamation)
                    txtCaractLiquidoN.Focus()
                ElseIf txtApgar1N.Text = "" Then
                    MsgBox("Por favor ingrese apgar 1.", MsgBoxStyle.Exclamation)
                    txtApgar1N.Focus()
                ElseIf txtApgar2.Text = "" Then
                    MsgBox("Por favor ingrese apgar 5.", MsgBoxStyle.Exclamation)
                    txtApgar2.Focus()
                ElseIf txtRmacionN.Text = "" Then
                    MsgBox("Por favor ingrese r/mación al nacer.", MsgBoxStyle.Exclamation)
                    txtRmacionN.Focus()
                ElseIf txtEdadMadreN.Text = "" Then
                    MsgBox("Por favor ingrese edad de la madre.", MsgBoxStyle.Exclamation)
                    txtEdadMadreN.Focus()
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
                ElseIf txtHemPN.Text = "" Then
                    MsgBox("Por favor ingrese hemoclasificación del padre.", MsgBoxStyle.Exclamation)
                    txtHemPN.Focus()
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
                ElseIf txtHemoclasificacionN.Text = "" Then
                    MsgBox("Por favor ingrese hemoclasificación.", MsgBoxStyle.Exclamation)
                    txtHemoclasificacionN.Focus()
                ElseIf txtVDRLN.Text = "" Then
                    MsgBox("Por favor ingrese VDRL.", MsgBoxStyle.Exclamation)
                    txtVDRLN.Focus()
                ElseIf txtTSHN.Text = "" Then
                    MsgBox("Por favor ingrese TSH.", MsgBoxStyle.Exclamation)
                    txtTSHN.Focus()
                ElseIf txtGlucometriasN.Text = "" Then
                    MsgBox("Por favor ingrese glucometrias.", MsgBoxStyle.Exclamation)
                    txtGlucometriasN.Focus()
                ElseIf txtGeneralesN.Text = "" Then
                    MsgBox("Por favor ingrese exámenes físicos generales.", MsgBoxStyle.Exclamation)
                    txtGeneralesN.Focus()
                ElseIf txtSig_vitalesN.Text = "" Then
                    MsgBox("Por favor ingrese signos vitales.", MsgBoxStyle.Exclamation)
                    txtSig_vitalesN.Focus()
                ElseIf txtCab_cuelloN.Text = "" Then
                    MsgBox("Por favor ingrese cabeza y cuello.", MsgBoxStyle.Exclamation)
                    txtCab_cuelloN.Focus()
                ElseIf txtToraxN.Text = "" Then
                    MsgBox("Por favor ingrese tórax.", MsgBoxStyle.Exclamation)
                    txtToraxN.Focus()
                ElseIf txtCardioN.Text = "" Then
                    MsgBox("Por favor ingrese cardio-pulmonar.", MsgBoxStyle.Exclamation)
                    txtCardioN.Focus()
                ElseIf txtAbdomenN.Text = "" Then
                    MsgBox("Por favor ingrese abdomen.", MsgBoxStyle.Exclamation)
                    txtAbdomenN.Focus()
                ElseIf txtGenitoN.Text = "" Then
                    MsgBox("Por favor ingrese genito-urinario.", MsgBoxStyle.Exclamation)
                    txtGenitoN.Focus()
                ElseIf txtExtremidadesN.Text = "" Then
                    MsgBox("Por favor ingrese extremidades.", MsgBoxStyle.Exclamation)
                    txtExtremidadesN.Focus()
                ElseIf txtS_NervN.Text = "" Then
                    MsgBox("Por favor ingrese S. Nerv. Central.", MsgBoxStyle.Exclamation)
                    txtS_NervN.Focus()
                ElseIf txtAnalisisN.Text = "" Then
                    MsgBox("Por favor ingrese análisis.", MsgBoxStyle.Exclamation)
                    txtAnalisisN.Focus()
                ElseIf txtPronosticoN.Text = "" Then
                    MsgBox("Por favor ingrese pronóstico.", MsgBoxStyle.Exclamation)
                    txtPronosticoN.Focus()
                ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    guardarInfoIngresoAN()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    cargarInfoIngreso()
                End If
            End If
            'guardarInforme(Constantes.INFO_INGRESO)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        tsinfovista.Enabled = True
    End Sub

    Private Sub guardarInfoIngresoAN()
        Try
            tsinfovista.Enabled = False
            objHistoriaClinica.objInfoIngreso.usuario = usuarioActual
            objHistoriaClinica.objInfoIngreso.codigoEP = SesionActual.codigoEP
            If servicioNeonatal = False Then
                precargarDatosInfoIngresoAdulto()
            Else
                precargarDatosInfoIngresoNeonato()
            End If
            objHistoriaClinica.objInfoIngreso.guardarDetalle()
        Catch ex As Exception
            tsinfovista.Enabled = True
            Throw ex
        End Try

    End Sub

    Private Sub precargarDatosInfoIngresoNeonato()
        objHistoriaClinica.objInfoIngreso.peso = txtGramos.Text
        objHistoriaClinica.objInfoIngreso.pesoUltimo = txtPesoU.Text
        objHistoriaClinica.objInfoIngreso.motivo = txtAnamnesisN.Text
        objHistoriaClinica.objInfoIngreso.tParto = txtTipoParto.Text
        objHistoriaClinica.objInfoIngreso.tRupturaM = txtTRupturaM.Text
        objHistoriaClinica.objInfoIngreso.induccionParto = txtInduccionP.Text
        objHistoriaClinica.objInfoIngreso.caracteristicasLiquidas = txtCaractLiquidoN.Text
        objHistoriaClinica.objInfoIngreso.apgar1 = txtApgar1N.Text
        objHistoriaClinica.objInfoIngreso.apgar5 = txtApgar2.Text
        objHistoriaClinica.objInfoIngreso.reanimacion = txtRmacionN.Text
        objHistoriaClinica.objInfoIngreso.edadMadre = txtEdadMadreN.Text
        objHistoriaClinica.objInfoIngreso.edadGestacional = txtEdadGestN.Text
        objHistoriaClinica.objInfoIngreso.fumador = txtFumN.Text
        objHistoriaClinica.objInfoIngreso.antecedentesObstetricos = txtObstetricosN.Text
        objHistoriaClinica.objInfoIngreso.hemoclasificacionMadre = txtHemMN.Text
        objHistoriaClinica.objInfoIngreso.hemoclasificacionPadre = txtHemPN.Text
        objHistoriaClinica.objInfoIngreso.control = txtControlPN.Text
        objHistoriaClinica.objInfoIngreso.medicamentos = txtMedDurEmbN.Text
        objHistoriaClinica.objInfoIngreso.habito = txtHabitosN.Text
        objHistoriaClinica.objInfoIngreso.infeccion = txtInfeccionesN.Text
        objHistoriaClinica.objInfoIngreso.diabeteG = txtDiabeteGN.Text
        objHistoriaClinica.objInfoIngreso.diabeteM = txtDiabeteMN.Text
        objHistoriaClinica.objInfoIngreso.hipertencion = txtHiperGN.Text
        objHistoriaClinica.objInfoIngreso.preclampcia = txtPreeclampciaN.Text
        objHistoriaClinica.objInfoIngreso.enfermedad = txtEnferTN.Text
        objHistoriaClinica.objInfoIngreso.vacunacion = txtVacunacionN.Text
        objHistoriaClinica.objInfoIngreso.torch = txtTorch.Text
        objHistoriaClinica.objInfoIngreso.hemoclasificacion = txtHemoclasificacionN.Text
        objHistoriaClinica.objInfoIngreso.vdrl = txtVDRLN.Text
        objHistoriaClinica.objInfoIngreso.tsh = txtTSHN.Text
        objHistoriaClinica.objInfoIngreso.glucometria = txtGlucometriasN.Text
        objHistoriaClinica.objInfoIngreso.generales = txtGeneralesN.Text
        objHistoriaClinica.objInfoIngreso.signosVitales = txtSig_vitalesN.Text
        objHistoriaClinica.objInfoIngreso.cabezaYCuello = txtCab_cuelloN.Text
        objHistoriaClinica.objInfoIngreso.torax = txtToraxN.Text
        objHistoriaClinica.objInfoIngreso.cardio = txtCardioN.Text
        objHistoriaClinica.objInfoIngreso.abdomen = txtAbdomenN.Text
        objHistoriaClinica.objInfoIngreso.gentoUrinario = txtGenitoN.Text
        objHistoriaClinica.objInfoIngreso.extremidades = txtExtremidadesN.Text
        objHistoriaClinica.objInfoIngreso.sistemaNervioso = txtS_NervN.Text
        objHistoriaClinica.objInfoIngreso.analisis = txtAnalisisN.Text
        objHistoriaClinica.objInfoIngreso.pronostico = txtPronosticoN.Text
    End Sub

    Private Sub precargarDatosInfoIngresoAdulto()
        objHistoriaClinica.objInfoIngreso.peso = txtPeso.Text
        objHistoriaClinica.objInfoIngreso.pesoUltimo = txtPesoU.Text
        objHistoriaClinica.objInfoIngreso.motivo = txtAnamnesis.Text
        objHistoriaClinica.objInfoIngreso.antecedentes = txtAnteM.Text
        objHistoriaClinica.objInfoIngreso.antecedentesQuirurgicos = txtAnteQ.Text
        objHistoriaClinica.objInfoIngreso.antecedentesTraumaticos = txtAnteT.Text
        objHistoriaClinica.objInfoIngreso.antecedentesTransfusionales = txtAnteTr.Text
        objHistoriaClinica.objInfoIngreso.antecedentesAlergicos = txtAnteA.Text
        objHistoriaClinica.objInfoIngreso.antecedentesToxicos = txtAnteTo.Text
        objHistoriaClinica.objInfoIngreso.antecedentesFamiliares = txtAnteF.Text
        objHistoriaClinica.objInfoIngreso.revisionSistema = txtRevision.Text
        objHistoriaClinica.objInfoIngreso.signosVitales = txtInfoSigV.Text
        objHistoriaClinica.objInfoIngreso.cabezaYCuello = txtInfoCabCu.Text
        objHistoriaClinica.objInfoIngreso.torax = txtInfoTorax.Text
        objHistoriaClinica.objInfoIngreso.cardio = txtInfoCardio.Text
        objHistoriaClinica.objInfoIngreso.abdomen = txtInfoAbdomen.Text
        objHistoriaClinica.objInfoIngreso.gentoUrinario = txtInfoGenito.Text
        objHistoriaClinica.objInfoIngreso.extremidades = txtInfoExtrem.Text
        objHistoriaClinica.objInfoIngreso.sistemaNervioso = txtInfoSNerv.Text
        objHistoriaClinica.objInfoIngreso.paraclinico = txtInfoParaclinico.Text
        objHistoriaClinica.objInfoIngreso.analisis = txtInfoAnalisis.Text
        objHistoriaClinica.objInfoIngreso.pronostico = txtInfoPronos.Text
    End Sub

    Private Sub verificarActivoYEdicion()
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
    End Sub

    Private Sub fechaOrdenMedica_ValueChanged(sender As Object, e As EventArgs) Handles fechaOrdenMedica.ValueChanged
        If tsordenguardar.Enabled = True And Visible = True Then
            NDPesoPacienteNutricion.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.ultimoPeso(txtRegistro.Text, fechaOrdenMedica.Value)
        End If
    End Sub

    Private Sub generarVistaPrevia()
        Try
            Dim formPlataforma As New FormVisorPlataformaDoc
            formPlataforma.consolidado(objPrincipal)

            objHistoriaClinica.generarVistaPrevia(usuarioActual, txtNombre.Text, formPlataforma)
            If Not objHistoriaClinica.objConsolidado.errorGeneracion Then
                Application.Run(formPlataforma)
            End If
            If Not String.IsNullOrEmpty(objHistoriaClinica.mostrarErrores()) Then
                General.mensajeCritico("Hubo errores al generar algunos soportes. " & ConstantesError.COMUNICAR_SISTEMA, objHistoriaClinica.mostrarErrores())
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        If Visible Then
            pnlConsolidado.Visible = False
            tsConsolidado.Text = "Consolidado"
            tsConsolidado.Enabled = True
        Else
            fPadre.pnlConsolidado.Visible = False
        End If
    End Sub

    Private Sub generarPrefactura()
        Try
            objHistoriaClinica.generarPrefactura(usuarioActual, txtNombre.Text)
        Catch ex As Exception
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(modulo)
            params.Add(usuarioActual)
            General.ejecutarSQL(ConsultasHC.PREFACTURA_ACTUALIZAR, params)
            General.manejoErrores(ex)
        End Try
        tsPrefactura.Text = "Prefactura"
        tsPrefactura.Enabled = True
        verificarSoat()
    End Sub
    Private Sub verificarSoat()
        Dim dtSOAT As New DataTable
        objHistoriaClinica.objPrefactura.nRegistro = nRegistro
        objHistoriaClinica.objPrefactura.cargarSOAT(dtSOAT)
        txtSOAT.Visible = False
        If dtSOAT.Rows.Count = 0 Then
            gbResumen.Visible = False
            gbTope.Visible = False
        Else
            gbResumen.Visible = True
            gbTope.Visible = True
            lblTope.Text = dtSOAT.Rows(0).Item("Tope")
            lblResumen.Text = dtSOAT.Rows(0).Item("Resumen")
            Dim alerta As Integer = dtSOAT.Rows(0).Item("Alerta")
            If alerta = 3 Then
                tsordennuevo.Visible = False
            Else
                tsordennuevo.Visible = True
            End If
            tsevonuevo.Visible = tsordennuevo.Visible
            tsremnuevo.Visible = tsordennuevo.Visible
            tsfisionuevo.Visible = tsordennuevo.Visible
            tsenferNuevo.Visible = tsordennuevo.Visible
            tsordenduplicar.Visible = tsordennuevo.Visible
            tsevoduplicar.Visible = tsordennuevo.Visible
            tsremduplicar.Visible = tsordennuevo.Visible
            tsfisioduplicar.Visible = tsordennuevo.Visible
            tsenferduplicar.Visible = tsordennuevo.Visible
            txtSOAT.Clear()
            Select Case alerta
                Case 1
                    lblResumen.ForeColor = Color.Green
                Case 2
                    lblResumen.ForeColor = Color.Orange
                    txtSOAT.Text = "Cuidado, está próximo a susperar el tope del SOAT"
                    txtSOAT.Visible = True
                    txtSOAT.BackColor = Color.Orange
                Case Else
                    lblResumen.ForeColor = Color.Red
                    txtSOAT.Text = "Ha superado el tope del SOAT"
                    txtSOAT.Visible = True
                    txtSOAT.BackColor = Color.Red
            End Select
        End If
    End Sub
    Private Sub guardarReporteOrdenMedica()
        Dim objHistoriaClinica2 As HistoriaClinica

        Dim params As New List(Of String)
        params.Add(modulo)
        params.Add(servicioNeonatal)
        params.Add(objHistoriaClinica.nRegistro)
        objHistoriaClinica2 = New HistoriaClinica(params)
        objHistoriaClinica2.objOrdenMedica.registro = objHistoriaClinica.nRegistro
        objHistoriaClinica2.objOrdenMedica.fechaOrden = objHistoriaClinica.objOrdenMedica.fechaOrden
        objHistoriaClinica2.objOrdenMedica.usuario = usuarioActual
        objHistoriaClinica2.objOrdenMedica.usuarioReal = usuarioInformeTemporal
        objHistoriaClinica2.objOrdenMedica.codigoEP = SesionActual.codigoEP
        Try
            If modulo = Constantes.CODIGO_MENU_HISTC Then
                SabanaAplicacionMedDAL.guardarSabanaAutomaticaHC(objHistoriaClinica2.objOrdenMedica)
                If activoAM = True Then
                    SabanaAplicacionMedDAL.guardarSabanaAutomaticaAM(objHistoriaClinica2.objOrdenMedica)
                End If
                If activoAM = True Then
                    SabanaAplicacionMedDAL.guardarSabanaAutomaticaAF(objHistoriaClinica2.objOrdenMedica)
                End If
            ElseIf modulo = Constantes.CODIGO_MENU_AUDM Then
                SabanaAplicacionMedDAL.guardarSabanaAutomaticaAM(objHistoriaClinica2.objOrdenMedica)
                If activoAM = True Then
                    SabanaAplicacionMedDAL.guardarSabanaAutomaticaAF(objHistoriaClinica2.objOrdenMedica)
                End If
            ElseIf modulo = Constantes.CODIGO_MENU_AUDF Then
                SabanaAplicacionMedDAL.guardarSabanaAutomaticaAF(objHistoriaClinica2.objOrdenMedica)
            End If
        Catch ex As Exception
            Label166.Text = "Error 200"
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub guardarSabanaAutomatica()
        Dim objHistoriaClinica2 As HistoriaClinica
        Dim params As New List(Of String)
        params.Add(modulo)
        params.Add(servicioNeonatal)
        params.Add(objHistoriaClinica.nRegistro)
        objHistoriaClinica2 = New HistoriaClinica(params)
        objHistoriaClinica2.objOrdenMedica.registro = objHistoriaClinica.nRegistro
        objHistoriaClinica2.objOrdenMedica.fechaOrden = General.fechaActualServidor
        objHistoriaClinica2.objOrdenMedica.usuario = 0
        objHistoriaClinica2.objOrdenMedica.usuarioReal = usuarioActual
        objHistoriaClinica2.objOrdenMedica.codigoEP = SesionActual.codigoEP
        Try
            If modulo = Constantes.CODIGO_MENU_AUDM Then
                SabanaAplicacionMedDAL.guardarSabanaAutomaticaAM(objHistoriaClinica2.objOrdenMedica)
            ElseIf modulo = Constantes.CODIGO_MENU_AUDF Then
                SabanaAplicacionMedDAL.guardarSabanaAutomaticaAF(objHistoriaClinica2.objOrdenMedica)
            End If
            params.Clear()
            params.Add(objHistoriaClinica.nRegistro)
            General.ejecutarSQL(Consultas.PLANTILLA_CONFIGURACION, params)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub guardarReporteOrdenMedicaOxigeno()
        Try
            cargarOxigeno()
            guardarOxigenoFisioterapia(False)
        Catch ex As Exception
            Label166.Text = "Error 100"
            General.manejoErrores(ex)
        End Try

        tsordenvista.Enabled = True
    End Sub
    Private Sub tsremguardar_Click(sender As Object, e As EventArgs) Handles tsremguardar.Click
        Try
            TabHistoriaC.SelectedIndex = TabHistoriaC.TabPages("remisiones").TabIndex
            objHistoriaClinica.objRemision.opcionCancelar = False
            If validarRemision() = False Then Exit Sub
            guardarRemision()
            GroupBoxAnexo9.Focus()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Function validarRemision() As Boolean
        If (Not IsDate(fechaRemision.Text)) Then
            MsgBox("La fecha de la remisión no es valida. Por favor, corrijala.", MsgBoxStyle.Exclamation)
            fechaRemision.Focus()
            Return False
        ElseIf Comboprioridad.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione la prioridad.", MsgBoxStyle.Exclamation)
            Comboprioridad.Focus()
            Return False
        ElseIf Combocomplejidad.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione la complejidad.", MsgBoxStyle.Exclamation)
            Combocomplejidad.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtModalidadApoyo.Text) Then
            MsgBox("Por favor seleccione la modalidad de apoyo o motivo de solicitud.", MsgBoxStyle.Exclamation)
            btModalidadApoyo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtantecedentes.Text) Then
            MsgBox("Debe digitar los antecedentes del paciente.", MsgBoxStyle.Exclamation)
            txtantecedentes.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtglasgow.Text) Then
            MsgBox("Debe digitar valores en glasgow.", MsgBoxStyle.Exclamation)
            txtglasgow.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtdescripglasgow.Text) Then
            MsgBox("Debe digitar la descripción de glasgow.", MsgBoxStyle.Exclamation)
            txtdescripglasgow.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtpresionsis.Text) Then
            MsgBox("Debe digitar información de la presión sistólica.", MsgBoxStyle.Exclamation)
            txtpresionsis.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtpresiondias.Text) Then
            MsgBox("Debe digitar información de la presión diastólica.", MsgBoxStyle.Exclamation)
            txtpresiondias.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtfreccar.Text) Then
            MsgBox("Debe digitar información de frecuencia cardíaca.", MsgBoxStyle.Exclamation)
            txtfreccar.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtfrecresp.Text) Then
            MsgBox("Debe digitar información frecuencia cardíaca.", MsgBoxStyle.Exclamation)
            txtfrecresp.Focus()
            Return False
        ElseIf rbambuSI.Checked = True And String.IsNullOrEmpty(txtServicioAmb.Text) Then
            MsgBox("Debe seleccionar el servicio de traslado.", MsgBoxStyle.Exclamation)
            btServicioAmb.Focus()
            Return False
        ElseIf rboxigenoSI.Checked = True And String.IsNullOrEmpty(txtReferenciaOx.Text) Then
            MsgBox("Debe seleccionar especialidad oxigeno.", MsgBoxStyle.Exclamation)
            btReferenciaOx.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtdatos.Text) Then
            MsgBox("Debe digitar datos médicos.", MsgBoxStyle.Exclamation)
            txtdatos.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub guardarRemision()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                tsremvista.Enabled = False
                objHistoriaClinica.objRemision.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objRemision.codigoRemision = txtcodigoRemision.Text
                objHistoriaClinica.objRemision.datosMedicos = txtdatos.Text
                objHistoriaClinica.objRemision.fechaRemision = fechaRemision.Text
                objHistoriaClinica.objRemision.prioridad = Comboprioridad.SelectedValue
                objHistoriaClinica.objRemision.complejidad = Combocomplejidad.SelectedValue
                objHistoriaClinica.objRemision.otras = txtotras.Text
                objHistoriaClinica.objRemision.antecedentes = txtantecedentes.Text
                objHistoriaClinica.objRemision.glasgow = txtglasgow.Text
                objHistoriaClinica.objRemision.descripglasgow = txtdescripglasgow.Text
                objHistoriaClinica.objRemision.presionsis = txtpresionsis.Text
                objHistoriaClinica.objRemision.presiondias = txtpresiondias.Text
                objHistoriaClinica.objRemision.freccar = txtfreccar.Text
                objHistoriaClinica.objRemision.frecresp = txtfrecresp.Text
                objHistoriaClinica.objRemision.ambulancia = If(rbambuSI.Checked = True, 1, 0)
                objHistoriaClinica.objRemision.oxigeno = If(rboxigenoSI.Checked = True, 1, 0)
                objHistoriaClinica.objRemision.usuario = SesionActual.idUsuario
                objHistoriaClinica.objRemision.usuarioReal = IIf(String.IsNullOrEmpty(objHistoriaClinica.objRemision.usuarioReal), objHistoriaClinica.objRemision.usuario, objHistoriaClinica.objRemision.usuarioReal)
                objHistoriaClinica.objRemision.remisionExterna = cmbRemisionDestino.SelectedValue
                objHistoriaClinica.objRemision.guardarRemision()
                txtcodigoRemision.Text = objHistoriaClinica.objRemision.codigoRemision
                CodigoTemporal = objHistoriaClinica.objRemision.codigoRemision
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                listarRemisiones()
                Listaremisiones.SelectedValue = objHistoriaClinica.objRemision.codigoRemision
                'guardarInforme(Constantes.REMISION)

            End If
        Catch ex As Exception
            Throw ex
        End Try
        tsremvista.Enabled = True
    End Sub

    Private Sub Label90_Click(sender As Object, e As EventArgs) Handles Label90.Click

    End Sub

    Private Sub tsinterguardar_Click(sender As Object, e As EventArgs) Handles tsinterguardar.Click
        TabHistoriaC.SelectedIndex = TabHistoriaC.TabPages("interconsultas").TabIndex
        Try
            If (Not IsDate(fechaInterconsulta.Text)) Then
                MsgBox("La fecha de la interconsulta no es valida. Por favor, corrijala.", MsgBoxStyle.Exclamation)
                fechaInterconsulta.Focus()
            ElseIf String.IsNullOrEmpty(txtRespuesta.Text) Then
                MsgBox("Debe digitar la respuesta de la interconsulta.", MsgBoxStyle.Exclamation)
                txtRespuesta.Focus()
            ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                tsintervista.Enabled = False
                objHistoriaClinica.objInterconsulta.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objInterconsulta.codigoOrden = CInt(TXTCODIGOINTERCONSULTA.Text)
                objHistoriaClinica.objInterconsulta.codigoProcedimiento = procedimientoInterconsulta
                objHistoriaClinica.objInterconsulta.Respuesta = txtRespuesta.Text
                objHistoriaClinica.objInterconsulta.fechaInterconsulta = fechaInterconsulta.Text

                objHistoriaClinica.objInterconsulta.guardarInterconsultaMedica()
                CodigoTemporal = CInt(TXTCODIGOINTERCONSULTA.Text)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                listarInterconsultas()
                ListaInterconsultas.SelectedValue = objHistoriaClinica.objInterconsulta.codigoOrden
                ' guardarInforme(Constantes.INTERCONSULTA)
            End If
        Catch ex As Exception

            General.manejoErrores(ex)
        End Try
        tsintervista.Enabled = True
    End Sub
    Private Sub tsevoguardar_Click(sender As Object, e As EventArgs) Handles tsevoguardar.Click
        Try
            evoluciones.Focus()
            txtJustificacionEVO_Leave(sender, e)
            TabHistoriaC.SelectedIndex = TabHistoriaC.TabPages("evoluciones").TabIndex
            objHistoriaClinica.objEvolucionMedica.opcionCancelar = False
            If validarEvolucionMedica() = False Then Exit Sub
            If fechaEvolucion_Validating(sender, Nothing) = False Then Exit Sub
            guardarEvolucionMedica()
            GroupBoxProblemas.Focus()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub guardarEvolucionMedica()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                tsevovista.Enabled = False
                objHistoriaClinica.objEvolucionMedica.codigoEvolucion = txtcodigoevolucion.Text
                objHistoriaClinica.objEvolucionMedica.analisis = TXTANALISIS.Text
                objHistoriaClinica.objEvolucionMedica.planTratamiento = TXTPLAN.Text
                objHistoriaClinica.objEvolucionMedica.fechaEvolucion = fechaEvolucion.Text
                objHistoriaClinica.objEvolucionMedica.subjetivo = TXTSUBJETIVO.Text
                objHistoriaClinica.objEvolucionMedica.signoVital = TXTSIG_VITALES.Text
                objHistoriaClinica.objEvolucionMedica.cabezaCuello = TXTCAB_CUELLO.Text
                objHistoriaClinica.objEvolucionMedica.torax = TXTTORAX.Text
                objHistoriaClinica.objEvolucionMedica.cardioPulmonar = TXTCARDIO.Text
                objHistoriaClinica.objEvolucionMedica.abdomen = TXTABDOMEN.Text
                objHistoriaClinica.objEvolucionMedica.genturinario = TXTGENTURINARIO.Text
                objHistoriaClinica.objEvolucionMedica.extremidades = TXTEXTREM.Text
                objHistoriaClinica.objEvolucionMedica.sistemaNervioso = TXTSNERV.Text
                objHistoriaClinica.objEvolucionMedica.usuario = SesionActual.idUsuario
                objHistoriaClinica.objEvolucionMedica.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objEvolucionMedica.guardarEvolucionMedica()
                txtcodigoevolucion.Text = objHistoriaClinica.objEvolucionMedica.codigoEvolucion
                CodigoTemporal = txtcodigoevolucion.Text
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                If General.getEstadoVF(Consultas.ESTANCIA_PROLONGADA_VERIFICAR & CInt(txtRegistro.Text)) = True Then
                    MsgBox("Por favor llene el siguiente formulario para estancias prolongadas", MsgBoxStyle.Information)
                    FormPrincipal.Cursor = Cursors.WaitCursor
                    Dim estancia As New Form_Estancia_Prolongada
                    Dim param As New List(Of String)
                    param.Add(txtRegistro.Text)
                    'Dim dt2 As New DataTable
                    'General.llenarTabla(Consultas.ESTANCIA_PROLONGADA_ULTIMAEVO, param, dt2)

                    'If dt2.Rows.Count > 0 Then
                    '    codigoEvo = dt2.Rows(0).Item("Codigo_Evo").ToString
                    '    If codigoEvo > 0 Then
                    '        objHistoriaClinica.objEstancia.codigoevo = codigoEvo
                    '        General.cargarForm(estancia)
                    '        estancia.preCargarDatosEstancia(objHistoriaClinica)
                    '        estancia.cargarPaciente(Me)
                    '    Else
                    '        MsgBox("este paciente aun no tiene evolución para el dia 12 de estancia", MsgBoxStyle.Exclamation)
                    '    End If
                    'End If

                    FormPrincipal.Cursor = Cursors.Default
                End If
                General.deshabilitarControles(evoluciones)
                General.deshabilitarBotones_HC(TSevoluciones)
                listarEvoluciones()
                Listaevoluciones.SelectedValue = objHistoriaClinica.objEvolucionMedica.codigoEvolucion
                ' guardarInforme(Constantes.EVOLUCION_MEDICA)

            End If
        Catch ex As Exception

            Throw ex
        End Try
        tsevovista.Enabled = True
    End Sub

    Private Function validarEvolucionMedica()
        If (Not IsDate(fechaEvolucion.Text)) Then
            MsgBox("La fecha de la evolución no es valida. Por favor, corrijala.", MsgBoxStyle.Exclamation)
            fechaEvolucion.Focus()
            Return False
        ElseIf dgvDIAGEVO.Rows.Count <= 1 Then
            MsgBox("Por favor digite por lo menos un diagnóstico.", MsgBoxStyle.Exclamation)
            dgvDIAGEVO.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTSUBJETIVO.Text) Then
            MsgBox("Debe digitar la información entregada por el paciente (subjetivo).", MsgBoxStyle.Exclamation)
            TXTSUBJETIVO.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTSIG_VITALES.Text) Then
            MsgBox("Debe digitar los signos vitales.", MsgBoxStyle.Exclamation)
            TXTSIG_VITALES.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTCAB_CUELLO.Text) Then
            MsgBox("Debe digitar información de cabeza y cuello.", MsgBoxStyle.Exclamation)
            TXTCAB_CUELLO.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTTORAX.Text) Then
            MsgBox("Debe digitar información de torax.", MsgBoxStyle.Exclamation)
            TXTTORAX.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTCARDIO.Text) Then
            MsgBox("Debe digitar información cardio-pulmonar.", MsgBoxStyle.Exclamation)
            TXTCARDIO.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTABDOMEN.Text) Then
            MsgBox("Debe digitar información abdomen.", MsgBoxStyle.Exclamation)
            TXTABDOMEN.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTGENTURINARIO.Text) Then
            MsgBox("Debe digitar información genito urinario.", MsgBoxStyle.Exclamation)
            TXTGENTURINARIO.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTEXTREM.Text) Then
            MsgBox("Debe digitar información extremidades.", MsgBoxStyle.Exclamation)
            TXTEXTREM.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTSNERV.Text) Then
            MsgBox("Debe digitar información S. Nerv. Central.", MsgBoxStyle.Exclamation)
            TXTSNERV.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTANALISIS.Text) Then
            MsgBox("Debe digitar el análisis.", MsgBoxStyle.Exclamation)
            TXTANALISIS.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(TXTPLAN.Text) Then
            MsgBox("Debe digitar el plan.", MsgBoxStyle.Exclamation)
            TXTPLAN.Focus()
            Return False
        Else

            dgvParaclinicoEvo.EndEdit()
            dgvParaclinicoEvo.ClearSelection()

            For i = 0 To dgvParaclinicoEvo.Rows.Count - 1
                If dgvParaclinicoEvo.Rows(i).Cells("Obligatorio").Value = 1 AndAlso String.IsNullOrWhiteSpace(dgvParaclinicoEvo.Rows(i).Cells("dgInterpretacionParaEvo").Value.ToString) Then
                    MsgBox("Debe diligenciar la interpretación de los paraclínicos obligatorios.", MsgBoxStyle.Exclamation)
                    gbAnalisisEvo.Focus()
                    dgvParaclinicoEvo.Rows(i).Selected = True
                    Return False
                    Exit For
                End If
            Next

        End If
        Return True
    End Function
    Private Sub bttrasladoc_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btsabana_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btparametrov_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btrecetario_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btpedido_farm_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsenferduplicar_Click(sender As Object, e As EventArgs) Handles tsenferduplicar.Click
        If opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION Then
            If SesionActual.tienePermiso(pDuplicarOie) Then
                If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                    Dim tbl As DataRow = Nothing
                    Dim params As New List(Of String)
                    params.Add(Constantes.LISTA_CARGO_ORDEN_INSUMO_ENFER)
                    params.Add(SesionActual.idEmpresa)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                    tbl = formBusqueda.rowResultados
                    If tbl IsNot Nothing Then
                        objHistoriaClinica.objEnfermeria.objInsumosEnfer.usuarioReal = tbl(0)
                        txtNombreUsuarioInforme.Text = tbl(1)
                    Else
                        MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
                deshabilitarGroupBoxEnfer()
                GroupBoxInsuEnfer.Enabled = True
                editaDuplicaOpcionesInsumoEnfer()
                txtCodigoEnfermeria.Clear()
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        ElseIf opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION Then
            If SesionActual.tienePermiso(pDuplicarNe) Then
                If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                    Dim tbl As DataRow = Nothing
                    Dim params As New List(Of String)
                    params.Add(Constantes.LISTA_CARGO_NOTA_ENFERMERIA)
                    params.Add(SesionActual.idEmpresa)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                    tbl = formBusqueda.rowResultados
                    If tbl IsNot Nothing Then
                        objHistoriaClinica.objEnfermeria.objNotaEnfer.usuarioReal = tbl(0)
                        txtNombreUsuarioInforme.Text = tbl(1)
                    Else
                        MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
                deshabilitarGroupBoxEnfer()
                GroupBoxNotaEnfer.Enabled = True
                editaDuplicaOpcionesNotaEnfer()
                txtCodigoEnfermeria.Clear()
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsenfereditar_Click(sender As Object, e As EventArgs) Handles tsenfereditar.Click

        If opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION Then
            If SesionActual.tienePermiso(pEditarOie) Then
                deshabilitarGroupBoxEnfer()
                GroupBoxInsuEnfer.Enabled = True
                editaDuplicaOpcionesInsumoEnfer()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If

        ElseIf opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION Then
            If SesionActual.tienePermiso(pEditarNe) Then
                deshabilitarGroupBoxEnfer()
                GroupBoxNotaEnfer.Enabled = True
                editaDuplicaOpcionesNotaEnfer()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        ElseIf opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION Then

            If SesionActual.tienePermiso(pEditarHg) Then

                If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                    Dim tbl As DataRow = Nothing
                    Dim params As New List(Of String)
                    params.Add(Constantes.LISTA_CARGO_NOTA_ENFERMERIA)
                    params.Add(SesionActual.idEmpresa)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                    tbl = formBusqueda.rowResultados
                    If tbl IsNot Nothing Then
                        objHistoriaClinica.objEnfermeria.objGlucomEnfer.usuarioReal = tbl(0)
                        txtNombreUsuarioInforme.Text = tbl(1)
                    Else
                        MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If

                deshabilitarGroupBoxEnfer()
                GroupBoxGluco.Enabled = True
                editaDuplicaOpcionesGlucomEnfer()

            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Private Sub tsenferNuevo_Click(sender As Object, e As EventArgs) Handles tsenferNuevo.Click
        objHistoriaClinica.objEnfermeria.opcionCancelar = False
        Try
            If opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION Then
                If SesionActual.tienePermiso(pNuevaOie) Then
                    If modulo <> Constantes.HC AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                        Dim tbl As DataRow = Nothing
                        Dim params As New List(Of String)
                        params.Add(Constantes.LISTA_CARGO_ORDEN_INSUMO_ENFER)
                        params.Add(SesionActual.idEmpresa)
                        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                        tbl = formBusqueda.rowResultados
                        If tbl IsNot Nothing Then
                            objHistoriaClinica.objEnfermeria.objInsumosEnfer.usuarioReal = tbl(0)
                            txtNombreUsuarioInforme.Text = tbl(1)
                        Else
                            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Else
                        objHistoriaClinica.objEnfermeria.objInsumosEnfer.usuarioReal = SesionActual.idUsuario
                        txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
                    End If
                    listaInsumosEnfer.SelectedIndex = 0
                    ordenNuevaInsumoEnfer()
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            ElseIf opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION Then
                If SesionActual.tienePermiso(pNuevaNe) Then
                    If modulo <> Constantes.HC AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                        Dim tbl As DataRow = Nothing
                        Dim params As New List(Of String)
                        params.Add(Constantes.LISTA_CARGO_NOTA_ENFERMERIA)
                        params.Add(SesionActual.idEmpresa)
                        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                        tbl = formBusqueda.rowResultados
                        If tbl IsNot Nothing Then
                            objHistoriaClinica.objEnfermeria.objNotaEnfer.usuarioReal = tbl(0)
                            txtNombreUsuarioInforme.Text = tbl(1)
                        Else
                            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Else
                        objHistoriaClinica.objEnfermeria.objNotaEnfer.usuarioReal = SesionActual.idUsuario
                        txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
                    End If
                    listaNotasEnfer.SelectedIndex = 0
                    ordenNuevaNotaEnfer()
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            ElseIf opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION Then
                If SesionActual.tienePermiso(pNuevaHg) Then
                    If modulo <> Constantes.HC AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                        Dim tbl As DataRow = Nothing
                        Dim params As New List(Of String)
                        params.Add(Constantes.LISTA_CARGO_NOTA_ENFERMERIA)
                        params.Add(SesionActual.idEmpresa)
                        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                        tbl = formBusqueda.rowResultados
                        If tbl IsNot Nothing Then
                            objHistoriaClinica.objEnfermeria.objGlucomEnfer.usuarioReal = tbl(0)
                            txtNombreUsuarioInforme.Text = tbl(1)
                        Else
                            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Else
                        objHistoriaClinica.objEnfermeria.objGlucomEnfer.usuarioReal = SesionActual.idUsuario
                        txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
                    End If
                    ordenNuevaGlucomEnfer()
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub tsfisioanular_Click(sender As Object, e As EventArgs) Handles tsfisioanular.Click
        Try
            If opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION Then
                If SesionActual.tienePermiso(pAnularOi) Then
                    objHistoriaClinica.objFisioterapia.opcionCancelar = False
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        objHistoriaClinica.objFisioterapia.objInsumosFisio.codigoOrden = txtCodigoFisioterapia.Text
                        objHistoriaClinica.objFisioterapia.objInsumosFisio.usuario = usuarioActual
                        objHistoriaClinica.objFisioterapia.objInsumosFisio.codigoEP = SesionActual.codigoEP
                        objHistoriaClinica.objFisioterapia.anularOrdenInsumoFisio()
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        listarFisioterapia()
                        listaInsumosfisio.Focus()
                        verificarSoat()
                    End If
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            ElseIf opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION Then
                If SesionActual.tienePermiso(pAnularNf) Then
                    objHistoriaClinica.objFisioterapia.opcionCancelar = False
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        anularNotaFisio()
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        listarFisioterapia()
                        listaNotasfisio.Focus()
                    End If
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub listaParaclinicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaParaclinicos.SelectedIndexChanged
        Try
            If listaParaclinicos.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaParaclinicos.SelectedIndex) Then
                txtCodigoEnfermeria.Clear()
                objHistoriaClinica.objEnfermeria.objParaclinico.codigoOrden = txtCodigoEnfermeria.Text
                If Not IsNothing(dgvExamenParaclinicos.DataSource) Then
                    dgvExamenParaclinicos.DataSource.clear
                End If
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                cargarParaclinico()
                edicionSegunRegistro(listaParaclinicos, TSEnfermeria)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvParaclinico_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinico.CellContentDoubleClick
        Dim objExamen As Object = Nothing
        Dim nombreArchivo, ruta As String
        Dim verificarTipo As Integer
        Dim codigoCompuesto As String

        If dgvParaclinico.RowCount > 0 And e.ColumnIndex = dgvParaclinico.Columns("dgResultadoPara").Index Then

            verificarTipo = Funciones.consultarAplicaParaclinico(objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows _
                                                                 (dgvParaclinico.CurrentCell.RowIndex).Item("CodigoTipoExamen"))

            If dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("Resultado").Value = 1 Then
                If verificarTipo = ConstantesHC.CODIGO_APLICA_LABORATORIO Then
                    objExamen = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_EXAMEN_LAB & modulo)
                    objExamen.codigoProcedimiento = dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("dgCodigoPara").Value
                    objExamen.codigoOrden = txtCodigoOrden.Text
                    objExamen.areaExamen = Constantes.HISTORIA_CLIN
                    objExamen.tipoExamen = dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("dgCodigoTipoParaclinicoOM").Value
                    objExamen.cargarNombrePDF()
                ElseIf verificarTipo = ConstantesHC.CODIGO_APLICA_IMAGEN Then
                    objExamen = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_IMAGENOLOGIA & modulo)
                    objExamen.codigoProcedimiento = dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("dgCodigoPara").Value
                    objExamen.codigoOrden = txtCodigoOrden.Text
                ElseIf verificarTipo = ConstantesHC.CODIGO_APLICA_PDF Then
                    Dim Form = New Form_resultado
                    Form.cargarResultado(txtCodigoOrden.Text,
                                         objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Código"),
                                         objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Descripción"),
                                         modulo,
                                         If(verificarTipo = ConstantesHC.CODIGO_APLICA_IMAGEN, 1, 0), Constantes.TipoEXAM, txtRegistro.Text)
                    Form.MdiParent = FormPrincipal
                    Form.Show()
                    Form.Focus()
                    Exit Sub
                End If
                Try
                    If objExamen.area = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA OrElse objExamen.area = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_R OrElse
                        objExamen.area = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_RR Then
                        codigoCompuesto = objExamen.codigoOrden + objExamen.codigoProcedimiento
                    Else
                        codigoCompuesto = objExamen.codigoOrden
                    End If

                    nombreArchivo = objExamen.area & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoCompuesto & ConstantesHC.EXTENSION_ARCHIVO_PDF
                    ruta = IO.Path.GetTempPath() & nombreArchivo
                    If verificarTipo <> ConstantesHC.CODIGO_APLICA_PDF Then
                        objExamen.imprimir()
                    End If

                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If

    End Sub


    Private Sub tsmVisado_Click(sender As Object, e As EventArgs) Handles tsmVisado.Click
        If MsgBox(Mensajes.CAMBIO_VISADO, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            consultaVisado(GeneralHC.consultaVisado(nRegistro))
        End If
    End Sub


    Private Sub consultaVisado(resultado As Boolean)
        If resultado Then
            tsmVisado.Text = "Quitar Visado Para Factura"
            tsmVisado.Image = My.Resources.Close_2_icon
            fechaOrdenMedica.Location = New Point(470, fechaOrdenMedica.Location.Y)
            fechaEvolucion.Location = New Point(470, fechaEvolucion.Location.Y)
            fechaInterconsulta.Location = New Point(470, fechaInterconsulta.Location.Y)
            fechaRemision.Location = New Point(470, fechaRemision.Location.Y)
            fechaFisioterapia.Location = New Point(470, fechaFisioterapia.Location.Y)
            fechaEnfermeria.Location = New Point(470, fechaEnfermeria.Location.Y)
        Else
            tsmVisado.Text = "Visado Para Factura"
            tsmVisado.Image = My.Resources.Badge_tick_icon__1_
            fechaOrdenMedica.Location = New Point(748, fechaOrdenMedica.Location.Y)
            fechaEvolucion.Location = New Point(748, fechaEvolucion.Location.Y)
            fechaInterconsulta.Location = New Point(599, fechaInterconsulta.Location.Y)
            fechaRemision.Location = New Point(748, fechaRemision.Location.Y)
            fechaFisioterapia.Location = New Point(748, fechaFisioterapia.Location.Y)
            fechaEnfermeria.Location = New Point(748, fechaEnfermeria.Location.Y)
        End If
        If Not SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then Exit Sub
        tsinfoeditar.Visible = Not resultado
        tsinfoguardar.Visible = Not resultado
        tsinfocancelar.Visible = Not resultado

        tsordennuevo.Visible = Not resultado
        tsordeneditar.Visible = Not resultado
        tsordenguardar.Visible = Not resultado
        tsordencancelar.Visible = Not resultado
        tsordenanular.Visible = Not resultado
        tsordenduplicar.Visible = Not resultado

        tsevonuevo.Visible = Not resultado
        tsevoeditar.Visible = Not resultado
        tsevoguardar.Visible = Not resultado
        tsevocancelar.Visible = Not resultado
        tsevoduplicar.Visible = Not resultado
        tsevoanular.Visible = Not resultado

        tsintereditar.Visible = Not resultado
        tsinteranular.Visible = Not resultado
        tsinterguardar.Visible = Not resultado
        tsintercancelar.Visible = Not resultado

        tsremnuevo.Visible = Not resultado
        tsremeditar.Visible = Not resultado
        tsremduplicar.Visible = Not resultado
        tsremanular.Visible = Not resultado
        tsremguardar.Visible = Not resultado
        tsremcancelar.Visible = Not resultado

        tsfisionuevo.Visible = Not resultado
        tsfisioeditar.Visible = Not resultado
        tsfisioduplicar.Visible = Not resultado
        tsfisioanular.Visible = Not resultado
        tsfisioguardar.Visible = Not resultado
        tsfisiocancelar.Visible = Not resultado

        tsenferNuevo.Visible = Not resultado
        tsenfereditar.Visible = Not resultado
        tsenferduplicar.Visible = Not resultado
        tsenferanular.Visible = Not resultado
        tsenferguardar.Visible = Not resultado
        tsenfercancelar.Visible = Not resultado

        tscuerponuevo.Visible = Not resultado
        tscuerpoeditar.Visible = Not resultado
        tscuerpoanular.Visible = Not resultado
        tscuerpoguardar.Visible = Not resultado
        tscuerpocancelar.Visible = Not resultado

        tssOG.Visible = Not resultado
        tssOE.Visible = Not resultado
        tssOD.Visible = Not resultado
        tssOA.Visible = Not resultado
        tssEG.Visible = Not resultado
        tssEE.Visible = Not resultado
        tssED.Visible = Not resultado
        tssEA.Visible = Not resultado
        tssIE.Visible = Not resultado
        tssIA.Visible = Not resultado
        tssFG.Visible = Not resultado
        tssFE.Visible = Not resultado
        tssFD.Visible = Not resultado
        tssFA.Visible = Not resultado
        tssENG.Visible = Not resultado
        tssEnE.Visible = Not resultado
        tssEnD.Visible = Not resultado
        tssENA.Visible = Not resultado
        tssInG.Visible = Not resultado
        tssRG.Visible = Not resultado
        tssRE.Visible = Not resultado
        tssRD.Visible = Not resultado
        tssRA.Visible = Not resultado
        tssCG.Visible = Not resultado
        tssCE.Visible = Not resultado
        tssCA.Visible = Not resultado
    End Sub


    Private Sub tsmFormatoIngreso_Click(sender As Object, e As EventArgs) Handles tsmFormatoIngreso.Click
        If tsinfoeditar.Enabled = False Then
            cargarFormatoIngreso()
        Else
            MsgBox("El formato de ingreso no puede ser usado, si el registro no se encuentra en estado de ediciòn", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarFormatoIngreso()
        Try
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.nRegistro)
            General.buscarElemento(Consultas.FORMATO_INGRESO_LISTA,
                              params,
                              AddressOf cargarFormatoIngreso,
                              TitulosForm.BUSQUEDA_FORMATO_INGRESO,
                              True)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub cargarFormatoIngreso(pCodigo As Integer)
        objFormato = New FormatoIngreso
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Try
            params.Add(pCodigo)
            dFila = General.cargarItem(objFormato.sqlCargarRegistro, params)
            txtAnamnesisN.Text = dFila.Item("Anamnesis").ToString
            txtAnamnesis.Text = dFila.Item("Anamnesis").ToString
            txtAnteM.Text = dFila.Item("Medico").ToString
            txtAnteQ.Text = dFila.Item("Quirurgico").ToString
            txtAnteT.Text = dFila.Item("Traumatico").ToString
            txtAnteTr.Text = dFila.Item("Transfucionales").ToString
            txtAnteA.Text = dFila.Item("Alergico").ToString
            txtAnteTo.Text = dFila.Item("Toxico").ToString
            txtAnteF.Text = dFila.Item("Ant_Familiares").ToString
            txtRevision.Text = dFila.Item("Revision_Sistema").ToString
            txtSig_vitalesN.Text = dFila.Item("Signo_Vitales").ToString
            txtInfoSigV.Text = dFila.Item("Signo_Vitales").ToString
            txtCab_cuelloN.Text = dFila.Item("Cabeza_Cuello").ToString
            txtInfoCabCu.Text = dFila.Item("Cabeza_Cuello").ToString
            txtToraxN.Text = dFila.Item("Torax").ToString
            txtInfoTorax.Text = dFila.Item("Torax").ToString
            txtCardioN.Text = dFila.Item("Cardio_Pulmonar").ToString
            txtInfoCardio.Text = dFila.Item("Cardio_Pulmonar").ToString
            txtAbdomenN.Text = dFila.Item("Abdomen").ToString
            txtInfoAbdomen.Text = dFila.Item("Abdomen").ToString
            txtGenitoN.Text = dFila.Item("Gestion_Urinaria").ToString
            txtInfoGenito.Text = dFila.Item("Gestion_Urinaria").ToString
            txtExtremidadesN.Text = dFila.Item("Extremidades").ToString
            txtInfoExtrem.Text = dFila.Item("Extremidades").ToString
            txtS_NervN.Text = dFila.Item("Nervio_Central").ToString
            txtInfoSNerv.Text = dFila.Item("Nervio_Central").ToString
            txtInfoParaclinico.Text = dFila.Item("Paraclinico").ToString
            txtAnalisisN.Text = dFila.Item("Analisis").ToString
            txtInfoAnalisis.Text = dFila.Item("Analisis").ToString
            txtPronosticoN.Text = dFila.Item("Pronostico").ToString
            txtInfoPronos.Text = dFila.Item("Pronostico").ToString
            txtTipoParto.Text = dFila.Item("Tipo_Parto").ToString
            txtTRupturaM.Text = dFila.Item("Ruptura_Memb").ToString
            txtInduccionP.Text = dFila.Item("Induccion_Parto").ToString
            txtApgar1N.Text = dFila.Item("Apgar1").ToString
            txtApgar2.Text = dFila.Item("Apgar5").ToString
            txtRmacionN.Text = dFila.Item("Reanimacion_Nacer").ToString
            txtEdadMadreN.Text = dFila.Item("Edad_Madre").ToString
            txtEdadGestN.Text = dFila.Item("Edad_Gestacional").ToString
            txtFumN.Text = dFila.Item("Fum").ToString
            txtObstetricosN.Text = dFila.Item("Obstetrico").ToString
            txtHemMN.Text = dFila.Item("Hemo_Madre").ToString
            txtHemPN.Text = dFila.Item("Hemo_Padre").ToString
            txtControlPN.Text = dFila.Item("Control_Prenatal").ToString
            txtMedDurEmbN.Text = dFila.Item("Med_Durante_Emb").ToString
            txtHabitosN.Text = dFila.Item("Habitos").ToString
            txtInfeccionesN.Text = dFila.Item("Infecciones_Emb").ToString
            txtDiabeteGN.Text = dFila.Item("Diab_Gestional").ToString
            txtDiabeteMN.Text = dFila.Item("Diab_Mellitud").ToString
            txtHiperGN.Text = dFila.Item("Hiper_Gestional").ToString
            txtPreeclampciaN.Text = dFila.Item("Preclampcia").ToString
            txtVacunacionN.Text = dFila.Item("Vacunacion").ToString
            txtEnferTN.Text = dFila.Item("Tiroidea").ToString
            txtTorch.Text = dFila.Item("Torch").ToString
            txtHemoclasificacionN.Text = dFila.Item("Hemo_Menor").ToString
            txtVDRLN.Text = dFila.Item("VDRL").ToString
            txtTSHN.Text = dFila.Item("TSH").ToString
            txtGlucometriasN.Text = dFila.Item("Glucometria").ToString
            txtGeneralesN.Text = dFila.Item("Generales").ToString
            txtCaractLiquidoN.Text = dFila.Item("Caract_Liquido").ToString
            cargarDiagnosticoImpresion(pCodigo)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub cargarDiagnosticoImpresion(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        params.Add(If(modulo = Constantes.HC, 1, Nothing))
        General.llenarTabla(objFormato.sqlCargarDiagnoticoImpresion, params, objHistoriaClinica.objInfoIngreso.dtDiagImpresion)
        With dgvImpresion
            .DataSource = objHistoriaClinica.objInfoIngreso.dtDiagImpresion
            .Columns(0).DisplayIndex = 3
            .AutoGenerateColumns = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
        If servicioNeonatal = False Then
            objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.Add()
        Else
            objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.Add()
        End If
    End Sub
    Private Sub buscarFormatoIngreso()
        Try
            Dim params As New List(Of String)
            params.Add(objHistoriaClinica.nRegistro)
            General.buscarElemento(Consultas.FORMATO_INGRESO_LISTA,
                              params,
                              AddressOf cargarOrdenFormatoIngreso,
                              TitulosForm.BUSQUEDA_FORMATO_INGRESO,
                              True)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarOrdenFormatoIngreso(pCodigo As String)
        cargarMedicamentos(pCodigo)
        cargarParaclinico(pCodigo)
    End Sub
    Private Sub cargarMedicamentos(pCodigo As String)
        Dim dtMed As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        params.Add(If(modulo = Constantes.HC, 1, Nothing))
        Try
            General.llenarTabla(objFormato.sqlCargarMedicamentos, params, dtMed)
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Clear()
            For Each fila As DataRow In dtMed.Select
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.ImportRow(fila)
                llenarMedicamentoFormatoIngreso()
            Next
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows.Add()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarParaclinico(pCodigo As String)
        Dim dtParac As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        params.Add(If(modulo = Constantes.HC, 1, Nothing))
        Try
            General.llenarTabla(objFormato.sqlCargarParaclinicos, params, dtParac)
            objHistoriaClinica.objOrdenMedica.dtParaclinicos.Clear()
            For Each fila As DataRow In dtParac.Select
                objHistoriaClinica.objOrdenMedica.dtParaclinicos.ImportRow(fila)
                llenarParaclinicoFormatoIngreso()
            Next
            objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Add()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarMedicamentoFormatoIngreso()
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Dosis") = Constantes.VALOR_VALIDO
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("CódigoVia") = Constantes.VALOR_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("DescripciónVia") = Constantes.TEXTO_NO_APLICA
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Suspender") = False
        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Dias") = Constantes.VALOR_VALIDO
        dgvMedicamento.Columns("dgDosisMed").ReadOnly = False
        dgvMedicamento.Columns("dgHorarioMed").ReadOnly = False
        dgvMedicamento.Columns("dgInicioMed").ReadOnly = False
        dgvMedicamento.Columns("dgSuspenderMed").ReadOnly = False
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgDosisMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgHorarioMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgHorarioMed").Value = Constantes.ITEM_dgv_SELECCIONE
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgInicioMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgInicioMed").Value = Constantes.ITEM_dgv_SELECCIONE
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgSuspenderMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgDosisMed").Selected = True
        dgvMedicamentoDisplayIndex()
        If Not SesionActual.tienePermiso(pEditarHoras) Then
            dgvMedicamento.Columns("dgInicioMed").ReadOnly = True
        End If
        abrirSolicitudNOPOSoJustificacion(Constantes.OM_MEDICAMENTO)
    End Sub
    Private Sub llenarParaclinicoFormatoIngreso()
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 1).Item("Indicación") = ""
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 1).Item("Justificación") = ""
        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows(dgvParaclinico.Rows.Count - 1).Item("Resultado") = Constantes.VALOR_VALIDO
        dgvParaclinico.Columns("dgCantidadPara").ReadOnly = False
        dgvParaclinico.Rows(dgvParaclinico.Rows.Count - 1).Cells("dgCantidadPara").ReadOnly = True
        dgvParaclinico.Rows(dgvParaclinico.Rows.Count - 1).Cells("dgCantidadPara").Selected = True
    End Sub
    Private Sub dgvExamenParaclinicos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamenParaclinicos.CellContentDoubleClick
        Dim objExamen As ParaclinicoLaboratorio
        Dim nombreArchivo, ruta As String
        If dgvExamenParaclinicos.RowCount > 0 Then
            objExamen = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_EXAMEN_LAB & Tag.modulo)
            If dgvExamenParaclinicos.Rows(dgvExamenParaclinicos.CurrentCell.RowIndex).Cells("dgEstadoP").Value = Constantes.ITEM_MODIFICADO Then
                objExamen.codigoProcedimiento = dgvExamenParaclinicos.Rows(dgvExamenParaclinicos.CurrentCell.RowIndex).Cells("dgCodigoP").Value
                objExamen.codigoOrden = txtCodigoEnfermeria.Text
                objExamen.tipoExamen = dgvExamenParaclinicos.Rows(dgvExamenParaclinicos.CurrentCell.RowIndex).Cells("dgCodigoTipoParaclinico").Value
                objExamen.registro = nRegistro
                objExamen.cargarNombrePDF()
                Try
                    nombreArchivo = objExamen.area & ConstantesHC.NOMBRE_PDF_SEPARADOR & objExamen.codigoOrden & ConstantesHC.EXTENSION_ARCHIVO_PDF
                    ruta = IO.Path.GetTempPath() & nombreArchivo
                    objExamen.imprimir()
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try

            End If
        End If
    End Sub

    Private Sub dgvExamenParaclinicos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamenParaclinicos.CellClick

    End Sub

    Private Sub tsPrefactura_Click(sender As Object, e As EventArgs) Handles tsPrefactura.Click
        If SesionActual.tienePermiso(pVerPrefactura) Then
            Cursor = Cursors.WaitCursor
            tsPrefactura.Enabled = False
            tsPrefactura.Text = "Generando..."
            Try
                Dim params As New List(Of String)
                params.Add(nRegistro)
                params.Add(SesionActual.idUsuario)
                If SesionActual.tienePermiso(pPrefacturar) AndAlso modulo = Constantes.CODIGO_MENU_AUDF And Not _
                        (txtEstadoAtencion.Text.ToUpper.Contains("PREFACT") OrElse txtEstadoAtencionN.Text.ToUpper.Contains("PREFACT")) And Not _
                        (txtEstadoAtencion.Text.ToUpper.Contains("REVISI") OrElse txtEstadoAtencionN.Text.ToUpper.Contains("REVISI")) Then
                    txtEstadoAtencion.Text = General.getValorConsulta(ConsultasHC.ESTADO_PREFACTURADO_CAMBIAR, params)
                    txtEstadoAtencionN.Text = txtEstadoAtencion.Text
                    If txtEstadoAtencion.Text.ToUpper.Contains("PREFACT") OrElse txtEstadoAtencionN.Text.ToUpper.Contains("PREFACT") Then
                        tsmVisado.Visible = True
                    End If
                End If
                params.Clear()
                params.Add(nRegistro)
                params.Add(modulo)
                If General.getEstadoVF(ConsultasHC.PREFACTURA_VERIFICAR, params) = True Then
                    MsgBox(Mensajes.REPORTE_EN_PROGRESO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Dim guardarEn2doPlano As Thread
                guardarEn2doPlano = New Thread(AddressOf generarPrefactura)
                guardarEn2doPlano.Name = "Generar prefactura"
                guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
                guardarEn2doPlano.Start()
                ' MsgBox(Mensajes.SEGUNDO_PLANO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub anularNotaFisio()
        objHistoriaClinica.objFisioterapia.objNotaFisio.codigoNota = txtCodigoFisioterapia.Text
        objHistoriaClinica.objFisioterapia.objNotaFisio.usuario = usuarioActual
        objHistoriaClinica.objFisioterapia.objNotaFisio.codigoEP = SesionActual.codigoEP
        objHistoriaClinica.objFisioterapia.anularNotaFisio()

    End Sub

    Private Sub tsEnferanular_Click(sender As Object, e As EventArgs) Handles tsenferanular.Click
        Try
            If opcionEnferSeleccionado = ConstantesHC.ORDEN_INSUMO_ENFER_SELECCION Then
                If SesionActual.tienePermiso(pAnularOie) Then
                    objHistoriaClinica.objEnfermeria.opcionCancelar = False
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        objHistoriaClinica.objEnfermeria.objInsumosEnfer.codigoOrden = txtCodigoEnfermeria.Text
                        objHistoriaClinica.objEnfermeria.objInsumosEnfer.usuario = usuarioActual
                        objHistoriaClinica.objEnfermeria.objInsumosEnfer.codigoEP = SesionActual.codigoEP
                        objHistoriaClinica.objEnfermeria.anularOrdenInsumoEnfer()
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        listarEnfermeria()
                        listaInsumosEnfer.Focus()
                        verificarSoat()
                    End If
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            ElseIf opcionEnferSeleccionado = ConstantesHC.NOTA_ENFER_SELECCION Then
                If SesionActual.tienePermiso(pAnularNe) Then
                    objHistoriaClinica.objEnfermeria.opcionCancelar = False
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        objHistoriaClinica.objEnfermeria.objNotaEnfer.codigoNota = txtCodigoEnfermeria.Text
                        objHistoriaClinica.objEnfermeria.objNotaEnfer.usuario = usuarioActual
                        objHistoriaClinica.objEnfermeria.objNotaEnfer.codigoEP = SesionActual.codigoEP
                        objHistoriaClinica.objEnfermeria.anularNotaEnfer()
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        listarEnfermeria()
                        listaNotasEnfer.Focus()
                    End If
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub tsfisioduplicar_Click(sender As Object, e As EventArgs) Handles tsfisioduplicar.Click
        If opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION Then
            If SesionActual.tienePermiso(pDuplicarOi) Then
                If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                    Dim tbl As DataRow = Nothing
                    Dim params As New List(Of String)
                    params.Add(Constantes.LISTA_CARGO_FISIOTERAPIA)
                    params.Add(SesionActual.idEmpresa)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                    tbl = formBusqueda.rowResultados
                    If tbl IsNot Nothing Then
                        objHistoriaClinica.objFisioterapia.objInsumosFisio.usuarioReal = tbl(0)
                        txtNombreUsuarioInforme.Text = tbl(1)
                    Else
                        MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
                deshabilitarGroupBoxFisio()
                gbInsumoFisio.Enabled = True
                editaDuplicaOpcionesInsumoFisio()
                txtCodigoFisioterapia.Clear()
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaFisioterapia)
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        ElseIf opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION Then
            If SesionActual.tienePermiso(pDuplicarNf) Then
                If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                    Dim tbl As DataRow = Nothing
                    Dim params As New List(Of String)
                    params.Add(Constantes.LISTA_CARGO_FISIOTERAPIA)
                    params.Add(SesionActual.idEmpresa)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                    tbl = formBusqueda.rowResultados
                    If tbl IsNot Nothing Then
                        objHistoriaClinica.objFisioterapia.objNotaFisio.usuarioReal = tbl(0)
                        txtNombreUsuarioInforme.Text = tbl(1)
                    Else
                        MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
                deshabilitarGroupBoxFisio()
                gbNotaFisio.Enabled = True
                editaDuplicaOpcionesNotaFisio()
                txtCodigoFisioterapia.Clear()
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaFisioterapia)
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsfisioeditar_Click(sender As Object, e As EventArgs) Handles tsfisioeditar.Click
        If opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION Then
            If SesionActual.tienePermiso(pEditarOx) Then
                deshabilitarGroupBoxFisio()
                groupBoxOxigeno.Enabled = True
                opcionesFisio()
                dgvOxigenoFisio.Focus()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        ElseIf opcionFisioSeleccionado = ConstantesHC.NEBULIZACION_SELECCION Then
            If SesionActual.tienePermiso(pEditarNe) Then
                deshabilitarGroupBoxFisio()
                groupBoxNeb.Enabled = True
                opcionesFisio()
                dgvNebulizacion.Focus()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        ElseIf opcionFisioSeleccionado = ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION Then
            If SesionActual.tienePermiso(pEditarOi) Then
                deshabilitarGroupBoxFisio()
                gbInsumoFisio.Enabled = True
                editaDuplicaOpcionesInsumoFisio()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If

        ElseIf opcionFisioSeleccionado = ConstantesHC.TERAPIA_SELECCION Then
            If SesionActual.tienePermiso(pEditarTp) Then
                deshabilitarGroupBoxFisio()
                gbTerapia.Enabled = True
                editaDuplicaOpcionesTerapia()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        ElseIf opcionFisioSeleccionado = ConstantesHC.NOTA_FISIO_SELECCION Then
            If SesionActual.tienePermiso(pEditarNf) Then
                deshabilitarGroupBoxFisio()
                gbNotaFisio.Enabled = True
                editaDuplicaOpcionesNotaFisio()
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
    Private Sub deshabilitarGroupBoxFisio()
        groupBoxOxigeno.Enabled = False
        groupBoxNeb.Enabled = False
        gbTerapia.Enabled = False
        gbInsumoFisio.Enabled = False
        gbNotaFisio.Enabled = False
    End Sub
    Private Sub deshabilitarGroupBoxEnfer()
        GroupBoxInsuEnfer.Enabled = False
        GroupBoxNotaEnfer.Enabled = False
        GroupBoxGluco.Enabled = False
    End Sub
    Private Sub tsfisionuevo_Click(sender As Object, e As EventArgs) Handles tsfisionuevo.Click
        objHistoriaClinica.objFisioterapia.opcionCancelar = False
        Try
            Select Case opcionFisioSeleccionado
                Case ConstantesHC.ORDEN_INSUMO_FISIO_SELECCION
                    If SesionActual.tienePermiso(pNuevaOi) Then
                        If modulo <> Constantes.HC AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                            Dim tbl As DataRow = Nothing
                            peritirVisibilidadbusquedaFisioterapeutas(tbl)
                            If tbl IsNot Nothing Then
                                objHistoriaClinica.objFisioterapia.objInsumosFisio.usuarioReal = tbl(0)
                                txtNombreUsuarioInforme.Text = tbl(1)
                            Else
                                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If
                        Else
                            objHistoriaClinica.objFisioterapia.objInsumosFisio.usuarioReal = SesionActual.idUsuario
                            txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
                        End If
                        listaInsumosfisio.SelectedIndex = 0
                        ordenNuevaInsumoFisio()
                    Else
                        MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Case ConstantesHC.NOTA_FISIO_SELECCION
                    If SesionActual.tienePermiso(pNuevaNf) Then
                        If modulo <> Constantes.HC AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                            Dim tbl As DataRow = Nothing
                            peritirVisibilidadbusquedaFisioterapeutas(tbl)
                            If tbl IsNot Nothing Then
                                objHistoriaClinica.objFisioterapia.objNotaFisio.usuarioReal = tbl(0)
                                txtNombreUsuarioInforme.Text = tbl(1)
                            Else
                                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If
                        Else
                            objHistoriaClinica.objFisioterapia.objNotaFisio.usuarioReal = SesionActual.idUsuario
                            txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
                        End If

                        listaNotasfisio.SelectedIndex = 0
                        ordenNuevaNotaFisio()
                    Else
                        MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                    End If
                Case ConstantesHC.OXIGENO_SELECCION
                    If SesionActual.tienePermiso(pNuevaOx) Then
                        If modulo <> Constantes.HC AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                            Dim tbl As DataRow = Nothing
                            peritirVisibilidadbusquedaFisioterapeutas(tbl)
                            If tbl IsNot Nothing Then
                                objHistoriaClinica.objFisioterapia.objOxigeno.usuarioReal = tbl(0)
                                txtNombreUsuarioInforme.Text = tbl(1)
                            Else
                                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If
                        Else
                            objHistoriaClinica.objFisioterapia.objOxigeno.usuarioReal = SesionActual.idUsuario
                            txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
                        End If
                    Else
                        MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                    End If
            End Select
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaFisioterapia)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Sub peritirVisibilidadbusquedaFisioterapeutas(ByRef fila As DataRow)
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_FISIOTERAPIA)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
        fila = formBusqueda.rowResultados
    End Sub
    Private Sub ordenNuevaInsumoFisio()
        fechaFisioterapia.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        deshabilitarGroupBoxFisio()
        gbInsumoFisio.Enabled = True
        cargarInsumoFisio()
        objHistoriaClinica.objFisioterapia.objInsumosFisio.nRegistro = nRegistro
        objHistoriaClinica.objFisioterapia.objInsumosFisio.fechaOrden = fechaFisioterapia.Value.Date
        objHistoriaClinica.objFisioterapia.cargarInsumoFisioAutomatico()
        editaDuplicaOpcionesInsumoFisio()
    End Sub
    Private Sub ordenNuevaNotaFisio()
        fechaFisioterapia.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        deshabilitarGroupBoxFisio()
        gbNotaFisio.Enabled = True
        cargarNotaFisio()
        objHistoriaClinica.objFisioterapia.objNotaFisio.nRegistro = nRegistro
        objHistoriaClinica.objFisioterapia.objNotaFisio.fechaNota = fechaFisioterapia.Value.Date
        editaDuplicaOpcionesNotaFisio()
    End Sub
    Private Sub ordenNuevaInsumoEnfer()
        deshabilitarGroupBoxEnfer()
        GroupBoxInsuEnfer.Enabled = True
        cargarInsumoEnfer()
        objHistoriaClinica.objEnfermeria.objInsumosEnfer.nRegistro = nRegistro
        objHistoriaClinica.objEnfermeria.objInsumosEnfer.fechaOrden = fechaEnfermeria.Value.Date
        objHistoriaClinica.objEnfermeria.cargarInsumoEnferAutomatico()
        editaDuplicaOpcionesInsumoEnfer()
    End Sub

    Private Sub listaHemoderivados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaHemoderivados.SelectedIndexChanged
        Try
            If listaHemoderivados.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaHemoderivados.SelectedIndex) Then
                txtCodigoEnfermeria.Clear()
                If Not IsNothing(dgvExamenHemoderivados.DataSource) Then
                    dgvExamenHemoderivados.DataSource.clear
                End If
                HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEnfermeria)
            Else
                cargarHemoderivados()
                edicionSegunRegistro(listaHemoderivados, TSEnfermeria)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvExamenHemoderivados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamenHemoderivados.CellClick
        Dim form As Object
        If objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer.Rows.Count > 0 Then
            If e.ColumnIndex = 1 Then
                form = New Form_resultado
                form.cargarResultado(txtCodigoEnfermeria.Text,
                                     objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer.Rows(dgvExamenHemoderivados.CurrentCell.RowIndex).Item("CodigoH"),
                                     objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer.Rows(dgvExamenHemoderivados.CurrentCell.RowIndex).Item("ExamenH"),
                                     modulo,
                                     If(objHistoriaClinica.objEnfermeria.objHemoderivado.dtHemoderivadoEnfer.Rows(dgvExamenHemoderivados.CurrentCell.RowIndex).Item("CodigoTipoExamenH") _
                                     = ConstantesHC.CODIGO_IMAGENOLOGIA, 1, 0), Constantes.TipoEXAM)

                form.historiaClinica = Me
                form.MdiParent = FormPrincipal
                form.Show()
                form.Focus()
            End If
        End If
    End Sub
    Private Sub dgvEstancia_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEstancia.CellEnter
        bloquearDgvEstancia()
    End Sub
    Private Sub ColocarCPAPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColocarCPAPToolStripMenuItem.Click
        objHistoriaClinica.objFisioterapia.objOxigeno.colocarCPAP(dgvOxigenoFisio.CurrentRow.Index)
        Dim filaActualCPAP As Integer = dgvOxigenoFisio.CurrentRow.Index
        For indiceFila = filaActualCPAP To filaActualCPAP + 3
            objHistoriaClinica.objFisioterapia.objOxigeno.totalizarMinutosLitrosPorFila(indiceFila)
            colocarColorFilaNueva(indiceFila)
        Next
        totalizarOxigeno()
    End Sub
    Private Sub ordenNuevaNotaEnfer()
        deshabilitarGroupBoxEnfer()
        GroupBoxNotaEnfer.Enabled = True
        cargarNotaEnfer()
        objHistoriaClinica.objEnfermeria.objNotaEnfer.nRegistro = nRegistro
        objHistoriaClinica.objEnfermeria.objNotaEnfer.fechaNota = fechaEnfermeria.Value.Date
        editaDuplicaOpcionesNotaEnfer()
    End Sub
    Private Sub ordenNuevaGlucomEnfer()
        deshabilitarGroupBoxEnfer()
        cargarGlucomEnfer()
        objHistoriaClinica.objEnfermeria.objGlucomEnfer.nRegistro = nRegistro
        objHistoriaClinica.objEnfermeria.objGlucomEnfer.fechaOrden = fechaEnfermeria.Value.Date
        editaDuplicaOpcionesGlucomEnfer()
    End Sub


    Private Sub dgvEstancia_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvEstancia.RowPostPaint
        General.generarSecuencial(dgvEstancia, e)
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
    Private Sub txtNombreUsuarioInf_MouseDoubleClick(sender As Object, e As EventArgs) Handles txtNombreUsuarioINF.MouseDoubleClick, txtNombreUsuarioINFN.MouseDoubleClick
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso tsinfoguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_ORDEN_MEDICA, objHistoriaClinica.objInfoIngreso.usuarioReal)
        End If
    End Sub
    Private Sub txtNombreUsuarioevo_MouseDoubleClick(sender As Object, e As EventArgs) Handles txtNombreUsuarioEVO.MouseDoubleClick
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso tsevoguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_EVOLUCION, objHistoriaClinica.objEvolucionMedica.usuarioReal)
        End If
    End Sub

    Private Sub txtNombreUsuarioINT_MouseDoubleClick(sender As Object, e As EventArgs) Handles txtNombreUsuarioINT.MouseDoubleClick
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso tsinterguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_INTERCONSULTA, objHistoriaClinica.objInterconsulta.usuarioReal)
        End If
    End Sub

    Private Sub Listaremisiones_MouseDoubleClick(sender As Object, e As EventArgs) Handles Listaremisiones.MouseDoubleClick
        If Listaremisiones.Enabled = False AndAlso SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso tsremguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_REMISION, objHistoriaClinica.objRemision.usuarioReal)
        End If
    End Sub

    Private Sub txtNombreUsuarioOM_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtNombreUsuarioOM.MouseDoubleClick
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso tsordenguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_ORDEN_MEDICA, objHistoriaClinica.objOrdenMedica.usuarioReal)
        End If
    End Sub
    Private Sub tsEpicrisis_Click(sender As Object, e As EventArgs) Handles tsEpicrisis.Click
        FormEpicrisis.tomarModulo(Tag.modulo)
        General.cargarForm(FormEpicrisis)

        FormEpicrisis.tomarRegistro(nRegistro)
        FormEpicrisis.cargarEpicrisis()
    End Sub

    Private Sub fechaEnfermeria_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechaEnfermeria.Validating
        If objHistoriaClinica.objEnfermeria.opcionCancelar = True Then
            Exit Sub
        End If
        Dim paramsPermisos As New List(Of String)
        paramsPermisos.Add(pIntervalo4horas)
        paramsPermisos.Add(pDocumentoIntermedio)
        mensajeError = GeneralHC.validarFecha(modulo, nRegistro, fechaEnfermeria, CDate(txtAdmision.Text), paramsPermisos)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            e.Cancel = True
            fechaEnfermeria.Focus()
        End If
    End Sub

    Private Sub fechaFisioterapia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechaFisioterapia.Validating
        If objHistoriaClinica.objFisioterapia.opcionCancelar = True OrElse
            opcionFisioSeleccionado = ConstantesHC.OXIGENO_SELECCION OrElse
            opcionFisioSeleccionado = ConstantesHC.NEBULIZACION_SELECCION Then
            Exit Sub
        End If
        Dim paramsPermisos As New List(Of String)
        paramsPermisos.Add(pIntervalo4horas)
        paramsPermisos.Add(pDocumentoIntermedio)
        mensajeError = GeneralHC.validarFecha(modulo, nRegistro, fechaFisioterapia, CDate(txtAdmision.Text), paramsPermisos)
        If mensajeError <> "" Then
            MsgBox(mensajeError, MsgBoxStyle.Exclamation)
            e.Cancel = True
            fechaFisioterapia.Focus()
        End If
    End Sub

    Private Sub tsremanular_Click(sender As Object, e As EventArgs) Handles tsremanular.Click
        objHistoriaClinica.objRemision.opcionCancelar = False
        If SesionActual.tienePermiso(pAnularRm) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objRemision.anularRemision()

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                listarRemisiones()

            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsremduplicar_Click(sender As Object, e As EventArgs) Handles tsremduplicar.Click
        objHistoriaClinica.objRemision.opcionCancelar = False
        If SesionActual.tienePermiso(pDuplicarRm) Then
            If MsgBox(Mensajes.DUPLICAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.DUPLICAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_REMISION)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objRemision.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            txtcodigoRemision.Clear()
            General.habilitarControles(remisiones)
            General.deshabilitarBotones_HC(TSRemisiones)
            tsremguardar.Enabled = True
            tsremcancelar.Enabled = True
            GroupBoxAnexo9.Focus()
            Listaremisiones.Enabled = False
            txtcodigoevolucion.ReadOnly = True
            txtModalidadApoyo.ReadOnly = True
            txtReferenciaOx.ReadOnly = True
            txtServicioAmb.ReadOnly = True
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaRemision)
            fechaRemision.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsremeditar_Click(sender As Object, e As EventArgs) Handles tsremeditar.Click
        objHistoriaClinica.objRemision.opcionCancelar = False
        If SesionActual.tienePermiso(pEditarRm) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            General.habilitarControles(remisiones)
            General.deshabilitarBotones_HC(TSRemisiones)
            tsremguardar.Enabled = True
            tsremcancelar.Enabled = True
            GroupBoxAnexo9.Focus()
            btCorreo.Enabled = False
            CheckEnviado.Enabled = False
            Listaremisiones.Enabled = False
            txtcodigoevolucion.ReadOnly = True
            txtModalidadApoyo.ReadOnly = True
            txtReferenciaOx.ReadOnly = True
            txtServicioAmb.ReadOnly = True
            btReferenciaOx.Enabled = rboxigenoSI.Checked
            btServicioAmb.Enabled = rbambuSI.Checked
            fechaRemision.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub dgvProcedimiento_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProcedimiento.CellContentDoubleClick
        Dim form As Object
        If objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows.Count > 0 And Not String.IsNullOrEmpty(txtCodigoOrden.Text) Then
            Try
                If e.ColumnIndex = dgvProcedimiento.Columns("dgResultadoProce").Index Then
                    form = New Form_resultado
                    form.historiaClinica = Me
                    form.cargarResultado(txtCodigoOrden.Text,
                                         objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Código"),
                                         objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Descripción"),
                                         modulo,
                                          0, Constantes.TipoEXAM, txtRegistro.Text)
                    form.MdiParent = FormPrincipal
                    form.Show()
                    form.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If e.ColumnIndex = dgvProcedimiento.Columns("dgFormatoProce").Index And
                (objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Descripción").ToString.ToLower.Contains("angioplas") OrElse
                 objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Descripción").ToString.ToLower.Contains("arteriog")) Then
                Try
                    Dim objFormCateterismo As New FormCateterismoHemodinamia
                    objFormCateterismo.objHistoriaClinica = objHistoriaClinica
                    objFormCateterismo.objFormHistoriaClinica = Me
                    objFormCateterismo.codigoExamen = objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Código")
                    objFormCateterismo.codigoOrden = txtCodigoOrden.Text
                    objFormCateterismo.ShowDialog()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub dgvGlucometriaEnfer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlucometriaEnfer.CellClick
        If tsenferguardar.Enabled = False Then Exit Sub
        Try
            If opcionEnferSeleccionado = ConstantesHC.GLUCOMETRIA_SELECCION Then
                If Funciones.verificacionPosicionActual(dgvGlucometriaEnfer, e, "dgHoraDia") Then
                    dtHoraGlucom.Text = dgvGlucometriaEnfer.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    dibujaPanelGlucometria()
                    dtHoraGlucom.Enabled = True
                    dtHoraGlucom.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tsremnuevo_Click(sender As Object, e As EventArgs) Handles tsremnuevo.Click
        objHistoriaClinica.objRemision.opcionCancelar = False
        If SesionActual.tienePermiso(pNuevaRm) Then
            Dim params As New List(Of String)
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing
                params.Add(Constantes.LISTA_CARGO_REMISION)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objRemision.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox("Debe seleccionar el empleado para continuar", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                objHistoriaClinica.objRemision.usuarioReal = SesionActual.idUsuario
                txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
            End If
            objHistoriaClinica.objRemision.codigoOrden = ""
            objHistoriaClinica.objRemision.especialidad = Constantes.VALOR_PREDETERMINADO
            objHistoriaClinica.objRemision.traslados = Constantes.VALOR_PREDETERMINADO
            General.limpiarControles(remisiones)
            General.habilitarControles(remisiones)
            General.deshabilitarBotones_HC(TSRemisiones)
            tsremguardar.Enabled = True
            tsremcancelar.Enabled = True
            btCorreo.Enabled = False
            CheckEnviado.Enabled = False
            btReferenciaOx.Enabled = False
            btServicioAmb.Enabled = False
            GroupBoxAnexo9.Focus()
            Listaremisiones.Enabled = False
            txtcodigoevolucion.ReadOnly = True
            txtModalidadApoyo.ReadOnly = True
            txtReferenciaOx.ReadOnly = True
            txtServicioAmb.ReadOnly = True
            Dim dt As New DataTable
            params.Clear()
            params.Add(nRegistro)
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaRemision)
            General.llenarTabla(objHistoriaClinica.objEvolucionMedica.consultaUltimaEvolucion, params, dt)
            params.Clear()
            If dt.Rows.Count = 0 Then Exit Sub
            params.Add(dt.Rows(0).Item("Codigo_Evo").ToString())
            dt = New DataTable
            General.llenarTabla(objHistoriaClinica.objEvolucionMedica.evolucionCargar, params, dt)
            If dt.Rows.Count > 0 Then
                Dim dtInterpretaciones As New DataTable
                params.Add(nRegistro)
                params.Add(Format(CDate(dt.Rows(0).Item("Fecha_Evo").ToString()), Constantes.FORMATO_FECHA_GEN2))
                General.llenarTabla(objHistoriaClinica.objEvolucionMedica.paraclinicoCargar, params, dtInterpretaciones)
                For i = 0 To dtInterpretaciones.Rows.Count - 1
                    txtdatos.Text = txtdatos.Text & dtInterpretaciones.Rows(i).Item("Descripción") & ": " &
                                dtInterpretaciones.Rows(i).Item("Interpretación").ToString() & vbCrLf
                Next
                txtdatos.Text = dt.Rows(0).Item("Subjetivo").ToString() & vbCrLf &
                                dt.Rows(0).Item("Sig_Vitales").ToString() & vbCrLf &
                                dt.Rows(0).Item("Cab_Cuello").ToString() & vbCrLf &
                                dt.Rows(0).Item("Torax").ToString() & vbCrLf &
                                dt.Rows(0).Item("Card_Pulm").ToString() & vbCrLf &
                                dt.Rows(0).Item("Abdom").ToString() & vbCrLf &
                                dt.Rows(0).Item("Genturinario").ToString() & vbCrLf &
                                dt.Rows(0).Item("Extrem").ToString() & vbCrLf &
                                dt.Rows(0).Item("S_Nerv_Central").ToString() & vbCrLf & vbCrLf &
                                txtdatos.Text & vbCrLf &
                                dt.Rows(0).Item("Analisis").ToString() & vbCrLf &
                                dt.Rows(0).Item("Plan_Trtmnto").ToString() & vbCrLf
            Else
                MsgBox("No hay evolución realizada para hoy", MsgBoxStyle.Information + MsgBoxStyle.Exclamation)
            End If
            fechaRemision.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dtHoraGlucometria_KeyDown(sender As Object, e As KeyEventArgs) Handles dtHoraGlucom.KeyDown
        If e.KeyCode = Keys.Escape OrElse e.KeyCode = Keys.Enter Then
            dgvGlucometriaEnfer.Focus()
        End If
    End Sub
    Private Sub dtHoraGlucometria_Leave(sender As Object, e As EventArgs) Handles dtHoraGlucom.LostFocus
        Try
            Dim Hora As String = Format(Convert.ToDateTime(fechaEnfermeria.Value), "HH:mm:ss")
            panelGlucom.Visible = False
            dgvGlucometriaEnfer.CurrentCell = dgvGlucometriaEnfer.Rows(dgvGlucometriaEnfer.CurrentCell.RowIndex).Cells("dgHoraDia")
            objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows(dgvGlucometriaEnfer.CurrentCell.RowIndex).Item("HoraDia") = dtHoraGlucom.Text
            'dgvGlucometriaEnfer.CommitEdit(DataGridViewDataErrorContexts.Commit)
            'dgvGlucometriaEnfer.EndEdit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvGlucometriaEnfer_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvGlucometriaEnfer.DataError
        If e.ColumnIndex = 3 Then
            MsgBox("¡ Valor no valido solo numeros enteros son permitidos !", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsinteranular_Click(sender As Object, e As EventArgs) Handles tsinteranular.Click
        If SesionActual.tienePermiso(pAnularIc) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objInterconsulta.anularInterconsulta()
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                listarInterconsultas()

            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsintereditar_Click(sender As Object, e As EventArgs) Handles tsintereditar.Click
        If SesionActual.tienePermiso(pEditarIc) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_INTERCONSULTA)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objInterconsulta.usuario = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                objHistoriaClinica.objInterconsulta.usuarioReal = SesionActual.idUsuario
                txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
            End If
            txtRespuesta.ReadOnly = False
            General.deshabilitarBotones_HC(TSInterconsultas)
            tsinterguardar.Enabled = True
            tsintercancelar.Enabled = True
            fechaInterconsulta.Enabled = True
            GroupBoxInfoInterconsulta.Focus()
            ListaInterconsultas.Enabled = False
            txtcodigoevolucion.ReadOnly = True
            txtNombreUsuarioOM.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsinternuevo_Click(sender As Object, e As EventArgs) Handles tsinternuevo.Click
        If SesionActual.tienePermiso(pNuevaIc) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_INTERCONSULTA)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objInterconsulta.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            General.limpiarControles(interconsultas)
            General.habilitarControles(interconsultas)
            General.deshabilitarBotones_HC(TSInterconsultas)
            tsinterguardar.Enabled = True
            tsintercancelar.Enabled = True
            fechaInterconsulta.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            GroupBoxInfoInterconsulta.Focus()
            ListaInterconsultas.Enabled = False
            txtcodigoevolucion.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tsevoanular_Click(sender As Object, e As EventArgs) Handles tsevoanular.Click
        objHistoriaClinica.objEvolucionMedica.opcionCancelar = False
        If SesionActual.tienePermiso(pAnularEm) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objEvolucionMedica.anularEvolucion()
                objHistoriaClinica.objEvolucionMedica.elementoAEliminar.Clear()
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                listarEvoluciones()
                Dim params As New List(Of String)
                params.Add(nRegistro)

            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub


    Private Sub tsevoduplicar_Click(sender As Object, e As EventArgs) Handles tsevoduplicar.Click
        objHistoriaClinica.objEvolucionMedica.opcionCancelar = False
        If SesionActual.tienePermiso(pDuplicarEm) Then
            If MsgBox(Mensajes.DUPLICAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.DUPLICAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_EVOLUCION)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objEvolucionMedica.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            objHistoriaClinica.objEvolucionMedica.elementoAEliminar.Clear()
            objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows.Add()
            txtcodigoevolucion.Clear()
            General.habilitarControles(evoluciones)
            General.deshabilitarBotones_HC(TSevoluciones)
            Listaevoluciones.Enabled = False
            tsevoguardar.Enabled = True
            tsevocancelar.Enabled = True
            txtcodigoevolucion.ReadOnly = True
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEvolucion)
            txtNombreUsuarioOM.ReadOnly = True
            reiniciarDtOrden(objHistoriaClinica.objEvolucionMedica.dtDiagnosticos)
            quitaInterpretacionRealizada()
            dgvParaclinicoEvo.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub quitaInterpretacionRealizada()
        cargarInterpretacionParaclinicos()
        objHistoriaClinica.objEvolucionMedica.paraclinicosDuplicar()

    End Sub
    Private Sub dibujarInterpretacionEvo()
        For I = 0 To objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows.Count - 1
            If objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Rows(I).Item("Resultado") = 1 Then
                dgvParaclinicoEvo.Rows(I).Cells("dgResultadosParaEvo").Value = My.Resources.OK
            Else
                dgvParaclinicoEvo.Rows(I).Cells("dgResultadosParaEvo").Value = My.Resources._new
            End If
        Next
        dgvParaclinicoEvo.Columns("Resultado").Visible = False
        dgvParaclinicoEvo.Columns("codigo_orden").Visible = False
        dgvParaclinicoEvo.Columns("obligatorio").Visible = False
        dgvParaclinicoEvo.Columns("dgResultadosParaEvo").DisplayIndex = 8
        dgvParaclinicoEvo.ReadOnly = True
    End Sub

    Private Sub btNotaAuditoriaNotif_Click(sender As Object, e As EventArgs) Handles btNotaAuditoriaNotif.Click
        If SesionActual.tienePermiso(pVisorNotaAuditoria) Then
            Dim formHojaRuta As New FormVisorHojaRuta
            formHojaRuta.objHistoriaClinica = objHistoriaClinica
            formHojaRuta.formHistoriaClinica = Me
            formHojaRuta.indicacion = 1
            formHojaRuta.ShowDialog()
            verificarColorNotaAud()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub verificarColorNotaAud()
        segundoPlanoColoreNotasAud()
    End Sub
    Public Sub verificarColorHojaRuta()
        segundoPlanoColoreHojaRuta()
    End Sub
    Private Sub segundoPlanoColoreHojaRuta()
        Try
            Dim estado As Boolean
            estado = Funciones.consultarEmpleadoHojaRuta(SesionActual.idUsuario, Date.Now, txtRegistro.Text)
            If estado = False Then
                desCombinacionColor()
            Else
                habCombinacionColores(estado, btVisorHojaRuta)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub segundoPlanoColoreNotasAud()
        Try
            Dim estado As Boolean
            estado = Funciones.consultarEmpleadoNotaAudit(SesionActual.idUsuario, txtRegistro.Text)
            habCombinacionColores(estado, btNotaAuditoriaNotif)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub desCombinacionColor()
        If abierto = True Then cerrar = True abierto = False
    End Sub
    Private Sub habCombinacionColores(estado As Boolean,
                                      ByRef boton As Object)

        '----------------------Combinacion de colores--------------------------------------
        'Thread.Sleep(500)
        Select Case estado
            Case True
                boton.BackColor = Color.Red
            Case False
                boton.BackColor = Control.DefaultBackColor
        End Select
        '------------------------en este codigo valido si esta pendiente alguna nota por realizar
        'If cerrar = True Then
        '    cerrar = False
        '    boton.BackColor = Control.DefaultBackColor
        'Else
        '    abierto = True
        'End If
        '-----------------------------------------------------------

    End Sub
    Private Sub tsevoeditar_Click(sender As Object, e As EventArgs) Handles tsevoeditar.Click
        objHistoriaClinica.objEvolucionMedica.opcionCancelar = False
        If SesionActual.tienePermiso(pEditarEm) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            objHistoriaClinica.objEvolucionMedica.elementoAEliminar.Clear()
            objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows.Add()
            General.habilitarControles(evoluciones)
            General.deshabilitarBotones_HC(TSevoluciones)
            Listaevoluciones.Enabled = False
            dgvDIAGEVO.ReadOnly = True
            tsevoguardar.Enabled = True
            tsevocancelar.Enabled = True
            txtcodigoevolucion.ReadOnly = True
            objHistoriaClinica.objEvolucionMedica.codigoEvolucion = txtcodigoevolucion.Text
            txtNombreUsuarioOM.ReadOnly = True
            dgvParaclinicoEvo.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvdiagRem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdiagRem.CellDoubleClick
        General.abrirJustificacion(dgvdiagRem, objHistoriaClinica.objInfoIngreso.dtDiagREMIsion, PanelJustificacionR, txtJustificacionR, "Observacion", True)
    End Sub
    Private Sub btVisorHojaRuta_Click(sender As Object, e As EventArgs) Handles btVisorHojaRuta.Click
        If SesionActual.tienePermiso(pHojaRuta) Then
            Dim formHojaRuta As New FormVisorHojaRuta
            formHojaRuta.objHistoriaClinica = objHistoriaClinica
            formHojaRuta.formHistoriaClinica = Me
            formHojaRuta.indicacion = 0
            formHojaRuta.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListaDeTareasPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btOpcionChequeo.Click

        Dim form As New FormFacturaImprimir

        form.registro(objListachequeo)
        FormPrincipal.Cursor = Cursors.WaitCursor
        form.ShowDialog()
        If form.WindowState = FormWindowState.Minimized Then
            form.WindowState = FormWindowState.Normal
        End If
        verificarListas()
        FormPrincipal.Cursor = Cursors.Default
    End Sub

    Public Sub verificarAuditor()
        Dim params As New List(Of String)
        params.Add(txtRegistro.Text)
        objAuditorEx.ideps = General.getValorConsulta(Consultas.AUDITOR_GET_IDEPS, params)
        objAuditorEx.registro = txtRegistro.Text
        objAuditorEx.verificarAuditor()

        For i = 0 To objAuditorEx.dtEps.Rows.Count - 1
            If IsDBNull(objAuditorEx.dtEps.Rows(i).Item("Hora_Salida")) And objAuditorEx.dtEps.Rows(i).Item("fecha_entrada") = CDate(Now.Date) And objAuditorEx.dtEps.Rows(i).Item("n_registro") = txtRegistro.Text Then
                btAuditor.BackColor = Color.Salmon
            Else
                btAuditor.BackColor = Color.Transparent
            End If
        Next
        If objAuditorEx.dtEps.Rows.Count = 0 Then
            btAuditor.BackColor = Color.Transparent
        End If
    End Sub

    Public Sub verificarListas()

        For i = 0 To objListachequeo.dsLista.Tables("Table1").Rows.Count - 1
            If objListachequeo.dsLista.Tables("Table1").Rows(i).Item("indice") = 0 Then
                btOpcionChequeo.BackColor = Color.Red
                btOpcionChequeo.ForeColor = Color.Black
                'btOpcionChequeo.Image = Global.Celer.My.Resources.Resources.atencion
                Exit Sub
            Else
                btOpcionChequeo.BackColor = Color.SeaGreen
                btOpcionChequeo.ForeColor = Color.Black
                'btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
            End If
        Next
    End Sub

    Private Sub TimerAlerta_Tick(sender As Object, e As EventArgs)
        'Handles TimerAlerta.Tick TODO LO COMENTÉ HASTA NUEVA ORDEN
        'Try
        '    If Me.Visible = True Then
        '        verificarAuditor()
        '    End If
        'Catch ex As Exception
        '    TimerAlerta.Stop()
        'End Try
    End Sub

    Private Sub dgvdiagRemN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdiagRemN.CellDoubleClick
        General.abrirJustificacion(dgvdiagRemN, objHistoriaClinica.objInfoIngreso.dtDiagREMIsion, PanelJustificacionRN, txtJustificacionRN, "Observacion", True)
    End Sub

    Private Sub dgvOxigenoFisio_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvOxigenoFisio.DataError

    End Sub

    Private Sub listaProcedimientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaProcedimientos.SelectedIndexChanged
        Try
            If listaProcedimientos.DisplayMember = Nothing Then Exit Sub
            If listaProcedimientos.SelectedIndex = 0 Then
                General.limpiarControles(ordenes)
                General.deshabilitarBotones_HC(TScuerpom)
                tscuerponuevo.Enabled = False
                tscuerpotarifa.Enabled = True
                chkAplica.Enabled = False
                dgvCuerpoM.Enabled = False
            Else
                cargarCuerpoMedico()
                chkAplica.Enabled = False
                dgvCuerpoM.Enabled = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    'Private Sub dgvCuerpoM_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If dgvCuerpoM.Rows(dgvCuerpoM.CurrentCell.RowIndex).Cells("CMQuitar").Selected = False Then
    '        Dim params As New List(Of String)
    '        params.Add(objHistoriaClinica.objCuerpoMedico.Codigo)
    '        General.buscarElemento(Consultas.EMPLEADO_CUERPO_MEDICO_LISTAR,
    '                               params,
    '                               AddressOf cargarEspecialista,
    '                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
    '                               True)
    '    ElseIf dgvCuerpoM.Rows(dgvCuerpoM.CurrentCell.RowIndex).Cells("CMQuitar").Selected = True AndAlso dgvCuerpoM.CurrentCell.RowIndex <> dgvCuerpoM.RowCount - 1 Then
    '        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
    '            dgvCuerpoM.DataSource.Rows.RemoveAt(dgvCuerpoM.CurrentCell.RowIndex)
    '        End If
    '    End If
    'End Sub
    'Private Sub cargarEspecialista(pcodigo As String)
    '    Dim params As New List(Of String)
    '    params.Add(pcodigo)
    '    params.Add(SesionActual.idEmpresa)
    '    Using dt As New DataTable
    '        General.llenarTabla(Consultas.TERCERO_CUERPO_MEDICO_CARGAR, params, dt)
    '        If dt.Rows.Count = 0 Then Exit Sub
    '        Dim dw = dt(0)
    '        If (dw("Tercero").ToString) IsNot DBNull.Value Then
    '            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(dgvCuerpoM.CurrentRow.Index).Item(0) = pcodigo
    '            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(dgvCuerpoM.CurrentRow.Index).Item(1) = dw("Tercero").ToString()
    '            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(dgvCuerpoM.CurrentRow.Index).Item(2) = dw("Cargo").ToString()
    '            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(dgvCuerpoM.CurrentRow.Index).Item(4) = dw("Codigo_Cargo").ToString()
    '            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows(dgvCuerpoM.CurrentRow.Index).Item(5) = 0
    '            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows.Add()
    '            dgvCuerpoM.ReadOnly = True
    '            chkAplica.Enabled = True
    '        End If
    '    End Using
    '    cargarValoresCM(pcodigo)
    'End Sub
    Private Sub dgvCuerpoM_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuerpoM.CellDoubleClick ' este es el codigo que sirve

        Dim columna As Integer = e.ColumnIndex
        Try
            If tscuerpoguardar.Enabled = False Then
                Exit Sub
            End If
            If columna = 2 Then
                'agregarCargo(Consultas.LISTA_PARAMETRO_CARGO, TitulosForm.BUSQUEDA_CARGOS, dgvCuerpoM, dtParticipantes)
            ElseIf columna = 4 And dgvCuerpoM.Rows(dgvCuerpoM.CurrentCell.RowIndex).Cells(1).ToString <> "" Then
                agregarTercero(Consultas.BUSQUEDA_EMPLEADO_HC & dgvCuerpoM.Rows(dgvCuerpoM.CurrentRow.Index).Cells(1).Value & "," & SesionActual.idEmpresa, TitulosForm.BUSQUEDA_EMPLEADO_HC, dgvCuerpoM, dtParticipantes)
            ElseIf dgvCuerpoM.Rows(dgvCuerpoM.CurrentCell.RowIndex).Cells("anular").Selected = True And dgvCuerpoM.Rows(dgvCuerpoM.CurrentCell.RowIndex).Cells(4).Value.ToString <> "" Then
                dtParticipantes.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub agregarCargo(ByVal consulta As String, ByVal titulo As String, ByVal datagrid As Object, ByVal datatable As Object)
        Dim tbl As DataRow = Nothing
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(consulta, Nothing, titulo, False)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            datatable.Rows(datagrid.CurrentCell.RowIndex).Item(0) = tbl(0)
            datatable.Rows(datagrid.CurrentCell.RowIndex).Item(1) = tbl(1)
            datagrid.Rows(datagrid.RowCount - 1).Cells(4).Selected = True
        End If
    End Sub
    Private Sub agregarTercero(ByVal consulta As String, ByVal titulo As String, ByVal datagrid As Object, ByVal datatable As Object)
        Dim tbl As DataRow = Nothing
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(consulta, Nothing, titulo, False)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            If dtParticipantes.Rows(dgvCuerpoM.CurrentRow.Index).Item(2).ToString = "" Then
                datatable.Rows.Add()
            End If
            datatable.Rows(datagrid.CurrentCell.RowIndex).Item(2) = tbl(0)
            datatable.Rows(datagrid.CurrentCell.RowIndex).Item(3) = tbl(1)
            datagrid.Rows(datagrid.RowCount - 1).Cells(2).Selected = True
            cargarValoresCM(tbl(0))
        End If
    End Sub
    Private Sub cargarValoresCM(pcodigo)
        Dim i As Integer
        Dim SubTotal As Double = 0
        Dim objCuerpo = objHistoriaClinica.objCuerpoMedico
        If chkAplica.Checked = True Then
            Dim params1 As New List(Of String)
            For i = 0 To (dtParticipantes.Rows.Count - 1)
                If dtParticipantes.Rows(i).Item(0) IsNot DBNull.Value Then
                    params1.Clear()
                    params1.Add(objCuerpo.Codigo)
                    params1.Add(dtParticipantes.Rows(i).Item("IdEmpleado"))
                    Dim filaResultadoValor As DataRow = General.cargarItem(Consultas.CUERPO_MEDICO_TARIFA_CARGAR, params1)
                    If Not IsNothing(filaResultadoValor) Then
                        dtParticipantes.Rows(i).Item(4) = filaResultadoValor.Item(0)
                        SubTotal = SubTotal + filaResultadoValor.Item(0)
                    End If
                End If
            Next
        Else
            Dim filaResultado As DataRow() = objCuerpo.dtProcedimientos.Select("Codigo_Procedimiento='" & objCuerpo.Codigo & "'", "")
            Dim params2 As New List(Of String)
            For i = 0 To (dtParticipantes.Rows.Count - 1)
                If dtParticipantes.Rows(i).Item(0) IsNot DBNull.Value Then
                    params2.Clear()
                    params2.Add(objCuerpo.Codigo)
                    params2.Add(dtParticipantes.Rows(i).Item("IdEmpleado"))
                    params2.Add(objHistoriaClinica.nRegistro)
                    params2.Add(Format(CDate(filaResultado(0)(2)), "yyyy-MM-dd"))
                    params2.Add(filaResultado(0)(0))
                    params2.Add(dtParticipantes.Rows(i).Item("Identificador"))
                    Dim filaResultadoValor As DataRow = General.cargarItem(Consultas.CUERPO_MEDICO_MANUAL_CARGAR, params2)
                    If Not IsNothing(filaResultadoValor) Then
                        dtParticipantes.Rows(i).Item(4) = filaResultadoValor.Item(0)
                        SubTotal = SubTotal + filaResultadoValor.Item(0)
                        objCuerpo.CodigoOrden = filaResultado(0)(0)
                    End If
                End If
            Next
        End If
        txtSubTotal.Text = FormatCurrency(SubTotal)
    End Sub
    Private Sub chkAplica_Click(sender As Object, e As EventArgs) Handles chkAplica.Click
        cargarValoresCM(Nothing)
    End Sub

    Private Sub tscuerponuevo_Click(sender As Object, e As EventArgs) Handles tscuerponuevo.Click
        tscuerpoguardar.Enabled = True
        tscuerpocancelar.Enabled = True
        chkAplica.Enabled = True
        tscuerponuevo.Enabled = False
        dgvCuerpoM.Enabled = True
        dgvCuerpoM.ReadOnly = True
        listaProcedimientos.Enabled = False
        dtParticipantes.Rows.Add()
    End Sub

    Private Sub tscuerpoguardar_Click(sender As Object, e As EventArgs) Handles tscuerpoguardar.Click
        If validarDatos() = True Then
            MsgBox("No ha ingresado una Cuerpo Medico para el Procedimiento seleccionado...", MsgBoxStyle.Exclamation)
            objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows.Add()
            Exit Sub
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            dgvCuerpoM.EndEdit()
            cargarObjetosCM()
            Try
                CuerpoMedioBLL.guardarCuerpoMedico(objHistoriaClinica.objCuerpoMedico)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarBotones_HC(TScuerpom)
                dgvCuerpoM.Enabled = False
                chkAplica.Enabled = False
                listaProcedimientos.Enabled = True
                txtTotal.Text = 0
                For i = 1 To listaProcedimientos.Items.Count - 1
                    objHistoriaClinica.objCuerpoMedico.Codigo = objHistoriaClinica.objCuerpoMedico.dtProcedimientos.Rows(i - 1).Item("Codigo_Procedimiento")
                    objHistoriaClinica.objCuerpoMedico.CodigoOrden = objHistoriaClinica.objCuerpoMedico.dtProcedimientos.Rows(i - 1).Item("Codigo_Orden")
                    calcularTotal()
                Next
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Function validarDatos() As Boolean
        Dim res As Boolean
        For i = 0 To dtParticipantes.Rows.Count - 1
            If dtParticipantes.Rows(i).Item("IdEmpleado") Is DBNull.Value Then
                dtParticipantes.Rows(i).Delete()
            End If
        Next
        If dtParticipantes.Rows.Count = 0 Then
            res = True
        End If
        Return res
    End Function
    Sub cargarObjetosCM()

        Dim objCuerpo = objHistoriaClinica.objCuerpoMedico
        '    objCuerpo.CodigoCM = txtCodCM.Text
        '    objCuerpo.usuario = SesionActual.idUsuario
        '    objCuerpo.dtAuxCM.Clear()
        '    For i = 0 To objCuerpo.dtEmpleadoProc.Rows.Count - 1
        '        If objCuerpo.dtEmpleadoProc.Rows(i).Item(0) IsNot DBNull.Value Then
        '            objCuerpo.dtAuxCM.Rows.Add()
        '            objCuerpo.dtAuxCM.Rows(i).Item("CodigoOrden") = objCuerpo.dtProcedimientos.Rows(listaProcedimientos.SelectedIndex - 1).Item(0)
        '            objCuerpo.dtAuxCM.Rows(i).Item("CodigoProcedimiento") = objCuerpo.Codigo
        '            objCuerpo.dtAuxCM.Rows(i).Item("IdEmpleado") = objCuerpo.dtEmpleadoProc.Rows(i).Item("IdEmpleado")
        '            objCuerpo.dtAuxCM.Rows(i).Item("TarifaPactada") = chkAplica.Checked
        '            objCuerpo.dtAuxCM.Rows(i).Item("Anulado") = 0
        '        End If
        '    Next
        objHistoriaClinica.objCuerpoMedico.dtParticipantes.Clear()
        For indice = 0 To dtParticipantes.Rows.Count - 1
            If dtParticipantes.Rows(indice).Item("Identificador") IsNot DBNull.Value Then
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows.Add()
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("tipoProceso") = "QX"
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("codigoProceso") = objCuerpo.dtProcedimientos.Rows(listaProcedimientos.SelectedIndex - 1).Item(0)
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("codigoProcedimiento") = objCuerpo.Codigo
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("codigoParametro") = dtParticipantes.Rows(indice).Item("Identificador")
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("idTercero") = dtParticipantes.Rows(indice).Item("idEmpleado")
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("aplicaTarifa") = chkAplica.Checked
                objHistoriaClinica.objCuerpoMedico.dtParticipantes.Rows(indice).Item("usuario") = SesionActual.idUsuario
            End If
        Next

    End Sub

    Private Sub TSRemisiones_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles TSRemisiones.ItemClicked

    End Sub

    Private Sub tscuerpoeditar_Click(sender As Object, e As EventArgs) Handles tscuerpoeditar.Click
        tscuerpoguardar.Enabled = True
        tscuerpocancelar.Enabled = True
        chkAplica.Enabled = True
        dgvCuerpoM.Enabled = True
        dgvCuerpoM.ReadOnly = True
        objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Rows.Add()
        tscuerpoanular.Enabled = False
        tscuerpoeditar.Enabled = False
        listaProcedimientos.Enabled = False
    End Sub

    Private Sub tscuerpocancelar_Click(sender As Object, e As EventArgs) Handles tscuerpocancelar.Click
        General.deshabilitarBotones_HC(TScuerpom)
        objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Clear()
        dgvCuerpoM.Enabled = False
        txtSubTotal.Text = 0
        chkAplica.Enabled = False
        listaProcedimientos.Enabled = True
    End Sub

    Private Sub tscuerpoanular_Click(sender As Object, e As EventArgs) Handles tscuerpoanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Try
                objHistoriaClinica.objCuerpoMedico.CodigoCM = txtCodCM.Text
                objHistoriaClinica.objCuerpoMedico.usuario = SesionActual.idUsuario
                objHistoriaClinica.objCuerpoMedico.AnularCuerpoMedico()
                General.deshabilitarBotones_HC(TScuerpom)
                objHistoriaClinica.objCuerpoMedico.dtEmpleadoProc.Clear()
                dgvCuerpoM.Enabled = False
                txtSubTotal.Text = 0
                chkAplica.Enabled = False
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                txtTotal.Text = 0
                For i = 1 To listaProcedimientos.Items.Count - 1
                    objHistoriaClinica.objCuerpoMedico.Codigo = objHistoriaClinica.objCuerpoMedico.dtProcedimientos.Rows(i - 1).Item("Codigo_Procedimiento")
                    objHistoriaClinica.objCuerpoMedico.CodigoOrden = objHistoriaClinica.objCuerpoMedico.dtProcedimientos.Rows(i - 1).Item("Codigo_Orden")
                    calcularTotal()
                Next
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btAuditor_Click_1(sender As Object, e As EventArgs) Handles btAuditor.Click
        verificarAuditor()
        Dim form As New FormEntradaAuditorExterno
        form.obtenerRegistro(txtRegistro.Text)
        FormPrincipal.Cursor = Cursors.WaitCursor
        form.ShowDialog()
        form.Focus()
        If form.WindowState = FormWindowState.Minimized Then
            form.WindowState = FormWindowState.Normal
        End If
        FormPrincipal.Cursor = Cursors.Default
    End Sub


    Private Sub tscuerpotarifa_Click(sender As Object, e As EventArgs) Handles tscuerpotarifa.Click
        Dim formCuerpo As New FormCuerpoMedico
        formCuerpo.txtRegistro.Text = txtRegistro.Text
        formCuerpo.MdiParent = FormPrincipal
        formCuerpo.Show()
    End Sub

    Private Sub tsevonuevo_Click(sender As Object, e As EventArgs) Handles tsevonuevo.Click
        objHistoriaClinica.objEvolucionMedica.opcionCancelar = False
        If SesionActual.tienePermiso(pNuevaEm) Then
            Dim params As New List(Of String)
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing

                params.Add(Constantes.LISTA_CARGO_EVOLUCION)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objEvolucionMedica.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                objHistoriaClinica.objEvolucionMedica.usuarioReal = SesionActual.idUsuario
                txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
            End If

            objHistoriaClinica.objEvolucionMedica.elementoAEliminar.Clear()
            GroupBoxProblemas.Focus()
            objHistoriaClinica.objEvolucionMedica.codigoEvolucion = -1
            objHistoriaClinica.objEvolucionMedica.cargarEvolucionMedica()
            dgvDIAGEVO.DataSource = objHistoriaClinica.objEvolucionMedica.dtDiagnosticos
            dgvDIAGEVO.Columns("Estado").Visible = False
            dgvDIAGEVO.Columns("anulardiagevo").DisplayIndex = 4
            dgvDIAGEVO.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDIAGEVO.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaEvolucion)
            reiniciarDtOrden(objHistoriaClinica.objEvolucionMedica.dtDiagnosticos)
            General.limpiarControles(evoluciones)
            cargarInterpretacionParaclinicos()
            General.habilitarControles(evoluciones)
            General.deshabilitarBotones_HC(TSevoluciones)
            params.Clear()
            params.Add(nRegistro)
            If General.getEstadoVF(objHistoriaClinica.objEvolucionMedica.consultaVerificar, params) = False Then
                TXTSIG_VITALES.Text = IIf(servicioNeonatal = False, txtInfoSigV.Text, txtSig_vitalesN.Text)
                TXTCAB_CUELLO.Text = IIf(servicioNeonatal = False, txtInfoCabCu.Text, txtCab_cuelloN.Text)
                TXTTORAX.Text = IIf(servicioNeonatal = False, txtInfoTorax.Text, txtToraxN.Text)
                TXTCARDIO.Text = IIf(servicioNeonatal = False, txtInfoCardio.Text, txtCardioN.Text)
                TXTABDOMEN.Text = IIf(servicioNeonatal = False, txtInfoAbdomen.Text, txtAbdomenN.Text)
                TXTGENTURINARIO.Text = IIf(servicioNeonatal = False, txtInfoGenito.Text, txtGenitoN.Text)
                TXTEXTREM.Text = IIf(servicioNeonatal = False, txtInfoExtrem.Text, txtExtremidadesN.Text)
                TXTSNERV.Text = IIf(servicioNeonatal = False, txtInfoSNerv.Text, txtS_NervN.Text)
                Dim dtNueva As DataTable
                dtNueva = objHistoriaClinica.objInfoIngreso.dtDiagImpresion.copy()
                For Each fila As DataRow In dtNueva.Select
                    objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.ImportRow(fila)
                Next
            Else
                Dim dt As New DataTable
                General.llenarTabla(objHistoriaClinica.objEvolucionMedica.consultaUltimaEvolucion, params, dt)
                If dt.Rows.Count > 0 Then
                    objHistoriaClinica.objEvolucionMedica.codigoEvolucion = dt.Rows(0).Item("Codigo_Evo").ToString
                    objHistoriaClinica.objEvolucionMedica.cargarDiagnosticosEvolucion()
                End If

            End If
            objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.Rows.Add()
            objHistoriaClinica.objEvolucionMedica.dtDiagnosticos.AcceptChanges()
            dgvDIAGEVO.EndEdit()
            tsevoguardar.Enabled = True
            tsevocancelar.Enabled = True
            dgvDIAGEVO.ReadOnly = True
            Listaevoluciones.Enabled = False
            txtcodigoevolucion.ReadOnly = True
            dgvParaclinicoEvo.Columns("Resultado").Visible = False
            dgvParaclinicoEvo.Columns("codigo_orden").Visible = False
            dgvParaclinicoEvo.Columns("obligatorio").Visible = False
            dgvParaclinicoEvo.Columns("dgResultadosParaEvo").DisplayIndex = 8
            dgvParaclinicoEvo.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub copiarExamenFisicoIngreso()

    End Sub
    Private Sub cargarInterpretacionParaclinicos()
        objHistoriaClinica.objEvolucionMedica.dtParaclinicos.Clear()
        objHistoriaClinica.objEvolucionMedica.fechaEvolucion = fechaEvolucion.Value
        HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_PARACLINICO_EVO, objHistoriaClinica.objEvolucionMedica.paraclinicoCargar, objHistoriaClinica.objEvolucionMedica.dtParaclinicos, dgvParaclinicoEvo, IIf(String.IsNullOrEmpty(txtcodigoevolucion.Text), -1, txtcodigoevolucion.Text), nRegistro, objHistoriaClinica.objEvolucionMedica.fechaEvolucion)

    End Sub

    Private Sub tsordenduplicar_Click(sender As Object, e As EventArgs) Handles tsordenduplicar.Click
        objHistoriaClinica.objOrdenMedica.opcionCancelar = False
        If SesionActual.tienePermiso(pDuplicarOm) Then
            If MsgBox(Mensajes.DUPLICAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.DUPLICAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then

                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objOrdenMedica.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Clear()
            txtCodigoOrden.Clear()
            General.habilitarControles(ordenes)
            General.deshabilitarBotones_HC(TSOrdenes)
            HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaOrdenMedica)
            If HistoriaClinicaBLL.verificarEstanciaDia(modulo, nRegistro, fechaOrdenMedica.Value.Date) = False Then
                MsgBox(Mensajes.SELECCIONE_DIA_ESTANCIA, MsgBoxStyle.Information)
                Dim params As New List(Of String)
                params.Add(nRegistro)
                params.Add(Constantes.GRUPO_ESTANCIA)
                params.Add(Nothing)
                General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_ESTANCIA, dgvEstancia,
                                  objHistoriaClinica.objOrdenMedica.dtEstancias, 0, 1, dgvEstancia.Columns("dgDescripcion").Index,
                                  False,,, True, AddressOf llenarEstancia)
                If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Count > 0 AndAlso objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 1).Item("Estado").ToString <> "" Then
                    objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
                End If
            Else
                objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
            End If
            HistoriaClinicaBLL.quitarProductosMayorHorario24(objHistoriaClinica.objOrdenMedica.dtMedicamentos)
            dgvMezcla_Leave(sender, e)
            objHistoriaClinica.objOrdenMedica.codigoOrden = txtCodigoOrden.Text
            editaDuplicaOpciones()
            If dgvNutricion.RowCount = 0 Then
                iniciarNutricion()
            Else
                editarNutricion()
            End If
            If objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows.Count < 2 Then
                agregaOxigenoAutomatico()
            End If
            txtNombreUsuarioOM.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub fechaEvolucion_ValueChanged(sender As Object, e As EventArgs) Handles fechaEvolucion.ValueChanged
        If Not Visible Then Exit Sub
        cargarInterpretacionParaclinicos()
        dibujarInterpretacionEvo()
    End Sub

    Private Sub agregaOxigenoAutomatico()
        HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_OXIGENO, objHistoriaClinica.objOrdenMedica.oxigenoAutoCargar, objHistoriaClinica.objOrdenMedica.dtOxigenos, dgvOxigeno, txtRegistro.Text)
        objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows.Add()
    End Sub
    Private Function agregaMedicamentoAutomatico() As Boolean
        objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Clear()
        HistoriaClinicaDAL.cargarMedicamentosAutomatico(objHistoriaClinica.objOrdenMedica)
        For i = 0 To objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows.Count - 1
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Código") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Código")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Descripción") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Descripción")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Unidad") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Unidad")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Dosis") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Dosis")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("CódigoVia") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("CódigoVia")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("DescripciónVia") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("DescripciónVia")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Horario") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Horario")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Inicio") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Inicio")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Frecuencia") = objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(i).Item("Frecuencia")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Dias") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Dias")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Suspender") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Suspender")
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Estado") = Constantes.ITEM_NUEVO
            objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows.Add()
        Next
        If objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btOpcionConsolidado.Click
        pnlConsolidado.Visible = False
    End Sub

    Private Sub txtIndicacion_TextChanged(areaTexto As Object, e As EventArgs) Handles txtIndicacion.LostFocus
        'If areaTexto.TextLength > 0 Then
        '    Dim wordApp As New Microsoft.Office.Interop.Word.Application
        '    wordApp.Visible = False
        '    Dim doc As Word.Document = wordApp.Documents.Add()
        '    Dim range As Word.Range
        '    range = doc.Range
        '    range.Text = areaTexto.text
        '    doc.Activate()
        '    doc.CheckSpelling()
        '    Dim chars() As Char = {CType(vbCr, Char), CType(vbLf, Char)}
        '    areaTexto.text = doc.Range.Text.Trim(chars)
        '    doc.Close(SaveChanges:=False)
        '    wordApp.Quit()
        'End If
    End Sub
    Private Sub ConsultarNotaAuditoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarNotaAuditoriaToolStripMenuItem.Click
        Dim formNotaAuditoria As New FormNotaAuditoria
        formNotaAuditoria.formHistoriaClinica = Me
        formNotaAuditoria.cargarModulo(Tag.modulo)
        formNotaAuditoria.Show()
        verificarColorNotaAud()
    End Sub
    Private Sub txtViaIngreso_Enter(sender As Object, e As EventArgs) Handles txtViaIngreso.Enter

    End Sub

    Private Sub Form_Historia_clinica_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cargarSOAT()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        valoresNutricionPorDefecto()

    End Sub

    Private Sub btModalidadApoyo_Click(sender As Object, e As EventArgs) Handles btModalidadApoyo.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.BUSQUEDA_INDICACION,
                             params,
                             AddressOf cargarModalidadApoyo,
                             TitulosForm.BUSQUEDA_INDICACION, True, 0, True)
    End Sub
    Private Sub cargarModalidadApoyo(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.INDICACION_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            objHistoriaClinica.objRemision.modalidad = pCodigo
            txtModalidadApoyo.Text = dt.Rows(0).Item("Descripcion").ToString()
        End If
    End Sub

    Private Sub btReferenciaOx_Click(sender As Object, e As EventArgs) Handles btReferenciaOx.Click
        Dim params As New List(Of String)
        General.buscarElemento(Consultas.ESPECIALIDAD_LISTAR,
                             Nothing,
                             AddressOf cargarEspecialidad,
                             TitulosForm.BUSQUEDA_ESPECIALIDAD, True, 0, True)
    End Sub
    Private Sub cargarEspecialidad(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_ESPECIALIDADES_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            objHistoriaClinica.objRemision.especialidad = pCodigo
            txtReferenciaOx.Text = dt.Rows(0).Item("Descripción").ToString()
        End If
    End Sub

    Private Sub btServicioAmb_Click(sender As Object, e As EventArgs) Handles btServicioAmb.Click
        Dim params As New List(Of String)
        General.buscarElemento(Consultas.BUSQUEDA_PROCEDIMIENTO_TRASLADOS & nRegistro & "," & codEps & ",''",
                             Nothing,
                             AddressOf cargarServicioAmbu,
                             TitulosForm.BUSQUEDA_ESPECIALIDAD, True, 0, True)
    End Sub
    Private Sub cargarServicioAmbu(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(nRegistro)
        General.llenarTabla(Consultas.PROCEDIMIENTO_TRASLADO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            objHistoriaClinica.objRemision.traslados = pCodigo

            txtServicioAmb.Text = dt.Rows(0).Item("Descripción").ToString()
        End If
    End Sub

    Private Sub TrasladoDeCamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrasladoDeCamaToolStripMenuItem.Click
        If SesionActual.tienePermiso(pTrasladoC) Then
            Dim formTrasladoCama As New Form_Traslado_Cama
            formTrasladoCama.datosPrincipales(Me, area, nRegistro)
            formTrasladoCama.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub SabanaDeAplicaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SabanaDeAplicaciónToolStripMenuItem.Click
        If SesionActual.tienePermiso(pSabana) Then
            Dim formSabana As New FormSabanaAplicacionMed
            objHistoriaClinica.objSabanaAplicacion.limpiarDts()
            objHistoriaClinica.generarSabanaAplicacion()
            formSabana.MdiParent = FormPrincipal
            formSabana.Show()
            formSabana.cargarDatosPaciente(objHistoriaClinica, modulo, IIf(IsNothing(cuerpo.Parent), False, True))
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ParamVentilaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParamVentilaciónToolStripMenuItem.Click
        Dim DFila As DataRow
        Dim params As New List(Of String)
        params.Add(objHistoriaClinica.nRegistro)
        DFila = General.cargarItem(objHistoriaClinica.VERIFICAR_VENTILACION, params)
        If Not IsNothing(DFila) Then
            If SesionActual.tienePermiso(pParametrosv) Then
                Dim formParametroVentilacion As New Form_Parametro_Ventilacion
                objHistoriaClinica.generarParametroVentilacion()
                formParametroVentilacion.MdiParent = FormPrincipal
                formParametroVentilacion.Show()
                formParametroVentilacion.cargarDatosPaciente(objHistoriaClinica)
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Este Paciente no Presenta Ventilación Mecanica ", MsgBoxStyle.Information, "Información")
        End If
    End Sub

    Private Sub RecetarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecetarioToolStripMenuItem.Click
        If SesionActual.tienePermiso(pRecetario) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                Form_Recetario.cargarModulo(Tag.modulo)
                General.cargarForm(Form_Recetario)
                txtNombreUsuarioInforme.Text = tbl(1)
                Form_Recetario.cargarDatos(txtRegistro.Text, txtHC.Text, txtSexo.Text, txtNombre.Text, txtEdad.Text, txtContrato.Text, txtNombreContrato.Text, tbl(0))
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PedidoDeFarmaciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidoDeFarmaciaToolStripMenuItem.Click
        If SesionActual.tienePermiso(pPedidoFarm) Then
            If modulo = Constantes.CODIGO_MENU_HISTC Then
                FormPedidoFarmacia.MdiParent = FormPrincipal
                FormPedidoFarmacia.iniciarDatos(Me)
                FormPedidoFarmacia.Show()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub TrasladoDeÁreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrasladoDeÁreaToolStripMenuItem.Click
        If SesionActual.tienePermiso(PTrasladar) Then
            verificarTraslado()
            pnlTraslado.Visible = Not pnlTraslado.Visible
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub verificarTraslado()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(nRegistro)
        General.llenarTabla(ConsultasHC.VERIFICAR_ADMISION_TRASLADO, params, dt)
        If dt.Rows.Count > 0 Then
            textTraslado.Text = dt.Rows(0).Item(0)
            lblAreaServicioTraslado.Text = "Solicitud de traslado a: " & textTraslado.Text
        End If
    End Sub

    Private Sub btBuscarEPROC_Click(sender As Object, e As EventArgs) Handles btBuscarEsp.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(txtContrato.Text)
        params.Add(servicioNeonatal)
        params.Add(nRegistro)
        General.buscarElemento(
                               Consultas.TRIAGE_BUSCAR_AREAS,
                               params,
                               AddressOf cargarArea,
                               TitulosForm.BUSQUEDA_AREA_SERVICIO,
                               False,
                               0,
                               True
                              )
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim params As New List(Of String)
        params.Add(nRegistro)
        params.Add(SesionActual.idUsuario)
        General.ejecutarSQL(ConsultasHC.ADMISION_TRASLADO_ANULAR, params)
        MsgBox("¡Solicitud cancelada!", MsgBoxStyle.Information)
        textTraslado.Clear()
        btLimpiar.Visible = False
    End Sub

    Private Sub GroupBox18_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormatoEmbarazoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatoEmbarazoToolStripMenuItem.Click
        If SesionActual.tienePermiso(pParto) Then
            If modulo = Constantes.CODIGO_MENU_HISTC Then
                FormEmbarazo.MdiParent = FormPrincipal
                FormEmbarazo.iniciarDatos(Me, modulo)
                FormEmbarazo.Show()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub FormatoParaCasosDeProblemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatoParaCasosDeProblemaToolStripMenuItem.Click
        General.cargarForm(FormCasoProblema)
        FormCasoProblema.cargarDatos(txtRegistro.Text,
                                     txtHC.Text,
                                     txtSexo.Text,
                                     txtNombre.Text,
                                     txtEdad.Text,
                                     txtContrato.Text,
                                     txtNombreContrato.Text)
    End Sub

#Region "Envio de correo"
    Private Sub btCorreo_Click(sender As Object, e As EventArgs) Handles btCorreo.Click
        Dim params As New List(Of String)
        params.Add(txtContrato.Text)
        Dim fila As DataRow = General.cargarItem(Consultas.REMISION_HC_CORREO, params)
        If Not IsNothing(fila) Then
            Cursor = Cursors.WaitCursor

            Try

                Dim correoConfigurado As Correo
                Dim listaCorreos As New List(Of Correo)
                listaCorreos = General.cargarInformacionCorreo(Me.Tag.codigo)

                If Not IsNothing(listaCorreos) Then
                    If listaCorreos.Count > 1 Then
                        'pnlUsuarioPass.Visible = True
                        'cmbCorreos.Items.Clear()
                        'For Each correo As Correo In listaCorreos
                        '    cmbCorreos.Items.Add(correo.correo)
                        'Next
                        'cmbCorreos.Tag = listaCorreos
                        'cmbCorreos.Enabled = True
                        'btnEnviar.Enabled = True
                        'btSalirPanel.Enabled = True
                        'cmbCorreos.SelectedIndex = 0
                    Else
                        correoConfigurado = New Correo
                        correoConfigurado = listaCorreos.First()
                        correoConfigurado.correoDestinatario = fila.Item(0)
                        correoConfigurado.codigoDocumentoRPT = objHistoriaClinica.objRemision.codigoRemision
                        correoConfigurado.asunto += "Remision No." & objHistoriaClinica.objRemision.codigoRemision
                        correoConfigurado.obj = objHistoriaClinica
                        codigoRemision = txtcodigoRemision.Text
                        iniciarEnvioCorreo(correoConfigurado)

                    End If
                Else
                    MsgBox("Aún no tiene configurado ningún correo para este formulario!", MsgBoxStyle.Exclamation)
                End If

            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    Shared Sub iniciarEnvioCorreo(ByRef pCorreo As Correo)
        If Not IsNothing(hilo) Then
            If hilo.IsAlive Then
                MsgBox("Ya esta en proceso un envio, debe esperar para volver a enviar un nuevo correo!", MsgBoxStyle.Critical)
            Else
                iniciarHilo(pCorreo)
            End If
        Else
            iniciarHilo(pCorreo)
        End If
    End Sub
    Shared Sub iniciarHilo(ByRef pCorreo As Correo)
        Try
            hilo = New System.Threading.Thread(AddressOf Form_Historia_clinica.enviarCorreo)
            hilo.Start(pCorreo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Shared Sub enviarCorreo(ByVal correoConfigurado As Correo)

        General.ConfigurarCorreo(correoConfigurado,
                                 Constantes.FORMULARIO.REMISIONES,
                                 "",
                                 correoConfigurado.correoDestinatario)
        Try
            If generarReporte(correoConfigurado, Nothing) AndAlso
                Funciones.enviarCorreo(correoConfigurado) Then
                cambiarEstadoRemisionCorreo()
                MsgBox("Correo enviado !", MsgBoxStyle.Information)
                'CheckEnviado.Checked = True
            Else
                MsgBox("Correo no enviado !", MsgBoxStyle.Critical)
                'CheckEnviado.Checked = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Shared Function generarReporte(ByVal correoConfigurado As Correo, Optional objeto As Object = Nothing) As Boolean
        Dim params As New List(Of Object)
        Return generarReporte(correoConfigurado.codigoDocumentoRPT, Nothing, correoConfigurado.rutaArchivo, params, correoConfigurado)
    End Function

    Shared Function generarReporte(ByVal Codigo As String,
                                   Optional proveedor As Integer = Nothing,
                                   Optional ruta As String = "",
                                   Optional ByRef params As List(Of Object) = Nothing,
                                   Optional obj As Object = Nothing) As Boolean

        Try
            Dim nombreArchivo, formula, codigoNombre, campo As String
            codigoNombre = Codigo
            campo = "Codigo_remision"


            nombreArchivo = obj.obj.objRemision.nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                    codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF

            formula = "{VISTA_REMISION." & campo & "} = " & codigoNombre & " 
                       AND {VISTA_REMISION.Modulo}=" & obj.obj.objRemision.moduloReporte & ""
            Dim reporte As New ftp_reportes
            reporte.crearReportePDF(obj.obj.objRemision.nombreReporte, obj.obj.nRegistro, New rptRemision,
                                      codigoNombre, formula,
                                      obj.obj.objRemision.nombreReporte, If(ruta = "", Nothing, ruta), "", True)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub NotaDeAuditoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeAuditoriaToolStripMenuItem.Click
        If SesionActual.tienePermiso(pNotaAuditoria) Then
            Dim formNotaAuditoria As New FormNotaAuditoria
            formNotaAuditoria.formHistoriaClinica = Me
            formNotaAuditoria.cargarModulo(Tag.modulo)
            formNotaAuditoria.Show()
            verificarColorNotaAud()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

#End Region

    Private Shared Sub cambiarEstadoRemisionCorreo()
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = Consultas.CAMBIAR_ESTADO_REMISION_CORREO
                comando.Parameters.Add(New SqlParameter("@codigoRemision", SqlDbType.Int)).Value = codigoRemision
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FormatoPartoYReciénNacidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatoPartoYReciénNacidoToolStripMenuItem.Click
        If SesionActual.tienePermiso(pParto) Then
            If modulo = Constantes.CODIGO_MENU_HISTC Then
                FormParto.MdiParent = FormPrincipal
                FormParto.iniciarDatos(Me, modulo)
                FormParto.Show()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cargarArea(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CARGA_AREA_SERVICIO, params, dt)
        If dt.Rows.Count > 0 Then
            textTraslado.Text = dt.Rows(0).Item("Descripción").ToString()
            lblAreaServicioTraslado.Text = "Solicitud de traslado a: " & textTraslado.Text
            params.Clear()
            params.Add(nRegistro)
            params.Add(pCodigo)
            params.Add(SesionActual.idUsuario)
            General.ejecutarSQL(ConsultasHC.ADMISION_TRASLADO_CREAR, params)
            MsgBox("¡Solicitud realizada con éxito!", MsgBoxStyle.Information)
            btLimpiar.Visible = True
            btLimpiar.Enabled = True
        End If
    End Sub

    Private Sub agregarProcedimientoAutomatico()
        objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Clear()
        HistoriaClinicaDAL.cargarProcedimientosAutomatico(objHistoriaClinica.objOrdenMedica)
        If objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows.Count > 0 Then
            MsgBox(Mensajes.PROCEDIMIENTOS_AUTOMATICOS, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            For i = 0 To objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows.Count - 1
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Código") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("codigo_procedimiento")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Descripción") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("Descripcion")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Cantidad") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("column1")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Indicación") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("indicacion")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Justificación") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("justificacion")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Resultado") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("resultado")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Formato") = objHistoriaClinica.objOrdenMedica.dtProcedimientosAuto.Rows(i).Item("formato")
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows(dgvProcedimiento.Rows.Count - 1).Item("Estado") = Constantes.ITEM_NUEVO
                objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows.Add()
            Next
            dgvProcedimiento.Focus()
        End If
    End Sub

    Private Function agregaMedicamentoAutomaticoAuditoria() As Boolean
        objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Clear()
        objHistoriaClinica.objOrdenMedica.fechaOrden = fechaOrdenMedica.Value
        HistoriaClinicaBLL.agregaMedicamentoAutomaticoAuditoria(objHistoriaClinica.objOrdenMedica, dgvInfusion)
        If objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows.Count > 0 Then
            MsgBox(Mensajes.MEDICAMENTOS_AUDITORIA_AUTOMATICOS, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            For i = 0 To objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows.Count - 1
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Código") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Código")
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Descripción") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Descripción")
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Unidad") = objHistoriaClinica.objOrdenMedica.dtMedicamentosAuto.Rows(i).Item("Unidad")
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows(dgvMedicamento.Rows.Count - 1).Item("Estado") = Constantes.ITEM_NUEVO
                objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows.Add()

                llenarMedicamento()
            Next
            Return True

        End If
        Return False
    End Function

    Private Sub editaDuplicaOpciones()
        dgvEstancia.Columns("dgCodigo").ReadOnly = True
        dgvEstancia.Columns("dgDescripcion").ReadOnly = True
        dgvEstancia.Columns("dgJustificacion").ReadOnly = True
        dgvEstancia.Columns("dgDiaEstancia").ReadOnly = True
        dgvEstancia.Rows(dgvEstancia.Rows.Count - 1).ReadOnly = True
        txtIndicacion.ReadOnly = False
        omColumnasDefecto()
        tsordenguardar.Enabled = True
        tsordencancelar.Enabled = True
        txtCodigoOrden.ReadOnly = True
        listaordenes.Enabled = False
        verificarPermisosOM()
        reiniciarOrden()
    End Sub
    Private Sub reiniciarOrden()
        If String.IsNullOrEmpty(objHistoriaClinica.objOrdenMedica.codigoOrden) Then
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtEstancias)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtComidas)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtOxigenos)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtParaclinicos)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtProcedimientos)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtGlucometrias)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtHemoderivados)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtMedicamentos)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtImpregnaciones)
            reiniciarDtOrden(objHistoriaClinica.objOrdenMedica.dtInfusiones)
            HistoriaClinicaBLL.reiniciarMezcla(objHistoriaClinica.objOrdenMedica.mezclaCargar, dgvInfusion, objHistoriaClinica.objOrdenMedica.dsMezcla)

        End If

    End Sub
    Private Sub reiniciarDtOrden(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 2
            dt.Rows(i).Item("Estado") = Constantes.ITEM_NUEVO
        Next
    End Sub

    Private Sub editaDuplicaOpcionesTerapia()
        opcionesFisio()
        dgvTerapias.Columns("dgCodigoFisio").ReadOnly = True
        dgvTerapias.Columns("dgDescripcionFisio").ReadOnly = True
        dgvTerapias.Columns("dgAplicaFisio").ReadOnly = False
        listaTerapias.Enabled = False
        dgvTerapias.Focus()
    End Sub

    Private Sub opcionesFisio()
        General.deshabilitarBotones_HC(TSFisioterapias)
        fechaFisioterapia.Enabled = True
        tsfisioguardar.Enabled = True
        tsfisiocancelar.Enabled = True
    End Sub

    Private Sub editaDuplicaOpcionesInsumoFisio()
        opcionesFisio()
        dgvInsumosFisio.DataSource.Rows.Add()
        dgvInsumosFisio.ReadOnly = False
        dgvInsumosFisio.Columns("dgCodigoInsuFisio").ReadOnly = True
        dgvInsumosFisio.Columns("dgDescripcionInsuFisio").ReadOnly = True
        dgvInsumosFisio.Columns("dgCantidadInsuFisio").ReadOnly = False
        dgvInsumosFisio.Rows(dgvInsumosFisio.Rows.Count - 1).ReadOnly = True
        listaInsumosfisio.Enabled = False
        dgvInsumosFisio.Focus()
    End Sub
    Private Sub opcionesEnfer()
        General.deshabilitarBotones_HC(TSEnfermeria)
        fechaEnfermeria.Enabled = True
        tsenferguardar.Enabled = True
        tsenfercancelar.Enabled = True
    End Sub

    Private Sub editaDuplicaOpcionesInsumoEnfer()
        opcionesEnfer()
        dgvInsumosEnfer.DataSource.Rows.Add()
        dgvInsumosEnfer.ReadOnly = False
        dgvInsumosEnfer.Columns("dgCodigoInsuEnfer").ReadOnly = True
        dgvInsumosEnfer.Columns("dgDescripcionInsuEnfer").ReadOnly = True
        dgvInsumosEnfer.Columns("dgCantidadInsuEnfer").ReadOnly = False
        dgvInsumosEnfer.Rows(dgvInsumosEnfer.Rows.Count - 1).ReadOnly = True
        listaInsumosEnfer.Enabled = False
        dgvInsumosEnfer.Focus()
    End Sub
    Private Sub editaDuplicaOpcionesNotaFisio()
        opcionesFisio()
        listaNotasfisio.Enabled = False
        txtNotaFisio.ReadOnly = False
        txtNotaFisio.Focus()
        txtNotaFisio.SelectionStart = txtNotaFisio.TextLength
    End Sub
    Private Sub editaDuplicaOpcionesNotaEnfer()
        opcionesEnfer()
        listaNotasEnfer.Enabled = False
        txtNotaEnfer.ReadOnly = False
        txtNotaEnfer.Focus()
        txtNotaEnfer.SelectionStart = txtNotaEnfer.TextLength
    End Sub
    Private Sub editaDuplicaOpcionesGlucomEnfer()
        opcionesEnfer()
        dgvGlucometriaEnfer.Columns("dgGlicemia").ReadOnly = False
        GroupBoxGluco.Enabled = True
        listaGlucometria.Enabled = False
        dgvGlucometriaEnfer.Focus()
        crearFilaEditar()
    End Sub
    Private Sub crearFilaEditar()
        If objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows.Count < 30 Then
            Dim contenedor As Integer = objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows.Count
            Dim fila As Integer
            For i = 1 To 29
                fila = (contenedor + i)
                objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows.Add()
                objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows(fila - 1).Item("Consecutivo") = fila
                objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows(fila - 1).Item("HoraDia") = Format(Convert.ToDateTime(fechaEnfermeria.Text), "HH:mm:ss")
                objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows(fila - 1).Item("UnidadMedida") = "MS/DL"
                objHistoriaClinica.objEnfermeria.objGlucomEnfer.dtGlucomEnfer.Rows(fila - 1).Item("Descripcion") = "Glucometria Nº " & fila
            Next
        End If
    End Sub
    Private Sub verificarPermisosOM()
        If Not SesionActual.tienePermiso(pTrabajarOm) OrElse (Not String.IsNullOrEmpty(txtCodigoOrden.Text) AndAlso verificarSolicitudLab(txtCodigoOrden.Text)) Then
            dgvEstancia.Enabled = False
            dgvOxigeno.Enabled = False
            'dgvComida.Enabled = False
            dgvParaclinico.Enabled = False
            dgvHemoderivado.Enabled = False
            dgvProcedimiento.Enabled = False
            General.deshabilitarControles(gbNutricion)
            dgvGlucometria.Columns("dgCantidadGlu").ReadOnly = True
            dgvGlucometria.Columns("anularGlu").ReadOnly = True
            dgvMedicamento.Columns("dgDosisMed").ReadOnly = True
            dgvMedicamento.Columns("dgSuspenderMed").ReadOnly = True
            dgvMedicamento.Columns("dgHorarioMed").ReadOnly = True
            dgvMedicamento.Columns("anularMed").ReadOnly = True
            dgvImpregnacion.Columns("dgDosisImpre").ReadOnly = True
            dgvImpregnacion.Columns("dgVelocidadImpre").ReadOnly = True
            dgvImpregnacion.Columns("dgSuspenderImpre").ReadOnly = True
            dgvImpregnacion.Columns("dgCantidadImpre").ReadOnly = True
            dgvImpregnacion.Columns("anularImpre").ReadOnly = True
            dgvInfusion.Columns("dgDosisInfu").ReadOnly = True
            dgvInfusion.Columns("dgVelocidadInfu").ReadOnly = True
            dgvInfusion.Columns("dgSuspenderInfu").ReadOnly = True
            dgvInfusion.Columns("anularInfu").ReadOnly = True
            dgvMezcla.Enabled = False
            fechaOrdenMedica.Enabled = False
        Else
            dgvEstancia.Enabled = True
            dgvOxigeno.Enabled = True
            dgvParaclinico.Enabled = True
            dgvHemoderivado.Enabled = True
            dgvProcedimiento.Enabled = True
        End If
        If Not SesionActual.tienePermiso(pEditarHoras) Then
            dgvGlucometria.Columns("dgInicioGlu").ReadOnly = True
            dgvMedicamento.Columns("dgInicioMed").ReadOnly = True
            dgvInfusion.Columns("dgInicioInfu").ReadOnly = True
            dgvImpregnacion.Columns("dgInicioImpre").ReadOnly = True
        End If
        If SesionActual.tienePermiso(pTrabajarComida) Then
            dgvComida.Enabled = True
        Else
            dgvComida.Enabled = False
        End If
    End Sub

    Private Sub omColumnasDefecto()
        objHistoriaClinica.objOrdenMedica.dtComidas.Rows.Add()
        dgvComida.Columns("dgDescripcionComida").ReadOnly = True
        dgvComida.Columns("dgDesayuno").ReadOnly = False
        dgvComida.Columns("dgAlmuerzo").ReadOnly = False
        dgvComida.Columns("dgCena").ReadOnly = False
        dgvComida.Columns("dgJustificacionComida").ReadOnly = True
        dgvComida.Columns("dgVirtual").ReadOnly = False
        dgvComida.Rows(dgvComida.Rows.Count - 1).ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtOxigenos.Rows.Add()
        'dgvOxigeno.Columns(2).ReadOnly = True
        dgvOxigeno.Columns("dgPorcentaje").ReadOnly = True
        dgvOxigeno.Columns("dgJustificacionOxigeno").ReadOnly = True
        dgvOxigeno.Rows(dgvOxigeno.Rows.Count - 1).ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtParaclinicos.Rows.Add()
        dgvParaclinico.Columns("dgDescripcionPara").ReadOnly = True
        dgvParaclinico.Columns("dgCantidadPara").ReadOnly = False
        dgvParaclinico.Columns("dgIndicacionPara").ReadOnly = True
        dgvParaclinico.Columns("dgJustificacionPara").ReadOnly = True
        dgvParaclinico.Rows(dgvParaclinico.Rows.Count - 1).Cells("dgCantidadPara").ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtHemoderivados.Rows.Add()
        dgvHemoderivado.Columns("dgDescripcionHemo").ReadOnly = True
        dgvHemoderivado.Columns("dgCantidadHemo").ReadOnly = False
        dgvHemoderivado.Columns("dgIndicacionHemo").ReadOnly = True
        dgvHemoderivado.Columns("dgJustificacionHemo").ReadOnly = True
        dgvHemoderivado.Rows(dgvHemoderivado.Rows.Count - 1).Cells("dgCantidadHemo").ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtGlucometrias.Rows.Add()
        dgvGlucometria.Columns("dgDescripcionGlu").ReadOnly = True
        dgvGlucometria.Columns("dgCantidadGlu").ReadOnly = False
        dgvGlucometria.Columns("dgInicioGlu").ReadOnly = False
        dgvGlucometria.Columns("dgFrecuenciaGlu").ReadOnly = True
        dgvGlucometria.Rows(dgvGlucometria.Rows.Count - 1).Cells("dgCantidadGlu").ReadOnly = True
        dgvGlucometria.Rows(dgvGlucometria.Rows.Count - 1).Cells("dgInicioGlu").ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtProcedimientos.Rows.Add()
        dgvProcedimiento.Columns("dgDescripcionProce").ReadOnly = True
        dgvProcedimiento.Columns("dgCantidadProce").ReadOnly = False
        dgvProcedimiento.Columns("dgIndicacionProce").ReadOnly = True
        dgvProcedimiento.Columns("dgJustificacionProce").ReadOnly = True
        dgvProcedimiento.Rows(dgvProcedimiento.Rows.Count - 1).Cells("dgCantidadProce").ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtImpregnaciones.Rows.Add()
        dgvImpregnacion.Columns("dgDescripcionImpre").ReadOnly = True
        dgvImpregnacion.Columns("dgCantidadImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgDosisImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgUnidadImpre").ReadOnly = True
        dgvImpregnacion.Columns("dgVelocidadImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgDisolventeImpre").ReadOnly = True
        dgvImpregnacion.Columns("dgTotalDisolventeImpre").ReadOnly = True
        dgvImpregnacion.Columns("dgInicioImpre").ReadOnly = False
        dgvImpregnacion.Columns("dgDiasImpre").ReadOnly = True
        dgvImpregnacion.Columns("dgSuspenderImpre").ReadOnly = False
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgCantidadImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgDosisImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgVelocidadImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgInicioImpre").ReadOnly = True
        dgvImpregnacion.Rows(dgvImpregnacion.Rows.Count - 1).Cells("dgSuspenderImpre").ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtInfusiones.Rows.Add()
        dgvInfusion.Columns("dgDescripcionInfu").ReadOnly = True
        dgvInfusion.Columns("dgDosisInfu").ReadOnly = False
        dgvInfusion.Columns("dgUnidadInfu").ReadOnly = True
        dgvInfusion.Columns("dgVelocidadInfu").ReadOnly = False
        dgvInfusion.Columns("dgDisolventeInfu").ReadOnly = True
        dgvInfusion.Columns("dgTotalDosisInfu").ReadOnly = True
        dgvInfusion.Columns("dgInicioInfu").ReadOnly = False
        dgvInfusion.Columns("dgDiasInfu").ReadOnly = True
        dgvInfusion.Columns("dgSuspenderInfu").ReadOnly = False
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgDosisInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgVelocidadInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgInicioInfu").ReadOnly = True
        dgvInfusion.Rows(dgvInfusion.Rows.Count - 1).Cells("dgSuspenderInfu").ReadOnly = True

        objHistoriaClinica.objOrdenMedica.dtMedicamentos.Rows.Add()
        dgvMedicamento.Columns("dgDescripcionMed").ReadOnly = True
        dgvMedicamento.Columns("dgDosisMed").ReadOnly = False
        dgvMedicamento.Columns("dgUnidadMed").ReadOnly = True
        dgvMedicamento.Columns("dgViaMed").ReadOnly = True
        dgvMedicamento.Columns("dgHorarioMed").ReadOnly = False
        dgvMedicamento.Columns("dgInicioMed").ReadOnly = False
        dgvMedicamento.Columns("dgDiaMed").ReadOnly = True
        dgvMedicamento.Columns("dgSuspenderMed").ReadOnly = False
        dgvMedicamento.Columns("dgFrecuenciaMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgDosisMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgHorarioMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgInicioMed").ReadOnly = True
        dgvMedicamento.Rows(dgvMedicamento.Rows.Count - 1).Cells("dgSuspenderMed").ReadOnly = True

    End Sub

    Private Sub tsordenanular_Click(sender As Object, e As EventArgs) Handles tsordenanular.Click
        objHistoriaClinica.objOrdenMedica.opcionCancelar = False
        If SesionActual.tienePermiso(pAnularOm) Then
            If verificarSolicitudLab(txtCodigoOrden.Text) = True Then
                MsgBox(Mensajes.SOLICITUD_LAB_EXISTENTE, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objOrdenMedica.elementoAEliminar.Clear()
                If modulo = Constantes.HC Then
                    consulta = Consultas.ANULAR_ORDEN_MEDICA & SesionActual.idUsuario & "," & CInt(txtCodigoOrden.Text) & "," & SesionActual.codigoEP
                    consultaVerificar = Consultas.ORDEN_MEDICA_VERIFICAR & nRegistro
                ElseIf modulo = Constantes.AM Then
                    consulta = Consultas.ANULAR_ORDEN_MEDICAR & SesionActual.idUsuario & "," & CInt(txtCodigoOrden.Text) & "," & SesionActual.codigoEP
                    consultaVerificar = Consultas.ORDEN_MEDICA_VERIFICARR & nRegistro
                ElseIf modulo = Constantes.AF Then
                    consulta = Consultas.ANULAR_ORDEN_MEDICARR & SesionActual.idUsuario & "," & CInt(txtCodigoOrden.Text)
                    consultaVerificar = Consultas.ORDEN_MEDICA_VERIFICARRR & nRegistro
                End If
                If General.anularRegistro(consulta) = True Then
                    If General.getEstadoVF(consultaVerificar) = True Then
                        fechaTemporal = fechaOrdenMedica.Value.Date
                        guardarReporteOrdenMedica()
                    End If
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    listarOrdenes()
                    verificarSoat()

                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub tsordeneditar_Click(sender As Object, e As EventArgs) Handles tsordeneditar.Click
        objHistoriaClinica.objOrdenMedica.opcionCancelar = False
        primeraVez = False
        If SesionActual.tienePermiso(pEditarOm) Then
            If verificarSolicitudLab(txtCodigoOrden.Text) Then
                If SesionActual.tienePermiso(pEditarHoras) OrElse SesionActual.tienePermiso(pTrabajarComida) Then
                    MsgBox(Mensajes.EDITAR_HORAS_MEDICAMENTO, MsgBoxStyle.Information)
                Else
                    MsgBox(Mensajes.SOLICITUD_LAB_EXISTENTE, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

            End If
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                Exit Sub
            End If

            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Clear()
            objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
            General.habilitarControles(ordenes)
            General.deshabilitarBotones_HC(TSOrdenes)
            dgvMezcla_Leave(sender, e)
            editaDuplicaOpciones()
            editarNutricion()
            txtNombreUsuarioOM.ReadOnly = True
            If listaordenes.DataSource.rows(listaordenes.SelectedIndex).item("N_Registro").ToString <> nRegistro Then
                gbIndicaciones.Focus()
                fechaOrdenMedica.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Function verificarSolicitudLab(codigoOrden As String) As Boolean
        If modulo <> Constantes.CODIGO_MENU_HISTC Then
            Return False
        End If
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        Dim respuesta As Boolean
        If Not String.IsNullOrEmpty(codigoOrden) Then
            respuesta = General.getValorConsulta(ConsultasHC.SOLICITUD_LABORATORIO_VERIFICAR, params)
        End If

        Return respuesta

    End Function

    Private Sub tsordennuevo_Click(sender As Object, e As EventArgs) Handles tsordennuevo.Click
        objHistoriaClinica.objOrdenMedica.opcionCancelar = False
        primeraVez = False
        If SesionActual.tienePermiso(pNuevaOm) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objHistoriaClinica.objOrdenMedica.usuarioReal = tbl(0)
                    txtNombreUsuarioInforme.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                objHistoriaClinica.objOrdenMedica.usuarioReal = SesionActual.idUsuario
                txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto
            End If

            objHistoriaClinica.objOrdenMedica.elementoAEliminar.Clear()
            gbEstancia.Focus()
            General.limpiarControles(ordenes)
            General.habilitarControles(ordenes)
            General.deshabilitarBotones_HC(TSOrdenes)
            cargarDatosYValidacionDefecto()
            iniciarNutricion()
            objHistoriaClinica.objOrdenMedica.codigoOrden = txtCodigoOrden.Text
            agregaOxigenoAutomatico()

            If listaordenes.Items.Count = 1 Then

                fechaOrdenMedica.Value = Format(CDate(txtAdmision.Text), Constantes.FORMATO_FECHA_HORA_GEN)
                If MsgBox(Mensajes.FORMATO_INGRESO, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    buscarFormatoIngreso()
                End If
            End If

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub
    Private Sub cargarDatosYValidacionDefecto()
        If dgvComida.DataSource Is Nothing Then
            HistoriaClinicaBLL.enlazarTabla(dgvEstancia, objHistoriaClinica.objOrdenMedica.dtEstancias, Constantes.OM_ESTANCIA)
            HistoriaClinicaBLL.enlazarTabla(dgvComida, objHistoriaClinica.objOrdenMedica.dtComidas, Constantes.OM_COMIDA)
            HistoriaClinicaBLL.enlazarTabla(dgvOxigeno, objHistoriaClinica.objOrdenMedica.dtOxigenos, Constantes.OM_OXIGENO)
            HistoriaClinicaBLL.enlazarTabla(dgvParaclinico, objHistoriaClinica.objOrdenMedica.dtParaclinicos, Constantes.OM_PARACLINICO)
            dgvParaclinico.Columns("Resultado").Visible = False
            HistoriaClinicaBLL.enlazarTabla(dgvHemoderivado, objHistoriaClinica.objOrdenMedica.dtHemoderivados, Constantes.OM_HEMODERIVADO)
            dgvHemoderivado.Columns("Resultado").Visible = False
            dgvHemoderivado.Columns("Formato").Visible = False
            HistoriaClinicaBLL.enlazarTabla(dgvGlucometria, objHistoriaClinica.objOrdenMedica.dtGlucometrias, Constantes.OM_GLUCOMETRIA)
            HistoriaClinicaBLL.enlazarTabla(dgvProcedimiento, objHistoriaClinica.objOrdenMedica.dtProcedimientos, Constantes.OM_PROCEDIMIENTO)
            dgvProcedimiento.Columns("Resultado").Visible = False
            dgvProcedimiento.Columns("Formato").Visible = False
            HistoriaClinicaBLL.enlazarTabla(dgvInfusion, objHistoriaClinica.objOrdenMedica.dtInfusiones, Constantes.OM_INFUSION)
            HistoriaClinicaBLL.enlazarTabla(dgvMedicamento, objHistoriaClinica.objOrdenMedica.dtMedicamentos, Constantes.OM_MEDICAMENTO)
            HistoriaClinicaBLL.enlazarTabla(dgvImpregnacion, objHistoriaClinica.objOrdenMedica.dtImpregnaciones, Constantes.OM_IMPREGNACION)
            dgvInfusionDisplayIndex()
            dgvImpregnacionDisplayIndex()
            dgvMedicamentoDisplayIndex()

        End If
        HistoriaClinicaBLL.cargarDgvOM(Constantes.OM_ESTANCIA, objHistoriaClinica.objOrdenMedica.estanciaCargar, objHistoriaClinica.objOrdenMedica.dtEstancias, dgvEstancia, nRegistro)
        txtCodigoOrden.ReadOnly = True
        iniciardgvs()
        verificarPermisosOM()
        txtIndicacion.ReadOnly = False
        tsordenguardar.Enabled = True
        tsordencancelar.Enabled = True
        listaordenes.Enabled = False
    End Sub


    Private Sub iniciardgvs()
        'columnas que deben ser solo lectura
        dgvEstancia.Columns("dgCodigo").ReadOnly = True
        dgvEstancia.Columns("dgDescripcion").ReadOnly = True
        dgvEstancia.Columns("dgJustificacion").ReadOnly = True
        HistoriaClinicaBLL.getFechaValida(modulo, nRegistro, fechaOrdenMedica)
        If Not IsNothing(cuerpo.Parent) Then
            agregarFilaPorDefecto()
            Exit Sub
        End If
        If HistoriaClinicaBLL.verificarEstanciaDia(modulo, nRegistro, fechaOrdenMedica.Value.Date) = False Then
            MsgBox(Mensajes.SELECCIONE_DIA_ESTANCIA, MsgBoxStyle.Information)
            Dim params As New List(Of String)
            params.Add(nRegistro)
            params.Add(Constantes.GRUPO_ESTANCIA)
            params.Add(Nothing)
            General.busquedaItems(Consultas.BUSQUEDA_GRUPO_CUPS_OM, params, TitulosForm.BUSQUEDA_ESTANCIA, dgvEstancia,
                                  objHistoriaClinica.objOrdenMedica.dtEstancias, 0, 1, dgvEstancia.Columns("dgDescripcion").Index,
                                  False,,, True, AddressOf llenarEstancia)
            If objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Count > 0 AndAlso objHistoriaClinica.objOrdenMedica.dtEstancias.Rows(dgvEstancia.Rows.Count - 1).Item("Estado").ToString <> "" Then
                objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
            End If
        Else
            objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
            dgvEstancia.Columns("dgDiaEstancia").ReadOnly = False
            dgvEstancia.Rows(dgvEstancia.Rows.Count - 1).Cells("dgDiaEstancia").ReadOnly = True
        End If
        agregarFilaPorDefecto()
    End Sub
    Private Sub agregarFilaPorDefecto()
        If dgvEstancia.RowCount = 0 Then
            objHistoriaClinica.objOrdenMedica.dtEstancias.Rows.Add()
            dgvEstancia.Columns("dgDiaEstancia").ReadOnly = False
            dgvEstancia.Rows(dgvEstancia.Rows.Count - 1).Cells("dgDiaEstancia").ReadOnly = True
        End If
        omColumnasDefecto()
    End Sub

    Private Sub tsinfoeditar_Click(sender As Object, e As EventArgs) Handles tsinfoeditar.Click

        If SesionActual.tienePermiso(pEditarInfoIngreso) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtInfoAnalisis.Text) AndAlso String.IsNullOrEmpty(txtAnalisisN.Text) Then
                If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                    Dim tbl As DataRow = Nothing
                    Dim params As New List(Of String)
                    params.Add(Constantes.LISTA_CARGO_INFO_INGRESO)
                    params.Add(SesionActual.idEmpresa)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
                    tbl = formBusqueda.rowResultados
                    If tbl IsNot Nothing Then
                        objHistoriaClinica.objInfoIngreso.usuarioReal = tbl(0)
                        txtNombreUsuarioInforme.Text = tbl(1)
                    Else
                        MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Else
                    objHistoriaClinica.objInfoIngreso.usuarioReal = SesionActual.idUsuario
                    txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto

                End If
            End If

            objHistoriaClinica.objInfoIngreso.elementoAEliminar.Clear()
            If String.IsNullOrEmpty(txtAnamnesis.Text) And String.IsNullOrEmpty(txtAnamnesisN.Text) Then
                cargarFormatoIngreso()
            End If

            If servicioNeonatal = False Then
                objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.Add()
            Else
                objHistoriaClinica.objInfoIngreso.dtDiagImpresion.Rows.Add()
            End If

            General.habilitarControles(ingreso)
            General.deshabilitarBotones_HC(TSinfoingreso)
            General.deshabilitarControles(GroupBox6)
            txtPeso.ReadOnly = False
            General.deshabilitarControles(GroupBox22)
            dgvImpresion.ReadOnly = True
            dgvImpresionN.ReadOnly = True
            txtGramos.ReadOnly = False
            tsinfoguardar.Enabled = True
            tsinfocancelar.Enabled = True
            tsOtrasOpciones.Enabled = True
            tsHojaIngreso.Enabled = True
            tsEpicrisis.Enabled = True
            tsPrefactura.Enabled = True
            tsConsolidado.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub
    'Public Function getMemoEdit1() As Object
    '    Return MemoEdit1
    'End Function

    Private Sub Form_Historia_clinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            verificarActivoYEdicion()
            servicioNeonatal = General.getEstadoVF(Consultas.AREA_SERVICIO_VERIFICAR & area)
            verificarYCargarOpcDefecto()

            verificarAuditor()

            'TimerAlerta.Start()
            General.cargarCombo(Consultas.PRIORIDAD_COMPLEJIDAD_LISTAR, "Descripción", "Código", Comboprioridad)
            General.cargarCombo(Consultas.PRIORIDAD_COMPLEJIDAD_LISTAR, "Descripción", "Código", Combocomplejidad)

            Dim params As New List(Of String)
            params.Add(modulo)
            params.Add(servicioNeonatal)
            params.Add(txtRegistro.Text)
            objHistoriaClinica = New HistoriaClinica(params)
            nRegistro = txtRegistro.Text
            objListachequeo = GeneralHC.fabricaHC.crear(Constantes.CODIGO_LISTA_CHEQUEO & Tag.modulo)
            objListachequeo.registro = nRegistro
            cargarListaChequeo()
            cargarInfoIngreso()
            guardarSabana()
            colocarMaximosMinimosNumericDownNutricion()
            mostrarHojaRuta()
            verificarColorNotaAud()
            verificarColorHojaRuta()
            visualiarNutricion()
            If txtEstadoAtencionN.Text.ToLower.Contains("revisi") OrElse txtEstadoAtencion.Text.ToLower.Contains("revisi") Then
                txtEstancia.Text = objHistoriaClinica.objInfoIngreso.DIASESTANCIA & " Dia(s)"
            End If
            verificarTraslado()
            If txtSexo.Text <> "F" OrElse servicioNeonatal Then
                FormatoPartoYReciénNacidoToolStripMenuItem.Visible = False
                FormatoEmbarazoToolStripMenuItem.Visible = False
            End If
            params.Clear()

            If SesionActual.codigoEP = Constantes.PUNTO_POR_DEFECTO Then
                params.Add(Constantes.PUNTO_POR_DEFECTO_HOSP)
            ElseIf SesionActual.codigoEP = Constantes.PUNTO_POR_DEFECTO_HOSP Then
                params.Add(Constantes.PUNTO_POR_DEFECTO)
            Else
                params.Add(Nothing)
            End If

            General.cargarCombo(Consultas.REMISION_LLENAR_DESTINO, params, "Descripcion", "Codigo_Parametro", cmbRemisionDestino)
            If SesionActual.tienePermiso(pVerListaChequeo) Then
                btOpcionChequeo.Visible = True
            Else
                btOpcionChequeo.Visible = False
            End If
            txtSOAT.Visible = False
            'General.agregarDicc(SpellChecker1)
            'General.agregarEventoDevExp(Me, MemoEdit1)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub visualiarNutricion()
        gbNutricion.Visible = False
        If Label1.Text.Contains("NEONATAL") OrElse Label1.Text.Contains("PEDIATRICO") Then
            gbNutricion.Visible = True
        End If
    End Sub
    Public Sub cargarListaChequeo()
        Try
            Dim arbolListaCuequeo As Thread
            btOpcionChequeo.Enabled = False
            arbolLista()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub guardarSabana()
        If (servicioNeonatal AndAlso Not txtEstadoAtencionN.Text.ToUpper.Contains("INI")) OrElse
                (Not servicioNeonatal AndAlso Not txtEstadoAtencion.Text.ToUpper.Contains("INI")) Then
            Exit Sub
        End If
        Try
            guardarSabanaAutomatica()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub arbolLista()
        Try
            objListachequeo.cargarMenu()
            verificarListas()
            btOpcionChequeo.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Sub colocarMaximosMinimosNumericDownNutricion()
        For Each ctrl In gbNutricion.Controls
            If TypeOf ctrl Is NumericUpDown Then
                ctrl.Maximum = 10000000
                ctrl.Minimum = -10000000
            End If
        Next
    End Sub
    Private Sub verificarYCargarOpcDefecto()
        'aqui colocare el codigo para el formato de ingreso-----------

        If servicioNeonatal = False Then
            contenedor.Panel1Collapsed = False
            contenedor.Panel2Collapsed = True
            Label119.Text = "Kg."
            Label122.Text = "Peso (Kg.)"
        Else
            contenedor.Panel2Collapsed = False
            contenedor.Panel1Collapsed = True
            Label119.Text = "Gr."
            Label122.Text = "Peso (Gr.)"
        End If
        If txtSexo.Text.Contains("F") = True Then
            antecedentegineco.Enabled = True
        Else
            antecedentegineco.Enabled = False
        End If
        usuarioActual = SesionActual.idUsuario
        General.deshabilitarControles(ingreso)
        General.deshabilitarControles(ordenes)
        General.deshabilitarControles(evoluciones)
        General.deshabilitarControles(interconsultas)
        General.deshabilitarControles(remisiones)
        General.deshabilitarControles(fisioterapia)
        General.deshabilitarControles(enfermeria)
        General.deshabilitarControles(cuerpo)
        General.deshabilitarBotones_HC(TSinfoingreso)
        tsinfoeditar.Enabled = True
        tsOtrasOpciones.Enabled = True
        tsHojaIngreso.Enabled = True
        tsEpicrisis.Enabled = True
        tsPrefactura.Enabled = True
        tsConsolidado.Enabled = True
        General.deshabilitarBotones_HC(TSOrdenes)
        tsordennuevo.Enabled = True
        General.deshabilitarBotones_HC(TSevoluciones)
        tsevonuevo.Enabled = True
        General.deshabilitarBotones_HC(TSInterconsultas)
        tsinternuevo.Enabled = True
        General.deshabilitarBotones_HC(TSRemisiones)
        tsremnuevo.Enabled = True
        General.deshabilitarBotones_HC(TSFisioterapias)
        tsfisionuevo.Enabled = True
        General.deshabilitarBotones_HC(TSEnfermeria)
        tsenferNuevo.Enabled = True
        General.deshabilitarBotones_HC(TScuerpom)
        tscuerponuevo.Enabled = True
        opcionCopiarPegar()
    End Sub

    Private Sub opcionCopiarPegar()
        Dim respuesta As Boolean
        respuesta = SesionActual.tienePermiso(pDuplicarEm)
        TXTSUBJETIVO.ShortcutsEnabled = respuesta
        TXTABDOMEN.ShortcutsEnabled = respuesta
        TXTSIG_VITALES.ShortcutsEnabled = respuesta
        TXTGENTURINARIO.ShortcutsEnabled = respuesta
        TXTTORAX.ShortcutsEnabled = respuesta
        TXTEXTREM.ShortcutsEnabled = respuesta
        TXTCAB_CUELLO.ShortcutsEnabled = respuesta
        TXTSNERV.ShortcutsEnabled = respuesta
        TXTCARDIO.ShortcutsEnabled = respuesta
        TXTPLAN.ShortcutsEnabled = respuesta
        TXTANALISIS.ShortcutsEnabled = respuesta
    End Sub

    Public Sub cargarPermisos(moduloPermiso As String)
        permisoGeneral = perG.buscarPermisoGeneral(Form_Listado_Paciente.Name, moduloPermiso)
        pEditarInfoIngreso = permisoGeneral & "pp" & "01"
        pAnularDiagnostico = permisoGeneral & "pp" & "02"
        pNuevaOm = permisoGeneral & "pp" & "03"
        pEditarOm = permisoGeneral & "pp" & "04"
        pAnularOm = permisoGeneral & "pp" & "05"
        pDuplicarOm = permisoGeneral & "pp" & "06"
        pTrabajarOm = permisoGeneral & "pp" & "07"
        pEditarHoras = permisoGeneral & "pp" & "08"
        pNuevaEm = permisoGeneral & "pp" & "09"
        pEditarEm = permisoGeneral & "pp" & "10"
        pAnularEm = permisoGeneral & "pp" & "11"
        pDuplicarEm = permisoGeneral & "pp" & "12"
        pNuevaIc = permisoGeneral & "pp" & "13"
        pEditarIc = permisoGeneral & "pp" & "14"
        pAnularIc = permisoGeneral & "pp" & "15"
        pDuplicarIc = permisoGeneral & "pp" & "16"
        pNuevaRm = permisoGeneral & "pp" & "17"
        pEditarRm = permisoGeneral & "pp" & "18"
        pAnularRm = permisoGeneral & "pp" & "19"
        pDuplicarRm = permisoGeneral & "pp" & "20"
        pNuevaOx = permisoGeneral & "pp" & "21"
        pEditarOx = permisoGeneral & "pp" & "22"
        pAnularOx = permisoGeneral & "pp" & "23"
        pEditarTp = permisoGeneral & "pp" & "24"
        pNuevaOi = permisoGeneral & "pp" & "25"
        pEditarOi = permisoGeneral & "pp" & "26"
        pAnularOi = permisoGeneral & "pp" & "27"
        pAnularI = permisoGeneral & "pp" & "28"
        pDuplicarOi = permisoGeneral & "pp" & "29"
        pNuevaNf = permisoGeneral & "pp" & "30"
        pEditarNf = permisoGeneral & "pp" & "31"
        pAnularNf = permisoGeneral & "pp" & "32"
        pDuplicarNf = permisoGeneral & "pp" & "33"
        pNuevaOie = permisoGeneral & "pp" & "34"
        pEditarOie = permisoGeneral & "pp" & "35"
        pAnularOie = permisoGeneral & "pp" & "36"
        pAnularIe = permisoGeneral & "pp" & "37"
        pDuplicarOie = permisoGeneral & "pp" & "38"
        pNuevaNe = permisoGeneral & "pp" & "39"
        pEditarNe = permisoGeneral & "pp" & "40"
        pAnularNe = permisoGeneral & "pp" & "41"
        pDuplicarNe = permisoGeneral & "pp" & "42"
        pSolicitudLab = permisoGeneral & "pp" & "43"
        pVerResultadoP = permisoGeneral & "pp" & "44"
        pIngresarResulP = permisoGeneral & "pp" & "45"
        pVerResultadoH = permisoGeneral & "pp" & "46"
        pIngresarInterH = permisoGeneral & "pp" & "47"
        pIngresarArchivoH = permisoGeneral & "pp" & "48"
        pNuevaHg = permisoGeneral & "pp" & "49"
        pEditarHg = permisoGeneral & "pp" & "50"
        pAnularHg = permisoGeneral & "pp" & "51"
        pAnularG = permisoGeneral & "pp" & "52"
        pDuplicarHg = permisoGeneral & "pp" & "53"
        pPedidoFarm = permisoGeneral & "pp" & "54"
        pRecetario = permisoGeneral & "pp" & "55"
        pParametrosv = permisoGeneral & "pp" & "56"
        pSabana = permisoGeneral & "pp" & "57"
        pTrasladoC = permisoGeneral & "pp" & "58"
        pIntervalo4horas = permisoGeneral & "pp" & "69"
        pDocumentoIntermedio = permisoGeneral & "pp" & "70"
        pVisado = permisoGeneral & "pp" & "71"
        pEpicrisis = permisoGeneral & "pp" & "72"
        pCrearExamen = permisoGeneral & "pp" & "74"
        pVerPrefactura = permisoGeneral & "pp" & "75"
        pPrefacturar = permisoGeneral & "pp" & "76"
        pConsolidado = permisoGeneral & "pp" & "77"
        pHojaRuta = permisoGeneral & "pp" & "89"
        PTrasladar = permisoGeneral & "pp" & "93"
        pParto = permisoGeneral & "pp" & "94"
        pCorreo = permisoGeneral & "pp" & "95"
        pVisorNotaAuditoria = permisoGeneral & "pp" & "96"
        pTrabajarComida = permisoGeneral & "pp" & "97"
        pNotaAuditoria = permisoGeneral & "pp" & "90"
        pVerListaChequeo = permisoGeneral & "pp" & "98"
        Select Case moduloPermiso
            Case Constantes.CODIGO_MENU_HEMO, Constantes.CODIGO_MENU_QUIR
                diseñoHemodinamia()
            Case Else
                cuerpo.Parent = Nothing
        End Select
    End Sub

    Private Sub diseñoHemodinamia()
        gbEstancia.Visible = False
        gbTerapia.Visible = False
        gbInsumoFisio.Visible = False
        gbNotaFisio.Visible = False
        gbIndicaciones.Location = New Point(gbIndicaciones.Location.X, gbIndicaciones.Location.Y - 246)
        gbDietas.Location = New Point(gbDietas.Location.X, gbDietas.Location.Y - 246)
        gbOxigeno.Location = New Point(gbOxigeno.Location.X, gbOxigeno.Location.Y - 246)
        gbParaclinicos.Location = New Point(gbParaclinicos.Location.X, gbParaclinicos.Location.Y - 246)
        gbHemoderivados.Location = New Point(gbHemoderivados.Location.X, gbHemoderivados.Location.Y - 246)
        gbProcedimientos.Location = New Point(gbProcedimientos.Location.X, gbProcedimientos.Location.Y - 246)
        gbGlucometrias.Location = New Point(gbGlucometrias.Location.X, gbGlucometrias.Location.Y - 246)
        gbMedicamentos.Location = New Point(gbMedicamentos.Location.X, gbMedicamentos.Location.Y - 246)
        gbImpregnacion.Location = New Point(gbImpregnacion.Location.X, gbImpregnacion.Location.Y - 246)
        gbInfusion.Location = New Point(gbInfusion.Location.X, gbInfusion.Location.Y - 246)
        gbNutricion.Location = New Point(gbNutricion.Location.X, gbNutricion.Location.Y - 246)
    End Sub

    Private Sub btsolitudLab_Click(sender As Object, e As EventArgs) Handles btsolitudLab.Click
        Dim formlab As New FormSolicitudLab
        formlab.iniciarForm(objHistoriaClinica)
        formlab.ShowDialog()
    End Sub
    Private Sub mostrarHojaRuta()
        If Funciones.consultarEmpleadoHojaRuta(SesionActual.idUsuario,
                                               Date.Now,
                                               txtRegistro.Text) = True Then
            Dim visorHojaRuta As New FormVisorHojaRuta
            visorHojaRuta.objHistoriaClinica = objHistoriaClinica
            visorHojaRuta.formHistoriaClinica = Me
            visorHojaRuta.indicacion = 0
            visorHojaRuta.ShowDialog()
        End If
    End Sub

    Private Sub menuNotas_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles menuNotas.Opening
        Dim formulario As String
        For Each f As Windows.Forms.Form In Application.OpenForms
            Try
                formulario = If(f.Name = "HISTORIAC" OrElse
                                f.Name = "AUDITORIAM" OrElse
                                f.Name = "AUDITORIAF", "Form_Historia_clinica", f.Name)

                If Funciones.consultarFormulario(formulario) = True Then

                    If SesionActual.tienePermiso(pNotaAuditoria) Then
                        ConsultarNotaAuditoriaToolStripMenuItem.Visible = True
                    End If

                Else
                    ConsultarNotaAuditoriaToolStripMenuItem.Visible = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
#Region "Nutricion"
#Region "Metodos"
    Sub iniciarNutricion()
        enlazarNutricion()
        cargarProductosPorDefectosNutricion()
        valoresNutricionPorDefecto()
        deshabilitarControlesNutricion()
        NDPesoPacienteNutricion.Enabled = True
        NDPesoPacienteNutricion.ReadOnly = False
        NDPesoPacienteNutricion.Value = objHistoriaClinica.objOrdenMedica.objetoNutricion.ultimoPeso(txtRegistro.Text, fechaOrdenMedica.Value)
    End Sub

    Sub cargarProductosPorDefectosNutricion()
        General.llenarTabla(Consultas.ORDEN_MEDICA_LISTAR_NUTRICION_PRODUCTOS_POR_DEFECTO, Nothing, objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion)
        dgvNutricion.DataSource = objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion
        dgvNutricion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvNutricion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Sub calcularNutricion()
        NDDuracion.Value = ConstantesHC.DURACION_NUTRICION
        TextFrecuencia.Text = ConstantesHC.FRECUENCIA_MEDICACION_NUTRICION
        NDFactorAjustes.Value = ConstantesHC.FACTOR_AJUSTE


        If NDPesoPacienteNutricion.Value > 0 OrElse NDAlimentacion.Value > 0 OrElse NDMedicacion.Value > 0 OrElse NDOtros.Value > 0 Then
            If NDPesoPacienteNutricion.Value = 0 AndAlso (NDAlimentacion.Value > 0 OrElse NDMedicacion.Value > 0 OrElse NDOtros.Value > 0) Then
                MsgBox("Debe colocar el peso del paciente!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            'peso dependiendo del entorno 
            Dim peso As Double = NDPesoPacienteNutricion.Value
            peso = If(servicioNeonatal = True, peso / 1000, peso)

            calcularTasaHidrica(peso)
            If objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion.Rows.Count > 0 Then
                Dim cantidad As Integer = objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion.Compute("Sum(Requerimiento)", "")
                calcularVolumenes(peso)
                If cantidad > 0 Then
                    calcularAporteEnergetico()
                    calcularProcentajeGlucosa(peso)
                    calcularKilosCalorias(peso)
                Else
                    limpiarAporteEnergetico()
                End If
                calcularOsmolalidadTotal()
            End If
        Else
            valoresNutricionPorDefecto()
        End If
    End Sub
    Sub valoresNutricionPorDefecto()
        cmbHoraInicialNutricion.SelectedIndex = 0
        For Each ctrl As Object In gbNutricion.Controls
            If TypeOf ctrl Is NumericUpDown Then
                ctrl.Value = 0
            ElseIf TypeOf ctrl Is GroupBox Then
                For Each sctrl As Object In ctrl.Controls
                    If TypeOf sctrl Is NumericUpDown Then
                        sctrl.Value = 0
                    End If
                Next
            ElseIf TypeOf ctrl Is Panel Then
                For Each sctrl As Object In ctrl.Controls
                    If TypeOf sctrl Is NumericUpDown Then
                        sctrl.Value = 0
                    End If
                Next
            End If
        Next
        For indiceFila = 0 To objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion.Rows.Count - 1
            objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion.Rows(indiceFila).Item("Requerimiento") = 0
            objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion.Rows(indiceFila).Item("Volumenes") = 0
        Next
    End Sub
    Sub deshabilitarControlesNutricion()
        For Each ctrl As Object In gbNutricion.Controls
            If TypeOf ctrl Is NumericUpDown Then
                ctrl.ReadOnly = True
                ctrl.enabled = False
            ElseIf TypeOf ctrl Is GroupBox Then
                For Each sctrl As Object In ctrl.Controls
                    If TypeOf sctrl Is NumericUpDown Then
                        sctrl.ReadOnly = True
                        sctrl.enabled = False
                    End If
                Next
            ElseIf TypeOf ctrl Is Panel Then
                For Each sctrl As Object In ctrl.Controls
                    If TypeOf sctrl Is NumericUpDown Then
                        sctrl.ReadOnly = True
                        sctrl.enabled = False
                    End If
                Next
            End If
        Next
    End Sub
    Sub limpiarAporteEnergetico()
        NDCarbohidratosGramos.Value = 0
        NDAminoacidosGramos.Value = 0
        NDLipidosGramos.Value = 0

        NDCarbohidratosKCALAportados.Value = 0
        NDAminoacidosKCALAportados.Value = 0
        NDLipidosKCALAportados.Value = 0
        NDTotalesKCALAportados.Value = 0

        NDPorcentajeAporte.Value = 0
        NDAminoacidosPorcentajeAporte.Value = 0
        NDLipidosPorcentajeAporte.Value = 0
        NDTotalesPorcentajeAporte.Value = 0

        NDTotalesGrNitrogeno.Value = 0
        NDKCALNP.Value = 0
        NDKCALNPN2.Value = 0
        NDKCALNPP.Value = 0

        textcaloriasporkilo.Text = 0
        NDPorcentajeGlucosa.Value = 0
    End Sub
    Sub calcularAporteEnergetico()
        Dim aporteEnergetico() As Double = HistoriaClinicaBLL.calcularAporteEnergetico(objHistoriaClinica)

        NDCarbohidratosGramos.Value = aporteEnergetico(0)
        NDAminoacidosGramos.Value = aporteEnergetico(1)
        NDLipidosGramos.Value = aporteEnergetico(2)

        HistoriaClinicaBLL.calcularAporteEnergeticoDetallado(NDCarbohidratosKCALAportados,
                                                              NDAminoacidosKCALAportados,
                                                              NDLipidosKCALAportados,
                                                              NDTotalesKCALAportados,
                                                              NDPorcentajeAporte,
                                                              NDAminoacidosPorcentajeAporte,
                                                              NDLipidosPorcentajeAporte,
                                                              NDTotalesPorcentajeAporte,
                                                              NDTotalesGrNitrogeno,
                                                              NDAminoacidosGramos,
                                                              NDKCALNP,
                                                              NDKCALNPN2,
                                                              NDKCALNPP,
                                                              NDCarbohidratosGramos,
                                                              NDLipidosGramos)

    End Sub
    Sub calcularVolumenes(ByVal peso As Double)
        HistoriaClinicaBLL.calcularVolumenes(objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion,
                                             peso,
                                             NDVolumenTotal,
                                             NDAguaDestilada)
    End Sub
    Sub calcularKilosCalorias(ByVal peso As Double)
        HistoriaClinicaBLL.calcularKilosCalorias(peso, textcaloriasporkilo, NDTotalesKCALAportados)
    End Sub
    Sub calcularOsmolalidadTotal()
        HistoriaClinicaBLL.calcularOsmolalidadTotal(objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion, NDOsmolaridad)
    End Sub
    Sub calcularProcentajeGlucosa(ByVal peso As Double)
        HistoriaClinicaBLL.calcularProcentajeGlucosa(peso, NDPorcentajeGlucosa, objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion)
    End Sub
    Sub calcularTasaHidrica(ByVal peso As Double)
        HistoriaClinicaBLL.calcularTasaHidrica(NDTotalesAlimentacion,
                                               NDAlimentacion,
                                               TextFrecuencia,
                                               NDTotalesMedicacion,
                                               NDMedicacion,
                                               NDTotalesOtros,
                                               NDOtros,
                                               NDTasaHidricasAlimentacion,
                                               peso,
                                               NDTasaHidricaMedicacion,
                                               NDTasaHidricaOtros,
                                               NDTasaHidricaTHLEV,
                                               NDTasaHidrica,
                                               NDTasaHidricaTotal,
                                               NDTasaHidricaTHT,
                                               NDVolumenTotal,
                                               NDRasarRazon,
                                               NDDuracion)
    End Sub
    Sub enlazarNutricion()
        HistoriaClinicaBLL.enlazarNutricion(dgvNutricion, objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion)
    End Sub
    Sub establecerObjetoNutricion()
        objHistoriaClinica.objOrdenMedica.objetoNutricion.peso = NDPesoPacienteNutricion.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.horaInicial = If(cmbHoraInicialNutricion.SelectedIndex = 0, 0, cmbHoraInicialNutricion.SelectedItem)
        objHistoriaClinica.objOrdenMedica.objetoNutricion.TasaHidrica = NDTasaHidrica.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.FactorAjustes = NDFactorAjustes.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.alimentacion = NDAlimentacion.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.medicacion = NDMedicacion.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.otros = NDOtros.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.tht = NDTasaHidricaTotal.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.volumen = NDVolumenTotal.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.razon = NDRasarRazon.Value
        objHistoriaClinica.objOrdenMedica.objetoNutricion.codigoAgua = ConstantesHC.AGUA_DESTLADA
        objHistoriaClinica.objOrdenMedica.objetoNutricion.cantidadAgua = NDAguaDestilada.Value
    End Sub
    Sub editarNutricion()
        deshabilitarControlesNutricion()
        NDPesoPacienteNutricion.Enabled = True
        NDAlimentacion.Enabled = True
        NDMedicacion.Enabled = True
        NDOtros.Enabled = True
        NDTasaHidricaTotal.Enabled = True
        NDPesoPacienteNutricion.ReadOnly = False
        NDAlimentacion.ReadOnly = False
        NDMedicacion.ReadOnly = False
        NDOtros.ReadOnly = False
        NDTasaHidricaTotal.ReadOnly = False
        objHistoriaClinica.objOrdenMedica.objetoNutricion.llenarNutricionParaEdicion()
    End Sub
#End Region
#Region "eventos de dgvNutricion"
    Private Sub dgvNutricion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNutricion.CellEndEdit
        dgvNutricion.CommitEdit(DataGridViewDataErrorContexts.Commit)
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Requerimientos", dgvNutricion) Then
            HistoriaClinicaBLL.mostrarAdvertenciaNutricion(objHistoriaClinica.objOrdenMedica.objetoNutricion.dtNutricion, e.RowIndex)
            calcularNutricion()
        End If
    End Sub
    Private Sub dgvNutricion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNutricion.CellEnter
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Requerimientos", dgvNutricion) AndAlso tsordenguardar.Enabled = True Then
            dgvNutricion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
        Else
            dgvNutricion.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        End If
    End Sub
    Private Sub dgvNutricion_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvNutricion.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
#End Region
#Region "Botones"
    Private Sub btnKalPeso_Click(sender As Object, e As EventArgs) Handles btnKalPeso.Click
        panelcalorias.Visible = True
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        panelcalorias.Visible = False
    End Sub
#End Region
#Region "Evento de los Numeric Down"
    Private Sub NDPesoPacienteNutricion_Leave(sender As Object, e As EventArgs) Handles NDPesoPacienteNutricion.Leave
        calcularNutricion()
        NDTasaHidricaTotal.Enabled = True
        NDTasaHidricaTotal.ReadOnly = False
        NDTasaHidricaTotal.Focus()
    End Sub
    Private Sub NDTasaHidricaTotal_Leave(sender As Object, e As EventArgs) Handles NDTasaHidricaTotal.Leave
        NDAlimentacion.Enabled = True
        NDAlimentacion.ReadOnly = False
        NDAlimentacion.Focus()
    End Sub
    Private Sub NDAlimentacion_Leave(sender As Object, e As EventArgs) Handles NDAlimentacion.Leave
        NDMedicacion.Enabled = True
        NDMedicacion.ReadOnly = False
        NDMedicacion.Focus()
    End Sub
    Private Sub NDMedicacion_Leave(sender As Object, e As EventArgs) Handles NDMedicacion.Leave
        NDOtros.Enabled = True
        NDOtros.ReadOnly = False
        NDOtros.Focus()
    End Sub
    Private Sub NDOtros_Leave(sender As Object, e As EventArgs) Handles NDOtros.Leave
        dgvNutricion.Focus()
    End Sub




#End Region

#End Region
#Region "Oxigeno"
#Region "Evento de los controles de oxigeno Fisioterapia"
    Private Sub dgvOxigenoFisio_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvOxigenoFisio.CellMouseDown
        'If tsfisioguardar.Enabled = True Then
        '    CtxOxigenoFisioterapia.Enabled = True
        'Else
        '    CtxOxigenoFisioterapia.Enabled = False
        'End If
    End Sub
    Private Sub dgvOxigenoFisio_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvOxigenoFisio.MouseDown
        'If tsfisioguardar.Enabled = True Then
        '    CtxOxigenoFisioterapia.Enabled = True
        'Else
        '    CtxOxigenoFisioterapia.Enabled = False
        'End If
    End Sub
    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        If agregarFilaoxigeno() Then
            colocarColorFilaNueva(dgvOxigenoFisio.CurrentRow.Index + 1)
            objHistoriaClinica.objFisioterapia.objOxigeno.totalizarMinutosLitrosPorFila(dgvOxigenoFisio.CurrentRow.Index + 1)
            totalizarOxigeno()
        End If
    End Sub
    Private Sub OrganizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrganizarToolStripMenuItem.Click
        objHistoriaClinica.objFisioterapia.objOxigeno.configurarOxigeno()
    End Sub
    Private Sub dgvOxigenoFisio_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvOxigenoFisio.RowPostPaint
        General.generarSecuencial(dgvOxigenoFisio, e)
    End Sub
    Private Sub dgvOxigenoFisio_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOxigenoFisio.CellDoubleClick
        'If tsfisioguardar.Enabled = True Then
        '    If e.RowIndex = 0 AndAlso Funciones.verificacionPosicionActual(dgvOxigenoFisio, e, "Fecha_Inicio") Then
        '        MsgBox(Mensajes.FECHA_PRIMERA_ORDEN_PACIENTE, MsgBoxStyle.Exclamation)
        '    ElseIf Funciones.verificacionPosicionActual(dgvOxigenoFisio, e, "Fecha_Inicio") OrElse Funciones.verificacionPosicionActual(dgvOxigenoFisio, e, "Fecha_Fin") Then
        '        mTxtOxigeno.Text = dgvOxigenoFisio.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        '        dibugarPanelOxigenoFisioterapia()
        '        mTxtOxigeno.Enabled = True
        '        mTxtOxigeno.Focus()
        '    ElseIf Funciones.verificacionPosicionActual(dgvOxigenoFisio, e, dgvOxigenoFisio.Columns("DescripcionOxigeno").Name) Then
        '        'buscarModoVentilacion(AddressOf colocarModoVentilacion)
        '    ElseIf Funciones.verificacionPosicionActual(dgvOxigenoFisio, e, dgvOxigenoFisio.Columns("QuitarModoOxigeno").Name) Then
        '        Funciones.quitarFilas(objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno, e.RowIndex)
        '        totalizarOxigeno()
        '    End If
        'Else
        '    mTxtOxigeno.Enabled = False
        'End If
    End Sub
    Private Sub mTxtOxigeno_Leave(sender As Object, e As EventArgs) Handles mTxtOxigeno.Leave
        Dim fechaActual As DateTime = Format(CDate(objHistoriaClinica.objFisioterapia.objOxigeno.obtenerFechaActual), "dd-MM-yyyy HH:mm:ss")
        Dim fechaEditada As DateTime = Format(CDate(mTxtOxigeno.Value), "dd-MM-yyyy HH:mm:ss")
        Dim diasDiferencia As Integer = DateDiff(DateInterval.Day, fechaActual, fechaEditada)
        If diasDiferencia > 1 Then
            isNotFechaValida()
        Else
            isFechaValida()

        End If
        'SI PASA DE DOS DIAS
        '

        dgvOxigenoFisio.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvOxigenoFisio.EndEdit()
    End Sub
    Private Sub mTxtOxigeno_KeyDown(sender As Object, e As KeyEventArgs) Handles mTxtOxigeno.KeyDown
        If e.KeyCode = Keys.Escape OrElse e.KeyCode = Keys.Enter Then
            dgvOxigenoFisio.Focus()
        End If
    End Sub
    Private Sub listaOxigeno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaOxigeno.SelectedIndexChanged
        Try
            If listaOxigeno.DisplayMember = Nothing Then Exit Sub
            If Funciones.indiceValidoListas(listaOxigeno.SelectedIndex) AndAlso Not IsNothing(listaOxigeno.DataSource) Then
                txtCodigoFisioterapia.Text = listaOxigeno.SelectedValue

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
#End Region
#Region "Funciones"
    Function nombreColumnaActual(ByRef dgv As DataGridView) As String
        Return dgv.Columns(dgv.CurrentCell.ColumnIndex).Name
    End Function

#End Region
#Region "Metodos"
    Sub colocarColorFilaNueva(ByVal filaColoreada As Integer)
        dgvOxigenoFisio.Rows(filaColoreada).DefaultCellStyle.BackColor = Color.Aquamarine
    End Sub
    Private Sub isFechaValida()
        If dgvOxigenoFisio.CurrentCell.ColumnIndex = 1 AndAlso HistoriaClinicaBLL.isFechaMayor(dgvOxigenoFisio.Rows(dgvOxigenoFisio.CurrentCell.RowIndex).Cells("Fecha_Inicio").Value, mTxtOxigeno.Value) Then
            MsgBox(Mensajes.FECHA_FINAL_MAYOR, MsgBoxStyle.Exclamation)
        Else
            Dim fecha As DateTime = mTxtOxigeno.Value
            objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentCell.RowIndex).Item(nombreColumnaActual(dgvOxigenoFisio)) = Format(fecha, Constantes.FORMATO_FECHA_OXIGENO_MASCARA)
            objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentCell.RowIndex).Item("Estado") = Constantes.TERMINADO
        End If

        PanelOxigeno.Visible = False
        dgvOxigenoFisio.CurrentCell = dgvOxigenoFisio.Rows(dgvOxigenoFisio.CurrentCell.RowIndex).Cells("Fecha_Fin")
        objHistoriaClinica.objFisioterapia.objOxigeno.totalizarMinutosLitrosPorFila(dgvOxigenoFisio.CurrentRow.Index)
        totalizarOxigeno()
    End Sub
    Sub isNotFechaValida()
        MsgBox(Mensajes.FECHA_NO_VALIDA, MsgBoxStyle.Critical)
        Exec.SacudirCrtl(PanelOxigeno)
        mTxtOxigeno.Focus()
    End Sub
    Sub cargarOxigeno()
        objHistoriaClinica.objFisioterapia.objOxigeno.nRegistro = objHistoriaClinica.nRegistro
        objHistoriaClinica.objFisioterapia.objOxigeno.cargarListaOxigenoOrdenados()
        totalizarOxigeno()
    End Sub

    Sub dibugarPanelOxigenoFisioterapia()
        Dim rec As Rectangle
        Panel5.VerticalScroll.Minimum = ConstantesHC.POSISION_PANEL_CENTRAL_OXIGENO
        Panel5.VerticalScroll.Value = ConstantesHC.POSISION_PANEL_CENTRAL_OXIGENO
        rec = dgvOxigenoFisio.GetCellDisplayRectangle(dgvOxigenoFisio.CurrentCell.ColumnIndex, dgvOxigenoFisio.CurrentCell.RowIndex, False)
        PanelOxigeno.Location = New Point(rec.Location.X + dgvOxigenoFisio.Location.X + groupBoxOxigeno.Location.X - ConstantesHC.EJE_X, rec.Location.Y + dgvOxigenoFisio.Location.Y + groupBoxOxigeno.Location.Y - ConstantesHC.EJE_Y)
        PanelOxigeno.Visible = True
    End Sub
    Sub dibujaPanelGlucometria()
        Dim rec As Rectangle
        'Panel6.VerticalScroll.Minimum = 0
        'Panel6.VerticalScroll.Value = 20
        rec = dgvGlucometriaEnfer.GetCellDisplayRectangle(dgvGlucometriaEnfer.CurrentCell.ColumnIndex, dgvGlucometriaEnfer.CurrentCell.RowIndex, False)
        panelGlucom.Location = New Point(rec.Location.X + dgvGlucometriaEnfer.Location.X + GroupBoxGluco.Location.X - 5, rec.Location.Y + dgvGlucometriaEnfer.Location.Y + GroupBoxGluco.Location.Y - 560)
        panelGlucom.Visible = True
    End Sub
    Sub totalizarOxigeno()
        objHistoriaClinica.objFisioterapia.objOxigeno.totaliarPrecioOxigeno()
        objHistoriaClinica.objFisioterapia.objOxigeno.totalizarLitrosOxigeno()
        txtTotalLitros.Text = String.Format("{0:N0}", objHistoriaClinica.objFisioterapia.objOxigeno.totalLitrosOxigeno)
        txtTotalPrecioOxigenoFisioterapia.Text = FormatCurrency(objHistoriaClinica.objFisioterapia.objOxigeno.totalPrecioOxigeno, 2)
    End Sub
    Function agregarFilaoxigeno() As Boolean
        ' If objHistoriaClinica.objFisioterapia.objOxigeno.agregarOxigeno(dgvOxigenoFisio.CurrentRow.Index) = False Then
        'MsgBox(Mensajes.FECHA_EGRESO_MENOR, MsgBoxStyle.Exclamation)
        'Return False
        ' End If
        objHistoriaClinica.objFisioterapia.objOxigeno.agregarOxigeno(dgvOxigenoFisio.CurrentRow.Index)
        Return True
    End Function
    Sub buscarModoVentilacion(pMetodo As General.cargaInfoForm)
        General.buscarElemento(ConsultasHC.OXIGENO_BUSCAR_MODO,
                               Nothing,
                               pMetodo,
                               TitulosForm.BUSQUEDA_OXIGENO_MODO_VENTILACION,
                               False)
    End Sub
    Sub colocarModoVentilacion(ByVal codigo As Integer)
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(objHistoriaClinica.nRegistro)
        Dim fila As DataRow
        fila = General.cargarItem(ConsultasHC.OXIGENO_CAMBIAR_MODO, params)

        objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentRow.Index).Item("Codigo") = fila("Codigo")
        objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentRow.Index).Item("Descripcion") = fila("Descripcion")
        objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentRow.Index).Item("Porcentaje") = fila("Porcentaje")
        objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentRow.Index).Item("Factor") = fila("Factor")
        objHistoriaClinica.objFisioterapia.objOxigeno.tablaOxigeno.Rows(dgvOxigenoFisio.CurrentRow.Index).Item("Valor") = fila("Valor")
        objHistoriaClinica.objFisioterapia.objOxigeno.colocarFechaFinal()
        totalizarOxigeno()
    End Sub

#End Region
#End Region
#Region "Nebulizacion"
#Region "Metodos"
    Public Sub configurarDgvNebulizacion()
        If dgvNebulizacion.DataSource Is Nothing Then
            With dgvNebulizacion
                .Columns("DescripcionMed").DataPropertyName = "nombreMedicamento"
                .Columns("Fecha_inicio_neb").DataPropertyName = "Fecha_inicio_neb"
                .Columns("Fecha_fin_neb").DataPropertyName = "Fecha_fin_neb"
                .Columns("DescripcionOxi").DataPropertyName = "Descripcion"
                .Columns("Porcentaje_neb").DataPropertyName = "Porcentaje"
                .Columns("Minutos_neb").DataPropertyName = "Hora"
                .Columns("Litros_neb").DataPropertyName = "Litro"
                .Columns("Total_neb").DataPropertyName = "Total"
                .AutoGenerateColumns = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
                .DataSource = objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion
            End With
        End If
    End Sub
    Private Sub cargarNebulizacion()
        objHistoriaClinica.objFisioterapia.objnebulizacion.codigoOrden = listaNebulizacion.SelectedValue
        txtCodigoFisioterapia.Text = objHistoriaClinica.objFisioterapia.objnebulizacion.codigoOrden
        configurarDgvNebulizacion()
        objHistoriaClinica.objFisioterapia.objnebulizacion.cargarNebulizacion()
        objHistoriaClinica.objFisioterapia.objnebulizacion.calculosNebulizacion()
        totalizarNebuliacion()
    End Sub
    Sub dibugarPanelNebulizacion()
        Dim rec As Rectangle
        Panel5.VerticalScroll.Value = ConstantesHC.POSISION_PANEL_CENTRAL_NEBULIZACION
        rec = dgvNebulizacion.GetCellDisplayRectangle(dgvNebulizacion.CurrentCell.ColumnIndex, dgvNebulizacion.CurrentCell.RowIndex, False)
        panelNebulizacion.Location = New Point(rec.Location.X + dgvNebulizacion.Location.X + groupBoxNeb.Location.X - 5, rec.Location.Y + dgvNebulizacion.Location.Y + groupBoxNeb.Location.Y - 91)
        panelNebulizacion.Visible = True
    End Sub
    Sub colocarModoVentilacionNebulizacion(ByVal codigo As Integer)
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(objHistoriaClinica.nRegistro)
        Dim fila As DataRow
        fila = General.cargarItem(ConsultasHC.OXIGENO_CAMBIAR_MODO, params)

        objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentRow.Index).Item("Codigo") = fila("Codigo")
        objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentRow.Index).Item("Descripcion") = fila("Descripcion")
        objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentRow.Index).Item("Porcentaje") = fila("Porcentaje")
        objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentRow.Index).Item("Factor") = fila("Factor")
        objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentRow.Index).Item("Valor") = fila("Valor")
        objHistoriaClinica.objFisioterapia.objnebulizacion.calculosNebulizacion()
        totalizarNebuliacion()
    End Sub
    Sub totalizarNebuliacion()
        objHistoriaClinica.objFisioterapia.objnebulizacion.totaliarPrecioNebulizacion()
        objHistoriaClinica.objFisioterapia.objnebulizacion.totalizarLitrosOxigeno()
        TextBox47.Text = String.Format("{0:N0}", objHistoriaClinica.objFisioterapia.objnebulizacion.totalLitrosNebulizacion)
        TextBox46.Text = FormatCurrency(objHistoriaClinica.objFisioterapia.objnebulizacion.totalPrecioNebulizacion, 2)
    End Sub
    Private Sub isFechaValidaNeb()
        If dgvNebulizacion.CurrentCell.ColumnIndex = 2 AndAlso HistoriaClinicaBLL.isFechaMayor(dgvNebulizacion.Rows(dgvNebulizacion.CurrentCell.RowIndex).Cells("Fecha_inicio_neb").Value, mtxtnebulizacion.Text) Then
            MsgBox(Mensajes.FECHA_FINAL_MAYOR, MsgBoxStyle.Exclamation)
            GoTo salidaError
        End If
        Dim fecha As DateTime = mtxtnebulizacion.Text
        If nombreColumnaActual(dgvNebulizacion) <> "DescripcionOxi" Then
            objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentCell.RowIndex).Item(nombreColumnaActual(dgvNebulizacion)) = Format(fecha, Constantes.FORMATO_FECHA_OXIGENO_MASCARA)
            objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(dgvNebulizacion.CurrentCell.RowIndex).Item("Estado") = Constantes.TERMINADO
        End If

salidaError:
        panelNebulizacion.Visible = False
        dgvNebulizacion.CurrentCell = dgvNebulizacion.Rows(dgvNebulizacion.CurrentCell.RowIndex).Cells("Fecha_fin_neb")
        objHistoriaClinica.objFisioterapia.objnebulizacion.calcularMinutos(dgvNebulizacion.CurrentRow.Index)
        totalizarNebuliacion()
    End Sub
    Sub isNotFechaValidaNebulizacion()
        MsgBox(Mensajes.FECHA_NO_VALIDA, MsgBoxStyle.Critical)
        Exec.SacudirCrtl(panelNebulizacion)
        mtxtnebulizacion.Focus()
    End Sub
    Public Sub guardarNebulizacionFisioterapia()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                CodigoTemporal = listaNebulizacion.SelectedValue
                objHistoriaClinica.objFisioterapia.objnebulizacion.usuario = SesionActual.idUsuario
                objHistoriaClinica.objFisioterapia.objnebulizacion.codigoEP = SesionActual.codigoEP
                objHistoriaClinica.objFisioterapia.guardarNebulizacion()
                'guardarInforme(ConstantesHC.IDENTIFICADOR_NEBULIZACION_FISIOTERAPIA)
                postGuardarFisio()
                listaNebulizacion.SelectedIndex = 0
                tsfisionuevo.Enabled = False
                tsfisioduplicar.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Evento de controles"
    Private Sub listaNebulizacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaNebulizacion.SelectedIndexChanged
        Try
            If listaNebulizacion.DisplayMember = Nothing Then Exit Sub
            If Not Funciones.indiceValidoListas(listaNebulizacion.SelectedIndex) Then
                txtCodigoFisioterapia.Clear()
                tsfisionuevo.Enabled = False
                tsfisioduplicar.Enabled = False
                If Not IsNothing(dgvNebulizacion.DataSource) Then
                    dgvNebulizacion.DataSource.clear
                End If
                tsfisioeditar.Enabled = False
                tsfisioanular.Enabled = False
                totalizarNebuliacion()
            Else
                cargarNebulizacion()
                tsfisionuevo.Enabled = True
                tsfisioeditar.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvNebulizacion_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvNebulizacion.RowPostPaint
        General.generarSecuencial(dgvNebulizacion, e)
    End Sub
    Private Sub dgvNebulizacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNebulizacion.CellDoubleClick

        If tsfisioguardar.Enabled = True Then
            If e.RowIndex = 0 AndAlso Funciones.verificacionPosicionActual(dgvNebulizacion, e, "Fecha_inicio_neb") Then
                MsgBox(Mensajes.FECHA_PRIMERA_ORDEN_PACIENTE, MsgBoxStyle.Exclamation)
            ElseIf (Funciones.verificacionPosicionActual(dgvNebulizacion, e, "Fecha_inicio_neb") OrElse
                   Funciones.verificacionPosicionActual(dgvNebulizacion, e, "Fecha_fin_neb")) AndAlso
                   objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion.Rows(e.RowIndex).Item("Descripcion").ToString = "" Then

                MsgBox(Mensajes.ESCOGE_MODO_VENTILACION, MsgBoxStyle.Exclamation)
            ElseIf Funciones.verificacionPosicionActual(dgvNebulizacion, e, "Fecha_inicio_neb") OrElse
                   Funciones.verificacionPosicionActual(dgvNebulizacion, e, "Fecha_fin_neb") Then

                mtxtnebulizacion.Text = dgvNebulizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                dibugarPanelNebulizacion()
                mtxtnebulizacion.ReadOnly = False
                mtxtnebulizacion.Focus()
            ElseIf Funciones.verificacionPosicionActual(dgvNebulizacion, e, dgvNebulizacion.Columns("DescripcionOxi").Name) Then
                buscarModoVentilacion(AddressOf colocarModoVentilacionNebulizacion)
            ElseIf Funciones.verificacionPosicionActual(dgvNebulizacion, e, dgvNebulizacion.Columns("quitarNeb").Name) Then
                Funciones.quitarFilas(objHistoriaClinica.objFisioterapia.objnebulizacion.tablaNebulacion, e.RowIndex)
                totalizarNebuliacion()
            End If
        Else
            mTxtOxigeno.Enabled = False
        End If

    End Sub
    Private Sub mtxtnebulizacion_Leave(mtxtnebulizacion As Object, e As EventArgs) Handles mtxtnebulizacion.Leave
        If IsDate(mtxtnebulizacion.Text) AndAlso mtxtnebulizacion.MaskCompleted Then
            isFechaValidaNeb()
        Else
            isNotFechaValidaNebulizacion()
        End If

        dgvNebulizacion.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvNebulizacion.EndEdit()
    End Sub
    Private Sub AgregarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem1.Click
        If tsfisioguardar.Enabled = True And Funciones.filaValida(dgvNebulizacion.CurrentRow.Index) Then
            objHistoriaClinica.objFisioterapia.objnebulizacion.agregarNuevaNebulizacion(dgvNebulizacion.CurrentRow.Index)
        End If
    End Sub
    Private Sub dgvNebulizacion_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvNebulizacion.CellMouseDown
        If tsfisioguardar.Enabled = True Then
            CtxNebulizacionFisioterapia.Enabled = True
        Else
            CtxNebulizacionFisioterapia.Enabled = False
        End If
    End Sub
    Private Sub mtxtnebulizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles mtxtnebulizacion.KeyDown
        If e.KeyCode = Keys.Escape OrElse e.KeyCode = Keys.Enter Then
            dgvNebulizacion.Focus()
        End If
    End Sub
    Private Sub dgvOxigeno_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOxigeno.CellEnter
        ActivarSuspender(e)
    End Sub
    Private Sub dgvOxigeno_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOxigeno.CellClick
        ActivarSuspender(e)
    End Sub
    Sub ActivarSuspender(e As DataGridViewCellEventArgs)
        If Funciones.filaValida(e.RowIndex) Then
            Dim cantidadSuspendidos As Integer = objHistoriaClinica.objOrdenMedica.dtOxigenos.Select("Suspender = True", "").Count
            dgvOxigeno.ReadOnly = False
            If tsordenguardar.Enabled AndAlso
                e.RowIndex < (dgvOxigeno.Rows.Count - 1) AndAlso
                e.ColumnIndex = dgvOxigeno.Columns("SuspenderOx").Index AndAlso
                dgvOxigeno.Rows(e.RowIndex).Cells("dgCodigoOxigeno").Value.ToString <> "" Then

                dgvOxigeno.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvOxigeno.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
#End Region
#End Region

End Class