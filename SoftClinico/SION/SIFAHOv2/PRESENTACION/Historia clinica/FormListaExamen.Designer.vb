<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormListaExamen
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormListaExamen))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.lbSub = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PanelBotones = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btConsultado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btVistaPrevia = New System.Windows.Forms.ToolStripDropDownButton()
        Me.VistaPreviaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtFechaFinCons = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbEstadoAtencion = New System.Windows.Forms.GroupBox()
        Me.chRealizado = New System.Windows.Forms.RadioButton()
        Me.chPendiente = New System.Windows.Forms.RadioButton()
        Me.dtFcehaIniCons = New System.Windows.Forms.DateTimePicker()
        Me.comboAreaServicio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbLaboratorio = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBuscarConsildado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pag1 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgvmanual = New System.Windows.Forms.DataGridView()
        Me.dgResultado = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pag2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvConsolidadoExam = New System.Windows.Forms.DataGridView()
        Me.npaciente = New System.Windows.Forms.Label()
        Me.lbTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbCodigo = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PanelBotones.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.gbEstadoAtencion.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.pag1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvmanual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pag2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvConsolidadoExam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCodigo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbTotal)
        Me.GroupBox1.Controls.Add(Me.lbSub)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.npaciente)
        Me.GroupBox1.Controls.Add(Me.lbTitulo)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1292, 555)
        Me.GroupBox1.TabIndex = 10048
        Me.GroupBox1.TabStop = False
        '
        'lbTotal
        '
        Me.lbTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTotal.AutoSize = True
        Me.lbTotal.BackColor = System.Drawing.Color.Transparent
        Me.lbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lbTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTotal.Location = New System.Drawing.Point(201, 531)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(14, 15)
        Me.lbTotal.TabIndex = 10063
        Me.lbTotal.Text = "0"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbSub
        '
        Me.lbSub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbSub.AutoSize = True
        Me.lbSub.BackColor = System.Drawing.Color.Transparent
        Me.lbSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lbSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbSub.Location = New System.Drawing.Point(68, 532)
        Me.lbSub.Name = "lbSub"
        Me.lbSub.Size = New System.Drawing.Size(14, 15)
        Me.lbSub.TabIndex = 10062
        Me.lbSub.Text = "0"
        Me.lbSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(165, 531)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 10061
        Me.Label5.Text = "Total:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 531)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 10060
        Me.Label4.Text = "Sub Total:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gbCodigo)
        Me.GroupBox3.Controls.Add(Me.PanelBotones)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtFechaFinCons)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.gbEstadoAtencion)
        Me.GroupBox3.Controls.Add(Me.dtFcehaIniCons)
        Me.GroupBox3.Controls.Add(Me.comboAreaServicio)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cbLaboratorio)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtBuscarConsildado)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1279, 82)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtros de Busqueda:"
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBotones.Controls.Add(Me.ToolStrip1)
        Me.PanelBotones.Location = New System.Drawing.Point(937, 14)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(334, 59)
        Me.PanelBotones.TabIndex = 10067
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btConsultado, Me.ToolStripSeparator1, Me.btVistaPrevia, Me.ToolStripSeparator3, Me.btguardar, Me.ToolStripSeparator5, Me.btbuscar, Me.ToolStripSeparator4, Me.btanular})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(332, 54)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btConsultado
        '
        Me.btConsultado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConsultado.Image = Global.Celer.My.Resources.Resources.Refresh_icon
        Me.btConsultado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btConsultado.Name = "btConsultado"
        Me.btConsultado.Size = New System.Drawing.Size(57, 51)
        Me.btConsultado.Text = "Consulta"
        Me.btConsultado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'btVistaPrevia
        '
        Me.btVistaPrevia.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VistaPreviaToolStripMenuItem, Me.FacturaToolStripMenuItem})
        Me.btVistaPrevia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btVistaPrevia.Image = Global.Celer.My.Resources.Resources.Printer_icon__1_
        Me.btVistaPrevia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btVistaPrevia.Name = "btVistaPrevia"
        Me.btVistaPrevia.Size = New System.Drawing.Size(84, 51)
        Me.btVistaPrevia.Text = "Impresiones"
        Me.btVistaPrevia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'VistaPreviaToolStripMenuItem
        '
        Me.VistaPreviaToolStripMenuItem.Image = Global.Celer.My.Resources.Resources.Printer_icon__1_
        Me.VistaPreviaToolStripMenuItem.Name = "VistaPreviaToolStripMenuItem"
        Me.VistaPreviaToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.VistaPreviaToolStripMenuItem.Text = "Consolidado"
        '
        'FacturaToolStripMenuItem
        '
        Me.FacturaToolStripMenuItem.Image = Global.Celer.My.Resources.Resources.Printer_icon__1_
        Me.FacturaToolStripMenuItem.Name = "FacturaToolStripMenuItem"
        Me.FacturaToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.FacturaToolStripMenuItem.Text = "Factura"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
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
        'btanular
        '
        Me.btanular.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btanular.Image = Global.Celer.My.Resources.Resources.Document_Delete_icon__1_
        Me.btanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btanular.Name = "btanular"
        Me.btanular.Size = New System.Drawing.Size(46, 51)
        Me.btanular.Text = "&Anular"
        Me.btanular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(790, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 15)
        Me.Label7.TabIndex = 10066
        Me.Label7.Text = "Hasta:"
        '
        'dtFechaFinCons
        '
        Me.dtFechaFinCons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtFechaFinCons.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFinCons.Location = New System.Drawing.Point(836, 48)
        Me.dtFechaFinCons.Name = "dtFechaFinCons"
        Me.dtFechaFinCons.Size = New System.Drawing.Size(85, 21)
        Me.dtFechaFinCons.TabIndex = 10065
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(786, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 10064
        Me.Label8.Text = "Desde:"
        '
        'gbEstadoAtencion
        '
        Me.gbEstadoAtencion.Controls.Add(Me.chRealizado)
        Me.gbEstadoAtencion.Controls.Add(Me.chPendiente)
        Me.gbEstadoAtencion.Location = New System.Drawing.Point(671, 10)
        Me.gbEstadoAtencion.Name = "gbEstadoAtencion"
        Me.gbEstadoAtencion.Size = New System.Drawing.Size(99, 64)
        Me.gbEstadoAtencion.TabIndex = 10058
        Me.gbEstadoAtencion.TabStop = False
        '
        'chRealizado
        '
        Me.chRealizado.AutoSize = True
        Me.chRealizado.BackColor = System.Drawing.Color.Transparent
        Me.chRealizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chRealizado.ForeColor = System.Drawing.Color.DarkOrange
        Me.chRealizado.Location = New System.Drawing.Point(6, 37)
        Me.chRealizado.Name = "chRealizado"
        Me.chRealizado.Size = New System.Drawing.Size(87, 19)
        Me.chRealizado.TabIndex = 10059
        Me.chRealizado.Text = "Realizados"
        Me.chRealizado.UseVisualStyleBackColor = False
        '
        'chPendiente
        '
        Me.chPendiente.AutoSize = True
        Me.chPendiente.BackColor = System.Drawing.Color.Transparent
        Me.chPendiente.Checked = True
        Me.chPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chPendiente.ForeColor = System.Drawing.Color.Green
        Me.chPendiente.Location = New System.Drawing.Point(6, 13)
        Me.chPendiente.Name = "chPendiente"
        Me.chPendiente.Size = New System.Drawing.Size(87, 19)
        Me.chPendiente.TabIndex = 10053
        Me.chPendiente.TabStop = True
        Me.chPendiente.Text = "Pendientes"
        Me.chPendiente.UseVisualStyleBackColor = False
        '
        'dtFcehaIniCons
        '
        Me.dtFcehaIniCons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtFcehaIniCons.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFcehaIniCons.Location = New System.Drawing.Point(836, 18)
        Me.dtFcehaIniCons.Name = "dtFcehaIniCons"
        Me.dtFcehaIniCons.Size = New System.Drawing.Size(85, 21)
        Me.dtFcehaIniCons.TabIndex = 10063
        '
        'comboAreaServicio
        '
        Me.comboAreaServicio.BackColor = System.Drawing.Color.White
        Me.comboAreaServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAreaServicio.FormattingEnabled = True
        Me.comboAreaServicio.Location = New System.Drawing.Point(433, 47)
        Me.comboAreaServicio.Name = "comboAreaServicio"
        Me.comboAreaServicio.Size = New System.Drawing.Size(221, 23)
        Me.comboAreaServicio.TabIndex = 10052
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(331, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 10051
        Me.Label3.Text = "Área de Servicio:"
        '
        'cbLaboratorio
        '
        Me.cbLaboratorio.BackColor = System.Drawing.Color.White
        Me.cbLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLaboratorio.FormattingEnabled = True
        Me.cbLaboratorio.Location = New System.Drawing.Point(433, 17)
        Me.cbLaboratorio.Name = "cbLaboratorio"
        Me.cbLaboratorio.Size = New System.Drawing.Size(221, 23)
        Me.cbLaboratorio.TabIndex = 10052
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(331, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 10051
        Me.Label9.Text = "Laboratorio:"
        '
        'txtBuscarConsildado
        '
        Me.txtBuscarConsildado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarConsildado.Location = New System.Drawing.Point(65, 20)
        Me.txtBuscarConsildado.Name = "txtBuscarConsildado"
        Me.txtBuscarConsildado.Size = New System.Drawing.Size(245, 21)
        Me.txtBuscarConsildado.TabIndex = 10050
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 15)
        Me.Label11.TabIndex = 10048
        Me.Label11.Text = "Filtro:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.pag1)
        Me.TabControl1.Controls.Add(Me.pag2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1286, 428)
        Me.TabControl1.TabIndex = 10059
        '
        'pag1
        '
        Me.pag1.Controls.Add(Me.GroupBox5)
        Me.pag1.Location = New System.Drawing.Point(4, 22)
        Me.pag1.Name = "pag1"
        Me.pag1.Padding = New System.Windows.Forms.Padding(3)
        Me.pag1.Size = New System.Drawing.Size(1278, 402)
        Me.pag1.TabIndex = 0
        Me.pag1.Text = "Listado"
        Me.pag1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgvmanual)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1272, 396)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pacientes:"
        '
        'dgvmanual
        '
        Me.dgvmanual.AllowUserToAddRows = False
        Me.dgvmanual.AllowUserToDeleteRows = False
        Me.dgvmanual.AllowUserToResizeColumns = False
        Me.dgvmanual.AllowUserToResizeRows = False
        Me.dgvmanual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvmanual.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvmanual.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvmanual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvmanual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgResultado})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvmanual.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvmanual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvmanual.Location = New System.Drawing.Point(3, 17)
        Me.dgvmanual.MultiSelect = False
        Me.dgvmanual.Name = "dgvmanual"
        Me.dgvmanual.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvmanual.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvmanual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvmanual.Size = New System.Drawing.Size(1266, 376)
        Me.dgvmanual.TabIndex = 19
        '
        'dgResultado
        '
        Me.dgResultado.HeaderText = "Resultados"
        Me.dgResultado.Name = "dgResultado"
        Me.dgResultado.Text = "Resultados"
        Me.dgResultado.UseColumnTextForButtonValue = True
        Me.dgResultado.Width = 65
        '
        'pag2
        '
        Me.pag2.Controls.Add(Me.GroupBox2)
        Me.pag2.Location = New System.Drawing.Point(4, 22)
        Me.pag2.Name = "pag2"
        Me.pag2.Padding = New System.Windows.Forms.Padding(3)
        Me.pag2.Size = New System.Drawing.Size(1278, 413)
        Me.pag2.TabIndex = 1
        Me.pag2.Text = "Consolidado"
        Me.pag2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvConsolidadoExam)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1272, 407)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Examenes:"
        '
        'dgvConsolidadoExam
        '
        Me.dgvConsolidadoExam.AllowUserToAddRows = False
        Me.dgvConsolidadoExam.AllowUserToDeleteRows = False
        Me.dgvConsolidadoExam.AllowUserToResizeColumns = False
        Me.dgvConsolidadoExam.AllowUserToResizeRows = False
        Me.dgvConsolidadoExam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvConsolidadoExam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvConsolidadoExam.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvConsolidadoExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConsolidadoExam.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvConsolidadoExam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsolidadoExam.Location = New System.Drawing.Point(3, 17)
        Me.dgvConsolidadoExam.MultiSelect = False
        Me.dgvConsolidadoExam.Name = "dgvConsolidadoExam"
        Me.dgvConsolidadoExam.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvConsolidadoExam.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvConsolidadoExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvConsolidadoExam.Size = New System.Drawing.Size(1266, 387)
        Me.dgvConsolidadoExam.TabIndex = 19
        '
        'npaciente
        '
        Me.npaciente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.npaciente.AutoSize = True
        Me.npaciente.BackColor = System.Drawing.Color.Transparent
        Me.npaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.npaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.npaciente.Location = New System.Drawing.Point(1244, 531)
        Me.npaciente.Name = "npaciente"
        Me.npaciente.Size = New System.Drawing.Size(14, 15)
        Me.npaciente.TabIndex = 10058
        Me.npaciente.Text = "0"
        Me.npaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTitulo
        '
        Me.lbTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTitulo.AutoSize = True
        Me.lbTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lbTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lbTitulo.ForeColor = System.Drawing.Color.Black
        Me.lbTitulo.Location = New System.Drawing.Point(1104, 532)
        Me.lbTitulo.Name = "lbTitulo"
        Me.lbTitulo.Size = New System.Drawing.Size(124, 15)
        Me.lbTitulo.TabIndex = 10056
        Me.lbTitulo.Text = "Cantidad de examén:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 16)
        Me.Label1.TabIndex = 10045
        Me.Label1.Text = "LISTADO DE EXAMENES "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1249, 20)
        Me.Label2.TabIndex = 10046
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.laboratory_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10047
        Me.PictureBox1.TabStop = False
        '
        'gbCodigo
        '
        Me.gbCodigo.Controls.Add(Me.TextBox1)
        Me.gbCodigo.Controls.Add(Me.Label6)
        Me.gbCodigo.Location = New System.Drawing.Point(10, 42)
        Me.gbCodigo.Name = "gbCodigo"
        Me.gbCodigo.Size = New System.Drawing.Size(162, 35)
        Me.gbCodigo.TabIndex = 10068
        Me.gbCodigo.TabStop = False
        Me.gbCodigo.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(67, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(79, 21)
        Me.TextBox1.TabIndex = 10071
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 15)
        Me.Label6.TabIndex = 10070
        Me.Label6.Text = "Codigo:"
        '
        'FormListaExamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 617)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "FormListaExamen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PanelBotones.ResumeLayout(False)
        Me.PanelBotones.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbEstadoAtencion.ResumeLayout(False)
        Me.gbEstadoAtencion.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.pag1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvmanual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pag2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvConsolidadoExam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCodigo.ResumeLayout(False)
        Me.gbCodigo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Protected WithEvents lbTitulo As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents pag1 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgvmanual As DataGridView
    Friend WithEvents dgResultado As DataGridViewButtonColumn
    Friend WithEvents gbEstadoAtencion As GroupBox
    Friend WithEvents chRealizado As RadioButton
    Friend WithEvents chPendiente As RadioButton
    Friend WithEvents comboAreaServicio As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pag2 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvConsolidadoExam As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtFechaFinCons As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents dtFcehaIniCons As DateTimePicker
    Friend WithEvents cbLaboratorio As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtBuscarConsildado As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents npaciente As Label
    Friend WithEvents lbTotal As Label
    Friend WithEvents lbSub As Label
    Protected WithEvents Label5 As Label
    Protected WithEvents Label4 As Label
    Friend WithEvents PanelBotones As Panel
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btConsultado As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btVistaPrevia As ToolStripDropDownButton
    Friend WithEvents VistaPreviaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturaToolStripMenuItem As ToolStripMenuItem
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Friend WithEvents gbCodigo As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label6 As Label
End Class
