Public Class FormMetaHistorico
    Dim objHistorico As New MetaHistorico
    Private Sub FormMetaHistorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.limpiarControles(Me)
        Dim objConfigMeta As New ConfigMetaEmpleado
        objConfigMeta.cargarMetaGeneral()
        Dim thisDay As DateTime = General.fechaActualServidor()
        Dim dTent As DateTime = thisDay.AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)
        If dTent > thisDay Then
            fechaInicio.Value = thisDay.AddMonths(-1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)
            fechaFin.Value = dTent.AddDays(-1)
        Else
            fechaInicio.Value = dTent
            fechaFin.Value = thisDay.AddMonths(1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte)
        End If
        enlazarTabla()
    End Sub
    Private Sub enlazarTabla()
        With dgvHistorico
            .Columns("dgIdEmpleado").DataPropertyName = "Id_Empleado"
            .Columns("dgEmpleado").DataPropertyName = "Empleado"
            .Columns("dgFechaMeta").DataPropertyName = "FechaMeta"
            .Columns("dgTotal").DataPropertyName = "Total"
            .Columns("dgMeta").DataPropertyName = "MetaAlcanzada"
            .Columns("dgPorcentaje").DataPropertyName = "Porcentaje"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DataSource = objHistorico.dtHistorico
        End With
    End Sub

    Private Sub FormMetaHistorico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cargarHistorico()
        dgvHistorico.ReadOnly = True
    End Sub
    Private Sub cargarHistorico()
        objHistorico.fechaInicio = fechaInicio.Value
        objHistorico.fechaFin = fechaFin.Value
        objHistorico.cargarHistorico()
    End Sub

    Private Sub fechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles fechaInicio.ValueChanged, fechaFin.ValueChanged
        cargarHistorico()
    End Sub
    Private Sub dgvMetas_CellFormatting(sender As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvHistorico.CellFormatting
        If IsNumeric(e.Value) Then
            If e.ColumnIndex = dgvHistorico.Columns("dgPorcentaje").Index Then
                e.Value = Format(Val(e.Value / 100), "p2")
            ElseIf e.ColumnIndex <> dgvHistorico.Columns("dgMeta").Index Then
                e.Value = Format(Val(e.Value), "c0")

            End If

        End If
    End Sub
End Class