Public Class ContratosAM
    Public Property codHab As String
    Public Property codigoContrato As String
    Public Property idEmpresa As Integer
    Public Property idCliente As Integer
    Public Property idEPS As Integer
    Public Property codigoAdmin As String
    Public Property numContrato As String
    Public Property codigoPais As String
    Public Property codigoDpto As String
    Public Property codigoMunicipio As String
    Public Property idRepresentante As Integer
    Public Property NombreRep As String
    Public Property fecha As String
    Public Property fechaVencimento As String
    Public Property plazo As String
    Public Property estado As String
    Public Property historico As String
    Public Property Observaciones As String
    Public Property TipoCodRef As Integer
    Public Property CodigoHA As Integer
    Public Property issMayor25 As Decimal
    Public Property issMayor300 As Decimal
    Public Property codigoManual As Decimal
    Public Property Usuario As Integer
    Public Property sqlBuscarCodigoHab As String
    Public Property sqlBuscarManualTarifarioCON As String
    Public Property sqlCargarManualTarifarioCON As String
    Public Property sqlGuardarContratoAM As String
    Public Property sqlBuscarContratoAM As String
    Public Property sqlCargarContratoAM As String
    Public Property sqlAnularContratoAM As String
    Public Property sqlTerminarContratoAM As String

    Public Sub New()
        sqlBuscarCodigoHab = ConstantesAm.CODIGO_HABILITACION_AM
        sqlBuscarManualTarifarioCON = ConstantesAm.MANUAL_TARIFARIO_AM_BUSCAR
        sqlCargarManualTarifarioCON = ConstantesAm.MANUAL_TARIFARIO_AM_CARGAR
        sqlGuardarContratoAM = ConstantesAm.CONTRATO_AM_CREAR
        sqlBuscarContratoAM = ConstantesAm.CONTRATO_AM_BUSCAR
        sqlCargarContratoAM = ConstantesAm.CONTRATO_AM_CARGAR
        sqlAnularContratoAM = ConstantesAm.CONTRATO_AM_ANULAR
        sqlTerminarContratoAM = ConstantesAm.CONTRATO_AM_TERMINAR
    End Sub
    Public Sub AnularContratoAM()
        General.anularRegistro(sqlAnularContratoAM & codigoContrato &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & Usuario)
    End Sub
    Public Sub TerminarContratoAM()
        General.anularRegistro(sqlTerminarContratoAM & codigoContrato &
               ConstantesHC.NOMBRE_PDF_SEPARADOR3 & Usuario)
    End Sub
End Class
