Public Class AtencionAM
    Public Property usuario As Integer
    Public Property codAtencion As String
    Public Property idTripulacion As String
    Public Property identiPaciente As Integer
    Public Property idTarifa As String
    Public Property factor As Decimal
    Public Property valorTrasladoSimpleMasTarifa As Decimal
    Public Property valorTrasladoMasTarifa As Decimal
    Public Property valorKmsMayor25 As Decimal
    Public Property valorKmsMayor300 As Decimal
    Public Property valorTotalAtencion As Decimal
    Public Property TipoCodRef As Integer
    Public Property idEPS As Integer
    Public Property N_Registro As Integer
    Public Property codigoSolicitudServicio As String
    Public Property codigoContrato As String
    Public Property codProcedimiento As String
    Public Property redondo As Boolean
    Public Property tipoDia As String
    Public Property salida As DateTime
    Public Property llegada As DateTime
    Public Property observaciones As String
    Public Property idAdministrador As String
    Public Property idMedico As String
    Public Property idParamedico As String
    Public Property idFisioterapeuta As String
    Public Property idConductor As String
    Public Property idContacto As String
    Public Property retorno As DateTime
    Public Property regreso As DateTime
    Public Property valorAdministrativo As Decimal
    Public Property valorConductor As Decimal
    Public Property valorParamedico As Decimal
    Public Property valorMedico As Decimal
    Public Property valorContacto As Decimal
    Public Property valorFisioterapeuta As Decimal
    Public Property controlAgregarMinuto As Integer
    Public Property kmAdicional As Integer
    Public Property valorTotalKmsAdicional As Integer
    Public Property recargoNocturno As Boolean
    Public Property valorTotalRecargoNocturno As Integer
    Public Property cantidadHoraAdicional As Decimal
    Public Property valorTotalHorasAdicionales As Integer
    Public Property dtTablaDesglosado As DataTable
    Public Property dtTablaTraslado As DataTable
    Public Property dtTablaDiagnostico As DataTable
    Public Property dtTablaTripulacion As DataTable
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

        dtTablaTripulacion = New DataTable
        dtTablaTripulacion.Columns.Add("Codigo", Type.GetType("System.String"))
        dtTablaTripulacion.Columns.Add("Id_Tercero", Type.GetType("System.Int32"))
        dtTablaTripulacion.Columns.Add("Nombre", Type.GetType("System.String"))

        dtTablaTraslado = New DataTable
        dtTablaTraslado.Columns.Add("Codigo_Pais_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Pais_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Dpto_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Dpto_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Municipio_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Municipio_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Institucion_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Institucion_Origen", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Pais_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Pais_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Dpto_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Dpto_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Codigo_Municipio_Destino", Type.GetType("System.String"))
        dtTablaTraslado.Columns.Add("Descripcion_Municipio_Destino", Type.GetType("System.String"))
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

        sqlBuscarManualTarifarioAM = ConsultasAmbu.MANUAL_TARIFARIO_EPS_AM_BUSCAR
        sqlCargarManualTarifarioAM = ConsultasAmbu.MANUAL_TARIFARIO_AM_CARGAR
        sqlGuardarAtencionAM = ConsultasAmbu.ATENCION_AM_CREAR
        sqlBuscarAtencionAM = ConsultasAmbu.ATENCION_AM_BUSCAR
        sqlCargarAtencionAM = ConsultasAmbu.ATENCION_AM_CARGAR
        sqlCargarDiagnosticoAM = ConsultasAmbu.ATENCION_AM_DIAG_CARGAR
        sqlAnularAtencionAM = ConsultasAmbu.ATENCION_AM_ANULAR
        sqlTarifaTripulacionAM = ConsultasAmbu.TARIFA_TRIPULACION_BUSCAR
    End Sub
    Public Sub AnularAtencionAM()
        General.anularRegistro(sqlAnularAtencionAM & codAtencion &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & usuario)
    End Sub

    Public Sub calcularDetalleTraslado()
        If TipoCodRef = 1 Then
            valorTotalKmsAdicional = If(kmAdicional > 300, valorKmsMayor300, valorKmsMayor25) * (factor) * kmAdicional
            valorTotalRecargoNocturno = valorTrasladoSimpleMasTarifa * If(recargoNocturno = True, 0.25, 0)
            valorTotalHorasAdicionales = valorTrasladoSimpleMasTarifa * 0.4 * Math.Round(cantidadHoraAdicional, 0, MidpointRounding.AwayFromZero)
        Else
            valorTotalKmsAdicional = 0
            valorTotalRecargoNocturno = 0
            valorTotalHorasAdicionales = 0
        End If
    End Sub

    Public Sub calcularPrecioTraslado()
        If redondo = True Then
            valorTotalAtencion = valorTrasladoMasTarifa + valorTotalKmsAdicional + valorTotalRecargoNocturno + valorTotalHorasAdicionales
        Else
            valorTotalAtencion = valorTrasladoMasTarifa + valorTotalKmsAdicional + valorTotalRecargoNocturno
        End If
    End Sub
End Class
