Imports System.Data.SqlClient
Public Class FormEntrega
    Dim entrega As New EntregaBLL
    Public comboEntrega As ComboBox
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub FormEntrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub Form_EntregaClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        'descripcion guarda y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 15/06/2016

        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de la linea !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()

        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtnombre.Text)
                params.Add(txtcodigo.Text)
                If General.getEstadoVF(Consultas.ENTREGA_DIA_VERIFICAR, params) Then
                    MsgBox("El dia: " & txtnombre.Text & " ya existe", MsgBoxStyle.Exclamation)
                    txtnombre.Clear()
                Else
                    entrega.guardar_plazo(txtcodigo, txtnombre.Text)
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                    If Not IsNothing(comboEntrega) Then
                        General.cargarCombo(Consultas.DIAS_ENTREGA_LISTAR, "Descripción", "Código", comboEntrega)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.DIAS_ENTREGA_LISTAR,
                             Nothing,
                             AddressOf cargarDatos,
                             TitulosForm.BUSQUEDA_ENTREGA,
                             True, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.DIAS_ENTREGA_CARGAR, params, dt)
        txtnombre.Text = dt.Rows(0).Item("Descripción").ToString
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
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

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            Try

                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Dim params As New List(Of String)
                    params.Add(txtcodigo.Text)
                    params.Add(SesionActual.idUsuario)
                    General.ejecutarSQL(Consultas.ANULAR_ENTREGA, params)


                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.limpiarControles(Me)
                    btanular.Enabled = False
                    btcancelar.Enabled = False
                    bteditar.Enabled = False

                End If

            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
End Class