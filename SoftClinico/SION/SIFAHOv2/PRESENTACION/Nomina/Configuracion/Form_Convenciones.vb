Option Explicit On
Imports System.Threading
Public Class Form_Convenciones
    Dim cmd As New ConvencionLaboralBLL
    Dim sTminutos, tDminutos As Integer, thrd As Thread
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Convenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        dateEntrar.Value = Today.AddHours(8)
        dateDescansar.Value = Today.AddHours(8)
        txtsimbolo.ForeColor = Color.Black
        btcolor.Enabled = True
        txtnombre.Focus()
        txtSalir.ReadOnly = True
        txtRetornar.ReadOnly = True
        txtTotalHoras.ReadOnly = True
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        btcolor.Enabled = True
        txtnombre.Focus()
        txtSalir.ReadOnly = True
        txtRetornar.ReadOnly = True
        txtTotalHoras.ReadOnly = True
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub Form_Convenciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(Consultas.BUSCAR_CONVERCIONES,
                                   Nothing,
                                   AddressOf cargarConverciones,
                                   TitulosForm.BUSQUEDA_CONVERCIONES,
                                   False, 0, True)
    End Sub
    Private Sub cargarConverciones(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_DATOS_CONVERCIONES,
                                              params)

        txtcodigo.Text = pCodigo
        txtsimbolo.Text = dr.Item(0)
        txtsimbolo.ForeColor = Color.FromArgb(dr.Item(1))
        txtnombre.Text = dr.Item(2)
        dateEntrar.Value = dr.Item(3)
        dateDescansar.Value = If(IsDate(dr.Item(4)), dr.Item(4), dateEntrar.Value)
        Dim Ctiempo = TimeSpan.FromMinutes(dr.Item(5) + dr.Item(6))
        numSubtotalHoras.Value = CInt(Math.Truncate(Ctiempo.TotalHours))
        numSubtotalMinutos.Value = Ctiempo.Minutes
        Dim Dtiempo = TimeSpan.FromMinutes(dr.Item(6))
        numTotalHorasDescanso.Value = CInt(Math.Truncate(Dtiempo.TotalHours))
        numTotalMinutosDescanso.Value = Dtiempo.Minutes
        CheckBox1.Checked = numTotalHorasDescanso.Value > 0 Or numTotalMinutosDescanso.Value > 0
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        calcularDescanso()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcolor.Click
        If ColorDialog1.ShowDialog() Then
            txtsimbolo.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub textnombre_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnombre.KeyUp
        If txtsimbolo.Enabled Then
            txtsimbolo.Text = Strings.Left(txtnombre.Text.Split(" ")(0), 1).ToUpper
            If txtnombre.Text.Split(" ").Length > 1 Then txtsimbolo.Text &= Strings.Left(txtnombre.Text.Split(" ")(1), 1).ToUpper
        End If
    End Sub

    Private Sub dateDescansar_ValueChanged(sender As Object, e As EventArgs) Handles dateEntrar.ValueChanged, numSubtotalHoras.ValueChanged, numSubtotalMinutos.ValueChanged
        sTminutos = numSubtotalHoras.Value * 60 + numSubtotalMinutos.Value
        txtSalir.Text = StrConv(dateEntrar.Value.AddMinutes(sTminutos).ToString("hh :  mm tt  ddddd"), VbStrConv.ProperCase)
        setTotal()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dateDescansar.ValueChanged, numTotalHorasDescanso.ValueChanged, numTotalMinutosDescanso.ValueChanged
        tDminutos = numTotalHorasDescanso.Value * 60 + numTotalMinutosDescanso.Value
        txtRetornar.Text = If(tDminutos = 0, "  No tiene  ", StrConv(dateDescansar.Value.AddMinutes(tDminutos).ToString("hh :  mm tt  ddddd"), VbStrConv.ProperCase))
        setTotal()
    End Sub

    Sub setTotal()
        Dim Ttiempo = TimeSpan.FromMinutes(sTminutos) - TimeSpan.FromMinutes(tDminutos)
        txtTotalHoras.Text = String.Format("{0:00} : {1:00}", CInt(Math.Truncate(Ttiempo.TotalHours)), Ttiempo.Minutes)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If (txtnombre.Text = "") Then
            MsgBox("¡ Por favor digite el nombre del Convencion !", MsgBoxStyle.Information)
            txtnombre.Focus()
        ElseIf (txtsimbolo.Text.Trim = "") Then
            MsgBox("¡ Por favor digite el Simbolo de la Convencion !", MsgBoxStyle.Information)
            txtsimbolo.Focus()
        ElseIf (txtTotalHoras.Text.trim = "00 : 00") OrElse (txtTotalHoras.Text.Contains("-")) Then
            MsgBox("¡ Configuración errada de las horas laborales !", MsgBoxStyle.Information)
            txtsimbolo.Focus()
        ElseIf tDminutos > 0 AndAlso validarRangoDescanso()Then
            '
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim convencion1 As New Convencion
                convencion1.Codigo = txtcodigo.Text.Trim
                convencion1.Nombre = txtnombre.Text.Trim
                convencion1.Simbolo = txtsimbolo.Text.Trim
                convencion1.Argcolor = txtsimbolo.ForeColor.ToArgb
                convencion1.Entrar = dateEntrar.Value
                convencion1.stMinutos = sTminutos
                convencion1.Descansar = dateDescansar.Value
                convencion1.dMinutos = tDminutos

                Dim rCodigo = cmd.guardar_convencion(convencion1)
                If rCodigo <> "" Then
                    txtcodigo.Text = rCodigo
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    'Habilitar botones
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                End If
            End If
        End If
    End Sub

    Function validarRangoDescanso() As Boolean
        Dim datetimeSalir = dateEntrar.Value.AddMinutes(sTminutos)
        Dim datetimeRetornar = dateDescansar.Value.AddMinutes(tDminutos)
        Dim res As Boolean = True
        If datetimeSalir <= datetimeRetornar Then
            MsgBox("¡ La hora de salida no debe ser menor (o igual) que la hora de final del descanso!", MsgBoxStyle.Information)
            numTotalHorasDescanso.Focus()
        ElseIf dateDescansar.Value <= dateEntrar.Value Then
            MsgBox("¡ La hora de descanso no debe ser menor (o igual) que la hora de entrada a turno!", MsgBoxStyle.Information)
            dateDescansar.Focus()
        Else : res = False
        End If
        Return res
    End Function

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If General.anularRegistro("PROC_CONVENCION_ANULAR " & txtcodigo.Text & ", " & SesionActual.idUsuario) = True Then
                    General.limpiarControles(Me)
                    General.deshabilitarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub txtsimbolo_ReadOnlyChanged(sender As Object, e As EventArgs) Handles txtsimbolo.ReadOnlyChanged
        lbsimbolo.Visible = txtsimbolo.ReadOnly
        lbsimbolo.BringToFront()
    End Sub

    Private Sub txtsimbolo_TextChanged(sender As Object, e As EventArgs) Handles txtsimbolo.TextChanged
        lbsimbolo.Text = txtsimbolo.Text
        Try
            thrd.Abort()
        Catch ex As Exception
        End Try
        thrd = New Thread(Sub() validar_existencia(txtsimbolo.Text, txtcodigo.Text))
        thrd.Start()
    End Sub

    Private Sub txtsimbolo_ForeColorChanged(sender As Object, e As EventArgs) Handles txtsimbolo.ForeColorChanged
        lbsimbolo.ForeColor = txtsimbolo.ForeColor
    End Sub

    Private Sub validar_existencia(ByVal pSimbolo As String, ByVal pCodigo As String)
        Dim nombre As String = ""
        Dim existencia As Boolean = buscar_simbolo(pSimbolo, pCodigo, nombre)
        If existencia Then
            mostrarInfo(String.Format("error: la convencion '{0}' ya existe: Se llama '{1}'", pSimbolo, nombre), Color.White, Color.Red)
        Else
            mostrarInfo(Nothing, Nothing, Nothing, True)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        calcularDescanso()

    End Sub
    Private Sub calcularDescanso()
        If CheckBox1.Checked Then
            GroupBox2.Enabled = True
            dateDescansar.Visible = True
        Else
            GroupBox2.Enabled = False
            dateDescansar.Visible = False
            numTotalHorasDescanso.Value = 0
            numTotalMinutosDescanso.Value = 0
        End If
    End Sub

    Function buscar_simbolo(pSimbolo As String, pCodigo As String, ByRef rNombre As String) As Boolean
        If pSimbolo Is Nothing OrElse pSimbolo.Trim = "" Then Return False
        Dim cadena As String = "SELECT Nombre FROM D_CONVENCION WHERE Simbolo = '" & pSimbolo & "' AND Codigo_convencion <> '" & pCodigo & "'"
        Using dt As New DataTable
            General.llenarTablaYdgv(cadena, dt)
            If dt.Rows.Count = 0 Then : Return False
            Else : rNombre = dt(0)(0).ToString : Return True
            End If
        End Using
    End Function

    Sub mostrarInfo(pSmg As String, pColorFuenteLetra As Color, pColorFondoPanel As Color, Optional pOcultar As Boolean = False)
        If InvokeRequired Then
            Invoke(New MethodInvoker(Sub() mostrarInfo(pSmg, pColorFuenteLetra, pColorFondoPanel, pOcultar)))
        Else
            If pOcultar Then
                PnlInfo.Visible = False
            Else
                lbinfo.Text = pSmg.ToUpper : lbinfo.ForeColor = pColorFuenteLetra : PictureBox2.Image = My.Resources.info
                PnlInfo.BackColor = pColorFondoPanel : PnlInfo.BringToFront() : PnlInfo.Visible = True
            End If
        End If
    End Sub

End Class