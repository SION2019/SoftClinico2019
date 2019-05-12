<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormManualTarifario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormManualTarifario))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.btAgregarFila = New System.Windows.Forms.Button()
        Me.dgvManualTarifario = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDuplicarLista = New System.Windows.Forms.Button()
        Me.cmbEPS = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNombreManual = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPaisO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaisOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodDptoO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DptoOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMunO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mun_Origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEntO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntidadOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPaisD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaisDestino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodDptoD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DptoDestino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMunD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MunDestino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEntD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntidadDestino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodTras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Traslado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paramedico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fisioterapeuta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Conductor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contacto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvManualTarifario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "MANUAL TARIFARIO AMBULANCIA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(982, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "_________________________________________________________________________________" &
    "__________________________________________________________"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 13
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 470)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtBusqueda)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 119)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1006, 62)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Busqueda Avanzada"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Busqueda: "
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(98, 22)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(902, 21)
        Me.txtBusqueda.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel7)
        Me.GroupBox3.Controls.Add(Me.btAgregarFila)
        Me.GroupBox3.Controls.Add(Me.dgvManualTarifario)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 196)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1007, 268)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lista de Precios"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.OldLace
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.txtComentario)
        Me.Panel7.Location = New System.Drawing.Point(475, 84)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(509, 124)
        Me.Panel7.TabIndex = 10086
        Me.Panel7.Visible = False
        '
        'txtComentario
        '
        Me.txtComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.Location = New System.Drawing.Point(3, 3)
        Me.txtComentario.MaxLength = 50
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentario.Size = New System.Drawing.Size(501, 116)
        Me.txtComentario.TabIndex = 10065
        '
        'btAgregarFila
        '
        Me.btAgregarFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAgregarFila.Image = Global.Celer.My.Resources.Resources.add_icon
        Me.btAgregarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAgregarFila.Location = New System.Drawing.Point(6, 20)
        Me.btAgregarFila.Name = "btAgregarFila"
        Me.btAgregarFila.Size = New System.Drawing.Size(121, 29)
        Me.btAgregarFila.TabIndex = 9
        Me.btAgregarFila.Text = "Agregar Fila"
        Me.btAgregarFila.UseVisualStyleBackColor = True
        '
        'dgvManualTarifario
        '
        Me.dgvManualTarifario.AllowUserToAddRows = False
        Me.dgvManualTarifario.AllowUserToDeleteRows = False
        Me.dgvManualTarifario.AllowUserToResizeColumns = False
        Me.dgvManualTarifario.AllowUserToResizeRows = False
        Me.dgvManualTarifario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvManualTarifario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvManualTarifario.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvManualTarifario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvManualTarifario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvManualTarifario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodPaisO, Me.PaisOrigen, Me.CodDptoO, Me.DptoOrigen, Me.CodMunO, Me.Mun_Origen, Me.CodEntO, Me.EntidadOrigen, Me.CodPaisD, Me.PaisDestino, Me.CodDptoD, Me.DptoDestino, Me.CodMunD, Me.MunDestino, Me.CodEntD, Me.EntidadDestino, Me.CodTras, Me.Traslado, Me.Valor, Me.Medico, Me.Paramedico, Me.Fisioterapeuta, Me.Conductor, Me.Contacto, Me.Observaciones, Me.CodInt})
        Me.dgvManualTarifario.Location = New System.Drawing.Point(6, 49)
        Me.dgvManualTarifario.Name = "dgvManualTarifario"
        Me.dgvManualTarifario.RowHeadersVisible = False
        Me.dgvManualTarifario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvManualTarifario.Size = New System.Drawing.Size(995, 213)
        Me.dgvManualTarifario.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDuplicarLista)
        Me.GroupBox2.Controls.Add(Me.cmbEPS)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtNombreManual)
        Me.GroupBox2.Controls.Add(Me.TxtCodigo)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1007, 79)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Manual"
        '
        'btnDuplicarLista
        '
        Me.btnDuplicarLista.Image = Global.Celer.My.Resources.Resources.Files_Copy_File_icon__2_
        Me.btnDuplicarLista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDuplicarLista.Location = New System.Drawing.Point(886, 31)
        Me.btnDuplicarLista.Name = "btnDuplicarLista"
        Me.btnDuplicarLista.Size = New System.Drawing.Size(114, 34)
        Me.btnDuplicarLista.TabIndex = 10002
        Me.btnDuplicarLista.Text = "Duplicar Lista"
        Me.btnDuplicarLista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDuplicarLista.UseVisualStyleBackColor = True
        '
        'cmbEPS
        '
        Me.cmbEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEPS.FormattingEnabled = True
        Me.cmbEPS.Location = New System.Drawing.Point(95, 47)
        Me.cmbEPS.Name = "cmbEPS"
        Me.cmbEPS.Size = New System.Drawing.Size(785, 23)
        Me.cmbEPS.TabIndex = 10001
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 10000
        Me.Label3.Text = "EPS:"
        '
        'TxtNombreManual
        '
        Me.TxtNombreManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreManual.Location = New System.Drawing.Point(314, 20)
        Me.TxtNombreManual.Name = "TxtNombreManual"
        Me.TxtNombreManual.ReadOnly = True
        Me.TxtNombreManual.Size = New System.Drawing.Size(566, 21)
        Me.TxtNombreManual.TabIndex = 9999
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(95, 20)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(136, 21)
        Me.TxtCodigo.TabIndex = 9999
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(253, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Nombre:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Código :"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn1.HeaderText = "conse"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Ciudad_Origen"
        Me.DataGridViewTextBoxColumn2.FillWeight = 117.5407!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ciudad Origen"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 130
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 130
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Pais_Destino"
        Me.DataGridViewTextBoxColumn3.FillWeight = 146.0403!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Entidad Origen"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 162
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 162
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Ciudad_Destino"
        Me.DataGridViewTextBoxColumn4.FillWeight = 102.4652!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ciudad Destino"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 113
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 113
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Pais_Destino"
        Me.DataGridViewTextBoxColumn5.FillWeight = 128.6433!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Entidad Destino"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 142
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 142
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Pais_Destino"
        Me.DataGridViewTextBoxColumn6.FillWeight = 210.4765!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Descripcion de Traslado"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 233
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 233
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 57.24609!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 63
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 63
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 58.18782!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Medico"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 65
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Paramedico"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 69
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Pais_Destino"
        Me.DataGridViewTextBoxColumn10.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn10.HeaderText = "Fisioterapeuta"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 79
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.FillWeight = 59.82351!
        Me.DataGridViewTextBoxColumn11.HeaderText = "Conductor"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 66
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 66
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.FillWeight = 60.53221!
        Me.DataGridViewTextBoxColumn12.HeaderText = "Contacto"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 67
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn12.Width = 67
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn13.HeaderText = "Observaciones"
        Me.DataGridViewTextBoxColumn13.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 84
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn14.HeaderText = "Fisioterapeuta"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Width = 79
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.FillWeight = 59.82351!
        Me.DataGridViewTextBoxColumn15.HeaderText = "Conductor"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 66
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 66
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.FillWeight = 60.53221!
        Me.DataGridViewTextBoxColumn16.HeaderText = "Contacto"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 67
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 67
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Observaciones"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 84
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.FillWeight = 210.4765!
        Me.DataGridViewTextBoxColumn18.HeaderText = "Descripcion de Traslado"
        Me.DataGridViewTextBoxColumn18.MinimumWidth = 233
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn18.Width = 233
        '
        'DataGridViewTextBoxColumn19
        '
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn19.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn19.FillWeight = 57.24609!
        Me.DataGridViewTextBoxColumn19.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn19.MinimumWidth = 63
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn19.Width = 63
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.FillWeight = 58.18782!
        Me.DataGridViewTextBoxColumn20.HeaderText = "Medico"
        Me.DataGridViewTextBoxColumn20.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 65
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn21.HeaderText = "Paramedico"
        Me.DataGridViewTextBoxColumn21.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn21.Visible = False
        Me.DataGridViewTextBoxColumn21.Width = 69
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.FillWeight = 59.0444!
        Me.DataGridViewTextBoxColumn22.HeaderText = "Fisioterapeuta"
        Me.DataGridViewTextBoxColumn22.MinimumWidth = 65
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn22.Visible = False
        Me.DataGridViewTextBoxColumn22.Width = 79
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.FillWeight = 59.82351!
        Me.DataGridViewTextBoxColumn23.HeaderText = "Conductor"
        Me.DataGridViewTextBoxColumn23.MinimumWidth = 66
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn23.Visible = False
        Me.DataGridViewTextBoxColumn23.Width = 66
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.FillWeight = 60.53221!
        Me.DataGridViewTextBoxColumn24.HeaderText = "Contacto"
        Me.DataGridViewTextBoxColumn24.MinimumWidth = 67
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn24.Visible = False
        Me.DataGridViewTextBoxColumn24.Width = 67
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Observaciones"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn25.Width = 84
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "CodInt"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Visible = False
        Me.DataGridViewTextBoxColumn26.Width = 64
        '
        'CodPaisO
        '
        Me.CodPaisO.HeaderText = "CodPaisO"
        Me.CodPaisO.Name = "CodPaisO"
        Me.CodPaisO.Visible = False
        Me.CodPaisO.Width = 61
        '
        'PaisOrigen
        '
        Me.PaisOrigen.DataPropertyName = "Pais_Origen"
        Me.PaisOrigen.FillWeight = 117.5407!
        Me.PaisOrigen.HeaderText = "País Origen"
        Me.PaisOrigen.MinimumWidth = 130
        Me.PaisOrigen.Name = "PaisOrigen"
        Me.PaisOrigen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaisOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PaisOrigen.Width = 130
        '
        'CodDptoO
        '
        Me.CodDptoO.HeaderText = "CodDptoO"
        Me.CodDptoO.Name = "CodDptoO"
        Me.CodDptoO.Visible = False
        Me.CodDptoO.Width = 82
        '
        'DptoOrigen
        '
        Me.DptoOrigen.HeaderText = "Departamento Origen"
        Me.DptoOrigen.Name = "DptoOrigen"
        Me.DptoOrigen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DptoOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DptoOrigen.Width = 113
        '
        'CodMunO
        '
        Me.CodMunO.HeaderText = "CodMunO"
        Me.CodMunO.Name = "CodMunO"
        Me.CodMunO.Visible = False
        Me.CodMunO.Width = 80
        '
        'Mun_Origen
        '
        Me.Mun_Origen.HeaderText = "Municipio Origen"
        Me.Mun_Origen.Name = "Mun_Origen"
        Me.Mun_Origen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Mun_Origen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mun_Origen.Width = 95
        '
        'CodEntO
        '
        Me.CodEntO.HeaderText = "CodEntO"
        Me.CodEntO.Name = "CodEntO"
        Me.CodEntO.Visible = False
        Me.CodEntO.Width = 75
        '
        'EntidadOrigen
        '
        Me.EntidadOrigen.FillWeight = 146.0403!
        Me.EntidadOrigen.HeaderText = "Entidad Origen"
        Me.EntidadOrigen.MinimumWidth = 162
        Me.EntidadOrigen.Name = "EntidadOrigen"
        Me.EntidadOrigen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EntidadOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EntidadOrigen.Width = 162
        '
        'CodPaisD
        '
        Me.CodPaisD.HeaderText = "CodPaisD"
        Me.CodPaisD.Name = "CodPaisD"
        Me.CodPaisD.Visible = False
        Me.CodPaisD.Width = 79
        '
        'PaisDestino
        '
        Me.PaisDestino.DataPropertyName = "Pais_Destino"
        Me.PaisDestino.FillWeight = 102.4652!
        Me.PaisDestino.HeaderText = "País Destino"
        Me.PaisDestino.MinimumWidth = 113
        Me.PaisDestino.Name = "PaisDestino"
        Me.PaisDestino.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaisDestino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PaisDestino.Width = 113
        '
        'CodDptoD
        '
        Me.CodDptoD.HeaderText = "CodDptoD"
        Me.CodDptoD.Name = "CodDptoD"
        Me.CodDptoD.Visible = False
        Me.CodDptoD.Width = 81
        '
        'DptoDestino
        '
        Me.DptoDestino.HeaderText = "Departamento Destino"
        Me.DptoDestino.Name = "DptoDestino"
        Me.DptoDestino.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DptoDestino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DptoDestino.Width = 116
        '
        'CodMunD
        '
        Me.CodMunD.HeaderText = "CodMunD"
        Me.CodMunD.Name = "CodMunD"
        Me.CodMunD.Visible = False
        Me.CodMunD.Width = 79
        '
        'MunDestino
        '
        Me.MunDestino.HeaderText = "Muncipio Destino"
        Me.MunDestino.Name = "MunDestino"
        Me.MunDestino.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MunDestino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MunDestino.Width = 95
        '
        'CodEntD
        '
        Me.CodEntD.HeaderText = "CodEntD"
        Me.CodEntD.Name = "CodEntD"
        Me.CodEntD.Visible = False
        Me.CodEntD.Width = 74
        '
        'EntidadDestino
        '
        Me.EntidadDestino.FillWeight = 128.6433!
        Me.EntidadDestino.HeaderText = "Entidad Destino"
        Me.EntidadDestino.MinimumWidth = 142
        Me.EntidadDestino.Name = "EntidadDestino"
        Me.EntidadDestino.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EntidadDestino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EntidadDestino.Width = 142
        '
        'CodTras
        '
        Me.CodTras.HeaderText = "CodTras"
        Me.CodTras.Name = "CodTras"
        Me.CodTras.Visible = False
        Me.CodTras.Width = 73
        '
        'Traslado
        '
        Me.Traslado.FillWeight = 210.4765!
        Me.Traslado.HeaderText = "Descripción de Traslado"
        Me.Traslado.MinimumWidth = 233
        Me.Traslado.Name = "Traslado"
        Me.Traslado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Traslado.Width = 233
        '
        'Valor
        '
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle8
        Me.Valor.FillWeight = 57.24609!
        Me.Valor.HeaderText = "Valor"
        Me.Valor.MinimumWidth = 63
        Me.Valor.Name = "Valor"
        Me.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valor.Width = 63
        '
        'Medico
        '
        Me.Medico.FillWeight = 58.18782!
        Me.Medico.HeaderText = "Médico"
        Me.Medico.MinimumWidth = 65
        Me.Medico.Name = "Medico"
        Me.Medico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Medico.Visible = False
        Me.Medico.Width = 65
        '
        'Paramedico
        '
        Me.Paramedico.FillWeight = 59.0444!
        Me.Paramedico.HeaderText = "Paramédico"
        Me.Paramedico.MinimumWidth = 65
        Me.Paramedico.Name = "Paramedico"
        Me.Paramedico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Paramedico.Visible = False
        Me.Paramedico.Width = 69
        '
        'Fisioterapeuta
        '
        Me.Fisioterapeuta.FillWeight = 59.0444!
        Me.Fisioterapeuta.HeaderText = "Fisioterapeuta"
        Me.Fisioterapeuta.MinimumWidth = 65
        Me.Fisioterapeuta.Name = "Fisioterapeuta"
        Me.Fisioterapeuta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fisioterapeuta.Visible = False
        Me.Fisioterapeuta.Width = 79
        '
        'Conductor
        '
        Me.Conductor.FillWeight = 59.82351!
        Me.Conductor.HeaderText = "Conductor"
        Me.Conductor.MinimumWidth = 66
        Me.Conductor.Name = "Conductor"
        Me.Conductor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Conductor.Visible = False
        Me.Conductor.Width = 66
        '
        'Contacto
        '
        Me.Contacto.FillWeight = 60.53221!
        Me.Contacto.HeaderText = "Contacto"
        Me.Contacto.MinimumWidth = 67
        Me.Contacto.Name = "Contacto"
        Me.Contacto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Contacto.Visible = False
        Me.Contacto.Width = 67
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Observaciones.Width = 83
        '
        'CodInt
        '
        Me.CodInt.HeaderText = "CodInt"
        Me.CodInt.Name = "CodInt"
        Me.CodInt.Visible = False
        Me.CodInt.Width = 64
        '
        'FormManualTarifario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "FormManualTarifario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.dgvManualTarifario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents TxtNombreManual As TextBox
    Public WithEvents TxtCodigo As TextBox
    Public WithEvents Label11 As Label
    Public WithEvents Label10 As Label
    Public WithEvents Label3 As Label
    Public WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgvManualTarifario As DataGridView
    Friend WithEvents cmbEPS As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents btnDuplicarLista As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents btAgregarFila As Button
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtComentario As TextBox
    Friend WithEvents CodPaisO As DataGridViewTextBoxColumn
    Friend WithEvents PaisOrigen As DataGridViewTextBoxColumn
    Friend WithEvents CodDptoO As DataGridViewTextBoxColumn
    Friend WithEvents DptoOrigen As DataGridViewTextBoxColumn
    Friend WithEvents CodMunO As DataGridViewTextBoxColumn
    Friend WithEvents Mun_Origen As DataGridViewTextBoxColumn
    Friend WithEvents CodEntO As DataGridViewTextBoxColumn
    Friend WithEvents EntidadOrigen As DataGridViewTextBoxColumn
    Friend WithEvents CodPaisD As DataGridViewTextBoxColumn
    Friend WithEvents PaisDestino As DataGridViewTextBoxColumn
    Friend WithEvents CodDptoD As DataGridViewTextBoxColumn
    Friend WithEvents DptoDestino As DataGridViewTextBoxColumn
    Friend WithEvents CodMunD As DataGridViewTextBoxColumn
    Friend WithEvents MunDestino As DataGridViewTextBoxColumn
    Friend WithEvents CodEntD As DataGridViewTextBoxColumn
    Friend WithEvents EntidadDestino As DataGridViewTextBoxColumn
    Friend WithEvents CodTras As DataGridViewTextBoxColumn
    Friend WithEvents Traslado As DataGridViewTextBoxColumn
    Friend WithEvents Valor As DataGridViewTextBoxColumn
    Friend WithEvents Medico As DataGridViewTextBoxColumn
    Friend WithEvents Paramedico As DataGridViewTextBoxColumn
    Friend WithEvents Fisioterapeuta As DataGridViewTextBoxColumn
    Friend WithEvents Conductor As DataGridViewTextBoxColumn
    Friend WithEvents Contacto As DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As DataGridViewTextBoxColumn
    Friend WithEvents CodInt As DataGridViewTextBoxColumn
End Class
