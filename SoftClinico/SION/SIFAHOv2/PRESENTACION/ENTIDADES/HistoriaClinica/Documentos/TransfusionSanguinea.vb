Public Class TransfusionSanguinea

    'Formato del Medico
    Public Property CodigoTransfusion As String
    Public Property CodigoOrden As String
    Public Property codigoProcedimiento As String
    Public Property Fecha As DateTime
    Public Property GrupoSanguineo As String
    Public Property Rh As String
    Public Property Transfundir As Int32
    Public Property Reserva As String
    Public Property sangre As Boolean
    Public Property globulRoroja2 As Boolean
    Public Property globuloRoja As Boolean
    Public Property Plasma As Boolean
    Public Property Plaquetas As Boolean
    Public Property Otros As Boolean
    Public Property Sala As String
    Public Property fechaSala As DateTime
    Public Property transfusionesPrevia As Boolean
    Public Property Cuantas As String
    Public Property RASangre As Boolean
    Public Property RAplasma As Boolean
    Public Property RAOtros As Boolean
    Public Property RAnacidoMuerto As Boolean
    Public Property RAAborto As Boolean
    Public Property RAEnfHemoliticaRNfeto As Boolean
    Public Property Diagnostico As String
    Public Property Usuario As Integer
    Public Property dtLaboratorio As DataTable
    Public Property dtEnfermera As DataTable
    Public Property dtenfermera2 As DataTable
    Public Property codigoEp As Integer
    'formato laboratorio2
    Public Property rastreo As String
    Public Property observaciones As String


    Sub New()
        'Formato de Laboratorio

        dtLaboratorio = New DataTable
        dtLaboratorio.Columns.Add("Codigo_TS", Type.GetType("System.String"))
        dtLaboratorio.Columns.Add("bolsa", Type.GetType("System.String"))
        dtLaboratorio.Columns.Add("gs", Type.GetType("System.String"))
        dtLaboratorio.Columns.Add("rh", Type.GetType("System.String"))
        dtLaboratorio.Columns.Add("sello", Type.GetType("System.String"))
        dtLaboratorio.Columns.Add("prueba", Type.GetType("System.String"))
        dtLaboratorio.Columns.Add("fecha", Type.GetType("System.DateTime"))
        dtLaboratorio.Columns.Add("usuario_creacion", Type.GetType("System.Int32"))

        'primera dgv de enfermeria

        dtEnfermera = New DataTable
        dtEnfermera.Columns.Add("Codigo_TS", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("bolsae", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("aplicada", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("pa", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("pulso", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("temperatura", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("fechae1", Type.GetType("System.DateTime"))
        dtEnfermera.Columns.Add("fechae2", Type.GetType("System.DateTime"))
        dtEnfermera.Columns.Add("respondio", Type.GetType("System.String"))
        dtEnfermera.Columns.Add("usuario_creacione", Type.GetType("System.String"))

        'segunda dgv de enfermeria

        dtenfermera2 = New DataTable
        dtenfermera2.Columns.Add("Codigo_TS", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("bolsar", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("hora", Type.GetType("System.DateTime"))
        dtenfermera2.Columns.Add("par", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("pulsor", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("temperaturar", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("describalo", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("rechaza", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("observaciones", Type.GetType("System.String"))
        dtenfermera2.Columns.Add("usuario_creacioner", Type.GetType("System.String"))
    End Sub






End Class
