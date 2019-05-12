Public Class CuerpoMedico
    Public Property sqlBuscarProcedimientoH As String
    Public Property sqlGuardarTarifaMedica As String
    Public Property sqlGuardarCuerpoMedico As String
    Public Property sqlBuscarTarifaMedia As String
    Public Property sqlCargarTarifaMedica As String
    Public Property sqlAnularTarifaMedica As String
    Public Property sqlAnularCuerpoMedico As String
    Public Property sqlCargarProcedimientos As String
    Public Property sqlCargarEmpleadoProcedimientos As String
    Public Property dtCuerpoMedico As DataTable
    Public Property dtProcedimientos As DataTable
    Public Property dtEmpleadoProc As DataTable
    Public Property dtAuxCM As DataTable
    Public Property idEmpleado As Integer
    Public Property usuario As Integer
    Public Property Codigo As String
    Public Property CodigoCM As String
    Public Property CodigoOrden As String
    Public Property registro As Integer
    Public Property Activo As Boolean
    Public Property dtParticipantes As DataTable
    Public Sub New()

        dtCuerpoMedico = New DataTable
        dtCuerpoMedico.Columns.Add("Codigo", Type.GetType("System.String"))
        dtCuerpoMedico.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtCuerpoMedico.Columns.Add("Valor", Type.GetType("System.Double"))
        dtCuerpoMedico.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        dtProcedimientos = New DataTable
        dtProcedimientos.Columns.Add("Codigo_Orden", Type.GetType("System.String"))
        dtProcedimientos.Columns.Add("Nombre_Procedimiento", Type.GetType("System.String"))
        dtProcedimientos.Columns.Add("Fecha_Orden", Type.GetType("System.DateTime"))

        dtEmpleadoProc = New DataTable
        dtEmpleadoProc.Columns.Add("IdEmpleado", Type.GetType("System.String"))
        dtEmpleadoProc.Columns.Add("Empleado", Type.GetType("System.String"))
        dtEmpleadoProc.Columns.Add("Cargo", Type.GetType("System.String"))
        dtEmpleadoProc.Columns.Add("Valor", Type.GetType("System.Double"))
        dtEmpleadoProc.Columns.Add("CodCargo", Type.GetType("System.String"))
        dtEmpleadoProc.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        'dtAuxCM = New DataTable
        'dtAuxCM.Columns.Add("CodigoOrden", Type.GetType("System.Int32"))
        'dtAuxCM.Columns.Add("CodigoProcedimiento", Type.GetType("System.String"))
        'dtAuxCM.Columns.Add("IdEmpleado", Type.GetType("System.Int32"))
        'dtAuxCM.Columns.Add("TarifaPactada", Type.GetType("System.Boolean"))
        'dtAuxCM.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        dtParticipantes = New DataTable
        dtParticipantes.Columns.Add("tipoProceso", Type.GetType("System.String"))
        dtParticipantes.Columns.Add("codigoProceso", Type.GetType("System.Int32"))
        dtParticipantes.Columns.Add("codigoProcedimiento", Type.GetType("System.String"))
        dtParticipantes.Columns.Add("codigoParametro", Type.GetType("System.Int32"))
        dtParticipantes.Columns.Add("idTercero", Type.GetType("System.Int32"))
        dtParticipantes.Columns.Add("aplicaTarifa", Type.GetType("System.Boolean"))
        dtParticipantes.Columns.Add("usuario", Type.GetType("System.Int32"))

        sqlBuscarProcedimientoH = Consultas.TARIFA_MEDICA_PROCEDIMIENTOS_CUPS_BUSCAR
        sqlGuardarTarifaMedica = Consultas.TARIFA_MEDICA_CREAR
        'sqlGuardarCuerpoMedico = Consultas.PARTICIPANTES_CREAR
        sqlBuscarTarifaMedia = Consultas.TARIFA_MEDICA_BUSCAR
        sqlCargarTarifaMedica = Consultas.TARIFA_MEDICA_CARGAR
        sqlAnularTarifaMedica = Consultas.TARIFA_MEDICA_ANULAR
        sqlAnularCuerpoMedico = Consultas.CUERPO_MEDICO_ANULAR
        sqlCargarProcedimientos = Consultas.CUERPO_MEDICO_PROCEDIMIENTOS_LISTAR
        'sqlCargarEmpleadoProcedimientos = Consultas.PARTICIPANTES_CARGAR

    End Sub
    Public Sub AnularTarifaMedica()
        General.anularRegistro(sqlAnularTarifaMedica & Codigo & ConstantesHC.NOMBRE_PDF_SEPARADOR3 & usuario)
    End Sub
    Public Sub AnularCuerpoMedico()
        General.anularRegistro(sqlAnularCuerpoMedico & CodigoCM & ConstantesHC.NOMBRE_PDF_SEPARADOR3 & usuario)
    End Sub
    Public Sub CargarListaProcedimientosRealizados()
        Dim params As New List(Of String)
        params.Add(registro)
        General.llenarTabla(sqlCargarProcedimientos, params, dtProcedimientos)
    End Sub
    Public Sub CargarCuerpoMedico()
        'Dim params As New List(Of String)
        'params.Add(CodigoOrden)
        'params.Add(Codigo)
        ''params.Add(SesionActual.idEmpresa)
        'General.llenarTabla(sqlCargarEmpleadoProcedimientos, params, dtEmpleadoProc)
    End Sub
End Class
