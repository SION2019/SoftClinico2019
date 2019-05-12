Public Class Form_ConfiguracionAuditoria
    Private dtInsumos As New DataTable
    Private dtProcedimientos, dtParaclinicos As New DataTable
    Private perG As New Buscar_Permisos_generales
    Private permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pduplicar, tipo, PGrupoAuditoria As String
    Dim idEps, opcionDuplicar As Integer
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        btEps.Enabled = True
        btEps.Visible = False
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_CONFIGURACION & "'" & txtcodigo.Text & "'")

                    If respuesta = True Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        General.limpiarControles(Me)
                        General.deshabilitarBotones(ToolStrip1)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        btEps.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btduplicar_Click(sender As Object, e As EventArgs) Handles btduplicar.Click
        If SesionActual.tienePermiso(Pduplicar) Then
            If MsgBox(Mensajes.DUPLICAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.DUPLICAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarBotones(Me.ToolStrip1)
                TextnombreEps.ReadOnly = True
                TextnombreProcedimiento.ReadOnly = True
                btbuscarprocedimiento.Enabled = False
                dtInsumos.Rows.Add()
                dtProcedimientos.Rows.Add()
                dtParaclinicos.Rows.Add()
                btguardar.Enabled = True
                btcancelar.Enabled = True
                btBuscarEps.Enabled = True
                TextcodigoEps.ReadOnly = True
                TextcodigoProcedimiento.ReadOnly = True
                TextnombreEps.ReadOnly = True
                TextnombreProcedimiento.ReadOnly = True
                opcionDuplicar = 1
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validardgvs() Then
            guardarConfiguracion()
            opcionDuplicar = 0
        End If
    End Sub
    Public Function crearConfiguracionAuditoria() As ConfiguracionAuditoria
        Dim objConfiguracionAuditoria As New ConfiguracionAuditoria

        objConfiguracionAuditoria.idConfig = txtcodigo.Text
        objConfiguracionAuditoria.codigoProcedimiento = Textcodigo.Text
        objConfiguracionAuditoria.idTerceroEps = Textideps.Text
        objConfiguracionAuditoria.codigoAreaServicio = Comboservicio.SelectedValue
        objConfiguracionAuditoria.historia = Check_hc.Checked
        objConfiguracionAuditoria.auditoriaM = Check_auditM.Checked
        objConfiguracionAuditoria.auditoriaF = Check_auditF.Checked
        objConfiguracionAuditoria.paquete = Check_paquete.Checked
        objConfiguracionAuditoria.unaVez = Check_unavez.Checked
        objConfiguracionAuditoria.tipo = tipo
        objConfiguracionAuditoria.usuario = SesionActual.idUsuario

        For Each drFilaInsumos As DataRow In dtInsumos.Rows
            If drFilaInsumos.Item("Codigo").ToString <> "" Then
                Dim drInsumos As DataRow = objConfiguracionAuditoria.dtInsumo.NewRow
                drInsumos.Item("Codigo") = drFilaInsumos.Item("Codigo")
                drInsumos.Item("Cantidad") = drFilaInsumos.Item("Cantidad")
                objConfiguracionAuditoria.dtInsumo.Rows.Add(drInsumos)
            End If
        Next
        For Each drFilaProcedimiento As DataRow In dtProcedimientos.Rows
            If drFilaProcedimiento.Item("Codigo").ToString <> "" Then
                Dim drProcedimientos As DataRow = objConfiguracionAuditoria.dtProcedimiento.NewRow
                drProcedimientos.Item("Codigo") = drFilaProcedimiento.Item("Codigo")
                drProcedimientos.Item("Cantidad") = drFilaProcedimiento.Item("Cantidad")
                objConfiguracionAuditoria.dtProcedimiento.Rows.Add(drProcedimientos)
            End If
        Next
        For Each drFilaParaclinico As DataRow In dtParaclinicos.Rows
            If drFilaParaclinico.Item("Codigo").ToString <> "" Then
                Dim drParaclinicos As DataRow = objConfiguracionAuditoria.dtParaclinico.NewRow
                drParaclinicos.Item("Codigo") = drFilaParaclinico.Item("Codigo")
                drParaclinicos.Item("Cantidad") = drFilaParaclinico.Item("Cantidad")
                objConfiguracionAuditoria.dtParaclinico.Rows.Add(drParaclinicos)
            End If
        Next

        Return objConfiguracionAuditoria
    End Function
    Private Sub guardarConfiguracion()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objConfigAuditoria As New ConfiguracionAuditoriaBLL
            Try
                txtcodigo.Text = objConfigAuditoria.guardarConfAuditoria(crearConfiguracionAuditoria())
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                cargarInsumos()
                cargarProcedimientos()
                cargarParaclinicos()
                btEps.Enabled = True
                btduplicar.Enabled = True
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarControles(Me)
                General.deshabilitarBotones(Me.ToolStrip1)
                dgvinsumos.ReadOnly = False
                dgvprocedimientos.ReadOnly = False
                dtInsumos.Rows.Add()
                dtProcedimientos.Rows.Add()
                dtParaclinicos.Rows.Add()
                Check_hc.Enabled = True
                Check_auditM.Enabled = True
                Check_auditF.Enabled = True
                Check_paquete.Enabled = True
                Check_unavez.Enabled = True
                btguardar.Enabled = True
                btcancelar.Enabled = True
                dgvinsumos.ReadOnly = False
                dgvParaclinicos.ReadOnly = False
                dgvprocedimientos.ReadOnly = False
                deshabilitarColumnas()
                TextcodigoEps.ReadOnly = True
                TextcodigoProcedimiento.ReadOnly = True
                TextnombreEps.ReadOnly = True
                TextnombreProcedimiento.ReadOnly = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub enlazarTabla()

        Dim col1, col2, col3, col4, col5, col6, estado, estadop, col7, col8, col9, estadoPar As New DataColumn

        col1.ColumnName = "Codigo"
        col1.DataType = Type.GetType("System.String")
        col1.DefaultValue = String.Empty
        dtInsumos.Columns.Add(col1)

        col2.ColumnName = "Descripcion"
        col2.DataType = Type.GetType("System.String")
        col2.DefaultValue = String.Empty
        dtInsumos.Columns.Add(col2)

        col3.ColumnName = "Cantidad"
        col3.DataType = Type.GetType("System.Int32")
        col3.DefaultValue = 1
        dtInsumos.Columns.Add(col3)

        With dgvinsumos
            .Columns.Item("dgCodigoinsumos").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigoinsumos").DataPropertyName = "Codigo"
            .Columns("dgCodigoinsumos").Visible = True

            .Columns.Item("dgdescripcioninsumos").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgdescripcioninsumos").DataPropertyName = "Descripcion"
            .Columns.Item("dgdescripcioninsumos").ReadOnly = True

            .Columns.Item("dgCant").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCant").DataPropertyName = "Cantidad"
            .Columns.Item("dgCant").ReadOnly = False

        End With
        dgvinsumos.AutoGenerateColumns = False
        dgvinsumos.DataSource = dtInsumos
        dgvinsumos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvinsumos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '------------------------------------------------------------------------------
        col4.ColumnName = "Codigo"
        col4.DataType = Type.GetType("System.String")
        col4.DefaultValue = String.Empty
        dtProcedimientos.Columns.Add(col4)

        col5.ColumnName = "Descripcion"
        col5.DataType = Type.GetType("System.String")
        col5.DefaultValue = String.Empty
        dtProcedimientos.Columns.Add(col5)

        col6.ColumnName = "Cantidad"
        col6.DataType = Type.GetType("System.Int32")
        col6.DefaultValue = 1
        dtProcedimientos.Columns.Add(col6)

        With dgvprocedimientos
            .Columns.Item("dgCodigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigo").DataPropertyName = "Codigo"
            .Columns.Item("dgCodigo").ReadOnly = True
            .Columns("dgCodigo").Visible = True

            .Columns.Item("dgDescripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcion").DataPropertyName = "Descripcion"
            .Columns.Item("dgDescripcion").ReadOnly = True

            .Columns.Item("dgCantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCantidad").DataPropertyName = "Cantidad"
            .Columns.Item("dgCantidad").ReadOnly = False

        End With

        dgvprocedimientos.AutoGenerateColumns = False
        dgvprocedimientos.DataSource = dtProcedimientos
        dgvprocedimientos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimientos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '---------------------------------------------------------------------------------------------
        col7.ColumnName = "Codigo"
        col7.DataType = Type.GetType("System.String")
        col7.DefaultValue = String.Empty
        dtParaclinicos.Columns.Add(col7)

        col8.ColumnName = "Descripcion"
        col8.DataType = Type.GetType("System.String")
        col8.DefaultValue = String.Empty
        dtParaclinicos.Columns.Add(col8)

        col9.ColumnName = "Cantidad"
        col9.DataType = Type.GetType("System.Int32")
        col9.DefaultValue = 1
        dtParaclinicos.Columns.Add(col9)

        With dgvParaclinicos
            .Columns.Item("dgCodigoPar").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigoPar").DataPropertyName = "Codigo"
            .Columns.Item("dgCodigoPar").ReadOnly = True
            .Columns("dgCodigoPar").Visible = True

            .Columns.Item("dgDescripcionPar").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionPar").DataPropertyName = "Descripcion"
            .Columns.Item("dgDescripcionPar").ReadOnly = True

            .Columns.Item("dgCantidadPar").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCantidadPar").DataPropertyName = "Cantidad"
            .Columns.Item("dgCantidadPar").ReadOnly = False
        End With
        dgvParaclinicos.AutoGenerateColumns = False
        dgvParaclinicos.DataSource = dtParaclinicos
        dgvParaclinicos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvParaclinicos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Function validardgvs()
        If Textideps.Text = "" Then
            MsgBox("Debe escoger una EPS", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            btEps.Focus()
        ElseIf Textcodigo.Text = "" Then
            MsgBox("Debe escoger un procedimiento", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            btbuscarprocedimiento.Focus()
        ElseIf Comboservicio.SelectedIndex < 1 Then
            MsgBox("Debe escoger un area de servicio", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            Comboservicio.Focus()
        ElseIf (dgvinsumos.RowCount = 1) And (dgvprocedimientos.RowCount = 1) And (dgvParaclinicos.RowCount = 1) Then
            MsgBox("No se puede guardar registros sin agregar items en alguna de las listas", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            dgvprocedimientos.Focus()
        ElseIf Check_hc.Checked = False And Check_auditM.Checked = False And Check_auditF.Checked = False Then
            MsgBox("Debe elejir al menos una opcion, (Historia Clinica, Auditoria M o Auditoria F) ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
        Else
            For i = 0 To dgvinsumos.Rows.Count - 1
                If dgvinsumos.Rows(i).Cells("dgCodigoinsumos").Value.ToString <> String.Empty Then
                    If dgvinsumos.Rows(i).Cells("dgCant").Value = 0 Then
                        dgvinsumos.Rows(i).Cells("dgCant").Value = 1
                    End If
                End If
            Next
            For j = 0 To dgvprocedimientos.Rows.Count - 1
                If dgvprocedimientos.Rows(j).Cells("dgCodigo").Value.ToString <> String.Empty Then
                    If dgvprocedimientos.Rows(j).Cells("dgCantidad").Value = 0 Then
                        dgvprocedimientos.Rows(j).Cells("dgCantidad").Value = 1

                    End If
                End If
            Next
            Return True
        End If
        Return False
    End Function
    Private Sub Form_Configuracion_de_Procedimientos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub Form_Configuracion_de_Procedimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pduplicar = permiso_general & "pp" & "05"
        PGrupoAuditoria = permiso_general & "pp" & "06"
        enlazarTabla()
        General.cargarCombo(Consultas.BUSQUEDA_AREA_SERVICIO & -1 & "", "Descripción", "Codigo_area_servicio", Comboservicio)
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btbuscar.Enabled = True
        btnuevo.Enabled = True
        btOpcionGrupo.Enabled = True
    End Sub
    Private Sub cargarInsumos()
        General.llenarTablaYdgv(Consultas.CONFIGURACION_AUDITORIA_INSUMOS_CARGAR & "'" & txtcodigo.Text & "'", dtInsumos)
    End Sub
    Private Sub cargarProcedimientos()
        General.llenarTablaYdgv(Consultas.CONFIGURACION_AUDITORIA_PROCEDIMIENTOS_CARGAR & "'" & txtcodigo.Text & "'", dtProcedimientos)
    End Sub
    Private Sub cargarParaclinicos()
        General.llenarTablaYdgv(Consultas.CONFIGURACION_AUDITORIA_PARACLINICOS_CARGAR & "'" & txtcodigo.Text & "'", dtParaclinicos)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            If TextnombreEps.Text = String.Empty Then
                btBuscarEps_Click(sender, e)
            End If
            If TextcodigoEps.Text = String.Empty Then
                    MsgBox("Debe escoger una EPS", MsgBoxStyle.Information)
                Else
                    Dim params As New List(Of String)
                    params.Add("")
                    params.Add(Textideps.Text)
                    General.buscarElemento(Consultas.BUSQUEDA_CONFIGURACION_AUDITORIA_BUSCAR,
                                   params,
                                   AddressOf cargarConfProcedimientos,
                                   TitulosForm.BUSQUEDA_CONFIGURACION_AUDITORIA,
                                   False, Constantes.TAMANO_MEDIANO, True)
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub
    Public Sub cargarConfProcedimientos(codigo)
        Dim dtConfig As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CONFIGURACION_AUDITORIA_CARGAR, params, dtConfig)
        txtcodigo.Text = codigo
        Textcodigo.Text = dtConfig.Rows(0).Item("Codigo_Config").ToString
        Comboservicio.SelectedValue = dtConfig.Rows(0).Item("Codigo_Area_Servicio").ToString
        TextcodigoProcedimiento.Text = dtConfig.Rows(0).Item("codigo").ToString
        TextnombreProcedimiento.Text = dtConfig.Rows(0).Item("Descripcion").ToString
        Check_hc.Checked = dtConfig.Rows(0).Item("Historia")
        Check_auditM.Checked = dtConfig.Rows(0).Item("Auditoria_M")
        Check_auditF.Checked = dtConfig.Rows(0).Item("Auditoria_F")
        Check_paquete.Checked = dtConfig.Rows(0).Item("Paquete")
        Check_unavez.Checked = dtConfig.Rows(0).Item("Una_Vez")
        tipo = dtConfig.Rows(0).Item("Tipo_codigo").ToString
        cargarInsumos()
        cargarProcedimientos()
        cargarParaclinicos()
        General.deshabilitarControles(Me)
        General.habilitarBotones(Me.ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False
        btEps.Enabled = True
    End Sub

    Private Sub dgvinsumos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvinsumos.CellDoubleClick
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvinsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Cells("dgCodigoinsumos").Selected = True Or dgvinsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Cells("dgdescripcioninsumos").Selected = True) Then
                General.agregarItems(Consultas.INSUMOS_BUSCAR, TitulosForm.BUSQUEDA_INSUMOS, dgvinsumos, dtInsumos)
            ElseIf dgvinsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Cells("anular").Selected = True And dtInsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Item(0).ToString <> "" Then
                dtInsumos.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        deshabilitarColumnas()
    End Sub
    Private Sub deshabilitarColumnas()
        With dgvinsumos
            .Columns.Item("dgCodigoinsumos").ReadOnly = True
            .Columns.Item("dgdescripcioninsumos").ReadOnly = True
        End With
        With dgvprocedimientos
            .Columns.Item("dgCodigo").ReadOnly = True
            .Columns.Item("dgDescripcion").ReadOnly = True
        End With
        With dgvParaclinicos
            .Columns.Item("dgCodigoPar").ReadOnly = True
            .Columns.Item("dgDescripcionPar").ReadOnly = True
        End With
    End Sub
    Private Sub dgvprocedimientos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimientos.CellDoubleClick
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvprocedimientos.Rows(dgvprocedimientos.CurrentCell.RowIndex).Cells("dgCodigo").Selected = True Or dgvprocedimientos.Rows(dgvprocedimientos.CurrentCell.RowIndex).Cells("dgDescripcion").Selected = True) Then
                Dim params As New List(Of String)
                params.Add(Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO & "," & Constantes.GRUPO_HEMODINAMICO)
                General.busquedaItems(Consultas.GRUPO_CUPS_GENERAL_BUSCAR, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgvprocedimientos,
                                  dtProcedimientos, 0, 1, dgvprocedimientos.Columns("dgDescripcion").Index,
                                  False, True, 0)
            ElseIf dgvprocedimientos.Rows(dgvprocedimientos.CurrentCell.RowIndex).Cells("anularp").Selected = True And dtProcedimientos.Rows(dgvprocedimientos.CurrentCell.RowIndex).Item(0).ToString <> "" Then
                dtProcedimientos.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        deshabilitarColumnas()
    End Sub
    Private Sub dgvParaclinicos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellDoubleClick
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgCodigoPar").Selected = True Or dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgDescripcionPar").Selected = True) Then
                Dim params As New List(Of String)
                params.Add(Constantes.GRUPO_PARACLINICO & "," & Constantes.GRUPO_HEMODERIVADO)
                General.busquedaItems(Consultas.GRUPO_CUPS_GENERAL_BUSCAR, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinicos,
                                  dtParaclinicos, 0, 1, dgvParaclinicos.Columns("dgDescripcionPar").Index, False, True, 0)
            ElseIf dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgAnularPar").Selected = True And dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item(0).ToString <> "" Then
                dtParaclinicos.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        deshabilitarColumnas()
    End Sub

    Private Sub dgvinsumos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvinsumos.KeyDown
        If dgvinsumos.Rows.Count > 0 Then
            If e.KeyCode = Keys.F3 And btcancelar.Enabled = True Then
                General.agregarItems(Consultas.INSUMOS_BUSCAR, TitulosForm.BUSQUEDA_INSUMOS, dgvinsumos, dtInsumos)
            End If
        End If
    End Sub
    Private Sub dgvprocedimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvprocedimientos.KeyDown
        If dgvprocedimientos.Rows.Count > 0 Then
            If e.KeyCode = Keys.F3 And btcancelar.Enabled = True Then
                Dim params As New List(Of String)
                params.Add(Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
                General.busquedaItems(Consultas.GRUPO_CUPS_GENERAL_BUSCAR, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgvprocedimientos,
                                  dtProcedimientos, 0, 1, dgvprocedimientos.Columns("dgDescripcion").Index,
                                  False, True, 0)
            End If
        End If
    End Sub
    Private Sub dgvParaclinicos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvParaclinicos.KeyDown
        If dgvprocedimientos.Rows.Count > 0 Then
            If e.KeyCode = Keys.F3 And btcancelar.Enabled = True Then
                Dim params As New List(Of String)
                params.Add(Constantes.GRUPO_PARACLINICO & "," & Constantes.GRUPO_HEMODERIVADO)
                General.busquedaItems(Consultas.GRUPO_CUPS_GENERAL_BUSCAR, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinicos,
                                  dtParaclinicos, 0, 1, dgvParaclinicos.Columns("dgDescripcionPar").Index, False, True, 0)
            End If
        End If
    End Sub
    Private Sub btbuscarprocedimiento_Click(sender As Object, e As EventArgs) Handles btbuscarprocedimiento.Click
        Dim params As New List(Of String)
        params.Add("")
        General.buscarElemento(Consultas.CONFIGURACION_AUDITORIA_PROCEDIMIENTOS_BUSCAR,
                               params,
                               AddressOf cargarProcedimientosCUPS,
                               TitulosForm.BUSQUEDA_PROCEDIMIENTOS_CUPS,
                              True, Constantes.TAMANO_MEDIANO, True)

    End Sub

    Private Sub btBuscarEps_Click(sender As Object, e As EventArgs) Handles btBuscarEps.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.EPS_LISTAR,
                               params,
                               AddressOf cargarEPS,
                               TitulosForm.BUSQUEDA_EPS,
                               False, 0, True)

    End Sub

    Private Sub OpcionBtGrupo_Click(sender As Object, e As EventArgs) Handles btOpcionGrupo.Click
        If SesionActual.tienePermiso(PGrupoAuditoria) Then
            Dim FormGrupoConfiguracion As New FormGrupoConfiguracionAuditoria
            FormGrupoConfiguracion.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarProcedimientosCUPS(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.CONFIGURACION_AUDIT_PROCEDIMIENTOS_CARGAR, params)
        Textcodigo.Text = drFila.Item(1)
        TextcodigoProcedimiento.Text = drFila.Item(1)
        TextnombreProcedimiento.Text = drFila.Item(2)
        tipo = drFila.Item(3)
    End Sub

    Public Sub cargarEPS(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.EPS_CARGAR, params)
        If opcionDuplicar = 0 Then
            General.limpiarControles(Me)
        End If
        idEps = pCodigo
        Textideps.Text = pCodigo
        TextnombreEps.Text = drFila.Item(0)
        TextcodigoEps.Text = drFila.Item(1)

    End Sub
    'Public Sub recargarEPS(pCodigo As String)
    '    Dim drFila As DataRow
    '    Dim params As New List(Of String)
    '    params.Add(pCodigo)
    '    drFila = General.cargarItem(Consultas.EPS_CARGAR, params)
    '    Textideps.Text = idEps
    '    TextnombreEps.Text = drFila.Item(0)
    '    TextcodigoEps.Text = drFila.Item(1)
    'End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            btbuscareps_Click(sender, e)
            dtInsumos.Rows.Add()
            dtProcedimientos.Rows.Add()
            dtParaclinicos.Rows.Add()
            dgvinsumos.ReadOnly = False
            dgvParaclinicos.ReadOnly = False
            dgvprocedimientos.ReadOnly = False
            deshabilitarColumnas()
            TextcodigoEps.ReadOnly = True
            TextcodigoProcedimiento.ReadOnly = True
            TextnombreEps.ReadOnly = True
            TextnombreProcedimiento.ReadOnly = True
            btEps.Visible = False
            btBuscarEps.Enabled = True
            opcionDuplicar = 0
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub dgvinsumos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvinsumos.CellEnter
        If btguardar.Enabled = True And dgvinsumos.Rows(e.RowIndex).Cells(0).Value <> "" Then
            dgvinsumos.ReadOnly = False
            dgvinsumos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = If(Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "dgCant", dgvinsumos) = False, True, False)
            dgvinsumos.EndEdit()
        End If
    End Sub
    Private Sub dgvParaclinicos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellEnter
        If btguardar.Enabled = True And dgvParaclinicos.Rows(e.RowIndex).Cells(0).Value <> "" Then
            dgvParaclinicos.ReadOnly = False
            dgvParaclinicos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = If(Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "dgCantidadPar", dgvParaclinicos) = False, True, False)
            dgvParaclinicos.EndEdit()
        End If
    End Sub
    Private Sub dgvprocedimientos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimientos.CellEnter
        If btguardar.Enabled = True And dgvprocedimientos.Rows(e.RowIndex).Cells(0).Value <> "" Then
            dgvprocedimientos.ReadOnly = False
            dgvprocedimientos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = If(Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "dgCantidad", dgvprocedimientos) = False, True, False)
            dgvprocedimientos.EndEdit()
        End If
    End Sub
End Class