Public Class Form_TipoDocumento
    Private codigoDocumento As String

    Private Sub btnuevo_Click(sender As Object, e As EventArgs)
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, Nothing, btbuscar)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
    End Sub

    Private Sub Form_TipoDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.posLoadForm(Me, ToolStrip1, Nothing, btbuscar)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(Nothing)

        General.buscarElemento(Consultas.DOCUMENTOS_CONTABLES_BUSCAR,
                               params,
                               AddressOf cargarDocumento,
                               TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
                               True, 0, True)
    End Sub

    Public Sub cargarDocumento(ByVal pCodigo As String)
        Dim drDocumento As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)

        drDocumento = General.cargarItem(Consultas.DOCUMENTO_CONTABLE_CARGAR, params)
        codigoDocumento = drDocumento.Item(0)
        txtSigla.Text = drDocumento.Item(1).ToString
        txtDescripcion.Text = drDocumento.Item(2).ToString

        General.posBuscarForm(Me, ToolStrip1, Nothing, btbuscar, bteditar, btanular)

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click

        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim documento = crearDocumentoContable()
            guardarDocumento(documento)
            General.posGuardarForm(Me, ToolStrip1, Nothing, btbuscar, bteditar, btanular)
        End If

    End Sub

    Public Sub guardarDocumento(objDocumentoContable As DocumentoContable)
        Dim documentoBLL As New DocumentoContableBLL

        Try
            documentoBLL.guardarDocumentoContable(objDocumentoContable, SesionActual.idUsuario)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Function validarFormulario()

        If String.IsNullOrEmpty(txtSigla.Text) Then
            MsgBox("Favor ingresar las sigla del documento", MsgBoxStyle.Exclamation)
        ElseIf String.IsNullOrEmpty(txtDescripcion.Text) Then
            MsgBox("Favor ingresar la descripcion del documento", MsgBoxStyle.Exclamation)
        Else
            Return True
        End If
        Return False

    End Function


    Private Function crearDocumentoContable() As DocumentoContable
        Dim documento As New DocumentoContable()

        documento.codigo = codigoDocumento
        documento.sigla = txtSigla.Text
        documento.descripcion = txtDescripcion.Text

        Return documento

    End Function

    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)

                params.Add(txtSigla.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.TIPO_DOCUMENTO_CONTABLE_ANULAR, params)
                General.posAnularForm(Me, ToolStrip1, Nothing, btbuscar)

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class