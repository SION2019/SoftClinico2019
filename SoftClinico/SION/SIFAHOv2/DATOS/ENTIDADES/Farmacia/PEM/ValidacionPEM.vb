Public Class ValidacionPEM
    Public Property tabla As DataTable
    Public Property dgv As DataGridView
    Public Property Dosis As String
    Public Property velocidad As String
    Public Property cantidadDisolvente As String
    Public Property focoDosis As String
    Public Property focoVelocidad As String
    Public Property focoCantidadDisolvente As String
    Public Property focoEscogerDisolvente As String
    Public Property nombreEtiqueta As String
    Public Property parametros As List(Of Object)
    Sub New()
        tabla = New DataTable
        parametros = New List(Of Object)

    End Sub
    Public Function verificarDgvInfImp(ByVal tabla As DataTable,
                                       ByRef dgv As DataGridView,
                                       ByVal Dosis As String,
                                       ByVal velocidad As String,
                                       ByVal cantidaddisolvente As String,
                                       ByVal focoDosis As String,
                                       ByVal focoVelocidad As String,
                                       ByVal focoCantidadDisolvente As String,
                                       ByVal focoEscogerDisolvente As String,
                                       ByVal nombreEtiqueta As String) As List(Of Object)
        parametros.Clear()

        Dim filasMed As DataRowCollection = tabla.Rows
        Dim totalFilas = filasMed.Count - 1

        For indiceFilaActual = 0 To totalFilas
            If filasMed(indiceFilaActual).Item(Dosis) <= 0 Then
                parametros.Add("colocar la concentracion de la dosis de la " & nombreEtiqueta & "!")
                parametros.Add(False)
                celdaFocoSeleccionada(dgv, focoDosis, indiceFilaActual)
            ElseIf filasMed(indiceFilaActual).Item(velocidad) = 0 Then
                parametros.Add("Colocar la velocidad de la " & nombreEtiqueta & " que establecera pare el medicamento!")
                parametros.Add(False)
                celdaFocoSeleccionada(dgv, focoVelocidad, indiceFilaActual)
            ElseIf filasMed(indiceFilaActual).Item("Producto_Disolvente") > 0 AndAlso filasMed(indiceFilaActual).Item(cantidaddisolvente) = 0 Then
                parametros.Add("Colocar la cantidad del disolvente de la " & nombreEtiqueta & "!")
                parametros.Add(False)
                celdaFocoSeleccionada(dgv, focoCantidadDisolvente, indiceFilaActual)
            ElseIf filasMed(indiceFilaActual).Item("Aplica_disolvente").ToString = "True" And filasMed(indiceFilaActual).Item("Producto_Disolvente") = -1 Then
                parametros.Add("Debe escger el disolvente!")
                parametros.Add(False)
                celdaFocoSeleccionada(dgv, focoEscogerDisolvente, indiceFilaActual)
            End If
        Next
        Return parametros
    End Function
    Sub celdaFocoSeleccionada(dgv As DataGridView, ByVal nombreColumnaFoco As String, Optional filaActual As Integer = Nothing)
        Dim filaFoco As Integer = If(Not IsNothing(filaActual), filaActual, dgv.CurrentRow.Index)
        dgv.CurrentCell = dgv(nombreColumnaFoco, filaFoco)
    End Sub
End Class

