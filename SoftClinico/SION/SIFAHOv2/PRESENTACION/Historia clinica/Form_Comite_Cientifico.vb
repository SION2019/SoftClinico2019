Imports System.Threading
Public Class Form_Comite_Cientifico
    Dim reporteSegundoPlano As Thread
    Dim reporte As New ftp_reportes
    Dim activoAM, activoAF As Boolean
    Dim objComite As New ComiteCTC
    Private codigo As String
    Property modulo As String = Nothing
    Property pem As FormPEM
    Dim reporteParams As New ReporteParams
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click

        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_QUIMICO_FARMACEUTICO)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(ConsultasAmbu.CARGO_AM_BUSCAR, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objComite.usuarioReal = tbl(0)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(TabControl1)
        General.limpiarControles(Me)

        codigo = String.Empty
        dtfecha.Enabled = True
        objComite.dtMedicamento.Rows.Add()
        btbuscarPaciente.Enabled = True
        btguardar.Enabled = True
        btcancelar.Enabled = True

    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            codigo = String.Empty
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(TabControl1)

            If objComite.dtdiag.Rows.Count = 0 Then
                llenarDiagnoticos(txtregistro.Text)
            End If

            dtfecha.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True

        End If
    End Sub
    Private Sub dgvMiembros_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvMiembros.RowPostPaint
        Using Pinceles As New SolidBrush(dgvMiembros.RowHeadersDefaultCellStyle.ForeColor)
            Dim nombre As String
            nombre = objComite.dtAsistentes.Rows(e.RowIndex).Item("Cargo")
            e.Graphics.DrawString(nombre,
                                  dgvMiembros.Rows(e.RowIndex).Cells(0).InheritedStyle.Font,
                                  Pinceles, e.RowBounds.Location.X + 14,
                                  e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Function ValidarGuardar() As Boolean
        Dim resultado As Boolean
        If txtidentificacion.Text = String.Empty Then
            MsgBox("¡ Por favor seleccione el paciente!", MsgBoxStyle.Exclamation)
            txtidentificacion.Focus()
        ElseIf IsDBNull(objComite.dtAsistentes.Rows(0).Item("ID_Empleado")) Then
            MsgBox("¡ Por favor seleccione el presidente del comite!", MsgBoxStyle.Exclamation)
            dgvMiembros.Rows(0).Cells("dgcedula").Selected = True
        ElseIf IsDBNull(objComite.dtAsistentes.Rows(1).Item("ID_Empleado")) Then
            MsgBox("¡ Por favor seleccione el secretario del comite!", MsgBoxStyle.Exclamation)
            dgvMiembros.Rows(1).Cells("dgcedula").Selected = True
        ElseIf IsDBNull(objComite.dtAsistentes.Rows(2).Item("ID_Empleado")) Then
            MsgBox("¡ Por favor seleccione el gerente del comite!", MsgBoxStyle.Exclamation)
            dgvMiembros.Rows(2).Cells("dgcedula").Selected = True
        ElseIf IsDBNull(objComite.dtAsistentes.Rows(3).Item("ID_Empleado")) Then
            MsgBox("¡ Por favor seleccione el jefe de enfermeria del comite!", MsgBoxStyle.Exclamation)
            dgvMiembros.Rows(3).Cells("dgcedula").Selected = True
        ElseIf IsDBNull(objComite.dtAsistentes.Rows(4).Item("ID_Empleado")) Then
            MsgBox("¡ Por favor seleccione el medico general del comite!", MsgBoxStyle.Exclamation)
            dgvMiembros.Rows(4).Cells("dgcedula").Selected = True
        Else
            resultado = True
        End If
        Return resultado
    End Function
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        General.buscarElemento(objComite.sqlBuscarRegistro,
                               params,
                               AddressOf cargarCtc,
                               TitulosForm.BUSQUEDA_CTC,
                               True)
    End Sub
    Private Sub cargarCtc(pCodigo)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(0) '--------------Representa una bandera en el procedimiento sql
        Try
            drFila = General.cargarItem(objComite.sqlCargarRegistro, params)
            objComite.dtMedicamento.Clear()
            objComite.dtMedicamento.Rows.Add()
            codigo = pCodigo
            objComite.codigo = codigo
            txtregistro.Text = drFila.Item("N_Registro")
            objComite.nRegistro = drFila.Item("N_Registro")
            txtidentificacion.Text = drFila.Item("Identi_Paciente")
            txtfechaingreso.Text = Format(CDate(drFila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = drFila.Item("Paciente").ToString
            txtsexo.Text = drFila.Item("Descripcion_Genero").ToString
            txtedad.Text = drFila.Item("Edad").ToString
            txtcodigocontrato.Text = drFila.Item("Codigo_Contrato").ToString
            txtcontrato.Text = drFila.Item("Contrato").ToString
            lblentorno.Text = drFila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = drFila.Item("Cama").ToString
            Txtdescripcion.Text = drFila.Item("Observaciones")
            dtfecha.Text = Format(drFila.Item("Fecha_ctc"), Constantes.FORMATO_FECHA_HORA_GEN)
            objComite.dtMedicamento.Rows(0).Item("Codigo") = drFila.Item("Codigo_Interno")
            objComite.dtMedicamento.Rows(0).Item("Medicamento") = drFila.Item("Descripcion")
            objComite.dtMedicamento.Rows(0).Item("dosis") = drFila.Item("Dosis")
            objComite.dtMedicamento.Rows(0).Item("cant") = drFila.Item("cant")
            objComite.dtMedicamento.Rows(0).Item("dias") = drFila.Item("dias")
            Txtencabezado.Text = drFila.Item("Encabezado")
            Txtdecision.Text = drFila.Item("Decision")
            objComite.Codigo_PEM = drFila.Item("Codigo_Pem").ToString
            objComite.Codigo_Solic = drFila.Item("Codigo_Solic").ToString

            params.Clear()
            params.Add(pCodigo)
            params.Add(1) '--------------Representa una bandera en el procedimiento sql
            General.llenarTabla(objComite.sqlCargarRegistro, params, objComite.dtdiag)
            dgvdiag.DataSource = objComite.dtdiag


            params.Clear()
            params.Add(pCodigo)
            params.Add(2) '--------------Representa una bandera en el procedimiento sql
            General.llenarTabla(objComite.sqlCargarRegistro, params, objComite.dtAsistentes)
            dgvMiembros.DataSource = objComite.dtAsistentes

            objComite.banderaGuardar = True

            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btimprimir.Enabled = True

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If ValidarGuardar() = True Then
            guardarCtc()
        End If
    End Sub
    Private Sub guardarCtc()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjeto()
                objComite.guardarRegistro()
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                codigo = objComite.codigo
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                If Not IsNothing(pem) Then
                    pem.cargarEncabezadoPEMS()
                End If
                ' guardarSegundoPlano()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub Form_Ctc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modulo = If(IsNothing(modulo), Tag.modulo, modulo)
        objComite = GeneralHC.fabricaHC.crear(Constantes.CODIGO_COMITE & modulo)
        Label1.Text = objComite.titulo
        validarDgvDiag()
        validarDgMed()
        validarDgEmpl()
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub valoresIniciales()
        objComite.idEmpresa = SesionActual.idEmpresa
        objComite.codigoEp = SesionActual.codigoEP
        objComite.usuario = SesionActual.idUsuario
        objComite.usuarioReal = SesionActual.idUsuario
    End Sub
    Private Sub validarDgvDiag()
        With dgvdiag
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo"
            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"
        End With
        dgvdiag.DataSource = objComite.dtdiag
        dgvdiag.AutoGenerateColumns = False
    End Sub
    Private Sub validarDgMed()
        With dgvMedicamento
            .ReadOnly = False
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo"
            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Medicamento"
            .Columns.Item(1).ReadOnly = True
            .Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(2).DataPropertyName = "dosis"
            .Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(3).DataPropertyName = "cant"
            .Columns.Item(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(4).DataPropertyName = "dias"
        End With
        dgvMedicamento.DataSource = objComite.dtMedicamento
        dgvMedicamento.AutoGenerateColumns = False
    End Sub
    Private Sub validarDgEmpl()
        With dgvMiembros
            .Columns.Item("dgindice").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgindice").DataPropertyName = "Indice"
            .Columns.Item("dgnombreCargo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgnombreCargo").DataPropertyName = "Cargo"
            .Columns.Item("dgid_Empleado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgid_Empleado").DataPropertyName = "ID_Empleado"
            .Columns.Item("dgcedula").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcedula").DataPropertyName = "Cedula"
            .Columns.Item("dgnombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgnombre").DataPropertyName = "Nombre"
        End With
        dgvMiembros.DataSource = objComite.dtAsistentes
        dgvMiembros.AutoGenerateColumns = False
    End Sub
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)

        If Constantes.HC = modulo Then
            params.Add(pem.txtHistoriaClinica.Text)
        End If

        General.buscarElemento(objComite.sqlBuscarPaciente,
                               params,
                               AddressOf cargarPaciente,
                               TitulosForm.BUSQUEDA_PACIENTE,
                               True, 0, True)
    End Sub
    Private Sub cargarPaciente(pCodigo)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        objComite.Codigo_Solic = pCodigo
        params.Add(objComite.Codigo_Solic)

        Try
            drFila = General.cargarItem(objComite.sqlCargarPaciente, params)
            txtregistro.Text = drFila.Item("N_Registro")
            objComite.nRegistro = drFila.Item("N_Registro")
            txtidentificacion.Text = drFila.Item("Identi_Paciente")
            txtfechaingreso.Text = Format(CDate(drFila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = drFila.Item("Paciente").ToString
            txtsexo.Text = drFila.Item("Descripcion_Genero").ToString
            txtedad.Text = drFila.Item("Edad").ToString
            txtcodigocontrato.Text = drFila.Item("Codigo_Contrato").ToString
            txtcontrato.Text = drFila.Item("Contrato").ToString
            lblentorno.Text = drFila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = drFila.Item("Cama").ToString
            Txtdescripcion.Text = drFila.Item("Observaciones")
            dtfecha.Text = Format(drFila.Item("Fecha"), Constantes.FORMATO_FECHA_HORA_GEN)
            objComite.dtMedicamento.Rows(0).Item("Codigo") = drFila.Item("Codigo_Interno1")
            objComite.dtMedicamento.Rows(0).Item("Medicamento") = drFila.Item("Descripcion")
            objComite.dtMedicamento.Rows(0).Item("dosis") = drFila.Item("Dosis")
            objComite.dtMedicamento.Rows(0).Item("cant") = drFila.Item("cant")
            objComite.dtMedicamento.Rows(0).Item("dias") = drFila.Item("dias")
            Txtencabezado.Text = Replace(Constantes.ENCABEZADO, "$", SesionActual.nombreEmpresa)
            Txtdecision.Text = Constantes.DECISIONES
            llenarDescripciones()
            llenarDiagnoticos(txtregistro.Text)
            cargarUltimosAsistentes()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub llenarDiagnoticos(pcodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pcodigo)
        Try
            General.llenarTabla(objComite.sqlCargarDiagnostico, params, objComite.dtdiag)
            dgvdiag.DataSource = objComite.dtdiag
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Form_Informe_QX_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub llenarDescripciones()
        Try
            objComite.dtAsistentes.Clear()

            For i = 0 To 5
                objComite.dtAsistentes.Rows.Add(i)
            Next

            objComite.dtAsistentes.Rows(0).Item("Cargo") = Constantes.PRESIDENTE
            objComite.dtAsistentes.Rows(1).Item("Cargo") = Constantes.SECRETARIO
            objComite.dtAsistentes.Rows(2).Item("Cargo") = Constantes.GERENTE
            objComite.dtAsistentes.Rows(3).Item("Cargo") = Constantes.JEFE_ENFERMERIA
            objComite.dtAsistentes.Rows(4).Item("Cargo") = Constantes.MEDICO_GENERAL
            objComite.dtAsistentes.Rows(5).Item("Cargo") = Constantes.INVITADO
            dgvMiembros.Columns("dgindice").Visible = False
            dgvMiembros.Columns("dgnombreCargo").Visible = False
            dgvMiembros.Columns("dgid_Empleado").Visible = False

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub dgvMiembros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMiembros.CellDoubleClick
        If txtidentificacion.Text <> String.Empty _
            And btguardar.Enabled = True Then
            Dim params As New List(Of String)
            params.Add(miembroAsignar())
            params.Add(SesionActual.idEmpresa)
            General.buscarItem(Consultas.BUSQUEDA_BUSCAR_EMPLEADOS_COMITE,
                                             params,
                                             AddressOf cargarEmpleadoSeleccionado,
                                             TitulosForm.BUSQUEDA_EMPLEADO_HC, False)
        End If
    End Sub
    Public Sub cargarEmpleadoSeleccionado(contenedor As DataRow)
        Try
            objComite.dtAsistentes.Rows(dgvMiembros.CurrentCell.RowIndex).Item("ID_Empleado") = contenedor.Item("Id_empleado")
            objComite.dtAsistentes.Rows(dgvMiembros.CurrentCell.RowIndex).Item("Cedula") = contenedor.Item("Cedula")
            objComite.dtAsistentes.Rows(dgvMiembros.CurrentCell.RowIndex).Item("Nombre") = contenedor.Item("Empleado")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cargarObjeto()
        objComite.codigo = codigo
        objComite.Codigo_PEM = If(objComite.Codigo_PEM = String.Empty, Nothing, objComite.Codigo_PEM)
        objComite.Codigo_Solic = objComite.Codigo_Solic
        objComite.fechaRegistro = dtfecha.Value
        objComite.Encabezado = Txtencabezado.Text
        objComite.Decision = Txtdecision.Text
        objComite.usuario = SesionActual.idUsuario
        objComite.usuarioReal = If(objComite.usuarioReal = Nothing, SesionActual.idUsuario, objComite.usuarioReal)
        objComite.codigoEp = SesionActual.codigoEP
    End Sub

    Private Function miembroAsignar() As Integer
        Dim codigo As Integer
        Select Case dgvMiembros.CurrentCell.RowIndex
            Case 0  'Presidente (Medico especialista)
                codigo = Constantes.CARGO_MEDICO_ESPECIALISTA
            Case 1  'Secretario (Medico General)
                codigo = Constantes.CARGO_MEDICO_GENERAL_UCI
            Case 2  'Gerente (Gerente)
                codigo = Constantes.CARGO_GERENTE_GENERAL
            Case 3  'Jefe de enfermeria
                codigo = Constantes.CARGO_JEFE_DE_ENFERMERIA
            Case 4  ' medico General
                codigo = Constantes.CARGO_MEDICO_GENERAL_UCI
            Case 5  'Invitado (Todos)
                codigo = Constantes.CARGO_GERENTE_GENERAL
        End Select
        Return codigo
    End Function

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objComite.anularCTC(reporteParams.activoAM, reporteParams.activoAF)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim ruta, nombreArchivo As String
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            nombreArchivo = objComite.area & ConstantesHC.NOMBRE_PDF_SEPARADOR & objComite.codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            objComite.imprimir()
            'Cambia de estado a impreso
            'objComite.codigo
            Dim params As New List(Of String)
            params.Add(objComite.codigo)
            Try
                General.ejecutarSQL(Consultas.CTC_CAMBIAR_VISTO, params)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub cargarUltimosAsistentes()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.CARGAR_ULTIMOS_ASISTENTES, params, objComite.dtAsistentes)
        dgvMiembros.DataSource = objComite.dtAsistentes
    End Sub
End Class