<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Determinar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Determinar))
        Me.btsalir = New System.Windows.Forms.Button()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.btaceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCantHora = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.datetimeSalidaD = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.datetimeEntradaD = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.comboconvencion = New System.Windows.Forms.ComboBox()
        Me.datetimeSalida = New System.Windows.Forms.DateTimePicker()
        Me.datetimeEntrada = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPuntoServicio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btsalir
        '
        Me.btsalir.BackColor = System.Drawing.Color.White
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btsalir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsalir.ForeColor = System.Drawing.Color.Black
        Me.btsalir.Location = New System.Drawing.Point(157, 202)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(89, 34)
        Me.btsalir.TabIndex = 34
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btsalir.UseVisualStyleBackColor = False
        '
        'bteliminar
        '
        Me.bteliminar.BackColor = System.Drawing.Color.White
        Me.bteliminar.BackgroundImage = CType(resources.GetObject("bteliminar.BackgroundImage"), System.Drawing.Image)
        Me.bteliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bteliminar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bteliminar.ForeColor = System.Drawing.Color.DimGray
        Me.bteliminar.Location = New System.Drawing.Point(120, 202)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(36, 34)
        Me.bteliminar.TabIndex = 26
        Me.bteliminar.UseVisualStyleBackColor = False
        '
        'btaceptar
        '
        Me.btaceptar.BackColor = System.Drawing.Color.White
        Me.btaceptar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btaceptar.ForeColor = System.Drawing.Color.Black
        Me.btaceptar.Image = Global.Celer.My.Resources.Resources.OK
        Me.btaceptar.Location = New System.Drawing.Point(30, 202)
        Me.btaceptar.Name = "btaceptar"
        Me.btaceptar.Size = New System.Drawing.Size(89, 34)
        Me.btaceptar.TabIndex = 25
        Me.btaceptar.Text = "Aplicar"
        Me.btaceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btaceptar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 20)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "CORREGIR HORARIOS LABORALES "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Working_Schedule55555
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPuntoServicio)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCantHora)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.datetimeSalidaD)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.datetimeEntradaD)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.comboconvencion)
        Me.GroupBox1.Controls.Add(Me.datetimeSalida)
        Me.GroupBox1.Controls.Add(Me.datetimeEntrada)
        Me.GroupBox1.Controls.Add(Me.btsalir)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.bteliminar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btaceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 245)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'txtCantHora
        '
        Me.txtCantHora.Location = New System.Drawing.Point(99, 111)
        Me.txtCantHora.Name = "txtCantHora"
        Me.txtCantHora.ReadOnly = True
        Me.txtCantHora.Size = New System.Drawing.Size(166, 20)
        Me.txtCantHora.TabIndex = 44
        Me.txtCantHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Total Hrs: "
        '
        'datetimeSalidaD
        '
        Me.datetimeSalidaD.CustomFormat = "  hh:mm:ss tt   dd/MM/yyyy"
        Me.datetimeSalidaD.Enabled = False
        Me.datetimeSalidaD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimeSalidaD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimeSalidaD.Location = New System.Drawing.Point(99, 63)
        Me.datetimeSalidaD.Name = "datetimeSalidaD"
        Me.datetimeSalidaD.ShowUpDown = True
        Me.datetimeSalidaD.Size = New System.Drawing.Size(166, 20)
        Me.datetimeSalidaD.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 14)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Sal. Descanso: "
        '
        'datetimeEntradaD
        '
        Me.datetimeEntradaD.CustomFormat = "  hh:mm:ss tt   dd/MM/yyyy"
        Me.datetimeEntradaD.Enabled = False
        Me.datetimeEntradaD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimeEntradaD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimeEntradaD.Location = New System.Drawing.Point(99, 38)
        Me.datetimeEntradaD.Name = "datetimeEntradaD"
        Me.datetimeEntradaD.ShowUpDown = True
        Me.datetimeEntradaD.Size = New System.Drawing.Size(166, 20)
        Me.datetimeEntradaD.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Ent. Descanso: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 16)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Convención:"
        '
        'comboconvencion
        '
        Me.comboconvencion.DropDownHeight = 300
        Me.comboconvencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboconvencion.DropDownWidth = 200
        Me.comboconvencion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboconvencion.FormattingEnabled = True
        Me.comboconvencion.IntegralHeight = False
        Me.comboconvencion.Location = New System.Drawing.Point(99, 159)
        Me.comboconvencion.Name = "comboconvencion"
        Me.comboconvencion.Size = New System.Drawing.Size(166, 22)
        Me.comboconvencion.TabIndex = 37
        '
        'datetimeSalida
        '
        Me.datetimeSalida.CustomFormat = "  hh:mm:ss tt   dd/MM/yyyy"
        Me.datetimeSalida.Enabled = False
        Me.datetimeSalida.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimeSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimeSalida.Location = New System.Drawing.Point(99, 87)
        Me.datetimeSalida.Name = "datetimeSalida"
        Me.datetimeSalida.ShowUpDown = True
        Me.datetimeSalida.Size = New System.Drawing.Size(166, 20)
        Me.datetimeSalida.TabIndex = 36
        '
        'datetimeEntrada
        '
        Me.datetimeEntrada.CustomFormat = "  hh:mm:ss tt   dd/MM/yyyy"
        Me.datetimeEntrada.Enabled = False
        Me.datetimeEntrada.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimeEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimeEntrada.Location = New System.Drawing.Point(99, 13)
        Me.datetimeEntrada.Name = "datetimeEntrada"
        Me.datetimeEntrada.ShowUpDown = True
        Me.datetimeEntrada.Size = New System.Drawing.Size(166, 20)
        Me.datetimeEntrada.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 14)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Salida Turno: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 14)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Entrada Turno: "
        '
        'txtPuntoServicio
        '
        Me.txtPuntoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuntoServicio.Location = New System.Drawing.Point(99, 135)
        Me.txtPuntoServicio.Name = "txtPuntoServicio"
        Me.txtPuntoServicio.ReadOnly = True
        Me.txtPuntoServicio.Size = New System.Drawing.Size(166, 18)
        Me.txtPuntoServicio.TabIndex = 46
        Me.txtPuntoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "P. de Servicio:"
        '
        'Form_Determinar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(304, 311)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(320, 350)
        Me.MinimumSize = New System.Drawing.Size(320, 350)
        Me.Name = "Form_Determinar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btsalir As Button
    Friend WithEvents bteliminar As Button
    Friend WithEvents btaceptar As Button
    Public WithEvents Label2 As Label
    Public WithEvents Label3 As Label
    Public WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents comboconvencion As ComboBox
    Friend WithEvents datetimeSalida As DateTimePicker
    Friend WithEvents datetimeEntrada As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents datetimeSalidaD As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents datetimeEntradaD As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCantHora As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPuntoServicio As TextBox
    Friend WithEvents Label6 As Label
End Class
