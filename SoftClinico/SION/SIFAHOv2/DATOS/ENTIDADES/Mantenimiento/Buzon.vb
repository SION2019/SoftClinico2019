Public Class Buzon

    Public Property idEmpresa As Integer
    Public Property codigo As String
    Public Property codigoCargo As String
    Public Property fecha As Date
    Public Property observacion As String
    Public Property asunto As String
    Public Property usuario As Integer
    Public Property dtEmpleado As DataTable
    Public Property dtCargos As DataTable

    Public Property dtRespuesta As DataTable


    Public Sub buscarCargos()
        Dim params As New List(Of String)
        params.Add(idEmpresa)
        General.llenarTabla(Consultas.BUZON_BUSCAR_CARGOS, params, dtCargos)
    End Sub

    Public Sub buscarEmpleado()
        Dim params As New List(Of String)
        params.Add(idEmpresa)
        params.Add(codigoCargo)
        General.llenarTabla(Consultas.BUZON_CARGO_EMPLEADO_CARGAR, params, dtEmpleado)
    End Sub

    Public Sub CargarRespuesta()
        dtRespuesta = New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(133)
        General.llenarTabla(Consultas.BUZON_RECIBE_MENSAJE, params, dtRespuesta)
    End Sub

    Public Sub guardar()
        If String.IsNullOrEmpty(codigo) Then
            codigo = Constantes.VALOR_PREDETERMINADO
        End If
        BuzonDAL.guardarBuzon(Me)
    End Sub

    Sub New()
        dtCargos = New DataTable
        dtCargos.Columns.Add("Código", Type.GetType("System.String"))
        dtCargos.Columns.Add("Cargo", Type.GetType("System.String"))
        dtCargos.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))

        dtEmpleado = New DataTable
        dtEmpleado.Columns.Add("Código", Type.GetType("System.String"))
        dtEmpleado.Columns.Add("Empleado", Type.GetType("System.String"))
        dtEmpleado.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))

    End Sub

End Class
