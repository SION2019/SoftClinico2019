Public Class Tripulante
    Public Property Codigo_Tarifa_Tripulacion As String
    Public Property Codigo_Pais_Origen As String
    Public Property Codigo_Dpto_Origen As String
    Public Property Codigo_Municipio_Origen As String
    Public Property Codigo_Pais_Destino As String
    Public Property Codigo_Dpto_Destino As String
    Public Property Codigo_Municipio_Destino As String
    Public Property Valor_Administrativo_S As Decimal
    Public Property Valor_Administrativo_R As Decimal
    Public Property Valor_Conductor_S As Decimal
    Public Property Valor_Conductor_R As Decimal
    Public Property Valor_Paramedico_S As Decimal
    Public Property Valor_Paramedico_R As Decimal
    Public Property Valor_Medico_S As Decimal
    Public Property Valor_Medico_R As Decimal
    Public Property Valor_Contacto As Decimal
    Public Property Valor_Fisioterapeuta_S As Decimal
    Public Property Valor_Fisioterapeuta_R As Decimal
    Public Property Recargo_Nocturno As Decimal
    Public Property viceversa As Boolean
    Public Property id_tercero_responsable As Integer
    Public Property Usuario As Integer
    Public Property sqlGuardarTarifaTripulacion As String
    Public Property sqlBuscarTarifaTripulacion As String
    Public Property sqlCargarTarifaTripulacion As String
    Public Property sqlAnularTarifaTripulacion As String
    Public Property sqlBuscarResponsableTarifaTripulacion As String
    Public Property sqlCargarResponsableTarifaTripulacion As String

    Public Sub New()
        sqlGuardarTarifaTripulacion = ConstantesAm.TARIFA_TRIPULACION_CREAR
        sqlBuscarTarifaTripulacion = ConstantesAm.TARIFA_TRIPULACION_BUSCAR
        sqlCargarTarifaTripulacion = ConstantesAm.TARIFA_TRIPULACION_CARGAR
        sqlAnularTarifaTripulacion = ConstantesAm.TARIFA_TRIPULACION_ANULAR
        sqlBuscarResponsableTarifaTripulacion = ConstantesAm.TARIFA_TRIPULACION_RESPONSABLE_BUSCAR
        sqlCargarResponsableTarifaTripulacion = ConstantesAm.TARIFA_TRIPULACION_RESPONSABLE_CARGAR
    End Sub

    Public Sub AnularTarifaTripulacion()
        General.anularRegistro(sqlAnularTarifaTripulacion & Codigo_Tarifa_Tripulacion &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & Usuario)
    End Sub

End Class
