<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGlasgow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGlasgow))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gbRmotora = New System.Windows.Forms.GroupBox()
        Me.CheckBox_1_g3 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_2_g3 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_3_g3 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_4_g3 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_5_g3 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_6_g3 = New System.Windows.Forms.RadioButton()
        Me.gbRverbal = New System.Windows.Forms.GroupBox()
        Me.CheckBox_1_g2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_2_g2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_3_g2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_4_g2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_5_g2 = New System.Windows.Forms.RadioButton()
        Me.gbReaccion = New System.Windows.Forms.GroupBox()
        Me.CheckBox_1 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_3 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_4 = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbRmotora.SuspendLayout()
        Me.gbRverbal.SuspendLayout()
        Me.gbReaccion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(11, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(460, 30)
        Me.Button1.TabIndex = 925
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'gbRmotora
        '
        Me.gbRmotora.Controls.Add(Me.CheckBox_1_g3)
        Me.gbRmotora.Controls.Add(Me.CheckBox_2_g3)
        Me.gbRmotora.Controls.Add(Me.CheckBox_3_g3)
        Me.gbRmotora.Controls.Add(Me.CheckBox_4_g3)
        Me.gbRmotora.Controls.Add(Me.CheckBox_5_g3)
        Me.gbRmotora.Controls.Add(Me.CheckBox_6_g3)
        Me.gbRmotora.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbRmotora.ForeColor = System.Drawing.Color.Black
        Me.gbRmotora.Location = New System.Drawing.Point(322, 63)
        Me.gbRmotora.Name = "gbRmotora"
        Me.gbRmotora.Size = New System.Drawing.Size(149, 166)
        Me.gbRmotora.TabIndex = 924
        Me.gbRmotora.TabStop = False
        Me.gbRmotora.Text = "Respuesta Motora"
        '
        'CheckBox_1_g3
        '
        Me.CheckBox_1_g3.AutoSize = True
        Me.CheckBox_1_g3.Checked = True
        Me.CheckBox_1_g3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_1_g3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_1_g3.Location = New System.Drawing.Point(6, 141)
        Me.CheckBox_1_g3.Name = "CheckBox_1_g3"
        Me.CheckBox_1_g3.Size = New System.Drawing.Size(78, 19)
        Me.CheckBox_1_g3.TabIndex = 31
        Me.CheckBox_1_g3.TabStop = True
        Me.CheckBox_1_g3.Text = "1. Flacido"
        Me.CheckBox_1_g3.UseVisualStyleBackColor = True
        '
        'CheckBox_2_g3
        '
        Me.CheckBox_2_g3.AutoSize = True
        Me.CheckBox_2_g3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_2_g3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_2_g3.Location = New System.Drawing.Point(6, 116)
        Me.CheckBox_2_g3.Name = "CheckBox_2_g3"
        Me.CheckBox_2_g3.Size = New System.Drawing.Size(92, 19)
        Me.CheckBox_2_g3.TabIndex = 30
        Me.CheckBox_2_g3.Text = "2. Extension"
        Me.CheckBox_2_g3.UseVisualStyleBackColor = True
        '
        'CheckBox_3_g3
        '
        Me.CheckBox_3_g3.AutoSize = True
        Me.CheckBox_3_g3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_3_g3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_3_g3.Location = New System.Drawing.Point(6, 92)
        Me.CheckBox_3_g3.Name = "CheckBox_3_g3"
        Me.CheckBox_3_g3.Size = New System.Drawing.Size(78, 19)
        Me.CheckBox_3_g3.TabIndex = 29
        Me.CheckBox_3_g3.Text = "3. Flexion"
        Me.CheckBox_3_g3.UseVisualStyleBackColor = True
        '
        'CheckBox_4_g3
        '
        Me.CheckBox_4_g3.AutoSize = True
        Me.CheckBox_4_g3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_4_g3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_4_g3.Location = New System.Drawing.Point(6, 68)
        Me.CheckBox_4_g3.Name = "CheckBox_4_g3"
        Me.CheckBox_4_g3.Size = New System.Drawing.Size(116, 19)
        Me.CheckBox_4_g3.TabIndex = 28
        Me.CheckBox_4_g3.Text = "4. Respord dolor"
        Me.CheckBox_4_g3.UseVisualStyleBackColor = True
        '
        'CheckBox_5_g3
        '
        Me.CheckBox_5_g3.AutoSize = True
        Me.CheckBox_5_g3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_5_g3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_5_g3.Location = New System.Drawing.Point(6, 45)
        Me.CheckBox_5_g3.Name = "CheckBox_5_g3"
        Me.CheckBox_5_g3.Size = New System.Drawing.Size(133, 19)
        Me.CheckBox_5_g3.TabIndex = 27
        Me.CheckBox_5_g3.Text = "5. Localizador dolor"
        Me.CheckBox_5_g3.UseVisualStyleBackColor = True
        '
        'CheckBox_6_g3
        '
        Me.CheckBox_6_g3.AutoSize = True
        Me.CheckBox_6_g3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_6_g3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_6_g3.Location = New System.Drawing.Point(6, 23)
        Me.CheckBox_6_g3.Name = "CheckBox_6_g3"
        Me.CheckBox_6_g3.Size = New System.Drawing.Size(111, 19)
        Me.CheckBox_6_g3.TabIndex = 26
        Me.CheckBox_6_g3.Text = "6. Obedece Ord"
        Me.CheckBox_6_g3.UseVisualStyleBackColor = True
        '
        'gbRverbal
        '
        Me.gbRverbal.Controls.Add(Me.CheckBox_1_g2)
        Me.gbRverbal.Controls.Add(Me.CheckBox_2_g2)
        Me.gbRverbal.Controls.Add(Me.CheckBox_3_g2)
        Me.gbRverbal.Controls.Add(Me.CheckBox_4_g2)
        Me.gbRverbal.Controls.Add(Me.CheckBox_5_g2)
        Me.gbRverbal.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbRverbal.ForeColor = System.Drawing.Color.Black
        Me.gbRverbal.Location = New System.Drawing.Point(167, 63)
        Me.gbRverbal.Name = "gbRverbal"
        Me.gbRverbal.Size = New System.Drawing.Size(149, 166)
        Me.gbRverbal.TabIndex = 923
        Me.gbRverbal.TabStop = False
        Me.gbRverbal.Text = "Respuesta Verbal"
        '
        'CheckBox_1_g2
        '
        Me.CheckBox_1_g2.AutoSize = True
        Me.CheckBox_1_g2.Checked = True
        Me.CheckBox_1_g2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_1_g2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_1_g2.Location = New System.Drawing.Point(8, 116)
        Me.CheckBox_1_g2.Name = "CheckBox_1_g2"
        Me.CheckBox_1_g2.Size = New System.Drawing.Size(85, 19)
        Me.CheckBox_1_g2.TabIndex = 25
        Me.CheckBox_1_g2.TabStop = True
        Me.CheckBox_1_g2.Text = "1. Ninguna"
        Me.CheckBox_1_g2.UseVisualStyleBackColor = True
        '
        'CheckBox_2_g2
        '
        Me.CheckBox_2_g2.AutoSize = True
        Me.CheckBox_2_g2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_2_g2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_2_g2.Location = New System.Drawing.Point(8, 92)
        Me.CheckBox_2_g2.Name = "CheckBox_2_g2"
        Me.CheckBox_2_g2.Size = New System.Drawing.Size(119, 19)
        Me.CheckBox_2_g2.TabIndex = 24
        Me.CheckBox_2_g2.Text = "2. Ruido incompr"
        Me.CheckBox_2_g2.UseVisualStyleBackColor = True
        '
        'CheckBox_3_g2
        '
        Me.CheckBox_3_g2.AutoSize = True
        Me.CheckBox_3_g2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_3_g2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_3_g2.Location = New System.Drawing.Point(8, 68)
        Me.CheckBox_3_g2.Name = "CheckBox_3_g2"
        Me.CheckBox_3_g2.Size = New System.Drawing.Size(115, 19)
        Me.CheckBox_3_g2.TabIndex = 23
        Me.CheckBox_3_g2.Text = "3. Palab Inaprop"
        Me.CheckBox_3_g2.UseVisualStyleBackColor = True
        '
        'CheckBox_4_g2
        '
        Me.CheckBox_4_g2.AutoSize = True
        Me.CheckBox_4_g2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_4_g2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_4_g2.Location = New System.Drawing.Point(8, 45)
        Me.CheckBox_4_g2.Name = "CheckBox_4_g2"
        Me.CheckBox_4_g2.Size = New System.Drawing.Size(107, 19)
        Me.CheckBox_4_g2.TabIndex = 22
        Me.CheckBox_4_g2.Text = "4. Convert Conf"
        Me.CheckBox_4_g2.UseVisualStyleBackColor = True
        '
        'CheckBox_5_g2
        '
        Me.CheckBox_5_g2.AutoSize = True
        Me.CheckBox_5_g2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_5_g2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_5_g2.Location = New System.Drawing.Point(8, 23)
        Me.CheckBox_5_g2.Name = "CheckBox_5_g2"
        Me.CheckBox_5_g2.Size = New System.Drawing.Size(118, 19)
        Me.CheckBox_5_g2.TabIndex = 21
        Me.CheckBox_5_g2.Text = "5. Convers Orient"
        Me.CheckBox_5_g2.UseVisualStyleBackColor = True
        '
        'gbReaccion
        '
        Me.gbReaccion.Controls.Add(Me.CheckBox_1)
        Me.gbReaccion.Controls.Add(Me.CheckBox_2)
        Me.gbReaccion.Controls.Add(Me.CheckBox_3)
        Me.gbReaccion.Controls.Add(Me.CheckBox_4)
        Me.gbReaccion.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbReaccion.ForeColor = System.Drawing.Color.Black
        Me.gbReaccion.Location = New System.Drawing.Point(12, 63)
        Me.gbReaccion.Name = "gbReaccion"
        Me.gbReaccion.Size = New System.Drawing.Size(149, 166)
        Me.gbReaccion.TabIndex = 922
        Me.gbReaccion.TabStop = False
        Me.gbReaccion.Text = "Reacción Ocular"
        '
        'CheckBox_1
        '
        Me.CheckBox_1.AutoSize = True
        Me.CheckBox_1.Checked = True
        Me.CheckBox_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_1.Location = New System.Drawing.Point(17, 92)
        Me.CheckBox_1.Name = "CheckBox_1"
        Me.CheckBox_1.Size = New System.Drawing.Size(85, 19)
        Me.CheckBox_1.TabIndex = 20
        Me.CheckBox_1.TabStop = True
        Me.CheckBox_1.Text = "1. Ninguna"
        Me.CheckBox_1.UseVisualStyleBackColor = True
        '
        'CheckBox_2
        '
        Me.CheckBox_2.AutoSize = True
        Me.CheckBox_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_2.Location = New System.Drawing.Point(17, 68)
        Me.CheckBox_2.Name = "CheckBox_2"
        Me.CheckBox_2.Size = New System.Drawing.Size(76, 19)
        Me.CheckBox_2.TabIndex = 19
        Me.CheckBox_2.Text = "2. A dolor"
        Me.CheckBox_2.UseVisualStyleBackColor = True
        '
        'CheckBox_3
        '
        Me.CheckBox_3.AutoSize = True
        Me.CheckBox_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_3.Location = New System.Drawing.Point(17, 45)
        Me.CheckBox_3.Name = "CheckBox_3"
        Me.CheckBox_3.Size = New System.Drawing.Size(66, 19)
        Me.CheckBox_3.TabIndex = 18
        Me.CheckBox_3.Text = "3. A voz"
        Me.CheckBox_3.UseVisualStyleBackColor = True
        '
        'CheckBox_4
        '
        Me.CheckBox_4.AutoSize = True
        Me.CheckBox_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox_4.Location = New System.Drawing.Point(17, 23)
        Me.CheckBox_4.Name = "CheckBox_4"
        Me.CheckBox_4.Size = New System.Drawing.Size(73, 19)
        Me.CheckBox_4.TabIndex = 17
        Me.CheckBox_4.Text = "4. Esport"
        Me.CheckBox_4.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.checklist48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10053
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 10051
        Me.Label1.Text = "Cálculo Escala Glasgow"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(408, 20)
        Me.Label2.TabIndex = 10052
        Me.Label2.Text = "_________________________________________________________"
        '
        'FormGlasgow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(482, 272)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gbRmotora)
        Me.Controls.Add(Me.gbRverbal)
        Me.Controls.Add(Me.gbReaccion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(498, 311)
        Me.MinimumSize = New System.Drawing.Size(498, 311)
        Me.Name = "FormGlasgow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbRmotora.ResumeLayout(False)
        Me.gbRmotora.PerformLayout()
        Me.gbRverbal.ResumeLayout(False)
        Me.gbRverbal.PerformLayout()
        Me.gbReaccion.ResumeLayout(False)
        Me.gbReaccion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents gbRmotora As GroupBox
    Friend WithEvents CheckBox_1_g3 As RadioButton
    Friend WithEvents CheckBox_2_g3 As RadioButton
    Friend WithEvents CheckBox_3_g3 As RadioButton
    Friend WithEvents CheckBox_4_g3 As RadioButton
    Friend WithEvents CheckBox_5_g3 As RadioButton
    Friend WithEvents CheckBox_6_g3 As RadioButton
    Friend WithEvents gbRverbal As GroupBox
    Friend WithEvents CheckBox_1_g2 As RadioButton
    Friend WithEvents CheckBox_2_g2 As RadioButton
    Friend WithEvents CheckBox_3_g2 As RadioButton
    Friend WithEvents CheckBox_4_g2 As RadioButton
    Friend WithEvents CheckBox_5_g2 As RadioButton
    Friend WithEvents gbReaccion As GroupBox
    Friend WithEvents CheckBox_1 As RadioButton
    Friend WithEvents CheckBox_2 As RadioButton
    Friend WithEvents CheckBox_3 As RadioButton
    Friend WithEvents CheckBox_4 As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
