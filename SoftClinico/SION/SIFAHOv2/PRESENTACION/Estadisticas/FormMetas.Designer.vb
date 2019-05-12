<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMetas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSuperada = New System.Windows.Forms.Label()
        Me.lblDescripcionMeta = New System.Windows.Forms.Label()
        Me.picSostenimiento = New System.Windows.Forms.PictureBox()
        Me.picAporte = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtProximaMeta = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDiasFaltantes = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiasCorridos = New System.Windows.Forms.TextBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.txtAporteActual = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picSostenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.lblSuperada)
        Me.GroupBox1.Controls.Add(Me.lblDescripcionMeta)
        Me.GroupBox1.Controls.Add(Me.picSostenimiento)
        Me.GroupBox1.Controls.Add(Me.picAporte)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDiasFaltantes)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDiasCorridos)
        Me.GroupBox1.Controls.Add(Me.txtnombre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PictureBox7)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 491)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'lblSuperada
        '
        Me.lblSuperada.AutoSize = True
        Me.lblSuperada.BackColor = System.Drawing.Color.White
        Me.lblSuperada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuperada.ForeColor = System.Drawing.Color.Green
        Me.lblSuperada.Location = New System.Drawing.Point(615, 401)
        Me.lblSuperada.Name = "lblSuperada"
        Me.lblSuperada.Size = New System.Drawing.Size(75, 15)
        Me.lblSuperada.TabIndex = 31
        Me.lblSuperada.Text = "SUPERADA!"
        '
        'lblDescripcionMeta
        '
        Me.lblDescripcionMeta.AutoSize = True
        Me.lblDescripcionMeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionMeta.Location = New System.Drawing.Point(368, 401)
        Me.lblDescripcionMeta.Name = "lblDescripcionMeta"
        Me.lblDescripcionMeta.Size = New System.Drawing.Size(154, 15)
        Me.lblDescripcionMeta.TabIndex = 30
        Me.lblDescripcionMeta.Text = "Sostenimiento: $5.000.000"
        '
        'picSostenimiento
        '
        Me.picSostenimiento.Image = Global.Celer.My.Resources.Resources.LogoInicioCeler
        Me.picSostenimiento.Location = New System.Drawing.Point(576, 393)
        Me.picSostenimiento.Name = "picSostenimiento"
        Me.picSostenimiento.Size = New System.Drawing.Size(33, 30)
        Me.picSostenimiento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSostenimiento.TabIndex = 29
        Me.picSostenimiento.TabStop = False
        '
        'picAporte
        '
        Me.picAporte.Image = Global.Celer.My.Resources.Resources.logoC
        Me.picAporte.Location = New System.Drawing.Point(313, 84)
        Me.picAporte.Name = "picAporte"
        Me.picAporte.Size = New System.Drawing.Size(30, 407)
        Me.picAporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAporte.TabIndex = 28
        Me.picAporte.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtProximaMeta)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(250, 73)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Próxima Meta A:"
        '
        'txtProximaMeta
        '
        Me.txtProximaMeta.BackColor = System.Drawing.Color.White
        Me.txtProximaMeta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProximaMeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProximaMeta.ForeColor = System.Drawing.Color.Red
        Me.txtProximaMeta.Location = New System.Drawing.Point(10, 34)
        Me.txtProximaMeta.Name = "txtProximaMeta"
        Me.txtProximaMeta.ReadOnly = True
        Me.txtProximaMeta.Size = New System.Drawing.Size(232, 17)
        Me.txtProximaMeta.TabIndex = 27
        Me.txtProximaMeta.Text = "$35.000.000"
        Me.txtProximaMeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtAporteActual)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 73)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Aporte Actual:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Días Faltantes:"
        '
        'txtDiasFaltantes
        '
        Me.txtDiasFaltantes.BackColor = System.Drawing.Color.White
        Me.txtDiasFaltantes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDiasFaltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasFaltantes.Location = New System.Drawing.Point(140, 76)
        Me.txtDiasFaltantes.Name = "txtDiasFaltantes"
        Me.txtDiasFaltantes.ReadOnly = True
        Me.txtDiasFaltantes.Size = New System.Drawing.Size(40, 14)
        Me.txtDiasFaltantes.TabIndex = 25
        Me.txtDiasFaltantes.Text = "20"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Días Transcurridos:"
        '
        'txtDiasCorridos
        '
        Me.txtDiasCorridos.BackColor = System.Drawing.Color.White
        Me.txtDiasCorridos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDiasCorridos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasCorridos.Location = New System.Drawing.Point(140, 50)
        Me.txtDiasCorridos.Name = "txtDiasCorridos"
        Me.txtDiasCorridos.ReadOnly = True
        Me.txtDiasCorridos.Size = New System.Drawing.Size(40, 14)
        Me.txtDiasCorridos.TabIndex = 21
        Me.txtDiasCorridos.Text = "10"
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.Color.White
        Me.txtnombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(77, 23)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(295, 14)
        Me.txtnombre.TabIndex = 22
        Me.txtnombre.Text = "YULEIDY PEÑA MORALES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Nombre:"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.Celer.My.Resources.Resources.c22logo
        Me.PictureBox7.Location = New System.Drawing.Point(555, 11)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(72, 474)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 39
        Me.PictureBox7.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "METAS DEL EMPLEADO"
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
        Me.Label2.Size = New System.Drawing.Size(660, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "_________________________________________________________________________________" &
    "____________"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(21, 319)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(250, 97)
        Me.GroupBox4.TabIndex = 40
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Porcentaje de Aumento Salarial:"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BackColor = System.Drawing.Color.White
        Me.txtPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPorcentaje.Location = New System.Drawing.Point(10, 37)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.ReadOnly = True
        Me.txtPorcentaje.Size = New System.Drawing.Size(232, 31)
        Me.txtPorcentaje.TabIndex = 27
        Me.txtPorcentaje.Text = "15 %"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAporteActual
        '
        Me.txtAporteActual.BackColor = System.Drawing.Color.White
        Me.txtAporteActual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAporteActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAporteActual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtAporteActual.Location = New System.Drawing.Point(10, 32)
        Me.txtAporteActual.Name = "txtAporteActual"
        Me.txtAporteActual.ReadOnly = True
        Me.txtAporteActual.Size = New System.Drawing.Size(232, 22)
        Me.txtAporteActual.TabIndex = 26
        Me.txtAporteActual.Text = "$15.000.000"
        Me.txtAporteActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormMetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(725, 556)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.Name = "FormMetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picSostenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Friend WithEvents picSostenimiento As PictureBox
    Friend WithEvents picAporte As PictureBox
    Public WithEvents GroupBox3 As GroupBox
    Public WithEvents txtProximaMeta As TextBox
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label5 As Label
    Public WithEvents txtDiasFaltantes As TextBox
    Public WithEvents Label4 As Label
    Public WithEvents txtDiasCorridos As TextBox
    Public WithEvents txtnombre As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents lblDescripcionMeta As Label
    Public WithEvents lblSuperada As Label
    Friend WithEvents PictureBox7 As PictureBox
    Public WithEvents GroupBox4 As GroupBox
    Public WithEvents txtPorcentaje As TextBox
    Public WithEvents txtAporteActual As TextBox
End Class
