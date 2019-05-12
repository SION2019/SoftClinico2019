<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSispro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSispro))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvSispro = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.fechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.btexcel = New System.Windows.Forms.Button()
        Me.btGenerar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSispro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.descarga
        Me.PictureBox1.Location = New System.Drawing.Point(11, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10053
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 16)
        Me.Label1.TabIndex = 10051
        Me.Label1.Text = "INFORME SISPRO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(53, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1234, 20)
        Me.Label2.TabIndex = 10052
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvSispro)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1298, 518)
        Me.GroupBox1.TabIndex = 10054
        Me.GroupBox1.TabStop = False
        '
        'dgvSispro
        '
        Me.dgvSispro.AllowUserToAddRows = False
        Me.dgvSispro.AllowUserToDeleteRows = False
        Me.dgvSispro.AllowUserToResizeColumns = False
        Me.dgvSispro.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvSispro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSispro.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSispro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSispro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSispro.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSispro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSispro.Location = New System.Drawing.Point(3, 16)
        Me.dgvSispro.MultiSelect = False
        Me.dgvSispro.Name = "dgvSispro"
        Me.dgvSispro.ReadOnly = True
        Me.dgvSispro.RowHeadersVisible = False
        Me.dgvSispro.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSispro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSispro.ShowCellErrors = False
        Me.dgvSispro.ShowCellToolTips = False
        Me.dgvSispro.ShowEditingIcon = False
        Me.dgvSispro.ShowRowErrors = False
        Me.dgvSispro.Size = New System.Drawing.Size(1292, 499)
        Me.dgvSispro.TabIndex = 38
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.fechaHasta)
        Me.GroupBox2.Controls.Add(Me.fechaDesde)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(57, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(569, 47)
        Me.GroupBox2.TabIndex = 10055
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde:"
        '
        'fechaHasta
        '
        Me.fechaHasta.CustomFormat = "dd MMMM yyyy"
        Me.fechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaHasta.Location = New System.Drawing.Point(353, 17)
        Me.fechaHasta.Name = "fechaHasta"
        Me.fechaHasta.Size = New System.Drawing.Size(200, 21)
        Me.fechaHasta.TabIndex = 1
        '
        'fechaDesde
        '
        Me.fechaDesde.CustomFormat = "dd MMMM yyyy"
        Me.fechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaDesde.Location = New System.Drawing.Point(71, 18)
        Me.fechaDesde.Name = "fechaDesde"
        Me.fechaDesde.Size = New System.Drawing.Size(200, 21)
        Me.fechaDesde.TabIndex = 0
        '
        'btexcel
        '
        Me.btexcel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btexcel.Image = Global.Celer.My.Resources.Resources.Excel_icon__1_
        Me.btexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btexcel.Location = New System.Drawing.Point(1197, 50)
        Me.btexcel.Name = "btexcel"
        Me.btexcel.Size = New System.Drawing.Size(105, 34)
        Me.btexcel.TabIndex = 60040
        Me.btexcel.Text = "  Exp. a excel"
        Me.btexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btexcel.UseVisualStyleBackColor = True
        '
        'btGenerar
        '
        Me.btGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btGenerar.Location = New System.Drawing.Point(655, 52)
        Me.btGenerar.Name = "btGenerar"
        Me.btGenerar.Size = New System.Drawing.Size(90, 34)
        Me.btGenerar.TabIndex = 60041
        Me.btGenerar.Text = "Generar"
        Me.btGenerar.UseVisualStyleBackColor = True
        '
        'FormSispro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.btGenerar)
        Me.Controls.Add(Me.btexcel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "FormSispro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvSispro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvSispro As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Public WithEvents btexcel As Button
    Public WithEvents btGenerar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents fechaHasta As DateTimePicker
    Friend WithEvents fechaDesde As DateTimePicker
End Class
