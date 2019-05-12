Public Class Urocultivo
    Public Property celEpi As String
    Public Property leucocito As String
    Public Property hematies As String
    Public Property bacteria As String
    Public Property otroCultivo As String
    Public Property PH As String
    Public Property trichomonas As String
    Public Property celuGuias As String
    Public Property textAmias As String
    Public Property KOH As String
    Public Property gram As String
    Public Property zhiel As String
    Public Property migroOrg As String
    Public Property sencible As String
    Public Property fechaRegistro As DateTime
    Public Property resistente As String
    Public Property sqlGuardarUrocultivo As String
    Public Property sqlAnularUrocultivo As String
    Public Property sqlCargarRegistroUrocultivo As String
    Public Property nombrePDF As String
    Public Sub New()
        sqlAnularUrocultivo = ConsultasHC.EXAMENES_PARACLINICOS_UROCUL_ANULAR
        sqlGuardarUrocultivo = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_UROC
        sqlCargarRegistroUrocultivo = ConsultasHC.PARAMETROS_EXAMES_UROC
        nombrePDF = ConstantesHC.NOMBRE_PDF_UROCULTIVO
    End Sub

    Public Sub cargarRegistro(codigoOrden As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(codigoOrden)
        dFila = General.cargarItem(sqlCargarRegistroUrocultivo, params)
        If Not IsNothing(dFila) Then
            PH = dFila.Item("ph")
            bacteria = dFila.Item("Bacterias")
            celEpi = dFila.Item("Celulas_epiteliales")
            hematies = dFila.Item("Hematies")
            leucocito = dFila.Item("Leucocitos")
            trichomonas = dFila.Item("trichomonas")
            celuGuias = dFila.Item("celulas_guias")
            textAmias = dFila.Item("test_amias")
            otroCultivo = dFila.Item("Otros")
            sencible = dFila.Item("sencible")
            resistente = dFila.Item("resistente")
            KOH = dFila.Item("examen_dir_koh")
            gram = dFila.Item("GRAM")
            zhiel = dFila.Item("ZHIEL")
            migroOrg = dFila.Item("microorganismos")
            fechaRegistro = dFila.Item("Fecha")
        Else
            limpiarObjeto()
        End If
    End Sub
    Private Sub limpiarObjeto()
        celEpi = String.Empty
        leucocito = String.Empty
        hematies = String.Empty
        bacteria = String.Empty
        otroCultivo = String.Empty
        PH = String.Empty
        trichomonas = String.Empty
        celuGuias = String.Empty
        textAmias = String.Empty
        KOH = String.Empty
        gram = String.Empty
        zhiel = String.Empty
        migroOrg = String.Empty
        sencible = String.Empty
        fechaRegistro = DateTime.Now
        resistente = String.Empty
    End Sub
    Public Function consultaReporteUrocultivo(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_UROCULTIVO.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_UROCULTIVO.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class
