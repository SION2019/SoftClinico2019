<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAnexo3
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAnexo3))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
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
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btEnviarCorreos = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvanexo = New System.Windows.Forms.DataGridView()
        Me.CodigoCUPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Servicios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inicio = New Celer.DataGridViewDateTimePickerColumn()
        Me.Fin = New Celer.DataGridViewDateTimePickerColumn()
        Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANULAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.textTraslado = New System.Windows.Forms.TextBox()
        Me.btBuscarEsp = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.rdhospitalizacion = New System.Windows.Forms.RadioButton()
        Me.rdurgencia = New System.Windows.Forms.RadioButton()
        Me.drconsulta = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtjustificacion = New System.Windows.Forms.RichTextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtobservacion = New System.Windows.Forms.RichTextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdnoprioridad = New System.Windows.Forms.RadioButton()
        Me.rdprioridad = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdservicios = New System.Windows.Forms.RadioButton()
        Me.rdposterior = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoRemision = New System.Windows.Forms.TextBox()
        Me.txtCodigoArea = New System.Windows.Forms.TextBox()
        Me.fecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtregistro = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtservicio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtorden = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcontrato = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttipoinforme = New System.Windows.Forms.TextBox()
        Me.txtcontador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtidentificacion = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewDateTimePickerColumn1 = New Celer.DataGridViewDateTimePickerColumn()
        Me.DataGridViewDateTimePickerColumn2 = New Celer.DataGridViewDateTimePickerColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlUsuarioPass = New System.Windows.Forms.Panel()
        Me.btSalirPanel = New System.Windows.Forms.Button()
        Me.cmbCorreos = New System.Windows.Forms.ComboBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btLimpiar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvanexo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlUsuarioPass.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "ANEXO3: SOLICITUD DE SERVICIOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(53, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.document_compare_icon
        Me.PictureBox1.Location = New System.Drawing.Point(11, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir, Me.ToolStripSeparator2, Me.btEnviarCorreos})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 39
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'btEnviarCorreos
        '
        Me.btEnviarCorreos.Enabled = False
        Me.btEnviarCorreos.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEnviarCorreos.Image = Global.Celer.My.Resources.Resources.new_message_icon
        Me.btEnviarCorreos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEnviarCorreos.Name = "btEnviarCorreos"
        Me.btEnviarCorreos.Size = New System.Drawing.Size(43, 51)
        Me.btEnviarCorreos.Text = "&Enviar"
        Me.btEnviarCorreos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvanexo)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(903, 448)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'dgvanexo
        '
        Me.dgvanexo.AllowUserToAddRows = False
        Me.dgvanexo.AllowUserToDeleteRows = False
        Me.dgvanexo.AllowUserToResizeColumns = False
        Me.dgvanexo.AllowUserToResizeRows = False
        Me.dgvanexo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvanexo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvanexo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvanexo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvanexo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoCUPS, Me.Servicios, Me.Inicio, Me.Fin, Me.Dias, Me.ANULAR})
        Me.dgvanexo.Location = New System.Drawing.Point(6, 320)
        Me.dgvanexo.MultiSelect = False
        Me.dgvanexo.Name = "dgvanexo"
        Me.dgvanexo.RowHeadersVisible = False
        Me.dgvanexo.Size = New System.Drawing.Size(890, 122)
        Me.dgvanexo.TabIndex = 7
        '
        'CodigoCUPS
        '
        Me.CodigoCUPS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodigoCUPS.HeaderText = "Código CUPS"
        Me.CodigoCUPS.Name = "CodigoCUPS"
        '
        'Servicios
        '
        Me.Servicios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Servicios.HeaderText = "Descripción Servicio"
        Me.Servicios.Name = "Servicios"
        '
        'Inicio
        '
        Me.Inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "d"
        Me.Inicio.DefaultCellStyle = DataGridViewCellStyle1
        Me.Inicio.HeaderText = "Dia Inicial"
        Me.Inicio.Name = "Inicio"
        Me.Inicio.Width = 85
        '
        'Fin
        '
        Me.Fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        Me.Fin.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fin.HeaderText = "Dia Final"
        Me.Fin.Name = "Fin"
        Me.Fin.Width = 85
        '
        'Dias
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Dias.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dias.HeaderText = "Dias"
        Me.Dias.Name = "Dias"
        Me.Dias.ReadOnly = True
        Me.Dias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Dias.Width = 34
        '
        'ANULAR
        '
        Me.ANULAR.HeaderText = "Quitar/Anular"
        Me.ANULAR.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.ANULAR.Name = "ANULAR"
        Me.ANULAR.Width = 76
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btLimpiar)
        Me.GroupBox8.Controls.Add(Me.textTraslado)
        Me.GroupBox8.Controls.Add(Me.btBuscarEsp)
        Me.GroupBox8.Controls.Add(Me.Label28)
        Me.GroupBox8.Controls.Add(Me.rdhospitalizacion)
        Me.GroupBox8.Controls.Add(Me.rdurgencia)
        Me.GroupBox8.Controls.Add(Me.drconsulta)
        Me.GroupBox8.Location = New System.Drawing.Point(328, 95)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(569, 38)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        '
        'textTraslado
        '
        Me.textTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.textTraslado.Location = New System.Drawing.Point(361, 13)
        Me.textTraslado.Name = "textTraslado"
        Me.textTraslado.ReadOnly = True
        Me.textTraslado.Size = New System.Drawing.Size(172, 20)
        Me.textTraslado.TabIndex = 60021
        '
        'btBuscarEsp
        '
        Me.btBuscarEsp.Enabled = False
        Me.btBuscarEsp.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarEsp.Location = New System.Drawing.Point(535, 11)
        Me.btBuscarEsp.Name = "btBuscarEsp"
        Me.btBuscarEsp.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarEsp.TabIndex = 60020
        Me.btBuscarEsp.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(283, 15)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 15)
        Me.Label28.TabIndex = 60008
        Me.Label28.Text = "Trasladar A:"
        '
        'rdhospitalizacion
        '
        Me.rdhospitalizacion.AutoSize = True
        Me.rdhospitalizacion.Checked = True
        Me.rdhospitalizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdhospitalizacion.Location = New System.Drawing.Point(6, 13)
        Me.rdhospitalizacion.Name = "rdhospitalizacion"
        Me.rdhospitalizacion.Size = New System.Drawing.Size(109, 19)
        Me.rdhospitalizacion.TabIndex = 4
        Me.rdhospitalizacion.TabStop = True
        Me.rdhospitalizacion.Text = "Hospitalización"
        Me.rdhospitalizacion.UseVisualStyleBackColor = True
        '
        'rdurgencia
        '
        Me.rdurgencia.AutoSize = True
        Me.rdurgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdurgencia.Location = New System.Drawing.Point(117, 13)
        Me.rdurgencia.Name = "rdurgencia"
        Me.rdurgencia.Size = New System.Drawing.Size(75, 19)
        Me.rdurgencia.TabIndex = 3
        Me.rdurgencia.Text = "Urgencia"
        Me.rdurgencia.UseVisualStyleBackColor = True
        '
        'drconsulta
        '
        Me.drconsulta.AutoSize = True
        Me.drconsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.drconsulta.Location = New System.Drawing.Point(195, 13)
        Me.drconsulta.Name = "drconsulta"
        Me.drconsulta.Size = New System.Drawing.Size(81, 19)
        Me.drconsulta.TabIndex = 2
        Me.drconsulta.Text = "C. Externa"
        Me.drconsulta.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtjustificacion)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(6, 196)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(890, 118)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Justificación Clínica"
        '
        'txtjustificacion
        '
        Me.txtjustificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtjustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtjustificacion.Location = New System.Drawing.Point(3, 17)
        Me.txtjustificacion.Name = "txtjustificacion"
        Me.txtjustificacion.Size = New System.Drawing.Size(884, 98)
        Me.txtjustificacion.TabIndex = 0
        Me.txtjustificacion.Text = ""
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtobservacion)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(6, 135)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(890, 58)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Manejo integral segun dia"
        '
        'txtobservacion
        '
        Me.txtobservacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtobservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtobservacion.Location = New System.Drawing.Point(3, 17)
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(884, 38)
        Me.txtobservacion.TabIndex = 0
        Me.txtobservacion.Text = ""
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdnoprioridad)
        Me.GroupBox5.Controls.Add(Me.rdprioridad)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(207, 95)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(117, 38)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Atención Prioritaria"
        '
        'rdnoprioridad
        '
        Me.rdnoprioridad.AutoSize = True
        Me.rdnoprioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdnoprioridad.Location = New System.Drawing.Point(62, 14)
        Me.rdnoprioridad.Name = "rdnoprioridad"
        Me.rdnoprioridad.Size = New System.Drawing.Size(43, 19)
        Me.rdnoprioridad.TabIndex = 1
        Me.rdnoprioridad.Text = "NO"
        Me.rdnoprioridad.UseVisualStyleBackColor = True
        '
        'rdprioridad
        '
        Me.rdprioridad.AutoSize = True
        Me.rdprioridad.Checked = True
        Me.rdprioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdprioridad.Location = New System.Drawing.Point(11, 14)
        Me.rdprioridad.Name = "rdprioridad"
        Me.rdprioridad.Size = New System.Drawing.Size(36, 19)
        Me.rdprioridad.TabIndex = 0
        Me.rdprioridad.TabStop = True
        Me.rdprioridad.Text = "SI"
        Me.rdprioridad.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdservicios)
        Me.GroupBox3.Controls.Add(Me.rdposterior)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 95)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(197, 38)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Servicio Solicitado"
        '
        'rdservicios
        '
        Me.rdservicios.AutoSize = True
        Me.rdservicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdservicios.Location = New System.Drawing.Point(88, 14)
        Me.rdservicios.Name = "rdservicios"
        Me.rdservicios.Size = New System.Drawing.Size(103, 19)
        Me.rdservicios.TabIndex = 1
        Me.rdservicios.Text = "Serv. Electivos"
        Me.rdservicios.UseVisualStyleBackColor = True
        '
        'rdposterior
        '
        Me.rdposterior.AutoSize = True
        Me.rdposterior.Checked = True
        Me.rdposterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rdposterior.Location = New System.Drawing.Point(7, 14)
        Me.rdposterior.Name = "rdposterior"
        Me.rdposterior.Size = New System.Drawing.Size(74, 19)
        Me.rdposterior.TabIndex = 0
        Me.rdposterior.TabStop = True
        Me.rdposterior.Text = "Posterior"
        Me.rdposterior.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoRemision)
        Me.GroupBox2.Controls.Add(Me.txtCodigoArea)
        Me.GroupBox2.Controls.Add(Me.fecha)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtregistro)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtservicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtorden)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtcontrato)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtpaciente)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txttipoinforme)
        Me.GroupBox2.Controls.Add(Me.txtcontador)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtidentificacion)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(890, 83)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Básicos"
        '
        'txtCodigoRemision
        '
        Me.txtCodigoRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoRemision.Location = New System.Drawing.Point(591, 59)
        Me.txtCodigoRemision.Name = "txtCodigoRemision"
        Me.txtCodigoRemision.ReadOnly = True
        Me.txtCodigoRemision.Size = New System.Drawing.Size(15, 21)
        Me.txtCodigoRemision.TabIndex = 60009
        Me.txtCodigoRemision.Visible = False
        '
        'txtCodigoArea
        '
        Me.txtCodigoArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoArea.Location = New System.Drawing.Point(574, 59)
        Me.txtCodigoArea.Name = "txtCodigoArea"
        Me.txtCodigoArea.ReadOnly = True
        Me.txtCodigoArea.Size = New System.Drawing.Size(15, 21)
        Me.txtCodigoArea.TabIndex = 41
        Me.txtCodigoArea.Visible = False
        '
        'fecha
        '
        Me.fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.fecha.Location = New System.Drawing.Point(130, 36)
        Me.fecha.Mask = "00/00/0000"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Size = New System.Drawing.Size(136, 21)
        Me.fecha.TabIndex = 42
        Me.fecha.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(327, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 15)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Registro:"
        '
        'txtregistro
        '
        Me.txtregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtregistro.Location = New System.Drawing.Point(385, 58)
        Me.txtregistro.Name = "txtregistro"
        Me.txtregistro.ReadOnly = True
        Me.txtregistro.Size = New System.Drawing.Size(150, 21)
        Me.txtregistro.TabIndex = 40
        Me.txtregistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(712, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Orden:"
        '
        'txtservicio
        '
        Me.txtservicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtservicio.Location = New System.Drawing.Point(705, 58)
        Me.txtservicio.Name = "txtservicio"
        Me.txtservicio.ReadOnly = True
        Me.txtservicio.Size = New System.Drawing.Size(175, 21)
        Me.txtservicio.TabIndex = 32
        Me.txtservicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(610, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 15)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Servicio Actual:"
        '
        'txtorden
        '
        Me.txtorden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtorden.Location = New System.Drawing.Point(762, 13)
        Me.txtorden.Name = "txtorden"
        Me.txtorden.ReadOnly = True
        Me.txtorden.Size = New System.Drawing.Size(118, 21)
        Me.txtorden.TabIndex = 38
        Me.txtorden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(327, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Contrato:"
        '
        'txtcontrato
        '
        Me.txtcontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcontrato.Location = New System.Drawing.Point(385, 35)
        Me.txtcontrato.Name = "txtcontrato"
        Me.txtcontrato.ReadOnly = True
        Me.txtcontrato.Size = New System.Drawing.Size(495, 21)
        Me.txtcontrato.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(325, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Paciente:"
        '
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(385, 13)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.ReadOnly = True
        Me.txtpaciente.Size = New System.Drawing.Size(321, 21)
        Me.txtpaciente.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Tipo informe anexo:"
        '
        'txttipoinforme
        '
        Me.txttipoinforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txttipoinforme.Location = New System.Drawing.Point(130, 58)
        Me.txttipoinforme.Name = "txttipoinforme"
        Me.txttipoinforme.ReadOnly = True
        Me.txttipoinforme.Size = New System.Drawing.Size(190, 21)
        Me.txttipoinforme.TabIndex = 32
        Me.txttipoinforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcontador
        '
        Me.txtcontador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcontador.Location = New System.Drawing.Point(274, 36)
        Me.txtcontador.Name = "txtcontador"
        Me.txtcontador.ReadOnly = True
        Me.txtcontador.Size = New System.Drawing.Size(46, 21)
        Me.txtcontador.TabIndex = 31
        Me.txtcontador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 15)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Número de solicitud:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Identificación:"
        '
        'txtidentificacion
        '
        Me.txtidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentificacion.Location = New System.Drawing.Point(130, 13)
        Me.txtidentificacion.Name = "txtidentificacion"
        Me.txtidentificacion.ReadOnly = True
        Me.txtidentificacion.Size = New System.Drawing.Size(136, 21)
        Me.txtidentificacion.TabIndex = 27
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código CUPS"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 89
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción Servicio"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 480
        '
        'DataGridViewDateTimePickerColumn1
        '
        Me.DataGridViewDateTimePickerColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewDateTimePickerColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewDateTimePickerColumn1.HeaderText = "Dia Inicial"
        Me.DataGridViewDateTimePickerColumn1.Name = "DataGridViewDateTimePickerColumn1"
        Me.DataGridViewDateTimePickerColumn1.Width = 85
        '
        'DataGridViewDateTimePickerColumn2
        '
        Me.DataGridViewDateTimePickerColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewDateTimePickerColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewDateTimePickerColumn2.HeaderText = "Dia Final"
        Me.DataGridViewDateTimePickerColumn2.Name = "DataGridViewDateTimePickerColumn2"
        Me.DataGridViewDateTimePickerColumn2.Width = 85
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dias"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 34
        '
        'pnlUsuarioPass
        '
        Me.pnlUsuarioPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUsuarioPass.Controls.Add(Me.btSalirPanel)
        Me.pnlUsuarioPass.Controls.Add(Me.cmbCorreos)
        Me.pnlUsuarioPass.Controls.Add(Me.btnEnviar)
        Me.pnlUsuarioPass.Controls.Add(Me.Label11)
        Me.pnlUsuarioPass.Location = New System.Drawing.Point(155, 259)
        Me.pnlUsuarioPass.Name = "pnlUsuarioPass"
        Me.pnlUsuarioPass.Size = New System.Drawing.Size(616, 38)
        Me.pnlUsuarioPass.TabIndex = 41
        Me.pnlUsuarioPass.Visible = False
        '
        'btSalirPanel
        '
        Me.btSalirPanel.Location = New System.Drawing.Point(526, 7)
        Me.btSalirPanel.Name = "btSalirPanel"
        Me.btSalirPanel.Size = New System.Drawing.Size(75, 23)
        Me.btSalirPanel.TabIndex = 40
        Me.btSalirPanel.Text = "Salir"
        Me.btSalirPanel.UseVisualStyleBackColor = True
        '
        'cmbCorreos
        '
        Me.cmbCorreos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorreos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCorreos.FormattingEnabled = True
        Me.cmbCorreos.Location = New System.Drawing.Point(65, 7)
        Me.cmbCorreos.Name = "cmbCorreos"
        Me.cmbCorreos.Size = New System.Drawing.Size(374, 23)
        Me.cmbCorreos.TabIndex = 39
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(445, 7)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 38
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 15)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Correos: "
        '
        'btLimpiar
        '
        Me.btLimpiar.Enabled = False
        Me.btLimpiar.Image = Global.Celer.My.Resources.Resources.sign_error_icon
        Me.btLimpiar.Location = New System.Drawing.Point(508, 11)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(25, 23)
        Me.btLimpiar.TabIndex = 60022
        Me.btLimpiar.UseVisualStyleBackColor = True
        Me.btLimpiar.Visible = False
        '
        'FormAnexo3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.pnlUsuarioPass)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormAnexo3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvanexo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlUsuarioPass.ResumeLayout(False)
        Me.pnlUsuarioPass.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
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
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox5 As GroupBox
    Public WithEvents rdnoprioridad As RadioButton
    Public WithEvents rdprioridad As RadioButton
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents rdservicios As RadioButton
    Public WithEvents rdposterior As RadioButton
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label9 As Label
    Public WithEvents txtregistro As TextBox
    Public WithEvents Label8 As Label
    Public WithEvents txtorden As TextBox
    Public WithEvents Label7 As Label
    Public WithEvents txtcontrato As TextBox
    Public WithEvents Label5 As Label
    Public WithEvents txtpaciente As TextBox
    Public WithEvents Label4 As Label
    Public WithEvents txttipoinforme As TextBox
    Public WithEvents txtcontador As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents Label6 As Label
    Public WithEvents txtidentificacion As TextBox
    Public WithEvents GroupBox7 As GroupBox
    Public WithEvents txtjustificacion As RichTextBox
    Public WithEvents GroupBox6 As GroupBox
    Public WithEvents txtobservacion As RichTextBox
    Public WithEvents GroupBox8 As GroupBox
    Public WithEvents txtservicio As TextBox
    Public WithEvents Label10 As Label
    Public WithEvents rdhospitalizacion As RadioButton
    Public WithEvents rdurgencia As RadioButton
    Public WithEvents drconsulta As RadioButton
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents fecha As MaskedTextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDateTimePickerColumn1 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewDateTimePickerColumn2 As DataGridViewDateTimePickerColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Public WithEvents Label28 As Label
    Public WithEvents txtCodigoArea As TextBox
    Public WithEvents txtCodigoRemision As TextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents btEnviarCorreos As ToolStripButton
    Public WithEvents dgvanexo As DataGridView
    Friend WithEvents CodigoCUPS As DataGridViewTextBoxColumn
    Friend WithEvents Servicios As DataGridViewTextBoxColumn
    Friend WithEvents Inicio As DataGridViewDateTimePickerColumn
    Friend WithEvents Fin As DataGridViewDateTimePickerColumn
    Friend WithEvents Dias As DataGridViewTextBoxColumn
    Friend WithEvents ANULAR As DataGridViewImageColumn
    Friend WithEvents pnlUsuarioPass As Panel
    Friend WithEvents btSalirPanel As Button
    Friend WithEvents cmbCorreos As ComboBox
    Friend WithEvents btnEnviar As Button
    Public WithEvents Label11 As Label
    Public WithEvents textTraslado As TextBox
    Public WithEvents btBuscarEsp As Button
    Public WithEvents btLimpiar As Button
End Class
