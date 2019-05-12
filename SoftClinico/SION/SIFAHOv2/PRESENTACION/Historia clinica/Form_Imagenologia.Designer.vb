<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Imagenologia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Imagenologia))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.busquedaPaciente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.selrealizado = New System.Windows.Forms.RadioButton()
        Me.comboAreaServicio = New System.Windows.Forms.ComboBox()
        Me.selpendiente = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GbProcedencia = New System.Windows.Forms.GroupBox()
        Me.rbExterno = New System.Windows.Forms.RadioButton()
        Me.rbInterno = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dgvimagen = New System.Windows.Forms.DataGridView()
        Me.npaciente = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCodigoOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCodigoProcedimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCodigoEspecialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTipoExamen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgEPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgAbrirAtencion = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgImagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.abrirlaboratorio = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgImprimir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgEnviar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GbProcedencia.SuspendLayout()
        CType(Me.dgvimagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 10049
        Me.Label1.Text = "IMAGENOLOGIA"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1117, 540)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 15)
        Me.Label4.TabIndex = 10056
        Me.Label4.Text = "Cantidad de Pacientes:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(334, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 10051
        Me.Label3.Text = "Área de servicio:"
        '
        'busquedaPaciente
        '
        Me.busquedaPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.busquedaPaciente.Location = New System.Drawing.Point(76, 25)
        Me.busquedaPaciente.Name = "busquedaPaciente"
        Me.busquedaPaciente.Size = New System.Drawing.Size(240, 21)
        Me.busquedaPaciente.TabIndex = 10050
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
        'selrealizado
        '
        Me.selrealizado.AutoSize = True
        Me.selrealizado.BackColor = System.Drawing.Color.White
        Me.selrealizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selrealizado.ForeColor = System.Drawing.Color.Blue
        Me.selrealizado.Location = New System.Drawing.Point(85, 16)
        Me.selrealizado.Name = "selrealizado"
        Me.selrealizado.Size = New System.Drawing.Size(87, 19)
        Me.selrealizado.TabIndex = 10055
        Me.selrealizado.Text = "Realizados"
        Me.selrealizado.UseVisualStyleBackColor = False
        Me.selrealizado.Visible = False
        '
        'comboAreaServicio
        '
        Me.comboAreaServicio.BackColor = System.Drawing.Color.White
        Me.comboAreaServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAreaServicio.Enabled = False
        Me.comboAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAreaServicio.FormattingEnabled = True
        Me.comboAreaServicio.Location = New System.Drawing.Point(429, 23)
        Me.comboAreaServicio.Name = "comboAreaServicio"
        Me.comboAreaServicio.Size = New System.Drawing.Size(187, 23)
        Me.comboAreaServicio.TabIndex = 10052
        '
        'selpendiente
        '
        Me.selpendiente.AutoSize = True
        Me.selpendiente.BackColor = System.Drawing.Color.White
        Me.selpendiente.Checked = True
        Me.selpendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selpendiente.ForeColor = System.Drawing.Color.Green
        Me.selpendiente.Location = New System.Drawing.Point(6, 16)
        Me.selpendiente.Name = "selpendiente"
        Me.selpendiente.Size = New System.Drawing.Size(81, 19)
        Me.selpendiente.TabIndex = 10053
        Me.selpendiente.TabStop = True
        Me.selpendiente.Text = "Pendiente"
        Me.selpendiente.UseVisualStyleBackColor = False
        Me.selpendiente.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(53, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1234, 20)
        Me.Label2.TabIndex = 10050
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______________"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.selrealizado)
        Me.GroupBox2.Controls.Add(Me.selpendiente)
        Me.GroupBox2.Location = New System.Drawing.Point(1095, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 42)
        Me.GroupBox2.TabIndex = 10058
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado de atención:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GbProcedencia)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.dtFechaFin)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.dtFechaInicio)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.comboAreaServicio)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.busquedaPaciente)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1276, 54)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtros de busqueda:"
        '
        'GbProcedencia
        '
        Me.GbProcedencia.Controls.Add(Me.rbExterno)
        Me.GbProcedencia.Controls.Add(Me.rbInterno)
        Me.GbProcedencia.Location = New System.Drawing.Point(933, 9)
        Me.GbProcedencia.Name = "GbProcedencia"
        Me.GbProcedencia.Size = New System.Drawing.Size(151, 42)
        Me.GbProcedencia.TabIndex = 10059
        Me.GbProcedencia.TabStop = False
        Me.GbProcedencia.Text = "Procedencia:"
        '
        'rbExterno
        '
        Me.rbExterno.AutoSize = True
        Me.rbExterno.BackColor = System.Drawing.Color.White
        Me.rbExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbExterno.ForeColor = System.Drawing.Color.Blue
        Me.rbExterno.Location = New System.Drawing.Point(76, 16)
        Me.rbExterno.Name = "rbExterno"
        Me.rbExterno.Size = New System.Drawing.Size(67, 19)
        Me.rbExterno.TabIndex = 10055
        Me.rbExterno.Text = "Externo"
        Me.rbExterno.UseVisualStyleBackColor = False
        '
        'rbInterno
        '
        Me.rbInterno.AutoSize = True
        Me.rbInterno.BackColor = System.Drawing.Color.White
        Me.rbInterno.Checked = True
        Me.rbInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbInterno.ForeColor = System.Drawing.Color.Green
        Me.rbInterno.Location = New System.Drawing.Point(8, 16)
        Me.rbInterno.Name = "rbInterno"
        Me.rbInterno.Size = New System.Drawing.Size(63, 19)
        Me.rbInterno.TabIndex = 10053
        Me.rbInterno.TabStop = True
        Me.rbInterno.Text = "Interno"
        Me.rbInterno.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(788, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 10062
        Me.Label6.Text = "Hasta:"
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Enabled = False
        Me.dtFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(834, 25)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(85, 21)
        Me.dtFechaFin.TabIndex = 10061
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(637, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 10060
        Me.Label5.Text = "Desde:"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Enabled = False
        Me.dtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(685, 25)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(85, 21)
        Me.dtFechaInicio.TabIndex = 10059
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
        Me.dgvimagen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgRegistro, Me.dgCodigoOrden, Me.dgCodigoProcedimiento, Me.dgCodigoEspecialidad, Me.dgTipoExamen, Me.dgNombre, Me.dgEPS, Me.dgDescripcion, Me.dgArea, Me.dgFecha, Me.dgAbrirAtencion, Me.dgImagen, Me.abrirlaboratorio, Me.dgImprimir, Me.dgEnviar})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvimagen.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvimagen.Location = New System.Drawing.Point(13, 20)
        Me.dgvimagen.Name = "dgvimagen"
        Me.dgvimagen.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvimagen.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvimagen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvimagen.Size = New System.Drawing.Size(1264, 438)
        Me.dgvimagen.TabIndex = 19
        '
        'npaciente
        '
        Me.npaciente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.npaciente.AutoSize = True
        Me.npaciente.BackColor = System.Drawing.Color.White
        Me.npaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.npaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.npaciente.Location = New System.Drawing.Point(1264, 540)
        Me.npaciente.Name = "npaciente"
        Me.npaciente.Size = New System.Drawing.Size(14, 15)
        Me.npaciente.TabIndex = 10058
        Me.npaciente.Text = "0"
        Me.npaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgvimagen)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(10, 70)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1276, 464)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pacientes:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.npaciente)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1292, 562)
        Me.GroupBox1.TabIndex = 10052
        Me.GroupBox1.TabStop = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Description = "+"
        Me.DataGridViewImageColumn1.HeaderText = "Resultado"
        Me.DataGridViewImageColumn1.Image = Global.Celer.My.Resources.Resources._new
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.Width = 61
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = "Imprimir solicitud"
        Me.DataGridViewImageColumn2.Image = Global.Celer.My.Resources.Resources.Printermini2_icon
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.Width = 80
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Documents_X_Ray_Hand_icon1
        Me.PictureBox1.Location = New System.Drawing.Point(11, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10051
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 69
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "EPS"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 53
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 88
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "Area"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 54
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 62
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 62
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "EPS"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 53
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 88
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Area"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 54
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 62
        '
        'dgRegistro
        '
        Me.dgRegistro.Frozen = True
        Me.dgRegistro.HeaderText = "Registro"
        Me.dgRegistro.Name = "dgRegistro"
        Me.dgRegistro.Visible = False
        Me.dgRegistro.Width = 53
        '
        'dgCodigoOrden
        '
        Me.dgCodigoOrden.Frozen = True
        Me.dgCodigoOrden.HeaderText = "Codigo Orden"
        Me.dgCodigoOrden.Name = "dgCodigoOrden"
        Me.dgCodigoOrden.Visible = False
        Me.dgCodigoOrden.Width = 80
        '
        'dgCodigoProcedimiento
        '
        Me.dgCodigoProcedimiento.Frozen = True
        Me.dgCodigoProcedimiento.HeaderText = "Codigo Procedimiento"
        Me.dgCodigoProcedimiento.Name = "dgCodigoProcedimiento"
        Me.dgCodigoProcedimiento.Visible = False
        Me.dgCodigoProcedimiento.Width = 119
        '
        'dgCodigoEspecialidad
        '
        Me.dgCodigoEspecialidad.Frozen = True
        Me.dgCodigoEspecialidad.HeaderText = "Codigo Especialidad"
        Me.dgCodigoEspecialidad.Name = "dgCodigoEspecialidad"
        Me.dgCodigoEspecialidad.Visible = False
        Me.dgCodigoEspecialidad.Width = 109
        '
        'dgTipoExamen
        '
        Me.dgTipoExamen.Frozen = True
        Me.dgTipoExamen.HeaderText = "Tipo Examen"
        Me.dgTipoExamen.Name = "dgTipoExamen"
        Me.dgTipoExamen.Visible = False
        Me.dgTipoExamen.Width = 75
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
        Me.dgDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgDescripcion.HeaderText = "Descripcion"
        Me.dgDescripcion.Name = "dgDescripcion"
        Me.dgDescripcion.Width = 88
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
        'dgAbrirAtencion
        '
        Me.dgAbrirAtencion.HeaderText = "Abrir Atención"
        Me.dgAbrirAtencion.Name = "dgAbrirAtencion"
        Me.dgAbrirAtencion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAbrirAtencion.Text = "Abrir Atención"
        Me.dgAbrirAtencion.UseColumnTextForButtonValue = True
        Me.dgAbrirAtencion.Width = 82
        '
        'dgImagen
        '
        Me.dgImagen.Description = "+"
        Me.dgImagen.HeaderText = "Resultado"
        Me.dgImagen.Image = Global.Celer.My.Resources.Resources._new
        Me.dgImagen.Name = "dgImagen"
        Me.dgImagen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgImagen.Width = 60
        '
        'abrirlaboratorio
        '
        Me.abrirlaboratorio.HeaderText = "Abrir Laboratorio"
        Me.abrirlaboratorio.Name = "abrirlaboratorio"
        Me.abrirlaboratorio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.abrirlaboratorio.Text = "Abrir Laboratorio"
        Me.abrirlaboratorio.UseColumnTextForButtonValue = True
        Me.abrirlaboratorio.Width = 95
        '
        'dgImprimir
        '
        Me.dgImprimir.HeaderText = "Imprimir solicitud"
        Me.dgImprimir.Image = Global.Celer.My.Resources.Resources.Printermini_icon
        Me.dgImprimir.Name = "dgImprimir"
        Me.dgImprimir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgImprimir.Width = 98
        '
        'dgEnviar
        '
        Me.dgEnviar.HeaderText = "Enviar"
        Me.dgEnviar.Name = "dgEnviar"
        Me.dgEnviar.Width = 44
        '
        'Form_Imagenologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "Form_Imagenologia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GbProcedencia.ResumeLayout(False)
        Me.GbProcedencia.PerformLayout()
        CType(Me.dgvimagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Protected WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents busquedaPaciente As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents selrealizado As RadioButton
    Friend WithEvents comboAreaServicio As ComboBox
    Friend WithEvents selpendiente As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvimagen As DataGridView
    Friend WithEvents npaciente As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtFechaFin As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtFechaInicio As DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents GbProcedencia As GroupBox
    Friend WithEvents rbExterno As RadioButton
    Friend WithEvents rbInterno As RadioButton
    Friend WithEvents dgRegistro As DataGridViewTextBoxColumn
    Friend WithEvents dgCodigoOrden As DataGridViewTextBoxColumn
    Friend WithEvents dgCodigoProcedimiento As DataGridViewTextBoxColumn
    Friend WithEvents dgCodigoEspecialidad As DataGridViewTextBoxColumn
    Friend WithEvents dgTipoExamen As DataGridViewTextBoxColumn
    Friend WithEvents dgNombre As DataGridViewTextBoxColumn
    Friend WithEvents dgEPS As DataGridViewTextBoxColumn
    Friend WithEvents dgDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents dgArea As DataGridViewTextBoxColumn
    Friend WithEvents dgFecha As DataGridViewTextBoxColumn
    Friend WithEvents dgAbrirAtencion As DataGridViewButtonColumn
    Friend WithEvents dgImagen As DataGridViewImageColumn
    Friend WithEvents abrirlaboratorio As DataGridViewButtonColumn
    Friend WithEvents dgImprimir As DataGridViewImageColumn
    Friend WithEvents dgEnviar As DataGridViewImageColumn
End Class
