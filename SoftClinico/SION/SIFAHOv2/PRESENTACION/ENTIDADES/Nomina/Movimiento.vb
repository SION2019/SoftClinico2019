Public Class Movimiento
    Property Fecha As Date
    Property Cuota As Integer
    Property Dias As Integer
    Property Abono As Decimal
    Property Total As Decimal
    Property ValorCuota As Decimal
    Property Saldo As Decimal
    Property Nomina As String
    Property InteresAbono As Decimal

    Sub New()
        Cuota = 1
        Nomina = "Aún No Pago"
    End Sub

    Function setDiasPrimeraCuota(pFechaNomina As Date, pFechaDeduccion As Date) As Boolean

        Dias = Exec.TotalDiasMes(pFechaDeduccion) - pFechaDeduccion.Day + 1

        If (Dias > 30) OrElse (pFechaNomina.ToString("yyyyMM") <> pFechaDeduccion.ToString("yyyyMM")) Then
            Dias = 30
            Return True
        End If

        Return False
    End Function


    Function getInteresAbono(pNumtasainteres As Decimal, pAplicaBase As Boolean) As Decimal

        If pAplicaBase Then
            InteresAbono = Total * (pNumtasainteres / 100)
        Else
            InteresAbono = (Saldo * (pNumtasainteres / 100))
        End If

        InteresAbono = (InteresAbono * (Dias / 30))

        Return InteresAbono

    End Function

    Function setDetipoNoprestamo() As Decimal

        Abono = Total
        InteresAbono = 0

        Return 0

    End Function


    Function setAbonoConValidesdeSaldoInferior() As Boolean

        If (Saldo < Abono) Then

            Abono = Saldo

            Return True
        End If


        Return False

    End Function


    Function getTotalCuota() As Decimal

        ValorCuota = (Abono + InteresAbono)
        Return ValorCuota

    End Function

    Function setSaldoConValidesdelAbono() As Boolean

        If (Abono = 0) Then
            Saldo = 0
            Return False
        Else
            Saldo -= Abono
            Return True
        End If

    End Function


    Function setFechaMasUnmes(pfecha As Date) As Boolean

        Fecha = pfecha.AddMonths(1)
        Return True
    End Function




End Class
