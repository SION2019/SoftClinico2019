Public Class Uroanalisis

    Public Property celEpi As String
    Public Property leucocito As String
    Public Property hematies As String
    Public Property color As String
    Public Property aspecto As String
    Public Property PH As String
    Public Property densidad As String
    Public Property urobilinogenos As String
    Public Property cetona As String
    Public Property otroUro As String
    Public Property cilindro As String
    Public Property cristale As String
    Public Property otroUroSet As String
    Public Property proteina As String
    Public Property glucosa As String
    Public Property sangre As String
    Public Property bilirubina As String
    Public Property nitrito As String
    Public Property bacteria As String
    Public Property plocito As String
    Public Property fechaRegistro As DateTime
    Public Property sqlGuardarUroanalisis As String
    Public Property sqlAnularUroanalisis As String
    Public Property sqlCargarRegistroUroanalisis As String
    Public Property nombrePDF As String
    Public Sub New()
        sqlAnularUroanalisis = ConsultasHC.EXAMENES_PARACLINICOS_UROANAL_ANULAR
        sqlGuardarUroanalisis = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_UROA
        sqlCargarRegistroUroanalisis = ConsultasHC.PARAMETROS_EXAMES_UROA
        nombrePDF = ConstantesHC.NOMBRE_PDF_UROANALISIS
    End Sub

    Public Sub cargarRegistro(codigoOrden As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(codigoOrden)
        dFila = General.cargarItem(sqlCargarRegistroUroanalisis, params)
        If Not IsNothing(dFila) Then
            color = dFila.Item("color")
            aspecto = dFila.Item("aspecto")
            PH = dFila.Item("PH")
            bacteria = dFila.Item("bacterias")
            densidad = dFila.Item("densidad")
            urobilinogenos = dFila.Item("urobilinogeno")
            cetona = dFila.Item("cetona")
            otroUro = dFila.Item("Otros_Orina")
            proteina = dFila.Item("proteinas")
            glucosa = dFila.Item("glucosa")
            sangre = dFila.Item("sangre")
            bilirubina = dFila.Item("bilirubina")
            nitrito = dFila.Item("nitritos")
            celEpi = dFila.Item("Cel_Epitelial")
            hematies = dFila.Item("hematies")
            cilindro = dFila.Item("cilindro")
            cristale = dFila.Item("cristales")
            otroUroSet = dFila.Item("Otros_sedimento")
            leucocito = dFila.Item("leucocitos")
            plocito = dFila.Item("plocitos")
            fechaRegistro = dFila.Item("Fecha")
        Else
            limpiarObjeto()
        End If
    End Sub
    Private Sub limpiarObjeto()
        celEpi = String.Empty
        leucocito = String.Empty
        hematies = String.Empty
        color = String.Empty
        aspecto = String.Empty
        PH = String.Empty
        densidad = String.Empty
        urobilinogenos = String.Empty
        cetona = String.Empty
        otroUro = String.Empty
        cilindro = String.Empty
        cristale = String.Empty
        otroUroSet = String.Empty
        proteina = String.Empty
        glucosa = String.Empty
        sangre = String.Empty
        bilirubina = String.Empty
        nitrito = String.Empty
        bacteria = String.Empty
        plocito = String.Empty
        fechaRegistro = DateTime.Now
    End Sub
    Public Function consultaReporteUroanalisis(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_UROANALISIS.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_UROANALISIS.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class
