<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEstadisticaNotasAuditoria
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.fechaFin = New System.Windows.Forms.DateTimePicker()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboCargo = New System.Windows.Forms.ComboBox()
        Me.lbCargo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCreador = New System.Windows.Forms.RadioButton()
        Me.rbResponsable = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvInformeNota = New System.Windows.Forms.DataGridView()
        Me.dgDetalle = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.pnlAuditoria = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvNotaAuditoria = New System.Windows.Forms.DataGridView()
        Me.dgVer = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lbNombreResponsable = New System.Windows.Forms.Label()
        Me.lbNotas = New System.Windows.Forms.Label()
        Me.lbTotlPacientes = New System.Windows.Forms.Label()
        Me.lbPromedio = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvInformeNota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAuditoria.SuspendLayout()
        CType(Me.dgvNotaAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "INFORME DE NOTAS AUDITORIA"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.estudio
        Me.PictureBox1.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(45, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1010, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "_________________________________________________________________________________" &
    "______________________________________________________________"
        '
        'fechaInicio
        '
        Me.fechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaInicio.Location = New System.Drawing.Point(74, 18)
        Me.fechaInicio.Name = "fechaInicio"
        Me.fechaInicio.Size = New System.Drawing.Size(108, 21)
        Me.fechaInicio.TabIndex = 40
        '
        'fechaFin
        '
        Me.fechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaFin.Location = New System.Drawing.Point(238, 18)
        Me.fechaFin.Name = "fechaFin"
        Me.fechaFin.Size = New System.Drawing.Size(107, 21)
        Me.fechaFin.TabIndex = 41
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(80, 104)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(403, 21)
        Me.txtBusqueda.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(191, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Hasta"
        '
        'comboCargo
        '
        Me.comboCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboCargo.FormattingEnabled = True
        Me.comboCargo.Location = New System.Drawing.Point(827, 17)
        Me.comboCargo.Name = "comboCargo"
        Me.comboCargo.Size = New System.Drawing.Size(220, 23)
        Me.comboCargo.TabIndex = 45
        '
        'lbCargo
        '
        Me.lbCargo.AutoSize = True
        Me.lbCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCargo.Location = New System.Drawing.Point(781, 20)
        Me.lbCargo.Name = "lbCargo"
        Me.lbCargo.Size = New System.Drawing.Size(40, 15)
        Me.lbCargo.TabIndex = 46
        Me.lbCargo.Text = "Cargo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCreador)
        Me.GroupBox1.Controls.Add(Me.rbResponsable)
        Me.GroupBox1.Controls.Add(Me.fechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.fechaFin)
        Me.GroupBox1.Controls.Add(Me.lbCargo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.comboCargo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1079, 51)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'rbCreador
        '
        Me.rbCreador.AutoSize = True
        Me.rbCreador.Checked = True
        Me.rbCreador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCreador.Location = New System.Drawing.Point(416, 19)
        Me.rbCreador.Name = "rbCreador"
        Me.rbCreador.Size = New System.Drawing.Size(126, 19)
        Me.rbCreador.TabIndex = 48
        Me.rbCreador.TabStop = True
        Me.rbCreador.Text = "Creador de la nota"
        Me.rbCreador.UseVisualStyleBackColor = True
        '
        'rbResponsable
        '
        Me.rbResponsable.AutoSize = True
        Me.rbResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbResponsable.Location = New System.Drawing.Point(548, 20)
        Me.rbResponsable.Name = "rbResponsable"
        Me.rbResponsable.Size = New System.Drawing.Size(155, 19)
        Me.rbResponsable.TabIndex = 47
        Me.rbResponsable.Text = "Responsable de la nota"
        Me.rbResponsable.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Busqueda"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvInformeNota)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 153)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(617, 410)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        '
        'dgvInformeNota
        '
        Me.dgvInformeNota.AllowUserToAddRows = False
        Me.dgvInformeNota.AllowUserToDeleteRows = False
        Me.dgvInformeNota.AllowUserToResizeColumns = False
        Me.dgvInformeNota.AllowUserToResizeRows = False
        Me.dgvInformeNota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvInformeNota.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvInformeNota.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvInformeNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInformeNota.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgDetalle})
        Me.dgvInformeNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInformeNota.Location = New System.Drawing.Point(3, 16)
        Me.dgvInformeNota.MultiSelect = False
        Me.dgvInformeNota.Name = "dgvInformeNota"
        Me.dgvInformeNota.ReadOnly = True
        Me.dgvInformeNota.RowHeadersVisible = False
        Me.dgvInformeNota.Size = New System.Drawing.Size(611, 391)
        Me.dgvInformeNota.TabIndex = 32
        '
        'dgDetalle
        '
        Me.dgDetalle.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgDetalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgDetalle.HeaderText = "Detalle"
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
        Me.dgDetalle.Text = "Detalle"
        Me.dgDetalle.UseColumnTextForLinkValue = True
        Me.dgDetalle.Visible = False
        Me.dgDetalle.VisitedLinkColor = System.Drawing.Color.Purple
        Me.dgDetalle.Width = 46
        '
        'pnlAuditoria
        '
        Me.pnlAuditoria.Controls.Add(Me.Button1)
        Me.pnlAuditoria.Controls.Add(Me.dgvNotaAuditoria)
        Me.pnlAuditoria.Location = New System.Drawing.Point(622, 169)
        Me.pnlAuditoria.Name = "pnlAuditoria"
        Me.pnlAuditoria.Size = New System.Drawing.Size(463, 391)
        Me.pnlAuditoria.TabIndex = 10065
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(440, -1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 21)
        Me.Button1.TabIndex = 10074
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'dgvNotaAuditoria
        '
        Me.dgvNotaAuditoria.AllowUserToAddRows = False
        Me.dgvNotaAuditoria.AllowUserToDeleteRows = False
        Me.dgvNotaAuditoria.AllowUserToResizeColumns = False
        Me.dgvNotaAuditoria.AllowUserToResizeRows = False
        Me.dgvNotaAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvNotaAuditoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvNotaAuditoria.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvNotaAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotaAuditoria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgVer})
        Me.dgvNotaAuditoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNotaAuditoria.Location = New System.Drawing.Point(0, 0)
        Me.dgvNotaAuditoria.Name = "dgvNotaAuditoria"
        Me.dgvNotaAuditoria.ReadOnly = True
        Me.dgvNotaAuditoria.RowHeadersVisible = False
        Me.dgvNotaAuditoria.Size = New System.Drawing.Size(463, 391)
        Me.dgvNotaAuditoria.TabIndex = 2
        '
        'dgVer
        '
        Me.dgVer.HeaderText = "Ver"
        Me.dgVer.Image = Global.Celer.My.Resources.Resources.Image_JPEG_icon
        Me.dgVer.Name = "dgVer"
        Me.dgVer.ReadOnly = True
        Me.dgVer.Visible = False
        Me.dgVer.Width = 29
        '
        'lbNombreResponsable
        '
        Me.lbNombreResponsable.AutoSize = True
        Me.lbNombreResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNombreResponsable.Location = New System.Drawing.Point(626, 150)
        Me.lbNombreResponsable.Name = "lbNombreResponsable"
        Me.lbNombreResponsable.Size = New System.Drawing.Size(14, 15)
        Me.lbNombreResponsable.TabIndex = 10066
        Me.lbNombreResponsable.Text = "A"
        Me.lbNombreResponsable.Visible = False
        '
        'lbNotas
        '
        Me.lbNotas.AutoSize = True
        Me.lbNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNotas.Location = New System.Drawing.Point(526, 108)
        Me.lbNotas.Name = "lbNotas"
        Me.lbNotas.Size = New System.Drawing.Size(69, 15)
        Me.lbNotas.TabIndex = 10067
        Me.lbNotas.Text = "Total Notas"
        '
        'lbTotlPacientes
        '
        Me.lbTotlPacientes.AutoSize = True
        Me.lbTotlPacientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotlPacientes.Location = New System.Drawing.Point(687, 108)
        Me.lbTotlPacientes.Name = "lbTotlPacientes"
        Me.lbTotlPacientes.Size = New System.Drawing.Size(91, 15)
        Me.lbTotlPacientes.TabIndex = 10068
        Me.lbTotlPacientes.Text = "Total Pacientes"
        '
        'lbPromedio
        '
        Me.lbPromedio.AutoSize = True
        Me.lbPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPromedio.Location = New System.Drawing.Point(844, 108)
        Me.lbPromedio.Name = "lbPromedio"
        Me.lbPromedio.Size = New System.Drawing.Size(91, 15)
        Me.lbPromedio.TabIndex = 10069
        Me.lbPromedio.Text = "Total Pacientes"
        '
        'FormEstadisticaNotasAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1088, 567)
        Me.Controls.Add(Me.lbPromedio)
        Me.Controls.Add(Me.lbTotlPacientes)
        Me.Controls.Add(Me.lbNotas)
        Me.Controls.Add(Me.lbNombreResponsable)
        Me.Controls.Add(Me.pnlAuditoria)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(958, 606)
        Me.Name = "FormEstadisticaNotasAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvInformeNota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAuditoria.ResumeLayout(False)
        CType(Me.dgvNotaAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents fechaInicio As DateTimePicker
    Friend WithEvents fechaFin As DateTimePicker
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents comboCargo As ComboBox
    Friend WithEvents lbCargo As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbCreador As RadioButton
    Friend WithEvents rbResponsable As RadioButton
    Public WithEvents dgvInformeNota As DataGridView
    Friend WithEvents pnlAuditoria As Panel
    Friend WithEvents dgvNotaAuditoria As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents lbNombreResponsable As Label
    Friend WithEvents dgDetalle As DataGridViewLinkColumn
    Friend WithEvents dgVer As DataGridViewImageColumn
    Friend WithEvents lbNotas As Label
    Friend WithEvents lbTotlPacientes As Label
    Friend WithEvents lbPromedio As Label
End Class
