<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fom_consolidado_comida
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fom_consolidado_comida))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgvCena = New System.Windows.Forms.DataGridView()
        Me.NombreC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgvAlmuerzo = New System.Windows.Forms.DataGridView()
        Me.NombreA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvDesayuno = New System.Windows.Forms.DataGridView()
        Me.NombreD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbAreaServicio = New System.Windows.Forms.ComboBox()
        Me.lab = New System.Windows.Forms.Label()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbFecha = New System.Windows.Forms.ComboBox()
        Me.txtCostosTotalesComidas = New System.Windows.Forms.TextBox()
        Me.txtCostoCenas = New System.Windows.Forms.TextBox()
        Me.txtCostosAlmuerzos = New System.Windows.Forms.TextBox()
        Me.txtCostosDesayunos = New System.Windows.Forms.TextBox()
        Me.txtCantidadTotalesComidas = New System.Windows.Forms.TextBox()
        Me.txtCantidadCenas = New System.Windows.Forms.TextBox()
        Me.txtCantidadAlmuerzos = New System.Windows.Forms.TextBox()
        Me.txtCantidadDesayunos = New System.Windows.Forms.TextBox()
        Me.lblTotalComidas = New System.Windows.Forms.Label()
        Me.lblCantidadCenas = New System.Windows.Forms.Label()
        Me.lblCantidadAlmuerzos = New System.Windows.Forms.Label()
        Me.lblCantidadDesayunos = New System.Windows.Forms.Label()
        Me.lblCostosTotales = New System.Windows.Forms.Label()
        Me.lblCostoCenas = New System.Windows.Forms.Label()
        Me.lblCostoAlmuerzos = New System.Windows.Forms.Label()
        Me.lblCostoDesayunos = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.btOpcionDetallado = New System.Windows.Forms.Button()
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvCena, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvAlmuerzo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDesayuno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "CONSOLIDADO DE COMIDAS"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.checklist48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(982, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "_________________________________________________________________________________" &
    "__________________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1021, 471)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1009, 399)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información de Comidas"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgvCena)
        Me.GroupBox6.Location = New System.Drawing.Point(675, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(328, 373)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Cenas"
        '
        'dgvCena
        '
        Me.dgvCena.AllowUserToAddRows = False
        Me.dgvCena.AllowUserToDeleteRows = False
        Me.dgvCena.AllowUserToResizeColumns = False
        Me.dgvCena.AllowUserToResizeRows = False
        Me.dgvCena.BackgroundColor = System.Drawing.Color.White
        Me.dgvCena.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCena.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreC, Me.CantidadC, Me.ValorC, Me.TotalC})
        Me.dgvCena.Location = New System.Drawing.Point(6, 20)
        Me.dgvCena.Name = "dgvCena"
        Me.dgvCena.RowHeadersVisible = False
        Me.dgvCena.Size = New System.Drawing.Size(316, 347)
        Me.dgvCena.TabIndex = 0
        '
        'NombreC
        '
        Me.NombreC.HeaderText = "Nombre"
        Me.NombreC.Name = "NombreC"
        Me.NombreC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreC.Width = 110
        '
        'CantidadC
        '
        Me.CantidadC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantidadC.DefaultCellStyle = DataGridViewCellStyle1
        Me.CantidadC.HeaderText = "Cant."
        Me.CantidadC.Name = "CantidadC"
        Me.CantidadC.Width = 45
        '
        'ValorC
        '
        Me.ValorC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ValorC.DefaultCellStyle = DataGridViewCellStyle2
        Me.ValorC.HeaderText = "Valor"
        Me.ValorC.Name = "ValorC"
        Me.ValorC.Width = 60
        '
        'TotalC
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.TotalC.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalC.HeaderText = "Total"
        Me.TotalC.Name = "TotalC"
        Me.TotalC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalC.Width = 80
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgvAlmuerzo)
        Me.GroupBox5.Location = New System.Drawing.Point(341, 20)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(328, 373)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Almuerzos"
        '
        'dgvAlmuerzo
        '
        Me.dgvAlmuerzo.AllowUserToAddRows = False
        Me.dgvAlmuerzo.AllowUserToDeleteRows = False
        Me.dgvAlmuerzo.AllowUserToResizeColumns = False
        Me.dgvAlmuerzo.AllowUserToResizeRows = False
        Me.dgvAlmuerzo.BackgroundColor = System.Drawing.Color.White
        Me.dgvAlmuerzo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlmuerzo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreA, Me.CantidadA, Me.ValorA, Me.TotalA})
        Me.dgvAlmuerzo.Location = New System.Drawing.Point(6, 20)
        Me.dgvAlmuerzo.Name = "dgvAlmuerzo"
        Me.dgvAlmuerzo.RowHeadersVisible = False
        Me.dgvAlmuerzo.Size = New System.Drawing.Size(316, 347)
        Me.dgvAlmuerzo.TabIndex = 0
        '
        'NombreA
        '
        Me.NombreA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NombreA.HeaderText = "Nombre"
        Me.NombreA.Name = "NombreA"
        Me.NombreA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreA.Width = 110
        '
        'CantidadA
        '
        Me.CantidadA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantidadA.DefaultCellStyle = DataGridViewCellStyle4
        Me.CantidadA.HeaderText = "Cant."
        Me.CantidadA.Name = "CantidadA"
        Me.CantidadA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CantidadA.Width = 45
        '
        'ValorA
        '
        Me.ValorA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ValorA.DefaultCellStyle = DataGridViewCellStyle5
        Me.ValorA.HeaderText = "Valor"
        Me.ValorA.Name = "ValorA"
        Me.ValorA.Width = 60
        '
        'TotalA
        '
        Me.TotalA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.TotalA.DefaultCellStyle = DataGridViewCellStyle6
        Me.TotalA.HeaderText = "Total"
        Me.TotalA.Name = "TotalA"
        Me.TotalA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalA.Width = 80
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvDesayuno)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(328, 373)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Desayunos"
        '
        'dgvDesayuno
        '
        Me.dgvDesayuno.AllowUserToAddRows = False
        Me.dgvDesayuno.AllowUserToDeleteRows = False
        Me.dgvDesayuno.AllowUserToResizeColumns = False
        Me.dgvDesayuno.AllowUserToResizeRows = False
        Me.dgvDesayuno.BackgroundColor = System.Drawing.Color.White
        Me.dgvDesayuno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDesayuno.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreD, Me.CantidadD, Me.ValorD, Me.TotalD})
        Me.dgvDesayuno.Location = New System.Drawing.Point(6, 20)
        Me.dgvDesayuno.Name = "dgvDesayuno"
        Me.dgvDesayuno.RowHeadersVisible = False
        Me.dgvDesayuno.Size = New System.Drawing.Size(316, 347)
        Me.dgvDesayuno.TabIndex = 0
        '
        'NombreD
        '
        Me.NombreD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NombreD.HeaderText = "Nombre"
        Me.NombreD.Name = "NombreD"
        Me.NombreD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreD.Width = 110
        '
        'CantidadD
        '
        Me.CantidadD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantidadD.DefaultCellStyle = DataGridViewCellStyle7
        Me.CantidadD.HeaderText = "Cant."
        Me.CantidadD.Name = "CantidadD"
        Me.CantidadD.Width = 45
        '
        'ValorD
        '
        Me.ValorD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.ValorD.DefaultCellStyle = DataGridViewCellStyle8
        Me.ValorD.HeaderText = "Valor"
        Me.ValorD.Name = "ValorD"
        Me.ValorD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ValorD.Width = 60
        '
        'TotalD
        '
        Me.TotalD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.TotalD.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalD.HeaderText = "Total"
        Me.TotalD.Name = "TotalD"
        Me.TotalD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalD.Width = 80
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbAreaServicio)
        Me.GroupBox2.Controls.Add(Me.lab)
        Me.GroupBox2.Controls.Add(Me.cmbAnio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.CmbFecha)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1009, 50)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(454, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Área Servicio:"
        '
        'cmbAreaServicio
        '
        Me.cmbAreaServicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreaServicio.FormattingEnabled = True
        Me.cmbAreaServicio.Location = New System.Drawing.Point(541, 16)
        Me.cmbAreaServicio.Name = "cmbAreaServicio"
        Me.cmbAreaServicio.Size = New System.Drawing.Size(266, 23)
        Me.cmbAreaServicio.TabIndex = 11
        '
        'lab
        '
        Me.lab.AutoSize = True
        Me.lab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab.Location = New System.Drawing.Point(266, 20)
        Me.lab.Name = "lab"
        Me.lab.Size = New System.Drawing.Size(34, 15)
        Me.lab.TabIndex = 9
        Me.lab.Text = "Año :"
        '
        'cmbAnio
        '
        Me.cmbAnio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Location = New System.Drawing.Point(306, 16)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(85, 23)
        Me.cmbAnio.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Mes :"
        '
        'CmbFecha
        '
        Me.CmbFecha.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbFecha.FormattingEnabled = True
        Me.CmbFecha.Location = New System.Drawing.Point(61, 16)
        Me.CmbFecha.Name = "CmbFecha"
        Me.CmbFecha.Size = New System.Drawing.Size(176, 23)
        Me.CmbFecha.TabIndex = 6
        '
        'txtCostosTotalesComidas
        '
        Me.txtCostosTotalesComidas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostosTotalesComidas.Location = New System.Drawing.Point(886, 556)
        Me.txtCostosTotalesComidas.Name = "txtCostosTotalesComidas"
        Me.txtCostosTotalesComidas.ReadOnly = True
        Me.txtCostosTotalesComidas.Size = New System.Drawing.Size(136, 21)
        Me.txtCostosTotalesComidas.TabIndex = 15
        Me.txtCostosTotalesComidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoCenas
        '
        Me.txtCostoCenas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoCenas.Location = New System.Drawing.Point(669, 555)
        Me.txtCostoCenas.Name = "txtCostoCenas"
        Me.txtCostoCenas.ReadOnly = True
        Me.txtCostoCenas.Size = New System.Drawing.Size(102, 21)
        Me.txtCostoCenas.TabIndex = 14
        Me.txtCostoCenas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostosAlmuerzos
        '
        Me.txtCostosAlmuerzos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostosAlmuerzos.Location = New System.Drawing.Point(461, 555)
        Me.txtCostosAlmuerzos.Name = "txtCostosAlmuerzos"
        Me.txtCostosAlmuerzos.ReadOnly = True
        Me.txtCostosAlmuerzos.Size = New System.Drawing.Size(102, 21)
        Me.txtCostosAlmuerzos.TabIndex = 13
        Me.txtCostosAlmuerzos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostosDesayunos
        '
        Me.txtCostosDesayunos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostosDesayunos.Location = New System.Drawing.Point(234, 555)
        Me.txtCostosDesayunos.Name = "txtCostosDesayunos"
        Me.txtCostosDesayunos.ReadOnly = True
        Me.txtCostosDesayunos.Size = New System.Drawing.Size(102, 21)
        Me.txtCostosDesayunos.TabIndex = 12
        Me.txtCostosDesayunos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidadTotalesComidas
        '
        Me.txtCantidadTotalesComidas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadTotalesComidas.Location = New System.Drawing.Point(922, 531)
        Me.txtCantidadTotalesComidas.Name = "txtCantidadTotalesComidas"
        Me.txtCantidadTotalesComidas.ReadOnly = True
        Me.txtCantidadTotalesComidas.Size = New System.Drawing.Size(100, 21)
        Me.txtCantidadTotalesComidas.TabIndex = 11
        Me.txtCantidadTotalesComidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadCenas
        '
        Me.txtCantidadCenas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadCenas.Location = New System.Drawing.Point(692, 531)
        Me.txtCantidadCenas.Name = "txtCantidadCenas"
        Me.txtCantidadCenas.ReadOnly = True
        Me.txtCantidadCenas.Size = New System.Drawing.Size(79, 21)
        Me.txtCantidadCenas.TabIndex = 10
        Me.txtCantidadCenas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadAlmuerzos
        '
        Me.txtCantidadAlmuerzos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadAlmuerzos.Location = New System.Drawing.Point(484, 531)
        Me.txtCantidadAlmuerzos.Name = "txtCantidadAlmuerzos"
        Me.txtCantidadAlmuerzos.ReadOnly = True
        Me.txtCantidadAlmuerzos.Size = New System.Drawing.Size(79, 21)
        Me.txtCantidadAlmuerzos.TabIndex = 9
        Me.txtCantidadAlmuerzos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadDesayunos
        '
        Me.txtCantidadDesayunos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadDesayunos.Location = New System.Drawing.Point(257, 531)
        Me.txtCantidadDesayunos.Name = "txtCantidadDesayunos"
        Me.txtCantidadDesayunos.ReadOnly = True
        Me.txtCantidadDesayunos.Size = New System.Drawing.Size(79, 21)
        Me.txtCantidadDesayunos.TabIndex = 8
        Me.txtCantidadDesayunos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalComidas
        '
        Me.lblTotalComidas.AutoSize = True
        Me.lblTotalComidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalComidas.Location = New System.Drawing.Point(783, 533)
        Me.lblTotalComidas.Name = "lblTotalComidas"
        Me.lblTotalComidas.Size = New System.Drawing.Size(132, 16)
        Me.lblTotalComidas.TabIndex = 7
        Me.lblTotalComidas.Text = "Cant. Total Comidas:"
        '
        'lblCantidadCenas
        '
        Me.lblCantidadCenas.AutoSize = True
        Me.lblCantidadCenas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadCenas.Location = New System.Drawing.Point(582, 533)
        Me.lblCantidadCenas.Name = "lblCantidadCenas"
        Me.lblCantidadCenas.Size = New System.Drawing.Size(107, 16)
        Me.lblCantidadCenas.TabIndex = 6
        Me.lblCantidadCenas.Text = "Cantidad Cenas:"
        '
        'lblCantidadAlmuerzos
        '
        Me.lblCantidadAlmuerzos.AutoSize = True
        Me.lblCantidadAlmuerzos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadAlmuerzos.Location = New System.Drawing.Point(351, 533)
        Me.lblCantidadAlmuerzos.Name = "lblCantidadAlmuerzos"
        Me.lblCantidadAlmuerzos.Size = New System.Drawing.Size(131, 16)
        Me.lblCantidadAlmuerzos.TabIndex = 5
        Me.lblCantidadAlmuerzos.Text = "Cantidad Almuerzos:"
        '
        'lblCantidadDesayunos
        '
        Me.lblCantidadDesayunos.AutoSize = True
        Me.lblCantidadDesayunos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadDesayunos.Location = New System.Drawing.Point(114, 533)
        Me.lblCantidadDesayunos.Name = "lblCantidadDesayunos"
        Me.lblCantidadDesayunos.Size = New System.Drawing.Size(137, 16)
        Me.lblCantidadDesayunos.TabIndex = 4
        Me.lblCantidadDesayunos.Text = "Cantidad Desayunos:"
        '
        'lblCostosTotales
        '
        Me.lblCostosTotales.AutoSize = True
        Me.lblCostosTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostosTotales.Location = New System.Drawing.Point(783, 558)
        Me.lblCostosTotales.Name = "lblCostosTotales"
        Me.lblCostosTotales.Size = New System.Drawing.Size(99, 16)
        Me.lblCostosTotales.TabIndex = 3
        Me.lblCostosTotales.Text = "Total Comidas:"
        '
        'lblCostoCenas
        '
        Me.lblCostoCenas.AutoSize = True
        Me.lblCostoCenas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoCenas.Location = New System.Drawing.Point(583, 557)
        Me.lblCostoCenas.Name = "lblCostoCenas"
        Me.lblCostoCenas.Size = New System.Drawing.Size(84, 16)
        Me.lblCostoCenas.TabIndex = 2
        Me.lblCostoCenas.Text = "Total Cenas:"
        '
        'lblCostoAlmuerzos
        '
        Me.lblCostoAlmuerzos.AutoSize = True
        Me.lblCostoAlmuerzos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoAlmuerzos.Location = New System.Drawing.Point(351, 557)
        Me.lblCostoAlmuerzos.Name = "lblCostoAlmuerzos"
        Me.lblCostoAlmuerzos.Size = New System.Drawing.Size(108, 16)
        Me.lblCostoAlmuerzos.TabIndex = 1
        Me.lblCostoAlmuerzos.Text = "Total Almuerzos:"
        '
        'lblCostoDesayunos
        '
        Me.lblCostoDesayunos.AutoSize = True
        Me.lblCostoDesayunos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoDesayunos.Location = New System.Drawing.Point(114, 557)
        Me.lblCostoDesayunos.Name = "lblCostoDesayunos"
        Me.lblCostoDesayunos.Size = New System.Drawing.Size(114, 16)
        Me.lblCostoDesayunos.TabIndex = 0
        Me.lblCostoDesayunos.Text = "Total Desayunos:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 528)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'btOpcionDetallado
        '
        Me.btOpcionDetallado.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionDetallado.Image = Global.Celer.My.Resources.Resources.check_nada_23
        Me.btOpcionDetallado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionDetallado.Location = New System.Drawing.Point(837, 3)
        Me.btOpcionDetallado.Name = "btOpcionDetallado"
        Me.btOpcionDetallado.Size = New System.Drawing.Size(118, 34)
        Me.btOpcionDetallado.TabIndex = 34
        Me.btOpcionDetallado.Text = "Informe Detallado"
        Me.btOpcionDetallado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionDetallado.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cant."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 45
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 110
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cant."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 45
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn7.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 60
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = "0"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn8.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn9.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 110
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn10.HeaderText = "Cant."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 45
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "0"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn11.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 60
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn12.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'Fom_consolidado_comida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 582)
        Me.Controls.Add(Me.txtCostosTotalesComidas)
        Me.Controls.Add(Me.txtCostoCenas)
        Me.Controls.Add(Me.txtCostosAlmuerzos)
        Me.Controls.Add(Me.txtCostosDesayunos)
        Me.Controls.Add(Me.txtCantidadTotalesComidas)
        Me.Controls.Add(Me.txtCantidadCenas)
        Me.Controls.Add(Me.txtCantidadAlmuerzos)
        Me.Controls.Add(Me.txtCantidadDesayunos)
        Me.Controls.Add(Me.lblCostoDesayunos)
        Me.Controls.Add(Me.lblTotalComidas)
        Me.Controls.Add(Me.lblCostoAlmuerzos)
        Me.Controls.Add(Me.lblCantidadCenas)
        Me.Controls.Add(Me.lblCostoCenas)
        Me.Controls.Add(Me.lblCantidadAlmuerzos)
        Me.Controls.Add(Me.lblCostosTotales)
        Me.Controls.Add(Me.lblCantidadDesayunos)
        Me.Controls.Add(Me.btOpcionDetallado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "Fom_consolidado_comida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgvCena, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvAlmuerzo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvDesayuno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Friend WithEvents lab As Label
    Friend WithEvents cmbAnio As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbFecha As ComboBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblTotalComidas As Label
    Friend WithEvents lblCantidadCenas As Label
    Friend WithEvents lblCantidadAlmuerzos As Label
    Friend WithEvents lblCantidadDesayunos As Label
    Friend WithEvents lblCostosTotales As Label
    Friend WithEvents lblCostoCenas As Label
    Friend WithEvents lblCostoAlmuerzos As Label
    Friend WithEvents lblCostoDesayunos As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dgvCena As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgvAlmuerzo As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvDesayuno As DataGridView
    Friend WithEvents txtCostosTotalesComidas As TextBox
    Friend WithEvents txtCostoCenas As TextBox
    Friend WithEvents txtCostosAlmuerzos As TextBox
    Friend WithEvents txtCostosDesayunos As TextBox
    Friend WithEvents txtCantidadTotalesComidas As TextBox
    Friend WithEvents txtCantidadCenas As TextBox
    Friend WithEvents txtCantidadAlmuerzos As TextBox
    Friend WithEvents txtCantidadDesayunos As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbAreaServicio As ComboBox
    Public WithEvents btOpcionDetallado As Button
    Friend WithEvents NombreC As DataGridViewTextBoxColumn
    Friend WithEvents CantidadC As DataGridViewTextBoxColumn
    Friend WithEvents ValorC As DataGridViewTextBoxColumn
    Friend WithEvents TotalC As DataGridViewTextBoxColumn
    Friend WithEvents NombreA As DataGridViewTextBoxColumn
    Friend WithEvents CantidadA As DataGridViewTextBoxColumn
    Friend WithEvents ValorA As DataGridViewTextBoxColumn
    Friend WithEvents TotalA As DataGridViewTextBoxColumn
    Friend WithEvents NombreD As DataGridViewTextBoxColumn
    Friend WithEvents CantidadD As DataGridViewTextBoxColumn
    Friend WithEvents ValorD As DataGridViewTextBoxColumn
    Friend WithEvents TotalD As DataGridViewTextBoxColumn
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
End Class
