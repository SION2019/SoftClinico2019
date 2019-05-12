<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfiguracionPacientesCapitados
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
        Me.btImportar = New System.Windows.Forms.Button()
        Me.dgvPacientes = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btTrasladarPacientes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextnombreEps = New System.Windows.Forms.TextBox()
        Me.btbuscareps = New System.Windows.Forms.Button()
        Me.lbFormato = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvPacientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btImportar
        '
        Me.btImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImportar.Image = Global.Celer.My.Resources.Resources.Excel_icon__1_
        Me.btImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btImportar.Location = New System.Drawing.Point(899, 45)
        Me.btImportar.Name = "btImportar"
        Me.btImportar.Size = New System.Drawing.Size(132, 34)
        Me.btImportar.TabIndex = 0
        Me.btImportar.Text = "Importar Archivo"
        Me.btImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btImportar.UseVisualStyleBackColor = True
        '
        'dgvPacientes
        '
        Me.dgvPacientes.BackgroundColor = System.Drawing.Color.White
        Me.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPacientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPacientes.Location = New System.Drawing.Point(3, 17)
        Me.dgvPacientes.Name = "dgvPacientes"
        Me.dgvPacientes.ReadOnly = True
        Me.dgvPacientes.Size = New System.Drawing.Size(1029, 432)
        Me.dgvPacientes.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(7, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60012
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 16)
        Me.Label1.TabIndex = 60011
        Me.Label1.Text = "CONFIGURACION DE PACIENTES CAPITADOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(49, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(961, 20)
        Me.Label2.TabIndex = 60013
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_______________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbFormato)
        Me.GroupBox1.Controls.Add(Me.dgvPacientes)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1035, 452)
        Me.GroupBox1.TabIndex = 60014
        Me.GroupBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btTrasladarPacientes, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 60015
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btTrasladarPacientes
        '
        Me.btTrasladarPacientes.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTrasladarPacientes.Image = Global.Celer.My.Resources.Resources.Arrows_Sync_icon
        Me.btTrasladarPacientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btTrasladarPacientes.Name = "btTrasladarPacientes"
        Me.btTrasladarPacientes.Size = New System.Drawing.Size(119, 51)
        Me.btTrasladarPacientes.Text = "&Relacionar Pacientes"
        Me.btTrasladarPacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'TextnombreEps
        '
        Me.TextnombreEps.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextnombreEps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextnombreEps.Location = New System.Drawing.Point(7, 55)
        Me.TextnombreEps.MaxLength = 100
        Me.TextnombreEps.Name = "TextnombreEps"
        Me.TextnombreEps.Size = New System.Drawing.Size(517, 21)
        Me.TextnombreEps.TabIndex = 60016
        '
        'btbuscareps
        '
        Me.btbuscareps.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscareps.Location = New System.Drawing.Point(530, 54)
        Me.btbuscareps.Name = "btbuscareps"
        Me.btbuscareps.Size = New System.Drawing.Size(25, 23)
        Me.btbuscareps.TabIndex = 80024
        Me.btbuscareps.UseVisualStyleBackColor = True
        '
        'lbFormato
        '
        Me.lbFormato.BackColor = System.Drawing.Color.Transparent
        Me.lbFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFormato.Image = Global.Celer.My.Resources.Resources.Captura
        Me.lbFormato.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lbFormato.Location = New System.Drawing.Point(94, 28)
        Me.lbFormato.Name = "lbFormato"
        Me.lbFormato.Size = New System.Drawing.Size(829, 73)
        Me.lbFormato.TabIndex = 3
        Me.lbFormato.Text = "Para importar el archivo es necesario mantener el siguiente formato y mismo nombr" &
    "e de columnas"
        Me.lbFormato.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbFormato.Visible = False
        '
        'Label3
        '
        Me.Label3.Image = Global.Celer.My.Resources.Resources.info
        Me.Label3.Location = New System.Drawing.Point(707, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 80025
        Me.Label3.Text = "Ayuda"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormConfiguracionPacientesCapitados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btbuscareps)
        Me.Controls.Add(Me.TextnombreEps)
        Me.Controls.Add(Me.btImportar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "FormConfiguracionPacientesCapitados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvPacientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btImportar As Button
    Friend WithEvents dgvPacientes As DataGridView
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btTrasladarPacientes As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TextnombreEps As TextBox
    Public WithEvents btbuscareps As Button
    Friend WithEvents lbFormato As Label
    Friend WithEvents Label3 As Label
End Class
