Public Class Bodega
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PTipo_bodega, Pasignar_Quitar, pVerDetalleProducto As String
    Dim objBodega As BodegaE
    Private Sub Bodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "Metodos"
    Public Sub llenaTipoBodega()
        General.cargarCombo(Consultas.TIPO_BODEGA, "Descripción", "Código", cmbTipo)
    End Sub
    Public Sub inicializarForm()
        objBodega = New BodegaE
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PTipo_bodega = permiso_general & "pp" & "05"
        Pasignar_Quitar = permiso_general & "pp" & "06"
        pVerDetalleProducto = permiso_general & "pp" & "07"
        llenaTipoBodega()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub buscarResponsable()
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_RESPONSABLE,
                                params,
                                AddressOf cargarResponsableBodega,
                                TitulosForm.BUSQUEDA_RESPONSABLE,
                                False, 0, True)
    End Sub
    Sub editar()
        If SesionActual.tienePermiso(Peditar ) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                txnombreResponsable.ReadOnly = True
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub buscar()
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.BUSQUEDA_BODEGA,
                               params,
                               AddressOf cargarBodega,
                               TitulosForm.BUSQUEDA_BODEGA,
                               False, 0, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub nuevo()
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtCodigoResponsable.Enabled = False
            txnombreResponsable.Enabled = False
            btVerExistencias.Enabled = False
            btnAsignar.Enabled = False
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarBodega(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_BODEGA, params)
        objBodega.codigo = pCodigo
        objBodega.descripcion = dr.Item(0)
        objBodega.codigPunto = dr.Item(1)
        objBodega.codigoTipoBodega = dr.Item(3)
        objBodega.direccion = dr.Item(4)
        objBodega.telefono = dr.Item(5)
        objBodega.noCuenta = dr.Item(6)
        objBodega.incremento = dr.Item(7)
        objBodega.responsable = dr.Item(8)
        objBodega.responsableIdentificacion = dr.Item(9).ToString
        txnombreResponsable.Text = dr.Item(10).ToString
        objBodega.estado = dr.Item(11)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        ToolStripDropDownButton1.Enabled = True
        btVerExistencias.Enabled = True
        btnAsignar.Enabled = True
        empalmarObjetoToDiseño()
    End Sub
    Sub empalmarObjetoToDiseño()
        txtCodigo.Text = objBodega.codigo
        txtnombre.Text = objBodega.descripcion
        cmbTipo.SelectedValue = objBodega.codigoTipoBodega
        txtDireccion.Text = objBodega.direccion
        txtTelefono.Text = objBodega.telefono
        txtCuenta.Text = objBodega.noCuenta
        NDincremento.Value = objBodega.incremento
        txtCodigoResponsable.Text = objBodega.responsableIdentificacion
        ChkActivo.Checked = objBodega.estado
        cmbTipo.SelectedValue = objBodega.codigoTipoBodega
    End Sub
    Sub empalmarDiseñoToObjeto()
        objBodega.codigo = txtCodigo.Text
        objBodega.descripcion = txtnombre.Text
        objBodega.codigPunto = SesionActual.codigoEP
        objBodega.direccion = txtDireccion.Text
        objBodega.telefono = txtTelefono.Text
        objBodega.noCuenta = txtCuenta.Text
        objBodega.incremento = NDincremento.Value
        objBodega.estado = ChkActivo.Checked
        objBodega.codigoTipoBodega = cmbTipo.SelectedValue
    End Sub
    Private Sub cargarPuntoBodega(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_BODEGA_PUNTO, params)
        objBodega.codigPunto = pCodigo
    End Sub
    Private Sub cargarResponsableBodega(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_RESPONSABLE, params)
        objBodega.responsable = dr.Item(0)
        objBodega.responsableIdentificacion = dr.Item(1)
        txtCodigoResponsable.Text = objBodega.responsableIdentificacion
        txnombreResponsable.Text = dr.Item(2)
    End Sub
    Sub guardar()
        If validarForm() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                Dim objBodegaBll As New BodegaBLL
                empalmarDiseñoToObjeto()
                objBodegaBll.establecerGuardado(objBodega, SesionActual.idUsuario)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, bteditar, btbuscar, btanular)
                cargarBodega(objBodega.codigo)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Sub anular()
        Dim respuesta As Boolean
        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_BODEGA & CInt(txtCodigo.Text) & "," & SesionActual.idUsuario & "")
                    If respuesta = True Then
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub cancelar()
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Function validarForm() As Boolean
        If txtnombre.Text.Trim = "" Then
            MsgBox("Debe colocar el nombre de la bodega  antes de guardar !!", MsgBoxStyle.Information)
            txtnombre.Focus()
            Return False
        ElseIf cmbTipo.SelectedIndex < 1 Then
            MsgBox("Debe escoger el tipo de bodega antes de guardar !!", MsgBoxStyle.Information)
            cmbTipo.Focus()
            Return False
        ElseIf txtDireccion.Text.Trim = "" Then
            MsgBox("Debe colocar la dirección  de la bodega antes de guardar !!", MsgBoxStyle.Information)
            txtDireccion.Focus()
            Return False
        ElseIf txtCuenta.Text.Trim = "" Then
            MsgBox("Debe colocar la cuenta antes de guardar !!", MsgBoxStyle.Information)
            txtCuenta.Focus()
            Return False
        ElseIf txtCodigoResponsable.Text.Trim = "" Then
            MsgBox("Debe escoger el responsable antes de guardar !!", MsgBoxStyle.Information)
            btnResponsable.Focus()
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Botones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        If SesionActual.tienePermiso(Pasignar_Quitar) Then
            If txtCodigo.Text = "" Then
                MsgBox("Debe cargar la bodega !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Else
                Form_asignar_productos.objBodega = objBodega
                Form_asignar_productos.ShowDialog()
                'General.cargarForm(Form_asignar_productos)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btVerExistencias_Click(sender As Object, e As EventArgs) Handles btVerExistencias.Click
        If SesionActual.tienePermiso(pVerDetalleProducto) Then
            If txtCodigo.Text = "" Then
                MsgBox("Debe cargar la bodega !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Else

                General.cargarForm(Form_ver_existencias)
                Form_ver_existencias.setCodigoBodega(txtCodigo.Text)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnResponsable_Click(sender As Object, e As EventArgs) Handles btnResponsable.Click
        buscarResponsable()
    End Sub
    Private Sub btnTipoBodega_Click(sender As Object, e As EventArgs) Handles btOpcionTipoBodega.Click
        If SesionActual.tienePermiso(PTipo_bodega) Then
            Dim formTipoBodega As New Form_tipo_Bodega
            formTipoBodega.formBodega = Me
            formTipoBodega.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        nuevo()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        editar()
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        cancelar()
    End Sub

    Private Sub ImprimirEtiquetasMedicamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasMedicamentoToolStripMenuItem.Click

        Cursor = Cursors.WaitCursor
        Dim rpt As New rptStockActual
        Try
            Dim tbl As New Hashtable
            tbl.Add("@Bodega", objBodega.codigo)
            tbl.Add("@Empresa", SesionActual.idEmpresa)
            Funciones.getReporteNoFTP(rpt, Nothing, "", Constantes.FORMATO_PDF, tbl)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        buscar()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardar()
    End Sub
#End Region
#Region "Otros Eventos"
    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
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
    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        anular()
    End Sub
#End Region
End Class