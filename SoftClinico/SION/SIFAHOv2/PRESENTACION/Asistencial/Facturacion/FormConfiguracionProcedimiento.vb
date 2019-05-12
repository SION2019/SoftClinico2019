Public Class FormConfiguracionProcedimiento
    Dim objConfiguracion As New ConfiguracionChequeo
    Dim codigo As Integer
    Private Sub FormConfiguracionProcedimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvprocedimiento
            .Columns("Codigoprocedimiento").ReadOnly = True
            .Columns("Codigoprocedimiento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigoprocedimiento").DataPropertyName = "Codigo Procedimiento"
            .Columns("Codigoprocedimiento").Width = 90
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").Width = 685
            .Columns("codigopadre").ReadOnly = True
            .Columns("codigopadre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("codigopadre").DataPropertyName = "Codigo Padre"
        End With
        cargarProcedimientos()
        With dgvExepciones
            .Columns("Codigoprocedimiento1").ReadOnly = True
            .Columns("Codigoprocedimiento1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigoprocedimiento1").DataPropertyName = "Codigo Procedimiento"
            .Columns("Codigoprocedimiento1").Width = 90
            .Columns("Descripcion1").ReadOnly = True
            .Columns("Descripcion1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion1").DataPropertyName = "Descripción"
            .Columns("Descripcion1").Width = 685
        End With
        cargarExepciones()
    End Sub

    Public Sub registros(ByVal codigoConf As Integer)
        codigo = codigoConf
    End Sub

    Public Sub cargarProcedimientos()
        objConfiguracion.codigoChequeo = codigo
        objConfiguracion.cargarProcedimientos()
        dgvprocedimiento.DataSource = objConfiguracion.dtProcedimientos
    End Sub
    Public Sub cargarExepciones()
        objConfiguracion.codigoChequeo = codigo
        objConfiguracion.cargarProcedimientosExepcion()
        dgvExepciones.DataSource = objConfiguracion.dtExepciones
    End Sub
    Private Sub dgvprocedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellDoubleClick
        If e.ColumnIndex = 1 Then
            Try
                objConfiguracion.codigoProcedimiento = dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("CodigoProcedimiento").Value
                objConfiguracion.descripcionProcedimiento = dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells("Descripcion").Value
                objConfiguracion.codigoChequeo = codigo
                objConfiguracion.guardarProcedimientos()

                cargarProcedimientos()
                cargarExepciones()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        objConfiguracion.busqueda = txtbusqueda.Text
        cargarProcedimientos()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda2.TextChanged
        objConfiguracion.busqueda = txtbusqueda2.Text
        cargarExepciones()
    End Sub

    Private Sub dgvExepciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExepciones.CellDoubleClick
        If e.ColumnIndex = 1 Then
            Try
                objConfiguracion.codigoProcedimiento = dgvExepciones.Rows(dgvExepciones.CurrentCell.RowIndex).Cells("CodigoProcedimiento1").Value
                objConfiguracion.codigoChequeo = codigo
                objConfiguracion.exepcionQuitar()

                cargarExepciones()
                cargarProcedimientos()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class