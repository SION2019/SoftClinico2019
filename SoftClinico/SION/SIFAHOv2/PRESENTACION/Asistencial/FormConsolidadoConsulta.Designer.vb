<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsolidadoConsulta
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtFin = New System.Windows.Forms.DateTimePicker()
        Me.dgvConsolidado = New System.Windows.Forms.DataGridView()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btOpcionTraslado = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textBusqueda = New System.Windows.Forms.TextBox()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbQuitar = New System.Windows.Forms.Label()
        Me.rbConsolidado = New System.Windows.Forms.RadioButton()
        Me.rbGeneral = New System.Windows.Forms.RadioButton()
        Me.btBusquedaEmpleado = New System.Windows.Forms.Button()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.cmbAreaServicio = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.checklist48
        Me.PictureBox1.Location = New System.Drawing.Point(2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10056
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 16)
        Me.Label1.TabIndex = 10054
        Me.Label1.Text = "Informe de consulta de pacientes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(44, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1010, 20)
        Me.Label2.TabIndex = 10055
        Me.Label2.Text = "_________________________________________________________________________________" &
    "______________________________________________________________"
        '
        'dtInicio
        '
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(54, 14)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(104, 20)
        Me.dtInicio.TabIndex = 10057
        '
        'dtFin
        '
        Me.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFin.Location = New System.Drawing.Point(212, 14)
        Me.dtFin.Name = "dtFin"
        Me.dtFin.Size = New System.Drawing.Size(105, 20)
        Me.dtFin.TabIndex = 10058
        '
        'dgvConsolidado
        '
        Me.dgvConsolidado.AllowUserToAddRows = False
        Me.dgvConsolidado.AllowUserToDeleteRows = False
        Me.dgvConsolidado.AllowUserToResizeColumns = False
        Me.dgvConsolidado.AllowUserToResizeRows = False
        Me.dgvConsolidado.BackgroundColor = System.Drawing.Color.White
        Me.dgvConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsolidado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsolidado.Location = New System.Drawing.Point(3, 16)
        Me.dgvConsolidado.Name = "dgvConsolidado"
        Me.dgvConsolidado.ReadOnly = True
        Me.dgvConsolidado.RowHeadersVisible = False
        Me.dgvConsolidado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConsolidado.Size = New System.Drawing.Size(1086, 398)
        Me.dgvConsolidado.TabIndex = 10059
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(4, 15)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(49, 15)
        Me.Label38.TabIndex = 10060
        Me.Label38.Text = "Desde :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(169, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 10061
        Me.Label3.Text = "Hasta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvConsolidado)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1092, 417)
        Me.GroupBox1.TabIndex = 10062
        Me.GroupBox1.TabStop = False
        '
        'btOpcionTraslado
        '
        Me.btOpcionTraslado.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionTraslado.Image = Global.Celer.My.Resources.Resources.Printer_icon__1_
        Me.btOpcionTraslado.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btOpcionTraslado.Location = New System.Drawing.Point(1000, 9)
        Me.btOpcionTraslado.Name = "btOpcionTraslado"
        Me.btOpcionTraslado.Size = New System.Drawing.Size(84, 34)
        Me.btOpcionTraslado.TabIndex = 60016
        Me.btOpcionTraslado.Text = "Imprimir"
        Me.btOpcionTraslado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionTraslado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.textBusqueda)
        Me.GroupBox2.Controls.Add(Me.lblFiltro)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.btOpcionTraslado)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1105, 502)
        Me.GroupBox2.TabIndex = 60017
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox4.Controls.Add(Me.LblNumero)
        Me.GroupBox4.Controls.Add(Me.LblCantidad)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 463)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1092, 33)
        Me.GroupBox4.TabIndex = 10065
        Me.GroupBox4.TabStop = False
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.Location = New System.Drawing.Point(1056, 12)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(15, 16)
        Me.LblNumero.TabIndex = 10
        Me.LblNumero.Text = "#"
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad.Location = New System.Drawing.Point(913, 12)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(141, 16)
        Me.LblCantidad.TabIndex = 9
        Me.LblCantidad.Text = "Cantidad de pacientes:"
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
        'textBusqueda
        '
        Me.textBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBusqueda.Location = New System.Drawing.Point(102, 13)
        Me.textBusqueda.MaxLength = 100
        Me.textBusqueda.Name = "textBusqueda"
        Me.textBusqueda.Size = New System.Drawing.Size(445, 21)
        Me.textBusqueda.TabIndex = 10063
        '
        'lblFiltro
        '
        Me.lblFiltro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltro.ForeColor = System.Drawing.Color.Black
        Me.lblFiltro.Location = New System.Drawing.Point(5, 15)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(98, 15)
        Me.lblFiltro.TabIndex = 10064
        Me.lblFiltro.Text = "Filtrar Pacientes:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbQuitar)
        Me.GroupBox3.Controls.Add(Me.rbConsolidado)
        Me.GroupBox3.Controls.Add(Me.rbGeneral)
        Me.GroupBox3.Controls.Add(Me.btBusquedaEmpleado)
        Me.GroupBox3.Controls.Add(Me.txtEmpleado)
        Me.GroupBox3.Controls.Add(Me.cmbAreaServicio)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.dtInicio)
        Me.GroupBox3.Controls.Add(Me.dtFin)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1105, 48)
        Me.GroupBox3.TabIndex = 60018
        Me.GroupBox3.TabStop = False
        '
        'lbQuitar
        '
        Me.lbQuitar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbQuitar.AutoSize = True
        Me.lbQuitar.BackColor = System.Drawing.Color.Transparent
        Me.lbQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQuitar.ForeColor = System.Drawing.Color.Red
        Me.lbQuitar.Location = New System.Drawing.Point(1045, 18)
        Me.lbQuitar.Name = "lbQuitar"
        Me.lbQuitar.Size = New System.Drawing.Size(16, 15)
        Me.lbQuitar.TabIndex = 60024
        Me.lbQuitar.Text = "X"
        Me.lbQuitar.Visible = False
        '
        'rbConsolidado
        '
        Me.rbConsolidado.AutoSize = True
        Me.rbConsolidado.Location = New System.Drawing.Point(669, 17)
        Me.rbConsolidado.Name = "rbConsolidado"
        Me.rbConsolidado.Size = New System.Drawing.Size(83, 17)
        Me.rbConsolidado.TabIndex = 60022
        Me.rbConsolidado.Text = "Consolidado"
        Me.rbConsolidado.UseVisualStyleBackColor = True
        '
        'rbGeneral
        '
        Me.rbGeneral.AutoSize = True
        Me.rbGeneral.Checked = True
        Me.rbGeneral.Location = New System.Drawing.Point(601, 17)
        Me.rbGeneral.Name = "rbGeneral"
        Me.rbGeneral.Size = New System.Drawing.Size(62, 17)
        Me.rbGeneral.TabIndex = 60021
        Me.rbGeneral.TabStop = True
        Me.rbGeneral.Text = "General"
        Me.rbGeneral.UseVisualStyleBackColor = True
        '
        'btBusquedaEmpleado
        '
        Me.btBusquedaEmpleado.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBusquedaEmpleado.Location = New System.Drawing.Point(1067, 15)
        Me.btBusquedaEmpleado.Name = "btBusquedaEmpleado"
        Me.btBusquedaEmpleado.Size = New System.Drawing.Size(25, 23)
        Me.btBusquedaEmpleado.TabIndex = 60020
        Me.btBusquedaEmpleado.UseVisualStyleBackColor = True
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEmpleado.Location = New System.Drawing.Point(756, 16)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(309, 21)
        Me.txtEmpleado.TabIndex = 60019
        Me.txtEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbAreaServicio
        '
        Me.cmbAreaServicio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAreaServicio.BackColor = System.Drawing.Color.White
        Me.cmbAreaServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreaServicio.ForeColor = System.Drawing.Color.Black
        Me.cmbAreaServicio.FormattingEnabled = True
        Me.cmbAreaServicio.Location = New System.Drawing.Point(422, 14)
        Me.cmbAreaServicio.Name = "cmbAreaServicio"
        Me.cmbAreaServicio.Size = New System.Drawing.Size(168, 23)
        Me.cmbAreaServicio.TabIndex = 60018
        '
        'Label29
        '
        Me.Label29.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(325, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 15)
        Me.Label29.TabIndex = 60017
        Me.Label29.Text = "Area de servicio:"
        '
        'FormConsolidadoConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1118, 591)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1134, 630)
        Me.MinimumSize = New System.Drawing.Size(1134, 630)
        Me.Name = "FormConsolidadoConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtInicio As DateTimePicker
    Friend WithEvents dtFin As DateTimePicker
    Friend WithEvents dgvConsolidado As DataGridView
    Public WithEvents Label38 As Label
    Public WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents btOpcionTraslado As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbAreaServicio As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents textBusqueda As TextBox
    Friend WithEvents lblFiltro As Label
    Friend WithEvents btBusquedaEmpleado As Button
    Friend WithEvents txtEmpleado As TextBox
    Friend WithEvents rbConsolidado As RadioButton
    Friend WithEvents rbGeneral As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LblNumero As Label
    Friend WithEvents LblCantidad As Label
    Friend WithEvents lbQuitar As Label
End Class
