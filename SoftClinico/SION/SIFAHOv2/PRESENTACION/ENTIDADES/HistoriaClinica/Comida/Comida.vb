Public Class Comida
    Private codigoComida As Integer
    Private nombreComida As String
    Private costo As Double
    Private puntoComida As Integer
    Sub New()

    End Sub
    Public Property SetGetPuntoComida As Integer
        Get
            Return puntoComida
        End Get
        Set(value As Integer)
            puntoComida = value
        End Set
    End Property
    Public Property SetGetCodigoComida As Integer
        Get
            Return codigoComida
        End Get
        Set(value As Integer)
            codigoComida = value
        End Set
    End Property

    Public Property SetGetNombreComida As String
        Get
            Return nombreComida
        End Get
        Set(value As String)
            nombreComida = value
        End Set
    End Property

    Public Property SetGetCosto As Double
        Get
            Return costo
        End Get
        Set(value As Double)
            costo = value
        End Set
    End Property

End Class
