Imports System.Data.SqlClient
Public Class FormAnexo1

    Private dtAnexo As New DataTable
    Dim cmd As New Anexo1BLL
    Dim reporte As New ftp_reportes
    Dim perG As New Buscar_Permisos_generales
    Private servicio As Boolean
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigoTemporal, codigoOrden As String
    Private Sub Form_Anexo1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        txtnumerosol.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        establecer_tabla()
        dgvanexo.DataSource = dtAnexo
        With dgvanexo
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").Width = 140
            .Columns("Datos segun documentos").ReadOnly = True
            .Columns("Datos segun documentos").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Datos segun documentos").DataPropertyName = "Datos segun documentos"
            .Columns("Datos segun documentos").Width = 210
            .Columns("Datos base datos").ReadOnly = True
            .Columns("Datos base datos").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Datos base datos").DataPropertyName = "Datos base datos"
            .Columns("Datos base datos").Width = 170
            .Columns("Seleccionar1").ReadOnly = True
            .Columns("Seleccionar1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Seleccionar1").DisplayIndex = 1
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With


        deshabilitar()
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        btguardar.Enabled = False
        btanular.Enabled = False
        bteditar.Enabled = False
        btcancelar.Enabled = False
    End Sub

    Public Sub establecer_tabla()
        Dim col1, col2, col3 As New DataColumn

        col1.ColumnName = "Descripcion"
        col1.DataType = Type.GetType("System.String")
        dtAnexo.Columns.Add(col1)

        col2.ColumnName = "Datos segun documentos"
        col2.DataType = Type.GetType("System.String")
        dtAnexo.Columns.Add(col2)

        col3.ColumnName = "Datos base datos"
        col3.DataType = Type.GetType("System.String")
        dtAnexo.Columns.Add(col3)

        col1 = Nothing : col2 = Nothing : col3 = Nothing
    End Sub
    Public Sub limpiar()
        txtobservacion.Clear()
        txtorden.Clear()
        dtAnexo.Clear()
    End Sub
    Public Sub CargarDatos(ByVal codigo As String)
        Dim params As New List(Of String)
        Dim dt As New DataTable
        params.Add(codigo)
        General.llenarTabla(Consultas.ANEXO1_CARGAR, params, dt)

        txtorden.Text = codigo
        txtobservacion.Text = dt.Rows(0).Item("Observacion")
        Dim fechasoli As String = dt.Rows(0).Item("N_solicitd").ToString()
        txtnumerosol.Text = fechasoli.Remove(10, 4)
        txtcontador.Text = fechasoli.ToString.Substring(12)
        If dt.Rows(0).Item("Servicio").ToString = Constantes.ANEXO1_DATOS_NO Then
            rddatos.Checked = True
        ElseIf dt.Rows(0).Item("Servicio").ToString = Constantes.ANEXO1_USUARIO_NO Then
            rdnoexiste.Checked = True
        End If
        cargarDatosPaciente()
        cargar_datos_detalle()
    End Sub
    Public Sub VerificarRegistro()
        Dim dt As New DataTable
        Dim contador As Integer
        General.llenarTablaYdgv(Consultas.ANEXO1_VERIFICAR_NUMERO_REGISTRO & txtregistro.Text.ToString, dt)
        contador = dt.Rows(0).Item("Registro").ToString
        If String.IsNullOrEmpty(txtorden.Text) Then
            txtcontador.Text = contador + 1
        Else
            txtcontador.Text = dt.Rows(0).Item("Registro")
        End If
    End Sub

    Public Sub cargar_datos_detalle()
        General.llenarTablaYdgv(Consultas.ANEXO1_CARGAR_DETALLE & txtorden.Text, dtAnexo)
        dgvanexo.Columns("Seleccionar1").DisplayIndex = 1
        dgvanexo.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        For j As Int16 = 0 To dtAnexo.Rows.Count - 1
            If dgvanexo.Rows(j).Cells(2).Value <> dgvanexo.Rows(j).Cells(3).Value Then
                dgvanexo.Rows(j).Cells(0).Value = True
            End If
        Next
    End Sub
    Public Sub cargarDatosPaciente()
        Funciones.agregarFilas(dtAnexo, 6)
        dtAnexo.Rows(0).Item(0) = "Primer Apellido"
        dtAnexo.Rows(1).Item(0) = "Segundo Apellido"
        dtAnexo.Rows(2).Item(0) = "Primer Nombre"
        dtAnexo.Rows(3).Item(0) = "Segundo Nombre"
        dtAnexo.Rows(4).Item(0) = "N° Identificación"
        dtAnexo.Rows(5).Item(0) = "Fecha de Nacimiento"
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            If txtregistro.Text <> "" Then
                btcancelar.Enabled = True
                btnuevo.Enabled = False
                bteditar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
                habilitar()
                btbuscar.Enabled = False
                limpiar()
                VerificarRegistro()
                txtnumerosol.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
                btguardar.Enabled = True
                dgvanexo.Columns(3).ReadOnly = False
                cargarDatosPaciente()
                cargarPacientesDatos()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarPacientesDatos()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtidentificacion.Text)
        General.llenarTabla(Consultas.ANEXO1_CARGAR_PACIENTE, params, dt)
        If dt.Rows.Count > 0 Then
            dgvanexo.Rows(0).Cells(2).Value = dt.Rows(0).Item("Primer_Apellido").ToString
            dgvanexo.Rows(0).Cells(3).Value = dt.Rows(0).Item("Primer_Apellido").ToString
            dgvanexo.Rows(1).Cells(2).Value = dt.Rows(0).Item("Segundo_Apellido").ToString
            dgvanexo.Rows(1).Cells(3).Value = dt.Rows(0).Item("Segundo_Apellido").ToString
            dgvanexo.Rows(2).Cells(2).Value = dt.Rows(0).Item("Primer_Nombre").ToString
            dgvanexo.Rows(2).Cells(3).Value = dt.Rows(0).Item("Primer_Nombre").ToString
            dgvanexo.Rows(3).Cells(2).Value = dt.Rows(0).Item("Segundo_Nombre").ToString
            dgvanexo.Rows(3).Cells(3).Value = dt.Rows(0).Item("Segundo_Nombre").ToString
            dgvanexo.Rows(4).Cells(2).Value = dt.Rows(0).Item("Identi_Paciente").ToString
            dgvanexo.Rows(4).Cells(3).Value = dt.Rows(0).Item("Identi_Paciente").ToString
            dgvanexo.Rows(5).Cells(2).Value = dt.Rows(0).Item("Fecha_Nacimiento").ToString
            dgvanexo.Rows(5).Cells(3).Value = dt.Rows(0).Item("Fecha_Nacimiento").ToString
        End If
    End Sub
    Private Sub deshabilitar()
        txtobservacion.ReadOnly = True
        GroupBox3.Enabled = False
        rddatos.Enabled = False
        rdnoexiste.Enabled = False
        dgvanexo.Columns("Datos base datos").ReadOnly = True
    End Sub

    Private Sub habilitar()
        txtobservacion.ReadOnly = False
        GroupBox3.Enabled = True
        rddatos.Enabled = True
        rdnoexiste.Enabled = True
    End Sub

    Private Sub deshabilitarControles()
        txtidentificacion.ReadOnly = True
        txtnumerosol.ReadOnly = True
        txtorden.ReadOnly = True
        txtpaciente.ReadOnly = True
        txtregistro.ReadOnly = True
        txtcontador.ReadOnly = True
        txtcontrato.ReadOnly = True
        txttipoinforme.ReadOnly = True
        dgvanexo.Columns("datos segun documentos").ReadOnly = True
        dgvanexo.Columns("Descripcion").ReadOnly = True
        dgvanexo.Columns("Seleccionar1").ReadOnly = True
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            If txtregistro.Text <> "" Then
                Dim params As New List(Of String)
                params.Add(txtregistro.Text)

                General.buscarElemento(Consultas.BUSQUEDA_ANEXO1,
                                   params,
                                   AddressOf CargarDatos,
                                   TitulosForm.BUSQUEDA_ANEXO1,
                                   False, 0, True)

                If txtorden.Text <> "" Then
                    bteditar.Enabled = True
                    deshabilitar()
                    btnuevo.Enabled = True
                    btimprimir.Enabled = True
                    btanular.Enabled = True
                    btcancelar.Enabled = False

                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub dgvanexo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvanexo.CellEndEdit
        For j As Int32 = 0 To dgvanexo.Rows.Count - 1
            If dgvanexo.Rows(j).Cells(3).Value <> "" And dgvanexo.Rows(j).Cells(2).Value <> dgvanexo.Rows(j).Cells(3).Value Then
                dgvanexo.Rows(j).Cells(0).Value = True
            Else
                dgvanexo.Rows(j).Cells(0).Value = False
            End If
        Next
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del anexo", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim nombreArchivo, ruta, formula, codigoNombre, nombreReporte As String

            codigoNombre = txtorden.Text
            nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            formula = "{VISTA_ANEXO1.N_Orden} = " & codigoNombre & ""
            Dim reporte As New ftp_reportes
            reporte.crearReportePDF(nombreReporte, txtorden.Text, New rptAnexo1,
                                  codigoNombre, formula,
                                  nombreReporte, IO.Path.GetTempPath)
        Catch ex As Exception
            Throw ex
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarReporteAnexo()
        Try
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ANEXO_1,
                                         codigoTemporal, New rptAnexo1,
                                         codigoOrden, "{VISTA_ANEXO1.N_Orden} = " & codigoOrden & "",
                                         ConstantesHC.NOMBRE_PDF_ANEXO_1, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            limpiar()
            txtnumerosol.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
            deshabilitar()
            btcancelar.Enabled = False
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            bteditar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            btguardar.Enabled = False
        End If
    End Sub


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtorden.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_ANEXO1, params)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                limpiar()
                btanular.Enabled = False
                btguardar.Enabled = False
                bteditar.Enabled = False
                btimprimir.Enabled = False
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btcancelar.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
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
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                dgvanexo.Columns("Datos base datos").ReadOnly = False
                habilitar()
                deshabilitarControles()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            If rdnoexiste.Checked = True Then
                servicio = Constantes.ANEXO1_USUARIO_NO
            Else
                servicio = Constantes.ANEXO1_DATOS_NO
            End If
            Dim nombreSolicitud As String
            If txtnumerosol.Text.Contains("-") Then
                nombreSolicitud = txtnumerosol.Text
            Else
                nombreSolicitud = txtnumerosol.Text & " - " & txtcontador.Text
            End If
            Try
                cmd.guardar_anexo(txtorden, txtregistro.Text, servicio, nombreSolicitud, txtobservacion.Text, SesionActual.idUsuario, dgvanexo.DataSource)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                btimprimir.Enabled = True
                VerificarRegistro()
                codigoTemporal = txtregistro.Text
                codigoOrden = txtorden.Text
                btbuscar.Enabled = True
                'guardarReporteAnexo()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
End Class