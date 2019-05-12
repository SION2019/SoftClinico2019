Public Class EquivalenciaInventario
    Public Property codigopos As String
    Public Property descripcion As String
    Public Property grupo As Integer
    Public Property rboption As String
    Public Property linea As Integer
    Public Property comboprese As Integer
    Public Property descripcionpro As String
    Public Property Checkdislvente As Boolean
    Public Property Numconce As Double
    Public Property combonum As Integer
    Public Property Checkaplica As Boolean
    Public Property Numerictempmin As Double
    Public Property Numeritemmax As Double
    Public Property combotemconse As Integer
    Public Property Combotemconsemax As Integer
    Public Property duracion As Integer
    Public Property duracionmax As Integer
    Public Property osmolalidad As Double
    Public Property Checkmespecial As Boolean
    Public Property Combocualidad As Integer
    Public Property Checkestirilizacion As Boolean
    Public Property Checkenfermeria As Boolean
    Public Property usuario As Integer
    Public Property codigoint As String
    Public Property Comboriesgo As Integer
    Public Property Checkmezcla As Boolean
    Public Property Checkfisio As Boolean
    Public Property dsDatos As New DataSet

    Public Sub guardarEquivalencia()
        EquivalenciaDAL.GuardarEquivalencia(Me, dsDatos.Tables("Vias_Equi"))
    End Sub

    Public Sub CreaOpciones(codigo As String, ByRef arbol As TreeView, ByRef ds As DataSet)
        Dim cadena As String

        cadena = "EXEC SP_VIASADMINISTRATIVA_BUSCAR ''"
        Try
            Using consulta = New SqlCommand(cadena, FormPrincipal.cnxion)
                Using daAdaptador = New SqlDataAdapter(consulta)
                    daAdaptador.Fill(ds, "Vias")
                End Using
            End Using
            If codigo = "" Then
                codigo = -1
            End If
            cadena = "EXEC [SP_VIAS_ADMON_EQUIVALENCIA] " & codigo & ""

            Using consulta = New SqlCommand(cadena, FormPrincipal.cnxion)
                Using daAdaptador = New SqlDataAdapter(consulta)
                    daAdaptador.Fill(ds, "Vias_Equi")
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        arbol.Nodes.Clear()
        arbol.ExpandAll()

        Dim aDrFilas As DataRow()
        aDrFilas = ds.Tables("Vias").Select("[Codigo via] > -1", "[Codigo Via]")
        For Each drFila As DataRow In aDrFilas
            Dim nodo As New System.Windows.Forms.TreeNode
            nodo.Name = drFila("Codigo Via").ToString()
            nodo.Text = drFila("Nombre").ToString()

            If ds.Tables("Vias_Equi").Select("[Codigo_Via]='" + nodo.Name.ToString + "'").Count = 1 Then
                nodo.Checked = True
            Else
                nodo.Checked = False
            End If

            arbol.Nodes.Add(nodo)
        Next

    End Sub

End Class
