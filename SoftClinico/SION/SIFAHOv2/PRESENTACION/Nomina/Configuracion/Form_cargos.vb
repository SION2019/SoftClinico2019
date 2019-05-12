Public Class Form_Cargos
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objCargos As Cargo
    Public comboCargo As ComboBox
    Private Sub Form_Cargos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text.Trim = "" Then
            MsgBox("Debe colocar el nombre del cargo antes de guardar !!", MsgBoxStyle.Information And MsgBoxStyle.OkOnly, "SIFAHO")
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardar()
            End If
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            buscar()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Metodos"
    Sub anular()
        Dim objCargoBLL As New CargoBLL
        objCargos = New Cargo
        establecerObjeto(objCargos)
        Try
            objCargoBLL.anularCargo(objCargos)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub guardar()
        Dim objCargaoBLL As New CargoBLL
        objCargos = New Cargo
        establecerObjeto(objCargos)
        Try
            objCargaoBLL.guardarCargo(objCargos)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            reflejarObjeto(objCargos)
            If Not IsNothing(comboCargo) Then
                Dim params As New List(Of String)
                params.Add(Nothing)
                General.cargarCombo(Consultas.CARGO_LISTAR, params,
                                    "Descripción cargo",
                                    "Código",
                                   comboCargo)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub buscar()
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.CARGO_LISTAR,
                                  params,
                                  AddressOf cargarCargo,
                                  TitulosForm.BUSQUEDA_CARGOS,
                                  False, 0, True)

    End Sub
    Sub establecerObjeto(ByRef objCargo As Cargo)
        objCargos.codigo = txtcodigo.Text
        objCargos.descripcion = txtnombre.Text
    End Sub
    Sub cargarCargo(ByVal codigo As String)
        objCargos = New Cargo
        Dim params As New List(Of String)
        params.Add(codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGO_CARGAR_INFORMACION, params)
        objCargos.codigo = fila(0)
        objCargos.descripcion = fila(1)
        reflejarObjeto(objCargos)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Sub reflejarObjeto(ByRef objCargos As Cargo)
        txtcodigo.Text = objCargos.codigo
        txtnombre.Text = objCargos.descripcion
    End Sub
#End Region
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
End Class