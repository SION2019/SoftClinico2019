
Public Class FormModulosEmpresa
    Public Codigo_punto As String
    Dim fprincipal As New PrincipalDAL
    Dim mempresa As New EmpresaModuloDAL
    Dim contadorEspecial As Integer
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormModulosEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        habilitarBt()
    End Sub
    Private Sub habilitarBt()
        Dim dt As DataTable
        dt = mempresa.cargar(Codigo_punto, SesionActual.idEmpresa)
        If dt.Rows.Count > 0 Then
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_ADMON & "'").Count > 0 Then
                R1.Checked = True
            Else
                R1.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_AMBU & "'").Count > 0 Then
                r2.Checked = True
            Else
                r2.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_ASIS & "'").Count > 0 Then
                r3.Checked = True
            Else
                r3.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_CONTA & "'").Count > 0 Then
                r4.Checked = True
            Else
                r4.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_FARMA & "'").Count > 0 Then
                r5.Checked = True
            Else
                r5.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_HEMO & "'").Count > 0 Then
                r6.Checked = True
            Else
                r6.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_IMAG & "'").Count > 0 Then
                r7.Checked = True
            Else
                r7.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_INVEN & "'").Count > 0 Then
                r8.Checked = True
            Else
                r8.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_LAB & "'").Count > 0 Then
                r9.Checked = True
            Else
                r9.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_NOM & "'").Count > 0 Then
                r10.Checked = True
            Else
                r10.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_HISTC & "'").Count > 0 Then
                r11.Checked = True
            Else
                r11.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_AUDM & "'").Count > 0 Then
                r12.Checked = True
            Else
                r12.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_AUDF & "'").Count > 0 Then
                r13.Checked = True
            Else
                r13.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_CEXT & "'").Count > 0 Then
                r14.Checked = True
            Else
                r14.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_QUIR & "'").Count > 0 Then
                R17.Checked = True
            Else
                R17.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_HOSP & "'").Count > 0 Then
                r15.Checked = True
            Else
                r15.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_URG & "'").Count > 0 Then
                r16.Checked = True
            Else
                r16.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.CODIGO_MENU_SOCG & "'").Count > 0 Then
                R19.Checked = True
            Else
                R19.Checked = False
            End If
            If dt.Select("Codigo_Menu='" & Constantes.OPCION_ESPECIAL & "'").Count > 0 Then
                rEspecial.Checked = True
            Else
                rEspecial.Checked = False
            End If
        End If
        pnlEspecial.Visible = False
        gbEspecial.Visible = False
        contadorEspecial = 0

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If r3.Checked = False Then
            r3.Checked = True
            r8.Checked = True
            r11.Checked = True
        Else
            r3.Checked = False
            r11.Checked = False
            If r5.Checked = False And r6.Checked = False And r9.Checked = False Then
                r8.Checked = False
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If r2.Checked = False Then
            r2.Checked = True
        Else
            r2.Checked = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If r4.Checked = False Then
            r4.Checked = True
        Else
            r4.Checked = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If r5.Checked = False Then
            r5.Checked = True
            r8.Checked = True
        Else
            r5.Checked = False
            If r3.Checked = False And r6.Checked = False And r9.Checked = False Then
                r8.Checked = False
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If r6.Checked = False Then
            r6.Checked = True
            r8.Checked = True
        Else
            r6.Checked = False
            If r3.Checked = False And r5.Checked = False And r9.Checked = False Then
                r8.Checked = False
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If r7.Checked = False Then
            r7.Checked = True
        Else
            r7.Checked = False
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If r8.Checked = False Then
            If r3.Checked = True Or r5.Checked = True Or r6.Checked = True Or r9.Checked = True Then
                r8.Checked = True
            Else
                MsgBox("Seleccione alguno de estos módulos: " + vbCrLf + "      Asistencial" + vbCrLf + "      Farmacia" + vbCrLf + "      Hemodinámia" + vbCrLf + "      Laboratorio", MsgBoxStyle.Information)
            End If

        Else
            r3.Checked = False
            r5.Checked = False
            r6.Checked = False
            r9.Checked = False
            r8.Checked = False
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If r9.Checked = False Then
            r9.Checked = True
            r8.Checked = True
        Else
            r9.Checked = False
            If r3.Checked = False And r5.Checked = False And r6.Checked = False Then
                r8.Checked = False
            End If
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Button3_Click(sender, e)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If r12.Checked = False Then
            If r11.Checked = False Then
                Button3_Click(sender, e)
                r12.Checked = True
            Else
                r12.Checked = True
            End If
        Else
            r12.Checked = False
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If r13.Checked = False Then
            If r11.Checked = False Then
                Button3_Click(sender, e)
                r13.Checked = True
            Else
                r13.Checked = True
            End If
        Else
            r13.Checked = False
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If r14.Checked = False Then
            r14.Checked = True
        Else
            r14.Checked = False
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If r15.Checked = False Then
            r15.Checked = True
        Else
            r15.Checked = False
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If r16.Checked = False Then
            r16.Checked = True
        Else
            r16.Checked = False
        End If
    End Sub

    Private Sub Beditar_Click(sender As Object, e As EventArgs) Handles Beditar.Click
        Beditar.Enabled = False
        btguardar.Enabled = True
        btcancelar.Enabled = True
        GroupBox1.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        Button16.Enabled = True
        Button17.Enabled = True
        Button18.Enabled = True
        Button19.Enabled = True

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, Nothing, Nothing)
        Beditar.Enabled = True
        habilitarBt()

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                If mempresa.guardar(Codigo_punto, SesionActual.idEmpresa) = True Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    Beditar.Enabled = True
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    GroupBox1.Enabled = False
                    gbEspecial.Visible = False
                    If btguardar.Enabled = False Then
                        fprincipal.eliminarMenu()
                        fprincipal.CreaOpciones(SesionActual.idEmpresa, SesionActual.codigoPerfil)
                        SesionActual.dtPermisos.Clear()
                        SesionActual.dtPermisos = fprincipal.cargarOpciones(SesionActual.codigoPerfil, SesionActual.idEmpresa)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub


    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If R17.Checked = False Then
            R17.Checked = True
        Else
            R17.Checked = False
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If R19.Checked = False Then
            R19.Checked = True
        Else
            R19.Checked = False
        End If
    End Sub

    Private Sub FormModulosEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If rEspecial.Checked = False Then
            rEspecial.Checked = True
        Else
            rEspecial.Checked = False
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If SesionActual.idUsuario <> 0 Then
            Dim respuesta = txtEspecial.Text
            Dim comparacion = String.CompareOrdinal(respuesta, Constantes.SANTO_Y_SENA_ESPECIAL)
            If comparacion <> 0 Then
                gbEspecial.Visible = False
            Else
                gbEspecial.Visible = True
            End If
            pnlEspecial.Visible = False
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        gbEspecial.Visible = False
        pnlEspecial.Visible = False
        contadorEspecial = 0
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        contadorEspecial += 1
        If contadorEspecial = 10 Then
            pnlEspecial.Visible = True
        End If
    End Sub

End Class