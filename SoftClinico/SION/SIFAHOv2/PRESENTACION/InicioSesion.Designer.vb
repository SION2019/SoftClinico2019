<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InicioSesion
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InicioSesion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.foto = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Textusuario = New System.Windows.Forms.TextBox()
        Me.Textcontraseña = New System.Windows.Forms.TextBox()
        Me.Combopunto = New System.Windows.Forms.ComboBox()
        Me.ComboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CANCEL = New System.Windows.Forms.Button()
        Me.Ok = New System.Windows.Forms.Button()
        Me.barraestadopp = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barraestadopp.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.foto)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Textusuario)
        Me.GroupBox1.Controls.Add(Me.Textcontraseña)
        Me.GroupBox1.Controls.Add(Me.Combopunto)
        Me.GroupBox1.Controls.Add(Me.ComboEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CANCEL)
        Me.GroupBox1.Controls.Add(Me.Ok)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 256)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INICIO DE SESIÓN"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Celer.My.Resources.Resources.CHInicio
        Me.PictureBox2.Location = New System.Drawing.Point(71, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(399, 75)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'foto
        '
        Me.foto.BackColor = System.Drawing.Color.Gray
        Me.foto.Image = Global.Celer.My.Resources.Resources.usuario
        Me.foto.Location = New System.Drawing.Point(35, 111)
        Me.foto.Name = "foto"
        Me.foto.Size = New System.Drawing.Size(106, 120)
        Me.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.foto.TabIndex = 0
        Me.foto.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Location = New System.Drawing.Point(33, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(110, 125)
        Me.Panel1.TabIndex = 11
        '
        'Textusuario
        '
        Me.Textusuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Textusuario.Location = New System.Drawing.Point(287, 111)
        Me.Textusuario.Name = "Textusuario"
        Me.Textusuario.Size = New System.Drawing.Size(230, 21)
        Me.Textusuario.TabIndex = 0
        '
        'Textcontraseña
        '
        Me.Textcontraseña.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Textcontraseña.Location = New System.Drawing.Point(287, 137)
        Me.Textcontraseña.Name = "Textcontraseña"
        Me.Textcontraseña.Size = New System.Drawing.Size(230, 21)
        Me.Textcontraseña.TabIndex = 1
        Me.Textcontraseña.UseSystemPasswordChar = True
        '
        'Combopunto
        '
        Me.Combopunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combopunto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Combopunto.FormattingEnabled = True
        Me.Combopunto.Location = New System.Drawing.Point(287, 189)
        Me.Combopunto.Name = "Combopunto"
        Me.Combopunto.Size = New System.Drawing.Size(230, 24)
        Me.Combopunto.TabIndex = 3
        '
        'ComboEmpresa
        '
        Me.ComboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpresa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboEmpresa.FormattingEnabled = True
        Me.ComboEmpresa.Location = New System.Drawing.Point(287, 163)
        Me.ComboEmpresa.Name = "ComboEmpresa"
        Me.ComboEmpresa.Size = New System.Drawing.Size(230, 24)
        Me.ComboEmpresa.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(166, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Punto de servicio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(213, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Empresa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(198, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(220, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario:"
        '
        'CANCEL
        '
        Me.CANCEL.ForeColor = System.Drawing.Color.Black
        Me.CANCEL.Location = New System.Drawing.Point(434, 215)
        Me.CANCEL.Name = "CANCEL"
        Me.CANCEL.Size = New System.Drawing.Size(84, 23)
        Me.CANCEL.TabIndex = 5
        Me.CANCEL.Text = "Salir"
        Me.CANCEL.UseVisualStyleBackColor = True
        '
        'Ok
        '
        Me.Ok.ForeColor = System.Drawing.Color.Black
        Me.Ok.Location = New System.Drawing.Point(286, 215)
        Me.Ok.Name = "Ok"
        Me.Ok.Size = New System.Drawing.Size(129, 23)
        Me.Ok.TabIndex = 4
        Me.Ok.Text = "Entrar"
        Me.Ok.UseVisualStyleBackColor = True
        '
        'barraestadopp
        '
        Me.barraestadopp.BackColor = System.Drawing.Color.LightSkyBlue
        Me.barraestadopp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.barraestadopp.Location = New System.Drawing.Point(0, 286)
        Me.barraestadopp.Name = "barraestadopp"
        Me.barraestadopp.Size = New System.Drawing.Size(560, 22)
        Me.barraestadopp.TabIndex = 1
        Me.barraestadopp.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(360, 17)
        Me.ToolStripStatusLabel1.Text = "Bienvenidos a Celer Versión. 2.0. ©  Todos los derechos reservados "
        '
        'Timer1
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Location = New System.Drawing.Point(0, -6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(560, 286)
        Me.Panel2.TabIndex = 3
        '
        'InicioSesion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(560, 308)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.barraestadopp)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(560, 308)
        Me.MinimumSize = New System.Drawing.Size(560, 308)
        Me.Name = "InicioSesion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraestadopp.ResumeLayout(False)
        Me.barraestadopp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CANCEL As Button
    Friend WithEvents Ok As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents foto As PictureBox
    Friend WithEvents barraestadopp As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Textusuario As TextBox
    Friend WithEvents Textcontraseña As TextBox
    Friend WithEvents Combopunto As ComboBox
    Friend WithEvents ComboEmpresa As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel2 As Panel
End Class
