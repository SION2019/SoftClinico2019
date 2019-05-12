<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_ver_existencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ver_existencias))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgvProductosLotes = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.pnlLotes = New System.Windows.Forms.Panel()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.lblPadre = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvDetalladoLotes = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvProductosLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLotes.SuspendLayout()
        CType(Me.dgvDetalladoLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "EXISTENCIAS EN BODEGA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.checklist48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DgvProductosLotes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtBuscar)
        Me.GroupBox1.Controls.Add(Me.pnlLotes)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(902, 492)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'DgvProductosLotes
        '
        Me.DgvProductosLotes.AllowUserToAddRows = False
        Me.DgvProductosLotes.AllowUserToDeleteRows = False
        Me.DgvProductosLotes.AllowUserToResizeColumns = False
        Me.DgvProductosLotes.AllowUserToResizeRows = False
        Me.DgvProductosLotes.BackgroundColor = System.Drawing.Color.White
        Me.DgvProductosLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProductosLotes.Location = New System.Drawing.Point(6, 55)
        Me.DgvProductosLotes.Name = "DgvProductosLotes"
        Me.DgvProductosLotes.ReadOnly = True
        Me.DgvProductosLotes.RowHeadersVisible = False
        Me.DgvProductosLotes.Size = New System.Drawing.Size(890, 431)
        Me.DgvProductosLotes.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Busqueda Producto:"
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscar.Location = New System.Drawing.Point(131, 20)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(765, 21)
        Me.TxtBuscar.TabIndex = 6
        '
        'pnlLotes
        '
        Me.pnlLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLotes.Controls.Add(Me.txtMarca)
        Me.pnlLotes.Controls.Add(Me.Label3)
        Me.pnlLotes.Controls.Add(Me.txtProducto)
        Me.pnlLotes.Controls.Add(Me.lblPadre)
        Me.pnlLotes.Controls.Add(Me.Button1)
        Me.pnlLotes.Controls.Add(Me.dgvDetalladoLotes)
        Me.pnlLotes.Location = New System.Drawing.Point(6, 55)
        Me.pnlLotes.Name = "pnlLotes"
        Me.pnlLotes.Size = New System.Drawing.Size(890, 431)
        Me.pnlLotes.TabIndex = 20
        Me.pnlLotes.Visible = False
        '
        'txtMarca
        '
        Me.txtMarca.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.Location = New System.Drawing.Point(492, 5)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(254, 21)
        Me.txtMarca.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(443, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Marca:"
        '
        'txtProducto
        '
        Me.txtProducto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(73, 5)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(353, 21)
        Me.txtProducto.TabIndex = 21
        '
        'lblPadre
        '
        Me.lblPadre.AutoSize = True
        Me.lblPadre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPadre.Location = New System.Drawing.Point(8, 8)
        Me.lblPadre.Name = "lblPadre"
        Me.lblPadre.Size = New System.Drawing.Size(59, 15)
        Me.lblPadre.TabIndex = 21
        Me.lblPadre.Text = "Producto:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(810, 403)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Salir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvDetalladoLotes
        '
        Me.dgvDetalladoLotes.AllowUserToAddRows = False
        Me.dgvDetalladoLotes.AllowUserToDeleteRows = False
        Me.dgvDetalladoLotes.AllowUserToResizeColumns = False
        Me.dgvDetalladoLotes.AllowUserToResizeRows = False
        Me.dgvDetalladoLotes.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalladoLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalladoLotes.Location = New System.Drawing.Point(3, 32)
        Me.dgvDetalladoLotes.Name = "dgvDetalladoLotes"
        Me.dgvDetalladoLotes.ReadOnly = True
        Me.dgvDetalladoLotes.RowHeadersVisible = False
        Me.dgvDetalladoLotes.Size = New System.Drawing.Size(882, 365)
        Me.dgvDetalladoLotes.TabIndex = 20
        '
        'Form_ver_existencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 557)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "Form_ver_existencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvProductosLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLotes.ResumeLayout(False)
        Me.pnlLotes.PerformLayout()
        CType(Me.dgvDetalladoLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents DgvProductosLotes As DataGridView
    Friend WithEvents pnlLotes As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvDetalladoLotes As DataGridView
    Friend WithEvents lblPadre As Label
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProducto As TextBox
End Class
