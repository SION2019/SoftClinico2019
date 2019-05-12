Public Class FacturaAtencionAsistencial
    Inherits FacturaAtencion
    Public Property dtEstancias As New DataTable
    Public Property dtTraslados As New DataTable
    Public Property dtOxigenos As New DataTable
    Public Property dtParaclinicos As New DataTable
    Public Property dtHemoderivados As New DataTable
    Public Property dtProcedimientos As New DataTable
    Public Property dtMedicamentos As New DataTable
    Public Property dtInsumos As New DataTable
    Public Property sqlPrecargarEstancias As String
    Public Property sqlPrecargarTraslados As String
    Public Property sqlPrecargarOxigenos As String
    Public Property sqlPrecargarParaclinicos As String
    Public Property sqlPrecargarHemoderivados As String
    Public Property sqlPrecargarProcedimientos As String
    Public Property sqlPrecargarMedicamentos As String
    Public Property sqlPrecargarMedicamentosCTC As String
    Public Property sqlPrecargarInsumos As String
    Public Property sqlPostCargarEstancias As String
    Public Property sqlPostCargarTraslados As String
    Public Property sqlPostCargarOxigenos As String
    Public Property sqlPostCargarParaclinicos As String
    Public Property sqlPostCargarHemoderivados As String
    Public Property sqlPostCargarProcedimientos As String
    Public Property sqlPostCargarMedicamentos As String
    Public Property sqlPostCargarMedicamentosCTC As String
    Public Property sqlPostCargarInsumos As String
    Public Property totalEstancias As Double
    Public Property totalTraslados As Double
    Public Property totalOxigenos As Double
    Public Property totalParaclinicos As Double
    Public Property totalHemoderivados As Double
    Public Property totalProcedimientos As Double
    Public Property totalMedicamentos As Double
    Public Property totalInsumos As Double
    Public Property valorCeroEnEstancias As Boolean
    Public Property valorCeroEnTraslados As Boolean
    Public Property valorCeroEnOxigenos As Boolean
    Public Property valorCeroEnParaclinicos As Boolean
    Public Property valorCeroEnHemoderivados As Boolean
    Public Property valorCeroEnProcedimientos As Boolean
    Public Property valorCeroEnMedicamentos As Boolean
    Public Property valorCeroEnInsumos As Boolean
    Public Property actualizaEstancias As Boolean
    Public Property actualizaTraslados As Boolean
    Public Property actualizaOxigenos As Boolean
    Public Property actualizaParaclinicos As Boolean
    Public Property actualizaHemoderivados As Boolean
    Public Property actualizaProcedimientos As Boolean
    Public Property actualizaMedicamentos As Boolean
    Public Property actualizaInsumos As Boolean
    Public Property nombreCertificadoPDF As String
    Public Property moduloReporte As Integer
    Public Sub New()
        consultasCargarDatos()
        consultasCargarDatosFactura()
        sqlPrecargarTraslados = ConsultasAsis.FACTURA_TRASLADOS_CARGAR
        sqlCargarContrato = ConsultasAsis.FACTURA_ATENCION_CLIENTE_CARGAR
        sqlBuscarFactura = ConsultasAsis.FACTURA_ATENCION_BUSCAR
        sqlCargarFactura = ConsultasAsis.FACTURA_ATENCION_CARGAR
        sqlAnularFactura = ConsultasAsis.FACTURA_ANULAR
        GeneralAsis.crearTablaFactura(dtEstancias)
        GeneralAsis.crearTablaFactura(dtTraslados)
        GeneralAsis.crearTablaFactura(dtOxigenos)
        GeneralAsis.crearTablaFactura(dtParaclinicos)
        GeneralAsis.crearTablaFactura(dtHemoderivados)
        GeneralAsis.crearTablaFactura(dtProcedimientos)
        GeneralAsis.crearTablaFactura(dtMedicamentos)
        GeneralAsis.crearTablaFactura(dtInsumos)
    End Sub

    Public Overridable Sub consultasCargarDatos()
        sqlPrecargarEstancias = ConsultasAsis.FACTURA_ESTANCIAS_CARGAR
        sqlPrecargarOxigenos = ConsultasAsis.FACTURA_OXIGENO_CARGAR
        sqlPrecargarParaclinicos = ConsultasAsis.FACTURA_PARACLINICOS_CARGAR
        sqlPrecargarHemoderivados = ConsultasAsis.FACTURA_HEMODERIVADOS_CARGAR
        sqlPrecargarMedicamentos = ConsultasAsis.FACTURA_MEDICAMENTOS_CARGAR
        sqlPrecargarMedicamentosCTC = ConsultasAsis.FACTURA_CTC_MEDICAMENTOS_CARGAR
        sqlPrecargarProcedimientos = ConsultasAsis.FACTURA_PROCEDIMIENTOS_CARGAR
        sqlPrecargarInsumos = ConsultasAsis.FACTURA_INSUMOS_CARGAR
        sqlBuscarContrato = ConsultasAsis.FACTURA_ATENCION_CLIENTE_BUSCAR
        sqlbuscarRegistroAFacturar = ConsultasAsis.FACTURA_ATENCION_REGISTRO_A_FACTURAR_BUSCAR
        sqlCargarRegistroAFacturar = ConsultasAsis.FACTURA_ATENCION_REGISTRO_A_FACTURAR_CARGAR
    End Sub
    Public Sub consultasCargarDatosFactura()
        sqlPostCargarEstancias = ConsultasAsis.FACTURA_ESTANCIAS_POSTCARGAR
        sqlPostCargarOxigenos = ConsultasAsis.FACTURA_OXIGENO_POSTCARGAR
        sqlPostCargarParaclinicos = ConsultasAsis.FACTURA_PARACLINICOS_POSTCARGAR
        sqlPostCargarHemoderivados = ConsultasAsis.FACTURA_HEMODERIVADOS_POSTCARGAR
        sqlPostCargarMedicamentos = ConsultasAsis.FACTURA_MEDICAMENTOS_POSTCARGAR
        sqlPostCargarProcedimientos = ConsultasAsis.FACTURA_PROCEDIMIENTOS_POSTCARGAR
        sqlPostCargarInsumos = ConsultasAsis.FACTURA_INSUMOS_POSTCARGAR
        sqlPostCargarTraslados = ConsultasAsis.FACTURA_TRASLADOS_POSTCARGAR
    End Sub

    Public Function verificarTotales() As String
        Dim mensaje As String = ""
        valorCeroEnEstancias = validarValorEnCero(dtEstancias)
        valorCeroEnTraslados = validarValorEnCero(dtTraslados)
        valorCeroEnOxigenos = validarValorEnCero(dtOxigenos)
        valorCeroEnParaclinicos = validarValorEnCero(dtParaclinicos)
        valorCeroEnHemoderivados = validarValorEnCero(dtHemoderivados)
        valorCeroEnProcedimientos = validarValorEnCero(dtProcedimientos)
        valorCeroEnMedicamentos = validarValorEnCero(dtMedicamentos)
        valorCeroEnInsumos = validarValorEnCero(dtInsumos)
        If valorCeroEnEstancias Then
            mensaje = "-Estancias." & vbCrLf
        End If
        If valorCeroEnTraslados Then
            mensaje = mensaje & "-Traslados." & vbCrLf
        End If
        If valorCeroEnOxigenos Then
            mensaje = mensaje & "-Oxígenos." & vbCrLf
        End If
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


    Private Function validarValorEnCero(dt As DataTable) As Boolean
        If dt.Select("Total=0", "").Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Overridable Sub nombreReportePDF()
        If CTC = True Then
            nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_CTC
            tipo = 1
        Else
            nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA
            tipo = 0
        End If
        nombreCertificadoPDF = ConstantesHC.NOMBRE_PDF_FACTURA_CERTIFICADO
        moduloReporte = Constantes.REPORTE_HC
    End Sub


    Public Overrides Sub cargarDetalle()
        Try
            limpiarTablas()
            nombreReportePDF()
            If Not String.IsNullOrEmpty(codigoFactura) Then
                cargarFactura()
            Else
                If CTC = True Then
                    preCargarMedicamentosCTC()
                    totalFactura = If(IsDBNull(dtMedicamentos.Compute("SUM(Total)", "")), 0, dtMedicamentos.Compute("SUM(Total)", ""))
                Else
                    precargarEstancias()
                    precargarTraslados()
                    precargarOxigenos()
                    precargarParaclinicos()
                    precargarHemoderivados()
                    precargarProcedimientos()
                    preCargarMedicamentos()
                    precargarInsumos()
                    calcularTotal()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub limpiarTablas()
        dtEstancias.Clear()
        dtTraslados.Clear()
        dtOxigenos.Clear()
        dtParaclinicos.Clear()
        dtHemoderivados.Clear()
        dtProcedimientos.Clear()
        dtMedicamentos.Clear()
        dtInsumos.Clear()
    End Sub

    Private Sub calcularTotal()
        totalEstancias = If(IsDBNull(dtEstancias.Compute("SUM(Total)", "")), 0, dtEstancias.Compute("SUM(Total)", ""))
        totalTraslados = If(IsDBNull(dtTraslados.Compute("SUM(Total)", "")), 0, dtTraslados.Compute("SUM(Total)", ""))
        totalOxigenos = If(IsDBNull(dtOxigenos.Compute("SUM(Total)", "")), 0, dtOxigenos.Compute("SUM(Total)", ""))
        totalParaclinicos = If(IsDBNull(dtParaclinicos.Compute("SUM(Total)", "")), 0, dtParaclinicos.Compute("SUM(Total)", ""))
        totalHemoderivados = If(IsDBNull(dtHemoderivados.Compute("SUM(Total)", "")), 0, dtHemoderivados.Compute("SUM(Total)", ""))
        totalProcedimientos = If(IsDBNull(dtProcedimientos.Compute("SUM(Total)", "")), 0, dtProcedimientos.Compute("SUM(Total)", ""))
        totalMedicamentos = If(IsDBNull(dtMedicamentos.Compute("SUM(Total)", "")), 0, dtMedicamentos.Compute("SUM(Total)", ""))
        totalInsumos = If(IsDBNull(dtInsumos.Compute("SUM(Total)", "")), 0, dtInsumos.Compute("SUM(Total)", ""))
        totalFactura = totalEstancias + totalTraslados + totalOxigenos + totalParaclinicos + totalHemoderivados _
                     + totalProcedimientos + totalMedicamentos + totalInsumos
    End Sub

    Public Sub precargarEstancias()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarEstancias, params, dtEstancias)
    End Sub
    Public Sub precargarTraslados()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarTraslados, params, dtTraslados)
    End Sub
    Public Sub precargarOxigenos()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarOxigenos, params, dtOxigenos)
    End Sub
    Public Sub precargarParaclinicos()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarParaclinicos, params, dtParaclinicos)
    End Sub
    Public Sub precargarHemoderivados()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarHemoderivados, params, dtHemoderivados)
    End Sub
    Public Sub precargarProcedimientos()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarProcedimientos, params, dtProcedimientos)
    End Sub
    Public Sub precargarInsumos()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarInsumos, params, dtInsumos)
    End Sub

    Public Sub preCargarMedicamentos()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        params.Add(Nothing)
        params.Add(False)
        General.llenarTabla(sqlPrecargarMedicamentos, params, dtMedicamentos)
    End Sub
    Public Sub preCargarMedicamentosCTC()
        Dim params As New List(Of String)
        params.Add(registroAFacturar)
        General.llenarTabla(sqlPrecargarMedicamentosCTC, params, dtMedicamentos)

    End Sub
    Public Sub postCargarMedicamentos()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarMedicamentos, params, dtMedicamentos)
    End Sub

    Public Sub postCargarEstancias()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarEstancias, params, dtEstancias)
    End Sub
    Public Sub postCargarTraslados()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarTraslados, params, dtTraslados)
    End Sub
    Public Sub postCargarOxigenos()
        Dim params As New List(Of String)
        params.Add(codigoFactura)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(sqlPostCargarOxigenos, params, dtOxigenos)
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
        postCargarEstancias()
        postCargarTraslados()
        postCargarOxigenos()
        postCargarParaclinicos()
        postCargarHemoderivados()
        postCargarProcedimientos()
        postCargarMedicamentos()
        postCargarInsumos()
        calcularTotal()
    End Sub
    Public Overrides Sub guardarFactura()
        Try
            FacturaAtencionAsistencialDAL.guardarFactura(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub calcularFechas()
        Dim params As New List(Of String)
        params.Add(CodigoContrato)
        params.Add(fechaFactura.Date.ToShortDateString)
        fechaVencimiento = CDate(General.getValorConsulta(ConsultasAsis.FACTURA_CONTRATO_FECHA_VENCIMIENTO, params))
    End Sub
    Public Overrides Sub imprimirFactura()
        Try
            Dim nombreArchivo, ruta As String
            Dim reporte As New ftp_reportes
            nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            ftp_reportes.llamarArchivo(ruta, nombreArchivo, registroAFacturar, nombrePDF)
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
        ftp_reportes.eliminarArchivo(nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        ftp_reportes.eliminarArchivo(nombreCertificadoPDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF)
    End Sub
End Class

