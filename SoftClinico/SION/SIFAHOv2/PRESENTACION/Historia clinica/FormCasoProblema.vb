Public Class FormCasoProblema
    Dim objCasoProblema As CasoProblema
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim reporte As New ftp_reportes
    Dim usuarioReal As Integer
    Dim modulo As String
    Private Sub Form_Recetario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objCasoProblema = New CasoProblema
        asignarPermiso()
        iniciarFormulario()
    End Sub
    Private Sub iniciarFormulario()
        objCasoProblema.codigoEmpleado = SesionActual.idUsuario
        txtEmpleado.Text = SesionActual.nombreCompleto
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub asignarPermiso()
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
    Public Function validar()
        If txtobservacion.Text = String.Empty Then
            MsgBox("El campo observacion se encuentra vacio", MsgBoxStyle.Exclamation)
            txtobservacion.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        'If SesionActual.tienePermiso(Pnuevo) Then
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(gbObservacion)
        btBuscarEmpleado.Enabled = True
        btguardar.Enabled = True
        btcancelar.Enabled = True
        objCasoProblema.codigo = Nothing
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            iniciarFormulario()
            General.limpiarControles(Me)
            objCasoProblema.codigo = Nothing
        End If
    End Sub
    Private Sub FormCasoProblema_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'If SesionActual.tienePermiso(Panular) Then
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Dim lista As New List(Of String)
            lista.Add(objCasoProblema.codigo)
            lista.Add(SesionActual.idUsuario)
            General.ejecutarSQL("[PROC_CASO_PROBLEMA_ANULAR]", lista)
            General.limpiarControles(Me)
            iniciarFormulario()
            objCasoProblema.codigo = Nothing
            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            End If
        'Else
        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        'If btguardar.Enabled = True Then
        '    MsgBox("Por favor guarde el caso ", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_CASO_PROBLEMA
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & objCasoProblema.codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_CASO_PROBLEMA, objCasoProblema.codigo, New rptCasoProblema,
                                    objCasoProblema.codigo, " {VISTA_CASO_PROBLEMA.Codigo_Caso}= " & objCasoProblema.codigo & "",
                                    ConstantesHC.NOMBRE_PDF_CASO_PROBLEMA, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub btBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles btBuscarEmpleado.Click
        usuarioEmpleado()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validar() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                cargarObjeto()
                CasoProblemaBLL.guardarCasoProblema(objCasoProblema)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        '    If SesionActual.tienePermiso(Peditar) Then
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(gbObservacion)
        btBuscarEmpleado.Enabled = True
        btguardar.Enabled = True
        btcancelar.Enabled = True
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If SesionActual.tienePermiso(PBuscar) Then
        Dim param As New List(Of String)
        param.Add(txtregistro.Text)
        param.Add(String.Empty)
        General.buscarElemento("[PROC_CASO_PROBLEMA_BUSCAR]", param,
                                   AddressOf cargarRegistro,
                                   TitulosForm.BUSQUEDA_CASO_PROBLEMA,
                                   0,
                                   0,
                                   True)
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Sub cargarObjeto()
        objCasoProblema.nRegistro = txtregistro.Text
        objCasoProblema.Observacion = txtobservacion.Text
    End Sub
    Private Sub cargarRegistro(codigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        Try
            General.llenarTabla("[PROC_CASO_PROBLEMA_CARGAR]", params, dt)
            objCasoProblema.codigo = codigo
            txtobservacion.Text = dt.Rows(0).Item("Observacion").ToString
            objCasoProblema.codigoEmpleado = dt.Rows(0).Item("Usuario_real").ToString
            txtEmpleado.Text = dt.Rows(0).Item("Empleado").ToString
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
    End Sub
    Private Function usuarioEmpleado() As Boolean
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        Dim estado As Boolean
        params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC,
                                                                          params,
                                                                          TitulosForm.BUSQUEDA_EMPLEADO_HC,
                                                                          True,,
                                                                          True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objCasoProblema.codigoEmpleado = tbl(0)
            txtEmpleado.Text = tbl(1)
            estado = True
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
        End If
        Return estado
    End Function
    Public Sub cargarDatos(registro As String,
                           identificacion As String,
                           sexo As String,
                           nombre As String,
                           edad As String,
                           contrato As String,
                           nombrecontrato As String)
        txtregistro.Text = registro
        txtidentificacion.Text = identificacion
        txtsexo.Text = sexo
        txtpaciente.Text = nombre
        txtedad.Text = edad
        txtcodigocontrato.Text = contrato
        txtcontrato.Text = nombrecontrato
    End Sub
End Class