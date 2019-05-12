<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRips
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.relegir = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgvRips = New System.Windows.Forms.DataGridView()
        Me.rtodos = New System.Windows.Forms.RadioButton()
        Me.gbArchivos = New System.Windows.Forms.GroupBox()
        Me.txtnombreformato = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtcodigogrupo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtconsecutivo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gbTipoArchivos = New System.Windows.Forms.GroupBox()
        Me.tt = New System.Windows.Forms.CheckBox()
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
        Me.rgeneral = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtidtercero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Datefechaexp = New System.Windows.Forms.DateTimePicker()
        Me.txtruta = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtfechafinal = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtfechaini = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtcodigoeps = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtciudad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdv = New System.Windows.Forms.TextBox()
        Me.txtnit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txteps = New System.Windows.Forms.TextBox()
        Me.btbuscarl = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btOpcionEPS = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgvRips, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbArchivos.SuspendLayout()
        Me.gbTipoArchivos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "GENERADOR DE RIPS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(46, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(869, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_____"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.relegir)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.rtodos)
        Me.GroupBox1.Controls.Add(Me.gbArchivos)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(910, 448)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "0"
        '
        'relegir
        '
        Me.relegir.AutoSize = True
        Me.relegir.Location = New System.Drawing.Point(809, 272)
        Me.relegir.Name = "relegir"
        Me.relegir.Size = New System.Drawing.Size(92, 17)
        Me.relegir.TabIndex = 7
        Me.relegir.Text = "Elegir facturas"
        Me.relegir.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.dgvRips)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 291)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(896, 151)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Listado de factura"
        '
        'dgvRips
        '
        Me.dgvRips.AllowUserToAddRows = False
        Me.dgvRips.AllowUserToDeleteRows = False
        Me.dgvRips.AllowUserToResizeColumns = False
        Me.dgvRips.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvRips.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRips.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRips.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvRips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRips.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRips.Location = New System.Drawing.Point(3, 17)
        Me.dgvRips.Name = "dgvRips"
        Me.dgvRips.ReadOnly = True
        Me.dgvRips.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvRips.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRips.Size = New System.Drawing.Size(890, 131)
        Me.dgvRips.TabIndex = 0
        '
        'rtodos
        '
        Me.rtodos.AutoSize = True
        Me.rtodos.Checked = True
        Me.rtodos.Location = New System.Drawing.Point(747, 272)
        Me.rtodos.Name = "rtodos"
        Me.rtodos.Size = New System.Drawing.Size(55, 17)
        Me.rtodos.TabIndex = 6
        Me.rtodos.TabStop = True
        Me.rtodos.Text = "Todos"
        Me.rtodos.UseVisualStyleBackColor = True
        '
        'gbArchivos
        '
        Me.gbArchivos.Controls.Add(Me.txtnombreformato)
        Me.gbArchivos.Controls.Add(Me.Label14)
        Me.gbArchivos.Controls.Add(Me.txtcodigogrupo)
        Me.gbArchivos.Controls.Add(Me.Label4)
        Me.gbArchivos.Controls.Add(Me.txtconsecutivo)
        Me.gbArchivos.Controls.Add(Me.Label12)
        Me.gbArchivos.Controls.Add(Me.gbTipoArchivos)
        Me.gbArchivos.Controls.Add(Me.rgeneral)
        Me.gbArchivos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArchivos.Location = New System.Drawing.Point(6, 168)
        Me.gbArchivos.Name = "gbArchivos"
        Me.gbArchivos.Size = New System.Drawing.Size(896, 98)
        Me.gbArchivos.TabIndex = 2
        Me.gbArchivos.TabStop = False
        Me.gbArchivos.Text = "Selección de Archivos a Exportar:"
        '
        'txtnombreformato
        '
        Me.txtnombreformato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtnombreformato.Location = New System.Drawing.Point(622, 42)
        Me.txtnombreformato.Name = "txtnombreformato"
        Me.txtnombreformato.ReadOnly = True
        Me.txtnombreformato.Size = New System.Drawing.Size(271, 21)
        Me.txtnombreformato.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(563, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 15)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Formato:"
        '
        'txtcodigogrupo
        '
        Me.txtcodigogrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigogrupo.Location = New System.Drawing.Point(499, 43)
        Me.txtcodigogrupo.Name = "txtcodigogrupo"
        Me.txtcodigogrupo.ReadOnly = True
        Me.txtcodigogrupo.Size = New System.Drawing.Size(58, 21)
        Me.txtcodigogrupo.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(712, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Consecutivo:"
        '
        'txtconsecutivo
        '
        Me.txtconsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtconsecutivo.Location = New System.Drawing.Point(792, 16)
        Me.txtconsecutivo.Name = "txtconsecutivo"
        Me.txtconsecutivo.ReadOnly = True
        Me.txtconsecutivo.Size = New System.Drawing.Size(98, 21)
        Me.txtconsecutivo.TabIndex = 26
        Me.txtconsecutivo.Text = "000001"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(401, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 15)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Codigo Formato:"
        '
        'gbTipoArchivos
        '
        Me.gbTipoArchivos.Controls.Add(Me.tt)
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
        Me.gbTipoArchivos.Location = New System.Drawing.Point(163, 11)
        Me.gbTipoArchivos.Name = "gbTipoArchivos"
        Me.gbTipoArchivos.Size = New System.Drawing.Size(229, 78)
        Me.gbTipoArchivos.TabIndex = 3
        Me.gbTipoArchivos.TabStop = False
        '
        'tt
        '
        Me.tt.AutoSize = True
        Me.tt.Location = New System.Drawing.Point(172, 55)
        Me.tt.Name = "tt"
        Me.tt.Size = New System.Drawing.Size(40, 19)
        Me.tt.TabIndex = 13
        Me.tt.Tag = "10"
        Me.tt.Text = "TT"
        Me.tt.UseVisualStyleBackColor = True
        Me.tt.Visible = False
        '
        'an
        '
        Me.an.AutoSize = True
        Me.an.Location = New System.Drawing.Point(119, 55)
        Me.an.Name = "an"
        Me.an.Size = New System.Drawing.Size(42, 19)
        Me.an.TabIndex = 12
        Me.an.Text = "AN"
        Me.an.UseVisualStyleBackColor = True
        '
        'ap
        '
        Me.ap.AutoSize = True
        Me.ap.Location = New System.Drawing.Point(63, 55)
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
        Me.at.Location = New System.Drawing.Point(172, 33)
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
        Me.au.Location = New System.Drawing.Point(119, 33)
        Me.au.Name = "au"
        Me.au.Size = New System.Drawing.Size(42, 19)
        Me.au.TabIndex = 8
        Me.au.Text = "AU"
        Me.au.UseVisualStyleBackColor = True
        '
        'ac
        '
        Me.ac.AutoSize = True
        Me.ac.Location = New System.Drawing.Point(63, 33)
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
        Me.am.Location = New System.Drawing.Point(172, 12)
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
        Me.ah.Location = New System.Drawing.Point(119, 12)
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
        Me.ad.Location = New System.Drawing.Point(63, 12)
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
        'rgeneral
        '
        Me.rgeneral.AutoSize = True
        Me.rgeneral.Checked = True
        Me.rgeneral.Location = New System.Drawing.Point(37, 43)
        Me.rgeneral.Name = "rgeneral"
        Me.rgeneral.Size = New System.Drawing.Size(61, 20)
        Me.rgeneral.TabIndex = 0
        Me.rgeneral.TabStop = True
        Me.rgeneral.Text = "General"
        Me.rgeneral.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtidtercero)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Datefechaexp)
        Me.GroupBox3.Controls.Add(Me.txtruta)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtfechafinal)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtfechaini)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 89)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(896, 73)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha"
        '
        'txtidtercero
        '
        Me.txtidtercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidtercero.Location = New System.Drawing.Point(815, 16)
        Me.txtidtercero.Name = "txtidtercero"
        Me.txtidtercero.ReadOnly = True
        Me.txtidtercero.Size = New System.Drawing.Size(65, 21)
        Me.txtidtercero.TabIndex = 32
        Me.txtidtercero.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(733, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 15)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Codigo EPS:"
        Me.Label15.Visible = False
        '
        'Datefechaexp
        '
        Me.Datefechaexp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Datefechaexp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Datefechaexp.Location = New System.Drawing.Point(134, 19)
        Me.Datefechaexp.Name = "Datefechaexp"
        Me.Datefechaexp.Size = New System.Drawing.Size(102, 21)
        Me.Datefechaexp.TabIndex = 27
        Me.Datefechaexp.Value = New Date(2017, 11, 2, 0, 0, 0, 0)
        '
        'txtruta
        '
        Me.txtruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtruta.Location = New System.Drawing.Point(163, 43)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.txtruta.Size = New System.Drawing.Size(717, 21)
        Me.txtruta.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.Button1.Location = New System.Drawing.Point(131, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Ubicacion del archivo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(468, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 15)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Fecha final:"
        '
        'txtfechafinal
        '
        Me.txtfechafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechafinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtfechafinal.Location = New System.Drawing.Point(541, 18)
        Me.txtfechafinal.Name = "txtfechafinal"
        Me.txtfechafinal.Size = New System.Drawing.Size(102, 21)
        Me.txtfechafinal.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(259, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Fecha inicio:"
        '
        'txtfechaini
        '
        Me.txtfechaini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechaini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtfechaini.Location = New System.Drawing.Point(340, 20)
        Me.txtfechaini.Name = "txtfechaini"
        Me.txtfechaini.Size = New System.Drawing.Size(102, 21)
        Me.txtfechaini.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(4, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Fecha de expedicion:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtcodigoeps)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txttelefono)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtciudad)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtdireccion)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtdv)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txteps)
        Me.GroupBox2.Controls.Add(Me.btbuscarl)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(896, 75)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del cliente"
        '
        'txtcodigoeps
        '
        Me.txtcodigoeps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigoeps.Location = New System.Drawing.Point(792, 20)
        Me.txtcodigoeps.Name = "txtcodigoeps"
        Me.txtcodigoeps.ReadOnly = True
        Me.txtcodigoeps.Size = New System.Drawing.Size(98, 21)
        Me.txtcodigoeps.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(715, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 15)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Codigo EPS:"
        '
        'txttelefono
        '
        Me.txttelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txttelefono.Location = New System.Drawing.Point(771, 47)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.ReadOnly = True
        Me.txttelefono.Size = New System.Drawing.Size(119, 21)
        Me.txttelefono.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(711, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Telefono:"
        '
        'txtciudad
        '
        Me.txtciudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtciudad.Location = New System.Drawing.Point(582, 48)
        Me.txtciudad.Name = "txtciudad"
        Me.txtciudad.ReadOnly = True
        Me.txtciudad.Size = New System.Drawing.Size(125, 21)
        Me.txtciudad.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(528, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Ciudad:"
        '
        'txtdireccion
        '
        Me.txtdireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtdireccion.Location = New System.Drawing.Point(74, 47)
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.ReadOnly = True
        Me.txtdireccion.Size = New System.Drawing.Size(450, 21)
        Me.txtdireccion.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Direccion:"
        '
        'txtdv
        '
        Me.txtdv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtdv.Location = New System.Drawing.Point(131, 20)
        Me.txtdv.Name = "txtdv"
        Me.txtdv.ReadOnly = True
        Me.txtdv.Size = New System.Drawing.Size(25, 21)
        Me.txtdv.TabIndex = 20
        '
        'txtnit
        '
        Me.txtnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtnit.Location = New System.Drawing.Point(42, 20)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ReadOnly = True
        Me.txtnit.Size = New System.Drawing.Size(87, 21)
        Me.txtnit.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "EPS:"
        '
        'txteps
        '
        Me.txteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txteps.Location = New System.Drawing.Point(187, 20)
        Me.txteps.Name = "txteps"
        Me.txteps.ReadOnly = True
        Me.txteps.Size = New System.Drawing.Size(521, 21)
        Me.txteps.TabIndex = 17
        '
        'btbuscarl
        '
        Me.btbuscarl.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarl.Location = New System.Drawing.Point(160, 19)
        Me.btbuscarl.Name = "btbuscarl"
        Me.btbuscarl.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarl.TabIndex = 16
        Me.btbuscarl.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btcancelar, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 24
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
        Me.btguardar.Image = Global.Celer.My.Resources.Resources.Download_Folder_icon
        Me.btguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(52, 51)
        Me.btguardar.Text = "&Generar"
        Me.btguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
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
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Files_icon
        Me.PictureBox1.Location = New System.Drawing.Point(4, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'btOpcionEPS
        '
        Me.btOpcionEPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionEPS.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btOpcionEPS.Image = Global.Celer.My.Resources.Resources.hotel_icon__1_
        Me.btOpcionEPS.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btOpcionEPS.Location = New System.Drawing.Point(749, 2)
        Me.btOpcionEPS.Name = "btOpcionEPS"
        Me.btOpcionEPS.Size = New System.Drawing.Size(165, 34)
        Me.btOpcionEPS.TabIndex = 25
        Me.btOpcionEPS.Text = "Configuracion EPS"
        Me.btOpcionEPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionEPS.UseVisualStyleBackColor = True
        '
        'FormRips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.btOpcionEPS)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormRips"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.dgvRips, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbArchivos.ResumeLayout(False)
        Me.gbArchivos.PerformLayout()
        Me.gbTipoArchivos.ResumeLayout(False)
        Me.gbTipoArchivos.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtciudad As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtdireccion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtdv As TextBox
    Friend WithEvents txtnit As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txteps As TextBox
    Public WithEvents btbuscarl As Button
    Friend WithEvents gbArchivos As GroupBox
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
    Friend WithEvents rgeneral As RadioButton
    Friend WithEvents txtruta As TextBox
    Public WithEvents Button1 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtfechafinal As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtfechaini As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents relegir As RadioButton
    Public WithEvents GroupBox7 As GroupBox
    Public WithEvents dgvRips As DataGridView
    Friend WithEvents rtodos As RadioButton
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Public WithEvents btnuevo As ToolStripButton
    Friend WithEvents txtcodigoeps As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtconsecutivo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Datefechaexp As DateTimePicker
    Friend WithEvents txtnombreformato As TextBox
    Friend WithEvents Label14 As Label
    Public WithEvents txtcodigogrupo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtidtercero As TextBox
    Friend WithEvents Label15 As Label
    Public WithEvents btOpcionEPS As Button
    Friend WithEvents tt As CheckBox
End Class
