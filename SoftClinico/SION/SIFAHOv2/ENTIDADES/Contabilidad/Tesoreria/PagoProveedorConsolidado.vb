Public Class PagoProveedorConsolidado
    Public Property numFacturas As Integer
    Public Property numProveedores As Integer
    Public Property totalFacturas As Double
    Public Property totalAbono As Double
    Public ReadOnly Property totalDiferencia As Double
        Get
            Return totalFacturas - totalAbono
        End Get
    End Property


    Sub New()
        numFacturas = 0
        numProveedores = 0
        totalFacturas = 0
        totalAbono = 0
    End Sub




End Class
