Public Class FormReporteAceptacionGlosa
    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        Dim rptNotaCredito As New rptMotivo
        Dim consolidado As Integer
        Dim departamento As String = ""
        Try
            Select Case combodepartamento.SelectedValue
                Case -1
                    departamento = "-1"
                Case 1
                    departamento = Constantes.MEDICOSUCI
                Case 2
                    departamento = Constantes.DPTSISTEMAS
                Case 3
                    departamento = Constantes.FACTURACION
                Case 4
                    departamento = Constantes.AUDITORES
                Case 5
                    departamento = Constantes.CONTRATACION
                Case 6
                    departamento = Constantes.ENFERMERIAUCI
                Case 7
                    departamento = Constantes.FISIO
                Case 8
                    departamento = Constantes.ADMISIONISTAS
                Case 9
                    departamento = Constantes.FARMACIA
                Case 10
                    departamento = Constantes.LABORATORIO
            End Select

            If Checkconsolidado.Checked = True Then
                consolidado = 1
            Else
                consolidado = 0
            End If
            Dim tbl As New Hashtable
            tbl.Add("fechainicial", FechaInicio.Text)
            tbl.Add("fecha", FechaInicio.Text)
            tbl.Add("fechafinal", FechaFinal.Text)
            tbl.Add("fechafin", FechaFinal.Text)
            tbl.Add("@DEPARTAMENTO", departamento)
            tbl.Add("soloConsolidado", consolidado)
            tbl.Add("@CODIGOAREA", comboarea.SelectedValue)
            tbl.Add("@fecha", FechaInicio.Text)
            tbl.Add("@fechafinal", FechaFinal.Text)
            tbl.Add("@CODIGO", comboarea.SelectedValue)
            tbl.Add("@DEPARTAMENT", departamento)


            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(rptNotaCredito, Nothing, "Aceptacion glosa", Constantes.FORMATO_PDF, tbl)
            Cursor = Cursors.Default
        Catch ex As Exception
            General.manejoErrores(ex)

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormReporteAceptacionGlosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'" & Nothing & "','-1',''", "Descripción", "Código", comboarea)
        General.cargarCombo(ConsultasAsis.DEPARTAMENTO_GLOSA_BUSCAR, "departamentos", "id departamento", combodepartamento)
    End Sub

    Private Sub Checkconsolidado_CheckedChanged(sender As Object, e As EventArgs) Handles Checkconsolidado.CheckedChanged

    End Sub


End Class