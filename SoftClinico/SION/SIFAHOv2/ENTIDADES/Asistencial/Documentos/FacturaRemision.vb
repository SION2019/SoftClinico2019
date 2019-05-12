Public Class FacturaRemision
    Inherits FacturaAtencion
    Public Property idCliente As Integer
    Public Property dtMedicamentos As New DataTable
    Public Property dtPendiente As New DataTable
    Public Property dtAFacturar As New DataTable
    Public Property dtInsumos As New DataTable
    Public Property valorIVA As Double
    Public Property sqlPrecargarMedicamentos As String
    Public Property sqlPostCargarMedicamentos As String
    Public Property sqlPostCargarInsumos As String
    Public Property observacion As String
    Public Property listaDocumentos As String
    Public Property totalMedicamentos As Double
    Public Property totalInsumos As Double

    Public Sub New()
        consultasCargarDatosFactura()
        sqlbuscarRegistroAFacturar = ConsultasAsis.FACTURA_REMISION_PENDIENTE_BUSCAR
        sqlCargarRegistroAFacturar = ConsultasAsis.FACTURA_REMISION_FACTURADA_CARGAR
        sqlBuscarContrato = ConsultasAsis.FACTURA_REMISION_CLIENTE_BUSCAR
        sqlCargarContrato = Consultas.CLIENTES_CARGAR
        sqlPrecargarMedicamentos = ConsultasAsis.FACTURA_REMISION_MEDICAMENTOS_CARGAR
        sqlPostCargarMedicamentos = ConsultasAsis.FACTURA_REMISION_MEDICAMENTOS_POSTCARGAR
        sqlPostCargarInsumos = ConsultasAsis.FACTURA_REMISION_INSUMOS_POSTCARGAR
        sqlBuscarFactura = ConsultasAsis.FACTURA_REMISION_BUSCAR
        sqlCargarFactura = ConsultasAsis.FACTURA_REMISION_CARGAR
        sqlAnularFactura = ConsultasAsis.FACTURA_ANULAR
        GeneralAsis.crearTablaFacturaMedRem(dtMedicamentos)
        GeneralAsis.crearTablaFacturaMedRem(dtInsumos)
        GeneralAsis.crearTablaFacturaRem(dtPendiente)
        GeneralAsis.crearTablaFacturaRem(dtAFacturar)
        nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_REMISION
        tipo = 4
    End Sub
    Public Sub consultasCargarDatosFactura()
        sqlPostCargarMedicamentos = ConsultasAsis.FACTURA_REMISION_MEDICAMENTOS_POSTCARGAR
        sqlPostCargarInsumos = ConsultasAsis.FACTURA_REMISION_INSUMOS_POSTCARGAR
    End Sub

    Public Function verificarClausulas() As String
        Dim mensaje As String = ""
        Dim params As New List(Of String)
        'params.Add(CodigoContrato)
        If Not String.IsNullOrEmpty(codigoFactura) Then Return mensaje
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
    Public Function verificarTotales() As String
        Return ""
    End Function

    Public Overrides Sub cargarDetalle()
        Try
            limpiarTablas()
            preCargarMedicamentos()
            preCargarInsumos()

            calcularTotal()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub preCargarInsumos()
        FacturaRemisionDAL.cargarInsumoPendientes(Me)
    End Sub

    Public Sub preCargarMedicamentos()
        FacturaRemisionDAL.cargarMedicamentoPendientes(Me)
    End Sub

    Public Sub limpiarTablas()
        dtMedicamentos.Clear()
        dtInsumos.Clear()
    End Sub

    Public Sub calcularTotal()
        If String.IsNullOrEmpty(codigoFactura) Then
            totalMedicamentos = If(IsDBNull(dtMedicamentos.Compute("SUM(Total)", "")), 0, dtMedicamentos.Compute("SUM(Total)", ""))
            totalInsumos = If(IsDBNull(dtInsumos.Compute("SUM(Total)", "")), 0, dtInsumos.Compute("SUM(Total)", ""))
            valorIVA = If(IsDBNull(dtInsumos.Compute("SUM(ValorIVA)", "")), 0, dtInsumos.Compute("SUM(ValorIVA)", "")) + If(IsDBNull(dtMedicamentos.Compute("SUM(ValorIVA)", "")), 0, dtMedicamentos.Compute("SUM(ValorIVA)", ""))
            totalFactura = totalMedicamentos + totalInsumos + valorIVA
        Else
            valorIVA = If(IsDBNull(dtInsumos.Compute("SUM(ValorIVA)", "")), 0, dtInsumos.Compute("SUM(ValorIVA)", "")) + If(IsDBNull(dtMedicamentos.Compute("SUM(ValorIVA)", "")), 0, dtMedicamentos.Compute("SUM(ValorIVA)", ""))
        End If

    End Sub

    Public Sub cargarFacturadas()
        Try
            Dim params As New List(Of String)
            params.Add(codigoFactura)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlCargarRegistroAFacturar, params, dtAFacturar)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub postCargarMedicamentos()
        Try
            Dim params As New List(Of String)
            params.Add(codigoFactura)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlPostCargarMedicamentos, params, dtMedicamentos)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub postCargarInsumos()
        Try
            Dim params As New List(Of String)
            params.Add(codigoFactura)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlPostCargarInsumos, params, dtInsumos)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub cargarPendientes()
        dtPendiente.Clear()
        FacturaRemisionDAL.cargarPendientes(Me)
    End Sub

    Public Overrides Sub cargarFactura()
        limpiarTablas()
        cargarFacturadas()
        postCargarMedicamentos()
        postCargarInsumos()

        calcularTotal()

    End Sub
    Public Overrides Sub guardarFactura()
        Try

            FacturaRemisionDAL.guardarFactura(Me)

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
            params.Add(valorIVA)
            params.Add(observacion)
            params.Add(listaDocumentos)
            nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(nombrePDF, codigoFactura, New rptFacturaRemision,
                                    codigoFactura,
                                   "{VISTA_FACTURACION.codigo_factura} = '" & codigoFactura & "' 
                                   AND {VISTA_FACTURACION.TipoFactura}=" & tipo & "
                                   AND {VISTA_FACTURACION.Id_Empresa}=" & SesionActual.idEmpresa & "",
                                   nombrePDF, IO.Path.GetTempPath,,, params)

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
