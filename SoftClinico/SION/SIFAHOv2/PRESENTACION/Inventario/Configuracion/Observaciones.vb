Imports System.Data.SqlClient
Public Class Observaciones
    Dim objObservacion As New Observacion
    Dim perG As New Buscar_Permisos_generales
    Public bobservaciones As Boolean
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Observaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Observaciones_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        If String.IsNullOrEmpty(txtnombre.Text) Then
            MsgBox("El campo descripcion se encuentra vacio", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objObservacion.codigo = txtcodigo.Text
                objObservacion.descripcion = txtnombre.Text
                objObservacion.usuario = SesionActual.idUsuario
                objObservacion.guardarObservaciones()
                txtcodigo.Text = objObservacion.codigo
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_OBSERVACION, Nothing,
                                   AddressOf cargarObservacion,
                                   TitulosForm.BUSQUEDA_OBSERVACIONES,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarObservacion(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_CARGAR, params, dt)

        txtcodigo.Text = pCodigo
        txtnombre.Text = dt.Rows(0).Item("Observación")


        bteditar.Enabled = True
        btcancelar.Enabled = False
        btanular.Enabled = True
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
        'fecha_creacion: 05/05/2016
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_OBSERVACION, params)
                General.limpiarControles(Me)
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                bteditar.Enabled = False
                btanular.Enabled = False
                btcancelar.Enabled = False
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class