Public Class FormConfigurarPDoc
    Dim objPlataforma As PlataformaDoc
    Dim FormPlataformaDocumenta As New FormPlataformaDocumental
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedValue = -1 And CheckBox1.Checked = 0 Then
            With OpdBuscarPDF
                .InitialDirectory = ""
                .Filter = "Todos los archivos de PDF|*.pdf|Archivos de word|*.doc|Archivos de word|*.docx"
                .Title = "Seleccionar Solo archivos PDF"
            End With
            If OpdBuscarPDF.ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtUbicacion.Clear()
                TxtNomArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(OpdBuscarPDF.FileName)
                Me.TxtUbicacion.Text = OpdBuscarPDF.FileName
                Me.ComboBox1.Enabled = False
                Me.CheckBox1.Enabled = False
            End If
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormConfigurarPDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPlataforma = New PlataformaDoc
        General.cargarCombo(Consultas.CATEGORIA_BUSCAR, "Nombre", "Código", ComboBox1)
        objPlataforma.BdAceptar = 1
    End Sub

    Private Sub btaceptar_Click(sender As Object, e As EventArgs) Handles btaceptar.Click
        If objPlataforma.BdAceptar = 0 Then
            objPlataforma.NomCategoria = TxtCategoria.Text
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    PlataformaDocBLL.guardarPlataformaDocDesc(objPlataforma)
                    If objPlataforma.BdAceptar <> 3 Then
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    general.manejoErrores(ex) 
                End Try
            End If
        Else
            If ComboBox1.SelectedValue <> -1 Or TxtUbicacion.Text <> "Cargar PDF" Then
                If ComboBox1.SelectedValue <> -1 Then
                    CheckBox1.Checked = True
                End If
                'objPlataforma.NodoHijo = ComboBox1.Text
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Close()
            Else
                MsgBox("Elija una Categoria o un PDF", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub CategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriaToolStripMenuItem.Click
        Me.ComboBox1.Visible = False
        Me.CheckBox1.Visible = False
        Me.TxtUbicacion.Visible = False
        Me.Button1.Visible = False
        Me.TxtCategoria.Visible = True
        Me.TxtCategoria.Top = 101
        Me.TxtCategoria.Left = 12
        Me.btaceptar.Top = 181
        Me.btsalir.Top = 181
        objPlataforma.BdAceptar = 0
    End Sub

    Private Sub PDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToolStripMenuItem.Click
        Me.TxtCategoria.Visible = False
        Me.ComboBox1.Visible = True
        Me.CheckBox1.Visible = True
        Me.TxtUbicacion.Visible = True
        Me.Button1.Visible = True
        Me.btaceptar.Top = 215
        Me.btsalir.Top = 215
        objPlataforma.BdAceptar = 1
        General.cargarCombo(Consultas.CATEGORIA_BUSCAR, "Nombre", "Código", ComboBox1)
    End Sub
End Class