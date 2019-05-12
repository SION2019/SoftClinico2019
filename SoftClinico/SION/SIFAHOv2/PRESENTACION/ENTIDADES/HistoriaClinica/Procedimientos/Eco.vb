Public Class Eco
    Inherits Procedimientos
    Public Property codigoMenu As String
    Public Property codigoTipoEco As String
    Public Property objEcocardiograma As Ecocardiograma
    Public Property objEcocardiogramaEstres As EcocardiogramaEstres
    Public Property descripcionHallazgo As String
    Public Property rpte As ReportClass
    Public Sub New()
        '----- Consultas 
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_ECOCARDIOGRAMA
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_ECOCARDIOGRAMA
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_ECOCARDIOGRAMA
        sqlCargarRegistro = Consultas.CARGAR_ECOCARDIOGRAMA
    End Sub
    Public Sub instanciaObjeto(modulo As String)
        '----- iniciar las clase segun eñ modulo 
        codigotipo()
        objEcocardiograma = GeneralHC.fabricaHC.crear(Constantes.CODIGO_ECOCARDIOGRAMA & Constantes.ECO & modulo)
        objEcocardiogramaEstres = GeneralHC.fabricaHC.crear(Constantes.CODIGO_ECO_ESTRES & Constantes.ECOSTRES & modulo)
    End Sub
    Public Function validarFormulario() As String
        '------valida el tirulo del formulario segun el modulo y el tipo de examen 
        Select Case codigoTipoEco
            Case Constantes.CODIGO_ECOCARDIOGRAMA
                titulo = objEcocardiograma.titulo
            Case Constantes.CODIGO_ECO_ESTRES
                titulo = objEcocardiogramaEstres.titulo
        End Select
        Return titulo
    End Function
    Public Overrides Sub guardarRegistro()
        If String.IsNullOrEmpty(codigo) Then
            codigo = Constantes.VALOR_PREDETERMINADO '--------validamos que el codigo este sin registro para poder generar uno nuevo 
        End If
        EcocardiogramaBLL.guardarEcocardiograma(Me)
    End Sub

    Public Sub MostrarReporte()
        '----------validamos el area segun el tipo de examen de ecocardiograma 
        Select Case codigoTipoEco
            Case Constantes.CODIGO_ECOCARDIOGRAMA
                area = objEcocardiograma.area
            Case Constantes.CODIGO_ECO_ESTRES
                area = objEcocardiogramaEstres.area
        End Select
    End Sub
    Public Sub codigotipo()
        '---- consultamos el codigo del examen eco
        Try
            If codigoMenu = Constantes.CODIGO_MENU_ECOSTRES_HC _
                                Or codigoMenu = Constantes.CODIGO_MENU_ECOSTRES_AM _
                                Or codigoMenu = Constantes.CODIGO_MENU_ECOSTRES_AF Then
                codigoTipoEco = Constantes.CODIGO_ECO_ESTRES
            Else
                codigoTipoEco = Constantes.CODIGO_ECOCARDIOGRAMA
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub anularEco(activoAM As Boolean, activoAF As Boolean)
        '---------------- codigo para anular
        Dim nombrePdf, nombrePdfR, nombrePdfRR, consulta As String
        Dim params As New List(Of String)

        params.Add(usuario)
        params.Add(codigo)
        params.Add(CodigoEP)
        params.Add(editado)

        Select Case codigoTipoEco
            Case Constantes.CODIGO_ECOCARDIOGRAMA
                consulta = objEcocardiograma.sqlAnularRegistro
                nombrePdf = ConstantesHC.NOMBRE_PDF_ECO
                nombrePdfR = ConstantesHC.NOMBRE_PDF_ECO_R
                nombrePdfRR = ConstantesHC.NOMBRE_PDF_ECO_RR
            Case Constantes.CODIGO_ECO_ESTRES
                consulta = objEcocardiogramaEstres.sqlAnularRegistro
                nombrePdf = ConstantesHC.NOMBRE_PDF_ECOSTRES
                nombrePdfR = ConstantesHC.NOMBRE_PDF_ECOSTRES_R
                nombrePdfRR = ConstantesHC.NOMBRE_PDF_ECOSTRES_RR
        End Select
        General.ejecutarSQL(consulta, params)
        ftp_reportes.eliminarArchivo(nombrePdf & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        If activoAM = True Then
            ftp_reportes.eliminarArchivo(nombrePdfR & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
        If activoAF = True Then
            ftp_reportes.eliminarArchivo(nombrePdfRR & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
    End Sub


End Class
