Public Class TipoExamenBLL
    Public Shared Function guardarTipoExamen(objConfiguracion As ConfiguracionGeneral)
        TipoExamenDAL.guardarTipoExamen(objConfiguracion)
        Return objConfiguracion
    End Function
    Public Sub llenarCombo(cbTipo As ComboBox)
        Dim dtTabla As New DataTable
        Dim drFila As DataRow = dtTabla.NewRow()
        dtTabla.Columns.Add("Codigo")
        dtTabla.Columns.Add("Descripcion")
        drFila.Item(0) = "-1"
        drFila.Item(1) = " - - - Seleccione - - - "
        dtTabla.Rows.Add(drFila)
        cbTipo.DataSource = llenarItem(dtTabla)
        cbTipo.ValueMember = "codigo"
        cbTipo.DisplayMember = "Descripcion"
    End Sub
    Private Function llenarItem(ByRef dt As DataTable) As DataTable
        For j = 0 To 2
            dt.Rows.Add()
        Next

        dt.Rows(1).Item(0) = "0"
        dt.Rows(1).Item(1) = "Aplica Laboratorio"

        dt.Rows(2).Item(0) = "1"
        dt.Rows(2).Item(1) = "Aplica Imagen"

        dt.Rows(3).Item(0) = "2"
        dt.Rows(3).Item(1) = "Aplica PDF"
        Return dt
    End Function
End Class