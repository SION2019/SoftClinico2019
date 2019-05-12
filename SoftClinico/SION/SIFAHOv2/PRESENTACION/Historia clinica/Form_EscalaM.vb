Public Class Form_EscalaM
    Dim respuesta As Boolean
    Dim permiso_general, Peditar, Panular As String
    Dim perG As New Buscar_Permisos_generales
    Dim objEscala As New EscalaMorse
    Dim reporte As New ftp_reportes
    Dim modulo As String
    Private Sub Form_EscalaM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deshablitar_controles()
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Peditar = permiso_general & "pp" & "01"
        Panular = permiso_general & "pp" & "02"
        Datefecha.Enabled = False

        txtalto.Text = "Alto Riesgo"
        txtmoderado.Text = "Riesgo Moderado"
        txtbajo.Text = "Riesgo Bajo"
        txtmayor.Text = 50
        txtentre.Text = "Entre 25 y 50"
        txtmenor.Text = "Menor o igual a 24"

    End Sub

    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub
    Private Sub Form_EscalaM_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Sub calcular()
        Dim total2 As Integer
        If R1.Checked = False Then
            l1.Text = 25
        Else
            l1.Text = 0
        End If
        If R3.Checked = False Then
            l2.Text = 15
        Else
            l2.Text = 0
        End If
        If R6.Checked = True Then
            l3.Text = 15
        ElseIf R7.Checked = True Then
            l3.Text = 30
        Else
            l3.Text = 0
        End If
        If R8.Checked = False Then
            l4.Text = 20
        Else
            l4.Text = 0
        End If

        If R11.Checked = True Then
            l5.Text = 10
        ElseIf R12.Checked = True Then
            l5.Text = 20
        Else
            l5.Text = 0
        End If
        If R13.Checked = False Then
            l6.Text = 15
        Else
            l6.Text = 0
        End If

        total2 = CInt(l1.Text) + CInt(l2.Text) + CInt(l3.Text) + CInt(l4.Text) + CInt(l5.Text) + CInt(l6.Text)
        total.Text = total2
        If total2 < 25 Then
            obser.Text = "Cuidados básicos de enfermeria"
            total.BackColor = Color.PaleGoldenrod
        ElseIf total2 < 51 And total2 > 24 Then
            obser.Text = "Implementación de plan de prevención"
            total.BackColor = Color.Orange
        Else
            obser.Text = "Implementación de medidas especiales"
            total.BackColor = Color.LightCoral
        End If
    End Sub

    Private Sub hablitar_controles()
        GroupBox10.Enabled = True
        GroupBox11.Enabled = True
        GroupBox12.Enabled = True
        GroupBox13.Enabled = True
        GroupBox14.Enabled = True
        GroupBox15.Enabled = True
    End Sub
    Private Sub deshablitar_controles()
        GroupBox10.Enabled = False
        GroupBox11.Enabled = False
        GroupBox12.Enabled = False
        GroupBox13.Enabled = False
        GroupBox14.Enabled = False
        GroupBox15.Enabled = False
    End Sub

    Public Sub cargarDatos()
        objEscala.registro = txtregistro.Text
        objEscala.cargarDatos()

        If objEscala.dt.Rows.Count > 0 Then
            l1.Text = objEscala.l1
            l2.Text = objEscala.l2
            l3.Text = objEscala.l3
            l4.Text = objEscala.l4
            l5.Text = objEscala.l5
            l6.Text = objEscala.l6
            Datefecha.Value = objEscala.dateFecha
            R2.Checked = objEscala.r2
            R4.Checked = objEscala.r4
            R6.Checked = objEscala.r6
            R7.Checked = objEscala.r7
            R5.Checked = objEscala.r5
            R9.Checked = objEscala.r9
            R11.Checked = objEscala.r11
            R12.Checked = objEscala.r12
            R10.Checked = objEscala.r10
            R14.Checked = objEscala.r14

            calcular()
            bteditar.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            Datefecha.Enabled = False
            btimprimir.Enabled = True
        Else
            bteditar.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            calcular()
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            hablitar_controles()
            btcancelar.Enabled = True
            btguardar.Enabled = True
            bteditar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            Datefecha.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub establecerRadios()
        R1.Checked = True
        R3.Checked = True
        R5.Checked = True
        R8.Checked = True
        R10.Checked = True
        R13.Checked = True
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea Cancelar este registro?", 32 + 1, "Cancelar") = 1 Then
            If total.Text > 0 Then
                bteditar.Enabled = False
                cargarDatos()
                deshablitar_controles()
                btimprimir.Enabled = True
                btanular.Enabled = True
            Else
                btanular.Enabled = False
                btcancelar.Enabled = False
                btimprimir.Enabled = False
                btguardar.Enabled = False
                bteditar.Enabled = True
                deshablitar_controles()
                establecerRadios()
            End If
        End If
    End Sub

    Private Sub R2_CheckedChanged(sender As Object, e As EventArgs) Handles R2.CheckedChanged
        calcular()
    End Sub

    Private Sub R3_CheckedChanged(sender As Object, e As EventArgs) Handles R3.CheckedChanged
        calcular()
    End Sub

    Private Sub R4_CheckedChanged(sender As Object, e As EventArgs) Handles R4.CheckedChanged
        calcular()
    End Sub

    Private Sub R5_CheckedChanged(sender As Object, e As EventArgs) Handles R5.CheckedChanged
        calcular()
    End Sub

    Private Sub R6_CheckedChanged(sender As Object, e As EventArgs) Handles R6.CheckedChanged
        calcular()
    End Sub

    Private Sub R7_CheckedChanged(sender As Object, e As EventArgs) Handles R7.CheckedChanged
        calcular()
    End Sub

    Private Sub R8_CheckedChanged(sender As Object, e As EventArgs) Handles R8.CheckedChanged
        calcular()
    End Sub

    Private Sub R9_CheckedChanged(sender As Object, e As EventArgs) Handles R9.CheckedChanged
        calcular()
    End Sub

    Private Sub R10_CheckedChanged(sender As Object, e As EventArgs) Handles R10.CheckedChanged
        calcular()
    End Sub

    Private Sub R11_CheckedChanged(sender As Object, e As EventArgs) Handles R11.CheckedChanged
        calcular()
    End Sub

    Private Sub R12_CheckedChanged(sender As Object, e As EventArgs) Handles R12.CheckedChanged
        calcular()
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_MORSE & txtregistro.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    deshablitar_controles()
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    btimprimir.Enabled = False
                    btcancelar.Enabled = False
                    establecerRadios()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If String.IsNullOrEmpty(total.Text) Then
            MsgBox("No puede guardar sin llenar los registros", MsgBoxStyle.Exclamation)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objEscala.l1 = l1.Text
                objEscala.l2 = l2.Text
                objEscala.l3 = l3.Text
                objEscala.l4 = l4.Text
                objEscala.l5 = l5.Text
                objEscala.l6 = l6.Text
                objEscala.dateFecha = Datefecha.Value
                objEscala.registro = txtregistro.Text
                objEscala.usuario = SesionActual.idUsuario
                objEscala.guardarEscala()

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                btguardar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btcancelar.Enabled = False
                deshablitar_controles()
                btimprimir.Enabled = True
            End If
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_MORSE
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtregistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarMorse()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarMorse()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_MORSE, txtregistro.Text, New rptEscala_Morse,
                                    txtregistro.Text, "{VISTA_ESCALA_MORSE.N_Registro} = " & txtregistro.Text & "",
                                    ConstantesHC.NOMBRE_PDF_MORSE, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub R13_CheckedChanged(sender As Object, e As EventArgs) Handles R13.CheckedChanged
        calcular()
    End Sub

    Private Sub R14_CheckedChanged(sender As Object, e As EventArgs) Handles R14.CheckedChanged
        calcular()
    End Sub
End Class