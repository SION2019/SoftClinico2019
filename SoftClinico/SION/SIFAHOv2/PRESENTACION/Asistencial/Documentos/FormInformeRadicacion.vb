Public Class FormInformeRadicacion
    Dim objInfRadicacion As New FacturaRadicacionParams
    Private Sub btExportaExcel_Click(sender As Object, e As EventArgs) Handles btExportaExcel.Click
        Try
            visualizarReporte(ExportFormatType.Excel)
        Catch ex As Exception
            General.manejoErrores(ex) 
        End Try
    End Sub

    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        visualizarReporte(ExportFormatType.PortableDocFormat)
    End Sub

    Private Sub btTercero_Click(sender As Object, e As EventArgs) Handles btTercero.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        ChkTodos.Checked = False
        General.buscarElemento(Consultas.BUSQUEDA_TERCERO_CLIENTE_FACTURA,
                               params,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               False, 0, True)
    End Sub
    Public Sub visualizarReporte(formato As CrystalDecisions.Shared.ExportFormatType)
        Dim params As New FacturaRadicacionParams

        params = crearParametros()
        FacturaRadicacionBLL.calcularFacturaRadicacion(params)

        If params.resultado = False Then
            MsgBox(Mensajes.CONTA_RESULTADO_VACIO, MsgBoxStyle.Exclamation)
        Else
            Select Case formato
                Case ExportFormatType.PortableDocFormat
                    Funciones.getReporteNoFTP(generarReporte(params), Nothing, "Informe de Radicación")
                Case ExportFormatType.Excel
                    Funciones.getReporte(generarReporte(params), "Informe de Radicación", Nothing, formato)
            End Select
        End If

    End Sub
    Public Function generarReporte(params As FacturaRadicacionParams) As rptFacturaRadicacion
        Dim rptRadicacion As New rptFacturaRadicacion

        Dim rango As String = dtpFechaInicio.Text & " - " & dtpFechaFin.Text
        rptRadicacion.SetParameterValue("@FECHAINICIO", Format(params.fechaInicio, Constantes.FORMATO_FECHA_GEN))
        rptRadicacion.SetParameterValue("@FECHAFIN", Format(params.fechaFin, Constantes.FORMATO_FECHA_GEN))
        rptRadicacion.SetParameterValue("@IDCLIENTE", params.idTercero)
        rptRadicacion.SetParameterValue("@TIPOFACT", params.TipoFactura)
        rptRadicacion.SetParameterValue("@Id_Empresa", SesionActual.idEmpresa)
        rptRadicacion.SetParameterValue("rango", rango)
        Return rptRadicacion

    End Function
    Private Function crearParametros()
        Dim params As New FacturaRadicacionParams
        params.idEmpresa = SesionActual.idEmpresa
        params.idTercero = IIf(FacturaRadicacionBLL.obtenerTerceroByNit(txtIdentificacionTercero.Text) = 0, Nothing, FacturaRadicacionBLL.obtenerTerceroByNit(txtIdentificacionTercero.Text))
        params.fechaInicio = dtpFechaInicio.Text
        params.fechaFin = dtpFechaFin.Text
        params.TipoFactura = objInfRadicacion.TipoFactura
        Return params
    End Function
    Public Sub cargarTercero(pCodigoTercero As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoTercero)

        drTercero = General.cargarItem(Consultas.CONTA_TERCERO_CARGAR, params)
        txtIdentificacionTercero.Text = drTercero.Item(0)
        txtDescripcionTercero.Text = drTercero.Item(1)
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        objInfRadicacion.TipoFactura = 1
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        objInfRadicacion.TipoFactura = 0
    End Sub

    Private Sub ChkTodos_Click(sender As Object, e As EventArgs) Handles ChkTodos.Click
        txtIdentificacionTercero.Text = Nothing
        txtDescripcionTercero.Text = Nothing
    End Sub

    Private Sub FormInformeRadicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChkTodos.Checked = True
    End Sub
End Class