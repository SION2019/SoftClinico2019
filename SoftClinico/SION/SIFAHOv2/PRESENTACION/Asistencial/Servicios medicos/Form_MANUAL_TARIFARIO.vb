Imports System.Data.SqlClient
Public Class Form_MANUAL_TARIFARIO
    Dim dt As New DataTable
    Dim objManual As New ManualTarifario
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_MANUAL_TARIFARIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        General.deshabilitarBotones(ToolStrip1)
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
    Public Sub cargarManual(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drFila = General.cargarItem(Consultas.MANUAL_CARGAR, params)

        txtCodigo.Text = pCodigo
        descripcion.Text = drFila.Item(0).ToString

        ToolStrip1.Enabled = True

        Cargardgv(txtCodigo.Text)
        Button2.Enabled = False
        Button3.Enabled = False
        txtbuscar.Enabled = True
        txtbuscar.ReadOnly = False
    End Sub
    Private Sub Cargardgv(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(txtbuscar.Text)
        txtCodigo.Text = pCodigo
        General.llenarTabla(Consultas.MANUAL_TARIFARIO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            dgvmanual.DataSource = dt
        End If
    End Sub

    Private Sub dgvmanual_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmanual.CellEnter
        If e.RowIndex >= 0 Then
            txtcodigocups.Text = dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells(0).Value
            txtcodigosoat.Text = dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells(1).Value
            txtcodigoiss.Text = dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells(2).Value
            cargarCups(txtcodigocups.Text)
            cargarSoat(txtcodigosoat.Text)
            cargarIss(txtcodigoiss.Text)
            GroupBox2.Enabled = False
            General.deshabilitarBotones(ToolStrip1)
            btnuevo.Enabled = True
            bteditar.Enabled = True
            btanular.Enabled = True
        End If
    End Sub


    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged
        Cargardgv(txtCodigo.Text)
    End Sub

    Private Sub btbuscarmanual_Click(sender As Object, e As EventArgs) Handles btbuscarmanual.Click

        General.buscarElemento(Consultas.MANUAL_BUSCAR,
                               Nothing,
                               AddressOf cargarManual,
                               TitulosForm.BUSQUEDA_MANUAL,
                               False, 0, True)
        If Not IsNothing(txtCodigo.Text) Then

            btnuevo.Enabled = True
            btanular.Enabled = True
            descripcion.ReadOnly = True
            bteditar.Enabled = True
            btcancelar.Enabled = False
            btanular.Enabled = False
        End If


    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        btnuevo.Enabled = True
        btguardar.Enabled = False
        bteditar.Enabled = True
        btcancelar.Enabled = False
        btanular.Enabled = False
        txtdescripcioncups.ReadOnly = True
        txtcodigoiss.Clear()
        txtdescripcioniss.Clear()
        txtcodigocups.Clear()
        txtdescripcioncups.Clear()
        Button2.Enabled = False
        Button3.Enabled = False
        txtcodigosoat.Clear()
        txtdescripcionsoat.Clear()
        Cargardgv(txtCodigo.Text)
        btbuscarmanual.Enabled = True
        dgvmanual.Enabled = True
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtcodigocups.Text = "" Then
            MsgBox("Seleccione el codigo CUPS !!", MsgBoxStyle.Information)
        ElseIf txtcodigosoat.Text = "" Then
            MsgBox("Seleccione el codigo SOAT !!", MsgBoxStyle.Information)
        ElseIf txtcodigoiss.Text = "" Then
            MsgBox("Seleccione el codigo ISS !!", MsgBoxStyle.Information)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objManual.codigo = CInt(txtCodigo.Text)
                objManual.codigoCups = txtcodigocups.Text
                objManual.codigoSoat = txtcodigosoat.Text
                objManual.codigoIss = txtcodigoiss.Text
                objManual.usuario = SesionActual.idUsuario
                objManual.guardarManual()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                btguardar.Enabled = False
                Cargardgv(txtCodigo.Text)
                bteditar.Enabled = True
                btnuevo.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                dgvmanual.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtcodigosoat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcodigosoat.KeyDown
        If btguardar.Enabled = True Then
            If e.KeyValue = Keys.F3 Then
                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add(Nothing)
                General.buscarElemento(Consultas.MANUAL_TARIFARIO_BUSCAR_SOAT,
                              params,
                              AddressOf cargarSoat,
                              TitulosForm.BUSQUEDA_MANUAL,
                              False)

            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub txtcodigoiss_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcodigoiss.KeyDown
        If btguardar.Enabled = True Then
            If e.KeyValue = Keys.F3 Then
                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add(Nothing)
                General.buscarElemento(Consultas.MANUAL_TARIFARIO_BUSCAR_ISS,
                              params,
                              AddressOf cargarIss,
                              TitulosForm.BUSQUEDA_MANUAL,
                              False)
            End If
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            GroupBox2.Enabled = False
            txtcodigosoat.ReadOnly = True
            txtdescripcionsoat.ReadOnly = True
            txtdescripcioniss.ReadOnly = True
            txtcodigoiss.ReadOnly = True
            btbuscarmanual.Enabled = False
            General.habilitarBotones(ToolStrip1)
            bteditar.Enabled = False
            btnuevo.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            txtbuscar.Enabled = True
            txtbuscar.ReadOnly = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim paramas As New List(Of String)
                paramas.Add(txtCodigo.Text)
                paramas.Add(txtcodigocups.Text)
                paramas.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_MANUAL_TARIFARIO, paramas)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Cargardgv(txtCodigo.Text)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btguardar.Enabled = False
                End If

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            GroupBox2.Enabled = True
            btnuevo.Enabled = False
            btguardar.Enabled = True
            bteditar.Enabled = False
            txtdescripcioncups.ReadOnly = True
            txtcodigoiss.Clear()
            txtdescripcioniss.Clear()
            txtcodigocups.Clear()
            txtdescripcioncups.Clear()
            txtcodigosoat.Clear()
            txtdescripcionsoat.Clear()
            txtcodigocups.ReadOnly = True
            txtcodigosoat.ReadOnly = True
            Button2.Enabled = True
            Button3.Enabled = True
            txtcodigoiss.ReadOnly = True
            txtdescripcioniss.ReadOnly = True
            txtdescripcionsoat.ReadOnly = True
            btcancelar.Enabled = True
            btanular.Enabled = False
            btbuscarmanual.Enabled = False
            dgvmanual.Enabled = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub txtcodigocups_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcodigocups.KeyDown
        If btguardar.Enabled = True Then
            If e.KeyValue = Keys.F3 Then
                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add("")
                General.buscarElemento(Consultas.MANUAL_TARIFARIO_BUSCAR_CUPS,
                              params,
                              AddressOf cargarCups,
                              TitulosForm.BUSQUEDA_MANUAL,
                              False)

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If btguardar.Enabled = True Then

            Dim params As New List(Of String)
            params.Add(txtCodigo.Text)
            params.Add("")
            General.buscarElemento(Consultas.MANUAL_TARIFARIO_BUSCAR_CUPS,
                          params,
                          AddressOf cargarCups,
                          TitulosForm.BUSQUEDA_MANUAL,
                          False, 0, True)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If btguardar.Enabled = True Then

            Dim params As New List(Of String)
            params.Add(txtCodigo.Text)
            params.Add("")
            General.buscarElemento(Consultas.MANUAL_TARIFARIO_BUSCAR_SOAT,
                              params,
                              AddressOf cargarSoat,
                              TitulosForm.BUSQUEDA_MANUAL,
                              False, 0, True)


        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If btguardar.Enabled = True Then

            Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add(Nothing)
            General.buscarElemento(Consultas.MANUAL_TARIFARIO_BUSCAR_ISS,
                          params,
                          AddressOf cargarIss,
                          TitulosForm.BUSQUEDA_MANUAL,
                          False, 0, True)
        End If
    End Sub

    Private Sub txtcodigocups_TextChanged(sender As Object, e As EventArgs) Handles txtcodigocups.TextChanged

    End Sub

    Private Sub cargarCups(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigocups.Text = pCodigo
        General.llenarTabla(Consultas.MANUAL_TARIFARIO_CARGAR_CUPS, params, dt)
        txtdescripcioncups.Text = dt.Rows(0).Item("Descripcion").ToString()

        If btguardar.Enabled = True AndAlso txtcodigocups.Enabled = True AndAlso objManual.validar_codigo(txtCodigo.Text, txtcodigocups.Text) = True Then
            txtcodigocups.Clear()
            txtdescripcioncups.Clear()
            MsgBox("Este codigo CUPS ya esta configurado para este Manual.", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub cargarIss(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtCodigo.Text)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.MANUAL_TARIFARIO_CARGAR_ISS, params, dt)
        txtdescripcioniss.Text = dt.Rows(0).Item("Descripcion").ToString()
        txtcodigoiss.Text = pCodigo
    End Sub
    Private Sub cargarSoat(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtCodigo.Text)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.MANUAL_TARIFARIO_CARGAR_SOAT, params, dt)
        txtdescripcionsoat.Text = dt.Rows(0).Item("Descripcion").ToString()
        txtcodigosoat.Text = pCodigo

    End Sub
End Class