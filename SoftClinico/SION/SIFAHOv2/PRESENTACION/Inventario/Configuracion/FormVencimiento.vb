Imports System.Data.SqlClient
Public Class FormVencimiento
    Dim objVencimiento As New DiaVencimiento
    Public comboVencimiento As ComboBox
    Private Sub FormVencimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        General.deshabilitarControles(Me)
    End Sub

    Private Sub FormVencimiento_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            If txtnombre.Text = "" Then
                MsgBox("¡ Por favor digite el dia !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
                txtnombre.Focus()
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                    Dim params As New List(Of String)
                    params.Add(txtnombre.Text)
                    params.Add(txtcodigo.Text)
                    If General.getEstadoVF(Consultas.VENCIMIENTO_DIA_VERIFICAR, params) Then
                        MsgBox("El dia: " & txtnombre.Text & " ya existe", MsgBoxStyle.Exclamation)
                        txtnombre.Clear()
                    Else
                        objVencimiento.codigo = txtcodigo.Text
                        objVencimiento.nombre = txtnombre.Text
                        objVencimiento.guardarVencimiento()
                        txtcodigo.Text = objVencimiento.codigo
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        General.habilitarBotones(Me.ToolStrip1)
                        General.deshabilitarControles(Me)
                        btguardar.Enabled = False '--Guardar--
                        btcancelar.Enabled = False '--Cancelar--
                        If Not IsNothing(comboVencimiento) Then
                            General.cargarCombo(Consultas.DIAS_VENCIMIENTO_LISTAR, "Descripción", "Código", comboVencimiento)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try
            General.buscarElemento(Consultas.BUSQUEDA_DIAS_VENCIMIENTO, Nothing, AddressOf cargaVencimiento,
                                                         TitulosForm.BUSQUEDA_DIAS_VENCIMIENTO, True, 0, True)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargaVencimiento(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CARGA_VENCIMIENTO, params, dtCarga)
        txtcodigo.Text = dtCarga.Rows(0).Item(0)
        txtnombre.Text = dtCarga.Rows(0).Item(1)
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
        End If


    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 05/05/2016
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Dim params As New List(Of String)
            params.Add(txtcodigo.Text)
            General.ejecutarSQL(Consultas.ANULAR_VENCIMIENTO, params)
            General.limpiarControles(Me)
            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            btanular.Enabled = False
            bteditar.Enabled = False
            btcancelar.Enabled = False
        End If

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click

        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        txtnombre.Focus()

    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub


End Class