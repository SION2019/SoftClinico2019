<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLibroAuxiliar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLibroAuxiliar))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtDescripcionTercero = New System.Windows.Forms.TextBox()
        Me.txtDescripcionCuenta = New System.Windows.Forms.TextBox()
        Me.btTercero = New System.Windows.Forms.Button()
        Me.btBusquedaCuenta = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIdentificacionTercero = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCodigoCuenta = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btExportaExcel = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.btVisualizaPDF = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox2.Controls.Add(Me.txtDescripcionTercero)
        Me.GroupBox2.Controls.Add(Me.txtDescripcionCuenta)
        Me.GroupBox2.Controls.Add(Me.btTercero)
        Me.GroupBox2.Controls.Add(Me.btBusquedaCuenta)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtIdentificacionTercero)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtCodigoCuenta)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(535, 229)
        Me.GroupBox2.TabIndex = 10006
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
        Me.Label4.TabIndex = 60020
        Me.Label4.Text = "Fecha Inicio"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicio.Location = New System.Drawing.Point(97, 106)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(117, 21)
        Me.dtpFechaInicio.TabIndex = 60019
        Me.dtpFechaInicio.Value = New Date(2017, 1, 30, 0, 0, 0, 0)
        '
        'txtDescripcionTercero
        '
        Me.txtDescripcionTercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionTercero.Location = New System.Drawing.Point(189, 49)
        Me.txtDescripcionTercero.Name = "txtDescripcionTercero"
        Me.txtDescripcionTercero.ReadOnly = True
        Me.txtDescripcionTercero.Size = New System.Drawing.Size(329, 20)
        Me.txtDescripcionTercero.TabIndex = 60018
        '
        'txtDescripcionCuenta
        '
        Me.txtDescripcionCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionCuenta.Location = New System.Drawing.Point(189, 23)
        Me.txtDescripcionCuenta.Name = "txtDescripcionCuenta"
        Me.txtDescripcionCuenta.ReadOnly = True
        Me.txtDescripcionCuenta.Size = New System.Drawing.Size(329, 20)
        Me.txtDescripcionCuenta.TabIndex = 60017
        '
        'btTercero
        '
        Me.btTercero.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btTercero.Location = New System.Drawing.Point(150, 48)
        Me.btTercero.Name = "btTercero"
        Me.btTercero.Size = New System.Drawing.Size(25, 23)
        Me.btTercero.TabIndex = 60016
        Me.btTercero.UseVisualStyleBackColor = True
        '
        'btBusquedaCuenta
        '
        Me.btBusquedaCuenta.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.btBusquedaCuenta.Location = New System.Drawing.Point(150, 22)
        Me.btBusquedaCuenta.Name = "btBusquedaCuenta"
        Me.btBusquedaCuenta.Size = New System.Drawing.Size(25, 23)
        Me.btBusquedaCuenta.TabIndex = 60015
        Me.btBusquedaCuenta.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nit:"
        '
        'txtIdentificacionTercero
        '
        Me.txtIdentificacionTercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentificacionTercero.Location = New System.Drawing.Point(80, 49)
        Me.txtIdentificacionTercero.Name = "txtIdentificacionTercero"
        Me.txtIdentificacionTercero.Size = New System.Drawing.Size(66, 20)
        Me.txtIdentificacionTercero.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Cuenta"
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(80, 23)
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(65, 20)
        Me.txtCodigoCuenta.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(521, 80)
        Me.GroupBox3.TabIndex = 60030
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btExportaExcel)
        Me.GroupBox4.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox4.Controls.Add(Me.btVisualizaPDF)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 90)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(518, 133)
        Me.GroupBox4.TabIndex = 60031
        Me.GroupBox4.TabStop = False
        '
        'btExportaExcel
        '
        Me.btExportaExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btExportaExcel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExportaExcel.Image = Global.Celer.My.Resources.Resources.Excel_icon__1_
        Me.btExportaExcel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btExportaExcel.Location = New System.Drawing.Point(156, 73)
        Me.btExportaExcel.Name = "btExportaExcel"
        Me.btExportaExcel.Size = New System.Drawing.Size(130, 34)
        Me.btExportaExcel.TabIndex = 60029
        Me.btExportaExcel.Text = "Exportar a Excel"
        Me.btExportaExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btExportaExcel.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(291, 15)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(117, 21)
        Me.dtpFechaFin.TabIndex = 60027
        Me.dtpFechaFin.Value = New Date(2017, 1, 30, 0, 0, 0, 0)
        '
        'btVisualizaPDF
        '
        Me.btVisualizaPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btVisualizaPDF.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btVisualizaPDF.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.btVisualizaPDF.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btVisualizaPDF.Location = New System.Drawing.Point(18, 73)
        Me.btVisualizaPDF.Name = "btVisualizaPDF"
        Me.btVisualizaPDF.Size = New System.Drawing.Size(130, 34)
        Me.btVisualizaPDF.TabIndex = 60028
        Me.btVisualizaPDF.Text = "Generar Reporte"
        Me.btVisualizaPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btVisualizaPDF.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(230, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 60022
        Me.Label5.Text = "Fecha fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 10009
        Me.Label1.Text = "LIBRO AUXILIAR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(492, 20)
        Me.Label2.TabIndex = 10007
        Me.Label2.Text = "_____________________________________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.chart_search_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10008
        Me.PictureBox1.TabStop = False
        '
        'FormLibroAuxiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(559, 296)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(575, 335)
        Me.MinimumSize = New System.Drawing.Size(575, 335)
        Me.Name = "FormLibroAuxiliar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label1 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents txtCodigoCuenta As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents txtIdentificacionTercero As TextBox
    Public WithEvents Label11 As Label
    Public WithEvents txtDescripcionTercero As TextBox
    Public WithEvents txtDescripcionCuenta As TextBox
    Public WithEvents btTercero As Button
    Public WithEvents btBusquedaCuenta As Button
    Friend WithEvents dtpFechaFin As DateTimePicker
    Public WithEvents Label5 As Label
    Public WithEvents Label4 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Public WithEvents btExportaExcel As Button
    Public WithEvents btVisualizaPDF As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
End Class
