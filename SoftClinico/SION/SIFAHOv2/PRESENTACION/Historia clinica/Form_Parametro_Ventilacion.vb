Imports System.Threading
Public Class Form_Parametro_Ventilacion
    Dim objParametro As New ParametroVentilacion
    Dim codigoTemporal, moduloTemporal, usuarioActual, nRegistro As String
    Dim reporteSegundoPlano As Thread
    Dim activoAM, activoAF As Boolean

    Private Sub cargarDescripcion()
        objParametro.cargarDetalle()
        GeneralHC.enlaceDgvSabana(dtgvParametro, objParametro.dtHorasabana)
    End Sub
    Private Sub dgv_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dtgvParametro.CellDoubleClick
        GeneralHC.RegistroEditar(dgv, objParametro)
    End Sub

    Private Sub grillaPrametrosVentilacion_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dtgvParametro.RowPostPaint
        Using Pinceles As New SolidBrush(dtgvParametro.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(objParametro.dtHorasabana.Rows(e.RowIndex).Item("Nombre").ToString,
            dtgvParametro.Rows(e.RowIndex).Cells(0).InheritedStyle.Font,
            Pinceles, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Public Sub cargarDatosPaciente(ByRef pHistoriaClinica As HistoriaClinica)
        Dim params As New List(Of String)
        Dim dr As DataRow
        Dim fechaServidor As DateTime = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objParametro = pHistoriaClinica.objParametroV
        General.deshabilitarControles(GroupDatos)
        moduloTemporal = pHistoriaClinica.modulo
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
        Try
            params.Add(objParametro.nRegistro)
            dr = General.cargarItem(objParametro.sqlDatoPacienteCarga, params)
            txtregistro.Text = objParametro.nRegistro
            txtidentificacion.Text = dr.Item(0).ToString
            txtpaciente.Text = dr.Item(1).ToString
            txtsexo.Text = dr.Item(2).ToString
            txtedad.Text = dr.Item(3).ToString
            txtcama.Text = dr.Item(4).ToString
            txtfechaingreso.Text = Format(CDate(dr.Item(5).ToString), Constantes.FORMATO_FECHA_HORA_GEN3)
            txtcodigocontrato.Text = dr.Item(6).ToString
            txtcontrato.Text = dr.Item(7).ToString
            txtServicio.Text = dr.Item(8).ToString
            dtFecha.Value = Format(CDate(dr.Item(9).ToString), Constantes.FORMATO_FECHA_HORA_GEN3)
            dtFechaEgreso.Text = Format(CDate(dr.Item(9).ToString), Constantes.FORMATO_FECHA_HORA_GEN3)
            dtFecha.Enabled = True
            cargarRegistroParametro()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarRegistroParametro()
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL ) AndAlso IsNothing(objParametro.usuarioReal) Then
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Information)
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_FISIOTERAPIA)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objParametro.usuarioReal = tbl(0)
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Close()
                Exit Sub
            End If
        End If
        objParametro.fechaReal = dtFecha.Value.Date
        objParametro.fechaIngreso = txtfechaingreso.Text
        objParametro.fechaEgreso = dtFechaEgreso.Text
        objParametro.cargarCodigoSabana()
        cargarDescripcion()
        GeneralHC.colorRegistroCargar(dtgvParametro, objParametro, ConstantesHC.ID_COLUMNA_PARAMETROS_VENTILACION)

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click

        If validarDGV() = True AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                dtgvParametro.EndEdit()
                objParametro.usuario = SesionActual.idUsuario
                objParametro.codigoEP = SesionActual.codigoEP
                objParametro.guardarDetalle()
                codigoTemporal = objParametro.codigoSabana
                usuarioActual = objParametro.usuario
                nRegistro = objParametro.nRegistro
                GeneralHC.colorRegistroCargar(dtgvParametro, objParametro, ConstantesHC.ID_COLUMNA_PARAMETROS_VENTILACION)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)

            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        If Not IsNothing(dtgvParametro.DataSource) Then
            If GeneralHC.verificarFechaMaxMinSeleccionParametrosV(dtFecha, objParametro) Then
                cargarRegistroParametro()
            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        dtFecha.Value = dtFecha.Value.AddDays(-1)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        dtFecha.Value = dtFecha.Value.AddDays(1)
    End Sub
    Private Sub ingreso(sender As Object, e As EventArgs) Handles irIngreso.Click, irIngreso2.Click
        dtFecha.Value = CDate(txtfechaingreso.Text).Date
    End Sub
    Private Sub egreso(sender As Object, e As EventArgs) Handles irEgreso.Click, irEgreso2.Click
        dtFecha.Value = CDate(dtFechaEgreso.Text).Date
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsRecargar.Click
        If GeneralHC.verificarFechaMaxMinSeleccionParametrosV(dtFecha, objParametro) Then
            cargarRegistroParametro()
        End If
    End Sub
    Private Function validarDGV() As Boolean
        If dtgvParametro.RowCount = 0 Then
            If GeneralHC.verificarFechaMaxMinSeleccionParametrosV(dtFecha, objParametro) Then
                cargarRegistroParametro()
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub tsImprimirHoja_Click(sender As Object, e As EventArgs) Handles tsImprimirHoja.Click, tsImprimirTodas.Click
        Try
            If String.IsNullOrEmpty(objParametro.codigoSabana) Then Exit Sub
            Cursor = Cursors.WaitCursor
            objParametro.imprimirHoja(tsImprimirTodas.Pressed)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default

    End Sub
End Class