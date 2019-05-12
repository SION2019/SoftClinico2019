Public Class PartoRecienNacido
    Inherits InfoIngresoNeonato


    Public Sub New()
        sqlDetalleCarga = Consultas.INFO_INGRESO_PARTO_CARGAR
        nombreReporte = ConstantesHC.NOMBRE_PDF_INGRESO_MEDICO
        objReporte = New rptInfoIngresoNeonato
        vistaReporte = "VISTA_H_INGRESO_NEONATAL"
        moduloReporte = Constantes.REPORTE_HC
    End Sub
    Public Overrides Sub cargarDetalle()
        elementoAEliminar.Clear()
        cargarDetallePaciente()
        cargarDetalleImpresion()
    End Sub
    Public Overrides Sub cargarDetallePaciente()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(nRegistro)
        General.llenarTabla(sqlDetalleCarga, params, dt)
        If dt.Rows.Count > 0 Then
            nombre = dt.Rows(0).Item("NOMBRE").ToString ''ESTE LO UTILIZAREMOS COMO EL NOMBRE DEL BEBE
            fechaParto = dt.Rows(0).Item("FECHA_PARTO").ToString ''ESTE LO UTILIZAREMOS COMO FECHA DEL PARTO
            sexo = dt.Rows(0).Item("SEXO").ToString ''ESTO LO UTILIZAREMOS COMO SEXO
            peso = dt.Rows(0).Item("Peso").ToString
            'pesoUltimo = dt.Rows(0).Item("UltimoPeso").ToString
            motivo = dt.Rows(0).Item("motivo_ingreso").ToString
            tParto = dt.Rows(0).Item("t_parto").ToString
            tRupturaM = dt.Rows(0).Item("t_rupt_menbrana").ToString
            induccionParto = dt.Rows(0).Item("indu_parto").ToString
            caracteristicasLiquidas = dt.Rows(0).Item("caract_liquidas").ToString
            apgar1 = dt.Rows(0).Item("apgar1").ToString
            apgar5 = dt.Rows(0).Item("apgar5").ToString
            reanimacion = dt.Rows(0).Item("reanim_nacer").ToString
            vih = dt.Rows(0).Item("NOMBRE").ToString
            edadGestacional = dt.Rows(0).Item("edad_gesta").ToString
            fumador = dt.Rows(0).Item("fum").ToString
            antecedentesObstetricos = dt.Rows(0).Item("ant_obstetrico").ToString
            hemoclasificacionMadre = dt.Rows(0).Item("hemoc_maternal").ToString
            hemoclasificacionPadre = dt.Rows(0).Item("hemoc_paternal").ToString
            control = dt.Rows(0).Item("control_prenatal").ToString
            medicamentos = dt.Rows(0).Item("medc_durat_embarazo").ToString
            habito = dt.Rows(0).Item("habito").ToString
            infeccion = dt.Rows(0).Item("infecc_embarazo").ToString
            diabeteG = dt.Rows(0).Item("diabete_gest").ToString
            diabeteM = dt.Rows(0).Item("diabete_mellitus").ToString
            hipertencion = dt.Rows(0).Item("hipertenc_gesta").ToString
            preclampcia = dt.Rows(0).Item("preclampcia").ToString
            enfermedad = dt.Rows(0).Item("enferm_tiroidea").ToString
            vacunacion = dt.Rows(0).Item("vacunacion").ToString
            torch = dt.Rows(0).Item("torch").ToString
            hemoclasificacion = dt.Rows(0).Item("hemoclasificacion").ToString
            vdrl = dt.Rows(0).Item("vdrl").ToString
            tsh = dt.Rows(0).Item("tsh").ToString
            glucometria = dt.Rows(0).Item("glucometria").ToString
            generales = dt.Rows(0).Item("Generales").ToString
            signosVitales = dt.Rows(0).Item("Sig_Vitales").ToString
            cabezaYCuello = dt.Rows(0).Item("Cab_Cuello").ToString
            torax = dt.Rows(0).Item("Torax").ToString
            cardio = dt.Rows(0).Item("Card_Pulm").ToString
            abdomen = dt.Rows(0).Item("Abdom").ToString
            gentoUrinario = dt.Rows(0).Item("Genturinario").ToString
            extremidades = dt.Rows(0).Item("Extrem").ToString
            sistemaNervioso = dt.Rows(0).Item("S_Nerv_Central").ToString
            analisis = dt.Rows(0).Item("Analiisis").ToString
            pronostico = dt.Rows(0).Item("Pronosticos").ToString
            usuarioNombre = dt.Rows(0).Item("Usuario").ToString
            usuarioReal = dt.Rows(0).Item("usuarioInforme").ToString
            'codEps = dt.Rows(0).Item("Id_Tercero_EPS").ToString
            usuarioCreacion = dt.Rows(0).Item("usuarioCreacion").ToString
            'diasEstancia = dt.Rows(0).Item("dias_estancias").ToString
        End If

    End Sub

    Public Overrides Sub guardarDetalle()
        Dim dtDiagnostico As New DataTable
        dtDiagnostico = dtDiagImpresion.Copy
        dtDiagnostico.Columns.RemoveAt(1)
        dtDiagnostico.Columns.RemoveAt(1)
        dtDiagnostico.Rows.RemoveAt(dtDiagnostico.Rows.Count - 1)
        For i = 0 To dtDiagnostico.Rows.Count - 1
            If IsDBNull(dtDiagnostico.Rows(i).Item(1)) Then
                dtDiagnostico.Rows(i).Item(1) = ""
            End If

        Next


        HistoriaClinicaDAL.guardarInfoIngresoParto(Me, dtDiagnostico)
    End Sub
    Public Sub guardarEmbarazo()
        HistoriaClinicaDAL.guardarInfoIngresoEmbarazo(Me)
    End Sub

    Public Sub anularEmbarazo()
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(nRegistro)
        General.ejecutarSQL(Consultas.ANULAR_EMBARAZO, params)
    End Sub
    Public Sub anularParto()
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(nRegistro)
        General.ejecutarSQL(Consultas.ANULAR_ADMISION, params)
    End Sub
End Class
