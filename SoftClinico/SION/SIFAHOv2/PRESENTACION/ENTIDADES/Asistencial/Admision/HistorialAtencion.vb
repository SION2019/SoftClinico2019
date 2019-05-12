Public Class HistorialAtencion
    Private fechaInic As Date
    Private fechaFin As Date
    Private busqueda As String

    Sub New()

    End Sub

    Public Property setGetFechaIni As Date
        Get
            Return fechaInic
        End Get
        Set(value As Date)
            value = Format(CDate(value), "yyyy-MM-dd")
            fechaInic = value
        End Set
    End Property

    Public Property setGetFechaFin As Date
        Get
            Return fechaFin
        End Get
        Set(value As Date)
            value = Format(CDate(value), "yyyy-MM-dd")
            fechaFin = value
        End Set
    End Property
    Public Property setGetBusqueda As String
        Get
            Return busqueda
        End Get
        Set(value As String)
            value = If(value = String.Empty, Nothing, value)
            busqueda = value
        End Set
    End Property

    Public Sub seleccionarNodos(nodo As TreeView)
        For i = 1 To nodo.Nodes.Count - 1
            nodo.Nodes(i).Checked = True
        Next
    End Sub

    Public Sub ocultarColumnas(nodo As TreeView, grilla As DataGridView)
        For i = 0 To nodo.Nodes.Count - 1
            grilla.Columns(nodo.Nodes(i).Text.ToString).Visible = nodo.Nodes(i).Checked
        Next
    End Sub
End Class
