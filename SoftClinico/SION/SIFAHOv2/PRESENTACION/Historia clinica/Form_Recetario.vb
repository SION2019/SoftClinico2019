Public Class Form_Recetario
    Dim objRecetario As New RecetarioBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim reporte As New ftp_reportes
    Dim usuarioReal As Integer
    Dim modulo As String
    Private Sub Form_Recetario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
    End Sub

    Public Sub cargarModulo(tag As String)
        modulo = tag
    End Sub
    Public Function validar()
        If txtobservacion.Text = "" Then
            MsgBox("El campo observacion se encuentra vacio", MsgBoxStyle.Exclamation)
            txtobservacion.Focus()
            Return False
        End If
        Return True
    End Function
    Public Function Recetario() As Recetario
        Dim objRecetario = New Recetario
        objRecetario.registro = txtregistro.Text
        objRecetario.resultado = txtobservacion.Text
        objRecetario.usuario = SesionActual.idUsuario
        objRecetario.usuarioReal = usuarioReal
        Return objRecetario
    End Function


    Public Sub cargarDatos(registro As String, identificacion As String, sexo As String, nombre As String, edad As String, contrato As String, nombrecontrato As String, usuario As Integer)
        txtregistro.Text = registro
        txtidentificacion.Text = identificacion
        txtsexo.Text = sexo
        txtpaciente.Text = nombre
        txtedad.Text = edad
        txtcodigocontrato.Text = contrato
        txtcontrato.Text = nombrecontrato
        usuarioReal = usuario
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            btnuevo.Enabled = False
            btguardar.Enabled = True
            btbuscar.Enabled = False
            txtCodigo.Clear()
            btcancelar.Enabled = True
            btanular.Enabled = False
            txtobservacion.Clear()
            btimprimir.Enabled = False
            bteditar.Enabled = False
            habilitarControles()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub deshabilitarControles()
        txtobservacion.ReadOnly = True
    End Sub
    Private Sub habilitarControles()
        txtobservacion.ReadOnly = False
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            btbuscar.Enabled = True
            btnuevo.Enabled = True
            btguardar.Enabled = False
            txtobservacion.Clear()
            txtCodigo.Clear()
        End If
    End Sub
    Private Sub Form_recetario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim lista As New List(Of String)
                lista.Add(txtCodigo.Text)
                lista.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_RECETARIO, lista)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btguardar.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
                txtCodigo.Clear()
                txtobservacion.Clear()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del recetario", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_RECETARIO
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtCodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarRecetario()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarRecetario()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_RECETARIO, txtCodigo.Text, New rptRecetario,
                                    txtCodigo.Text, "{VISTA_RECETARIO.codigo_Recetario} = " & txtCodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_RECETARIO, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validar() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objRecetario.crearRecetario(Recetario(), txtCodigo)
                If txtCodigo.Text <> "" Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    btimprimir.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.deshabilitarBotones(ToolStrip1)
            habilitarControles()
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
            bteditar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            btnuevo.Enabled = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim param As New List(Of String)
            param.Add(txtregistro.Text)
            General.buscarElemento(Consultas.BUSCAR_RECETARIO, param,
                                   AddressOf cargarRegistro,
                                   TitulosForm.BUSQUEDA_RECETARIO, 0, 0, True)
            If txtCodigo.Text <> "" Then
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btanular.Enabled = True
                btimprimir.Enabled = True
                General.deshabilitarControles(Me)
            End If

        Else
               MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarRegistro(codigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.BUSCAR_RECETARIO_CARGAR, params, dt)
        txtCodigo.Text = dt.Rows(0).Item("Código").ToString
        txtobservacion.Text = dt.Rows(0).Item("Observacion").ToString
    End Sub
End Class