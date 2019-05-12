<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_resultado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_resultado))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
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
        Me.openPdf = New System.Windows.Forms.OpenFileDialog()
        Me.GroupControlDCM = New System.Windows.Forms.GroupBox()
        Me.menuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TamañoCompletoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TamañoNormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.controlDCM = New AxezDICOMax.AxezDICOMX()
        Me.pdfArchivos = New AxAcroPDFLib.AxAcroPDF()
        Me.panelGrabadora = New System.Windows.Forms.Panel()
        Me.btEliminar = New System.Windows.Forms.Button()
        Me.btDetener = New System.Windows.Forms.Button()
        Me.btPausa = New System.Windows.Forms.Button()
        Me.btReproducir = New System.Windows.Forms.Button()
        Me.btGrabar = New System.Windows.Forms.Button()
        Me.btImagen = New System.Windows.Forms.Button()
        Me.Groupnota = New System.Windows.Forms.GroupBox()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.comboDgvInfor = New System.Windows.Forms.GroupBox()
        Me.dgvArchivos = New System.Windows.Forms.DataGridView()
        Me.dgruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgquitar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btSubir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCodigo = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCodigoExamen = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.txtExamen = New System.Windows.Forms.ToolStripTextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btPlantilla = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupControlDCM.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.controlDCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pdfArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelGrabadora.SuspendLayout()
        Me.Groupnota.SuspendLayout()
        Me.comboDgvInfor.SuspendLayout()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 10048
        Me.Label1.Text = "Titulo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1234, 20)
        Me.Label2.TabIndex = 10049
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______________"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Doctor-icon (1).png")
        Me.ImageList1.Images.SetKeyName(1, "Medical-Nurse-Female-Dark-icon (1).png")
        Me.ImageList1.Images.SetKeyName(2, "Medical-Nurse-Male-Light-icon (1).png")
        Me.ImageList1.Images.SetKeyName(3, "nurse-icon1.png")
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Quitar/Anular"
        Me.DataGridViewImageColumn1.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 76
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = "Quitar/Anular"
        Me.DataGridViewImageColumn2.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Width = 76
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.HeaderText = "Quitar/Anular"
        Me.DataGridViewImageColumn3.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.Width = 76
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Documents_icon2
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10050
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 562)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1310, 54)
        Me.ToolStrip1.TabIndex = 10052
        Me.ToolStrip1.Text = "Hallazgo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
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
        'bteditar
        '
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
        'openPdf
        '
        Me.openPdf.FileName = "Resultados"
        '
        'GroupControlDCM
        '
        Me.GroupControlDCM.ContextMenuStrip = Me.menuStrip
        Me.GroupControlDCM.Controls.Add(Me.SplitContainer1)
        Me.GroupControlDCM.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControlDCM.Location = New System.Drawing.Point(6, 10)
        Me.GroupControlDCM.Name = "GroupControlDCM"
        Me.GroupControlDCM.Size = New System.Drawing.Size(1289, 461)
        Me.GroupControlDCM.TabIndex = 10052
        Me.GroupControlDCM.TabStop = False
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TamañoCompletoToolStripMenuItem, Me.TamañoNormalToolStripMenuItem})
        Me.menuStrip.Name = "menu"
        Me.menuStrip.Size = New System.Drawing.Size(173, 48)
        '
        'TamañoCompletoToolStripMenuItem
        '
        Me.TamañoCompletoToolStripMenuItem.Name = "TamañoCompletoToolStripMenuItem"
        Me.TamañoCompletoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.TamañoCompletoToolStripMenuItem.Text = "Tamaño completo"
        '
        'TamañoNormalToolStripMenuItem
        '
        Me.TamañoNormalToolStripMenuItem.Name = "TamañoNormalToolStripMenuItem"
        Me.TamañoNormalToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.TamañoNormalToolStripMenuItem.Text = "Tamaño Normal"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.controlDCM)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pdfArchivos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPlantilla)
        Me.SplitContainer1.Panel2.Controls.Add(Me.panelGrabadora)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btImagen)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Groupnota)
        Me.SplitContainer1.Panel2.Controls.Add(Me.comboDgvInfor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btSubir)
        Me.SplitContainer1.Size = New System.Drawing.Size(1283, 441)
        Me.SplitContainer1.SplitterDistance = 975
        Me.SplitContainer1.TabIndex = 0
        '
        'controlDCM
        '
        Me.controlDCM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.controlDCM.Location = New System.Drawing.Point(0, 0)
        Me.controlDCM.Name = "controlDCM"
        Me.controlDCM.OcxState = CType(resources.GetObject("controlDCM.OcxState"), System.Windows.Forms.AxHost.State)
        Me.controlDCM.Size = New System.Drawing.Size(975, 441)
        Me.controlDCM.TabIndex = 4
        '
        'pdfArchivos
        '
        Me.pdfArchivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfArchivos.Enabled = True
        Me.pdfArchivos.Location = New System.Drawing.Point(0, 0)
        Me.pdfArchivos.Name = "pdfArchivos"
        Me.pdfArchivos.OcxState = CType(resources.GetObject("pdfArchivos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfArchivos.Size = New System.Drawing.Size(975, 441)
        Me.pdfArchivos.TabIndex = 3
        Me.pdfArchivos.Visible = False
        '
        'panelGrabadora
        '
        Me.panelGrabadora.Controls.Add(Me.btEliminar)
        Me.panelGrabadora.Controls.Add(Me.btDetener)
        Me.panelGrabadora.Controls.Add(Me.btPausa)
        Me.panelGrabadora.Controls.Add(Me.btReproducir)
        Me.panelGrabadora.Controls.Add(Me.btGrabar)
        Me.panelGrabadora.Location = New System.Drawing.Point(5, 399)
        Me.panelGrabadora.Name = "panelGrabadora"
        Me.panelGrabadora.Size = New System.Drawing.Size(291, 37)
        Me.panelGrabadora.TabIndex = 10061
        '
        'btEliminar
        '
        Me.btEliminar.Image = Global.Celer.My.Resources.Resources.trash_icon2
        Me.btEliminar.Location = New System.Drawing.Point(234, 2)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(37, 33)
        Me.btEliminar.TabIndex = 4
        Me.btEliminar.UseVisualStyleBackColor = True
        '
        'btDetener
        '
        Me.btDetener.Image = Global.Celer.My.Resources.Resources.Stop_red_icon__1_
        Me.btDetener.Location = New System.Drawing.Point(181, 2)
        Me.btDetener.Name = "btDetener"
        Me.btDetener.Size = New System.Drawing.Size(37, 33)
        Me.btDetener.TabIndex = 3
        Me.btDetener.UseVisualStyleBackColor = True
        '
        'btPausa
        '
        Me.btPausa.Image = Global.Celer.My.Resources.Resources.Button_Pause_icon
        Me.btPausa.Location = New System.Drawing.Point(75, 2)
        Me.btPausa.Name = "btPausa"
        Me.btPausa.Size = New System.Drawing.Size(37, 33)
        Me.btPausa.TabIndex = 2
        Me.btPausa.UseVisualStyleBackColor = True
        '
        'btReproducir
        '
        Me.btReproducir.Image = Global.Celer.My.Resources.Resources.Button_Play_icon__1_
        Me.btReproducir.Location = New System.Drawing.Point(22, 2)
        Me.btReproducir.Name = "btReproducir"
        Me.btReproducir.Size = New System.Drawing.Size(37, 33)
        Me.btReproducir.TabIndex = 1
        Me.btReproducir.UseVisualStyleBackColor = True
        '
        'btGrabar
        '
        Me.btGrabar.Image = Global.Celer.My.Resources.Resources.microphone_icon__1_
        Me.btGrabar.Location = New System.Drawing.Point(128, 2)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(37, 33)
        Me.btGrabar.TabIndex = 0
        Me.btGrabar.UseVisualStyleBackColor = True
        '
        'btImagen
        '
        Me.btImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImagen.Image = Global.Celer.My.Resources.Resources.Image_JPEG_icon
        Me.btImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btImagen.Location = New System.Drawing.Point(10, 229)
        Me.btImagen.Name = "btImagen"
        Me.btImagen.Size = New System.Drawing.Size(91, 32)
        Me.btImagen.TabIndex = 10059
        Me.btImagen.Text = "Imagenes"
        Me.btImagen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btImagen.UseVisualStyleBackColor = True
        '
        'Groupnota
        '
        Me.Groupnota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Groupnota.Controls.Add(Me.txtNota)
        Me.Groupnota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Groupnota.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Groupnota.Location = New System.Drawing.Point(5, 265)
        Me.Groupnota.Name = "Groupnota"
        Me.Groupnota.Size = New System.Drawing.Size(295, 130)
        Me.Groupnota.TabIndex = 10060
        Me.Groupnota.TabStop = False
        Me.Groupnota.Text = "Lectura"
        '
        'txtNota
        '
        Me.txtNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(3, 17)
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNota.Size = New System.Drawing.Size(289, 110)
        Me.txtNota.TabIndex = 0
        '
        'comboDgvInfor
        '
        Me.comboDgvInfor.Controls.Add(Me.dgvArchivos)
        Me.comboDgvInfor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboDgvInfor.Location = New System.Drawing.Point(7, 3)
        Me.comboDgvInfor.Name = "comboDgvInfor"
        Me.comboDgvInfor.Size = New System.Drawing.Size(285, 223)
        Me.comboDgvInfor.TabIndex = 10057
        Me.comboDgvInfor.TabStop = False
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.AllowUserToResizeColumns = False
        Me.dgvArchivos.AllowUserToResizeRows = False
        Me.dgvArchivos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArchivos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgruta, Me.dgNombre, Me.dgquitar})
        Me.dgvArchivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvArchivos.Location = New System.Drawing.Point(3, 17)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.ReadOnly = True
        Me.dgvArchivos.RowHeadersVisible = False
        Me.dgvArchivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvArchivos.Size = New System.Drawing.Size(279, 203)
        Me.dgvArchivos.TabIndex = 7
        '
        'dgruta
        '
        Me.dgruta.HeaderText = "Ruta"
        Me.dgruta.Name = "dgruta"
        Me.dgruta.ReadOnly = True
        Me.dgruta.Visible = False
        '
        'dgNombre
        '
        Me.dgNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgNombre.HeaderText = "Nombre Archivo"
        Me.dgNombre.Name = "dgNombre"
        Me.dgNombre.ReadOnly = True
        '
        'dgquitar
        '
        Me.dgquitar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgquitar.HeaderText = "Quitar"
        Me.dgquitar.Image = Global.Celer.My.Resources.Resources.Papelera16
        Me.dgquitar.Name = "dgquitar"
        Me.dgquitar.ReadOnly = True
        Me.dgquitar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgquitar.Width = 46
        '
        'btSubir
        '
        Me.btSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSubir.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.btSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btSubir.Location = New System.Drawing.Point(104, 229)
        Me.btSubir.Name = "btSubir"
        Me.btSubir.Size = New System.Drawing.Size(104, 32)
        Me.btSubir.TabIndex = 10058
        Me.btSubir.Text = "Documento"
        Me.btSubir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSubir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ToolStrip2)
        Me.GroupBox1.Controls.Add(Me.GroupControlDCM)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1298, 502)
        Me.GroupBox1.TabIndex = 10051
        Me.GroupBox1.TabStop = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtCodigo, Me.ToolStripLabel3, Me.txtCodigoExamen, Me.ToolStripLabel2, Me.txtExamen})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 474)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1292, 25)
        Me.ToolStrip2.TabIndex = 10053
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(85, 22)
        Me.ToolStripLabel1.Text = "Codigo Orden:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(100, 25)
        Me.txtCodigo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripLabel3.Text = "Codigo:"
        '
        'txtCodigoExamen
        '
        Me.txtCodigoExamen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoExamen.Name = "txtCodigoExamen"
        Me.txtCodigoExamen.ReadOnly = True
        Me.txtCodigoExamen.Size = New System.Drawing.Size(100, 25)
        Me.txtCodigoExamen.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripLabel2.Text = "Nombre del Archivo:"
        '
        'txtExamen
        '
        Me.txtExamen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExamen.Name = "txtExamen"
        Me.txtExamen.ReadOnly = True
        Me.txtExamen.Size = New System.Drawing.Size(600, 25)
        Me.txtExamen.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 430
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.HeaderText = "Justificación"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 64
        '
        'btPlantilla
        '
        Me.btPlantilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPlantilla.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.btPlantilla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btPlantilla.Location = New System.Drawing.Point(211, 229)
        Me.btPlantilla.Name = "btPlantilla"
        Me.btPlantilla.Size = New System.Drawing.Size(81, 32)
        Me.btPlantilla.TabIndex = 10062
        Me.btPlantilla.Text = "Plantilla"
        Me.btPlantilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPlantilla.UseVisualStyleBackColor = True
        '
        'Form_resultado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "Form_resultado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupControlDCM.ResumeLayout(False)
        Me.menuStrip.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.controlDCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pdfArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelGrabadora.ResumeLayout(False)
        Me.Groupnota.ResumeLayout(False)
        Me.Groupnota.PerformLayout()
        Me.comboDgvInfor.ResumeLayout(False)
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn3 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDateTimePickerColumn1 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btguardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents bteditar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btcancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btanular As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents openPdf As OpenFileDialog
    Friend WithEvents GroupControlDCM As GroupBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btSubir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents menuStrip As ContextMenuStrip
    Friend WithEvents TamañoCompletoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TamañoNormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btImagen As Button
    Friend WithEvents Groupnota As GroupBox
    Friend WithEvents txtNota As TextBox
    Friend WithEvents comboDgvInfor As GroupBox
    Friend WithEvents dgvArchivos As DataGridView
    Friend WithEvents dgruta As DataGridViewTextBoxColumn
    Friend WithEvents dgNombre As DataGridViewTextBoxColumn
    Friend WithEvents dgquitar As DataGridViewImageColumn
    Friend WithEvents pdfArchivos As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents controlDCM As AxezDICOMax.AxezDICOMX
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txtCodigo As ToolStripTextBox
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents txtCodigoExamen As ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents txtExamen As ToolStripTextBox
    Friend WithEvents panelGrabadora As Panel
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents btGrabar As Button
    Friend WithEvents btEliminar As Button
    Friend WithEvents btDetener As Button
    Friend WithEvents btPausa As Button
    Friend WithEvents btReproducir As Button
    Friend WithEvents btPlantilla As Button
End Class
