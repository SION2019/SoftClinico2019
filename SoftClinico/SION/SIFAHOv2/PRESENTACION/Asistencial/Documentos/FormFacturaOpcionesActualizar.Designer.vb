<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFacturaOpcionesActualizar
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbInsumo = New System.Windows.Forms.CheckBox()
        Me.cbMedicamento = New System.Windows.Forms.CheckBox()
        Me.cbProcedimiento = New System.Windows.Forms.CheckBox()
        Me.cbHemoderivado = New System.Windows.Forms.CheckBox()
        Me.cbParaclinico = New System.Windows.Forms.CheckBox()
        Me.cbOxigeno = New System.Windows.Forms.CheckBox()
        Me.cbTraslado = New System.Windows.Forms.CheckBox()
        Me.cbEstancia = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btguardar, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 242)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(559, 54)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btguardar
        '
        Me.btguardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btguardar.Image = Global.Celer.My.Resources.Resources.Badge_tick_icon__1_
        Me.btguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(63, 51)
        Me.btguardar.Text = "&Continuar"
        Me.btguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.aplica
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "SELECCIÓN DE GRUPOS PARA ACTUALIZAR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(489, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(532, 187)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbInsumo)
        Me.GroupBox2.Controls.Add(Me.cbMedicamento)
        Me.GroupBox2.Controls.Add(Me.cbProcedimiento)
        Me.GroupBox2.Controls.Add(Me.cbHemoderivado)
        Me.GroupBox2.Controls.Add(Me.cbParaclinico)
        Me.GroupBox2.Controls.Add(Me.cbOxigeno)
        Me.GroupBox2.Controls.Add(Me.cbTraslado)
        Me.GroupBox2.Controls.Add(Me.cbEstancia)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 166)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Grupos:"
        '
        'cbInsumo
        '
        Me.cbInsumo.AutoSize = True
        Me.cbInsumo.Checked = True
        Me.cbInsumo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbInsumo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbInsumo.Location = New System.Drawing.Point(287, 112)
        Me.cbInsumo.Name = "cbInsumo"
        Me.cbInsumo.Size = New System.Drawing.Size(77, 20)
        Me.cbInsumo.TabIndex = 7
        Me.cbInsumo.Text = "Insumos"
        Me.cbInsumo.UseVisualStyleBackColor = True
        '
        'cbMedicamento
        '
        Me.cbMedicamento.AutoSize = True
        Me.cbMedicamento.Checked = True
        Me.cbMedicamento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMedicamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMedicamento.Location = New System.Drawing.Point(287, 86)
        Me.cbMedicamento.Name = "cbMedicamento"
        Me.cbMedicamento.Size = New System.Drawing.Size(116, 20)
        Me.cbMedicamento.TabIndex = 6
        Me.cbMedicamento.Text = "Medicamentos"
        Me.cbMedicamento.UseVisualStyleBackColor = True
        '
        'cbProcedimiento
        '
        Me.cbProcedimiento.AutoSize = True
        Me.cbProcedimiento.Checked = True
        Me.cbProcedimiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbProcedimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProcedimiento.Location = New System.Drawing.Point(287, 60)
        Me.cbProcedimiento.Name = "cbProcedimiento"
        Me.cbProcedimiento.Size = New System.Drawing.Size(121, 20)
        Me.cbProcedimiento.TabIndex = 5
        Me.cbProcedimiento.Text = "Procedimientos"
        Me.cbProcedimiento.UseVisualStyleBackColor = True
        '
        'cbHemoderivado
        '
        Me.cbHemoderivado.AutoSize = True
        Me.cbHemoderivado.Checked = True
        Me.cbHemoderivado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbHemoderivado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHemoderivado.Location = New System.Drawing.Point(287, 34)
        Me.cbHemoderivado.Name = "cbHemoderivado"
        Me.cbHemoderivado.Size = New System.Drawing.Size(125, 20)
        Me.cbHemoderivado.TabIndex = 4
        Me.cbHemoderivado.Text = "Hemoderivados"
        Me.cbHemoderivado.UseVisualStyleBackColor = True
        '
        'cbParaclinico
        '
        Me.cbParaclinico.AutoSize = True
        Me.cbParaclinico.Checked = True
        Me.cbParaclinico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbParaclinico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbParaclinico.Location = New System.Drawing.Point(117, 112)
        Me.cbParaclinico.Name = "cbParaclinico"
        Me.cbParaclinico.Size = New System.Drawing.Size(101, 20)
        Me.cbParaclinico.TabIndex = 3
        Me.cbParaclinico.Text = "Paraclínicos"
        Me.cbParaclinico.UseVisualStyleBackColor = True
        '
        'cbOxigeno
        '
        Me.cbOxigeno.AutoSize = True
        Me.cbOxigeno.Checked = True
        Me.cbOxigeno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbOxigeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOxigeno.Location = New System.Drawing.Point(117, 86)
        Me.cbOxigeno.Name = "cbOxigeno"
        Me.cbOxigeno.Size = New System.Drawing.Size(84, 20)
        Me.cbOxigeno.TabIndex = 2
        Me.cbOxigeno.Text = "Oxígenos"
        Me.cbOxigeno.UseVisualStyleBackColor = True
        '
        'cbTraslado
        '
        Me.cbTraslado.AutoSize = True
        Me.cbTraslado.Checked = True
        Me.cbTraslado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTraslado.Location = New System.Drawing.Point(117, 60)
        Me.cbTraslado.Name = "cbTraslado"
        Me.cbTraslado.Size = New System.Drawing.Size(89, 20)
        Me.cbTraslado.TabIndex = 1
        Me.cbTraslado.Text = "Traslados"
        Me.cbTraslado.UseVisualStyleBackColor = True
        '
        'cbEstancia
        '
        Me.cbEstancia.AutoSize = True
        Me.cbEstancia.Checked = True
        Me.cbEstancia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEstancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstancia.Location = New System.Drawing.Point(117, 34)
        Me.cbEstancia.Name = "cbEstancia"
        Me.cbEstancia.Size = New System.Drawing.Size(86, 20)
        Me.cbEstancia.TabIndex = 0
        Me.cbEstancia.Text = "Estancias"
        Me.cbEstancia.UseVisualStyleBackColor = True
        '
        'FormFacturaOpcionesActualizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(559, 296)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(575, 335)
        Me.MinimumSize = New System.Drawing.Size(575, 335)
        Me.Name = "FormFacturaOpcionesActualizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbInsumo As CheckBox
    Friend WithEvents cbMedicamento As CheckBox
    Friend WithEvents cbProcedimiento As CheckBox
    Friend WithEvents cbHemoderivado As CheckBox
    Friend WithEvents cbParaclinico As CheckBox
    Friend WithEvents cbOxigeno As CheckBox
    Friend WithEvents cbTraslado As CheckBox
    Friend WithEvents cbEstancia As CheckBox
End Class
