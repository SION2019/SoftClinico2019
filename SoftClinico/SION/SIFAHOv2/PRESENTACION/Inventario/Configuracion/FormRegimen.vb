Public Class FormRegimen
    Dim regimen As New Regimen_D
    'Dim perG As New Buscar_Permisos_generales
    'Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public bregimen As Boolean
    Private Sub FormRegimen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'permiso_general = perG.buscar_permiso_general(Name)
        'Pnuevo = permiso_general & "pp" & "01"
        'Peditar = permiso_general & "pp" & "02"
        'Panular = permiso_general & "pp" & "03"
        'PBuscar = permiso_general & "pp" & "04"
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
            MsgBox("¡ Por favor digite el nombre de la linea !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                If regimen.guardar(txtcodigo.Text, txtnombre.Text) = True Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                End If
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If FormPrincipal.dt_permisos.Select("Codigo_Menu='" & PBuscar ) Then
        General.buscarElemento(Consultas.TIPO_REGIMEN_BUSCAR, Nothing,
                               AddressOf cargarRegimen,
                               TitulosForm.BUSQUEDA_REGIMEN,
                               False, 0, True)


        bteditar.Enabled = True
        btcancelar.Enabled = True
        btanular.Enabled = True

        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Public Sub cargarRegimen(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.TIPO_REGIMEN_CARGAR, params, dt)

        txtcodigo.Text = pCodigo
        txtnombre.Text = dt.Rows(0).Item("Descripcion_Regimen")

        bteditar.Enabled = True
        btcancelar.Enabled = True
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

            If regimen.anular(txtcodigo.Text.ToString) = True Then
                General.limpiarControles(Me)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            End If
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
End Class