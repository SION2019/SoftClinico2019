<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInterconsulta
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.lresponsable = New System.Windows.Forms.ToolStripLabel()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNombreUsuarioInforme = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.dtfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grupoRespuesta = New System.Windows.Forms.GroupBox()
        Me.txtRespuesta = New System.Windows.Forms.TextBox()
        Me.grupoMotivo = New System.Windows.Forms.GroupBox()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.GroupBoxInfoInterconsulta = New System.Windows.Forms.GroupBox()
        Me.txtInterconsultado = New System.Windows.Forms.TextBox()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.txtInterconsultante = New System.Windows.Forms.TextBox()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.GroupDatos = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigoOrden = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtregistro = New System.Windows.Forms.TextBox()
        Me.txtfechaingreso = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAreaServicio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtedad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grupoRespuesta.SuspendLayout()
        Me.grupoMotivo.SuspendLayout()
        Me.GroupBoxInfoInterconsulta.SuspendLayout()
        Me.GroupDatos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.bteditar, Me.ToolStripSeparator4, Me.btguardar, Me.ToolStripSeparator5, Me.btbuscar, Me.ToolStripSeparator3, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.lresponsable, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(942, 54)
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
        Me.btnuevo.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        Me.ToolStripSeparator1.Visible = False
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
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
        Me.btbuscar.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        Me.ToolStripSeparator3.Visible = False
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
        'lresponsable
        '
        Me.lresponsable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lresponsable.Name = "lresponsable"
        Me.lresponsable.Size = New System.Drawing.Size(10, 51)
        Me.lresponsable.Text = "."
        Me.lresponsable.Visible = False
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNombreUsuarioInforme)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.dtfecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.grupoRespuesta)
        Me.GroupBox1.Controls.Add(Me.grupoMotivo)
        Me.GroupBox1.Controls.Add(Me.GroupBoxInfoInterconsulta)
        Me.GroupBox1.Controls.Add(Me.GroupDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(929, 448)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'txtNombreUsuarioInforme
        '
        Me.txtNombreUsuarioInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtNombreUsuarioInforme.Location = New System.Drawing.Point(310, 93)
        Me.txtNombreUsuarioInforme.Name = "txtNombreUsuarioInforme"
        Me.txtNombreUsuarioInforme.Size = New System.Drawing.Size(414, 21)
        Me.txtNombreUsuarioInforme.TabIndex = 10088
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(731, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 10087
        Me.Label3.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(793, 93)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(122, 21)
        Me.txtCodigo.TabIndex = 10086
        '
        'dtfecha
        '
        Me.dtfecha.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfecha.Location = New System.Drawing.Point(92, 91)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.Size = New System.Drawing.Size(143, 21)
        Me.dtfecha.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Fecha:"
        '
        'grupoRespuesta
        '
        Me.grupoRespuesta.Controls.Add(Me.txtRespuesta)
        Me.grupoRespuesta.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoRespuesta.ForeColor = System.Drawing.Color.Black
        Me.grupoRespuesta.Location = New System.Drawing.Point(6, 272)
        Me.grupoRespuesta.Name = "grupoRespuesta"
        Me.grupoRespuesta.Size = New System.Drawing.Size(917, 169)
        Me.grupoRespuesta.TabIndex = 10085
        Me.grupoRespuesta.TabStop = False
        Me.grupoRespuesta.Text = "Respuesta de la Interconsulta:"
        '
        'txtRespuesta
        '
        Me.txtRespuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRespuesta.Location = New System.Drawing.Point(6, 22)
        Me.txtRespuesta.Multiline = True
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.ReadOnly = True
        Me.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRespuesta.Size = New System.Drawing.Size(904, 141)
        Me.txtRespuesta.TabIndex = 10064
        '
        'grupoMotivo
        '
        Me.grupoMotivo.Controls.Add(Me.txtMotivo)
        Me.grupoMotivo.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoMotivo.ForeColor = System.Drawing.Color.Black
        Me.grupoMotivo.Location = New System.Drawing.Point(6, 168)
        Me.grupoMotivo.Name = "grupoMotivo"
        Me.grupoMotivo.Size = New System.Drawing.Size(917, 102)
        Me.grupoMotivo.TabIndex = 10084
        Me.grupoMotivo.TabStop = False
        Me.grupoMotivo.Text = "Motivo de la Interconsulta:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(6, 20)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ReadOnly = True
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivo.Size = New System.Drawing.Size(904, 76)
        Me.txtMotivo.TabIndex = 10064
        '
        'GroupBoxInfoInterconsulta
        '
        Me.GroupBoxInfoInterconsulta.Controls.Add(Me.txtInterconsultado)
        Me.GroupBoxInfoInterconsulta.Controls.Add(Me.Label118)
        Me.GroupBoxInfoInterconsulta.Controls.Add(Me.txtInterconsultante)
        Me.GroupBoxInfoInterconsulta.Controls.Add(Me.Label124)
        Me.GroupBoxInfoInterconsulta.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxInfoInterconsulta.ForeColor = System.Drawing.Color.Black
        Me.GroupBoxInfoInterconsulta.Location = New System.Drawing.Point(6, 113)
        Me.GroupBoxInfoInterconsulta.Name = "GroupBoxInfoInterconsulta"
        Me.GroupBoxInfoInterconsulta.Size = New System.Drawing.Size(917, 51)
        Me.GroupBoxInfoInterconsulta.TabIndex = 10083
        Me.GroupBoxInfoInterconsulta.TabStop = False
        Me.GroupBoxInfoInterconsulta.Text = "Información:"
        '
        'txtInterconsultado
        '
        Me.txtInterconsultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterconsultado.Location = New System.Drawing.Point(508, 22)
        Me.txtInterconsultado.Name = "txtInterconsultado"
        Me.txtInterconsultado.ReadOnly = True
        Me.txtInterconsultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInterconsultado.Size = New System.Drawing.Size(402, 21)
        Me.txtInterconsultado.TabIndex = 10073
        Me.txtInterconsultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label118.Location = New System.Drawing.Point(449, 25)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(56, 15)
        Me.Label118.TabIndex = 10072
        Me.Label118.Text = "Servicio :"
        '
        'txtInterconsultante
        '
        Me.txtInterconsultante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterconsultante.Location = New System.Drawing.Point(162, 22)
        Me.txtInterconsultante.Name = "txtInterconsultante"
        Me.txtInterconsultante.ReadOnly = True
        Me.txtInterconsultante.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInterconsultante.Size = New System.Drawing.Size(276, 21)
        Me.txtInterconsultante.TabIndex = 10062
        Me.txtInterconsultante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label124
        '
        Me.Label124.AutoSize = True
        Me.Label124.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label124.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label124.Location = New System.Drawing.Point(10, 25)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(143, 15)
        Me.Label124.TabIndex = 10057
        Me.Label124.Text = "Servicio Interconsultante:"
        '
        'GroupDatos
        '
        Me.GroupDatos.Controls.Add(Me.Label6)
        Me.GroupDatos.Controls.Add(Me.txtCodigoOrden)
        Me.GroupDatos.Controls.Add(Me.Label30)
        Me.GroupDatos.Controls.Add(Me.txtregistro)
        Me.GroupDatos.Controls.Add(Me.txtfechaingreso)
        Me.GroupDatos.Controls.Add(Me.Label9)
        Me.GroupDatos.Controls.Add(Me.txtAreaServicio)
        Me.GroupDatos.Controls.Add(Me.Label7)
        Me.GroupDatos.Controls.Add(Me.txtedad)
        Me.GroupDatos.Controls.Add(Me.Label4)
        Me.GroupDatos.Controls.Add(Me.txtpaciente)
        Me.GroupDatos.Controls.Add(Me.Label8)
        Me.GroupDatos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupDatos.Location = New System.Drawing.Point(6, 7)
        Me.GroupDatos.Name = "GroupDatos"
        Me.GroupDatos.Size = New System.Drawing.Size(917, 80)
        Me.GroupDatos.TabIndex = 37
        Me.GroupDatos.TabStop = False
        Me.GroupDatos.Text = "Informacion del Paciente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(701, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 15)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Codigo Orden:"
        '
        'txtCodigoOrden
        '
        Me.txtCodigoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoOrden.Location = New System.Drawing.Point(787, 47)
        Me.txtCodigoOrden.Name = "txtCodigoOrden"
        Me.txtCodigoOrden.Size = New System.Drawing.Size(85, 21)
        Me.txtCodigoOrden.TabIndex = 41
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 15)
        Me.Label30.TabIndex = 40
        Me.Label30.Text = "N° Registro:"
        '
        'txtregistro
        '
        Me.txtregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtregistro.Location = New System.Drawing.Point(86, 21)
        Me.txtregistro.Name = "txtregistro"
        Me.txtregistro.Size = New System.Drawing.Size(128, 21)
        Me.txtregistro.TabIndex = 39
        '
        'txtfechaingreso
        '
        Me.txtfechaingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechaingreso.Location = New System.Drawing.Point(304, 47)
        Me.txtfechaingreso.Mask = "00/00/0000 00:00"
        Me.txtfechaingreso.Name = "txtfechaingreso"
        Me.txtfechaingreso.Size = New System.Drawing.Size(143, 21)
        Me.txtfechaingreso.TabIndex = 34
        Me.txtfechaingreso.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(223, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Fecha Orden:"
        '
        'txtAreaServicio
        '
        Me.txtAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAreaServicio.Location = New System.Drawing.Point(86, 47)
        Me.txtAreaServicio.Name = "txtAreaServicio"
        Me.txtAreaServicio.Size = New System.Drawing.Size(128, 21)
        Me.txtAreaServicio.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(724, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Edad:"
        '
        'txtedad
        '
        Me.txtedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtedad.Location = New System.Drawing.Point(787, 20)
        Me.txtedad.Name = "txtedad"
        Me.txtedad.Size = New System.Drawing.Size(85, 21)
        Me.txtedad.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(223, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Paciente:"
        '
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(304, 21)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.Size = New System.Drawing.Size(414, 21)
        Me.txtpaciente.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Area Servicio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "INTERCONSULTA"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.surgeon_icon1
        Me.PictureBox1.Location = New System.Drawing.Point(13, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(55, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(842, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "_________________________________________________________________________________" &
    "______________________________________"
        '
        'FormInterconsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(942, 556)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(958, 595)
        Me.MinimumSize = New System.Drawing.Size(958, 595)
        Me.Name = "FormInterconsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grupoRespuesta.ResumeLayout(False)
        Me.grupoRespuesta.PerformLayout()
        Me.grupoMotivo.ResumeLayout(False)
        Me.grupoMotivo.PerformLayout()
        Me.GroupBoxInfoInterconsulta.ResumeLayout(False)
        Me.GroupBoxInfoInterconsulta.PerformLayout()
        Me.GroupDatos.ResumeLayout(False)
        Me.GroupDatos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btguardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btbuscar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents bteditar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btcancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btanular As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents lresponsable As ToolStripLabel
    Friend WithEvents btimprimir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupDatos As GroupBox
    Friend WithEvents dtfecha As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtregistro As TextBox
    Friend WithEvents txtfechaingreso As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtedad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtpaciente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents grupoRespuesta As GroupBox
    Friend WithEvents txtRespuesta As TextBox
    Friend WithEvents grupoMotivo As GroupBox
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents GroupBoxInfoInterconsulta As GroupBox
    Friend WithEvents txtInterconsultado As TextBox
    Friend WithEvents Label118 As Label
    Friend WithEvents txtInterconsultante As TextBox
    Friend WithEvents Label124 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAreaServicio As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCodigoOrden As TextBox
    Friend WithEvents txtNombreUsuarioInforme As TextBox
End Class
