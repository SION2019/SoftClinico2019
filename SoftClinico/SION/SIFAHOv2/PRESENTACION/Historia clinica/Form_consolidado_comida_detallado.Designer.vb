<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_consolidado_comida_detallado
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_consolidado_comida_detallado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbAreaServicio = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbtnPDF = New System.Windows.Forms.RadioButton()
        Me.rbtnExcel = New System.Windows.Forms.RadioButton()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtCantidadCena = New System.Windows.Forms.TextBox()
        Me.txtCantidadDesyuno = New System.Windows.Forms.TextBox()
        Me.txtCantidadAlmuerzo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvComidadDiaDia = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesayunoA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlmuerzoA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CenaA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvComidadDiaDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "DETALLADO DIA A DIA DE COMIDAS"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.order_history_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbAreaServicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.dtpFecha)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(890, 61)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'cmbAreaServicio
        '
        Me.cmbAreaServicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreaServicio.FormattingEnabled = True
        Me.cmbAreaServicio.Location = New System.Drawing.Point(101, 21)
        Me.cmbAreaServicio.Name = "cmbAreaServicio"
        Me.cmbAreaServicio.Size = New System.Drawing.Size(284, 23)
        Me.cmbAreaServicio.TabIndex = 307
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 15)
        Me.Label10.TabIndex = 306
        Me.Label10.Text = "Área Servicio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 15)
        Me.Label3.TabIndex = 301
        Me.Label3.Text = "Fecha de Busqueda:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbtnPDF)
        Me.GroupBox6.Controls.Add(Me.rbtnExcel)
        Me.GroupBox6.Location = New System.Drawing.Point(718, 9)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(166, 45)
        Me.GroupBox6.TabIndex = 304
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Tipo Impresión"
        '
        'rbtnPDF
        '
        Me.rbtnPDF.AutoSize = True
        Me.rbtnPDF.Checked = True
        Me.rbtnPDF.Location = New System.Drawing.Point(22, 19)
        Me.rbtnPDF.Name = "rbtnPDF"
        Me.rbtnPDF.Size = New System.Drawing.Size(46, 20)
        Me.rbtnPDF.TabIndex = 302
        Me.rbtnPDF.TabStop = True
        Me.rbtnPDF.Text = "PDF"
        Me.rbtnPDF.UseVisualStyleBackColor = True
        '
        'rbtnExcel
        '
        Me.rbtnExcel.AutoSize = True
        Me.rbtnExcel.Location = New System.Drawing.Point(101, 19)
        Me.rbtnExcel.Name = "rbtnExcel"
        Me.rbtnExcel.Size = New System.Drawing.Size(58, 20)
        Me.rbtnExcel.TabIndex = 303
        Me.rbtnExcel.Text = "EXCEL"
        Me.rbtnExcel.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "MMMM - yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(532, 22)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(143, 21)
        Me.dtpFecha.TabIndex = 300
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btimprimir
        '
        Me.btimprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btimprimir.Image = Global.Celer.My.Resources.Resources.Printer_icon
        Me.btimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(58, 51)
        Me.btimprimir.Text = "&Imprimir"
        Me.btimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(905, 446)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.dgvComidadDiaDia)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 78)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(890, 362)
        Me.GroupBox3.TabIndex = 302
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detallado"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtCantidadCena)
        Me.GroupBox5.Controls.Add(Me.txtCantidadDesyuno)
        Me.GroupBox5.Controls.Add(Me.txtCantidadAlmuerzo)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(573, 110)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(286, 75)
        Me.GroupBox5.TabIndex = 324
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cantidades Totalizadas"
        '
        'txtCantidadCena
        '
        Me.txtCantidadCena.BackColor = System.Drawing.SystemColors.Control
        Me.txtCantidadCena.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadCena.Location = New System.Drawing.Point(213, 37)
        Me.txtCantidadCena.Name = "txtCantidadCena"
        Me.txtCantidadCena.ReadOnly = True
        Me.txtCantidadCena.Size = New System.Drawing.Size(51, 21)
        Me.txtCantidadCena.TabIndex = 310
        Me.txtCantidadCena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadDesyuno
        '
        Me.txtCantidadDesyuno.BackColor = System.Drawing.SystemColors.Control
        Me.txtCantidadDesyuno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadDesyuno.Location = New System.Drawing.Point(20, 37)
        Me.txtCantidadDesyuno.Name = "txtCantidadDesyuno"
        Me.txtCantidadDesyuno.ReadOnly = True
        Me.txtCantidadDesyuno.Size = New System.Drawing.Size(51, 21)
        Me.txtCantidadDesyuno.TabIndex = 306
        Me.txtCantidadDesyuno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadAlmuerzo
        '
        Me.txtCantidadAlmuerzo.BackColor = System.Drawing.SystemColors.Control
        Me.txtCantidadAlmuerzo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadAlmuerzo.Location = New System.Drawing.Point(116, 37)
        Me.txtCantidadAlmuerzo.Name = "txtCantidadAlmuerzo"
        Me.txtCantidadAlmuerzo.ReadOnly = True
        Me.txtCantidadAlmuerzo.Size = New System.Drawing.Size(51, 21)
        Me.txtCantidadAlmuerzo.TabIndex = 308
        Me.txtCantidadAlmuerzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 316
        Me.Label4.Text = "Desayuno"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(220, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 318
        Me.Label5.Text = "Cena"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(112, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 317
        Me.Label9.Text = "Almuerzo"
        '
        'dgvComidadDiaDia
        '
        Me.dgvComidadDiaDia.AllowUserToAddRows = False
        Me.dgvComidadDiaDia.AllowUserToDeleteRows = False
        Me.dgvComidadDiaDia.AllowUserToResizeColumns = False
        Me.dgvComidadDiaDia.AllowUserToResizeRows = False
        Me.dgvComidadDiaDia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComidadDiaDia.BackgroundColor = System.Drawing.Color.White
        Me.dgvComidadDiaDia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComidadDiaDia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComidadDiaDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvComidadDiaDia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Area, Me.Fecha, Me.DesayunoA, Me.AlmuerzoA, Me.CenaA})
        Me.dgvComidadDiaDia.EnableHeadersVisualStyles = False
        Me.dgvComidadDiaDia.Location = New System.Drawing.Point(6, 20)
        Me.dgvComidadDiaDia.Name = "dgvComidadDiaDia"
        Me.dgvComidadDiaDia.RowHeadersVisible = False
        Me.dgvComidadDiaDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComidadDiaDia.Size = New System.Drawing.Size(878, 336)
        Me.dgvComidadDiaDia.TabIndex = 326
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Area"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.HeaderText = "Desayuno"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.HeaderText = "Almuerzo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 90
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cena"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 90
        '
        'Area
        '
        Me.Area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Area.Width = 150
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'DesayunoA
        '
        Me.DesayunoA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DesayunoA.HeaderText = "Desayuno"
        Me.DesayunoA.Name = "DesayunoA"
        Me.DesayunoA.Width = 90
        '
        'AlmuerzoA
        '
        Me.AlmuerzoA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.AlmuerzoA.HeaderText = "Almuerzo"
        Me.AlmuerzoA.Name = "AlmuerzoA"
        Me.AlmuerzoA.Width = 90
        '
        'CenaA
        '
        Me.CenaA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CenaA.HeaderText = "Cena"
        Me.CenaA.Name = "CenaA"
        Me.CenaA.Width = 90
        '
        'Form_consolidado_comida_detallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "Form_consolidado_comida_detallado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgvComidadDiaDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbtnExcel As RadioButton
    Friend WithEvents rbtnPDF As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btimprimir As ToolStripButton
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgvComidadDiaDia As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtCantidadCena As TextBox
    Friend WithEvents txtCantidadDesyuno As TextBox
    Friend WithEvents txtCantidadAlmuerzo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbAreaServicio As ComboBox
    Friend WithEvents Area As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents DesayunoA As DataGridViewTextBoxColumn
    Friend WithEvents AlmuerzoA As DataGridViewTextBoxColumn
    Friend WithEvents CenaA As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
