<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmbarazo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmbarazo))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbAntecedente = New System.Windows.Forms.GroupBox()
        Me.txtNombreUsuarioInforme = New System.Windows.Forms.TextBox()
        Me.txtTorch = New System.Windows.Forms.TextBox()
        Me.txtNombreUsuarioINFN = New System.Windows.Forms.TextBox()
        Me.Label161 = New System.Windows.Forms.Label()
        Me.txtVacunacionN = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.txtEnferTN = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.txtPreeclampciaN = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtHiperGN = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.txtDiabeteMN = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.txtDiabeteGN = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.txtInfeccionesN = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtHabitosN = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtMedDurEmbN = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtControlPN = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.txtHemMN = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtObstetricosN = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtFumN = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.txtEdadGestN = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.txtVIH = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.txtNombreContrato = New System.Windows.Forms.TextBox()
        Me.txtContrato = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEstancia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSexo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAdmision = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRegistro = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbAntecedente.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btguardar, Me.ToolStripSeparator3, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 562)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1310, 54)
        Me.ToolStrip1.TabIndex = 10080
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbAntecedente)
        Me.GroupBox1.Controls.Add(Me.gbDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1286, 505)
        Me.GroupBox1.TabIndex = 10079
        Me.GroupBox1.TabStop = False
        '
        'gbAntecedente
        '
        Me.gbAntecedente.Controls.Add(Me.txtNombreUsuarioInforme)
        Me.gbAntecedente.Controls.Add(Me.txtTorch)
        Me.gbAntecedente.Controls.Add(Me.txtNombreUsuarioINFN)
        Me.gbAntecedente.Controls.Add(Me.Label161)
        Me.gbAntecedente.Controls.Add(Me.txtVacunacionN)
        Me.gbAntecedente.Controls.Add(Me.Label83)
        Me.gbAntecedente.Controls.Add(Me.txtEnferTN)
        Me.gbAntecedente.Controls.Add(Me.Label84)
        Me.gbAntecedente.Controls.Add(Me.txtPreeclampciaN)
        Me.gbAntecedente.Controls.Add(Me.Label79)
        Me.gbAntecedente.Controls.Add(Me.txtHiperGN)
        Me.gbAntecedente.Controls.Add(Me.Label80)
        Me.gbAntecedente.Controls.Add(Me.txtDiabeteMN)
        Me.gbAntecedente.Controls.Add(Me.Label81)
        Me.gbAntecedente.Controls.Add(Me.txtDiabeteGN)
        Me.gbAntecedente.Controls.Add(Me.Label82)
        Me.gbAntecedente.Controls.Add(Me.txtInfeccionesN)
        Me.gbAntecedente.Controls.Add(Me.Label69)
        Me.gbAntecedente.Controls.Add(Me.txtHabitosN)
        Me.gbAntecedente.Controls.Add(Me.Label76)
        Me.gbAntecedente.Controls.Add(Me.txtMedDurEmbN)
        Me.gbAntecedente.Controls.Add(Me.Label77)
        Me.gbAntecedente.Controls.Add(Me.txtControlPN)
        Me.gbAntecedente.Controls.Add(Me.Label78)
        Me.gbAntecedente.Controls.Add(Me.txtHemMN)
        Me.gbAntecedente.Controls.Add(Me.Label71)
        Me.gbAntecedente.Controls.Add(Me.txtObstetricosN)
        Me.gbAntecedente.Controls.Add(Me.Label72)
        Me.gbAntecedente.Controls.Add(Me.txtFumN)
        Me.gbAntecedente.Controls.Add(Me.Label73)
        Me.gbAntecedente.Controls.Add(Me.txtEdadGestN)
        Me.gbAntecedente.Controls.Add(Me.Label74)
        Me.gbAntecedente.Controls.Add(Me.txtVIH)
        Me.gbAntecedente.Controls.Add(Me.Label75)
        Me.gbAntecedente.ForeColor = System.Drawing.Color.RoyalBlue
        Me.gbAntecedente.Location = New System.Drawing.Point(7, 88)
        Me.gbAntecedente.Name = "gbAntecedente"
        Me.gbAntecedente.Size = New System.Drawing.Size(1269, 411)
        Me.gbAntecedente.TabIndex = 10092
        Me.gbAntecedente.TabStop = False
        Me.gbAntecedente.Text = "Antecedentes:"
        '
        'txtNombreUsuarioInforme
        '
        Me.txtNombreUsuarioInforme.BackColor = System.Drawing.Color.White
        Me.txtNombreUsuarioInforme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombreUsuarioInforme.Location = New System.Drawing.Point(958, -22)
        Me.txtNombreUsuarioInforme.Name = "txtNombreUsuarioInforme"
        Me.txtNombreUsuarioInforme.ReadOnly = True
        Me.txtNombreUsuarioInforme.Size = New System.Drawing.Size(307, 13)
        Me.txtNombreUsuarioInforme.TabIndex = 10076
        '
        'txtTorch
        '
        Me.txtTorch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTorch.Location = New System.Drawing.Point(751, 327)
        Me.txtTorch.Multiline = True
        Me.txtTorch.Name = "txtTorch"
        Me.txtTorch.ReadOnly = True
        Me.txtTorch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTorch.Size = New System.Drawing.Size(492, 41)
        Me.txtTorch.TabIndex = 10086
        '
        'txtNombreUsuarioINFN
        '
        Me.txtNombreUsuarioINFN.BackColor = System.Drawing.Color.White
        Me.txtNombreUsuarioINFN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombreUsuarioINFN.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNombreUsuarioINFN.Location = New System.Drawing.Point(962, 1)
        Me.txtNombreUsuarioINFN.Name = "txtNombreUsuarioINFN"
        Me.txtNombreUsuarioINFN.ReadOnly = True
        Me.txtNombreUsuarioINFN.Size = New System.Drawing.Size(297, 13)
        Me.txtNombreUsuarioINFN.TabIndex = 10075
        Me.txtNombreUsuarioINFN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label161
        '
        Me.Label161.AutoSize = True
        Me.Label161.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label161.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label161.Location = New System.Drawing.Point(649, 330)
        Me.Label161.Name = "Label161"
        Me.Label161.Size = New System.Drawing.Size(41, 15)
        Me.Label161.TabIndex = 10085
        Me.Label161.Text = "Torch:"
        '
        'txtVacunacionN
        '
        Me.txtVacunacionN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVacunacionN.Location = New System.Drawing.Point(751, 280)
        Me.txtVacunacionN.Multiline = True
        Me.txtVacunacionN.Name = "txtVacunacionN"
        Me.txtVacunacionN.ReadOnly = True
        Me.txtVacunacionN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVacunacionN.Size = New System.Drawing.Size(492, 41)
        Me.txtVacunacionN.TabIndex = 10084
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label83.Location = New System.Drawing.Point(673, 283)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(74, 15)
        Me.Label83.TabIndex = 10083
        Me.Label83.Text = "Vacunación:"
        '
        'txtEnferTN
        '
        Me.txtEnferTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnferTN.Location = New System.Drawing.Point(115, 327)
        Me.txtEnferTN.Multiline = True
        Me.txtEnferTN.Name = "txtEnferTN"
        Me.txtEnferTN.ReadOnly = True
        Me.txtEnferTN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEnferTN.Size = New System.Drawing.Size(484, 41)
        Me.txtEnferTN.TabIndex = 10082
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label84.Location = New System.Drawing.Point(13, 330)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(90, 15)
        Me.Label84.TabIndex = 10081
        Me.Label84.Text = "Enfer. Tiroidea:"
        '
        'txtPreeclampciaN
        '
        Me.txtPreeclampciaN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreeclampciaN.Location = New System.Drawing.Point(751, 233)
        Me.txtPreeclampciaN.Multiline = True
        Me.txtPreeclampciaN.Name = "txtPreeclampciaN"
        Me.txtPreeclampciaN.ReadOnly = True
        Me.txtPreeclampciaN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPreeclampciaN.Size = New System.Drawing.Size(492, 41)
        Me.txtPreeclampciaN.TabIndex = 10080
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label79.Location = New System.Drawing.Point(661, 236)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(86, 15)
        Me.Label79.TabIndex = 10079
        Me.Label79.Text = "Preeclampcia:"
        '
        'txtHiperGN
        '
        Me.txtHiperGN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHiperGN.Location = New System.Drawing.Point(115, 280)
        Me.txtHiperGN.Multiline = True
        Me.txtHiperGN.Name = "txtHiperGN"
        Me.txtHiperGN.ReadOnly = True
        Me.txtHiperGN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHiperGN.Size = New System.Drawing.Size(484, 41)
        Me.txtHiperGN.TabIndex = 10078
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label80.Location = New System.Drawing.Point(13, 283)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(98, 15)
        Me.Label80.TabIndex = 10077
        Me.Label80.Text = "Hiper. Gestional:"
        '
        'txtDiabeteMN
        '
        Me.txtDiabeteMN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiabeteMN.Location = New System.Drawing.Point(751, 186)
        Me.txtDiabeteMN.Multiline = True
        Me.txtDiabeteMN.Name = "txtDiabeteMN"
        Me.txtDiabeteMN.ReadOnly = True
        Me.txtDiabeteMN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDiabeteMN.Size = New System.Drawing.Size(492, 41)
        Me.txtDiabeteMN.TabIndex = 10076
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label81.Location = New System.Drawing.Point(662, 189)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(85, 15)
        Me.Label81.TabIndex = 10075
        Me.Label81.Text = "Diab. Mellitus:"
        '
        'txtDiabeteGN
        '
        Me.txtDiabeteGN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiabeteGN.Location = New System.Drawing.Point(115, 233)
        Me.txtDiabeteGN.Multiline = True
        Me.txtDiabeteGN.Name = "txtDiabeteGN"
        Me.txtDiabeteGN.ReadOnly = True
        Me.txtDiabeteGN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDiabeteGN.Size = New System.Drawing.Size(484, 41)
        Me.txtDiabeteGN.TabIndex = 10074
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label82.Location = New System.Drawing.Point(13, 236)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(94, 15)
        Me.Label82.TabIndex = 10073
        Me.Label82.Text = "Diab. Gestional:"
        '
        'txtInfeccionesN
        '
        Me.txtInfeccionesN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfeccionesN.Location = New System.Drawing.Point(751, 140)
        Me.txtInfeccionesN.Multiline = True
        Me.txtInfeccionesN.Name = "txtInfeccionesN"
        Me.txtInfeccionesN.ReadOnly = True
        Me.txtInfeccionesN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfeccionesN.Size = New System.Drawing.Size(492, 41)
        Me.txtInfeccionesN.TabIndex = 10072
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(631, 143)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(121, 15)
        Me.Label69.TabIndex = 10071
        Me.Label69.Text = "Infecciones en Emb.:"
        '
        'txtHabitosN
        '
        Me.txtHabitosN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHabitosN.Location = New System.Drawing.Point(115, 187)
        Me.txtHabitosN.Multiline = True
        Me.txtHabitosN.Name = "txtHabitosN"
        Me.txtHabitosN.ReadOnly = True
        Me.txtHabitosN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHabitosN.Size = New System.Drawing.Size(484, 41)
        Me.txtHabitosN.TabIndex = 10070
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label76.Location = New System.Drawing.Point(13, 190)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(52, 15)
        Me.Label76.TabIndex = 10069
        Me.Label76.Text = "Hábitos:"
        '
        'txtMedDurEmbN
        '
        Me.txtMedDurEmbN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedDurEmbN.Location = New System.Drawing.Point(751, 93)
        Me.txtMedDurEmbN.Multiline = True
        Me.txtMedDurEmbN.Name = "txtMedDurEmbN"
        Me.txtMedDurEmbN.ReadOnly = True
        Me.txtMedDurEmbN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMedDurEmbN.Size = New System.Drawing.Size(492, 41)
        Me.txtMedDurEmbN.TabIndex = 10068
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label77.Location = New System.Drawing.Point(634, 96)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(120, 15)
        Me.Label77.TabIndex = 10067
        Me.Label77.Text = "Med.  Durante Emb.:"
        '
        'txtControlPN
        '
        Me.txtControlPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtControlPN.Location = New System.Drawing.Point(115, 140)
        Me.txtControlPN.Multiline = True
        Me.txtControlPN.Name = "txtControlPN"
        Me.txtControlPN.ReadOnly = True
        Me.txtControlPN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtControlPN.Size = New System.Drawing.Size(484, 41)
        Me.txtControlPN.TabIndex = 10066
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label78.Location = New System.Drawing.Point(13, 143)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(98, 15)
        Me.Label78.TabIndex = 10065
        Me.Label78.Text = "Control Prenatal:"
        '
        'txtHemMN
        '
        Me.txtHemMN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHemMN.Location = New System.Drawing.Point(115, 93)
        Me.txtHemMN.Multiline = True
        Me.txtHemMN.Name = "txtHemMN"
        Me.txtHemMN.ReadOnly = True
        Me.txtHemMN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHemMN.Size = New System.Drawing.Size(484, 41)
        Me.txtHemMN.TabIndex = 10062
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label71.Location = New System.Drawing.Point(13, 96)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(105, 15)
        Me.Label71.TabIndex = 10061
        Me.Label71.Text = "Hem/sificación.M:"
        '
        'txtObstetricosN
        '
        Me.txtObstetricosN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObstetricosN.Location = New System.Drawing.Point(751, 46)
        Me.txtObstetricosN.Multiline = True
        Me.txtObstetricosN.Name = "txtObstetricosN"
        Me.txtObstetricosN.ReadOnly = True
        Me.txtObstetricosN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObstetricosN.Size = New System.Drawing.Size(492, 41)
        Me.txtObstetricosN.TabIndex = 10060
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label72.Location = New System.Drawing.Point(676, 49)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(71, 15)
        Me.Label72.TabIndex = 10059
        Me.Label72.Text = "Obstétricos:"
        '
        'txtFumN
        '
        Me.txtFumN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFumN.Location = New System.Drawing.Point(115, 46)
        Me.txtFumN.Multiline = True
        Me.txtFumN.Name = "txtFumN"
        Me.txtFumN.ReadOnly = True
        Me.txtFumN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFumN.Size = New System.Drawing.Size(484, 41)
        Me.txtFumN.TabIndex = 10058
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label73.Location = New System.Drawing.Point(13, 49)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(37, 15)
        Me.Label73.TabIndex = 10057
        Me.Label73.Text = "FUM:"
        '
        'txtEdadGestN
        '
        Me.txtEdadGestN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdadGestN.Location = New System.Drawing.Point(751, 20)
        Me.txtEdadGestN.Name = "txtEdadGestN"
        Me.txtEdadGestN.ReadOnly = True
        Me.txtEdadGestN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEdadGestN.Size = New System.Drawing.Size(492, 21)
        Me.txtEdadGestN.TabIndex = 10056
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label74.Location = New System.Drawing.Point(642, 23)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(107, 15)
        Me.Label74.TabIndex = 10055
        Me.Label74.Text = "Edad Gestacional:"
        '
        'txtVIH
        '
        Me.txtVIH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVIH.Location = New System.Drawing.Point(115, 20)
        Me.txtVIH.Name = "txtVIH"
        Me.txtVIH.ReadOnly = True
        Me.txtVIH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVIH.Size = New System.Drawing.Size(484, 21)
        Me.txtVIH.TabIndex = 10054
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label75.Location = New System.Drawing.Point(13, 23)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(29, 15)
        Me.Label75.TabIndex = 10053
        Me.Label75.Text = "VIH:"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtNombreContrato)
        Me.gbDatos.Controls.Add(Me.txtContrato)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.txtEstancia)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.txtEdad)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.txtSexo)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtNombre)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.txtAdmision)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.txtHC)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtRegistro)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.ForeColor = System.Drawing.Color.RoyalBlue
        Me.gbDatos.Location = New System.Drawing.Point(7, 13)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(1269, 69)
        Me.gbDatos.TabIndex = 1
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Información del paciente:"
        '
        'txtNombreContrato
        '
        Me.txtNombreContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreContrato.Location = New System.Drawing.Point(546, 42)
        Me.txtNombreContrato.Name = "txtNombreContrato"
        Me.txtNombreContrato.ReadOnly = True
        Me.txtNombreContrato.Size = New System.Drawing.Size(502, 21)
        Me.txtNombreContrato.TabIndex = 10067
        '
        'txtContrato
        '
        Me.txtContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContrato.Location = New System.Drawing.Point(470, 42)
        Me.txtContrato.Name = "txtContrato"
        Me.txtContrato.ReadOnly = True
        Me.txtContrato.Size = New System.Drawing.Size(72, 21)
        Me.txtContrato.TabIndex = 10066
        Me.txtContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(412, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 15)
        Me.Label9.TabIndex = 10065
        Me.Label9.Text = "Contrato:"
        '
        'txtEstancia
        '
        Me.txtEstancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstancia.Location = New System.Drawing.Point(293, 42)
        Me.txtEstancia.Name = "txtEstancia"
        Me.txtEstancia.ReadOnly = True
        Me.txtEstancia.Size = New System.Drawing.Size(114, 21)
        Me.txtEstancia.TabIndex = 10064
        Me.txtEstancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(232, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 10063
        Me.Label8.Text = "Estancia:"
        '
        'txtEdad
        '
        Me.txtEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdad.Location = New System.Drawing.Point(1132, 18)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.ReadOnly = True
        Me.txtEdad.Size = New System.Drawing.Size(114, 21)
        Me.txtEdad.TabIndex = 10062
        Me.txtEdad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(1091, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 10061
        Me.Label7.Text = "Edad:"
        '
        'txtSexo
        '
        Me.txtSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSexo.Location = New System.Drawing.Point(934, 18)
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.ReadOnly = True
        Me.txtSexo.Size = New System.Drawing.Size(114, 21)
        Me.txtSexo.TabIndex = 10060
        Me.txtSexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(893, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 10059
        Me.Label6.Text = "Sexo:"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(470, 18)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(394, 21)
        Me.txtNombre.TabIndex = 10058
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(412, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 10057
        Me.Label5.Text = "Nombre:"
        '
        'txtAdmision
        '
        Me.txtAdmision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdmision.Location = New System.Drawing.Point(76, 42)
        Me.txtAdmision.Name = "txtAdmision"
        Me.txtAdmision.ReadOnly = True
        Me.txtAdmision.Size = New System.Drawing.Size(150, 21)
        Me.txtAdmision.TabIndex = 10056
        Me.txtAdmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(10, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 10055
        Me.Label4.Text = "Admisión:"
        '
        'txtHC
        '
        Me.txtHC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHC.Location = New System.Drawing.Point(293, 18)
        Me.txtHC.Name = "txtHC"
        Me.txtHC.ReadOnly = True
        Me.txtHC.Size = New System.Drawing.Size(114, 21)
        Me.txtHC.TabIndex = 10054
        Me.txtHC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(197, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 15)
        Me.Label3.TabIndex = 10053
        Me.Label3.Text = "Historia Clínica:"
        '
        'txtRegistro
        '
        Me.txtRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistro.Location = New System.Drawing.Point(76, 18)
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.ReadOnly = True
        Me.txtRegistro.Size = New System.Drawing.Size(88, 21)
        Me.txtRegistro.TabIndex = 10052
        Me.txtRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(10, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 10051
        Me.Label10.Text = "Registro:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10078
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 16)
        Me.Label1.TabIndex = 10076
        Me.Label1.Text = "FORMATO DE EMBARAZO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1234, 20)
        Me.Label2.TabIndex = 10077
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______________"
        '
        'FormEmbarazo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "FormEmbarazo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbAntecedente.ResumeLayout(False)
        Me.gbAntecedente.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents btimprimir As ToolStripButton
    Public WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents gbAntecedente As GroupBox
    Friend WithEvents txtTorch As TextBox
    Friend WithEvents Label161 As Label
    Friend WithEvents txtVacunacionN As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents txtEnferTN As TextBox
    Friend WithEvents Label84 As Label
    Friend WithEvents txtPreeclampciaN As TextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents txtHiperGN As TextBox
    Friend WithEvents Label80 As Label
    Friend WithEvents txtDiabeteMN As TextBox
    Friend WithEvents Label81 As Label
    Friend WithEvents txtDiabeteGN As TextBox
    Friend WithEvents Label82 As Label
    Friend WithEvents txtInfeccionesN As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents txtHabitosN As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents txtMedDurEmbN As TextBox
    Friend WithEvents Label77 As Label
    Friend WithEvents txtControlPN As TextBox
    Friend WithEvents Label78 As Label
    Friend WithEvents txtHemMN As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents txtObstetricosN As TextBox
    Friend WithEvents Label72 As Label
    Friend WithEvents txtFumN As TextBox
    Friend WithEvents Label73 As Label
    Friend WithEvents txtEdadGestN As TextBox
    Friend WithEvents Label74 As Label
    Friend WithEvents txtVIH As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents gbDatos As GroupBox
    Friend WithEvents txtNombreContrato As TextBox
    Friend WithEvents txtContrato As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEstancia As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEdad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSexo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAdmision As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHC As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRegistro As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNombreUsuarioInforme As TextBox
    Friend WithEvents txtNombreUsuarioINFN As TextBox
End Class
