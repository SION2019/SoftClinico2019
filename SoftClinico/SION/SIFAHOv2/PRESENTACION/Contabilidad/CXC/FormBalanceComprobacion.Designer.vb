﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBalanceComprobacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBalanceComprobacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgBalance = New System.Windows.Forms.DataGridView()
        Me.btExportaExcel = New System.Windows.Forms.Button()
        Me.btVisualizaPDF = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbTipoDetalle = New System.Windows.Forms.GroupBox()
        Me.rbCuentaTercero = New System.Windows.Forms.RadioButton()
        Me.rbCuenta = New System.Windows.Forms.RadioButton()
        Me.rbTodas = New System.Windows.Forms.RadioButton()
        Me.rbResultado = New System.Windows.Forms.RadioButton()
        Me.rbBalance = New System.Windows.Forms.RadioButton()
        Me.gbTipoCuenta = New System.Windows.Forms.GroupBox()
        Me.gbDatosGrupo = New System.Windows.Forms.GroupBox()
        Me.btCalcular = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbTipoDetalle.SuspendLayout()
        Me.gbDatosGrupo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "BALANCE DE COMPROBACION DE SALDOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.gbDatosGrupo)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(904, 493)
        Me.GroupBox2.TabIndex = 10007
        Me.GroupBox2.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgBalance)
        Me.GroupBox5.Controls.Add(Me.btExportaExcel)
        Me.GroupBox5.Controls.Add(Me.btVisualizaPDF)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 152)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(872, 333)
        Me.GroupBox5.TabIndex = 60032
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Vista Previa"
        '
        'dgBalance
        '
        Me.dgBalance.AllowUserToAddRows = False
        Me.dgBalance.AllowUserToDeleteRows = False
        Me.dgBalance.AllowUserToResizeColumns = False
        Me.dgBalance.AllowUserToResizeRows = False
        Me.dgBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBalance.Location = New System.Drawing.Point(17, 23)
        Me.dgBalance.Name = "dgBalance"
        Me.dgBalance.ReadOnly = True
        Me.dgBalance.RowHeadersVisible = False
        Me.dgBalance.Size = New System.Drawing.Size(841, 260)
        Me.dgBalance.TabIndex = 60030
        '
        'btExportaExcel
        '
        Me.btExportaExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btExportaExcel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExportaExcel.Image = Global.Celer.My.Resources.Resources.Excel_icon__1_
        Me.btExportaExcel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btExportaExcel.Location = New System.Drawing.Point(150, 290)
        Me.btExportaExcel.Name = "btExportaExcel"
        Me.btExportaExcel.Size = New System.Drawing.Size(130, 34)
        Me.btExportaExcel.TabIndex = 60029
        Me.btExportaExcel.Text = "Exportar a Excel"
        Me.btExportaExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btExportaExcel.UseVisualStyleBackColor = True
        '
        'btVisualizaPDF
        '
        Me.btVisualizaPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btVisualizaPDF.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btVisualizaPDF.Image = Global.Celer.My.Resources.Resources.Adobe_PDF_Document_icon
        Me.btVisualizaPDF.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btVisualizaPDF.Location = New System.Drawing.Point(17, 289)
        Me.btVisualizaPDF.Name = "btVisualizaPDF"
        Me.btVisualizaPDF.Size = New System.Drawing.Size(130, 34)
        Me.btVisualizaPDF.TabIndex = 60028
        Me.btVisualizaPDF.Text = "Generar Reporte"
        Me.btVisualizaPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btVisualizaPDF.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbTipoDetalle)
        Me.GroupBox1.Controls.Add(Me.rbTodas)
        Me.GroupBox1.Controls.Add(Me.rbResultado)
        Me.GroupBox1.Controls.Add(Me.rbBalance)
        Me.GroupBox1.Controls.Add(Me.gbTipoCuenta)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(479, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 131)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones del informe"
        '
        'gbTipoDetalle
        '
        Me.gbTipoDetalle.Controls.Add(Me.rbCuentaTercero)
        Me.gbTipoDetalle.Controls.Add(Me.rbCuenta)
        Me.gbTipoDetalle.Location = New System.Drawing.Point(201, 21)
        Me.gbTipoDetalle.Name = "gbTipoDetalle"
        Me.gbTipoDetalle.Size = New System.Drawing.Size(189, 103)
        Me.gbTipoDetalle.TabIndex = 19
        Me.gbTipoDetalle.TabStop = False
        Me.gbTipoDetalle.Text = "Detalle"
        '
        'rbCuentaTercero
        '
        Me.rbCuentaTercero.AutoSize = True
        Me.rbCuentaTercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbCuentaTercero.Location = New System.Drawing.Point(18, 57)
        Me.rbCuentaTercero.Name = "rbCuentaTercero"
        Me.rbCuentaTercero.Size = New System.Drawing.Size(129, 19)
        Me.rbCuentaTercero.TabIndex = 19
        Me.rbCuentaTercero.Text = "Cuentas y Terceros"
        Me.rbCuentaTercero.UseVisualStyleBackColor = True
        '
        'rbCuenta
        '
        Me.rbCuenta.AutoSize = True
        Me.rbCuenta.Checked = True
        Me.rbCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbCuenta.Location = New System.Drawing.Point(18, 33)
        Me.rbCuenta.Name = "rbCuenta"
        Me.rbCuenta.Size = New System.Drawing.Size(70, 19)
        Me.rbCuenta.TabIndex = 18
        Me.rbCuenta.TabStop = True
        Me.rbCuenta.Text = "Cuentas"
        Me.rbCuenta.UseVisualStyleBackColor = True
        '
        'rbTodas
        '
        Me.rbTodas.AutoSize = True
        Me.rbTodas.Checked = True
        Me.rbTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbTodas.Location = New System.Drawing.Point(32, 92)
        Me.rbTodas.Name = "rbTodas"
        Me.rbTodas.Size = New System.Drawing.Size(59, 19)
        Me.rbTodas.TabIndex = 2
        Me.rbTodas.TabStop = True
        Me.rbTodas.Text = "Todas"
        Me.rbTodas.UseVisualStyleBackColor = True
        '
        'rbResultado
        '
        Me.rbResultado.AutoSize = True
        Me.rbResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbResultado.Location = New System.Drawing.Point(32, 65)
        Me.rbResultado.Name = "rbResultado"
        Me.rbResultado.Size = New System.Drawing.Size(87, 19)
        Me.rbResultado.TabIndex = 1
        Me.rbResultado.Text = "Resultados"
        Me.rbResultado.UseVisualStyleBackColor = True
        '
        'rbBalance
        '
        Me.rbBalance.AutoSize = True
        Me.rbBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbBalance.Location = New System.Drawing.Point(32, 41)
        Me.rbBalance.Name = "rbBalance"
        Me.rbBalance.Size = New System.Drawing.Size(70, 19)
        Me.rbBalance.TabIndex = 0
        Me.rbBalance.Text = "Balance"
        Me.rbBalance.UseVisualStyleBackColor = True
        '
        'gbTipoCuenta
        '
        Me.gbTipoCuenta.Location = New System.Drawing.Point(13, 20)
        Me.gbTipoCuenta.Name = "gbTipoCuenta"
        Me.gbTipoCuenta.Size = New System.Drawing.Size(182, 104)
        Me.gbTipoCuenta.TabIndex = 18
        Me.gbTipoCuenta.TabStop = False
        Me.gbTipoCuenta.Text = "Naturaleza"
        '
        'gbDatosGrupo
        '
        Me.gbDatosGrupo.Controls.Add(Me.btCalcular)
        Me.gbDatosGrupo.Controls.Add(Me.Label4)
        Me.gbDatosGrupo.Controls.Add(Me.dtpFechaFin)
        Me.gbDatosGrupo.Controls.Add(Me.dtpFechaInicio)
        Me.gbDatosGrupo.Controls.Add(Me.Label5)
        Me.gbDatosGrupo.Controls.Add(Me.txtRazonSocial)
        Me.gbDatosGrupo.Controls.Add(Me.txtNit)
        Me.gbDatosGrupo.Controls.Add(Me.Label11)
        Me.gbDatosGrupo.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosGrupo.Location = New System.Drawing.Point(10, 15)
        Me.gbDatosGrupo.Name = "gbDatosGrupo"
        Me.gbDatosGrupo.Size = New System.Drawing.Size(460, 131)
        Me.gbDatosGrupo.TabIndex = 16
        Me.gbDatosGrupo.TabStop = False
        Me.gbDatosGrupo.Text = "Empresa"
        '
        'btCalcular
        '
        Me.btCalcular.Image = Global.Celer.My.Resources.Resources.search_b_icon__1_
        Me.btCalcular.Location = New System.Drawing.Point(325, 81)
        Me.btCalcular.Name = "btCalcular"
        Me.btCalcular.Size = New System.Drawing.Size(130, 34)
        Me.btCalcular.TabIndex = 60032
        Me.btCalcular.Text = "Previsualizar"
        Me.btCalcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btCalcular.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 60029
        Me.Label4.Text = "Fecha Inicio:"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(99, 93)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(130, 21)
        Me.dtpFechaFin.TabIndex = 60028
        Me.dtpFechaFin.Value = New Date(2017, 1, 30, 0, 0, 0, 0)
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicio.Location = New System.Drawing.Point(100, 63)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(129, 21)
        Me.dtpFechaInicio.TabIndex = 60031
        Me.dtpFechaInicio.Value = New Date(2017, 1, 30, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 60030
        Me.Label5.Text = "Fecha fin:"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.Location = New System.Drawing.Point(196, 30)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(257, 20)
        Me.txtRazonSocial.TabIndex = 4
        '
        'txtNit
        '
        Me.txtNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNit.Location = New System.Drawing.Point(100, 30)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.ReadOnly = True
        Me.txtNit.Size = New System.Drawing.Size(87, 20)
        Me.txtNit.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 15)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Nit:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.chart_add_icon__1_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'FormBalanceComprobacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormBalanceComprobacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgBalance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbTipoDetalle.ResumeLayout(False)
        Me.gbTipoDetalle.PerformLayout()
        Me.gbDatosGrupo.ResumeLayout(False)
        Me.gbDatosGrupo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents gbDatosGrupo As GroupBox
    Public WithEvents txtRazonSocial As TextBox
    Public WithEvents txtNit As TextBox
    Public WithEvents Label11 As Label
    Public WithEvents Label4 As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Public WithEvents Label5 As Label
    Public WithEvents GroupBox1 As GroupBox
    Friend WithEvents gbTipoDetalle As GroupBox
    Friend WithEvents rbCuentaTercero As RadioButton
    Friend WithEvents rbCuenta As RadioButton
    Friend WithEvents rbTodas As RadioButton
    Friend WithEvents rbResultado As RadioButton
    Friend WithEvents rbBalance As RadioButton
    Friend WithEvents gbTipoCuenta As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Public WithEvents btExportaExcel As Button
    Public WithEvents btVisualizaPDF As Button
    Friend WithEvents dgBalance As DataGridView
    Friend WithEvents btCalcular As Button
End Class
