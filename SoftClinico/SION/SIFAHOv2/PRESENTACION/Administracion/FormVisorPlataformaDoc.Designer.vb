<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVisorPlataformaDoc
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVisorPlataformaDoc))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pdfArchivos = New AxAcroPDFLib.AxAcroPDF()
        Me.Timer_abrir = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_cerrar = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_rojo = New System.Windows.Forms.Timer(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Abrir = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btOpcionSabana = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pdfArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Abrir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "VISOR PLATAFORMA DOCUMENTAL"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(863, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "_________________________________________________________________________________" &
    "_________________________________________"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.pdfArchivos)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(905, 497)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'pdfArchivos
        '
        Me.pdfArchivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pdfArchivos.Enabled = True
        Me.pdfArchivos.Location = New System.Drawing.Point(3, 16)
        Me.pdfArchivos.Name = "pdfArchivos"
        Me.pdfArchivos.OcxState = CType(resources.GetObject("pdfArchivos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfArchivos.Size = New System.Drawing.Size(896, 475)
        Me.pdfArchivos.TabIndex = 4
        '
        'Timer_abrir
        '
        Me.Timer_abrir.Interval = 1
        '
        'Timer_cerrar
        '
        Me.Timer_cerrar.Interval = 1
        '
        'Timer_rojo
        '
        Me.Timer_rojo.Interval = 500
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(6, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(240, 478)
        Me.TreeView1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Mistral", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 38)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Aquí iria el Arbol"
        '
        'Abrir
        '
        Me.Abrir.BackColor = System.Drawing.Color.White
        Me.Abrir.Image = Global.Celer.My.Resources.Resources.a
        Me.Abrir.Location = New System.Drawing.Point(0, 223)
        Me.Abrir.Name = "Abrir"
        Me.Abrir.Size = New System.Drawing.Size(19, 25)
        Me.Abrir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Abrir.TabIndex = 981
        Me.Abrir.TabStop = False
        Me.Abrir.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Abrir)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Location = New System.Drawing.Point(2, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(254, 484)
        Me.Panel1.TabIndex = 29
        Me.Panel1.Visible = False
        '
        'btOpcionSabana
        '
        Me.btOpcionSabana.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOpcionSabana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btOpcionSabana.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOpcionSabana.Image = Global.Celer.My.Resources.Resources.Refresh_icon
        Me.btOpcionSabana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOpcionSabana.Location = New System.Drawing.Point(705, 4)
        Me.btOpcionSabana.Name = "btOpcionSabana"
        Me.btOpcionSabana.Size = New System.Drawing.Size(110, 34)
        Me.btOpcionSabana.TabIndex = 10055
        Me.btOpcionSabana.Text = "Recargar"
        Me.btOpcionSabana.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOpcionSabana.UseVisualStyleBackColor = True
        '
        'FormVisorPlataformaDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 556)
        Me.Controls.Add(Me.btOpcionSabana)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVisorPlataformaDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pdfArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Abrir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Public WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents pdfArchivos As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Timer_abrir As Timer
    Friend WithEvents Timer_cerrar As Timer
    Friend WithEvents Timer_rojo As Timer
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Label3 As Label
    Friend WithEvents Abrir As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btOpcionSabana As Button
End Class
