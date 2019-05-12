<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Listado_Paciente
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Listado_Paciente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.npaciente = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.pnlAuditoria = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvNotaAuditoria = New System.Windows.Forms.DataGridView()
        Me.pnlConsolidado = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btOpcionConsolidado = New System.Windows.Forms.Button()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.dgvConsolidado = New System.Windows.Forms.DataGridView()
        Me.dgvmanual = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.gbEstadoAtencion = New System.Windows.Forms.GroupBox()
        Me.selRevision = New System.Windows.Forms.RadioButton()
        Me.selPrefacturado = New System.Windows.Forms.RadioButton()
        Me.selFacturados = New System.Windows.Forms.RadioButton()
        Me.selTodos = New System.Windows.Forms.RadioButton()
        Me.selAtendidos = New System.Windows.Forms.RadioButton()
        Me.selCerrados = New System.Windows.Forms.RadioButton()
        Me.comboAreaServicio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.busquedaPaciente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btOpcionEnviarRevisados = New System.Windows.Forms.Button()
        Me.btOpcionAprobar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.pnlAuditoria.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvNotaAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsolidado.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        CType(Me.dgvConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvmanual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.gbEstadoAtencion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.npaciente)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1292, 562)
        Me.GroupBox1.TabIndex = 10048
        Me.GroupBox1.TabStop = False
        '
        'npaciente
        '
        Me.npaciente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.npaciente.AutoSize = True
        Me.npaciente.BackColor = System.Drawing.Color.Transparent
        Me.npaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.npaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.npaciente.Location = New System.Drawing.Point(1236, 540)
        Me.npaciente.Name = "npaciente"
        Me.npaciente.Size = New System.Drawing.Size(14, 15)
        Me.npaciente.TabIndex = 10058
        Me.npaciente.Text = "0"
        Me.npaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.pnlAuditoria)
        Me.GroupBox5.Controls.Add(Me.pnlConsolidado)
        Me.GroupBox5.Controls.Add(Me.dgvmanual)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 70)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1276, 464)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pacientes:"
        '
        'pnlAuditoria
        '
        Me.pnlAuditoria.Controls.Add(Me.Button1)
        Me.pnlAuditoria.Controls.Add(Me.GroupBox2)
        Me.pnlAuditoria.Location = New System.Drawing.Point(633, 24)
        Me.pnlAuditoria.Name = "pnlAuditoria"
        Me.pnlAuditoria.Size = New System.Drawing.Size(372, 257)
        Me.pnlAuditoria.TabIndex = 10064
        Me.pnlAuditoria.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(346, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(21, 21)
        Me.Button1.TabIndex = 10074
        Me.Button1.Text = "x"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvNotaAuditoria)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 232)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Notas:"
        '
        'dgvNotaAuditoria
        '
        Me.dgvNotaAuditoria.AllowUserToAddRows = False
        Me.dgvNotaAuditoria.AllowUserToDeleteRows = False
        Me.dgvNotaAuditoria.AllowUserToResizeColumns = False
        Me.dgvNotaAuditoria.AllowUserToResizeRows = False
        Me.dgvNotaAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvNotaAuditoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvNotaAuditoria.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvNotaAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotaAuditoria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgCargo, Me.dgCantidad})
        Me.dgvNotaAuditoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNotaAuditoria.Location = New System.Drawing.Point(3, 17)
        Me.dgvNotaAuditoria.Name = "dgvNotaAuditoria"
        Me.dgvNotaAuditoria.RowHeadersVisible = False
        Me.dgvNotaAuditoria.Size = New System.Drawing.Size(360, 212)
        Me.dgvNotaAuditoria.TabIndex = 2
        '
        'pnlConsolidado
        '
        Me.pnlConsolidado.Controls.Add(Me.Label5)
        Me.pnlConsolidado.Controls.Add(Me.btOpcionConsolidado)
        Me.pnlConsolidado.Controls.Add(Me.GroupBox30)
        Me.pnlConsolidado.Location = New System.Drawing.Point(1024, 20)
        Me.pnlConsolidado.Name = "pnlConsolidado"
        Me.pnlConsolidado.Size = New System.Drawing.Size(246, 261)
        Me.pnlConsolidado.TabIndex = 10063
        Me.pnlConsolidado.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 10074
        Me.Label5.Text = "Por favor espere..."
        '
        'btOpcionConsolidado
        '
        Me.btOpcionConsolidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOpcionConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionConsolidado.Location = New System.Drawing.Point(220, 3)
        Me.btOpcionConsolidado.Name = "btOpcionConsolidado"
        Me.btOpcionConsolidado.Size = New System.Drawing.Size(21, 21)
        Me.btOpcionConsolidado.TabIndex = 10073
        Me.btOpcionConsolidado.Text = "x"
        Me.btOpcionConsolidado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btOpcionConsolidado.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btOpcionConsolidado.UseVisualStyleBackColor = True
        Me.btOpcionConsolidado.Visible = False
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
        Me.dgvConsolidado.Location = New System.Drawing.Point(3, 17)
        Me.dgvConsolidado.Name = "dgvConsolidado"
        Me.dgvConsolidado.RowHeadersVisible = False
        Me.dgvConsolidado.Size = New System.Drawing.Size(228, 215)
        Me.dgvConsolidado.TabIndex = 1
        '
        'dgvmanual
        '
        Me.dgvmanual.AllowUserToAddRows = False
        Me.dgvmanual.AllowUserToDeleteRows = False
        Me.dgvmanual.AllowUserToResizeColumns = False
        Me.dgvmanual.AllowUserToResizeRows = False
        Me.dgvmanual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvmanual.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvmanual.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvmanual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvmanual.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvmanual.Location = New System.Drawing.Point(6, 20)
        Me.dgvmanual.MultiSelect = False
        Me.dgvmanual.Name = "dgvmanual"
        Me.dgvmanual.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvmanual.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvmanual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvmanual.Size = New System.Drawing.Size(1264, 438)
        Me.dgvmanual.TabIndex = 19
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gbEstadoAtencion)
        Me.GroupBox4.Controls.Add(Me.comboAreaServicio)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.busquedaPaciente)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1276, 54)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtros de Busqueda:"
        '
        'gbEstadoAtencion
        '
        Me.gbEstadoAtencion.Controls.Add(Me.selRevision)
        Me.gbEstadoAtencion.Controls.Add(Me.selPrefacturado)
        Me.gbEstadoAtencion.Controls.Add(Me.selFacturados)
        Me.gbEstadoAtencion.Controls.Add(Me.selTodos)
        Me.gbEstadoAtencion.Controls.Add(Me.selAtendidos)
        Me.gbEstadoAtencion.Controls.Add(Me.selCerrados)
        Me.gbEstadoAtencion.Location = New System.Drawing.Point(726, 8)
        Me.gbEstadoAtencion.Name = "gbEstadoAtencion"
        Me.gbEstadoAtencion.Size = New System.Drawing.Size(542, 42)
        Me.gbEstadoAtencion.TabIndex = 10058
        Me.gbEstadoAtencion.TabStop = False
        Me.gbEstadoAtencion.Text = "Estado de Atención:"
        '
        'selRevision
        '
        Me.selRevision.AutoSize = True
        Me.selRevision.BackColor = System.Drawing.Color.Transparent
        Me.selRevision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selRevision.ForeColor = System.Drawing.Color.DarkOrange
        Me.selRevision.Location = New System.Drawing.Point(103, 16)
        Me.selRevision.Name = "selRevision"
        Me.selRevision.Size = New System.Drawing.Size(72, 19)
        Me.selRevision.TabIndex = 10059
        Me.selRevision.Text = "Revisión"
        Me.selRevision.UseVisualStyleBackColor = False
        '
        'selPrefacturado
        '
        Me.selPrefacturado.AutoSize = True
        Me.selPrefacturado.BackColor = System.Drawing.Color.Transparent
        Me.selPrefacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selPrefacturado.ForeColor = System.Drawing.Color.Blue
        Me.selPrefacturado.Location = New System.Drawing.Point(269, 16)
        Me.selPrefacturado.Name = "selPrefacturado"
        Me.selPrefacturado.Size = New System.Drawing.Size(101, 19)
        Me.selPrefacturado.TabIndex = 10058
        Me.selPrefacturado.Text = "Prefacturados"
        Me.selPrefacturado.UseVisualStyleBackColor = False
        '
        'selFacturados
        '
        Me.selFacturados.AutoSize = True
        Me.selFacturados.BackColor = System.Drawing.Color.Transparent
        Me.selFacturados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selFacturados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.selFacturados.Location = New System.Drawing.Point(379, 16)
        Me.selFacturados.Name = "selFacturados"
        Me.selFacturados.Size = New System.Drawing.Size(86, 19)
        Me.selFacturados.TabIndex = 10057
        Me.selFacturados.Text = "Facturados"
        Me.selFacturados.UseVisualStyleBackColor = False
        '
        'selTodos
        '
        Me.selTodos.AutoSize = True
        Me.selTodos.BackColor = System.Drawing.Color.Transparent
        Me.selTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selTodos.ForeColor = System.Drawing.Color.Black
        Me.selTodos.Location = New System.Drawing.Point(473, 16)
        Me.selTodos.Name = "selTodos"
        Me.selTodos.Size = New System.Drawing.Size(59, 19)
        Me.selTodos.TabIndex = 10055
        Me.selTodos.Text = "Todos"
        Me.selTodos.UseVisualStyleBackColor = False
        '
        'selAtendidos
        '
        Me.selAtendidos.AutoSize = True
        Me.selAtendidos.BackColor = System.Drawing.Color.Transparent
        Me.selAtendidos.Checked = True
        Me.selAtendidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selAtendidos.ForeColor = System.Drawing.Color.Green
        Me.selAtendidos.Location = New System.Drawing.Point(17, 16)
        Me.selAtendidos.Name = "selAtendidos"
        Me.selAtendidos.Size = New System.Drawing.Size(79, 19)
        Me.selAtendidos.TabIndex = 10053
        Me.selAtendidos.TabStop = True
        Me.selAtendidos.Text = "Atendidos"
        Me.selAtendidos.UseVisualStyleBackColor = False
        '
        'selCerrados
        '
        Me.selCerrados.AutoSize = True
        Me.selCerrados.BackColor = System.Drawing.Color.Transparent
        Me.selCerrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selCerrados.ForeColor = System.Drawing.Color.Red
        Me.selCerrados.Location = New System.Drawing.Point(186, 16)
        Me.selCerrados.Name = "selCerrados"
        Me.selCerrados.Size = New System.Drawing.Size(75, 19)
        Me.selCerrados.TabIndex = 10054
        Me.selCerrados.Text = "Cerrados"
        Me.selCerrados.UseVisualStyleBackColor = False
        '
        'comboAreaServicio
        '
        Me.comboAreaServicio.BackColor = System.Drawing.Color.White
        Me.comboAreaServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAreaServicio.FormattingEnabled = True
        Me.comboAreaServicio.Location = New System.Drawing.Point(418, 22)
        Me.comboAreaServicio.Name = "comboAreaServicio"
        Me.comboAreaServicio.Size = New System.Drawing.Size(272, 23)
        Me.comboAreaServicio.TabIndex = 10052
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(378, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 15)
        Me.Label3.TabIndex = 10051
        Me.Label3.Text = "Área:"
        '
        'busquedaPaciente
        '
        Me.busquedaPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.busquedaPaciente.Location = New System.Drawing.Point(74, 23)
        Me.busquedaPaciente.Name = "busquedaPaciente"
        Me.busquedaPaciente.Size = New System.Drawing.Size(281, 21)
        Me.busquedaPaciente.TabIndex = 10050
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 15)
        Me.Label10.TabIndex = 10048
        Me.Label10.Text = "Paciente:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1089, 540)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 15)
        Me.Label4.TabIndex = 10056
        Me.Label4.Text = "Cantidad de Pacientes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 10045
        Me.Label1.Text = "LISTADO DE PACIENTES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(52, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1249, 20)
        Me.Label2.TabIndex = 10046
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.People_Patient_Male_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10047
        Me.PictureBox1.TabStop = False
        '
        'btOpcionEnviarRevisados
        '
        Me.btOpcionEnviarRevisados.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionEnviarRevisados.Image = Global.Celer.My.Resources.Resources.Document_write_icon
        Me.btOpcionEnviarRevisados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionEnviarRevisados.Location = New System.Drawing.Point(1098, 3)
        Me.btOpcionEnviarRevisados.Name = "btOpcionEnviarRevisados"
        Me.btOpcionEnviarRevisados.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionEnviarRevisados.TabIndex = 60009
        Me.btOpcionEnviarRevisados.Text = "Anexo 3"
        Me.btOpcionEnviarRevisados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionEnviarRevisados.UseVisualStyleBackColor = True
        Me.btOpcionEnviarRevisados.Visible = False
        '
        'btOpcionAprobar
        '
        Me.btOpcionAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionAprobar.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btOpcionAprobar.Image = Global.Celer.My.Resources.Resources.aplica
        Me.btOpcionAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionAprobar.Location = New System.Drawing.Point(1187, 3)
        Me.btOpcionAprobar.Name = "btOpcionAprobar"
        Me.btOpcionAprobar.Size = New System.Drawing.Size(112, 34)
        Me.btOpcionAprobar.TabIndex = 60012
        Me.btOpcionAprobar.Text = "Aprobar Todos"
        Me.btOpcionAprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionAprobar.UseVisualStyleBackColor = True
        Me.btOpcionAprobar.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cargo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 74
        '
        'dgCargo
        '
        Me.dgCargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgCargo.HeaderText = "Cargo"
        Me.dgCargo.Name = "dgCargo"
        Me.dgCargo.ReadOnly = True
        '
        'dgCantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgCantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgCantidad.HeaderText = "Cantidad"
        Me.dgCantidad.Name = "dgCantidad"
        Me.dgCantidad.ReadOnly = True
        Me.dgCantidad.Width = 74
        '
        'Form_Listado_Paciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.btOpcionAprobar)
        Me.Controls.Add(Me.btOpcionEnviarRevisados)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "Form_Listado_Paciente"
        Me.Opacity = 0.1R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.pnlAuditoria.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvNotaAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsolidado.ResumeLayout(False)
        Me.pnlConsolidado.PerformLayout()
        Me.GroupBox30.ResumeLayout(False)
        CType(Me.dgvConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvmanual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbEstadoAtencion.ResumeLayout(False)
        Me.gbEstadoAtencion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents busquedaPaciente As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgvmanual As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents npaciente As Label
    Friend WithEvents gbEstadoAtencion As GroupBox
    Friend WithEvents selFacturados As RadioButton
    Friend WithEvents selTodos As RadioButton
    Friend WithEvents selAtendidos As RadioButton
    Friend WithEvents selCerrados As RadioButton
    Friend WithEvents comboAreaServicio As ComboBox
    Protected WithEvents Label4 As Label
    Friend WithEvents selPrefacturado As RadioButton
    Friend WithEvents pnlConsolidado As Panel
    Friend WithEvents btOpcionConsolidado As Button
    Friend WithEvents GroupBox30 As GroupBox
    Friend WithEvents dgvConsolidado As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents selRevision As RadioButton
    Public WithEvents btOpcionEnviarRevisados As Button
    Public WithEvents btOpcionAprobar As Button
    Friend WithEvents pnlAuditoria As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvNotaAuditoria As DataGridView
    Friend WithEvents dgCargo As DataGridViewTextBoxColumn
    Friend WithEvents dgCantidad As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
