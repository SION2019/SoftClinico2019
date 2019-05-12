Imports System.Data.SqlClient
Public Class Form_diagnostico_cie
    Dim objDiagnostico As New ConfiguracionDiagnostico
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objDiagnostico.usuario = SesionActual.idUsuario
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
        General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", ComboGenero)
    End Sub

    Private Function validacioneCampos() As Boolean
        Dim bdra As Boolean
        If String.IsNullOrWhiteSpace(txtcodigo.Text) Then
            Exec.SavingMsg("¡ Por favor digite el código del diagnostico !", txtcodigo)
        ElseIf String.IsNullOrWhiteSpace(TextCategoria.Text) Then
            Exec.SavingMsg("¡ Por favor digite el código categoria del diagnostico !", TextCategoria)
        ElseIf String.IsNullOrWhiteSpace(txtnombre.Text) Then
            Exec.SavingMsg("¡ Por favor digite el nombre del diagnostico !", txtnombre)
        ElseIf ComboGenero.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Por favor seleccionar el genero !", ComboGenero)
        ElseIf String.IsNullOrWhiteSpace(TextEdadInici.Text) Then
            Exec.SavingMsg("¡ Por favor digite la edad inicial del diagnostico !", TextEdadInici)
        ElseIf String.IsNullOrWhiteSpace(TextEdadFinal.Text) Then
            Exec.SavingMsg("¡ Por favor digite la edad final del diagnostico !", TextEdadFinal)
        ElseIf CInt(TextEdadInici.Text) > CInt(TextEdadFinal.Text) Then
            Exec.SavingMsg("¡ La edad Iniciar no puede ser mayor a la edad Final !", TextEdadFinal)
        Else
            bdra = True
        End If
        Return bdra
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los documentos y actualiza: 
        'Autor: poseidon
        'fecha_creacion: 03/06/2016

        If validacioneCampos() = True
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()
                    DiagnosticoBLL.guardarDiagnoticos(objDiagnostico)
                    txtcodigo.Text = objDiagnostico.codigo
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
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    If General.anularConValidacion(Consultas.DIAGNOSTICO_ANULAR &
                                               txtcodigo.Text & "'" &
                                               ConstantesHC.NOMBRE_PDF_SEPARADOR3 &
                                               objDiagnostico.usuario) = True Then
                        General.deshabilitarBotones(ToolStrip1)
                        General.limpiarControles(Me)
                        General.deshabilitarControles(Me)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Else
                        MsgBox(Mensajes.NO_ANULAR_DIAGNOSTICO, MsgBoxStyle.Information)
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
            txtcodigo.ReadOnly = False
            txtcodigo.Focus()
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

    Private Sub TextEdadInici_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEdadInici.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub

    Private Sub TextEdadFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEdadFinal.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_DIAGNOSTICO,
                       Nothing,
                       AddressOf cargarDiagnosticoCIE,
                       TitulosForm.BUSQUEDA_DIAGNOSTICO_CIE,
                       False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarDiagnosticoCIE(pCodigo As String)
        Dim drDiagnosticoCIE As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drDiagnosticoCIE = General.cargarItem(Consultas.DIAGNOSTICO_CARGAR, params)
        txtcodigo.Text = pCodigo
        If Not IsNothing(drDiagnosticoCIE) Then
            txtnombre.Text = drDiagnosticoCIE(1)
            TextCategoria.Text = drDiagnosticoCIE(2)
            ComboGenero.SelectedValue = drDiagnosticoCIE(3)
            TextEdadInici.Text = drDiagnosticoCIE(4)
            TextEdadFinal.Text = drDiagnosticoCIE(5)
            General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        End If
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
        objDiagnostico.codigo = txtcodigo.Text
        objDiagnostico.codigoCategoria = TextCategoria.Text
        objDiagnostico.descripcion = txtnombre.Text
        objDiagnostico.codigoGenero = ComboGenero.SelectedValue
        objDiagnostico.edadInicial = TextEdadInici.Text
        objDiagnostico.edadFinal = TextEdadFinal.Text
    End Sub
End Class