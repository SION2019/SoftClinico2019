Public Class FormConfiguracionRips
    Private objRips As New Rips
    Dim posicionFin, posicionInicial As Integer
    Public Property formRips As FormRips
    Private Sub FormConfiguracionRips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.cargarCombo(Consultas.COMBO_CARGAR_ARCHIVOS_RIPS, "Siglas", "Codigo_Tipo_Rip", combodocumento)
        ListOrden.DataSource = objRips.dtListaConfigurada
        General.deshabilitarControles(Me)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
    Public Sub cargarListaOrden()
        objRips.cargarListaParametro()
    End Sub

    Private Sub ListOrden_MouseUp(sender As Object, e As MouseEventArgs) Handles ListOrden.MouseUp
        posicionFin = ListOrden.SelectedIndex

        IntercambiarPosicion()
        Cursor = Cursors.Default
    End Sub

    Private Sub IntercambiarPosicion()
        If posicionFin <> posicionInicial Then

            Dim filaNueva As DataRow = objRips.dtListaConfigurada.NewRow
            Dim filaAnterior As DataRow = objRips.dtListaConfigurada.NewRow
            filaNueva("Codigo_parametro") = objRips.dtListaConfigurada.Rows(posicionInicial).Item("Codigo_parametro")
            filaNueva("Descripcion") = objRips.dtListaConfigurada.Rows(posicionInicial).Item("Descripcion")
            filaAnterior("Codigo_parametro") = objRips.dtListaConfigurada.Rows(posicionFin).Item("Codigo_parametro")
            filaAnterior("Descripcion") = objRips.dtListaConfigurada.Rows(posicionFin).Item("Descripcion")
            If posicionFin > posicionInicial Then
                objRips.dtListaConfigurada.Rows.InsertAt(filaNueva, posicionFin)
                objRips.dtListaConfigurada.Rows.RemoveAt(posicionInicial)
                objRips.dtListaConfigurada.Rows.RemoveAt(posicionFin)
                objRips.dtListaConfigurada.Rows.InsertAt(filaAnterior, posicionInicial)

            Else
                objRips.dtListaConfigurada.Rows.InsertAt(filaNueva, posicionFin)
                objRips.dtListaConfigurada.Rows.RemoveAt(posicionInicial + 1)
                objRips.dtListaConfigurada.Rows.RemoveAt(posicionFin + 1)
                objRips.dtListaConfigurada.Rows.InsertAt(filaAnterior, posicionInicial)
                ListOrden.SelectedIndex = posicionFin
            End If

        End If
    End Sub

    Private Sub IntercambiarRegistroLista(ByRef dtOrigen As DataTable, ByRef dtDestino As DataTable, posicionLista As Integer)

        Dim filaNueva As DataRow = dtDestino.NewRow
        filaNueva("Codigo_parametro") = dtOrigen.Rows(posicionLista).Item("Codigo_parametro")
        filaNueva("Descripcion") = dtOrigen.Rows(posicionLista).Item("Descripcion")

        dtDestino.Rows.InsertAt(filaNueva, dtDestino.Rows.Count)
        dtOrigen.Rows.RemoveAt(posicionLista)

    End Sub

    Private Sub ListOrden_MouseDown(sender As Object, e As MouseEventArgs) Handles ListOrden.MouseDown
        posicionInicial = ListOrden.SelectedIndex
        Cursor = Cursors.Hand
    End Sub

    Private Sub btsubirlista_Click(sender As Object, e As EventArgs) Handles btsubirlista.Click
        If ListOrden.SelectedIndex <> 0 Then
            posicionInicial = ListOrden.SelectedIndex
            posicionFin = ListOrden.SelectedIndex - 1
            IntercambiarPosicion()
        End If
    End Sub

    Private Sub btbajarlista_Click(sender As Object, e As EventArgs) Handles btbajarlista.Click
        If ListOrden.SelectedIndex <> ListOrden.Items.Count - 1 Then
            posicionInicial = ListOrden.SelectedIndex
            posicionFin = ListOrden.SelectedIndex + 1
            IntercambiarPosicion()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btpasar.Click, btretroceder.Click
        If btpasar.Focused = True Then
            IntercambiarRegistroLista(objRips.dtLista, objRips.dtListaConfigurada, listado.SelectedIndex)
        ElseIf btretroceder.Focused = True Then
            IntercambiarRegistroLista(objRips.dtListaConfigurada, objRips.dtLista, ListOrden.SelectedIndex)
        End If
    End Sub

    Private Sub btretroceder_Click(sender As Object, e As EventArgs) Handles btretroceder.Click

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.habilitarControles(Me)
        General.limpiarControles(Me)
        objRips.dtListaConfigurada.Clear()
        btguardar.Enabled = False
        txtgrupo.ReadOnly = True
        txtdescripcion.ReadOnly = True
        bteditar.Enabled = False
        btnuevo.Enabled = False
        btcancelar.Enabled = True
        btretroceder.Enabled = False
        btsubirlista.Enabled = False
        btbajarlista.Enabled = False
        btpasar.Enabled = False
    End Sub

    Public Function validar()
        If txtdescripcion.Text = "" Then
            MsgBox("El campo descripcion se encuentra vacio", MsgBoxStyle.Exclamation)
            txtdescripcion.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub guardar()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                If String.IsNullOrEmpty(txtgrupo.Text) Then
                    objRips.codigoGrupo = -1
                Else
                    objRips.codigoGrupo = txtgrupo.Text
                End If
                objRips.usuario = SesionActual.idUsuario
                objRips.codigoTipoRips = combodocumento.SelectedValue
                objRips.descripcion = txtdescripcion.Text
                objRips.guardarConfiguracion(formRips)
                txtgrupo.Text = objRips.codigoGrupo
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                btguardar.Enabled = False
                General.deshabilitarControles(Me)
                ListOrden.Enabled = False
                listado.Enabled = False
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                combodocumento.Enabled = True

            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validar() Then
            guardar()
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea Cancelar este registro?", 32 + 1, "Cancelar") = 1 Then
            bteditar.Enabled = False
            btguardar.Enabled = False
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            btcancelar.Enabled = False
            General.deshabilitarControles(Me)
            objRips.dtListaConfigurada.Clear()
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(Consultas.RIPS_FORMATO_CARGAR,
                          Nothing,
                          AddressOf cargar,
                          TitulosForm.BUSQUEDA_CONFIGURACION_RIPS,
                          True, 0, True)
        btguardar.Enabled = False
        bteditar.Enabled = False
        btcancelar.Enabled = False
        btnuevo.Enabled = True
        listado.Enabled = False
        ListOrden.Enabled = False
        combodocumento.Enabled = True
        txtdescripcion.ReadOnly = True
        btpasar.Enabled = False
        btretroceder.Enabled = False
        btsubirlista.Enabled = False
        btbajarlista.Enabled = False
    End Sub
    Public Sub cargar(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.RIPS_CONFIGURACION_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txtgrupo.Text = dt.Rows(0).Item("Codigo_grupo").ToString
            txtdescripcion.Text = dt.Rows(0).Item("descripcion").ToString
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If SesionActual.tienePermiso(Peditar ) Then

        combodocumento.Enabled = True
            ListOrden.Enabled = True
            listado.Enabled = True
            bteditar.Enabled = False
            btpasar.Enabled = True
            btretroceder.Enabled = True
            btsubirlista.Enabled = True
            btbajarlista.Enabled = True
        btnuevo.Enabled = False
        btcancelar.Enabled = True
            btguardar.Enabled = True
            bteditar.Enabled = False
            btbuscar.Enabled = False

        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub

    Public Sub combodocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodocumento.SelectedIndexChanged
        If combodocumento.SelectedIndex = 0 Then
            objRips.dtLista.Clear()
            btguardar.Enabled = False
        Else
            objRips.codigoTipoRips = combodocumento.SelectedValue
            objRips.codigoGrupo = CInt(If(String.IsNullOrEmpty(txtgrupo.Text), 0, txtgrupo.Text))
            cargarListaOrden()
            listado.DataSource = objRips.dtLista
            listado.DisplayMember = "Descripcion"
            listado.ValueMember = "Codigo_parametro"
            objRips.cargarListaConfigurada()
            ListOrden.DataSource = objRips.dtListaConfigurada
            ListOrden.DisplayMember = "Descripcion"
            ListOrden.ValueMember = "Codigo_parametro"

            btguardar.Enabled = False
            bteditar.Enabled = True
            ListOrden.Enabled = False
            listado.Enabled = False
            btnuevo.Enabled = True
            btpasar.Enabled = False
            btcancelar.Enabled = False
            btbuscar.Enabled = True
            btretroceder.Enabled = False
            btsubirlista.Enabled = False
            btbajarlista.Enabled = False
            If String.IsNullOrEmpty(txtgrupo.Text) Then
                ListOrden.Enabled = True
                listado.Enabled = True
                btpasar.Enabled = True
                btretroceder.Enabled = True
                btsubirlista.Enabled = True
                btbajarlista.Enabled = True
                txtdescripcion.ReadOnly = False
                btnuevo.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = True
                btguardar.Enabled = True
            End If
        End If
    End Sub


End Class