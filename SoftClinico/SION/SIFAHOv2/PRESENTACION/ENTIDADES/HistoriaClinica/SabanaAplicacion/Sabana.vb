Public MustInherit Class Sabana
    Public Property numeroHorastranscurridas As Integer
    Public Property fechaReal As DateTime
    Public Property fechaIngreso As DateTime
    Public Property fechaEgreso As DateTime
    Public Property codigoSabana As String
    Public Property nRegistro As Integer
    Public Property usuario As String
    Public Property usuarioReal As String
    Public Property inicialesUsuario As String
    Public Property dtHorasabana As DataTable
    Public Property codigoEP As Integer
    Public Property sqlDetalleCarga As String
    Public Property sqlDatoPacienteCarga As String
    Public Property sqlCodigoSabanaCarga As String
    Public Property nombreReporte As String
    Public Property vistaReporte As String
    Public Property objReporte As Object
    Public Property moduloReporte As Integer
    Public Sub New()
        GeneralHC.crearTablaSabana(dtHorasabana)
    End Sub
    Public MustOverride Sub cargarDetalle()
    Public MustOverride Sub cargarCodigoSabana()
    Public MustOverride Sub guardarDetalle()
    Public Sub imprimirHoja(seleccionTodo As Boolean)
        Try
            Dim nombreArchivo, ruta, formula, codigoNombre As String
            Dim reporte As New ftp_reportes
            If seleccionTodo Then
                codigoNombre = nRegistro
                nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = Path.GetTempPath() & nombreArchivo
                ftp_reportes.llamarArchivo(ruta, nombreArchivo, nRegistro, nombreReporte)
            Else
                codigoNombre = codigoSabana
                nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
                formula = "{" & vistaReporte & ".Codigo_Sabana} = " & codigoSabana & " 
                                            AND {" & vistaReporte & ".Modulo}=" & moduloReporte & ""
                ruta = Path.GetTempPath() & nombreArchivo
                reporte.crearYGuardarReporte(nombreReporte, nRegistro, objReporte,
                              codigoNombre, formula,
                              nombreReporte, IO.Path.GetTempPath,, True)
            End If
            Process.Start(ruta)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
