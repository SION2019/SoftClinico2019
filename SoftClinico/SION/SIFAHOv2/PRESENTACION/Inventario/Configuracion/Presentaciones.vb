Imports System.Data.SqlClient
Public Class Presentaciones
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim presentacionE As Presentacion
    Private Sub Presentaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
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
#Region "Botones"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        cargarManual()
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
            busacar()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de presentacion !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardar()
            End If
        End If
    End Sub

#End Region
#Region "Metodos"
    Sub guardar()
        Dim presentacionCmd As New ProductoPresentacionBLL
        presentacionE = New Presentacion
        establecerObjeto(presentacionE)
        Try
            presentacionCmd.guardar(presentacionE, SesionActual.idUsuario)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, Nothing, bteditar)
            cargarPresentacion(presentacionE.Codigo)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub anular()
        Dim presentacionCmd As New ProductoPresentacionBLL
        presentacionE = New Presentacion
        establecerObjeto(presentacionE)
        Try
            presentacionCmd.anular(presentacionE, SesionActual.idUsuario)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub busacar()
        Dim params As New List(Of String)
        params.Add("")
        General.buscarElemento(Consultas.PRESENTACION_BUSCAR,
                               params,
                               AddressOf cargarPresentacion,
                               TitulosForm.BUSQUEDA_PRESENTACION,
                               False, 0, True)
    End Sub
    Sub establecerObjeto(ByRef objpresentacion As Presentacion)
        objpresentacion.Codigo = txtcodigo.Text
        objpresentacion.Descripcion = txtnombre.Text
    End Sub

    Sub reflearObjeto(ByRef objpresentacion As Presentacion)
        txtcodigo.Text = presentacionE.Codigo
        txtnombre.Text = presentacionE.Descripcion
    End Sub
    Sub cargarPresentacion(ByVal Codigo As String)
        presentacionE = New Presentacion
        Dim params As New List(Of String)
        params.Add(Codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.PRESENTACION_CARGAR_INFORMACION, params)
        presentacionE.Codigo = fila(0)
        presentacionE.Descripcion = fila(1)
        reflearObjeto(presentacionE)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, Nothing)
    End Sub
    Sub cargarManual()
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
#End Region

End Class