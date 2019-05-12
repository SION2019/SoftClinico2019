Imports System.Data.SqlClient
Public Class Lineas
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objLinea As Linea
    Private Sub Lineas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
#Region "Botones"
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
            buscar()
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
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite la descripción de la linea!", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardar()
            End If
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                anular()
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Metodos"
    Sub guardar()
        Dim lineaCmd As New ProductoLineaBLL
        objLinea = New Linea
        establecerObjeto(objLinea)
        Try
            lineaCmd.guardar(objLinea, SesionActual.idUsuario)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            cargarLiniea(objLinea.codigo)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub anular()
        Try
            Dim lineaCmd As New ProductoLineaBLL
            objLinea = New Linea
            establecerObjeto(objLinea)
            lineaCmd.anular(objLinea, SesionActual.idUsuario)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub buscar()


        General.buscarElemento(Consultas.BUSQUEDA_LINEA,
                               Nothing,
                               AddressOf cargarLiniea,
                               TitulosForm.BUSQUEDA_LINEA,
                               False, 0, True)

    End Sub
    Sub cargarLiniea(ByVal codigo As String)
        objLinea = New Linea
        Dim params As New List(Of String)
        params.Add(codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.LINEA_CARGAR_INFORMACION, params)
        objLinea.codigo = fila(0)
        objLinea.nombre = fila(1)
        objLinea.aplicaViaAdministracion = fila(2)
        reflejarObjeto(objLinea)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Sub reflejarObjeto(ByVal objLinea As Linea)
        txtcodigo.Text = objLinea.codigo
        txtnombre.Text = objLinea.nombre
        chekaplica.Checked = objLinea.aplicaViaAdministracion
    End Sub
    Sub establecerObjeto(ByRef objlinea As Linea)
        objlinea.codigo = txtcodigo.Text
        objlinea.nombre = txtnombre.Text
        objlinea.aplicaViaAdministracion = chekaplica.Checked
        objlinea.usuario = SesionActual.idUsuario
    End Sub
#End Region
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
End Class