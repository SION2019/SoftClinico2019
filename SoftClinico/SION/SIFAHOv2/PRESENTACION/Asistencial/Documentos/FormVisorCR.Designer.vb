<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVisorCR
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
        Me.CrystalRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CrystalRV
        '
        Me.CrystalRV.ActiveViewIndex = -1
        Me.CrystalRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalRV.Location = New System.Drawing.Point(0, 0)
        Me.CrystalRV.Name = "CrystalRV"
        Me.CrystalRV.Size = New System.Drawing.Size(828, 455)
        Me.CrystalRV.TabIndex = 0
        '
        'FormVisorCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(828, 455)
        Me.Controls.Add(Me.CrystalRV)
        Me.Name = "FormVisorCR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormVisorCR"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
