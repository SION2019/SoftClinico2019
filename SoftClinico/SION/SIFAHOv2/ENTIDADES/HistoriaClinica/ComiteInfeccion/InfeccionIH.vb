Public Class InfeccionIH
    Public Property codigoSolicitud As String
    Public Property nRegistro As Integer
    Public Property fechaSolicitud As Date
    Public Property medico As Integer
    Public Property motivo As String
    Public Property codigoEvo As Integer
    Public Property fechaAnalisis As Date
    Public Property analisis As String
    Public Property paquete As String
    Public Property infectologo As Integer
    Public Property neonatologo As Integer
    Public Property coordinadorNeonatos As Integer
    Public Property coordinadorAdulto As Integer
    Public Property auditorCuentas As Integer
    Public Property auditorConcu As Integer
    Public Property coordinadorAdminis As Integer
    Public Property fumador As Boolean
    Public Property diabetes As Boolean
    Public Property medicamentos As Boolean
    Public Property menor1000 As Boolean
    Public Property obesidad As Boolean
    Public Property inmunoSupresion As Boolean
    Public Property prematuro As Boolean
    Public Property otros As Boolean
    Public Property cvc As Boolean
    Public Property ventilacion As Boolean
    Public Property sondaV As Boolean
    Public Property sondaNasogastrica As Boolean
    Public Property aislamiento As String
    Public Property fechaCvc As Date
    Public Property fechaVent As Date
    Public Property fechaSondaV As Date
    Public Property fechaSondaN As Date
    Public Property fechaAlta As Date
    Public Property observacion As String
    Public Property inicial As String
    Public Property modificacion1 As String
    Public Property modificacion2 As String
    Public Property modificacion3 As String
    Public Property justificacion1 As String
    Public Property justificacion2 As String
    Public Property justificacion3 As String
    Public Property fechaMicro1 As Date
    Public Property muestra1 As String
    Public Property germen1 As String
    Public Property fechaMicro2 As Date
    Public Property muestra2 As String
    Public Property germen2 As String
    Public Property fechaMicro3 As Date
    Public Property muestra3 As String
    Public Property germen3 As String
    Public Property fechaMicro4 As Date
    Public Property muestra4 As String
    Public Property germen4 As String
    Public Property fechaMicro5 As Date
    Public Property muestra5 As String
    Public Property germen5 As String
    Public Property fechaMicro6 As Date
    Public Property muestra6 As String
    Public Property germen6 As String
    Public Property usuarioActualizacion As Integer
    Public Property usuarioCreacion As Integer
    Public Property dtRespuestas As DataTable

    Public Property detalleIH As List(Of InfeccionIH_Detalle)

    Sub New()

        dtRespuestas = New DataTable

        dtRespuestas.Columns.Add("codigo_solicitud", Type.GetType("System.String"))
        dtRespuestas.Columns.Add("codigo_criterio", Type.GetType("System.String"))
        dtRespuestas.Columns.Add("respuesta", Type.GetType("System.String"))

    End Sub



End Class
