Public Class Form_tipo_Bodega
    Dim cmd As New BodegaTipoBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objTipoBodega As TipoBodega
    Public Property formBodega As Bodega
    Private Sub Form_tipo_Bodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "Metodos"
    Sub inicializarForm()
        objTipoBodega = New TipoBodega
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub nuevo()
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cancelar()
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub editar()
        If SesionActual.tienePermiso(Peditar ) Then
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub anular()
        Dim respuesta As Boolean
        Try
            If SesionActual.tienePermiso(Panular ) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_TIPO_BODEGA & CInt(txtcodigo.Text) & "," & SesionActual.idUsuario & "")

                    If respuesta = True Then
                        formBodega.llenaTipoBodega()
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub guardar()
        If txtnombre.Text.Trim = "" Then
            MsgBox("Debe colocar el nombre de la marca antes de guardar !!", MsgBoxStyle.Information And MsgBoxStyle.OkOnly)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                empalmarDiseñoToObjeto()
                cmd.guardarTipoBodega(objTipoBodega, SesionActual.idUsuario)
                cargarDatos(objTipoBodega.codigo)
                formBodega.llenaTipoBodega()
                General.posGuardarForm(Me, ToolStrip1, btnuevo, bteditar, btbuscar, btanular)
            End If
        End If
    End Sub
    Sub buscar()
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.TIPO_BODEGA,
                              Nothing,
                              AddressOf cargarDatos,
                              TitulosForm.BUSQUEDA_BODEGA,
                              True, 0, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub emplamarObjetotoDiseño()
        txtcodigo.Text = objTipoBodega.codigo
        txtnombre.Text = objTipoBodega.nombre
    End Sub
    Sub empalmarDiseñoToObjeto()
        objTipoBodega.codigo = txtcodigo.Text
        objTipoBodega.nombre = txtnombre.Text
    End Sub
    Private Sub cargarDatos(pCodigo As Integer)
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        objTipoBodega.codigo = pCodigo
        fila = General.cargarItem(Consultas.TIPO_BODEGA_CARGAR, params)
        objTipoBodega.nombre = fila.Item("Descripcion")
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        emplamarObjetotoDiseño()
    End Sub
#End Region
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        nuevo()
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        cancelar()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        editar()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        anular()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardar()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        buscar()
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