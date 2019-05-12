<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_IndicadoresMetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_IndicadoresMetas))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAreaM = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudBasicoPE = New System.Windows.Forms.NumericUpDown()
        Me.nudIntermedioPE = New System.Windows.Forms.NumericUpDown()
        Me.nudIntensivoPE = New System.Windows.Forms.NumericUpDown()
        Me.nudBasicoOE = New System.Windows.Forms.NumericUpDown()
        Me.nudIntermedioOE = New System.Windows.Forms.NumericUpDown()
        Me.nudIntensivoOE = New System.Windows.Forms.NumericUpDown()
        Me.nudBasico = New System.Windows.Forms.NumericUpDown()
        Me.nudIntermedio = New System.Windows.Forms.NumericUpDown()
        Me.nudIntensivo = New System.Windows.Forms.NumericUpDown()
        Me.gboxPeriodo = New System.Windows.Forms.GroupBox()
        Me.rdbAño = New System.Windows.Forms.RadioButton()
        Me.rdbSemestre = New System.Windows.Forms.RadioButton()
        Me.rdbSemana = New System.Windows.Forms.RadioButton()
        Me.rdbMes = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvIndicadoresMetas = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nudBasicoPE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntermedioPE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntensivoPE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBasicoOE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntermedioOE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntensivoOE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntermedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntensivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxPeriodo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvIndicadoresMetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Column_Chart_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10065
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 16)
        Me.Label1.TabIndex = 10063
        Me.Label1.Text = "INDICADORES DE GESTIÓN: METAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 10064
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbAreaM)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.gboxPeriodo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(902, 152)
        Me.GroupBox1.TabIndex = 10066
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Area :"
        '
        'cmbAreaM
        '
        Me.cmbAreaM.FormattingEnabled = True
        Me.cmbAreaM.Location = New System.Drawing.Point(74, 19)
        Me.cmbAreaM.Name = "cmbAreaM"
        Me.cmbAreaM.Size = New System.Drawing.Size(272, 21)
        Me.cmbAreaM.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtTotal)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.nudBasicoPE)
        Me.GroupBox4.Controls.Add(Me.nudIntermedioPE)
        Me.GroupBox4.Controls.Add(Me.nudIntensivoPE)
        Me.GroupBox4.Controls.Add(Me.nudBasicoOE)
        Me.GroupBox4.Controls.Add(Me.nudIntermedioOE)
        Me.GroupBox4.Controls.Add(Me.nudIntensivoOE)
        Me.GroupBox4.Controls.Add(Me.nudBasico)
        Me.GroupBox4.Controls.Add(Me.nudIntermedio)
        Me.GroupBox4.Controls.Add(Me.nudIntensivo)
        Me.GroupBox4.Location = New System.Drawing.Point(352, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(544, 134)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Capacidad Instalada"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(137, 107)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtTotal.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(324, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(324, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(325, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(408, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Promedio de Estancia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(265, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ocupación Esperada"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(35, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "TOTAL:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label6.Location = New System.Drawing.Point(35, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Basico:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(35, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Intermedio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(35, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Intensivo:"
        '
        'nudBasicoPE
        '
        Me.nudBasicoPE.Location = New System.Drawing.Point(427, 82)
        Me.nudBasicoPE.Name = "nudBasicoPE"
        Me.nudBasicoPE.Size = New System.Drawing.Size(76, 20)
        Me.nudBasicoPE.TabIndex = 9
        '
        'nudIntermedioPE
        '
        Me.nudIntermedioPE.Location = New System.Drawing.Point(427, 56)
        Me.nudIntermedioPE.Name = "nudIntermedioPE"
        Me.nudIntermedioPE.Size = New System.Drawing.Size(76, 20)
        Me.nudIntermedioPE.TabIndex = 8
        '
        'nudIntensivoPE
        '
        Me.nudIntensivoPE.Location = New System.Drawing.Point(427, 31)
        Me.nudIntensivoPE.Name = "nudIntensivoPE"
        Me.nudIntensivoPE.Size = New System.Drawing.Size(76, 20)
        Me.nudIntensivoPE.TabIndex = 7
        '
        'nudBasicoOE
        '
        Me.nudBasicoOE.Location = New System.Drawing.Point(281, 82)
        Me.nudBasicoOE.Name = "nudBasicoOE"
        Me.nudBasicoOE.Size = New System.Drawing.Size(76, 20)
        Me.nudBasicoOE.TabIndex = 6
        '
        'nudIntermedioOE
        '
        Me.nudIntermedioOE.Location = New System.Drawing.Point(281, 56)
        Me.nudIntermedioOE.Name = "nudIntermedioOE"
        Me.nudIntermedioOE.Size = New System.Drawing.Size(76, 20)
        Me.nudIntermedioOE.TabIndex = 5
        '
        'nudIntensivoOE
        '
        Me.nudIntensivoOE.Location = New System.Drawing.Point(281, 31)
        Me.nudIntensivoOE.Name = "nudIntensivoOE"
        Me.nudIntensivoOE.Size = New System.Drawing.Size(76, 20)
        Me.nudIntensivoOE.TabIndex = 4
        '
        'nudBasico
        '
        Me.nudBasico.Location = New System.Drawing.Point(136, 82)
        Me.nudBasico.Name = "nudBasico"
        Me.nudBasico.Size = New System.Drawing.Size(76, 20)
        Me.nudBasico.TabIndex = 2
        '
        'nudIntermedio
        '
        Me.nudIntermedio.Location = New System.Drawing.Point(136, 56)
        Me.nudIntermedio.Name = "nudIntermedio"
        Me.nudIntermedio.Size = New System.Drawing.Size(76, 20)
        Me.nudIntermedio.TabIndex = 1
        '
        'nudIntensivo
        '
        Me.nudIntensivo.Location = New System.Drawing.Point(136, 30)
        Me.nudIntensivo.Name = "nudIntensivo"
        Me.nudIntensivo.Size = New System.Drawing.Size(76, 20)
        Me.nudIntensivo.TabIndex = 0
        '
        'gboxPeriodo
        '
        Me.gboxPeriodo.Controls.Add(Me.rdbAño)
        Me.gboxPeriodo.Controls.Add(Me.rdbSemestre)
        Me.gboxPeriodo.Controls.Add(Me.rdbSemana)
        Me.gboxPeriodo.Controls.Add(Me.rdbMes)
        Me.gboxPeriodo.Location = New System.Drawing.Point(20, 47)
        Me.gboxPeriodo.Name = "gboxPeriodo"
        Me.gboxPeriodo.Size = New System.Drawing.Size(326, 99)
        Me.gboxPeriodo.TabIndex = 0
        Me.gboxPeriodo.TabStop = False
        Me.gboxPeriodo.Text = "Periodos días"
        '
        'rdbAño
        '
        Me.rdbAño.AutoSize = True
        Me.rdbAño.Location = New System.Drawing.Point(192, 56)
        Me.rdbAño.Name = "rdbAño"
        Me.rdbAño.Size = New System.Drawing.Size(92, 17)
        Me.rdbAño.TabIndex = 2
        Me.rdbAño.TabStop = True
        Me.rdbAño.Text = "Año: 365 días"
        Me.rdbAño.UseVisualStyleBackColor = True
        '
        'rdbSemestre
        '
        Me.rdbSemestre.AutoSize = True
        Me.rdbSemestre.Location = New System.Drawing.Point(34, 56)
        Me.rdbSemestre.Name = "rdbSemestre"
        Me.rdbSemestre.Size = New System.Drawing.Size(126, 17)
        Me.rdbSemestre.TabIndex = 1
        Me.rdbSemestre.TabStop = True
        Me.rdbSemestre.Text = "Semestre: 182.5 días"
        Me.rdbSemestre.UseVisualStyleBackColor = True
        '
        'rdbSemana
        '
        Me.rdbSemana.AutoSize = True
        Me.rdbSemana.Location = New System.Drawing.Point(192, 33)
        Me.rdbSemana.Name = "rdbSemana"
        Me.rdbSemana.Size = New System.Drawing.Size(100, 17)
        Me.rdbSemana.TabIndex = 1
        Me.rdbSemana.TabStop = True
        Me.rdbSemana.Text = "Semana: 7 días"
        Me.rdbSemana.UseVisualStyleBackColor = True
        '
        'rdbMes
        '
        Me.rdbMes.AutoSize = True
        Me.rdbMes.Checked = True
        Me.rdbMes.Location = New System.Drawing.Point(34, 33)
        Me.rdbMes.Name = "rdbMes"
        Me.rdbMes.Size = New System.Drawing.Size(90, 17)
        Me.rdbMes.TabIndex = 0
        Me.rdbMes.TabStop = True
        Me.rdbMes.Text = "Mes : 30 días"
        Me.rdbMes.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvIndicadoresMetas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(902, 300)
        Me.GroupBox2.TabIndex = 10067
        Me.GroupBox2.TabStop = False
        '
        'dgvIndicadoresMetas
        '
        Me.dgvIndicadoresMetas.AllowUserToAddRows = False
        Me.dgvIndicadoresMetas.AllowUserToDeleteRows = False
        Me.dgvIndicadoresMetas.AllowUserToResizeColumns = False
        Me.dgvIndicadoresMetas.AllowUserToResizeRows = False
        Me.dgvIndicadoresMetas.BackgroundColor = System.Drawing.Color.White
        Me.dgvIndicadoresMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIndicadoresMetas.Location = New System.Drawing.Point(6, 13)
        Me.dgvIndicadoresMetas.Name = "dgvIndicadoresMetas"
        Me.dgvIndicadoresMetas.ReadOnly = True
        Me.dgvIndicadoresMetas.RowHeadersVisible = False
        Me.dgvIndicadoresMetas.Size = New System.Drawing.Size(890, 279)
        Me.dgvIndicadoresMetas.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btguardar, Me.ToolStripSeparator3, Me.btcancelar, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 10068
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btguardar
        '
        Me.btguardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btguardar.Image = Global.Celer.My.Resources.Resources._04_Save_icon
        Me.btguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(53, 51)
        Me.btguardar.Text = "&Guardar"
        Me.btguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'btcancelar
        '
        Me.btcancelar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancelar.Image = Global.Celer.My.Resources.Resources.Actions_blue_arrow_undo_icon__1_
        Me.btcancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btcancelar.Name = "btcancelar"
        Me.btcancelar.Size = New System.Drawing.Size(56, 51)
        Me.btcancelar.Text = "&Cancelar"
        Me.btcancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 54)
        '
        'Form_IndicadoresMetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "Form_IndicadoresMetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nudBasicoPE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntermedioPE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntensivoPE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBasicoOE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntermedioOE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntensivoOE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBasico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntermedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntensivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxPeriodo.ResumeLayout(False)
        Me.gboxPeriodo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvIndicadoresMetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents gboxPeriodo As GroupBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAreaM As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nudBasicoPE As NumericUpDown
    Friend WithEvents nudIntermedioPE As NumericUpDown
    Friend WithEvents nudIntensivoPE As NumericUpDown
    Friend WithEvents nudBasicoOE As NumericUpDown
    Friend WithEvents nudIntermedioOE As NumericUpDown
    Friend WithEvents nudIntensivoOE As NumericUpDown
    Friend WithEvents nudBasico As NumericUpDown
    Friend WithEvents nudIntermedio As NumericUpDown
    Friend WithEvents nudIntensivo As NumericUpDown
    Friend WithEvents rdbMes As RadioButton
    Friend WithEvents dgvIndicadoresMetas As DataGridView
    Friend WithEvents rdbAño As RadioButton
    Friend WithEvents rdbSemestre As RadioButton
    Friend WithEvents rdbSemana As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTotal As TextBox
End Class
