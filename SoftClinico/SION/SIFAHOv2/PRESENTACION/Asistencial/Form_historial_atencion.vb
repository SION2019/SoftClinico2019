Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports
Public Class Form_historial_atencion
    Dim dtLista As New DataTable
    Dim EnlceDta As BindingSource = New BindingSource
    Dim reporte As New ftp_reportes
    Dim objHistorial As New HistorialAtencion
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Form_historial_atencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim columnaBotonIn, columnaBotonEg As New DataGridViewButtonColumn

        columnaBotonIn.Name = Constantes.NOMBRE_COLUMNA_INGRESO
        columnaBotonEg.Name = Constantes.NOMBRE_COLUMNA_EGRESO
        columnaBotonIn.HeaderText = Constantes.NOMBRE_COLUMNA_ENCA_INGRESO
        columnaBotonEg.HeaderText = Constantes.NOMBRE_COLUMNA_ENCA_EGRESO
        columnaBotonIn.Text = Constantes.NOMBRE_COLUMNA_ENCA_INGRESO
        columnaBotonEg.Text = Constantes.NOMBRE_COLUMNA_ENCA_EGRESO

        columnaBotonIn.UseColumnTextForButtonValue = True
        columnaBotonEg.UseColumnTextForButtonValue = True

        With grillaHistorialAtencion
            .Columns.Add(columnaBotonIn)
            .Columns.Add(columnaBotonEg)
            .Columns(Constantes.NOMBRE_COLUMNA_INGRESO).Visible = False
            .Columns(Constantes.NOMBRE_COLUMNA_EGRESO).Visible = False
        End With

        rbIngreso.Checked = True
        dtfecha_inicio.Value = Format(General.fechaActualServidor, Constantes.FORMATO_FECHA2)
        dtfecha_fin.Value = Format(General.fechaActualServidor, Constantes.FORMATO_FECHA2)

        cargarComboContrato()
        cargarComboContacto()
        btConsultar.Enabled = True
    End Sub
    Private Sub cargarComboContrato()
        Dim params As New List(Of String)
        params.Add(Format(CDate(dtfecha_inicio.Value).Date, Constantes.FORMATO_FECHA2))
        params.Add(Format(CDate(dtfecha_fin.Value).Date, Constantes.FORMATO_FECHA2))
        params.Add(txtBusqueda.Text)
        General.cargarCombo(Consultas.LISTA_HISTORIAL_ATENCION_CONTRATO, params, "Contrato", "N_Registro", ComboContrato)
    End Sub
    Private Sub cargarComboContacto()
        Dim params As New List(Of String)
        params.Add(Format(CDate(dtfecha_inicio.Value).Date, Constantes.FORMATO_FECHA2))
        params.Add(Format(CDate(dtfecha_fin.Value).Date, Constantes.FORMATO_FECHA2))
        params.Add(txtBusqueda.Text)
        General.cargarCombo(Consultas.LISTA_HISTORIAL_ATENCION_CONTACTO, params, "Contacto", "N_Registro", ComboContacto)
    End Sub
    Public Sub llenardgv()


        Panel2.Visible = False
        Cursor = Cursors.WaitCursor
        Try
            llenarDtHistorial()

            grillaHistorialAtencion.DataSource = String.Empty
            grillaHistorialAtencion.DataSource = dtLista

            If dtLista.Rows.Count > 0 Then

                grillaHistorialAtencion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grillaHistorialAtencion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

                datosHistorial()
                armarGrillaHistorial()
                btimprimir.Enabled = True

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub llenarDtHistorial()
        Dim sqlParam As SqlParameter
        Dim consulta As String
        asociarObjetos()

        Try
            Dim params As New List(Of SqlParameter)
            sqlParam = New SqlParameter("@FECHA_INICIO", SqlDbType.NVarChar)
            sqlParam.Value = Format(CDate(objHistorial.setGetFechaIni), Constantes.FORMATO_FECHA2)
            params.Add(sqlParam)

            sqlParam = New SqlParameter("@FECHA_FIN", SqlDbType.NVarChar)
            sqlParam.Value = Format(CDate(objHistorial.setGetFechaFin), Constantes.FORMATO_FECHA2)
            params.Add(sqlParam)

            sqlParam = New SqlParameter("@COMBOCONTRATO", SqlDbType.NVarChar)
            sqlParam.Value = objHistorial.setGetContrato
            params.Add(sqlParam)

            sqlParam = New SqlParameter("@COMBOCONTACTO", SqlDbType.NVarChar)
            sqlParam.Value = objHistorial.setGetContacto
            params.Add(sqlParam)

            sqlParam = New SqlParameter("@CADENA", SqlDbType.NVarChar)
            sqlParam.Value = objHistorial.setGetBusqueda
            params.Add(sqlParam)

            consulta = If(rbIngreso.Checked = True, Consultas.BUSQUEDA_HISTORIAL_ATENCION_INGRESO,
                           Consultas.BUSQUEDA_HISTORIAL_ATENCION_EGRESO)

            dtLista.Clear()
            dtLista = General.llenarTabla(consulta, params)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub armarGrillaHistorial()

        Try
            With grillaHistorialAtencion
                .Columns("Registro").Visible = False
                .Columns(Constantes.NOMBRE_COLUMNA_INGRESO).Visible = True
                .Columns(Constantes.NOMBRE_COLUMNA_EGRESO).Visible = True
                .Columns(Constantes.NOMBRE_COLUMNA_INGRESO).DisplayIndex = 7
                .Columns(Constantes.NOMBRE_COLUMNA_EGRESO).DisplayIndex = 8
                If rbIngreso.Checked = True Then
                    .Columns(Constantes.NOMBRE_COLUMNA_EGRESO).Visible = False
                Else
                    .Columns(Constantes.NOMBRE_COLUMNA_EGRESO).Visible = True
                    .Columns("Fec. Egreso").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    datosHistorialEgreso()
                End If
                .Columns("Fec. Ingreso").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Contrato").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Documentos").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Paciente").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Edad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            validarGrilla()
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub validarGrilla()
        For columna = 0 To grillaHistorialAtencion.Columns.Count - 1
            grillaHistorialAtencion.Columns(columna).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub datosHistorial()
        Dim vSumaEstancia As Integer
        Dim promedioEstancia As Double
        LNpacientes.Text = dtLista.Rows.Count
        LnInRemision.Text = dtLista.Compute("COUNT([Via Ingreso])", "[Via Ingreso]='Remitido'")
        If dtLista.Rows.Count > 0 Then
            vSumaEstancia = dtLista.Compute("Sum(Estancia)", "")
            promedioEstancia = (vSumaEstancia / dtLista.Rows.Count)
            lPromedioEstancia.Text = Math.Ceiling(promedioEstancia) & "%"
        End If
    End Sub
    Private Sub datosHistorialEgreso()
        LnVivo.Text = CType(dtLista.Compute("COUNT([Salida])", "[Salida]='VIVO'"), String)
        lNMuerto.Text = dtLista.Compute("COUNT([Salida])", "[Salida]='MUERTO'")
        LnEgRemision.Text = dtLista.Compute("COUNT([Destino])", "[Destino]='Remitido'")
    End Sub
    Private Sub asociarObjetos()
        objHistorial.setGetFechaIni = Format(dtfecha_inicio.Value, Constantes.FORMATO_FECHA2)
        objHistorial.setGetFechaFin = Format(dtfecha_fin.Value, Constantes.FORMATO_FECHA2)
        objHistorial.setGetBusqueda = txtBusqueda.Text
        objHistorial.setGetContrato = If(ComboContrato.Text.ToString = Constantes.SELECCION,
                                              Nothing, ComboContrato.Text.ToString)
        objHistorial.setGetContacto = If(ComboContacto.Text.ToString = Constantes.SELECCION,
                                              Nothing, ComboContacto.Text.ToString)
    End Sub

    Private Sub dgvhistorial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaHistorialAtencion.CellClick
        Panel2.Visible = False
        If dtLista.Rows.Count > 0 Then
            If grillaHistorialAtencion.Rows(grillaHistorialAtencion.CurrentCell.RowIndex).Cells(Constantes.NOMBRE_COLUMNA_INGRESO).Selected = True Then
                Ltitulo.Text = TitulosForm.DIAGNOTICOS_INGRESO
                cargarDiagnostico(dtLista.Rows(grillaHistorialAtencion.CurrentCell.RowIndex).Item("Registro"), rbIngreso.Checked)
                Panel2.Visible = True
            ElseIf grillaHistorialAtencion.Rows(grillaHistorialAtencion.CurrentCell.RowIndex).Cells(Constantes.NOMBRE_COLUMNA_EGRESO).Selected = True Then
                Ltitulo.Text = TitulosForm.DIAGNOTICOS_EGRESO
                cargarDiagnostico(dtLista.Rows(grillaHistorialAtencion.CurrentCell.RowIndex).Item("Registro"), rbIngreso.Checked)
                Panel2.Visible = True
            End If
        End If
    End Sub
    Private Sub cargarDiagnostico(registro As Integer, estado As Boolean)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        Dim consulta As String
        consulta = If(estado = True, Consultas.CARGAR_DIAGNOSTICOS_ADMISION, Consultas.DIAGNOSTICOS_EGRESO_EPICRISIS)
        params.Add(registro)
        General.llenarTabla(consulta,
                             params, dt)
        dgvDiag.DataSource = dt
        With dgvDiag
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            If estado = True Then
                .Columns(2).Visible = False
            End If
        End With
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim params As New List(Of String)
        Dim ruta, area, nombreArchivo, formula As String
        Dim rprte As Object
        formula = String.Empty
        If grillaHistorialAtencion.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            area = Constantes.NOMBRE_HISTORIAL_ATENCION
            formula = "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa
            rprte = If(rbIngreso.Checked = True, New rptHistorialAtencionIngreso, New rptHistorialAtencionEgreso)

            params.Add(objHistorial.setGetFechaIni)
            params.Add(objHistorial.setGetFechaFin)
            params.Add(objHistorial.setGetContrato)
            params.Add(objHistorial.setGetContacto)
            params.Add(objHistorial.setGetBusqueda)

            Try
                nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & SesionActual.idUsuario & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = IO.Path.GetTempPath() & nombreArchivo
                reporte.crearReportePDF(area, SesionActual.idUsuario, rprte,
                                        SesionActual.idUsuario, formula,
                                       area, IO.Path.GetTempPath,,, params)
            Catch ex As Exception
                general.manejoErrores(ex) 
            End Try
            btimprimir.Enabled = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cargarOpcionesArbol()
        Dim dtArbol As New DataTable
        Dim consulta As String
        Try
            If rbIngreso.Checked = True Then
                consulta = Consultas.LISTA_HISTORIAL_ATENCION_INGRESO
            Else
                consulta = Consultas.LISTA_HISTORIAL_ATENCION_EGRESO
            End If
            General.llenarTabla(consulta, Nothing, dtArbol)
            cargarArbol(dtArbol)
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

    Private Sub cargarArbol(dtArbol As DataTable)
        Dim nodo As TreeNode
        Dim dFila As DataRow()
        arbolListtaItem.Nodes.Clear()
        arbolListtaItem.ExpandAll()
        Try
            dFila = dtArbol.Select()
            For Each Fila As DataRow In dFila
                nodo = New TreeNode
                nodo.Name = Fila.Item("Id")
                nodo.Text = Fila.Item("Opciones")
                arbolListtaItem.Nodes.Add(nodo)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub btopcion_Click(sender As Object, e As EventArgs) Handles btopcion.Click
        General.deshabilitarControles(Me)
        pOpciones.Visible = True
        arbolListtaItem.Enabled = True
        botonAplicar.Enabled = True
        btCerrar.Enabled = True
        cargarOpcionesArbol()
        objHistorial.seleccionarNodos(arbolListtaItem)
    End Sub
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        llenardgv()
        cargarComboContrato()
        cargarComboContacto()
    End Sub
    Private Sub botonAplicar_Click(sender As Object, e As EventArgs) Handles botonAplicar.Click
        objHistorial.ocultarColumnas(arbolListtaItem, grillaHistorialAtencion)
        General.habilitarControles(Me)
        pOpciones.Visible = False
    End Sub
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        General.habilitarControles(Me)
        pOpciones.Visible = False
    End Sub
    Private Sub ComboContacto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboContacto.SelectedIndexChanged,
                                                                                            ComboContrato.SelectedIndexChanged
    End Sub

    Private Sub dtfecha_fin_ValueChanged(sender As Object, e As EventArgs) Handles dtfecha_fin.ValueChanged
        If IsDate(Format(dtfecha_inicio.Value, Constantes.FORMATO_FECHA2)) And
            IsDate(Format(dtfecha_fin.Value, Constantes.FORMATO_FECHA2)) Then
            cargarComboContrato()
            cargarComboContacto()
        End If
    End Sub

    Private Sub btConsultar_Click(sender As Object, e As EventArgs) Handles btConsultar.Click
        llenardgv()
    End Sub
End Class