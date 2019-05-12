<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSemaforoGlosa
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSemaforoGlosa))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fechaini = New System.Windows.Forms.DateTimePicker()
        Me.fechafin = New System.Windows.Forms.DateTimePicker()
        Me.GroupEps = New System.Windows.Forms.GroupBox()
        Me.btbuscareps = New System.Windows.Forms.Button()
        Me.Texteps = New System.Windows.Forms.TextBox()
        Me.textnit = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvfacturas = New System.Windows.Forms.DataGridView()
        Me.dgvsemaforo = New System.Windows.Forms.DataGridView()
        Me.rtodos = New System.Windows.Forms.RadioButton()
        Me.reps = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupEps.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvfacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvsemaforo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.services_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "SEMAFORIZACION DE RESPUESTA A GLOSAS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label4.Location = New System.Drawing.Point(54, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(856, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "_________________________________________________________________________________" &
    "________________________________________"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.fechaini)
        Me.GroupBox2.Controls.Add(Me.fechafin)
        Me.GroupBox2.Controls.Add(Me.GroupEps)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.rtodos)
        Me.GroupBox2.Controls.Add(Me.reps)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(914, 498)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 10027
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 10026
        Me.Label1.Text = "Desde:"
        '
        'fechaini
        '
        Me.fechaini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaini.Location = New System.Drawing.Point(55, 20)
        Me.fechaini.Name = "fechaini"
        Me.fechaini.Size = New System.Drawing.Size(94, 21)
        Me.fechaini.TabIndex = 30
        Me.fechaini.Value = New Date(2017, 12, 1, 15, 19, 0, 0)
        '
        'fechafin
        '
        Me.fechafin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechafin.Location = New System.Drawing.Point(201, 20)
        Me.fechafin.Name = "fechafin"
        Me.fechafin.Size = New System.Drawing.Size(89, 21)
        Me.fechafin.TabIndex = 31
        '
        'GroupEps
        '
        Me.GroupEps.Controls.Add(Me.btbuscareps)
        Me.GroupEps.Controls.Add(Me.Texteps)
        Me.GroupEps.Controls.Add(Me.textnit)
        Me.GroupEps.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupEps.Location = New System.Drawing.Point(6, 46)
        Me.GroupEps.Name = "GroupEps"
        Me.GroupEps.Size = New System.Drawing.Size(902, 47)
        Me.GroupEps.TabIndex = 10025
        Me.GroupEps.TabStop = False
        Me.GroupEps.Text = "EPS"
        '
        'btbuscareps
        '
        Me.btbuscareps.Enabled = False
        Me.btbuscareps.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscareps.Location = New System.Drawing.Point(858, 18)
        Me.btbuscareps.Name = "btbuscareps"
        Me.btbuscareps.Size = New System.Drawing.Size(25, 23)
        Me.btbuscareps.TabIndex = 10024
        Me.btbuscareps.UseVisualStyleBackColor = True
        '
        'Texteps
        '
        Me.Texteps.BackColor = System.Drawing.Color.White
        Me.Texteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Texteps.Location = New System.Drawing.Point(121, 19)
        Me.Texteps.Name = "Texteps"
        Me.Texteps.ReadOnly = True
        Me.Texteps.Size = New System.Drawing.Size(727, 21)
        Me.Texteps.TabIndex = 25
        Me.Texteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textnit
        '
        Me.textnit.BackColor = System.Drawing.Color.White
        Me.textnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textnit.Location = New System.Drawing.Point(6, 19)
        Me.textnit.Name = "textnit"
        Me.textnit.ReadOnly = True
        Me.textnit.Size = New System.Drawing.Size(113, 21)
        Me.textnit.TabIndex = 10025
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvfacturas)
        Me.GroupBox4.Controls.Add(Me.dgvsemaforo)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 92)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(902, 399)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'dgvfacturas
        '
        Me.dgvfacturas.AllowUserToAddRows = False
        Me.dgvfacturas.AllowUserToDeleteRows = False
        Me.dgvfacturas.AllowUserToOrderColumns = True
        Me.dgvfacturas.AllowUserToResizeColumns = False
        Me.dgvfacturas.AllowUserToResizeRows = False
        Me.dgvfacturas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfacturas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvfacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvfacturas.Location = New System.Drawing.Point(200, 78)
        Me.dgvfacturas.Name = "dgvfacturas"
        Me.dgvfacturas.ReadOnly = True
        Me.dgvfacturas.RowHeadersVisible = False
        Me.dgvfacturas.Size = New System.Drawing.Size(475, 244)
        Me.dgvfacturas.TabIndex = 1
        Me.dgvfacturas.Visible = False
        '
        'dgvsemaforo
        '
        Me.dgvsemaforo.AllowUserToAddRows = False
        Me.dgvsemaforo.AllowUserToDeleteRows = False
        Me.dgvsemaforo.AllowUserToOrderColumns = True
        Me.dgvsemaforo.AllowUserToResizeColumns = False
        Me.dgvsemaforo.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvsemaforo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvsemaforo.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsemaforo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvsemaforo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvsemaforo.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvsemaforo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvsemaforo.Location = New System.Drawing.Point(3, 16)
        Me.dgvsemaforo.Name = "dgvsemaforo"
        Me.dgvsemaforo.ReadOnly = True
        Me.dgvsemaforo.RowHeadersVisible = False
        Me.dgvsemaforo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvsemaforo.Size = New System.Drawing.Size(896, 380)
        Me.dgvsemaforo.TabIndex = 0
        '
        'rtodos
        '
        Me.rtodos.AutoSize = True
        Me.rtodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.rtodos.Location = New System.Drawing.Point(769, 19)
        Me.rtodos.Name = "rtodos"
        Me.rtodos.Size = New System.Drawing.Size(55, 17)
        Me.rtodos.TabIndex = 29
        Me.rtodos.Text = "Todos"
        Me.rtodos.UseVisualStyleBackColor = True
        '
        'reps
        '
        Me.reps.AutoSize = True
        Me.reps.Checked = True
        Me.reps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.reps.Location = New System.Drawing.Point(697, 19)
        Me.reps.Name = "reps"
        Me.reps.Size = New System.Drawing.Size(46, 17)
        Me.reps.TabIndex = 28
        Me.reps.TabStop = True
        Me.reps.Text = "EPS"
        Me.reps.UseVisualStyleBackColor = True
        '
        'FormSemaforoGlosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 557)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 596)
        Me.MinimumSize = New System.Drawing.Size(942, 596)
        Me.Name = "FormSemaforoGlosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupEps.ResumeLayout(False)
        Me.GroupEps.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvfacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvsemaforo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents fechafin As DateTimePicker
    Friend WithEvents fechaini As DateTimePicker
    Friend WithEvents rtodos As RadioButton
    Friend WithEvents reps As RadioButton
    Friend WithEvents Texteps As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvfacturas As DataGridView
    Friend WithEvents dgvsemaforo As DataGridView
    Friend WithEvents btbuscareps As Button
    Friend WithEvents GroupEps As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents textnit As TextBox
End Class
