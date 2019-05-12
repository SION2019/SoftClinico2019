Public Class Form_Perfil_Paraclinico
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim area As Integer
    Dim objPerfilP As New PerfilParaclinico


    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'Guarda en base de datos los valores de tarifa de tripulantes Ambulancia
        If ValidarDatos() = True Then Exit Sub
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            If cargarObjetoPerfilP() = True Then
                Try
                    PerfilParaclinicoBLL.guardarPerfilParaclinico(objPerfilP)
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    txtcodigo.Text = objPerfilP.codigo
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If SesionActual.tienePermiso(PBuscar) Then
        General.buscarElemento(objPerfilP.sqlBuscarPerfilParaclinicoG,
                                   Nothing,
                                   AddressOf cargarPerfilParaclinico,
                                   TitulosForm.BUSQUEDA_PERFIL_PARACLINICO,
                                   False, 0, True)
        'Else
        'MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Function ValidarDatos() As Boolean
        If String.IsNullOrEmpty(txtDescripcion.Text) Then
            MsgBox("La Descripcion esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If SesionActual.tienePermiso(Peditar) Then
        'Actualiza en base de datos los valores de tarifa de tripulantes Ambulancia
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            Me.txtDescripcion.ReadOnly = False
        'Else
        'MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'If SesionActual.tienePermiso(Panular) Then
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    objPerfilP.AnularPerfilParaclinico()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        ' Else
        ' MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        ' End If
    End Sub

    Private Sub btOpcionConfiguracionHorario_Click(sender As Object, e As EventArgs)
        Dim ConfPP As New Form_Conf_Perfil_Paraclinico
        ConfPP.ShowDialog()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub Form_Perfil_Paraclinico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Function cargarObjetoPerfilP() As Boolean
        Dim resp As Boolean = True
        Try
            objPerfilP.codigo = txtcodigo.Text
            objPerfilP.Descripcion = txtDescripcion.Text
        Catch ex As Exception
            General.manejoErrores(ex)
            resp = False
        End Try
        Return resp
    End Function

    Private Sub Form_Perfil_Paraclinico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPerfilP.Usuario = SesionActual.idUsuario
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        txtcodigo.Enabled = False
        txtDescripcion.ReadOnly = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        ' If SesionActual.tienePermiso(Pnuevo) Then
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtDescripcion.ReadOnly = False
        'Else
        ' MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        ' End If
    End Sub

    Private Sub cargarPerfilParaclinico(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objPerfilP.sqlCargarPerfilParaclinico, params)
            objPerfilP.codigo = pCodigo
            txtcodigo.Text = pCodigo
            txtDescripcion.Text = dFila.Item(1)
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class