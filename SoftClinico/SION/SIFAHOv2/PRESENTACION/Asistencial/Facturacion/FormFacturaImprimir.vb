Imports System.Threading
Public Class FormFacturaImprimir
    Dim objLista As ListaCheck
    Dim arbolito As New TreeView
    Private Sub FormFacturaImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Label1.Text = objLista.titulo
        cargarPaciente()
        cargarListaChequeo()
    End Sub
    Public Sub cargarListaChequeo()
        Try
            'Dim arbolListaCuequeo As Thread

            'arbolListaCuequeo = New Thread(AddressOf cargarArbolPUC)
            'arbolListaCuequeo.Name = "Cargar Lista de Chequeo"

            'arbolListaCuequeo.SetApartmentState(ApartmentState.STA)
            'arbolListaCuequeo.Start()
            cargarArbolPUC()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub cargarPaciente()
        objLista.cargarPaciente()
        txtpaciente.Text = objLista.nombre
        txteps.Text = objLista.eps
        txtfecha.Text = objLista.fechaAdmision
        txtregistro.Text = objLista.registro
    End Sub

    Public Sub registro(ByRef pObjLista As ListaCheck)
        objLista = pObjLista
        objLista.dsLista.Reset()
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
                nodo.Name = drFila("CodigoTitulo").ToString()
                nodo.Text = drFila("Descripcion").ToString()

                arbolcheck.Nodes.Add(nodo)
                arbolcheck.Nodes(arbolcheck.Nodes.Count - 1).NodeFont = New Font("Arial", 8, FontStyle.Bold)

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
            aDrFilas = objLista.dsLista.Tables("Table1").Select(expr, "CodigoTitulo")

            For Each drFila As DataRow In aDrFilas
                subnodo = New TreeNode
                subnodo.Name = drFila("CodigoTitulo").ToString()
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

    Private Sub arbolcheck_DoubleClick(sender As Object, e As EventArgs) Handles arbolcheck.DoubleClick

    End Sub
End Class