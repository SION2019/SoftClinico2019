<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMetaHistorico
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvHistorico = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fechaFin = New System.Windows.Forms.DateTimePicker()
        Me.fechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgIdEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgFechaMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 491)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvHistorico)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 70)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(885, 415)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información de Cumplimiento de Metas"
        '
        'dgvHistorico
        '
        Me.dgvHistorico.AllowUserToAddRows = False
        Me.dgvHistorico.AllowUserToDeleteRows = False
        Me.dgvHistorico.AllowUserToResizeColumns = False
        Me.dgvHistorico.AllowUserToResizeRows = False
        Me.dgvHistorico.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgIdEmpleado, Me.dgEmpleado, Me.dgFechaMeta, Me.dgTotal, Me.dgMeta, Me.dgPorcentaje})
        Me.dgvHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistorico.GridColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.dgvHistorico.Location = New System.Drawing.Point(3, 17)
        Me.dgvHistorico.Name = "dgvHistorico"
        Me.dgvHistorico.RowHeadersVisible = False
        Me.dgvHistorico.Size = New System.Drawing.Size(879, 395)
        Me.dgvHistorico.TabIndex = 303
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fechaFin)
        Me.GroupBox2.Controls.Add(Me.fechaInicio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(885, 53)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodo:"
        '
        'fechaFin
        '
        Me.fechaFin.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaFin.CustomFormat = "dd /MMMM/ yyyy"
        Me.fechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaFin.Location = New System.Drawing.Point(295, 20)
        Me.fechaFin.Name = "fechaFin"
        Me.fechaFin.Size = New System.Drawing.Size(153, 21)
        Me.fechaFin.TabIndex = 322
        Me.fechaFin.Value = New Date(2014, 1, 10, 0, 0, 0, 0)
        '
        'fechaInicio
        '
        Me.fechaInicio.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaInicio.CustomFormat = "dd /MMMM/ yyyy"
        Me.fechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaInicio.Location = New System.Drawing.Point(68, 20)
        Me.fechaInicio.Name = "fechaInicio"
        Me.fechaInicio.Size = New System.Drawing.Size(154, 21)
        Me.fechaInicio.TabIndex = 320
        Me.fechaInicio.Value = New Date(2014, 1, 2, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(251, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 321
        Me.Label3.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 319
        Me.Label4.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "HISTÓRICO METAS CUMPLIDAS"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.chart_search_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(856, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________"
        '
        'dgIdEmpleado
        '
        Me.dgIdEmpleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgIdEmpleado.Frozen = True
        Me.dgIdEmpleado.HeaderText = "IdEmpleado"
        Me.dgIdEmpleado.Name = "dgIdEmpleado"
        Me.dgIdEmpleado.Visible = False
        '
        'dgEmpleado
        '
        Me.dgEmpleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgEmpleado.Frozen = True
        Me.dgEmpleado.HeaderText = "Empleado"
        Me.dgEmpleado.Name = "dgEmpleado"
        Me.dgEmpleado.Width = 280
        '
        'dgFechaMeta
        '
        Me.dgFechaMeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgFechaMeta.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgFechaMeta.HeaderText = "Fecha Meta"
        Me.dgFechaMeta.Name = "dgFechaMeta"
        Me.dgFechaMeta.Width = 90
        '
        'dgTotal
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgTotal.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTotal.HeaderText = "Total Aporte"
        Me.dgTotal.Name = "dgTotal"
        Me.dgTotal.Width = 120
        '
        'dgMeta
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgMeta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMeta.HeaderText = "Meta Alcanzada"
        Me.dgMeta.Name = "dgMeta"
        Me.dgMeta.Width = 90
        '
        'dgPorcentaje
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgPorcentaje.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgPorcentaje.HeaderText = "Aumento Salarial"
        Me.dgPorcentaje.Name = "dgPorcentaje"
        Me.dgPorcentaje.Width = 90
        '
        'FormMetaHistorico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormMetaHistorico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgvHistorico As DataGridView
    Friend WithEvents fechaFin As DateTimePicker
    Friend WithEvents fechaInicio As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dgIdEmpleado As DataGridViewTextBoxColumn
    Friend WithEvents dgEmpleado As DataGridViewTextBoxColumn
    Friend WithEvents dgFechaMeta As DataGridViewTextBoxColumn
    Friend WithEvents dgTotal As DataGridViewTextBoxColumn
    Friend WithEvents dgMeta As DataGridViewTextBoxColumn
    Friend WithEvents dgPorcentaje As DataGridViewTextBoxColumn
End Class
