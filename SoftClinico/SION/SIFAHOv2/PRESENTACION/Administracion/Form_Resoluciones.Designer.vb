<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Resoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Resoluciones))
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.activar = New System.Windows.Forms.CheckBox()
        Me.Textconseactual = New System.Windows.Forms.TextBox()
        Me.Textrangofin = New System.Windows.Forms.TextBox()
        Me.Textrangoini = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.fechavence = New System.Windows.Forms.DateTimePicker()
        Me.fechainicio = New System.Windows.Forms.DateTimePicker()
        Me.Textresolucion = New System.Windows.Forms.TextBox()
        Me.Textprefijo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btbuscarempresa = New System.Windows.Forms.Button()
        Me.Textrazonsocial = New System.Windows.Forms.TextBox()
        Me.Textnit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Textcodigo = New System.Windows.Forms.TextBox()
        Me.Textidempresa = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 242)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(559, 54)
        Me.ToolStrip1.TabIndex = 3
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
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Text_Document_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "RESOLUCIONES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(492, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "_____________________________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(542, 186)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.activar)
        Me.GroupBox3.Controls.Add(Me.Textconseactual)
        Me.GroupBox3.Controls.Add(Me.Textrangofin)
        Me.GroupBox3.Controls.Add(Me.Textrangoini)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.fechavence)
        Me.GroupBox3.Controls.Add(Me.fechainicio)
        Me.GroupBox3.Controls.Add(Me.Textresolucion)
        Me.GroupBox3.Controls.Add(Me.Textprefijo)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(530, 112)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos resolución"
        '
        'activar
        '
        Me.activar.AutoSize = True
        Me.activar.ForeColor = System.Drawing.Color.Black
        Me.activar.Location = New System.Drawing.Point(401, 80)
        Me.activar.Name = "activar"
        Me.activar.Size = New System.Drawing.Size(112, 20)
        Me.activar.TabIndex = 8
        Me.activar.Text = "Activar resolución"
        Me.activar.UseVisualStyleBackColor = True
        '
        'Textconseactual
        '
        Me.Textconseactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textconseactual.Location = New System.Drawing.Point(400, 51)
        Me.Textconseactual.Name = "Textconseactual"
        Me.Textconseactual.ShortcutsEnabled = False
        Me.Textconseactual.Size = New System.Drawing.Size(116, 21)
        Me.Textconseactual.TabIndex = 5
        '
        'Textrangofin
        '
        Me.Textrangofin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textrangofin.Location = New System.Drawing.Point(241, 51)
        Me.Textrangofin.Name = "Textrangofin"
        Me.Textrangofin.ShortcutsEnabled = False
        Me.Textrangofin.Size = New System.Drawing.Size(110, 21)
        Me.Textrangofin.TabIndex = 4
        '
        'Textrangoini
        '
        Me.Textrangoini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textrangoini.Location = New System.Drawing.Point(81, 51)
        Me.Textrangoini.Name = "Textrangoini"
        Me.Textrangoini.ShortcutsEnabled = False
        Me.Textrangoini.Size = New System.Drawing.Size(108, 21)
        Me.Textrangoini.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(195, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 15)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Hasta:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(357, 54)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 15)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Actual:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 15)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Rango:"
        '
        'fechavence
        '
        Me.fechavence.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechavence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechavence.Location = New System.Drawing.Point(277, 80)
        Me.fechavence.Name = "fechavence"
        Me.fechavence.Size = New System.Drawing.Size(100, 21)
        Me.fechavence.TabIndex = 7
        '
        'fechainicio
        '
        Me.fechainicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechainicio.Location = New System.Drawing.Point(85, 80)
        Me.fechainicio.Name = "fechainicio"
        Me.fechainicio.Size = New System.Drawing.Size(100, 21)
        Me.fechainicio.TabIndex = 6
        '
        'Textresolucion
        '
        Me.Textresolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textresolucion.Location = New System.Drawing.Point(81, 25)
        Me.Textresolucion.Name = "Textresolucion"
        Me.Textresolucion.ShortcutsEnabled = False
        Me.Textresolucion.Size = New System.Drawing.Size(108, 21)
        Me.Textresolucion.TabIndex = 2
        '
        'Textprefijo
        '
        Me.Textprefijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Textprefijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textprefijo.Location = New System.Drawing.Point(241, 25)
        Me.Textprefijo.MaxLength = 2
        Me.Textprefijo.Name = "Textprefijo"
        Me.Textprefijo.ShortcutsEnabled = False
        Me.Textprefijo.Size = New System.Drawing.Size(36, 21)
        Me.Textprefijo.TabIndex = 2
        Me.Textprefijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(195, 83)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 15)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Fecha vence:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 83)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 15)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Fecha inicio:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(195, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 15)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Prefijo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 15)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Resolución:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btbuscarempresa)
        Me.GroupBox2.Controls.Add(Me.Textrazonsocial)
        Me.GroupBox2.Controls.Add(Me.Textnit)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(530, 47)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información de la empresa"
        '
        'btbuscarempresa
        '
        Me.btbuscarempresa.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarempresa.Location = New System.Drawing.Point(122, 18)
        Me.btbuscarempresa.Name = "btbuscarempresa"
        Me.btbuscarempresa.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarempresa.TabIndex = 0
        Me.btbuscarempresa.UseVisualStyleBackColor = True
        '
        'Textrazonsocial
        '
        Me.Textrazonsocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textrazonsocial.Location = New System.Drawing.Point(231, 19)
        Me.Textrazonsocial.Name = "Textrazonsocial"
        Me.Textrazonsocial.ReadOnly = True
        Me.Textrazonsocial.Size = New System.Drawing.Size(293, 21)
        Me.Textrazonsocial.TabIndex = 999
        '
        'Textnit
        '
        Me.Textnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textnit.Location = New System.Drawing.Point(31, 19)
        Me.Textnit.Name = "Textnit"
        Me.Textnit.ReadOnly = True
        Me.Textnit.Size = New System.Drawing.Size(89, 21)
        Me.Textnit.TabIndex = 9999
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Nit:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(150, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Razón Social:"
        '
        'Textcodigo
        '
        Me.Textcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textcodigo.Location = New System.Drawing.Point(433, 70)
        Me.Textcodigo.Name = "Textcodigo"
        Me.Textcodigo.Size = New System.Drawing.Size(47, 21)
        Me.Textcodigo.TabIndex = 34
        Me.Textcodigo.Visible = False
        '
        'Textidempresa
        '
        Me.Textidempresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textidempresa.Location = New System.Drawing.Point(374, 65)
        Me.Textidempresa.Name = "Textidempresa"
        Me.Textidempresa.Size = New System.Drawing.Size(47, 21)
        Me.Textidempresa.TabIndex = 35
        Me.Textidempresa.Visible = False
        '
        'Form_Resoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(559, 296)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Textcodigo)
        Me.Controls.Add(Me.Textidempresa)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(575, 335)
        Me.MinimumSize = New System.Drawing.Size(575, 335)
        Me.Name = "Form_Resoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents fechavence As DateTimePicker
    Public WithEvents fechainicio As DateTimePicker
    Public WithEvents Textresolucion As TextBox
    Public WithEvents Textprefijo As TextBox
    Public WithEvents Label19 As Label
    Public WithEvents Label18 As Label
    Public WithEvents Label14 As Label
    Public WithEvents Label13 As Label
    Public WithEvents activar As CheckBox
    Public WithEvents Textconseactual As TextBox
    Public WithEvents Textrangofin As TextBox
    Public WithEvents Textrangoini As TextBox
    Public WithEvents Label17 As Label
    Public WithEvents Label16 As Label
    Public WithEvents Label15 As Label
    Public WithEvents Textcodigo As TextBox
    Public WithEvents Label4 As Label
    Public WithEvents Textrazonsocial As TextBox
    Public WithEvents Textnit As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents btbuscarempresa As Button
    Public WithEvents Textidempresa As TextBox
End Class
