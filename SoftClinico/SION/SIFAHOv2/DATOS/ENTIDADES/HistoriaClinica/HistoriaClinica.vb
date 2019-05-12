Imports Celer

Public Class HistoriaClinica
    Public Property nRegistro As Integer
    Public Property modulo As String
    Public Property servicioNeonatal As Boolean
    Public Property objFisioterapia As New Fisioterapia
    Public Property objEnfermeria As New Enfermeria
    Public Property objOrdenMedica As New OrdenMedica
    Public Property objVistaPrevia As New VistaPrevia
    Public Property objPrefactura As New Prefactura
    Public Property objParametroV As New ParametroVentilacion
    Public Property objSabanaAplicacion As New SabanaAplicacionMed
    Public Property objInfoIngreso As New Object
    Public Property objEvolucionMedica As New EvolucionMedica
    Public Property objInterconsulta As New InterconsultaMedica
    Public Property objRemision As New Remision
    Public Property objEstancia As New EstanciaProlongada
    Public Property objCuerpoMedico As New CuerpoMedico
    Public Property objConsolidado As Consolidado

    Public Property VERIFICAR_VENTILACION As String

    Public Sub crearConsolidado()
        objConsolidado = New Consolidado
        objConsolidado.N_Registro = nRegistro
        objConsolidado.Codigo_Menu = modulo
        objConsolidado.Generando = True
        objConsolidado.Generando2doPlanoParte1 = True
        objConsolidado.Generando2doPlanoParte2 = True
        objConsolidado.Generando2doPlanoParte3 = True
        objConsolidado.Generando2doPlanoParte4 = True

    End Sub

    Public Sub New(params As List(Of String))
        modulo = params(0)
        servicioNeonatal = params(1)
        nRegistro = params(2)
        objInfoIngreso = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_INFO_INGRESO & Math.Abs(CInt(servicioNeonatal)) & modulo)
        objEvolucionMedica = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_EVOLUCION_MEDICA & modulo)
        objInterconsulta = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_INTERCONSULTA_MEDICA & modulo)
        objRemision = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_REMISION & modulo)
        objFisioterapia = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_FISIOTERAPIA & modulo)
        objEnfermeria = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_ENFERMERIA & modulo)
        objOrdenMedica = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_ORDEN_MEDICA & modulo)
        objVistaPrevia = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_VISTA_PREVIA & modulo)
        objPrefactura = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_PREFACTURA & modulo)
        objParametroV = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_PARAMETROS_VENT & modulo)
        objSabanaAplicacion = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_SABANA_APLICACION & modulo)
        objEstancia = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_ESTANCIA_PROLONGADA & modulo)
        Select Case modulo
            Case Constantes.CODIGO_MENU_HISTC
                VERIFICAR_VENTILACION = Consultas.PARAMETRO_VENTILACION_VERIFICAR_OXIGENO
            Case Constantes.CODIGO_MENU_AUDM
                VERIFICAR_VENTILACION = Consultas.PARAMETRO_VENTILACION_VERIFICAR_OXIGENO_R
            Case Constantes.CODIGO_MENU_AUDF
                VERIFICAR_VENTILACION = Consultas.PARAMETRO_VENTILACION_VERIFICAR_OXIGENO_RR
        End Select

    End Sub
    Public Sub cargarFisioterapia()
        objFisioterapia.registro = nRegistro
        objFisioterapia.cargarListaTerapia()
        objFisioterapia.cargarListaOrdenesInsumoFisio()
        objFisioterapia.cargarListaNotaFisio()
        objFisioterapia.cargarListaOxigenosOrdenados()
        objFisioterapia.cargarListaNebulizacion()
    End Sub
    Public Sub cargarEnfermeria()
        objEnfermeria.registro = nRegistro
        objEnfermeria.cargarListaOrdenesInsumoEnfer()
        objEnfermeria.cargarListaNotaEnfer()
        objEnfermeria.cargarListaOrdenesGlucomEnfer()
        objEnfermeria.cargarListaOrdenesParaclinicos()
        objEnfermeria.cargarListaOrdenesHemoderivados()
    End Sub

    Public Sub cargarInfoIngreso()
        objInfoIngreso.nRegistro = nRegistro
        objInfoIngreso.cargarDetalle()
    End Sub
    Public Sub cargarCuerpoMedico()
        objCuerpoMedico.registro = nRegistro
        objCuerpoMedico.CargarListaProcedimientosRealizados()
    End Sub
    Public Sub cargarEvolucion(ByRef plistEvolucion As ListBox)
        objEvolucionMedica.nRegistro = nRegistro
        objEvolucionMedica.cargarListaEvoluciones(plistEvolucion)
    End Sub
    Public Sub cargarInterconsulta(ByRef plistInterconsulta As ListBox)
        objInterconsulta.nRegistro = nRegistro
        objInterconsulta.cargarListaInterconsulta(plistInterconsulta)
    End Sub
    Public Sub cargarRemision(ByRef plistRemision As ListBox)
        objRemision.nRegistro = nRegistro
        objRemision.cargarListaRemisiones(plistRemision)
    End Sub
    Public Sub cargarOrden(ByRef plistOrden As ListBox)
        objOrdenMedica.modulo = modulo
        objOrdenMedica.registro = nRegistro
        objOrdenMedica.cargarListaOrdenes(plistOrden)
    End Sub

    Public Sub generarVistaPrevia(pUsuario As Integer, pNombrePaciente As String, ByRef formPlataforma As FormVisorPlataformaDoc)
        objVistaPrevia.registro = nRegistro
        objVistaPrevia.usuario = pUsuario
        objVistaPrevia.nombrePaciente = pNombrePaciente
        objConsolidado.errorGeneracion = False
        objVistaPrevia.cargarDocumentos(objConsolidado, formPlataforma)

    End Sub
    Public Function mostrarErrores() As String
        Return objVistaPrevia.erroresEncontrados
    End Function
    Public Sub generarPrefactura(pUsuario As Integer, pNombrePaciente As String)
        objPrefactura.nRegistro = nRegistro
        objPrefactura.usuario = pUsuario
        objPrefactura.nombrePaciente = pNombrePaciente
        objPrefactura.cargarPdf()
    End Sub
    Public Sub generarParametroVentilacion()
        objParametroV.nRegistro = nRegistro
        objParametroV.fechaReal = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objParametroV.cargarDetalle()
    End Sub
    Public Sub generarSabanaAplicacion()
        objSabanaAplicacion.nRegistro = nRegistro
        objSabanaAplicacion.servicioNeonatal = servicioNeonatal
        objSabanaAplicacion.fechaReal = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objSabanaAplicacion.cargarDetalle()
    End Sub
End Class
