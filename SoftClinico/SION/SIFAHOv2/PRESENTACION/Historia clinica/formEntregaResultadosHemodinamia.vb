Public Class formEntregaResultadosHemodinamia
    Dim objResultados As New ResultadosImagenologia
    Private Sub formEntregaResultadosHemodinamia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enlazarGrilla()
        dtpInicio.Value = Date.Now.AddDays(-Date.Now.Day + 1)
        listadoPacientesPendientes()
    End Sub
    Public Sub listadoPacientesPendientes()
        objResultados.cargarResultados(SesionActual.codigoEP, txtBusqueda.Text, dtpInicio.Value, dtpFin.Value, rdRealizados.Checked)
        verificarColumnaResultado()
        contarPacientes()
    End Sub
    Public Sub listadoPacienteRealizados()
        verificarColumnaResultado()
        contarPacientes()
    End Sub
    Sub verificarColumnaResultado()
        dgvimagen.Columns("dgImagen").Visible = If((rdRealizados.Checked), True, False)
    End Sub
    Sub contarPacientes()
        lblCantidadPacientes.Text = objResultados.tablaResultados.Rows.Count
    End Sub
    Private Sub enlazarGrilla()
        With dgvimagen
            .Columns("dgNombre").DataPropertyName = "Paciente"
            .Columns("dgEPS").DataPropertyName = "EPS"
            .Columns("dgDescripcion").DataPropertyName = "Descripcion"
            .Columns("dgArea").DataPropertyName = "Area_servicio"
            .Columns("dgFecha").DataPropertyName = "Fecha"
            .AutoGenerateColumns = False
            .DataSource = objResultados.tablaResultados
        End With
    End Sub
    Private Sub busquedaPaciente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            listadoPacientesPendientes()
        End If
    End Sub
    Private Sub rdRealizados_Click(sender As Object, e As EventArgs) Handles rdRealizados.Click, rdPendiente.Click
        listadoPacientesPendientes()
    End Sub
    Private Sub dgvimagen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvimagen.CellContentClick

        Cursor = Cursors.WaitCursor
        If Funciones.filaValida(e.RowIndex) Then
            Dim codigoOrden As String = objResultados.tablaResultados.Rows(e.RowIndex).Item("Codigo_Orden")
            Dim codigoProcedimiento As String = objResultados.tablaResultados.Rows(e.RowIndex).Item("Codigo_Procedimiento")
            Try
                If e.ColumnIndex = dgvimagen.Columns("dgImagen").Index Then

                    If objResultados.tablaResultados.Rows(e.RowIndex).Item("TipoExamen").Equals("LE") Then
                        Dim paraclinicoLab As New AtencionParaclinicoLaboratorio
                        paraclinicoLab.codigoOrden = codigoOrden
                        paraclinicoLab.codigoProcedimiento = codigoProcedimiento
                        paraclinicoLab.cargarNombrePDF()
                        paraclinicoLab.areaExamen = "A"
                        paraclinicoLab.imprimir()
                    Else
                        Dim tablaResultadoImagenes As New DataTable
                        Dim params As New List(Of String)
                        Dim ruta As String = Funciones.crearCarpeta(codigoOrden)
                        params.Add(codigoOrden)
                        params.Add(codigoProcedimiento)
                        params.Add(0)
                        General.llenarTabla(ConsultasHC.RESULTADO_EXAMENES_CARGAR_D, params, tablaResultadoImagenes)
                        For Each fila As DataRow In tablaResultadoImagenes.Rows
                            If Not fila.Item("nombreArchivo").ToString.Contains(".dcm") Then
                                Dim bites() As Byte
                                Using picImagen As New PictureBox
                                    bites = fila.Item("Archivo")
                                    Using ms As New MemoryStream(bites)
                                        picImagen.Image = Image.FromStream(ms, False, False)
                                        picImagen.Image.Save(ruta & "\" & fila.Item("nombreArchivo"))
                                    End Using
                                End Using
                                bites = Nothing
                                Process.Start(ruta & "\")
                            End If
                        Next
                        imprimirLectura(codigoOrden, codigoProcedimiento)
                    End If

                ElseIf e.ColumnIndex = dgvimagen.Columns("solicitud").Index
                    Dim abrirAtencion As New FormAtencionLaboratorio
                    abrirAtencion.esHijo = True
                    abrirAtencion.cargarDatos(Me.Tag.modulo, codigoOrden)
                    FormPrincipal.Cursor = Cursors.WaitCursor
                    abrirAtencion.ShowDialog()
                    If abrirAtencion.WindowState = FormWindowState.Minimized Then
                        abrirAtencion.WindowState = FormWindowState.Normal
                    End If
                    FormPrincipal.Cursor = Cursors.Default
                End If
            Catch ex As Exception
                Cursor = Cursors.Default
                MsgBox(ex.Message)
            End Try
        End If
        Cursor = Cursors.Default
    End Sub
    Public Sub imprimirLectura(ByVal codigoOrden As String,
                               ByVal codigoProcedimiento As String)

        Try
            Dim lectura As New ExamenResultado
            lectura.CodigoOrden = codigoOrden
            lectura.CodigoProcedimiento = codigoProcedimiento
            lectura.imprimir()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

End Class