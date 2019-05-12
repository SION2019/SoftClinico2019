<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFacturaVSRadicado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFacturaVSRadicado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btLimpiar = New System.Windows.Forms.Button()
        Me.chbRadicado = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btbuscartercero = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvFactuVSRadicado = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtValorSinRadicar = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtvalorRadicado = New System.Windows.Forms.TextBox()
        Me.btexcel = New System.Windows.Forms.Button()
        Me.lbNumRegistro = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvFactuVSRadicado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 16)
        Me.Label1.TabIndex = 60041
        Me.Label1.Text = "INFORME DE FACTURAS VS RADICADOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(53, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1248, 20)
        Me.Label2.TabIndex = 60042
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.order_history_icon
        Me.PictureBox1.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60047
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btLimpiar)
        Me.GroupBox1.Controls.Add(Me.chbRadicado)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.btbuscartercero)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1295, 55)
        Me.GroupBox1.TabIndex = 60048
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1179, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 37)
        Me.Button1.TabIndex = 60070
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btLimpiar
        '
        Me.btLimpiar.Image = Global.Celer.My.Resources.Resources.Close_icon1
        Me.btLimpiar.Location = New System.Drawing.Point(1001, 22)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(25, 24)
        Me.btLimpiar.TabIndex = 60068
        Me.btLimpiar.UseVisualStyleBackColor = True
        Me.btLimpiar.Visible = False
        '
        'chbRadicado
        '
        Me.chbRadicado.AutoSize = True
        Me.chbRadicado.Location = New System.Drawing.Point(1055, 24)
        Me.chbRadicado.Name = "chbRadicado"
        Me.chbRadicado.Size = New System.Drawing.Size(104, 19)
        Me.chbRadicado.TabIndex = 60067
        Me.chbRadicado.Text = "No Radicados"
        Me.chbRadicado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 60066
        Me.Label3.Text = "Clientes:"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(427, 24)
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.ReadOnly = True
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(102, 21)
        Me.TxtCodigoCliente.TabIndex = 60065
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(561, 24)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(435, 21)
        Me.txtCliente.TabIndex = 60064
        '
        'btbuscartercero
        '
        Me.btbuscartercero.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btbuscartercero.Location = New System.Drawing.Point(532, 24)
        Me.btbuscartercero.Name = "btbuscartercero"
        Me.btbuscartercero.Size = New System.Drawing.Size(25, 23)
        Me.btbuscartercero.TabIndex = 60063
        Me.btbuscartercero.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtFechaInicio)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(177, 42)
        Me.GroupBox3.TabIndex = 60062
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha Inicio"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.CustomFormat = "ddMMMMyyyy  "
        Me.dtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaInicio.Location = New System.Drawing.Point(6, 16)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(165, 21)
        Me.dtFechaInicio.TabIndex = 10056
        Me.dtFechaInicio.Value = New Date(2018, 4, 10, 0, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtFechaFin)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(183, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(177, 42)
        Me.GroupBox4.TabIndex = 60061
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fecha Fin"
        '
        'dtFechaFin
        '
        Me.dtFechaFin.CustomFormat = "ddMMMMyyyy  "
        Me.dtFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaFin.Location = New System.Drawing.Point(6, 16)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(165, 21)
        Me.dtFechaFin.TabIndex = 10056
        Me.dtFechaFin.Value = New Date(2018, 4, 10, 0, 0, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvFactuVSRadicado)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1295, 457)
        Me.GroupBox2.TabIndex = 60049
        Me.GroupBox2.TabStop = False
        '
        'dgvFactuVSRadicado
        '
        Me.dgvFactuVSRadicado.AllowUserToAddRows = False
        Me.dgvFactuVSRadicado.AllowUserToDeleteRows = False
        Me.dgvFactuVSRadicado.AllowUserToResizeColumns = False
        Me.dgvFactuVSRadicado.AllowUserToResizeRows = False
        Me.dgvFactuVSRadicado.BackgroundColor = System.Drawing.Color.White
        Me.dgvFactuVSRadicado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFactuVSRadicado.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFactuVSRadicado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFactuVSRadicado.Location = New System.Drawing.Point(3, 16)
        Me.dgvFactuVSRadicado.Name = "dgvFactuVSRadicado"
        Me.dgvFactuVSRadicado.ReadOnly = True
        Me.dgvFactuVSRadicado.RowHeadersVisible = False
        Me.dgvFactuVSRadicado.Size = New System.Drawing.Size(1289, 438)
        Me.dgvFactuVSRadicado.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtValorSinRadicar)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 569)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(177, 42)
        Me.GroupBox5.TabIndex = 60062
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Valor sin Radicar"
        '
        'txtValorSinRadicar
        '
        Me.txtValorSinRadicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorSinRadicar.Location = New System.Drawing.Point(8, 16)
        Me.txtValorSinRadicar.Name = "txtValorSinRadicar"
        Me.txtValorSinRadicar.ReadOnly = True
        Me.txtValorSinRadicar.Size = New System.Drawing.Size(163, 21)
        Me.txtValorSinRadicar.TabIndex = 60066
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtvalorRadicado)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(191, 569)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(177, 42)
        Me.GroupBox6.TabIndex = 60063
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Valor Radicado"
        '
        'txtvalorRadicado
        '
        Me.txtvalorRadicado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalorRadicado.Location = New System.Drawing.Point(6, 16)
        Me.txtvalorRadicado.Name = "txtvalorRadicado"
        Me.txtvalorRadicado.ReadOnly = True
        Me.txtvalorRadicado.Size = New System.Drawing.Size(163, 21)
        Me.txtvalorRadicado.TabIndex = 60067
        '
        'btexcel
        '
        Me.btexcel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btexcel.Image = Global.Celer.My.Resources.Resources.Excel_icon__1_
        Me.btexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btexcel.Location = New System.Drawing.Point(372, 576)
        Me.btexcel.Name = "btexcel"
        Me.btexcel.Size = New System.Drawing.Size(105, 34)
        Me.btexcel.TabIndex = 60064
        Me.btexcel.Text = "  Exp. a excel"
        Me.btexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btexcel.UseVisualStyleBackColor = True
        '
        'lbNumRegistro
        '
        Me.lbNumRegistro.AutoSize = True
        Me.lbNumRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumRegistro.Location = New System.Drawing.Point(1208, 564)
        Me.lbNumRegistro.Name = "lbNumRegistro"
        Me.lbNumRegistro.Size = New System.Drawing.Size(81, 15)
        Me.lbNumRegistro.TabIndex = 60065
        Me.lbNumRegistro.Text = "Registros: Nº "
        '
        'FormFacturaVSRadicado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.lbNumRegistro)
        Me.Controls.Add(Me.btexcel)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "FormFacturaVSRadicado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvFactuVSRadicado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvFactuVSRadicado As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtFechaInicio As DateTimePicker
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtFechaFin As DateTimePicker
    Friend WithEvents Label3 As Label
    Public WithEvents TxtCodigoCliente As TextBox
    Public WithEvents txtCliente As TextBox
    Public WithEvents btbuscartercero As Button
    Friend WithEvents GroupBox5 As GroupBox
    Public WithEvents txtValorSinRadicar As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Public WithEvents txtvalorRadicado As TextBox
    Friend WithEvents chbRadicado As CheckBox
    Public WithEvents btLimpiar As Button
    Public WithEvents btexcel As Button
    Public WithEvents Button1 As Button
    Friend WithEvents lbNumRegistro As Label
End Class
