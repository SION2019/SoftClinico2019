Public Class FacturaExterna
    Inherits FacturaAtencion
    Public Property dtParaclinicos As New DataTable
    Public Property dtHemoderivados As New DataTable
    Public Property dtProcedimientos As New DataTable
    Public Property dtMedicamentos As New DataTable
    Public Property dtInsumos As New DataTable
    Public Property sqlPrecargarParaclinicos As String
    Public Property sqlPrecargarHemoderivados As String
    Public Property sqlPrecargarProcedimientos As String
    Public Property sqlPrecargarMedicamentos As String
    Public Property sqlPrecargarInsumos As String
    Public Property sqlPostCargarParaclinicos As String
    Public Property sqlPostCargarHemoderivados As String
    Public Property sqlPostCargarProcedimientos As String
    Public Property sqlPostCargarMedicamentos As String
    Public Property observacion As String
    Public Property sqlPostCargarInsumos As String
    Public Property totalParaclinicos As Double
    Public Property totalHemoderivados As Double
    Public Property totalProcedimientos As Double
    Public Property totalMedicamentos As Double
    Public Property totalInsumos As Double
    Public Property valorCeroEnParaclinicos As Boolean
    Public Property valorCeroEnHemoderivados As Boolean
    Public Property valorCeroEnProcedimientos As Boolean
    Public Property valorCeroEnMedicamentos As Boolean
    Public Property valorCeroEnInsumos As Boolean
    Public Property facturaManual As Boolean
    Public Property facturaConsolidadoPEM As Boolean
    Public Property facturaConsolidadoTotal As Boolean
    Public Property dtPendiente As New DataTable
    Public Property dtAFacturar As New DataTable
    Public Property fechaInicio As Date
    Public Property fechaFin As Date
    Public Property consolidado As Boolean
    Public Property listaDocumentos As String
    Public Sub New()
        consultasCargarDatosFactura()
        sqlbuscarRegistroAFacturar = ConsultasAsis.FACTURA_EXTERNA_PENDIENTE_BUSCAR
        sqlCargarRegistroAFacturar = ConsultasAsis.FACTURA_EXTERNA_FACTURADA_CARGAR
        sqlBuscarContrato = ConsultasAsis.FACTURA_EXTERNA_CLIENTE_BUSCAR
        sqlCargarContrato = ConsultasAsis.FACTURA_ATENCION_CLIENTE_CARGAR
        sqlBuscarFactura = ConsultasAsis.FACTURA_EXTERNA_BUSCAR
        sqlCargarFactura = ConsultasAsis.FACTURA_EXTERNA_CARGAR
        sqlAnularFactura = ConsultasAsis.FACTURA_ANULAR
        GeneralAsis.crearTablaFactura(dtParaclinicos)
        GeneralAsis.crearTablaFactura(dtHemoderivados)
        GeneralAsis.crearTablaFactura(dtProcedimientos)
        GeneralAsis.crearTablaFacturaMed(dtMedicamentos)
        GeneralAsis.crearTablaFacturaMed(dtInsumos)
        GeneralAsis.crearTablaFacturaExt(dtPendiente)
        GeneralAsis.crearTablaFacturaExt(dtAFacturar)
        nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_EXTERNA
        tipo = 2
        sqlPrecargarParaclinicos = ConsultasAsis.FACTURA_EXTERNA_PARACLINICOS
        sqlPrecargarHemoderivados = ConsultasAsis.FACTURA_EXTERNA_HEMODERIVADOS
        sqlPrecargarProcedimientos = ConsultasAsis.FACTURA_EXTERNA_PROCEDIMIENTOS
        sqlPrecargarMedicamentos = ConsultasAsis.FACTURA_EXTERNA_MEDICAMENTOS
        sqlPrecargarInsumos = ConsultasAsis.FACTURA_EXTERNA_INSUMOS
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
        params.Add(CodigoContrato)
        If Not String.IsNullOrEmpty(codigoFactura) Then Return mensaje
        If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_FECHA_CONTRATO_VERIFICAR, params) = False Then
            mensaje = Mensajes.FECHA_FIN_CONTRATO
            Return mensaje
        End If
        If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_ATENCION_CONTRATO_VERIFICAR, params) = False Then
            mensaje = Mensajes.LIMITE_ATENCION_CONTRATO
            Return mensaje
        End If
        If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_VALOR_CONTRATO_VERIFICAR, params) = False Then
            mensaje = Mensajes.VALOR_FIN_CONTRATO
            Return mensaje
        End If
        params.Clear()
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
            If Not String.IsNullOrEmpty(codigoFactura) Then
                cargarFactura()
            Else
                preCargarMedicamentos()
                preCargarInsumos()
                preCargarParaclinicos()
                preCargarProcedimientos()
                preCargarHemoderivados()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Public Sub cargarPendientes()
        dtPendiente.Clear()
        FacturaExternaDAL.cargarPendientes(Me)
    End Sub
    Public Sub preCargarInsumos()
        FacturaExternaDAL.cargarInsumoPendientes(Me)
    End Sub

    Public Sub preCargarMedicamentos()
        FacturaExternaDAL.cargarMedicamentoPendientes(Me)
    End Sub
    Public Sub preCargarParaclinicos()
        FacturaExternaDAL.cargarParaclinicoPendientes(Me)
    End Sub

    Public Sub preCargarProcedimientos()
        FacturaExternaDAL.cargarProcedimientoPendientes(Me)
    End Sub
    Public Sub preCargarHemoderivados()
        FacturaExternaDAL.cargarHemoderivadoPendientes(Me)
    End Sub

    Public Function verificarTotales() As String
        Dim mensaje As String = ""
        valorCeroEnParaclinicos = validarValorEnCero(dtParaclinicos)
        valorCeroEnHemoderivados = validarValorEnCero(dtHemoderivados)
        valorCeroEnProcedimientos = validarValorEnCero(dtProcedimientos)
        valorCeroEnMedicamentos = validarValorEnCero(dtMedicamentos)
        valorCeroEnInsumos = validarValorEnCero(dtInsumos)

        If valorCeroEnParaclinicos Then
            mensaje = mensaje & "-Paraclínicos." & vbCrLf
        End If
        If valorCeroEnHemoderivados Then
            mensaje = mensaje & "-Hemoderivados." & vbCrLf
        End If
        If valorCeroEnProcedimientos Then
            mensaje = mensaje & "-Procedimientos." & vbCrLf
        End If
        If valorCeroEnMedicamentos Then
            mensaje = mensaje & "-Medicamentos." & vbCrLf
        End If
        If valorCeroEnInsumos Then
            mensaje = mensaje & "-Insumos." & vbCrLf
        End If
        If Not String.IsNullOrEmpty(mensaje) Then
            mensaje = Mensajes.VALORES_EN_CERO & vbCrLf & vbCrLf & mensaje
        End If
        Return mensaje
    End Function

    Private Function validarValorEnCero(dt As DataTable) As Boolean
        If dt.Select("Total=0", "").Count > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub limpiarTablas()
        dtParaclinicos.Clear()
        dtHemoderivados.Clear()
        dtProcedimientos.Clear()
        dtMedicamentos.Clear()
        dtInsumos.Clear()
    End Sub

    Public Sub calcularTotal()
        totalParaclinicos = If(IsDBNull(dtParaclinicos.Compute("SUM(Total)", "")), 0, dtParaclinicos.Compute("SUM(Total)", ""))
        totalHemoderivados = If(IsDBNull(dtHemoderivados.Compute("SUM(Total)", "")), 0, dtHemoderivados.Compute("SUM(Total)", ""))
        totalProcedimientos = If(IsDBNull(dtProcedimientos.Compute("SUM(Total)", "")), 0, dtProcedimientos.Compute("SUM(Total)", ""))
        totalMedicamentos = If(IsDBNull(dtMedicamentos.Compute("SUM(Total)", "")), 0, dtMedicamentos.Compute("SUM(Total)", ""))
        totalInsumos = If(IsDBNull(dtInsumos.Compute("SUM(Total)", "")), 0, dtInsumos.Compute("SUM(Total)", ""))
        totalFactura = totalParaclinicos + totalHemoderivados _
                     + totalProcedimientos + totalMedicamentos + totalInsumos
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

    Public Sub postCargarParaclinicos()
        Try
            Dim params As New List(Of String)
            params.Add(codigoFactura)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlPostCargarParaclinicos, params, dtParaclinicos)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub postCargarHemoderivados()
        Try
            Dim params As New List(Of String)
            params.Add(codigoFactura)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlPostCargarHemoderivados, params, dtHemoderivados)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub postCargarProcedimientos()
        Try
            Dim params As New List(Of String)
            params.Add(codigoFactura)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlPostCargarProcedimientos, params, dtProcedimientos)
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

    Public Overrides Sub cargarFactura()
        If tipo <> ConstantesAsis.TIPO_FACTURA_EXTERNA Then
            cargarFacturadas()
        End If
        postCargarParaclinicos()
        postCargarHemoderivados()
        postCargarProcedimientos()
        postCargarMedicamentos()
        postCargarInsumos()
        calcularTotal()

    End Sub

    Public Overrides Sub guardarFactura()
        Try
            If facturaManual Then
                quitarUltimaFila()
                FacturaExternaDAL.guardarFactura(Me)
            Else
                FacturaExternaDAL.guardarFactura(Me)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub buscarPrecioCUPS(ByRef dt As DataTable, grupo As Integer)
        Dim params As New List(Of String)
        params.Add(CodigoContrato)
        params.Add(dt.Rows(dt.Rows.Count - 2).Item("Código"))
        params.Add(grupo)
        dt.Rows(dt.Rows.Count - 2).Item("Precio unitario") = (General.getValorConsulta(ConsultasAsis.FACTURA_CONTRATO_PRECIO_CUPS, params))
    End Sub
    Public Sub buscarPrecioMed(ByRef dt As DataTable)
        Dim params As New List(Of String)
        params.Add(CodigoContrato)
        params.Add(dt.Rows(dt.Rows.Count - 2).Item("Código"))
        dt.Rows(dt.Rows.Count - 2).Item("Precio unitario") = (General.getValorConsulta(ConsultasAsis.FACTURA_CONTRATO_PRECIO_MED, params))
    End Sub
    Public Overrides Sub calcularFechas()
        Dim params As New List(Of String)
        params.Add(CodigoContrato)
        params.Add(fechaFactura.Date.ToShortDateString)
        fechaVencimiento = CDate(General.getValorConsulta(ConsultasAsis.FACTURA_CONTRATO_FECHA_VENCIMIENTO, params))
    End Sub
    Public Overrides Sub imprimirFactura()
        Try
            Dim ruta, nombreArchivo As String
            Dim reporte As New ftp_reportes
            Dim params As New List(Of String)
            params.Add(FuncionesContables.Convertir_Numero(totalFactura))
            nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(nombrePDF, codigoFactura, New rptFacturaExterna,
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
    Public Sub quitarUltimaFila()
        dtParaclinicos.Rows.RemoveAt(dtParaclinicos.Rows.Count - 1)
        dtHemoderivados.Rows.RemoveAt(dtHemoderivados.Rows.Count - 1)
        dtProcedimientos.Rows.RemoveAt(dtProcedimientos.Rows.Count - 1)
        dtMedicamentos.Rows.RemoveAt(dtMedicamentos.Rows.Count - 1)
        dtInsumos.Rows.RemoveAt(dtInsumos.Rows.Count - 1)
    End Sub

End Class
