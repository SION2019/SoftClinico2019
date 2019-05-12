Public Class Form_ARP
    Dim cmd As New ArpBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objARL As ARL
    Public comboarp As ComboBox
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Profesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        txtnombre.Enabled = True
        txtnombre.ReadOnly = True
    End Sub
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular ) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objARL = New ARL
                    establecerObjeto(objARL)
                    cmd.anularARP(objARL)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                End If
            Else
               MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If txtnombre.Text.Trim = "" Then
                MsgBox("Debe colocar el nombre de la ARL antes de guardar !!", MsgBoxStyle.Information)
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    objARL = New ARL
                    establecerObjeto(objARL)
                    Dim objArpBll As New ArpBLL
                    objArpBll.guardarArp(objARL)
                    reflejarObjeto(objARL)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    If Not IsNothing(comboarp) Then
                        General.cargarCombo(Consultas.ARP_LISTAR, "Descripción ARP", "Código", comboarp)
                    End If
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                txtnombre.Enabled = True
                txtnombre.ReadOnly = False
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try
            If SesionActual.tienePermiso(PBuscar ) Then
                General.buscarElemento(Consultas.BUSQUEDA_ARL,
                                   Nothing,
                                   AddressOf cargarARL,
                                   TitulosForm.BUSQUEDA_ARL,
                                   True, 0, True)


            Else
               MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub ARP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
#End Region
#Region "Metodos"
    Private Sub establecerObjeto(pObjARL As ARL)
        pObjARL.codigoARL = txtcodigo.Text
        pObjARL.descripcionARL = txtnombre.Text
    End Sub
    Private Sub reflejarObjeto(pObjARL As ARL)
        txtcodigo.Text = pObjARL.codigoARL
        txtnombre.Text = pObjARL.descripcionARL
    End Sub
    Sub cargarARL(ByVal codigo As String)
        objARL = New ARL
        Dim params As New List(Of String)
        params.Add(codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGA_ARL, params)
        objARL.codigoARL = fila(0)
        objARL.descripcionARL = fila(1)
        reflejarObjeto(objARL)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Private Sub cargaARL(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CARGA_ARL, params, dtCarga)
        txtcodigo.Text = dtCarga.Rows(0).Item(0)
        txtnombre.Text = dtCarga.Rows(0).Item(1)
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False

    End Sub
#End Region

End Class