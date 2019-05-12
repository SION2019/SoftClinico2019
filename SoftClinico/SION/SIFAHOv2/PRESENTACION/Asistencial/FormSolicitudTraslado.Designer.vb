<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudTraslado
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.npaciente = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgvmanual = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.gbEstadoAtencion = New System.Windows.Forms.GroupBox()
        Me.selRealizado = New System.Windows.Forms.RadioButton()
        Me.selPendiente = New System.Windows.Forms.RadioButton()
        Me.comboAreaServicio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.busquedaPaciente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvmanual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.gbEstadoAtencion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.npaciente)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1292, 562)
        Me.GroupBox1.TabIndex = 10052
        Me.GroupBox1.TabStop = False
        '
        'npaciente
        '
        Me.npaciente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.npaciente.AutoSize = True
        Me.npaciente.BackColor = System.Drawing.Color.Transparent
        Me.npaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.npaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.npaciente.Location = New System.Drawing.Point(1236, 540)
        Me.npaciente.Name = "npaciente"
        Me.npaciente.Size = New System.Drawing.Size(14, 15)
        Me.npaciente.TabIndex = 10058
        Me.npaciente.Text = "0"
        Me.npaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgvmanual)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 70)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1276, 464)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pacientes:"
        '
        'dgvmanual
        '
        Me.dgvmanual.AllowUserToAddRows = False
        Me.dgvmanual.AllowUserToDeleteRows = False
        Me.dgvmanual.AllowUserToResizeColumns = False
        Me.dgvmanual.AllowUserToResizeRows = False
        Me.dgvmanual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvmanual.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvmanual.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvmanual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvmanual.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvmanual.Location = New System.Drawing.Point(6, 20)
        Me.dgvmanual.MultiSelect = False
        Me.dgvmanual.Name = "dgvmanual"
        Me.dgvmanual.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvmanual.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvmanual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvmanual.Size = New System.Drawing.Size(1264, 438)
        Me.dgvmanual.TabIndex = 19
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gbEstadoAtencion)
        Me.GroupBox4.Controls.Add(Me.comboAreaServicio)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.busquedaPaciente)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1276, 54)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtros de Busqueda:"
        '
        'gbEstadoAtencion
        '
        Me.gbEstadoAtencion.Controls.Add(Me.selRealizado)
        Me.gbEstadoAtencion.Controls.Add(Me.selPendiente)
        Me.gbEstadoAtencion.Location = New System.Drawing.Point(812, 8)
        Me.gbEstadoAtencion.Name = "gbEstadoAtencion"
        Me.gbEstadoAtencion.Size = New System.Drawing.Size(306, 42)
        Me.gbEstadoAtencion.TabIndex = 10058
        Me.gbEstadoAtencion.TabStop = False
        Me.gbEstadoAtencion.Text = "Estado de Solicitud:"
        '
        'selRealizado
        '
        Me.selRealizado.AutoSize = True
        Me.selRealizado.BackColor = System.Drawing.Color.Transparent
        Me.selRealizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selRealizado.ForeColor = System.Drawing.Color.Green
        Me.selRealizado.Location = New System.Drawing.Point(165, 16)
        Me.selRealizado.Name = "selRealizado"
        Me.selRealizado.Size = New System.Drawing.Size(87, 19)
        Me.selRealizado.TabIndex = 10054
        Me.selRealizado.Text = "Realizados"
        Me.selRealizado.UseVisualStyleBackColor = False
        '
        'selPendiente
        '
        Me.selPendiente.AutoSize = True
        Me.selPendiente.BackColor = System.Drawing.Color.Transparent
        Me.selPendiente.Checked = True
        Me.selPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.selPendiente.ForeColor = System.Drawing.Color.Red
        Me.selPendiente.Location = New System.Drawing.Point(28, 16)
        Me.selPendiente.Name = "selPendiente"
        Me.selPendiente.Size = New System.Drawing.Size(87, 19)
        Me.selPendiente.TabIndex = 10053
        Me.selPendiente.TabStop = True
        Me.selPendiente.Text = "Pendientes"
        Me.selPendiente.UseVisualStyleBackColor = False
        '
        'comboAreaServicio
        '
        Me.comboAreaServicio.BackColor = System.Drawing.Color.White
        Me.comboAreaServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAreaServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAreaServicio.FormattingEnabled = True
        Me.comboAreaServicio.Location = New System.Drawing.Point(521, 22)
        Me.comboAreaServicio.Name = "comboAreaServicio"
        Me.comboAreaServicio.Size = New System.Drawing.Size(261, 23)
        Me.comboAreaServicio.TabIndex = 10052
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(421, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 10051
        Me.Label3.Text = "Área de Servicio:"
        '
        'busquedaPaciente
        '
        Me.busquedaPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.busquedaPaciente.Location = New System.Drawing.Point(74, 23)
        Me.busquedaPaciente.Name = "busquedaPaciente"
        Me.busquedaPaciente.Size = New System.Drawing.Size(328, 21)
        Me.busquedaPaciente.TabIndex = 10050
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 15)
        Me.Label10.TabIndex = 10048
        Me.Label10.Text = "Paciente:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1089, 540)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 15)
        Me.Label4.TabIndex = 10056
        Me.Label4.Text = "Cantidad de Pacientes:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.People_Patient_Male_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10051
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 16)
        Me.Label1.TabIndex = 10049
        Me.Label1.Text = "LISTADO DE PACIENTES A TRASLADAR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1249, 20)
        Me.Label2.TabIndex = 10050
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'FormSolicitudTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 616)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 655)
        Me.MinimumSize = New System.Drawing.Size(1326, 655)
        Me.Name = "FormSolicitudTraslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvmanual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbEstadoAtencion.ResumeLayout(False)
        Me.gbEstadoAtencion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents npaciente As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgvmanual As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents gbEstadoAtencion As GroupBox
    Friend WithEvents selPendiente As RadioButton
    Friend WithEvents comboAreaServicio As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents busquedaPaciente As TextBox
    Friend WithEvents Label10 As Label
    Protected WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents selRealizado As RadioButton
End Class
