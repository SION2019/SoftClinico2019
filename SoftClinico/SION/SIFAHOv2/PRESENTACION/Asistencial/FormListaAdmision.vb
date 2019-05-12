Public Class FormListaAdmision
    Dim objLista As New ListaCheck
    Dim nRegistro As Integer

    Private Sub FormListaAdmision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarPaciente()
        cargarArbolPUC()
    End Sub

    Public Sub cargarRegistro(ByVal registro As String)
        nRegistro = registro
    End Sub

    Public Sub cargarPaciente()
        objLista.registro = nRegistro
        objLista.cargarPaciente()
        txtnombre.Text = objLista.nombre
        txtCodigo.Text = objLista.registro
    End Sub
    Public Sub cargarArbolPUC()
        Dim nodo As TreeNode
        Dim drCuentaPadre As DataRow()

        arbolcheck.Enabled = True
        arbolcheck.Nodes.Clear()
        arbolcheck.ExpandAll()

        Try
            objLista.registro = nRegistro
            objLista.cargarDocumentos()
            drCuentaPadre = objLista.dsLista.Tables("Padre").Select()

            'Se recorren las cuentas Padre
            For Each drFila As DataRow In drCuentaPadre
                nodo = New TreeNode
                nodo.Name = drFila("Codigo").ToString()
                nodo.Text = drFila("Descripcion").ToString()

                arbolcheck.Nodes.Add(nodo)
                arbolcheck.Nodes(arbolcheck.Nodes.Count - 1).NodeFont = New Font("Arial", 9, FontStyle.Bold)

                'Se recorren las cuentas hijas
                crearSubcuentas(nodo)
            Next
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
        objLista.dsLista.Dispose()
    End Sub

    Private Sub crearSubcuentas(ByRef nodoPade As TreeNode)
        Dim expr As String = "codigopadre ='" & nodoPade.Name & "'"
        Dim subnodo As TreeNode

        Try
            Dim aDrFilas As DataRow()
            aDrFilas = objLista.dsLista.Tables("Hijos").Select(expr, "Codigo")

            For Each drFila As DataRow In aDrFilas
                subnodo = New TreeNode
                subnodo.Name = drFila("Codigo").ToString()
                subnodo.Text = drFila("mensaje").ToString()
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
            general.manejoErrores(ex) 
        End Try
    End Sub

End Class