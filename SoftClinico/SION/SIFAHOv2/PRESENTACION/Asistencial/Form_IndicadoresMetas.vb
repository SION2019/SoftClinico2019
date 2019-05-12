Public Class Form_IndicadoresMetas
    Dim Cadena As String
    Dim objIndicadorMeta As New Indicadores
    Sub limpiar()
        nudIntensivo.Value = 0
        nudIntermedio.Value = 0
        nudBasico.Value = 0
        nudIntensivoOE.Value = 0
        nudIntermedioOE.Value = 0
        nudBasicoOE.Value = 0
        nudIntensivoPE.Value = 0
        nudIntermedioPE.Value = 0
        nudBasicoPE.Value = 0
        txtTotal.Text = 0
    End Sub
    Sub desahabilitar()
        nudIntensivo.Enabled = False
        nudIntermedio.Enabled = False
        nudBasico.Enabled = False
        nudIntensivoOE.Enabled = False
        nudIntermedioOE.Enabled = False
        nudBasicoOE.Enabled = False
        nudIntensivoPE.Enabled = False
        nudIntermedioPE.Enabled = False
        nudBasicoPE.Enabled = False
        txtTotal.Enabled = False
        btguardar.Enabled = False
        rdbMes.Checked = True
    End Sub
    Sub habilitar()
        nudIntensivo.Enabled = True
        nudIntermedio.Enabled = True
        nudIntensivoOE.Enabled = True
        nudIntermedioOE.Enabled = True
        nudIntensivoPE.Enabled = True
        nudIntermedioPE.Enabled = True
        txtTotal.Enabled = True
        txtTotal.ReadOnly = True
        btguardar.Enabled = True
        If cmbAreaM.SelectedIndex = 5 Then
            nudBasico.Enabled = True
            nudBasicoOE.Enabled = True
            nudBasicoPE.Enabled = True
        Else
            nudBasico.Enabled = False
            nudBasicoOE.Enabled = False
            nudBasicoPE.Enabled = False
        End If
    End Sub
    Private Sub Form_IndicadoresMetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cadena = ConsultasNom.LISTA_NOMINA_AREA & SesionActual.codigoEP
        General.cargarCombo(Consultas.PERFIL_PARACLINICO_AREA_SERVICIO_BUSCAR, "Descripcion", "Codigo", cmbAreaM)
        limpiar()
        desahabilitar()
        dgvIndicadoresMetas.DataSource = objIndicadorMeta.dtIndicadorMeta
    End Sub
    Public Sub darFormatodgvIndicadoresMetas()
        With dgvIndicadoresMetas
            .Columns(0).Visible = False
            .Columns(1).Width = 150
            .Columns(2).Width = 230
            .Columns(3).Width = 250
            .Columns(4).Width = 85
            .Columns(4).DefaultCellStyle.Format = "N0"
            .Columns(5).Width = 85
            .Columns(5).DefaultCellStyle.Format = "N0"
            .Columns(6).Width = 70
            .Columns(6).DefaultCellStyle.Format = "N0"
        End With
    End Sub
    Sub cargarIndicadores()
        Dim param As New List(Of String)
        param.Add(cmbAreaM.SelectedValue)
        General.llenarTabla(Consultas.INDICADORES, param, objIndicadorMeta.dtIndicadorMeta)
        If cmbAreaM.SelectedIndex = 5 Then
            dgvIndicadoresMetas.Columns(6).Visible = True
        Else
            dgvIndicadoresMetas.Columns(6).Visible = False
        End If
        darFormatodgvIndicadoresMetas()
    End Sub
    Sub cargarCapacidades()
        Dim rw As DataRow
        Dim param As New List(Of String)
        param.Add(cmbAreaM.SelectedValue)
        rw = General.cargarItem(Consultas.CAPACIDADES, param)
        If rw IsNot Nothing Then
            nudIntensivo.Value = rw(0)
            nudIntermedio.Value = rw(1)
            nudBasico.Value = rw(2)
            nudIntensivoOE.Value = rw(3)
            nudIntermedioOE.Value = rw(4)
            nudBasicoOE.Value = rw(5)
            nudIntensivoPE.Value = rw(6)
            nudIntermedioPE.Value = rw(7)
            nudBasicoPE.Value = rw(8)
        End If
    End Sub
    Private Sub cmbAreaM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreaM.SelectedIndexChanged
        If cmbAreaM.SelectedIndex <> 0 Then
            limpiar()
            habilitar()
            cargarIndicadores()
            cargarCapacidades()
        Else
            limpiar()
            desahabilitar()
        End If
    End Sub

    Private Sub nudIntensivo_ValueChanged(sender As Object, e As EventArgs) Handles nudIntensivo.ValueChanged
        calcularTotal()
    End Sub

    Sub calcularTotal()
        txtTotal.Text = nudIntensivo.Value + nudIntermedio.Value + nudBasico.Value
    End Sub

    Private Sub nudIntermedio_ValueChanged(sender As Object, e As EventArgs) Handles nudIntermedio.ValueChanged
        calcularTotal()
    End Sub

    Private Sub nudBasico_ValueChanged(sender As Object, e As EventArgs) Handles nudBasico.ValueChanged
        calcularTotal()
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            cargarObjetos()
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                IndicadoresBLL.guardarIndicadoresMetas(objIndicadorMeta)
                cargarIndicadores()
                cargarCapacidades()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub cargarObjetos()
        objIndicadorMeta.usuario = SesionActual.idUsuario
        If objIndicadorMeta.dtCapacidad.Rows.Count = 0 Then
            objIndicadorMeta.dtCapacidad.Rows.Add()
        Else
            objIndicadorMeta.dtCapacidad.Rows.Clear()
            objIndicadorMeta.dtCapacidad.Rows.Add()
        End If
        objIndicadorMeta.dtCapacidad.Rows(0).Item(0) = cmbAreaM.SelectedValue
        objIndicadorMeta.dtCapacidad.Rows(0).Item(1) = nudIntensivo.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(2) = nudIntermedio.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(3) = nudBasico.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(4) = nudIntensivoOE.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(5) = nudIntermedioOE.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(6) = nudBasicoOE.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(7) = nudIntensivoPE.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(8) = nudIntermedioPE.Value
        objIndicadorMeta.dtCapacidad.Rows(0).Item(9) = nudBasicoPE.Value
        If rdbMes.Checked = True Then
            objIndicadorMeta.periodo = 30
        ElseIf rdbSemana.Checked = True Then
            objIndicadorMeta.periodo = 7
        ElseIf rdbSemestre.Checked = True Then
            objIndicadorMeta.periodo = 182
        ElseIf rdbAño.Checked = True Then
            objIndicadorMeta.periodo = 365
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        Me.Close()
    End Sub
End Class