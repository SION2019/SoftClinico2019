Public Class Form_Traslado_Cama

    Dim vFormPadre As Form_Historia_clinica
    Dim area, nRegistro As Integer

    Public Sub datosPrincipales(ByRef form_Historia_clinica As Form_Historia_clinica, area As Integer, nRegistro As Integer)
        Me.vFormPadre = form_Historia_clinica
        Me.area = area
        Me.nRegistro = nRegistro
    End Sub

    Private Sub Form_Traslado_Cama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Se cargan los valores iniciales
        txtCamaActual.Text = vFormPadre.txtCama.Text

        Dim params As New List(Of String)
        params.Add(area)
        params.Add(SesionActual.codigoEP)
        params.Add(nRegistro)

        General.cargarCombo(Consultas.CAMAS_DISPONIBLES, params, "Cama", "Id", cbCamasDisponibles)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardarRegistroCama()
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)

            vFormPadre.txtCama.Text = cbCamasDisponibles.Text
        End If
    End Sub

    Private Function validarFormulario() As Boolean

        If cbCamasDisponibles.SelectedValue = Constantes.VALOR_PREDETERMINADO Then
            MsgBox("Favor elija una de la lista de camas disponibles!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function

    Private Sub guardarRegistroCama()

        Try
            TrasladoCamaBLL.actualizarRegistroCama(nRegistro, cbCamasDisponibles.SelectedValue)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

End Class