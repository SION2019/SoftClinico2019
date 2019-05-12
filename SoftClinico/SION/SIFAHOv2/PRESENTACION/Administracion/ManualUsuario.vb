Public Class ManualUsuario
    Dim manual As New ManualUsuarioDAL
    Private Sub ManualUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.DataSource = Nothing

        ComboBox1.DataSource = manual.Cargar_opciones
        ComboBox1.DisplayMember = "Descripcion_Menu"
        ComboBox1.ValueMember = "Codigo_Menu"
        ComboBox1.SelectedIndex = 0
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim nmbres() As String
            Dim rutas() As String
            With Buscar_imagen
                .FileName = ""
                .InitialDirectory = ""
                .Filter = "Todos los archivos PDF|*.pdf"
                .Title = "Seleccionar pdf" + ""
                .Multiselect = False
            End With

            If Buscar_imagen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    rutas = Buscar_imagen.FileNames.ToArray
                    nmbres = Buscar_imagen.SafeFileNames.ToArray
                    Dim archivos As String = ""
                    If manual.subir(rutas(0), ComboBox1.SelectedValue.ToString.Trim) = True Then
                        TextBox1.Text = nmbres(0).ToString
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    End If

                Catch
                End Try
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ""
        If ComboBox1.SelectedIndex <> 0 Then
            TextBox1.Text = manual.cargar_manual(ComboBox1.SelectedValue.ToString.Trim)
        End If

    End Sub

    Private Sub ManualUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
End Class