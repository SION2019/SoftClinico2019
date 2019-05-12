<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRemisionAnexo
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
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Combotraslados = New System.Windows.Forms.ComboBox()
        Me.rbambuNO = New System.Windows.Forms.RadioButton()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.rbambuSI = New System.Windows.Forms.RadioButton()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtdatos = New System.Windows.Forms.TextBox()
        Me.GroupBox50 = New System.Windows.Forms.GroupBox()
        Me.Comboespecialidad = New System.Windows.Forms.ComboBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.rboxigenoSI = New System.Windows.Forms.RadioButton()
        Me.rboxigenoNO = New System.Windows.Forms.RadioButton()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Combocomplejidad = New System.Windows.Forms.ComboBox()
        Me.Comboprioridad = New System.Windows.Forms.ComboBox()
        Me.txtfrecresp = New System.Windows.Forms.TextBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.txtfreccar = New System.Windows.Forms.TextBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.txtpresiondias = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.txtpresionsis = New System.Windows.Forms.TextBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.txtdescripglasgow = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.txtglasgow = New System.Windows.Forms.TextBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtotras = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtantecedentes = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.GroupOtrosD = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCodigoProcedimiento = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txtexamen = New System.Windows.Forms.TextBox()
        Me.GroupDatos = New System.Windows.Forms.GroupBox()
        Me.lblentorno = New System.Windows.Forms.TextBox()
        Me.fechaRemision = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcodigocontrato = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtregistro = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcontrato = New System.Windows.Forms.TextBox()
        Me.txtfechaingreso = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcama = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtedad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsexo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtidentificacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoRemision = New System.Windows.Forms.TextBox()
        Me.Combomodalidad = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbGeneral.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox50.SuspendLayout()
        Me.GroupOtrosD.SuspendLayout()
        Me.GroupDatos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btguardar, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(942, 54)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btguardar
        '
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbGeneral)
        Me.GroupBox1.Controls.Add(Me.GroupOtrosD)
        Me.GroupBox1.Controls.Add(Me.GroupDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(918, 448)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.GroupBox2)
        Me.gbGeneral.Controls.Add(Me.Label12)
        Me.gbGeneral.Controls.Add(Me.txtdatos)
        Me.gbGeneral.Controls.Add(Me.Combomodalidad)
        Me.gbGeneral.Controls.Add(Me.GroupBox50)
        Me.gbGeneral.Controls.Add(Me.Combocomplejidad)
        Me.gbGeneral.Controls.Add(Me.Comboprioridad)
        Me.gbGeneral.Controls.Add(Me.txtfrecresp)
        Me.gbGeneral.Controls.Add(Me.Label101)
        Me.gbGeneral.Controls.Add(Me.txtfreccar)
        Me.gbGeneral.Controls.Add(Me.Label103)
        Me.gbGeneral.Controls.Add(Me.txtpresiondias)
        Me.gbGeneral.Controls.Add(Me.Label104)
        Me.gbGeneral.Controls.Add(Me.txtpresionsis)
        Me.gbGeneral.Controls.Add(Me.Label105)
        Me.gbGeneral.Controls.Add(Me.txtdescripglasgow)
        Me.gbGeneral.Controls.Add(Me.Label106)
        Me.gbGeneral.Controls.Add(Me.txtglasgow)
        Me.gbGeneral.Controls.Add(Me.Label99)
        Me.gbGeneral.Controls.Add(Me.Label33)
        Me.gbGeneral.Controls.Add(Me.txtotras)
        Me.gbGeneral.Controls.Add(Me.Label32)
        Me.gbGeneral.Controls.Add(Me.txtantecedentes)
        Me.gbGeneral.Controls.Add(Me.Label94)
        Me.gbGeneral.Controls.Add(Me.Label100)
        Me.gbGeneral.Controls.Add(Me.Label102)
        Me.gbGeneral.ForeColor = System.Drawing.Color.RoyalBlue
        Me.gbGeneral.Location = New System.Drawing.Point(12, 103)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(896, 339)
        Me.gbGeneral.TabIndex = 10080
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "Datos Anexo 9:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Combotraslados)
        Me.GroupBox2.Controls.Add(Me.rbambuNO)
        Me.GroupBox2.Controls.Add(Me.Label110)
        Me.GroupBox2.Controls.Add(Me.rbambuSI)
        Me.GroupBox2.Controls.Add(Me.Label109)
        Me.GroupBox2.Location = New System.Drawing.Point(590, 103)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 92)
        Me.GroupBox2.TabIndex = 10097
        Me.GroupBox2.TabStop = False
        '
        'Combotraslados
        '
        Me.Combotraslados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combotraslados.DropDownWidth = 500
        Me.Combotraslados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Combotraslados.FormattingEnabled = True
        Me.Combotraslados.Location = New System.Drawing.Point(11, 57)
        Me.Combotraslados.Name = "Combotraslados"
        Me.Combotraslados.Size = New System.Drawing.Size(283, 23)
        Me.Combotraslados.TabIndex = 10091
        '
        'rbambuNO
        '
        Me.rbambuNO.AutoSize = True
        Me.rbambuNO.Checked = True
        Me.rbambuNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbambuNO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rbambuNO.Location = New System.Drawing.Point(143, 15)
        Me.rbambuNO.Name = "rbambuNO"
        Me.rbambuNO.Size = New System.Drawing.Size(43, 19)
        Me.rbambuNO.TabIndex = 10089
        Me.rbambuNO.TabStop = True
        Me.rbambuNO.Text = "NO"
        Me.rbambuNO.UseVisualStyleBackColor = True
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label110.Location = New System.Drawing.Point(8, 17)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(129, 15)
        Me.Label110.TabIndex = 10087
        Me.Label110.Text = "Requiere Ambulancia:"
        '
        'rbambuSI
        '
        Me.rbambuSI.AutoSize = True
        Me.rbambuSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbambuSI.ForeColor = System.Drawing.Color.Black
        Me.rbambuSI.Location = New System.Drawing.Point(189, 15)
        Me.rbambuSI.Name = "rbambuSI"
        Me.rbambuSI.Size = New System.Drawing.Size(36, 19)
        Me.rbambuSI.TabIndex = 10088
        Me.rbambuSI.Text = "SI"
        Me.rbambuSI.UseVisualStyleBackColor = True
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label109.Location = New System.Drawing.Point(9, 39)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(53, 15)
        Me.Label109.TabIndex = 10090
        Me.Label109.Text = "Servicio:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(9, 204)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 15)
        Me.Label12.TabIndex = 10096
        Me.Label12.Text = "Datos Médicos:"
        '
        'txtdatos
        '
        Me.txtdatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatos.Location = New System.Drawing.Point(122, 201)
        Me.txtdatos.Multiline = True
        Me.txtdatos.Name = "txtdatos"
        Me.txtdatos.ReadOnly = True
        Me.txtdatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtdatos.Size = New System.Drawing.Size(768, 132)
        Me.txtdatos.TabIndex = 10095
        '
        'GroupBox50
        '
        Me.GroupBox50.Controls.Add(Me.Comboespecialidad)
        Me.GroupBox50.Controls.Add(Me.Label107)
        Me.GroupBox50.Controls.Add(Me.rboxigenoSI)
        Me.GroupBox50.Controls.Add(Me.rboxigenoNO)
        Me.GroupBox50.Controls.Add(Me.Label108)
        Me.GroupBox50.Location = New System.Drawing.Point(590, 7)
        Me.GroupBox50.Name = "GroupBox50"
        Me.GroupBox50.Size = New System.Drawing.Size(300, 90)
        Me.GroupBox50.TabIndex = 10093
        Me.GroupBox50.TabStop = False
        '
        'Comboespecialidad
        '
        Me.Comboespecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comboespecialidad.DropDownWidth = 500
        Me.Comboespecialidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Comboespecialidad.FormattingEnabled = True
        Me.Comboespecialidad.Location = New System.Drawing.Point(11, 56)
        Me.Comboespecialidad.Name = "Comboespecialidad"
        Me.Comboespecialidad.Size = New System.Drawing.Size(283, 23)
        Me.Comboespecialidad.TabIndex = 10086
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label107.Location = New System.Drawing.Point(8, 16)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(110, 15)
        Me.Label107.TabIndex = 10080
        Me.Label107.Text = "Requiere Oxigeno:"
        '
        'rboxigenoSI
        '
        Me.rboxigenoSI.AutoSize = True
        Me.rboxigenoSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rboxigenoSI.ForeColor = System.Drawing.Color.Black
        Me.rboxigenoSI.Location = New System.Drawing.Point(172, 15)
        Me.rboxigenoSI.Name = "rboxigenoSI"
        Me.rboxigenoSI.Size = New System.Drawing.Size(36, 19)
        Me.rboxigenoSI.TabIndex = 10081
        Me.rboxigenoSI.Text = "SI"
        Me.rboxigenoSI.UseVisualStyleBackColor = True
        '
        'rboxigenoNO
        '
        Me.rboxigenoNO.AutoSize = True
        Me.rboxigenoNO.Checked = True
        Me.rboxigenoNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rboxigenoNO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rboxigenoNO.Location = New System.Drawing.Point(126, 15)
        Me.rboxigenoNO.Name = "rboxigenoNO"
        Me.rboxigenoNO.Size = New System.Drawing.Size(43, 19)
        Me.rboxigenoNO.TabIndex = 10082
        Me.rboxigenoNO.TabStop = True
        Me.rboxigenoNO.Text = "NO"
        Me.rboxigenoNO.UseVisualStyleBackColor = True
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label108.Location = New System.Drawing.Point(8, 38)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(117, 15)
        Me.Label108.TabIndex = 10083
        Me.Label108.Text = "Solicitar Referencia:"
        '
        'Combocomplejidad
        '
        Me.Combocomplejidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combocomplejidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Combocomplejidad.FormattingEnabled = True
        Me.Combocomplejidad.Location = New System.Drawing.Point(122, 39)
        Me.Combocomplejidad.Name = "Combocomplejidad"
        Me.Combocomplejidad.Size = New System.Drawing.Size(191, 23)
        Me.Combocomplejidad.TabIndex = 10085
        '
        'Comboprioridad
        '
        Me.Comboprioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comboprioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Comboprioridad.FormattingEnabled = True
        Me.Comboprioridad.Location = New System.Drawing.Point(122, 14)
        Me.Comboprioridad.Name = "Comboprioridad"
        Me.Comboprioridad.Size = New System.Drawing.Size(191, 23)
        Me.Comboprioridad.TabIndex = 10084
        '
        'txtfrecresp
        '
        Me.txtfrecresp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfrecresp.Location = New System.Drawing.Point(468, 112)
        Me.txtfrecresp.Name = "txtfrecresp"
        Me.txtfrecresp.ReadOnly = True
        Me.txtfrecresp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtfrecresp.Size = New System.Drawing.Size(115, 21)
        Me.txtfrecresp.TabIndex = 10079
        Me.txtfrecresp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label101.Location = New System.Drawing.Point(325, 115)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(141, 15)
        Me.Label101.TabIndex = 10078
        Me.Label101.Text = "Frecuencia Respiratoria:"
        '
        'txtfreccar
        '
        Me.txtfreccar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfreccar.Location = New System.Drawing.Point(468, 89)
        Me.txtfreccar.Name = "txtfreccar"
        Me.txtfreccar.ReadOnly = True
        Me.txtfreccar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtfreccar.Size = New System.Drawing.Size(115, 21)
        Me.txtfreccar.TabIndex = 10077
        Me.txtfreccar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label103.Location = New System.Drawing.Point(343, 92)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(123, 15)
        Me.Label103.TabIndex = 10076
        Me.Label103.Text = "Frecuencia Cardíaca:"
        '
        'txtpresiondias
        '
        Me.txtpresiondias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpresiondias.Location = New System.Drawing.Point(468, 64)
        Me.txtpresiondias.Name = "txtpresiondias"
        Me.txtpresiondias.ReadOnly = True
        Me.txtpresiondias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtpresiondias.Size = New System.Drawing.Size(115, 21)
        Me.txtpresiondias.TabIndex = 10075
        Me.txtpresiondias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label104.Location = New System.Drawing.Point(318, 67)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(148, 15)
        Me.Label104.TabIndex = 10074
        Me.Label104.Text = "Presión arterial diastólica:"
        '
        'txtpresionsis
        '
        Me.txtpresionsis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpresionsis.Location = New System.Drawing.Point(468, 39)
        Me.txtpresionsis.Name = "txtpresionsis"
        Me.txtpresionsis.ReadOnly = True
        Me.txtpresionsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtpresionsis.Size = New System.Drawing.Size(115, 21)
        Me.txtpresionsis.TabIndex = 10073
        Me.txtpresionsis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label105.Location = New System.Drawing.Point(324, 42)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(142, 15)
        Me.Label105.TabIndex = 10072
        Me.Label105.Text = "Presión Arterial Sistólica:"
        '
        'txtdescripglasgow
        '
        Me.txtdescripglasgow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripglasgow.Location = New System.Drawing.Point(468, 15)
        Me.txtdescripglasgow.Name = "txtdescripglasgow"
        Me.txtdescripglasgow.ReadOnly = True
        Me.txtdescripglasgow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtdescripglasgow.Size = New System.Drawing.Size(115, 21)
        Me.txtdescripglasgow.TabIndex = 10071
        Me.txtdescripglasgow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label106.Location = New System.Drawing.Point(340, 18)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(126, 15)
        Me.Label106.TabIndex = 10070
        Me.Label106.Text = "Descripción Glasgow:"
        '
        'txtglasgow
        '
        Me.txtglasgow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtglasgow.Location = New System.Drawing.Point(122, 112)
        Me.txtglasgow.Name = "txtglasgow"
        Me.txtglasgow.ReadOnly = True
        Me.txtglasgow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtglasgow.Size = New System.Drawing.Size(191, 21)
        Me.txtglasgow.TabIndex = 10069
        Me.txtglasgow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label99.Location = New System.Drawing.Point(9, 115)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(58, 15)
        Me.Label99.TabIndex = 10068
        Me.Label99.Text = "Glasgow:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(9, 139)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 15)
        Me.Label33.TabIndex = 10067
        Me.Label33.Text = "Antecedentes:"
        '
        'txtotras
        '
        Me.txtotras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotras.Location = New System.Drawing.Point(122, 89)
        Me.txtotras.Name = "txtotras"
        Me.txtotras.ReadOnly = True
        Me.txtotras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtotras.Size = New System.Drawing.Size(191, 21)
        Me.txtotras.TabIndex = 10066
        Me.txtotras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(9, 92)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(114, 15)
        Me.Label32.TabIndex = 10065
        Me.Label32.Text = "Otras Modalidades:"
        '
        'txtantecedentes
        '
        Me.txtantecedentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtantecedentes.Location = New System.Drawing.Point(122, 136)
        Me.txtantecedentes.Multiline = True
        Me.txtantecedentes.Name = "txtantecedentes"
        Me.txtantecedentes.ReadOnly = True
        Me.txtantecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtantecedentes.Size = New System.Drawing.Size(461, 59)
        Me.txtantecedentes.TabIndex = 10064
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label94.Location = New System.Drawing.Point(9, 67)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(105, 15)
        Me.Label94.TabIndex = 10061
        Me.Label94.Text = "Modalidad Apoyo:"
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label100.Location = New System.Drawing.Point(9, 42)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(80, 15)
        Me.Label100.TabIndex = 10057
        Me.Label100.Text = "Complejidad:"
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label102.Location = New System.Drawing.Point(9, 18)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(60, 15)
        Me.Label102.TabIndex = 10053
        Me.Label102.Text = "Prioridad:"
        '
        'GroupOtrosD
        '
        Me.GroupOtrosD.Controls.Add(Me.Label15)
        Me.GroupOtrosD.Controls.Add(Me.txtCodigoProcedimiento)
        Me.GroupOtrosD.Controls.Add(Me.Label16)
        Me.GroupOtrosD.Controls.Add(Me.Txtexamen)
        Me.GroupOtrosD.Location = New System.Drawing.Point(12, 97)
        Me.GroupOtrosD.Name = "GroupOtrosD"
        Me.GroupOtrosD.Size = New System.Drawing.Size(896, 39)
        Me.GroupOtrosD.TabIndex = 70
        Me.GroupOtrosD.TabStop = False
        Me.GroupOtrosD.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 15)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Procedimiento:"
        '
        'txtCodigoProcedimiento
        '
        Me.txtCodigoProcedimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoProcedimiento.Location = New System.Drawing.Point(102, 12)
        Me.txtCodigoProcedimiento.Name = "txtCodigoProcedimiento"
        Me.txtCodigoProcedimiento.Size = New System.Drawing.Size(78, 21)
        Me.txtCodigoProcedimiento.TabIndex = 68
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(185, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 15)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Examen:"
        '
        'Txtexamen
        '
        Me.Txtexamen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Txtexamen.Location = New System.Drawing.Point(244, 12)
        Me.Txtexamen.Name = "Txtexamen"
        Me.Txtexamen.Size = New System.Drawing.Size(646, 21)
        Me.Txtexamen.TabIndex = 44
        '
        'GroupDatos
        '
        Me.GroupDatos.Controls.Add(Me.lblentorno)
        Me.GroupDatos.Controls.Add(Me.fechaRemision)
        Me.GroupDatos.Controls.Add(Me.Label5)
        Me.GroupDatos.Controls.Add(Me.txtcodigocontrato)
        Me.GroupDatos.Controls.Add(Me.Label30)
        Me.GroupDatos.Controls.Add(Me.txtregistro)
        Me.GroupDatos.Controls.Add(Me.Label11)
        Me.GroupDatos.Controls.Add(Me.Label10)
        Me.GroupDatos.Controls.Add(Me.txtcontrato)
        Me.GroupDatos.Controls.Add(Me.txtfechaingreso)
        Me.GroupDatos.Controls.Add(Me.Label9)
        Me.GroupDatos.Controls.Add(Me.Label8)
        Me.GroupDatos.Controls.Add(Me.txtcama)
        Me.GroupDatos.Controls.Add(Me.Label7)
        Me.GroupDatos.Controls.Add(Me.txtedad)
        Me.GroupDatos.Controls.Add(Me.Label6)
        Me.GroupDatos.Controls.Add(Me.txtsexo)
        Me.GroupDatos.Controls.Add(Me.Label4)
        Me.GroupDatos.Controls.Add(Me.txtpaciente)
        Me.GroupDatos.Controls.Add(Me.Label3)
        Me.GroupDatos.Controls.Add(Me.txtidentificacion)
        Me.GroupDatos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupDatos.Location = New System.Drawing.Point(12, 7)
        Me.GroupDatos.Name = "GroupDatos"
        Me.GroupDatos.Size = New System.Drawing.Size(896, 90)
        Me.GroupDatos.TabIndex = 37
        Me.GroupDatos.TabStop = False
        Me.GroupDatos.Text = "Informacion del Paciente"
        '
        'lblentorno
        '
        Me.lblentorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblentorno.Location = New System.Drawing.Point(764, 40)
        Me.lblentorno.Name = "lblentorno"
        Me.lblentorno.Size = New System.Drawing.Size(128, 21)
        Me.lblentorno.TabIndex = 71
        '
        'fechaRemision
        '
        Me.fechaRemision.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.fechaRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.fechaRemision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaRemision.Location = New System.Drawing.Point(753, 17)
        Me.fechaRemision.Name = "fechaRemision"
        Me.fechaRemision.Size = New System.Drawing.Size(138, 21)
        Me.fechaRemision.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(686, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Fecha:"
        '
        'txtcodigocontrato
        '
        Me.txtcodigocontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigocontrato.Location = New System.Drawing.Point(91, 63)
        Me.txtcodigocontrato.Name = "txtcodigocontrato"
        Me.txtcodigocontrato.Size = New System.Drawing.Size(64, 21)
        Me.txtcodigocontrato.TabIndex = 41
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(686, 66)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 15)
        Me.Label30.TabIndex = 40
        Me.Label30.Text = "N° Registro:"
        '
        'txtregistro
        '
        Me.txtregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtregistro.Location = New System.Drawing.Point(764, 63)
        Me.txtregistro.Name = "txtregistro"
        Me.txtregistro.Size = New System.Drawing.Size(128, 21)
        Me.txtregistro.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(686, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 15)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Sala:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Contrato:"
        '
        'txtcontrato
        '
        Me.txtcontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcontrato.Location = New System.Drawing.Point(158, 63)
        Me.txtcontrato.Name = "txtcontrato"
        Me.txtcontrato.Size = New System.Drawing.Size(515, 21)
        Me.txtcontrato.TabIndex = 35
        '
        'txtfechaingreso
        '
        Me.txtfechaingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechaingreso.Location = New System.Drawing.Point(567, 40)
        Me.txtfechaingreso.Mask = "00/00/0000 00:00"
        Me.txtfechaingreso.Name = "txtfechaingreso"
        Me.txtfechaingreso.Size = New System.Drawing.Size(106, 21)
        Me.txtfechaingreso.TabIndex = 34
        Me.txtfechaingreso.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(478, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Fecha Ingreso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(355, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Cama:"
        '
        'txtcama
        '
        Me.txtcama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcama.Location = New System.Drawing.Point(402, 40)
        Me.txtcama.Name = "txtcama"
        Me.txtcama.Size = New System.Drawing.Size(71, 21)
        Me.txtcama.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(214, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Edad:"
        '
        'txtedad
        '
        Me.txtedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtedad.Location = New System.Drawing.Point(262, 40)
        Me.txtedad.Name = "txtedad"
        Me.txtedad.Size = New System.Drawing.Size(76, 21)
        Me.txtedad.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Sexo:"
        '
        'txtsexo
        '
        Me.txtsexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtsexo.Location = New System.Drawing.Point(91, 40)
        Me.txtsexo.Name = "txtsexo"
        Me.txtsexo.Size = New System.Drawing.Size(112, 21)
        Me.txtsexo.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(221, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Paciente:"
        '
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(281, 17)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.Size = New System.Drawing.Size(392, 21)
        Me.txtpaciente.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Identificación:"
        '
        'txtidentificacion
        '
        Me.txtidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentificacion.Location = New System.Drawing.Point(91, 17)
        Me.txtidentificacion.Name = "txtidentificacion"
        Me.txtidentificacion.Size = New System.Drawing.Size(96, 21)
        Me.txtidentificacion.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 16)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "REMISIÓN PROCEDIMIENTOS HEMODINÁMICOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.surgeon_icon1
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(877, 20)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'txtCodigoRemision
        '
        Me.txtCodigoRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoRemision.Location = New System.Drawing.Point(512, 8)
        Me.txtCodigoRemision.Name = "txtCodigoRemision"
        Me.txtCodigoRemision.Size = New System.Drawing.Size(78, 21)
        Me.txtCodigoRemision.TabIndex = 69
        Me.txtCodigoRemision.Visible = False
        '
        'Combomodalidad
        '
        Me.Combomodalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combomodalidad.DropDownWidth = 400
        Me.Combomodalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Combomodalidad.FormattingEnabled = True
        Me.Combomodalidad.Location = New System.Drawing.Point(122, 64)
        Me.Combomodalidad.Name = "Combomodalidad"
        Me.Combomodalidad.Size = New System.Drawing.Size(191, 23)
        Me.Combomodalidad.TabIndex = 10094
        '
        'FormRemisionAnexo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(942, 556)
        Me.Controls.Add(Me.txtCodigoRemision)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(958, 595)
        Me.MinimumSize = New System.Drawing.Size(958, 595)
        Me.Name = "FormRemisionAnexo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox50.ResumeLayout(False)
        Me.GroupBox50.PerformLayout()
        Me.GroupOtrosD.ResumeLayout(False)
        Me.GroupOtrosD.PerformLayout()
        Me.GroupDatos.ResumeLayout(False)
        Me.GroupDatos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btguardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupOtrosD As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCodigoProcedimiento As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txtexamen As TextBox
    Friend WithEvents GroupDatos As GroupBox
    Friend WithEvents lblentorno As TextBox
    Friend WithEvents fechaRemision As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcodigocontrato As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtregistro As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtcontrato As TextBox
    Friend WithEvents txtfechaingreso As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtcama As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtedad As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsexo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtpaciente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtidentificacion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents gbGeneral As GroupBox
    Friend WithEvents GroupBox50 As GroupBox
    Friend WithEvents Combotraslados As ComboBox
    Friend WithEvents Label110 As Label
    Friend WithEvents Comboespecialidad As ComboBox
    Friend WithEvents Label109 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents rbambuSI As RadioButton
    Friend WithEvents rboxigenoSI As RadioButton
    Friend WithEvents rbambuNO As RadioButton
    Friend WithEvents rboxigenoNO As RadioButton
    Friend WithEvents Label108 As Label
    Friend WithEvents Combocomplejidad As ComboBox
    Friend WithEvents Comboprioridad As ComboBox
    Friend WithEvents txtfrecresp As TextBox
    Friend WithEvents Label101 As Label
    Friend WithEvents txtfreccar As TextBox
    Friend WithEvents Label103 As Label
    Friend WithEvents txtpresiondias As TextBox
    Friend WithEvents Label104 As Label
    Friend WithEvents txtpresionsis As TextBox
    Friend WithEvents Label105 As Label
    Friend WithEvents txtdescripglasgow As TextBox
    Friend WithEvents Label106 As Label
    Friend WithEvents txtglasgow As TextBox
    Friend WithEvents Label99 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txtotras As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtantecedentes As TextBox
    Friend WithEvents Label94 As Label
    Friend WithEvents Label100 As Label
    Friend WithEvents Label102 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtdatos As TextBox
    Friend WithEvents txtCodigoRemision As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Combomodalidad As ComboBox
End Class
