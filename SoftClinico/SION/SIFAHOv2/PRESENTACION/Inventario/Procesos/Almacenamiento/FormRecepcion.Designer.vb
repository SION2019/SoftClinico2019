<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecepcion
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRecepcion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.MtxtFechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTrasportadora = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtguia = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtfactura = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFechaLimite = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaOrden = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCodigoOrden = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOrden = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtidproveedor = New System.Windows.Forms.TextBox()
        Me.txtproveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.txtbruto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.txtiva = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PnlLotes = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtCantidadProducto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtDescripcionProducto = New System.Windows.Forms.TextBox()
        Me.dgvLotes = New System.Windows.Forms.DataGridView()
        Me.Reg_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New Celer.DataGridViewDateTimePickerColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Excepcion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtNuevoLotes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtSalirlOTES = New System.Windows.Forms.ToolStripButton()
        Me.nproducto = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvproductos = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewDateTimePickerColumn1 = New Celer.DataGridViewDateTimePickerColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantida_Recibida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad_Faltante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bodega_Escoger = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnBodegas = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lotes = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ANULAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.PnlLotes.SuspendLayout()
        CType(Me.dgvLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.dgvproductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1021, 135)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Básicos"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.MtxtFechaRecepcion)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtcodigo)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cmbTrasportadora)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtguia)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtfactura)
        Me.GroupBox4.Location = New System.Drawing.Point(478, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(537, 115)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Recepción de Compra"
        '
        'MtxtFechaRecepcion
        '
        Me.MtxtFechaRecepcion.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.MtxtFechaRecepcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MtxtFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MtxtFechaRecepcion.Location = New System.Drawing.Point(338, 17)
        Me.MtxtFechaRecepcion.Name = "MtxtFechaRecepcion"
        Me.MtxtFechaRecepcion.Size = New System.Drawing.Size(189, 22)
        Me.MtxtFechaRecepcion.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "No. Recep:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigo.Location = New System.Drawing.Point(137, 18)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(77, 21)
        Me.txtcodigo.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(227, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 15)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Fecha Recepción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(239, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Transportadora:"
        '
        'cmbTrasportadora
        '
        Me.cmbTrasportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrasportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmbTrasportadora.FormattingEnabled = True
        Me.cmbTrasportadora.Location = New System.Drawing.Point(338, 50)
        Me.cmbTrasportadora.Name = "cmbTrasportadora"
        Me.cmbTrasportadora.Size = New System.Drawing.Size(189, 23)
        Me.cmbTrasportadora.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "No. Factura:"
        '
        'txtguia
        '
        Me.txtguia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtguia.Location = New System.Drawing.Point(92, 84)
        Me.txtguia.Name = "txtguia"
        Me.txtguia.Size = New System.Drawing.Size(122, 21)
        Me.txtguia.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "No. Guia:"
        '
        'txtfactura
        '
        Me.txtfactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfactura.Location = New System.Drawing.Point(92, 51)
        Me.txtfactura.Name = "txtfactura"
        Me.txtfactura.Size = New System.Drawing.Size(122, 21)
        Me.txtfactura.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFechaLimite)
        Me.GroupBox2.Controls.Add(Me.txtFechaOrden)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCodigoOrden)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnOrden)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtidproveedor)
        Me.GroupBox2.Controls.Add(Me.txtproveedor)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 115)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Orden Compra"
        '
        'txtFechaLimite
        '
        Me.txtFechaLimite.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaLimite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaLimite.Location = New System.Drawing.Point(368, 77)
        Me.txtFechaLimite.Name = "txtFechaLimite"
        Me.txtFechaLimite.Size = New System.Drawing.Size(88, 22)
        Me.txtFechaLimite.TabIndex = 36
        '
        'txtFechaOrden
        '
        Me.txtFechaOrden.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.txtFechaOrden.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaOrden.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaOrden.Location = New System.Drawing.Point(111, 77)
        Me.txtFechaOrden.Name = "txtFechaOrden"
        Me.txtFechaOrden.Size = New System.Drawing.Size(155, 22)
        Me.txtFechaOrden.TabIndex = 35
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(272, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 15)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Fecha Entrega:"
        '
        'txtCodigoOrden
        '
        Me.txtCodigoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoOrden.Location = New System.Drawing.Point(111, 17)
        Me.txtCodigoOrden.Name = "txtCodigoOrden"
        Me.txtCodigoOrden.ReadOnly = True
        Me.txtCodigoOrden.Size = New System.Drawing.Size(55, 21)
        Me.txtCodigoOrden.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "No. Orden:"
        '
        'btnOrden
        '
        Me.btnOrden.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btnOrden.Location = New System.Drawing.Point(172, 16)
        Me.btnOrden.Name = "btnOrden"
        Me.btnOrden.Size = New System.Drawing.Size(25, 23)
        Me.btnOrden.TabIndex = 1
        Me.btnOrden.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Proveedor:"
        '
        'txtidproveedor
        '
        Me.txtidproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidproveedor.Location = New System.Drawing.Point(111, 48)
        Me.txtidproveedor.Name = "txtidproveedor"
        Me.txtidproveedor.ReadOnly = True
        Me.txtidproveedor.Size = New System.Drawing.Size(55, 20)
        Me.txtidproveedor.TabIndex = 2
        '
        'txtproveedor
        '
        Me.txtproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtproveedor.Location = New System.Drawing.Point(172, 48)
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(284, 20)
        Me.txtproveedor.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 15)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Fecha Orden:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "RECEPCIÓN TÉCNICA DE COMPRA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(982, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "_________________________________________________________________________________" &
    "__________________________________________________________"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1043, 582)
        Me.Panel1.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 528)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 23
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
        Me.btimprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btimprimir.Image = Global.Celer.My.Resources.Resources.Printer_icon
        Me.btimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(57, 51)
        Me.btimprimir.Text = "&Imprimir"
        Me.btimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.PnlLotes)
        Me.GroupBox3.Controls.Add(Me.nproducto)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.dgvproductos)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 182)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1021, 343)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Productos"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.txttotal)
        Me.GroupBox5.Controls.Add(Me.txtbruto)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtdescuento)
        Me.GroupBox5.Controls.Add(Me.txtiva)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 294)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1005, 43)
        Me.GroupBox5.TabIndex = 34
        Me.GroupBox5.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Valor Bruto:"
        '
        'txttotal
        '
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(840, 15)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(153, 20)
        Me.txttotal.TabIndex = 30
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtbruto
        '
        Me.txtbruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbruto.Location = New System.Drawing.Point(99, 15)
        Me.txtbruto.Name = "txtbruto"
        Me.txtbruto.ReadOnly = True
        Me.txtbruto.Size = New System.Drawing.Size(140, 20)
        Me.txtbruto.TabIndex = 24
        Me.txtbruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(753, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 15)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Valor Total:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(258, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 15)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Valor % Iva:"
        '
        'txtdescuento
        '
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(594, 15)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.ReadOnly = True
        Me.txtdescuento.Size = New System.Drawing.Size(140, 20)
        Me.txtdescuento.TabIndex = 28
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtiva
        '
        Me.txtiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.Location = New System.Drawing.Point(347, 15)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.ReadOnly = True
        Me.txtiva.Size = New System.Drawing.Size(140, 20)
        Me.txtiva.TabIndex = 26
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(506, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 15)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Descuento:"
        '
        'PnlLotes
        '
        Me.PnlLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlLotes.Controls.Add(Me.Label15)
        Me.PnlLotes.Controls.Add(Me.TxtCantidadProducto)
        Me.PnlLotes.Controls.Add(Me.Label14)
        Me.PnlLotes.Controls.Add(Me.TxtDescripcionProducto)
        Me.PnlLotes.Controls.Add(Me.dgvLotes)
        Me.PnlLotes.Controls.Add(Me.ToolStrip2)
        Me.PnlLotes.Location = New System.Drawing.Point(451, 41)
        Me.PnlLotes.Name = "PnlLotes"
        Me.PnlLotes.Size = New System.Drawing.Size(570, 247)
        Me.PnlLotes.TabIndex = 33
        Me.PnlLotes.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(368, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 16)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Cantidad Pedida:"
        '
        'TxtCantidadProducto
        '
        Me.TxtCantidadProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadProducto.Location = New System.Drawing.Point(482, 6)
        Me.TxtCantidadProducto.Name = "TxtCantidadProducto"
        Me.TxtCantidadProducto.ReadOnly = True
        Me.TxtCantidadProducto.Size = New System.Drawing.Size(83, 20)
        Me.TxtCantidadProducto.TabIndex = 39
        Me.TxtCantidadProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Producto:"
        '
        'TxtDescripcionProducto
        '
        Me.TxtDescripcionProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcionProducto.Location = New System.Drawing.Point(73, 6)
        Me.TxtDescripcionProducto.Name = "TxtDescripcionProducto"
        Me.TxtDescripcionProducto.ReadOnly = True
        Me.TxtDescripcionProducto.Size = New System.Drawing.Size(258, 20)
        Me.TxtDescripcionProducto.TabIndex = 37
        '
        'dgvLotes
        '
        Me.dgvLotes.AllowUserToAddRows = False
        Me.dgvLotes.AllowUserToDeleteRows = False
        Me.dgvLotes.AllowUserToResizeColumns = False
        Me.dgvLotes.AllowUserToResizeRows = False
        Me.dgvLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvLotes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reg_lote, Me.Num_lote, Me.Fecha, Me.Cantidad, Me.Excepcion, Me.DataGridViewImageColumn2})
        Me.dgvLotes.Location = New System.Drawing.Point(3, 32)
        Me.dgvLotes.MultiSelect = False
        Me.dgvLotes.Name = "dgvLotes"
        Me.dgvLotes.RowHeadersVisible = False
        Me.dgvLotes.Size = New System.Drawing.Size(562, 134)
        Me.dgvLotes.TabIndex = 34
        '
        'Reg_lote
        '
        Me.Reg_lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Reg_lote.HeaderText = "Reg_lote"
        Me.Reg_lote.Name = "Reg_lote"
        Me.Reg_lote.Visible = False
        '
        'Num_lote
        '
        Me.Num_lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Num_lote.HeaderText = "Número Lote"
        Me.Num_lote.Name = "Num_lote"
        Me.Num_lote.Width = 86
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Fecha.HeaderText = "Fecha Vencimiento"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Fecha.Width = 111
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 74
        '
        'Excepcion
        '
        Me.Excepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Excepcion.HeaderText = "Excepción"
        Me.Excepcion.Name = "Excepcion"
        Me.Excepcion.Width = 61
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn2.HeaderText = "Anular"
        Me.DataGridViewImageColumn2.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Width = 45
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtNuevoLotes, Me.ToolStripSeparator2, Me.BtSalirlOTES})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 191)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(568, 54)
        Me.ToolStrip2.TabIndex = 40
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'BtNuevoLotes
        '
        Me.BtNuevoLotes.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNuevoLotes.Image = Global.Celer.My.Resources.Resources.Document_Add_icon__1_
        Me.BtNuevoLotes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtNuevoLotes.Name = "BtNuevoLotes"
        Me.BtNuevoLotes.Size = New System.Drawing.Size(46, 51)
        Me.BtNuevoLotes.Text = "&Nuevo"
        Me.BtNuevoLotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'BtSalirlOTES
        '
        Me.BtSalirlOTES.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtSalirlOTES.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtSalirlOTES.Image = Global.Celer.My.Resources.Resources.Exit_icon
        Me.BtSalirlOTES.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtSalirlOTES.Name = "BtSalirlOTES"
        Me.BtSalirlOTES.Size = New System.Drawing.Size(36, 51)
        Me.BtSalirlOTES.Text = "&Salir"
        Me.BtSalirlOTES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'nproducto
        '
        Me.nproducto.AutoSize = True
        Me.nproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nproducto.Location = New System.Drawing.Point(979, 23)
        Me.nproducto.Name = "nproducto"
        Me.nproducto.Size = New System.Drawing.Size(14, 15)
        Me.nproducto.TabIndex = 29
        Me.nproducto.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(882, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 15)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Total Productos:"
        '
        'dgvproductos
        '
        Me.dgvproductos.AllowUserToAddRows = False
        Me.dgvproductos.AllowUserToDeleteRows = False
        Me.dgvproductos.AllowUserToResizeColumns = False
        Me.dgvproductos.AllowUserToResizeRows = False
        Me.dgvproductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvproductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvproductos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvproductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Marca, Me.Iva, Me.Descuento, Me.CantidadCompra, Me.Cantida_Recibida, Me.Cantidad_Faltante, Me.Bodega_Escoger, Me.BtnBodegas, Me.Costo, Me.Total, Me.Lotes, Me.ANULAR})
        Me.dgvproductos.Location = New System.Drawing.Point(6, 41)
        Me.dgvproductos.MultiSelect = False
        Me.dgvproductos.Name = "dgvproductos"
        Me.dgvproductos.RowHeadersVisible = False
        Me.dgvproductos.Size = New System.Drawing.Size(1008, 247)
        Me.dgvproductos.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Window_Enter_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "ANULAR"
        Me.DataGridViewImageColumn1.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 43
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Número Lote"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 86
        '
        'DataGridViewDateTimePickerColumn1
        '
        Me.DataGridViewDateTimePickerColumn1.HeaderText = "Fecha Vencimiento"
        Me.DataGridViewDateTimePickerColumn1.Name = "DataGridViewDateTimePickerColumn1"
        Me.DataGridViewDateTimePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDateTimePickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDateTimePickerColumn1.Width = 113
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 74
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 67
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 88
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.Width = 60
        '
        'Iva
        '
        Me.Iva.HeaderText = "Iva %"
        Me.Iva.Name = "Iva"
        Me.Iva.Width = 59
        '
        'Descuento
        '
        Me.Descuento.HeaderText = "Descuento %"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.Width = 93
        '
        'CantidadCompra
        '
        Me.CantidadCompra.HeaderText = "Cant. Solicitada"
        Me.CantidadCompra.Name = "CantidadCompra"
        Me.CantidadCompra.Width = 106
        '
        'Cantida_Recibida
        '
        Me.Cantida_Recibida.HeaderText = "Cant. Recibida"
        Me.Cantida_Recibida.Name = "Cantida_Recibida"
        '
        'Cantidad_Faltante
        '
        Me.Cantidad_Faltante.HeaderText = "Cant. Faltante"
        Me.Cantidad_Faltante.Name = "Cantidad_Faltante"
        Me.Cantidad_Faltante.Width = 96
        '
        'Bodega_Escoger
        '
        Me.Bodega_Escoger.HeaderText = "Bodega"
        Me.Bodega_Escoger.Name = "Bodega_Escoger"
        Me.Bodega_Escoger.Width = 68
        '
        'BtnBodegas
        '
        Me.BtnBodegas.HeaderText = "Buscar Bodega"
        Me.BtnBodegas.Name = "BtnBodegas"
        Me.BtnBodegas.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BtnBodegas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BtnBodegas.Text = "Buscar Bodega"
        Me.BtnBodegas.UseColumnTextForButtonValue = True
        Me.BtnBodegas.Width = 103
        '
        'Costo
        '
        DataGridViewCellStyle2.Format = "C2"
        Me.Costo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.Width = 60
        '
        'Total
        '
        DataGridViewCellStyle3.Format = "C2"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle3
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Width = 57
        '
        'Lotes
        '
        Me.Lotes.HeaderText = "Lotes"
        Me.Lotes.Name = "Lotes"
        Me.Lotes.Text = "Lotes"
        Me.Lotes.UseColumnTextForButtonValue = True
        Me.Lotes.Width = 39
        '
        'ANULAR
        '
        Me.ANULAR.HeaderText = "Quitar"
        Me.ANULAR.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.ANULAR.Name = "ANULAR"
        Me.ANULAR.Width = 43
        '
        'FormRecepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 582)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "FormRecepcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.PnlLotes.ResumeLayout(False)
        Me.PnlLotes.PerformLayout()
        CType(Me.dgvLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.dgvproductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents Label6 As Label
    Public WithEvents txtcodigo As TextBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents Panel1 As Panel
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents nproducto As Label
    Public WithEvents Label10 As Label
    Public WithEvents cmbTrasportadora As ComboBox
    Public WithEvents txtguia As TextBox
    Public WithEvents txtfactura As TextBox
    Public WithEvents Label11 As Label
    Public WithEvents Label5 As Label
    Public WithEvents Label3 As Label
    Public WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Public WithEvents Label13 As Label
    Public WithEvents PnlLotes As Panel
    Public WithEvents TxtCantidadProducto As TextBox
    Public WithEvents Label14 As Label
    Public WithEvents TxtDescripcionProducto As TextBox
    Public WithEvents dgvLotes As DataGridView
    Public WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewDateTimePickerColumn1 As DataGridViewDateTimePickerColumn
    Public WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Public WithEvents dgvproductos As DataGridView
    Public WithEvents ToolStrip2 As ToolStrip
    Public WithEvents BtNuevoLotes As ToolStripButton
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents Label15 As Label
    Public WithEvents BtSalirlOTES As ToolStripButton
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents GroupBox4 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label12 As Label
    Public WithEvents txtCodigoOrden As TextBox
    Public WithEvents Label4 As Label
    Public WithEvents btnOrden As Button
    Public WithEvents Label7 As Label
    Public WithEvents txtidproveedor As TextBox
    Public WithEvents txtproveedor As TextBox
    Public WithEvents Label8 As Label
    Friend WithEvents MtxtFechaRecepcion As DateTimePicker
    Friend WithEvents txtFechaLimite As DateTimePicker
    Friend WithEvents txtFechaOrden As DateTimePicker
    Friend WithEvents Reg_lote As DataGridViewTextBoxColumn
    Friend WithEvents Num_lote As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewDateTimePickerColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Excepcion As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Public WithEvents GroupBox5 As GroupBox
    Public WithEvents Label9 As Label
    Public WithEvents txttotal As TextBox
    Public WithEvents txtbruto As TextBox
    Public WithEvents Label17 As Label
    Public WithEvents Label16 As Label
    Public WithEvents txtdescuento As TextBox
    Public WithEvents txtiva As TextBox
    Public WithEvents Label18 As Label
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Marca As DataGridViewTextBoxColumn
    Friend WithEvents Iva As DataGridViewTextBoxColumn
    Friend WithEvents Descuento As DataGridViewTextBoxColumn
    Friend WithEvents CantidadCompra As DataGridViewTextBoxColumn
    Friend WithEvents Cantida_Recibida As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad_Faltante As DataGridViewTextBoxColumn
    Friend WithEvents Bodega_Escoger As DataGridViewTextBoxColumn
    Friend WithEvents BtnBodegas As DataGridViewButtonColumn
    Friend WithEvents Costo As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Lotes As DataGridViewButtonColumn
    Friend WithEvents ANULAR As DataGridViewImageColumn
End Class
