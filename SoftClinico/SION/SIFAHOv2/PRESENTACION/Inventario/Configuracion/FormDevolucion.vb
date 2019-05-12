Imports System.Data.SqlClient
Public Class FormDevolucion
    Dim objDevolucion As New DiaDevolucion

    Public comboDevolucion As ComboBox
    Private Sub FormDevolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 15/06/2016

        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el Dia !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()

        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtnombre.Text)
                params.Add(txtcodigo.Text)
                If General.getEstadoVF(Consultas.DEVOLUCION_DIA_VERIFICAR, params) Then
                    MsgBox("El dia: " & txtnombre.Text & " ya existe", MsgBoxStyle.Exclamation)
                    txtnombre.Clear()
                Else
                    objDevolucion.codigo = txtcodigo.Text
                    objDevolucion.nombre = CInt(txtnombre.Text)
                    objDevolucion.guararDevolucuion()
                    txtcodigo.Text = objDevolucion.codigo
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                    If Not IsNothing(comboDevolucion) Then
                        General.cargarCombo(Consultas.DIAS_DEVOLUCION_LISTAR, "Descripción", "Código", comboDevolucion)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(Consultas.BUSQUEDA_DEVOLUCION, Nothing, AddressOf cargar, TitulosForm.BUSQUEDA_MARCAS, True, 0, True)
    End Sub

    Sub cargar(pcodigo As String)
        txtcodigo.Text = pcodigo.Split("|")(0)
        txtnombre.Text = pcodigo.Split("|")(1)

        bteditar.Enabled = True
        btcancelar.Enabled = False
        btanular.Enabled = True
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If FormPrincipal.dt_permisos.Select("Codigo_Menu='" & Peditar ) Then
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(Me)
        btcancelar.Enabled = True '--Cancelar--
        btguardar.Enabled = True '--Guardar--
        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 05/05/2016
        'If FormPrincipal.dt_permisos.Select("Codigo_Menu='" & Panular ) Then
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

            Dim params As New List(Of String)
            params.Add(txtcodigo.Text)
            General.ejecutarSQL(Consultas.ANULAR_DEVOLUCION, params)
            General.limpiarControles(Me)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                btanular.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False

        End If
        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        'If FormPrincipal.dt_permisos.Select("Codigo_Menu='" & Pnuevo ) Then
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        txtnombre.Focus()
        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
End Class