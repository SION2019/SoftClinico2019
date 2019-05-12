<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReporteAceptacionGlosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReporteAceptacionGlosa))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Checkconsolidado = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combodepartamento = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.comboarea = New System.Windows.Forms.ComboBox()
        Me.FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btVisualizaPDF = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btVisualizaPDF)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(543, 243)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha reportes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Checkconsolidado)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.combodepartamento)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.comboarea)
        Me.GroupBox2.Controls.Add(Me.FechaFinal)
        Me.GroupBox2.Controls.Add(Me.FechaInicio)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(527, 82)
        Me.GroupBox2.TabIndex = 60031
        Me.GroupBox2.TabStop = False
        '
        'Checkconsolidado
        '
        Me.Checkconsolidado.AutoSize = True
        Me.Checkconsolidado.Location = New System.Drawing.Point(427, 22)
        Me.Checkconsolidado.Name = "Checkconsolidado"
        Me.Checkconsolidado.Size = New System.Drawing.Size(86, 20)
        Me.Checkconsolidado.TabIndex = 18
        Me.Checkconsolidado.Text = "Consolidado"
        Me.Checkconsolidado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(239, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Departamento:"
        '
        'combodepartamento
        '
        Me.combodepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combodepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.combodepartamento.FormattingEnabled = True
        Me.combodepartamento.Location = New System.Drawing.Point(334, 47)
        Me.combodepartamento.Name = "combodepartamento"
        Me.combodepartamento.Size = New System.Drawing.Size(179, 23)
        Me.combodepartamento.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Area:"
        '
        'comboarea
        '
        Me.comboarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.comboarea.FormattingEnabled = True
        Me.comboarea.Location = New System.Drawing.Point(88, 47)
        Me.comboarea.Name = "comboarea"
        Me.comboarea.Size = New System.Drawing.Size(145, 23)
        Me.comboarea.TabIndex = 14
        '
        'FechaFinal
        '
        Me.FechaFinal.CustomFormat = ""
        Me.FechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaFinal.Location = New System.Drawing.Point(296, 23)
        Me.FechaFinal.Name = "FechaFinal"
        Me.FechaFinal.Size = New System.Drawing.Size(114, 21)
        Me.FechaFinal.TabIndex = 13
        '
        'FechaInicio
        '
        Me.FechaInicio.CustomFormat = ""
        Me.FechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaInicio.Location = New System.Drawing.Point(88, 22)
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.Size = New System.Drawing.Size(126, 21)
        Me.FechaInicio.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(220, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Fecha final:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha inicio:"
        '
        'btVisualizaPDF
        '
        Me.btVisualizaPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btVisualizaPDF.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btVisualizaPDF.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.btVisualizaPDF.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btVisualizaPDF.Location = New System.Drawing.Point(8, 203)
        Me.btVisualizaPDF.Name = "btVisualizaPDF"
        Me.btVisualizaPDF.Size = New System.Drawing.Size(84, 34)
        Me.btVisualizaPDF.TabIndex = 60030
        Me.btVisualizaPDF.Text = "Imprimir"
        Me.btVisualizaPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btVisualizaPDF.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.text_list_numbers_icon
        Me.PictureBox1.Location = New System.Drawing.Point(5, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "ACEPTACIÓN DE GLOSA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label6.Location = New System.Drawing.Point(47, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(506, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "_______________________________________________________________________"
        '
        'FormReporteAceptacionGlosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(559, 296)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(575, 335)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(575, 335)
        Me.Name = "FormReporteAceptacionGlosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents btVisualizaPDF As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Checkconsolidado As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents combodepartamento As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents comboarea As ComboBox
    Friend WithEvents FechaFinal As DateTimePicker
    Friend WithEvents FechaInicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
