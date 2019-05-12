﻿Public Class EvolucionMedica
    Public Property subjetivo As String
    Public Property signoVital As String
    Public Property cabezaCuello As String
    Public Property torax As String
    Public Property cardioPulmonar As String
    Public Property abdomen As String
    Public Property genturinario As String
    Public Property extremidades As String
    Public Property sistemaNervioso As String
    Public Property analisis As String
    Public Property planTratamiento As String
    Public Property listEvolucion As New DataTable
    Public Property evolucionListar As String
    Public Property evolucionCargar As String
    Public Property diagnosticoCargar As String
    Public Property moduloReporte As Integer
    Public Property codigoEvolucion As String
    Public Property fechaEvolucion As DateTime
    Public Property editado As Boolean
    Public Property usuario As String
    Public Property usuarioReal As String
    Public Property usuarioNombre As String
    Public Property nRegistro As Integer
    Public Property dtDiagnosticos As New DataTable
    Public Property codigoEP As Integer
    Public Property elementoAEliminar As New List(Of String)
    Public Property nombreReporte As String
    Public Property consultaVerificar As String
    Sub New()
        nombreReporte = ConstantesHC.NOMBRE_PDF_EVOLUCION_MEDICA
        moduloReporte = Constantes.REPORTE_HC
        evolucionListar = Consultas.LISTAR_EVOLUCIONES
        evolucionCargar = Consultas.EVOLUCION_MEDICA_CARGAR
        diagnosticoCargar = Consultas.EVOLUCION_MEDICA_DIAGNOSTICA_CARGAR
        consultaVerificar = Consultas.EVOLUCION_VERIFICAR
    End Sub

    Public Sub cargarListaEvoluciones(ByRef listEvolucion As ListBox)
        Dim params As New List(Of String)
        params.Add(nRegistro)
        General.cargarLista(evolucionListar, params, "Nombre", "Codigo_Evo", listEvolucion)
    End Sub

    Public Sub cargarEvolucionMedica()
        elementoAEliminar.Clear()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigoEvolucion)
        General.llenarTabla(evolucionCargar, params, dt)
        If dt.Rows.Count > 0 Then
            subjetivo = dt.Rows(0).Item("Subjetivo").ToString
            signoVital = dt.Rows(0).Item("Sig_Vitales").ToString
            cabezaCuello = dt.Rows(0).Item("Cab_Cuello").ToString
            torax = dt.Rows(0).Item("Torax").ToString
            cardioPulmonar = dt.Rows(0).Item("Card_Pulm").ToString
            abdomen = dt.Rows(0).Item("Abdom").ToString
            genturinario = dt.Rows(0).Item("Genturinario").ToString
            extremidades = dt.Rows(0).Item("Extrem").ToString
            sistemaNervioso = dt.Rows(0).Item("S_Nerv_Central").ToString
            analisis = dt.Rows(0).Item("Analisis").ToString
            planTratamiento = dt.Rows(0).Item("Plan_Trtmnto").ToString
            usuarioNombre = dt.Rows(0).Item("Usuario").ToString
            fechaEvolucion = dt.Rows(0).Item("Fecha_Evo").ToString
            usuarioReal = dt.Rows(0).Item("usuarioInforme").ToString
        End If
        cargarDiagnosticosEvolucion()
    End Sub

    Private Sub cargarDiagnosticosEvolucion()
        Dim params As New List(Of String)
        params.Add(codigoEvolucion)
        General.llenarTabla(diagnosticoCargar, params, dtDiagnosticos)
        For I = 0 To dtDiagnosticos.Rows.Count - 1
            dtDiagnosticos.Rows(I).Item("Estado") = Constantes.ITEM_CARGADO
        Next
    End Sub

    Public Overridable Sub guardarEvolucionMedica()
        Try
            HistoriaClinicaBLL.guardar_evolucion(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Sub imprimirEvolucion(indicelista As Integer)
        Try
            Dim nombreArchivo, ruta, formula, codigoNombre As String

            If indicelista = 0 Then
                codigoNombre = nRegistro
                nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = Path.GetTempPath() & nombreArchivo
                ftp_reportes.llamarArchivo(ruta, nombreArchivo, nRegistro, nombreReporte)
            Else
                codigoNombre = codigoEvolucion
                nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = Path.GetTempPath() & nombreArchivo
                formula = "{VISTA_EVOLUCION.Codigo_Evo} = " & codigoNombre & " 
                                            AND {VISTA_EVOLUCION.Modulo}=" & moduloReporte & ""
                Dim reporte As New ftp_reportes
                reporte.crearYGuardarReporte(nombreReporte, nRegistro, New rptEvolucionMedica,
                                  codigoNombre, formula,
                                  nombreReporte, IO.Path.GetTempPath,, True)
            End If

            Process.Start(ruta)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Overridable Sub anularEvolucion()
        Dim params As New List(Of String)
        params.Add(usuario)
        params.Add(codigoEvolucion)
        params.Add(codigoEP)
        General.ejecutarSQL(Consultas.ANULAR_EVOLUCION, params)
    End Sub
End Class
