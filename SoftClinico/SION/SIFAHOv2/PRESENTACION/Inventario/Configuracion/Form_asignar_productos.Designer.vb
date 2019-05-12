<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_asignar_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_asignar_productos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnVerTodos = New System.Windows.Forms.Button()
        Me.Btnasignados = New System.Windows.Forms.Button()
        Me.Asignar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBusquedaSinasignar = New System.Windows.Forms.TextBox()
        Me.dgvPorAsignar = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnVerTodos2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBusquedaASignados = New System.Windows.Forms.TextBox()
        Me.dgvAsignados = New System.Windows.Forms.DataGridView()
        Me.Lbl_Bodega = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPorAsignar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "ASIGNACIÓN DE PRODUCTOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(982, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "_________________________________________________________________________________" &
    "__________________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnVerTodos)
        Me.GroupBox1.Controls.Add(Me.Btnasignados)
        Me.GroupBox1.Controls.Add(Me.Asignar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBusquedaSinasignar)
        Me.GroupBox1.Controls.Add(Me.dgvPorAsignar)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 248)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos sin asignar"
        '
        'btnVerTodos
        '
        Me.btnVerTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerTodos.Image = Global.Celer.My.Resources.Resources.Actions_blue_arrow_undo_icon__1_
        Me.btnVerTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerTodos.Location = New System.Drawing.Point(271, 30)
        Me.btnVerTodos.Name = "btnVerTodos"
        Me.btnVerTodos.Size = New System.Drawing.Size(97, 32)
        Me.btnVerTodos.TabIndex = 7
        Me.btnVerTodos.Text = "Ver Todos"
        Me.btnVerTodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerTodos.UseVisualStyleBackColor = True
        '
        'Btnasignados
        '
        Me.Btnasignados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnasignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnasignados.Image = Global.Celer.My.Resources.Resources.Badge_tick_icon__1_
        Me.Btnasignados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btnasignados.Location = New System.Drawing.Point(136, 30)
        Me.Btnasignados.Name = "Btnasignados"
        Me.Btnasignados.Size = New System.Drawing.Size(136, 32)
        Me.Btnasignados.TabIndex = 4
        Me.Btnasignados.Text = "Ver Seleccionados"
        Me.Btnasignados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btnasignados.UseVisualStyleBackColor = True
        '
        'Asignar
        '
        Me.Asignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Asignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Asignar.Image = Global.Celer.My.Resources.Resources.Button_Add_icon__2_
        Me.Asignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Asignar.Location = New System.Drawing.Point(6, 30)
        Me.Asignar.Name = "Asignar"
        Me.Asignar.Size = New System.Drawing.Size(131, 32)
        Me.Asignar.TabIndex = 1
        Me.Asignar.Text = "Asignar a Bodega"
        Me.Asignar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Asignar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(410, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Buscar :"
        '
        'txtBusquedaSinasignar
        '
        Me.txtBusquedaSinasignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaSinasignar.Location = New System.Drawing.Point(467, 29)
        Me.txtBusquedaSinasignar.Name = "txtBusquedaSinasignar"
        Me.txtBusquedaSinasignar.Size = New System.Drawing.Size(546, 21)
        Me.txtBusquedaSinasignar.TabIndex = 5
        '
        'dgvPorAsignar
        '
        Me.dgvPorAsignar.AllowUserToAddRows = False
        Me.dgvPorAsignar.AllowUserToDeleteRows = False
        Me.dgvPorAsignar.AllowUserToResizeColumns = False
        Me.dgvPorAsignar.AllowUserToResizeRows = False
        Me.dgvPorAsignar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPorAsignar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPorAsignar.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvPorAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPorAsignar.Location = New System.Drawing.Point(6, 61)
        Me.dgvPorAsignar.MultiSelect = False
        Me.dgvPorAsignar.Name = "dgvPorAsignar"
        Me.dgvPorAsignar.RowHeadersVisible = False
        Me.dgvPorAsignar.Size = New System.Drawing.Size(1007, 178)
        Me.dgvPorAsignar.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnVerTodos2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtBusquedaASignados)
        Me.GroupBox2.Controls.Add(Me.dgvAsignados)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 307)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1019, 261)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos Asignados"
        '
        'btnVerTodos2
        '
        Me.btnVerTodos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerTodos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerTodos2.Image = Global.Celer.My.Resources.Resources.Actions_blue_arrow_undo_icon__1_
        Me.btnVerTodos2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerTodos2.Location = New System.Drawing.Point(271, 35)
        Me.btnVerTodos2.Name = "btnVerTodos2"
        Me.btnVerTodos2.Size = New System.Drawing.Size(97, 32)
        Me.btnVerTodos2.TabIndex = 8
        Me.btnVerTodos2.Text = "Ver Todos"
        Me.btnVerTodos2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerTodos2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Celer.My.Resources.Resources.Badge_tick_icon__1_
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(136, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 32)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Ver Seleccionados"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.Celer.My.Resources.Resources.Remove_icon
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(6, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 32)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Quitar de Bodega"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(410, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Buscar :"
        '
        'txtBusquedaASignados
        '
        Me.txtBusquedaASignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaASignados.Location = New System.Drawing.Point(467, 37)
        Me.txtBusquedaASignados.Name = "txtBusquedaASignados"
        Me.txtBusquedaASignados.Size = New System.Drawing.Size(546, 21)
        Me.txtBusquedaASignados.TabIndex = 11
        '
        'dgvAsignados
        '
        Me.dgvAsignados.AllowUserToAddRows = False
        Me.dgvAsignados.AllowUserToDeleteRows = False
        Me.dgvAsignados.AllowUserToResizeColumns = False
        Me.dgvAsignados.AllowUserToResizeRows = False
        Me.dgvAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAsignados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAsignados.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAsignados.Location = New System.Drawing.Point(6, 66)
        Me.dgvAsignados.MultiSelect = False
        Me.dgvAsignados.Name = "dgvAsignados"
        Me.dgvAsignados.RowHeadersVisible = False
        Me.dgvAsignados.Size = New System.Drawing.Size(1007, 189)
        Me.dgvAsignados.TabIndex = 9
        '
        'Lbl_Bodega
        '
        Me.Lbl_Bodega.AutoSize = True
        Me.Lbl_Bodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Bodega.Location = New System.Drawing.Point(747, 23)
        Me.Lbl_Bodega.Name = "Lbl_Bodega"
        Me.Lbl_Bodega.Size = New System.Drawing.Size(0, 16)
        Me.Lbl_Bodega.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.Arrows_Sync_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Form_asignar_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 582)
        Me.Controls.Add(Me.Lbl_Bodega)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1059, 620)
        Me.MinimumSize = New System.Drawing.Size(1059, 620)
        Me.Name = "Form_asignar_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPorAsignar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Asignar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvPorAsignar As DataGridView
    Friend WithEvents Btnasignados As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBusquedaSinasignar As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBusquedaASignados As TextBox
    Friend WithEvents dgvAsignados As DataGridView
    Friend WithEvents Lbl_Bodega As Label
    Friend WithEvents btnVerTodos As Button
    Friend WithEvents btnVerTodos2 As Button
End Class
