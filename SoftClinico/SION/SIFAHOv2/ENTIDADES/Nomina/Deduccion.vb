Public Class Deduccion
    Public Property codigo As String
    Public Property id_empleado As Integer
    Public Property codigo_Contrato As Integer
    Public Property estado As Integer
    Public Property Fecha_cobro As Date
    Public Property tipo As Integer
    Public Property id_empresa_prestadora As String
    Public Property Fecha_Deduccion As Date
    Public Property Valor As Double
    Public Property cuotas As Integer
    Public Property mesesHistorial As Integer
    Public Property tasa_Interes As Double
    Public Property Tipo_Interes As String
    Public Property Adicional_Refinanciado As Double
    Public Property cuotas_Refinanciadas As Double
    Public Property dtMovimientos As New DataTable
    Public Property dtAnticipoDeuda As New DataTable
    Public Property dtExceptuarMes As New DataTable
    Public Property dtHistorialPagos As New DataTable
    Public Property sqlBuscarDeduccion As String
    Public Property sqlCargarDeduccion As String
    Public Property sqlAnularDeduccion As String
    Public Property sqlCargarHistorialPagos As String
    Public Property sqlCargarHistorico As String
    Public Property sqlCargarHistoricoNuevo As String
    Public Property sqlCargarAnticipo As String
    Public Property sqlCargarExcepcion As String
    Public Property sqlCalcularMovimientos As String
    Public Property saldo As Integer
    Public Property refinanciar As Boolean
    Public Property anticipo As Boolean
    Public Property exceptuar As Boolean
    Public Property minimaCuota As Double
    Public Property maximaCuota As Double
    Public Property interesMora As Double

    Public Sub New()
        sqlBuscarDeduccion = ConsultasNom.DEDUCCION_BUSCAR
        sqlCargarDeduccion = ConsultasNom.DEDUCCION_CARGAR
        sqlAnularDeduccion = ConsultasNom.DEDUCCION_ANULAR
        sqlCargarHistorico = ConsultasNom.DEDUCCIONES_DETALLE_CARGAR
        sqlCargarHistoricoNuevo = ConsultasNom.DEDUCCION_MOVIMIENTOS_CREAR
        sqlCalcularMovimientos = ConsultasNom.DEDUCCION_MOVIMIENTOS_CALCULAR
        sqlCargarAnticipo = ConsultasNom.DEDUCCION_ANTICIPOS_CARGAR
        sqlCargarExcepcion = ConsultasNom.DEDUCCION_EXCEPCIONES_CARGAR
        sqlCargarHistorialPagos = ConsultasNom.DEDUCCION_HISTORIAL_PAGOS_CARGAR
        mesesHistorial = ConstantesNom.MESES_ESTUDIO_PAGO
    End Sub
    Public Sub cargarHistorialPagos()
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(id_empleado)
        params.Add(mesesHistorial)
        params.Add(Format(Exec.primerDiaMes(Fecha_Deduccion), Constantes.FORMATO_FECHA_GEN))
        General.llenarTabla(sqlCargarHistorialPagos, params, dtHistorialPagos)
        params.Clear()
        If Exec.primerDiaMes(Fecha_Deduccion) >= Exec.primerDiaMes(General.fechaActualServidor) AndAlso codigo = Constantes.VALOR_PREDETERMINADO Then

            params.Add(codigo_Contrato)
            params.Add(SesionActual.idEmpresa)
            params.Add(Format(Fecha_cobro, Constantes.FORMATO_FECHA_GEN))
            dFila = General.cargarItem(ConsultasNom.ESTADO_MENSUAL_TRABAJADOR_CARGAR, params)
            If dFila.ItemArray.Count > 0 Then
                dtHistorialPagos.Rows.Add(Exec.primerDiaMes(General.fechaActualServidor), dFila.Item("TotalDevengado") - dFila.Item("TotalDeducciones"))
            End If
        End If


        calcularCapacidadEndeudamiento()
    End Sub

    Private Sub calcularCapacidadEndeudamiento()
        Dim promedioNetoPago As Double
        If Exec.primerDiaMes(Fecha_Deduccion) >= Exec.primerDiaMes(General.fechaActualServidor) Then
            promedioNetoPago = If(IsDBNull(dtHistorialPagos.Compute("SUM([Neto Pago])", "[Nómina Mes]='" & Exec.primerDiaMes(General.fechaActualServidor) & "'")), 0, dtHistorialPagos.Compute("SUM([Neto Pago])", "[Nómina Mes]='" & Exec.primerDiaMes(General.fechaActualServidor) & "'"))
        Else
            promedioNetoPago = If(IsDBNull(dtHistorialPagos.Compute("SUM([Neto Pago])", "")), 0, dtHistorialPagos.Compute("SUM([Neto Pago])", "")) / mesesHistorial
        End If

        minimaCuota = promedioNetoPago * ConstantesNom.PORCENTAJE_ENDEUDAMIENTO_MINIMO
        maximaCuota = promedioNetoPago * ConstantesNom.PORCENTAJE_ENDEUDAMIENTO_MAXIMO
    End Sub
    Public Sub cargarDeduccionHistorico()
        DeduccionDAL.calcularMovimientosConAfectaciones(Me)
    End Sub
    Public Sub cargarDeduccionAnticipo()
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(sqlCargarAnticipo, params, dtAnticipoDeuda)
    End Sub
    Public Sub cargarDeduccionExcepcion()
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(sqlCargarExcepcion, params, dtExceptuarMes)

    End Sub

    Public Sub anular()
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(SesionActual.idUsuario)
        General.getEstadoVF(sqlAnularDeduccion, params)
    End Sub

    Public Sub calcularMovimientos()
        If codigo = Constantes.VALOR_PREDETERMINADO Then
            calcularMovimientosConAfectacionesNuevo()
        Else
            calcularMovimientosConAfectaciones()
        End If

        calcularSaldo()
    End Sub
    Public Sub calcularSaldo()
        saldo = Valor - If(IsDBNull(dtMovimientos.Compute("SUM([Valor abono])", "Tipo in (5,1,0)")), 0, dtMovimientos.Compute("SUM([Valor abono])", "Tipo in (5,1,0)"))
        saldo = saldo + interesMora
    End Sub
    Public Sub guardar()
        DeduccionDAL.guardar(Me)
    End Sub
    Public Sub calcularMovimientosConAfectacionesNuevo()
        DeduccionDAL.calcularMovimientosConAfectacionesNuevo(Me)
    End Sub
    Public Sub calcularMovimientosConAfectaciones()
        DeduccionDAL.calcularMovimientosConAfectaciones(Me)
    End Sub
End Class
