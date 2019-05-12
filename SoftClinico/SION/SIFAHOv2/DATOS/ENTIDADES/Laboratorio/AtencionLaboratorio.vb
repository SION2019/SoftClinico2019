Public Class AtencionLaboratorio
    Public Property idEps As Integer
    Public Property identipaciente As Integer
    Public Property nombre As String
    Public Property fecha As DateTime
    Public Property codigoEP As Integer
    Public Property codigoContrato As Integer
    Public Property codigoAtencion As String
    Public Property observacion As String
    Public Property usuario As Integer
    Public Property dtParaclinicos As DataTable
    Public Property dtParaclinicosNuevo As DataTable
    Public Property dtHemoderivados As DataTable
    Public Property dtProcedimiento As DataTable
    Public Property dtMedicamentos As DataTable
    Public Property dtInsumo As DataTable
    Public Property codigoCita As Integer
    Public Property imagen As Byte()
    Public Property tipoDocumento As Integer
    Public Property dtImagen As New DataTable
    Public Property extensionDoc As String
    Public Property consulta As String
    Public Property tipo As String
    Public Property modulo As String
    Public Sub cargarParaclinicos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.ATENCION_LAB_CARGAR_PARACLINICOS, params, dtParaclinicos)
    End Sub

    Public Sub cargarProcedimientos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.ATENCION_LAB_CARGAR_PROCEDIMIENTOS, params, dtProcedimiento)
    End Sub

    Public Sub cargarHemoderivados()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.ATENCION_LAB_CARGAR_HEMODERIVADOS, params, dtHemoderivados)
    End Sub

    Public Sub cargarMedicamentos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.ATENCION_LAB_CARGAR_MEDICAMENTOS, params, dtMedicamentos)
    End Sub

    Public Sub cargarInsumos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.ATENCION_LAB_CARGAR_INSUMOS, params, dtInsumo)
    End Sub
    Public Sub cargarParaclinicosCitas()
        Dim params As New List(Of String)
        params.Add(codigoCita)
        General.llenarTabla(Consultas.CITA_MEDICA_CARGAR_PARACLINICOS, params, dtParaclinicos)
    End Sub

    Public Sub cargarProcedimientosCitas()
        Dim params As New List(Of String)
        params.Add(codigoCita)
        General.llenarTabla(Consultas.CITA_MEDICA_CARGAR_PROCEDIMIENTOS, params, dtProcedimiento)
    End Sub
    Public Sub guardarAtencion()
        dtParaclinicosNuevo = New DataTable
        dtParaclinicosNuevo = dtParaclinicos.Copy
        dtParaclinicosNuevo.Columns.Remove("Resultado")
        AtencionLabDAL.guardarAtencionLab(Me)
    End Sub
    Public Sub guardarDocumentos(objAtencion As AtencionLaboratorio)
        AtencionLabDAL.guardarDocumento(objAtencion)
    End Sub

    Public Sub cargarDocumentos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        params.Add(tipo)
        General.llenarTabla(Consultas.CARGAR_DOCUMENTO_EXTERNO, params, dtImagen)
    End Sub


    Public Sub establecerDGVParaclinico(dgvParaclinicos As DataGridView)
        With dgvParaclinicos
            .Columns.Item("dgcodigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigo").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcionp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionp").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidadp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidadp").DataPropertyName = "Cantidad"

            .Columns.Item("dganular").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganular").DataPropertyName = "Quitar"
        End With
        dgvParaclinicos.DataSource = dtParaclinicos

    End Sub

    Public Sub establecerDGVprocedimientos(dgvProcedimientos As DataGridView)
        With dgvProcedimientos
            .Columns.Item("dgcodigop").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigop").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcionps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionps").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidadps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidadps").DataPropertyName = "Cantidad"


            .Columns.Item("dganularps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganularps").DataPropertyName = "Quitar"
        End With
        dgvProcedimientos.DataSource = dtProcedimiento
    End Sub

    Public Sub establecerDGVhemoderivados(dgvHemoderivados As DataGridView)
        With dgvHemoderivados
            .Columns.Item("dgcodigoh").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigoh").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcionh").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionh").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidadh").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidadh").DataPropertyName = "Cantidad"

            .Columns.Item("dganularh").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganularh").DataPropertyName = "Quitar"
        End With
        dgvHemoderivados.DataSource = dtHemoderivados
    End Sub

    Public Sub establecerDGVmedicamentos(dgvMedicamentos As DataGridView)
        With dgvMedicamentos

            .Columns.Item("dgcodigooculto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigooculto").DataPropertyName = "CódigoOculto"

            .Columns.Item("dgcodigom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigom").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcionm").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionm").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidad").DataPropertyName = "Cantidad"

            .Columns.Item("dganularm").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganularm").DataPropertyName = "Quitar"
        End With
        dgvMedicamentos.DataSource = dtMedicamentos

    End Sub

    Public Sub establecerDGVinsumos(dgvInsumos As DataGridView)
        With dgvInsumos

            .Columns.Item("dgcodigoin").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigoin").DataPropertyName = "CodigoInsumo"

            .Columns.Item("dgcodigoi").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigoi").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcioni").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcioni").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidadi").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidadi").DataPropertyName = "Cantidad"

            .Columns.Item("dganulari").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganulari").DataPropertyName = "Quitar"
        End With
        dgvInsumos.DataSource = dtInsumo

    End Sub

    Sub New()
        dtParaclinicos = New DataTable
        dtParaclinicos.Columns.Add("Codigo", Type.GetType("System.String"))
        dtParaclinicos.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtParaclinicos.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtParaclinicos.Columns.Add("Resultado", Type.GetType("System.String"))
        dtParaclinicos.Columns("Cantidad").DefaultValue = 0


        dtHemoderivados = New DataTable
        dtHemoderivados.Columns.Add("Codigo", Type.GetType("System.String"))
        dtHemoderivados.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtHemoderivados.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtHemoderivados.Columns("Cantidad").DefaultValue = 0



        dtProcedimiento = New DataTable
        dtProcedimiento.Columns.Add("Codigo", Type.GetType("System.String"))
        dtProcedimiento.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtProcedimiento.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtProcedimiento.Columns("Cantidad").DefaultValue = 0



        dtMedicamentos = New DataTable
        dtMedicamentos.Columns.Add("CódigoOculto", Type.GetType("System.String"))
        dtMedicamentos.Columns.Add("Codigo", Type.GetType("System.String"))
        dtMedicamentos.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtMedicamentos.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtMedicamentos.Columns("Cantidad").DefaultValue = 0


        dtInsumo = New DataTable
        dtInsumo.Columns.Add("CodigoInsumo", Type.GetType("System.String"))
        dtInsumo.Columns.Add("Codigo", Type.GetType("System.String"))
        dtInsumo.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtInsumo.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtInsumo.Columns("Cantidad").DefaultValue = 0

    End Sub

End Class
