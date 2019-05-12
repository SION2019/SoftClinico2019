Public Class Form_consolidado_comida_detallado
    Dim objConsolidadoComidaDetalle As New ConsolidadoComidaDetallado
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pTodasAreas As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_consolidado_comida_detallado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        llenarDiaDia(objConsolidadoComidaDetalle)
    End Sub
    Private Sub cmbAreaServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAreaServicio.SelectedIndexChanged
        If IsNumeric(cmbAreaServicio.SelectedValue) Then
            llenarDiaDia(objConsolidadoComidaDetalle)
        End If
    End Sub
    Private Sub Form_consolidado_comida_detallado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Try
            Dim objConsolidadoComidaDetalladoBLL As New ConsolidadoComidasDetalladoBLL
            objConsolidadoComidaDetalladoBLL.guardar(objConsolidadoComidaDetalle)
            configurarImpresion()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
#Region "Metodos"
    Sub inicializarForm()
        enlazarTabla()
        llenarComboAreaSevicios()
        llenarDiaDia(objConsolidadoComidaDetalle)
        deshabilitarControlesInternos()
    End Sub
    Sub llenarComboAreaSevicios()
        permisoGeneral = perG.buscarPermisoGeneral("Form_pedido_comida")
        pTodasAreas = permisoGeneral & "pp" & "07"
        Dim parametros As New List(Of String)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)
        General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", cmbAreaServicio)
        If SesionActual.tienePermiso(pTodasAreas ) Then
            cmbAreaServicio.DataSource.Rows.Add()
            cmbAreaServicio.DataSource.Rows(cmbAreaServicio.DataSource.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
            cmbAreaServicio.DataSource.Rows(cmbAreaServicio.DataSource.Rows.Count - 1).Item(1) = "TODOS"
        End If


    End Sub
    Sub imprimir()
        Dim reporte As New ftp_reportes
        Try
            If rbtnPDF.Checked = True Then
                reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS_DETALLADO, "", New rptConsolidadoComidaDetallado,
                              "", "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa,
                               ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS_DETALLADO, IO.Path.GetTempPath, "")
            Else
                Dim ruta, area, nombreArchivo As String
                area = ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS_DETALLADO
                nombreArchivo = ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS_DETALLADO & "_" & If(rbtnPDF.Checked, ConstantesHC.EXTENSION_ARCHIVO_PDF, ConstantesHC.EXTENSION_ARCHIVO_EXCEL)
                ruta = IO.Path.GetTempPath() & nombreArchivo
                reporte.crearReporteExcel(ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS_DETALLADO, "", New rptConsolidadoComidaDetallado,
                              "", "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa,
                               ConstantesHC.NOMBRE_PDF_CONSOLIDADO_COMIDAS_DETALLADO, IO.Path.GetTempPath, "", True)

                Process.Start(ruta)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub configurarImpresion()
        Try

            Cursor = Cursors.WaitCursor
            btimprimir.Enabled = False
            Try

                imprimir()
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
            Cursor = Cursors.Default
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub enlazarTabla()
        Dim objComsolidadoComidasBl As New ConsolidadoComidasDetalladoBLL
        objComsolidadoComidasBl.enlazarDgv(objConsolidadoComidaDetalle, dgvComidadDiaDia)
    End Sub
    Sub llenarDiaDia(objConsolidadoComidaDetalle As ConsolidadoComidaDetallado)
        If cmbAreaServicio.SelectedIndex = 0 Then
            objConsolidadoComidaDetalle.tblDetalleDias.Clear()
            Exit Sub
        End If
        Dim params As New List(Of String)
        params.Add(Format(dtpFecha.Value, "yyyy-MM"))
        params.Add(cmbAreaServicio.SelectedValue)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CONSOLIDADO_COMIDAS_DETALLADO, params, objConsolidadoComidaDetalle.tblDetalleDias)
        calcularCantidades()
    End Sub
    Sub calcularCantidades()
        calcularCantidadDesayuno()
        calcularCantidadAlmuerzo()
        calcularCantidadCena()
    End Sub
    Sub calcularCantidadDesayuno()
        txtCantidadDesyuno.Text = cantidadesComidas("CantidadD", objConsolidadoComidaDetalle)
    End Sub
    Sub calcularCantidadAlmuerzo()
        txtCantidadAlmuerzo.Text = cantidadesComidas("cantidadA", objConsolidadoComidaDetalle)
    End Sub
    Sub calcularCantidadCena()
        txtCantidadCena.Text = cantidadesComidas("cantidadC", objConsolidadoComidaDetalle)
    End Sub

    Sub deshabilitarControlesInternos()
        txtCantidadDesyuno.ReadOnly = True
        txtCantidadAlmuerzo.ReadOnly = True
        txtCantidadCena.ReadOnly = True
    End Sub
#End Region
#Region "Funciones"
    Function cantidadesComidas(ByVal columna As String, objconsolidadoComidasdetalldo As ConsolidadoComidaDetallado) As Integer
        Return If(IsDBNull(objConsolidadoComidaDetalle.tblDetalleDias.Compute("Sum(" & columna & ")", "")), 0, objConsolidadoComidaDetalle.tblDetalleDias.Compute("Sum(" & columna & ")", ""))
    End Function
#End Region

End Class