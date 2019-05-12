<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEstadisticaFacturacion
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.btGenerar = New System.Windows.Forms.Button()
        Me.ComboConcepto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbConsolidado = New System.Windows.Forms.RadioButton()
        Me.fechafinal = New System.Windows.Forms.DateTimePicker()
        Me.rbSede50 = New System.Windows.Forms.RadioButton()
        Me.fechainicio = New System.Windows.Forms.DateTimePicker()
        Me.rbSabanalarga = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nombreInforme = New System.Windows.Forms.Label()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.porcentaje2 = New System.Windows.Forms.Label()
        Me.porcentaje1 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ComboConcepto.Size = New System.Drawing.Size(344, 21)
        Me.ComboConcepto.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(634, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Fecha Final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(416, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Fecha Inicial:"
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
        Me.Chart1.Location = New System.Drawing.Point(7, 85)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1299, 501)
        Me.Chart1.TabIndex = 60032
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbConsolidado)
        Me.GroupBox1.Controls.Add(Me.fechafinal)
        Me.GroupBox1.Controls.Add(Me.rbSede50)
        Me.GroupBox1.Controls.Add(Me.fechainicio)
        Me.GroupBox1.Controls.Add(Me.rbSabanalarga)
        Me.GroupBox1.Controls.Add(Me.btGenerar)
        Me.GroupBox1.Controls.Add(Me.ComboConcepto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1299, 39)
        Me.GroupBox1.TabIndex = 60029
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información requerida:"
        '
        'rbConsolidado
        '
        Me.rbConsolidado.AutoSize = True
        Me.rbConsolidado.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsolidado.Location = New System.Drawing.Point(1075, 13)
        Me.rbConsolidado.Name = "rbConsolidado"
        Me.rbConsolidado.Size = New System.Drawing.Size(85, 20)
        Me.rbConsolidado.TabIndex = 60039
        Me.rbConsolidado.Text = "Consolidado"
        Me.rbConsolidado.UseVisualStyleBackColor = True
        '
        'fechafinal
        '
        Me.fechafinal.CustomFormat = "ddMMMMyyyy"
        Me.fechafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechafinal.Location = New System.Drawing.Point(700, 13)
        Me.fechafinal.Name = "fechafinal"
        Me.fechafinal.Size = New System.Drawing.Size(145, 21)
        Me.fechafinal.TabIndex = 60040
        '
        'rbSede50
        '
        Me.rbSede50.AutoSize = True
        Me.rbSede50.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSede50.Location = New System.Drawing.Point(972, 13)
        Me.rbSede50.Name = "rbSede50"
        Me.rbSede50.Size = New System.Drawing.Size(97, 20)
        Me.rbSede50.TabIndex = 60037
        Me.rbSede50.Text = "Sede Clínica 50"
        Me.rbSede50.UseVisualStyleBackColor = True
        '
        'fechainicio
        '
        Me.fechainicio.CustomFormat = "ddMMMMyyyy"
        Me.fechainicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechainicio.Location = New System.Drawing.Point(482, 13)
        Me.fechainicio.Name = "fechainicio"
        Me.fechainicio.Size = New System.Drawing.Size(145, 21)
        Me.fechainicio.TabIndex = 60039
        '
        'rbSabanalarga
        '
        Me.rbSabanalarga.AutoSize = True
        Me.rbSabanalarga.Checked = True
        Me.rbSabanalarga.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSabanalarga.Location = New System.Drawing.Point(855, 13)
        Me.rbSabanalarga.Name = "rbSabanalarga"
        Me.rbSabanalarga.Size = New System.Drawing.Size(109, 20)
        Me.rbSabanalarga.TabIndex = 31
        Me.rbSabanalarga.TabStop = True
        Me.rbSabanalarga.Text = "Sede Sabanalarga"
        Me.rbSabanalarga.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.chart_search_icon
        Me.PictureBox1.Location = New System.Drawing.Point(8, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60034
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(58, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1178, 20)
        Me.Label2.TabIndex = 60033
        Me.Label2.Text = "_________________________________________________________________________________" &
    "________________________________________________________________________________" &
    "______"
        '
        'nombreInforme
        '
        Me.nombreInforme.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreInforme.Location = New System.Drawing.Point(64, 3)
        Me.nombreInforme.Name = "nombreInforme"
        Me.nombreInforme.Size = New System.Drawing.Size(1236, 30)
        Me.nombreInforme.TabIndex = 60036
        Me.nombreInforme.Text = "..."
        Me.nombreInforme.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.nombreInforme.Visible = False
        '
        'Chart2
        '
        ChartArea2.Area3DStyle.Enable3D = True
        ChartArea2.Area3DStyle.WallWidth = 0
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(1043, 232)
        Me.Chart2.Name = "Chart2"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(262, 251)
        Me.Chart2.TabIndex = 0
        Me.Chart2.Text = "Chart2"
        '
        'porcentaje2
        '
        Me.porcentaje2.AutoSize = True
        Me.porcentaje2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcentaje2.Location = New System.Drawing.Point(1281, 256)
        Me.porcentaje2.Name = "porcentaje2"
        Me.porcentaje2.Size = New System.Drawing.Size(17, 16)
        Me.porcentaje2.TabIndex = 60037
        Me.porcentaje2.Text = "%"
        Me.porcentaje2.Visible = False
        '
        'porcentaje1
        '
        Me.porcentaje1.AutoSize = True
        Me.porcentaje1.BackColor = System.Drawing.Color.Transparent
        Me.porcentaje1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcentaje1.Location = New System.Drawing.Point(1281, 242)
        Me.porcentaje1.Name = "porcentaje1"
        Me.porcentaje1.Size = New System.Drawing.Size(17, 16)
        Me.porcentaje1.TabIndex = 60038
        Me.porcentaje1.Text = "%"
        Me.porcentaje1.Visible = False
        '
        'FormEstadisticaFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1310, 586)
        Me.Controls.Add(Me.porcentaje1)
        Me.Controls.Add(Me.porcentaje2)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.nombreInforme)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1326, 625)
        Me.MinimumSize = New System.Drawing.Size(1326, 625)
        Me.Name = "FormEstadisticaFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboConcepto As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btGenerar As Button
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Friend WithEvents nombreInforme As Label
    Friend WithEvents rbSede50 As RadioButton
    Friend WithEvents rbSabanalarga As RadioButton
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents porcentaje2 As Label
    Friend WithEvents porcentaje1 As Label
    Friend WithEvents fechafinal As DateTimePicker
    Friend WithEvents fechainicio As DateTimePicker
    Friend WithEvents rbConsolidado As RadioButton
End Class
