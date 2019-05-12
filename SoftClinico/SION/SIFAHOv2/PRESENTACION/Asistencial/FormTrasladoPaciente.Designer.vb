<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTrasladoPaciente
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTrasladoPaciente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btTraslado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cbAreaServicio = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbCama = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btBuscarContrato = New System.Windows.Forms.Button()
        Me.txtcodigocontrato = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcontrato = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbPuntoServicio = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Groupdatos = New System.Windows.Forms.GroupBox()
        Me.btTodos = New System.Windows.Forms.Button()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAdministradora = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btbuscarpaciente = New System.Windows.Forms.Button()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGenero = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtRegistro = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtidenti = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Groupdatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "TRASLADO DE HISTORIA CLINICA "
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btTraslado, Me.ToolStripSeparator1, Me.btcancelar, Me.ToolStripSeparator6, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btTraslado
        '
        Me.btTraslado.Enabled = False
        Me.btTraslado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTraslado.Image = Global.Celer.My.Resources.Resources.Files_Copy_File_icon__1_
        Me.btTraslado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btTraslado.Name = "btTraslado"
        Me.btTraslado.Size = New System.Drawing.Size(44, 51)
        Me.btTraslado.Text = "&Iniciar"
        Me.btTraslado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.btimprimir.Size = New System.Drawing.Size(58, 51)
        Me.btimprimir.Text = "&Imprimir"
        Me.btimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btimprimir.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Groupdatos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(903, 448)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cbAreaServicio)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(6, 282)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(890, 55)
        Me.GroupBox7.TabIndex = 58
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Areas de servicio"
        '
        'cbAreaServicio
        '
        Me.cbAreaServicio.BackColor = System.Drawing.Color.White
        Me.cbAreaServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAreaServicio.FormattingEnabled = True
        Me.cbAreaServicio.Location = New System.Drawing.Point(124, 21)
        Me.cbAreaServicio.Name = "cbAreaServicio"
        Me.cbAreaServicio.Size = New System.Drawing.Size(755, 23)
        Me.cbAreaServicio.TabIndex = 10055
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 15)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Area de Servicio:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbCama)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(6, 342)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(890, 55)
        Me.GroupBox6.TabIndex = 57
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Camas disponibles"
        '
        'cbCama
        '
        Me.cbCama.BackColor = System.Drawing.Color.White
        Me.cbCama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCama.FormattingEnabled = True
        Me.cbCama.Location = New System.Drawing.Point(124, 21)
        Me.cbCama.Name = "cbCama"
        Me.cbCama.Size = New System.Drawing.Size(755, 23)
        Me.cbCama.TabIndex = 10055
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 15)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Cama Disponible:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btBuscarContrato)
        Me.GroupBox5.Controls.Add(Me.txtcodigocontrato)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtcontrato)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 222)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(890, 55)
        Me.GroupBox5.TabIndex = 56
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Contratos"
        '
        'btBuscarContrato
        '
        Me.btBuscarContrato.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarContrato.Location = New System.Drawing.Point(857, 19)
        Me.btBuscarContrato.Name = "btBuscarContrato"
        Me.btBuscarContrato.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarContrato.TabIndex = 54
        Me.btBuscarContrato.UseVisualStyleBackColor = True
        '
        'txtcodigocontrato
        '
        Me.txtcodigocontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigocontrato.Location = New System.Drawing.Point(124, 20)
        Me.txtcodigocontrato.Name = "txtcodigocontrato"
        Me.txtcodigocontrato.ReadOnly = True
        Me.txtcodigocontrato.Size = New System.Drawing.Size(69, 21)
        Me.txtcodigocontrato.TabIndex = 44
        Me.txtcodigocontrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Contrato:"
        '
        'txtcontrato
        '
        Me.txtcontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcontrato.Location = New System.Drawing.Point(199, 20)
        Me.txtcontrato.Name = "txtcontrato"
        Me.txtcontrato.ReadOnly = True
        Me.txtcontrato.Size = New System.Drawing.Size(654, 21)
        Me.txtcontrato.TabIndex = 42
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbPuntoServicio)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 170)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(890, 47)
        Me.GroupBox4.TabIndex = 55
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Puntos de servicios"
        '
        'cbPuntoServicio
        '
        Me.cbPuntoServicio.BackColor = System.Drawing.Color.White
        Me.cbPuntoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPuntoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPuntoServicio.FormattingEnabled = True
        Me.cbPuntoServicio.Location = New System.Drawing.Point(124, 16)
        Me.cbPuntoServicio.Name = "cbPuntoServicio"
        Me.cbPuntoServicio.Size = New System.Drawing.Size(755, 23)
        Me.cbPuntoServicio.TabIndex = 10054
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 15)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Punto de servicio:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbEmpresa)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(890, 47)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Empresas"
        '
        'cbEmpresa
        '
        Me.cbEmpresa.BackColor = System.Drawing.Color.White
        Me.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(124, 16)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(755, 23)
        Me.cbEmpresa.TabIndex = 10053
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 15)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Empresa:"
        '
        'Groupdatos
        '
        Me.Groupdatos.Controls.Add(Me.btTodos)
        Me.Groupdatos.Controls.Add(Me.txtEstado)
        Me.Groupdatos.Controls.Add(Me.Label14)
        Me.Groupdatos.Controls.Add(Me.txtAdministradora)
        Me.Groupdatos.Controls.Add(Me.Label18)
        Me.Groupdatos.Controls.Add(Me.txtEdad)
        Me.Groupdatos.Controls.Add(Me.Label15)
        Me.Groupdatos.Controls.Add(Me.btbuscarpaciente)
        Me.Groupdatos.Controls.Add(Me.txtArea)
        Me.Groupdatos.Controls.Add(Me.Label8)
        Me.Groupdatos.Controls.Add(Me.txtGenero)
        Me.Groupdatos.Controls.Add(Me.Label7)
        Me.Groupdatos.Controls.Add(Me.txtFecha)
        Me.Groupdatos.Controls.Add(Me.Label4)
        Me.Groupdatos.Controls.Add(Me.TxtRegistro)
        Me.Groupdatos.Controls.Add(Me.Label3)
        Me.Groupdatos.Controls.Add(Me.Label5)
        Me.Groupdatos.Controls.Add(Me.txtpaciente)
        Me.Groupdatos.Controls.Add(Me.Label6)
        Me.Groupdatos.Controls.Add(Me.txtidenti)
        Me.Groupdatos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Groupdatos.Location = New System.Drawing.Point(6, 12)
        Me.Groupdatos.Name = "Groupdatos"
        Me.Groupdatos.Size = New System.Drawing.Size(890, 101)
        Me.Groupdatos.TabIndex = 0
        Me.Groupdatos.TabStop = False
        Me.Groupdatos.Text = "Admisión "
        '
        'btTodos
        '
        Me.btTodos.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btTodos.Location = New System.Drawing.Point(858, 44)
        Me.btTodos.Name = "btTodos"
        Me.btTodos.Size = New System.Drawing.Size(25, 23)
        Me.btTodos.TabIndex = 56
        Me.ToolTip1.SetToolTip(Me.btTodos, "Buscar Todos los pacientes")
        Me.btTodos.UseVisualStyleBackColor = True
        '
        'txtEstado
        '
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEstado.Location = New System.Drawing.Point(763, 45)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(92, 21)
        Me.txtEstado.TabIndex = 55
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(710, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 15)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "Estado:"
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
        'txtEdad
        '
        Me.txtEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEdad.Location = New System.Drawing.Point(763, 71)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.ReadOnly = True
        Me.txtEdad.Size = New System.Drawing.Size(120, 21)
        Me.txtEdad.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(711, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Edad:"
        '
        'btbuscarpaciente
        '
        Me.btbuscarpaciente.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarpaciente.Location = New System.Drawing.Point(858, 18)
        Me.btbuscarpaciente.Name = "btbuscarpaciente"
        Me.btbuscarpaciente.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarpaciente.TabIndex = 49
        Me.ToolTip1.SetToolTip(Me.btbuscarpaciente, "Buscar pacientes atendidos")
        Me.btbuscarpaciente.UseVisualStyleBackColor = True
        '
        'txtArea
        '
        Me.txtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtArea.Location = New System.Drawing.Point(558, 45)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(143, 21)
        Me.txtArea.TabIndex = 47
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
        'txtGenero
        '
        Me.txtGenero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtGenero.Location = New System.Drawing.Point(303, 46)
        Me.txtGenero.Name = "txtGenero"
        Me.txtGenero.ReadOnly = True
        Me.txtGenero.Size = New System.Drawing.Size(136, 21)
        Me.txtGenero.TabIndex = 45
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
        'txtFecha
        '
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(108, 43)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(101, 21)
        Me.txtFecha.TabIndex = 43
        Me.txtFecha.ValidatingType = GetType(Date)
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
        'TxtRegistro
        '
        Me.TxtRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtRegistro.Location = New System.Drawing.Point(108, 16)
        Me.TxtRegistro.Name = "TxtRegistro"
        Me.TxtRegistro.ReadOnly = True
        Me.TxtRegistro.Size = New System.Drawing.Size(101, 21)
        Me.TxtRegistro.TabIndex = 37
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
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(558, 19)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.ReadOnly = True
        Me.txtpaciente.Size = New System.Drawing.Size(297, 21)
        Me.txtpaciente.TabIndex = 34
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
        'txtidenti
        '
        Me.txtidenti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidenti.Location = New System.Drawing.Point(303, 20)
        Me.txtidenti.Name = "txtidenti"
        Me.txtidenti.ReadOnly = True
        Me.txtidenti.Size = New System.Drawing.Size(136, 21)
        Me.txtidenti.TabIndex = 27
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dias"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 34
        '
        'FormTrasladoPaciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormTrasladoPaciente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Groupdatos.ResumeLayout(False)
        Me.Groupdatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents Groupdatos As GroupBox
    Public WithEvents Label5 As Label
    Public WithEvents txtpaciente As TextBox
    Public WithEvents Label6 As Label
    Public WithEvents txtidenti As TextBox
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDateTimePickerColumn1 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewDateTimePickerColumn2 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Public WithEvents Label4 As Label
    Public WithEvents TxtRegistro As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents txtArea As TextBox
    Public WithEvents Label8 As Label
    Public WithEvents txtGenero As TextBox
    Public WithEvents Label7 As Label
    Friend WithEvents txtFecha As MaskedTextBox
    Public WithEvents btbuscarpaciente As Button
    Public WithEvents txtEdad As TextBox
    Public WithEvents Label15 As Label
    Public WithEvents txtAdministradora As TextBox
    Public WithEvents Label18 As Label
    Public WithEvents GroupBox6 As GroupBox
    Public WithEvents GroupBox5 As GroupBox
    Public WithEvents GroupBox4 As GroupBox
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents btTraslado As ToolStripButton
    Friend WithEvents Label12 As Label
    Public WithEvents btBuscarContrato As Button
    Friend WithEvents txtcodigocontrato As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtcontrato As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbCama As ComboBox
    Friend WithEvents cbPuntoServicio As ComboBox
    Friend WithEvents cbEmpresa As ComboBox
    Public WithEvents GroupBox7 As GroupBox
    Friend WithEvents cbAreaServicio As ComboBox
    Friend WithEvents Label13 As Label
    Public WithEvents btTodos As Button
    Public WithEvents txtEstado As TextBox
    Public WithEvents Label14 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
