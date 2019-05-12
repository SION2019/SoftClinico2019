Public Class Serologia
    Public Property VDRL As String
    Public Property ASTO As String
    Public Property PCR As String
    Public Property RATES As String
    Public Property GX_sangre As String
    Public Property HIV As String
    Public Property Hepatitis_B As String
    Public Property Hepatitis_A As String
    Public Property Hepatitis_C As String
    Public Property Tifoidea_O As String
    Public Property Tifoidea_H As String
    Public Property Paratifoidea_A As String
    Public Property Paratifoidea_B As String
    Public Property Brucella As String
    Public Property Proteus_OX As String
    Public Property Observacion As String
    Public Property fechaReal As DateTime
    Public Property Taxoplasma_IGM As String
    Public Property Taxoplasma_IGG As String
    Public Property sqlGuardarSerologia As String
    Public Property sqlAnularSerologia As String
    Public Property sqlCargarRegistroSerologia As String
    Public Property nombrePDF As String
    Public Sub New()
        sqlAnularSerologia = ConsultasHC.EXAMENES_PARACLINICOS_SEROL_ANULAR
        sqlGuardarSerologia = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_SEROLOGIA
        sqlCargarRegistroSerologia = ConsultasHC.PARAMETROS_EXAMES_SEROL
        nombrePDF = ConstantesHC.NOMBRE_PDF_SEROLOGIA
    End Sub
    Public Sub cargarRegistro(codigoOrden As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(codigoOrden)
        dFila = General.cargarItem(sqlCargarRegistroSerologia, params)
        If Not IsNothing(dFila) Then
            VDRL = dFila.Item("VDRL")
            ASTO = dFila.Item("ASTO")
            PCR = dFila.Item("PCR")
            RATES = dFila.Item("RATES")
            GX_sangre = dFila.Item("GX_sangre")
            HIV = dFila.Item("HIV")
            Hepatitis_B = dFila.Item("Hepatitis_B")
            Hepatitis_A = dFila.Item("Hepatitis_A")
            Hepatitis_C = dFila.Item("Hepatitis_C")
            Tifoidea_O = dFila.Item("Tifoidea_O")
            Tifoidea_H = dFila.Item("Tifoidea_H")
            Paratifoidea_A = dFila.Item("Paratifoidea_A")
            Paratifoidea_B = dFila.Item("Paratifoidea_B")
            Brucella = dFila.Item("Brucella")
            Proteus_OX = dFila.Item("Proteus_OX")
            Observacion = dFila.Item("Observacion")
            Taxoplasma_IGM = dFila.Item("Taxoplasma_IGM")
            Taxoplasma_IGG = dFila.Item("Taxoplasma_IGG")
            fechaReal = dFila.Item("Fecha")
        Else
            limpiarObjeros()
        End If
    End Sub
    Private Sub limpiarObjeros()
        VDRL = String.Empty
        ASTO = String.Empty
        PCR = String.Empty
        RATES = String.Empty
        GX_sangre = String.Empty
        HIV = String.Empty
        Hepatitis_B = String.Empty
        Hepatitis_A = String.Empty
        Hepatitis_C = String.Empty
        Tifoidea_O = String.Empty
        Tifoidea_H = String.Empty
        Paratifoidea_A = String.Empty
        Paratifoidea_B = String.Empty
        Brucella = String.Empty
        Proteus_OX = String.Empty
        Observacion = String.Empty
        fechaReal = DateTime.Now
        Taxoplasma_IGM = String.Empty
        Taxoplasma_IGG = String.Empty
    End Sub
    Public Function consultaReporteSerologia(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_SEROLOGIA.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_SEROLOGIA.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class
