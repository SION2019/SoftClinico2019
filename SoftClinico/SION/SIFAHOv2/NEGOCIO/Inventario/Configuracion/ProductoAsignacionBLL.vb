Public Class ProductoAsignacionBLL
    Dim cmd As New ProductoAsignacionDAL
    Dim cmd2 As New ProductoDAL
    Public Function seleccionados_sin_asignar(ByVal dt As Object) As DataTable
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = dt.Clone()
        rows = dt.Select("[Asignar] = True")
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        rows = Nothing
        Form_asignar_productos.dgvPorAsignar.Columns(Form_asignar_productos.dgvPorAsignar.Columns.Count - 1).Visible = False
        Return dtNew
    End Function
    Public Function seleccionados_asignados(ByVal dt As Object) As DataTable
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = dt.Clone()
        rows = dt.Select("[Asignar] = True")
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        rows = Nothing
        Form_asignar_productos.dgvAsignados.Columns(Form_asignar_productos.dgvAsignados.Columns.Count - 1).Visible = False
        Return dtNew
    End Function
    Public Function asignar_productos(ByVal tabla As DataTable, ByVal codigo_bodega As Integer) As Boolean
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = tabla.Clone()
        rows = tabla.Select("[Asignar] = True")
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        If cmd.asignarProductos(dtNew, codigo_bodega) = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function quitar_productos(ByRef objProductoBodega As AsignarProductosBodega) As Boolean
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = objProductoBodega.tablaProductosAsignados.Clone()
        rows = objProductoBodega.tablaProductosAsignados.Select("[Asignar] = True")
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        If cmd.quitarProductos(objProductoBodega, dtNew) = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificar_existencia_producto(ByVal Codigo_producto As String, ByVal Codigo_Bodega As String) As Boolean
        If cmd2.verificar_existencia_producto(Codigo_producto, Codigo_Bodega) = True Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
