<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_historial_atencion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_historial_atencion))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtfecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.dtfecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbEgreso = New System.Windows.Forms.RadioButton()
        Me.rbIngreso = New System.Windows.Forms.RadioButton()
        Me.btimprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pOpciones = New System.Windows.Forms.Panel()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.botonAplicar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.arbolListtaItem = New System.Windows.Forms.TreeView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvDiag = New System.Windows.Forms.DataGridView()
        Me.Ltitulo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grillaHistorialAtencion = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ComboContrato = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboContacto = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.btopcion = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lPaciente = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LNpacientes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Lvivo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LnVivo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Lmuerto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lNMuerto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LEstancia = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lPromedioEstancia = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LnInRemision = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LnEgRemision = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btConsultar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pOpciones.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaHistorialAtencion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.History_Folder_Blue_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60007
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(940, 20)
        Me.Label2.TabIndex = 60011
        Me.Label2.Text = "_________________________________________________________________________________" &
    "____________________________________________________"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 60012
        Me.Label1.Text = "HISTORIAL DE ATENCIÓN"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btConsultar)
        Me.GroupBox1.Controls.Add(Me.dtfecha_fin)
        Me.GroupBox1.Controls.Add(Me.dtfecha_inicio)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 91)
        Me.GroupBox1.TabIndex = 60013
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'dtfecha_fin
        '
        Me.dtfecha_fin.CustomFormat = "dd/MM/yyyyy"
        Me.dtfecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtfecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfecha_fin.Location = New System.Drawing.Point(249, 18)
        Me.dtfecha_fin.Name = "dtfecha_fin"
        Me.dtfecha_fin.Size = New System.Drawing.Size(130, 21)
        Me.dtfecha_fin.TabIndex = 60019
        '
        'dtfecha_inicio
        '
        Me.dtfecha_inicio.CustomFormat = "dd/MM/yyyyy"
        Me.dtfecha_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtfecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfecha_inicio.Location = New System.Drawing.Point(67, 18)
        Me.dtfecha_inicio.Name = "dtfecha_inicio"
        Me.dtfecha_inicio.Size = New System.Drawing.Size(126, 21)
        Me.dtfecha_inicio.TabIndex = 60018
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbEgreso)
        Me.Panel1.Controls.Add(Me.rbIngreso)
        Me.Panel1.Location = New System.Drawing.Point(12, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(207, 34)
        Me.Panel1.TabIndex = 60016
        '
        'rbEgreso
        '
        Me.rbEgreso.AutoSize = True
        Me.rbEgreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbEgreso.Location = New System.Drawing.Point(132, 6)
        Me.rbEgreso.Name = "rbEgreso"
        Me.rbEgreso.Size = New System.Drawing.Size(64, 19)
        Me.rbEgreso.TabIndex = 1
        Me.rbEgreso.TabStop = True
        Me.rbEgreso.Text = "Egreso"
        Me.rbEgreso.UseVisualStyleBackColor = True
        '
        'rbIngreso
        '
        Me.rbIngreso.AutoSize = True
        Me.rbIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbIngreso.Location = New System.Drawing.Point(7, 6)
        Me.rbIngreso.Name = "rbIngreso"
        Me.rbIngreso.Size = New System.Drawing.Size(66, 19)
        Me.rbIngreso.TabIndex = 0
        Me.rbIngreso.TabStop = True
        Me.rbIngreso.Text = "Ingreso"
        Me.rbIngreso.UseVisualStyleBackColor = True
        '
        'btimprimir
        '
        Me.btimprimir.Enabled = False
        Me.btimprimir.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btimprimir.Image = Global.Celer.My.Resources.Resources.Printer_icon__1_
        Me.btimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btimprimir.Location = New System.Drawing.Point(515, 31)
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(79, 34)
        Me.btimprimir.TabIndex = 60015
        Me.btimprimir.Text = "Imprimir"
        Me.btimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btimprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(203, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 992
        Me.Label3.Text = "Hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(9, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 990
        Me.Label8.Text = "Desde:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pOpciones)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.grillaHistorialAtencion)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 404)
        Me.GroupBox2.TabIndex = 60014
        Me.GroupBox2.TabStop = False
        '
        'pOpciones
        '
        Me.pOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pOpciones.Controls.Add(Me.btCerrar)
        Me.pOpciones.Controls.Add(Me.botonAplicar)
        Me.pOpciones.Controls.Add(Me.GroupBox4)
        Me.pOpciones.Controls.Add(Me.Label10)
        Me.pOpciones.Controls.Add(Me.Label11)
        Me.pOpciones.Location = New System.Drawing.Point(341, 20)
        Me.pOpciones.Name = "pOpciones"
        Me.pOpciones.Size = New System.Drawing.Size(253, 378)
        Me.pOpciones.TabIndex = 60017
        Me.pOpciones.Visible = False
        '
        'btCerrar
        '
        Me.btCerrar.Image = Global.Celer.My.Resources.Resources.Close_2_icon
        Me.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCerrar.Location = New System.Drawing.Point(165, 342)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(80, 33)
        Me.btCerrar.TabIndex = 60019
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'botonAplicar
        '
        Me.botonAplicar.Image = Global.Celer.My.Resources.Resources.Badge_tick_icon__1_
        Me.botonAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.botonAplicar.Location = New System.Drawing.Point(6, 342)
        Me.botonAplicar.Name = "botonAplicar"
        Me.botonAplicar.Size = New System.Drawing.Size(80, 33)
        Me.botonAplicar.TabIndex = 60018
        Me.botonAplicar.Text = "Aplicar"
        Me.botonAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.botonAplicar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.arbolListtaItem)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 27)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(245, 314)
        Me.GroupBox4.TabIndex = 60016
        Me.GroupBox4.TabStop = False
        '
        'arbolListtaItem
        '
        Me.arbolListtaItem.CheckBoxes = True
        Me.arbolListtaItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.arbolListtaItem.Location = New System.Drawing.Point(3, 17)
        Me.arbolListtaItem.Name = "arbolListtaItem"
        Me.arbolListtaItem.Size = New System.Drawing.Size(239, 294)
        Me.arbolListtaItem.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 16)
        Me.Label10.TabIndex = 60015
        Me.Label10.Text = "OPCIONES"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(5, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(247, 20)
        Me.Label11.TabIndex = 60012
        Me.Label11.Text = "__________________________________"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.Ltitulo)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(261, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(453, 211)
        Me.Panel2.TabIndex = 6
        Me.Panel2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvDiag)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 29)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(445, 176)
        Me.GroupBox3.TabIndex = 60016
        Me.GroupBox3.TabStop = False
        '
        'dgvDiag
        '
        Me.dgvDiag.AllowUserToAddRows = False
        Me.dgvDiag.AllowUserToDeleteRows = False
        Me.dgvDiag.AllowUserToResizeColumns = False
        Me.dgvDiag.AllowUserToResizeRows = False
        Me.dgvDiag.BackgroundColor = System.Drawing.Color.White
        Me.dgvDiag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiag.Location = New System.Drawing.Point(3, 17)
        Me.dgvDiag.Name = "dgvDiag"
        Me.dgvDiag.ReadOnly = True
        Me.dgvDiag.RowHeadersVisible = False
        Me.dgvDiag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDiag.Size = New System.Drawing.Size(439, 156)
        Me.dgvDiag.TabIndex = 6
        '
        'Ltitulo
        '
        Me.Ltitulo.AutoSize = True
        Me.Ltitulo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ltitulo.Location = New System.Drawing.Point(7, 6)
        Me.Ltitulo.Name = "Ltitulo"
        Me.Ltitulo.Size = New System.Drawing.Size(47, 16)
        Me.Ltitulo.TabIndex = 60015
        Me.Ltitulo.Text = "TITULO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(5, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(436, 20)
        Me.Label9.TabIndex = 60012
        Me.Label9.Text = "_____________________________________________________________"
        '
        'grillaHistorialAtencion
        '
        Me.grillaHistorialAtencion.AllowUserToAddRows = False
        Me.grillaHistorialAtencion.AllowUserToDeleteRows = False
        Me.grillaHistorialAtencion.AllowUserToResizeColumns = False
        Me.grillaHistorialAtencion.AllowUserToResizeRows = False
        Me.grillaHistorialAtencion.BackgroundColor = System.Drawing.Color.White
        Me.grillaHistorialAtencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaHistorialAtencion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaHistorialAtencion.Location = New System.Drawing.Point(3, 17)
        Me.grillaHistorialAtencion.Name = "grillaHistorialAtencion"
        Me.grillaHistorialAtencion.ReadOnly = True
        Me.grillaHistorialAtencion.RowHeadersVisible = False
        Me.grillaHistorialAtencion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grillaHistorialAtencion.Size = New System.Drawing.Size(986, 384)
        Me.grillaHistorialAtencion.TabIndex = 5
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ComboContrato)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.btimprimir)
        Me.GroupBox5.Controls.Add(Me.ComboContacto)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtBusqueda)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(396, 59)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(601, 91)
        Me.GroupBox5.TabIndex = 60015
        Me.GroupBox5.TabStop = False
        '
        'ComboContrato
        '
        Me.ComboContrato.BackColor = System.Drawing.Color.White
        Me.ComboContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboContrato.FormattingEnabled = True
        Me.ComboContrato.Location = New System.Drawing.Point(330, 52)
        Me.ComboContrato.Name = "ComboContrato"
        Me.ComboContrato.Size = New System.Drawing.Size(173, 23)
        Me.ComboContrato.TabIndex = 142
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(271, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "Contrato:"
        '
        'ComboContacto
        '
        Me.ComboContacto.BackColor = System.Drawing.Color.White
        Me.ComboContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboContacto.FormattingEnabled = True
        Me.ComboContacto.Location = New System.Drawing.Point(72, 52)
        Me.ComboContacto.Name = "ComboContacto"
        Me.ComboContacto.Size = New System.Drawing.Size(179, 23)
        Me.ComboContacto.TabIndex = 140
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Contacto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(4, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Busqueda:"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(72, 19)
        Me.txtBusqueda.MaxLength = 400
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(431, 22)
        Me.txtBusqueda.TabIndex = 0
        '
        'btopcion
        '
        Me.btopcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btopcion.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btopcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btopcion.Location = New System.Drawing.Point(842, 2)
        Me.btopcion.Name = "btopcion"
        Me.btopcion.Size = New System.Drawing.Size(149, 36)
        Me.btopcion.TabIndex = 60016
        Me.btopcion.Text = "Configuraciones "
        Me.btopcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btopcion.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lPaciente, Me.LNpacientes, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel4, Me.Lvivo, Me.LnVivo, Me.ToolStripStatusLabel2, Me.Lmuerto, Me.lNMuerto, Me.ToolStripStatusLabel3, Me.LEstancia, Me.lPromedioEstancia, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.LnInRemision, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel8, Me.LnEgRemision})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 559)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1002, 22)
        Me.StatusStrip1.TabIndex = 60017
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lPaciente
        '
        Me.lPaciente.Name = "lPaciente"
        Me.lPaciente.Size = New System.Drawing.Size(60, 17)
        Me.lPaciente.Text = "Pacientes:"
        '
        'LNpacientes
        '
        Me.LNpacientes.Name = "LNpacientes"
        Me.LNpacientes.Size = New System.Drawing.Size(13, 17)
        Me.LNpacientes.Text = "0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(18, 17)
        Me.ToolStripStatusLabel1.Text = "|| "
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel4.Text = "Estado Salida:("
        '
        'Lvivo
        '
        Me.Lvivo.Name = "Lvivo"
        Me.Lvivo.Size = New System.Drawing.Size(33, 17)
        Me.Lvivo.Text = "Vivo:"
        '
        'LnVivo
        '
        Me.LnVivo.Name = "LnVivo"
        Me.LnVivo.Size = New System.Drawing.Size(13, 17)
        Me.LnVivo.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel2.Text = "-"
        '
        'Lmuerto
        '
        Me.Lmuerto.Name = "Lmuerto"
        Me.Lmuerto.Size = New System.Drawing.Size(49, 17)
        Me.Lmuerto.Text = "Muerto:"
        '
        'lNMuerto
        '
        Me.lNMuerto.Name = "lNMuerto"
        Me.lNMuerto.Size = New System.Drawing.Size(13, 17)
        Me.lNMuerto.Text = "0"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(25, 17)
        Me.ToolStripStatusLabel3.Text = ") || "
        '
        'LEstancia
        '
        Me.LEstancia.Name = "LEstancia"
        Me.LEstancia.Size = New System.Drawing.Size(124, 17)
        Me.LEstancia.Text = "Promedio de Estancia:"
        '
        'lPromedioEstancia
        '
        Me.lPromedioEstancia.Name = "lPromedioEstancia"
        Me.lPromedioEstancia.Size = New System.Drawing.Size(23, 17)
        Me.lPromedioEstancia.Text = "0%"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(15, 17)
        Me.ToolStripStatusLabel5.Text = "||"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(140, 17)
        Me.ToolStripStatusLabel6.Text = "Ingresados por Remisión:"
        '
        'LnInRemision
        '
        Me.LnInRemision.Name = "LnInRemision"
        Me.LnInRemision.Size = New System.Drawing.Size(13, 17)
        Me.LnInRemision.Text = "0"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(15, 17)
        Me.ToolStripStatusLabel7.Text = "||"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(136, 17)
        Me.ToolStripStatusLabel8.Text = "Egresados por Remisión:"
        '
        'LnEgRemision
        '
        Me.LnEgRemision.Name = "LnEgRemision"
        Me.LnEgRemision.Size = New System.Drawing.Size(13, 17)
        Me.LnEgRemision.Text = "0"
        '
        'btConsultar
        '
        Me.btConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btConsultar.Enabled = False
        Me.btConsultar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConsultar.Image = Global.Celer.My.Resources.Resources.Refresh_icon
        Me.btConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btConsultar.Location = New System.Drawing.Point(286, 51)
        Me.btConsultar.Name = "btConsultar"
        Me.btConsultar.Size = New System.Drawing.Size(93, 34)
        Me.btConsultar.TabIndex = 60018
        Me.btConsultar.Text = "Consultar"
        Me.btConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btConsultar.UseVisualStyleBackColor = True
        '
        'Form_historial_atencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1002, 581)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btopcion)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1018, 620)
        Me.MinimumSize = New System.Drawing.Size(1018, 620)
        Me.Name = "Form_historial_atencion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.pOpciones.ResumeLayout(False)
        Me.pOpciones.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvDiag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaHistorialAtencion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btimprimir As Button
    Friend WithEvents grillaHistorialAtencion As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbEgreso As RadioButton
    Friend WithEvents rbIngreso As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgvDiag As DataGridView
    Friend WithEvents Ltitulo As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pOpciones As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents arbolListtaItem As TreeView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents botonAplicar As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btopcion As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents btCerrar As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lPaciente As ToolStripStatusLabel
    Friend WithEvents LNpacientes As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Lvivo As ToolStripStatusLabel
    Friend WithEvents LnVivo As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Lmuerto As ToolStripStatusLabel
    Friend WithEvents lNMuerto As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents LEstancia As ToolStripStatusLabel
    Friend WithEvents lPromedioEstancia As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents LnInRemision As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As ToolStripStatusLabel
    Friend WithEvents LnEgRemision As ToolStripStatusLabel
    Friend WithEvents dtfecha_fin As DateTimePicker
    Friend WithEvents dtfecha_inicio As DateTimePicker
    Public WithEvents ComboContrato As ComboBox
    Public WithEvents Label6 As Label
    Public WithEvents ComboContacto As ComboBox
    Public WithEvents Label5 As Label
    Friend WithEvents btConsultar As Button
End Class
