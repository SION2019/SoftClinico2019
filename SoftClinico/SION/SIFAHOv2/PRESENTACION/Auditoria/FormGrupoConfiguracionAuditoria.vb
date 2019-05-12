Public Class FormGrupoConfiguracionAuditoria
    Dim dtGrupoConfiguracion As New DataTable
    Dim idEps As Integer
    Public Function crearGrupoConfiguracionAuditoria() As GrupoConfiguracionAuditoria
        Dim objConfiguracionAuditoria As New GrupoConfiguracionAuditoria
        objConfiguracionAuditoria.codigoGrupo = txtcodigo.Text
        objConfiguracionAuditoria.nombreGrupo = txtNombre.Text
        For Each drFilaGrupo As DataRow In dtGrupoConfiguracion.Rows
            If drFilaGrupo.Item("Código").ToString <> "" Then
                Dim drGrupo As DataRow = objConfiguracionAuditoria.dtGrupoConfiguracion.NewRow
                drGrupo.Item("CodigoGrupo") = objConfiguracionAuditoria.codigoGrupo
                drGrupo.Item("Código") = drFilaGrupo.Item("Código")
                drGrupo.Item("NombreGrupo") = objConfiguracionAuditoria.nombreGrupo
                drGrupo.Item("Usuario") = SesionActual.idUsuario
                objConfiguracionAuditoria.dtGrupoConfiguracion.Rows.Add(drGrupo)
            End If
        Next
        Return objConfiguracionAuditoria
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validardgvs() Then
            guardarConfiguracion()
        End If
    End Sub
    Private Sub guardarConfiguracion()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objConfigAuditoria As New GrupoConfiguracionAuditoriaBLL
            Try
                txtcodigo.Text = objConfigAuditoria.guardarConfAuditoria(crearGrupoConfiguracionAuditoria())
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                cargarProcedimientos()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.habilitarControles(Me)
            General.deshabilitarControles(Me)
            General.deshabilitarBotones(Me.ToolStrip1)
            dgvGrupoConfiguracion.ReadOnly = True
            dtGrupoConfiguracion.Rows.Add()
            TxtNombre.ReadOnly = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscareps.Enabled = False
            TextcodigoEps.ReadOnly = True
            TextnombreEps.ReadOnly = True
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.GRUPO_CONFIGURACION_AUDITORIA_ANULAR, params)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                TxtNombre.ReadOnly = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub enlazarTabla()
        Dim col1, col2, col3, col4 As New DataColumn

        col1.ColumnName = "Código"
        col1.DataType = Type.GetType("System.String")
        col1.DefaultValue = String.Empty
        dtGrupoConfiguracion.Columns.Add(col1)

        col2.ColumnName = "Código Procedimiento"
        col2.DataType = Type.GetType("System.String")
        col2.DefaultValue = String.Empty
        dtGrupoConfiguracion.Columns.Add(col2)

        col3.ColumnName = "Descripción"
        col3.DataType = Type.GetType("System.String")
        dtGrupoConfiguracion.Columns.Add(col3)

        col4.ColumnName = "Servicio"
        col4.DataType = Type.GetType("System.String")
        dtGrupoConfiguracion.Columns.Add(col4)

        With dgvGrupoConfiguracion
            .Columns.Item("dgCodigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigo").DataPropertyName = "Código"

            .Columns.Item("dgCodigoProcedimiento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigoProcedimiento").DataPropertyName = "Código Procedimiento"

            .Columns.Item("dgDescripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcion").DataPropertyName = "Descripción"
            .Columns.Item("dgDescripcion").ReadOnly = True

            .Columns.Item("dgServicio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgServicio").DataPropertyName = "Servicio"
            .Columns.Item("dgServicio").ReadOnly = True
        End With
        dgvGrupoConfiguracion.AutoGenerateColumns = False
        dgvGrupoConfiguracion.DataSource = dtGrupoConfiguracion
        dgvGrupoConfiguracion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGrupoConfiguracion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub

    Private Sub FormGrupoConfiguracionAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enlazarTabla()
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btbuscareps.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        dtGrupoConfiguracion.Rows.Add()
        dgvGrupoConfiguracion.ReadOnly = True
        TxtNombre.ReadOnly = False
        TextcodigoEps.ReadOnly = True
        TextnombreEps.ReadOnly = True
        recargarEPS(idEps)
    End Sub
    Private Sub dgvGrupoConfiguracion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGrupoConfiguracion.CellDoubleClick
        Dim params As New List(Of String)
        params.Add("")
        params.Add(idEps)
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvGrupoConfiguracion.Rows(dgvGrupoConfiguracion.CurrentCell.RowIndex).Cells("dgCodigoProcedimiento").Selected = True Or dgvGrupoConfiguracion.Rows(dgvGrupoConfiguracion.CurrentCell.RowIndex).Cells("dgDescripcion").Selected = True) Then
                General.busquedaItems(Consultas.PROCEDIMIENTOS_CONFIGURADOS_BUSCAR, params, TitulosForm.BUSQUEDA_CONFIGURACION_AUDITORIA, dgvGrupoConfiguracion, dtGrupoConfiguracion, 0, 3, 0, 0, True)
            ElseIf dgvGrupoConfiguracion.Rows(dgvGrupoConfiguracion.CurrentCell.RowIndex).Cells("anular").Selected = True And dtGrupoConfiguracion.Rows(dgvGrupoConfiguracion.CurrentCell.RowIndex).Item(0).ToString <> "" Then
                dtGrupoConfiguracion.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarCodigoGrupo(codigoGrupo As String)
        Dim dtConfig As New DataTable
        Dim params As New List(Of String)
        txtcodigo.Text = codigoGrupo
        cargarDatosGrupo(codigoGrupo)
        cargarProcedimientos()
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btcancelar.Enabled = False
        btguardar.Enabled = False
    End Sub
    Public Sub cargarDatosGrupo(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.CONFIGURACION_AUDITORIA_GRUPO_CARGAR, params)
        idEps = drFila.Item(0)
        TextcodigoEps.Text = drFila.Item(1)
        TextnombreEps.Text = drFila.Item(2)
    End Sub
    Private Sub cargarProcedimientos()
        General.llenarTablaYdgv(Consultas.CONFIGURACION_AUDITORIA_GRUPO_DETALLE_CARGAR & "'" & txtcodigo.Text & "'", dtGrupoConfiguracion)
        TxtNombre.Text = dtGrupoConfiguracion.Rows(0).Item("Nombre_Grupo").ToString()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add("")
        General.buscarElemento(Consultas.GRUPOS_CONFIGURACION_AUDITORIA_BUSCAR,
                                       params,
                                       AddressOf cargarCodigoGrupo,
                                       TitulosForm.BUSQUEDA_CONFIGURACION_AUDITORIA,
                                       False, Constantes.TAMANO_MEDIANO, True)

    End Sub
    Private Function validardgvs()
        If TextcodigoEps.Text = "" Then
            MsgBox("Debe escoger una EPS", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            btbuscareps.Focus()
        ElseIf TxtNombre.Text = "" Then
            MsgBox("Digite El nombre del grupo", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            TxtNombre.Focus()
        ElseIf (dgvGrupoConfiguracion.RowCount = 1) Then
            MsgBox("No se puede guardar registros sin agregar items en alguna de las listas", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            dgvGrupoConfiguracion.Focus()
        Else
            Return True
        End If
        Return False
    End Function
    Private Sub FormGrupoConfiguracionAuditoria_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub btbuscareps_Click(sender As Object, e As EventArgs) Handles btbuscareps.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.EPS_LISTAR,
                               params,
                               AddressOf cargarEPS,
                               TitulosForm.BUSQUEDA_EPS,
                               False, 0, True)

    End Sub
    Public Sub cargarEPS(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.EPS_CARGAR, params)
        General.limpiarControles(Me)
        idEps = pCodigo
        TextnombreEps.Text = drFila.Item(0)
        TextcodigoEps.Text = drFila.Item(1)
        btnuevo.Enabled = True
    End Sub
    Public Sub recargarEPS(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.EPS_CARGAR, params)
        TextnombreEps.Text = drFila.Item(0)
        TextcodigoEps.Text = drFila.Item(1)
    End Sub
End Class