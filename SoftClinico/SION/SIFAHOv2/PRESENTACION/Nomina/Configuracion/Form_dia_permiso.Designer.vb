<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_dia_permiso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_dia_permiso))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.numtiempototalminutos = New System.Windows.Forms.NumericUpDown()
        Me.numtiempototalhoras = New System.Windows.Forms.NumericUpDown()
        Me.rbrangotiempo = New System.Windows.Forms.RadioButton()
        Me.rbtotal = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.fechacomienzo = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtfin = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbconvencion = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtretornar = New System.Windows.Forms.TextBox()
        Me.txtdescansar = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttiempototalhorario = New System.Windows.Forms.TextBox()
        Me.txtsalir = New System.Windows.Forms.TextBox()
        Me.txtentrar = New System.Windows.Forms.TextBox()
        Me.txtconvencion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtdia = New System.Windows.Forms.TextBox()
        Me.combotipo = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btaceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.numtiempototalminutos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numtiempototalhoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 278)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.rbrangotiempo)
        Me.GroupBox5.Controls.Add(Me.rbtotal)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 164)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(560, 109)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuracion del Permiso"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.numtiempototalminutos)
        Me.GroupBox7.Controls.Add(Me.numtiempototalhoras)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(285, 28)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(140, 69)
        Me.GroupBox7.TabIndex = 22
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tiempo Total"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(64, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 15)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = ";"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(79, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Minutos:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Horas:"
        '
        'numtiempototalminutos
        '
        Me.numtiempototalminutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.numtiempototalminutos.Location = New System.Drawing.Point(81, 32)
        Me.numtiempototalminutos.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.numtiempototalminutos.Name = "numtiempototalminutos"
        Me.numtiempototalminutos.Size = New System.Drawing.Size(44, 22)
        Me.numtiempototalminutos.TabIndex = 15
        '
        'numtiempototalhoras
        '
        Me.numtiempototalhoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.numtiempototalhoras.Location = New System.Drawing.Point(16, 32)
        Me.numtiempototalhoras.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numtiempototalhoras.Name = "numtiempototalhoras"
        Me.numtiempototalhoras.Size = New System.Drawing.Size(44, 22)
        Me.numtiempototalhoras.TabIndex = 14
        '
        'rbrangotiempo
        '
        Me.rbrangotiempo.AutoSize = True
        Me.rbrangotiempo.Location = New System.Drawing.Point(103, 20)
        Me.rbrangotiempo.Name = "rbrangotiempo"
        Me.rbrangotiempo.Size = New System.Drawing.Size(110, 20)
        Me.rbrangotiempo.TabIndex = 12
        Me.rbrangotiempo.TabStop = True
        Me.rbrangotiempo.Text = "Rango De Tiempo"
        Me.rbrangotiempo.UseVisualStyleBackColor = True
        '
        'rbtotal
        '
        Me.rbtotal.AutoSize = True
        Me.rbtotal.Location = New System.Drawing.Point(10, 21)
        Me.rbtotal.Name = "rbtotal"
        Me.rbtotal.Size = New System.Drawing.Size(50, 20)
        Me.rbtotal.TabIndex = 11
        Me.rbtotal.TabStop = True
        Me.rbtotal.Text = "Total"
        Me.rbtotal.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.fechacomienzo)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.txtfin)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(88, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(463, 83)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "     "
        '
        'fechacomienzo
        '
        Me.fechacomienzo.CustomFormat = " hh:mm tt"
        Me.fechacomienzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechacomienzo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechacomienzo.Location = New System.Drawing.Point(82, 39)
        Me.fechacomienzo.Name = "fechacomienzo"
        Me.fechacomienzo.ShowUpDown = True
        Me.fechacomienzo.Size = New System.Drawing.Size(90, 22)
        Me.fechacomienzo.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(347, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 15)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Fin:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 15)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Comienzo:"
        '
        'txtfin
        '
        Me.txtfin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfin.Location = New System.Drawing.Point(380, 40)
        Me.txtfin.Name = "txtfin"
        Me.txtfin.ReadOnly = True
        Me.txtfin.Size = New System.Drawing.Size(75, 22)
        Me.txtfin.TabIndex = 16
        Me.txtfin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtObservacion)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.lbconvencion)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txttiempototalhorario)
        Me.GroupBox3.Controls.Add(Me.txtsalir)
        Me.GroupBox3.Controls.Add(Me.txtentrar)
        Me.GroupBox3.Controls.Add(Me.txtconvencion)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 60)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(560, 105)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Horario"
        '
        'TxtObservacion
        '
        Me.TxtObservacion.BackColor = System.Drawing.SystemColors.Control
        Me.TxtObservacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservacion.Location = New System.Drawing.Point(95, 73)
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(456, 20)
        Me.TxtObservacion.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 73)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 15)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Observación:"
        '
        'lbconvencion
        '
        Me.lbconvencion.BackColor = System.Drawing.Color.Transparent
        Me.lbconvencion.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbconvencion.Location = New System.Drawing.Point(85, 23)
        Me.lbconvencion.Name = "lbconvencion"
        Me.lbconvencion.Size = New System.Drawing.Size(31, 18)
        Me.lbconvencion.TabIndex = 25
        Me.lbconvencion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtretornar)
        Me.GroupBox4.Controls.Add(Me.txtdescansar)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(235, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 61)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "  Descanso    "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(95, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 15)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Salida"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Entrada"
        '
        'txtretornar
        '
        Me.txtretornar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtretornar.Location = New System.Drawing.Point(84, 33)
        Me.txtretornar.Name = "txtretornar"
        Me.txtretornar.ReadOnly = True
        Me.txtretornar.Size = New System.Drawing.Size(70, 21)
        Me.txtretornar.TabIndex = 7
        Me.txtretornar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtdescansar
        '
        Me.txtdescansar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescansar.Location = New System.Drawing.Point(5, 33)
        Me.txtdescansar.Name = "txtdescansar"
        Me.txtdescansar.ReadOnly = True
        Me.txtdescansar.Size = New System.Drawing.Size(70, 21)
        Me.txtdescansar.TabIndex = 6
        Me.txtdescansar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(476, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Tiempo Total"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(415, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Salida"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(167, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Entrada"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Convención"
        '
        'txttiempototalhorario
        '
        Me.txttiempototalhorario.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttiempototalhorario.Location = New System.Drawing.Point(480, 41)
        Me.txttiempototalhorario.Name = "txttiempototalhorario"
        Me.txttiempototalhorario.ReadOnly = True
        Me.txttiempototalhorario.Size = New System.Drawing.Size(71, 21)
        Me.txttiempototalhorario.TabIndex = 9
        Me.txttiempototalhorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtsalir
        '
        Me.txtsalir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsalir.Location = New System.Drawing.Point(401, 41)
        Me.txtsalir.Name = "txtsalir"
        Me.txtsalir.ReadOnly = True
        Me.txtsalir.Size = New System.Drawing.Size(73, 21)
        Me.txtsalir.TabIndex = 8
        Me.txtsalir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtentrar
        '
        Me.txtentrar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtentrar.Location = New System.Drawing.Point(158, 41)
        Me.txtentrar.Name = "txtentrar"
        Me.txtentrar.ReadOnly = True
        Me.txtentrar.Size = New System.Drawing.Size(71, 21)
        Me.txtentrar.TabIndex = 5
        Me.txtentrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtconvencion
        '
        Me.txtconvencion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconvencion.Location = New System.Drawing.Point(12, 41)
        Me.txtconvencion.Name = "txtconvencion"
        Me.txtconvencion.ReadOnly = True
        Me.txtconvencion.Size = New System.Drawing.Size(140, 20)
        Me.txtconvencion.TabIndex = 4
        Me.txtconvencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtdia)
        Me.GroupBox2.Controls.Add(Me.combotipo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(560, 54)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información del Permiso"
        '
        'txtdia
        '
        Me.txtdia.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdia.Location = New System.Drawing.Point(166, 21)
        Me.txtdia.Name = "txtdia"
        Me.txtdia.ReadOnly = True
        Me.txtdia.Size = New System.Drawing.Size(177, 21)
        Me.txtdia.TabIndex = 1
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'combotipo
        '
        Me.combotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combotipo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combotipo.FormattingEnabled = True
        Me.combotipo.Location = New System.Drawing.Point(383, 19)
        Me.combotipo.Name = "combotipo"
        Me.combotipo.Size = New System.Drawing.Size(170, 23)
        Me.combotipo.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(349, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 15)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Tipo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(138, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Dia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Código:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(60, 21)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(69, 21)
        Me.txtcodigo.TabIndex = 0
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btaceptar, Me.ToolStripSeparator1, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir, Me.ToolStripSeparator11})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 325)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(598, 54)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btaceptar
        '
        Me.btaceptar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btaceptar.Image = Global.Celer.My.Resources.Resources.Badge_tick_icon
        Me.btaceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btaceptar.Name = "btaceptar"
        Me.btaceptar.Size = New System.Drawing.Size(52, 51)
        Me.btaceptar.Text = "&Aceptar"
        Me.btaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
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
        Me.btimprimir.Visible = False
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 54)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Padlock_User_Control_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "ASIGNAR PERMISO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(534, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "___________________________________________________________________________"
        '
        'Form_dia_permiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(598, 379)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 418)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 418)
        Me.Name = "Form_dia_permiso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.numtiempototalminutos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numtiempototalhoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btaceptar As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents Label10 As Label
    Public WithEvents Label9 As Label
    Public WithEvents Label6 As Label
    Public WithEvents Label4 As Label
    Public WithEvents txttiempototalhorario As TextBox
    Public WithEvents txtconvencion As TextBox
    Public WithEvents txtsalir As TextBox
    Public WithEvents txtentrar As TextBox
    Public WithEvents GroupBox5 As GroupBox
    Public WithEvents Label3 As Label
    Public WithEvents Label5 As Label
    Public WithEvents txtdia As TextBox
    Public WithEvents txtcodigo As TextBox
    Friend WithEvents rbrangotiempo As RadioButton
    Friend WithEvents rbtotal As RadioButton
    Public WithEvents GroupBox6 As GroupBox
    Public WithEvents Label12 As Label
    Public WithEvents Label11 As Label
    Public WithEvents txtfin As TextBox
    Public WithEvents GroupBox7 As GroupBox
    Friend WithEvents fechacomienzo As DateTimePicker
    Public WithEvents GroupBox4 As GroupBox
    Public WithEvents Label8 As Label
    Public WithEvents Label7 As Label
    Public WithEvents txtretornar As TextBox
    Public WithEvents txtdescansar As TextBox
    Public WithEvents Label14 As Label
    Public WithEvents Label13 As Label
    Friend WithEvents numtiempototalminutos As NumericUpDown
    Friend WithEvents numtiempototalhoras As NumericUpDown
    Friend WithEvents combotipo As ComboBox
    Public WithEvents Label15 As Label
    Public WithEvents Label16 As Label
    Public WithEvents lbconvencion As Label
    Friend WithEvents btimprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Public WithEvents TxtObservacion As TextBox
    Friend WithEvents Label17 As Label
End Class
