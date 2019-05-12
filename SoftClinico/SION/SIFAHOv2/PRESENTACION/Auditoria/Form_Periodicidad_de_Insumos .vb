Public Class Form_Periodicidad_de_Insumos
    Dim dtInsumos As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, PBuscar, Panular As String
    Dim dgvAsignada As New BindingSource
    Public Function muestraImagen()
        Return PictureBox1.Image
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
    Private Sub Textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles Textdescripcion.TextChanged
        dgvAsignada.Filter = "[Codigo] LIKE '%" + Textdescripcion.Text.Trim() + "%' or [Descripcion] LIKE '%" + Textdescripcion.Text.Trim() + "%'"
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            cargarInsumos()
            bloquearColumnasdgv()
            General.cargarCombo(Consultas.PROC_AREA_SERVICIO_COMBO_LLENAR & "'" & SesionActual.codigoEP & "'", "Descripción", "Código", comboAreaServicio)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bloquearColumnasdgv()
        With dgvinsumos
            .Columns("dgdescripcion").ReadOnly = True
        End With
    End Sub
    Public Function crearPeriodicInsumos() As PeriodicInsumos
        Dim objPeriodicInsumos As New PeriodicInsumos
        Dim filas As DataRow()
        dtInsumos.AcceptChanges()
        filas = dtInsumos.Select("Cantidad<>0", "")
        Dim dtTemporal As New DataTable
        dtTemporal = dtInsumos.Clone

        For Each fila As DataRow In filas
            dtTemporal.ImportRow(fila)
        Next
        dtInsumos.Clear()
        dtInsumos.Merge(dtTemporal)

        dtTemporal.Dispose()
        objPeriodicInsumos.areaServicio = comboAreaServicio.SelectedValue
        objPeriodicInsumos.usuario = SesionActual.codigoEP
        objPeriodicInsumos.dtInsumos = dtInsumos
        Return objPeriodicInsumos
    End Function
    Private Sub guardarInsumos()
        If MsgBox("¿Desea guardar este Registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Guardar") = MsgBoxResult.Yes Then
            dgvinsumos.EndEdit()
            dgvinsumos.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dtInsumos.AcceptChanges()

            Try
                Dim objPerInsumosBLL As New PeriodicidadInsumoBLL
                objPerInsumosBLL.guardarInsumos(crearPeriodicInsumos())
                cargarDatos(comboAreaServicio.SelectedValue)
                General.habilitarBotones(ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                dgvinsumos.ReadOnly = True
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub cargarInsumos()
        Dim params As New List(Of String)
        params.Add("")
        General.llenarTabla(Consultas.PERIODICIDAD_INSUMOS_LLENAR, params, dtInsumos)
        dgvAsignada.DataSource = dtInsumos
        dgvinsumos.DataSource = dgvAsignada
        dgvinsumos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvinsumos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

    End Sub
    Private Sub cargarDatos(pArea As Integer)
        Dim params As New List(Of String)
        params.Add(pArea)
        comboAreaServicio.SelectedValue = pArea
        General.llenarTabla(Consultas.PERIODICIDAD_INSUMOS_CARGAR, params, dtInsumos)
        dgvAsignada.DataSource = dtInsumos
        dgvinsumos.DataSource = dgvAsignada
        dgvinsumos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvinsumos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False
        Textdescripcion.Clear()
    End Sub
    Private Sub dgvprocedimientos_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvinsumos.EditingControlShowing
        If dgvinsumos.CurrentCell.ColumnIndex = 2 Then
            Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            RemoveHandler dText.KeyPress, AddressOf validar_Keypress
            AddHandler dText.KeyPress, AddressOf validar_Keypress
        End If
    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If dgvinsumos.CurrentCell.ColumnIndex = 2 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or e.KeyChar = CChar(ChrW(Keys.Space)) Or
            (caracter = ",") And (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub dgvprocedimientos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvinsumos.DataError
        If e.ColumnIndex = 2 Then
            dgvinsumos.Rows(dgvinsumos.CurrentRow.Index).Cells(2).Value = 0
        End If
    End Sub
    Private Sub dgvprocedimientos_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvinsumos.CellFormatting
        If e.ColumnIndex = 2 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), 0)
            Else
                e.Value = Format(Val(e.Value), 0)
            End If
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                dgvinsumos.Columns(1).ReadOnly = True
                General.deshabilitarBotones(ToolStrip1)
                dtInsumos.Rows.Add()
                btguardar.Enabled = True
                btcancelar.Enabled = True
                comboAreaServicio.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If comboAreaServicio.SelectedIndex <= 0 Then
            MsgBox("Escoja un area de servicio", MsgBoxStyle.Exclamation)
        Else
            guardarInsumos()
        End If
    End Sub
    Private Sub dgvprocedimientos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvinsumos.CellDoubleClick
        Dim respuesta As Boolean
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If dgvinsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Cells("anular").Selected = True Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_CANTIDAD_PERIODICIDAD_INSUMOS & "'" & comboAreaServicio.SelectedValue &
                                              "','" & dtInsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Item("Codigo") & "'")
                    If respuesta = True Then
                        dtInsumos.Rows(dgvinsumos.CurrentCell.RowIndex).Item("cantidad") = 0
                        dgvinsumos.EndEdit()
                        dtInsumos.AcceptChanges()
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.cargarCombo(Consultas.BUSQUEDA_AREA_SERVICIO & "'" & SesionActual.codigoEP & "'", "Descripción", "Codigo_Area_Servicio", comboAreaServicio)
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(Consultas.PERIODICIDAD_INSUMOS_BUSCAR,
                               params,
                               AddressOf cargarDatos,
                               TitulosForm.BUSQUEDA_PERIODICIDAD_INSUMOS,
                               True, 0, True)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_PERIODICIDAD_INSUMOS & "" & SesionActual.idUsuario & "," & CInt(comboAreaServicio.SelectedValue) & "")
                If respuesta = True Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                End If
            End If
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub Form_Periodicidad_de_Insumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btbuscar.Enabled = True
        Dim col1, col2, col3 As New DataColumn

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
        col3.DefaultValue = 0
        dtInsumos.Columns.Add(col3)

        With dgvinsumos
            .Columns.Item("dgCodigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigo").DataPropertyName = "Codigo"
            .Columns.Item("dgCodigo").ReadOnly = True

            .Columns.Item("dgDescripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcion").DataPropertyName = "Descripcion"
            .Columns.Item("dgDescripcion").ReadOnly = True

            .Columns.Item("dgCantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCantidad").DataPropertyName = "Cantidad"
            .Columns.Item("dgCantidad").ReadOnly = False
        End With
        dgvinsumos.AutoGenerateColumns = False
        dgvinsumos.DataSource = dtInsumos
        dgvinsumos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvinsumos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvinsumos.ReadOnly = True
        btbuscar.Enabled = True
        btnuevo.Enabled = True
    End Sub
End Class