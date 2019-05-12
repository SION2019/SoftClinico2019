Public Class ExamenResultado
    Inherits Procedimientos
    Public Property codigoTipo As Integer
    Public Property observacion As String
    Public Property dtExamen As DataTable
    Public Property verificarRegistroGuardado As Boolean
    Public Property contador As Integer = 1
    Public Property sqlCargarRegistroDetalle As String
    Private muestraPDF As Boolean
    Private mustraImage As Boolean
    Sub New()
        titulo = TitulosForm.TITULO_RESULT
        sqlCargarRegistro = ConsultasHC.RESULTADO_EXAMENES_CARGAR
        sqlAnularRegistro = ConsultasHC.RESULTADO_EXAMEN_ANULAR
        sqlGuardarRegistro = ConsultasHC.RESULTADO_EXAMEN_GUARDAR
        sqlCargarRegistroDetalle = ConsultasHC.RESULTADO_EXAMENES_CARGAR_D
        area = ConstantesHC.NOMBRE_PDF_RESULTADO
        dtExamen = New DataTable
        dtExamen.Columns.Add("nombreArchivo", Type.GetType("System.String"))
        dtExamen.Columns.Add("Archivo", Type.GetType("System.Byte[]"))
        dtExamen.Columns.Add("ruta", Type.GetType("System.String"))
        dtExamen.Columns.Add("idArchivo", Type.GetType("System.Int32"))
    End Sub

    Public Overrides Sub guardarRegistro()
        ExamenResultadoBLL.guardarResultado(Me)
    End Sub
    Public Sub cargarResultado()
        Try
            Dim params As New List(Of String)
            Dim drResultado As DataRow
            params.Add(CodigoOrden)
            params.Add(CodigoProcedimiento)
            drResultado = General.cargarItem(sqlCargarRegistro, params)
            If drResultado IsNot Nothing Then
                codigoTipo = drResultado.Item(0).ToString
                observacion = drResultado.Item(1).ToString
                verificarRegistroGuardado = True '-------------------bandera que me identifica que los datos estan en la base de datos 
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cargarImagenDicom()
        Dim params As New List(Of String)
        Dim contador As Integer
        Dim ruta As String
        Try
            params.Add(CodigoOrden)
            params.Add(CodigoProcedimiento)
            General.llenarTabla(sqlCargarRegistroDetalle, params, dtExamen)
            While (dtExamen.Rows.Count - 1) >= contador
                ruta = IO.Path.GetTempPath & Format(DateTime.Now, "ddMMyyyyHHmmss") &
                ConstantesHC.NOMBRE_PDF_SEPARADOR & contador &
                ConstantesHC.NOMBRE_PDF_SEPARADOR & dtExamen.Rows(contador).Item("nombreArchivo")
                IO.File.WriteAllBytes(ruta, dtExamen.Rows(contador).Item("Archivo"))
                dtExamen.Rows(contador).Item("ruta") = ruta
                contador = contador + 1
            End While
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function muestraVisorPDF() As Boolean
        Return If(codigoTipo = ConstantesHC.CODIGO_PDF, True, False)
    End Function
    'Public Function muestraVisorImage() As Boolean
    '    Return If(codigoTipo = ConstantesHC.CODIGO_IMAGE_COMUN, True, False)
    'End Function
    Public Function muestraVisorDicom() As Boolean
        Return If(codigoTipo = ConstantesHC.CODIGO_IMAGEN_DCM, True, False)
    End Function
    Public Function cargarImagen(abrirArchivo As OpenFileDialog) As DataTable
        Return General.subirimagenDiagnostica(abrirArchivo)
    End Function

End Class
