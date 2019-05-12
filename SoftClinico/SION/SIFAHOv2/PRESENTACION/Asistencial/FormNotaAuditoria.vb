Public Class FormNotaAuditoria
    Dim vFormPadre As Form_Historia_clinica
    Private objNotaAuditoria As NotaAuditoria
    Dim permiso_general, pNuevo, pBuscar, pAnular, pEditar As String
    Dim perG As New Buscar_Permisos_generales
    Public Property formHistoriaClinica As Form_Historia_clinica
    Dim codigo As String
    Dim idEmpleado, idCargo, idCoordinador As Integer
    Public sw As Boolean
    Dim modulo As String
    Private Sub FormNotaAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objNotaAuditoria = New NotaAuditoria
        permiso_general = perG.buscarPermisoGeneral(Me.Name, modulo)
        pNuevo = permiso_general & "pp" & "01"
        pBuscar = permiso_general & "pp" & "02"
        pEditar = permiso_general & "pp" & "03"
        pAnular = permiso_general & "pp" & "04"
        General.deshabilitarBotones(lblUsuario)
        General.deshabilitarControles(Me)
        btbuscarPaciente.Enabled = True
        btbuscar.Enabled = True
        btnuevo.Enabled = True
        If sw = False Then
            cargarPaciente(formHistoriaClinica.txtRegistro.Text)
        End If
        txtObservacion.ReadOnly = True
    End Sub
    Public Sub cargarModulo(tag As String)
        modulo = tag
    End Sub
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(Consultas.BUSQUEDA_ADMISION,
                              params,
                              AddressOf cargarPaciente,
                              TitulosForm.BUSQUEDA_PACIENTE,
                              True, 0, True)
    End Sub
    Public Sub cargarPaciente(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim fila As DataRow
        params.Add(pCodigo)
        Try
            'If objNotaAuditoria.bandera = False Then
            '    codigo = String.Empty
            '    General.limpiarControles(Me)
            'End If
            fila = General.cargarItem(Consultas.PACIENTE_CARGAR_NOTA, params)
            txtregistro.Text = fila.Item("Registro")
            txtidentificacion.Text = fila.Item("Documento")
            txtfechaingreso.Text = Format(CDate(fila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = fila.Item("Paciente").ToString
            txtsexo.Text = fila.Item("Genero").ToString
            txtedad.Text = fila.Item("Edad").ToString
            txtcodigocontrato.Text = fila.Item("Codigo_EPS").ToString
            txtcontrato.Text = fila.Item("Contrato").ToString
            txtAreaServicio.Text = fila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = fila.Item("Cama").ToString

            General.deshabilitarBotones(lblUsuario)
            General.habilitarControles(Me)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            dtfecha.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarObjeto()
        objNotaAuditoria.codigoNota = codigo
        objNotaAuditoria.idResponsableDirig = idCargo
        objNotaAuditoria.idResponsableEncargado = idEmpleado
        objNotaAuditoria.idCoordinador = idCoordinador
        objNotaAuditoria.registro = txtregistro.Text
        objNotaAuditoria.titulo = txtTitulo.Text
        objNotaAuditoria.nota = txtNota.Rtf
        objNotaAuditoria.dtFecha = Convert.ToDateTime(dtfecha.Value)
        objNotaAuditoria.revisado = chRevisado.Checked
        objNotaAuditoria.codigoNotaRevisada = txtCodigoNota.Text
    End Sub
    Private Function validarCampos() As Boolean
        Dim bandera As Boolean

        If txtCargo.Text = "" Then
            Exec.SavingMsg("¡ Seleccionar para quien va dirigido !", txtCargo)
        ElseIf txtEmpleado.Text = "" Then
            Exec.SavingMsg("¡ Seleccionar el Encargado !", txtEmpleado)
        ElseIf txtCoordinador.Text = "" Then
            Exec.SavingMsg("¡ seleccionar el coordinador !", txtCoordinador)
        ElseIf txtTitulo.Text = String.Empty Then
            Exec.SavingMsg("¡ Digitar el titulo !", txtTitulo)
        ElseIf txtNota.Text = String.Empty Then
            Exec.SavingMsg("¡ Digitar la nota de Auditoria !", txtNota)
        Else
            bandera = True
        End If
        Return bandera
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarCampos() = True Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = vbYes Then
                Try
                    cargarObjeto()
                    NotaAuditoriaBLL.guardarNotaAuditoria(objNotaAuditoria)
                    codigo = objNotaAuditoria.codigoNota
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(lblUsuario)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub cambiarColor()
        If Colores.ShowDialog = DialogResult.OK Then
            txtNota.SelectionColor = Colores.Color
        End If
    End Sub
    Private Sub cambiarLetra()
        If Letra.ShowDialog = DialogResult.OK Then
            txtNota.SelectionFont = Letra.Font
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = vbYes Then
            General.deshabilitarBotones(lblUsuario)
            General.deshabilitarControles(Me)
            txtNota.Clear()
            txtEmpleado.Clear()
            txtCoordinador.Clear()
            txtCargo.Clear()
            textUsuario.Text = ""
            codigo = String.Empty
            btbuscar.Enabled = True
            btnuevo.Enabled = True
        End If
    End Sub
    Private Sub CambiarColorDeFuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarColorDeFuenteToolStripMenuItem.Click
        If btguardar.Enabled = False Then Exit Sub
        cambiarColor()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = vbYes Then
                General.deshabilitarBotones(lblUsuario)
                General.habilitarControles(Me)
                General.deshabilitarControles(GroupDatos)
                dtfecha.Enabled = True
                btguardar.Enabled = True
                btcancelar.Enabled = True
                txtObservacion.ReadOnly = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub CambiarLetraDeLaFuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarLetraDeLaFuenteToolStripMenuItem.Click
        If btguardar.Enabled = False Then Exit Sub
        cambiarLetra()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(txtregistro.Text)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.NOTA_AUDITORIA_BUSCAR,
                                          params,
                                          AddressOf cargarDatos,
                                          TitulosForm.BUSQUEDA_NOTA_AUDITORIA,
                                          True, Constantes.TAMANO_GRANDE, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub cargarDatos(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        dFila = General.cargarItem(Consultas.NOTA_AUDITORIA_CARGAR, params)
        txtObservacion.Text = "Respuesta de"
        If Not IsNothing(dFila) Then
            Cursor = Cursors.WaitCursor
            codigo = pCodigo
            txtCodigoNota.Text = pCodigo
            dtfecha.Value = dFila.Item("Fecha")
            idCargo = dFila.Item("ID_Responsable_Dirig")
            txtCargo.Text = dFila.Item("Cargo")
            idEmpleado = dFila.Item("ID_Responsable_Enca")
            txtEmpleado.Text = dFila.Item("Responsable")
            idCoordinador = dFila.Item("ID_Coordinador")
            txtCoordinador.Text = dFila.Item("Coordinador")
            txtObservacion.Text = txtObservacion.Text & " " & dFila.Item("RealizadoPor").ToString.ToLower & " " &
                dFila.Item("fecha_realizacion") & vbCrLf & dFila.Item("Observacion").ToString
            txtTitulo.Text = dFila.Item("Titulo")
            Try
                txtNota.Rtf = dFila.Item("Nota")
            Catch ex As Exception
                txtNota.Text = dFila.Item("Nota")
            End Try
            chRevisado.Checked = dFila.Item("Revisado")

            'objNotaAuditoria.bandera = True
            cargarPaciente(dFila.Item("N_Registro"))
            textUsuario.Text = dFila.Item("Usuario").ToString
            'objNotaAuditoria.bandera = False
            General.habilitarBotones(lblUsuario)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            btbuscarPaciente.Enabled = True
            If dFila.Item("Observacion").ToString = String.Empty Then
                bteditar.Enabled = True
                chRevisado.Visible = False
                ChRenviar.Visible = False
            Else
                chRevisado.Visible = True
                If chRevisado.Checked = False Then
                    ChRenviar.Visible = True
                    chRevisado.Enabled = True
                    ChRenviar.Enabled = True
                Else
                    ChRenviar.Visible = False
                    chRevisado.Enabled = False
                End If
                bteditar.Enabled = False

            End If
            Cursor = Cursors.Default

        End If
        ChRenviar.Checked = False
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If General.anularRegistro(Consultas.NOTA_AUDITORIA_ANULAR & " " & codigo & "," & SesionActual.idUsuario) Then
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(lblUsuario)
                    btbuscarPaciente.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim nombreArchivo, ruta As String
        Dim reporte As New ftp_reportes
        Cursor = Cursors.WaitCursor
        Try
            nombreArchivo = Constantes.NOTA_AUDITORIA & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(Constantes.NOTA_AUDITORIA, objNotaAuditoria.registro,
                                               New rptNotaAuditoria,
                                               codigo,
                                               "{VISTA_NOTA_AUDITORIA.ID_Nota_Auditoria}=" & CInt(codigo),
                                               Constantes.NOTA_AUDITORIA,
                                               IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btCaptura_Click(sender As Object, e As EventArgs) Handles btCaptura.Click
        Dim Imagen As Bitmap = RecorteImagen.capturarPantalla(Me)
        If Imagen Is Nothing Then Return
        Clipboard.SetDataObject(Imagen)
        txtNota.Focus()
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNuevo) Then
            btBuscarCargo.Enabled = True
            btBuscarCoordinador.Enabled = True
            btBuscarResponsable.Enabled = True
            txtNota.ReadOnly = False
            txtNota.Clear()
            txtCoordinador.Clear()
            txtEmpleado.Clear()
            txtCargo.Clear()
            txtTitulo.Clear()
            General.deshabilitarBotones(lblUsuario)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            txtTitulo.ReadOnly = False
            txtObservacion.ReadOnly = True
            txtObservacion.Clear()
            codigo = String.Empty
            ChRenviar.Visible = False
            chRevisado.Visible = False
            btCaptura.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btBuscarCoordinador_Click(sender As Object, e As EventArgs) Handles btBuscarCoordinador.Click
        Dim tblCoordinador As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.EMPLEADO_ACTIVOS_BUSCAR, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True, False, True)
        tblCoordinador = formBusqueda.rowResultados
        If tblCoordinador IsNot Nothing Then
            idCoordinador = tblCoordinador(0)
            txtCoordinador.Text = tblCoordinador(2)
        End If
    End Sub

    Private Sub ChRenviar_CheckedChanged(sender As Object, e As EventArgs) Handles ChRenviar.CheckedChanged
        If ChRenviar.Checked Then
            codigo = String.Empty
            General.deshabilitarBotones(lblUsuario)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            txtNota.ReadOnly = False
            chRevisado.Checked = True
        Else
            General.habilitarBotones(lblUsuario)
            btcancelar.Enabled = False
            btguardar.Enabled = False
            bteditar.Enabled = False
            codigo = txtCodigoNota.Text
            txtNota.ReadOnly = True
            chRevisado.Checked = False
        End If
    End Sub

    Private Sub chRevisado_CheckedChanged(sender As Object, e As EventArgs) Handles chRevisado.CheckedChanged
        If chRevisado.Checked Then
            General.deshabilitarBotones(lblUsuario)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
            General.habilitarBotones(lblUsuario)
            btcancelar.Enabled = False
            btguardar.Enabled = False
            bteditar.Enabled = False
        End If
    End Sub

    Private Sub btBuscarResponsable_Click(sender As Object, e As EventArgs) Handles btBuscarResponsable.Click
        Dim tblEmpleado As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(idCargo)
        params.Add(SesionActual.idEmpresa)
        params.Add(String.Empty)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.EMPLEADOS_ACTIVOS_LISTAR, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True, False, True)
        tblEmpleado = formBusqueda.rowResultados
        If tblEmpleado IsNot Nothing Then
            idEmpleado = tblEmpleado(0)
            txtEmpleado.Text = tblEmpleado(1)
        End If
    End Sub

    Private Sub btBuscarCargo_Click(sender As Object, e As EventArgs) Handles btBuscarCargo.Click
        Dim tblCargo As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(String.Empty)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.CARGO_LISTAR, params, TitulosForm.BUSQUEDA_CARGOS, True, False, True)
        tblCargo = formBusqueda.rowResultados
        If tblCargo IsNot Nothing Then
            idCargo = tblCargo(0)
            txtCargo.Text = tblCargo(1)
            idEmpleado = 0
            txtEmpleado.Clear()
        End If
    End Sub

End Class