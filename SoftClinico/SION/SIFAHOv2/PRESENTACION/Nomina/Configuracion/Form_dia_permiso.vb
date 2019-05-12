Public Class Form_dia_permiso
    Dim permiso As Permiso, convencion As Convencion
    Property PostAcc As EditarPermiso
    Property dttipo As DataTable
    Property dwConvencion As DataRow
    Property habltrCntrls As Boolean

    Sub New(ByRef pPermiso As Permiso)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        permiso = pPermiso
    End Sub

    Private Sub Form_dia_permiso_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        'permiso_general = perG.buscarPermisoGeneral(Name)
        'Pnuevo = permiso_general & "pp" & "01"
        'Peditar = permiso_general & "pp" & "02"
        'Panular = permiso_general & "pp" & "03"
        'PBuscar = permiso_general & "pp" & "04"
        'General.deshabilitarBotones(ToolStrip1)
        iniciar_tipo()
        leer_permiso()
        If habltrCntrls = False Then
            General.deshabilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            btcancelar.Enabled = True
        End If
    End Sub

    Sub iniciar_tipo()
        combotipo.DataSource = dttipo
        combotipo.ValueMember = dttipo.Columns(0).ColumnName
        combotipo.DisplayMember = dttipo.Columns(1).ColumnName
        combotipo.SelectedIndex = 0
    End Sub

    Sub leer_permiso()
        Dim comtiempo As Integer
        Label1.Text &= " A " & permiso.Empleado
        txtdia.Text = String.Format("{0:dddd} {0:%d} de {0:MMMM} del {0:yyyy}", permiso.Fecha)
        txtdia.Text = permiso.Fecha.ToString("dddd  d / MMMM / yyyy")
        lbconvencion.Text = leer_convencion()
        TxtObservacion.Text = permiso.Observacion
        If permiso.Codigo IsNot Nothing Then
            txtcodigo.Text = permiso.Codigo
            btanular.Text = If(permiso.Anulado, "Dehacer Anular", "Anular")
        Else
            If permiso.Enlistado Then btanular.Text = "Quitar" : btanular.Image = My.Resources._02_Recycle_icon__1_
        End If
        If permiso.Enlistado Then
            combotipo.SelectedValue = permiso.Tipo
            rbtotal.Checked = permiso.EsTotal
            rbrangotiempo.Checked = Not rbtotal.Checked
            fechacomienzo.Value = permiso.Comienzo
            Dim Ptiempo = TimeSpan.FromMinutes(permiso.TiempoTotal)
            Dim Ctiempo = TimeSpan.FromMinutes(convencion.stMinutos + convencion.dMinutos)
            comtiempo = CInt(Math.Truncate(Ctiempo.TotalHours))
            numtiempototalhoras.Value = CInt(Math.Truncate(Ptiempo.TotalHours))
            numtiempototalminutos.Value = Ptiempo.Minutes
            If numtiempototalhoras.Value = comtiempo Then
                rbtotal.Checked = True
                rbrangotiempo.Checked = False
            End If
        End If
        btanular.Enabled = permiso.Enlistado
    End Sub

    Function leer_convencion() As String
        convencion = New Convencion(dwConvencion)
        txtentrar.Text = convencion.Entrar.ToString("hh : mm tt")
        txtsalir.Text = convencion.Entrar.AddMinutes(convencion.stMinutos + convencion.dMinutos).ToString("hh : mm tt")
        txtconvencion.Text = convencion.Nombre
        If Len(convencion.Nombre) > 23 Then
            txtconvencion.Font = New Font("Arial Narrow", 7, FontStyle.Bold)
        End If
        If convencion.dMinutos > 0 Then
            txtdescansar.Text = convencion.Descansar.ToString("hh : mm tt")
            txtretornar.Text = convencion.Descansar.AddMinutes(convencion.dMinutos).ToString("hh : mm tt")
        Else
            txtdescansar.Text = "no-tiene" : txtretornar.Text = "no-tiene"
        End If
        Dim Ctiempo = TimeSpan.FromMinutes(convencion.stMinutos + convencion.dMinutos)
        txttiempototalhorario.Text = String.Format("{0:00}h. {1:00}m.", CInt(Math.Truncate(Ctiempo.TotalHours)), Ctiempo.Minutes)
        'fechacomienzo.Value = convencion.Entrar
        lbconvencion.ForeColor = Color.FromArgb(convencion.Argcolor)
        Return permiso.Convencion
    End Function

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'If SesionActual.tienePermiso(Panular ) Then
        If (permiso.Anulado) Then
            permiso.Anulado = False
            permiso.Editado = False
            PostAcc = EditarPermiso.DeshacerAnul
        ElseIf (permiso.Codigo Is Nothing) Then
            PostAcc = EditarPermiso.Quitar
        ElseIf (MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes) Then
            permiso.Anulado = True
            PostAcc = EditarPermiso.AnularEnDB
        Else
            Return
        End If
        Close()
        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btaceptar_EnabledChanged(sender As Object, e As EventArgs) Handles btaceptar.EnabledChanged, btimprimir.EnabledChanged
        btimprimir.Enabled = Not btaceptar.Enabled
    End Sub

    Private Sub btaceptar_Click(sender As Object, e As EventArgs) Handles btaceptar.Click
        If combotipo.SelectedIndex < 1 Then
            MsgBox("Debe seleccionar un tipo de permiso !!", MsgBoxStyle.Exclamation) : combotipo.Focus()
        ElseIf (rbtotal.Checked = False AndAlso rbrangotiempo.Checked = False) Then
            MsgBox("Debe configurar el rango de tiempo del permiso !!", MsgBoxStyle.Exclamation)
        ElseIf (rbrangotiempo.Checked AndAlso numtiempototalhoras.Value <= 0 AndAlso numtiempototalminutos.Value <= 0) Then
            MsgBox("El tiempo total del permiso no puede ser igual a 0!!", MsgBoxStyle.Exclamation) : numtiempototalhoras.Focus()
        Else
            permiso.Tipo = combotipo.SelectedValue.ToString
            permiso.EsTotal = rbtotal.Checked
            permiso.Comienzo = fechacomienzo.Value
            permiso.TiempoTotal = numtiempototalhoras.Value * 60 + numtiempototalminutos.Value
            permiso.Observacion = TxtObservacion.Text
            permiso.HrPermiso = (convencion.stMinutos / 60)
            permiso.Editado = True
            PostAcc = EditarPermiso.Actualizar
            Close()
            End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        Close()
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        'Dim rptPermiso1 As New rptPermiso()
        'rptPermiso1.SetParameterValue("@pUsuario", SesionActual.idUsuario)
        'rptPermiso1.SetParameterValue("@pEmpresa", SesionActual.idEmpresa)
        'rptPermiso1.SetParameterValue("@pCodigo", txtcodigo.Text)
        'Exec.getReport(rptPermiso1, Nothing, "Permiso")
    End Sub

    Private Sub fechacomienzo_ValueChanged(sender As Object, e As EventArgs) Handles fechacomienzo.ValueChanged, numtiempototalhoras.ValueChanged, numtiempototalminutos.ValueChanged
        Dim Pminutos = numtiempototalhoras.Value * 60 + numtiempototalminutos.Value
        txtfin.Text = StrConv(fechacomienzo.Value.AddMinutes(Pminutos).ToString("hh : mm tt"), VbStrConv.ProperCase)
    End Sub

    Private Sub rbrangotiempo_CheckedChanged(sender As Object, e As EventArgs) Handles rbrangotiempo.CheckedChanged
        GroupBox6.Enabled = rbrangotiempo.Checked : GroupBox7.Enabled = rbrangotiempo.Checked
        fechacomienzo.Value = DateTime.Now
    End Sub

    Private Sub rbtotal_CheckedChanged(sender As Object, e As EventArgs) Handles rbtotal.CheckedChanged
        GroupBox6.Enabled = rbrangotiempo.Checked : GroupBox7.Enabled = rbrangotiempo.Checked
        Dim Inicio = fechacomienzo.Value.ToShortDateString & " " & convencion.Entrar.ToString("hh : mm tt")
        fechacomienzo.Value = Inicio
        txtfin.Text = txtsalir.Text
    End Sub

End Class