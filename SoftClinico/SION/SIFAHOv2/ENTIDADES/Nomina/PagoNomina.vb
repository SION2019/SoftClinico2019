Public Class PagoNomina
    Public Property codigoEmpresa As String
    Public Property fechaInical As Date
    Public Property fechaFin As Date
    Public Property dtPagoNom As DataTable
    Public Property Navegador As BindingSource
    Public Sub New()
        dtPagoNom = New DataTable
        Navegador = New BindingSource
        dtPagoNom.Columns.Add("Empresa", Type.GetType("System.String"))
        dtPagoNom.Columns.Add("Identificación", Type.GetType("System.Int32"))
        dtPagoNom.Columns.Add("Nombre", Type.GetType("System.String"))
        dtPagoNom.Columns.Add("Cargo", Type.GetType("System.String"))
        dtPagoNom.Columns.Add("Devengado", Type.GetType("System.Int32"))
        dtPagoNom.Columns.Add("Periodo", Type.GetType("System.String"))
        Navegador.DataSource = dtPagoNom
    End Sub
    Public Sub cargarPagoNomina()
        Dim params As New List(Of String)
        params.Add(codigoEmpresa)
        params.Add(Format(fechaInical, Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(fechaFin, Constantes.FORMATO_FECHA_GEN))
        General.llenarTabla(Consultas.PAGOS_NOMINA_CARGAR, params, dtPagoNom)
    End Sub
End Class
