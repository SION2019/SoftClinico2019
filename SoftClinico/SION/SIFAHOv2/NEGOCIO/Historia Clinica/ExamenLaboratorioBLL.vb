Public Class ExamenLaboratorioBLL
    Public Shared Sub guardarExamen(objExamenParaclinico As ParaclinicoLaboratorio)
        ExamenParaclinicoDAL.guardarParaclinicoLab(objExamenParaclinico)
    End Sub
    Public Shared Sub anularExamen(objExamenParaclinico As ParaclinicoLaboratorio)
        ExamenParaclinicoDAL.AnularParaclinicoLab(objExamenParaclinico)
    End Sub
    Public Shared Sub abrirJustificacion(dgv As DataGridView, dt As DataTable, panel As Panel, txtJustificacion As TextBox, nombreColumna As String)
        If dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Selected = True Then
            panel.Visible = True
            txtJustificacion.ReadOnly = False
            txtJustificacion.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Value.ToString
            txtJustificacion.Focus()
            txtJustificacion.SelectionStart = txtJustificacion.TextLength
        End If
    End Sub
    Public Shared Sub abrirJustificacionLab(dgv As DataGridView, estado As Boolean, panel As Panel, txtJustificacion As TextBox, nombreColumna As String)
        If dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Selected = True Then
            panel.Visible = True
            txtJustificacion.ReadOnly = estado
            txtJustificacion.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Value.ToString
            txtJustificacion.Focus()
            txtJustificacion.SelectionStart = txtJustificacion.TextLength
        End If
    End Sub
    Public Shared Sub agregarFilaHemocultivo(dttable As DataTable)
        dttable.Rows.Add()
        dttable.Rows(dttable.Rows.Count - 1).Item(0) = dttable.Rows.Count
        dttable.Rows(dttable.Rows.Count - 1).Item(1) = ConstantesHC.MUESTRA_HEMOCULTIVO &
                     ConstantesHC.NOMBRE_PDF_SEPARADOR2 &
                      (dttable.Rows.Count)
    End Sub
    Public Shared Sub cargarNombrePDF(ByRef nombrePDF As String,
                                          ByRef nombrePDF_R As String,
                                          ByRef nombrePDF_RR As String,
                                          ByRef campoVista As String,
                                          ByRef reporteParams As ReporteParams)

        Select Case reporteParams.codigoTemporal3
            Case ConstantesHC.TIPO_EXAMEN_ELECTROLITO
                nombrePDF = ConstantesHC.NOMBRE_PDF_ELECTROLITO
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_ELECTROLITO_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_ELECTROLITO_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_HEMOGRAMA
                nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOGRAMA
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_HEMOGRAMA_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_HEMOGRAMA_RR
                campoVista = "Codigo_Procedimiento"
            Case ConstantesHC.TIPO_EXAMEN_QUIMICASANGUINEA
                nombrePDF = ConstantesHC.NOMBRE_PDF_QUIMICASANGUINEA
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_QUIMICASANGUINEA_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_QUIMICASANGUINEA_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_UROCULTIVO
                nombrePDF = ConstantesHC.NOMBRE_PDF_UROCULTIVO
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_UROCULTIVO_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_UROCULTIVO_RR
                campoVista = "Codigo_Procedimiento"
            Case ConstantesHC.TIPO_EXAMEN_UROANALISIS
                nombrePDF = ConstantesHC.NOMBRE_PDF_UROANALISIS
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_UROANALISIS_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_UROANALISIS_RR
                campoVista = "Codigo_Procedimiento"
            Case ConstantesHC.TIPO_EXAMEN_HEMOCULTIVO
                nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO_RR
                campoVista = "Codigo_Procedimiento"
            Case ConstantesHC.TIPO_EXAMEN_COPROLOGICO
                nombrePDF = ConstantesHC.NOMBRE_PDF_COPROLOGICO
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_COPROLOGICO_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_COPROLOGICO_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_COPROSCOPICO
                nombrePDF = ConstantesHC.NOMBRE_PDF_COPROSCOPICO
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_COPROSCOPICO_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_COPROSCOPICO_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_SEROLOGIA
                nombrePDF = ConstantesHC.NOMBRE_PDF_SEROLOGIA
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_SEROLOGIA_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_SEROLOGIA_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_TINTACHINA
                nombrePDF = ConstantesHC.NOMBRE_PDF_TINTACHINA
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_TINTACHINA_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_TINTACHINA_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_IMAGENOLOGIA
                nombrePDF = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_GASESARTERIALES
                nombrePDF = ConstantesHC.NOMBRE_PDF_GASESARTERIALES
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_GASESARTERIALES_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_GASESARTERIALES_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TP
                nombrePDF = ConstantesHC.NOMBRE_PDF_TIEMPOP
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_TIEMPOP_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_TIEMPOP_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TTP
                nombrePDF = ConstantesHC.NOMBRE_PDF_TIEMPOPT
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_TIEMPOPT_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_TIEMPOPT_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
            Case Else
                nombrePDF = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA
                nombrePDF_R = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA_R
                nombrePDF_RR = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA_RR
                reporteParams.codigoTemporal2 = reporteParams.codigoTemporal4
        End Select

    End Sub
End Class
