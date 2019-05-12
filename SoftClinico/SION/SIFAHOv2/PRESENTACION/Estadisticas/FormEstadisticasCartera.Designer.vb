<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticasCartera
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btBusquedaCuenta = New System.Windows.Forms.Button()
        Me.textnombretercero = New System.Windows.Forms.TextBox()
        Me.btGenerar = New System.Windows.Forms.Button()
        Me.ComboConcepto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fechafinal = New System.Windows.Forms.DateTimePicker()
        Me.fechainicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.porcentajePeriodo = New System.Windows.Forms.Label()
        Me.porcentajeCartera = New System.Windows.Forms.Label()
        Me.nombreInforme = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.periodo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.chart_search_icon
        Me.PictureBox1.Location = New System.Drawing.Point(7, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60038
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(57, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1178, 20)
        Me.Label2.TabIndex = 60037
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______"
        '
        'Chart1
        '
        Me.Chart1.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter
        Me.Chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(6, 10)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1264, 426)
        Me.Chart1.TabIndex = 60036
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btBusquedaCuenta)
        Me.GroupBox1.Controls.Add(Me.textnombretercero)
        Me.GroupBox1.Controls.Add(Me.btGenerar)
        Me.GroupBox1.Controls.Add(Me.ComboConcepto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.fechafinal)
        Me.GroupBox1.Controls.Add(Me.fechainicio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1299, 39)
        Me.GroupBox1.TabIndex = 60035
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información requerida:"
        '
        'btBusquedaCuenta
        '
        Me.btBusquedaCuenta.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBusquedaCuenta.Location = New System.Drawing.Point(707, 12)
        Me.btBusquedaCuenta.Name = "btBusquedaCuenta"
        Me.btBusquedaCuenta.Size = New System.Drawing.Size(25, 23)
        Me.btBusquedaCuenta.TabIndex = 60051
        Me.btBusquedaCuenta.UseVisualStyleBackColor = True
        Me.btBusquedaCuenta.Visible = False
        '
        'textnombretercero
        '
        Me.textnombretercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textnombretercero.Location = New System.Drawing.Point(273, 13)
        Me.textnombretercero.Name = "textnombretercero"
        Me.textnombretercero.ReadOnly = True
        Me.textnombretercero.Size = New System.Drawing.Size(428, 22)
        Me.textnombretercero.TabIndex = 60050
        Me.textnombretercero.Visible = False
        '
        'btGenerar
        '
        Me.btGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btGenerar.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGenerar.Location = New System.Drawing.Point(1197, 11)
        Me.btGenerar.Name = "btGenerar"
        Me.btGenerar.Size = New System.Drawing.Size(66, 23)
        Me.btGenerar.TabIndex = 30
        Me.btGenerar.Text = "Generar"
        Me.btGenerar.UseVisualStyleBackColor = False
        '
        'ComboConcepto
        '
        Me.ComboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboConcepto.FormattingEnabled = True
        Me.ComboConcepto.Location = New System.Drawing.Point(62, 13)
        Me.ComboConcepto.Name = "ComboConcepto"
        Me.ComboConcepto.Size = New System.Drawing.Size(205, 21)
        Me.ComboConcepto.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(969, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Fecha Final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(738, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Fecha Inicial:"
        '
        'fechafinal
        '
        Me.fechafinal.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafinal.CustomFormat = "ddMMMMyyyy"
        Me.fechafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechafinal.Location = New System.Drawing.Point(1039, 12)
        Me.fechafinal.Name = "fechafinal"
        Me.fechafinal.Size = New System.Drawing.Size(141, 21)
        Me.fechafinal.TabIndex = 26
        '
        'fechainicio
        '
        Me.fechainicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.CustomFormat = "ddMMMMyyyy"
        Me.fechainicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechainicio.Location = New System.Drawing.Point(811, 12)
        Me.fechainicio.Name = "fechainicio"
        Me.fechainicio.Size = New System.Drawing.Size(146, 21)
        Me.fechainicio.TabIndex = 25
        Me.fechainicio.Value = New Date(2017, 8, 1, 17, 44, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Concepto:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Chart2
        '
        Me.Chart2.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter
        Me.Chart2.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(6, 6)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Size = New System.Drawing.Size(991, 430)
        Me.Chart2.TabIndex = 60039
        Me.Chart2.Text = "Chart2"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Celer.My.Resources.Resources.C_Users_Sistema_2_AppData_Local_Packages_Microsoft_SkypeApp_kzf8qxf38zg5c_LocalState_aaa457e2_a754_46b2_b3c5_7142f11e8035
        Me.PictureBox2.Location = New System.Drawing.Point(1018, 17)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(251, 197)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 60040
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Celer.My.Resources.Resources.C_Users_Sistema_2_AppData_Local_Packages_Microsoft_SkypeApp_kzf8qxf38zg5c_LocalState_1f383bce_959d_4f9f_9e5c_dedc8e0181b6
        Me.PictureBox3.Location = New System.Drawing.Point(1018, 220)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(251, 173)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 60041
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'porcentajePeriodo
        '
        Me.porcentajePeriodo.AutoSize = True
        Me.porcentajePeriodo.BackColor = System.Drawing.Color.White
        Me.porcentajePeriodo.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcentajePeriodo.ForeColor = System.Drawing.Color.Red
        Me.porcentajePeriodo.Location = New System.Drawing.Point(1124, 119)
        Me.porcentajePeriodo.Name = "porcentajePeriodo"
        Me.porcentajePeriodo.Size = New System.Drawing.Size(34, 31)
        Me.porcentajePeriodo.TabIndex = 60042
        Me.porcentajePeriodo.Text = "%"
        Me.porcentajePeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'porcentajeCartera
        '
        Me.porcentajeCartera.AutoSize = True
        Me.porcentajeCartera.BackColor = System.Drawing.Color.White
        Me.porcentajeCartera.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcentajeCartera.ForeColor = System.Drawing.Color.Red
        Me.porcentajeCartera.Location = New System.Drawing.Point(1124, 308)
        Me.porcentajeCartera.Name = "porcentajeCartera"
        Me.porcentajeCartera.Size = New System.Drawing.Size(34, 31)
        Me.porcentajeCartera.TabIndex = 60043
        Me.porcentajeCartera.Text = "%"
        Me.porcentajeCartera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nombreInforme
        '
        Me.nombreInforme.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreInforme.Location = New System.Drawing.Point(5, 80)
        Me.nombreInforme.Name = "nombreInforme"
        Me.nombreInforme.Size = New System.Drawing.Size(1298, 23)
        Me.nombreInforme.TabIndex = 60044
        Me.nombreInforme.Text = "..."
        Me.nombreInforme.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.nombreInforme.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1112, 237)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 60046
        Me.Label8.Text = "Cartera"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'periodo
        '
        Me.periodo.AutoSize = True
        Me.periodo.BackColor = System.Drawing.Color.White
        Me.periodo.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.periodo.ForeColor = System.Drawing.Color.Black
        Me.periodo.Location = New System.Drawing.Point(1112, 52)
        Me.periodo.Name = "periodo"
        Me.periodo.Size = New System.Drawing.Size(58, 17)
        Me.periodo.TabIndex = 60047
        Me.periodo.Text = "Periodo"
        Me.periodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label10.Location = New System.Drawing.Point(1088, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 17)
        Me.Label10.TabIndex = 60048
        Me.Label10.Text = "Recaudo/Ventas"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 106)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1296, 468)
        Me.TabControl1.TabIndex = 60050
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Chart1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1288, 442)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.porcentajeCartera)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.porcentajePeriodo)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.periodo)
        Me.TabPage2.Controls.Add(Me.Chart2)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.PictureBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1288, 442)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comportamiento Recaudo Vs Ventas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label1.Location = New System.Drawing.Point(1058, 261)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 17)
        Me.Label1.TabIndex = 60050
        Me.Label1.Text = "Gestión recaudo/Cartera "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormEstadisticasCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 586)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.nombreInforme)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 625)
        Me.MinimumSize = New System.Drawing.Size(1326, 625)
        Me.Name = "FormEstadisticasCartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btGenerar As Button
    Friend WithEvents ComboConcepto As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents fechafinal As DateTimePicker
    Friend WithEvents fechainicio As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents porcentajePeriodo As Label
    Friend WithEvents porcentajeCartera As Label
    Friend WithEvents nombreInforme As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents periodo As Label
    Friend WithEvents Label10 As Label
    Public WithEvents btBusquedaCuenta As Button
    Friend WithEvents textnombretercero As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
End Class
