<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ComiteIH
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtfecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.seltodos = New System.Windows.Forms.RadioButton()
        Me.selPendientes = New System.Windows.Forms.RadioButton()
        Me.dtfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Comboservicio = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextBusqueda = New System.Windows.Forms.TextBox()
        Me.dgvrayosx = New System.Windows.Forms.DataGridView()
        Me.Fecha_solicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero_Registro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo_Solicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgEPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgentorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgInterpretacion = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvrayosx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 16)
        Me.Label1.TabIndex = 60015
        Me.Label1.Text = "SOLICITUDES PARA COMITÉ DE INFECCIONES INTRAHOSPITALARIAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1227, 20)
        Me.Label2.TabIndex = 60017
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "_____________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Text_Document_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60016
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.dgvrayosx)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1269, 546)
        Me.GroupBox1.TabIndex = 60018
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(3, 507)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1267, 33)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1211, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "#"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1068, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cantidad de pacientes:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtfecha2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.dtfecha)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Comboservicio)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.TextBusqueda)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1263, 47)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'dtfecha2
        '
        Me.dtfecha2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfecha2.Location = New System.Drawing.Point(892, 16)
        Me.dtfecha2.Name = "dtfecha2"
        Me.dtfecha2.Size = New System.Drawing.Size(101, 21)
        Me.dtfecha2.TabIndex = 275
        Me.dtfecha2.Value = New Date(2014, 1, 25, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(848, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 15)
        Me.Label5.TabIndex = 274
        Me.Label5.Text = "Hasta:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.seltodos)
        Me.GroupBox4.Controls.Add(Me.selPendientes)
        Me.GroupBox4.Location = New System.Drawing.Point(1064, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(195, 33)
        Me.GroupBox4.TabIndex = 273
        Me.GroupBox4.TabStop = False
        '
        'seltodos
        '
        Me.seltodos.AutoSize = True
        Me.seltodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seltodos.Location = New System.Drawing.Point(106, 11)
        Me.seltodos.Name = "seltodos"
        Me.seltodos.Size = New System.Drawing.Size(87, 19)
        Me.seltodos.TabIndex = 1
        Me.seltodos.Text = "Realizados"
        Me.seltodos.UseVisualStyleBackColor = True
        '
        'selPendientes
        '
        Me.selPendientes.AutoSize = True
        Me.selPendientes.Checked = True
        Me.selPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selPendientes.Location = New System.Drawing.Point(5, 11)
        Me.selPendientes.Name = "selPendientes"
        Me.selPendientes.Size = New System.Drawing.Size(87, 19)
        Me.selPendientes.TabIndex = 0
        Me.selPendientes.TabStop = True
        Me.selPendientes.Text = "Pendientes"
        Me.selPendientes.UseVisualStyleBackColor = True
        '
        'dtfecha
        '
        Me.dtfecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfecha.Location = New System.Drawing.Point(728, 15)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.Size = New System.Drawing.Size(101, 21)
        Me.dtfecha.TabIndex = 271
        Me.dtfecha.Value = New Date(2014, 1, 25, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(675, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 270
        Me.Label6.Text = "Desde:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(4, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 269
        Me.Label7.Text = "Paciente:"
        '
        'Comboservicio
        '
        Me.Comboservicio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comboservicio.BackColor = System.Drawing.Color.White
        Me.Comboservicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comboservicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comboservicio.ForeColor = System.Drawing.Color.Black
        Me.Comboservicio.FormattingEnabled = True
        Me.Comboservicio.Location = New System.Drawing.Point(422, 14)
        Me.Comboservicio.Name = "Comboservicio"
        Me.Comboservicio.Size = New System.Drawing.Size(218, 23)
        Me.Comboservicio.TabIndex = 268
        '
        'Label29
        '
        Me.Label29.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(323, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 15)
        Me.Label29.TabIndex = 267
        Me.Label29.Text = "Area de servicio:"
        '
        'TextBusqueda
        '
        Me.TextBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBusqueda.Location = New System.Drawing.Point(71, 15)
        Me.TextBusqueda.MaxLength = 100
        Me.TextBusqueda.Name = "TextBusqueda"
        Me.TextBusqueda.Size = New System.Drawing.Size(238, 21)
        Me.TextBusqueda.TabIndex = 0
        '
        'dgvrayosx
        '
        Me.dgvrayosx.AllowUserToAddRows = False
        Me.dgvrayosx.AllowUserToDeleteRows = False
        Me.dgvrayosx.AllowUserToResizeColumns = False
        Me.dgvrayosx.AllowUserToResizeRows = False
        Me.dgvrayosx.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvrayosx.BackgroundColor = System.Drawing.Color.White
        Me.dgvrayosx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvrayosx.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvrayosx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvrayosx.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha_solicitud, Me.FechaAdm, Me.Numero_Registro, Me.Codigo_Solicitud, Me.dgNombre, Me.dgEPS, Me.Motivo, Me.dgentorno, Me.Descripcion, Me.dgInterpretacion, Me.codigo})
        Me.dgvrayosx.Location = New System.Drawing.Point(3, 73)
        Me.dgvrayosx.Name = "dgvrayosx"
        Me.dgvrayosx.ReadOnly = True
        Me.dgvrayosx.RowHeadersVisible = False
        Me.dgvrayosx.Size = New System.Drawing.Size(1263, 428)
        Me.dgvrayosx.TabIndex = 9
        '
        'Fecha_solicitud
        '
        Me.Fecha_solicitud.HeaderText = "Fecha Solicitud"
        Me.Fecha_solicitud.Name = "Fecha_solicitud"
        Me.Fecha_solicitud.ReadOnly = True
        Me.Fecha_solicitud.Width = 90
        '
        'FechaAdm
        '
        Me.FechaAdm.HeaderText = "Fecha Admisión"
        Me.FechaAdm.Name = "FechaAdm"
        Me.FechaAdm.ReadOnly = True
        Me.FechaAdm.Width = 130
        '
        'Numero_Registro
        '
        Me.Numero_Registro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Numero_Registro.HeaderText = "Registro"
        Me.Numero_Registro.Name = "Numero_Registro"
        Me.Numero_Registro.ReadOnly = True
        Me.Numero_Registro.Visible = False
        '
        'Codigo_Solicitud
        '
        Me.Codigo_Solicitud.HeaderText = "Codigo Solicitud"
        Me.Codigo_Solicitud.Name = "Codigo_Solicitud"
        Me.Codigo_Solicitud.ReadOnly = True
        Me.Codigo_Solicitud.Visible = False
        '
        'dgNombre
        '
        Me.dgNombre.HeaderText = "Nombre del paciente"
        Me.dgNombre.Name = "dgNombre"
        Me.dgNombre.ReadOnly = True
        Me.dgNombre.Width = 280
        '
        'dgEPS
        '
        Me.dgEPS.HeaderText = "EPS"
        Me.dgEPS.Name = "dgEPS"
        Me.dgEPS.ReadOnly = True
        Me.dgEPS.Width = 230
        '
        'Motivo
        '
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        Me.Motivo.Width = 350
        '
        'dgentorno
        '
        Me.dgentorno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgentorno.HeaderText = "Area"
        Me.dgentorno.Name = "dgentorno"
        Me.dgentorno.ReadOnly = True
        Me.dgentorno.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Area Servicio"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'dgInterpretacion
        '
        Me.dgInterpretacion.HeaderText = "Ver"
        Me.dgInterpretacion.Name = "dgInterpretacion"
        Me.dgInterpretacion.ReadOnly = True
        Me.dgInterpretacion.Text = "+"
        Me.dgInterpretacion.ToolTipText = "Ingresar"
        Me.dgInterpretacion.UseColumnTextForButtonValue = True
        Me.dgInterpretacion.Visible = False
        Me.dgInterpretacion.Width = 60
        '
        'codigo
        '
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Visible = False
        '
        'Form_ComiteIH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1284, 611)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1300, 650)
        Me.MinimumSize = New System.Drawing.Size(1300, 650)
        Me.Name = "Form_ComiteIH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvrayosx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtfecha2 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents seltodos As RadioButton
    Friend WithEvents selPendientes As RadioButton
    Friend WithEvents dtfecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Comboservicio As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TextBusqueda As TextBox
    Friend WithEvents dgvrayosx As DataGridView
    Friend WithEvents Fecha_solicitud As DataGridViewTextBoxColumn
    Friend WithEvents FechaAdm As DataGridViewTextBoxColumn
    Friend WithEvents Numero_Registro As DataGridViewTextBoxColumn
    Friend WithEvents Codigo_Solicitud As DataGridViewTextBoxColumn
    Friend WithEvents dgNombre As DataGridViewTextBoxColumn
    Friend WithEvents dgEPS As DataGridViewTextBoxColumn
    Friend WithEvents Motivo As DataGridViewTextBoxColumn
    Friend WithEvents dgentorno As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents dgInterpretacion As DataGridViewButtonColumn
    Friend WithEvents codigo As DataGridViewTextBoxColumn
End Class
