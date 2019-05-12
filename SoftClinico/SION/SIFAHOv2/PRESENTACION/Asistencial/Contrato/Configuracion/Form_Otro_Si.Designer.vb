<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Otro_Si
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
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Textcodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Gpotros_si = New System.Windows.Forms.GroupBox()
        Me.vigente = New System.Windows.Forms.CheckBox()
        Me.Textvalor_si = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.fecha_ini_si = New System.Windows.Forms.DateTimePicker()
        Me.fecha_fin_si = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Textcodigo_contrato = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textdescripcion = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Gpotros_si.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 288)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(652, 54)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnuevo
        '
        Me.btnuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnuevo.Image = Global.Celer.My.Resources.Resources.Document_Add_icon__1_
        Me.btnuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnuevo.Name = "btnuevo"
        Me.btnuevo.Size = New System.Drawing.Size(46, 51)
        Me.btnuevo.Text = "&Nuevo"
        Me.btnuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'btguardar
        '
        Me.btguardar.Enabled = False
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
        'btbuscar
        '
        Me.btbuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbuscar.Image = Global.Celer.My.Resources.Resources.Actions_page_zoom_icon__1_
        Me.btbuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(46, 51)
        Me.btbuscar.Text = "&Buscar"
        Me.btbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'bteditar
        '
        Me.bteditar.Enabled = False
        Me.bteditar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bteditar.Image = Global.Celer.My.Resources.Resources.edit_file_icon__1_
        Me.bteditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bteditar.Name = "bteditar"
        Me.bteditar.Size = New System.Drawing.Size(41, 51)
        Me.bteditar.Text = "&Editar"
        Me.bteditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
        '
        'btcancelar
        '
        Me.btcancelar.Enabled = False
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
        'btanular
        '
        Me.btanular.Enabled = False
        Me.btanular.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btanular.Image = Global.Celer.My.Resources.Resources.Document_Delete_icon__1_
        Me.btanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btanular.Name = "btanular"
        Me.btanular.Size = New System.Drawing.Size(46, 51)
        Me.btanular.Text = "&Anular"
        Me.btanular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 54)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "OTRO SI"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(64, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(576, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "_________________________________________________________________________________" &
    ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Textcodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Gpotros_si)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 228)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'Textcodigo
        '
        Me.Textcodigo.BackColor = System.Drawing.SystemColors.Control
        Me.Textcodigo.Enabled = False
        Me.Textcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textcodigo.Location = New System.Drawing.Point(84, 22)
        Me.Textcodigo.Name = "Textcodigo"
        Me.Textcodigo.ReadOnly = True
        Me.Textcodigo.Size = New System.Drawing.Size(112, 21)
        Me.Textcodigo.TabIndex = 80017
        Me.Textcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 80018
        Me.Label3.Text = "Código:"
        '
        'Gpotros_si
        '
        Me.Gpotros_si.Controls.Add(Me.vigente)
        Me.Gpotros_si.Controls.Add(Me.Textvalor_si)
        Me.Gpotros_si.Controls.Add(Me.Label20)
        Me.Gpotros_si.Controls.Add(Me.Label22)
        Me.Gpotros_si.Controls.Add(Me.Label26)
        Me.Gpotros_si.Controls.Add(Me.fecha_ini_si)
        Me.Gpotros_si.Controls.Add(Me.fecha_fin_si)
        Me.Gpotros_si.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Gpotros_si.ForeColor = System.Drawing.Color.Black
        Me.Gpotros_si.Location = New System.Drawing.Point(5, 109)
        Me.Gpotros_si.Name = "Gpotros_si"
        Me.Gpotros_si.Size = New System.Drawing.Size(625, 113)
        Me.Gpotros_si.TabIndex = 80016
        Me.Gpotros_si.TabStop = False
        Me.Gpotros_si.Text = "Otros si"
        '
        'vigente
        '
        Me.vigente.AutoSize = True
        Me.vigente.Location = New System.Drawing.Point(498, 55)
        Me.vigente.Name = "vigente"
        Me.vigente.Size = New System.Drawing.Size(60, 20)
        Me.vigente.TabIndex = 80019
        Me.vigente.Text = "Activar"
        Me.vigente.UseVisualStyleBackColor = True
        '
        'Textvalor_si
        '
        Me.Textvalor_si.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textvalor_si.Location = New System.Drawing.Point(56, 22)
        Me.Textvalor_si.MaxLength = 15
        Me.Textvalor_si.Name = "Textvalor_si"
        Me.Textvalor_si.ReadOnly = True
        Me.Textvalor_si.Size = New System.Drawing.Size(124, 21)
        Me.Textvalor_si.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(6, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 15)
        Me.Label20.TabIndex = 181
        Me.Label20.Text = "Valor:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(412, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 15)
        Me.Label22.TabIndex = 172
        Me.Label22.Text = "Fecha Final"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(189, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 15)
        Me.Label26.TabIndex = 171
        Me.Label26.Text = "Fecha Inicio:"
        '
        'fecha_ini_si
        '
        Me.fecha_ini_si.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_ini_si.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_ini_si.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_si.Location = New System.Drawing.Point(281, 23)
        Me.fecha_ini_si.Name = "fecha_ini_si"
        Me.fecha_ini_si.Size = New System.Drawing.Size(121, 21)
        Me.fecha_ini_si.TabIndex = 1
        '
        'fecha_fin_si
        '
        Me.fecha_fin_si.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_fin_si.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_fin_si.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_si.Location = New System.Drawing.Point(498, 22)
        Me.fecha_fin_si.Name = "fecha_fin_si"
        Me.fecha_fin_si.Size = New System.Drawing.Size(115, 21)
        Me.fecha_fin_si.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.Textcodigo_contrato)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.textdescripcion)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(5, 49)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(624, 54)
        Me.GroupBox4.TabIndex = 131
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del contrato"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(202, 24)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(94, 15)
        Me.Label38.TabIndex = 60010
        Me.Label38.Text = "Nombre cliente:"
        '
        'Textcodigo_contrato
        '
        Me.Textcodigo_contrato.BackColor = System.Drawing.SystemColors.Control
        Me.Textcodigo_contrato.Enabled = False
        Me.Textcodigo_contrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textcodigo_contrato.Location = New System.Drawing.Point(79, 22)
        Me.Textcodigo_contrato.Name = "Textcodigo_contrato"
        Me.Textcodigo_contrato.ReadOnly = True
        Me.Textcodigo_contrato.Size = New System.Drawing.Size(112, 21)
        Me.Textcodigo_contrato.TabIndex = 99
        Me.Textcodigo_contrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Contrato:"
        '
        'textdescripcion
        '
        Me.textdescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textdescripcion.Location = New System.Drawing.Point(302, 22)
        Me.textdescripcion.Name = "textdescripcion"
        Me.textdescripcion.ReadOnly = True
        Me.textdescripcion.Size = New System.Drawing.Size(311, 21)
        Me.textdescripcion.TabIndex = 98
        Me.textdescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.search_b_icon
        Me.PictureBox1.Location = New System.Drawing.Point(15, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Form_Otro_Si
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(652, 342)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(668, 381)
        Me.MinimumSize = New System.Drawing.Size(668, 381)
        Me.Name = "Form_Otro_Si"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Gpotros_si.ResumeLayout(False)
        Me.Gpotros_si.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox4 As GroupBox
    Public WithEvents Textcodigo_contrato As TextBox
    Public WithEvents Label4 As Label
    Public WithEvents textdescripcion As TextBox
    Public WithEvents Gpotros_si As GroupBox
    Public WithEvents Textvalor_si As TextBox
    Public WithEvents Label20 As Label
    Public WithEvents Label22 As Label
    Public WithEvents Label26 As Label
    Public WithEvents fecha_ini_si As DateTimePicker
    Public WithEvents fecha_fin_si As DateTimePicker
    Public WithEvents Label38 As Label
    Public WithEvents Textcodigo As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents vigente As CheckBox
End Class
