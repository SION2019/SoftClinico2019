<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormContratoLaboral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormContratoLaboral))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MostrarActivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btTerminar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.panelRazon = New System.Windows.Forms.Panel()
        Me.btCancelarRazon = New System.Windows.Forms.Button()
        Me.btContinuar = New System.Windows.Forms.Button()
        Me.txtRazones = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabcontrolidentificar = New System.Windows.Forms.TabControl()
        Me.tpFoto = New System.Windows.Forms.TabPage()
        Me.pictureFoto = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.pictureFirma = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtDescripcionMinuta = New System.Windows.Forms.TextBox()
        Me.btbuscarminuta = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.domDiaPrueba = New System.Windows.Forms.DomainUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.textAuxTrans = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.textsalario = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvPuntoContrato = New System.Windows.Forms.DataGridView()
        Me.codigoPunto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anular = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtCodigoMinuta = New System.Windows.Forms.TextBox()
        Me.textminuta = New System.Windows.Forms.RichTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.gbAprendiz = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbEspecialidad = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.RbNo = New System.Windows.Forms.RadioButton()
        Me.rbSI = New System.Windows.Forms.RadioButton()
        Me.txtDVCentro = New System.Windows.Forms.TextBox()
        Me.txtNitCentroF = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCentroF = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumeroGrupo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.textDV = New System.Windows.Forms.TextBox()
        Me.txtidentificacion = New System.Windows.Forms.TextBox()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.textEmpresa = New System.Windows.Forms.TextBox()
        Me.btbuscartercero = New System.Windows.Forms.Button()
        Me.btbuscarEmpresa = New System.Windows.Forms.Button()
        Me.textNit = New System.Windows.Forms.TextBox()
        Me.dtFechaClaus = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInic = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.combotipo = New System.Windows.Forms.ComboBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btOpcionEmpleado = New System.Windows.Forms.Button()
        Me.btOpcionTercero = New System.Windows.Forms.Button()
        Me.btOpcionMinuta = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.panelRazon.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tabcontrolidentificar.SuspendLayout()
        Me.tpFoto.SuspendLayout()
        CType(Me.pictureFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.pictureFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvPuntoContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.gbAprendiz.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 10010
        Me.Label1.Text = "CONTRATOS LABORALES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(982, 20)
        Me.Label2.TabIndex = 10011
        Me.Label2.Text = "_________________________________________________________________________________" &
    "__________________________________________________________"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator2, Me.btimprimir, Me.ToolStripSeparator7, Me.btTerminar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 10014
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
        Me.btbuscar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarActivosToolStripMenuItem, Me.MostrarTodosToolStripMenuItem})
        Me.btbuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbuscar.Image = Global.Celer.My.Resources.Resources.Actions_page_zoom_icon__1_
        Me.btbuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(55, 51)
        Me.btbuscar.Text = "&Buscar"
        Me.btbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MostrarActivosToolStripMenuItem
        '
        Me.MostrarActivosToolStripMenuItem.Name = "MostrarActivosToolStripMenuItem"
        Me.MostrarActivosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.MostrarActivosToolStripMenuItem.Text = "Mostrar Activos"
        '
        'MostrarTodosToolStripMenuItem
        '
        Me.MostrarTodosToolStripMenuItem.Name = "MostrarTodosToolStripMenuItem"
        Me.MostrarTodosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.MostrarTodosToolStripMenuItem.Text = "Mostrar Todos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'btimprimir
        '
        Me.btimprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btimprimir.Image = Global.Celer.My.Resources.Resources.Printer_icon
        Me.btimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(58, 51)
        Me.btimprimir.Text = "&Imprimir"
        Me.btimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 54)
        '
        'btTerminar
        '
        Me.btTerminar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btTerminar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTerminar.Image = Global.Celer.My.Resources.Resources.delete_file_icon
        Me.btTerminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btTerminar.Name = "btTerminar"
        Me.btTerminar.Size = New System.Drawing.Size(58, 51)
        Me.btTerminar.Text = "&Terminar"
        Me.btTerminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 470)
        Me.GroupBox1.TabIndex = 10015
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.panelRazon)
        Me.GroupBox3.Controls.Add(Me.TabControl1)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1006, 348)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'panelRazon
        '
        Me.panelRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelRazon.Controls.Add(Me.btCancelarRazon)
        Me.panelRazon.Controls.Add(Me.btContinuar)
        Me.panelRazon.Controls.Add(Me.txtRazones)
        Me.panelRazon.Controls.Add(Me.Label26)
        Me.panelRazon.Controls.Add(Me.Label25)
        Me.panelRazon.Location = New System.Drawing.Point(345, 4)
        Me.panelRazon.Name = "panelRazon"
        Me.panelRazon.Size = New System.Drawing.Size(341, 192)
        Me.panelRazon.TabIndex = 10018
        Me.panelRazon.Visible = False
        '
        'btCancelarRazon
        '
        Me.btCancelarRazon.Location = New System.Drawing.Point(169, 158)
        Me.btCancelarRazon.Name = "btCancelarRazon"
        Me.btCancelarRazon.Size = New System.Drawing.Size(75, 23)
        Me.btCancelarRazon.TabIndex = 10021
        Me.btCancelarRazon.Text = "Cancelar"
        Me.btCancelarRazon.UseVisualStyleBackColor = True
        '
        'btContinuar
        '
        Me.btContinuar.Location = New System.Drawing.Point(87, 158)
        Me.btContinuar.Name = "btContinuar"
        Me.btContinuar.Size = New System.Drawing.Size(75, 23)
        Me.btContinuar.TabIndex = 10020
        Me.btContinuar.Text = "Continuar"
        Me.btContinuar.UseVisualStyleBackColor = True
        '
        'txtRazones
        '
        Me.txtRazones.Location = New System.Drawing.Point(8, 34)
        Me.txtRazones.Multiline = True
        Me.txtRazones.Name = "txtRazones"
        Me.txtRazones.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRazones.Size = New System.Drawing.Size(326, 118)
        Me.txtRazones.TabIndex = 10019
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 7)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(210, 16)
        Me.Label26.TabIndex = 10018
        Me.Label26.Text = "Razón para la Terminación de contrato"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label25.Location = New System.Drawing.Point(4, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(324, 20)
        Me.Label25.TabIndex = 10012
        Me.Label25.Text = "_____________________________________________"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(6, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(994, 322)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(986, 294)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.tabcontrolidentificar)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 288)
        Me.Panel1.TabIndex = 0
        '
        'tabcontrolidentificar
        '
        Me.tabcontrolidentificar.Controls.Add(Me.tpFoto)
        Me.tabcontrolidentificar.Controls.Add(Me.TabPage3)
        Me.tabcontrolidentificar.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabcontrolidentificar.Location = New System.Drawing.Point(786, 6)
        Me.tabcontrolidentificar.Name = "tabcontrolidentificar"
        Me.tabcontrolidentificar.SelectedIndex = 0
        Me.tabcontrolidentificar.Size = New System.Drawing.Size(190, 161)
        Me.tabcontrolidentificar.TabIndex = 338
        '
        'tpFoto
        '
        Me.tpFoto.BackColor = System.Drawing.Color.White
        Me.tpFoto.Controls.Add(Me.pictureFoto)
        Me.tpFoto.Controls.Add(Me.Panel5)
        Me.tpFoto.Location = New System.Drawing.Point(4, 25)
        Me.tpFoto.Name = "tpFoto"
        Me.tpFoto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFoto.Size = New System.Drawing.Size(182, 132)
        Me.tpFoto.TabIndex = 0
        Me.tpFoto.Text = "Foto"
        '
        'pictureFoto
        '
        Me.pictureFoto.BackColor = System.Drawing.Color.White
        Me.pictureFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureFoto.Location = New System.Drawing.Point(38, 9)
        Me.pictureFoto.Name = "pictureFoto"
        Me.pictureFoto.Size = New System.Drawing.Size(105, 113)
        Me.pictureFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureFoto.TabIndex = 87
        Me.pictureFoto.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(35, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(111, 119)
        Me.Panel5.TabIndex = 327
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.pictureFirma)
        Me.TabPage3.Controls.Add(Me.Panel6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(182, 132)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Firma"
        '
        'pictureFirma
        '
        Me.pictureFirma.BackColor = System.Drawing.Color.White
        Me.pictureFirma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureFirma.Location = New System.Drawing.Point(7, 6)
        Me.pictureFirma.Name = "pictureFirma"
        Me.pictureFirma.Size = New System.Drawing.Size(168, 120)
        Me.pictureFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureFirma.TabIndex = 118
        Me.pictureFirma.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(5, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(174, 126)
        Me.Panel6.TabIndex = 328
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtDescripcionMinuta)
        Me.GroupBox5.Controls.Add(Me.btbuscarminuta)
        Me.GroupBox5.Controls.Add(Me.GroupBox10)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(779, 111)
        Me.GroupBox5.TabIndex = 337
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Información del Empleado:"
        '
        'txtDescripcionMinuta
        '
        Me.txtDescripcionMinuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionMinuta.Location = New System.Drawing.Point(171, 73)
        Me.txtDescripcionMinuta.MaxLength = 30
        Me.txtDescripcionMinuta.Name = "txtDescripcionMinuta"
        Me.txtDescripcionMinuta.ReadOnly = True
        Me.txtDescripcionMinuta.Size = New System.Drawing.Size(602, 21)
        Me.txtDescripcionMinuta.TabIndex = 284
        '
        'btbuscarminuta
        '
        Me.btbuscarminuta.Enabled = False
        Me.btbuscarminuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbuscarminuta.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarminuta.Location = New System.Drawing.Point(4, 71)
        Me.btbuscarminuta.Name = "btbuscarminuta"
        Me.btbuscarminuta.Size = New System.Drawing.Size(161, 24)
        Me.btbuscarminuta.TabIndex = 283
        Me.btbuscarminuta.Text = "Seleccionar minuta"
        Me.btbuscarminuta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btbuscarminuta.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.domDiaPrueba)
        Me.GroupBox10.Controls.Add(Me.Label24)
        Me.GroupBox10.Controls.Add(Me.Panel4)
        Me.GroupBox10.Location = New System.Drawing.Point(4, 15)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(769, 49)
        Me.GroupBox10.TabIndex = 2
        Me.GroupBox10.TabStop = False
        '
        'domDiaPrueba
        '
        Me.domDiaPrueba.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.domDiaPrueba.Location = New System.Drawing.Point(652, 18)
        Me.domDiaPrueba.Name = "domDiaPrueba"
        Me.domDiaPrueba.Size = New System.Drawing.Size(108, 22)
        Me.domDiaPrueba.TabIndex = 336
        Me.domDiaPrueba.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(545, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(101, 15)
        Me.Label24.TabIndex = 335
        Me.Label24.Text = "Dias de Pruebas:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.textAuxTrans)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.textsalario)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Location = New System.Drawing.Point(6, 15)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(488, 28)
        Me.Panel4.TabIndex = 326
        '
        'textAuxTrans
        '
        Me.textAuxTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textAuxTrans.Location = New System.Drawing.Point(335, 3)
        Me.textAuxTrans.Name = "textAuxTrans"
        Me.textAuxTrans.ReadOnly = True
        Me.textAuxTrans.Size = New System.Drawing.Size(146, 22)
        Me.textAuxTrans.TabIndex = 312
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(14, 6)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 15)
        Me.Label28.TabIndex = 307
        Me.Label28.Text = "Salario:"
        '
        'textsalario
        '
        Me.textsalario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textsalario.Location = New System.Drawing.Point(73, 3)
        Me.textsalario.Name = "textsalario"
        Me.textsalario.ReadOnly = True
        Me.textsalario.Size = New System.Drawing.Size(146, 22)
        Me.textsalario.TabIndex = 308
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(241, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 15)
        Me.Label12.TabIndex = 311
        Me.Label12.Text = "Aux. transporte:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvPuntoContrato)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 119)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(781, 166)
        Me.GroupBox4.TabIndex = 335
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Punto donde Labora"
        '
        'dgvPuntoContrato
        '
        Me.dgvPuntoContrato.AllowUserToAddRows = False
        Me.dgvPuntoContrato.AllowUserToDeleteRows = False
        Me.dgvPuntoContrato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPuntoContrato.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPuntoContrato.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuntoContrato.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPuntoContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPuntoContrato.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigoPunto, Me.descrip, Me.anular})
        Me.dgvPuntoContrato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPuntoContrato.Location = New System.Drawing.Point(3, 17)
        Me.dgvPuntoContrato.MultiSelect = False
        Me.dgvPuntoContrato.Name = "dgvPuntoContrato"
        Me.dgvPuntoContrato.RowHeadersVisible = False
        Me.dgvPuntoContrato.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPuntoContrato.Size = New System.Drawing.Size(775, 146)
        Me.dgvPuntoContrato.TabIndex = 336
        '
        'codigoPunto
        '
        Me.codigoPunto.HeaderText = "Codigo"
        Me.codigoPunto.Name = "codigoPunto"
        Me.codigoPunto.ReadOnly = True
        Me.codigoPunto.Width = 71
        '
        'descrip
        '
        Me.descrip.HeaderText = "Descripcion"
        Me.descrip.Name = "descrip"
        Me.descrip.ReadOnly = True
        Me.descrip.Width = 97
        '
        'anular
        '
        Me.anular.HeaderText = "Quitar/Anular"
        Me.anular.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.anular.Name = "anular"
        Me.anular.Width = 84
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(986, 294)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Minuta del contrato"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txtCodigoMinuta)
        Me.Panel2.Controls.Add(Me.textminuta)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(980, 288)
        Me.Panel2.TabIndex = 0
        '
        'txtCodigoMinuta
        '
        Me.txtCodigoMinuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoMinuta.Location = New System.Drawing.Point(348, 6)
        Me.txtCodigoMinuta.MaxLength = 30
        Me.txtCodigoMinuta.Name = "txtCodigoMinuta"
        Me.txtCodigoMinuta.ReadOnly = True
        Me.txtCodigoMinuta.Size = New System.Drawing.Size(65, 21)
        Me.txtCodigoMinuta.TabIndex = 11
        Me.txtCodigoMinuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textminuta
        '
        Me.textminuta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textminuta.Location = New System.Drawing.Point(7, 31)
        Me.textminuta.Name = "textminuta"
        Me.textminuta.Size = New System.Drawing.Size(973, 254)
        Me.textminuta.TabIndex = 2
        Me.textminuta.Text = ""
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.gbAprendiz)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(986, 294)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Información Aprendiz"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'gbAprendiz
        '
        Me.gbAprendiz.Controls.Add(Me.Label4)
        Me.gbAprendiz.Controls.Add(Me.cbEspecialidad)
        Me.gbAprendiz.Controls.Add(Me.GroupBox9)
        Me.gbAprendiz.Controls.Add(Me.txtDVCentro)
        Me.gbAprendiz.Controls.Add(Me.txtNitCentroF)
        Me.gbAprendiz.Controls.Add(Me.Label8)
        Me.gbAprendiz.Controls.Add(Me.txtCentroF)
        Me.gbAprendiz.Controls.Add(Me.Label9)
        Me.gbAprendiz.Controls.Add(Me.Label10)
        Me.gbAprendiz.Controls.Add(Me.Label11)
        Me.gbAprendiz.Controls.Add(Me.txtNumeroGrupo)
        Me.gbAprendiz.Location = New System.Drawing.Point(6, 6)
        Me.gbAprendiz.Name = "gbAprendiz"
        Me.gbAprendiz.Size = New System.Drawing.Size(768, 91)
        Me.gbAprendiz.TabIndex = 2
        Me.gbAprendiz.TabStop = False
        Me.gbAprendiz.Text = "Información de la Institución del Aprendiz"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(607, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 15)
        Me.Label4.TabIndex = 330
        Me.Label4.Text = "DV:"
        '
        'cbEspecialidad
        '
        Me.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEspecialidad.Enabled = False
        Me.cbEspecialidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEspecialidad.FormattingEnabled = True
        Me.cbEspecialidad.Location = New System.Drawing.Point(141, 57)
        Me.cbEspecialidad.Name = "cbEspecialidad"
        Me.cbEspecialidad.Size = New System.Drawing.Size(179, 23)
        Me.cbEspecialidad.TabIndex = 329
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.RbNo)
        Me.GroupBox9.Controls.Add(Me.rbSI)
        Me.GroupBox9.Location = New System.Drawing.Point(278, 11)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(107, 40)
        Me.GroupBox9.TabIndex = 287
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "SENA"
        '
        'RbNo
        '
        Me.RbNo.AutoSize = True
        Me.RbNo.Location = New System.Drawing.Point(59, 15)
        Me.RbNo.Name = "RbNo"
        Me.RbNo.Size = New System.Drawing.Size(43, 19)
        Me.RbNo.TabIndex = 1
        Me.RbNo.TabStop = True
        Me.RbNo.Text = "NO"
        Me.RbNo.UseVisualStyleBackColor = True
        '
        'rbSI
        '
        Me.rbSI.AutoSize = True
        Me.rbSI.Location = New System.Drawing.Point(11, 15)
        Me.rbSI.Name = "rbSI"
        Me.rbSI.Size = New System.Drawing.Size(36, 19)
        Me.rbSI.TabIndex = 0
        Me.rbSI.TabStop = True
        Me.rbSI.Text = "SI"
        Me.rbSI.UseVisualStyleBackColor = True
        '
        'txtDVCentro
        '
        Me.txtDVCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtDVCentro.Location = New System.Drawing.Point(638, 20)
        Me.txtDVCentro.Name = "txtDVCentro"
        Me.txtDVCentro.ReadOnly = True
        Me.txtDVCentro.Size = New System.Drawing.Size(25, 21)
        Me.txtDVCentro.TabIndex = 286
        '
        'txtNitCentroF
        '
        Me.txtNitCentroF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtNitCentroF.Location = New System.Drawing.Point(466, 19)
        Me.txtNitCentroF.Name = "txtNitCentroF"
        Me.txtNitCentroF.ReadOnly = True
        Me.txtNitCentroF.Size = New System.Drawing.Size(136, 21)
        Me.txtNitCentroF.TabIndex = 285
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(429, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 15)
        Me.Label8.TabIndex = 284
        Me.Label8.Text = "Nit:"
        '
        'txtCentroF
        '
        Me.txtCentroF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCentroF.Location = New System.Drawing.Point(466, 58)
        Me.txtCentroF.Name = "txtCentroF"
        Me.txtCentroF.ReadOnly = True
        Me.txtCentroF.Size = New System.Drawing.Size(293, 21)
        Me.txtCentroF.TabIndex = 283
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(335, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 15)
        Me.Label9.TabIndex = 282
        Me.Label9.Text = "Centro de Formación:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 15)
        Me.Label10.TabIndex = 281
        Me.Label10.Text = "Especialidad o Curso:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 15)
        Me.Label11.TabIndex = 279
        Me.Label11.Text = "Numero de Grupo:"
        '
        'txtNumeroGrupo
        '
        Me.txtNumeroGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtNumeroGrupo.Location = New System.Drawing.Point(141, 21)
        Me.txtNumeroGrupo.Name = "txtNumeroGrupo"
        Me.txtNumeroGrupo.ReadOnly = True
        Me.txtNumeroGrupo.Size = New System.Drawing.Size(131, 21)
        Me.txtNumeroGrupo.TabIndex = 278
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.textDV)
        Me.GroupBox2.Controls.Add(Me.txtidentificacion)
        Me.GroupBox2.Controls.Add(Me.txtEmpleado)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.textEmpresa)
        Me.GroupBox2.Controls.Add(Me.btbuscartercero)
        Me.GroupBox2.Controls.Add(Me.btbuscarEmpresa)
        Me.GroupBox2.Controls.Add(Me.textNit)
        Me.GroupBox2.Controls.Add(Me.dtFechaClaus)
        Me.GroupBox2.Controls.Add(Me.dtFechaInic)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.combotipo)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1006, 102)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del contrato:"
        '
        'textDV
        '
        Me.textDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textDV.Location = New System.Drawing.Point(252, 74)
        Me.textDV.Name = "textDV"
        Me.textDV.Size = New System.Drawing.Size(33, 21)
        Me.textDV.TabIndex = 304
        '
        'txtidentificacion
        '
        Me.txtidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentificacion.Location = New System.Drawing.Point(118, 49)
        Me.txtidentificacion.Name = "txtidentificacion"
        Me.txtidentificacion.ReadOnly = True
        Me.txtidentificacion.Size = New System.Drawing.Size(167, 21)
        Me.txtidentificacion.TabIndex = 268
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEmpleado.Location = New System.Drawing.Point(291, 49)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(601, 21)
        Me.txtEmpleado.TabIndex = 270
        Me.txtEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 77)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 15)
        Me.Label22.TabIndex = 303
        Me.Label22.Text = "Pago a Través de:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 277
        Me.Label20.Text = "Empleado:"
        '
        'textEmpresa
        '
        Me.textEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textEmpresa.Location = New System.Drawing.Point(291, 74)
        Me.textEmpresa.Name = "textEmpresa"
        Me.textEmpresa.Size = New System.Drawing.Size(601, 21)
        Me.textEmpresa.TabIndex = 302
        Me.textEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btbuscartercero
        '
        Me.btbuscartercero.Enabled = False
        Me.btbuscartercero.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscartercero.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btbuscartercero.Location = New System.Drawing.Point(893, 48)
        Me.btbuscartercero.Name = "btbuscartercero"
        Me.btbuscartercero.Size = New System.Drawing.Size(25, 23)
        Me.btbuscartercero.TabIndex = 298
        Me.btbuscartercero.UseVisualStyleBackColor = True
        '
        'btbuscarEmpresa
        '
        Me.btbuscarEmpresa.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarEmpresa.Location = New System.Drawing.Point(893, 73)
        Me.btbuscarEmpresa.Name = "btbuscarEmpresa"
        Me.btbuscarEmpresa.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarEmpresa.TabIndex = 300
        Me.btbuscarEmpresa.UseVisualStyleBackColor = True
        '
        'textNit
        '
        Me.textNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textNit.Location = New System.Drawing.Point(118, 74)
        Me.textNit.Name = "textNit"
        Me.textNit.Size = New System.Drawing.Size(112, 21)
        Me.textNit.TabIndex = 301
        '
        'dtFechaClaus
        '
        Me.dtFechaClaus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaClaus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaClaus.Location = New System.Drawing.Point(892, 21)
        Me.dtFechaClaus.Name = "dtFechaClaus"
        Me.dtFechaClaus.Size = New System.Drawing.Size(106, 21)
        Me.dtFechaClaus.TabIndex = 299
        '
        'dtFechaInic
        '
        Me.dtFechaInic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaInic.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInic.Location = New System.Drawing.Point(685, 21)
        Me.dtFechaInic.Name = "dtFechaInic"
        Me.dtFechaInic.Size = New System.Drawing.Size(106, 21)
        Me.dtFechaInic.TabIndex = 298
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(808, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Terminación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(641, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Inicio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(225, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Tipo de Contratación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Nº de Contrato:"
        '
        'combotipo
        '
        Me.combotipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.combotipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combotipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combotipo.FormattingEnabled = True
        Me.combotipo.Location = New System.Drawing.Point(354, 19)
        Me.combotipo.Name = "combotipo"
        Me.combotipo.Size = New System.Drawing.Size(268, 23)
        Me.combotipo.TabIndex = 11
        '
        'txtcodigo
        '
        Me.txtcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(118, 19)
        Me.txtcodigo.MaxLength = 30
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(90, 21)
        Me.txtcodigo.TabIndex = 10
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(236, 77)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 15)
        Me.Label23.TabIndex = 305
        Me.Label23.Text = "-"
        '
        'btOpcionEmpleado
        '
        Me.btOpcionEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionEmpleado.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionEmpleado.Image = Global.Celer.My.Resources.Resources.Office_Customer_Male_Dark_icon__1_
        Me.btOpcionEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionEmpleado.Location = New System.Drawing.Point(704, 2)
        Me.btOpcionEmpleado.Name = "btOpcionEmpleado"
        Me.btOpcionEmpleado.Size = New System.Drawing.Size(97, 34)
        Me.btOpcionEmpleado.TabIndex = 10017
        Me.btOpcionEmpleado.Text = "Empleado"
        Me.btOpcionEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionEmpleado.UseVisualStyleBackColor = True
        '
        'btOpcionTercero
        '
        Me.btOpcionTercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionTercero.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionTercero.Image = Global.Celer.My.Resources.Resources.boss_icon__1_
        Me.btOpcionTercero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionTercero.Location = New System.Drawing.Point(808, 2)
        Me.btOpcionTercero.Name = "btOpcionTercero"
        Me.btOpcionTercero.Size = New System.Drawing.Size(97, 34)
        Me.btOpcionTercero.TabIndex = 10016
        Me.btOpcionTercero.Text = "Tercero"
        Me.btOpcionTercero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionTercero.UseVisualStyleBackColor = True
        '
        'btOpcionMinuta
        '
        Me.btOpcionMinuta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionMinuta.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionMinuta.Image = Global.Celer.My.Resources.Resources.Text_Document_icon
        Me.btOpcionMinuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionMinuta.Location = New System.Drawing.Point(911, 2)
        Me.btOpcionMinuta.Name = "btOpcionMinuta"
        Me.btOpcionMinuta.Size = New System.Drawing.Size(97, 34)
        Me.btOpcionMinuta.TabIndex = 10013
        Me.btOpcionMinuta.Text = "Minuta"
        Me.btOpcionMinuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionMinuta.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Text_Document_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10012
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 71
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 97
        '
        'FormContratoLaboral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.btOpcionEmpleado)
        Me.Controls.Add(Me.btOpcionTercero)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btOpcionMinuta)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "FormContratoLaboral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.panelRazon.ResumeLayout(False)
        Me.panelRazon.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tabcontrolidentificar.ResumeLayout(False)
        Me.tpFoto.ResumeLayout(False)
        CType(Me.pictureFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.pictureFirma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvPuntoContrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.gbAprendiz.ResumeLayout(False)
        Me.gbAprendiz.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents btOpcionMinuta As Button
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents btimprimir As ToolStripButton
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label7 As Label
    Public WithEvents Label6 As Label
    Public WithEvents Label5 As Label
    Public WithEvents Label3 As Label
    Public WithEvents combotipo As ComboBox
    Public WithEvents txtcodigo As TextBox
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Public WithEvents Panel1 As Panel
    Public WithEvents TabPage2 As TabPage
    Public WithEvents btbuscartercero As Button
    Public WithEvents txtEmpleado As TextBox
    Public WithEvents Label20 As Label
    Public WithEvents txtidentificacion As TextBox
    Public WithEvents Panel2 As Panel
    Public WithEvents dtFechaClaus As DateTimePicker
    Public WithEvents dtFechaInic As DateTimePicker
    Public WithEvents textminuta As RichTextBox
    Public WithEvents btOpcionTercero As Button
    Public WithEvents btOpcionEmpleado As Button
    Public WithEvents btTerminar As ToolStripButton
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents txtCodigoMinuta As TextBox
    Public WithEvents Label22 As Label
    Friend WithEvents textEmpresa As TextBox
    Public WithEvents btbuscarEmpresa As Button
    Friend WithEvents textNit As TextBox
    Friend WithEvents textDV As TextBox
    Public WithEvents Label23 As Label
    Public WithEvents btbuscar As ToolStripDropDownButton
    Friend WithEvents MostrarActivosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarTodosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As GroupBox
    Public WithEvents dgvPuntoContrato As DataGridView
    Friend WithEvents codigoPunto As DataGridViewTextBoxColumn
    Friend WithEvents descrip As DataGridViewTextBoxColumn
    Friend WithEvents anular As DataGridViewImageColumn
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox10 As GroupBox
    Public WithEvents Panel4 As Panel
    Public WithEvents textAuxTrans As TextBox
    Public WithEvents Label28 As Label
    Public WithEvents textsalario As TextBox
    Public WithEvents Label12 As Label
    Friend WithEvents domDiaPrueba As DomainUpDown
    Public WithEvents Label24 As Label
    Public WithEvents tabcontrolidentificar As TabControl
    Public WithEvents tpFoto As TabPage
    Public WithEvents pictureFoto As PictureBox
    Public WithEvents Panel5 As Panel
    Public WithEvents TabPage3 As TabPage
    Public WithEvents pictureFirma As PictureBox
    Public WithEvents Panel6 As Panel
    Friend WithEvents panelRazon As Panel
    Friend WithEvents btCancelarRazon As Button
    Friend WithEvents btContinuar As Button
    Friend WithEvents txtRazones As TextBox
    Public WithEvents Label26 As Label
    Public WithEvents Label25 As Label
    Public WithEvents txtDescripcionMinuta As TextBox
    Public WithEvents btbuscarminuta As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents gbAprendiz As GroupBox
    Public WithEvents Label4 As Label
    Public WithEvents cbEspecialidad As ComboBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents RbNo As RadioButton
    Friend WithEvents rbSI As RadioButton
    Public WithEvents txtDVCentro As TextBox
    Public WithEvents txtNitCentroF As TextBox
    Public WithEvents Label8 As Label
    Public WithEvents txtCentroF As TextBox
    Public WithEvents Label9 As Label
    Public WithEvents Label10 As Label
    Public WithEvents Label11 As Label
    Public WithEvents txtNumeroGrupo As TextBox
End Class
