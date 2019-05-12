<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFormaPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFormaPago))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.textnumero = New System.Windows.Forms.TextBox()
        Me.rbcheque = New System.Windows.Forms.RadioButton()
        Me.rbtransferencia = New System.Windows.Forms.RadioButton()
        Me.tbnota = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbcaja = New System.Windows.Forms.RadioButton()
        Me.rbcuentaahorro = New System.Windows.Forms.RadioButton()
        Me.rbcuentacorriente = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgvPuc = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btaplicar = New System.Windows.Forms.ToolStripSplitButton()
        Me.AplicarAlPagoActualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AplicarATodosLosPagosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnoaplicar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvPuc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.textnumero)
        Me.GroupBox2.Controls.Add(Me.rbcheque)
        Me.GroupBox2.Controls.Add(Me.rbtransferencia)
        Me.GroupBox2.Controls.Add(Me.tbnota)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(310, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 95)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Medio de pago "
        '
        'textnumero
        '
        Me.textnumero.Enabled = False
        Me.textnumero.Location = New System.Drawing.Point(120, 62)
        Me.textnumero.Name = "textnumero"
        Me.textnumero.Size = New System.Drawing.Size(115, 21)
        Me.textnumero.TabIndex = 3
        Me.textnumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rbcheque
        '
        Me.rbcheque.AutoSize = True
        Me.rbcheque.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbcheque.Location = New System.Drawing.Point(7, 62)
        Me.rbcheque.Name = "rbcheque"
        Me.rbcheque.Size = New System.Drawing.Size(67, 20)
        Me.rbcheque.TabIndex = 2
        Me.rbcheque.Text = "  Cheque"
        Me.rbcheque.UseVisualStyleBackColor = True
        '
        'rbtransferencia
        '
        Me.rbtransferencia.AutoSize = True
        Me.rbtransferencia.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtransferencia.Location = New System.Drawing.Point(7, 41)
        Me.rbtransferencia.Name = "rbtransferencia"
        Me.rbtransferencia.Size = New System.Drawing.Size(95, 20)
        Me.rbtransferencia.TabIndex = 1
        Me.rbtransferencia.Text = "  Transferencia"
        Me.rbtransferencia.UseVisualStyleBackColor = True
        '
        'tbnota
        '
        Me.tbnota.AutoSize = True
        Me.tbnota.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnota.Location = New System.Drawing.Point(7, 20)
        Me.tbnota.Name = "tbnota"
        Me.tbnota.Size = New System.Drawing.Size(95, 20)
        Me.tbnota.TabIndex = 0
        Me.tbnota.Text = "  Nota bancaria"
        Me.tbnota.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "número:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbcaja)
        Me.GroupBox1.Controls.Add(Me.rbcuentaahorro)
        Me.GroupBox1.Controls.Add(Me.rbcuentacorriente)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 95)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Cuenta "
        '
        'rbcaja
        '
        Me.rbcaja.AutoSize = True
        Me.rbcaja.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbcaja.Location = New System.Drawing.Point(6, 64)
        Me.rbcaja.Name = "rbcaja"
        Me.rbcaja.Size = New System.Drawing.Size(107, 20)
        Me.rbcaja.TabIndex = 2
        Me.rbcaja.Text = "  Caja  /  Efectivo."
        Me.rbcaja.UseVisualStyleBackColor = True
        '
        'rbcuentaahorro
        '
        Me.rbcuentaahorro.AutoSize = True
        Me.rbcuentaahorro.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbcuentaahorro.Location = New System.Drawing.Point(6, 42)
        Me.rbcuentaahorro.Name = "rbcuentaahorro"
        Me.rbcuentaahorro.Size = New System.Drawing.Size(140, 20)
        Me.rbcuentaahorro.TabIndex = 1
        Me.rbcuentaahorro.Text = "  Banco – Cuenta Ahorro"
        Me.rbcuentaahorro.UseVisualStyleBackColor = True
        '
        'rbcuentacorriente
        '
        Me.rbcuentacorriente.AutoSize = True
        Me.rbcuentacorriente.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbcuentacorriente.Location = New System.Drawing.Point(6, 20)
        Me.rbcuentacorriente.Name = "rbcuentacorriente"
        Me.rbcuentacorriente.Size = New System.Drawing.Size(150, 20)
        Me.rbcuentacorriente.TabIndex = 0
        Me.rbcuentacorriente.Text = "  Banco – Cuenta Corriente"
        Me.rbcuentacorriente.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Celer.My.Resources.Resources.tools__1_
        Me.PictureBox1.Location = New System.Drawing.Point(7, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 35
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "CONFIGURACION FORMA PAGO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label3.Location = New System.Drawing.Point(49, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(856, 20)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "_________________________________________________________________________________" &
    "________________________________________"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(919, 480)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgvPuc)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 103)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(907, 365)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Elija una cuenta "
        '
        'dgvPuc
        '
        Me.dgvPuc.AllowUserToAddRows = False
        Me.dgvPuc.AllowUserToDeleteRows = False
        Me.dgvPuc.AllowUserToResizeColumns = False
        Me.dgvPuc.AllowUserToResizeRows = False
        Me.dgvPuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPuc.BackgroundColor = System.Drawing.Color.White
        Me.dgvPuc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPuc.Location = New System.Drawing.Point(3, 17)
        Me.dgvPuc.MultiSelect = False
        Me.dgvPuc.Name = "dgvPuc"
        Me.dgvPuc.ReadOnly = True
        Me.dgvPuc.RowHeadersWidth = 22
        Me.dgvPuc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPuc.Size = New System.Drawing.Size(901, 345)
        Me.dgvPuc.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btaplicar, Me.ToolStripSeparator1, Me.btnoaplicar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 527)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 29)
        Me.ToolStrip1.TabIndex = 37
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btaplicar
        '
        Me.btaplicar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AplicarAlPagoActualToolStripMenuItem, Me.AplicarATodosLosPagosToolStripMenuItem})
        Me.btaplicar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btaplicar.ForeColor = System.Drawing.Color.White
        Me.btaplicar.Image = CType(resources.GetObject("btaplicar.Image"), System.Drawing.Image)
        Me.btaplicar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btaplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btaplicar.Name = "btaplicar"
        Me.btaplicar.Size = New System.Drawing.Size(93, 26)
        Me.btaplicar.Text = "Aplicar"
        Me.btaplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'AplicarAlPagoActualToolStripMenuItem
        '
        Me.AplicarAlPagoActualToolStripMenuItem.Name = "AplicarAlPagoActualToolStripMenuItem"
        Me.AplicarAlPagoActualToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.AplicarAlPagoActualToolStripMenuItem.Text = "Aplicar al pago actual"
        '
        'AplicarATodosLosPagosToolStripMenuItem
        '
        Me.AplicarATodosLosPagosToolStripMenuItem.Name = "AplicarATodosLosPagosToolStripMenuItem"
        Me.AplicarATodosLosPagosToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.AplicarATodosLosPagosToolStripMenuItem.Text = "Aplicar a todos los pagos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'btnoaplicar
        '
        Me.btnoaplicar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnoaplicar.Image = CType(resources.GetObject("btnoaplicar.Image"), System.Drawing.Image)
        Me.btnoaplicar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnoaplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnoaplicar.Name = "btnoaplicar"
        Me.btnoaplicar.Size = New System.Drawing.Size(81, 26)
        Me.btnoaplicar.Text = "Cancelar"
        Me.btnoaplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'FormFormaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(942, 595)
        Me.MinimumSize = New System.Drawing.Size(942, 595)
        Me.Name = "FormFormaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvPuc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents textnumero As TextBox
    Friend WithEvents rbcheque As RadioButton
    Friend WithEvents rbtransferencia As RadioButton
    Friend WithEvents tbnota As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbcaja As RadioButton
    Friend WithEvents rbcuentaahorro As RadioButton
    Friend WithEvents rbcuentacorriente As RadioButton
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents Label3 As Label
    Public WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgvPuc As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btaplicar As ToolStripSplitButton
    Friend WithEvents AplicarAlPagoActualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AplicarATodosLosPagosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnoaplicar As ToolStripButton
End Class
