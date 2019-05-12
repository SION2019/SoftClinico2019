Public Class FacturaAtencionAmbulancia
    Inherits FacturaAtencion

    Public Property precioTraslado As Decimal
    Public Property cantidadKMS As Decimal
    Public Property precioKMS As Decimal
    Public Property cantidadHH As Decimal
    Public Property precioHH As Decimal
    Public Property precioRN As Decimal
    Public Property dtTraslado As New DataTable
    Public Property sqlCargarTraslado As String
    Public Property observacion As String
    Public Sub New()
        sqlCargarTraslado = ConsultasAsis.FACTURA_TRASLADO_CARGAR
        sqlBuscarContrato = ConsultasAsis.FACTURA_ATENCION_AMB_CLIENTE_BUSCAR
        sqlbuscarRegistroAFacturar = ConsultasAsis.FACTURA_ATENCION_AMB_REGISTRO_A_FACTURAR_BUSCAR
        sqlCargarRegistroAFacturar = ConsultasAsis.FACTURA_ATENCION_AMB_REGISTRO_A_FACTURAR_CARGAR
        sqlCargarContrato = ConsultasAsis.FACTURA_ATENCION_AMB_CLIENTE_CARGAR
        sqlBuscarFactura = ConsultasAsis.FACTURA_ATENCION_AMB_BUSCAR
        sqlCargarFactura = ConsultasAsis.FACTURA_ATENCION_AMB_CARGAR
        sqlAnularFactura = ConsultasAsis.FACTURA_ANULAR
        GeneralAsis.crearTablaFacturaAmb(dtTraslado)
        nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_AMBULANCIA
        tipo = 3
    End Sub
    Public Sub verificarTotales()

    End Sub

    Public Function verificarClausulas() As String
        Dim mensaje As String = ""
        Dim params As New List(Of String)
        params.Add(CodigoContrato)
        If Not String.IsNullOrEmpty(codigoFactura) Then Return mensaje
        If General.getEstadoVF(ConsultasAsis.FACTURA_ATENCION_AMB_FECHA_CONTRATO_VERIFICAR, params) = False Then
            mensaje = Mensajes.FECHA_FIN_CONTRATO
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
            dtTraslado.Clear()
            cargarFactura()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub cargarFactura()
        cargarTraslado()
    End Sub
    Public Sub cargarTraslado()
        Try
            Dim params As New List(Of String)
            params.Add(registroAFacturar)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(sqlCargarTraslado, params, dtTraslado)
        Catch ex As Exception
            General.manejoErrores(ex)

        End Try

    End Sub

    Public Overrides Sub guardarFactura()
        Try
            FacturaAmbulanciaDAL.guardarFactura(Me)
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
            Dim ruta, nombreArchivo As String
            Dim reporte As New ftp_reportes
            Dim params As New List(Of String)
            params.Add(FuncionesContables.Convertir_Numero(totalFactura))
            nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(nombrePDF, codigoFactura, New rptFacturaAmbulancia,
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
