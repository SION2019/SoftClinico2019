Public Class Form_ValoracionNutricional
    Dim dtValoracion As New DataTable
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim codigoEvo As String
    Dim reporte As New ftp_reportes
    Dim modulo As String
    Private Sub Form_ValoracionNutricional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        establecerTabla()

        With dgvunion
            .Columns.Item("Codigo_CIE").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Codigo_CIE").DataPropertyName = "Codigo_CIE"
            .Columns.Item("Codigo_CIE").ReadOnly = True

            .Columns.Item("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Descripcion").DataPropertyName = "Descripcion"
            .Columns.Item("Descripcion").ReadOnly = True

        End With
        General.deshabilitarControles(Me)
        dgvunion.DataSource = dtValoracion

        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_NUTRICIONISTA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", Combonutri)

    End Sub

    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub

    Public Sub establecerTabla()
        Dim Col1, Col2 As New DataColumn

        Col1.ColumnName = "Codigo_CIE"
        Col1.DataType = Type.GetType("System.String")
        dtValoracion.Columns.Add(Col1)

        Col2.ColumnName = "Descripcion"
        Col2.DataType = Type.GetType("System.String")
        dtValoracion.Columns.Add(Col2)

        Col1 = Nothing : Col2 = Nothing
    End Sub

    Private Sub limpiar()
        fechavalor.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        PesoA.Clear()
        Talla.Clear()
        txtcodigo.Clear()
        pt.Clear()
        pe.Clear()
        te.Clear()
        diagN.Clear()
        prescD.Clear()
        AnamA.Clear()
        AlimP.Clear()
        CaloR.Clear()
        Prot.Clear()
        AlimR.Clear()
        Gras.Clear()
        CHO.Clear()
        Combonutri.SelectedValue = -1
        ExamL.Clear()
        IntoA.Clear()

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim param As New List(Of String)
            param.Add(txtregistro.Text)
            General.buscarElemento(Consultas.BUSCAR_VALORACION_NUTRICIONAL, param,
                                   AddressOf cargarRegistro,
                                   TitulosForm.BUSQUEDA_NUTRICIONAL, False, 0, True)

            If txtcodigo.Text <> "" Then
                bteditar.Enabled = True
                btanular.Enabled = True
                btcancelar.Enabled = False
                btnuevo.Enabled = True
                btimprimir.Enabled = True
                cargarDiagnosticos()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub cargarRegistro(codigo As Integer)
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.BUSCAR_VALORACION_NUTRICIONAL2 & codigo, dt)
        txtcodigo.Text = dt.Rows(0).Item("Codigo_Valoracion").ToString
        fechavalor.Text = dt.Rows(0).Item("Fecha_valoracion").ToString
        PesoA.Text = dt.Rows(0).Item("PesoA").ToString
        Talla.Text = dt.Rows(0).Item("Talla").ToString
        pt.Text = dt.Rows(0).Item("pt").ToString
        pe.Text = dt.Rows(0).Item("Pe").ToString
        te.Text = dt.Rows(0).Item("te").ToString
        diagN.Text = dt.Rows(0).Item("diagN").ToString
        prescD.Text = dt.Rows(0).Item("PresD").ToString
        AnamA.Text = dt.Rows(0).Item("AnamA").ToString
        AlimP.Text = dt.Rows(0).Item("AlimP").ToString
        CaloR.Text = dt.Rows(0).Item("Calor").ToString
        Prot.Text = dt.Rows(0).Item("Prot").ToString
        AlimR.Text = dt.Rows(0).Item("AlimR").ToString
        Gras.Text = dt.Rows(0).Item("Gras").ToString
        CHO.Text = dt.Rows(0).Item("CHO").ToString
        ExamL.Text = dt.Rows(0).Item("ExamL").ToString
        IntoA.Text = dt.Rows(0).Item("IntoA").ToString
        Combonutri.SelectedValue = dt.Rows(0).Item("Nutricionista").ToString
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.habilitarControles(Me)
            limpiar()
            dgvunion.ReadOnly = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btanular.Enabled = False
            btbuscar.Enabled = False
            txteps.ReadOnly = True
            fechaadmision.ReadOnly = True
            btimprimir.Enabled = False
            bteditar.Enabled = False
            btnuevo.Enabled = False
            txtregistro.ReadOnly = True
            txtpaciente.ReadOnly = True
            txteps.ReadOnly = True
            fechaadmision.ReadOnly = True
            cargarDiagnosticos()
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarDiagnosticos()
        If codigoEvo = "" Then
            General.llenarTablaYdgv(Consultas.CARGAR_DIAG_V_NUTRICIONAL & txtregistro.Text, dtValoracion)
        Else
            General.llenarTablaYdgv(Consultas.CARGAR_DIAG_V_NUTRICIONAL2 & codigoEvo, dtValoracion)
        End If
    End Sub

    Public Function crearVNutricional() As ValoracionNutricional
        Dim objValoracion = New ValoracionNutricional
        objValoracion.CodigoValoracion = txtcodigo.Text
        objValoracion.Registro = txtregistro.Text
        objValoracion.AlimP = AlimP.Text
        objValoracion.AlimR = AlimR.Text
        objValoracion.AnamA = AnamA.Text
        objValoracion.CaloR = CaloR.Text
        objValoracion.CHO = CHO.Text
        objValoracion.DiagN = diagN.Text
        objValoracion.ExamL = ExamL.Text
        objValoracion.Fechavaloracion = fechavalor.Value
        objValoracion.Gras = Gras.Text
        objValoracion.IntoA = IntoA.Text
        objValoracion.Nutricionista = Combonutri.SelectedValue
        objValoracion.pe = pe.Text
        objValoracion.PesoA = PesoA.Text
        objValoracion.PresD = prescD.Text
        objValoracion.Prot = Prot.Text
        objValoracion.pt = pt.Text
        objValoracion.Talla = Talla.Text
        objValoracion.te = te.Text
        objValoracion.Usuario = SesionActual.idUsuario
        Return objValoracion
    End Function
    Private Sub Form_ValoracionNutricional_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Public Sub crearValoracion()
        Dim objValoracion_D As New ValoracionNutricionalBLL
        Dim objValoracion As ValoracionNutricional

        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objValoracion = crearVNutricional()
                objValoracion_D.crearValoracionN(objValoracion)
                txtcodigo.Text = objValoracion.CodigoValoracion

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btbuscar.Enabled = True
                btnuevo.Enabled = True
                btimprimir.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Public Function validarControles()
        If Combonutri.SelectedValue = -1 Then
            MsgBox("Debe seleccionar el nutricionista", MsgBoxStyle.Exclamation)
            Combonutri.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(diagN.Text) Then
            MsgBox("El campo diagnóstico nutricional se encuentra vacio", MsgBoxStyle.Exclamation)
            diagN.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(prescD.Text) Then
            MsgBox("El campo prescripción dietaria se encuentra vacio", MsgBoxStyle.Exclamation)
            prescD.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(AnamA.Text) Then
            MsgBox("El campo anamnesis alimentaria se encuentra vacio", MsgBoxStyle.Exclamation)
            AnamA.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(AlimP.Text) Then
            MsgBox("El campo alimentos preferidos se encuentra vacio", MsgBoxStyle.Exclamation)
            AlimP.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(CaloR.Text) Then
            MsgBox("El campo calorias requeridas se encuentra vacio", MsgBoxStyle.Exclamation)
            CaloR.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(Prot.Text) Then
            MsgBox("El campo proteinas se encuentra vacio", MsgBoxStyle.Exclamation)
            Prot.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(Gras.Text) Then
            MsgBox("El campo grasas se encuentra vacio", MsgBoxStyle.Exclamation)
            Gras.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(CHO.Text) Then
            MsgBox("El campo CHO se encuentra vacio", MsgBoxStyle.Exclamation)
            CHO.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(ExamL.Text) Then
            MsgBox("El campo examen de laboratorio se encuentra vacio", MsgBoxStyle.Exclamation)
            ExamL.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(IntoA.Text) Then
            MsgBox("El campo intolerancia algun alimento se encuentra vacio", MsgBoxStyle.Exclamation)
            IntoA.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarControles() Then
            crearValoracion()
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del valoracion", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_V_NUTRICIONAL
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarReportes()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarReportes()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_V_NUTRICIONAL, txtcodigo.Text, New rptValorNutricional,
                                    txtcodigo.Text, "{VISTA_V_NUTRICIONAL.codigo_Valoracion} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_V_NUTRICIONAL, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub PesoA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PesoA.KeyPress

    End Sub

    Private Sub Talla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Talla.KeyPress

    End Sub

    Private Sub fechavalor_ValueChanged(sender As Object, e As EventArgs) Handles fechavalor.ValueChanged

    End Sub

    Private Sub fechavalor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles fechavalor.Validating
        If fechavalor.Text < CDate(fechaadmision.Text).Date Then
            MsgBox("La fecha de curacion no puede ser menor a la fecha admision", MsgBoxStyle.Exclamation)
            fechavalor.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.habilitarControles(Me)
            dgvunion.ReadOnly = True
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btnuevo.Enabled = False
            bteditar.Enabled = False
            txteps.ReadOnly = True
            fechaadmision.ReadOnly = True
            btanular.Enabled = False
            btimprimir.Enabled = False
            txtregistro.ReadOnly = True
            txtpaciente.ReadOnly = True
            btbuscar.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarPaciente(registro As String, nombre As String, fecha As String, eps As String)
        txtregistro.Text = registro
        txtpaciente.Text = nombre
        fechaadmision.Text = fecha
        txteps.Text = eps
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim lista As New List(Of String)
                lista.Add(txtcodigo.Text)
                lista.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_V_NUTRICIONAL, lista)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                limpiar()
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btguardar.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
                txtcodigo.Clear()
                dtValoracion.Clear()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            btanular.Enabled = False
            bteditar.Enabled = False
            btnuevo.Enabled = False
            btimprimir.Enabled = False
            btbuscar.Enabled = True
            btguardar.Enabled = False
            txtregistro.ReadOnly = True
            btnuevo.Enabled = True
            txtpaciente.ReadOnly = True
            limpiar()
            dtValoracion.Clear()
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
End Class