Imports System.Data.SqlClient
Public Class Empaque

    Private Sub Empaque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los EMPAQUES y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 07/05/2016

        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de la linea !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then


                Using consulta = New SqlCommand()
                    Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                        consulta.Connection = FormPrincipal.cnxion
                        consulta.Transaction = trnsccion
                        If txtcodigo.Text <> "" Then
                            consulta.CommandText = "execute EMPAQUE_ACTUALIZACION @Descripcion='" & txtnombre.Text & "',@usuario_actualizacion='" & SesionActual.idUsuario & "',@Codigo_empaque='" & txtcodigo.Text.Trim & "'"
                            consulta.ExecuteNonQuery()
                        Else

                            consulta.CommandText = "execute EMPAQUE_CREAR @Descripcion='" & txtnombre.Text & "',@Usuario='" & SesionActual.idUsuario & "'"
                            txtcodigo.Text = CType(consulta.ExecuteScalar, String)
                        End If

                        Try
                            trnsccion.Commit()
                            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                            General.habilitarBotones(Me.ToolStrip1)
                            General.deshabilitarControles(Me)
                            btguardar.Enabled = False '--Guardar--
                            btcancelar.Enabled = False '--Cancelar--
                        Catch ex As Exception
                            trnsccion.Rollback()
                        End Try
                    End Using
                End Using
            End If
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 07/05/2016
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion

                    consulta.CommandText = "execute EMPAQUE_ANULAR @Usuario='" & SesionActual.idUsuario & "',@Codigo_empaque='" & txtcodigo.Text.Trim & "'"
                    consulta.ExecuteNonQuery()

                    Try
                        trnsccion.Commit()
                        General.limpiarControles(Me)
                        General.deshabilitarControles(Me)
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)

                    Catch ex As Exception
                        trnsccion.Rollback()
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        txtnombre.Focus()

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(Me)
        btcancelar.Enabled = True '--Cancelar--
        btguardar.Enabled = True '--Guardar--
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
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
End Class