<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_maestro_capacitacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_maestro_capacitacion))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvcapacitacion = New System.Windows.Forms.DataGridView()
        Me.Num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tema = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New Celer.DataGridViewDateTimePickerColumn()
        Me.Id_capacitador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.capacitador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dirigido_A = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Asistentes = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANULAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btbuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Textcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Textced_resp = New System.Windows.Forms.TextBox()
        Me.Btbuscar_respo = New System.Windows.Forms.Button()
        Me.Dom_años = New System.Windows.Forms.DomainUpDown()
        Me.Textresponsable = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvcapacitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvcapacitacion)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1022, 356)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'dgvcapacitacion
        '
        Me.dgvcapacitacion.AllowUserToAddRows = False
        Me.dgvcapacitacion.AllowUserToDeleteRows = False
        Me.dgvcapacitacion.AllowUserToResizeColumns = False
        Me.dgvcapacitacion.AllowUserToResizeRows = False
        Me.dgvcapacitacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvcapacitacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvcapacitacion.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvcapacitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcapacitacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Num, Me.Codigo, Me.Tema, Me.Fecha, Me.Id_capacitador, Me.capacitador, Me.Dirigido_A, Me.Asistentes, Me.Accion, Me.ANULAR})
        Me.dgvcapacitacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvcapacitacion.Location = New System.Drawing.Point(3, 17)
        Me.dgvcapacitacion.Name = "dgvcapacitacion"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvcapacitacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvcapacitacion.Size = New System.Drawing.Size(1016, 336)
        Me.dgvcapacitacion.TabIndex = 10016
        '
        'Num
        '
        Me.Num.HeaderText = "Num"
        Me.Num.Name = "Num"
        Me.Num.Visible = False
        Me.Num.Width = 55
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 67
        '
        'Tema
        '
        Me.Tema.HeaderText = "Tema"
        Me.Tema.Name = "Tema"
        Me.Tema.Width = 59
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 41
        '
        'Id_capacitador
        '
        Me.Id_capacitador.HeaderText = "Id capacitador"
        Me.Id_capacitador.Name = "Id_capacitador"
        Me.Id_capacitador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Id_capacitador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Id_capacitador.Width = 79
        '
        'capacitador
        '
        Me.capacitador.HeaderText = "Capacitador"
        Me.capacitador.Name = "capacitador"
        Me.capacitador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.capacitador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.capacitador.Width = 69
        '
        'Dirigido_A
        '
        Me.Dirigido_A.HeaderText = "Dirigido A"
        Me.Dirigido_A.Name = "Dirigido_A"
        Me.Dirigido_A.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dirigido_A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Dirigido_A.Width = 81
        '
        'Asistentes
        '
        Me.Asistentes.HeaderText = "Asistentes"
        Me.Asistentes.Name = "Asistentes"
        Me.Asistentes.Width = 61
        '
        'Accion
        '
        Me.Accion.HeaderText = "Accion"
        Me.Accion.Name = "Accion"
        Me.Accion.Visible = False
        Me.Accion.Width = 65
        '
        'ANULAR
        '
        Me.ANULAR.HeaderText = "ANULAR"
        Me.ANULAR.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.ANULAR.Name = "ANULAR"
        Me.ANULAR.Width = 55
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.btbuscar, Me.ToolStripSeparator4, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator2, Me.btimprimir, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 10015
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnuevo
        '
        Me.btnuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnuevo.Image = Global.Celer.My.Resources.Resources.Document_Add_icon__1_
        Me.btnuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnuevo.Name = "btnuevo"
        Me.btnuevo.Size = New System.Drawing.Size(46, 51)
        Me.btnuevo.Text = "&Nuevo"
        Me.btnuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'btguardar
        '
        Me.btguardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btguardar.Image = Global.Celer.My.Resources.Resources._04_Save_icon
        Me.btguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(53, 51)
        Me.btguardar.Text = "&Guardar"
        Me.btguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'btbuscar
        '
        Me.btbuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbuscar.Image = Global.Celer.My.Resources.Resources.Actions_page_zoom_icon__1_
        Me.btbuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(46, 51)
        Me.btbuscar.Text = "&Buscar"
        Me.btbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'bteditar
        '
        Me.bteditar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bteditar.Image = Global.Celer.My.Resources.Resources.edit_file_icon__1_
        Me.bteditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bteditar.Name = "bteditar"
        Me.bteditar.Size = New System.Drawing.Size(41, 51)
        Me.bteditar.Text = "&Editar"
        Me.bteditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
        '
        'btcancelar
        '
        Me.btcancelar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancelar.Image = Global.Celer.My.Resources.Resources.Actions_blue_arrow_undo_icon__1_
        Me.btcancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btcancelar.Name = "btcancelar"
        Me.btcancelar.Size = New System.Drawing.Size(56, 51)
        Me.btcancelar.Text = "&Cancelar"
        Me.btcancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 54)
        '
        'btanular
        '
        Me.btanular.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btanular.Image = Global.Celer.My.Resources.Resources.Document_Delete_icon__1_
        Me.btanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btanular.Name = "btanular"
        Me.btanular.Size = New System.Drawing.Size(46, 51)
        Me.btanular.Text = "&Anular"
        Me.btanular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'btimprimir
        '
        Me.btimprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btimprimir.Image = Global.Celer.My.Resources.Resources.Printer_icon
        Me.btimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(58, 51)
        Me.btimprimir.Text = "&Imprimir"
        Me.btimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Textcodigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Textced_resp)
        Me.GroupBox1.Controls.Add(Me.Btbuscar_respo)
        Me.GroupBox1.Controls.Add(Me.Dom_años)
        Me.GroupBox1.Controls.Add(Me.Textresponsable)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1021, 85)
        Me.GroupBox1.TabIndex = 10016
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'Textcodigo
        '
        Me.Textcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Textcodigo.Location = New System.Drawing.Point(100, 20)
        Me.Textcodigo.Name = "Textcodigo"
        Me.Textcodigo.ReadOnly = True
        Me.Textcodigo.Size = New System.Drawing.Size(120, 21)
        Me.Textcodigo.TabIndex = 10023
        Me.Textcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 10022
        Me.Label1.Text = "Codigo.:"
        '
        'Textced_resp
        '
        Me.Textced_resp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Textced_resp.Location = New System.Drawing.Point(100, 51)
        Me.Textced_resp.Name = "Textced_resp"
        Me.Textced_resp.ReadOnly = True
        Me.Textced_resp.Size = New System.Drawing.Size(120, 21)
        Me.Textced_resp.TabIndex = 10021
        Me.Textced_resp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btbuscar_respo
        '
        Me.Btbuscar_respo.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.Btbuscar_respo.Location = New System.Drawing.Point(824, 50)
        Me.Btbuscar_respo.Name = "Btbuscar_respo"
        Me.Btbuscar_respo.Size = New System.Drawing.Size(25, 23)
        Me.Btbuscar_respo.TabIndex = 10020
        Me.Btbuscar_respo.UseVisualStyleBackColor = True
        '
        'Dom_años
        '
        Me.Dom_años.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Dom_años.Location = New System.Drawing.Point(926, 51)
        Me.Dom_años.Name = "Dom_años"
        Me.Dom_años.Size = New System.Drawing.Size(89, 21)
        Me.Dom_años.TabIndex = 58
        Me.Dom_años.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Textresponsable
        '
        Me.Textresponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Textresponsable.Location = New System.Drawing.Point(226, 51)
        Me.Textresponsable.Name = "Textresponsable"
        Me.Textresponsable.ReadOnly = True
        Me.Textresponsable.Size = New System.Drawing.Size(592, 21)
        Me.Textresponsable.TabIndex = 3
        Me.Textresponsable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(11, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Responsable.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(867, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Periodo.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label4.Location = New System.Drawing.Point(53, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(968, 20)
        Me.Label4.TabIndex = 10017
        Me.Label4.Text = "_________________________________________________________________________________" &
    "________________________________________________________"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(54, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(211, 16)
        Me.Label5.TabIndex = 10019
        Me.Label5.Text = "PLAN MAESTRO DE CAPACITACIONES"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "ANULAR"
        Me.DataGridViewImageColumn1.Image = Global.Celer.My.Resources.Resources.trash_icon
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 43
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.order_history_icon
        Me.PictureBox1.Location = New System.Drawing.Point(11, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10018
        Me.PictureBox1.TabStop = False
        '
        'Form_maestro_capacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "Form_maestro_capacitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvcapacitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents btbuscar As ToolStripButton
    Public WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents btimprimir As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents dgvcapacitacion As DataGridView
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents Textresponsable As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents Label2 As Label
    Public WithEvents Dom_años As DomainUpDown
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label4 As Label
    Public WithEvents Label5 As Label
    Public WithEvents Btbuscar_respo As Button
    Public WithEvents Textced_resp As TextBox
    Public WithEvents Textcodigo As TextBox
    Public WithEvents Label1 As Label
    Public WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Public WithEvents Num As DataGridViewTextBoxColumn
    Public WithEvents Codigo As DataGridViewTextBoxColumn
    Public WithEvents Tema As DataGridViewTextBoxColumn
    Public WithEvents Fecha As DataGridViewDateTimePickerColumn
    Public WithEvents Id_capacitador As DataGridViewTextBoxColumn
    Public WithEvents capacitador As DataGridViewTextBoxColumn
    Public WithEvents Dirigido_A As DataGridViewLinkColumn
    Public WithEvents Asistentes As DataGridViewLinkColumn
    Public WithEvents Accion As DataGridViewTextBoxColumn
    Public WithEvents ANULAR As DataGridViewImageColumn
End Class
