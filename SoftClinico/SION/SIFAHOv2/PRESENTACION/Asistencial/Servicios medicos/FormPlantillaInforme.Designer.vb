<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPlantillaInforme
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPlantillaInforme))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMedico = New System.Windows.Forms.TextBox()
        Me.btBuscarProcedimiento = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlDiagnostico = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPnlNombre = New System.Windows.Forms.TextBox()
        Me.txtPnlInterpretacion = New System.Windows.Forms.TextBox()
        Me.dgvDiagnostico = New System.Windows.Forms.DataGridView()
        Me.cmbRespuesta = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlDiagnostico.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDiagnostico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Actions_view_list_details_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "PLANTILLA INFORME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label2.Location = New System.Drawing.Point(54, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(723, 20)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_____________________"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btguardar, Me.ToolStripSeparator3, Me.btcancelar, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 407)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 54)
        Me.ToolStrip1.TabIndex = 33
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
        Me.btcancelar.Image = Global.Celer.My.Resources.Resources.Alarm_Error_icon1
        Me.btcancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btcancelar.Name = "btcancelar"
        Me.btcancelar.Size = New System.Drawing.Size(36, 51)
        Me.btcancelar.Text = "&Salir"
        Me.btcancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMedico)
        Me.GroupBox1.Controls.Add(Me.btBuscarProcedimiento)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmbRespuesta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 351)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'txtMedico
        '
        Me.txtMedico.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtMedico.Location = New System.Drawing.Point(12, 323)
        Me.txtMedico.Name = "txtMedico"
        Me.txtMedico.ReadOnly = True
        Me.txtMedico.Size = New System.Drawing.Size(336, 20)
        Me.txtMedico.TabIndex = 6
        Me.txtMedico.Text = "MÉDICO"
        '
        'btBuscarProcedimiento
        '
        Me.btBuscarProcedimiento.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarProcedimiento.Location = New System.Drawing.Point(354, 322)
        Me.btBuscarProcedimiento.Name = "btBuscarProcedimiento"
        Me.btBuscarProcedimiento.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarProcedimiento.TabIndex = 5
        Me.btBuscarProcedimiento.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(701, 327)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "HORAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(401, 327)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(244, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "TIEMPO PROGRAMACIÓN RESPUESTA: "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlDiagnostico)
        Me.GroupBox2.Controls.Add(Me.dgvDiagnostico)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(748, 309)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'pnlDiagnostico
        '
        Me.pnlDiagnostico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDiagnostico.Controls.Add(Me.Label4)
        Me.pnlDiagnostico.Controls.Add(Me.GroupBox3)
        Me.pnlDiagnostico.Location = New System.Drawing.Point(87, 23)
        Me.pnlDiagnostico.Name = "pnlDiagnostico"
        Me.pnlDiagnostico.Size = New System.Drawing.Size(587, 268)
        Me.pnlDiagnostico.TabIndex = 1
        Me.pnlDiagnostico.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(562, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 22)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "X"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtPnlNombre)
        Me.GroupBox3.Controls.Add(Me.txtPnlInterpretacion)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(581, 246)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Nombre:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Interpretación:"
        '
        'txtPnlNombre
        '
        Me.txtPnlNombre.Location = New System.Drawing.Point(6, 29)
        Me.txtPnlNombre.Name = "txtPnlNombre"
        Me.txtPnlNombre.Size = New System.Drawing.Size(569, 20)
        Me.txtPnlNombre.TabIndex = 0
        '
        'txtPnlInterpretacion
        '
        Me.txtPnlInterpretacion.Location = New System.Drawing.Point(6, 71)
        Me.txtPnlInterpretacion.Multiline = True
        Me.txtPnlInterpretacion.Name = "txtPnlInterpretacion"
        Me.txtPnlInterpretacion.Size = New System.Drawing.Size(569, 172)
        Me.txtPnlInterpretacion.TabIndex = 1
        '
        'dgvDiagnostico
        '
        Me.dgvDiagnostico.AllowUserToAddRows = False
        Me.dgvDiagnostico.AllowUserToDeleteRows = False
        Me.dgvDiagnostico.BackgroundColor = System.Drawing.Color.White
        Me.dgvDiagnostico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiagnostico.Location = New System.Drawing.Point(6, 10)
        Me.dgvDiagnostico.Name = "dgvDiagnostico"
        Me.dgvDiagnostico.RowHeadersVisible = False
        Me.dgvDiagnostico.Size = New System.Drawing.Size(736, 293)
        Me.dgvDiagnostico.TabIndex = 0
        '
        'cmbRespuesta
        '
        Me.cmbRespuesta.FormattingEnabled = True
        Me.cmbRespuesta.Items.AddRange(New Object() {"24", "48", "72"})
        Me.cmbRespuesta.Location = New System.Drawing.Point(648, 324)
        Me.cmbRespuesta.Name = "cmbRespuesta"
        Me.cmbRespuesta.Size = New System.Drawing.Size(47, 21)
        Me.cmbRespuesta.TabIndex = 1
        Me.cmbRespuesta.Text = "24"
        '
        'FormPlantillaInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "FormPlantillaInforme"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlDiagnostico.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvDiagnostico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvDiagnostico As DataGridView
    Friend WithEvents cmbRespuesta As ComboBox
    Friend WithEvents pnlDiagnostico As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtPnlNombre As TextBox
    Friend WithEvents txtPnlInterpretacion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMedico As TextBox
    Public WithEvents btBuscarProcedimiento As Button
End Class
