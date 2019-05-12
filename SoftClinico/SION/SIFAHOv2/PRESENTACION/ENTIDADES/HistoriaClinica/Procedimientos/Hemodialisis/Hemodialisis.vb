Public Class Hemodialisis
    Inherits Procedimientos
    Public Property dtSigno As DataTable
    Public Property dtMedicamento As DataTable
    Public Property nota As String
    Public Property resultado As String

    Public Sub New()
        dtSigno = New DataTable
        dtMedicamento = New DataTable
        titulo = "HEMODIALISIS: HISTORIA CLÍNICA"
        area = ConstantesHC.NOMBRE_PDF_HEMODIALISIS
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_HEMO
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_HEMO
        sqlCargarRegistro = Consultas.CARGAR_HEMO
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_HEMODIALISI
        sqlGuardarRegistro = Consultas.CREAR_HEMO
        sqlAnularRegistro = Consultas.HEMOD_ANULAR

        dtSigno.Columns.Add("HORA", Type.GetType("System.String"))
        dtSigno.Columns.Add("TA", Type.GetType("System.String"))
        dtSigno.Columns.Add("FC", Type.GetType("System.String"))
        dtSigno.Columns.Add("FR", Type.GetType("System.String"))
        dtSigno.Columns.Add("TAM", Type.GetType("System.String"))
        dtSigno.Columns.Add("SPO3%", Type.GetType("System.String"))
        dtSigno.Columns.Add("TEMP", Type.GetType("System.String"))

        dtMedicamento.Columns.Add("Codigo", Type.GetType("System.String"))
        dtMedicamento.Columns.Add("Medicamento", Type.GetType("System.String"))
        dtMedicamento.Columns.Add("Cantidad", Type.GetType("System.String"))

    End Sub
    Public Overrides Sub guardarRegistro()
        If String.IsNullOrEmpty(codigo) Then
            codigo = -1
        End If
        HemodialisiBLL.guardarHemodialisi(Me)
    End Sub
    Public Sub anularHemodialisis(activoAM As Boolean, activoAF As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(codigo)
        params.Add(SesionActual.codigoEP)
        params.Add(editado)

        General.ejecutarSQL(sqlAnularRegistro, params)
        ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_HEMODIALISIS & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        If activoAM = True Then
            ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_HEMODIALISIS_R & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
        If activoAF = True Then
            ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_HEMODIALISIS_RR & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
    End Sub
End Class
