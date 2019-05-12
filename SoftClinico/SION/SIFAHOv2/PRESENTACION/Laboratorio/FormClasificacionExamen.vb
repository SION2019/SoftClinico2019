Public Class FormClasificacionExamen
    Private objExamen As New ClasificacionExamen
    Private Sub FormClasificacionExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvExamen
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Código examen"
            .Columns("Codigo").Width = 90
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripción"
            .Columns("Descripcion").Width = 685
            .Columns("Laboratorio").ReadOnly = True
            .Columns("Laboratorio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Laboratorio").DataPropertyName = "Laboratorio"

        End With
        dgvExamen.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        cargarExamenes()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormClasificacionExamen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Public Sub cargarExamenes()
        objExamen.cargarExamen()
        dgvExamen.DataSource = objExamen.dtExamen
        dgvExamen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExamen.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub


    Private Sub BtSalirlOTES_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        Panel2.Visible = False
    End Sub

    Private Sub dgvExamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellClick
        If e.ColumnIndex = 2 Then
            Panel2.Visible = True
            objExamen.codigoExamen = dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells(0).Value
            If Panel2.Visible = True Then
                objExamen.arbol = arbolmenu
                objExamen.cargarArbol()
                objExamen.cargarArbolCheck()
            End If
        End If
    End Sub


    Private Sub arbolmenu_Click(sender As Object, e As EventArgs) Handles arbolmenu.Click
        Try
            If Panel2.Visible = True Then
                For i = 0 To arbolmenu.Nodes.Count - 1
                    If arbolmenu.Nodes(i).Checked = True Then
                        objExamen.codigoProveedor = arbolmenu.Nodes(i).Name
                        objExamen.guardar()
                    Else
                        objExamen.codigoProveedor = arbolmenu.Nodes(i).Name
                        Dim params As New List(Of String)
                        params.Add(objExamen.codigoExamen)
                        params.Add(objExamen.codigoProveedor)
                        General.ejecutarSQL(Consultas.ANULAR_CLASIFICACION_EXAMEN, params)
                    End If
                Next
                objExamen.codigoProveedor = Nothing
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub txtbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        objExamen.busqueda = Funciones.validarComillaSimple(txtbusqueda.Text)
        objExamen.cargarExamen()
    End Sub
End Class