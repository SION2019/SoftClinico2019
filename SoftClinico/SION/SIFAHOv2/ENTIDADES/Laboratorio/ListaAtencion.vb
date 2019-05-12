Imports System.Data.SqlClient
Public Class ListaAtencion
    Public Property codigoAtencion As Integer
    Public Property nombre As String
    Public Property eps As String
    Public Property fechaAdmision As DateTime
    Public Property consultaPendiente As String
    Public Property dsLista As New DataSet
    Public Property accion As Integer
    Public Property titulo As String

    Sub New()
        titulo = "LISTA DE TAREAS PENDIENTE: HEMODINAMIA"
    End Sub

    Public Overridable Sub cargarMenu()
        consultaPendiente = Consultas.LISTA_ATENCION
        ListaAtencionDAL.cargarMenuPadres(Me)
    End Sub

    Public Function verificarDocumentos() As DataTable
        Dim list As New List(Of String)
        Dim dtLista As New DataTable
        list.Add(codigoAtencion)
        list.Add(Constantes.CARGARHIJOS)
        General.llenarTabla(Consultas.VERIFICAR_DOCUMENTOS, list, dtLista)
        Return dtLista
    End Function
    Public Sub cargarPaciente()
        Dim dt As New DataTable
        Dim list As New List(Of String)
        list.Add(codigoAtencion)
        General.llenarTabla(Consultas.LISTA_PACIENTE_CHEQUEO, list, dt)
        If dt.Rows.Count > 0 Then
            nombre = dt.Rows(0).Item("paciente")
            eps = dt.Rows(0).Item("eps")
            fechaAdmision = dt.Rows(0).Item("fecha_admision")
        End If
    End Sub
End Class
