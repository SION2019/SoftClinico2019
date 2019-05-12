Imports System.Data.SqlClient
Public Class Form_estado_atencion
    Dim objConfiguracion As New ConfiguracionGeneral
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
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
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los documentos y actualiza: 
        'Autor: poseidon
        'fecha_creacion: 03/06/2016

        If String.IsNullOrWhiteSpace(txtnombre.Text) Then
            Exec.SavingMsg("¡ Por favor digite el nombre de la estado atenciòn !", txtnombre)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()
                    EstadoAtencionBLL.guardarEstadoAtencion(objConfiguracion)
                    txtcodigo.Text = objConfiguracion.codigo
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    bteditar.Enabled = True
                    btanular.Enabled = True
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
                    If General.anularConValidacion(Consultas.ESTADO_ATENCION_ANULAR &
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
                        MsgBox(Mensajes.NO_ANULAR_ESTADO_ATENCION, MsgBoxStyle.Information)
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
        If SesionActual.tienePermiso(Peditar ) Then
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.ESTADO_ATENCION_BUSCAR,
                                   Nothing,
                                   AddressOf cargar,
                                   TitulosForm.BUSQUEDA_ESTADO_ATENCION,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub cargar(pCodigo As String)
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.ESTADO_ATENCION_CARGAR, params)
        txtcodigo.Text = pCodigo
        txtnombre.Text = dr.Item(0)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
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