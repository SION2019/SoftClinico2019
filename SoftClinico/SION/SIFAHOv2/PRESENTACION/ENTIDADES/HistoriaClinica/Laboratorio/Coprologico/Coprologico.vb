Public Class Coprologico

    Public Property consistencia As String
    Public Property leucocito As String
    Public Property moco As String
    Public Property color As String
    Public Property PH As String
    Public Property azucareReductores As String
    Public Property coli As String
    Public Property histolitico As String
    Public Property nana As String
    Public Property lodomoeba As String
    Public Property griardia As String
    Public Property ascari As String
    Public Property tricocefalo As String
    Public Property uncinaria As String
    Public Property sangreOculta As String
    Public Property Hymenolepi As String
    Public Property teniaGP As String
    Public Property otro As String
    Public Property hongo As String
    Public Property fechaRegistro As DateTime
    Public Property sqlGuardarCoprologico As String
    Public Property sqlAnularCoprologico As String
    Public Property sqlCargarRegistroCoprologico As String
    Public Property nombrePDF As String
    Public Sub New()
        sqlAnularCoprologico = ConsultasHC.EXAMENES_PARACLINICOS_COPRO_ANULAR
        sqlGuardarCoprologico = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_COPRO
        sqlCargarRegistroCoprologico = ConsultasHC.PARAMETROS_EXAMES_COPRO
        nombrePDF = ConstantesHC.NOMBRE_PDF_COPROLOGICO
    End Sub
    Public Sub cargarRegistro(codigoOrden As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(codigoOrden)
        dFila = General.cargarItem(sqlCargarRegistroCoprologico, params)
        If Not IsNothing(dFila) Then
            color = dFila.Item("color")
            PH = dFila.Item("PH")
            leucocito = dFila.Item("leucocitos")
            consistencia = dFila.Item("consistencia")
            sangreOculta = dFila.Item("Sangre")
            moco = dFila.Item("moco")
            azucareReductores = dFila.Item("azucares")
            coli = dFila.Item("coli")
            histolitico = dFila.Item("histolitica")
            nana = dFila.Item("nana")
            lodomoeba = dFila.Item("iodomoeba")
            griardia = dFila.Item("giardia")
            otro = dFila.Item("otros")
            ascari = dFila.Item("ascaris")
            tricocefalo = dFila.Item("tricocefalo")
            uncinaria = dFila.Item("uncinaria")
            Hymenolepi = dFila.Item("hymenolepis")
            teniaGP = dFila.Item("gp")
            hongo = dFila.Item("hongos")
            fechaRegistro = dFila.Item("Fecha")
        Else
            limpiarObjetos()
        End If
    End Sub
    Private Sub limpiarObjetos()
        consistencia = String.Empty
        leucocito = String.Empty
        moco = String.Empty
        color = String.Empty
        PH = String.Empty
        azucareReductores = String.Empty
        coli = String.Empty
        histolitico = String.Empty
        nana = String.Empty
        lodomoeba = String.Empty
        griardia = String.Empty
        ascari = String.Empty
        tricocefalo = String.Empty
        uncinaria = String.Empty
        sangreOculta = String.Empty
        Hymenolepi = String.Empty
        teniaGP = String.Empty
        otro = String.Empty
        hongo = String.Empty
        fechaRegistro = DateTime.Now
    End Sub
    Public Function consultaReporteCoprologico(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_COPROLOGICO.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_COPROLOGICO.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class
