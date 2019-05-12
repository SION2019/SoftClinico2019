Public Class Form_comidas_horas
    Dim objComida As ComidasHoras
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Form_comidas_horas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Me.Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
#Region "Botones"
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objComida = New ComidasHoras
                establecerObjeto(objComida)
                anular(objComida)
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        objComida = New ComidasHoras
        establecerObjeto(objComida)
        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardar(objComida)
            reflejarObjeto(objComida)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
            txtDescripcion.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            limpiarInterno()
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtDescripcion.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            limpiarInterno()
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            buscar()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Metodos"
    Sub guardar(ByVal objComidaHora As ComidasHoras)
        Dim comidaHoraCmd As New ComidaHora_D
        Try
            comidaHoraCmd.guardar(objComidaHora, SesionActual.idUsuario, SesionActual.codigoEP)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub anular(ByVal objComidaHora As ComidasHoras)
        Dim comidaHoraCmd As New ComidaHora_D
        Try
            comidaHoraCmd.anular(objComidaHora, SesionActual.idUsuario)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub limpiarInterno()
        General.limpiarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Sub buscar()
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(Consultas.CONFIGURACION_COMIDA_BUSCAR,
                               params,
                               AddressOf cargarConfiguracion,
                               TitulosForm.BUSQUEDA_CONFIGURACION_COMIDA,
                               False, 0, True)

    End Sub
    Sub cargarConfiguracion(ByVal pCodigo As String)
        objComida = New ComidasHoras
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CONFIGURACION_COMIDA_CARGAR_INDIVIDUAL, params)
        objComida.codigo = fila(0)
        objComida.descripcion = fila(1)
        objComida.hDesdeDesayuno = fila(2)
        objComida.hHastaDesayuno = fila(3)
        objComida.hDesdeAlmuerzo = fila(4)
        objComida.hHastaAlmuerzo = fila(5)
        objComida.hDesdeCena = fila(6)
        objComida.hHastaCena = fila(7)
        reflejarObjeto(objComida)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Function validarFormulario() As Boolean
        If txtDescripcion.Text = "" Then
            MsgBox("¡ Por favor digite la descripción de la configuración!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            txtDescripcion.Focus()
            Return False
        ElseIf dtimeDesdeDesayuno.Value >= dtimeHastaDesayuno.Value Then
            MsgBox("¡No se puede tener el mismo rango de fecha en el desayuno!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            dtimeHastaDesayuno.Focus()
            Return False
        ElseIf dtimeDesdeAlmuerzo.Value >= dtimeHastaAlmuerzo.Value Then
            MsgBox("¡No se puede tener el mismo rango de fecha en el almuerzo!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            dtimeHastaAlmuerzo.Focus()
            Return False
        ElseIf dtimeDesdeCena.Value >= dtimeHastaCena.Value Then
            MsgBox("¡No se puede tener el mismo rango de fecha en la cena!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            dtimeHastaCena.Focus()
            Return False
        ElseIf dtimeHastaDesayuno.Value >= dtimeDesdeAlmuerzo.Value Then
            MsgBox("¡Las horas de pedir almuerzo no pueden ser menor o igual a las del desayuno!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            dtimeHastaCena.Focus()
            Return False
        ElseIf dtimeHastaAlmuerzo.Value >= dtimeDesdeCena.Value Then
            MsgBox("¡Las horas de pedir cena no pueden ser menor o igual a las del almuerzo!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            dtimeHastaCena.Focus()
            Return False
        End If
        Return True
    End Function
    Sub establecerObjeto(ByRef objComida As ComidasHoras)
        objComida.codigo = txtCodigo.Text
        objComida.descripcion = txtDescripcion.Text.ToUpper
        objComida.hDesdeDesayuno = dtimeDesdeDesayuno.Value
        objComida.hHastaDesayuno = dtimeHastaDesayuno.Value
        objComida.hDesdeAlmuerzo = dtimeDesdeAlmuerzo.Value
        objComida.hHastaAlmuerzo = dtimeHastaAlmuerzo.Value
        objComida.hDesdeCena = dtimeDesdeCena.Value
        objComida.hHastaCena = dtimeHastaCena.Value
    End Sub

    Sub reflejarObjeto(ByRef objComida As ComidasHoras)
        txtCodigo.Text = objComida.codigo
        txtDescripcion.Text = objComida.descripcion
        dtimeDesdeDesayuno.Value = objComida.hDesdeDesayuno
        dtimeHastaDesayuno.Value = objComida.hHastaDesayuno
        dtimeDesdeAlmuerzo.Value = objComida.hDesdeAlmuerzo
        dtimeHastaAlmuerzo.Value = objComida.hHastaAlmuerzo
        dtimeDesdeCena.Value = objComida.hDesdeCena
        dtimeHastaCena.Value = objComida.hHastaCena
    End Sub
    Sub reestablecerValoresDatetiemPiket(ByRef obj As Object)
        For Each ctrl In obj.controls
            If TypeOf ctrl Is GroupBox Then
                reestablecerValoresDatetiemPiket(ctrl)
            ElseIf TypeOf ctrl Is DateTimePicker Then
                ctrl.MinDate = "01/01/1753 00:00:00"
                ctrl.MaxDate = "31/12/9998 00:00:00"
            End If
        Next
    End Sub
#End Region
End Class