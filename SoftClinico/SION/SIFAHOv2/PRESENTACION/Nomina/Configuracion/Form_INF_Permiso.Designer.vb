<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_INF_Permiso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_INF_Permiso))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.comboempleados = New System.Windows.Forms.ComboBox()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbpdf = New System.Windows.Forms.RadioButton()
        Me.rbdoc = New System.Windows.Forms.RadioButton()
        Me.rbxls = New System.Windows.Forms.RadioButton()
        Me.dateInicio = New System.Windows.Forms.DateTimePicker()
        Me.dateFin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(1, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(373, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "____________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.comboempleados)
        Me.GroupBox1.Controls.Add(Me.btvistaprevia)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.dateInicio)
        Me.GroupBox1.Controls.Add(Me.dateFin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(3, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 213)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'comboempleados
        '
        Me.comboempleados.FormattingEnabled = True
        Me.comboempleados.Location = New System.Drawing.Point(99, 182)
        Me.comboempleados.Name = "comboempleados"
        Me.comboempleados.Size = New System.Drawing.Size(269, 21)
        Me.comboempleados.TabIndex = 30
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btvistaprevia.Image = Global.Celer.My.Resources.Resources.Actions_page_zoom_icon__1_
        Me.btvistaprevia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btvistaprevia.Location = New System.Drawing.Point(230, 71)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(131, 72)
        Me.btvistaprevia.TabIndex = 29
        Me.btvistaprevia.Text = "Vista Previa"
        Me.btvistaprevia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbpdf)
        Me.GroupBox6.Controls.Add(Me.rbdoc)
        Me.GroupBox6.Controls.Add(Me.rbxls)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 52)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(123, 110)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Tipo de Archivo"
        '
        'rbpdf
        '
        Me.rbpdf.AutoSize = True
        Me.rbpdf.Checked = True
        Me.rbpdf.Location = New System.Drawing.Point(11, 27)
        Me.rbpdf.Name = "rbpdf"
        Me.rbpdf.Size = New System.Drawing.Size(44, 20)
        Me.rbpdf.TabIndex = 27
        Me.rbpdf.TabStop = True
        Me.rbpdf.Text = ".pdf"
        Me.rbpdf.UseVisualStyleBackColor = True
        '
        'rbdoc
        '
        Me.rbdoc.AutoSize = True
        Me.rbdoc.Location = New System.Drawing.Point(11, 53)
        Me.rbdoc.Name = "rbdoc"
        Me.rbdoc.Size = New System.Drawing.Size(46, 20)
        Me.rbdoc.TabIndex = 28
        Me.rbdoc.Text = ".doc"
        Me.rbdoc.UseVisualStyleBackColor = True
        '
        'rbxls
        '
        Me.rbxls.AutoSize = True
        Me.rbxls.Location = New System.Drawing.Point(11, 79)
        Me.rbxls.Name = "rbxls"
        Me.rbxls.Size = New System.Drawing.Size(42, 20)
        Me.rbxls.TabIndex = 29
        Me.rbxls.Text = ".xls"
        Me.rbxls.UseVisualStyleBackColor = True
        '
        'dateInicio
        '
        Me.dateInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateInicio.Location = New System.Drawing.Point(16, 21)
        Me.dateInicio.Name = "dateInicio"
        Me.dateInicio.Size = New System.Drawing.Size(104, 20)
        Me.dateInicio.TabIndex = 27
        '
        'dateFin
        '
        Me.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFin.Location = New System.Drawing.Point(188, 21)
        Me.dateFin.Name = "dateFin"
        Me.dateFin.Size = New System.Drawing.Size(104, 20)
        Me.dateFin.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(137, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "HASTA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 188)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "EMPLEADO:"
        '
        'Form_INF_Permiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(389, 215)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_INF_Permiso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox6 As GroupBox
    Public WithEvents Label5 As Label
    Public WithEvents rbxls As RadioButton
    Public WithEvents rbdoc As RadioButton
    Public WithEvents rbpdf As RadioButton
    Public WithEvents Label11 As Label
    Friend WithEvents dateFin As DateTimePicker
    Friend WithEvents dateInicio As DateTimePicker
    Friend WithEvents btvistaprevia As Button
    Friend WithEvents comboempleados As ComboBox
End Class
