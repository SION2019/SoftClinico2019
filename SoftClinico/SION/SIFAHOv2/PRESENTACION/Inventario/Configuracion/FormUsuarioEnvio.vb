Public Class FormUsuarioEnvio
    Dim objConfiguracionEnvioCorreos As New UsuarioEnvioCorreo
    Dim objUsuarioEnvioCorreoBLL As New UsuarioEnvioCorreoBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, PBuscar, Peditar, Panular, pBuscarEmpleado As String
    Dim enlaceTabla As New BindingSource
#Region "Metodos"
    Sub listarForms()
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CORREO_CONFIGURACION_LISTAR_FORMULARIOS, params, objConfiguracionEnvioCorreos.tblFormularios)

    End Sub
    Sub configurarDgv()
        With dgvproductos
            .Columns("Codigo_Menu").DataPropertyName = "codigo_Menu"
            .Columns("Codigo_Menu").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion_menu").DataPropertyName = "Descripcion_menu"
            .Columns("Descripcion_menu").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("formulario").DataPropertyName = "formulario"
            .Columns("formulario").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Modulo").DataPropertyName = "Modulo"
            .Columns("Modulo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Asignar").DataPropertyName = "Asignar"
            .Columns("Asignar").SortMode = DataGridViewColumnSortMode.NotSortable
            .DataSource = enlaceTabla
        End With
        General.diseñoDGV(dgvproductos)
    End Sub
    Sub guardarConfiguracion()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                empalmarDiseñoToObjeto()
                objUsuarioEnvioCorreoBLL.guardarConfiguracion(objConfiguracionEnvioCorreos, SesionActual.idUsuario)
                General.posGuardarForm(Me, ToolStrip1, bteditar, btanular, Nothing, Nothing)
                cargarConfiguracionCorreo(objConfiguracionEnvioCorreos.CodigoConfiguracion)
                empalmarObjetoToDeseño()
                txtBusqueda.ResetText()
            End If
        Catch ex As Exception
            MsgBox(MsgBox(ex.Message))
        End Try
    End Sub
    Sub llenarTablaForm()
        listarForms()
        configurarDgv()
    End Sub
    Sub empalmarObjetoToDeseño()
        txtCodigo.Text = objConfiguracionEnvioCorreos.CodigoConfiguracion
        txtEmail.Text = objConfiguracionEnvioCorreos.email
        txtPass.Text = objConfiguracionEnvioCorreos.contreseña
        dpFechaCorreo.Value = objConfiguracionEnvioCorreos.fechaConf
        txtIdEmpleado.Text = objConfiguracionEnvioCorreos.idTerceroAsignado
        txtAsunto.Text = objConfiguracionEnvioCorreos.asunto
    End Sub
    Sub empalmarDiseñoToObjeto()
        objConfiguracionEnvioCorreos.idTerceroAsignado = txtIdEmpleado.Text
        objConfiguracionEnvioCorreos.CodigoConfiguracion = txtCodigo.Text
        objConfiguracionEnvioCorreos.email = txtEmail.Text
        objConfiguracionEnvioCorreos.contreseña = txtPass.Text
        objConfiguracionEnvioCorreos.fechaConf = dpFechaCorreo.Value
        objConfiguracionEnvioCorreos.asunto = txtAsunto.Text
    End Sub
    Sub inicializarForm()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pBuscarEmpleado = permiso_general & "pp" & "05"
        enlaceTabla.DataSource = objConfiguracionEnvioCorreos.tblFormularios
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        traerUsuarioActual()
        txtBusqueda.ReadOnly = False
    End Sub
    Sub traerUsuarioActual()
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(SesionActual.idUsuario)
        fila = General.cargarItem(Consultas.CORREO_CONFIGURACION_USUARIO_DEFAULT, params)
        If Not IsNothing(fila) Then
            objConfiguracionEnvioCorreos.idTerceroAsignado = fila.Item(0)
            txtIdEmpleado.Text = fila.Item(0)
            txtEmpleado.Text = fila.Item(1)
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            llenarTablaForm()
            deshbilitarControlesUsuario()
            traerUsuarioActual()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvproductos.EndEdit()
        objConfiguracionEnvioCorreos.tblFormularios.AcceptChanges()
        If txtEmail.Text.Equals("") Then
            General.mensajeValidacion("Debe colocar el usuario del correo !")
            Exec.SacudirCrtl(txtEmail)
        ElseIf Funciones.esCorreoValido(txtEmail.Text) = False Then
            General.mensajeValidacion("Correo no valido !")
            Exec.SacudirCrtl(txtEmail)
        ElseIf txtPass.Text.Equals("") Then
            General.mensajeValidacion("Debe colocar la contraseña del correo !")
            Exec.SacudirCrtl(txtPass)
        ElseIf txtAsunto.Text.Equals("") Then
            General.mensajeValidacion("Debe colocar el asunto del correo !")
            Exec.SacudirCrtl(txtAsunto)
        ElseIf objConfiguracionEnvioCorreos.tblFormularios.Select("Asignar = True").Count = 0 Then
            General.mensajeValidacion("Debe escoger por lo menos un formulario !")
            Exec.SacudirCrtl(dgvproductos)
        Else
            guardarConfiguracion()
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                Dim tablaRestantes As New DataTable
                Dim params As New List(Of String)
                params.Add(objConfiguracionEnvioCorreos.CodigoConfiguracion)
                params.Add(SesionActual.codigoEP)
                General.llenarTabla(Consultas.CORREO_CONFIGURACION_CARGAR_INFORMACION_RESTANTE, params, tablaRestantes, True)
                For indiceFila = 0 To tablaRestantes.Rows.Count - 1
                    objConfiguracionEnvioCorreos.tblFormularios.ImportRow(tablaRestantes.Rows(indiceFila))
                Next
                deshbilitarControlesUsuario()
                traerUsuarioActual()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub deshbilitarControlesUsuario()
        txtIdEmpleado.ReadOnly = True
        txtEmpleado.ReadOnly = True
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    empalmarDiseñoToObjeto()
                    objUsuarioEnvioCorreoBLL.anularConfiguracion(objConfiguracionEnvioCorreos, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub BtbuscarEmpleado_Click(sender As Object, e As EventArgs) Handles BtbuscarEmpleado.Click
        If SesionActual.tienePermiso(pBuscarEmpleado) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.idEmpresa)
            General.buscarItem(Consultas.CORREO_CONFIGURACION_LISTAR_EMPLEADOS,
                                        params,
                                        AddressOf colocarEmpleado,
                                        TitulosForm.BUSQUEDA_EMPLEADO_HC,
                                        True,
                                        Constantes.TAMANO_MEDIANO,
                                        True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub colocarEmpleado(ByVal fila As DataRow)
        If Not IsNothing(fila) Then
            objConfiguracionEnvioCorreos.idTerceroAsignado = fila.Item(0)
            txtIdEmpleado.Text = fila.Item(0)
            txtEmpleado.Text = fila.Item(1)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            params.Add(SesionActual.idUsuario)
            General.buscarElemento(Consultas.CORREO_CONFIGURACION_BUSCAR,
                                   params,
                                   AddressOf cargarConfiguracionCorreo,
                                   TitulosForm.BUSQUEDA_CONFIGURACION_CORREO,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cargarConfiguracionCorreo(ByVal codigoConfiguracion As String)
        objConfiguracionEnvioCorreos.CodigoConfiguracion = codigoConfiguracion
        Dim params As New List(Of String)
        params.Add(objConfiguracionEnvioCorreos.CodigoConfiguracion)
        Dim fila As DataRow = General.cargarItem(Consultas.CORREO_CONFIGURACION_CARGAR_INFORMACION, params)
        If Not IsNothing(fila) Then
            objConfiguracionEnvioCorreos.email = fila.Item(1)
            objConfiguracionEnvioCorreos.contreseña = fila.Item(2)
            objConfiguracionEnvioCorreos.fechaConf = fila.Item(3)
            objConfiguracionEnvioCorreos.idTerceroAsignado = fila.Item(4)
            txtEmpleado.Text = fila.Item(5)
            objConfiguracionEnvioCorreos.asunto = fila.Item(6).ToString
            General.llenarTabla(Consultas.CORREO_CONFIGURACION_CARGAR_INFORMACION_DETALLE, params, objConfiguracionEnvioCorreos.tblFormularios)
            configurarDgv()
        End If
        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btbuscar, btanular)
        empalmarObjetoToDeseño()
        txtBusqueda.ReadOnly = False
    End Sub
#End Region
#Region "Otros Eventos"
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        enlaceTabla.Filter = "convert([Descripcion_menu], System.String) like '%" & txtBusqueda.Text & "%' or " &
                             "convert([Modulo], System.String) like '%" & txtBusqueda.Text & "%'"
    End Sub
    Private Sub FormUsuarioEnvio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#End Region
#Region "Funciones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#End Region

End Class