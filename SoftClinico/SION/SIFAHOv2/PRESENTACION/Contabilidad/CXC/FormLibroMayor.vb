Imports System.Data.SqlClient

Public Class FormLibroMayor
    Private Sub Form_BalanceComprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNit.Text = Funciones.empresaActual.nit
        txtRazonSocial.Text = Funciones.empresaActual.razonSocial

        dtpFechaInicio.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dtpFechaFin.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)

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
    Public Function crearParametros() As LibroMayorParams
        Dim params As New LibroMayorParams

        params.idEmpresa = SesionActual.idEmpresa
        params.fechaInicio = dtpFechaInicio.Value
        params.fechaFin = dtpFechaFin.Value

        Return params
    End Function

    Private Sub btExportaExcel_Click(sender As Object, e As EventArgs) Handles btExportaExcel.Click
        Try
            Dim nombreRpt As String = "libro_mayor01"
            Dim dtLibroMayor As New DataTable
            Dim params As New List(Of String)

            Cursor = Cursors.WaitCursor
            params.Add(SesionActual.idEmpresa)
            params.Add(CDate(dtpFechaInicio.Value).Date)
            params.Add(CDate(dtpFechaFin.Value).Date)

            General.llenarTabla("PROC_E_LIBRO_MAYOR_CARGAR_PADRES_XLS", params, dtLibroMayor)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtLibroMayor, nombreRpt)

            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        Try
            visualizarReporte(ExportFormatType.PortableDocFormat)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub


    Public Function generarReporte() As rptLibroMayor
        Dim rptLibro As New rptLibroMayor

        Dim rango As String = dtpFechaInicio.Text & " - " & dtpFechaFin.Text

        Cursor = Cursors.WaitCursor
        rptLibro.SetParameterValue("IdEmpresa", SesionActual.idEmpresa)
        rptLibro.SetParameterValue("rango", rango)

        Return rptLibro

    End Function

    Public Sub visualizarReporte(formato As CrystalDecisions.Shared.ExportFormatType)
        Dim objLibroMayorBLL As New LibroMayorBLL
        Dim params As New LibroMayorParams

        params = crearParametros()
        objLibroMayorBLL.calcularlibroMayor(params)


        If params.resultado = False Then
            MsgBox(Mensajes.CONTA_RESULTADO_VACIO, MsgBoxStyle.Exclamation)
        Else
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(generarReporte(), Nothing, "LibroMayor01")
            Cursor = Cursors.Default
        End If

    End Sub
End Class