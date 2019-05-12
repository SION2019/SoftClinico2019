<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVisorHojaRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVisorHojaRuta))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Textestancia = New System.Windows.Forms.TextBox()
        Me.textidentificacion = New System.Windows.Forms.TextBox()
        Me.textnombre = New System.Windows.Forms.TextBox()
        Me.texthc = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.grupoLista = New System.Windows.Forms.GroupBox()
        Me.PanelJustificacionR = New System.Windows.Forms.Panel()
        Me.txtJustificacionR = New System.Windows.Forms.TextBox()
        Me.dgvTareaPrograma = New System.Windows.Forms.DataGridView()
        Me.grupoImagen = New System.Windows.Forms.GroupBox()
        Me.txtNota = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visor = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grupoLista.SuspendLayout()
        Me.PanelJustificacionR.SuspendLayout()
        CType(Me.dgvTareaPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoImagen.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "................"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(877, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "_________________________________________________________________________________" &
    "___________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.grupoLista)
        Me.GroupBox1.Controls.Add(Me.grupoImagen)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 521)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(972, 53)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Textestancia)
        Me.Panel1.Controls.Add(Me.textidentificacion)
        Me.Panel1.Controls.Add(Me.textnombre)
        Me.Panel1.Controls.Add(Me.texthc)
        Me.Panel1.Controls.Add(Me.Label76)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.Label74)
        Me.Panel1.Location = New System.Drawing.Point(6, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(960, 32)
        Me.Panel1.TabIndex = 40
        '
        'Textestancia
        '
        Me.Textestancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textestancia.Location = New System.Drawing.Point(845, 5)
        Me.Textestancia.Name = "Textestancia"
        Me.Textestancia.ReadOnly = True
        Me.Textestancia.Size = New System.Drawing.Size(107, 21)
        Me.Textestancia.TabIndex = 3067
        Me.Textestancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textidentificacion
        '
        Me.textidentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textidentificacion.Location = New System.Drawing.Point(256, 4)
        Me.textidentificacion.Name = "textidentificacion"
        Me.textidentificacion.ReadOnly = True
        Me.textidentificacion.Size = New System.Drawing.Size(120, 21)
        Me.textidentificacion.TabIndex = 3068
        '
        'textnombre
        '
        Me.textnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textnombre.Location = New System.Drawing.Point(434, 5)
        Me.textnombre.Name = "textnombre"
        Me.textnombre.ReadOnly = True
        Me.textnombre.Size = New System.Drawing.Size(350, 21)
        Me.textnombre.TabIndex = 3066
        '
        'texthc
        '
        Me.texthc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texthc.Location = New System.Drawing.Point(61, 5)
        Me.texthc.Name = "texthc"
        Me.texthc.ReadOnly = True
        Me.texthc.Size = New System.Drawing.Size(107, 21)
        Me.texthc.TabIndex = 3065
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label76.Location = New System.Drawing.Point(6, 5)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(56, 15)
        Me.Label76.TabIndex = 3064
        Me.Label76.Text = "Registro:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(174, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 3063
        Me.Label14.Text = "Identificación:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(790, 8)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(57, 15)
        Me.Label32.TabIndex = 3062
        Me.Label32.Text = "Estancia:"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Black
        Me.Label74.Location = New System.Drawing.Point(380, 7)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(55, 15)
        Me.Label74.TabIndex = 3061
        Me.Label74.Text = "Nombre:"
        '
        'grupoLista
        '
        Me.grupoLista.Controls.Add(Me.PanelJustificacionR)
        Me.grupoLista.Controls.Add(Me.dgvTareaPrograma)
        Me.grupoLista.Location = New System.Drawing.Point(6, 63)
        Me.grupoLista.Name = "grupoLista"
        Me.grupoLista.Size = New System.Drawing.Size(972, 454)
        Me.grupoLista.TabIndex = 38
        Me.grupoLista.TabStop = False
        Me.grupoLista.Text = "Tareas "
        '
        'PanelJustificacionR
        '
        Me.PanelJustificacionR.BackColor = System.Drawing.Color.OldLace
        Me.PanelJustificacionR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelJustificacionR.Controls.Add(Me.txtJustificacionR)
        Me.PanelJustificacionR.Location = New System.Drawing.Point(235, 19)
        Me.PanelJustificacionR.Name = "PanelJustificacionR"
        Me.PanelJustificacionR.Size = New System.Drawing.Size(517, 132)
        Me.PanelJustificacionR.TabIndex = 10062
        Me.PanelJustificacionR.Visible = False
        '
        'txtJustificacionR
        '
        Me.txtJustificacionR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJustificacionR.Location = New System.Drawing.Point(3, 3)
        Me.txtJustificacionR.Multiline = True
        Me.txtJustificacionR.Name = "txtJustificacionR"
        Me.txtJustificacionR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJustificacionR.Size = New System.Drawing.Size(509, 124)
        Me.txtJustificacionR.TabIndex = 10065
        '
        'dgvTareaPrograma
        '
        Me.dgvTareaPrograma.AllowUserToAddRows = False
        Me.dgvTareaPrograma.AllowUserToDeleteRows = False
        Me.dgvTareaPrograma.AllowUserToResizeColumns = False
        Me.dgvTareaPrograma.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTareaPrograma.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTareaPrograma.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTareaPrograma.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTareaPrograma.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvTareaPrograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTareaPrograma.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Visor})
        Me.dgvTareaPrograma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTareaPrograma.Location = New System.Drawing.Point(3, 17)
        Me.dgvTareaPrograma.MultiSelect = False
        Me.dgvTareaPrograma.Name = "dgvTareaPrograma"
        Me.dgvTareaPrograma.ReadOnly = True
        Me.dgvTareaPrograma.RowHeadersVisible = False
        Me.dgvTareaPrograma.Size = New System.Drawing.Size(966, 434)
        Me.dgvTareaPrograma.TabIndex = 30
        '
        'grupoImagen
        '
        Me.grupoImagen.Controls.Add(Me.txtNota)
        Me.grupoImagen.Location = New System.Drawing.Point(6, 67)
        Me.grupoImagen.Name = "grupoImagen"
        Me.grupoImagen.Size = New System.Drawing.Size(972, 454)
        Me.grupoImagen.TabIndex = 37
        Me.grupoImagen.TabStop = False
        Me.grupoImagen.Text = "Indicaciones "
        Me.grupoImagen.Visible = False
        '
        'txtNota
        '
        Me.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNota.Location = New System.Drawing.Point(3, 17)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(966, 434)
        Me.txtNota.TabIndex = 0
        Me.txtNota.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.App_lists_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Procedimiento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Diagnosticos"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.HeaderText = "Diagnosticos"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Cedula"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 71
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.HeaderText = "Nombre Empleados"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'Visor
        '
        Me.Visor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Visor.HeaderText = "Ver"
        Me.Visor.Image = Global.Celer.My.Resources.Resources.Image_JPEG_icon
        Me.Visor.Name = "Visor"
        Me.Visor.ReadOnly = True
        Me.Visor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Visor.Width = 31
        '
        'FormVisorHojaRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(997, 567)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(958, 595)
        Me.Name = "FormVisorHojaRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grupoLista.ResumeLayout(False)
        Me.PanelJustificacionR.ResumeLayout(False)
        Me.PanelJustificacionR.PerformLayout()
        CType(Me.dgvTareaPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoImagen.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents grupoLista As GroupBox
    Friend WithEvents grupoImagen As GroupBox
    Friend WithEvents dgvTareaPrograma As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Textestancia As TextBox
    Friend WithEvents textidentificacion As TextBox
    Friend WithEvents textnombre As TextBox
    Friend WithEvents texthc As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents txtNota As RichTextBox
    Friend WithEvents PanelJustificacionR As Panel
    Friend WithEvents txtJustificacionR As TextBox
    Friend WithEvents Visor As DataGridViewImageColumn
End Class
