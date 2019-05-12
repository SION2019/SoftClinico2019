Public Class TintaChina
    Public Property muestra As String
    Public Property resultado As String
    Public Property fechaRegistro As DateTime
    Public Property sqlGuardarTinta As String
    Public Property sqlAnularTinta As String
    Public Property sqlCargarRegistroTinta As String
    Public Property nombrePDF As String
    Public Sub New()
        sqlAnularTinta = ConsultasHC.EXAMENES_PARACLINICOS_TINTA_ANULAR
        sqlGuardarTinta = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_TINTA
        sqlCargarRegistroTinta = ConsultasHC.PARAMETROS_EXAMES_TINTA
        nombrePDF = ConstantesHC.NOMBRE_PDF_TINTA
    End Sub
    Public Sub cargarRegistro(codigoOrden As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(codigoOrden)
        dFila = General.cargarItem(sqlCargarRegistroTinta, params)
        If Not IsNothing(dFila) Then
            muestra = dFila.Item("muestra")
            resultado = dFila.Item("resultado")
            fechaRegistro = dFila.Item("Fecha")
        Else
            limpiarObjeto()
        End If
    End Sub
    Private Sub limpiarObjeto()
        muestra = String.Empty
        resultado = String.Empty
        fechaRegistro = DateTime.Now
    End Sub
    Public Function consultaReporteTintaChina(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_TINTA_CHINA.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_TINTA_CHINA.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class
