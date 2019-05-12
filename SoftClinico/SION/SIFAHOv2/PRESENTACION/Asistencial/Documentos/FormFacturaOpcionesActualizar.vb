Public Class FormFacturaOpcionesActualizar
    Dim objFactura As FacturaAtencionAsistencial
    Public Sub cargarDatos(ByRef pObjFactura As FacturaAtencionAsistencial)
        objFactura = pObjFactura

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        objFactura.actualizaEstancias = cbEstancia.Checked
        objFactura.actualizaTraslados = cbTraslado.Checked
        objFactura.actualizaOxigenos = cbOxigeno.Checked
        objFactura.actualizaParaclinicos = cbParaclinico.Checked
        objFactura.actualizaHemoderivados = cbHemoderivado.Checked
        objFactura.actualizaProcedimientos = cbProcedimiento.Checked
        objFactura.actualizaMedicamentos = cbMedicamento.Checked
        objFactura.actualizaInsumos = cbInsumo.Checked
        DialogResult = DialogResult.OK
    End Sub
End Class