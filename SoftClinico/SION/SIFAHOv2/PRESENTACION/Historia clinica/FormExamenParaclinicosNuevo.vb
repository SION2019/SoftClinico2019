Imports System.Threading
Public Class FormExamenParaclinicosNuevo
    Private objParaclinicoLab As Object
    Private reporteParams As New ReporteParams
    Public Property historiaClinica As Form_Historia_clinica
    Property listaExamen As FormListaExamen
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Peditar, Panular, PNuevo As String
    Private Sub FormExamenParaclinicosNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False
        objParaclinicoLab.codigoEP = SesionActual.codigoEP
        objParaclinicoLab.usuario = SesionActual.idUsuario
        objParaclinicoLab.idEmpresa = SesionActual.idEmpresa
        reporteParams.activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        reporteParams.activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
        pedirEmpleado()
        objParaclinicoLab.filtrarTipo()
        btHistorialReultados.Enabled = True
    End Sub

    Private Sub pedirEmpleado()
        If String.IsNullOrEmpty(objParaclinicoLab.usuarioReal) And
                  objParaclinicoLab.datosExistente = False Then
            responsableCargar()
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                If reporteParams.moduloTemporal <> Constantes.HC AndAlso IsNothing(objParaclinicoLab.usuarioReal) Then
                    If responsableCargar() = False Then
                        Exit Sub
                    End If
                End If

                General.deshabilitarBotones(ToolStrip1)
                General.habilitarControles(Me)
                General.deshabilitarControles(GroupDatos)
                ValidarCamposGrilla()
                dtfecha.Enabled = True
                dtFechaMuestra.Enabled = True
                btguardar.Enabled = True
                btcancelar.Enabled = True
                ChAntibiograma.Enabled = False
                btAntibiograma.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Dim dtAux As DataTable
        dgvExamen.EndEdit()
        dgvExamen.CommitEdit(DataGridViewDataErrorContexts.Commit)
        objParaclinicoLab.dtExamen.AcceptChanges()
        dtAux = objParaclinicoLab.dtExamen.copy

        If dtAux.Select("[Resultado] <> ''").Count = 0 Then
            MsgBox("Digite algún resultado", MsgBoxStyle.Exclamation)
        ElseIf Format(CDate(CDate(dtFechaMuestra.Value)), Constantes.FORMATO_FECHA_GEN2) >
               Format(CDate(CDate(dtfecha.Value)), Constantes.FORMATO_FECHA_GEN2) Then
            MsgBox("La fecha de Muestra debe ser inferior, a la fecha del resultado", MsgBoxStyle.Exclamation)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                btimprimir.Enabled = False
                objParaclinicoLab.usuarioReal = IIf(String.IsNullOrEmpty(objParaclinicoLab.usuarioReal),
                                                    objParaclinicoLab.usuario, objParaclinicoLab.usuarioReal)
                objParaclinicoLab.fechaReal = dtfecha.Value
                Try
                    guardarExamenes()
                    ' guardarReporte()
                    'historiaClinica.cargarOrdenMedica()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub guardarExamenes()
        reporteParams.usuarioActual = objParaclinicoLab.usuario
        reporteParams.nRegistro = objParaclinicoLab.registro
        objParaclinicoLab.fechaMuestra = dtFechaMuestra.Value
        reporteParams.codigoTemporal = objParaclinicoLab.codigoOrden
        reporteParams.codigoTemporal2 = objParaclinicoLab.codigoProcedimiento
        reporteParams.codigoTemporal3 = objParaclinicoLab.tipoExamen
        reporteParams.codigoTemporal4 = objParaclinicoLab.tipoExamenDescripcion
        ExamenLaboratorioBLL.guardarExamen(objParaclinicoLab)
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False
        ChAntibiograma.Enabled = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    ExamenLaboratorioBLL.anularExamen(objParaclinicoLab)
                    If Not IsNothing(historiaClinica) Then
                        historiaClinica.cargarOrdenMedica()
                    ElseIf Not IsNothing(listaExamen) Then
                        listaExamen.cargarRegistros()
                    End If
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Dispose()
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dispose()
        End If
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Try

            objParaclinicoLab.imprimir()

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub FormExamenParaclinicos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btguardar.Enabled = True AndAlso objParaclinicoLab.datosExistente Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If objParaclinicoLab.datosExistente = False OrElse MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Function cargarPaciente(codigoOrden As Integer,
                                   codigoProcedimiento As String,
                                   modulo As String,
                                   estado As Boolean,
                                   areaExamen As String) As Boolean
        Dim banderaPermiso As Boolean

        cargarPermiso(If(modulo = Constantes.LB, Constantes.HC, modulo))
        modulo = If(modulo <> Constantes.CODIGO_MENU_AUDM AndAlso modulo <> Constantes.CODIGO_MENU_AUDF, Constantes.HC, modulo)
        If SesionActual.tienePermiso(PNuevo) = False _
            And estado = False Then
            banderaPermiso = True
        End If

        Dim dFila As DataRow
        objParaclinicoLab = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_EXAMEN_LAB & If(areaExamen = "A", Constantes.LB, modulo))

        Label1.Text = objParaclinicoLab.titulo
        objParaclinicoLab.codigoOrden = codigoOrden
        objParaclinicoLab.codigoProcedimiento = codigoProcedimiento
        objParaclinicoLab.areaExamen = areaExamen
        reporteParams.moduloTemporal = modulo


        dFila = objParaclinicoLab.cargarPacienteExamen()
        txtidentificacion.Text = dFila.Item("identificacion")
        txtpaciente.Text = dFila.Item("NombrePaciente")
        txtfechaingreso.Text = dFila.Item("Fecha_Admision")
        dtFechaOrden.Text = dFila.Item("Fecha_Orden")
        lblentorno.Text = dFila.Item("Sala")
        txtsexo.Text = dFila.Item("Genero")
        txtedad.Text = dFila.Item("Edad")
        txtcama.Text = dFila.Item("Cama")
        txtregistro.Text = dFila.Item("N_Registro")
        txtcodigocontrato.Text = dFila.Item("Codigo_Contrato")
        txtcontrato.Text = dFila.Item("Contrato")
        dtFechaMuestra.Value = dFila.Item("Fecha_Muestra")
        objParaclinicoLab.codigoGenero = dFila.Item("CodGenero")
        dtfecha.Value = dFila.Item("Fecha")
        txtCodigoOrden.Text = codigoOrden
        TabPage1.Text = dFila.Item("Nombre_Laboratorio")
        objParaclinicoLab.tipoExamenDescripcion = dFila.Item("Nombre_Laboratorio")
        objParaclinicoLab.registro = txtregistro.Text
        objParaclinicoLab.tipoExamen = dFila.Item("Codigo_Laboratorio")
        objParaclinicoLab.datosExistente = dFila.Item("Existencia")
        objParaclinicoLab.agrupable = dFila.Item("Agrupable")
        objParaclinicoLab.usuarioreal = dFila.Item("Usuario_Real").ToString
        objParaclinicoLab.cargarNombrePDF()
        objParaclinicoLab.CargarParametros()
        validarDgv(dgvExamen)

        General.deshabilitarBotones(ToolStrip1)

        If objParaclinicoLab.datosExistente = True Then
            objParaclinicoLab.banderaReporte = True
            General.deshabilitarControles(Me)
            bteditar.Enabled = True
            btanular.Enabled = True
            btimprimir.Enabled = True
        Else
            General.habilitarControles(Me)
            General.deshabilitarControles(GroupDatos)
            ValidarCamposGrilla()
            dtfecha.Enabled = True
            dtFechaMuestra.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            ChAntibiograma.Enabled = False
        End If

        If Funciones.consultaExistenciaAntibiograma(codigoOrden, codigoProcedimiento, modulo) = True Then
            ChAntibiograma.Checked = True
            ChAntibiograma.Enabled = False
        Else
            ChAntibiograma.Enabled = True
            btAntibiograma.Enabled = False
        End If

        Return banderaPermiso

    End Function
    Private Sub dgvExamen_CellClick(sender As Object, e As EventArgs) Handles dgvExamen.CellClick
        Dim estado As Boolean
        If btguardar.Enabled = True Then
            estado = False
        Else
            estado = True
        End If
        ExamenLaboratorioBLL.abrirJustificacionLab(dgvExamen, estado, Panel7, txtComentario, "Comentario")
    End Sub
    Private Sub txtComentario_Leave(sender As Object, e As EventArgs) Handles txtComentario.Leave
        Try
            If Panel7.Visible = True Then
                Panel7.Visible = False
                dgvExamen.Rows(dgvExamen.CurrentRow.Index).Cells("Comentario").Value = txtComentario.Text
                txtComentario.Clear()
                objParaclinicoLab.dtExamen.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvExamen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvExamen.KeyPress
        Dim estado As Boolean
        If btguardar.Enabled = True Then
            estado = False
        Else
            estado = True
        End If
        ExamenLaboratorioBLL.abrirJustificacionLab(dgvExamen, estado, Panel7, txtComentario, "Comentario")
    End Sub
    Private Sub validarDgv(grilla As DataGridView)
        With grilla
            .DataSource = objParaclinicoLab.dtExamen
            .Columns("Codigo_Orden").Visible = False
            .Columns("Codigo_Procedimiento").Visible = False
            .Columns("Codigo").Visible = False
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("resultado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("comentario").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Referencia").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Referencia").DefaultCellStyle.BackColor = Control.DefaultBackColor
            .Columns("unidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("unidad").DefaultCellStyle.BackColor = Control.DefaultBackColor
            'CType(.Columns("resultado"), DataGridView).le
        End With
    End Sub
    Private Sub ValidarCamposGrilla()
        With dgvExamen
            .Columns("Descripcion").ReadOnly = True
            .Columns("resultado").ReadOnly = False
            .Columns("comentario").ReadOnly = False
            .Columns("Referencia").ReadOnly = True
            .Columns("unidad").ReadOnly = True
        End With
    End Sub


    Private Sub ChAntibiograma_CheckedChanged(sender As Object, e As EventArgs) Handles ChAntibiograma.CheckedChanged
        If ChAntibiograma.Checked = True Then
            btAntibiograma.Enabled = True
        Else
            btAntibiograma.Enabled = False
        End If
    End Sub

    Private Sub btAntibiograma_Click(sender As Object, e As EventArgs) Handles btAntibiograma.Click
        Dim form As New Form_resultado
        form.cargarResultado(objParaclinicoLab.codigoOrden,
                             objParaclinicoLab.codigoProcedimiento,
                             TabPage1.Text, reporteParams.moduloTemporal,
                             ConstantesHC.CODIGO_PDF, "H", objParaclinicoLab.registro)

        form.ShowDialog()
    End Sub
    Private Sub dgvExamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellClick

    End Sub
    Private Sub btHistorialReultados_Click(sender As Object, e As EventArgs) Handles btHistorialReultados.Click
        dgvHistorialResultados.DataSource = objParaclinicoLab.llenarHistorial()
        If dgvHistorialResultados.Columns.Contains("Codigo_procedimiento") Then
            dgvHistorialResultados.Columns("Codigo_procedimiento").Visible = False
            dgvHistorialResultados.Columns("Codigo_Item").Visible = False
        End If
        btnSalir.Enabled = True
        pnlHistorial.Visible = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        pnlHistorial.Visible = False
    End Sub

    Private Sub dgvExamen_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellEndEdit
        If dgvExamen.RowCount > 0 Then
            Dim filaActual As DataGridViewCellCollection = dgvExamen.Rows(e.RowIndex).Cells
            If filaActual("Codigo").Value = 73 OrElse filaActual("Codigo").Value = 74 Then
                If valirdarIngresoValido(dgvExamen, "Resultado", 0) AndAlso valirdarIngresoValido(dgvExamen, "Resultado", 1) Then
                    Dim fo2 As Double = dgvExamen.Rows(0).Cells("Resultado").Value
                    Dim po2 As Double = dgvExamen.Rows(1).Cells("Resultado").Value
                    dgvExamen.Rows(7).Cells("Resultado").Value = (po2 / fo2).ToString("N2")
                End If
            End If
        End If
    End Sub
    Function valirdarIngresoValido(ByRef dgv As DataGridView, ByVal nombreComlumna As String, fila As Integer)
        Return IsNumeric(dgv.Rows(fila).Cells(nombreComlumna).Value.ToString) AndAlso Not IsDBNull(dgv.Rows(fila).Cells(nombreComlumna).Value)
    End Function

    Private Sub BtExamen_Click(sender As Object, e As EventArgs) Handles BtExamen.Click
        Dim formExamenParac As New FormReferenciaExamConf
        formExamenParac.objParaclinico = objParaclinicoLab
        formExamenParac.ShowDialog()
    End Sub
    Private Sub cargarPermiso(Modulo As String)
        permiso_general = perG.buscarPermisoGeneral(Name, Modulo)
        Peditar = permiso_general & "pp" & "01"
        Panular = permiso_general & "pp" & "02"
        PNuevo = permiso_general & "pp" & "03"
    End Sub

    Private Function responsableCargar() As Boolean
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_EXAMEN_LAB)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(If(SesionActual.codigoEnlace = 2, Consultas.BUSQUEDA_EMPLEADO_REYFALS, Consultas.BUSQUEDA_EMPLEADO_HC), params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objParaclinicoLab.usuarioReal = tbl(0)
                respuesta = True
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Close()
            End If
        End If
        Return respuesta
    End Function
End Class