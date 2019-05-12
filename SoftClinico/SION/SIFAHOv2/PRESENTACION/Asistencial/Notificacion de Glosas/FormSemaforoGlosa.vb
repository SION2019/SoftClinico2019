Public Class FormSemaforoGlosa
    Public idEps As String
    Public buseps As Boolean
    Public Property objFormNotificacion As FormNotificacionGlosa
    Public Property objFormDevolucion As FormDevolucionGlosa
    Public Property formulario As Integer = 0
    Public Sub cargarGlosas()
        Dim cadena As String = String.Empty
        Dim enlce_dta As BindingSource = New BindingSource
        Dim dtSemaforo As New DataTable
        Dim params As New List(Of String)
        Try
            If formulario = 1 Then
                dtSemaforo.Clear()
                If rtodos.Checked = True Then
                    params.Add(fechaini.Value.Date)
                    params.Add(fechafin.Value.Date)
                    params.Add(SesionActual.idEmpresa)
                    cadena = Consultas.SEMAFORO_DEVOLUCION_CARGAR
                ElseIf reps.Checked And textnit.Text <> "" Then
                    params.Add(idEps)
                    params.Add(fechaini.Value.Date)
                    params.Add(fechafin.Value.Date)
                    params.Add(SesionActual.idEmpresa)
                    cadena = Consultas.SEMAFORO_DEVOLUCION_EPS_CARGAR
                Else
                    dgvsemaforo.DataSource = Nothing
                    Exit Sub
                End If
                General.llenarTabla(cadena, params, dtSemaforo)
                dgvsemaforo.DataSource = dtSemaforo
                If dgvsemaforo.Rows.Count > 0 Then
                    dgvsemaforo.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvsemaforo.Columns.Item(1).Width = 590
                    dgvsemaforo.Columns.Item(3).Width = 60
                    dgvsemaforo.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            Else

                dtSemaforo.Clear()
                If rtodos.Checked = True Then
                    params.Add(fechaini.Value.Date)
                    params.Add(fechafin.Value.Date)
                    params.Add(SesionActual.idEmpresa)
                    cadena = Consultas.SEMAFORO_GLOSAS_CARGAR
                ElseIf reps.Checked And textnit.Text <> "" Then
                    params.Add(idEps)
                    params.Add(fechaini.Value.Date)
                    params.Add(fechafin.Value.Date)
                    params.Add(SesionActual.idEmpresa)
                    cadena = Consultas.SEMAFORO_GLOSAS_EPS_CARGAR
                Else
                    dgvsemaforo.DataSource = Nothing
                    Exit Sub
                End If
                General.llenarTabla(cadena, params, dtSemaforo)
                dgvsemaforo.DataSource = dtSemaforo
                If dgvsemaforo.Rows.Count > 0 Then
                    dgvsemaforo.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvsemaforo.Columns.Item(1).Width = 590
                    dgvsemaforo.Columns.Item(3).Width = 60
                    dgvsemaforo.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btbuscareps_Click(sender As System.Object, e As System.EventArgs) Handles btbuscareps.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.NOTIFICACION_GLOSA_BUSCAR_CLIENTES,
                              params,
                              AddressOf cargarTercero,
                              TitulosForm.BUSQUEDA_TERCERO,
                              True, Constantes.TAMANO_MEDIANO, True)
    End Sub
    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        idEps = pCodigo
        General.llenarTabla(Consultas.CONTA_CLIENTE_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textnit.Text = dt.Rows(0).Item("Nit").ToString()
            Texteps.Text = dt.Rows(0).Item("CLIENTE").ToString()
            cargarGlosas()
        End If
    End Sub
    Private Sub rtodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rtodos.CheckedChanged
        GroupEps.Visible = False
        cargarGlosas()
        dgvfacturas.Visible = False
    End Sub
    Private Sub reps_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles reps.CheckedChanged
        If reps.Checked Then
            GroupEps.Visible = True
        Else
            GroupEps.Visible = False
        End If
        textnit.Clear()
        Texteps.Clear()
        idEps = ""
        cargarGlosas()
        dgvfacturas.Visible = False
    End Sub

    Private Sub fechaini_ValueChanged(sender As System.Object, e As System.EventArgs) Handles fechaini.ValueChanged, fechafin.ValueChanged
        cargarGlosas()
    End Sub

    Private Sub grillasemaforo_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvsemaforo.CellFormatting
        If e.ColumnIndex = 3 Then
            If dgvsemaforo.Rows(e.RowIndex).Cells(3).Value <= 0 Then
                e.CellStyle.BackColor = Color.Red
                e.CellStyle.ForeColor = Color.White
            ElseIf dgvsemaforo.Rows(e.RowIndex).Cells(3).Value < Constantes.VALOR_DIAS_SEMAFORO_GLOSA Then
                e.CellStyle.BackColor = Color.Yellow
            ElseIf dgvsemaforo.Rows(e.RowIndex).Cells(3).Value >= Constantes.VALOR_DIAS_SEMAFORO_GLOSA Then
                e.CellStyle.BackColor = Color.PaleGreen
            End If
        End If
    End Sub

    Private Sub dgvsemaforo_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvsemaforo.CellDoubleClick
        cargarFacturas()
        dgvfacturas.Visible = True
    End Sub
    Public Sub cargarFacturas()
        Dim dtfactura As New DataTable
        Try
            Dim params As New List(Of String)
            params.Add(dgvsemaforo.Rows(dgvsemaforo.CurrentRow.Index).Cells(0).Value)
            params.Add(fechaini.Value.Date)
            params.Add(fechafin.Value.Date)
            If formulario = 1 Then
                General.llenarTabla(Consultas.SEMAFORO_DEVOLUCION_FACTURAS_CARGAR, params, dtfactura)
            Else
                General.llenarTabla(Consultas.SEMAFORO_GLOSA_FACTURAS_CARGAR, params, dtfactura)
            End If
            dgvfacturas.DataSource = dtfactura
            dgvfacturas.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvfacturas.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvfacturas.Columns.Item(2).Width = 300
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvsemaforo_Click(sender As System.Object, e As System.EventArgs) Handles dgvsemaforo.Click
        dgvfacturas.Visible = False
    End Sub

    Private Sub FormSemaforoGlosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btbuscareps.Enabled = True
        fechaini.Value = "01/12/2017"
        If formulario = 1 Then
            Label3.Text = "SEMAFORIZACION DE RESPUESTA A DEVOLUCION"
        Else
            Label3.Text = "SEMAFORIZACION DE RESPUESTA A GLOSAS"
        End If
    End Sub
End Class