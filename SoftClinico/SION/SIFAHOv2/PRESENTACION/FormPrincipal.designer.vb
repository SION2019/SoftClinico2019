<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPrincipal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrincipal))
        Me.barraestadopp = New System.Windows.Forms.StatusStrip()
        Me.lblSede = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblBodega = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.dgvPorVencer = New System.Windows.Forms.DataGridView()
        Me.Textnombre_completo = New System.Windows.Forms.Label()
        Me.Textusuario_actual = New System.Windows.Forms.Label()
        Me.Timer_abrir = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_cerrar = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer_rojo = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTipTitulo = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TimerDiario = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDiarioEspera = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_CerraxInactividad = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPorVencer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'barraestadopp
        '
        Me.barraestadopp.BackColor = System.Drawing.Color.LightSkyBlue
        Me.barraestadopp.Location = New System.Drawing.Point(0, 711)
        Me.barraestadopp.Name = "barraestadopp"
        Me.barraestadopp.Size = New System.Drawing.Size(1016, 22)
        Me.barraestadopp.TabIndex = 1
        '
        'lblSede
        '
        Me.lblSede.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSede.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lblSede.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSede.ForeColor = System.Drawing.Color.Black
        Me.lblSede.Location = New System.Drawing.Point(816, 714)
        Me.lblSede.Name = "lblSede"
        Me.lblSede.Size = New System.Drawing.Size(188, 19)
        Me.lblSede.TabIndex = 27
        Me.lblSede.Text = "Sede"
        Me.lblSede.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblBodega)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.dgvPorVencer)
        Me.Panel1.Location = New System.Drawing.Point(12, 484)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(463, 187)
        Me.Panel1.TabIndex = 35
        Me.Panel1.Visible = False
        '
        'LblBodega
        '
        Me.LblBodega.AutoSize = True
        Me.LblBodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBodega.Location = New System.Drawing.Point(3, 165)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(38, 16)
        Me.LblBodega.TabIndex = 2
        Me.LblBodega.Text = "------"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(423, 167)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cerrar"
        '
        'dgvPorVencer
        '
        Me.dgvPorVencer.AllowUserToAddRows = False
        Me.dgvPorVencer.AllowUserToDeleteRows = False
        Me.dgvPorVencer.AllowUserToOrderColumns = True
        Me.dgvPorVencer.AllowUserToResizeColumns = False
        Me.dgvPorVencer.AllowUserToResizeRows = False
        Me.dgvPorVencer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPorVencer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPorVencer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPorVencer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPorVencer.Location = New System.Drawing.Point(3, 3)
        Me.dgvPorVencer.Name = "dgvPorVencer"
        Me.dgvPorVencer.RowHeadersVisible = False
        Me.dgvPorVencer.Size = New System.Drawing.Size(455, 161)
        Me.dgvPorVencer.TabIndex = 0
        '
        'Textnombre_completo
        '
        Me.Textnombre_completo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Textnombre_completo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Textnombre_completo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textnombre_completo.ForeColor = System.Drawing.Color.Black
        Me.Textnombre_completo.Location = New System.Drawing.Point(92, 713)
        Me.Textnombre_completo.Name = "Textnombre_completo"
        Me.Textnombre_completo.Size = New System.Drawing.Size(282, 19)
        Me.Textnombre_completo.TabIndex = 974
        Me.Textnombre_completo.Text = "Nombre"
        Me.Textnombre_completo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Textusuario_actual
        '
        Me.Textusuario_actual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Textusuario_actual.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Textusuario_actual.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textusuario_actual.ForeColor = System.Drawing.Color.Black
        Me.Textusuario_actual.Location = New System.Drawing.Point(6, 713)
        Me.Textusuario_actual.Name = "Textusuario_actual"
        Me.Textusuario_actual.Size = New System.Drawing.Size(89, 19)
        Me.Textusuario_actual.TabIndex = 975
        Me.Textusuario_actual.Text = "C.C"
        Me.Textusuario_actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer_abrir
        '
        Me.Timer_abrir.Interval = 1
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 30000
        '
        'Timer_cerrar
        '
        Me.Timer_cerrar.Interval = 1
        '
        'Panel2
        '
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1016, 711)
        Me.Panel2.TabIndex = 977
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(766, 557)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer_rojo
        '
        Me.Timer_rojo.Enabled = True
        Me.Timer_rojo.Interval = 500
        '
        'ToolTipTitulo
        '
        Me.ToolTipTitulo.AutoPopDelay = 30000
        Me.ToolTipTitulo.InitialDelay = 500
        Me.ToolTipTitulo.IsBalloon = True
        Me.ToolTipTitulo.ReshowDelay = 100
        Me.ToolTipTitulo.ShowAlways = True
        Me.ToolTipTitulo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipTitulo.ToolTipTitle = "Notificación"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(426, 713)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(796, 19)
        Me.Label3.TabIndex = 986
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimerDiario
        '
        Me.TimerDiario.Interval = 5000
        '
        'TimerDiarioEspera
        '
        Me.TimerDiarioEspera.Interval = 600000
        '
        'Timer_CerraxInactividad
        '
        Me.Timer_CerraxInactividad.Interval = 5000
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.Celer.My.Resources.Resources.CLogoInicio
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1016, 733)
        Me.Controls.Add(Me.Textusuario_actual)
        Me.Controls.Add(Me.lblSede)
        Me.Controls.Add(Me.Textnombre_completo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.barraestadopp)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIFAHO"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPorVencer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barraestadopp As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSede As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents dgvPorVencer As System.Windows.Forms.DataGridView
    Friend WithEvents LblBodega As System.Windows.Forms.Label
    Friend WithEvents Textnombre_completo As System.Windows.Forms.Label
    Friend WithEvents Textusuario_actual As System.Windows.Forms.Label
    Friend WithEvents Timer_abrir As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer_cerrar As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Timer_rojo As Timer
    Friend WithEvents ToolTipTitulo As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents TimerDiario As Timer
    Friend WithEvents TimerDiarioEspera As Timer
    Friend WithEvents Timer_CerraxInactividad As Timer
    Friend WithEvents Button1 As Button
End Class
