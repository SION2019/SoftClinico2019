Public Class ManualTarifarioAM
    Public Property dtListaPrecios As DataTable
    Public Property CodigoElemnto As String
    Public Property CodigoManual As String
    Public Property CodigoTarifa As String
    Public Property CodigoPaisOrigen As String
    Public Property CodigoDptoOrigen As String
    Public Property CodigoMunicipioOrigen As String
    Public Property CodigoPaisDestino As String
    Public Property CodigoDptoDestino As String
    Public Property CodigoMunicipioDestino As String
    Public Property CodigoInstitucionOrigen As String
    Public Property CodigoInstitucionDestino As String
    Public Property CodigoProcedimiento As String
    Public Property Valor As Decimal
    Public Property ValorMedico As Decimal
    Public Property ValorParamedico As Decimal
    Public Property ValorConductor As Decimal
    Public Property ValorContacto As Decimal
    Public Property ValorFisioterapeuta As Decimal
    Public Property Observaciones As String
    Public Property Descripcion As String
    Public Property IdTercero As Integer
    Public Property IdEmpresa As Integer
    Public Property Usuario As Integer
    Public Property sqlGuardarManualTarifario As String
    Public Property sqlBuscarManualTarifarioAM As String
    Public Property sqlCargarManualTarifarioAM As String
    Public Property sqlAnularManualTarifario As String
    Public Property dtRuta As DataTable
    Public Property dtInst As DataTable
    Public Property dtTras As DataTable
    Public Property dtTablaManualTarifario As DataTable
    Public Property sqlBuscarElemento As String
    Public Property sqlCargarElemento As String
    Public Property sqlBuscarPais As String
    Public Property sqlCargarPais As String
    Public Property sqlBuscarDpto As String
    Public Property sqlCargarDpto As String
    Public Property sqlBuscarMun As String
    Public Property sqlCargarMun As String
    Public Property sqlBuscarInst As String
    Public Property sqlCargarInst As String
    Public Property sqlBuscarTras As String
    Public Property sqlCargarTras As String


    Public Sub New()
        dtTablaManualTarifario = New DataTable
        dtTablaManualTarifario.Columns.Add("Codigo_Pais_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Pais_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Dpto_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Dpto_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Municipio_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Municipio_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Pais_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Pais_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Dpto_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Dpto_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Municipio_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Municipio_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Institucion_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Institucion_Origen", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Institucion_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Institucion_Destino", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo_Procedimiento", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Descripcion_Procedimiento", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Valor", Type.GetType("System.Int32"))
        dtTablaManualTarifario.Columns.Add("Valor_Medico", Type.GetType("System.Int32"))
        dtTablaManualTarifario.Columns.Add("Valor_Paramedico", Type.GetType("System.Int32"))
        dtTablaManualTarifario.Columns.Add("Valor_Conductor", Type.GetType("System.Int32"))
        dtTablaManualTarifario.Columns.Add("Valor_Contacto", Type.GetType("System.Int32"))
        dtTablaManualTarifario.Columns.Add("Valor_Fisioterapeuta", Type.GetType("System.Int32"))
        dtTablaManualTarifario.Columns.Add("Observaciones", Type.GetType("System.String"))
        dtTablaManualTarifario.Columns.Add("Codigo", Type.GetType("System.Int32"))
        sqlBuscarPais = Consultas.PAIS_LISTAR
        sqlBuscarDpto = Consultas.DPTO_LISTAR
        sqlBuscarMun = Consultas.CIUDAD_LISTAR
        sqlCargarPais = Consultas.PAIS_CARGAR_DATOS
        sqlCargarDpto = Consultas.BUSQUEDA_DEPARTAMENTO_CARGAR
        sqlCargarMun = Consultas.MUNICIPIOS_CARGAR_AM
        sqlBuscarInst = Consultas.INSTITUCIONES_LISTAR
        sqlCargarInst = Consultas.INSTITUCIONES_CARGAR
        sqlBuscarTras = Consultas.BUSCAR_CUPS_AM
        sqlCargarTras = Consultas.CARGAR_CUPS_AM
        sqlGuardarManualTarifario = ConstantesAm.MANUAL_TARIFARIO_AM_CREAR
        sqlBuscarManualTarifarioAM = ConstantesAm.MANUAL_TARIFARIO_AM_BUSCAR
        sqlCargarManualTarifarioAM = ConstantesAm.MANUAL_TARIFARIO_AM_CARGAR
        sqlAnularManualTarifario = ConstantesAm.MANUAL_TARIFARIO_AM_ANULAR
    End Sub
    Public Sub AnularManualTarifario()
        General.anularRegistro(sqlAnularManualTarifario & CodigoManual &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & Usuario)
    End Sub
End Class
