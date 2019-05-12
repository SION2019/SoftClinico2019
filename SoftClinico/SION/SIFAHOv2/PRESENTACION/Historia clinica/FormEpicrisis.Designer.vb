<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEpicrisis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEpicrisis))
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
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grupotextos = New System.Windows.Forms.GroupBox()
        Me.fecha_admision = New System.Windows.Forms.DateTimePicker()
        Me.btbuscarpaciente = New System.Windows.Forms.Button()
        Me.fechaegreso = New System.Windows.Forms.DateTimePicker()
        Me.nombre_usuario = New System.Windows.Forms.Label()
        Me.Textestancia = New System.Windows.Forms.TextBox()
        Me.textedad = New System.Windows.Forms.TextBox()
        Me.textentorno = New System.Windows.Forms.TextBox()
        Me.Textsexo = New System.Windows.Forms.TextBox()
        Me.textidentificacion = New System.Windows.Forms.TextBox()
        Me.textnombre = New System.Windows.Forms.TextBox()
        Me.texthc = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvremision = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_diag = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.textepiciris = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Btborrar_firma = New System.Windows.Forms.Button()
        Me.Btfirma = New System.Windows.Forms.Button()
        Me.Picaux = New System.Windows.Forms.PictureBox()
        Me.Textobservacion = New System.Windows.Forms.TextBox()
        Me.Textpeso = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_diag_egreso = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Comboinstitucional = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.combodestino = New System.Windows.Forms.ComboBox()
        Me.comboestadosalida = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupotextos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvremision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_diag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Picaux, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_diag_egreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 60004
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Document_write_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60006
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 60005
        Me.Label1.Text = "EPICRISIS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(954, 20)
        Me.Label2.TabIndex = 60007
        Me.Label2.Text = "_________________________________________________________________________________" &
    "______________________________________________________"
        '
        'grupotextos
        '
        Me.grupotextos.BackColor = System.Drawing.Color.White
        Me.grupotextos.Controls.Add(Me.fecha_admision)
        Me.grupotextos.Controls.Add(Me.btbuscarpaciente)
        Me.grupotextos.Controls.Add(Me.fechaegreso)
        Me.grupotextos.Controls.Add(Me.nombre_usuario)
        Me.grupotextos.Controls.Add(Me.Textestancia)
        Me.grupotextos.Controls.Add(Me.textedad)
        Me.grupotextos.Controls.Add(Me.textentorno)
        Me.grupotextos.Controls.Add(Me.Textsexo)
        Me.grupotextos.Controls.Add(Me.textidentificacion)
        Me.grupotextos.Controls.Add(Me.textnombre)
        Me.grupotextos.Controls.Add(Me.texthc)
        Me.grupotextos.Controls.Add(Me.Label76)
        Me.grupotextos.Controls.Add(Me.Label14)
        Me.grupotextos.Controls.Add(Me.Label3)
        Me.grupotextos.Controls.Add(Me.Label4)
        Me.grupotextos.Controls.Add(Me.Label32)
        Me.grupotextos.Controls.Add(Me.Label92)
        Me.grupotextos.Controls.Add(Me.Label73)
        Me.grupotextos.Controls.Add(Me.Label74)
        Me.grupotextos.Controls.Add(Me.Label75)
        Me.grupotextos.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupotextos.ForeColor = System.Drawing.Color.Black
        Me.grupotextos.Location = New System.Drawing.Point(7, 9)
        Me.grupotextos.Name = "grupotextos"
        Me.grupotextos.Size = New System.Drawing.Size(1019, 93)
        Me.grupotextos.TabIndex = 0
        Me.grupotextos.TabStop = False
        Me.grupotextos.Text = "Información del Paciente"
        '
        'fecha_admision
        '
        Me.fecha_admision.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.fecha_admision.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_admision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha_admision.Location = New System.Drawing.Point(549, 41)
        Me.fecha_admision.Name = "fecha_admision"
        Me.fecha_admision.Size = New System.Drawing.Size(162, 21)
        Me.fecha_admision.TabIndex = 60010
        '
        'btbuscarpaciente
        '
        Me.btbuscarpaciente.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarpaciente.Location = New System.Drawing.Point(207, 16)
        Me.btbuscarpaciente.Name = "btbuscarpaciente"
        Me.btbuscarpaciente.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarpaciente.TabIndex = 60010
        Me.btbuscarpaciente.UseVisualStyleBackColor = True
        '
        'fechaegreso
        '
        Me.fechaegreso.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.fechaegreso.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaegreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaegreso.Location = New System.Drawing.Point(843, 41)
        Me.fechaegreso.Name = "fechaegreso"
        Me.fechaegreso.Size = New System.Drawing.Size(165, 21)
        Me.fechaegreso.TabIndex = 1
        '
        'nombre_usuario
        '
        Me.nombre_usuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.nombre_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre_usuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.nombre_usuario.Location = New System.Drawing.Point(692, 67)
        Me.nombre_usuario.Name = "nombre_usuario"
        Me.nombre_usuario.Size = New System.Drawing.Size(312, 21)
        Me.nombre_usuario.TabIndex = 3062
        Me.nombre_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Textestancia
        '
        Me.Textestancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textestancia.Location = New System.Drawing.Point(549, 66)
        Me.Textestancia.Name = "Textestancia"
        Me.Textestancia.ReadOnly = True
        Me.Textestancia.Size = New System.Drawing.Size(122, 21)
        Me.Textestancia.TabIndex = 3056
        Me.Textestancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textedad
        '
        Me.textedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textedad.Location = New System.Drawing.Point(319, 41)
        Me.textedad.Name = "textedad"
        Me.textedad.ReadOnly = True
        Me.textedad.Size = New System.Drawing.Size(121, 21)
        Me.textedad.TabIndex = 3057
        '
        'textentorno
        '
        Me.textentorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textentorno.Location = New System.Drawing.Point(94, 66)
        Me.textentorno.Name = "textentorno"
        Me.textentorno.ReadOnly = True
        Me.textentorno.Size = New System.Drawing.Size(346, 21)
        Me.textentorno.TabIndex = 3058
        Me.textentorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Textsexo
        '
        Me.Textsexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textsexo.Location = New System.Drawing.Point(94, 41)
        Me.Textsexo.Name = "Textsexo"
        Me.Textsexo.ReadOnly = True
        Me.Textsexo.Size = New System.Drawing.Size(137, 21)
        Me.Textsexo.TabIndex = 3059
        '
        'textidentificacion
        '
        Me.textidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textidentificacion.Location = New System.Drawing.Point(319, 17)
        Me.textidentificacion.Name = "textidentificacion"
        Me.textidentificacion.ReadOnly = True
        Me.textidentificacion.Size = New System.Drawing.Size(121, 21)
        Me.textidentificacion.TabIndex = 3060
        '
        'textnombre
        '
        Me.textnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textnombre.Location = New System.Drawing.Point(509, 17)
        Me.textnombre.Name = "textnombre"
        Me.textnombre.ReadOnly = True
        Me.textnombre.Size = New System.Drawing.Size(499, 21)
        Me.textnombre.TabIndex = 3054
        '
        'texthc
        '
        Me.texthc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texthc.Location = New System.Drawing.Point(94, 17)
        Me.texthc.Name = "texthc"
        Me.texthc.ReadOnly = True
        Me.texthc.Size = New System.Drawing.Size(110, 21)
        Me.texthc.TabIndex = 3053
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label76.Location = New System.Drawing.Point(8, 20)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(75, 15)
        Me.Label76.TabIndex = 3052
        Me.Label76.Text = "No.Registro:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(236, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 1005
        Me.Label14.Text = "Identificación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 1001
        Me.Label3.Text = "Área Servicio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(744, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 999
        Me.Label4.Text = "Fecha Egreso:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(461, 69)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 15)
        Me.Label32.TabIndex = 997
        Me.Label32.Text = " Días Estancia:"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.Black
        Me.Label92.Location = New System.Drawing.Point(8, 44)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(41, 15)
        Me.Label92.TabIndex = 220
        Me.Label92.Text = "Sexo: "
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Black
        Me.Label73.Location = New System.Drawing.Point(279, 44)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(39, 15)
        Me.Label73.TabIndex = 214
        Me.Label73.Text = "Edad:"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Black
        Me.Label74.Location = New System.Drawing.Point(452, 20)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(55, 15)
        Me.Label74.TabIndex = 212
        Me.Label74.Text = "Nombre:"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Black
        Me.Label75.Location = New System.Drawing.Point(451, 44)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(98, 15)
        Me.Label75.TabIndex = 210
        Me.Label75.Text = "Fecha Admisión:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.grupotextos)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1033, 470)
        Me.GroupBox1.TabIndex = 60009
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(7, 108)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1019, 356)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1011, 327)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Diagnósticos de Ingreso"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.dgvremision)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(999, 142)
        Me.GroupBox2.TabIndex = 3080
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Diagnósticos de Remisión"
        '
        'dgvremision
        '
        Me.dgvremision.AllowUserToAddRows = False
        Me.dgvremision.AllowUserToDeleteRows = False
        Me.dgvremision.AllowUserToResizeColumns = False
        Me.dgvremision.AllowUserToResizeRows = False
        Me.dgvremision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvremision.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvremision.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvremision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvremision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvremision.Location = New System.Drawing.Point(3, 17)
        Me.dgvremision.MultiSelect = False
        Me.dgvremision.Name = "dgvremision"
        Me.dgvremision.ReadOnly = True
        Me.dgvremision.RowHeadersVisible = False
        Me.dgvremision.Size = New System.Drawing.Size(993, 122)
        Me.dgvremision.TabIndex = 29
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_diag)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(6, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(999, 174)
        Me.GroupBox3.TabIndex = 3079
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Diagnósticos de Ingreso"
        '
        'dgv_diag
        '
        Me.dgv_diag.AllowUserToAddRows = False
        Me.dgv_diag.AllowUserToDeleteRows = False
        Me.dgv_diag.AllowUserToResizeColumns = False
        Me.dgv_diag.AllowUserToResizeRows = False
        Me.dgv_diag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_diag.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_diag.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgv_diag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_diag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_diag.Location = New System.Drawing.Point(3, 17)
        Me.dgv_diag.MultiSelect = False
        Me.dgv_diag.Name = "dgv_diag"
        Me.dgv_diag.ReadOnly = True
        Me.dgv_diag.RowHeadersVisible = False
        Me.dgv_diag.Size = New System.Drawing.Size(993, 154)
        Me.dgv_diag.TabIndex = 29
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage4.Controls.Add(Me.textepiciris)
        Me.TabPage4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1011, 327)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Epicrisis Final"
        '
        'textepiciris
        '
        Me.textepiciris.AcceptsReturn = True
        Me.textepiciris.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textepiciris.Location = New System.Drawing.Point(4, 5)
        Me.textepiciris.MaxLength = 10000000
        Me.textepiciris.Multiline = True
        Me.textepiciris.Name = "textepiciris"
        Me.textepiciris.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textepiciris.Size = New System.Drawing.Size(999, 315)
        Me.textepiciris.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.AutoScroll = True
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.Textpeso)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Comboinstitucional)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.combodestino)
        Me.TabPage3.Controls.Add(Me.comboestadosalida)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1011, 327)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Diagnósticos de Egreso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Btborrar_firma)
        Me.GroupBox4.Controls.Add(Me.Btfirma)
        Me.GroupBox4.Controls.Add(Me.Picaux)
        Me.GroupBox4.Controls.Add(Me.Textobservacion)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(4, 187)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1000, 91)
        Me.GroupBox4.TabIndex = 3085
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Observación"
        '
        'Btborrar_firma
        '
        Me.Btborrar_firma.Image = Global.Celer.My.Resources.Resources.sign_error_icon
        Me.Btborrar_firma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btborrar_firma.Location = New System.Drawing.Point(603, 52)
        Me.Btborrar_firma.Name = "Btborrar_firma"
        Me.Btborrar_firma.Size = New System.Drawing.Size(100, 32)
        Me.Btborrar_firma.TabIndex = 80018
        Me.Btborrar_firma.Text = "       Borrar Firma"
        Me.Btborrar_firma.UseVisualStyleBackColor = True
        Me.Btborrar_firma.Visible = False
        '
        'Btfirma
        '
        Me.Btfirma.Image = Global.Celer.My.Resources.Resources.sign_check_icon
        Me.Btfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btfirma.Location = New System.Drawing.Point(603, 20)
        Me.Btfirma.Name = "Btfirma"
        Me.Btfirma.Size = New System.Drawing.Size(100, 32)
        Me.Btfirma.TabIndex = 60011
        Me.Btfirma.Text = "   Tomar Firma"
        Me.Btfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btfirma.UseVisualStyleBackColor = True
        Me.Btfirma.Visible = False
        '
        'Picaux
        '
        Me.Picaux.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picaux.Location = New System.Drawing.Point(709, 20)
        Me.Picaux.Name = "Picaux"
        Me.Picaux.Size = New System.Drawing.Size(285, 63)
        Me.Picaux.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picaux.TabIndex = 60010
        Me.Picaux.TabStop = False
        Me.Picaux.Visible = False
        '
        'Textobservacion
        '
        Me.Textobservacion.AcceptsReturn = True
        Me.Textobservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textobservacion.Location = New System.Drawing.Point(3, 21)
        Me.Textobservacion.Multiline = True
        Me.Textobservacion.Name = "Textobservacion"
        Me.Textobservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Textobservacion.Size = New System.Drawing.Size(594, 62)
        Me.Textobservacion.TabIndex = 4
        '
        'Textpeso
        '
        Me.Textpeso.Location = New System.Drawing.Point(74, 291)
        Me.Textpeso.Name = "Textpeso"
        Me.Textpeso.ReadOnly = True
        Me.Textpeso.Size = New System.Drawing.Size(49, 20)
        Me.Textpeso.TabIndex = 3081
        Me.Textpeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgv_diag_egreso)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(4, 9)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1000, 172)
        Me.GroupBox6.TabIndex = 3078
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Diagnóstico de egreso"
        '
        'dgv_diag_egreso
        '
        Me.dgv_diag_egreso.AllowUserToAddRows = False
        Me.dgv_diag_egreso.AllowUserToDeleteRows = False
        Me.dgv_diag_egreso.AllowUserToResizeColumns = False
        Me.dgv_diag_egreso.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv_diag_egreso.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_diag_egreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_diag_egreso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_diag_egreso.BackgroundColor = System.Drawing.Color.White
        Me.dgv_diag_egreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_diag_egreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_diag_egreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_diag_egreso.Location = New System.Drawing.Point(3, 17)
        Me.dgv_diag_egreso.MultiSelect = False
        Me.dgv_diag_egreso.Name = "dgv_diag_egreso"
        Me.dgv_diag_egreso.RowHeadersVisible = False
        Me.dgv_diag_egreso.Size = New System.Drawing.Size(994, 152)
        Me.dgv_diag_egreso.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(592, 291)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 15)
        Me.Label18.TabIndex = 3077
        Me.Label18.Text = "Instituciones:"
        '
        'Comboinstitucional
        '
        Me.Comboinstitucional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Comboinstitucional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Comboinstitucional.BackColor = System.Drawing.Color.White
        Me.Comboinstitucional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comboinstitucional.DropDownWidth = 250
        Me.Comboinstitucional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comboinstitucional.FormattingEnabled = True
        Me.Comboinstitucional.Location = New System.Drawing.Point(672, 287)
        Me.Comboinstitucional.Name = "Comboinstitucional"
        Me.Comboinstitucional.Size = New System.Drawing.Size(326, 23)
        Me.Comboinstitucional.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(150, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 3065
        Me.Label5.Text = "Estado de Salida:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(383, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 3064
        Me.Label6.Text = "Destino:"
        '
        'combodestino
        '
        Me.combodestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combodestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combodestino.BackColor = System.Drawing.Color.White
        Me.combodestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combodestino.DropDownWidth = 250
        Me.combodestino.Enabled = False
        Me.combodestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combodestino.FormattingEnabled = True
        Me.combodestino.Location = New System.Drawing.Point(437, 288)
        Me.combodestino.Name = "combodestino"
        Me.combodestino.Size = New System.Drawing.Size(148, 23)
        Me.combodestino.TabIndex = 6
        '
        'comboestadosalida
        '
        Me.comboestadosalida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboestadosalida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboestadosalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboestadosalida.DropDownWidth = 250
        Me.comboestadosalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboestadosalida.FormattingEnabled = True
        Me.comboestadosalida.Location = New System.Drawing.Point(255, 289)
        Me.comboestadosalida.Name = "comboestadosalida"
        Me.comboestadosalida.Size = New System.Drawing.Size(126, 23)
        Me.comboestadosalida.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(123, 294)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 15)
        Me.Label7.TabIndex = 3079
        Me.Label7.Text = "Kg"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(5, 293)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 15)
        Me.Label17.TabIndex = 3075
        Me.Label17.Text = "Peso Final:"
        '
        'FormEpicrisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "FormEpicrisis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupotextos.ResumeLayout(False)
        Me.grupotextos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvremision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_diag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Picaux, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_diag_egreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btguardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btbuscar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents bteditar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btcancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btanular As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Public WithEvents grupotextos As GroupBox
    Friend WithEvents Textestancia As TextBox
    Friend WithEvents textedad As TextBox
    Friend WithEvents textentorno As TextBox
    Friend WithEvents Textsexo As TextBox
    Friend WithEvents textidentificacion As TextBox
    Friend WithEvents textnombre As TextBox
    Friend WithEvents texthc As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label92 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents textepiciris As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Textobservacion As TextBox
    Friend WithEvents Textpeso As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dgv_diag_egreso As DataGridView
    Friend WithEvents Label18 As Label
    Friend WithEvents Comboinstitucional As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents combodestino As ComboBox
    Friend WithEvents comboestadosalida As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents fechaegreso As DateTimePicker
    Friend WithEvents dgvremision As DataGridView
    Friend WithEvents dgv_diag As DataGridView
    Friend WithEvents btbuscarpaciente As Button
    Friend WithEvents btimprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Picaux As PictureBox
    Friend WithEvents Btfirma As Button
    Friend WithEvents nombre_usuario As Label
    Public WithEvents Btborrar_firma As Button
    Friend WithEvents fecha_admision As DateTimePicker
End Class
