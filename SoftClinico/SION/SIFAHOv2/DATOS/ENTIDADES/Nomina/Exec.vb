Class Exec
#Region "Nomina"
    Public Shared Function getStrFiltro4EnlceDta(pStrColm2Array As String, pTxtBuscar As String, Optional pSeparador As String = ",") As String

        ' ejemple una cadena de entrada valida:  nombre, Apelido ,[Razon_Social]
        Dim vColmArray = pStrColm2Array.Split(pSeparador).ToList()
        Dim rtrnr As String = preFmtFlt(vColmArray.First)

        vColmArray.RemoveAt(0)

        For Each columna In vColmArray
            rtrnr &= " OR " & preFmtFlt(columna)

        Next

        rtrnr = String.Format(rtrnr, pTxtBuscar.Trim)

        Return rtrnr

    End Function
    Public Shared Function preFmtFlt(pInPut As String) As String

        pInPut = pInPut.Trim.TrimStart("[").TrimEnd("]").Trim

        pInPut = String.Format("' '+[{1}] LIKE '% {0}%'", "{0}", pInPut)

        Return pInPut
    End Function
    Public Shared Function primerDiaMes(ByRef pInPut As Object) As Date
        Dim vOutput As Date = FechaValida(pInPut)

        Return vOutput.AddDays(1 - vOutput.Day)
    End Function
    Public Shared Function ultimoDiaMes(ByRef pInPut As Object) As Date
        Dim vOutput As Date = FechaValida(pInPut)

        Return New DateTime(vOutput.Year, vOutput.Month, TotalDiasMes(vOutput))
    End Function
    Public Shared Function TotalDiasMes(ByRef pInPut As Object) As Integer
        Dim vOutput As Date = FechaValida(pInPut)

        Return DateTime.DaysInMonth(vOutput.Year, vOutput.Month)
    End Function
    Public Shared Function FechaValida(ByRef pInPut As Object) As Date
        Dim vRet As Date

        If TypeOf pInPut Is Date Then
            vRet = pInPut
        ElseIf TypeOf pInPut Is DateTimePicker Then
            vRet = pInPut.Value
        Else
            vRet = CDate(pInPut)
        End If

        Return vRet.Date
    End Function
    Public Shared Function varcharDate(pInPut As String) As Date
        Dim vFormat As String = "yyyyMMdd"

        Return DateTime.ParseExact(pInPut, vFormat, Nothing)
    End Function
    Public Shared Function varcharDteTime(pInPut As String) As Date
        Dim vFormat As String = "yyyyMMdd HH:mm:ss"

        Return DateTime.ParseExact(pInPut, vFormat, Nothing)
    End Function
    Public Shared Function ToDbl(pInPut As Object) As Double
        Return If(IsNumeric(pInPut), pInPut, 0)
    End Function
    Public Shared Sub buscarConOculrEx(pConsultaSQL As String, pMetodo As General.cargaInfoForm, pTitulo As String, Optional pOcultaCol As List(Of String) = Nothing)
        Dim vForm As New Frm_BusquedaGeneral()
        vForm.Text = pTitulo
        vForm.ocultaEsto = pOcultaCol
        vForm.consulta = pConsultaSQL
        vForm.metodoCarga = pMetodo
        vForm.isOcultaCol = False
        vForm.ShowDialog()
    End Sub
    Public Shared Function getReport(pReporte As Object, pFormula As String, pArea As String, Optional ext As String = ".pdf") As Boolean
        Return Funciones.getReporteNoFTP(pReporte, pFormula, pArea, ext)
    End Function
    Public Shared Sub SavingMsg(pMsg As String, pControl As Control)
        SavingMsg(pMsg)
        GetFocus(pControl)
        SacudirCrtl(pControl)
    End Sub
    Public Shared Sub SavingMsg(pMsg As String)
        MsgBox(pMsg, MsgBoxStyle.Exclamation)
    End Sub
    Public Shared Sub GetFocus(control As Control)
        Dim crtlParent As Object = control.Parent
        If crtlParent IsNot Nothing Then
            If TypeOf control Is TabPage Then
                crtlParent.SelectedTab = control
            End If
            GetFocus(crtlParent)
        End If
        control.Focus()
    End Sub
    Public Shared Sub SacudirCrtl(control As Control)
        Task.Factory.StartNew(Sub() SacudirCrtl(control, control.Location))
    End Sub
    Private Shared Sub SacudirCrtl(control As Control, crtlLoc As Point, Optional sacudida As Integer = 0)
        While (sacudida < 10)
            sacudida += 1
            control.BeginInvoke(Sub() If (sacudida Mod 2) _
                                      Then control.Location = New Point(crtlLoc.X - 2, crtlLoc.Y) _
                                      Else control.Location = New Point(crtlLoc.X + 2, crtlLoc.Y))
            Threading.Thread.Sleep(80)
        End While
        control.BeginInvoke(Sub() control.Location = New Point(crtlLoc.X, crtlLoc.Y))
    End Sub
    Public Shared Function IsInaccesible(control As Control) As Boolean
        If (control.Visible = False OrElse control.Enabled = False OrElse IsReadOnly(control)) Then
            Return True
        Else
            Dim crtlParent = control.Parent
            If (crtlParent IsNot Nothing) Then Return IsInaccesible(crtlParent)
        End If
        Return False
    End Function
    Public Shared Function IsReadOnly(control) As Boolean
        Return (Not IsNothing(control.GetType.GetProperty("ReadOnly")) AndAlso control.ReadOnly)
    End Function
#End Region
End Class
