Public Class Form_Sonda_Vesical
    Dim dtsonda As New DataTable
    Public tipoEntrada As Integer
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim respuestan As Boolean
    Dim reportes As Boolean
    Dim modulo As String
    Private Sub Form_Sonda_Vesical_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        establecerTabla()
        General.deshabilitarBotones(ToolStrip1)
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        With dgvsonda
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "codigo"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "descripcion"
            .Columns.Item(1).ReadOnly = True

            .Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(2).DataPropertyName = "respuesta"
            .Columns.Item(2).ReadOnly = False

        End With
        dgvsonda.DataSource = dtsonda
        btnuevo.Enabled = True
        dgvsonda.Columns(2).ReadOnly = True
        TXTFECHACOLOCA.Enabled = False
        btbuscar.Enabled = True
        checkseleccionar.Enabled = False
    End Sub

    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub

    Private Sub Form_Sonda_Vesical_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Public Sub establecerTabla()
        Dim A, A1, A2 As New DataColumn

        A.ColumnName = "codigo"
        A.DataType = Type.GetType("System.String")
        dtsonda.Columns.Add(A)

        A1.ColumnName = "descripcion"
        A1.DataType = Type.GetType("System.String")
        dtsonda.Columns.Add(A1)

        A2.ColumnName = "respuesta"
        A2.DataType = Type.GetType("System.String")
        dtsonda.Columns.Add(A2)
        A = Nothing : A1 = Nothing : A2 = Nothing
    End Sub


    Public Sub llenarSondaVesical()
        General.llenarTabla(Consultas.SONDA_VESICAL_CARGAR2, Nothing, dtsonda)

        For i = 0 To dtsonda.Rows.Count - 1
            If dtsonda.Rows(i).Item(1).ToString.Contains("micro") And dtsonda.Rows(i).Item(2) = True Then
                GroupBox5.Visible = True
            End If
            If dtsonda.Rows(i).Item(1).ToString.Contains("retir") And dtsonda.Rows(i).Item(2) = True Then
                fechar.Visible = True
                Label8.Visible = True
            End If
        Next
        dgvsonda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvsonda.AllowUserToResizeColumns = False
    End Sub

    Public Sub deshabilitarControl()
        dgvsonda.Columns(2).ReadOnly = True
        checkseleccionar.Enabled = False
    End Sub

    Public Sub habilitarControl()
        dgvsonda.Columns(2).ReadOnly = False
        checkseleccionar.Enabled = True
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btnuevo.Enabled = False
            btimprimir.Enabled = False
            btanular.Enabled = False
            bteditar.Enabled = False
            General.habilitarControles(Me)
            txtregistro.ReadOnly = True
            txtpnombre.ReadOnly = True
            txtfecha.Enabled = False
            txteps.ReadOnly = True
            txtcodigo.ReadOnly = True
            dgvsonda.Columns(0).ReadOnly = True
            dgvsonda.Columns(1).ReadOnly = True
            TXTFECHACOLOCA.Enabled = True
            dgvsonda.Columns(2).ReadOnly = False
            btbuscar.Enabled = False
            checkseleccionar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            dgvsonda.Columns(2).ReadOnly = True
            dtsonda.Clear()
            txtcodigo.Clear()
            If tipoEntrada = Constantes.SONDA_VESICAL Then
                llenarSondaVesical()
            Else
                llenarVenopuncion()
            End If
            btcancelar.Enabled = False
            btnuevo.Enabled = True
            bteditar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            btguardar.Enabled = False
            TXTFECHACOLOCA.Enabled = False
            checkseleccionar.Enabled = False
            checkseleccionar.Checked = False
            checkseleccionar.Text = "Habilitar todo"
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If tipoEntrada = Constantes.SONDA_VESICAL Then
                    respuestan = General.anularRegistro(Consultas.ANULAR_SONDA_VESICAL & txtcodigo.Text & "," & SesionActual.idUsuario)
                    If respuestan = True Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        btanular.Enabled = False
                        deshabilitarControl()
                        txtcodigo.Clear()
                        llenarSondaVesical()
                        btguardar.Enabled = False
                        bteditar.Enabled = False
                        btcancelar.Enabled = False
                        btbuscar.Enabled = True
                        btnuevo.Enabled = True

                        btimprimir.Enabled = False
                        Label8.Visible = False
                        fechar.Visible = False
                        GroupBox5.Visible = False
                        txtcual.Clear()
                        checkseleccionar.Enabled = False
                        checkseleccionar.Checked = False
                        checkseleccionar.Text = "Habilitar todo"
                    End If
                ElseIf tipoEntrada = Constantes.VENOPUNCION Then
                    respuestan = General.anularRegistro(Consultas.ANULAR_VENOPUNCION & txtcodigo.Text & "," & SesionActual.idUsuario)
                    If respuestan = True Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        btanular.Enabled = False
                        deshabilitarControl()
                        txtcodigo.Clear()
                        llenarVenopuncion()
                        btguardar.Enabled = False
                        bteditar.Enabled = False
                        btimprimir.Enabled = False
                        btcancelar.Enabled = False
                        btnuevo.Enabled = True
                        checkseleccionar.Enabled = False
                        checkseleccionar.Checked = False
                        checkseleccionar.Text = "Habilitar todo"
                    End If
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(txtregistro.Text)
        If SesionActual.tienePermiso(PBuscar ) Then
            If tipoEntrada = Constantes.SONDA_VESICAL Then
                General.buscarElemento(Consultas.BUSQUEDA_SONDA_VESICAL,
                                   params,
                                   AddressOf cargarSonda,
                                   TitulosForm.BUSQUEDA_SONDA,
                                   False, 0, True)
            Else

                General.buscarElemento(Consultas.BUSQUEDA_VENOPUNCION,
                                   params,
                                   AddressOf cargarVenoPuncion,
                                   TitulosForm.BUSQUEDA_VENOPUNCION,
                                   False, 0, True)
            End If

        Else

            MsgBox(Mensajes.SINPERMISO)
        End If

    End Sub

    Private Sub cargarSonda(pCodigo)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Label8.Visible = False
        fechar.Visible = False
        General.llenarTabla(Consultas.SONDA_VESICAL_CARGAR, params, dtsonda)
        txtcodigo.Text = pCodigo
        GroupBox5.Visible = False
        For i = 0 To dtsonda.Rows.Count - 1
            If dtsonda.Rows(i).Item(1).ToString.Contains("micro") And dtsonda.Rows(i).Item(2) = True Then
                GroupBox5.Visible = True
            End If
            If dtsonda.Rows(i).Item(1).ToString.Contains("retir") And dtsonda.Rows(i).Item(2) = True Then
                fechar.Visible = True
                Label8.Visible = True
                txtcual.Text = dtsonda.Rows(0).Item("Microorganismo")
                fechar.Text = dtsonda.Rows(0).Item("Fecha_Retiro").ToString
            End If
        Next
        dgvsonda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvsonda.AllowUserToResizeColumns = False
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btimprimir.Enabled = True
    End Sub
    Private Sub cargarVenoPuncion(pCodigo)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.VENOPUNCION_CARGAR, params, dtsonda)
        txtcodigo.Text = pCodigo
        dgvsonda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvsonda.AllowUserToResizeColumns = False
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btimprimir.Enabled = True
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If tipoEntrada = Constantes.SONDA_VESICAL Then
            If btguardar.Enabled = True Then
                MsgBox("Por favor guarde la información ", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            btimprimir.Enabled = False
            Try
                Dim ruta, area, nombreArchivo As String
                area = ConstantesHC.NOMBRE_PDF_SONDA
                nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = IO.Path.GetTempPath() & nombreArchivo
                guardarSonda()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
            Cursor = Cursors.Default
        Else
            If btguardar.Enabled = True Then
                MsgBox("Por favor guarde la información ", MsgBoxStyle.Information)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            btimprimir.Enabled = False
            Try
                Dim ruta, area, nombreArchivo As String
                area = ConstantesHC.NOMBRE_PDF_VENO
                nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = IO.Path.GetTempPath() & nombreArchivo

                guardarVenopuncion()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub guardarSonda()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_SONDA, txtregistro.Text, New rptSonda_Vesical,
                                    txtcodigo.Text, "{VISTA_SONDA_VESICAL.Codigo_Sonda} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_SONDA, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub guardarVenopuncion()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_VENO, txtregistro.Text, New rptVenopuncion,
                                    txtcodigo.Text, "{VISTA_VENOPUNCION.Codigo_Venopuncion} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_VENO, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub checkseleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles checkseleccionar.CheckedChanged
        If checkseleccionar.Checked = True Then
            For i = 0 To dgvsonda.Rows.Count - 1
                dgvsonda.Rows(i).Cells("Respuesta").Value = True
                checkseleccionar.Text = "Deshabilitar todo"
                validarCheck(i)
            Next
        Else
            For i = 0 To dgvsonda.Rows.Count - 1
                dgvsonda.Rows(i).Cells("Respuesta").Value = False
                checkseleccionar.Text = "Habilitar todo"
                validarCheck(i)
            Next
        End If
    End Sub

    Public Sub llenarVenopuncion()
        General.llenarTabla(Consultas.VENOPUNCION_CARGAR2, Nothing, dtsonda)
        dgvsonda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvsonda.AllowUserToResizeColumns = False
    End Sub

    Private Sub TXTFECHACOLOCA_ValueChanged(sender As Object, e As EventArgs) Handles TXTFECHACOLOCA.ValueChanged

    End Sub

    Private Sub fechar_ValueChanged(sender As Object, e As EventArgs) Handles fechar.ValueChanged

    End Sub

    Private Sub TXTFECHACOLOCA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTFECHACOLOCA.Validating
        If TXTFECHACOLOCA.Text < CDate(txtfecha.Text).Date Then
            MsgBox("No puede colocar una fecha menor a la de admision", MsgBoxStyle.Exclamation)
            TXTFECHACOLOCA.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        End If
    End Sub

    Private Sub fechar_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechar.Validating
        If fechar.Text < CDate(txtfecha.Text).Date Then
            MsgBox("No puede colocar una fecha menor a la de admision", MsgBoxStyle.Exclamation)
            fechar.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        End If
    End Sub

    Private Sub dgvsondaVerificar(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsonda.CellContentClick
        If e.ColumnIndex = 2 Then
            validarCheck(dgvsonda.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub validarCheck(i As Integer)
        If dtsonda.Rows.Count > 0 Then
            dgvsonda.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvsonda.EndEdit()


            If dgvsonda.Rows(i).Cells(1).Value.ToString.Contains("se retir") Then
                If dgvsonda.Rows(i).Cells(2).Value = True Then
                    fechar.Visible = True
                    Label8.Visible = True
                Else
                    Label8.Visible = False
                    fechar.Visible = False
                End If
            End If
            If dgvsonda.Rows(i).Cells(1).Value.ToString.Contains("microorganismo") Then
                If dgvsonda.Rows(i).Cells(2).Value = True Then
                    GroupBox5.Visible = True
                Else
                    GroupBox5.Visible = False
                    txtcual.Clear()
                End If
            End If
        End If

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvsonda.EndEdit()
        dtsonda.AcceptChanges()
        If dtsonda.Select("respuesta=false").Count = dtsonda.Rows.Count Then
            MsgBox("Debe seleccionar algun registro", MsgBoxStyle.Exclamation)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                If tipoEntrada = Constantes.SONDA_VESICAL Then

                    SondaVesicalBLL.guardarSonda(txtcodigo, txtregistro.Text, TXTFECHACOLOCA.Text, txtcual.Text, fechar.Value, SesionActual.idUsuario, dgvsonda.DataSource)
                    If txtcodigo.Text <> "" Then
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        btguardar.Enabled = False
                        bteditar.Enabled = True
                        btanular.Enabled = True
                        btnuevo.Enabled = True
                        btcancelar.Enabled = False
                        TXTFECHACOLOCA.Enabled = False
                        btbuscar.Enabled = True
                        deshabilitarControl()
                        btimprimir.Enabled = True
                        fechar.Enabled = False
                        txtcual.ReadOnly = True
                    End If
                ElseIf tipoEntrada = Constantes.VENOPUNCION Then
                    SondaVesicalBLL.guardarVeno(txtcodigo, txtregistro.Text, CDate(TXTFECHACOLOCA.Text), SesionActual.idUsuario, dgvsonda.DataSource)
                    If txtcodigo.Text <> "" Then
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        btguardar.Enabled = False
                        bteditar.Enabled = True
                        btanular.Enabled = True
                        btnuevo.Enabled = True
                        btcancelar.Enabled = False
                        TXTFECHACOLOCA.Enabled = False
                        btbuscar.Enabled = True
                        deshabilitarControl()
                        btimprimir.Enabled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then

            btguardar.Enabled = True
            dgvsonda.ReadOnly = False
            btcancelar.Enabled = True
            Label8.Visible = False
            fechar.Visible = False
            dgvsonda.Columns(0).ReadOnly = True
            dgvsonda.Columns(1).ReadOnly = True
            TXTFECHACOLOCA.Enabled = True
            btanular.Enabled = False
            txtcual.Clear()
            GroupBox5.Visible = False
            btimprimir.Enabled = False
            btbuscar.Enabled = False
            bteditar.Enabled = False
            btnuevo.Enabled = False
            txtcodigo.Clear()
            checkseleccionar.Enabled = True
            If tipoEntrada = Constantes.SONDA_VESICAL Then
                llenarSondaVesical()
                dgvsonda.Columns(2).ReadOnly = False
            Else
                llenarVenopuncion()
                dgvsonda.Columns(2).ReadOnly = False
            End If

        Else
            MsgBox(Mensajes.SINPERMISO)
        End If

    End Sub
End Class