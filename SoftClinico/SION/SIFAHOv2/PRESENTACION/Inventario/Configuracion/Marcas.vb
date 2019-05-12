Public Class Marcas
    Dim cmd As New ProductoMarcaBLL
    Dim perG As New Buscar_Permisos_generales
    Dim objProductoMarca As Marca
    Public Property formProductos As Productos
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProductoMarca = New Marca
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
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
#Region "Metodos"
    Sub cargarMarcaBuscada(pCodigo As String)
        objProductoMarca.codigo = pCodigo
        objProductoMarca.cargarMarca(objProductoMarca)
        empalmarDatosAlDiseño(objProductoMarca)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Sub empalmarDatosAlObjetoMarca(ByRef objMarca As Marca)
        objMarca.codigo = If(txtcodigo.Text = "", -1, txtcodigo.Text)
        objMarca.nombre = txtnombre.Text
    End Sub
    Sub empalmarDatosAlDiseño(ByRef objMarca As Marca)
        txtcodigo.Text = objMarca.codigo
        txtnombre.Text = objMarca.nombre
    End Sub
#End Region
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                txtnombre.Focus()
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim objProductoMarcaBLL As New ProductoMarcaBLL
                Try
                    empalmarDatosAlObjetoMarca(objProductoMarca)
                    objProductoMarcaBLL.anularMarca(objProductoMarca, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    formProductos.llenar_marcas()
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text.Trim = "" Then
            MsgBox(Mensajes.MSM_NOMBRE, MsgBoxStyle.Exclamation)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    Dim objProductoMarcaBLL As New ProductoMarcaBLL
                    empalmarDatosAlObjetoMarca(objProductoMarca)
                    objProductoMarcaBLL.guardarMarca(objProductoMarca, SesionActual.idUsuario)
                    empalmarDatosAlDiseño(objProductoMarca)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    formProductos.llenar_marcas()
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_MARCAS, Nothing, AddressOf cargarMarcaBuscada, TitulosForm.BUSQUEDA_MARCAS, True, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
End Class