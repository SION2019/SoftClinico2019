Imports System.IO
Imports System.Data.SqlClient

Public Class Form_Empresas
    Dim idrepresentante As Integer
    Dim dtImagen As New DataTable
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Plinea, Pcualidad, Pgrupo, Pprese, Pviaadmin As String
    Dim arrFile() As Byte
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btOpcionResolucion_Click(sender As Object, e As EventArgs) Handles btOpcionResolucion.Click
        If Textcodigo.Text = "" Then
            MsgBox("Por favor seleccione una empresa.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim objResolucion As New Form_Resoluciones
        objResolucion.MdiParent = FormPrincipal
        objResolucion.Show()
        objResolucion.btnuevo_Click(sender, e)
        objResolucion.btbuscarempresa.Enabled = False
        objResolucion.Textidempresa.Text = Textcodigo.Text
        objResolucion.Textnit.Text = Textnit.Text
        objResolucion.Textrazonsocial.Text = textrazonsocial.Text
        objResolucion.Textresolucion.Focus()
        If objResolucion.WindowState = FormWindowState.Minimized Then
            objResolucion.WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub enlazarTabla()
        Dim col1, col2, col3, col4 As New DataColumn
        col1.ColumnName = "Id_Documento"
        col1.DataType = Type.GetType("System.String")
        col1.DefaultValue = ""
        dtImagen.Columns.Add(col1)

        col2.ColumnName = "Descripcion"
        col2.DataType = Type.GetType("System.String")
        col2.DefaultValue = ""
        dtImagen.Columns.Add(col2)

        col3.ColumnName = "Imagen"
        col3.DataType = Type.GetType("System.Byte[]")
        dtImagen.Columns.Add(col3)

        col4.ColumnName = "Fecha"
        col4.DataType = Type.GetType("System.DateTime")
        dtImagen.Columns.Add(col4)

        With dgvdocumentos

            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Id_Documento"

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"

            .Columns.Item(2).DataPropertyName = "Imagen"

            .Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(3).DataPropertyName = "Fecha"
        End With

        dgvdocumentos.AutoGenerateColumns = False
        dgvdocumentos.DataSource = dtImagen
        dgvdocumentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvdocumentos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub Form_empresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        enlazarTabla()
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        Combopais.SelectedIndex = 0
        fechainicio.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        fechavence.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        General.deshabilitarControles(Me)
        btlogo.Enabled = False
        btbuscarrepresentante.Enabled = False
        fechavence.Value = fechainicio.Value.AddYears(2)
    End Sub
    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged

        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub
    Private Sub btlogo_Click(sender As Object, e As EventArgs) Handles btlogo.Click
        General.subirimagen(picLogoPrincipal, Openimagen,, picLogoFactura)
    End Sub
    Private Sub dgvdocumentos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvdocumentos.DataError

    End Sub
    Private Sub form_Empresas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub btbuscarrepresentante_Click(sender As Object, e As EventArgs) Handles btbuscarrepresentante.Click

        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consultas.BUSQUEDA_REPRESENTANTE_LEGAL,
                                   Nothing,
                                   AddressOf cargarRepresentante,
                                   TitulosForm.BUSQUEDA_TERCERO,
                                   True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarRepresentante(pCodigo As String)
        Dim drRepresentante As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drRepresentante = General.cargarItem("[PROC_REPRESENTANTE_LEGAL_CARGAR]", params)

        idrepresentante = pCodigo
        Textidrepresentante.Text = drRepresentante.Item(0).ToString()
        Textnombrerepresentante.Text = drRepresentante.Item(1).ToString()
        Textresolucion.Focus()

    End Sub

    Private Sub btOpcionTercero_Click(sender As Object, e As EventArgs) Handles btOpcionTercero.Click
        If Textcodigo.Text = "" AndAlso SesionActual.idUsuario <> -1 Then
            MsgBox("Por favor seleccione una empresa.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim objTercero As New FormTercero
        General.cargarForm(objTercero)
    End Sub
    Private Sub Textnit_TextChanged(sender As Object, e As EventArgs) Handles Textnit.TextChanged
        Dim DV As New DigitoVerificacion
        Dim n As Integer
        n = DV.CalculaNit(Textnit.Text)
        Textdv.Text = CType(n, String)
        If Textnit.Text = Nothing Then
            Textdv.Text = Nothing
        End If
    End Sub
    Private Sub asignarImagenDatagrid()
        For indice = 0 To dtImagen.Rows.Count - 1
            If dtImagen.Rows(indice).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Or IsDBNull(dtImagen.Rows(indice).Item("Extension_Doc")) Then
                dgvdocumentos.Rows(indice).Cells(2).Value = My.Resources.picpdf
            End If
        Next
    End Sub

    Private Sub cargarDocumentos()
        Dim params As New List(Of String)
        params.Add(Textcodigo.Text)
        General.llenarTabla(Consultas.CARGAR_DOCUMENTOS_EMPRESA, params, dtImagen)
        asignarImagenDatagrid()
    End Sub
    Private Sub dgvdocumentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellContentClick
        If dgvdocumentos.Rows.Count <> 0 Then
            If e.ColumnIndex <> 4 Then
                Dim bites() As Byte = dgvdocumentos.SelectedCells(2).Value
                Dim ms As New MemoryStream(bites)
                With picturedocu
                    If dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Then
                        .Image = My.Resources.picpdf
                    Else
                        .Image = Image.FromStream(ms)
                        .SizeMode = PictureBoxSizeMode.Zoom
                        .BorderStyle = BorderStyle.None
                    End If
                End With
            End If
        End If
    End Sub
    Private Sub dgvdocumentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellDoubleClick
        Dim respuesta As Boolean
        If e.ColumnIndex = 4 Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ELIMINAR_DOCUMENTO_EMPRESA & "
            '" & dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(0).Value & "'")
                If respuesta = True Then
                    cargarDocumentos()
                    picturedocu.Image = Nothing
                    General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPRESA_LISTAR & "'" & Constantes.DOCUMENTO_EMPRESA & "','" &
                                     Textcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
                End If
            End If
        Else
            verArchivo()
        End If
    End Sub
    Private Sub verArchivo()
        Dim params As New List(Of String)
        Dim dt As New DataTable
        params.Add(dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(0).Value.ToString())
        Dim tempfileurl As String = System.IO.Path.GetTempPath + DateTime.Now.ToString("yyyyMMdd_HHmmss")
        General.llenarTabla(Consultas.DOCUMENTO_EMPRESA_CARGAR, params, dt)
        If dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Or IsDBNull(dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc")) Then
            tempfileurl += "-tempdocu" + Constantes.FORMATO_PDF
            My.Computer.FileSystem.WriteAllBytes(tempfileurl, dt.Rows(0).Item("Imagen"), True)
            Process.Start("file://" + tempfileurl)
        Else
            tempfileurl += "-tempimg.png"
            picturedocu.Image.Save(tempfileurl, Imaging.ImageFormat.Png)
            Process.Start("file://" + tempfileurl)
        End If
    End Sub
    Private Sub Textidrepresentante_TextChanged(sender As Object, e As EventArgs) Handles Textidrepresentante.TextChanged
        Dim DV As New DigitoVerificacion
        Dim n As Integer

        n = DV.CalculaNit(Textidrepresentante.Text)
        Textdvrepresentante.Text = CType(n, String)
        If Textidrepresentante.Text = Nothing Then
            Textdvrepresentante.Text = Nothing
        End If
    End Sub
    Private Sub Textnit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Textnit.KeyPress, Texttelefono.KeyPress, Textcelular.KeyPress, Textconseactual.KeyPress, Textrangoini.KeyPress, Textrangofin.KeyPress, Textresolucion.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then

            If String.IsNullOrEmpty(Textcodigo.Text) Then

                MsgBox("Solo se puede agregar documentos a una empresa previamente guardada", 64, "Informacion")
                combodescripciondocu.Enabled = False
                TabControl1.SelectedIndex = 0

            Else
                Cursor = Cursors.WaitCursor
                cargarDocumentos()
                Cursor = Cursors.Default
                General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPRESA_LISTAR & "'" & Constantes.DOCUMENTO_EMPRESA & "'," &
                                     Textcodigo.Text & "", "Descripción", "Código", combodescripciondocu)
                btexaminar.Enabled = True
                combodescripciondocu.Visible = False
                Labeltipodoc.Visible = False
            End If

        End If

    End Sub
    Private Sub btdocumentos_Click(sender As Object, e As EventArgs) Handles btOpcionDocumentos.Click
        If SesionActual.idUsuario <> -1 AndAlso Textcodigo.Text = "" Then
            MsgBox("Por favor seleccione una empresa.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim objTipoDocumento As New Form_Tipo_Documentos
        General.cargarForm(objTipoDocumento)
        objTipoDocumento.rbempledo.Visible = False
        objTipoDocumento.rbempresa.Checked = True
        objTipoDocumento.rbpaciente.Visible = False
        objTipoDocumento.Comboservicio.Visible = False
        objTipoDocumento.Labelarea.Visible = False
        objTipoDocumento.Focus()
        objTipoDocumento.cargarDatos()
    End Sub

    Private Sub btguardarimagen_Click(sender As Object, e As EventArgs) Handles btguardarimagen.Click
        If combodescripciondocu.SelectedIndex < 1 Then
            MsgBox("Por favor seleccione el tipo de documento que desea subir", MsgBoxStyle.Exclamation)
            combodescripciondocu.Focus()
        Else
            guardarDocumentos()
        End If
    End Sub
    Private Sub guardarDocumentos()
        Dim objAdmisionBLL As New AdmisionBLL
        Try
            objAdmisionBLL.guardarDocumentos(crearDocumentos, Consultas.GUARDAR_DOCUMENTOS_EMPRESA)
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            General.llenarTablaYdgv(Consultas.CARGAR_DOCUMENTOS_EMPRESA & CInt(Textcodigo.Text), dtImagen)
            asignarImagenDatagrid()
            General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPRESA_LISTAR & "'" & Constantes.DOCUMENTO_EMPRESA & "',
                '" & Textcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
            btguardarimagen.Enabled = False
            combodescripciondocu.Visible = False
            Labeltipodoc.Visible = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub Textsigla_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Textsigla.KeyPress, Textprefijo.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            Textidrepresentante.ReadOnly = True
            Textdvrepresentante.ReadOnly = True
            Textnombrerepresentante.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub Textrangofin_Leave(sender As Object, e As EventArgs) Handles Textrangofin.Leave
        Dim valorInicio, valorFinal As Integer
        If Textrangofin.Text <> "" Then
            valorInicio = Textrangoini.Text
            valorFinal = Textrangofin.Text
            If valorFinal < valorInicio Then
                MsgBox("El rango final no puede ser menor al inicial", MsgBoxStyle.Information)
                Textrangofin.Focus()
            End If
        End If
    End Sub
    Private Sub Textconseactual_Leave(sender As Object, e As EventArgs) Handles Textconseactual.Leave
        Dim valorInicio, valorFinal, valorActual As Integer
        If Textconseactual.Text <> "" Then
            valorInicio = Textrangoini.Text
            valorFinal = Textrangofin.Text
            valorActual = Textconseactual.Text
            If valorActual < valorInicio Or valorActual > valorFinal Then
                MsgBox("El valor del consecutivo actual debe estar entre el rango inicial y el final", MsgBoxStyle.Information)
                Textconseactual.Focus()
            End If
        End If
    End Sub
    Private Function validarInformacion()
        If (Textnit.Text = "") Then
            MsgBox("¡ Por favor digite el nit de la Empresa!", MsgBoxStyle.Exclamation)
            Textnit.Focus()
            Return False
        ElseIf (Textdv.Text = "") Then
            MsgBox("¡ Por favor digite el digito de verificacion de la empresa!", MsgBoxStyle.Exclamation)
            Textdv.Focus()
            Return False
        ElseIf (textrazonsocial.Text = Nothing) Then
            MsgBox("¡ Por favor digite la razon social de la empresa!", MsgBoxStyle.Exclamation)
            textrazonsocial.Focus()
            Return False
        ElseIf (Textdireccion.Text = "") Then
            MsgBox("¡ Por favor digite la direccion de la empresa!", MsgBoxStyle.Exclamation)
            Textdireccion.Focus()
            Return False
        ElseIf (Texttelefono.Text = "") Then
            MsgBox("¡ Por favor digite el numero de telefono de la empresa!", MsgBoxStyle.Exclamation)
            Texttelefono.Focus()
            Return False
        ElseIf (Textemail.Text = "") Then
            MsgBox("¡ Por favor digite la direccion de correo electronico de la empresa!", MsgBoxStyle.Exclamation)
            Textemail.Focus()
            Return False
        ElseIf (Textportalweb.Text = "") Then
            MsgBox("¡  Por favor digite la direccion del portal web de la empresa!", MsgBoxStyle.Exclamation)
            Textportalweb.Focus()
            Return False
        ElseIf (Combopais.SelectedIndex < 1) Then
            MsgBox("¡  Por favor digite el pais donde se encuentra la empresa!", MsgBoxStyle.Exclamation)
            Combopais.Focus()
            Return False
        ElseIf (Combodepartamento.SelectedIndex < 1) Then
            MsgBox("¡  Por favor escoja el departamento donde se encuentra de la empresa!", MsgBoxStyle.Exclamation)
            Combodepartamento.Focus()
            Return False
        ElseIf (Combociudad.SelectedIndex < 1) Then
            MsgBox("¡  Por favor escoja la ciudad donde se encuentra de la empresa!", MsgBoxStyle.Exclamation)
            Combociudad.Focus()
            Return False
        ElseIf (Textsigla.Text = "") Then
            MsgBox("¡  Por favor digite la sigla de la empresa!", MsgBoxStyle.Exclamation)
            Textsigla.Focus()
            Return False
        ElseIf (Textidrepresentante.Text = "") Then
            MsgBox("¡ Por favor seleccione el Representante Legal de la empresa!", MsgBoxStyle.Exclamation)
            btbuscarrepresentante.Focus()
            Return False
        ElseIf (Textresolucion.Text = "") Then
            MsgBox("¡ Por favor digite el numero de la resolucion!", MsgBoxStyle.Exclamation)
            Textresolucion.Focus()
            Return False
        ElseIf (Textrangoini.Text = "") Then
            MsgBox("¡ Por favor digite el consecutivo de inicio de la resolucion!", MsgBoxStyle.Exclamation)
            Textrangoini.Focus()
            Return False
        ElseIf (Textrangofin.Text = "") Then
            MsgBox("¡ Por favor digite el consecutivo final de la resolucion!", MsgBoxStyle.Exclamation)
            Textrangofin.Focus()
            Return False
        ElseIf (Textconseactual.Text = "") Then
            MsgBox("¡ Por favor digite consecutivo actual de la resolucion!", MsgBoxStyle.Exclamation)
            Textconseactual.Focus()
            Return False
        ElseIf CDate(fechainicio.Value).date >= CDate(fechavence.Value).date Then
            MsgBox("La fecha de vencimiento no puede ser menor o igual a la fecha de inicio!", MsgBoxStyle.Exclamation)
            fechavence.Focus()
            Return False
        ElseIf Format(CDate(fechavence.Value) <= Date.Now) Then
            MsgBox("La fecha de vencimiento no puede ser menor o igual a la fecha actual", MsgBoxStyle.Exclamation)
            Return False
        ElseIf (Textencabezado.Text = "") Then
            MsgBox("¡ Por favor digite el encabezado de la factura de la empresa!", MsgBoxStyle.Exclamation)
            Textencabezado.Focus()
            Return False
        ElseIf (textpiepagina.Text = "") Then
            MsgBox("¡ Por favor digite el pie de pagina de la factura de la empresa!", MsgBoxStyle.Exclamation)
            textpiepagina.Focus()
            Return False
        ElseIf CInt(Textrangofin.Text) < CInt(Textrangoini.Text) Then
            MsgBox("El rango final no puede ser menor al inicial", MsgBoxStyle.Exclamation)
            Textrangofin.Focus()
            Return False
        ElseIf CInt(Textconseactual.Text) < CInt(Textrangoini.Text) Or CInt(Textconseactual.Text) > CInt(Textrangofin.Text) Then
            MsgBox("El valor del consecutivo actual debe estar entre el rango inicial y el final", MsgBoxStyle.Exclamation)
            Textconseactual.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub fechainicio_ValueChanged(sender As Object, e As EventArgs) Handles fechainicio.ValueChanged
        fechavence.Value = fechainicio.Value.AddYears(2)
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarEmpresa()
        End If
    End Sub

    Private Sub btexaminar_Click(sender As Object, e As EventArgs) Handles btexaminar.Click

        General.subirimagen(picturedocu, Openimagen)

        If IsNothing(picturedocu.Image) Then
            btguardarimagen.Enabled = False
            combodescripciondocu.Visible = False
            Labeltipodoc.Visible = False
            combodescripciondocu.Enabled = False
        Else
            btguardarimagen.Enabled = True
            combodescripciondocu.Visible = True
            Labeltipodoc.Visible = True
            combodescripciondocu.Enabled = True
            Using bmp As New Bitmap(picturedocu.Image), ms As New MemoryStream()
                bmp.Save(ms, picturedocu.Image.RawFormat)
                arrFile = ms.GetBuffer
            End Using
            combodescripciondocu.Focus()
        End If

    End Sub

    Private Sub Textnit_Leave(sender As Object, e As EventArgs) Handles Textnit.Leave
        cargarNitEmpresa(Textnit.Text)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                btlogo.Enabled = True
                Textidrepresentante.ReadOnly = True
                Textdvrepresentante.ReadOnly = True
                Textnombrerepresentante.ReadOnly = True
                btbuscarrepresentante.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub logo2_Click(sender As Object, e As EventArgs)
        General.verImagen(logo2)
    End Sub

    Private Sub btlogo2_Click(sender As Object, e As EventArgs)
        General.subirimagen(logo2, Openimagen)
    End Sub

    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub logo2_Click_1(sender As Object, e As EventArgs) Handles logo2.Click
        General.verImagen(logo2)
    End Sub

    Private Sub btlogo2_Click_1(sender As Object, e As EventArgs) Handles btlogo2.Click
        General.subirimagen(logo2, Openimagen,, logo2)
    End Sub

    Private Sub picLogoPrincipal_DoubleClick(sender As Object, e As EventArgs) Handles picLogoPrincipal.DoubleClick
        If btguardar.Enabled AndAlso Not IsNothing(picLogoPrincipal.Image) AndAlso
           MsgBox("¿Desea redimencionar esta imagen?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            General.redimencionarImagen(picLogoPrincipal, picLogoFactura)
        End If
    End Sub

    Private Sub guardarEmpresa()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                Dim objEmpresaBLL As New EmpresaBLL
                Textcodigo.Text = objEmpresaBLL.guardarEmpresa(crearEmpresa())

                MsgBox(Mensajes.GUARDADO & " :  " & textrazonsocial.Text, MsgBoxStyle.Information)

                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btOpcionResolucion.Enabled = True
                btOpcionDocumentos.Enabled = True
                btOpcionPuntos.Enabled = True
                btlogo.Enabled = False
                btbuscarrepresentante.Enabled = False
                fprincipal.cargarImagenEmpresa(SesionActual.idEmpresa)
                If SesionActual.idUsuario = -1 Then
                    FormPrincipal.Dispose()
                    InicioSesion.Textusuario.Text = "AdminS"
                    InicioSesion.textusuario_Leave(Nothing, Nothing)
                    InicioSesion.Show()
                    InicioSesion.Textcontraseña.Focus()
                    Dispose()
                End If
                arrFile = Nothing
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_EMPRESA & "'" & CInt(Textcodigo.Text) & "'," & SesionActual.idUsuario)
                If respuesta = True Then
                    General.posAnularForm(Me, ToolStrip1, btbuscar, btnuevo)
                End If
            End If
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            General.buscarElemento(Consultas.BUSQUEDA_EMPRESA,
                                   params,
                                   AddressOf cargarEmpresa,
                                   TitulosForm.BUSQUEDA_EMPRESA,
                                   True,
                                   True,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarNitEmpresa(nit As String)
        Dim params As New List(Of String)
        params.Add(Textnit.Text)
        Dim dtNit As New DataTable
        General.llenarTabla(Consultas.CARGAR_NIT_EMPRESA, params, dtNit)
        If dtNit.Rows.Count > 0 Then
            MsgBox("Ya existe una empresa con este nit", MsgBoxStyle.Information)
            Textcodigo.Text = dtNit.Rows(0).Item(0)
            cargarEmpresa(Textcodigo.Text)
        End If
    End Sub

    Public Sub cargarEmpresa(pCodigo As String)
        Dim drEmpresa As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drEmpresa = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR, params)
        Textcodigo.Text = pCodigo
        Textdv.Text = drEmpresa.Item("DV").ToString
        Textnit.Text = drEmpresa.Item("NIT").ToString
        textrazonsocial.Text = drEmpresa.Item("Razon_social").ToString
        Textdireccion.Text = drEmpresa.Item("Direccion").ToString
        Texttelefono.Text = drEmpresa.Item("Telefono").ToString
        Textcelular.Text = drEmpresa.Item("Celular").ToString
        Combopais.SelectedValue = drEmpresa.Item("Codigo_Pais").ToString
        Combodepartamento.SelectedValue = drEmpresa.Item("Codigo_Departamento").ToString
        Combociudad.SelectedValue = drEmpresa.Item("Codigo_Municipio").ToString
        Textemail.Text = drEmpresa.Item("E_mail").ToString
        Textportalweb.Text = drEmpresa.Item("Portal_Web").ToString
        Textsigla.Text = drEmpresa.Item("Sigla").ToString
        Textencabezado.Text = drEmpresa.Item("Encabezado_Factura").ToString
        textpiepagina.Text = drEmpresa.Item("Pie_Factura").ToString
        idrepresentante = drEmpresa.Item("Id_Representante").ToString
        Textresolucion.Text = drEmpresa.Item("resolucion").ToString
        Textprefijo.Text = drEmpresa.Item("prefijo").ToString
        Textrangoini.Text = drEmpresa.Item("conse_inic").ToString
        Textconseactual.Text = drEmpresa.Item("conse_actual").ToString
        Textrangofin.Text = drEmpresa.Item("conse_fin").ToString
        fechainicio.Value = drEmpresa.Item("fecha_expedicion").ToString
        fechavence.Value = drEmpresa.Item("fecha_vencimiento").ToString
        Textidrepresentante.Text = drEmpresa.Item("Nit_Tercero").ToString
        Textnombrerepresentante.Text = drEmpresa.Item("Representante_Legal").ToString
        ckComercializadora.Checked = drEmpresa.Item("Valor").ToString
        If Not IsDBNull(drEmpresa.Item("Logo")) Then
            Dim bites() As Byte = drEmpresa.Item("Logo")
            Dim ms As New MemoryStream(bites)
            picLogoFactura.Image = Image.FromStream(ms)
            ms.Dispose()
            bites = Nothing
        Else
            picLogoFactura.Image = Nothing
        End If

        If Not IsDBNull(drEmpresa.Item("LogoPrincipal")) Then
            Dim bites() As Byte = drEmpresa.Item("LogoPrincipal")
            Dim ms As New MemoryStream(bites)
            picLogoPrincipal.Image = Image.FromStream(ms)
            ms.Dispose()
            bites = Nothing
        Else
            picLogoPrincipal.Image = Nothing
        End If

        General.deshabilitarControles(Me)
        General.habilitarBotones(Me.ToolStrip1)
        btOpcionDocumentos.Enabled = True
        btOpcionResolucion.Enabled = True
        btguardar.Enabled = False
        btcancelar.Enabled = False
        btOpcionPuntos.Enabled = True

    End Sub
    Private Sub btpuntos_Click_(sender As Object, e As EventArgs) Handles btOpcionPuntos.Click
        If Textcodigo.Text = "" Then
            MsgBox("Por favor seleccione una empresa.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim objPuntoServicio As New Punto_Servicio
        General.cargarForm(objPuntoServicio)
    End Sub
    Public Function crearEmpresa() As Empresa
        Dim objEmpresa As New Empresa
        If IsNothing(picLogoPrincipal.Image) Then
            picLogoPrincipal.Image = My.Resources.blanco
            picLogoFactura.Image = My.Resources.blanco
        End If
        Dim arrFilePrincipal() As Byte
        Using bmp As New Bitmap(picLogoPrincipal.Image), ms As New MemoryStream()
            bmp.Save(ms, picLogoPrincipal.Image.RawFormat)
            arrFilePrincipal = ms.GetBuffer
        End Using
        Dim arrFileFactura() As Byte
        Using bmp As New Bitmap(picLogoFactura.Image), ms As New MemoryStream()
            bmp.Save(ms, picLogoFactura.Image.RawFormat)
            arrFileFactura = ms.GetBuffer
        End Using
        objEmpresa.idEmpresa = Textcodigo.Text
        objEmpresa.nit = Textnit.Text
        objEmpresa.dv = Textdv.Text
        objEmpresa.razonSocial = textrazonsocial.Text
        objEmpresa.direccion = Textdireccion.Text
        objEmpresa.telefono = Texttelefono.Text
        objEmpresa.celular = Textcelular.Text
        objEmpresa.codPais = Combopais.SelectedValue
        objEmpresa.codDepartamento = Combodepartamento.SelectedValue
        objEmpresa.codMunicipio = Combociudad.SelectedValue
        objEmpresa.email = Textemail.Text
        objEmpresa.portalWeb = Textportalweb.Text
        objEmpresa.sigla = Textsigla.Text
        objEmpresa.encabezadoFactura = Textencabezado.Text
        objEmpresa.pieFactura = textpiepagina.Text
        objEmpresa.logoFactura = arrFileFactura
        objEmpresa.logoPrincipal = arrFilePrincipal
        objEmpresa.idRepresentante = idrepresentante
        objEmpresa.resolucion = Textresolucion.Text
        objEmpresa.prefijo = Textprefijo.Text
        objEmpresa.conseInic = Textrangoini.Text
        objEmpresa.conseActual = Textconseactual.Text
        objEmpresa.conseFin = Textrangofin.Text
        objEmpresa.fechaExpedicion = fechainicio.Value
        objEmpresa.fechaVencimiento = fechavence.Value
        objEmpresa.usuario = SesionActual.idUsuario
        objEmpresa.comercializadora = ckComercializadora.Checked

        Return objEmpresa
    End Function

    Public Function crearDocumentos() As Admision
        Dim objDocEmpresa As New Admision
        Dim ms As New MemoryStream
        picturedocu.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        arrFile = File.ReadAllBytes(Openimagen.FileName)
        objDocEmpresa.nRegistro = Textcodigo.Text
        objDocEmpresa.tipoDocumento = combodescripciondocu.SelectedValue
        objDocEmpresa.imagen = arrFile
        objDocEmpresa.extensionDoc = Path.GetExtension(Openimagen.FileName).ToLower()
        Return objDocEmpresa
    End Function
End Class