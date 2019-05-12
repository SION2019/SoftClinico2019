Public Class FormMetas
    Private dtDimensiones As New DataTable
    Private tamanhoAporte As Integer

    Public Sub llenarDt(ByRef dt As DataTable, tamanoAporte As Integer, nombre As String, aporteActual As Double, diasCorridos As Integer, diasFaltantes As Integer)
        dtDimensiones = dt.Copy
        tamanhoAporte = tamanoAporte
        txtnombre.Text = nombre
        txtAporteActual.Text = CDbl(aporteActual).ToString("C0")
        txtDiasCorridos.Text = diasCorridos
        txtDiasFaltantes.Text = diasFaltantes
        txtProximaMeta.Text = CDbl(0).ToString("c0")
        For i = 0 To dtDimensiones.Rows.Count - 1
            If dtDimensiones.Rows(i).Item("Superada") = False Then
                txtProximaMeta.Text = CDbl(dtDimensiones.Rows(i).Item("Valor") - aporteActual).ToString("c0")
                Exit For
            End If
        Next
    End Sub
    Private Sub FormMetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pintar()
        txtnombre.Focus()
    End Sub
    Private Sub pintar()

        If dtDimensiones.Rows.Count = 1 Then
            picSostenimiento.Location = New Point(picSostenimiento.Location.X, 84)
            lblDescripcionMeta.Location = New Point(lblDescripcionMeta.Location.X, 88)
            lblSuperada.Location = New Point(lblSuperada.Location.X, 88)
        End If
        lblDescripcionMeta.Text = "Meta Sostenimiento: " & CDbl(dtDimensiones.Rows(0).Item("Valor")).ToString("c0")
        If dtDimensiones.Rows(0).Item("Superada") = False Then
            lblSuperada.Visible = False
        End If
        Dim porcentajeAlcanzado As Double
        Dim proximaMeta As Integer
        For i = 1 To dtDimensiones.Rows.Count - 1
            Dim lblMeta, lblSuperadaMeta As New Label
            Dim picMeta As New PictureBox

            lblMeta.Text = "Meta N° " & i & ": " & CDbl(dtDimensiones.Rows(i).Item("Valor")).ToString("c0")
            lblMeta.Location = New Point(lblDescripcionMeta.Location.X, dtDimensiones.Rows(i).Item("Localizacion") + 8)
            lblMeta.Size = New Size(250, 23)
            lblMeta.Font = lblDescripcionMeta.Font

            picMeta.Size = New Size(33, 30)
            picMeta.SizeMode = PictureBoxSizeMode.StretchImage
            picMeta.Location = New Point(picSostenimiento.Location.X, dtDimensiones.Rows(i).Item("Localizacion"))

            lblSuperadaMeta.Text = "SUPERADA!"
            lblSuperadaMeta.Font = lblSuperada.Font
            lblSuperadaMeta.ForeColor = lblSuperadaMeta.ForeColor
            lblSuperadaMeta.Location = New Point(lblSuperada.Location.X, dtDimensiones.Rows(i).Item("Localizacion") + 8)

            If dtDimensiones.Rows(i).Item("Superada") = True Then
                lblSuperadaMeta.Visible = True

                proximaMeta = dtDimensiones.Rows(i).Item("Porcentaje")
                picMeta.Image = My.Resources.logo_new_peq
                porcentajeAlcanzado = dtDimensiones.Rows(i).Item("Porcentaje")
            Else
                lblSuperadaMeta.Visible = False
                picMeta.Image = My.Resources.logo_new
            End If
            lblSuperadaMeta.Size = New Size(75, 23)
            With GroupBox1.Controls
                .Add(lblMeta)
                .Add(lblSuperadaMeta)
                .Add(picMeta)
            End With
            lblMeta.BringToFront()
            lblSuperadaMeta.BringToFront()
            picMeta.BringToFront()
        Next
        picAporte.Size = New Size(picAporte.Width, tamanhoAporte)
        picAporte.Location = New Point(picAporte.Location.X, 480 - tamanhoAporte)
        txtPorcentaje.Text = porcentajeAlcanzado & " %"
    End Sub

    Private Sub FormMetas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GroupBox1.Focus()
        picSostenimiento.Focus()
    End Sub
End Class