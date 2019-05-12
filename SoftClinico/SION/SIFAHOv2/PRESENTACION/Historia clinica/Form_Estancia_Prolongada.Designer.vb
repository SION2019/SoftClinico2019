<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Estancia_Prolongada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Estancia_Prolongada))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbomedico = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTEPS = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtfechaingreso = New System.Windows.Forms.TextBox()
        Me.txtfecha = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtregistro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtidentificacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtresultado = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtjustificacion = New System.Windows.Forms.RichTextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvestancia = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtconducta = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvestancia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "ESTANCIA PROLONGADA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(49, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(979, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 42
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
        Me.btnuevo.Visible = False
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
        'btimprimir
        '
        Me.btimprimir.Enabled = False
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
        Me.GroupBox1.Controls.Add(Me.cbomedico)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXTEPS)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtfechaingreso)
        Me.GroupBox1.Controls.Add(Me.txtfecha)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtregistro)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidentificacion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtpaciente)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1026, 76)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Basicos"
        '
        'cbomedico
        '
        Me.cbomedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomedico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbomedico.FormattingEnabled = True
        Me.cbomedico.Location = New System.Drawing.Point(712, 45)
        Me.cbomedico.Name = "cbomedico"
        Me.cbomedico.Size = New System.Drawing.Size(303, 23)
        Me.cbomedico.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(192, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 15)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "EPS:"
        '
        'TXTEPS
        '
        Me.TXTEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TXTEPS.Location = New System.Drawing.Point(230, 46)
        Me.TXTEPS.Name = "TXTEPS"
        Me.TXTEPS.ReadOnly = True
        Me.TXTEPS.Size = New System.Drawing.Size(410, 21)
        Me.TXTEPS.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(659, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Médico:"
        '
        'txtfechaingreso
        '
        Me.txtfechaingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechaingreso.Location = New System.Drawing.Point(498, 20)
        Me.txtfechaingreso.Name = "txtfechaingreso"
        Me.txtfechaingreso.ReadOnly = True
        Me.txtfechaingreso.Size = New System.Drawing.Size(127, 21)
        Me.txtfechaingreso.TabIndex = 16
        '
        'txtfecha
        '
        Me.txtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfecha.Location = New System.Drawing.Point(72, 46)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.ReadOnly = True
        Me.txtfecha.Size = New System.Drawing.Size(105, 21)
        Me.txtfecha.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(875, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Registro:"
        '
        'txtregistro
        '
        Me.txtregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtregistro.Location = New System.Drawing.Point(934, 20)
        Me.txtregistro.Name = "txtregistro"
        Me.txtregistro.ReadOnly = True
        Me.txtregistro.Size = New System.Drawing.Size(81, 21)
        Me.txtregistro.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(404, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha Ingreso:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(634, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Indentificación:"
        '
        'txtidentificacion
        '
        Me.txtidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentificacion.Location = New System.Drawing.Point(724, 20)
        Me.txtidentificacion.Name = "txtidentificacion"
        Me.txtidentificacion.ReadOnly = True
        Me.txtidentificacion.Size = New System.Drawing.Size(142, 21)
        Me.txtidentificacion.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Paciente:"
        '
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(72, 20)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.ReadOnly = True
        Me.txtpaciente.Size = New System.Drawing.Size(325, 21)
        Me.txtpaciente.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtresultado)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 253)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1026, 71)
        Me.GroupBox3.TabIndex = 45
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Resultado de exámenes de importancia"
        '
        'txtresultado
        '
        Me.txtresultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtresultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtresultado.Location = New System.Drawing.Point(3, 17)
        Me.txtresultado.Name = "txtresultado"
        Me.txtresultado.Size = New System.Drawing.Size(1020, 51)
        Me.txtresultado.TabIndex = 1
        Me.txtresultado.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtjustificacion)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 145)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1026, 101)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Justificación de estancia prolongada"
        '
        'txtjustificacion
        '
        Me.txtjustificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtjustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtjustificacion.Location = New System.Drawing.Point(3, 17)
        Me.txtjustificacion.Name = "txtjustificacion"
        Me.txtjustificacion.Size = New System.Drawing.Size(1020, 81)
        Me.txtjustificacion.TabIndex = 1
        Me.txtjustificacion.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvestancia)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(9, 330)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(508, 188)
        Me.GroupBox4.TabIndex = 46
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Diagnósticos"
        '
        'dgvestancia
        '
        Me.dgvestancia.AllowUserToAddRows = False
        Me.dgvestancia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvestancia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvestancia.BackgroundColor = System.Drawing.Color.White
        Me.dgvestancia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvestancia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion})
        Me.dgvestancia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvestancia.Location = New System.Drawing.Point(3, 17)
        Me.dgvestancia.Name = "dgvestancia"
        Me.dgvestancia.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvestancia.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvestancia.Size = New System.Drawing.Size(502, 168)
        Me.dgvestancia.TabIndex = 0
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 67
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 88
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtconducta)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(523, 330)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(511, 187)
        Me.GroupBox5.TabIndex = 47
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Conducta a seguir"
        '
        'txtconducta
        '
        Me.txtconducta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtconducta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtconducta.Location = New System.Drawing.Point(3, 17)
        Me.txtconducta.Name = "txtconducta"
        Me.txtconducta.Size = New System.Drawing.Size(505, 167)
        Me.txtconducta.TabIndex = 1
        Me.txtconducta.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.aplica
        Me.PictureBox1.Location = New System.Drawing.Point(9, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 88
        '
        'Form_Estancia_Prolongada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "Form_Estancia_Prolongada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvestancia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtfechaingreso As TextBox
    Friend WithEvents txtfecha As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtregistro As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtidentificacion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtpaciente As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtresultado As RichTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtjustificacion As RichTextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvestancia As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtconducta As RichTextBox
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTEPS As TextBox
    Friend WithEvents cbomedico As ComboBox
End Class
