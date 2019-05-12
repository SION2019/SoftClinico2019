Public Class ConfiguracionPerfilParaclinico
    Public Property CodigoTipo As String
    Public Property codigoAreaServicio As Integer
    Public Property Titulo As String
    Public Property codigoConfig As Integer
    Public Property usuario As Integer
    Public Property codigoPunto As Integer
    Public Property dtProcedimiento As DataTable
    Public Property dtParaclinicoC As DataTable
    Public Property dtBotonesParaclinicos As DataTable
    Public Property sqlCrearProcedimientos As String
    Public Property sqlCargarProcedimientos As String
    Public Property sqlGrupoProcedimientos As String
    Public Property sqlcargarProcedimientoParaclinico As String
    Public Property sqlAsignarProcedimientoParaclinico As String
    Public Property sqlTipoExamenProcedimientoParaclinico As String
    Public Property sqlCrearProcedimientoParaclinico As String
    Public Property sqlBuscarPerfilParaclinico As String
    Public Property sqlCargarPerfilParaclinico As String
    Public Property sqlAnularPerfilParaclinico As String
    Public Property tablaClasificacion As New Hashtable

    Public Sub New()
        codigoPunto = SesionActual.codigoEP
        dtProcedimiento = New DataTable
        dtProcedimiento.Columns.Add("Codigo", Type.GetType("System.String"))
        dtProcedimiento.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtProcedimiento.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
        dtParaclinicoC = New DataTable
        dtParaclinicoC.Columns.Add("Codigo", Type.GetType("System.String"))
        dtBotonesParaclinicos = New DataTable
        dtBotonesParaclinicos.Columns.Add("Codigo", Type.GetType("System.String"))
        dtBotonesParaclinicos.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtBotonesParaclinicos.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
        sqlCrearProcedimientos = Consultas.PROCEDIMIENTO_CONFIGURACION_CREAR
        sqlCargarProcedimientos = Consultas.PROCEDIMIENTOS_CUPS_PERFIL_PARACLINICO_LISTAR
        sqlGrupoProcedimientos = Consultas.GRUPO_PROCEDIMIENTOS_LISTAR
        sqlCrearProcedimientoParaclinico = Consultas.PROCEDIMIENTO_CONF_PERFIL_PARACLINICOS_CREAR
        sqlcargarProcedimientoParaclinico = Consultas.PROCEDIMIENTOS_PARACLINICO_LISTAR
        sqlTipoExamenProcedimientoParaclinico = Consultas.PROCEDIMIENTOS_CUPS_PARACLINICOS_LISTAR
        sqlAsignarProcedimientoParaclinico = Consultas.PROCEDIMIENTO_ASIGNAR_PARACLINICOS_BUSCAR
        sqlBuscarPerfilParaclinico = Consultas.PERFIL_PARACLINICO_CONF_BUSCAR
        sqlCargarPerfilParaclinico = Consultas.PERFIL_PARACLINICO_CONF_CARGAR
        sqlAnularPerfilParaclinico = Consultas.PERFIL_PARACLINICO_CONF_ANULAR
    End Sub
    Public Sub llenarTabla()
        Dim params As New List(Of String)
        params.Add(CodigoTipo)
        params.Add(codigoAreaServicio)
        General.llenarTabla(consulta(Constantes.CODIGO_CONFIG_PROCEDIMIENTO), params, dtProcedimiento)
    End Sub
    Public Sub llenarTablaParaclinico()
        Dim params As New List(Of String)
        params.Add(CodigoTipo)
        params.Add(codigoAreaServicio)
        General.llenarTabla(sqlAsignarProcedimientoParaclinico, params, dtProcedimiento)
    End Sub
    Public Sub llenarTablaBotones()
        Dim params As New List(Of String)
        params.Add(codigoAreaServicio)
        General.llenarTabla(Consultas.PERFIL_PARACLINICO_BUSCAR, params, dtBotonesParaclinicos)
    End Sub
    Public Function consulta() As List(Of String)
        Dim params As New List(Of String)
        Select Case codigoConfig
            Case Constantes.CODIGO_CONFIG_PROCEDIMIENTO '------ Codigo para indentificar las consulta de configuarcion de procedimiento
                params.Add(sqlCargarProcedimientos)
                params.Add(sqlGrupoProcedimientos)
                params.Add(sqlCrearProcedimientos)
            Case Constantes.GRUPO_PARACLINICO          '---------Codigo para indentificar las consulta de configuarcion de procedimiento de Paraclinicos
                params.Add(sqlCrearProcedimientoParaclinico)
        End Select
        Return params
    End Function
    Public Sub AnularPerfilParaclinico()
        General.anularRegistro(sqlAnularPerfilParaclinico & CodigoTipo & ConstantesHC.NOMBRE_PDF_SEPARADOR3 & codigoAreaServicio & ConstantesHC.NOMBRE_PDF_SEPARADOR3 & usuario)
    End Sub
End Class
