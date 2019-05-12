Imports System.Data.SqlClient

Public Class FormBalanceComprobacion
    Private Sub Form_BalanceComprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNit.Text = Funciones.empresaActual.nit
        txtRazonSocial.Text = Funciones.empresaActual.razonSocial

        dtpFechaInicio.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dtpFechaFin.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)

    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        If validarFormulario() Then
            visualizarReporte()
        End If
    End Sub

    Private Sub visualizarReporte()
        Try
            visualizarReporte(ExportFormatType.PortableDocFormat)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Function validarFormulario() As Boolean
        If dtpFechaInicio.Value > dtpFechaFin.Value Then
            MsgBox("La fecha de inicio no puede ser mayor a la fecha final!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function

    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub


    Public Sub visualizarReporte(formato As CrystalDecisions.Shared.ExportFormatType)
        Dim objBalanceBLL As New BalanceComprobacionBLL
        Dim params As New BalanceComprobacionParams

        params = crearParametros()
        objBalanceBLL.calcularBalanceComprobacion(params)

        If params.resultado = False Then
            MsgBox(Mensajes.CONTA_RESULTADO_VACIO, MsgBoxStyle.Exclamation)
        Else
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(generarReporte(), Nothing, "Balance01")
            Cursor = Cursors.Default
        End If

    End Sub

    Public Function crearParametros() As BalanceComprobacionParams
        Dim params As New BalanceComprobacionParams

        params.idEmpresa = SesionActual.idEmpresa
        params.detalle = getTipoDetalle()
        params.clasificacion = getTipoCuentaSeleccionada()
        params.fechaInicio = dtpFechaInicio.Value
        params.fechaFin = dtpFechaFin.Value

        Return params
    End Function

    Private Sub btCalcular_Click(sender As Object, e As EventArgs) Handles btCalcular.Click
        If validarFormulario() Then
            calcularBalance()
        End If
    End Sub

    Private Sub calcularBalance()
        Dim dtBalance As New DataTable

        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(getTipoCuentaSeleccionada)
        params.Add(CDate(dtpFechaInicio.Value).Date)
        params.Add(CDate(dtpFechaFin.Value).Date)

        General.llenarTabla(Consultas.BALANCE_COMPROBACION_CARGAR_PREV, params, dtBalance)
        dgBalance.DataSource = dtBalance
        dgBalance.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgBalance.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

    End Sub

    Private Function getTipoCuentaSeleccionada()
        Select Case True
            Case rbBalance.Checked
                Return Constantes.PUC_CLASIFICACION_BALANCE
            Case rbResultado.Checked
                Return Constantes.PUC_CLASIFICACION_RESULTADO
            Case Else
                Return Nothing
        End Select

    End Function

    Public Function getTipoDetalle() As Boolean
        Return rbCuentaTercero.Checked
    End Function

    Private Sub btExportaExcel_Click(sender As Object, e As EventArgs) Handles btExportaExcel.Click
        Try
            Dim nombreRpt As String = "balance01"
            Dim dtBalance As New DataTable
            Dim params As New List(Of String)

            Cursor = Cursors.WaitCursor
            params.Add(SesionActual.idEmpresa)
            params.Add(getTipoCuentaSeleccionada())
            params.Add(CDate(dtpFechaInicio.Value).Date)
            params.Add(CDate(dtpFechaFin.Value).Date)

            General.llenarTabla(Consultas.BALANCE_COMPROBACION_CARGAR_XLS, params, dtBalance)
            Dim ruta As String = FuncionesExcel.exportarDataTable(dtBalance, nombreRpt)

            Process.Start(ruta)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Public Function generarReporte() As rptBalanceComprobacion
        Dim rptLibro As New rptBalanceComprobacion

        Dim rango As String = dtpFechaInicio.Text & " - " & dtpFechaFin.Text

        Cursor = Cursors.WaitCursor
        rptLibro.SetParameterValue("IdEmpresa", SesionActual.idEmpresa)
        rptLibro.SetParameterValue("rango", rango)

        Return rptLibro

    End Function
End Class