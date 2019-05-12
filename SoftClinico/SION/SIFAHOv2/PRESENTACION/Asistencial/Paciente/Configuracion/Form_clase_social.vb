Imports System.Data.SqlClient
Public Class Form_clase_social
    Dim objConfiguracion As New ConfiguracionGeneral
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objConfiguracion.idUsuario = SesionActual.idUsuario
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los documentos y actualiza: 
        'Autor: poseidon
        'fecha_creacion: 01/06/2016

        If String.IsNullOrWhiteSpace(txtnombre.Text) Then
            Exec.SavingMsg("¡ Por favor digite el nombre de la Clase social !", txtnombre)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()
                    ClaseSocialBLL.guardarClaseSocial(objConfiguracion)
                    txtcodigo.Text = objConfiguracion.codigo
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    If General.verificar_formulario(Form_paciente) = True Then
                        General.cargarCombo(Consultas.ESTRATO_LISTAR,
                                            "Clase Social",
                                            "Codigo",
                                            Form_paciente.comboestrato)
                    End If
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: poseidon
        'fecha_creacion: 01/06/2016

        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    If General.anularConValidacion(Consultas.CLASE_SOCIAL_ANULAR &
                                               txtcodigo.Text &
                                               ConstantesHC.NOMBRE_PDF_SEPARADOR3 &
                                               objConfiguracion.idUsuario) = True Then
                        General.deshabilitarBotones(ToolStrip1)
                        General.limpiarControles(Me)
                        General.deshabilitarControles(Me)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Else
                        MsgBox(Mensajes.NO_ANULAR_CLASE_SOCIAL, MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
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

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                General.habilitarControles(Me)
                btcancelar.Enabled = True '--Cancelar--
                btguardar.Enabled = True '--Guardar--  
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(Consultas.ESTRATO_LISTAR,
                               Nothing,
                               AddressOf cargarClaseSocial,
                               TitulosForm.BUSQUEDA_CLASE_SOCIAL,
                               False, 0, True)
    End Sub

    Public Sub cargarClaseSocial(pCodigo As String)
        Dim drClaseSocial As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)

        drClaseSocial = General.cargarItem(Consultas.CLASE_SOCIAL_CARGAR, params)
        txtcodigo.Text = pCodigo
        txtnombre.Text = drClaseSocial.Item(0)

        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Private Sub cargarObjeto()
        objConfiguracion.codigo = txtcodigo.Text
        objConfiguracion.descripcion = txtnombre.Text
    End Sub
End Class