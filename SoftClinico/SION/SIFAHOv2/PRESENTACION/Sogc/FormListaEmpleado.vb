Public Class FormListaEmpleado
    Dim objListaEmpleado As ListaEmpleado
    Dim reporte As New ftp_reportes
    Private Sub FormListaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objListaEmpleado = New ListaEmpleado
        objListaEmpleado.codigoEp = SesionActual.idEmpresa
        objListaEmpleado.codigoPunto = SesionActual.codigoEP
        validarDgv()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub validarDgv()
        With dgvEmpleado
            .ReadOnly = True
            .Columns("dgId").DataPropertyName = "Id_empleado"
            .Columns("dgCedula").DataPropertyName = "Cedula"
            .Columns("dgNombre").DataPropertyName = "Empleado"
            .Columns("dgCargo").DataPropertyName = "Cargo"
            .Columns("dgEmpresa").DataPropertyName = "Empresa"
            .Columns("dgPunto").DataPropertyName = "Punto_Servicio"
            .Columns("dgEps").DataPropertyName = "Eps"
            .Columns("dgArp").DataPropertyName = "Arp"
            .Columns("dgCaja").DataPropertyName = "Caja"
            .Columns("dgPension").DataPropertyName = "Pension"
            .Columns("dgContrato").DataPropertyName = "Contrato"
            .Columns("dgSalario").DataPropertyName = "Salario_Contrato"
            .DataSource = objListaEmpleado.dtEmpleado
            .AutoGenerateColumns = False
        End With
    End Sub

    Private Sub cargarDatoEmpleado()
        objListaEmpleado.cargarDatos(CDate(dtFechaInicio.Value).Date,
                                     CDate(dtFechaFin.Value).Date,
                                     If(ckInactivo.Checked = True, 1, 0),
                                     txtBusqueda.Text)
        dgvEmpleado.DataSource = objListaEmpleado.dtEmpleado
    End Sub

    Private Sub activarEventos(sender As Object, e As EventArgs) Handles ckInactivo.CheckedChanged,
                                                                                     dtFechaFin.ValueChanged,
                                                                                     txtBusqueda.TextChanged,
                                                                                     dtFechaInicio.ValueChanged
        cargarDatoEmpleado()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Cursor = Cursors.WaitCursor
        imprimirReporte(dtFechaInicio.Value,
                        dtFechaFin.Value,
                        If(ckInactivo.Checked = True, 1, 0),
                        txtBusqueda.Text)
        Cursor = Cursors.Default
    End Sub

    Private Sub imprimirReporte(fechaInicio As Date,
                                fechaFin As Date,
                                Inactivo As Integer,
                                txt As String)
        Dim ruta, area, nombreArchivo As String
        Dim params As New List(Of String)
        area = Constantes.NOMBRE_PDF_LISTA_EMPLEADO

        params.Add(Format(CDate(fechaInicio).Date, Constantes.FORMATO_FECHA_GEN2))
        params.Add(Format(CDate(fechaFin).Date, Constantes.FORMATO_FECHA_GEN2))
        params.Add(Inactivo)
        params.Add(txt)

        Try
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & objListaEmpleado.codigoEp & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            reporte.crearReportePDF(area, objListaEmpleado.codigoEp, New rptListaEmpleado,
                                     objListaEmpleado.codigoEp, "{VISTA_EMPRESAS.Id_empresa}=" & objListaEmpleado.codigoEp,
                                   area, IO.Path.GetTempPath,,, params)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
End Class