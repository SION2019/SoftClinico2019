Public Class RecorteImagen
    Private StartPoint As New Point(0, 0)

    Private Loc As New Point(0, 0)

    Public Shared Function capturarPantalla(ParentForm As Form) As Image
        If ParentForm.Name = "FormNotaAuditoria" Then
            ParentForm.Hide()
        End If
        System.Threading.Thread.Sleep(500)

        Dim R As New Rectangle(0, 0, 0, 0)
        For Each Screen As System.Windows.Forms.Screen In Screen.AllScreens
            R = Rectangle.Union(R, Screen.Bounds)
        Next

        Dim resultado As Bitmap = Nothing
        Dim Image As New Bitmap(R.Width, R.Height)
        Using G As Graphics = Graphics.FromImage(Image)
            G.CopyFromScreen(R.Left, R.Top, 0, 0, R.Size, CopyPixelOperation.SourceCopy)
        End Using
        Using recorte As New RecorteImagen
            recorte.DoubleBuffered = True
            recorte.Cursor = Cursors.Cross
            recorte.Location = R.Location
            recorte.Size = R.Size
            recorte.BackgroundImage = Image
            If recorte.ShowDialog(ParentForm) = Windows.Forms.DialogResult.OK Then
                resultado = New Bitmap(recorte.recortarArea.Width, recorte.recortarArea.Height)
                Using G As Graphics = Graphics.FromImage(resultado)
                    G.DrawImage(Image, 0, 0, recorte.recortarArea, GraphicsUnit.Pixel)
                End Using
            End If
        End Using
        If ParentForm.Name = "FormNotaAuditoria" Then
            ParentForm.Show()
        End If
        Return resultado
    End Function

    Private Sub New()
        InitializeComponent()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button <> Windows.Forms.MouseButtons.Left Then Return
        Me.StartPoint = e.Location
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If e.Button <> Windows.Forms.MouseButtons.Left Then Return
        Me.Loc = e.Location
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If e.Button <> Windows.Forms.MouseButtons.Left Then Return
        If Me.recortarArea.Height < 5 AndAlso Me.recortarArea.Width < 5 Then Return
        If Me.recortarArea.Height <= 1 OrElse Me.recortarArea.Width <= 1 Then Return
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim RG As New Region(New Rectangle(0, 0, Me.Width, Me.Height))
        If MouseButtons And Windows.Forms.MouseButtons.Left = Windows.Forms.MouseButtons.Left Then
            RG.Exclude(Me.recortarArea)
            e.Graphics.DrawRectangle(Pens.Black, Me.recortarArea)
        End If
        Using brush As New SolidBrush(Color.FromArgb(128, 255, 255, 255))
            e.Graphics.FillRegion(brush, RG)
        End Using
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then Me.Close()
        Return False
    End Function


    Protected Overrides Sub OnLostFocus(e As EventArgs)
        Me.Close()
    End Sub

    Private ReadOnly Property recortarArea As Rectangle
        Get
            Return New Rectangle(Math.Min(Me.StartPoint.X, Me.Loc.X), Math.Min(Me.StartPoint.Y, Me.Loc.Y),
                         Math.Abs(Me.StartPoint.X - Me.Loc.X), Math.Abs(Me.StartPoint.Y - Me.Loc.Y))
        End Get
    End Property


End Class