Public Class FormSeguimientoFacturacion
    Private modulo As String
    Private objSeguimiento As New SeguimientoFacturacion
    Dim data As New DataView
    Private Sub Form_Configuracion_de_Procedimientos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormSeguimientoFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modulo = Nothing Then
            modulo = Tag.modulo
        End If
        General.limpiarControles(Me)
        Dim thisDay As DateTime = DateTime.Today
        Dim dTent As DateTime = thisDay.AddDays(thisDay.Day * -1 + 21)
        If dTent > thisDay Then
            dtpDesde.Value = thisDay.AddMonths(-1).AddDays(thisDay.Day * -1 + 21)
            dtpHasta.Value = dTent.AddDays(-1)
        Else
            dtpDesde.Value = dTent
            dtpHasta.Value = thisDay.AddMonths(1).AddDays(thisDay.Day * -1 + 21)
        End If
        Me.comboAreaServicio.SelectedIndex = 0
        cargarObjetos()
        cargarfacturas()
        dgvFactura.DataSource = objSeguimiento.Navegador.DataSource
        dgvFactura.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        Calcular()
        With dgvFactura
            .Columns("no").ReadOnly = True
            .Columns("no").DataPropertyName = "No"
            .Columns("no").Frozen = True

            .Columns("paciente").ReadOnly = True
            .Columns("paciente").DataPropertyName = "Paciente"
            .Columns("Paciente").Frozen = True

            .Columns("identificación").ReadOnly = True
            .Columns("identificación").DataPropertyName = "Identificación"
            .Columns("identificación").Frozen = True

            '.Columns("Area").ReadOnly = True
            '.Columns("Area").DataPropertyName = "Area"

            '.Columns("eps").ReadOnly = True
            '.Columns("eps").DataPropertyName = "EPS"

            .Columns("factura").ReadOnly = True
            .Columns("factura").DataPropertyName = "Factura"

            .Columns("valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("valor").DataPropertyName = "Valor"

            .Columns("fecha_factura").HeaderText = "Fecha Factura"
            .Columns("fecha_ingreso").HeaderText = "Fecha Ingreso"
            .Columns("fecha_egreso").HeaderText = "Fecha Egreso"
            .Columns("fecha_Visado").HeaderText = "Fecha Visado"
            .Columns("fecha_Radicación").HeaderText = "Fecha Radicación"
            .Columns("días_radicación").HeaderText = "Días Radicación"
            .Columns("días_visado").HeaderText = "Días Visado"
            .Columns("días_facturado").HeaderText = "Días Facturados"
            .Columns("días_estancias").HeaderText = "Días Estancia"
            .Columns("Total_días").HeaderText = "Total Días"
            .Columns("Glosa_Objetada").HeaderText = "Glosa Objetada"
            .Columns("valor_Glosa").HeaderText = "Valor Glosa"
            .Columns("valor_Glosa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("fechaf").DataPropertyName = "Fecha_Factura"

            '.Columns("Fechai").ReadOnly = True
            '.Columns("Fechai").DataPropertyName = "Fecha_Ingreso"

            '.Columns("fechae").ReadOnly = True
            '.Columns("fechae").DataPropertyName = "fecha_Egreso"

            '.Columns("fechav").ReadOnly = True
            '.Columns("fechav").DataPropertyName = "Fecha_Visado"

            '.Columns("fechar").ReadOnly = True
            '.Columns("fechar").DataPropertyName = "Fecha_Radicacion"

            '.Columns("diasr").ReadOnly = True
            '.Columns("diasr").DataPropertyName = "Dias_Radicacion"

            '.Columns("diasv").ReadOnly = True
            '.Columns("diasv").DataPropertyName = "Dias_Visado"

            '.Columns("diasf").ReadOnly = True
            '.Columns("diasf").DataPropertyName = "Dias_Facturado"

            '.Columns("estancia").ReadOnly = True
            '.Columns("estancia").DataPropertyName = "Estancias"

            '.Columns("total").ReadOnly = True
            '.Columns("total").DataPropertyName = "Total"

            '.Columns("atencion").ReadOnly = True
            '.Columns("atencion").SortMode = DataGridViewColumnSortMode.NotSortable
            '.Columns("atencion").DataPropertyName = "Atencion"

            '.Columns("OGlosa").ReadOnly = True
            '.Columns("OGlosa").SortMode = DataGridViewColumnSortMode.NotSortable
            '.Columns("OGlosa").DataPropertyName = "Glosa_Objetada"

            '.Columns("VGlosa").ReadOnly = True
            '.Columns("VGlosa").DataPropertyName = "Valor_Glosa"
        End With

    End Sub

    Sub Calcular()
        If dgvFactura.DataSource.Rows.Count = 0 Then
            lbtEgresos.Text = "0 Egresos: 0"
            lbtFacturas.Text = "0 Facturada(s): 0 "
            lbtSinFacturas.Text = "0 Sin facturar: 0"
            lbtRadicadas.Text = "0 F. Radicada(s): 0"
            lbtSinRadicar.Text = "0 F. Sin radicar: 0"
            lbtProDiasF.Text = "Dias Facturado(s): 0"
            lbtProDiasR.Text = "Dias Radicado(s): 0"
            lbtProEst.Text = "Estancia: 0"
            lbtProTotalDias.Text = "Total: 0"
            Exit Sub
        End If
        If data.RowFilter <> "" Then
            dgvFactura.DataSource = data.ToTable
        End If
        Dim dt As New DataTable
        dt = dgvFactura.DataSource
        lbtEgresos.Text = dt.Rows.Count & " Egresos: " & Format(IIf(IsDBNull(dt.Compute("Sum(Valor)", "")), 0, dt.Compute("Sum(Valor)", "")), "c2")
        lbtFacturas.Text = dt.Select("Factura Is Not Null").Count & " Facturada(s): " & Format(IIf(IsDBNull(dt.Compute("Sum(Valor)", "Factura Is Not Null")), 0, dt.Compute("Sum(Valor)", "Factura Is Not Null")), "c2")
        lbtSinFacturas.Text = dt.Select("Factura Is Null").Count & " Sin facturar: " & Format(IIf(IsDBNull(dt.Compute("Sum(Valor)", "Factura Is Null")), 0, dt.Compute("Sum(Valor)", "Factura Is Null")), "c2")
        lbtRadicadas.Text = dt.Select("Fecha_Radicación Is Not Null").Count & " F. Radicada(s): " & Format(IIf(IsDBNull(dt.Compute("Sum(Valor)", "Fecha_Radicación Is not Null")), 0, dt.Compute("Sum(Valor)", "Fecha_Radicación Is not Null")), "c2")
        lbtSinRadicar.Text = dt.Select("Fecha_Radicación Is Null").Count & " F. Sin radicar: " & Format(IIf(IsDBNull(dt.Compute("Sum(Valor)", "Fecha_Radicación Is Null")), 0, dt.Compute("Sum(Valor)", "Fecha_Radicación Is Null")), "c2")
        lbtProDiasF.Text = "Dias Facturado(s): " & If(IsDBNull(dt.Compute("Avg(Días_Facturado)", "Días_Facturado Is Not Null")), 0, dt.Compute("Avg(Días_Facturado)", "Días_Facturado Is Not Null"))
        lbtProDiasR.Text = "Dias Radicado(s):  " & If(IsDBNull(dt.Compute("Avg(Días_Radicación)", "Días_Radicación Is Not Null")), 0, dt.Compute("Avg(Días_Radicación)", "Días_Radicación Is Not Null"))
        lbtProEst.Text = "Estancia: " & If(IsDBNull(dt.Compute("Avg(Días_Estancias)", "Días_Estancias Is Not Null")), 0, dt.Compute("Avg(Días_Estancias)", "Días_Estancias Is Not Null"))
        lbtProTotalDias.Text = "Total: " & If(IsDBNull(dt.Compute("Avg(Total_Días)", "Total_Días Is Not Null")), 0, dt.Compute("Avg(Total_Días)", "Total_Días Is Not Null"))
    End Sub


    Public Sub cargarObjetos()
        objSeguimiento.fechadesde = dtpDesde.Value.Date
        objSeguimiento.fechahasta = dtpHasta.Value.Date
        objSeguimiento.condicion = comboAreaServicio.SelectedIndex
        If objSeguimiento.condicion = 1 Or objSeguimiento.condicion = 4 Then
            Me.dtpDesde.Enabled = False
            Me.dtpHasta.Enabled = False
        Else
            Me.dtpDesde.Enabled = True
            Me.dtpHasta.Enabled = True
        End If
    End Sub
    Public Sub cargarfacturas()

        If modulo = Nothing Then
            modulo = Tag.modulo
        End If
        objSeguimiento.modulo = modulo
        objSeguimiento.cargarPacienteFactura()

        Dim columna As DataGridViewColumnCollection = dgvFactura.Columns
        If dgvFactura.RowCount > 0 Then
            If objSeguimiento.condicion = 1 Then
                columna("Factura").Visible = False
                columna("Fecha_Factura").Visible = False
                columna("Fecha_Radicación").Visible = False
                columna("Días_Radicación").Visible = False
                columna("Días_Facturado").Visible = False
                columna("Glosa_Objetada").Visible = False
                columna("Valor_Glosa").Visible = False
            Else
                columna("Factura").Visible = True
                columna("Fecha_Factura").Visible = True
                columna("Fecha_Radicación").Visible = True
                columna("Días_Radicación").Visible = True
                columna("Días_Facturado").Visible = True
                columna("Glosa_Objetada").Visible = True
                columna("Valor_Glosa").Visible = True
            End If
        End If

        dgvFactura.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
    End Sub

    Private Sub dgvFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFactura.CellFormatting

        If e.ColumnIndex = 6 Or e.ColumnIndex = 19 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        ElseIf e.ColumnIndex = 5 Then

            'If e.Value = "0" Then
            '    e.Value = Format("")
            'End If
        End If
    End Sub
    Private Sub busquedaPaciente_TextChanged(sender As Object, e As EventArgs) Handles busquedaPaciente.TextChanged
        Dim cadena As String
        Me.busquedaPaciente.Text = Funciones.validarComillaSimple(busquedaPaciente.Text)
        If objSeguimiento.dtFacturacion.Columns.Count > 0 Then
            cadena = "Paciente like '%" & Me.busquedaPaciente.Text & "%'" & " OR Identificación like '%" & Me.busquedaPaciente.Text & "%'" & " OR Area like '%" & Me.busquedaPaciente.Text & "%'" &
                     " OR EPS like '%" & Me.busquedaPaciente.Text & "%'" & " OR Factura like '%" & Me.busquedaPaciente.Text & "%'"
            data = objSeguimiento.dtFacturacion.DefaultView
            objSeguimiento.Navegador.Filter = cadena
            data.RowFilter = cadena
            Calcular()
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If comboAreaServicio.SelectedIndex >= 0 Then
            cargarObjetos()
            cargarfacturas()
            dgvFactura.DataSource = objSeguimiento.Navegador.DataSource
            Calcular()
        Else
            objSeguimiento.dtFacturacion.Clear()
        End If
    End Sub
End Class