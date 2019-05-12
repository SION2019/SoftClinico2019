Public Class FormEstadoCXC
    Dim dtEstadoCuentas, dtestadoDias, dtGeneral As New DataTable
    Dim formulario, nit, tituloReporte As String
    Dim reporte As New ftp_reportes
    Private Sub btBusquedaCuenta_Click(sender As Object, e As EventArgs) Handles btBusquedaCuenta.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        Dim consulta As String = ""
        If formulario = Constantes.CXC Then
            consulta = Consultas.BUSQUEDA_CLIENTES
        ElseIf formulario = Constantes.CXP Then
            consulta = Consultas.BUSQUEDA_PROVEEDOR
        End If
        General.buscarElemento(consulta,
                               params,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               True, 0, True)

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
    Private Sub llenarFacturas(pCodigo As String, fechaInicio As Date, fechaFinal As Date)
        Dim consulta As String = ""
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(fechaInicio)
        params.Add(fechaFinal)
        params.Add(SesionActual.idEmpresa)
        If formulario = Constantes.CXC Then
            tituloReporte = Constantes.NOMBRE_ESTADO_DE_CUENTAS_CXC
            consulta = Consultas.ESTADO_CUENTAS_POR_COBRAR
        ElseIf formulario = Constantes.CXP Then
            consulta = Consultas.ESTADO_CUENTAS_POR_PAGAR
            tituloReporte = Constantes.NOMBRE_ESTADO_DE_CUENTAS_CXP
        End If
        General.llenarTabla(consulta, params, dtEstadoCuentas)
        If dtEstadoCuentas.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            llenarDias()
            btimprimir.Enabled = True
            btexcel.Enabled = True
        Else
            dtGeneral.Clear()
        End If

    End Sub
    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        texttercero.Text = pCodigo
        General.llenarTabla(Consultas.TERCERO_CONTABILIDAD_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            texttercero.Text = dt.Rows(0).Item("Id_tercero").ToString()
            textnombretercero.Text = dt.Rows(0).Item("Tercero").ToString()
            nit = dt.Rows(0).Item("Nit").ToString()
            llenarFacturas(texttercero.Text, fechaini.Value.Date, fechafin.Value.Date)
        End If
    End Sub
    Public Sub llenarDias()
        'Dim consulta As String = ""
        'If formulario = Constantes.CXC Then
        '    consulta = Consultas.ESTADO_CUENTAS_DIAS
        'ElseIf formulario = Constantes.CXP Then
        '    consulta = Consultas.ESTADO_CUENTAS_DIAS_CXP
        'End If
        dtestadoDias.Clear()
        enlazarGeneral()

        For indicedgv = 0 To dtGeneral.Rows.Count - 1
            'Dim params As New List(Of String)
            'params.Add(dtGeneral.Rows(indicedgv).Item("Codigo_Factura").ToString)
            'General.llenarTabla(consulta, params, dtestadoDias)

            Dim fechaVence = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA))
            Dim diasMora As Integer = (fechaVence.Subtract(dgvCuentas.Rows(indicedgv).Cells("dgfechaRadicado").Value).TotalDays)
            Dim dias As Integer = (fechaVence.Subtract(dgvCuentas.Rows(indicedgv).Cells("dgfechaRadicado").Value).TotalDays)

            dgvCuentas.Rows(indicedgv).Cells(getPosiciondgv(dias)).Value = CDbl(dtEstadoCuentas.Rows(indicedgv).Item(6))
            dgvCuentas.Rows(indicedgv).Cells(9).Value = dias

        Next
        calcularTotales()
        dgvCuentas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvCuentas.EndEdit()
        Cursor = Cursors.Default
    End Sub

    Public Function getPosiciondgv(dias As Integer)
        Dim posicion As Integer

        Select Case dias
            Case 0 To 30
                posicion = 3
            Case 31 To 60
                posicion = 4
            Case 61 To 90
                posicion = 5
            Case 91 To 180
                posicion = 6
            Case 181 To 360
                posicion = 7
            Case Else
                posicion = 8
        End Select

        Return posicion

    End Function
    Public Function getTotal(posColumna As Integer) As Double
        Dim total As Double = 0
        For i = 0 To dgvCuentas.Rows.Count - 1

            total += dgvCuentas.Rows(i).Cells(posColumna).Value

        Next
        Return CDbl(Math.Abs(total)).ToString("C2")
    End Function

    Private Sub calcularTotales()
        Dim v30Dias, v60Dias, v90Dias, v180Dias, v360Dias, vMas360Dias, total As Double

        v30Dias = getTotal(3)
        text30dias.Text = v30Dias

        v60Dias = getTotal(4)
        text60dias.Text = v60Dias

        v90Dias = getTotal(5)
        text90dias.Text = v90Dias

        v180Dias = getTotal(6)
        text180dias.Text = v180Dias

        v360Dias = getTotal(7)
        text360dias.Text = v360Dias

        vMas360Dias = getTotal(8)
        textmas360dias.Text = vMas360Dias

        total = 0
        total = Math.Abs(CInt(v30Dias) + (v60Dias) + (v90Dias) + (v180Dias) + (v360Dias) + (vMas360Dias))
        textvalortotal.Text = total
        text30dias.Text = CDbl(text30dias.Text).ToString("C2")
        text60dias.Text = CDbl(text60dias.Text).ToString("C2")
        text90dias.Text = CDbl(text90dias.Text).ToString("C2")
        text180dias.Text = CDbl(text180dias.Text).ToString("C2")
        text360dias.Text = CDbl(text360dias.Text).ToString("C2")
        textmas360dias.Text = CDbl(textmas360dias.Text).ToString("C2")
        textvalortotal.Text = CDbl(textvalortotal.Text).ToString("C2")


    End Sub
    Private Sub FormEstadoCXC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fechaini.Value = "01/01/2010"
        If formulario = Nothing Then
            formulario = Tag.codigo
        End If
        Select Case formulario
            Case Constantes.CXC
                Label1.Text = Constantes.NOMBRE_ESTADO_DE_CUENTAS_CXC
            Case Constantes.CXP
                Label1.Text = Constantes.NOMBRE_ESTADO_DE_CUENTAS_CXP
        End Select
        enlazarTabla()

    End Sub
    Sub enlazarGeneral()
        dtGeneral.Clear()
        dtGeneral.Merge(dtEstadoCuentas)
        dtGeneral.Merge(dtestadoDias)
    End Sub

    Private Sub fechafin_ValueChanged(sender As Object, e As EventArgs) Handles fechafin.ValueChanged
        If textnombretercero.Text <> "" Then
            llenarFacturas(texttercero.Text, fechaini.Value.Date, fechafin.Value.Date)
        End If
    End Sub

    Private Sub enlazarTabla()
        Dim col02, col03, col04, col05, col06, col07, col08, col09, col10,
              col01 As New DataColumn

        col01.ColumnName = "Codigo_Factura"
        col01.DataType = Type.GetType("System.String")
        dtEstadoCuentas.Columns.Add(col01)

        col02.ColumnName = "Fecha_Doc"
        col02.DataType = Type.GetType("System.DateTime")
        dtEstadoCuentas.Columns.Add(col02)

        col03.ColumnName = "Fecha_Vence"
        col03.DataType = Type.GetType("System.DateTime")
        dtEstadoCuentas.Columns.Add(col03)


        col04.ColumnName = "30dias"
        col04.DataType = Type.GetType("System.Double")
        col04.DefaultValue = 0
        dtestadoDias.Columns.Add(col04)

        col05.ColumnName = "60dias"
        col05.DataType = Type.GetType("System.Double")
        col05.DefaultValue = 0
        dtestadoDias.Columns.Add(col05)

        col06.ColumnName = "90dias"
        col06.DataType = Type.GetType("System.Double")
        col06.DefaultValue = 0
        dtestadoDias.Columns.Add(col06)

        col07.ColumnName = "180dias"
        col07.DataType = Type.GetType("System.Double")
        col07.DefaultValue = 0
        dtestadoDias.Columns.Add(col07)

        col08.ColumnName = "360dias"
        col08.DataType = Type.GetType("System.Double")
        col08.DefaultValue = 0
        dtestadoDias.Columns.Add(col08)

        col09.ColumnName = "mas360dias"
        col09.DataType = Type.GetType("System.Double")
        col09.DefaultValue = 0
        dtestadoDias.Columns.Add(col09)

        col10.ColumnName = "Dias"
        col10.DataType = Type.GetType("System.Int32")
        col10.DefaultValue = 0
        dtestadoDias.Columns.Add(col10)
        enlazarGeneral()

        With dgvCuentas

            .Columns.Item("dgfactura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfactura").DataPropertyName = "Codigo_Factura"

            .Columns.Item("dgfechaRadicado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechaRadicado").DataPropertyName = "Fecha_Doc"

            .Columns.Item("dgFechaVence").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgFechaVence").DataPropertyName = "Fecha_Vence"

            .Columns.Item("dg30Dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dg30Dias").DefaultCellStyle.Format = "c"
            .Columns.Item("dg30Dias").DataPropertyName = "30dias"

            .Columns.Item("dg60Dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dg60Dias").DefaultCellStyle.Format = "c"
            .Columns.Item("dg60Dias").DataPropertyName = "60dias"

            .Columns.Item("dg90Dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dg90Dias").DefaultCellStyle.Format = "c"
            .Columns.Item("dg90Dias").DataPropertyName = "90dias"

            .Columns.Item("dg180Dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dg180Dias").DefaultCellStyle.Format = "c"
            .Columns.Item("dg180Dias").DataPropertyName = "180dias"

            .Columns.Item("dg360Dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dg360Dias").DefaultCellStyle.Format = "c"
            .Columns.Item("dg360Dias").DataPropertyName = "360dias"

            .Columns.Item("dgmas360Dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgmas360Dias").DefaultCellStyle.Format = "c"
            .Columns.Item("dgmas360Dias").DataPropertyName = "mas360dias"

            .Columns.Item("dgdias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgdias").DataPropertyName = "Dias"

            .AutoGenerateColumns = False
            .DataSource = dtGeneral
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .ReadOnly = True
        End With
    End Sub

    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        btimprimir.Enabled = False
        btexcel.Enabled = False
        guardarEstadoCuentas()

        Try
            Dim nombreRpt As String = "Estado de cartera"
            Dim dtEstadoCartera As New DataTable
            Dim params As New List(Of String)

            Cursor = Cursors.WaitCursor
            General.llenarTabla(Consultas.ESTADO_DE_CARTERA, Nothing, dtEstadoCartera)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtEstadoCartera, nombreRpt)

            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
        btimprimir.Enabled = True
        btexcel.Enabled = True
    End Sub


    Private Sub guardarEstadoCuentas()
        Dim objEstadoCuentasBLL As New EstadoCuentasBLL
        calcularTotales()

        Try
            objEstadoCuentasBLL.guardarEstadoCuentas(crearEstadoCuentas())

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function crearEstadoCuentas() As EstadoDeCuentas
        Dim objEstadocuentas As New EstadoDeCuentas
        Dim Total30dias,
        Total_60dias,
        Total_90dias,
        Total_180dias,
        Total_360dias,
        Total_mas360dias As Double

        Total30dias = text30dias.Text
        Total_60dias = text60dias.Text
        Total_90dias = text90dias.Text
        Total_180dias = text180dias.Text
        Total_360dias = text360dias.Text
        Total_mas360dias = textmas360dias.Text


        For Each drFila As DataRow In dtGeneral.Rows
            If drFila.Item("Codigo_Factura").ToString <> "" Then
                Dim drCuenta As DataRow = objEstadocuentas.dtCuentas.NewRow

                drCuenta.Item("Desde") = fechaini.Value
                drCuenta.Item("Hasta") = fechafin.Value
                drCuenta.Item("nit") = nit
                drCuenta.Item("Factura") = drFila.Item("Codigo_Factura")
                drCuenta.Item("FechaRecibo") = drFila.Item("Fecha_Doc")
                drCuenta.Item("FechaVence") = drFila.Item("Fecha_Vence")
                drCuenta.Item("a30dias") = drFila.Item("30dias")
                drCuenta.Item("a60dias") = drFila.Item("60dias")
                drCuenta.Item("a90dias") = drFila.Item("90dias")
                drCuenta.Item("a180dias") = drFila.Item("180dias")
                drCuenta.Item("a360dias") = drFila.Item("360dias")
                drCuenta.Item("mas360dias") = drFila.Item("mas360dias")
                drCuenta.Item("Total30dias") = Total30dias
                drCuenta.Item("Total_60dias") = Total_60dias
                drCuenta.Item("Total_90dias") = Total_90dias
                drCuenta.Item("Total_180dias") = Total_180dias
                drCuenta.Item("Total_360dias") = Total_360dias
                drCuenta.Item("Total_mas360dias") = Total_mas360dias
                drCuenta.Item("numDias") = drFila.Item("Dias")
                objEstadocuentas.dtCuentas.Rows.Add(drCuenta)
            End If
        Next
        Return objEstadocuentas
    End Function
    Public Sub imprimir()
        Dim rptEstadoCuentasCXC As New EstadoCXC
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pEmpresa", SesionActual.idEmpresa)
            tbl.Add("@pTituloReporte", tituloReporte)
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(rptEstadoCuentasCXC, Nothing, "EstadoCXC", Constantes.FORMATO_PDF, tbl)
            Cursor = Cursors.Default
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Try
            btimprimir.Enabled = False
            btexcel.Enabled = False
            guardarEstadoCuentas()
            imprimir()
            btimprimir.Enabled = True
            btexcel.Enabled = True
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub
End Class


