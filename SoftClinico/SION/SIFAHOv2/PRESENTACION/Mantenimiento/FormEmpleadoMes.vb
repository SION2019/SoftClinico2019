Public Class FormEmpleadoMes
    Dim objEmpleado As New EmpleadoMes
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            btnuevo.Enabled = False
            btguardar.Enabled = True
            bteditar.Enabled = False
            btcancelar.Enabled = True
            btbuscar.Enabled = False
            ComboEmpleado.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then

            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.EMPLEADO_MES,
                                   params,
                                   AddressOf CargarDatos,
                                   TitulosForm.TITULO_EMPLEADO,
                                   False, 0, True)



        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            fechaDate.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
            ComboEmpleado.SelectedValue = -1
            btcancelar.Enabled = False
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            bteditar.Enabled = False
            btguardar.Enabled = False
            ComboEmpleado.Enabled = False
        End If
    End Sub

    Private Sub ComboEmpleado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboEmpleado.SelectedIndexChanged

    End Sub

    Public Sub CargarDatos(ByVal codigo As String)
        Dim params As New List(Of String)
        Dim dt As New DataTable
        params.Add(codigo)
        General.llenarTabla(Consultas.EMPLEADO_MES_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            ComboEmpleado.SelectedValue = dt.Rows(0).Item("idempleado")
            fechaDate.Value = dt.Rows(0).Item("fecha")
        End If
        bteditar.Enabled = True

    End Sub
    Private Sub FormEmpleadoMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.cargarCombo(Consultas.CARGAR_EMPLEADOS_MES, "Empleado", "IdEmpleado", ComboEmpleado)
    End Sub

    Private Sub FormEmpleadoMes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
        Try
            If ComboEmpleado.SelectedValue = -1 Then
                MsgBox("Debe seleccionar un empleado", MsgBoxStyle.Exclamation)
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    objEmpleado.idEmpleado = ComboEmpleado.SelectedValue
                    objEmpleado.fecha = fechaDate.Value
                    objEmpleado.codigoEp = SesionActual.codigoEP
                    objEmpleado.guardarRegistro()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btguardar.Enabled = False
                    btnuevo.Enabled = True
                    bteditar.Enabled = True
                    btcancelar.Enabled = False
                    btbuscar.Enabled = True
                    ComboEmpleado.Enabled = False
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            ComboEmpleado.Enabled = True
            btnuevo.Enabled = False
            btguardar.Enabled = True
            bteditar.Enabled = False
            btcancelar.Enabled = True
            btbuscar.Enabled = False
            fechaDate.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
            ComboEmpleado.SelectedValue = -1
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class