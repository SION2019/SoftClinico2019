Public Class Convencion

    Property Codigo As String
    Property Nombre As String
    Property Simbolo As String
    Property Argcolor As Integer
    Property Entrar As Date
    Property stMinutos As Integer
    Property Descansar As Date
    Property dMinutos As Integer

    Sub New()
    End Sub

    Sub New(pDwconvencion As DataRow)
        Codigo = pDwconvencion("Codigo_convencion").ToString
        Nombre = pDwconvencion("Nombre").ToString
        Simbolo = pDwconvencion("Simbolo").ToString
        Argcolor = pDwconvencion("Simbolo_Color")
        Entrar = pDwconvencion("Hora_Entrada").ToString
        stMinutos = pDwconvencion("Minutos")
        dMinutos = pDwconvencion("MinutosDescanso")
        If dMinutos > 0 Then Descansar = pDwconvencion("Hora_Descanso").ToString
    End Sub

End Class
