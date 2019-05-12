<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_tomar_huella
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim BtSalir As System.Windows.Forms.Button
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_tomar_huella))
        Me.controlleerhuella = New DPFP.Gui.Enrollment.EnrollmentControl()
        Me.GrupoEventos = New System.Windows.Forms.GroupBox()
        Me.ListEvents = New System.Windows.Forms.ListBox()
        BtSalir = New System.Windows.Forms.Button()
        Me.GrupoEventos.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtSalir
        '
        BtSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        BtSalir.DialogResult = System.Windows.Forms.DialogResult.OK
        BtSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BtSalir.Image = CType(resources.GetObject("BtSalir.Image"), System.Drawing.Image)
        BtSalir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        BtSalir.Location = New System.Drawing.Point(404, 469)
        BtSalir.Name = "BtSalir"
        BtSalir.Size = New System.Drawing.Size(80, 23)
        BtSalir.TabIndex = 2
        BtSalir.Text = TitulosForm.CANCELAR
        BtSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        BtSalir.UseVisualStyleBackColor = True
        AddHandler BtSalir.Click, AddressOf Me.BtSalir_Click
        '
        'controlleerhuella
        '
        Me.controlleerhuella.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.controlleerhuella.EnrolledFingerMask = 0
        Me.controlleerhuella.Location = New System.Drawing.Point(2, 2)
        Me.controlleerhuella.MaxEnrollFingerCount = 10
        Me.controlleerhuella.Name = "controlleerhuella"
        Me.controlleerhuella.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        Me.controlleerhuella.Size = New System.Drawing.Size(492, 314)
        Me.controlleerhuella.TabIndex = 3
        '
        'GrupoEventos
        '
        Me.GrupoEventos.Controls.Add(Me.ListEvents)
        Me.GrupoEventos.Location = New System.Drawing.Point(11, 307)
        Me.GrupoEventos.Name = "GrupoEventos"
        Me.GrupoEventos.Size = New System.Drawing.Size(473, 146)
        Me.GrupoEventos.TabIndex = 4
        Me.GrupoEventos.TabStop = False
        Me.GrupoEventos.Text = "Events"
        '
        'ListEvents
        '
        Me.ListEvents.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListEvents.FormattingEnabled = True
        Me.ListEvents.Location = New System.Drawing.Point(16, 19)
        Me.ListEvents.Name = "ListEvents"
        Me.ListEvents.Size = New System.Drawing.Size(440, 108)
        Me.ListEvents.TabIndex = 0
        '
        'form_tomar_huella
        '
        Me.AcceptButton = BtSalir
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = BtSalir
        Me.ClientSize = New System.Drawing.Size(496, 504)
        Me.Controls.Add(Me.GrupoEventos)
        Me.Controls.Add(Me.controlleerhuella)
        Me.Controls.Add(BtSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Name = "form_tomar_huella"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tomar Huella"
        Me.GrupoEventos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents controlleerhuella As DPFP.Gui.Enrollment.EnrollmentControl
    Private WithEvents GrupoEventos As System.Windows.Forms.GroupBox
    Private WithEvents ListEvents As System.Windows.Forms.ListBox
End Class
