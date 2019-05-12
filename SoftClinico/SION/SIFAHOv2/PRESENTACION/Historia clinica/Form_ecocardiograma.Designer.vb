<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ecocardiograma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ecocardiograma))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupOtrosD = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCodigoOrden = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txtjustificacion = New System.Windows.Forms.TextBox()
        Me.Txtexamen = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvparametros = New System.Windows.Forms.DataGridView()
        Me.Textventana = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Rtdescripcion = New System.Windows.Forms.RichTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Rtconclusiones = New System.Windows.Forms.RichTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupDatos = New System.Windows.Forms.GroupBox()
        Me.dtfecha = New System.Windows.Forms.DateTimePicker()
        Me.lblentorno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btbuscarPaciente = New System.Windows.Forms.Button()
        Me.txtcodigocontrato = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtregistro = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpaciente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtidentificacion = New System.Windows.Forms.TextBox()
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
        Me.lresponsable = New System.Windows.Forms.ToolStripLabel()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.componente = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgmedicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvalorespPacientes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvaloresNormales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupOtrosD.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvparametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupDatos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "ECOCARDIOGRAMA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(877, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.heart_beat_no_sh_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupOtrosD)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.GroupDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(918, 448)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'GroupOtrosD
        '
        Me.GroupOtrosD.Controls.Add(Me.Label15)
        Me.GroupOtrosD.Controls.Add(Me.txtCodigoOrden)
        Me.GroupOtrosD.Controls.Add(Me.Label16)
        Me.GroupOtrosD.Controls.Add(Me.Txtjustificacion)
        Me.GroupOtrosD.Controls.Add(Me.Txtexamen)
        Me.GroupOtrosD.Controls.Add(Me.Label13)
        Me.GroupOtrosD.Location = New System.Drawing.Point(11, 116)
        Me.GroupOtrosD.Name = "GroupOtrosD"
        Me.GroupOtrosD.Size = New System.Drawing.Size(896, 77)
        Me.GroupOtrosD.TabIndex = 70
        Me.GroupOtrosD.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 15)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Codigo Orden:"
        '
        'txtCodigoOrden
        '
        Me.txtCodigoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoOrden.Location = New System.Drawing.Point(158, 12)
        Me.txtCodigoOrden.Name = "txtCodigoOrden"
        Me.txtCodigoOrden.Size = New System.Drawing.Size(78, 21)
        Me.txtCodigoOrden.TabIndex = 68
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(264, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 15)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Examen:"
        '
        'Txtjustificacion
        '
        Me.Txtjustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Txtjustificacion.Location = New System.Drawing.Point(158, 36)
        Me.Txtjustificacion.Multiline = True
        Me.Txtjustificacion.Name = "Txtjustificacion"
        Me.Txtjustificacion.Size = New System.Drawing.Size(731, 35)
        Me.Txtjustificacion.TabIndex = 68
        '
        'Txtexamen
        '
        Me.Txtexamen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Txtexamen.Location = New System.Drawing.Point(323, 12)
        Me.Txtexamen.Name = "Txtexamen"
        Me.Txtexamen.Size = New System.Drawing.Size(566, 21)
        Me.Txtexamen.TabIndex = 44
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(146, 15)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Justificacion del Examen:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 197)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(896, 245)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.dgvparametros)
        Me.TabPage1.Controls.Add(Me.Textventana)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(888, 219)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parametros"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 15)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Ventana Acustica:"
        '
        'dgvparametros
        '
        Me.dgvparametros.AllowUserToAddRows = False
        Me.dgvparametros.AllowUserToDeleteRows = False
        Me.dgvparametros.AllowUserToResizeColumns = False
        Me.dgvparametros.AllowUserToResizeRows = False
        Me.dgvparametros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvparametros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvparametros.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvparametros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvparametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvparametros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcodigo, Me.dgmedicion, Me.dgvalorespPacientes, Me.dgvaloresNormales})
        Me.dgvparametros.Location = New System.Drawing.Point(6, 32)
        Me.dgvparametros.MultiSelect = False
        Me.dgvparametros.Name = "dgvparametros"
        Me.dgvparametros.RowHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.dgvparametros.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvparametros.Size = New System.Drawing.Size(873, 181)
        Me.dgvparametros.TabIndex = 4
        '
        'Textventana
        '
        Me.Textventana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Textventana.Location = New System.Drawing.Point(113, 5)
        Me.Textventana.Name = "Textventana"
        Me.Textventana.Size = New System.Drawing.Size(527, 21)
        Me.Textventana.TabIndex = 42
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Rtdescripcion)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(888, 219)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Descripciones de Hallazgos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Rtdescripcion
        '
        Me.Rtdescripcion.BackColor = System.Drawing.SystemColors.Control
        Me.Rtdescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rtdescripcion.Location = New System.Drawing.Point(3, 3)
        Me.Rtdescripcion.Name = "Rtdescripcion"
        Me.Rtdescripcion.Size = New System.Drawing.Size(882, 213)
        Me.Rtdescripcion.TabIndex = 70
        Me.Rtdescripcion.Text = ""
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Rtconclusiones)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(888, 219)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Conclusiones"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Rtconclusiones
        '
        Me.Rtconclusiones.BackColor = System.Drawing.SystemColors.Control
        Me.Rtconclusiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rtconclusiones.Location = New System.Drawing.Point(0, 0)
        Me.Rtconclusiones.Name = "Rtconclusiones"
        Me.Rtconclusiones.Size = New System.Drawing.Size(888, 219)
        Me.Rtconclusiones.TabIndex = 71
        Me.Rtconclusiones.Text = ""
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(888, 219)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Informe/Imagen"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupDatos
        '
        Me.GroupDatos.Controls.Add(Me.dtfecha)
        Me.GroupDatos.Controls.Add(Me.lblentorno)
        Me.GroupDatos.Controls.Add(Me.Label5)
        Me.GroupDatos.Controls.Add(Me.btbuscarPaciente)
        Me.GroupDatos.Controls.Add(Me.txtcodigocontrato)
        Me.GroupDatos.Controls.Add(Me.Label30)
        Me.GroupDatos.Controls.Add(Me.txtregistro)
        Me.GroupDatos.Controls.Add(Me.Label11)
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
        Me.GroupDatos.Controls.Add(Me.Label4)
        Me.GroupDatos.Controls.Add(Me.txtpaciente)
        Me.GroupDatos.Controls.Add(Me.Label3)
        Me.GroupDatos.Controls.Add(Me.txtidentificacion)
        Me.GroupDatos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupDatos.Location = New System.Drawing.Point(11, 10)
        Me.GroupDatos.Name = "GroupDatos"
        Me.GroupDatos.Size = New System.Drawing.Size(896, 103)
        Me.GroupDatos.TabIndex = 37
        Me.GroupDatos.TabStop = False
        Me.GroupDatos.Text = "Informacion del Paciente"
        '
        'dtfecha
        '
        Me.dtfecha.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfecha.Location = New System.Drawing.Point(751, 21)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.Size = New System.Drawing.Size(138, 21)
        Me.dtfecha.TabIndex = 69
        '
        'lblentorno
        '
        Me.lblentorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblentorno.Location = New System.Drawing.Point(751, 47)
        Me.lblentorno.Name = "lblentorno"
        Me.lblentorno.Size = New System.Drawing.Size(138, 21)
        Me.lblentorno.TabIndex = 68
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(676, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Fecha:"
        '
        'btbuscarPaciente
        '
        Me.btbuscarPaciente.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarPaciente.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btbuscarPaciente.Location = New System.Drawing.Point(188, 19)
        Me.btbuscarPaciente.Name = "btbuscarPaciente"
        Me.btbuscarPaciente.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarPaciente.TabIndex = 65
        Me.btbuscarPaciente.UseVisualStyleBackColor = True
        '
        'txtcodigocontrato
        '
        Me.txtcodigocontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcodigocontrato.Location = New System.Drawing.Point(91, 72)
        Me.txtcodigocontrato.Name = "txtcodigocontrato"
        Me.txtcodigocontrato.Size = New System.Drawing.Size(64, 21)
        Me.txtcodigocontrato.TabIndex = 41
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(676, 75)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 15)
        Me.Label30.TabIndex = 40
        Me.Label30.Text = "N° Registro:"
        '
        'txtregistro
        '
        Me.txtregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtregistro.Location = New System.Drawing.Point(751, 72)
        Me.txtregistro.Name = "txtregistro"
        Me.txtregistro.Size = New System.Drawing.Size(138, 21)
        Me.txtregistro.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(676, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 15)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Sala:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Contrato:"
        '
        'txtcontrato
        '
        Me.txtcontrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcontrato.Location = New System.Drawing.Point(158, 73)
        Me.txtcontrato.Name = "txtcontrato"
        Me.txtcontrato.Size = New System.Drawing.Size(510, 21)
        Me.txtcontrato.TabIndex = 35
        '
        'txtfechaingreso
        '
        Me.txtfechaingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtfechaingreso.Location = New System.Drawing.Point(566, 47)
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
        Me.Label9.Location = New System.Drawing.Point(475, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Fecha Ingreso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(360, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Cama:"
        '
        'txtcama
        '
        Me.txtcama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtcama.Location = New System.Drawing.Point(406, 48)
        Me.txtcama.Name = "txtcama"
        Me.txtcama.Size = New System.Drawing.Size(57, 21)
        Me.txtcama.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(222, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Edad:"
        '
        'txtedad
        '
        Me.txtedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtedad.Location = New System.Drawing.Point(286, 48)
        Me.txtedad.Name = "txtedad"
        Me.txtedad.Size = New System.Drawing.Size(68, 21)
        Me.txtedad.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Sexo:"
        '
        'txtsexo
        '
        Me.txtsexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtsexo.Location = New System.Drawing.Point(91, 47)
        Me.txtsexo.Name = "txtsexo"
        Me.txtsexo.Size = New System.Drawing.Size(122, 21)
        Me.txtsexo.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(222, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Paciente:"
        '
        'txtpaciente
        '
        Me.txtpaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtpaciente.Location = New System.Drawing.Point(286, 22)
        Me.txtpaciente.Name = "txtpaciente"
        Me.txtpaciente.Size = New System.Drawing.Size(382, 21)
        Me.txtpaciente.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Identificación:"
        '
        'txtidentificacion
        '
        Me.txtidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtidentificacion.Location = New System.Drawing.Point(91, 20)
        Me.txtidentificacion.Name = "txtidentificacion"
        Me.txtidentificacion.Size = New System.Drawing.Size(97, 21)
        Me.txtidentificacion.TabIndex = 21
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.lresponsable, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(942, 54)
        Me.ToolStrip1.TabIndex = 37
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(301, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Prueba"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'componente
        '
        Me.componente.FileName = "OpenFileDialog1"
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
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 30
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'dgcodigo
        '
        Me.dgcodigo.HeaderText = "codigoParametro"
        Me.dgcodigo.Name = "dgcodigo"
        Me.dgcodigo.Visible = False
        Me.dgcodigo.Width = 108
        '
        'dgmedicion
        '
        Me.dgmedicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgmedicion.HeaderText = "Medicion"
        Me.dgmedicion.Name = "dgmedicion"
        '
        'dgvalorespPacientes
        '
        Me.dgvalorespPacientes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvalorespPacientes.HeaderText = "Valores Pacientes"
        Me.dgvalorespPacientes.MaxInputLength = 6
        Me.dgvalorespPacientes.Name = "dgvalorespPacientes"
        '
        'dgvaloresNormales
        '
        Me.dgvaloresNormales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvaloresNormales.HeaderText = "Valores Normales"
        Me.dgvaloresNormales.MaxInputLength = 30
        Me.dgvaloresNormales.Name = "dgvaloresNormales"
        '
        'Form_ecocardiograma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(942, 556)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(958, 595)
        Me.MinimumSize = New System.Drawing.Size(958, 595)
        Me.Name = "Form_ecocardiograma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupOtrosD.ResumeLayout(False)
        Me.GroupOtrosD.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvparametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupDatos.ResumeLayout(False)
        Me.GroupDatos.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
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
    Friend WithEvents Label11 As Label
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
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents dgvparametros As DataGridView
    Friend WithEvents Textventana As TextBox
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
    Friend WithEvents Label13 As Label
    Friend WithEvents Txtexamen As TextBox
    Friend WithEvents btbuscarPaciente As Button
    Friend WithEvents GroupOtrosD As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCodigoOrden As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txtjustificacion As TextBox
    Friend WithEvents lresponsable As ToolStripLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents btimprimir As ToolStripButton
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lblentorno As TextBox
    Friend WithEvents dtfecha As DateTimePicker
    Friend WithEvents Rtdescripcion As RichTextBox
    Friend WithEvents Rtconclusiones As RichTextBox
    Friend WithEvents dgcodigo As DataGridViewTextBoxColumn
    Friend WithEvents dgmedicion As DataGridViewTextBoxColumn
    Friend WithEvents dgvalorespPacientes As DataGridViewTextBoxColumn
    Friend WithEvents dgvaloresNormales As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents componente As OpenFileDialog
End Class
