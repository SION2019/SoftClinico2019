Public Class FormSoporteFacturacion
    Dim objSoporte As New SoporteFacturacion
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub dgvExamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            If Not String.IsNullOrEmpty(Funciones.castFromDbItem(dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("carpeta").Value)) Then
                Dim formSoporte As New FormConfiguracionFacturacion
                FormPrincipal.Cursor = Cursors.WaitCursor
                formSoporte.nombreCarpeta(dgvExamen.CurrentCell.RowIndex, objSoporte)
                formSoporte.cargarSoporte()
                formSoporte.ShowDialog()
                formSoporte.Focus()
                If formSoporte.WindowState = FormWindowState.Minimized Then
                    formSoporte.WindowState = FormWindowState.Normal
                End If
                FormPrincipal.Cursor = Cursors.Default
            Else
                MsgBox("debe colocar el nombre de la carpeta para acceder a la configuración", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub FormSoporteFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        With dgvExamen
            .Columns("Idcarpeta").ReadOnly = True
            .Columns("Idcarpeta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Idcarpeta").DataPropertyName = "Id Carpeta"
            .Columns("carpeta").ReadOnly = True
            .Columns("carpeta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("carpeta").DataPropertyName = "Carpeta"
            .Columns("carpeta").Width = 678
            .Columns("Documentos").ReadOnly = True
            .Columns("Documentos").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Documentos").DataPropertyName = "Documentos"
            .Columns("Documentos").Width = 120
        End With
        dgvExamen.DataSource = objSoporte.dtFacturacion
        dgvExamen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExamen.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            habilitarControles()
            btnuevo.Enabled = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            bteditar.Enabled = False
            btbuscar.Enabled = False
            limpiarControles()
            Checkcomprimir.Checked = False
            Checkpaginar.Checked = False
            dgvExamen.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscartraslado_Click(sender As Object, e As EventArgs) Handles bteps.Click
        General.buscarElemento(Consultas.EPS_SOPORTE_BUSCAR,
                       Nothing,
                       AddressOf cargar,
                       TitulosForm.BUSQUEDA_EPS,
                       True, 0, True)
    End Sub

    Public Sub deshabilitarControles()
        bteps.Enabled = False
        Checkpaginar.Enabled = False
        Checkcomprimir.Enabled = False
    End Sub

    Public Sub limpiarControles()
        txtcodigo.Clear()
        txteps.Clear()
        txtruta.Clear()
        objSoporte.dtConfigurado.Clear()
        objSoporte.dtFacturacion.Clear()
        objSoporte.dtConfiguradoCopia.Clear()
    End Sub
    Public Sub habilitarControles()
        bteps.Enabled = True
        Checkpaginar.Enabled = True
        Checkcomprimir.Enabled = True
    End Sub
    Public Sub habilitarDg()
        dgvExamen.ReadOnly = False
    End Sub
    Public Sub cargar(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.RIPS_EPS_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txtcodigo.Text = dt.Rows(0).Item("codigo_eps")
            txteps.Text = dt.Rows(0).Item("eps")
            objSoporte.idEps = dt.Rows(0).Item("id_eps")
        End If
        objSoporte.dtFacturacion.Clear()

        If objSoporte.dtFacturacion.Rows.Count = 0 Then
            objSoporte.dtFacturacion.Rows.Add()
        End If
        habilitarDg()
    End Sub

    Private Sub Checkcomprimir_CheckedChanged(sender As Object, e As EventArgs)
        If Checkcomprimir.Checked = True Then
            txtruta.ReadOnly = False
            btruta.Enabled = True
        Else
            txtruta.ReadOnly = True
            btruta.Enabled = False
        End If
    End Sub

    Public Sub comportamientoBtCancelar()
        btcancelar.Enabled = False
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        btguardar.Enabled = False
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea Cancelar este registro?", 32 + 1, "Cancelar") = 1 Then
            dgvExamen.EndEdit()
            objSoporte.dtFacturacion.AcceptChanges()
            objSoporte.dtFacturacion.Clear()
            limpiarControles()
            deshabilitarControles()
            comportamientoBtCancelar()
            Checkcomprimir.Checked = False
            Checkpaginar.Checked = False
        End If
    End Sub

    Private Sub dgvExamen_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellEndEdit
        dgvExamen.EndEdit()
        objSoporte.dtFacturacion.AcceptChanges()

        If Not String.IsNullOrEmpty(objSoporte.dtFacturacion.Rows(objSoporte.dtFacturacion.Rows.Count - 1).Item("carpeta").ToString) Then
            objSoporte.dtFacturacion.Rows.Add()
        ElseIf Not String.IsNullOrEmpty(objSoporte.dtFacturacion.Rows(objSoporte.dtFacturacion.Rows.Count - 1).Item("carpeta").ToString) Then
            If String.IsNullOrEmpty(objSoporte.dtFacturacion.Rows(objSoporte.dtFacturacion.Rows.Count - 1).Item("carpeta").ToString) Then
                objSoporte.dtFacturacion.Rows.RemoveAt(e.RowIndex)
            End If
        ElseIf String.IsNullOrEmpty(objSoporte.dtFacturacion.Rows(e.RowIndex).Item("carpeta").ToString) And objSoporte.dtFacturacion.Rows.Count > 1 Then
            objSoporte.dtFacturacion.Rows.RemoveAt(e.RowIndex)
        End If

    End Sub

    Private Function validar()
        dgvExamen.EndEdit()
        objSoporte.dtFacturacion.AcceptChanges()

        If Checkpaginar.Checked = False And Checkcomprimir.Checked = False Then
            MsgBox("Por favor debe chequear entre paginar y comprimir", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objSoporte.dtFacturacion.Rows.Count < 2 Then
            MsgBox("No puede guardar sin carpetas", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objSoporte.dtFacturacion.Select("carpeta= ''", "").Count > 1 Then
            MsgBox("Por favor no puedes guardar sin colocar nombre de las carpetas", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objSoporte.dtConfigurado.Rows.Count = 0 Then
            MsgBox("Por favor debe configurar la carpeta correspondiente", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function

    Public Sub guardarRegistro()
        If validar() Then
            Try
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    If Checkpaginar.Checked = True Then
                        objSoporte.accion = 0
                    Else
                        objSoporte.accion = 1
                    End If
                    objSoporte.guardar()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    btnuevo.Enabled = True
                    bteditar.Enabled = True
                    btbuscar.Enabled = True
                    btanular.Enabled = True
                    deshabilitarControles()
                    objSoporte.cargarCarpetas()
                    objSoporte.dtConfigurado.Clear()
                    objSoporte.dtConfiguradoCopia.Clear()
                    dgvExamen.Enabled = False
                    objSoporte.cargarSoporte()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvExamen.EndEdit()
        objSoporte.dtFacturacion.AcceptChanges()
        guardarRegistro()
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            bteditar.Enabled = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscar.Enabled = False
            btnuevo.Enabled = False
            bteps.Enabled = False
            dgvExamen.Enabled = True
            Checkcomprimir.Enabled = True
            Checkpaginar.Enabled = True
            objSoporte.dtFacturacion.Rows.Add()
            dgvExamen.ReadOnly = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consultas.SOPORTE_EPS_BUSCAR,
                     Nothing,
                     AddressOf cargarSoportes,
                     TitulosForm.BUSQUEDA_EPS,
                     True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarSoportes(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        Dim valor As Integer
        General.llenarTabla(Consultas.SOPORTE_EPS_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txtcodigo.Text = dt.Rows(0).Item("codigo_eps")
            txteps.Text = dt.Rows(0).Item("Nombre EPS")
            valor = dt.Rows(0).Item("valor")
            If valor = 0 Then
                Checkpaginar.Checked = True
            Else
                Checkcomprimir.Checked = True
            End If
            objSoporte.idEps = pCodigo
            objSoporte.cargarCarpetas()
            objSoporte.dtConfigurado.Clear()
            objSoporte.dtConfiguradoCopia.Clear()
            objSoporte.cargarSoporte()

        End If
        bteditar.Enabled = True
        dgvExamen.Enabled = False
        btcancelar.Enabled = False
        btanular.Enabled = True
    End Sub

    Private Sub dgvExamen_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellDoubleClick
        If e.RowIndex = 0 Then
            If Not String.IsNullOrEmpty(Funciones.castFromDbItem(dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("carpeta").Value)) Then
                objSoporte.dtFacturacion.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim paramas As New List(Of String)
                paramas.Add(objSoporte.idEps)
                General.ejecutarSQL(Consultas.SOPORTE_CONSOLIDADO_ELIMINAR, paramas)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                btanular.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btbuscar.Enabled = True
                btnuevo.Enabled = True
                limpiarControles()
                deshabilitarControles()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class