Public Class Form_Curaciones
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim fechaAdmi As Date
    Dim modulo As String
    Private Sub Form_Curaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_AUXILIAR_DE_ENFERMERIA & "," & Constantes.CARGO_JEFE_DE_ENFERMERIA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", Comboenfer)
    End Sub
    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub
    Public Sub habilitarControles()
        descripcion.ReadOnly = False
        fechavalor.Enabled = True
        Comboenfer.Enabled = True
    End Sub

    Public Sub limpiar()
        txtcodigo.Clear()
        descripcion.Clear()
        Comboenfer.SelectedValue = -1
    End Sub

    Private Sub Form_Curaciones_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.habilitarControles(Me)
            limpiar()
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btanular.Enabled = False
            txteps.ReadOnly = True
            bteditar.Enabled = False
            btnuevo.Enabled = False
            btbuscar.Enabled = False
            btimprimir.Enabled = False
            txtregistro.ReadOnly = True
            txtpaciente.ReadOnly = True
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
            btimprimir.Enabled = False
            btnuevo.Enabled = True
            btguardar.Enabled = False
            limpiar()
            txtcodigo.Clear()
        End If
    End Sub

    Public Function crearCuraciones() As Curacion
        Dim objCuracion = New Curacion
        objCuracion.codigoCuracion = txtcodigo.Text
        objCuracion.descripcion = descripcion.Text
        objCuracion.fechaCuracion = fechavalor.Value
        objCuracion.Registro = txtregistro.Text
        objCuracion.usuario = SesionActual.idUsuario
        objCuracion.enfermera = Comboenfer.SelectedValue

        Return objCuracion
    End Function

    Public Sub crearCuracion()
        Dim objCuracion_D As New CuracionBLL
        Dim objCuracion As Curacion

        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objCuracion = crearCuraciones()
                objCuracion_D.crearCuracion(objCuracion)
                txtcodigo.Text = objCuracion.codigoCuracion

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btimprimir.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Function validarControles()
        If String.IsNullOrEmpty(descripcion.Text) Then
            MsgBox("El campo descripcion se encuentra vacio", MsgBoxStyle.Exclamation)
            descripcion.Focus()
            Return False
        ElseIf Comboenfer.SelectedIndex < 1 Then
            MsgBox("Debe seleccionar la enfermera", MsgBoxStyle.Exclamation)
            Comboenfer.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarControles() Then
            crearCuracion()
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim lista As New List(Of String)
                lista.Add(txtcodigo.Text)
                lista.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_CURACION, lista)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                limpiar()
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btguardar.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btimprimir.Enabled = False
                btanular.Enabled = False
                txtcodigo.Clear()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del curacion", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_CURACION
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            guardarReporte()

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub


    Private Sub guardarReporte()
        Try
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_CURACION, txtcodigo.Text, New rptCuracion,
                                    txtcodigo.Text, "{VISTA_CURACION.Codigo_Curacion} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_CURACION, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub fechavalor_ValueChanged(sender As Object, e As EventArgs) Handles fechavalor.ValueChanged
        If fechavalor.Value < fechaAdmi Then
            MsgBox("La fecha de curacion no puede ser menor a la fecha admision", MsgBoxStyle.Exclamation)
            fechavalor.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.habilitarControles(Me)
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btnuevo.Enabled = False
            btbuscar.Enabled = False
            bteditar.Enabled = False
            txtregistro.ReadOnly = True
            txtpaciente.ReadOnly = True
            txteps.ReadOnly = True
            btanular.Enabled = False
            btimprimir.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarPaciente(codigo As String, nombre As String, eps As String, fechaAdmision As Date)
        txtregistro.Text = codigo
        txtpaciente.Text = nombre
        txteps.Text = eps
        fechaAdmi = fechaAdmision
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim param As New List(Of String)
            param.Add(txtregistro.Text)
            General.buscarElemento(Consultas.BUSCAR_CURACION_CARGAR, param,
                                   AddressOf cargarRegistro,
                                   TitulosForm.BUSQUEDA_CURACION, 0, 0, True)


        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Public Sub cargarRegistro()
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.BUSCAR_CURACION_CARGAR2 & txtregistro.Text, dt)
        txtcodigo.Text = dt.Rows(0).Item("Código").ToString
        fechavalor.Value = CDate(dt.Rows(0).Item("Fecha Curacion")).ToString
        descripcion.Text = dt.Rows(0).Item("Descripcion").ToString
        Comboenfer.SelectedValue = dt.Rows(0).Item("Enfermera").ToString
        If txtcodigo.Text <> "" Then
            bteditar.Enabled = True
            btanular.Enabled = True
            btcancelar.Enabled = False
            btguardar.Enabled = False
            btnuevo.Enabled = True
            btimprimir.Enabled = True
            General.deshabilitarControles(Me)
        End If
    End Sub
End Class