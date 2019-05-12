Public Class Admision
    Public Property nRegistro As String
    Public Property identiPaciente As Integer
    Public Property fechaAdmision As DateTime
    Public Property CodigoEp As Integer
    Public Property codigoEspecialidad As Integer
    Public Property codigoTriage As Integer
    Public Property codigoContrato As Integer
    Public Property codigoArea As Integer
    Public Property idContacto As Integer
    Public Property codigoIdAcompanate As Integer
    Public Property idAcompanate As String
    Public Property acompanante As String
    Public Property Direccion As String
    Public Property telAcompanate As String
    Public Property codigoPais As String
    Public Property codigoDepartamento As String
    Public Property codigoMunicipio As String
    Public Property codigoIdResponsable As Integer
    Public Property idResponsable As String
    Public Property responsable As String
    Public Property direccionResponsable As String
    Public Property telResponsable As String
    Public Property codigoPaisResponsable As String
    Public Property codigoDepartamentoResponsable As String
    Public Property codigoMunicipioResponsable As String
    Public Property usuario As String
    Public Property numAutorizacion As String
    Public Property viaIngreso As Integer
    Public Property institucion As Integer
    Public Property causaExterna As Integer
    Public Property codigoEstado As Integer
    Public Property codigoCama As Integer
    Public Property dtDiagnostico As DataTable
    Public Property dtTraslado As DataTable
    Public Property tipoDocumento As Integer
    Public Property opcionAcomp As Boolean
    Public Property opcionRespon As Boolean
    Public Property imagen As Byte()

    Sub New()
        dtDiagnostico = New DataTable
        dtDiagnostico.Columns.Add("N_Registro", Type.GetType("System.String"))
        dtDiagnostico.Columns.Add("Codigo_CIE", Type.GetType("System.String"))
    End Sub
End Class
