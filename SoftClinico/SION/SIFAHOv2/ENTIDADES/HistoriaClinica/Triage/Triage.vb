Public Class Triage
    Public Property codigoTriage As String
    Public Property nivelTriage As Integer
    Public Property registro As Integer
    Public Property fecha As DateTime
    Public Property esNeonatal As Boolean
    Public Property codigoAreaServicio As Integer
    '>> Datos Ingreso
    Public Property motivoConsulta As String
    Public Property tblParametros As DataTable
    Public Property tblDiagnostico As DataTable
    '>>antecedentes Adulto
    Public Property medicos As String
    Public Property quirurgicos As String
    Public Property traumaticos As String
    Public Property trasnfucionales As String
    Public Property alergicos As String
    Public Property toxico As String
    Public Property anteFamiliares As String
    '>> antecedentes Neo
    Public Property edadMadre As String
    Public Property edadGestacional As String
    Public Property fum As String
    Public Property obstetricos As String
    Public Property hemM As String
    Public Property hemP As String
    Public Property controlPrenatal As String
    Public Property medDurantembarazo As String
    Public Property habitos As String
    Public Property infeccEmb As String
    Public Property diabGestacional As String
    Public Property diabMellitus As String
    Public Property hiperGestacional As String
    Public Property preclancia As String
    Public Property enfermTiroidea As String
    Public Property vacunacion As String
    Public Property torch As String
    Public Property hemoclasificacion As String
    Public Property tsh As String
    Public Property vdrl As String
    Public Property glucometria As String
    '>> Examen fisico
    Public Property torax As String
    Public Property cabCue As String
    Public Property abdomen As String
    Public Property cardioPulmonar As String
    Public Property extremidades As String
    Public Property sisNervCen As String
    Public Property genitoUrinario As String
    Public Property descripcionAreaTraslado As String
    Sub New()
        codigoAreaServicio = -1
        tblParametros = New DataTable
        tblParametros.Columns.Add("Codigo_Parametro")
        tblParametros.Columns.Add("Descripcion")
        tblParametros.Columns.Add("Resultado")

        tblDiagnostico = New DataTable
        tblDiagnostico.Columns.Add("Codigo")
        tblDiagnostico.Columns.Add("Descripcion")
    End Sub
    Sub llenarParametrosSignos()
        Dim params As New List(Of String)
        General.llenarTabla(Consultas.PARAMETROS_TRIAGE_POR_DEFECTO, params, tblParametros)
    End Sub
    Public Overridable Sub guardarTriage()
        Dim objTriageBLL As New TriageBLL
        Try
            objTriageBLL.guardarTriage(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
