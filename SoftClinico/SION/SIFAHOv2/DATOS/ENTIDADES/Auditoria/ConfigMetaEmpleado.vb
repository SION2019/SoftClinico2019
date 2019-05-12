Public Class ConfigMetaEmpleado
    Public Property codigoEP As Integer
    Public Property diaCorte As String
    Public Property meta1 As Double
    Public Property meta2 As Double
    Public Property meta3 As Double
    Public Property dtEmpleado As DataTable
    Public Property dsEmpleado As BindingSource
    Public Property dtEmpleadoMeta As DataTable
    Public Property dsEmpleadoMeta As BindingSource
    Public Property consultaEmpleadoCargar As String
    Public Property consultaEmpleadoMetaCargar As String
    Public Property consultaMetaCargar As String
    Public Property consultaMetaGuardar As String

    Public Sub New()
        dtEmpleado = New DataTable
        dsEmpleado = New BindingSource
        dtEmpleadoMeta = New DataTable
        dsEmpleadoMeta = New BindingSource
        dtEmpleado.Columns.Add("IdEmpleado", Type.GetType("System.Int32"))
        dtEmpleado.Columns.Add("Empleado", Type.GetType("System.String"))
        dtEmpleado.Columns.Add("Cargo", Type.GetType("System.String"))
        dtEmpleado.Columns.Add("CodigoContrato", Type.GetType("System.Int32"))
        dtEmpleado.Columns.Add("Contrato", Type.GetType("System.String"))
        dtEmpleado.Columns.Add("ValorTurno", Type.GetType("System.Double")).DefaultValue = 0
        dtEmpleado.Columns.Add("Turnos", Type.GetType("System.Double")).DefaultValue = 0
        dtEmpleado.Columns.Add("Promedio", Type.GetType("System.Double")).DefaultValue = 0
        dtEmpleado.Columns.Add("MetaSostenimiento", Type.GetType("System.Double")).DefaultValue = 0
        dtEmpleado.Columns.Add("Activo", Type.GetType("System.Boolean"))

        dtEmpleadoMeta.Columns.Add("IdEmpleado", Type.GetType("System.Int32"))
        dtEmpleadoMeta.Columns.Add("Empleado", Type.GetType("System.String"))
        dtEmpleadoMeta.Columns.Add("IdMeta", Type.GetType("System.Int32"))
        dtEmpleadoMeta.Columns.Add("Valor", Type.GetType("System.Double")).DefaultValue = 0
        dtEmpleadoMeta.Columns.Add("Porcentaje", Type.GetType("System.Double")).DefaultValue = 0

        consultaEmpleadoCargar = ConsultasNom.EMPLEADO_META_CARGAR
        consultaEmpleadoMetaCargar = ConsultasNom.EMPLEADO_META_D_CARGAR
        consultaMetaCargar = ConsultasNom.META_CARGAR
        consultaMetaGuardar = ConsultasNom.META_GUARDAR
        dsEmpleado.DataSource = dtEmpleado
        dsEmpleadoMeta.DataSource = dtEmpleadoMeta
    End Sub

    Public Sub guardarMeta()
        Try
            ConfigMetaEmpleadoDAL.guardarMeta(Me)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub cargarEmpleados(mostrarTodos As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(mostrarTodos)
        General.llenarTabla(consultaEmpleadoCargar, params, dtEmpleado)
    End Sub
    Public Sub cargarEmpleadoMeta()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(consultaEmpleadoMetaCargar, params, dtEmpleadoMeta)
    End Sub

    Public Sub cargarMetaGeneral()
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        dr = General.cargarItem(consultaMetaCargar, params)
        If Not IsNothing(dr) Then
            diaCorte = dr.Item(0)
            meta1 = dr.Item(1)
            meta2 = dr.Item(2)
            meta3 = dr.Item(3)
        End If
    End Sub
End Class
