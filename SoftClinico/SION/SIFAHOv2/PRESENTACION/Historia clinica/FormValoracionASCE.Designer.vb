<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormValoracionASCE
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gbReaccion = New System.Windows.Forms.GroupBox()
        Me.cbEstupuroso = New System.Windows.Forms.RadioButton()
        Me.cbComa = New System.Windows.Forms.RadioButton()
        Me.cbSomnoliento = New System.Windows.Forms.RadioButton()
        Me.cbAletra = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cbBajoSedacion = New System.Windows.Forms.RadioButton()
        Me.gbReaccion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 16)
        Me.Label1.TabIndex = 10056
        Me.Label1.Text = "Valoración Neurológica"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(408, 20)
        Me.Label2.TabIndex = 10057
        Me.Label2.Text = "_________________________________________________________"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(11, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(460, 30)
        Me.Button1.TabIndex = 10055
        Me.Button1.Text = "Seleccionar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'gbReaccion
        '
        Me.gbReaccion.Controls.Add(Me.cbBajoSedacion)
        Me.gbReaccion.Controls.Add(Me.cbEstupuroso)
        Me.gbReaccion.Controls.Add(Me.cbComa)
        Me.gbReaccion.Controls.Add(Me.cbSomnoliento)
        Me.gbReaccion.Controls.Add(Me.cbAletra)
        Me.gbReaccion.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbReaccion.ForeColor = System.Drawing.Color.Black
        Me.gbReaccion.Location = New System.Drawing.Point(12, 56)
        Me.gbReaccion.Name = "gbReaccion"
        Me.gbReaccion.Size = New System.Drawing.Size(459, 166)
        Me.gbReaccion.TabIndex = 10054
        Me.gbReaccion.TabStop = False
        '
        'cbEstupuroso
        '
        Me.cbEstupuroso.AutoSize = True
        Me.cbEstupuroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbEstupuroso.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbEstupuroso.Location = New System.Drawing.Point(182, 101)
        Me.cbEstupuroso.Name = "cbEstupuroso"
        Me.cbEstupuroso.Size = New System.Drawing.Size(101, 19)
        Me.cbEstupuroso.TabIndex = 20
        Me.cbEstupuroso.Text = "E: Estupuroso"
        Me.cbEstupuroso.UseVisualStyleBackColor = True
        '
        'cbComa
        '
        Me.cbComa.AutoSize = True
        Me.cbComa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbComa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbComa.Location = New System.Drawing.Point(182, 74)
        Me.cbComa.Name = "cbComa"
        Me.cbComa.Size = New System.Drawing.Size(72, 19)
        Me.cbComa.TabIndex = 19
        Me.cbComa.Text = "C: Coma"
        Me.cbComa.UseVisualStyleBackColor = True
        '
        'cbSomnoliento
        '
        Me.cbSomnoliento.AutoSize = True
        Me.cbSomnoliento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbSomnoliento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbSomnoliento.Location = New System.Drawing.Point(182, 47)
        Me.cbSomnoliento.Name = "cbSomnoliento"
        Me.cbSomnoliento.Size = New System.Drawing.Size(109, 19)
        Me.cbSomnoliento.TabIndex = 18
        Me.cbSomnoliento.Text = "S: Somnoliento"
        Me.cbSomnoliento.UseVisualStyleBackColor = True
        '
        'cbAletra
        '
        Me.cbAletra.AutoSize = True
        Me.cbAletra.Checked = True
        Me.cbAletra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbAletra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbAletra.Location = New System.Drawing.Point(182, 20)
        Me.cbAletra.Name = "cbAletra"
        Me.cbAletra.Size = New System.Drawing.Size(69, 19)
        Me.cbAletra.TabIndex = 17
        Me.cbAletra.TabStop = True
        Me.cbAletra.Text = "A: Alerta"
        Me.cbAletra.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.checklist48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10058
        Me.PictureBox1.TabStop = False
        '
        'cbBajoSedacion
        '
        Me.cbBajoSedacion.AutoSize = True
        Me.cbBajoSedacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbBajoSedacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbBajoSedacion.Location = New System.Drawing.Point(182, 128)
        Me.cbBajoSedacion.Name = "cbBajoSedacion"
        Me.cbBajoSedacion.Size = New System.Drawing.Size(127, 19)
        Me.cbBajoSedacion.TabIndex = 21
        Me.cbBajoSedacion.Text = "BS: Bajo Sedación"
        Me.cbBajoSedacion.UseVisualStyleBackColor = True
        '
        'FormValoracionASCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(482, 272)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gbReaccion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FormValoracionASCE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbReaccion.ResumeLayout(False)
        Me.gbReaccion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents gbReaccion As GroupBox
    Friend WithEvents cbEstupuroso As RadioButton
    Friend WithEvents cbComa As RadioButton
    Friend WithEvents cbSomnoliento As RadioButton
    Friend WithEvents cbAletra As RadioButton
    Friend WithEvents cbBajoSedacion As RadioButton
End Class
