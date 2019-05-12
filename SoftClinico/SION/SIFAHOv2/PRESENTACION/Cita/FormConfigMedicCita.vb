Public Class FormConfigMedicCita
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objConfiguracion As New ConfigCita
    Property formCitaMedica As FormCitaMedica
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        PBuscar = permiso_general & "pp" & "03"
        Panular = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        General.cargarCombo(Consultas.EMPLEADO_CARGAR_TODOS & SesionActual.idEmpresa, "Empleado", "Id_empleado", cbEmpleado)
    End Sub
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
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If cbEmpleado.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Por favor seleccione un empleado !", cbEmpleado)
        ElseIf NCantidadCita.Value = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar una cantidad valida !", NCantidadCita)
        ElseIf NCantidadTiempo.Value = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar una cantidad en tiempo valida !", NCantidadTiempo)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()
                    ConfigCitaBLL.guardarConfigCita(objConfiguracion)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)

                    If Not IsNothing(formCitaMedica) Then
                        formCitaMedica.cargarComboMedico()
                    End If

                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    Dim params As New List(Of String)
                    params.Add(objConfiguracion.idEmpleado)
                    General.ejecutarSQL("[PROC_CONFIG_CITA_ANULAR]", params)
                    General.deshabilitarBotones(ToolStrip1)
                    General.limpiarControles(Me)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
            cbEmpleado.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento("[PROC_CONFIG_CITA_BUSCAR] ''",
                           Nothing,
                           AddressOf cargarDatos,
                           "Configuración Cita",
                           False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarObjeto()
        objConfiguracion.idEmpleado = cbEmpleado.SelectedValue
        objConfiguracion.cantidadCita = NCantidadCita.Value
        objConfiguracion.tiempo = NCantidadTiempo.Value
    End Sub
    Private Sub cargarDatos(pCodigo)
        Dim drDestino As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drDestino = General.cargarItem("[PROC_CONFIG_CITA_CARGAR]", params)
        cbEmpleado.SelectedValue = pCodigo
        NCantidadCita.Value = drDestino.Item("Cantidad_Cita")
        NCantidadTiempo.Value = drDestino.Item("Tiempo_Cita")
        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        objConfiguracion.idEmpleado = pCodigo
    End Sub
End Class