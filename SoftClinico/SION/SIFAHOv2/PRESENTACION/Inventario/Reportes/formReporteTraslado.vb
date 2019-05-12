Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class formReporteTraslado
    Dim objReporte As New Reporte
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pconsultar As String
    Private Sub formReporteTraslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pconsultar = permiso_general & "pp" & "01"

        cmbTipoConsulta.SelectedIndex = 0
        dtpFechaInicial.Value = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dtpFechaFinal.Value = New DateTime(Date.Now.Year, Date.Now.Month, DateTime.DaysInMonth(Date.Now.Year, Date.Now.Month))
    End Sub
#Region "Metodos"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Sub llenarCombo(ByVal consulta As String, ByVal displayM As String, ByVal valueM As String)
        General.cargarCombo(consulta, displayM, valueM, cmbPunto)
    End Sub
    Sub filtar()
        Cursor = Cursors.WaitCursor
        Dim params As New List(Of String)
        params.Add(Format(CDate(dtpFechaInicial.Value), "dd-MM-yyyy"))
        params.Add(Format(CDate(dtpFechaFinal.Value), "dd-MM-yyyy"))
        params.Add(cmbPunto.SelectedValue)
        params.Add(SesionActual.codigoEP)
        params.Add(cmbBodega.SelectedValue)

        Dim tipoConsulta As Reporte.tipoConsulta
        Select Case cmbTipoConsulta.SelectedItem
            Case "Orden Compra"
                tipoConsulta = Reporte.tipoConsulta.REPORTE_ORDEN_COMPRA
            Case "Recepción Técnica"
                tipoConsulta = Reporte.tipoConsulta.REPORTE_RECEPCION_TECNICA
            Case "Recepción Técnica Traslado"
                tipoConsulta = Reporte.tipoConsulta.REPORTE_RECEPCION_TECNICA_TRASLADO
            Case "Traslado" 'Traslado
                tipoConsulta = Reporte.tipoConsulta.REPORTE_TRASLADO
        End Select
        Try
            objReporte.realizarConsulta(params, tipoConsulta)
            llenarDatosDatagrid(objReporte.tablaRespuesta)
            totalizar()
        Catch ex As Exception
            Cursor = Cursors.Default
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub llenarDatosDatagrid(ByRef tablaResultado As DataTable)
        dgvHistorial.DataSource = tablaResultado
        General.diseñoDGV(dgvHistorial)
        If dgvHistorial.Columns.Contains("Total") Then
            dgvHistorial.Columns("Cantidad Producto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvHistorial.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvHistorial.Columns("Total").DefaultCellStyle.Format = "C2"
        End If
    End Sub
    Sub totalizar()
        If objReporte.tablaRespuesta.Rows.Count > 0 Then
            Dim total As Double = If(IsDBNull(objReporte.tablaRespuesta.Compute("sum(total)", "")), 0, objReporte.tablaRespuesta.Compute("sum(total)", ""))
            txtTotal.Text = FormatCurrency(total)
            txtCantidadMovimientos.Text = objReporte.tablaRespuesta.Rows.Count
        Else
            txtTotal.Text = FormatCurrency(0)
            txtCantidadMovimientos.Text = 0
        End If
    End Sub
    Sub llenarBodegas(ByVal codigoPunto As Integer)
        Dim params As New List(Of String)
        params.Add(codigoPunto)
        General.cargarCombo(Consultas.CARGAR_BODEGA_PUNTO, params, "nombre", "codigo_bodega", cmbBodega)
    End Sub
#End Region
#Region "botones"
    Private Sub btConsultar_Click(sender As Object, e As EventArgs) Handles btConsultar.Click
        If SesionActual.tienePermiso(Pconsultar) Then
            If cmbPunto.SelectedValue > -1 Then
                If cmbBodega.Visible = False Then
                    filtar()
                ElseIf (cmbBodega.Visible AndAlso cmbBodega.SelectedValue >= 0) Then
                    filtar()
                Else
                    MsgBox("Debe escoger la bodega para poder filtar!", MsgBoxStyle.Information)
                End If
            Else
                objReporte.tablaRespuesta.Clear()
                MsgBox("Debe seleccionar el punto antes de filtar", MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Function obtenerColumnasTamaño(ByRef dgvParam As DataGridView) As Single()
        Dim columnas As DataGridViewColumnCollection = dgvParam.Columns
        Dim values As Single() = New Single(columnas.Count - 1) {}
        For indiceColumna = 0 To columnas.Count - 1
            values(indiceColumna) = CSng(columnas(indiceColumna).Width)
        Next
        Return values
    End Function
    Public Sub configurarPDF(ByVal document As Document, ByRef dgvParam As DataGridView, ByVal Titulo As String)
        Dim datatable As New PdfPTable(dgvParam.Columns.Count)

        datatable.DefaultCell.Padding = 2
        Dim headerWith As Single() = obtenerColumnasTamaño(dgvParam)
        datatable.SetWidths(headerWith)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 1
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        Dim encabezado As New Paragraph(Titulo, New Font(Font.Name = "Arial", 18, Font.Bold))
        Dim texto As New Phrase("Fecha: " + Now.ToString, New Font(Font.Name = "Arial", 10, Font.Bold))
        For indiceColumna = 0 To dgvParam.ColumnCount - 1
            datatable.AddCell(dgvParam.Columns(indiceColumna).HeaderText)
        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 0.5

        For indiceFila = 0 To dgvParam.RowCount - 1
            datatable.DefaultCell.Padding = Padding.Left
            For indiceColumna = 0 To dgvParam.ColumnCount - 1
                If indiceFila Mod 2 = 0 Then
                    datatable.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY
                Else
                    datatable.DefaultCell.BackgroundColor = BaseColor.WHITE
                End If
                datatable.AddCell(dgvParam(indiceColumna, indiceFila).Value.ToString)
            Next
            datatable.CompleteRow()
        Next

        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR, params)

        Dim bites() As Byte = fila.Item("Logo")


        Dim IMAGEN As Image = Image.GetInstance(bites)   'Image.GetInstance("C:\Users\Public\Pictures\Sample Pictures\Koala.jpg")
        IMAGEN.ScalePercent(15)
        document.Add(IMAGEN)

        document.Add(encabezado)
        document.Add(texto)
        document.Add(datatable)
    End Sub
    Sub configuracionPagina(ByRef dgvParam As DataGridView, ByVal Titulo As String)
        Try
            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
            Dim filename As String = Path.GetTempPath & ConstantesHC.NOMBRE_PDF_SEPARADOR & Now.Ticks & Constantes.FORMATO_PDF
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()
            configurarPDF(doc, dgvParam, Titulo)
            doc.Close()
            Process.Start(filename)
        Catch ex As Exception
            MsgBox(ex.Message + " Se jodio esta vaina")
        End Try
    End Sub

#End Region
#Region "otros Eventos"

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        dtpFechaFinal.MinDate = dtpFechaInicial.Value
    End Sub
    Private Sub cmbTipoConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoConsulta.SelectedIndexChanged
        lblBodega.Visible = False
        cmbBodega.Visible = False
        If cmbTipoConsulta.SelectedIndex = 0 OrElse cmbTipoConsulta.SelectedIndex = 1 Then
            llenarCombo(Consultas.REPORTE_INVENTARIO_COMPRAS_LISTAR_PUNTOS, "NOMBRE", "codigo_EP")
        ElseIf cmbTipoConsulta.SelectedIndex = 3 Then
            lblBodega.Visible = True
            cmbBodega.Visible = True
            llenarCombo(Consultas.REPORTE_INVENTARIO_TRASLADOS_CARGAR_PUNTOS, "NOMBRE", "CODIGO_EP")
        End If
        objReporte.tablaRespuesta.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvHistorial.RowCount > 0 Then
            configuracionPagina(dgvHistorial, "Reporte de Movimientos")
        Else
            MsgBox("No hay datos para la impresión", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmbPunto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPunto.SelectedIndexChanged
        If cmbPunto.SelectedIndex > 0 Then
            objReporte.tablaRespuesta.Clear()
            llenarBodegas(cmbPunto.SelectedValue)
        End If
    End Sub
#End Region
End Class