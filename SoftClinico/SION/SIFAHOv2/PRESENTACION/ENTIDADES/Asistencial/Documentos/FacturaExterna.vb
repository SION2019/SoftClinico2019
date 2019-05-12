Public Class FacturaExterna
    Inherits FacturaAtencion
    Public Property idCliente As Integer
    Public Property dtParaclinicos As New DataTable
    Public Property dtHemoderivados As New DataTable
    Public Property dtProcedimientos As New DataTable
    Public Property dtMedicamentos As New DataTable
    Public Property dtInsumos As New DataTable
    Public Property sqlBuscarCliente As String
    Public Property sqlcargarCliente As String
    Public Property sqlPrecargarParaclinicos As String
    Public Property sqlPrecargarHemoderivados As String
    Public Property sqlPrecargarProcedimientos As String
    Public Property sqlPrecargarMedicamentos As String
    Public Property sqlPrecargarInsumos As String
    Public Property sqlPostCargarParaclinicos As String
    Public Property sqlPostCargarHemoderivados As String
    Public Property sqlPostCargarProcedimientos As String
    Public Property sqlPostCargarMedicamentos As String
    Public Property sqlPostCargarInsumos As String
    Public Property totalParaclinicos As Double
    Public Property totalHemoderivados As Double
    Public Property totalProcedimientos As Double
    Public Property totalMedicamentos As Double
    Public Property totalInsumos As Double
    Public Sub New()
        consultasCargarDatosFactura()
        sqlBuscarCliente = ConsultasAsis.FACTURA_EXTERNA_CLIENTE_BUSCAR
        sqlcargarCliente = Consultas.CLIENTES_CARGAR
        sqlBuscarFactura = ConsultasAsis.FACTURA_EXTERNA_BUSCAR
        sqlCargarFactura = ConsultasAsis.FACTURA_EXTERNA_CARGAR
        sqlAnularFactura = ConsultasAsis.FACTURA_ANULAR
        GeneralAsis.crearTablaFactura(dtParaclinicos)
        GeneralAsis.crearTablaFactura(dtHemoderivados)
        GeneralAsis.crearTablaFactura(dtProcedimientos)
        GeneralAsis.crearTablaFactura(dtMedicamentos)
        GeneralAsis.crearTablaFactura(dtInsumos)
        nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_EXTERNA
        tipo = 2
    End Sub
    Public Sub consultasCargarDatosFactura()
        sqlPostCargarParaclinicos = ConsultasAsis.FACTURA_PARACLINICOS_POSTCARGAR
        sqlPostCargarHemoderivados = ConsultasAsis.FACTURA_HEMODERIVADOS_POSTCARGAR
        sqlPostCargarMedicamentos = ConsultasAsis.FACTURA_MEDICAMENTOS_POSTCARGAR
        sqlPostCargarProcedimientos = ConsultasAsis.FACTURA_PROCEDIMIENTOS_POSTCARGAR
        sqlPostCargarInsumos = ConsultasAsis.FACTURA_INSUMOS_POSTCARGAR
    End Sub

    Public Function verificarClausulas() As String
        Dim mensaje As String = ""
        Dim params As New List(Of String)
        ''-------ESTO LO COMENTO POR SI ALGUN DIA SE HARÁ POR CONTRATOS
        ''--------------------------------------------------------------
        'params.Add(idCliente)
        'If Not String.IsNullOrEmpty(codigoFactura) Then Return mensaje
        'If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_FECHA_CONTRATO_VERIFICAR, params) = False Then
        '    mensaje = Mensajes.FECHA_FIN_CONTRATO
        '    Return mensaje
        'End If
        'If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_ATENCION_CONTRATO_VERIFICAR, params) = False Then
        '    mensaje = Mensajes.LIMITE_ATENCION_CONTRATO
        '    Return mensaje
        'End If
        'If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_VALOR_CONTRATO_VERIFICAR, params) = False Then
        '    mensaje = Mensajes.VALOR_FIN_CONTRATO
        '    Return mensaje
        'End If
        'params.Clear()
        params.Add(SesionActual.idEmpresa)
        If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_RESOLUCION_VERIFICAR, params) = False Then
            mensaje = Mensajes.LIMITE_RESOLUCION
            Return mensaje
        End If
        Return mensaje
    End Function

    Public Overrides Sub cargarDetalle()
        Try
            limpiarTablas()
            cargarFactura()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub limpiarTablas()
        dtParaclinicos.Clear()
        dtHemoderivados.Clear()
        dtProcedimientos.Clear()
        dtMedicamentos.Clear()
        dtInsumos.Clear()
    End Sub

    Private Sub calcularTotal()
        totalParaclinicos = If(IsDBNull(dtParaclinicos.Compute("SUM(Total)", "")), 0, dtParaclinicos.Compute("SUM(Total)", ""))
        totalHemoderivados = If(IsDBNull(dtHemoderivados.Compute("SUM(Total)", "")), 0, dtHemoderivados.Compute("SUM(Total)", ""))
        totalProcedimientos = If(IsDBNull(dtProcedimientos.Compute("SUM(Total)", "")), 0, dtProcedimientos.Compute("SUM(Total)", ""))
        totalMedicamentos = If(IsDBNull(dtMedicamentos.Compute("SUM(Total)", "")), 0, dtMedicamentos.Compute("SUM(Total)", ""))
        totalInsumos = If(IsDBNull(dtInsumos.Compute("SUM(Total)", "")), 0, dtInsumos.Compute("SUM(Total)", ""))
        totalFactura = totalParaclinicos + totalHemoderivados _
                     + totalProcedimientos + totalMedicamentos + totalInsumos
    End Sub
    Public Sub postCargarMedicamentos()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarMedicamentos, params, dtMedicamentos)
    End Sub

    Public Sub postCargarParaclinicos()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarParaclinicos, params, dtParaclinicos)
    End Sub
    Public Sub postCargarHemoderivados()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarHemoderivados, params, dtHemoderivados)
    End Sub
    Public Sub postCargarProcedimientos()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarProcedimientos, params, dtProcedimientos)
    End Sub
    Public Sub postCargarInsumos()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarInsumos, params, dtInsumos)
    End Sub

    Public Overrides Sub cargarFactura()
        postCargarParaclinicos()
        postCargarHemoderivados()
        postCargarProcedimientos()
        postCargarMedicamentos()
        postCargarInsumos()
        calcularTotal()
    End Sub
    Public Overrides Sub guardarFactura()
        Try
            FacturaExternaDAL.guardarFactura(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub calcularFechas()
        Dim params As New List(Of String)
        params.Add(idCliente)
        params.Add(fechaFactura.Date.ToShortDateString)
        fechaVencimiento = CDate(General.getValorConsulta(ConsultasAsis.FACTURA_CLIENTE_FECHA_VENCIMIENTO, params))
    End Sub
    Public Overrides Sub imprimirFactura()
        Try
            Dim ruta, nombreArchivo As String
            Dim reporte As New ftp_reportes
            Dim params As New List(Of String)
            params.Add(FuncionesContables.Convertir_Numero(totalFactura))
            nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearYGuardarReporte(nombrePDF, codigoFactura, New rptFacturaAsistencial,
                                    codigoFactura,
                                  "{VISTA_FACTURACION.codigo_factura} = '" & codigoFactura & "' 
                                  AND {VISTA_FACTURACION.TipoFactura}=" & tipo & "
                                  AND {VISTA_FACTURACION.Id_Empresa}=" & SesionActual.idEmpresa & "",
                                   nombrePDF, IO.Path.GetTempPath,, True, params)
            Process.Start(ruta)
        Catch ex As Exception
            MsgBox(ex.Message & "Error en imprimirFactura ")
        End Try
    End Sub

    Public Overrides Sub anularFactura()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        params.Add(SesionActual.idUsuario)
        General.ejecutarSQL(sqlAnularFactura, params)
    End Sub
End Class
