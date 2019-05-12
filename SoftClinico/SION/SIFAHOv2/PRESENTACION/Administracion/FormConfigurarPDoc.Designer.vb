<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfigurarPDoc
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfigurarPDoc))
        Me.OpdBuscarPDF = New System.Windows.Forms.OpenFileDialog()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btaceptar = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TxtNomArchivo = New System.Windows.Forms.TextBox()
        Me.TxtCategoria = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InsertarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpdBuscarPDF
        '
        Me.OpdBuscarPDF.FileName = "OpenFileDialog1"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"GUIAS NEONATAL", "GUIAS UCI ADULTO", "GUIAS HEMODINAMIA"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 101)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(260, 21)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "----SELECCIONE----"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(228, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "...."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Enabled = False
        Me.TxtUbicacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtUbicacion.Location = New System.Drawing.Point(11, 182)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(205, 20)
        Me.TxtUbicacion.TabIndex = 2
        Me.TxtUbicacion.Text = "Cargar PDF"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Documents_icon2
        Me.PictureBox1.Location = New System.Drawing.Point(12, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(70, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 16)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "CONFIGURAR DOCUMENTOS"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 20)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "CATEGORIA"
        '
        'btsalir
        '
        Me.btsalir.BackColor = System.Drawing.Color.White
        Me.btsalir.BackgroundImage = CType(resources.GetObject("btsalir.BackgroundImage"), System.Drawing.Image)
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btsalir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsalir.ForeColor = System.Drawing.Color.DimGray
        Me.btsalir.Location = New System.Drawing.Point(186, 215)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(30, 34)
        Me.btsalir.TabIndex = 44
        Me.btsalir.Text = "X"
        Me.btsalir.UseVisualStyleBackColor = False
        '
        'btaceptar
        '
        Me.btaceptar.BackColor = System.Drawing.Color.ForestGreen
        Me.btaceptar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btaceptar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btaceptar.Location = New System.Drawing.Point(73, 215)
        Me.btaceptar.Name = "btaceptar"
        Me.btaceptar.Size = New System.Drawing.Size(89, 34)
        Me.btaceptar.TabIndex = 42
        Me.btaceptar.Text = "Aceptar"
        Me.btaceptar.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(11, 159)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(102, 19)
        Me.CheckBox1.TabIndex = 45
        Me.CheckBox1.Text = "SUBCATEGORIA"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TxtNomArchivo
        '
        Me.TxtNomArchivo.Location = New System.Drawing.Point(11, 208)
        Me.TxtNomArchivo.Name = "TxtNomArchivo"
        Me.TxtNomArchivo.Size = New System.Drawing.Size(100, 20)
        Me.TxtNomArchivo.TabIndex = 46
        Me.TxtNomArchivo.Visible = False
        '
        'TxtCategoria
        '
        Me.TxtCategoria.Location = New System.Drawing.Point(13, 127)
        Me.TxtCategoria.Name = "TxtCategoria"
        Me.TxtCategoria.Size = New System.Drawing.Size(258, 20)
        Me.TxtCategoria.TabIndex = 47
        Me.TxtCategoria.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 48
        '
        'InsertarToolStripMenuItem
        '
        Me.InsertarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CategoriaToolStripMenuItem, Me.PDFToolStripMenuItem})
        Me.InsertarToolStripMenuItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertarToolStripMenuItem.Image = Global.Celer.My.Resources.Resources.Actions_go_next_icon
        Me.InsertarToolStripMenuItem.Name = "InsertarToolStripMenuItem"
        Me.InsertarToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.InsertarToolStripMenuItem.Text = "Insertar"
        '
        'CategoriaToolStripMenuItem
        '
        Me.CategoriaToolStripMenuItem.Image = Global.Celer.My.Resources.Resources.Folder_Open_icon1
        Me.CategoriaToolStripMenuItem.Name = "CategoriaToolStripMenuItem"
        Me.CategoriaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CategoriaToolStripMenuItem.Text = "Categoria"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'FormConfigurarPDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.TxtCategoria)
        Me.Controls.Add(Me.btaceptar)
        Me.Controls.Add(Me.TxtNomArchivo)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUbicacion)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormConfigurarPDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpdBuscarPDF As OpenFileDialog
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtUbicacion As TextBox
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label3 As Label
    Public WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btsalir As Button
    Friend WithEvents btaceptar As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TxtNomArchivo As TextBox
    Friend WithEvents TxtCategoria As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents InsertarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoriaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem As ToolStripMenuItem
End Class
