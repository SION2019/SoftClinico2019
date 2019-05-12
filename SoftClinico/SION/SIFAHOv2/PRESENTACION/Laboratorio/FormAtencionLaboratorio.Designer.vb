<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAtencionLaboratorio
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAtencionLaboratorio))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabPaciente = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btsolitudLab = New System.Windows.Forms.Button()
        Me.btBuscarCitaM = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCitaMedica = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtobservacion = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextCodEPS = New System.Windows.Forms.TextBox()
        Me.textEPS = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.textedad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextSexo = New System.Windows.Forms.TextBox()
        Me.textNombre = New System.Windows.Forms.TextBox()
        Me.CmbEPS = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btbuscarPaciente = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.textPaciente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.dgvParaclinicos = New System.Windows.Forms.DataGridView()
        Me.dgCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDescripcionp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcantidadp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgResultadoPara = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgAnular = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvProcedimiento = New System.Windows.Forms.DataGridView()
        Me.dgcodigop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdescripcionps = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCantidadps = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dganularps = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvHemoderivado = New System.Windows.Forms.DataGridView()
        Me.dgcodigoh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdescripcionh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcantidadh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dganularh = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvMedicamentos = New System.Windows.Forms.DataGridView()
        Me.dgcodigooculto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcodigom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdescripcionm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dganularm = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvInsumos = New System.Windows.Forms.DataGridView()
        Me.dgcodigoin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcodigoi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdescripcioni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcantidadi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dganulari = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Labeltipodoc = New System.Windows.Forms.Label()
        Me.btexaminar = New System.Windows.Forms.Button()
        Me.combodescripciondocu = New System.Windows.Forms.ComboBox()
        Me.dgvdocumentos = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.borrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.extension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btguardarimagen = New System.Windows.Forms.Button()
        Me.picturedocu = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btOpcionCitas = New System.Windows.Forms.Button()
        Me.openimagen = New System.Windows.Forms.OpenFileDialog()
        Me.btOpcionChequeo = New System.Windows.Forms.Button()
        Me.btConsolidado = New System.Windows.Forms.Button()
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
        Me.pnlConsolidado = New System.Windows.Forms.Panel()
        Me.btOpcionConsolidado = New System.Windows.Forms.Button()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.dgvConsolidado = New System.Windows.Forms.DataGridView()
        Me.fechaAtencion = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.TabPaciente.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgvParaclinicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvProcedimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvHemoderivado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvMedicamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgvdocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturedocu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsolidado.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        CType(Me.dgvConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabPaciente)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 449)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'TabPaciente
        '
        Me.TabPaciente.Controls.Add(Me.TabPage1)
        Me.TabPaciente.Controls.Add(Me.TabPage7)
        Me.TabPaciente.Location = New System.Drawing.Point(7, 13)
        Me.TabPaciente.Name = "TabPaciente"
        Me.TabPaciente.SelectedIndex = 0
        Me.TabPaciente.Size = New System.Drawing.Size(885, 430)
        Me.TabPaciente.TabIndex = 51
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.TabControl1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(877, 404)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Informacion"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fechaAtencion)
        Me.GroupBox2.Controls.Add(Me.btsolitudLab)
        Me.GroupBox2.Controls.Add(Me.btBuscarCitaM)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCitaMedica)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.txtobservacion)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextCodEPS)
        Me.GroupBox2.Controls.Add(Me.textEPS)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.textedad)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextSexo)
        Me.GroupBox2.Controls.Add(Me.textNombre)
        Me.GroupBox2.Controls.Add(Me.CmbEPS)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btbuscarPaciente)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.textPaciente)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtEstado)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(870, 179)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información del Paciente:"
        '
        'btsolitudLab
        '
        Me.btsolitudLab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btsolitudLab.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsolitudLab.Image = Global.Celer.My.Resources.Resources.science_chemistry_icon__1_
        Me.btsolitudLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsolitudLab.Location = New System.Drawing.Point(684, 134)
        Me.btsolitudLab.Name = "btsolitudLab"
        Me.btsolitudLab.Size = New System.Drawing.Size(179, 34)
        Me.btsolitudLab.TabIndex = 10082
        Me.btsolitudLab.Text = "Solicitudes de laboratorio"
        Me.btsolitudLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsolitudLab.UseVisualStyleBackColor = True
        '
        'btBuscarCitaM
        '
        Me.btBuscarCitaM.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBuscarCitaM.Location = New System.Drawing.Point(168, 19)
        Me.btBuscarCitaM.Name = "btBuscarCitaM"
        Me.btBuscarCitaM.Size = New System.Drawing.Size(25, 23)
        Me.btBuscarCitaM.TabIndex = 53
        Me.btBuscarCitaM.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 15)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "C. Medica:"
        '
        'txtCitaMedica
        '
        Me.txtCitaMedica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCitaMedica.Location = New System.Drawing.Point(80, 20)
        Me.txtCitaMedica.Name = "txtCitaMedica"
        Me.txtCitaMedica.Size = New System.Drawing.Size(86, 21)
        Me.txtCitaMedica.TabIndex = 54
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(784, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(82, 19)
        Me.CheckBox1.TabIndex = 51
        Me.CheckBox1.Text = "En espera"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtobservacion
        '
        Me.txtobservacion.BackColor = System.Drawing.Color.White
        Me.txtobservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtobservacion.Location = New System.Drawing.Point(95, 112)
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.ReadOnly = True
        Me.txtobservacion.Size = New System.Drawing.Size(566, 55)
        Me.txtobservacion.TabIndex = 49
        Me.txtobservacion.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 15)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Observación:"
        '
        'TextCodEPS
        '
        Me.TextCodEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextCodEPS.Location = New System.Drawing.Point(80, 49)
        Me.TextCodEPS.Name = "TextCodEPS"
        Me.TextCodEPS.Size = New System.Drawing.Size(86, 21)
        Me.TextCodEPS.TabIndex = 47
        '
        'textEPS
        '
        Me.textEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textEPS.Location = New System.Drawing.Point(168, 49)
        Me.textEPS.Name = "textEPS"
        Me.textEPS.Size = New System.Drawing.Size(463, 21)
        Me.textEPS.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 15)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "EPS:"
        '
        'textedad
        '
        Me.textedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textedad.Location = New System.Drawing.Point(794, 49)
        Me.textedad.MaxLength = 20
        Me.textedad.Name = "textedad"
        Me.textedad.ReadOnly = True
        Me.textedad.ShortcutsEnabled = False
        Me.textedad.Size = New System.Drawing.Size(73, 21)
        Me.textedad.TabIndex = 44
        Me.textedad.TabStop = False
        Me.textedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(752, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Edad:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(550, 79)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(102, 21)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(491, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Solicitud:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(637, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Sexo:"
        '
        'TextSexo
        '
        Me.TextSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextSexo.Location = New System.Drawing.Point(679, 49)
        Me.TextSexo.Name = "TextSexo"
        Me.TextSexo.Size = New System.Drawing.Size(60, 21)
        Me.TextSexo.TabIndex = 41
        '
        'textNombre
        '
        Me.textNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textNombre.Location = New System.Drawing.Point(384, 19)
        Me.textNombre.Name = "textNombre"
        Me.textNombre.Size = New System.Drawing.Size(372, 21)
        Me.textNombre.TabIndex = 40
        '
        'CmbEPS
        '
        Me.CmbEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CmbEPS.FormattingEnabled = True
        Me.CmbEPS.Location = New System.Drawing.Point(80, 77)
        Me.CmbEPS.Name = "CmbEPS"
        Me.CmbEPS.Size = New System.Drawing.Size(400, 23)
        Me.CmbEPS.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Facturar a:"
        '
        'btbuscarPaciente
        '
        Me.btbuscarPaciente.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscarPaciente.Location = New System.Drawing.Point(355, 18)
        Me.btbuscarPaciente.Name = "btbuscarPaciente"
        Me.btbuscarPaciente.Size = New System.Drawing.Size(25, 23)
        Me.btbuscarPaciente.TabIndex = 35
        Me.btbuscarPaciente.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(205, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Paciente:"
        '
        'textPaciente
        '
        Me.textPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.textPaciente.Location = New System.Drawing.Point(264, 19)
        Me.textPaciente.Name = "textPaciente"
        Me.textPaciente.Size = New System.Drawing.Size(86, 21)
        Me.textPaciente.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(664, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha:"
        '
        'txtEstado
        '
        Me.txtEstado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(758, 106)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(109, 21)
        Me.txtEstado.TabIndex = 3
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(705, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Estado:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(4, 183)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(870, 221)
        Me.TabControl1.TabIndex = 50
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.dgvParaclinicos)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(862, 195)
        Me.TabPage6.TabIndex = 6
        Me.TabPage6.Text = "Paraclinicos"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'dgvParaclinicos
        '
        Me.dgvParaclinicos.AllowUserToAddRows = False
        Me.dgvParaclinicos.AllowUserToDeleteRows = False
        Me.dgvParaclinicos.AllowUserToResizeColumns = False
        Me.dgvParaclinicos.AllowUserToResizeRows = False
        Me.dgvParaclinicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvParaclinicos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvParaclinicos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvParaclinicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParaclinicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgCodigo, Me.dgDescripcionp, Me.dgcantidadp, Me.dgResultadoPara, Me.dgAnular})
        Me.dgvParaclinicos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvParaclinicos.Location = New System.Drawing.Point(0, 0)
        Me.dgvParaclinicos.MultiSelect = False
        Me.dgvParaclinicos.Name = "dgvParaclinicos"
        Me.dgvParaclinicos.RowHeadersVisible = False
        Me.dgvParaclinicos.Size = New System.Drawing.Size(862, 195)
        Me.dgvParaclinicos.TabIndex = 10087
        '
        'dgCodigo
        '
        Me.dgCodigo.HeaderText = "Codigo"
        Me.dgCodigo.Name = "dgCodigo"
        Me.dgCodigo.Width = 65
        '
        'dgDescripcionp
        '
        Me.dgDescripcionp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgDescripcionp.HeaderText = "Descripción"
        Me.dgDescripcionp.Name = "dgDescripcionp"
        '
        'dgcantidadp
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgcantidadp.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcantidadp.HeaderText = "Cantidad"
        Me.dgcantidadp.Name = "dgcantidadp"
        Me.dgcantidadp.Width = 74
        '
        'dgResultadoPara
        '
        Me.dgResultadoPara.HeaderText = "Resultado"
        Me.dgResultadoPara.Name = "dgResultadoPara"
        Me.dgResultadoPara.Width = 61
        '
        'dgAnular
        '
        Me.dgAnular.HeaderText = "Quitar"
        Me.dgAnular.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.dgAnular.Name = "dgAnular"
        Me.dgAnular.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAnular.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgAnular.Width = 60
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvProcedimiento)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(862, 195)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "Procedimientos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvProcedimiento
        '
        Me.dgvProcedimiento.AllowUserToAddRows = False
        Me.dgvProcedimiento.AllowUserToDeleteRows = False
        Me.dgvProcedimiento.AllowUserToResizeColumns = False
        Me.dgvProcedimiento.AllowUserToResizeRows = False
        Me.dgvProcedimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProcedimiento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProcedimiento.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvProcedimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcedimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcodigop, Me.dgdescripcionps, Me.dgCantidadps, Me.dganularps})
        Me.dgvProcedimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcedimiento.Location = New System.Drawing.Point(0, 0)
        Me.dgvProcedimiento.MultiSelect = False
        Me.dgvProcedimiento.Name = "dgvProcedimiento"
        Me.dgvProcedimiento.RowHeadersVisible = False
        Me.dgvProcedimiento.Size = New System.Drawing.Size(862, 195)
        Me.dgvProcedimiento.TabIndex = 10087
        '
        'dgcodigop
        '
        Me.dgcodigop.HeaderText = "Codigo"
        Me.dgcodigop.Name = "dgcodigop"
        Me.dgcodigop.Width = 65
        '
        'dgdescripcionps
        '
        Me.dgdescripcionps.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgdescripcionps.HeaderText = "Descripción"
        Me.dgdescripcionps.Name = "dgdescripcionps"
        '
        'dgCantidadps
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgCantidadps.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCantidadps.HeaderText = "Cantidad"
        Me.dgCantidadps.Name = "dgCantidadps"
        Me.dgCantidadps.Width = 74
        '
        'dganularps
        '
        Me.dganularps.HeaderText = "Quitar"
        Me.dganularps.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.dganularps.Name = "dganularps"
        Me.dganularps.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dganularps.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dganularps.Width = 60
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvHemoderivado)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(862, 195)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Hemoderivados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvHemoderivado
        '
        Me.dgvHemoderivado.AllowUserToAddRows = False
        Me.dgvHemoderivado.AllowUserToDeleteRows = False
        Me.dgvHemoderivado.AllowUserToResizeColumns = False
        Me.dgvHemoderivado.AllowUserToResizeRows = False
        Me.dgvHemoderivado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvHemoderivado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvHemoderivado.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvHemoderivado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHemoderivado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcodigoh, Me.dgdescripcionh, Me.dgcantidadh, Me.dganularh})
        Me.dgvHemoderivado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHemoderivado.Location = New System.Drawing.Point(0, 0)
        Me.dgvHemoderivado.MultiSelect = False
        Me.dgvHemoderivado.Name = "dgvHemoderivado"
        Me.dgvHemoderivado.RowHeadersVisible = False
        Me.dgvHemoderivado.Size = New System.Drawing.Size(862, 195)
        Me.dgvHemoderivado.TabIndex = 10086
        '
        'dgcodigoh
        '
        Me.dgcodigoh.HeaderText = "Codigo"
        Me.dgcodigoh.Name = "dgcodigoh"
        Me.dgcodigoh.Width = 65
        '
        'dgdescripcionh
        '
        Me.dgdescripcionh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgdescripcionh.HeaderText = "Descripción"
        Me.dgdescripcionh.Name = "dgdescripcionh"
        '
        'dgcantidadh
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgcantidadh.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgcantidadh.HeaderText = "Cantidad"
        Me.dgcantidadh.Name = "dgcantidadh"
        Me.dgcantidadh.Width = 74
        '
        'dganularh
        '
        Me.dganularh.HeaderText = "Quitar"
        Me.dganularh.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.dganularh.Name = "dganularh"
        Me.dganularh.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dganularh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dganularh.Width = 60
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvMedicamentos)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(862, 195)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Medicamentos"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvMedicamentos
        '
        Me.dgvMedicamentos.AllowUserToAddRows = False
        Me.dgvMedicamentos.AllowUserToDeleteRows = False
        Me.dgvMedicamentos.AllowUserToResizeColumns = False
        Me.dgvMedicamentos.AllowUserToResizeRows = False
        Me.dgvMedicamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMedicamentos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMedicamentos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMedicamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcodigooculto, Me.dgcodigom, Me.dgdescripcionm, Me.dgcantidad, Me.dganularm})
        Me.dgvMedicamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMedicamentos.Location = New System.Drawing.Point(0, 0)
        Me.dgvMedicamentos.MultiSelect = False
        Me.dgvMedicamentos.Name = "dgvMedicamentos"
        Me.dgvMedicamentos.RowHeadersVisible = False
        Me.dgvMedicamentos.Size = New System.Drawing.Size(862, 195)
        Me.dgvMedicamentos.TabIndex = 10087
        '
        'dgcodigooculto
        '
        Me.dgcodigooculto.HeaderText = "CódigoOculto"
        Me.dgcodigooculto.Name = "dgcodigooculto"
        Me.dgcodigooculto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcodigooculto.Visible = False
        Me.dgcodigooculto.Width = 77
        '
        'dgcodigom
        '
        Me.dgcodigom.HeaderText = "Codigo"
        Me.dgcodigom.Name = "dgcodigom"
        Me.dgcodigom.Width = 65
        '
        'dgdescripcionm
        '
        Me.dgdescripcionm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgdescripcionm.HeaderText = "Descripción"
        Me.dgdescripcionm.Name = "dgdescripcionm"
        '
        'dgcantidad
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgcantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgcantidad.HeaderText = "Cantidad"
        Me.dgcantidad.Name = "dgcantidad"
        Me.dgcantidad.Width = 74
        '
        'dganularm
        '
        Me.dganularm.HeaderText = "Quitar"
        Me.dganularm.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.dganularm.Name = "dganularm"
        Me.dganularm.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dganularm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dganularm.Width = 60
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvInsumos)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(862, 195)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Insumos"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvInsumos
        '
        Me.dgvInsumos.AllowUserToAddRows = False
        Me.dgvInsumos.AllowUserToDeleteRows = False
        Me.dgvInsumos.AllowUserToResizeColumns = False
        Me.dgvInsumos.AllowUserToResizeRows = False
        Me.dgvInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvInsumos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvInsumos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInsumos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcodigoin, Me.dgcodigoi, Me.dgdescripcioni, Me.dgcantidadi, Me.dganulari})
        Me.dgvInsumos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsumos.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsumos.MultiSelect = False
        Me.dgvInsumos.Name = "dgvInsumos"
        Me.dgvInsumos.RowHeadersVisible = False
        Me.dgvInsumos.Size = New System.Drawing.Size(862, 195)
        Me.dgvInsumos.TabIndex = 10087
        '
        'dgcodigoin
        '
        Me.dgcodigoin.HeaderText = "CodigoInsumo"
        Me.dgcodigoin.Name = "dgcodigoin"
        Me.dgcodigoin.Visible = False
        Me.dgcodigoin.Width = 80
        '
        'dgcodigoi
        '
        Me.dgcodigoi.HeaderText = "Codigo"
        Me.dgcodigoi.Name = "dgcodigoi"
        Me.dgcodigoi.Width = 65
        '
        'dgdescripcioni
        '
        Me.dgdescripcioni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgdescripcioni.HeaderText = "Descripción"
        Me.dgdescripcioni.Name = "dgdescripcioni"
        '
        'dgcantidadi
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgcantidadi.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgcantidadi.HeaderText = "Cantidad"
        Me.dgcantidadi.Name = "dgcantidadi"
        Me.dgcantidadi.Width = 74
        '
        'dganulari
        '
        Me.dganulari.HeaderText = "Quitar"
        Me.dganulari.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.dganulari.Name = "dganulari"
        Me.dganulari.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dganulari.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dganulari.Width = 60
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Labeltipodoc)
        Me.TabPage7.Controls.Add(Me.btexaminar)
        Me.TabPage7.Controls.Add(Me.combodescripciondocu)
        Me.TabPage7.Controls.Add(Me.dgvdocumentos)
        Me.TabPage7.Controls.Add(Me.btguardarimagen)
        Me.TabPage7.Controls.Add(Me.picturedocu)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(877, 404)
        Me.TabPage7.TabIndex = 1
        Me.TabPage7.Text = "Documentos"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Labeltipodoc
        '
        Me.Labeltipodoc.AutoSize = True
        Me.Labeltipodoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeltipodoc.Location = New System.Drawing.Point(730, 4)
        Me.Labeltipodoc.Name = "Labeltipodoc"
        Me.Labeltipodoc.Size = New System.Drawing.Size(106, 13)
        Me.Labeltipodoc.TabIndex = 10008
        Me.Labeltipodoc.Text = "Tipo Documentos"
        '
        'btexaminar
        '
        Me.btexaminar.Enabled = False
        Me.btexaminar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btexaminar.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.btexaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btexaminar.Location = New System.Drawing.Point(539, 4)
        Me.btexaminar.Name = "btexaminar"
        Me.btexaminar.Size = New System.Drawing.Size(130, 36)
        Me.btexaminar.TabIndex = 10007
        Me.btexaminar.Text = "Agregar Documento"
        Me.btexaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btexaminar.UseVisualStyleBackColor = True
        '
        'combodescripciondocu
        '
        Me.combodescripciondocu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.combodescripciondocu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combodescripciondocu.Enabled = False
        Me.combodescripciondocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.combodescripciondocu.FormattingEnabled = True
        Me.combodescripciondocu.Location = New System.Drawing.Point(675, 20)
        Me.combodescripciondocu.Name = "combodescripciondocu"
        Me.combodescripciondocu.Size = New System.Drawing.Size(196, 24)
        Me.combodescripciondocu.TabIndex = 10003
        '
        'dgvdocumentos
        '
        Me.dgvdocumentos.AllowUserToAddRows = False
        Me.dgvdocumentos.AllowUserToDeleteRows = False
        Me.dgvdocumentos.AllowUserToResizeColumns = False
        Me.dgvdocumentos.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvdocumentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvdocumentos.BackgroundColor = System.Drawing.Color.White
        Me.dgvdocumentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvdocumentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgvdocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvdocumentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.Descripcion, Me.Imagen, Me.fecha, Me.borrar, Me.extension})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvdocumentos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvdocumentos.Location = New System.Drawing.Point(6, 3)
        Me.dgvdocumentos.MultiSelect = False
        Me.dgvdocumentos.Name = "dgvdocumentos"
        Me.dgvdocumentos.RowHeadersVisible = False
        Me.dgvdocumentos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvdocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvdocumentos.ShowCellErrors = False
        Me.dgvdocumentos.ShowCellToolTips = False
        Me.dgvdocumentos.ShowEditingIcon = False
        Me.dgvdocumentos.ShowRowErrors = False
        Me.dgvdocumentos.Size = New System.Drawing.Size(527, 396)
        Me.dgvdocumentos.TabIndex = 10005
        '
        'codigo
        '
        Me.codigo.DataPropertyName = "Id_Documento"
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 240
        '
        'Imagen
        '
        Me.Imagen.DataPropertyName = "Imagen"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.NullValue = "System.Drawing.Bitmap"
        Me.Imagen.DefaultCellStyle = DataGridViewCellStyle7
        Me.Imagen.HeaderText = "Imagen"
        Me.Imagen.Image = Global.Celer.My.Resources.Resources.Badge_tick_icon__1_
        Me.Imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Imagen.Name = "Imagen"
        Me.Imagen.ReadOnly = True
        Me.Imagen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'fecha
        '
        Me.fecha.DataPropertyName = "Fecha"
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'borrar
        '
        Me.borrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.borrar.HeaderText = "Quitar"
        Me.borrar.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.borrar.Name = "borrar"
        Me.borrar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.borrar.Width = 60
        '
        'extension
        '
        Me.extension.DataPropertyName = "Extension_Doc"
        Me.extension.HeaderText = "extension"
        Me.extension.Name = "extension"
        Me.extension.Visible = False
        '
        'btguardarimagen
        '
        Me.btguardarimagen.Enabled = False
        Me.btguardarimagen.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btguardarimagen.Image = Global.Celer.My.Resources.Resources._04_Save_icon1
        Me.btguardarimagen.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btguardarimagen.Location = New System.Drawing.Point(539, 40)
        Me.btguardarimagen.Name = "btguardarimagen"
        Me.btguardarimagen.Size = New System.Drawing.Size(130, 36)
        Me.btguardarimagen.TabIndex = 10004
        Me.btguardarimagen.Text = " Guardar Documento"
        Me.btguardarimagen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btguardarimagen.UseVisualStyleBackColor = True
        '
        'picturedocu
        '
        Me.picturedocu.BackColor = System.Drawing.Color.White
        Me.picturedocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturedocu.Location = New System.Drawing.Point(540, 82)
        Me.picturedocu.Name = "picturedocu"
        Me.picturedocu.Size = New System.Drawing.Size(331, 318)
        Me.picturedocu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picturedocu.TabIndex = 10006
        Me.picturedocu.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator2, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator7, Me.btimprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 503)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 54)
        Me.ToolStrip1.TabIndex = 28
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
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
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.People_Patient_Male_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "ATENCIÓN CONSULTA EXTERNA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(856, 20)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________"
        '
        'btOpcionCitas
        '
        Me.btOpcionCitas.BackColor = System.Drawing.Color.Transparent
        Me.btOpcionCitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionCitas.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionCitas.ForeColor = System.Drawing.Color.Black
        Me.btOpcionCitas.Image = Global.Celer.My.Resources.Resources.check_todos_23
        Me.btOpcionCitas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionCitas.Location = New System.Drawing.Point(795, 7)
        Me.btOpcionCitas.Name = "btOpcionCitas"
        Me.btOpcionCitas.Size = New System.Drawing.Size(110, 34)
        Me.btOpcionCitas.TabIndex = 10061
        Me.btOpcionCitas.Text = "Citas Médicas"
        Me.btOpcionCitas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionCitas.UseVisualStyleBackColor = False
        '
        'openimagen
        '
        Me.openimagen.FileName = "OpenFileDialog1"
        '
        'btOpcionChequeo
        '
        Me.btOpcionChequeo.BackColor = System.Drawing.Color.Transparent
        Me.btOpcionChequeo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionChequeo.Enabled = False
        Me.btOpcionChequeo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionChequeo.ForeColor = System.Drawing.Color.Black
        Me.btOpcionChequeo.Image = Global.Celer.My.Resources.Resources.check_nada_23
        Me.btOpcionChequeo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionChequeo.Location = New System.Drawing.Point(685, 7)
        Me.btOpcionChequeo.Name = "btOpcionChequeo"
        Me.btOpcionChequeo.Size = New System.Drawing.Size(110, 34)
        Me.btOpcionChequeo.TabIndex = 10062
        Me.btOpcionChequeo.Text = "L. de chequeo"
        Me.btOpcionChequeo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionChequeo.UseVisualStyleBackColor = False
        '
        'btConsolidado
        '
        Me.btConsolidado.BackColor = System.Drawing.Color.Transparent
        Me.btConsolidado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btConsolidado.Enabled = False
        Me.btConsolidado.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConsolidado.ForeColor = System.Drawing.Color.Black
        Me.btConsolidado.Image = Global.Celer.My.Resources.Resources.Actions_view_list_details_icon
        Me.btConsolidado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btConsolidado.Location = New System.Drawing.Point(575, 7)
        Me.btConsolidado.Name = "btConsolidado"
        Me.btConsolidado.Size = New System.Drawing.Size(110, 34)
        Me.btConsolidado.TabIndex = 10063
        Me.btConsolidado.Text = "Consolidado"
        Me.btConsolidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btConsolidado.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 71
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 82
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 71
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn9.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 82
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 71
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn12.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn13.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 71
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn14.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn15.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn16.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn17.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 82
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Id_Documento"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Descripcion"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn19.Width = 240
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "Fecha"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Extension_Doc"
        Me.DataGridViewTextBoxColumn21.HeaderText = "extension"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Visible = False
        '
        'pnlConsolidado
        '
        Me.pnlConsolidado.Controls.Add(Me.btOpcionConsolidado)
        Me.pnlConsolidado.Controls.Add(Me.GroupBox30)
        Me.pnlConsolidado.Location = New System.Drawing.Point(441, 47)
        Me.pnlConsolidado.Name = "pnlConsolidado"
        Me.pnlConsolidado.Size = New System.Drawing.Size(246, 261)
        Me.pnlConsolidado.TabIndex = 10063
        Me.pnlConsolidado.Visible = False
        '
        'btOpcionConsolidado
        '
        Me.btOpcionConsolidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOpcionConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionConsolidado.Location = New System.Drawing.Point(217, 6)
        Me.btOpcionConsolidado.Name = "btOpcionConsolidado"
        Me.btOpcionConsolidado.Size = New System.Drawing.Size(21, 21)
        Me.btOpcionConsolidado.TabIndex = 10073
        Me.btOpcionConsolidado.Text = "x"
        Me.btOpcionConsolidado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btOpcionConsolidado.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btOpcionConsolidado.UseVisualStyleBackColor = True
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.dgvConsolidado)
        Me.GroupBox30.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox30.Location = New System.Drawing.Point(7, 21)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(234, 235)
        Me.GroupBox30.TabIndex = 10072
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Procesos activos:"
        '
        'dgvConsolidado
        '
        Me.dgvConsolidado.AllowUserToAddRows = False
        Me.dgvConsolidado.AllowUserToDeleteRows = False
        Me.dgvConsolidado.AllowUserToResizeColumns = False
        Me.dgvConsolidado.AllowUserToResizeRows = False
        Me.dgvConsolidado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvConsolidado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvConsolidado.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsolidado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsolidado.Location = New System.Drawing.Point(3, 16)
        Me.dgvConsolidado.Name = "dgvConsolidado"
        Me.dgvConsolidado.RowHeadersVisible = False
        Me.dgvConsolidado.Size = New System.Drawing.Size(228, 216)
        Me.dgvConsolidado.TabIndex = 1
        '
        'fechaAtencion
        '
        Me.fechaAtencion.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaAtencion.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.fechaAtencion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaAtencion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaAtencion.Location = New System.Drawing.Point(717, 79)
        Me.fechaAtencion.Name = "fechaAtencion"
        Me.fechaAtencion.Size = New System.Drawing.Size(147, 21)
        Me.fechaAtencion.TabIndex = 10083
        '
        'FormAtencionLaboratorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 557)
        Me.Controls.Add(Me.pnlConsolidado)
        Me.Controls.Add(Me.btConsolidado)
        Me.Controls.Add(Me.btOpcionChequeo)
        Me.Controls.Add(Me.btOpcionCitas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 596)
        Me.MinimumSize = New System.Drawing.Size(942, 596)
        Me.Name = "FormAtencionLaboratorio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPaciente.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        CType(Me.dgvParaclinicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvProcedimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvHemoderivado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvMedicamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        CType(Me.dgvdocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturedocu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsolidado.ResumeLayout(False)
        Me.GroupBox30.ResumeLayout(False)
        CType(Me.dgvConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label3 As Label
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents btbuscarPaciente As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents textPaciente As TextBox
    Friend WithEvents CmbEPS As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents textNombre As TextBox
    Public WithEvents textedad As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextSexo As TextBox
    Friend WithEvents TextCodEPS As TextBox
    Friend WithEvents textEPS As TextBox
    Friend WithEvents Label10 As Label
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
    Friend WithEvents txtobservacion As RichTextBox
    Friend WithEvents Label11 As Label
    Public WithEvents btimprimir As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents dgvParaclinicos As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvProcedimiento As DataGridView
    Friend WithEvents dgcodigop As DataGridViewTextBoxColumn
    Friend WithEvents dgdescripcionps As DataGridViewTextBoxColumn
    Friend WithEvents dgCantidadps As DataGridViewTextBoxColumn
    Friend WithEvents dganularps As DataGridViewImageColumn
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvHemoderivado As DataGridView
    Friend WithEvents dgcodigoh As DataGridViewTextBoxColumn
    Friend WithEvents dgdescripcionh As DataGridViewTextBoxColumn
    Friend WithEvents dgcantidadh As DataGridViewTextBoxColumn
    Friend WithEvents dganularh As DataGridViewImageColumn
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents dgvMedicamentos As DataGridView
    Friend WithEvents dgcodigooculto As DataGridViewTextBoxColumn
    Friend WithEvents dgcodigom As DataGridViewTextBoxColumn
    Friend WithEvents dgdescripcionm As DataGridViewTextBoxColumn
    Friend WithEvents dgcantidad As DataGridViewTextBoxColumn
    Friend WithEvents dganularm As DataGridViewImageColumn
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents dgvInsumos As DataGridView
    Friend WithEvents dgcodigoin As DataGridViewTextBoxColumn
    Friend WithEvents dgcodigoi As DataGridViewTextBoxColumn
    Friend WithEvents dgdescripcioni As DataGridViewTextBoxColumn
    Friend WithEvents dgcantidadi As DataGridViewTextBoxColumn
    Friend WithEvents dganulari As DataGridViewImageColumn
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents btOpcionCitas As Button
    Public WithEvents btBuscarCitaM As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCitaMedica As TextBox
    Friend WithEvents TabPaciente As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Public WithEvents btexaminar As Button
    Public WithEvents dgvdocumentos As DataGridView
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Imagen As DataGridViewImageColumn
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents borrar As DataGridViewImageColumn
    Friend WithEvents extension As DataGridViewTextBoxColumn
    Public WithEvents picturedocu As PictureBox
    Public WithEvents combodescripciondocu As ComboBox
    Public WithEvents btguardarimagen As Button
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents Labeltipodoc As Label
    Public WithEvents openimagen As OpenFileDialog
    Friend WithEvents btOpcionChequeo As Button
    Friend WithEvents btsolitudLab As Button
    Friend WithEvents dgCodigo As DataGridViewTextBoxColumn
    Friend WithEvents dgDescripcionp As DataGridViewTextBoxColumn
    Friend WithEvents dgcantidadp As DataGridViewTextBoxColumn
    Friend WithEvents dgResultadoPara As DataGridViewImageColumn
    Friend WithEvents dgAnular As DataGridViewImageColumn
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btConsolidado As Button
    Friend WithEvents pnlConsolidado As Panel
    Friend WithEvents btOpcionConsolidado As Button
    Friend WithEvents GroupBox30 As GroupBox
    Friend WithEvents dgvConsolidado As DataGridView
    Friend WithEvents fechaAtencion As DateTimePicker
End Class
