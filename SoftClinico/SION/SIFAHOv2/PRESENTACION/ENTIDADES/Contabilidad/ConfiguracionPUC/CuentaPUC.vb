Public Class CuentaPUC
    'Atributos
    Private codigoPUC As Integer
    Private codigo As String
    Private descripcion As String
    Private clasificacion As String
    Private tipo As String
    Private naturaleza As String
    Private nivel As Integer
    Private cuentaPadre As String
    Private visible As Boolean

    'Constructor
    Public Sub New()

    End Sub

    Public Sub New(drCuentaPUC As DataRow)
        codigoPUC = drCuentaPUC.Item("codigo_puc").ToString
        codigo = drCuentaPUC.Item("codigo_cuenta").ToString
        descripcion = drCuentaPUC.Item("nombre").ToString
        clasificacion = drCuentaPUC.Item("clasificacion").ToString
        tipo = drCuentaPUC.Item("tipo").ToString
        naturaleza = drCuentaPUC.Item("naturaleza").ToString
        nivel = drCuentaPUC.Item("nivel").ToString
        cuentaPadre = drCuentaPUC.Item("padre").ToString
        visible = drCuentaPUC.Item("visible").ToString
    End Sub

    Public Function getCodigoPUC() As Integer
        Return codigoPUC
    End Function

    Public Sub setCodigoPUC(pCodigoPUC As Integer)
        codigoPUC = pCodigoPUC
    End Sub

    Public Function getCodigo() As String
        Return codigo
    End Function

    Public Sub setCodigo(pCodigo As String)
        codigo = pCodigo
    End Sub

    Public Function getDescripcion() As String
        Return descripcion
    End Function

    Public Sub setDescripcion(pDescripcion As String)
        descripcion = pDescripcion
    End Sub

    Public Function getClasificacion() As String
        Return clasificacion
    End Function

    Public Sub setClasifiacion(pClasificacion As String)
        clasificacion = pClasificacion
    End Sub

    Public Function getTipo() As String
        Return tipo
    End Function

    Public Sub setTipo(pTipo As String)
        tipo = pTipo
    End Sub

    Public Function getNaturaleza() As String
        Return naturaleza
    End Function

    Public Sub setNaturalea(pNaturaleza As String)
        naturaleza = pNaturaleza
    End Sub

    Public Function getNivel() As Integer
        Return nivel
    End Function

    Public Sub setNivel(pNivel As Integer)
        nivel = pNivel
    End Sub

    Public Function getCuentaPadre() As String
        Return cuentaPadre
    End Function

    Public Sub setCuentaPadre(pCuentaPadre As String)
        cuentaPadre = pCuentaPadre
    End Sub

    Public Function getVisible() As Boolean
        Return visible
    End Function

    Public Sub setVisible(pVisible As Boolean)
        visible = pVisible
    End Sub
End Class
