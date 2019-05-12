<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPlantillaArchivo
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCodigoManual = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvPlantilla = New System.Windows.Forms.DataGridView()
        Me.dgcodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgAgregar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.gbPlantilla = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fechaElectro = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPlantilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPlantilla.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ruta"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 58
        '
        'txtCodigoManual
        '
        Me.txtCodigoManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCodigoManual.Location = New System.Drawing.Point(6, 13)
        Me.txtCodigoManual.Name = "txtCodigoManual"
        Me.txtCodigoManual.Size = New System.Drawing.Size(114, 21)
        Me.txtCodigoManual.TabIndex = 66
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(126, 13)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(651, 21)
        Me.txtDescripcion.TabIndex = 67
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtCodigoManual)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(783, 43)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgvPlantilla
        '
        Me.dgvPlantilla.AllowUserToAddRows = False
        Me.dgvPlantilla.AllowUserToDeleteRows = False
        Me.dgvPlantilla.AllowUserToResizeColumns = False
        Me.dgvPlantilla.AllowUserToResizeRows = False
        Me.dgvPlantilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPlantilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPlantilla.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPlantilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPlantilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlantilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcodigo, Me.dgDescripcion, Me.dgAgregar})
        Me.dgvPlantilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPlantilla.Location = New System.Drawing.Point(3, 16)
        Me.dgvPlantilla.MultiSelect = False
        Me.dgvPlantilla.Name = "dgvPlantilla"
        Me.dgvPlantilla.RowHeadersVisible = False
        Me.dgvPlantilla.Size = New System.Drawing.Size(777, 229)
        Me.dgvPlantilla.TabIndex = 7
        '
        'dgcodigo
        '
        Me.dgcodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgcodigo.HeaderText = "Codigo"
        Me.dgcodigo.Name = "dgcodigo"
        Me.dgcodigo.Visible = False
        '
        'dgDescripcion
        '
        Me.dgDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgDescripcion.HeaderText = "Descripción"
        Me.dgDescripcion.Name = "dgDescripcion"
        '
        'dgAgregar
        '
        Me.dgAgregar.HeaderText = "Cargar"
        Me.dgAgregar.Image = Global.Celer.My.Resources.Resources.Actions_go_up_icon
        Me.dgAgregar.Name = "dgAgregar"
        Me.dgAgregar.Width = 50
        '
        'gbPlantilla
        '
        Me.gbPlantilla.Controls.Add(Me.dgvPlantilla)
        Me.gbPlantilla.Location = New System.Drawing.Point(8, 116)
        Me.gbPlantilla.Name = "gbPlantilla"
        Me.gbPlantilla.Size = New System.Drawing.Size(783, 248)
        Me.gbPlantilla.TabIndex = 1
        Me.gbPlantilla.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "PLANTILLA ARCHIVO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(5, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(751, 20)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________"
        '
        'fechaElectro
        '
        Me.fechaElectro.CustomFormat = "dd//MM/yyyy HH:mm:ss"
        Me.fechaElectro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaElectro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaElectro.Location = New System.Drawing.Point(626, 90)
        Me.fechaElectro.Name = "fechaElectro"
        Me.fechaElectro.Size = New System.Drawing.Size(159, 21)
        Me.fechaElectro.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(482, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 15)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Fecha resultado electro:"
        '
        'FormPlantillaArchivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(801, 370)
        Me.Controls.Add(Me.fechaElectro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbPlantilla)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(817, 409)
        Me.MinimumSize = New System.Drawing.Size(817, 409)
        Me.Name = "FormPlantillaArchivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPlantilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPlantilla.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents txtCodigoManual As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvPlantilla As DataGridView
    Friend WithEvents dgcodigo As DataGridViewTextBoxColumn
    Friend WithEvents dgDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents dgAgregar As DataGridViewImageColumn
    Friend WithEvents gbPlantilla As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents fechaElectro As DateTimePicker
    Friend WithEvents Label3 As Label
End Class
