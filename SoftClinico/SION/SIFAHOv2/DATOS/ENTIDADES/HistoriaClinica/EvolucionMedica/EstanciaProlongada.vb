﻿Public Class EstanciaProlongada

    Public Property registro As Int32
    Public Property codigoevo As Int32
    Public Property fecha As Date
    Public Property justificacion As String
    Public Property resultado As String
    Public Property conducta As String
    Public Property idempleado As Integer
    Public Property usuario As Integer
    Public Property dtEstancia As DataTable
    Public Property codigoEp As Int32
    Public Property cargarDatos As String
    Public Property cargaDiagnosticos As String
    Public Property anulaEstancia As String
    Public Property nombrePDF As String
    Public Property moduloReporte As String
    Sub New()
        cargarDatos = Consultas.ESTANCIA_PRO_CARGAR_DATOS
        cargaDiagnosticos = Consultas.DIAGNOSTICOS_ESTANCIA_PRO
        anulaEstancia = Consultas.ANULAR_ESTANCIA_PRO
        nombrePDF = ConstantesHC.NOMBRE_PDF_ESTANCIA_PRO
        moduloReporte = Constantes.REPORTE_HC
        crearTablaEstancia()
    End Sub

    Public Sub crearTablaEstancia()
        dtEstancia = New DataTable
        dtEstancia.Columns.Add("Codigo", Type.GetType("System.String"))
        dtEstancia.Columns.Add("Descripcion", Type.GetType("System.String"))
    End Sub

    Public Sub anular()
        Dim lista As New List(Of String)
        lista.Add(registro)
        lista.Add(SesionActual.idUsuario)
        lista.Add(SesionActual.codigoEP)
        General.ejecutarSQL(anulaEstancia, lista)
    End Sub

    Public Overridable Sub guardarEstancia()
        EstanciaProlongadaBLL.crearEstancias(Me)
    End Sub

    Public Sub cargarDiagnosticos()
        Dim lista As New List(Of String)
        dtEstancia = New DataTable
        lista.Add(codigoevo)
        General.llenarTabla(cargaDiagnosticos, lista, dtEstancia)
    End Sub

    Public Sub imprimir()
        Dim ruta, nombreArchivo As String
        nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF
        ruta = IO.Path.GetTempPath() & nombreArchivo

        ruta = Path.GetTempPath() & nombreArchivo
        Dim reporte As New ftp_reportes
        reporte.crearReportePDF(nombrePDF, registro, New rptOrdenMedica,
                                  registro, "{VISTA_ESTANCIA_PROLONGADA.N_Registro} = " & registro & " AND {VISTA_ESTANCIA_PROLONGADA.Modulo}=" & moduloReporte & "",
                                  nombrePDF, IO.Path.GetTempPath)
    End Sub
End Class
