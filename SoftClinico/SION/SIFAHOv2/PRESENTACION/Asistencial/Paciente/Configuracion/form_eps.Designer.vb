<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_eps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_eps))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btOpcionFormato = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbArchivos = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbFormato = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gbTipoArchivos = New System.Windows.Forms.GroupBox()
        Me.an = New System.Windows.Forms.CheckBox()
        Me.ap = New System.Windows.Forms.CheckBox()
        Me.us = New System.Windows.Forms.CheckBox()
        Me.at = New System.Windows.Forms.CheckBox()
        Me.au = New System.Windows.Forms.CheckBox()
        Me.ac = New System.Windows.Forms.CheckBox()
        Me.af = New System.Windows.Forms.CheckBox()
        Me.am = New System.Windows.Forms.CheckBox()
        Me.ah = New System.Windows.Forms.CheckBox()
        Me.ad = New System.Windows.Forms.CheckBox()
        Me.ct = New System.Windows.Forms.CheckBox()
        Me.rpersonalizado = New System.Windows.Forms.RadioButton()
        Me.rgeneral = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Textestancia = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboFormato = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Textcodigo_eps = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbArchivos.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gbTipoArchivos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Textestancia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Controls.Add(Me.btOpcionFormato)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 556)
        Me.Panel1.TabIndex = 0
        '
        'btOpcionFormato
        '
        Me.btOpcionFormato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionFormato.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btOpcionFormato.Image = Global.Celer.My.Resources.Resources.Documents_icon
        Me.btOpcionFormato.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btOpcionFormato.Location = New System.Drawing.Point(749, 4)
        Me.btOpcionFormato.Name = "btOpcionFormato"
        Me.btOpcionFormato.Size = New System.Drawing.Size(165, 34)
        Me.btOpcionFormato.TabIndex = 20
        Me.btOpcionFormato.Text = "Formato de Documentos"
        Me.btOpcionFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionFormato.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.btguardar, Me.btbuscar, Me.bteditar, Me.btcancelar, Me.btanular})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 18
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
        'btanular
        '
        Me.btanular.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btanular.Image = Global.Celer.My.Resources.Resources.Document_Delete_icon__1_
        Me.btanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btanular.Name = "btanular"
        Me.btanular.Size = New System.Drawing.Size(46, 51)
        Me.btanular.Text = "&Anular"
        Me.btanular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btanular.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.hotel_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "CONFIGURACIÓN DE EPS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(856, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbArchivos)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(910, 436)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'gbArchivos
        '
        Me.gbArchivos.Controls.Add(Me.GroupBox6)
        Me.gbArchivos.Controls.Add(Me.gbTipoArchivos)
        Me.gbArchivos.Controls.Add(Me.rpersonalizado)
        Me.gbArchivos.Controls.Add(Me.rgeneral)
        Me.gbArchivos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArchivos.Location = New System.Drawing.Point(20, 154)
        Me.gbArchivos.Name = "gbArchivos"
        Me.gbArchivos.Size = New System.Drawing.Size(867, 276)
        Me.gbArchivos.TabIndex = 3
        Me.gbArchivos.TabStop = False
        Me.gbArchivos.Text = "Configuración de Archivos Rips"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbFormato)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Location = New System.Drawing.Point(11, 47)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(328, 66)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Formato Personalizado"
        '
        'cbFormato
        '
        Me.cbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbFormato.FormattingEnabled = True
        Me.cbFormato.Items.AddRange(New Object() {"Predeterminado"})
        Me.cbFormato.Location = New System.Drawing.Point(95, 29)
        Me.cbFormato.Name = "cbFormato"
        Me.cbFormato.Size = New System.Drawing.Size(223, 23)
        Me.cbFormato.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(3, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 15)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Formato RIPS:"
        '
        'gbTipoArchivos
        '
        Me.gbTipoArchivos.Controls.Add(Me.an)
        Me.gbTipoArchivos.Controls.Add(Me.ap)
        Me.gbTipoArchivos.Controls.Add(Me.us)
        Me.gbTipoArchivos.Controls.Add(Me.at)
        Me.gbTipoArchivos.Controls.Add(Me.au)
        Me.gbTipoArchivos.Controls.Add(Me.ac)
        Me.gbTipoArchivos.Controls.Add(Me.af)
        Me.gbTipoArchivos.Controls.Add(Me.am)
        Me.gbTipoArchivos.Controls.Add(Me.ah)
        Me.gbTipoArchivos.Controls.Add(Me.ad)
        Me.gbTipoArchivos.Controls.Add(Me.ct)
        Me.gbTipoArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.gbTipoArchivos.Location = New System.Drawing.Point(11, 119)
        Me.gbTipoArchivos.Name = "gbTipoArchivos"
        Me.gbTipoArchivos.Size = New System.Drawing.Size(328, 151)
        Me.gbTipoArchivos.TabIndex = 3
        Me.gbTipoArchivos.TabStop = False
        '
        'an
        '
        Me.an.AutoSize = True
        Me.an.Location = New System.Drawing.Point(6, 123)
        Me.an.Name = "an"
        Me.an.Size = New System.Drawing.Size(42, 19)
        Me.an.TabIndex = 12
        Me.an.Text = "AN"
        Me.an.UseVisualStyleBackColor = True
        '
        'ap
        '
        Me.ap.AutoSize = True
        Me.ap.Location = New System.Drawing.Point(110, 55)
        Me.ap.Name = "ap"
        Me.ap.Size = New System.Drawing.Size(41, 19)
        Me.ap.TabIndex = 11
        Me.ap.Tag = "4"
        Me.ap.Text = "AP"
        Me.ap.UseVisualStyleBackColor = True
        '
        'us
        '
        Me.us.AutoSize = True
        Me.us.Location = New System.Drawing.Point(6, 55)
        Me.us.Name = "us"
        Me.us.Size = New System.Drawing.Size(43, 19)
        Me.us.TabIndex = 10
        Me.us.Tag = "2"
        Me.us.Text = "US"
        Me.us.UseVisualStyleBackColor = True
        '
        'at
        '
        Me.at.AutoSize = True
        Me.at.Location = New System.Drawing.Point(110, 101)
        Me.at.Name = "at"
        Me.at.Size = New System.Drawing.Size(40, 19)
        Me.at.TabIndex = 9
        Me.at.Tag = "6"
        Me.at.Text = "AT"
        Me.at.UseVisualStyleBackColor = True
        '
        'au
        '
        Me.au.AutoSize = True
        Me.au.Location = New System.Drawing.Point(6, 100)
        Me.au.Name = "au"
        Me.au.Size = New System.Drawing.Size(42, 19)
        Me.au.TabIndex = 8
        Me.au.Text = "AU"
        Me.au.UseVisualStyleBackColor = True
        '
        'ac
        '
        Me.ac.AutoSize = True
        Me.ac.Location = New System.Drawing.Point(110, 33)
        Me.ac.Name = "ac"
        Me.ac.Size = New System.Drawing.Size(41, 19)
        Me.ac.TabIndex = 7
        Me.ac.Tag = "3"
        Me.ac.Text = "AC"
        Me.ac.UseVisualStyleBackColor = True
        '
        'af
        '
        Me.af.AutoSize = True
        Me.af.Location = New System.Drawing.Point(6, 33)
        Me.af.Name = "af"
        Me.af.Size = New System.Drawing.Size(40, 19)
        Me.af.TabIndex = 6
        Me.af.Tag = "1"
        Me.af.Text = "AF"
        Me.af.UseVisualStyleBackColor = True
        '
        'am
        '
        Me.am.AutoSize = True
        Me.am.Location = New System.Drawing.Point(110, 80)
        Me.am.Name = "am"
        Me.am.Size = New System.Drawing.Size(44, 19)
        Me.am.TabIndex = 5
        Me.am.Tag = "0"
        Me.am.Text = "AM"
        Me.am.UseVisualStyleBackColor = True
        '
        'ah
        '
        Me.ah.AutoSize = True
        Me.ah.Location = New System.Drawing.Point(6, 78)
        Me.ah.Name = "ah"
        Me.ah.Size = New System.Drawing.Size(42, 19)
        Me.ah.TabIndex = 4
        Me.ah.Tag = "5"
        Me.ah.Text = "AH"
        Me.ah.UseVisualStyleBackColor = True
        '
        'ad
        '
        Me.ad.AutoSize = True
        Me.ad.Location = New System.Drawing.Point(110, 12)
        Me.ad.Name = "ad"
        Me.ad.Size = New System.Drawing.Size(42, 19)
        Me.ad.TabIndex = 3
        Me.ad.Text = "AD"
        Me.ad.UseVisualStyleBackColor = True
        '
        'ct
        '
        Me.ct.AutoSize = True
        Me.ct.Checked = True
        Me.ct.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ct.Location = New System.Drawing.Point(6, 12)
        Me.ct.Name = "ct"
        Me.ct.Size = New System.Drawing.Size(41, 19)
        Me.ct.TabIndex = 2
        Me.ct.Tag = "-1"
        Me.ct.Text = "CT"
        Me.ct.UseVisualStyleBackColor = True
        '
        'rpersonalizado
        '
        Me.rpersonalizado.AutoSize = True
        Me.rpersonalizado.Location = New System.Drawing.Point(106, 20)
        Me.rpersonalizado.Name = "rpersonalizado"
        Me.rpersonalizado.Size = New System.Drawing.Size(92, 20)
        Me.rpersonalizado.TabIndex = 1
        Me.rpersonalizado.Text = "Personalizado"
        Me.rpersonalizado.UseVisualStyleBackColor = True
        '
        'rgeneral
        '
        Me.rgeneral.AutoSize = True
        Me.rgeneral.Checked = True
        Me.rgeneral.Location = New System.Drawing.Point(11, 21)
        Me.rgeneral.Name = "rgeneral"
        Me.rgeneral.Size = New System.Drawing.Size(61, 20)
        Me.rgeneral.TabIndex = 0
        Me.rgeneral.TabStop = True
        Me.rgeneral.Text = "General"
        Me.rgeneral.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Textestancia)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ComboFormato)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Textcodigo_eps)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtnombre)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(867, 133)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Básicos"
        '
        'Textestancia
        '
        Me.Textestancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Textestancia.Location = New System.Drawing.Point(97, 78)
        Me.Textestancia.Name = "Textestancia"
        Me.Textestancia.Size = New System.Drawing.Size(57, 21)
        Me.Textestancia.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Dias Estancia:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Formato Solicitud NO POS:"
        '
        'ComboFormato
        '
        Me.ComboFormato.FormattingEnabled = True
        Me.ComboFormato.Location = New System.Drawing.Point(243, 49)
        Me.ComboFormato.Name = "ComboFormato"
        Me.ComboFormato.Size = New System.Drawing.Size(138, 24)
        Me.ComboFormato.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Código EPS:"
        '
        'Textcodigo_eps
        '
        Me.Textcodigo_eps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Textcodigo_eps.Location = New System.Drawing.Point(85, 23)
        Me.Textcodigo_eps.Name = "Textcodigo_eps"
        Me.Textcodigo_eps.ReadOnly = True
        Me.Textcodigo_eps.Size = New System.Drawing.Size(59, 21)
        Me.Textcodigo_eps.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(166, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Descripción:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(166, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Código:"
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtnombre.Location = New System.Drawing.Point(243, 22)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(407, 21)
        Me.txtnombre.TabIndex = 1
        '
        'txtcodigo
        '
        Me.txtcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigo.Location = New System.Drawing.Point(243, 79)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(59, 21)
        Me.txtcodigo.TabIndex = 0
        '
        'form_eps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "form_eps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "º"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbArchivos.ResumeLayout(False)
        Me.gbArchivos.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gbTipoArchivos.ResumeLayout(False)
        Me.gbTipoArchivos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Textestancia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents Panel1 As Panel
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label3 As Label
    Public WithEvents Label5 As Label
    Public WithEvents txtnombre As TextBox
    Public WithEvents txtcodigo As TextBox
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents btanular As ToolStripButton
    Public WithEvents Label4 As Label
    Public WithEvents Textcodigo_eps As TextBox
    Public WithEvents Label6 As Label
    Public WithEvents ComboFormato As ComboBox
    Public WithEvents Label7 As Label
    Friend WithEvents Textestancia As NumericUpDown
    Friend WithEvents gbArchivos As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cbFormato As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents gbTipoArchivos As GroupBox
    Friend WithEvents an As CheckBox
    Friend WithEvents ap As CheckBox
    Friend WithEvents us As CheckBox
    Friend WithEvents at As CheckBox
    Friend WithEvents au As CheckBox
    Friend WithEvents ac As CheckBox
    Friend WithEvents af As CheckBox
    Friend WithEvents am As CheckBox
    Friend WithEvents ah As CheckBox
    Friend WithEvents ad As CheckBox
    Friend WithEvents ct As CheckBox
    Friend WithEvents rpersonalizado As RadioButton
    Friend WithEvents rgeneral As RadioButton
    Public WithEvents btOpcionFormato As Button
End Class
