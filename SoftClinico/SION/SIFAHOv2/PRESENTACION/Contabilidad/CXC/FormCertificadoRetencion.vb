Imports System.Data.SqlClient

Public Class FormCertificadoRetencion
    Private Sub Form_BalanceComprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicio.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dtpFechaFin.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)

    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Function crearParametros() As CertificadoRetencionParams
        Dim params As New CertificadoRetencionParams

        params.idEmpresa = SesionActual.idEmpresa
        params.idTercero = LibroAuxiliarBLL.obtenerTerceroByNit(txtTercero.Text)
        params.fechaInicio = dtpFechaInicio.Value
        params.fechaFin = dtpFechaFin.Value

        Return params
    End Function
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btExportaExcel_Click(sender As Object, e As EventArgs)
        Try
            Dim nombreRpt As String = "certificado_retencion_01"
            Dim dtLibroDiario As New DataTable
            Dim params As New List(Of String)

            Cursor = Cursors.WaitCursor
            params.Add(SesionActual.idEmpresa)
            params.Add(CDate(dtpFechaInicio.Value).Date)
            params.Add(CDate(dtpFechaFin.Value).Date)

            General.llenarTabla(Consultas.CERTIFICADO_RETENCION_CARGAR_XLS, params, dtLibroDiario)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtLibroDiario, nombreRpt)

            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        Try
            visualizarReporte()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Public Sub visualizarReporte()

        Dim params As CertificadoRetencionParams

        If validarFormulario() Then
            params = crearParametros()
            CertificadoRetencionBLL.obtenerValorRetencion(params)

            If params.resultado = False Then
                MsgBox(Mensajes.CONTA_RESULTADO_VACIO, MsgBoxStyle.Exclamation)
            Else
                Cursor = Cursors.WaitCursor
                CertificadoRetencionBLL.generarCertificadoRetencion(params)
                Cursor = Cursors.Default
            End If
        End If

    End Sub

    Private Function validarFormulario() As Boolean

        If txtTercero.Text = String.Empty Then
            MsgBox("Favor escoger un tercero!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function
    Private Sub btTercero_Click(sender As Object, e As EventArgs) Handles btTercero.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(Nothing)
        General.buscarElemento(Consultas.CONTA_TERCERO_BUSCAR,
                               params,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               False, 0, True)
    End Sub

    Public Sub cargarTercero(pCodigoTercero As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoTercero)

        drTercero = General.cargarItem(Consultas.CONTA_PROVEEDOR_CARGAR, params)

        txtTercero.Text = drTercero.Item(1)
        txtRazonSocial.Text = drTercero.Item(2)

    End Sub

    Private Sub txtTercero_Leave(sender As Object, e As EventArgs) Handles txtTercero.Leave
        If txtTercero.Text = String.Empty Then
            txtRazonSocial.Text = String.Empty
            Return
        End If

        Dim idTercero As Integer = Nothing
        idTercero = LibroAuxiliarBLL.obtenerTerceroByNit(txtTercero.Text)

        If idTercero = Nothing Then
            MsgBox(Mensajes.CONTA_TERCERO_INEXISTENTE, MsgBoxStyle.Critical)
            txtTercero.Text = String.Empty
            txtRazonSocial.Text = String.Empty
            txtTercero.Focus()
        Else
            cargarTercero(idTercero)
        End If
    End Sub

    Public Sub cargarTercero(pCodigoTercero As Integer)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoTercero)

        drTercero = General.cargarItem(Consultas.CONTA_TERCERO_CARGAR, params)
        txtTercero.Text = drTercero.Item(0)
        txtRazonSocial.Text = drTercero.Item(1)

    End Sub

End Class