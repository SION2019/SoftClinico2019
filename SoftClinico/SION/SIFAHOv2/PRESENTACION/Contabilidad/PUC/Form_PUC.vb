Public Class Form_PUC

    Dim objPucBLL As New PucBLL
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        txtDescripcion.Focus()
        btCuentas.Enabled = False
        btRetencionIVA.Enabled = False
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(Consultas.BUSQUEDA_PUC,
                               Nothing,
                               AddressOf cargarPUC,
                               TitulosForm.BUSQUEDA_PUC,
                               False, 0, True)

    End Sub

    Public Sub cargarPUC(ByVal pCodigo As String)
        Dim drPUC As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drPUC = General.cargarItem(Consultas.PUC_CARGAR, params)

        If drPUC IsNot Nothing Then
            txtCodigo.Text = pCodigo
            numAno.Text = drPUC.Item(0)
            txtDescripcion.Text = drPUC.Item(1)
            chkActivo.Checked = drPUC.Item(2)
        End If

        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        btCuentas.Enabled = True
        btRetencionIVA.Enabled = True

    End Sub


    Public Sub cargarPUC(ByVal codigoPUC As String,
                         ByVal anoPUC As String,
                         ByVal descripcionPUC As String,
                         ByVal activoPUC As Boolean)

        txtCodigo.Text = codigoPUC
        txtDescripcion.Text = descripcionPUC
        numAno.Text = anoPUC
        chkActivo.Checked = activoPUC

        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        btCuentas.Enabled = True
        btRetencionIVA.Enabled = True
    End Sub

    Private Sub Form_PUC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Configura controles iniciales
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objPUC = crearPUC()
            guardarPUC(objPUC)
        End If

    End Sub

    Public Function crearPUC() As Puc
        Dim objPUC As New Puc

        objPUC.codigo = txtCodigo.Text
        objPUC.ano = numAno.Value
        objPUC.descripcion = txtDescripcion.Text
        objPUC.activo = chkActivo.Checked

        Return objPUC

    End Function

    Public Sub guardarPUC(objPUC As Puc)
        Dim codigoPUC As String = Nothing

        Try
            objPucBLL.guardarPUC(objPUC, SesionActual.idUsuario)

            'Si es un PUC nuevo
            If codigoPUC <> Nothing Then
                txtCodigo.Text = codigoPUC
            End If

            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btCuentas.Enabled = True
            btRetencionIVA.Enabled = True

            txtCodigo.Text = objPUC.codigo
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Function validarFormulario()

        If String.IsNullOrEmpty(txtDescripcion.Text) Then
            MsgBox("Favor digitar la descripción", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtDescripcion.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btCuentas_Click(sender As Object, e As EventArgs) Handles btCuentas.Click
        Dim formCuentaPUC As New Form_CuentasPUC
        General.cargarForm(formCuentaPUC)

        formCuentaPUC.cargarInfoPUC(txtCodigo.Text, numAno.Value, txtDescripcion.Text)

    End Sub

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
            If chkActivo.Checked Then
                MsgBox("No se puede anular el PUC activo. Escoja otro como activo antes de continuar .", MsgBoxStyle.Critical)
                Return
            End If
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add(SesionActual.idUsuario)

                General.ejecutarSQL(Consultas.ANULAR_PUC, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)

                btCuentas.Enabled = False
                btRetencionIVA.Enabled = False

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btRetencionIVA_Click(sender As Object, e As EventArgs) Handles btRetencionIVA.Click
        Form_RetencionIVA.MdiParent = FormPrincipal
        General.cargarForm(Form_RetencionIVA)

        Form_RetencionIVA.cargarInfoPUC(txtCodigo.Text,
                                       txtDescripcion.Text)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormBalanceGeneral.MdiParent = FormPrincipal
        General.cargarForm(FormBalanceGeneral)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        FormPYG.MdiParent = FormPrincipal
        General.cargarForm(FormPYG)
    End Sub
End Class