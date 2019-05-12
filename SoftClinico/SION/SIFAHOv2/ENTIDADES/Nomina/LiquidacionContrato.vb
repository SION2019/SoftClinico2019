Public Class LiquidacionContrato
    Public Property codigoContrato As String
    Public Property dtCuentas As DataTable
    Public Property dtCxp As DataTable
    Public Property dtLiquidacion As DataTable
    Public Property comprobante As String
    Public Property codigoPuc As Integer
    Public Property idEmpresa As Integer
    Public Property fecha As Date
    Public Property codigoDocumento As Integer
    Public Property cesantias As Boolean
    Public Property intCesantias As Boolean
    Public Property vacaciones As Boolean
    Public Property primas As Boolean
    Public Property liquidarTodo As Boolean
    Public Property usuario As Integer

    Sub New()
        dtLiquidacion = New DataTable
        dtCuentas = New DataTable
        dtCxp = New DataTable
        dtLiquidacion.Columns.Add("N° Contrato", Type.GetType("System.Int32"))
        dtLiquidacion.Columns.Add("Aux.Transporte", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Salario", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Primas", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Cesantías", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Vacaciones", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Int.Cesantías", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Base de Liquidación", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Descuentos", Type.GetType("System.Double"))
        dtLiquidacion.Columns.Add("Identificacion", Type.GetType("System.String"))
        dtLiquidacion.Columns.Add("Neto a Pagar", Type.GetType("System.Int32"))

        dtCuentas.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCuentas.Columns.Add("puc", Type.GetType("System.Int32"))
        dtCuentas.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("Debito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Credito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Orden", Type.GetType("System.Int32"))

        dtCxp.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCxp.Columns.Add("idEmpresa", Type.GetType("System.Int32"))
        dtCxp.Columns.Add("codigoDocumento", Type.GetType("System.Int32"))
        dtCxp.Columns.Add("codigoFactura", Type.GetType("System.String"))
        dtCxp.Columns.Add("idProveedor", Type.GetType("System.Int32"))
        dtCxp.Columns.Add("fechaRecibo", Type.GetType("System.DateTime"))
        dtCxp.Columns.Add("fechaVence", Type.GetType("System.DateTime"))
        dtCxp.Columns.Add("fechaDoc", Type.GetType("System.DateTime"))
        dtCxp.Columns.Add("valorDebito", Type.GetType("System.Double"))
        dtCxp.Columns.Add("valorCredito", Type.GetType("System.Double"))
        dtCxp.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub
    Sub llenarDetalle(ByVal comprobante As String,
                    ByVal codigoPuc As Integer,
                    ByVal cuenta As String,
                    ByVal valorColumna As String,
                    Optional posicionValorColumna As Boolean = False)
        dtCuentas.Rows.Add()
        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("comprobante") = comprobante
        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("puc") = codigoPuc
        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Cuenta") = cuenta
        If posicionValorColumna = False Then
            dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Debito") = valorColumna
            dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Credito") = 0
        Else
            dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Debito") = 0
            dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Credito") = valorColumna
        End If
        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Orden") = dtCuentas.Rows.Count - 1
    End Sub
    Public Sub llenarCuentas()
        dtLiquidacion.AcceptChanges()
        For indiceLiquidacion = 0 To dtLiquidacion.Rows.Count - 1
            comprobante = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, Constantes.COMPROBANTE_DE_CAUSACION)
            codigoPuc = FuncionesContables.obtenerPucActivo
            dtCxp.Clear()
            dtCuentas.Clear()
            dtCxp.Rows.Add()
            dtCxp.Rows(0).Item("comprobante") = comprobante
            dtCxp.Rows(0).Item("idEmpresa") = idEmpresa
            dtCxp.Rows(0).Item("codigoDocumento") = codigoDocumento
            dtCxp.Rows(0).Item("codigoFactura") = dtLiquidacion.Rows(indiceLiquidacion).Item("N° Contrato")
            dtCxp.Rows(0).Item("idProveedor") = dtLiquidacion.Rows(indiceLiquidacion).Item("Identificacion")
            dtCxp.Rows(0).Item("fechaRecibo") = fecha
            dtCxp.Rows(0).Item("fechaVence") = fecha
            dtCxp.Rows(0).Item("fechaDoc") = fecha
            dtCxp.Rows(0).Item("valorDebito") = dtLiquidacion.Rows(indiceLiquidacion).Item("Neto a Pagar")
            dtCxp.Rows(0).Item("valorCredito") = dtLiquidacion.Rows(indiceLiquidacion).Item("Neto a Pagar")
            dtCxp.Rows(0).Item("usuario") = usuario

            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_VACACIONES, dtLiquidacion.Rows(indiceLiquidacion).Item("Vacaciones"))
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_PRIMAS, dtLiquidacion.Rows(indiceLiquidacion).Item("Primas"))
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_INT_CESANTIAS, dtLiquidacion.Rows(indiceLiquidacion).Item("Int.Cesantías"))
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_CESANTIAS, dtLiquidacion.Rows(indiceLiquidacion).Item("Cesantías"))
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_VACACIONES_CONT, dtLiquidacion.Rows(indiceLiquidacion).Item("Vacaciones"), True)
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_PRIMAS_CONT, dtLiquidacion.Rows(indiceLiquidacion).Item("Primas"), True)
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_INT_CESANTIAS_CONT, dtLiquidacion.Rows(indiceLiquidacion).Item("Int.Cesantías"), True)
            llenarDetalle(comprobante, codigoPuc, Constantes.CUENTA_CESANTIAS_CONT, dtLiquidacion.Rows(indiceLiquidacion).Item("Cesantías"), True)

            Try
                Using dbCommand As New SqlCommand
                    dbCommand.Connection = FormPrincipal.cnxion
                    dbCommand.CommandType = CommandType.StoredProcedure
                    dbCommand.CommandText = "PROC_CARTERA_CXP_CREAR"
                    dbCommand.Parameters.Add(New SqlParameter("@carteracxp", SqlDbType.Structured)).Value = dtCxp
                    dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = dtCuentas
                    dbCommand.ExecuteNonQuery()
                    FuncionesContables.aumentarConsecutivo(SesionActual.idEmpresa, Constantes.COMPROBANTE_DE_CAUSACION)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        Next
    End Sub
End Class
