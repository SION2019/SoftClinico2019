Public Class InterconsultaMedica
    Public Property Interconsultante As String
    Public Property Interconsultado As String
    Public Property Motivo As String
    Public Property moduloReporte As Integer
    Public Property codigoOrden As String
    Public Property codigoProcedimiento As String
    Public Property usuario As String
    Public Property usuarioReal As String
    Public Property usuarioNombre As String
    Public Property nRegistro As Integer
    Public Property codigoEP As Integer
    Public Property Respuesta As String
    Public Property fechaInterconsulta As DateTime
    Public Property nombreReporte As String
    Public Property listInterconsulta As New DataTable
    Public Property interconsultaListar As String
    Public Property interconsultaCargar As String
    Public Property consultaVerificar As String
    Sub New()
        nombreReporte = ConstantesHC.NOMBRE_PDF_INTERCONSULTA
        moduloReporte = Constantes.REPORTE_HC
        interconsultaListar = Consultas.INTERCONSULTAS_LISTAR
        interconsultaCargar = Consultas.INTERCONSULTA_CARGAR
        consultaVerificar = Consultas.INTERCONSULTA_VERIFICAR
    End Sub

    Public Sub cargarListaInterconsulta(ByRef listInterconsulta As ListBox)
        Dim params As New List(Of String)
        params.Add(nRegistro)
        General.cargarLista(interconsultaListar, params, "Nombre", "Codigo_Orden", listInterconsulta)
    End Sub

    Public Sub cargarInterconsultaMedica()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        params.Add(codigoProcedimiento)
        General.llenarTabla(interconsultaCargar, params, dt)
        If dt.Rows.Count > 0 Then
            Interconsultante = dt.Rows(0).Item("Descripcion_Especialidad")
            Interconsultado = dt.Rows(0).Item("Descripcion")
            Motivo = dt.Rows(0).Item("Justificacion")
            Respuesta = dt.Rows(0).Item("Respuesta")
            fechaInterconsulta = dt.Rows(0).Item("Fecha")
        End If
    End Sub

    Public Overridable Sub guardarInterconsultaMedica()
        Try
            HistoriaClinicaDAL.guardarInterconsulta(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub imprimirInterconsulta(indicelista As Integer)
        Try
            Dim nombreArchivo, ruta, formula, codigoNombre As String

            If indicelista = 0 Then
                codigoNombre = nRegistro
                nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = Path.GetTempPath() & nombreArchivo
                ftp_reportes.llamarArchivo(ruta, nombreArchivo, nRegistro, nombreReporte)
            Else
                nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                                codigoOrden & ConstantesHC.EXTENSION_ARCHIVO_PDF
                ruta = Path.GetTempPath() & nombreArchivo
                formula = "{VISTA_INTERCONSULTA.Codigo_Orden} = " & codigoOrden & " AND {VISTA_INTERCONSULTA.Codigo_Procedimiento} = '" & codigoProcedimiento & " 
                                            AND {VISTA_INTERCONSULTA.Modulo}=" & moduloReporte & ""
                Dim reporte As New ftp_reportes
                reporte.crearYGuardarReporte(nombreReporte, nRegistro, New rptEvolucionMedica,
                                  codigoOrden, formula,
                                  nombreReporte, IO.Path.GetTempPath,, True)
            End If

            Process.Start(ruta)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overridable Sub anularInterconsulta()
        Dim params As New List(Of String)
        params.Add(usuario)
        params.Add(codigoOrden)
        params.Add(codigoProcedimiento)
        params.Add(codigoEP)
        General.ejecutarSQL(Consultas.ANULAR_INTERCONSULTA, params)
    End Sub
End Class
