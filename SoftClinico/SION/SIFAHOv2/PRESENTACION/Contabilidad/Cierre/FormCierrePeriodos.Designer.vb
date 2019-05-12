<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCierrePeriodos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCierrePeriodos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvCuentas = New System.Windows.Forms.DataGridView()
        Me.dgfecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgAnulado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btCerrarAño = New System.Windows.Forms.Button()
        Me.btAbrirAño = New System.Windows.Forms.Button()
        Me.btAbrirMes = New System.Windows.Forms.Button()
        Me.btCerrarMes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fechaCierre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dgvCuentas)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(907, 492)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'fechaCierre
        '
        Me.fechaCierre.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaCierre.CalendarMonthBackground = System.Drawing.SystemColors.MenuHighlight
        Me.fechaCierre.CustomFormat = "dd /MMMM/ yyyy"
        Me.fechaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaCierre.Location = New System.Drawing.Point(566, 38)
        Me.fechaCierre.MinDate = New Date(2014, 1, 1, 0, 0, 0, 0)
        Me.fechaCierre.Name = "fechaCierre"
        Me.fechaCierre.Size = New System.Drawing.Size(151, 22)
        Me.fechaCierre.TabIndex = 46
        Me.fechaCierre.Value = New Date(2014, 1, 2, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(590, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Seleccione fecha"
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AllowUserToAddRows = False
        Me.dgvCuentas.AllowUserToResizeColumns = False
        Me.dgvCuentas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvCuentas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCuentas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgfecha, Me.dgDetalle, Me.dgAnulado})
        Me.dgvCuentas.Location = New System.Drawing.Point(4, 11)
        Me.dgvCuentas.MultiSelect = False
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.RowHeadersVisible = False
        Me.dgvCuentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuentas.Size = New System.Drawing.Size(556, 475)
        Me.dgvCuentas.TabIndex = 49
        '
        'dgfecha
        '
        Me.dgfecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgfecha.HeaderText = "Fecha"
        Me.dgfecha.Name = "dgfecha"
        Me.dgfecha.Width = 63
        '
        'dgDetalle
        '
        Me.dgDetalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgDetalle.HeaderText = "Detalle"
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.Width = 400
        '
        'dgAnulado
        '
        Me.dgAnulado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgAnulado.HeaderText = "Cerrado"
        Me.dgAnulado.Name = "dgAnulado"
        Me.dgAnulado.Width = 74
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btCerrarAño)
        Me.GroupBox2.Controls.Add(Me.btAbrirAño)
        Me.GroupBox2.Controls.Add(Me.btAbrirMes)
        Me.GroupBox2.Controls.Add(Me.btCerrarMes)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(733, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(168, 287)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'btCerrarAño
        '
        Me.btCerrarAño.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btCerrarAño.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrarAño.Image = Global.Celer.My.Resources.Resources.july
        Me.btCerrarAño.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCerrarAño.Location = New System.Drawing.Point(10, 215)
        Me.btCerrarAño.Name = "btCerrarAño"
        Me.btCerrarAño.Size = New System.Drawing.Size(152, 57)
        Me.btCerrarAño.TabIndex = 43
        Me.btCerrarAño.Text = "Cerrar todo el año"
        Me.btCerrarAño.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btCerrarAño.UseVisualStyleBackColor = False
        '
        'btAbrirAño
        '
        Me.btAbrirAño.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btAbrirAño.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAbrirAño.Image = Global.Celer.My.Resources.Resources.Calendar_icon1
        Me.btAbrirAño.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAbrirAño.Location = New System.Drawing.Point(10, 150)
        Me.btAbrirAño.Name = "btAbrirAño"
        Me.btAbrirAño.Size = New System.Drawing.Size(152, 57)
        Me.btAbrirAño.TabIndex = 50
        Me.btAbrirAño.Text = "Abrir todo el año"
        Me.btAbrirAño.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAbrirAño.UseVisualStyleBackColor = False
        '
        'btAbrirMes
        '
        Me.btAbrirMes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btAbrirMes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAbrirMes.Image = Global.Celer.My.Resources.Resources.Calendar_Blue_icon
        Me.btAbrirMes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAbrirMes.Location = New System.Drawing.Point(10, 20)
        Me.btAbrirMes.Name = "btAbrirMes"
        Me.btAbrirMes.Size = New System.Drawing.Size(152, 57)
        Me.btAbrirMes.TabIndex = 47
        Me.btAbrirMes.Text = "Abrir todo el mes"
        Me.btAbrirMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAbrirMes.UseVisualStyleBackColor = False
        '
        'btCerrarMes
        '
        Me.btCerrarMes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btCerrarMes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrarMes.Image = Global.Celer.My.Resources.Resources.event_icon
        Me.btCerrarMes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCerrarMes.Location = New System.Drawing.Point(10, 85)
        Me.btCerrarMes.Name = "btCerrarMes"
        Me.btCerrarMes.Size = New System.Drawing.Size(152, 57)
        Me.btCerrarMes.TabIndex = 48
        Me.btCerrarMes.Text = "Cerrar todo el mes"
        Me.btCerrarMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btCerrarMes.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "CIERRE DE PERIODOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Calender_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label3.Location = New System.Drawing.Point(54, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(856, 20)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "_________________________________________________________________________________" &
    "________________________________________"
        '
        'FormCierrePeriodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormCierrePeriodos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents fechaCierre As DateTimePicker
    Friend WithEvents btAbrirAño As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btCerrarMes As Button
    Friend WithEvents btAbrirMes As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btCerrarAño As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvCuentas As DataGridView
    Friend WithEvents dgfecha As DataGridViewTextBoxColumn
    Friend WithEvents dgDetalle As DataGridViewTextBoxColumn
    Friend WithEvents dgAnulado As DataGridViewCheckBoxColumn
End Class
