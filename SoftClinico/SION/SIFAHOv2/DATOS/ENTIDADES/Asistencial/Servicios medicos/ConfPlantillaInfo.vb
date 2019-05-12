Public Class ConfPlantillaInfo
    Public Property codigoPlantilla As String
    Public Property Modulo As String
    Public Property codigoAreaServicio As Integer
    Public Property respuesto As Integer
    Public Property usarioCreacion As Integer
    Public Property codigoProcedimiento As String
    Public Property codigoOrden As String
    Public Property nombreDiag As String
    Public Property descripcionDiag As String
    Public Property dtPlantilla As DataTable
    Public Property sqlGuardarConfPlantillaInf As String
    Public Property sqlGuardarPlantillaInfR As String
    Public Property sqlGuardarPlantillaInfRR As String
    Public Property sqlBuscarConfPlantillaInf As String
    Public Property sqlCargarConfPlantillaInf As String
    Public Property sqlAnularConfPlantillaInf As String
    Public Sub New()
        sqlGuardarConfPlantillaInf = Consultas.CONF_PLANTILLA_INFO_CREAR
        sqlBuscarConfPlantillaInf = Consultas.CONF_PLANTILLA_INFO_BUSCAR
        sqlCargarConfPlantillaInf = Consultas.CONF_PLANTILLA_INFO_CARGAR
        sqlAnularConfPlantillaInf = Consultas.CONF_PLANTILLA_INFO_ANULAR
        sqlGuardarPlantillaInfR = Consultas.PLANTILLA_INFO_CREAR_R
        sqlGuardarPlantillaInfRR = Consultas.PLANTILLA_INFO_CREAR_RR
        dtPlantilla = New DataTable
        dtPlantilla.Columns.Add("Codigo Plantilla", Type.GetType("System.Int32"))
        dtPlantilla.Columns.Add("Codigo Procedimiento", Type.GetType("System.Int32"))
        dtPlantilla.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtPlantilla.Columns.Add("Area", Type.GetType("System.Int32"))
        dtPlantilla.Columns.Add("Nombre Area", Type.GetType("System.String"))
        dtPlantilla.Columns.Add("Nombre Diagnostico", Type.GetType("System.String"))
        dtPlantilla.Columns.Add("Interpretación", Type.GetType("System.String"))
        dtPlantilla.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
    End Sub

    Public Sub AnularConfPlantillaInf()
        General.anularRegistro(sqlAnularConfPlantillaInf & codigoPlantilla &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & usarioCreacion)
    End Sub
    Public Sub guardarRegistroR()
        ConfPlantillaInfBLL.guardarInformePlantillaR(Me)
    End Sub
    Public Sub guardarRegistroRR()
        ConfPlantillaInfBLL.guardarInformePlantillaRR(Me)
    End Sub
End Class
