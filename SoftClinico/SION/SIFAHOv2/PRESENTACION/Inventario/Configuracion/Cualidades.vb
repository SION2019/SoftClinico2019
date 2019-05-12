Public Class Cualidades
    'Descripcion: Creación general del formulario de cualidades  
    'Autor: trululu
    'fecha_creacion: 14/05/2016 10:00 a.m.

    'Descripcion: Modificado utilización de los permisos 
    'Autor: trululu
    'fecha_creacion: 23/05/2016 10:47 a.m.

    Dim cmd As New ProductoCualidadBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Cualidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        txtnombre.Enabled = True
        txtnombre.ReadOnly = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            btguardar.Enabled = True
            btcancelar.Enabled = True
            bteditar.Enabled = False
            btanular.Enabled = False
            btnuevo.Enabled = False
            txtnombre.Focus()
            txtnombre.Clear()
            txtcodigo.Clear()
            btbuscar.Enabled = False
            General.habilitarControles(Me)
            txtcodigo.ReadOnly = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                'metodo de anular
                If cmd.anular_cualidad(txtcodigo.Text) = True Then
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    btguardar.Enabled = False
                    bteditar.Enabled = False
                    btanular.Enabled = False
                    txtcodigo.Clear()
                    txtnombre.Clear()
                Else
                    '' aqui se va a poner algo si o no?
                End If
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text.Trim = "" Then
            MsgBox("Debe colocar el nombre de la cualidad antes de guardar !!", MsgBoxStyle.OkOnly)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                'metodo de guardar
                If cmd.guardar_cualidad(txtcodigo.Text, txtnombre.Text) = True Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    General.deshabilitarControles(Me)
                End If
            End If
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                txtnombre.Enabled = True
                txtnombre.ReadOnly = False
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.CUALIDADES_LISTAR,
                                   Nothing,
                                   AddressOf cargarCualidad,
                                   TitulosForm.BUSQUEDA_CUALIDADES,
                                   False, 0, True)


        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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
    Private Sub cargarCualidad(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_CUALIDADES,
                                              params)

        txtcodigo.Text = pCodigo
        txtnombre.Text = dr.Item(0)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
End Class