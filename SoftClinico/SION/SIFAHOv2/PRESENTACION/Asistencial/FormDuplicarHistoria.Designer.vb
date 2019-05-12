<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDuplicarHistoria
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDuplicarHistoria))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btDuplicar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtEdadOrigen = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAreaOrigen = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtGeneroOrigen = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFechaOrigen = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtRegistroOrigen = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtpacienteOrigen = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtidentiOrigen = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvFactura = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtAdministradora = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEdadDestino = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btbuscarpaciente = New System.Windows.Forms.Button()
        Me.txtAreaDestino = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGeneroDestino = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaDestino = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtRegistroDestino = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpacienteDestino = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtidentiDestino = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "AGENTE D.H.C"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(53, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Files_Copy_File_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(11, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btDuplicar, Me.ToolStripSeparator1, Me.btcancelar, Me.ToolStripSeparator6, Me.btimprimir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 503)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btDuplicar
        '
        Me.btDuplicar.Enabled = False
        Me.btDuplicar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDuplicar.Image = Global.Celer.My.Resources.Resources.Files_Copy_File_icon__1_
        Me.btDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btDuplicar.Name = "btDuplicar"
        Me.btDuplicar.Size = New System.Drawing.Size(43, 51)
        Me.btDuplicar.Text = "&Iniciar"
        Me.btDuplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
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
        'btimprimir
        '
        Me.btimprimir.Enabled = False
        Me.btimprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btimprimir.Image = Global.Celer.My.Resources.Resources.Printer_icon
        Me.btimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(57, 51)
        Me.btimprimir.Text = "&Imprimir"
        Me.btimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtBuscar)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(903, 448)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtEdadOrigen)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.txtAreaOrigen)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtGeneroOrigen)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtFechaOrigen)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TxtRegistroOrigen)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtpacienteOrigen)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtidentiOrigen)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 115)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(890, 74)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Admisión de Origén"
        '
        'txtEdadOrigen
        '
        Me.txtEdadOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEdadOrigen.Location = New System.Drawing.Point(776, 46)
        Me.txtEdadOrigen.Name = "txtEdadOrigen"
        Me.txtEdadOrigen.ReadOnly = True
        Me.txtEdadOrigen.Size = New System.Drawing.Size(102, 21)
        Me.txtEdadOrigen.TabIndex = 53
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(733, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 15)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Edad:"
        '
        'txtAreaOrigen
        '
        Me.txtAreaOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAreaOrigen.Location = New System.Drawing.Point(558, 45)
        Me.txtAreaOrigen.Name = "txtAreaOrigen"
        Me.txtAreaOrigen.ReadOnly = True
        Me.txtAreaOrigen.Size = New System.Drawing.Size(143, 21)
        Me.txtAreaOrigen.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(452, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 15)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Area de Servicio:"
        '
        'txtGeneroOrigen
        '
        Me.txtGeneroOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtGeneroOrigen.Location = New System.Drawing.Point(303, 46)
        Me.txtGeneroOrigen.Name = "txtGeneroOrigen"
        Me.txtGeneroOrigen.ReadOnly = True
        Me.txtGeneroOrigen.Size = New System.Drawing.Size(136, 21)
        Me.txtGeneroOrigen.TabIndex = 45
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(215, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Genero:"
        '
        'txtFechaOrigen
        '
        Me.txtFechaOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtFechaOrigen.Location = New System.Drawing.Point(108, 43)
        Me.txtFechaOrigen.Mask = "00/00/0000"
        Me.txtFechaOrigen.Name = "txtFechaOrigen"
        Me.txtFechaOrigen.ReadOnly = True
        Me.txtFechaOrigen.Size = New System.Drawing.Size(101, 21)
        Me.txtFechaOrigen.TabIndex = 43
        Me.txtFechaOrigen.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 15)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Fecha Admisión:"
        '
        'TxtRegistroOrigen
        '
        Me.TxtRegistroOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtRegistroOrigen.Location = New System.Drawing.Point(108, 16)
        Me.TxtRegistroOrigen.Name = "TxtRegistroOrigen"
        Me.TxtRegistroOrigen.ReadOnly = True
        Me.TxtRegistroOrigen.Size = New System.Drawing.Size(101, 21)
        Me.TxtRegistroOrigen.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 15)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Registro:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(452, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Paciente:"
        '
        'txtpacienteOrigen
        '
        Me.txtpacienteOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpacienteOrigen.Location = New System.Drawing.Point(558, 19)
        Me.txtpacienteOrigen.Name = "txtpacienteOrigen"
        Me.txtpacienteOrigen.ReadOnly = True
        Me.txtpacienteOrigen.Size = New System.Drawing.Size(320, 21)
        Me.txtpacienteOrigen.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(215, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Identificación:"
        '
        'txtidentiOrigen
        '
        Me.txtidentiOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentiOrigen.Location = New System.Drawing.Point(303, 20)
        Me.txtidentiOrigen.Name = "txtidentiOrigen"
        Me.txtidentiOrigen.ReadOnly = True
        Me.txtidentiOrigen.Size = New System.Drawing.Size(136, 21)
        Me.txtidentiOrigen.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 195)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 15)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtBuscar.Location = New System.Drawing.Point(63, 193)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(830, 21)
        Me.txtBuscar.TabIndex = 50
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvFactura)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 214)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(890, 228)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Facturas"
        '
        'dgvFactura
        '
        Me.dgvFactura.AllowUserToAddRows = False
        Me.dgvFactura.AllowUserToDeleteRows = False
        Me.dgvFactura.AllowUserToResizeColumns = False
        Me.dgvFactura.AllowUserToResizeRows = False
        Me.dgvFactura.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFactura.Location = New System.Drawing.Point(3, 17)
        Me.dgvFactura.Name = "dgvFactura"
        Me.dgvFactura.RowHeadersVisible = False
        Me.dgvFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFactura.ShowCellErrors = False
        Me.dgvFactura.Size = New System.Drawing.Size(884, 208)
        Me.dgvFactura.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtAdministradora)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtEdadDestino)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.btbuscarpaciente)
        Me.GroupBox2.Controls.Add(Me.txtAreaDestino)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtGeneroDestino)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFechaDestino)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtRegistroDestino)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtpacienteDestino)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtidentiDestino)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(890, 101)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Admisión de Destino"
        '
        'txtAdministradora
        '
        Me.txtAdministradora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAdministradora.Location = New System.Drawing.Point(108, 71)
        Me.txtAdministradora.Name = "txtAdministradora"
        Me.txtAdministradora.ReadOnly = True
        Me.txtAdministradora.Size = New System.Drawing.Size(594, 21)
        Me.txtAdministradora.TabIndex = 53
        Me.txtAdministradora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(93, 15)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Administradora:"
        '
        'txtEdadDestino
        '
        Me.txtEdadDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEdadDestino.Location = New System.Drawing.Point(777, 45)
        Me.txtEdadDestino.Name = "txtEdadDestino"
        Me.txtEdadDestino.ReadOnly = True
        Me.txtEdadDestino.Size = New System.Drawing.Size(102, 21)
        Me.txtEdadDestino.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(734, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Edad:"
        '
        'btbuscarpaciente
        '
        Me.btbuscarpaciente.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarpaciente.Location = New System.Drawing.Point(859, 17)
        Me.btbuscarpaciente.Name = "btbuscarpaciente"
        Me.btbuscarpaciente.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarpaciente.TabIndex = 49
        Me.btbuscarpaciente.UseVisualStyleBackColor = True
        '
        'txtAreaDestino
        '
        Me.txtAreaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAreaDestino.Location = New System.Drawing.Point(558, 45)
        Me.txtAreaDestino.Name = "txtAreaDestino"
        Me.txtAreaDestino.ReadOnly = True
        Me.txtAreaDestino.Size = New System.Drawing.Size(143, 21)
        Me.txtAreaDestino.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(452, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 15)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Area de Servicio:"
        '
        'txtGeneroDestino
        '
        Me.txtGeneroDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtGeneroDestino.Location = New System.Drawing.Point(303, 46)
        Me.txtGeneroDestino.Name = "txtGeneroDestino"
        Me.txtGeneroDestino.ReadOnly = True
        Me.txtGeneroDestino.Size = New System.Drawing.Size(136, 21)
        Me.txtGeneroDestino.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(215, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Genero:"
        '
        'txtFechaDestino
        '
        Me.txtFechaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtFechaDestino.Location = New System.Drawing.Point(108, 43)
        Me.txtFechaDestino.Mask = "00/00/0000"
        Me.txtFechaDestino.Name = "txtFechaDestino"
        Me.txtFechaDestino.ReadOnly = True
        Me.txtFechaDestino.Size = New System.Drawing.Size(101, 21)
        Me.txtFechaDestino.TabIndex = 43
        Me.txtFechaDestino.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 15)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Fecha Admisión:"
        '
        'TxtRegistroDestino
        '
        Me.TxtRegistroDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtRegistroDestino.Location = New System.Drawing.Point(108, 16)
        Me.TxtRegistroDestino.Name = "TxtRegistroDestino"
        Me.TxtRegistroDestino.ReadOnly = True
        Me.TxtRegistroDestino.Size = New System.Drawing.Size(101, 21)
        Me.TxtRegistroDestino.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Registro:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(452, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Paciente:"
        '
        'txtpacienteDestino
        '
        Me.txtpacienteDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpacienteDestino.Location = New System.Drawing.Point(558, 19)
        Me.txtpacienteDestino.Name = "txtpacienteDestino"
        Me.txtpacienteDestino.ReadOnly = True
        Me.txtpacienteDestino.Size = New System.Drawing.Size(297, 21)
        Me.txtpacienteDestino.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(215, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Identificación:"
        '
        'txtidentiDestino
        '
        Me.txtidentiDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentiDestino.Location = New System.Drawing.Point(303, 20)
        Me.txtidentiDestino.Name = "txtidentiDestino"
        Me.txtidentiDestino.ReadOnly = True
        Me.txtidentiDestino.Size = New System.Drawing.Size(136, 21)
        Me.txtidentiDestino.TabIndex = 27
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código CUPS"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 89
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción Servicio"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 480
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dias"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 34
        '
        'FormDuplicarHistoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 557)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormDuplicarHistoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btDuplicar As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label5 As Label
    Public WithEvents txtpacienteDestino As TextBox
    Public WithEvents Label6 As Label
    Public WithEvents txtidentiDestino As TextBox
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDateTimePickerColumn1 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewDateTimePickerColumn2 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents Label4 As Label
    Public WithEvents TxtRegistroDestino As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents txtAreaDestino As TextBox
    Public WithEvents Label8 As Label
    Public WithEvents txtGeneroDestino As TextBox
    Public WithEvents Label7 As Label
    Friend WithEvents txtFechaDestino As MaskedTextBox
    Public WithEvents btbuscarpaciente As Button
    Friend WithEvents GroupBox4 As GroupBox
    Public WithEvents txtEdadDestino As TextBox
    Public WithEvents Label15 As Label
    Public WithEvents dgvFactura As DataGridView
    Public WithEvents Label17 As Label
    Public WithEvents txtBuscar As TextBox
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents txtEdadOrigen As TextBox
    Public WithEvents Label16 As Label
    Public WithEvents txtAreaOrigen As TextBox
    Public WithEvents Label9 As Label
    Public WithEvents txtGeneroOrigen As TextBox
    Public WithEvents Label10 As Label
    Friend WithEvents txtFechaOrigen As MaskedTextBox
    Public WithEvents Label11 As Label
    Public WithEvents TxtRegistroOrigen As TextBox
    Public WithEvents Label12 As Label
    Public WithEvents Label13 As Label
    Public WithEvents txtpacienteOrigen As TextBox
    Public WithEvents Label14 As Label
    Public WithEvents txtidentiOrigen As TextBox
    Public WithEvents txtAdministradora As TextBox
    Public WithEvents Label18 As Label
End Class
