Public Class FormConfiguracionFacturacion
    Dim objSoporte As SoporteFacturacion
    Private Sub FormConfiguracionFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvconfiguracion
            .Columns("idcarpeta1").ReadOnly = True
            .Columns("idcarpeta1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("idcarpeta1").DataPropertyName = "Id Carpeta"
            .Columns("Codigoparametro").ReadOnly = True
            .Columns("Codigoparametro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigoparametro").DataPropertyName = "Codigo Parametro"
            .Columns("Codigoparametro").Width = 120
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripción"
            .Columns("Descripcion").Width = 778
        End With

        dgvconfiguracion.DataSource = objSoporte.bdPendiente

        With dgvConfigurado
            .Columns("idcarpeta").ReadOnly = True
            .Columns("idcarpeta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("idcarpeta").DataPropertyName = "Id Carpeta"
            .Columns("Codigoparametro1").ReadOnly = True
            .Columns("Codigoparametro1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigoparametro1").DataPropertyName = "Codigo Parametro"
            .Columns("Codigoparametro1").Width = 120
            .Columns("Descripcion1").ReadOnly = True
            .Columns("Descripcion1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion1").DataPropertyName = "Descripción"
            .Columns("Descripcion1").Width = 778
        End With
        dgvConfigurado.DataSource = objSoporte.bdConfigurado
        filtrar()
    End Sub

    Public Sub cargarSoporte()
        objSoporte.cargarSoporte()
    End Sub

    Public Sub nombreCarpeta(ByVal indice As Integer, ByRef objC As SoporteFacturacion)
        txtnombre.Text = objC.dtFacturacion.Rows(indice).Item("Carpeta").ToString
        objC.idCarpetaActual = IIf(String.IsNullOrEmpty(objC.dtFacturacion.Rows(indice).Item("id carpeta").ToString), txtnombre.Text, objC.dtFacturacion.Rows(indice).Item("id carpeta").ToString)
        objSoporte = objC
    End Sub

    Private Sub dgvconfiguracion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvconfiguracion.CellDoubleClick
        If e.RowIndex > -1 Then
            dgvconfiguracion.EndEdit()
            objSoporte.dtConfigurado.AcceptChanges()
            objSoporte.moverSoporte(1, dgvconfiguracion.Rows(e.RowIndex).Cells("Codigoparametro").Value.ToString)
            filtrar()
        End If
    End Sub

    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            If dgvConfigurado.Rows.Count = 0 Then
                objSoporte.dtConfigurado.Clear()
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvConfigurado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConfigurado.CellDoubleClick
        If e.RowIndex > -1 Then
            objSoporte.moverSoporte(2, dgvConfigurado.Rows(e.RowIndex).Cells("Codigoparametro1").Value.ToString)
            filtrar()
        End If
    End Sub
    Private Sub filtrar()
        objSoporte.bdPendiente.Filter = "[id carpeta]='-1'"
        objSoporte.bdConfigurado.Filter = "[id carpeta]='" & objSoporte.idCarpetaActual & "'"
    End Sub
End Class