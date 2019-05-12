Public Class FormLibroAuxiliar

    Private pucActivo As Integer
    Private Sub btBusquedaCuenta_Click(sender As Object, e As EventArgs) Handles btBusquedaCuenta.Click
        Dim params As New List(Of String)
        params.Add(pucActivo)
        params.Add(Nothing)

        General.buscarElemento(Consultas.BUSQUEDA_CUENTAS_PUC,
                               params,
                               AddressOf cargarCuenta,
                               TitulosForm.BUSQUEDA_CUENTAS_PUC,
                               False, 0, True)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Public Sub cargarCuenta(pCodigoCuenta As String)
        Dim drCuenta As DataRow
        Dim params As New List(Of String)
        params.Add(pucActivo)
        params.Add(pCodigoCuenta)

        drCuenta = General.cargarItem(Consultas.CUENTAS_PUC_CARGAR, params)

        If drCuenta IsNot Nothing Then
            txtCodigoCuenta.Text = drCuenta.Item(1)
            txtDescripcionCuenta.Text = drCuenta.Item(2)
        Else
            MsgBox(Mensajes.CONTA_CUENTA_PUC_INEXISTENTE, MsgBoxStyle.Critical)
            txtCodigoCuenta.Text = String.Empty
            txtDescripcionCuenta.Text = String.Empty
            txtCodigoCuenta.Focus()
        End If

    End Sub

    Private Sub btTercero_Click(sender As Object, e As EventArgs) Handles btTercero.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)

        General.buscarElemento(Consultas.BUSQUEDA_TERCERO,
                               params,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               False, 0, True)

    End Sub

    Public Sub cargarTercero(pCodigoTercero As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoTercero)

        drTercero = General.cargarItem(Consultas.CONTA_TERCERO_CARGAR, params)
        txtIdentificacionTercero.Text = drTercero.Item(0)
        txtDescripcionTercero.Text = drTercero.Item(1)

    End Sub

    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        Try
            visualizarReporte(ExportFormatType.PortableDocFormat)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Public Sub visualizarReporte(formato As CrystalDecisions.Shared.ExportFormatType)
        Dim params As New LibroAuxiliarParams

        params = crearParametros()
        LibroAuxiliarBLL.calcularLibroAuxiliar(params)

        If params.resultado = False Then
            MsgBox(Mensajes.CONTA_RESULTADO_VACIO, MsgBoxStyle.Exclamation)
        Else
            Select Case formato
                Case ExportFormatType.PortableDocFormat
                    Funciones.getReporteNoFTP(generarReporte(), Nothing, "LibroAux01")
                Case ExportFormatType.Excel
                    Funciones.getReporte(generarReporte, "LibroAux01", Nothing, formato)
            End Select
        End If

    End Sub

    Public Function generarReporte() As rptLibroAuxiliar
        Dim rptLibro As New rptLibroAuxiliar

        Dim rango As String = dtpFechaInicio.Text & " - " & dtpFechaFin.Text

        rptLibro.SetParameterValue("IdEmpresa", SesionActual.idEmpresa)
        rptLibro.SetParameterValue("rango", rango)

        Return rptLibro

    End Function

    Private Function crearParametros()
        Dim params As New LibroAuxiliarParams

        params.idEmpresa = SesionActual.idEmpresa
        params.codigoPUC = pucActivo
        params.codigoCuenta = txtCodigoCuenta.Text
        params.idTercero = LibroAuxiliarBLL.obtenerTerceroByNit(txtIdentificacionTercero.Text)
        params.fechaInicio = dtpFechaInicio.Text
        params.fechaFin = dtpFechaFin.Text

        Return params
    End Function

    Private Sub Form_LibroAuxiliarCxP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pucActivo = FuncionesContables.obtenerPucActivo()

        dtpFechaInicio.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dtpFechaFin.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
    End Sub

    Private Sub btExportaExcel_Click(sender As Object, e As EventArgs) Handles btExportaExcel.Click
        Try
            visualizarReporte(ExportFormatType.Excel)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub txtCodigoCuenta_Leave(sender As Object, e As EventArgs) Handles txtCodigoCuenta.Leave
        If txtCodigoCuenta.Text = String.Empty Then
            txtDescripcionCuenta.Text = String.Empty
        Else
            cargarCuenta(txtCodigoCuenta.Text)
        End If

    End Sub

    Private Sub txtCodigoTercero_Leave(sender As Object, e As EventArgs) Handles txtIdentificacionTercero.Leave
        If txtIdentificacionTercero.Text = String.Empty Then
            txtDescripcionTercero.Text = String.Empty
            Return
        End If

        Dim idTercero As Integer = Nothing
        idTercero = LibroAuxiliarBLL.obtenerTerceroByNit(txtIdentificacionTercero.Text)

        If idTercero = Nothing Then
            MsgBox(Mensajes.CONTA_TERCERO_INEXISTENTE, MsgBoxStyle.Critical)
            txtIdentificacionTercero.Text = String.Empty
            txtDescripcionTercero.Text = String.Empty
            txtIdentificacionTercero.Focus()
        Else
            cargarTercero(idTercero)
        End If
    End Sub
End Class