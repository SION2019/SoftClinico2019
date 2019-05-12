Public Class FormListaAtencion
    Dim objLista As New ListaAtencion
    Private Sub FormListaAtencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Label1.Text = objLista.titulo

        cargarListaChequeo()
    End Sub

    Private Sub FormListaAtencion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub


    Public Sub registro(ByRef pObjLista As ListaAtencion, ByVal codigoAtencion As Integer, ByVal nombre As String, ByVal fecha As Date, ByVal eps As String)
        txtregistro.Text = codigoAtencion
        txtpaciente.Text = nombre
        txtfecha.Text = fecha
        txteps.Text = eps
        objLista = pObjLista
        objLista.dsLista.Reset()
    End Sub
    Public Sub cargarListaChequeo()
        Try
            cargarArbolPUC()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub cargarArbolPUC()

        Dim nodo As TreeNode
        Dim drCuentaPadre As DataRow()

        arbolcheck.Enabled = True
        arbolcheck.Nodes.Clear()
        arbolcheck.ExpandAll()

        Try

            objLista.cargarMenu()
            drCuentaPadre = objLista.dsLista.Tables("Table").Select()

            'Se recorren las cuentas Padre
            For Each drFila As DataRow In drCuentaPadre
                nodo = New TreeNode
                nodo.Name = drFila("Codigo").ToString()
                nodo.Text = drFila("Descripcion").ToString()

                arbolcheck.Nodes.Add(nodo)
                arbolcheck.Nodes(arbolcheck.Nodes.Count - 1).NodeFont = New Font("Arial", 7.5, FontStyle.Bold)

                'Se recorren las cuentas hijas
                crearSubcuentas(nodo)
            Next
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        objLista.dsLista.Dispose()
    End Sub

    Private Sub crearSubcuentas(ByRef nodoPade As TreeNode)
        Dim expr As String = "codigopadre ='" & nodoPade.Name & "'"
        Dim subnodo As TreeNode

        Try
            Dim aDrFilas As DataRow()
            aDrFilas = objLista.dsLista.Tables("Table1").Select(expr, "Codigo")

            For Each drFila As DataRow In aDrFilas
                subnodo = New TreeNode
                subnodo.Name = drFila("Codigo").ToString()
                subnodo.Text = drFila("mensage").ToString()
                nodoPade.Nodes.Add(subnodo)
                If drFila("descripcion") = "" Then
                    nodoPade.Nodes(nodoPade.Nodes.Count - 1).NodeFont = New Font("Arial", 8, FontStyle.Bold)
                End If
                If drFila("indice") = 1 Then
                    nodoPade.Nodes(nodoPade.Nodes.Count - 1).ForeColor = Color.SeaGreen
                Else
                    nodoPade.Nodes(nodoPade.Nodes.Count - 1).ForeColor = Color.Red
                End If
                crearSubcuentas(subnodo)
            Next
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

End Class