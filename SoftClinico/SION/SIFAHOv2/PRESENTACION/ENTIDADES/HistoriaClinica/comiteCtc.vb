Public Class comiteCtc
    Public Property Codigo_CTC As String
    Public Property Codigo_Intero As Integer
    Public Property Codigo_Solic As Integer
    Public Property Codigo_PEM As Integer
    Public Property Encabezado As String
    Public Property Decision As String
    Public Property Fecha_ctc As DateTime
    Public Property Dosis As Integer
    Public Property Cant As Integer
    Public Property Dias As Integer
    Public Property Usuario_R As Integer
    Public Property dtdiag As DataTable
    Public Property dtAsistentes As DataTable
    Public Property Usuario As Integer
    Sub New()
        '---- Diagnostico
        dtdiag = New DataTable
        dtdiag.Columns.Add("Codigo", Type.GetType("System.String"))
        '---- Asistentes
        dtAsistentes = New DataTable
        dtAsistentes.Columns.Add("Codigo_CTC", Type.GetType("System.String"))
        dtAsistentes.Columns.Add("ID_Empleado", Type.GetType("System.Int32"))
        dtAsistentes.Columns.Add("Indice", Type.GetType("System.Int32"))

    End Sub

End Class
