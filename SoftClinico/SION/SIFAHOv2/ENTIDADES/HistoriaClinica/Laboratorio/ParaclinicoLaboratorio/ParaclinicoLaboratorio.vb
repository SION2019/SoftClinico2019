Public Class ParaclinicoLaboratorio
    Public Property idEmpresa As Integer
    Public Property usuarioReal As String
    Public Property usuario As String
    Public Property fechaReal As DateTime
    Public Property registro As Integer
    Public Property codigoOrden As Integer
    Public Property codigoProcedimiento As String
    Public Property codigoGenero As Integer
    Public Property codigoEP As Integer
    Public Property titulo As String
    Public Property editado As Integer
    Public Property dtExamen As DataTable
    Public Property sqlCargarPaciente As String
    Public Property sqlCargarParametros As String
    Public Property sqlExamenesGuardar As String
    Public Property sqlExamenesAnular As String
    Public Property area As String
    Public Property tipoExamen As Integer
    Public Property tipoExamenDescripcion As String
    Public Property datosExistente As Boolean
    Public Property banderaReporte As Boolean
    Public Property moduloReporte As Integer
    Public Property agrupable As Integer
    Property areaExamen As String
    Property fechaMuestra As DateTime
    Public Sub New()

        titulo = TitulosForm.EXAMEN_LABORATORIO
        moduloReporte = Constantes.REPORTE_HC
        sqlExamenesGuardar = ConsultasHC.LABORATORIO_PARACLINICO_CREAR
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN
        sqlCargarParametros = ConsultasHC.CARGAR_PARAMETRO_LABORATORIO
        sqlExamenesAnular = ConsultasHC.LABORATORIO_PARACLINICO_ANULAR

        dtExamen = New DataTable
        dtExamen.Columns.Add("Codigo_Orden", Type.GetType("System.Int32"))
        dtExamen.Columns.Add("Codigo_Procedimiento", Type.GetType("System.String"))
        dtExamen.Columns.Add("Codigo", Type.GetType("System.String"))
        dtExamen.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtExamen.Columns.Add("Resultado", Type.GetType("System.String")).DefaultValue = DBNull.Value
        dtExamen.Columns.Add("Comentario", Type.GetType("System.String"))
        dtExamen.Columns.Add("Referencia", Type.GetType("System.String"))
        dtExamen.Columns.Add("Unidad", Type.GetType("System.String"))

    End Sub
    Public Function cargarPacienteExamen() As DataRow
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        params.Add(codigoProcedimiento)
        params.Add(areaExamen)
        dFila = General.cargarItem(sqlCargarPaciente, params)
        Return dFila
    End Function
    Public Sub CargarParametros()
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        params.Add(codigoProcedimiento)
        params.Add(areaExamen)
        General.llenarTabla(sqlCargarParametros, params, dtExamen)
    End Sub
    Public Sub filtrarTipo()
        Dim codigoBandera As String
        codigoBandera = "o" & codigoOrden
        If agrupable = 0 Then
            codigoBandera += "p" & codigoProcedimiento
        Else
            codigoBandera += "t" & tipoExamen
        End If
        Dim dtNew As New DataTable
        Dim filas As DataRow()
        dtNew = dtExamen.Copy
        filas = dtNew.Select("CodigoBandera='" & codigoBandera & "'")
        dtExamen.Clear()
        For Each row As DataRow In filas
            dtExamen.ImportRow(row)
        Next
        dtExamen.Columns.Remove("CodigoBandera")
    End Sub
    Public Function llenarHistorial() As DataTable
        Dim dtv As New DataView(dtExamen)
        Dim tblCodigos,
            tblParametros,
            tblResultado As New DataTable

        tblCodigos = dtv.ToTable(True, "Codigo")
        tblParametros.Merge(tblCodigos)

        Dim paramshash As New Hashtable
        paramshash.Add("@pRegistro", registro)
        paramshash.Add("@pTipoExamen", tipoExamen)
        General.llenarTablaParametroTabla(Consultas.HISTORIAL_RESULTADOS_PARACLICNICO,
                                          paramshash,
                                          tblParametros,
                                          tblResultado,
                                          True)
        Return tblResultado
    End Function
    Public Overridable Sub cargarNombrePDF()
        Select Case tipoExamen
            Case ConstantesHC.TIPO_EXAMEN_ELECTROLITO
                area = ConstantesHC.NOMBRE_PDF_ELECTROLITO
            Case ConstantesHC.TIPO_EXAMEN_HEMOGRAMA
                area = ConstantesHC.NOMBRE_PDF_HEMOGRAMA
            Case ConstantesHC.TIPO_EXAMEN_QUIMICASANGUINEA
                area = ConstantesHC.NOMBRE_PDF_QUIMICASANGUINEA
            Case ConstantesHC.TIPO_EXAMEN_UROCULTIVO
                area = ConstantesHC.NOMBRE_PDF_UROCULTIVO
            Case ConstantesHC.TIPO_EXAMEN_UROANALISIS
                area = ConstantesHC.NOMBRE_PDF_UROANALISIS
            Case ConstantesHC.TIPO_EXAMEN_HEMOCULTIVO
                area = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO
            Case ConstantesHC.TIPO_EXAMEN_COPROLOGICO
                area = ConstantesHC.NOMBRE_PDF_COPROLOGICO
            Case ConstantesHC.TIPO_EXAMEN_COPROSCOPICO
                area = ConstantesHC.NOMBRE_PDF_COPROSCOPICO
            Case ConstantesHC.TIPO_EXAMEN_SEROLOGIA
                area = ConstantesHC.NOMBRE_PDF_SEROLOGIA
            Case ConstantesHC.TIPO_EXAMEN_TINTACHINA
                area = ConstantesHC.NOMBRE_PDF_TINTACHINA
            Case ConstantesHC.TIPO_EXAMEN_IMAGENOLOGIA
                area = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA
            Case ConstantesHC.TIPO_EXAMEN_GASESARTERIALES
                area = ConstantesHC.NOMBRE_PDF_GASESARTERIALES
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TP
                area = ConstantesHC.NOMBRE_PDF_TIEMPOP
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TTP
                area = ConstantesHC.NOMBRE_PDF_TIEMPOPT
            Case Else
                area = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA
        End Select
    End Sub

    Public Sub imprimir()
        Dim reporte As New ftp_reportes
        Dim nombreArchivo, ruta As String
        Dim codigoCompuesto As String
        Dim dFila As DataRow
        Dim params As New List(Of String)
        Dim campoVista As String
        Dim cadena As String
        Dim rprte As ReportClass
        Try
            codigoCompuesto = codigoOrden
            dFila = cargarPacienteExamen()
            tipoExamenDescripcion = dFila.Item("Nombre_Laboratorio")
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoCompuesto & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            campoVista = "Laboratorio"
            If areaExamen = Constantes.TipoEXAM Then
                rprte = If(SesionActual.codigoEnlace = 2, New rptExamenParaclinicoLa50, New rptExamenParaclinico)
                cadena = " {VISTA_PARACLINICOS_RESULTADO.Codigo_Orden}=" & codigoCompuesto &
                                       " AND {VISTA_PARACLINICOS_RESULTADO." & campoVista & "}='" & tipoExamenDescripcion &
                                       "' AND {VISTA_PARACLINICOS_RESULTADO.MODULO}=" & moduloReporte & ""
            Else
                rprte = New rptExamenParaclinicoAtencion
                cadena = " {VISTA_PARACLINICOS_RESULTADO_ATENCION.Codigo_Orden}=" & codigoCompuesto &
                                       " AND {VISTA_PARACLINICOS_RESULTADO_ATENCION." & campoVista & "}='" & tipoExamenDescripcion &
                                       "' AND {VISTA_PARACLINICOS_RESULTADO_ATENCION.MODULO}=4 AND {VISTA_EMPRESAS.Id_empresa} =" & 5
            End If
            params.Add(codigoCompuesto)
            params.Add(codigoProcedimiento)
            params.Add(areaExamen)
            reporte.crearReportePDF(area, registro, rprte,
                                   codigoCompuesto, cadena, area, IO.Path.GetTempPath,,, params)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
