<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeExogena
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformeExogena))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelTitulo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvExogena = New System.Windows.Forms.DataGridView()
        Me.btexcel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtAño = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboInforme = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvExogena, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources._2018ico
        Me.PictureBox1.Location = New System.Drawing.Point(7, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10056
        Me.PictureBox1.TabStop = False
        '
        'LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.Location = New System.Drawing.Point(53, 11)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(82, 20)
        Me.LabelTitulo.TabIndex = 10054
        Me.LabelTitulo.Text = "INFORMES "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(49, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1234, 20)
        Me.Label2.TabIndex = 10055
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvExogena)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1298, 531)
        Me.GroupBox1.TabIndex = 10057
        Me.GroupBox1.TabStop = False
        '
        'dgvExogena
        '
        Me.dgvExogena.AllowUserToAddRows = False
        Me.dgvExogena.AllowUserToDeleteRows = False
        Me.dgvExogena.AllowUserToResizeColumns = False
        Me.dgvExogena.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvExogena.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExogena.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExogena.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvExogena.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExogena.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvExogena.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExogena.Location = New System.Drawing.Point(3, 16)
        Me.dgvExogena.MultiSelect = False
        Me.dgvExogena.Name = "dgvExogena"
        Me.dgvExogena.ReadOnly = True
        Me.dgvExogena.RowHeadersVisible = False
        Me.dgvExogena.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExogena.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExogena.ShowCellErrors = False
        Me.dgvExogena.ShowCellToolTips = False
        Me.dgvExogena.ShowEditingIcon = False
        Me.dgvExogena.ShowRowErrors = False
        Me.dgvExogena.Size = New System.Drawing.Size(1292, 512)
        Me.dgvExogena.TabIndex = 38
        '
        'btexcel
        '
        Me.btexcel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btexcel.Image = Global.Celer.My.Resources.Resources.Excel_icon__1_
        Me.btexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btexcel.Location = New System.Drawing.Point(1141, 47)
        Me.btexcel.Name = "btexcel"
        Me.btexcel.Size = New System.Drawing.Size(105, 34)
        Me.btexcel.TabIndex = 60041
        Me.btexcel.Text = "  Exp. a excel"
        Me.btexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btexcel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtAño)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(1054, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(81, 46)
        Me.GroupBox3.TabIndex = 60042
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Año"
        '
        'dtAño
        '
        Me.dtAño.CustomFormat = "yyyy"
        Me.dtAño.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAño.Location = New System.Drawing.Point(6, 17)
        Me.dtAño.Name = "dtAño"
        Me.dtAño.ShowUpDown = True
        Me.dtAño.Size = New System.Drawing.Size(68, 22)
        Me.dtAño.TabIndex = 10056
        Me.dtAño.Value = New Date(2018, 1, 18, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(692, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 60043
        Me.Label4.Text = "Informe:"
        '
        'comboInforme
        '
        Me.comboInforme.BackColor = System.Drawing.Color.White
        Me.comboInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboInforme.FormattingEnabled = True
        Me.comboInforme.Location = New System.Drawing.Point(748, 59)
        Me.comboInforme.Name = "comboInforme"
        Me.comboInforme.Size = New System.Drawing.Size(247, 21)
        Me.comboInforme.TabIndex = 60044
        '
        'FormInformeExogena
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.comboInforme)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btexcel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LabelTitulo)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "FormInformeExogena"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvExogena, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelTitulo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvExogena As DataGridView
    Public WithEvents btexcel As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtAño As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents comboInforme As ComboBox
End Class
