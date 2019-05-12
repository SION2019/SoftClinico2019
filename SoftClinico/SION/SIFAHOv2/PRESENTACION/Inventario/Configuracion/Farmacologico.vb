Imports System.Data.SqlClient
Public Class Farmacologico
    Public farmaco As String
    Dim perG As New Buscar_Permisos_generales
    Dim objFarmaco As New GrupoFarmaco
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Farmacologico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        If txtcodigo.Text = "" Then
            General.cargarCombo(Consultas.FARMACOLOGICO_LISTAR, "Nombre", "Codigo linea", cbofarmaco)
        End If
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
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

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda una linea y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 05/05/2016

        Try
            If txtnombre.Text = "" Then
                MsgBox("¡ Por favor digite el nombre del farmaco !", MsgBoxStyle.Exclamation)
                txtnombre.Focus()
            ElseIf cbofarmaco.SelectedValue = -1 Then
                MsgBox("¡ Debe seleccionar una linea  !", MsgBoxStyle.Exclamation)
                cbofarmaco.Focus()
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    objFarmaco.nombre = txtnombre.Text
                    objFarmaco.combofarmaco = cbofarmaco.SelectedValue
                    objFarmaco.usuario = SesionActual.idUsuario
                    objFarmaco.codigo = txtcodigo.Text.Trim()
                    objFarmaco.guardarFarmaco()
                    txtcodigo.Text = objFarmaco.codigo
                    MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Information)
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btcancelar.Enabled = False
                    btbuscar.Enabled = True
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consultas.BUSQUEDA_FARMACOLOGICO, Nothing,
                                   AddressOf cargarFarmaco,
                                   TitulosForm.BUSQUEDA_FARMACOLOGICO,
                                    False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarFarmaco(fCodigo As String)
        Dim dt As New DataTable

        Dim param As New List(Of String)
        param.Add(fCodigo)

        General.llenarTabla(Consultas.BUSQUEDA_FARMACOLOGICO2, param, dt)
        txtcodigo.Text = dt.Rows(0).Item("CodigoGrupo")
        txtnombre.Text = dt.Rows(0).Item("Nombre")
        cbofarmaco.SelectedValue = dt.Rows(0).Item("Codigo_linea")

        bteditar.Enabled = True
        btcancelar.Enabled = False


    End Sub


    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub


End Class