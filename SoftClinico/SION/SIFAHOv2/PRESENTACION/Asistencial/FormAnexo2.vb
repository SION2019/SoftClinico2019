Imports System.Data.SqlClient
Imports System.Threading
Public Class FormAnexo2
    Dim cmd As New Anexo2BLL
    Dim reporte As New ftp_reportes
    Dim perG As New Buscar_Permisos_generales
    Dim vParams As New List(Of String)
    Dim respuesta As Boolean
    Dim guardarEn2doPlano As Thread
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigoTemporal, codigoOrden As String
    Private Sub Form_Anexo2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        fecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)

        General.cargarCombo(Consultas.INSTITUCIONES_LISTAR, "Descripción", "Código", Comboinstitu)
        If combopais.SelectedIndex = -1 Then
            General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", combopais)
        End If

        combopais.SelectedIndex = 0
        General.deshabilitarControles(Me)
        btbuscar.Enabled = True
        btcancelar.Enabled = False
        btguardar.Enabled = False
        btanular.Enabled = False
        bteditar.Enabled = False
        btnuevo_Click(sender, e)
    End Sub
    Private Sub cargarDatos(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtCodigo.Text = pCodigo
        General.llenarTabla(Consultas.ANEXO2_CARGAR, params, dt)

        txtregistro.Text = dt.Rows(0).Item("N_registro").ToString()
        Checkdomicilio.Checked = dt.Rows(0).Item("domicilio").ToString()
        Checkobservacion.Checked = dt.Rows(0).Item("observacion").ToString()
        Checkinternacion.Checked = dt.Rows(0).Item("internacion").ToString()
        Checkremision.Checked = dt.Rows(0).Item("remision").ToString()
        Checkcontrarremision.Checked = dt.Rows(0).Item("contraremision").ToString()
        Checkotros.Checked = dt.Rows(0).Item("otros").ToString()
        txtobservacion.Text = dt.Rows(0).Item("Nota").ToString()
        combopais.SelectedValue = dt.Rows(0).Item("codigo_pais").ToString()
        Combodepar.SelectedValue = dt.Rows(0).Item("codigo_departamento").ToString()
        Combociudad.SelectedValue = dt.Rows(0).Item("codigo_municipio").ToString()
        fecha.Text = dt.Rows(0).Item("fecha_urgencia").ToString()
        Comboinstitu.SelectedValue = dt.Rows(0).Item("codigo_institucion").ToString()

        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False

    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add(txtregistro.Text)
            General.buscarElemento(Consultas.BUSQUEDA_ANEXO2,
                              params,
                              AddressOf cargarDatos,
                              TitulosForm.BUSQUEDA_ANEXO2,
                              True, 0, True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub CargarPaciente()
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.ANEXO2_CARGAR_PACIENTE & txtregistro.Text, dt)
        txtcedula.Text = dt.Rows(0).Item("Identificacion").ToString
        txtpaciente.Text = dt.Rows(0).Item("Paciente").ToString
        txtsexo.Text = dt.Rows(0).Item("Genero").ToString
        txteps.Text = dt.Rows(0).Item("EPS").ToString
    End Sub
    Public Sub iniciarForm(ByRef params As List(Of String))
        vParams = params
        vParams.Add(Constantes.VALOR_PREDETERMINADO)
        txtregistro.Text = params(0)
        Dim dtDatosPaciente As New DataTable
        Dim params2 As New List(Of String)
        params2.Add(txtregistro.Text)
        General.llenarTabla(ConsultasAsis.ANEXO_2_ADMISION_CARGAR, params2, dtDatosPaciente)
        If dtDatosPaciente.Rows.Count > 0 Then
            vParams.Add(dtDatosPaciente.Rows(0).Item(0))
            Exit Sub
        End If
        CargarPaciente()
        ShowDialog()
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            HabilitarControlesManual()
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
            btanular.Enabled = False
            btimprimir.Enabled = False
            bteditar.Enabled = False
            btbuscar.Enabled = False
            btnuevo.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles combopais.SelectedIndexChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepar)
    End Sub

    Private Sub Combodepar_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepar.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepar.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub

    Public Sub HabilitarControlesManual()
        combopais.Enabled = True
        Combodepar.Enabled = True
        Combociudad.Enabled = True
        Comboinstitu.Enabled = True
        Checkinternacion.Enabled = True
        Checkobservacion.Enabled = True
        Checkotros.Enabled = True
        Checkremision.Enabled = True
        Checkcontrarremision.Enabled = True
        Checkdomicilio.Enabled = True
        txtobservacion.ReadOnly = False
    End Sub

    Public Sub DeshabilitarControlesManual()
        combopais.Enabled = False
        Combodepar.Enabled = False
        Combociudad.Enabled = False
        Comboinstitu.Enabled = False
        Checkinternacion.Enabled = False
        Checkobservacion.Enabled = False
        Checkotros.Enabled = False
        Checkremision.Enabled = False
        Checkcontrarremision.Enabled = False
        Checkdomicilio.Enabled = False
        txtobservacion.ReadOnly = True
    End Sub

    Public Sub limpiarControles()
        txtobservacion.Clear()
        Checkcontrarremision.Checked = False
        Checkdomicilio.Checked = False
        Checkinternacion.Checked = False
        Checkotros.Checked = False
        Checkremision.Checked = False
        txtCodigo.Clear()
        combopais.SelectedValue = -1
        Combociudad.SelectedValue = -1
        Comboinstitu.SelectedValue = -1
        Combodepar.SelectedValue = -1
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            HabilitarControlesManual()
            btnuevo.Enabled = False
            btguardar.Enabled = True
            bteditar.Enabled = False
            btanular.Enabled = False
            btbuscar.Enabled = False
            btimprimir.Enabled = False
            txtCodigo.Clear()
            limpiarControles()
            btcancelar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_ANEXO2 & txtCodigo.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then

                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    limpiar()
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    bteditar.Enabled = False
                    btimprimir.Enabled = False
                    btcancelar.Enabled = False
                    fecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del anexo2", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_ANEXO_2
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtCodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            'ftp_reportes.llamarArchivo(ruta, nombreArchivo, txtCodigo.Text, area)
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ANEXO_2, txtCodigo.Text, New rptAnexo2,
                                    txtCodigo.Text, "{VISTA_ANEXO2.N_solicitud} = " & txtCodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_ANEXO_2, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarSegundoPlano()
        guardarEn2doPlano = New Thread(AddressOf guardarReporteAnexo)
        guardarEn2doPlano.Name = "Guardar Anexo2"
        guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
        guardarEn2doPlano.Start()
    End Sub

    Private Sub guardarReporteAnexo()
        Try
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ANEXO_2, txtregistro.Text, New rptAnexo2,
                                    txtCodigo.Text, "{VISTA_ANEXO2.N_solicitud} = " & txtCodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_ANEXO_2, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub


    Public Sub habilitar()
        txtobservacion.ReadOnly = False
    End Sub

    Public Function validarControels()
        If combopais.SelectedValue = -1 Then
            MsgBox("Debe seleccionar el pais", MsgBoxStyle.Exclamation)
            combopais.Focus()
            Return False
        ElseIf Combodepar.SelectedValue = -1 Then
            MsgBox("Debe seleccionar el departamento", MsgBoxStyle.Exclamation)
            Combodepar.Focus()
            Return False
        ElseIf Combociudad.SelectedValue = -1 Then
            MsgBox("Debe seleccionar el municipio", MsgBoxStyle.Exclamation)
            Combociudad.Focus()
            Return False
        ElseIf Comboinstitu.SelectedValue = -1 Then
            MsgBox("Debe seleccionar una institucion", MsgBoxStyle.Exclamation)
            Comboinstitu.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtobservacion.Text) Then
            MsgBox("El campo observacion se encuentra vacio", MsgBoxStyle.Exclamation)
            txtobservacion.Focus()
            Return False
        ElseIf Checkdomicilio.Checked = False And Checkcontrarremision.Checked = False And Checkinternacion.Checked = False And Checkobservacion.Checked = False And Checkremision.Checked = False And Checkotros.Checked = False Then
            MsgBox("debe seleccioanar alguno de los siguientes check ejemplo Domicilio ", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Public Sub guardar()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                cmd.guardaranexo(txtCodigo, txtregistro.Text, Checkdomicilio.Checked, Checkobservacion.Checked, Checkinternacion.Checked, Checkremision.Checked,
                                    Checkcontrarremision.Checked, Checkotros.Checked, txtobservacion.Text, Comboinstitu.SelectedValue.ToString, combopais.SelectedValue.ToString, Combodepar.SelectedValue.ToString, Combociudad.SelectedValue.ToString, fecha.Text, SesionActual.idUsuario)

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                codigoTemporal = txtregistro.Text
                codigoOrden = txtCodigo.Text
                btguardar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btbuscar.Enabled = True
                btcancelar.Enabled = False
                btimprimir.Enabled = True
                btnuevo.Enabled = True
                DeshabilitarControlesManual()
                vParams.Add(txtCodigo.Text)
                'guardarSegundoPlano()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarControels() Then
            guardar()
        End If
    End Sub

    Private Sub limpiar()
        combopais.SelectedIndex = 0
        Combodepar.SelectedIndex = 0
        Combociudad.SelectedIndex = 0
        Comboinstitu.SelectedIndex = 0
        Checkinternacion.Checked = False
        Checkobservacion.Checked = False
        Checkotros.Checked = False
        Checkremision.Checked = False
        Checkcontrarremision.Checked = False
        Checkdomicilio.Checked = False
        txtobservacion.Clear()
        txtCodigo.Clear()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            DeshabilitarControlesManual()
            limpiar()
            btnuevo.Enabled = True
            fecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            btanular.Enabled = False
            btguardar.Enabled = False
            bteditar.Enabled = False
            btimprimir.Enabled = False
            btbuscar.Enabled = True
            btcancelar.Enabled = False
            txtCodigo.Clear()
        End If
    End Sub
End Class