<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SOAT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SOAT))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BUSCARMAN = New System.Windows.Forms.Button()
        Me.dgvprocedimiento = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btguardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.bteditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btcancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btanular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btOpcionArticulo = New System.Windows.Forms.Button()
        Me.btOpcionCapitulo = New System.Windows.Forms.Button()
        Me.btOpcionGrupo = New System.Windows.Forms.Button()
        Me.btOpcionGrupoQX = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btOpcionSeccion = New System.Windows.Forms.Button()
        Me.btOpcionSala = New System.Windows.Forms.Button()
        Me.btOpcionCapArticulo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvprocedimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DESCRIPCION)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.BUSCARMAN)
        Me.GroupBox1.Controls.Add(Me.dgvprocedimiento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1018, 470)
        Me.GroupBox1.TabIndex = 10029
        Me.GroupBox1.TabStop = False
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DESCRIPCION.Location = New System.Drawing.Point(270, 13)
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Size = New System.Drawing.Size(736, 21)
        Me.DESCRIPCION.TabIndex = 10055
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(192, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 15)
        Me.Label9.TabIndex = 10054
        Me.Label9.Text = "Descripción:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(103, 13)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(58, 21)
        Me.txtCodigo.TabIndex = 10052
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 15)
        Me.Label10.TabIndex = 10053
        Me.Label10.Text = "Código manual:"
        '
        'BUSCARMAN
        '
        Me.BUSCARMAN.Image = Global.Celer.My.Resources.Resources.Zoom_icon1
        Me.BUSCARMAN.Location = New System.Drawing.Point(163, 12)
        Me.BUSCARMAN.Name = "BUSCARMAN"
        Me.BUSCARMAN.Size = New System.Drawing.Size(25, 23)
        Me.BUSCARMAN.TabIndex = 10051
        Me.BUSCARMAN.UseVisualStyleBackColor = True
        '
        'dgvprocedimiento
        '
        Me.dgvprocedimiento.AllowUserToAddRows = False
        Me.dgvprocedimiento.AllowUserToDeleteRows = False
        Me.dgvprocedimiento.AllowUserToResizeColumns = False
        Me.dgvprocedimiento.AllowUserToResizeRows = False
        Me.dgvprocedimiento.BackgroundColor = System.Drawing.Color.White
        Me.dgvprocedimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvprocedimiento.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvprocedimiento.Location = New System.Drawing.Point(12, 76)
        Me.dgvprocedimiento.Name = "dgvprocedimiento"
        Me.dgvprocedimiento.ReadOnly = True
        Me.dgvprocedimiento.RowHeadersVisible = False
        Me.dgvprocedimiento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvprocedimiento.Size = New System.Drawing.Size(994, 388)
        Me.dgvprocedimiento.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Búsqueda:"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(103, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(903, 21)
        Me.TextBox1.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnuevo, Me.ToolStripSeparator1, Me.btguardar, Me.ToolStripSeparator3, Me.bteditar, Me.ToolStripSeparator5, Me.btcancelar, Me.ToolStripSeparator6, Me.btanular, Me.ToolStripSeparator2, Me.btimprimir, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 54)
        Me.ToolStrip1.TabIndex = 10028
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
        Me.btguardar.Enabled = False
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
        Me.btcancelar.Enabled = False
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
        Me.btanular.Enabled = False
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
        Me.btimprimir.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 54)
        Me.ToolStripSeparator7.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 10025
        Me.Label1.Text = "CODIFICACIÓN SOAT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(982, 20)
        Me.Label2.TabIndex = 10026
        Me.Label2.Text = "_________________________________________________________________________________" &
    "__________________________________________________________"
        '
        'btOpcionArticulo
        '
        Me.btOpcionArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionArticulo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionArticulo.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionArticulo.Location = New System.Drawing.Point(569, 3)
        Me.btOpcionArticulo.Name = "btOpcionArticulo"
        Me.btOpcionArticulo.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionArticulo.TabIndex = 10034
        Me.btOpcionArticulo.Text = "Articulos"
        Me.btOpcionArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionArticulo.UseVisualStyleBackColor = True
        Me.btOpcionArticulo.Visible = False
        '
        'btOpcionCapitulo
        '
        Me.btOpcionCapitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionCapitulo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionCapitulo.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionCapitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionCapitulo.Location = New System.Drawing.Point(452, 3)
        Me.btOpcionCapitulo.Name = "btOpcionCapitulo"
        Me.btOpcionCapitulo.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionCapitulo.TabIndex = 10033
        Me.btOpcionCapitulo.Text = "Capitulos"
        Me.btOpcionCapitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionCapitulo.UseVisualStyleBackColor = True
        Me.btOpcionCapitulo.Visible = False
        '
        'btOpcionGrupo
        '
        Me.btOpcionGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionGrupo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionGrupo.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionGrupo.Location = New System.Drawing.Point(335, 3)
        Me.btOpcionGrupo.Name = "btOpcionGrupo"
        Me.btOpcionGrupo.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionGrupo.TabIndex = 10032
        Me.btOpcionGrupo.Text = "Grupos"
        Me.btOpcionGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionGrupo.UseVisualStyleBackColor = True
        Me.btOpcionGrupo.Visible = False
        '
        'btOpcionGrupoQX
        '
        Me.btOpcionGrupoQX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionGrupoQX.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionGrupoQX.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionGrupoQX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionGrupoQX.Location = New System.Drawing.Point(218, 3)
        Me.btOpcionGrupoQX.Name = "btOpcionGrupoQX"
        Me.btOpcionGrupoQX.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionGrupoQX.TabIndex = 10030
        Me.btOpcionGrupoQX.Text = "Grupos QX"
        Me.btOpcionGrupoQX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionGrupoQX.UseVisualStyleBackColor = True
        Me.btOpcionGrupoQX.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Actions_view_list_details_icon1
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10027
        Me.PictureBox1.TabStop = False
        '
        'btOpcionSeccion
        '
        Me.btOpcionSeccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionSeccion.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionSeccion.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionSeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionSeccion.Location = New System.Drawing.Point(686, 3)
        Me.btOpcionSeccion.Name = "btOpcionSeccion"
        Me.btOpcionSeccion.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionSeccion.TabIndex = 10035
        Me.btOpcionSeccion.Text = "Secciones"
        Me.btOpcionSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionSeccion.UseVisualStyleBackColor = True
        Me.btOpcionSeccion.Visible = False
        '
        'btOpcionSala
        '
        Me.btOpcionSala.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionSala.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionSala.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionSala.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionSala.Location = New System.Drawing.Point(803, 3)
        Me.btOpcionSala.Name = "btOpcionSala"
        Me.btOpcionSala.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionSala.TabIndex = 10036
        Me.btOpcionSala.Text = "Salas de Proc."
        Me.btOpcionSala.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionSala.UseVisualStyleBackColor = True
        Me.btOpcionSala.Visible = False
        '
        'btOpcionCapArticulo
        '
        Me.btOpcionCapArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionCapArticulo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionCapArticulo.Image = Global.Celer.My.Resources.Resources.Setting_icon__1_
        Me.btOpcionCapArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionCapArticulo.Location = New System.Drawing.Point(920, 3)
        Me.btOpcionCapArticulo.Name = "btOpcionCapArticulo"
        Me.btOpcionCapArticulo.Size = New System.Drawing.Size(111, 34)
        Me.btOpcionCapArticulo.TabIndex = 10037
        Me.btOpcionCapArticulo.Text = "Capitulos Art."
        Me.btOpcionCapArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionCapArticulo.UseVisualStyleBackColor = True
        Me.btOpcionCapArticulo.Visible = False
        '
        'Form_SOAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 581)
        Me.Controls.Add(Me.btOpcionCapArticulo)
        Me.Controls.Add(Me.btOpcionSala)
        Me.Controls.Add(Me.btOpcionSeccion)
        Me.Controls.Add(Me.btOpcionArticulo)
        Me.Controls.Add(Me.btOpcionCapitulo)
        Me.Controls.Add(Me.btOpcionGrupo)
        Me.Controls.Add(Me.btOpcionGrupoQX)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "Form_SOAT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvprocedimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents btOpcionArticulo As Button
    Public WithEvents btOpcionCapitulo As Button
    Public WithEvents btOpcionGrupo As Button
    Public WithEvents btOpcionGrupoQX As Button
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents dgvprocedimiento As DataGridView
    Public WithEvents Label3 As Label
    Public WithEvents TextBox1 As TextBox
    Public WithEvents ToolStrip1 As ToolStrip
    Public WithEvents btnuevo As ToolStripButton
    Public WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents btguardar As ToolStripButton
    Public WithEvents ToolStripSeparator3 As ToolStripSeparator
    Public WithEvents bteditar As ToolStripButton
    Public WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents btcancelar As ToolStripButton
    Public WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents btanular As ToolStripButton
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents btimprimir As ToolStripButton
    Public WithEvents ToolStripSeparator7 As ToolStripSeparator
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents btOpcionSeccion As Button
    Public WithEvents btOpcionSala As Button
    Public WithEvents btOpcionCapArticulo As Button
    Public WithEvents DESCRIPCION As TextBox
    Public WithEvents Label9 As Label
    Public WithEvents txtCodigo As TextBox
    Public WithEvents Label10 As Label
    Public WithEvents BUSCARMAN As Button
End Class
