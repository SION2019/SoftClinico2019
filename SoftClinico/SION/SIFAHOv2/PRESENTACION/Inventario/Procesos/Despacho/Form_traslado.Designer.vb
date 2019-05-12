<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_traslado
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_traslado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dpFechaTraslado = New System.Windows.Forms.DateTimePicker()
        Me.ChkAumento = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbTransportadora = New System.Windows.Forms.ComboBox()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
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
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LblCostoTotal = New System.Windows.Forms.ToolStripLabel()
        Me.LblCantidad_productos = New System.Windows.Forms.ToolStripLabel()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PnlLotes = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtSalirlOTES = New System.Windows.Forms.ToolStripButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtCantidadProducto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtDescripcionProducto = New System.Windows.Forms.TextBox()
        Me.dgvLotes = New System.Windows.Forms.DataGridView()
        Me.Reg_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New Celer.DataGridViewDateTimePickerColumn()
        Me.stockLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgvproductos = New System.Windows.Forms.DataGridView()
        Me.Codigo_Interno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuequivalencias = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarEquivalenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nombre_equi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock_bod_solicitante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantPed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantEnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantFalt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_P = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ANULAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPuntoServicio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbBodSolicitada = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBuscar_pedidos = New System.Windows.Forms.Button()
        Me.CmbBodSolicitante = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCodigoPedido = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewDateTimePickerColumn1 = New Celer.DataGridViewDateTimePickerColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PnlLotes.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.dgvLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvproductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuequivalencias.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "TRASLADO PRODUCTOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(57, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1157, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "___"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.wire_transfer_icon
        Me.PictureBox1.Location = New System.Drawing.Point(15, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dpFechaTraslado)
        Me.GroupBox1.Controls.Add(Me.ChkAumento)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CmbTransportadora)
        Me.GroupBox1.Controls.Add(Me.txtGuia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(627, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 163)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Básicos del Despacho"
        '
        'dpFechaTraslado
        '
        Me.dpFechaTraslado.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dpFechaTraslado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaTraslado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaTraslado.Location = New System.Drawing.Point(492, 19)
        Me.dpFechaTraslado.Name = "dpFechaTraslado"
        Me.dpFechaTraslado.Size = New System.Drawing.Size(157, 22)
        Me.dpFechaTraslado.TabIndex = 23
        '
        'ChkAumento
        '
        Me.ChkAumento.AutoSize = True
        Me.ChkAumento.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ChkAumento.Location = New System.Drawing.Point(6, 103)
        Me.ChkAumento.Name = "ChkAumento"
        Me.ChkAumento.Size = New System.Drawing.Size(195, 20)
        Me.ChkAumento.TabIndex = 22
        Me.ChkAumento.Text = "Aplicar aumento a bodega solicitada"
        Me.ChkAumento.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(438, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Estado:"
        '
        'txtEstado
        '
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(492, 47)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(157, 21)
        Me.txtEstado.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(391, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Fecha Traslado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Trasnportadora:"
        '
        'CmbTransportadora
        '
        Me.CmbTransportadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbTransportadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTransportadora.DropDownHeight = 200
        Me.CmbTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTransportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTransportadora.FormattingEnabled = True
        Me.CmbTransportadora.IntegralHeight = False
        Me.CmbTransportadora.Location = New System.Drawing.Point(101, 74)
        Me.CmbTransportadora.Name = "CmbTransportadora"
        Me.CmbTransportadora.Size = New System.Drawing.Size(256, 23)
        Me.CmbTransportadora.TabIndex = 16
        '
        'txtGuia
        '
        Me.txtGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.Location = New System.Drawing.Point(101, 47)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(256, 21)
        Me.txtGuia.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "No.  de  guía:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Traslado No:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(101, 20)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(79, 21)
        Me.txtcodigo.TabIndex = 12
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator2, Me.LblCostoTotal, Me.LblCantidad_productos, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 562)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1310, 54)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'LblCostoTotal
        '
        Me.LblCostoTotal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblCostoTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCostoTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblCostoTotal.Name = "LblCostoTotal"
        Me.LblCostoTotal.Size = New System.Drawing.Size(0, 51)
        '
        'LblCantidad_productos
        '
        Me.LblCantidad_productos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblCantidad_productos.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad_productos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblCantidad_productos.Name = "LblCantidad_productos"
        Me.LblCantidad_productos.Size = New System.Drawing.Size(0, 51)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PnlLotes)
        Me.GroupBox3.Controls.Add(Me.dgvproductos)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 226)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1279, 327)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        '
        'PnlLotes
        '
        Me.PnlLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlLotes.Controls.Add(Me.ToolStrip2)
        Me.PnlLotes.Controls.Add(Me.Label15)
        Me.PnlLotes.Controls.Add(Me.TxtCantidadProducto)
        Me.PnlLotes.Controls.Add(Me.Label14)
        Me.PnlLotes.Controls.Add(Me.TxtDescripcionProducto)
        Me.PnlLotes.Controls.Add(Me.dgvLotes)
        Me.PnlLotes.Location = New System.Drawing.Point(703, 20)
        Me.PnlLotes.Name = "PnlLotes"
        Me.PnlLotes.Size = New System.Drawing.Size(570, 301)
        Me.PnlLotes.TabIndex = 34
        Me.PnlLotes.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtSalirlOTES})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 245)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(568, 54)
        Me.ToolStrip2.TabIndex = 40
        Me.ToolStrip2.Text = "ToolStrip2"
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
        Me.dgvLotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reg_lote, Me.Num_lote, Me.Fecha, Me.stockLote, Me.Cantidad, Me.Costo, Me.Total, Me.DataGridViewImageColumn2})
        Me.dgvLotes.Location = New System.Drawing.Point(3, 32)
        Me.dgvLotes.MultiSelect = False
        Me.dgvLotes.Name = "dgvLotes"
        Me.dgvLotes.RowHeadersVisible = False
        Me.dgvLotes.Size = New System.Drawing.Size(562, 210)
        Me.dgvLotes.TabIndex = 34
        '
        'Reg_lote
        '
        Me.Reg_lote.HeaderText = "Reg_lote"
        Me.Reg_lote.Name = "Reg_lote"
        Me.Reg_lote.Visible = False
        Me.Reg_lote.Width = 54
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
        'stockLote
        '
        Me.stockLote.HeaderText = "Stock"
        Me.stockLote.Name = "stockLote"
        Me.stockLote.Width = 59
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
        'Costo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Costo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.Width = 60
        '
        'Total
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle3
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Width = 57
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = "Anular/Quitar"
        Me.DataGridViewImageColumn2.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Width = 77
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
        Me.dgvproductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo_Interno, Me.Nombre_equi, Me.Codigo, Me.Nombre_producto, Me.Marca, Me.Stock, Me.Stock_bod_solicitante, Me.CantPed, Me.CantEnt, Me.CantFalt, Me.CPQ, Me.Total_P, Me.Lote, Me.ANULAR, Me.Accion})
        Me.dgvproductos.Location = New System.Drawing.Point(6, 20)
        Me.dgvproductos.MultiSelect = False
        Me.dgvproductos.Name = "dgvproductos"
        Me.dgvproductos.RowHeadersVisible = False
        Me.dgvproductos.Size = New System.Drawing.Size(1267, 301)
        Me.dgvproductos.TabIndex = 2
        '
        'Codigo_Interno
        '
        Me.Codigo_Interno.ContextMenuStrip = Me.menuequivalencias
        Me.Codigo_Interno.Frozen = True
        Me.Codigo_Interno.HeaderText = "Código Interno"
        Me.Codigo_Interno.Name = "Codigo_Interno"
        Me.Codigo_Interno.Visible = False
        Me.Codigo_Interno.Width = 84
        '
        'menuequivalencias
        '
        Me.menuequivalencias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarEquivalenciaToolStripMenuItem})
        Me.menuequivalencias.Name = "menuequivalencias"
        Me.menuequivalencias.Size = New System.Drawing.Size(240, 26)
        '
        'AgregarEquivalenciaToolStripMenuItem
        '
        Me.AgregarEquivalenciaToolStripMenuItem.Name = "AgregarEquivalenciaToolStripMenuItem"
        Me.AgregarEquivalenciaToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.AgregarEquivalenciaToolStripMenuItem.Text = "Dividir Cantidades Equivalencia"
        '
        'Nombre_equi
        '
        Me.Nombre_equi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Nombre_equi.ContextMenuStrip = Me.menuequivalencias
        Me.Nombre_equi.HeaderText = "Nombre Equivalencia"
        Me.Nombre_equi.Name = "Nombre_equi"
        Me.Nombre_equi.Width = 350
        '
        'Codigo
        '
        Me.Codigo.ContextMenuStrip = Me.menuequivalencias
        Me.Codigo.HeaderText = "Código Producto"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Visible = False
        Me.Codigo.Width = 113
        '
        'Nombre_producto
        '
        Me.Nombre_producto.ContextMenuStrip = Me.menuequivalencias
        Me.Nombre_producto.HeaderText = "Nombre Producto"
        Me.Nombre_producto.Name = "Nombre_producto"
        Me.Nombre_producto.Width = 106
        '
        'Marca
        '
        Me.Marca.ContextMenuStrip = Me.menuequivalencias
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.Width = 60
        '
        'Stock
        '
        Me.Stock.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle4
        Me.Stock.HeaderText = "Stock Bod. Solicitada"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 122
        '
        'Stock_bod_solicitante
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.SandyBrown
        Me.Stock_bod_solicitante.DefaultCellStyle = DataGridViewCellStyle5
        Me.Stock_bod_solicitante.HeaderText = "Stock Bod. Solicitante"
        Me.Stock_bod_solicitante.Name = "Stock_bod_solicitante"
        Me.Stock_bod_solicitante.Width = 124
        '
        'CantPed
        '
        Me.CantPed.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantPed.DefaultCellStyle = DataGridViewCellStyle6
        Me.CantPed.HeaderText = "Cantidad Pedida"
        Me.CantPed.Name = "CantPed"
        '
        'CantEnt
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantEnt.DefaultCellStyle = DataGridViewCellStyle7
        Me.CantEnt.HeaderText = "Cantidad Entregada"
        Me.CantEnt.Name = "CantEnt"
        Me.CantEnt.Width = 113
        '
        'CantFalt
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantFalt.DefaultCellStyle = DataGridViewCellStyle8
        Me.CantFalt.HeaderText = "Cantidad Faltante"
        Me.CantFalt.Name = "CantFalt"
        Me.CantFalt.Width = 104
        '
        'CPQ
        '
        Me.CPQ.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CPQ.DefaultCellStyle = DataGridViewCellStyle9
        Me.CPQ.HeaderText = "CPQ"
        Me.CPQ.Name = "CPQ"
        Me.CPQ.Visible = False
        Me.CPQ.Width = 55
        '
        'Total_P
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.Total_P.DefaultCellStyle = DataGridViewCellStyle10
        Me.Total_P.HeaderText = "Total Producto"
        Me.Total_P.Name = "Total_P"
        Me.Total_P.Width = 95
        '
        'Lote
        '
        Me.Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Lote.Text = "Lotes"
        Me.Lote.UseColumnTextForButtonValue = True
        Me.Lote.Width = 53
        '
        'ANULAR
        '
        Me.ANULAR.HeaderText = "Anular/Quitar"
        Me.ANULAR.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.ANULAR.Name = "ANULAR"
        Me.ANULAR.Width = 77
        '
        'Accion
        '
        Me.Accion.HeaderText = "Accion"
        Me.Accion.Name = "Accion"
        Me.Accion.Visible = False
        Me.Accion.Width = 65
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 44)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1291, 515)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPuntoServicio)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtEmpresa)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.CmbBodSolicitada)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.btnBuscar_pedidos)
        Me.GroupBox2.Controls.Add(Me.CmbBodSolicitante)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtCodigoPedido)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(615, 163)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del pedido"
        '
        'txtPuntoServicio
        '
        Me.txtPuntoServicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuntoServicio.Location = New System.Drawing.Point(88, 74)
        Me.txtPuntoServicio.Name = "txtPuntoServicio"
        Me.txtPuntoServicio.Size = New System.Drawing.Size(521, 21)
        Me.txtPuntoServicio.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 15)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Punto:"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.Location = New System.Drawing.Point(88, 47)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(521, 21)
        Me.txtEmpresa.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 15)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Empresa:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "B. Solicitada:"
        '
        'CmbBodSolicitada
        '
        Me.CmbBodSolicitada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBodSolicitada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBodSolicitada.DropDownHeight = 200
        Me.CmbBodSolicitada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodSolicitada.Enabled = False
        Me.CmbBodSolicitada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBodSolicitada.FormattingEnabled = True
        Me.CmbBodSolicitada.IntegralHeight = False
        Me.CmbBodSolicitada.Location = New System.Drawing.Point(88, 130)
        Me.CmbBodSolicitada.Name = "CmbBodSolicitada"
        Me.CmbBodSolicitada.Size = New System.Drawing.Size(521, 23)
        Me.CmbBodSolicitada.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "B. Solicitante:"
        '
        'btnBuscar_pedidos
        '
        Me.btnBuscar_pedidos.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btnBuscar_pedidos.Location = New System.Drawing.Point(183, 19)
        Me.btnBuscar_pedidos.Name = "btnBuscar_pedidos"
        Me.btnBuscar_pedidos.Size = New System.Drawing.Size(25, 23)
        Me.btnBuscar_pedidos.TabIndex = 25
        Me.btnBuscar_pedidos.UseVisualStyleBackColor = True
        '
        'CmbBodSolicitante
        '
        Me.CmbBodSolicitante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBodSolicitante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBodSolicitante.DropDownHeight = 200
        Me.CmbBodSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodSolicitante.Enabled = False
        Me.CmbBodSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBodSolicitante.FormattingEnabled = True
        Me.CmbBodSolicitante.IntegralHeight = False
        Me.CmbBodSolicitante.Location = New System.Drawing.Point(88, 101)
        Me.CmbBodSolicitante.Name = "CmbBodSolicitante"
        Me.CmbBodSolicitante.Size = New System.Drawing.Size(521, 23)
        Me.CmbBodSolicitante.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 15)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Pedido No:"
        '
        'txtCodigoPedido
        '
        Me.txtCodigoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoPedido.Location = New System.Drawing.Point(88, 20)
        Me.txtCodigoPedido.Name = "txtCodigoPedido"
        Me.txtCodigoPedido.ReadOnly = True
        Me.txtCodigoPedido.Size = New System.Drawing.Size(89, 21)
        Me.txtCodigoPedido.TabIndex = 23
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.ContextMenuStrip = Me.menuequivalencias
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código Interno"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 93
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.ContextMenuStrip = Me.menuequivalencias
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre Equivalencia"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewDateTimePickerColumn1
        '
        Me.DataGridViewDateTimePickerColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewDateTimePickerColumn1.HeaderText = "Fecha Vencimiento"
        Me.DataGridViewDateTimePickerColumn1.Name = "DataGridViewDateTimePickerColumn1"
        Me.DataGridViewDateTimePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDateTimePickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "Stock"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 74
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn5.HeaderText = "CPQ"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 54
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn6.HeaderText = "Código Producto"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 102
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn7.HeaderText = "Nombre Producto"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 105
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.ContextMenuStrip = Me.menuequivalencias
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn8.HeaderText = "Marca"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 62
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.ContextMenuStrip = Me.menuequivalencias
        Me.DataGridViewTextBoxColumn9.HeaderText = "Accion"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 65
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.ContextMenuStrip = Me.menuequivalencias
        Me.DataGridViewTextBoxColumn10.HeaderText = "Nombre Producto"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 105
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.ContextMenuStrip = Me.menuequivalencias
        Me.DataGridViewTextBoxColumn11.HeaderText = "Marca"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 62
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Accion"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 65
        '
        'Form_traslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "Form_traslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.PnlLotes.ResumeLayout(False)
        Me.PnlLotes.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.dgvLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvproductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuequivalencias.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents Label6 As Label
    Public WithEvents txtcodigo As TextBox
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
    Public WithEvents txtGuia As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents Label4 As Label
    Public WithEvents CmbTransportadora As ComboBox
    Public WithEvents Label7 As Label
    Public WithEvents txtEstado As TextBox
    Public WithEvents Label5 As Label
    Public WithEvents ChkAumento As CheckBox
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents LblCantidad_productos As ToolStripLabel
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents dgvproductos As DataGridView
    Public WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Public WithEvents GroupBox4 As GroupBox
    Public WithEvents menuequivalencias As ContextMenuStrip
    Public WithEvents AgregarEquivalenciaToolStripMenuItem As ToolStripMenuItem
    Public WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Public WithEvents PnlLotes As Panel
    Public WithEvents ToolStrip2 As ToolStrip
    Public WithEvents BtSalirlOTES As ToolStripButton
    Public WithEvents Label15 As Label
    Public WithEvents TxtCantidadProducto As TextBox
    Public WithEvents Label14 As Label
    Public WithEvents TxtDescripcionProducto As TextBox
    Public WithEvents dgvLotes As DataGridView
    Public WithEvents DataGridViewDateTimePickerColumn1 As DataGridViewDateTimePickerColumn
    Public WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Public WithEvents Reg_lote As DataGridViewTextBoxColumn
    Public WithEvents Num_lote As DataGridViewTextBoxColumn
    Public WithEvents Fecha As DataGridViewDateTimePickerColumn
    Public WithEvents stockLote As DataGridViewTextBoxColumn
    Public WithEvents Cantidad As DataGridViewTextBoxColumn
    Public WithEvents Costo As DataGridViewTextBoxColumn
    Public WithEvents Total As DataGridViewTextBoxColumn
    Public WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Public WithEvents btimprimir As ToolStripButton
    Public WithEvents LblCostoTotal As ToolStripLabel
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label10 As Label
    Public WithEvents CmbBodSolicitada As ComboBox
    Public WithEvents Label9 As Label
    Public WithEvents btnBuscar_pedidos As Button
    Public WithEvents CmbBodSolicitante As ComboBox
    Public WithEvents Label8 As Label
    Public WithEvents txtCodigoPedido As TextBox
    Friend WithEvents txtPuntoServicio As TextBox
    Public WithEvents Label12 As Label
    Friend WithEvents txtEmpresa As TextBox
    Public WithEvents Label11 As Label
    Friend WithEvents dpFechaTraslado As DateTimePicker
    Friend WithEvents Codigo_Interno As DataGridViewTextBoxColumn
    Friend WithEvents Nombre_equi As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Nombre_producto As DataGridViewTextBoxColumn
    Friend WithEvents Marca As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Stock_bod_solicitante As DataGridViewTextBoxColumn
    Friend WithEvents CantPed As DataGridViewTextBoxColumn
    Friend WithEvents CantEnt As DataGridViewTextBoxColumn
    Friend WithEvents CantFalt As DataGridViewTextBoxColumn
    Friend WithEvents CPQ As DataGridViewTextBoxColumn
    Friend WithEvents Total_P As DataGridViewTextBoxColumn
    Friend WithEvents Lote As DataGridViewButtonColumn
    Friend WithEvents ANULAR As DataGridViewImageColumn
    Friend WithEvents Accion As DataGridViewTextBoxColumn
End Class
