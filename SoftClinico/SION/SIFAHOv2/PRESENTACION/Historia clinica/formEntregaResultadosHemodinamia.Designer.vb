<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntregaResultadosHemodinamia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formEntregaResultadosHemodinamia))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblCantidadPacientes = New System.Windows.Forms.Label()
        Me.dgvimagen = New System.Windows.Forms.DataGridView()
        Me.dgNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgEPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.solicitud = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgImagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdRealizados = New System.Windows.Forms.RadioButton()
        Me.rdPendiente = New System.Windows.Forms.RadioButton()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvimagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.medical_report_icon
        Me.PictureBox1.Location = New System.Drawing.Point(11, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10055
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 16)
        Me.Label1.TabIndex = 10053
        Me.Label1.Text = "ENTREGA DE RESULTADOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(53, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(940, 20)
        Me.Label2.TabIndex = 10054
        Me.Label2.Text = "_________________________________________________________________________________" &
    "____________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 562)
        Me.GroupBox1.TabIndex = 10056
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblCantidadPacientes)
        Me.GroupBox5.Controls.Add(Me.dgvimagen)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(10, 70)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1014, 486)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pacientes:"
        '
        'lblCantidadPacientes
        '
        Me.lblCantidadPacientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCantidadPacientes.AutoSize = True
        Me.lblCantidadPacientes.BackColor = System.Drawing.Color.White
        Me.lblCantidadPacientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblCantidadPacientes.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblCantidadPacientes.Location = New System.Drawing.Point(867, 14)
        Me.lblCantidadPacientes.Name = "lblCantidadPacientes"
        Me.lblCantidadPacientes.Size = New System.Drawing.Size(14, 15)
        Me.lblCantidadPacientes.TabIndex = 10060
        Me.lblCantidadPacientes.Text = "0"
        Me.lblCantidadPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvimagen
        '
        Me.dgvimagen.AllowUserToAddRows = False
        Me.dgvimagen.AllowUserToDeleteRows = False
        Me.dgvimagen.AllowUserToResizeColumns = False
        Me.dgvimagen.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvimagen.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvimagen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvimagen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvimagen.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvimagen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvimagen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgNombre, Me.dgEPS, Me.dgDescripcion, Me.dgArea, Me.dgFecha, Me.solicitud, Me.dgImagen})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvimagen.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvimagen.Location = New System.Drawing.Point(13, 32)
        Me.dgvimagen.MultiSelect = False
        Me.dgvimagen.Name = "dgvimagen"
        Me.dgvimagen.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvimagen.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvimagen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvimagen.Size = New System.Drawing.Size(995, 448)
        Me.dgvimagen.TabIndex = 19
        '
        'dgNombre
        '
        Me.dgNombre.Frozen = True
        Me.dgNombre.HeaderText = "Nombre"
        Me.dgNombre.Name = "dgNombre"
        Me.dgNombre.Width = 70
        '
        'dgEPS
        '
        Me.dgEPS.HeaderText = "EPS"
        Me.dgEPS.Name = "dgEPS"
        Me.dgEPS.Width = 53
        '
        'dgDescripcion
        '
        Me.dgDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgDescripcion.HeaderText = "Descripcion"
        Me.dgDescripcion.Name = "dgDescripcion"
        '
        'dgArea
        '
        Me.dgArea.HeaderText = "Area"
        Me.dgArea.Name = "dgArea"
        Me.dgArea.Width = 54
        '
        'dgFecha
        '
        Me.dgFecha.HeaderText = "Fecha"
        Me.dgFecha.Name = "dgFecha"
        Me.dgFecha.Width = 60
        '
        'solicitud
        '
        Me.solicitud.HeaderText = "Solicitud"
        Me.solicitud.Name = "solicitud"
        Me.solicitud.Text = "Ir a Solicitud"
        Me.solicitud.UseColumnTextForButtonValue = True
        Me.solicitud.Width = 56
        '
        'dgImagen
        '
        Me.dgImagen.Description = "+"
        Me.dgImagen.HeaderText = "Resultado"
        Me.dgImagen.Image = Global.Celer.My.Resources.Resources.Printermini_icon
        Me.dgImagen.Name = "dgImagen"
        Me.dgImagen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgImagen.Visible = False
        Me.dgImagen.Width = 60
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(792, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 10059
        Me.Label4.Text = "Examenes:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.txtBusqueda)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1014, 60)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtros de busqueda:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpFin)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtpInicio)
        Me.GroupBox3.Location = New System.Drawing.Point(490, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(312, 42)
        Me.GroupBox3.TabIndex = 10059
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango Fechas"
        '
        'dtpFin
        '
        Me.dtpFin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFin.Location = New System.Drawing.Point(206, 15)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(100, 21)
        Me.dtpFin.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(174, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Fin:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Inicio:"
        '
        'dtpInicio
        '
        Me.dtpInicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(49, 15)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(100, 21)
        Me.dtpInicio.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdRealizados)
        Me.GroupBox2.Controls.Add(Me.rdPendiente)
        Me.GroupBox2.Location = New System.Drawing.Point(808, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 42)
        Me.GroupBox2.TabIndex = 10058
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado de atención:"
        '
        'rdRealizados
        '
        Me.rdRealizados.AutoSize = True
        Me.rdRealizados.BackColor = System.Drawing.Color.White
        Me.rdRealizados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdRealizados.ForeColor = System.Drawing.Color.Blue
        Me.rdRealizados.Location = New System.Drawing.Point(101, 16)
        Me.rdRealizados.Name = "rdRealizados"
        Me.rdRealizados.Size = New System.Drawing.Size(87, 19)
        Me.rdRealizados.TabIndex = 10055
        Me.rdRealizados.Text = "Realizados"
        Me.rdRealizados.UseVisualStyleBackColor = False
        '
        'rdPendiente
        '
        Me.rdPendiente.AutoSize = True
        Me.rdPendiente.BackColor = System.Drawing.Color.White
        Me.rdPendiente.Checked = True
        Me.rdPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdPendiente.ForeColor = System.Drawing.Color.Green
        Me.rdPendiente.Location = New System.Drawing.Point(6, 16)
        Me.rdPendiente.Name = "rdPendiente"
        Me.rdPendiente.Size = New System.Drawing.Size(81, 19)
        Me.rdPendiente.TabIndex = 10053
        Me.rdPendiente.TabStop = True
        Me.rdPendiente.Text = "Pendiente"
        Me.rdPendiente.UseVisualStyleBackColor = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(76, 25)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(408, 21)
        Me.txtBusqueda.TabIndex = 10050
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 15)
        Me.Label10.TabIndex = 10048
        Me.Label10.Text = "Busqueda:"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 69
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "EPS"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 53
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Area"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 54
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 62
        '
        'formEntregaResultadosHemodinamia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1051, 616)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formEntregaResultadosHemodinamia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgvimagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgvimagen As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdRealizados As RadioButton
    Friend WithEvents rdPendiente As RadioButton
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lblCantidadPacientes As Label
    Protected WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents dgNombre As DataGridViewTextBoxColumn
    Friend WithEvents dgEPS As DataGridViewTextBoxColumn
    Friend WithEvents dgDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents dgArea As DataGridViewTextBoxColumn
    Friend WithEvents dgFecha As DataGridViewTextBoxColumn
    Friend WithEvents solicitud As DataGridViewButtonColumn
    Friend WithEvents dgImagen As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
