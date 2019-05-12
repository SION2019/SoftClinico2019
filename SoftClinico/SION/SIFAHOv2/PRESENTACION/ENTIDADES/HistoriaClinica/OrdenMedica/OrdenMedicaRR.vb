Public Class OrdenMedicaRR
    Inherits OrdenMedica
    Sub New()
        objetoNutricion = New OrdenMedicaNutricionRR
        nombreReporte = ConstantesHC.NOMBRE_PDF_ORDEN_MEDICARR
        moduloReporte = Constantes.REPORTE_AF
        ordenListar = Consultas.ORDEN_MEDICA_LISTAR_RR
        ordenCargar = Consultas.ORDEN_MEDICA_CARGARRR
        estanciaCargar = Consultas.ORDEN_MEDICA_ESTANCIA_CARGARRR
        indicacionCargar = Consultas.ORDEN_MEDICA_INDICACION_CARGARRR
        comidaCargar = Consultas.ORDEN_MEDICA_COMIDA_CARGARRR
        oxigenoCargar = Consultas.ORDEN_MEDICA_OXIGENO_CARGARRR
        paraclinicoCargar = Consultas.ORDEN_MEDICA_PARACLINICO_CARGARRR
        hemoderivadoCargar = Consultas.ORDEN_MEDICA_HEMODERIVADO_CARGARRR
        glucometriaCargar = Consultas.ORDEN_MEDICA_GLUCOMETRIA_CARGARRR
        procedimientoCargar = Consultas.ORDEN_MEDICA_PROCEDIMIENTO_CARGARRR
        medicamentoCargar = Consultas.ORDEN_MEDICA_MEDICAMENTO_CARGARRR
        impregnacionCargar = Consultas.ORDEN_MEDICA_IMPREGNACION_CARGARRR
        infusionCargar = Consultas.ORDEN_MEDICA_INFUSION_CARGARRR
        mezclaCargar = Consultas.ORDEN_MEDICA_MEZCLA_CARGARRR
    End Sub
    Public Overrides Sub guardarSabanaAutomatica()
        SabanaAplicacionMedDAL.guardarSabanaAutomaticaAF(Me)
        Dim objSabanaAplicacion As SabanaAplicacionMed
        objSabanaAplicacion = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_SABANA_APLICACION & Constantes.CODIGO_MENU_AUDF)
        objSabanaAplicacion.usuario = usuario
        objSabanaAplicacion.nRegistro = registro
        objSabanaAplicacion.guardarReporte2doPlano()
    End Sub
End Class
