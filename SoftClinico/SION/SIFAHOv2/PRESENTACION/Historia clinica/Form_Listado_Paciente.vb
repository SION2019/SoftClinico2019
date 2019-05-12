Imports Celer
Imports System.Data.SqlClient

Public Class Form_Listado_Paciente
    Dim dt As New DataTable
    Dim modulo As String
    Dim moduloAreaServicio As String
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pTodasAreas, pverHistoriaClinica, pConsolidado, pCerrarRevision, pVerListaChequeo, pVerCantidadNota, pVerNotasRevisadas, pVerResponsablePaciente As String
    Dim registro As Integer
    Dim dtVerificar As New DataTable
    Public codGenerar As Boolean
    Dim entrarUnaVez As Boolean = False
    Dim revisionUnaVez As Boolean = False
    Dim objPrincipal As New Principal
    Dim objListachequeo As New ListaCheck
    Dim formHistoriaClinica As New Form_Historia_clinica()
    Private Sub dgvmanual_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmanual.CellDoubleClick
        If dgvmanual.RowCount > 0 Then
            If e.RowIndex = Constantes.VALOR_PREDETERMINADO Then
                If (dgvmanual.Columns(e.ColumnIndex).Name = "Aprobado") Then

                End If
                Exit Sub
            End If
            If dgvmanual.Columns(e.ColumnIndex).Name = "Aprobado" Then
                If MsgBox(Mensajes.APROBAR_REVISION_UNICA, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If dgvmanual.Rows.Count > 0 Then
                        If dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("Resultado").Value = 0 Then
                            registro = dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("registro").Value
                            cambiarEstadoCerrado(e.RowIndex, Constantes.CODIGO_MENU_HISTC)
                            cambiarEstadoCerrado(e.RowIndex, Constantes.CODIGO_MENU_AUDM)
                            cambiarEstadoCerrado(e.RowIndex, Constantes.CODIGO_MENU_AUDF)
                        Else
                            MsgBox("No se puede cerrar el paciente " & dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("Paciente").Value.ToString.ToLower & " porque tiene notas por revisar", MsgBoxStyle.Information)
                        End If
                    End If
                    End If
            ElseIf dgvmanual.Columns(e.ColumnIndex).Name = "Check_List" Then
                Dim form As New FormFacturaImprimir
                objListachequeo.registro = dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells("Registro").Value.ToString
                form.registro(objListachequeo)
                FormPrincipal.Cursor = Cursors.WaitCursor
                form.ShowDialog()
                If form.WindowState = FormWindowState.Minimized Then
                    form.WindowState = FormWindowState.Normal
                End If
                FormPrincipal.Cursor = Cursors.Default
            ElseIf dgvmanual.Columns(e.ColumnIndex).Name = "Notas" Then
                Dim params As New List(Of String)
                Dim dtNotas As New DataTable
                params.Add(dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells("Registro").Value.ToString)
                General.llenarTabla(ConsultasHC.NOTA_AUDITORIA_LISTAR, params, dtNotas)
                pnlAuditoria.Visible = True
                dgvNotaAuditoria.DataSource = dtNotas
            Else
                Dim principal As New PrincipalDAL
                If String.IsNullOrEmpty(dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells("Codigo_Solicitud").Value.ToString) Then
                    FormPrincipal.Cursor = Cursors.WaitCursor
                    Select Case modulo
                        Case Constantes.HC, Constantes.CODIGO_MENU_HEMO, Constantes.CODIGO_MENU_QUIR, Constantes.CODIGO_MENU_HOSP
                            abrirHistoriaClinica(principal)
                        Case Constantes.CODIGO_MENU_URG
                            Select Case Tag.codigo
                                Case Constantes.CODIGO_MENU_TRIAGE
                                    abrirTriage(principal)
                                Case Else
                                    abrirHistoriaClinica(principal)
                            End Select
                        Case Constantes.AM
                            abrirAuditoriaMedica(principal)
                        Case Constantes.AF
                            abrirAuditoriaFacturacion(principal)
                    End Select
                    FormPrincipal.Cursor = Cursors.Default

                End If
            End If

        End If

    End Sub

    Public Sub verificarSoporte(ByVal historiaCerrada As Boolean)
        If selRevision.Checked = True And historiaCerrada = True Then
            listarPaciente()
        End If
    End Sub

    Public Function listaChequeo(ByVal pModulo As String, ByVal index As Integer) As DataSet
        Dim verificar As String
        Select Case pModulo
            Case Constantes.AM
                verificar = Consultas.LISTA_CHECK_R
            Case Constantes.AF
                verificar = Consultas.LISTA_CHECK_RR
            Case Else
                verificar = Consultas.LISTA_CHECK
        End Select
        Dim ds As New DataSet
        Dim params As New List(Of String)
        If index <> Constantes.VALOR_PREDETERMINADO Then
            params.Add(registro)
            params.Add(Constantes.VALOR_PREDETERMINADO)
        Else
            params.Add(Constantes.VALOR_PREDETERMINADO)
            params.Add(Constantes.ESTADO_ATENCION_REVISION)
        End If

        General.llenarDataSet(verificar, params, ds)
        Return ds
    End Function

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub pintarTS(pForm As Form_Historia_clinica, Color As Color)
        pForm.TSinfoingreso.BackColor = Color
        pForm.TSOrdenes.BackColor = Color
        pForm.TSevoluciones.BackColor = Color
        pForm.TSInterconsultas.BackColor = Color
        pForm.TSRemisiones.BackColor = Color
        pForm.TSFisioterapias.BackColor = Color
        pForm.TSEnfermeria.BackColor = Color
        pForm.TScuerpom.BackColor = Color
    End Sub
    Private Sub pintarList(pForm As Form_Historia_clinica, Color As Color)
        pForm.listaordenes.ForeColor = Color
        pForm.Listaevoluciones.ForeColor = Color
        pForm.ListaInterconsultas.ForeColor = Color
        pForm.Listaremisiones.ForeColor = Color
        pForm.listaOxigeno.ForeColor = Color
        pForm.listaNebulizacion.ForeColor = Color
        pForm.listaTerapias.ForeColor = Color
        pForm.listaNotasfisio.ForeColor = Color
        pForm.listaInsumosfisio.ForeColor = Color
        pForm.listaInsumosEnfer.ForeColor = Color
        pForm.listaNotasEnfer.ForeColor = Color
        pForm.listaParaclinicos.ForeColor = Color
        pForm.listaHemoderivados.ForeColor = Color
        pForm.listaGlucometria.ForeColor = Color
    End Sub
    Private Sub abrirAuditoriaFacturacion(principal As PrincipalDAL)
        If SesionActual.tienePermiso(pverHistoriaClinica) Then
            If principal.estaAbierto(ConstantesHC.NOMBRE_FORM_AF) = True Then
                principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_AF)
                principal.cerrarFormulario(ConstantesHC.NOMBRE_FORM_AF)
            End If
            If principal.estaAbierto(ConstantesHC.NOMBRE_FORM_AF) = False Then
                Dim formAuditoriaFacturacion As New Form_Historia_clinica
                precargarForm(formAuditoriaFacturacion, ConstantesHC.NOMBRE_TITULO_AF, ConstantesHC.NOMBRE_FORM_AF)
                formAuditoriaFacturacion.Show()
                pintarTS(formAuditoriaFacturacion, Color.LightGreen)
                pintarList(formAuditoriaFacturacion, Color.Green)
                principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_AF)
            End If
        Else
            abrirConsolidado(ConstantesHC.NOMBRE_TITULO_AF, ConstantesHC.NOMBRE_FORM_AF)
        End If
    End Sub
    Private Sub abrirConsolidado(titulo As String, nombreForm As String)
        If Not formHistoriaClinica.consolidadoPendiente() Then
            precargarForm(formHistoriaClinica, titulo, nombreForm)
            formHistoriaClinica.cargarConsolidado(pConsolidado)
        End If
        formHistoriaClinica.tsConsolidado_Click(Nothing, Nothing)
    End Sub

    Public Sub generarConsolidado(ByVal generar As Boolean)
        codGenerar = generar
    End Sub
    Private Sub abrirAuditoriaMedica(principal As PrincipalDAL)
        If SesionActual.tienePermiso(pverHistoriaClinica) Then
            If principal.estaAbierto(ConstantesHC.NOMBRE_FORM_AM) = True Then
                principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_AM)
                principal.cerrarFormulario(ConstantesHC.NOMBRE_FORM_AM)
            End If
            If principal.estaAbierto(ConstantesHC.NOMBRE_FORM_AM) = False Then
                Dim formAuditoriaMedica As New Form_Historia_clinica
                precargarForm(formAuditoriaMedica, ConstantesHC.NOMBRE_TITULO_AM, ConstantesHC.NOMBRE_FORM_AM)
                formAuditoriaMedica.Show()
                pintarTS(formAuditoriaMedica, Color.LightBlue)
                pintarList(formAuditoriaMedica, Color.Blue)
                principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_AM)
            End If
        Else
            abrirConsolidado(ConstantesHC.NOMBRE_TITULO_AM, ConstantesHC.NOMBRE_FORM_AM)
        End If

    End Sub

    Private Sub abrirHistoriaClinica(principal As PrincipalDAL)
        If SesionActual.tienePermiso(pverHistoriaClinica) Then
            If principal.estaAbierto(ConstantesHC.NOMBRE_FORM_HC) = True Then
                principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_HC)
                principal.cerrarFormulario(ConstantesHC.NOMBRE_FORM_HC)
            End If
            If principal.estaAbierto(ConstantesHC.NOMBRE_FORM_HC) = False Then
                Dim formHistoriaClinica As New Form_Historia_clinica()
                precargarForm(formHistoriaClinica, ConstantesHC.NOMBRE_TITULO_HC, ConstantesHC.NOMBRE_FORM_HC)
                formHistoriaClinica.Show()
                principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_HC)
            End If
        Else
            abrirConsolidado(ConstantesHC.NOMBRE_TITULO_HC, ConstantesHC.NOMBRE_FORM_HC)
        End If
    End Sub

    Private Sub abrirTriage(principal As PrincipalDAL)
        If principal.estaAbierto(Form_Triage.Name) = True Then
            principal.traerAlFrente(Form_Triage.Name)
            principal.cerrarFormulario(Form_Triage.Name)
        End If
        If principal.estaAbierto(Form_Triage.Name) = False Then
            Dim pformTriage As New Form_Triage
            precargarForm(pformTriage, ConstantesHC.NOMBRE_TITULO_TRIAGE, pformTriage.Name)
            pformTriage.ShowDialog()
            listarPaciente()
            principal.traerAlFrente(ConstantesHC.NOMBRE_FORM_HC)
        End If
    End Sub

    Private Sub precargarForm(ByRef pForm As Object, vNombreTitulo As String, vNombreForm As String)
        General.limpiarControles(pForm)

        Dim params As New List(Of String)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Área").ToString)
        params.Add(vNombreForm)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Registro").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Identificación").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Paciente").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Admisión").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Estancia").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Contrato").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("EPS").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Sexo").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Edad").ToString)
        Dim moduloFinal As String
        Select Case modulo
            Case Constantes.CODIGO_MENU_HEMO, Constantes.CODIGO_MENU_URG, Constantes.CODIGO_MENU_HOSP, Constantes.CODIGO_MENU_QUIR
                moduloFinal = Constantes.CODIGO_MENU_HISTC
            Case Else
                moduloFinal = modulo
        End Select
        params.Add(moduloFinal)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Descripción área").ToString & vNombreTitulo)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Descripción área").ToString)
        pForm.cargarPermisos(modulo)
        pForm.datosPrincipales(params, Me)


    End Sub

    Private Sub quitarPrefacturados()
        selPrefacturado.Visible = False
        selFacturados.Location = New Point(selFacturados.Location.X - 105, selFacturados.Location.Y)
        selTodos.Location = New Point(selTodos.Location.X - 105, selTodos.Location.Y)
        gbEstadoAtencion.Size = New Size(gbEstadoAtencion.Width - 100, gbEstadoAtencion.Height)
        gbEstadoAtencion.Location = New Point(gbEstadoAtencion.Location.X + 60, gbEstadoAtencion.Location.Y)
    End Sub

    Private Sub quitarRevision()
        selRevision.Visible = False
        selCerrados.Location = New Point(selCerrados.Location.X - 55, selCerrados.Location.Y)
        selFacturados.Location = New Point(selFacturados.Location.X - 25, selFacturados.Location.Y)

    End Sub
    Private Sub mostrarSoloTriage()
        selPrefacturado.Visible = False
        selRevision.Visible = False
        selCerrados.Visible = False
        selFacturados.Visible = False
        selFacturados.Location = New Point(selFacturados.Location.X - 105, selFacturados.Location.Y)
        selTodos.Text = "Realizados"
        selAtendidos.Text = "Pendientes"
        selTodos.Location = New Point(selTodos.Location.X - 305, selTodos.Location.Y)
        selCerrados.Location = New Point(selCerrados.Location.X + 15, selCerrados.Location.Y)
        gbEstadoAtencion.Size = New Size(gbEstadoAtencion.Width - 100, gbEstadoAtencion.Height)
        gbEstadoAtencion.Location = New Point(gbEstadoAtencion.Location.X + 60, gbEstadoAtencion.Location.Y)
        Label3.Location = New Point(Label3.Location.X + 35, Label3.Location.Y)
        Label3.Text = Replace(ConstantesHC.NOMBRE_TITULO_TRIAGE, ":", "") & ":"
    End Sub


    Private Sub comboAreaServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedValueChanged
        If IsNumeric(comboAreaServicio.SelectedValue) Then
            If selRevision.Checked Then
                dtVerificar.Clear()
            End If
            listarPaciente()
        End If
    End Sub

    Private Sub selCerrados_CheckedChanged(sender As Object, e As EventArgs) Handles selRevision.CheckedChanged, selCerrados.CheckedChanged, selPrefacturado.CheckedChanged, selFacturados.CheckedChanged, selTodos.CheckedChanged
        '-- esto se hizo con el fin de evitar que cargara el listar paciente dos veces 
        'por si alguna inquietud preguntar a lycans
        cargarEstadosUnaVez()
    End Sub

    Private Sub cargarEstadosUnaVez()
        If entrarUnaVez = False And selCerrados.Checked Then
            entrarUnaVez = True
            revisionUnaVez = False
            listarPaciente()
        ElseIf revisionUnaVez = False And selRevision.Checked Then
            revisionUnaVez = True
            entrarUnaVez = False
            listarPaciente()
        ElseIf selAtendidos.Checked Then
            revisionUnaVez = False
            entrarUnaVez = False
            listarPaciente()
        ElseIf selFacturados.Checked Then
            revisionUnaVez = False
            entrarUnaVez = False
            listarPaciente()
        ElseIf selPrefacturado.Checked Then
            revisionUnaVez = False
            entrarUnaVez = False
            listarPaciente()
        ElseIf selTodos.Checked Then
            revisionUnaVez = False
            entrarUnaVez = False
            listarPaciente()
        End If
    End Sub

    Public Sub listarPaciente()

        Dim area As String
        area = comboAreaServicio.SelectedValue.ToString
        If comboAreaServicio.SelectedIndex = 0 Then
            area = "-2"
        End If
        If area = "-2" AndAlso dgvmanual.ColumnCount > 0 Then
            dt.Clear()
            Exit Sub
        End If
        Try
            btOpcionEnviarRevisados.Visible = False
            Dim estadoAtencion As Integer
            Dim consulta As String = ""
            If selAtendidos.Checked = True Then
                estadoAtencion = Constantes.ESTADO_ATENCION_INICIADO
            ElseIf selRevision.Checked = True Then
                estadoAtencion = Constantes.ESTADO_ATENCION_REVISION
            ElseIf selCerrados.Checked = True Then
                estadoAtencion = Constantes.ESTADO_ATENCION_CERRADO
            ElseIf selPrefacturado.Checked = True Then
                estadoAtencion = Constantes.ESTADO_ATENCION_PREFACTURADO
            ElseIf selFacturados.Checked = True Then
                estadoAtencion = Constantes.ESTADO_ATENCION_FACTURADO
            ElseIf selTodos.Checked = True Then
                estadoAtencion = Constantes.ESTADO_ATENCION_TODOS
            End If
            Select Case modulo
                Case Constantes.HC, Constantes.CODIGO_MENU_HEMO, Constantes.CODIGO_MENU_HOSP, Constantes.CODIGO_MENU_QUIR
                    consulta = Consultas.LISTA_PACIENTE
                Case Constantes.CODIGO_MENU_URG
                    Select Case Tag.codigo
                        Case Constantes.CODIGO_MENU_TRIAGE
                            consulta = Consultas.LISTA_TRIAGE_PACIENTE
                        Case Else
                            consulta = Consultas.LISTA_PACIENTE
                    End Select
                Case Constantes.AM
                    consulta = Consultas.LISTA_PACIENTER
                Case Constantes.AF
                    consulta = Consultas.LISTA_PACIENTERR
            End Select

            Dim params As New List(Of String)
            params.Add(busquedaPaciente.Text)
            params.Add(area)
            params.Add(estadoAtencion)
            params.Add(moduloAreaServicio)
            params.Add(SesionActual.codigoEP)
            params.Add(SesionActual.codigoPerfil)
            params.Add(modulo)
            params.Add(SesionActual.idUsuario)
            General.llenarTabla(consulta, params, dt)

            dgvmanual.DataSource = dt

            If selRevision.Checked <> True Then
                btOpcionAprobar.Visible = False
                dtVerificar.Clear()
            End If

            diseñoGrilla()
            consultarCantidadPaciente(estadoAtencion, area)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub diseñoGrilla()
        dgvmanual.ReadOnly = True
        For i = 0 To dgvmanual.Columns.Count - 1
            dgvmanual.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvmanual.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            dgvmanual.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        dgvmanual.Columns("Registro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Registro").Frozen = True
        dgvmanual.Columns("Registro").Width = "90"
        dgvmanual.Columns("Paciente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvmanual.Columns("Paciente").Frozen = True
        dgvmanual.Columns("Paciente").Width = "310"
        dgvmanual.Columns("Admisión").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Admisión").Width = "150"
        dgvmanual.Columns("Estancia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Estancia").Width = "82"
        dgvmanual.Columns("EPS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvmanual.Columns("EPS").Width = "240"
        dgvmanual.Columns("Área").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Área").Width = "40"
        dgvmanual.Columns("Área").Visible = False
        dgvmanual.Columns("Descripción área").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvmanual.Columns("Descripción área").Width = "150"
        dgvmanual.Columns("Contrato").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Contrato").Width = "50"
        dgvmanual.Columns("Contrato").Visible = False
        dgvmanual.Columns("Edad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Edad").Width = "90"
        dgvmanual.Columns("Cama").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Cama").Width = "150"
        dgvmanual.Columns("Notas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Notas").Width = "40"
        dgvmanual.Columns("Revisadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Revisadas").Width = "60"
        dgvmanual.Columns("Responsable").Width = "120"
        If Tag.codigo = Constantes.CODIGO_MENU_TRIAGE Then
            dgvmanual.Columns("Cama").HeaderText = Replace(ConstantesHC.NOMBRE_TITULO_TRIAGE, ":", "")
            dgvmanual.Columns("Estancia").Visible = False
        End If
        dgvmanual.Columns("Sexo").Width = "40"
        dgvmanual.Columns("Sexo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.Columns("Color").Visible = False
        dgvmanual.Columns("Identificación").Visible = False
        dgvmanual.Columns("Descripción área").Visible = False
        dgvmanual.Columns("Codigo_Solicitud").Visible = False
        dgvmanual.Columns("Resultado").Visible = False
        If selRevision.Checked Then
            cargarEstadoChequeo()
        Else
            dtVerificar.Clear()

            If Not IsNothing(dgvmanual.Columns("Check_List")) Then
                dgvmanual.Columns.Remove("Check_List")
                dgvmanual.Columns.Remove("Aprobado")
            End If
            dgvmanual.Columns("Cama").Visible = True
        End If
        cambiarEstancia()

        If SesionActual.tienePermiso(pVerCantidadNota) Then
            dgvmanual.Columns("Notas").Visible = True
        Else
            dgvmanual.Columns("Notas").Visible = False
        End If

        If SesionActual.tienePermiso(pVerNotasRevisadas) Then
            dgvmanual.Columns("Revisadas").Visible = True
        Else
            dgvmanual.Columns("Revisadas").Visible = False
        End If

        If SesionActual.tienePermiso(pVerResponsablePaciente) Then
            dgvmanual.Columns("Responsable").Visible = True
        Else
            dgvmanual.Columns("Responsable").Visible = False
        End If

        dgvmanual.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvmanual.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
    End Sub

    Private Sub cambiarEstancia()
        If selRevision.Checked Or modulo = Constantes.CODIGO_MENU_URG Then
            dgvmanual.Columns("Estancia").HeaderText = "Tiempo Transcurrido"
            dgvmanual.Columns("Estancia").Width = 120
            dgvmanual.Columns("Admisión").Visible = False
            dgvmanual.Columns("Estancia").DisplayIndex = 12
        Else
            dgvmanual.Columns("Estancia").HeaderText = "Estancia"
            dgvmanual.Columns("Estancia").Width = "82"
            dgvmanual.Columns("Admisión").Visible = True
            dgvmanual.Columns("Estancia").DisplayIndex = 6
        End If
    End Sub

    Private Sub cargarEstadoChequeo()
        If IsNothing(dgvmanual.Columns("Check_List")) Then
            ' Creamos la nueva columna
            '
            Dim column As New DataGridViewImageColumn
            With column
                .Name = "Check_List"
                .HeaderText = "Checklist"
                .Width = 70
                .Image = My.Resources.check_todos_23
            End With
            Dim column2 As New DataGridViewImageColumn
            Dim image As Image = My.Resources.Document_Add_icon__1_
            Dim tamano As New Bitmap(image, New Size(20, 20))
            With column2
                .Name = "Aprobado"
                .HeaderText = "Aprobar Cierre"
                .Width = 84
                .Image = tamano
            End With

            ' Añadimos la columna la cual aparecerá en la primera posición
            '

            dgvmanual.Columns.Insert(dgvmanual.Columns.Count - 1, column)
            dgvmanual.Columns.Insert(dgvmanual.Columns.Count - 1, column2)



            'btCerrarAll.Location = New Point(1012, 21)

        End If
        dgvmanual.Columns("Cama").Visible = False

        If Not SesionActual.tienePermiso(pCerrarRevision) Then
            dgvmanual.Columns("Aprobado").Visible = False
        Else
            'este dtVerificar hace una copia del datatable que contiene todo lo faltante de los pacientes y 
            'lo coloco aqui para que al momento de pasar un paciente a cerrado el vuelve hacer el cargar pacientes pero como
            'el dtverificar tiene registro no volvera a dibujar nuevamente el dgv ni el dibujarEstadoChequeo
            If dtVerificar.Rows.Count = 0 Then
                dibujarEstadoChequeo(modulo)
                btOpcionAprobar.Visible = True
            End If
        End If
    End Sub

    Private Sub dibujarEstadoDespuesCerrar()
        'este metodo lo hice con el fin de que al momento de pasar un paciente a cerrado y al momento de quitar ese indice del dt perdia los colores 
        'del dgv y el semaforo de la lista de chequeo, pero el dt verificar hace una copia del datatable que carga todo lo faltante de los pacientes
        'el aqui dibuja la columna check list sin necesidad de que vaya a  la base de datos a cargar nuevamente lo faltante de los pacientes.

        Dim faltantes As Integer
        Dim restante As Integer
        For i = 0 To dgvmanual.RowCount - 1
            faltantes = dtVerificar.Select("Registro=" & dgvmanual.Rows(i).Cells("registro").Value.ToString & " and Indice=0", "").Count
            restante = dtVerificar.Select("Registro=" & dgvmanual.Rows(i).Cells("registro").Value.ToString &
                                              "and Indice=0 and len([codigoTitulo]) = 4 and codigoTitulo not in(1001,1002,1003,1004) ", "").Count
            faltantes = faltantes - restante
            If faltantes = 0 Then
                'dgvmanual.Rows(i).Cells("check_list").Value = My.Resources.check_todos_23
                dgvmanual.Rows(i).Cells("check_list").Style.BackColor = Color.LightGreen
            ElseIf faltantes <= 4 Then
                dgvmanual.Rows(i).Cells("check_list").Style.BackColor = Color.Yellow
            Else
                'dgvmanual.Rows(i).Cells("check_list").Value = My.Resources.check_nada_23
                dgvmanual.Rows(i).Cells("check_list").Style.BackColor = Color.Red
            End If
        Next
    End Sub
    Private Sub dibujarEstadoChequeo(ByVal pmodulo As String)
        Dim dtEstadoChequeo As New DataTable
        Dim dtRestante As New DataTable
        dtEstadoChequeo = listaChequeo(pmodulo, Constantes.VALOR_PREDETERMINADO).Tables(1).Copy
        If selRevision.Checked Then
            dtVerificar = dtEstadoChequeo.Copy
        End If

        Dim faltantes As Integer
        Dim restante As Integer
        For i = 0 To dgvmanual.RowCount - 1
            faltantes = dtEstadoChequeo.Select("Registro=" & dgvmanual.Rows(i).Cells("registro").Value.ToString & " and Indice=0", "").Count
            restante = dtEstadoChequeo.Select("Registro=" & dgvmanual.Rows(i).Cells("registro").Value.ToString &
                                              "and Indice=0 and len([codigoTitulo]) = 4 and codigoTitulo not in(1001,1002,1003,1004) ", "").Count
            faltantes = faltantes - restante
            If faltantes = 0 Then
                'dgvmanual.Rows(i).Cells("check_list").Value = My.Resources.check_todos_23
                dgvmanual.Rows(i).Cells("check_list").Style.BackColor = Color.LightGreen
            ElseIf faltantes <= 4 Then
                dgvmanual.Rows(i).Cells("check_list").Style.BackColor = Color.Yellow
            Else
                'dgvmanual.Rows(i).Cells("check_list").Value = My.Resources.check_nada_23
                dgvmanual.Rows(i).Cells("check_list").Style.BackColor = Color.Red
            End If

        Next
    End Sub

    Private Sub cambiarEstadoCerrado(ByVal index As Integer, ByVal pModulo As String)

        Dim dtEstadoChequeo As New DataTable
        dtEstadoChequeo = listaChequeo(pModulo, index).Tables(1).Copy
        Dim faltantes As Integer
        Dim dtCambios As New DataTable
        dtCambios.Columns.Add("N_Registro")

        ''validar que si se selecciona uno solo, este esté en verde. Este es cuando dgvmanual.CurrentCell.RowIndex es mayor o igual a la 0
        If index <> Constantes.VALOR_PREDETERMINADO Then
            faltantes = dtEstadoChequeo.Select("Registro=" & dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("registro").Value.ToString & " and Indice=0", "").Count
            ''agregar al datatable si faltantes igual a 0
            If faltantes = 0 Then
                dtCambios.Rows.Add(dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("registro").Value)
                If modulo = pModulo Then
                    dgvmanual.DataSource.Rows(dgvmanual.CurrentCell.RowIndex).delete
                    MsgBox("El paciente cambio de estado a cerrado", MsgBoxStyle.Information)
                    dgvmanual.DataSource.acceptChanges
                End If
            End If
        End If

        ''Este ciclo solo se debe ejecutar si es el cerrar todos (docle clic en el HeaderText)
        If index = Constantes.VALOR_PREDETERMINADO Then

            Dim query = (From row In dtEstadoChequeo.AsEnumerable() Select row.Field(Of Int32)("registro")).Distinct()
            For i = 0 To query.Count - 1
                faltantes = dtEstadoChequeo.Select("Registro=" & query(i) & " and Indice=0", "").Count
                If faltantes = 0 Then
                    dtCambios.Rows.Add(query(i))
                    If modulo = pModulo Then
                        For j = 0 To dgvmanual.Rows.Count - 1
                            If Not String.IsNullOrEmpty(dgvmanual.Rows(j).Cells("Resultado").Value.ToString) Then
                                dgvmanual.Rows(j).Cells("Resultado").Value = -1
                            End If
                            If dgvmanual.Rows(j).Cells("Registro").Value = query(i) And Not String.IsNullOrEmpty(dgvmanual.Rows(j).Cells("Resultado").Value.ToString) = 0 Then
                                dgvmanual.DataSource.Rows(j).delete
                                MsgBox("Los paciente cambiaron de estado a cerrado", MsgBoxStyle.Information)
                                Exit For
                            End If
                        Next

                    End If
                End If
            Next
            dgvmanual.DataSource.acceptChanges
        End If
        Dim consulta As String
        Select Case pModulo

            Case Constantes.AM
                consulta = Consultas.ESTADO_PACIENTE_LISTA_CHEQUEO_R
            Case Constantes.AF
                consulta = Consultas.ESTADO_PACIENTE_LISTA_CHEQUEO_RR
            Case Else
                consulta = Consultas.ESTADO_PACIENTE_LISTA_CHEQUEO
        End Select
        'cambia el estado a cerrado '
        If dtCambios.Rows.Count > 0 Then
            cambiarEstado(dtCambios, consulta)
            'carga los pacientes para volver a colorear el dgv y dibujar la columna checkList 
            'tomando en cuenta el dtverificar .------cualquier inquietud preguntar a lycans
            'dt.Rows.RemoveAt(dgvmanual.CurrentCell.RowIndex)
            'dt.AcceptChanges()
            listarPaciente()
            dibujarEstadoDespuesCerrar()

        End If
    End Sub

    Private Sub cambiarEstado(ByVal dtRegistros As DataTable, ByVal consulta As String)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = consulta
                comando.Parameters.Add(New SqlParameter("@registro", SqlDbType.Structured)).Value = dtRegistros
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btOpcionAprobar_Click(sender As Object, e As EventArgs) Handles btOpcionAprobar.Click
        If MsgBox(Mensajes.APROBAR_REVISION, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If dgvmanual.Rows.Count > 0 Then
                cambiarEstadoCerrado(Constantes.VALOR_PREDETERMINADO, Constantes.CODIGO_MENU_HISTC)
                cambiarEstadoCerrado(Constantes.VALOR_PREDETERMINADO, Constantes.CODIGO_MENU_AUDM)
                cambiarEstadoCerrado(Constantes.VALOR_PREDETERMINADO, Constantes.CODIGO_MENU_AUDF)
                listarPaciente()
            Else
                MsgBox("No hay pacientes con soportes pendientes", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btVerificar_Click(sender As Object, e As EventArgs)
        listarPaciente()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlAuditoria.Visible = False
    End Sub

    Private Sub Form_Listado_Paciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        With dgvNotaAuditoria.Columns
            .Item("dgCargo").DataPropertyName = "Cargo"
            .Item("dgCantidad").DataPropertyName = "Cantidad"
        End With
    End Sub

    Private Sub consultarCantidadPaciente(estadoAtencion As Integer, area As String)
        Dim consulta As String = ""
        Select Case modulo
            Case Constantes.HC, Constantes.CODIGO_MENU_HEMO, Constantes.CODIGO_MENU_HOSP, Constantes.CODIGO_MENU_QUIR
                consulta = Consultas.CANTIDAD_PACIENTE
            Case Constantes.CODIGO_MENU_URG
                Select Case Tag.codigo
                    Case Constantes.CODIGO_MENU_TRIAGE
                        consulta = Consultas.CANTIDAD_TRIAGE_PACIENTE
                    Case Else
                        consulta = Consultas.CANTIDAD_PACIENTE
                End Select
            Case Constantes.AM
                consulta = Consultas.CANTIDAD_PACIENTER
            Case Constantes.AF
                consulta = Consultas.CANTIDAD_PACIENTERR
        End Select
        Dim params As New List(Of String)
        params.Add(area)
        params.Add(estadoAtencion)
        params.Add(moduloAreaServicio)
        params.Add(SesionActual.codigoEP)
        params.Add(SesionActual.codigoPerfil)
        params.Add(modulo)
        params.Add(SesionActual.idUsuario)
        npaciente.Text = General.getValorConsulta(consulta, params)

        For j As Int32 = 0 To dgvmanual.Rows.Count - 1
            dgvmanual.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(dgvmanual.Rows(j).Cells("Color").Value)
            If Not String.IsNullOrEmpty(dgvmanual.Rows(j).Cells("Notas").Value.ToString) Then
                If dgvmanual.Rows(j).Cells("Notas").Value <= 4 Then
                    dgvmanual.Rows(j).Cells("Notas").Style.BackColor = Color.Yellow
                Else
                    dgvmanual.Rows(j).Cells("Notas").Style.BackColor = Color.Red
                End If
            End If
            If Not String.IsNullOrEmpty(dgvmanual.Rows(j).Cells("Resultado").Value.ToString) Then
                If dgvmanual.Rows(j).Cells("Resultado").Value = 0 Then
                    dgvmanual.Rows(j).Cells("Revisadas").Style.BackColor = Color.LimeGreen
                Else
                    dgvmanual.Rows(j).Cells("Revisadas").Style.BackColor = Color.Red
                End If
            End If

        Next
    End Sub

    Private Sub busquedaPaciente_KeyDown(sender As Object, e As KeyEventArgs) Handles busquedaPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then
            busquedaPaciente.Text = Funciones.validarComillaSimple(busquedaPaciente.Text)
            listarPaciente()
        End If
    End Sub

    Private Sub Form_Listado_Paciente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If modulo = Nothing Then
            modulo = Tag.modulo
        End If

        Select Case modulo
            Case Constantes.CODIGO_MENU_HISTC
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_HC & " - " & Constantes.NOMBRE_MENU_HISTC
                quitarPrefacturados()
                quitarRevision()
            Case Constantes.CODIGO_MENU_HEMO
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_HC & " - " & Constantes.NOMBRE_MENU_HEMO
                quitarPrefacturados()
                quitarRevision()
            Case Constantes.CODIGO_MENU_HOSP
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_HC & " - " & Constantes.NOMBRE_MENU_HOSP
                quitarPrefacturados()
                quitarRevision()
            Case Constantes.CODIGO_MENU_QUIR
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_HC & " - " & Constantes.NOMBRE_MENU_QUIR
                quitarPrefacturados()
                quitarRevision()
            Case Constantes.CODIGO_MENU_URG
                Select Case Tag.codigo
                    Case Constantes.CODIGO_MENU_TRIAGE
                        Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_TRIAGE
                        mostrarSoloTriage()
                    Case Else
                        Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_HC
                        quitarPrefacturados()
                        quitarRevision()
                End Select

                Label1.Text = Label1.Text & " - " & Constantes.NOMBRE_MENU_URG
            Case Constantes.AM
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_AM
                quitarPrefacturados()
                BackColor = Color.LightBlue
            Case Constantes.AF
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_AF
                BackColor = Color.FromArgb(192, 255, 192)
            Case Else
                Label1.Text = Label1.Text & ConstantesHC.NOMBRE_TITULO_HC
                quitarPrefacturados()
                quitarRevision()
        End Select
        objListachequeo = GeneralHC.fabricaHC.crear(Constantes.CODIGO_LISTA_CHEQUEO & modulo)

        Try

            moduloAreaServicio = modulo

            permisoGeneral = perG.buscarPermisoGeneral("Form_Listado_Paciente", modulo)
            pTodasAreas = permisoGeneral & "pp" & "72"
            pverHistoriaClinica = permisoGeneral & "pp" & "88"
            pConsolidado = permisoGeneral & "pp" & "77"
            pCerrarRevision = permisoGeneral & "pp" & "91"
            pVerListaChequeo = permisoGeneral & "pp" & "98"
            pVerCantidadNota = permisoGeneral & "pp" & "99"
            pVerNotasRevisadas = permisoGeneral & "pp" & "101"
            pVerResponsablePaciente = permisoGeneral & "pp" & "102"
            Dim params As New List(Of String)
            params.Add(SesionActual.idUsuario)
            params.Add(SesionActual.codigoEP)
            params.Add(moduloAreaServicio)
            Select Case Tag.codigo
                Case Constantes.CODIGO_MENU_TRIAGE
                    General.cargarCombo(Consultas.TRIAGE_BUSCAR, "Descripcion", "Codigo_Triage", comboAreaServicio)
                    comboAreaServicio.DataSource.rows(1).delete()
                Case Else
                    General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", comboAreaServicio)
            End Select

            Dim dtNuevo As DataTable
            dtNuevo = comboAreaServicio.DataSource.copy
            If SesionActual.tienePermiso(pTodasAreas) Then
                dtNuevo.Rows.Add()
                dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
                dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
            End If
            comboAreaServicio.DataSource = dtNuevo


        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        listarPaciente()
    End Sub


End Class