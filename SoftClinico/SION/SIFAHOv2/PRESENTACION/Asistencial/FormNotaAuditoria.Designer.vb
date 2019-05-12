<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNotaAuditoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNotaAuditoria))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btCaptura = New System.Windows.Forms.Button()
        Me.ChRenviar = New System.Windows.Forms.CheckBox()
        Me.chRevisado = New System.Windows.Forms.CheckBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btBuscarCoordinador = New System.Windows.Forms.Button()
        Me.txtCoordinador = New System.Windows.Forms.TextBox()
        Me.btBuscarResponsable = New System.Windows.Forms.Button()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtNota = New System.Windows.Forms.RichTextBox()
        Me.menuColor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CambiarColorDeFuenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarLetraDeLaFuenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.btBuscarCargo = New System.Windows.Forms.Button()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupDatos = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCodigoNota = New System.Windows.Forms.TextBox()
        Me.txtregistro = New System.Windows.Forms.TextBox()
        Me.txtAreaServicio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcodigocontrato = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcontrato = New System.Windows.Forms.TextBox()
        Me.txtfechaingreso = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcama = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtedad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsexo = New System.Windows.Forms.TextBox()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtidentificacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btbuscarPaciente = New System.Windows.Forms.Button()
        Me.lblUsuario = New System.Windows.Forms.ToolStrip()
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
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.textUsuario = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Colores = New System.Windows.Forms.ColorDialog()
        Me.Letra = New System.Windows.Forms.FontDialog()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.menuColor.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupDatos.SuspendLayout()
        Me.lblUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "NOTA AUDITORIA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(54, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(877, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.new_message_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.btCaptura)
        Me.GroupBox1.Controls.Add(Me.ChRenviar)
        Me.GroupBox1.Controls.Add(Me.chRevisado)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 520)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(799, 260)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 15)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Añadir recorte"
        '
        'btCaptura
        '
        Me.btCaptura.BackgroundImage = Global.Celer.My.Resources.Resources.scissors_icon
        Me.btCaptura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btCaptura.Location = New System.Drawing.Point(885, 252)
        Me.btCaptura.Name = "btCaptura"
        Me.btCaptura.Size = New System.Drawing.Size(35, 30)
        Me.btCaptura.TabIndex = 83
        Me.btCaptura.UseVisualStyleBackColor = True
        '
        'ChRenviar
        '
        Me.ChRenviar.AutoSize = True
        Me.ChRenviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChRenviar.Location = New System.Drawing.Point(803, 223)
        Me.ChRenviar.Name = "ChRenviar"
        Me.ChRenviar.Size = New System.Drawing.Size(83, 19)
        Me.ChRenviar.TabIndex = 74
        Me.ChRenviar.Text = "Reenviar"
        Me.ChRenviar.UseVisualStyleBackColor = True
        Me.ChRenviar.Visible = False
        '
        'chRevisado
        '
        Me.chRevisado.AutoSize = True
        Me.chRevisado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chRevisado.ForeColor = System.Drawing.Color.Green
        Me.chRevisado.Location = New System.Drawing.Point(803, 198)
        Me.chRevisado.Name = "chRevisado"
        Me.chRevisado.Size = New System.Drawing.Size(85, 19)
        Me.chRevisado.TabIndex = 73
        Me.chRevisado.Text = "Revisado"
        Me.chRevisado.UseVisualStyleBackColor = True
        Me.chRevisado.Visible = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(6, 193)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(775, 87)
        Me.txtObservacion.TabIndex = 72
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btBuscarCoordinador)
        Me.GroupBox4.Controls.Add(Me.txtCoordinador)
        Me.GroupBox4.Controls.Add(Me.btBuscarResponsable)
        Me.GroupBox4.Controls.Add(Me.txtEmpleado)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(475, 121)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(449, 63)
        Me.GroupBox4.TabIndex = 71
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Encargados."
        '
        'btBuscarCoordinador
        '
        Me.btBuscarCoordinador.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarCoordinador.Location = New System.Drawing.Point(417, 35)
        Me.btBuscarCoordinador.Name = "btBuscarCoordinador"
        Me.btBuscarCoordinador.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarCoordinador.TabIndex = 82
        Me.btBuscarCoordinador.UseVisualStyleBackColor = True
        '
        'txtCoordinador
        '
        Me.txtCoordinador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCoordinador.Location = New System.Drawing.Point(91, 36)
        Me.txtCoordinador.Name = "txtCoordinador"
        Me.txtCoordinador.Size = New System.Drawing.Size(320, 21)
        Me.txtCoordinador.TabIndex = 81
        '
        'btBuscarResponsable
        '
        Me.btBuscarResponsable.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarResponsable.Location = New System.Drawing.Point(417, 11)
        Me.btBuscarResponsable.Name = "btBuscarResponsable"
        Me.btBuscarResponsable.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarResponsable.TabIndex = 80
        Me.btBuscarResponsable.UseVisualStyleBackColor = True
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEmpleado.Location = New System.Drawing.Point(91, 13)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(320, 21)
        Me.txtEmpleado.TabIndex = 79
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 15)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Coordinador:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 15)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Responsable:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtNota)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 283)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(918, 231)
        Me.GroupBox3.TabIndex = 71
        Me.GroupBox3.TabStop = False
        '
        'txtNota
        '
        Me.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNota.EnableAutoDragDrop = True
        Me.txtNota.Location = New System.Drawing.Point(3, 17)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(912, 211)
        Me.txtNota.TabIndex = 0
        Me.txtNota.Text = ""
        '
        'menuColor
        '
        Me.menuColor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CambiarColorDeFuenteToolStripMenuItem, Me.CambiarLetraDeLaFuenteToolStripMenuItem})
        Me.menuColor.Name = "menuColor"
        Me.menuColor.Size = New System.Drawing.Size(216, 48)
        '
        'CambiarColorDeFuenteToolStripMenuItem
        '
        Me.CambiarColorDeFuenteToolStripMenuItem.Image = Global.Celer.My.Resources.Resources.Categories_applications_graphics_icon
        Me.CambiarColorDeFuenteToolStripMenuItem.Name = "CambiarColorDeFuenteToolStripMenuItem"
        Me.CambiarColorDeFuenteToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.CambiarColorDeFuenteToolStripMenuItem.Text = "Cambiar Color de Fuente"
        '
        'CambiarLetraDeLaFuenteToolStripMenuItem
        '
        Me.CambiarLetraDeLaFuenteToolStripMenuItem.Name = "CambiarLetraDeLaFuenteToolStripMenuItem"
        Me.CambiarLetraDeLaFuenteToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.CambiarLetraDeLaFuenteToolStripMenuItem.Text = "Cambiar Letra de la Fuente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTitulo)
        Me.GroupBox2.Controls.Add(Me.btBuscarCargo)
        Me.GroupBox2.Controls.Add(Me.txtCargo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 63)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dirigido a."
        '
        'txtTitulo
        '
        Me.txtTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtTitulo.Location = New System.Drawing.Point(84, 36)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(345, 21)
        Me.txtTitulo.TabIndex = 79
        '
        'btBuscarCargo
        '
        Me.btBuscarCargo.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarCargo.Location = New System.Drawing.Point(433, 12)
        Me.btBuscarCargo.Name = "btBuscarCargo"
        Me.btBuscarCargo.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarCargo.TabIndex = 78
        Me.btBuscarCargo.UseVisualStyleBackColor = True
        '
        'txtCargo
        '
        Me.txtCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCargo.Location = New System.Drawing.Point(84, 13)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(345, 21)
        Me.txtCargo.TabIndex = 77
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 76
        Me.Label15.Text = "Titulo:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 15)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Cargo:"
        '
        'GroupDatos
        '
        Me.GroupDatos.Controls.Add(Me.Label11)
        Me.GroupDatos.Controls.Add(Me.txtCodigoNota)
        Me.GroupDatos.Controls.Add(Me.txtregistro)
        Me.GroupDatos.Controls.Add(Me.txtAreaServicio)
        Me.GroupDatos.Controls.Add(Me.Label16)
        Me.GroupDatos.Controls.Add(Me.dtfecha)
        Me.GroupDatos.Controls.Add(Me.Label5)
        Me.GroupDatos.Controls.Add(Me.txtcodigocontrato)
        Me.GroupDatos.Controls.Add(Me.Label30)
        Me.GroupDatos.Controls.Add(Me.Label10)
        Me.GroupDatos.Controls.Add(Me.txtcontrato)
        Me.GroupDatos.Controls.Add(Me.txtfechaingreso)
        Me.GroupDatos.Controls.Add(Me.Label9)
        Me.GroupDatos.Controls.Add(Me.Label8)
        Me.GroupDatos.Controls.Add(Me.txtcama)
        Me.GroupDatos.Controls.Add(Me.Label7)
        Me.GroupDatos.Controls.Add(Me.txtedad)
        Me.GroupDatos.Controls.Add(Me.Label6)
        Me.GroupDatos.Controls.Add(Me.txtsexo)
        Me.GroupDatos.Controls.Add(Me.txtpaciente)
        Me.GroupDatos.Controls.Add(Me.Label3)
        Me.GroupDatos.Controls.Add(Me.txtidentificacion)
        Me.GroupDatos.Controls.Add(Me.Label4)
        Me.GroupDatos.Controls.Add(Me.btbuscarPaciente)
        Me.GroupDatos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupDatos.Location = New System.Drawing.Point(6, 7)
        Me.GroupDatos.Name = "GroupDatos"
        Me.GroupDatos.Size = New System.Drawing.Size(918, 116)
        Me.GroupDatos.TabIndex = 37
        Me.GroupDatos.TabStop = False
        Me.GroupDatos.Text = "Informacion del Paciente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(743, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Código:"
        '
        'txtCodigoNota
        '
        Me.txtCodigoNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoNota.Location = New System.Drawing.Point(795, 90)
        Me.txtCodigoNota.Name = "txtCodigoNota"
        Me.txtCodigoNota.Size = New System.Drawing.Size(116, 21)
        Me.txtCodigoNota.TabIndex = 72
        Me.txtCodigoNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtregistro
        '
        Me.txtregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtregistro.Location = New System.Drawing.Point(772, 22)
        Me.txtregistro.Name = "txtregistro"
        Me.txtregistro.Size = New System.Drawing.Size(138, 21)
        Me.txtregistro.TabIndex = 39
        Me.txtregistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAreaServicio
        '
        Me.txtAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAreaServicio.Location = New System.Drawing.Point(85, 44)
        Me.txtAreaServicio.Name = "txtAreaServicio"
        Me.txtAreaServicio.Size = New System.Drawing.Size(132, 21)
        Me.txtAreaServicio.TabIndex = 71
        Me.txtAreaServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 15)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "Area servicio:"
        '
        'dtfecha
        '
        Me.dtfecha.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfecha.Location = New System.Drawing.Point(772, 46)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.Size = New System.Drawing.Size(138, 21)
        Me.dtfecha.TabIndex = 69
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(699, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Fecha:"
        '
        'txtcodigocontrato
        '
        Me.txtcodigocontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigocontrato.Location = New System.Drawing.Point(85, 92)
        Me.txtcodigocontrato.Name = "txtcodigocontrato"
        Me.txtcodigocontrato.Size = New System.Drawing.Size(132, 21)
        Me.txtcodigocontrato.TabIndex = 41
        Me.txtcodigocontrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(699, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 15)
        Me.Label30.TabIndex = 40
        Me.Label30.Text = "N° Registro:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Contrato:"
        '
        'txtcontrato
        '
        Me.txtcontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcontrato.Location = New System.Drawing.Point(218, 92)
        Me.txtcontrato.Name = "txtcontrato"
        Me.txtcontrato.Size = New System.Drawing.Size(515, 21)
        Me.txtcontrato.TabIndex = 35
        '
        'txtfechaingreso
        '
        Me.txtfechaingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechaingreso.Location = New System.Drawing.Point(343, 69)
        Me.txtfechaingreso.Mask = "00/00/0000 00:00"
        Me.txtfechaingreso.Name = "txtfechaingreso"
        Me.txtfechaingreso.Size = New System.Drawing.Size(102, 21)
        Me.txtfechaingreso.TabIndex = 34
        Me.txtfechaingreso.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(250, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Fecha Ingreso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(453, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Cama:"
        '
        'txtcama
        '
        Me.txtcama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcama.Location = New System.Drawing.Point(500, 46)
        Me.txtcama.Name = "txtcama"
        Me.txtcama.Size = New System.Drawing.Size(186, 21)
        Me.txtcama.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(250, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Edad:"
        '
        'txtedad
        '
        Me.txtedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtedad.Location = New System.Drawing.Point(343, 46)
        Me.txtedad.Name = "txtedad"
        Me.txtedad.Size = New System.Drawing.Size(68, 21)
        Me.txtedad.TabIndex = 29
        Me.txtedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Sexo:"
        '
        'txtsexo
        '
        Me.txtsexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtsexo.Location = New System.Drawing.Point(85, 68)
        Me.txtsexo.Name = "txtsexo"
        Me.txtsexo.Size = New System.Drawing.Size(132, 21)
        Me.txtsexo.TabIndex = 27
        Me.txtsexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(343, 22)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.Size = New System.Drawing.Size(343, 21)
        Me.txtpaciente.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Identificación:"
        '
        'txtidentificacion
        '
        Me.txtidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentificacion.Location = New System.Drawing.Point(85, 20)
        Me.txtidentificacion.Name = "txtidentificacion"
        Me.txtidentificacion.Size = New System.Drawing.Size(132, 21)
        Me.txtidentificacion.TabIndex = 21
        Me.txtidentificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(250, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Paciente:"
        '
        'btbuscarPaciente
        '
        Me.btbuscarPaciente.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarPaciente.Location = New System.Drawing.Point(206, 19)
        Me.btbuscarPaciente.Name = "btbuscarPaciente"
        Me.btbuscarPaciente.Size = New System.Drawing.Size(10, 23)
        Me.btbuscarPaciente.TabIndex = 65
        Me.btbuscarPaciente.UseVisualStyleBackColor = True
        Me.btbuscarPaciente.Visible = False
        '
        'lblUsuario
        '
        Me.lblUsuario.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblUsuario.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.lblUsuario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir, Me.textUsuario, Me.ToolStripSeparator2})
        Me.lblUsuario.Location = New System.Drawing.Point(0, 562)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(942, 54)
        Me.lblUsuario.TabIndex = 40
        Me.lblUsuario.Text = "."
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
        'textUsuario
        '
        Me.textUsuario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.textUsuario.Name = "textUsuario"
        Me.textUsuario.Size = New System.Drawing.Size(10, 51)
        Me.textUsuario.Text = "."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "codigoParametro"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 108
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Medicion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Valores Pacientes"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Valores Normales"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'FormNotaAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(942, 616)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(958, 655)
        Me.MinimumSize = New System.Drawing.Size(958, 655)
        Me.Name = "FormNotaAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.menuColor.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupDatos.ResumeLayout(False)
        Me.GroupDatos.PerformLayout()
        Me.lblUsuario.ResumeLayout(False)
        Me.lblUsuario.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupDatos As GroupBox
    Friend WithEvents txtcodigocontrato As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtregistro As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtcontrato As TextBox
    Friend WithEvents txtfechaingreso As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtcama As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtedad As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsexo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtpaciente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtidentificacion As TextBox
    Friend WithEvents btbuscarPaciente As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents dtfecha As DateTimePicker
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtNota As RichTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label12 As Label
    Public WithEvents lblUsuario As ToolStrip
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
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents Colores As ColorDialog
    Friend WithEvents menuColor As ContextMenuStrip
    Friend WithEvents CambiarColorDeFuenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambiarLetraDeLaFuenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Letra As FontDialog
    Friend WithEvents btBuscarCoordinador As Button
    Friend WithEvents txtCoordinador As TextBox
    Friend WithEvents btBuscarResponsable As Button
    Friend WithEvents txtEmpleado As TextBox
    Friend WithEvents txtTitulo As TextBox
    Friend WithEvents btBuscarCargo As Button
    Friend WithEvents txtCargo As TextBox
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents txtAreaServicio As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents textUsuario As ToolStripLabel
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents ChRenviar As CheckBox
    Friend WithEvents chRevisado As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCodigoNota As TextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btCaptura As Button
    Friend WithEvents Label17 As Label
End Class
