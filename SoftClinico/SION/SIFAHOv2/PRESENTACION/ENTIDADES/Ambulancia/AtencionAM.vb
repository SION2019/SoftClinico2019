Public Class AtencionAM
    Public Property usuario As Integer
    Public Property codAtencion As Integer
    Public Property nRegistro As Integer
    Public Property idTripulacion As Integer
    Public Property identiPaciente As Integer
    Public Property codigoServicio As Integer
    Public Property codigoContrato As Integer
    Public Property codProcedimiento As String
    Public Property tipoDia As String
    Public Property codTarifaTripulacion As Integer
    Public Property salida As DateTime
    Public Property llegada As DateTime
    Public Property observaciones As String
    Public Property idAdministrador As Integer
    Public Property idMedico As Integer
    Public Property idParamedico As Integer
    Public Property idFisioterapeuta As Integer
    Public Property idConductor As Integer
    Public Property idContacto As Integer
    Public Property retorno As DateTime
    Public Property regreso As DateTime
    Public Property idTarifa As Integer
    Public Property codCIE As Integer
    Public Property TipoCodRef As Integer
    Public Property SalarioHA As Decimal
    Public Property issMayor25 As Decimal
    Public Property issMayor300 As Decimal
    Public Property factor As Decimal
    Public Property codigoTripulacion As String
    Public Property codigoPaisOrigen As String
    Public Property codigoDptoOrigen As String
    Public Property codigoMunicipioOrigen As String
    Public Property codigoPaisDestino As String
    Public Property codigoDptoDestino As String
    Public Property codigoMunicipioDestino As String
    Public Property valorAdministrativo As Decimal
    Public Property valorConductor As Decimal
    Public Property valorParamedico As Decimal
    Public Property valorMedico As Decimal
    Public Property valorContacto As Decimal
    Public Property valorFisioterapeuta As Decimal
    Public Property valorTraslado As Decimal
    Public Property valNormal As Decimal
    Public Property valTotal As Decimal
    Public Property tgMtext As Integer
    Public Property kmsExt As Integer
    Public Property valKmsExt As Integer
    Public Property recNoc As Boolean
    Public Property valRecNoc As Integer
    Public Property hrAd As Integer
    Public Property valHrAd As Integer
    Public Property codFacA As Integer
    Public Property redondo As Boolean
    Public Property dtTablaDesglosado As DataTable
    Public Property dtTablaTraslado As DataTable
    Public Property dtTablaDiagnostico As DataTable
    Public Property sqlCargarManualTarifarioAM As String
    Public Property sqlBuscarManualTarifarioAM As String
    Public Property sqlGuardarAtencionAM As String
    Public Property sqlBuscarAtencionAM As String
    Public Property sqlCargarAtencionAM As String
    Public Property sqlCargarDiagnosticoAM As String
    Public Property sqlAnularAtencionAM As String
    Public Property sqlTarifaTripulacionAM As String
    Public Sub New()
        dtTablaDiagnostico = New DataTable
        dtTablaDiagnostico.Columns.Add("Codigo", Type.GetType("System.String"))
        dtTablaDiagnostico.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtTablaDiagnostico.Columns.Add("Estado", Type.GetType("System.String"))

        dtTablaTraslado = New DataTable
        dtTablaTraslado.Columns.Add("Codigo_Pais_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Pais_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Dpto_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Dpto_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Municipio_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Municipio_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Pais_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Pais_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Dpto_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Dpto_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Municipio_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Municipio_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Institucion_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Institucion_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Institucion_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Institucion_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Procedimiento", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Procedimiento", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Valor", Type.GetType("System.Int32"))
        dtTablaTraslado.Columns.Add("Valor_Medico", Type.GetType("System.Int32"))
        dtTablaTraslado.Columns.Add("Valor_Paramedico", Type.GetType("System.Int32"))
        dtTablaTraslado.Columns.Add("Valor_Conductor", Type.GetType("System.Int32"))
        dtTablaTraslado.Columns.Add("Valor_Contacto", Type.GetType("System.Int32"))
        dtTablaTraslado.Columns.Add("Valor_Fisioterapeuta", Type.GetType("System.Int32"))
        dtTablaTraslado.Columns.Add("Observaciones", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo", Type.GetType("System.Int32"))

        sqlBuscarManualTarifarioAM = ConstantesAm.MANUAL_TARIFARIO_EPS_AM_BUSCAR
        sqlCargarManualTarifarioAM = ConstantesAm.MANUAL_TARIFARIO_AM_CARGAR
        sqlGuardarAtencionAM = ConstantesAm.ATENCION_AM_CREAR
        sqlBuscarAtencionAM = ConstantesAm.ATENCION_AM_BUSCAR
        sqlCargarAtencionAM = ConstantesAm.ATENCION_AM_CARGAR
        sqlCargarDiagnosticoAM = ConstantesAm.ATENCION_AM_DIAG_CARGAR
        sqlAnularAtencionAM = ConstantesAm.ATENCION_AM_ANULAR
        sqlTarifaTripulacionAM = ConstantesAm.TARIFA_TRIPULACION_BUSCAR
    End Sub
    Public Sub AnularAtencionAM()
        General.anularRegistro(sqlAnularAtencionAM & codAtencion &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & usuario)
    End Sub

    Public Sub calcularRecNocYKmAdicional()
        valKmsExt = If(kmsExt > 300, issMayor300, issMayor25) * (factor / 100 + 1) * kmsExt
        valRecNoc = valorTraslado * ((factor / 100) + 1) * If(recNoc = "SI", 0.25, 0)
        valHrAd = valorTraslado * ((factor / 100) + 1) * 0.4 * Math.Round(hrAd, 0, MidpointRounding.AwayFromZero)
    End Sub

    Public Sub calcularPrecioTraslado()
        valNormal = (valorTraslado * factor / 100) + valorTraslado
        valTotal = (valorTraslado * factor / 100) + valorTraslado
    End Sub
End Class
