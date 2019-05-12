Public Class FormHistorialEquipos

    Private objHistorial As New HistorialEquipos
    Dim dtActualizado As New DataTable
    Public usuarioInforme, contadorDiag, CodigoTemporal, nRegistro, usuarioActual As Integer
    Dim activoAM, activoAF, respuestan As Boolean
    Dim reporte As New ftp_reportes
    Private Sub FormHistorialEquipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarEquiposRealizados()
        cargarEquiposActualizados()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormHistorialEquipos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If

    End Sub
    Public Sub pintar()
        Dim ver As String
        ver = Inicio.version_actu

        For j As Int32 = 0 To dgactualizado.Rows.Count - 1
            If Replace(dgactualizado.Rows(j).Cells(3).Value.ToString.Trim, "Versión ", "") < ver Then
                dgactualizado.Rows(j).Cells(3).Value = "¡¡Equipo desactualizado!!"
            Else
                dgactualizado.Rows(j).Cells(3).Value = "Este equipo se encuenta actualizado."
            End If
            If dgactualizado.Rows(j).Cells(3).Value.ToString.ToLower.Contains("desactu") Then
                dgactualizado.Rows(j).DefaultCellStyle.BackColor = Color.LightSalmon
            Else
                dgactualizado.Rows(j).DefaultCellStyle.BackColor = Color.LightBlue
            End If
        Next
    End Sub
    Public Sub cargarEquiposActualizados()
        If IsNothing(dgactualizado.DataSource) Then
            With dgactualizado

                .Columns("Equipo").ReadOnly = True
                .Columns.Item("Equipo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Equipo").DataPropertyName = "Nombre equipo"

                .Columns("fecha2").ReadOnly = True
                .Columns.Item("fecha2").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("fecha2").DataPropertyName = "Fecha"

                .Columns("Version").ReadOnly = True
                .Columns.Item("Version").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Version").DataPropertyName = "Version sifaho V2"

                .Columns("observacion2").ReadOnly = True
                .Columns.Item("observacion2").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("observacion2").DataPropertyName = "Observacion"

            End With
        End If
        objHistorial.fecha = fechaMantenimiento.Value.Date
        objHistorial.cargarEquiposActualizadosoDesactualizados()
        dgactualizado.DataSource = objHistorial.dtActualizados
        pintar()
    End Sub
    Public Sub cargarDatosEquipo()
        Dim objEquipo As EquipoComputo
        objEquipo = objHistorial.obtenerDatosEquipo(objHistorial.codigo)
        txtnombre.Text = objEquipo.nombre
        txtmarca.Text = objEquipo.marca
        txtmodelo.Text = objEquipo.modelo
        txtarea.Text = objEquipo.area
        serial.Text = objEquipo.serial
        procesador.Text = objEquipo.procesador
        board.Text = objEquipo.board
        memoria.Text = objEquipo.ram
        disco.Text = objEquipo.discoDuro
    End Sub

    Public Sub cargarDatosEquipoBio()
        Dim objEquipoBio As EquiposBiomedicos
        objEquipoBio = objHistorial.obtenerDatosBio(objHistorial.codigo)
        txtnombre.Text = objEquipoBio.nombre
        txtmarca.Text = objEquipoBio.marca
        txtmodelo.Text = objEquipoBio.modelo
        txtarea.Text = objEquipoBio.area
    End Sub

    Public Sub cargarHistorial(pObjHistorial As HistorialEquipos)
        objHistorial = pObjHistorial
    End Sub
    Private Sub cargarEquiposRealizados()
        If IsNothing(dgHistorial.DataSource) Then
            With dgHistorial

                .Columns("fecha").ReadOnly = True
                .Columns.Item("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("fecha").DataPropertyName = "Fecha"

                .Columns("preventivo1").ReadOnly = True
                .Columns.Item("preventivo1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("preventivo1").DataPropertyName = "Preventivo"

                .Columns("correctivo1").ReadOnly = True
                .Columns.Item("correctivo1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("correctivo1").DataPropertyName = "Correctivo"

                .Columns("falla1").ReadOnly = True
                .Columns.Item("falla1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("falla1").DataPropertyName = "Falla reportada"

                .Columns("trabajo1").ReadOnly = True
                .Columns.Item("trabajo1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("trabajo1").DataPropertyName = "Trabajo realizado"

                .Columns("observacion1").ReadOnly = True
                .Columns.Item("observacion1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("observacion1").DataPropertyName = "Observacion"

            End With
        End If

        If objHistorial.checkComputo = True Then
            cargarDatosEquipo()
        Else
            cargarDatosEquipoBio()
            serial.Visible = False
            disco.Visible = False
            procesador.Visible = False
            memoria.Visible = False
            board.Visible = False

            Label6.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            Label11.Visible = False
        End If
        objHistorial.cargarHistorialEquipo()
        dgHistorial.DataSource = objHistorial.dtHistorial
        dgHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgHistorial.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub

    Private Sub fechaMantenimiento_ValueChanged(sender As Object, e As EventArgs) Handles fechaMantenimiento.ValueChanged
        cargarEquiposActualizados()
    End Sub

    Private Sub dgHistorial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHistorial.CellClick
        If e.ColumnIndex = 0 Then
            imprimirHistoria()
        End If
    End Sub

    Public Sub imprimirHistoria()

        Cursor = Cursors.WaitCursor

        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_BITACORA
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & objHistorial.codigo & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            guardarReportecateter()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub guardarReportecateter()
        Dim tipo As Object
        Try
            If objHistorial.checkComputo = True Then
                tipo = New rptBitacora
                reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_BITACORA, objHistorial.codigo, tipo,
                             objHistorial.codigo, "{VISTA_BITACORA.Codigo_equipo} = " & objHistorial.codigo & "",
                               ConstantesHC.NOMBRE_PDF_BITACORA, IO.Path.GetTempPath)
            Else
                tipo = New rptBiomedicoBitacora
                reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_BITACORA, objHistorial.codigo, tipo,
                         objHistorial.codigo, "{VISTA_BITACORA_BIOMEDICO.Codigo_equipo} = " & objHistorial.codigo & "",
                           ConstantesHC.NOMBRE_PDF_BITACORA, IO.Path.GetTempPath)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
End Class