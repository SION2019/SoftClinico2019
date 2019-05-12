Imports System.Data.SqlClient
Public Class Transportadoras
    Dim clasetrans As New TransportadoraBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Transportadoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
        ' descripcion guarda una linea y actualiza
        'Autor:  Lycans
        'fecha_creacion: 26/05/2016

        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de transportadora !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                clasetrans.guardartrans(txtcodigo, txtnombre.Text, SesionActual.idUsuario)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                End If
            End If

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consultas.BUSCAR_TRANSPORTADORA,
                                   Nothing,
                                   AddressOf cargarTransportadora,
                                   TitulosForm.BUSQUEDA_TRANSPORTADORAS,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarTransportadora(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drFila = General.cargarItem(Consultas.TRANSPORTADORA_CARGAR, params)

        txtcodigo.Text = pCodigo
        txtnombre.Text = drFila.Item(0).ToString()

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
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

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click

        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 26/05/2016
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                If clasetrans.anulartrans(txtcodigo.Text.ToString, SesionActual.idUsuario) = True Then
                    General.limpiarControles(Me)
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                End If
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class