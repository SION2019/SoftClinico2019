Public Class FormInterconsulta
    Dim objHistoriaClinica As HistoriaClinica
    Dim perG As New Buscar_Permisos_generales
    Public Property objInterconsulta As New InterconsultaMedica
    Public CodigoTemporal, moduloTemporal As String
    Public procedimientoInterconsulta As String
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigo As String
    Dim nombrePDF As String
    Public Sub cargarInterconsulta(codigoOrden As Integer, codigoProcedimiento As String)
        Dim consulta As String = String.Empty
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        params.Add(codigoProcedimiento)
        If moduloTemporal = Constantes.HC Then
            consulta = Consultas.INTERCONSULTA_CARGAR
        ElseIf moduloTemporal = Constantes.AM Then
            consulta = Consultas.INTERCONSULTA_CARGARR
        ElseIf moduloTemporal = Constantes.AF Then
            consulta = Consultas.INTERCONSULTA_CARGARRR
        End If
        General.llenarTabla(consulta, params, dt)
        If dt.Rows.Count > 0 Then
            txtInterconsultante.Text = dt.Rows(0).Item("Descripcion_Especialidad")
            txtInterconsultado.Text = dt.Rows(0).Item("Descripcion")
            txtMotivo.Text = dt.Rows(0).Item("Justificacion").ToString
            txtRespuesta.Text = dt.Rows(0).Item("Respuesta")
            dtfecha.Value = dt.Rows(0).Item("Fecha")
            txtNombreUsuarioInforme.Text = dt.Rows(0).Item("Usuario").ToString
            'usuarioReal = dt.Rows(0).Item("usuarioInforme").ToString
            'usuarioCreacion = dt.Rows(0).Item("usuarioCreacion").ToString
            General.deshabilitarControles(GroupDatos)
        End If
    End Sub

    Private Sub FormInterconsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        bteditar.Enabled = True
        If String.IsNullOrEmpty(moduloTemporal) Then
            moduloTemporal = Tag.modulo
        End If
        objInterconsulta = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_INTERCONSULTA_MEDICA & moduloTemporal)
        objInterconsulta.usuario = SesionActual.idUsuario
        permiso_general = perG.buscarPermisoGeneral("FormInterconsulta", moduloTemporal)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        If moduloTemporal <> Constantes.AM And moduloTemporal <> Constantes.AF Then
            objInterconsulta.moduloReporte = Constantes.REPORTE_HC
        ElseIf moduloTemporal = Constantes.AM Then
            objInterconsulta.moduloReporte = Constantes.REPORTE_AM
        ElseIf moduloTemporal = Constantes.AF Then
            objInterconsulta.moduloReporte = Constantes.REPORTE_AF
        End If
        btbuscar.Enabled = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_INTERCONSULTA)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objInterconsulta.usuario = tbl(0)
                txtNombreUsuarioInforme.Text = tbl(1)
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        txtMotivo.ReadOnly = False
        txtRespuesta.ReadOnly = False
        dtfecha.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        GroupBoxInfoInterconsulta.Focus()
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimir()
    End Sub
    Public Sub imprimir()
        Try
            Dim nombreArchivo, ruta, formula As String


            formula = "{VISTA_INTERCONSULTA.Codigo_Orden} = " & txtCodigoOrden.Text & " AND 
                       {VISTA_INTERCONSULTA.Codigo_Procedimiento} = '" & procedimientoInterconsulta & "' 
                                            AND {VISTA_INTERCONSULTA.Modulo}=" & objInterconsulta.moduloReporte

            nombreArchivo = objInterconsulta.nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                txtCodigoOrden.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo

            Dim reporte As New ftp_reportes
            reporte.crearReportePDF(objInterconsulta.nombreReporte, txtregistro.Text, New rptInterconsulta,
                                  txtCodigoOrden.Text, formula,
                                  objInterconsulta.nombreReporte, IO.Path.GetTempPath)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objHistoriaClinica.objInterconsulta.anularInterconsulta()
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If String.IsNullOrEmpty(txtRespuesta.Text) Then
                MsgBox("Debe digitar la respuesta de la interconsulta.", MsgBoxStyle.Exclamation)
                txtRespuesta.Focus()
            ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objInterconsulta.codigoEP = SesionActual.codigoEP
                objInterconsulta.codigoOrden = CInt(txtCodigoOrden.Text)
                objInterconsulta.codigoProcedimiento = procedimientoInterconsulta
                objInterconsulta.Respuesta = txtRespuesta.Text
                objInterconsulta.fechaInterconsulta = dtfecha.Value
                objInterconsulta.guardarInterconsultaMedica()
                CodigoTemporal = txtCodigo.Text
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.habilitarBotones(ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub tomarModulo(modulo As String)
        moduloTemporal = modulo
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) And moduloTemporal <> Constantes.HC Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_INTERCONSULTA)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objInterconsulta.usuario = tbl(0)
                txtNombreUsuarioInforme.Text = tbl(1)
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            General.deshabilitarControles(Me)
        End If
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        txtMotivo.ReadOnly = True
        txtRespuesta.ReadOnly = False
        dtfecha.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        GroupBoxInfoInterconsulta.Focus()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(PBuscar) Then
        Dim consulta As String = String.Empty
        Dim params As New List(Of String)
        Dim tbl As DataRow = Nothing
        params.Add(Nothing)
        If moduloTemporal = Constantes.HC Then
            consulta = Consultas.INTERCONSULTA_BUSCAR
        ElseIf moduloTemporal = Constantes.AM Then
            consulta = Consultas.INTERCONSULTA_BUSCAR_R
        ElseIf moduloTemporal = Constantes.AF Then
            consulta = Consultas.INTERCONSULTA_BUSCAR_RR
        End If

        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(consulta, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, True,, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objInterconsulta.codigoOrden = tbl(0)
            objInterconsulta.codigoProcedimiento = tbl(1)
            cargarInterconsulta()
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Sub cargarInterconsulta()
        Dim dt As New DataTable
        objInterconsulta.codigoEP = SesionActual.codigoEP
        objInterconsulta.cargarInterconsultaMedica()
        txtInterconsultante.Text = objInterconsulta.Interconsultante
        txtInterconsultado.Text = objInterconsulta.Interconsultado
        txtMotivo.Text = objInterconsulta.Motivo
        txtRespuesta.Text = objInterconsulta.Respuesta
        txtNombreUsuarioInforme.Text = objInterconsulta.usuarioNombre
        General.deshabilitarControles(Me)
        General.habilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btguardar.Enabled = False
        btcancelar.Enabled = False
        If txtRespuesta.Text <> String.Empty Then
            btimprimir.Enabled = True
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(grupoRespuesta)
        GroupBoxInfoInterconsulta.Focus()
        bteditar.Enabled = True
    End Sub
End Class