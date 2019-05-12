Public Class FormReclamo
    Public objBuzon As New Buzon
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Private Sub FormReclamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        txtasunto.ReadOnly = True
        txtobservacion.ReadOnly = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormReclamo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Sub cargarMensajeRespuesta()
        objBuzon.codigo = textcodigo.Text

        objBuzon.CargarRespuesta()
        dgvMensaje.DataSource = objBuzon.dtRespuesta
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.habilitarControles(Me)
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btnuevo.Enabled = False
            bteditar.Enabled = False
            btbuscar.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = False
            btanular.Enabled = False
            btbuscar.Enabled = True
            btnuevo.Enabled = True
            btguardar.Enabled = False
            objBuzon.dtCargos.Clear()
            objBuzon.dtEmpleado.Clear()
            textcodigo.Clear()
            txtobservacion.Clear()
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            cargarCargos()
            General.habilitarControles(Me)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btanular.Enabled = False
            bteditar.Enabled = False
            btnuevo.Enabled = False
            txtobservacion.ReadOnly = False
            txtasunto.ReadOnly = False
            textcodigo.ReadOnly = True
            txtobservacion.Clear()
            txtasunto.Clear()
            textcodigo.Clear()
            objBuzon.dtEmpleado.Clear()
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvCargos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvCargos.EndEdit()
        dgvEmpleado.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvEmpleado.EndEdit()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objBuzon.idEmpresa = SesionActual.idEmpresa
                objBuzon.usuario = SesionActual.idUsuario
                objBuzon.fecha = Datefecha.Value.Date
                objBuzon.observacion = txtobservacion.Text
                objBuzon.codigo = textcodigo.Text
                objBuzon.asunto = txtasunto.Text
                objBuzon.guardar()
                textcodigo.Text = objBuzon.codigo
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = True
                btbuscar.Enabled = True
                btanular.Enabled = True
                btnuevo.Enabled = True
                cargarEmpleado()
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then

            General.buscarElemento(Consultas.BUZON_BUSCAR_DATOS, Nothing,
                                           AddressOf cargarBusqueda,
                                           TitulosForm.BUSQUEDA_BUZON,
                                           False, 0, True)
            If textcodigo.Text <> "" Then
                Checkseleccion.Enabled = False
                CheckBox2.Enabled = False
                btanular.Enabled = True
                Datefecha.Enabled = False
            End If

        Else

                MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarBusqueda(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.BUZON_BUSCAR_DATOS_CARGAR, params, dt)
        textcodigo.Text = pCodigo
        Datefecha.Value = dt.Rows(0).Item("Fecha")
        txtobservacion.Text = dt.Rows(0).Item("Observacion")
        txtasunto.Text = dt.Rows(0).Item("Asunto").ToString
        cargarCargo()
        cargarEmpleado()

        bteditar.Enabled = True
    End Sub

    Public Sub cargarCargo()
        Dim params As New List(Of String)
        params.Add(textcodigo.Text)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.BUZON_CARGO_CARGAR, params, objBuzon.dtCargos)
        dgvCargos.DataSource = objBuzon.dtCargos
        dgvCargos.Columns("Código").Visible = False
    End Sub

    Public Sub cargarEmpleado()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(textcodigo.Text)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.BUZON_CARGAR_EMPLEADO, params, objBuzon.dtEmpleado)
        dgvEmpleado.DataSource = objBuzon.dtEmpleado
        dgvEmpleado.Columns("Código").Visible = False
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim lista As New List(Of String)
                lista.Add(textcodigo.Text)
                lista.Add(SesionActual.idUsuario)
                lista.Add(SesionActual.idEmpresa)
                General.ejecutarSQL(Consultas.BUZON_ANULAR, lista)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btguardar.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btanular.Enabled = False
                textcodigo.Clear()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = True
    End Sub

    Private Sub BtSalirlOTES_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        cargarMensajeRespuesta()
        Panel2.Visible = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            For i = 0 To dgvEmpleado.Rows.Count - 1
                dgvEmpleado.Rows(i).Cells("Seleccionar").Value = True
                CheckBox2.Text = "Deshabilitar todo"
            Next
        Else
            For i = 0 To dgvEmpleado.Rows.Count - 1
                dgvEmpleado.Rows(i).Cells("Seleccionar").Value = False
                CheckBox2.Text = "Seleccionar todo"
            Next
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        cargarMensajeRespuesta()
    End Sub

    Private Sub dgvMensaje_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMensaje.CellDoubleClick
        General.abrirJustificacion(dgvMensaje, dgvMensaje.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Respuesta", Not btguardar.Enabled)
    End Sub

    Private Sub dgvMensaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvMensaje.KeyPress
        General.abrirJustificacion(dgvMensaje, dgvMensaje.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Respuesta", Not btguardar.Enabled, e.KeyChar)
    End Sub

    Public Sub cargarCargos()
        objBuzon.idEmpresa = SesionActual.idEmpresa
        objBuzon.buscarCargos()
        dgvCargos.DataSource = objBuzon.dtCargos
        dgvCargos.Columns("Código").Visible = False
        dgvCargos.ReadOnly = False
    End Sub

    Private Sub dgvCargos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCargos.CellContentClick
        dgvCargos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Dim seleccionados As String = ""
        For i = 0 To dgvCargos.Rows.Count - 1
            If dgvCargos.Rows(i).Cells("Seleccionar").Value = True Then
                If seleccionados.Length = 0 Then
                    seleccionados = dgvCargos.Rows(i).Cells("Código").Value
                Else
                    seleccionados = seleccionados & "," & dgvCargos.Rows(i).Cells("Código").Value
                End If
            End If
        Next
        If seleccionados <> "" Then
            objBuzon.codigoCargo = seleccionados
            objBuzon.buscarEmpleado()

            dgvEmpleado.DataSource = objBuzon.dtEmpleado
        Else
            objBuzon.dtEmpleado.Clear()
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Checkseleccion.CheckedChanged
        If Checkseleccion.Checked = True Then
            dgvCargos.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For i = 0 To dgvCargos.Rows.Count - 1
                dgvCargos.Rows(i).Cells("Seleccionar").Value = True
                Checkseleccion.Text = "Deshabilitar todo"
            Next
            dgvCargos.CommitEdit(DataGridViewDataErrorContexts.Commit)

            Dim seleccionados As String = ""
            For i = 0 To dgvCargos.Rows.Count - 1
                If dgvCargos.Rows(i).Cells("Seleccionar").Value = True Then
                    If seleccionados.Length = 0 Then
                        seleccionados = dgvCargos.Rows(i).Cells("Código").Value
                    Else
                        seleccionados = seleccionados & "," & dgvCargos.Rows(i).Cells("Código").Value
                    End If
                End If
            Next
            If seleccionados <> "" Then
                objBuzon.codigoCargo = seleccionados
                objBuzon.buscarEmpleado()

                dgvEmpleado.DataSource = objBuzon.dtEmpleado
            Else
                objBuzon.dtEmpleado.Clear()
            End If
        Else
            For i = 0 To dgvCargos.Rows.Count - 1
                dgvCargos.Rows(i).Cells("Seleccionar").Value = False
                Checkseleccion.Text = "Seleccionar todo"
            Next
            dgvCargos.CommitEdit(DataGridViewDataErrorContexts.Commit)

            Dim seleccionados As String = ""
            For i = 0 To dgvCargos.Rows.Count - 1
                If dgvCargos.Rows(i).Cells("Seleccionar").Value = True Then
                    If seleccionados.Length = 0 Then
                        seleccionados = dgvCargos.Rows(i).Cells("Código").Value
                    Else
                        seleccionados = seleccionados & "," & dgvCargos.Rows(i).Cells("Código").Value
                    End If
                End If
            Next
            If seleccionados <> "" Then
                objBuzon.codigoCargo = seleccionados
                objBuzon.buscarEmpleado()
                dgvEmpleado.DataSource = objBuzon.dtEmpleado

            Else
                objBuzon.dtEmpleado.Clear()
            End If
        End If
        dgvEmpleado.Columns("Código").Visible = False
    End Sub

    Private Sub btOpcionPresentacion_Click(sender As Object, e As EventArgs) Handles btOpcionPresentacion.Click
        Dim formImagen As New Form_resultado
        formImagen.ShowDialog()
    End Sub
End Class