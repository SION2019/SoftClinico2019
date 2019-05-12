Public Class ProgramacionPagoNomina
    Public Property codigoProgramacionPago As Integer
    Public Property dtEgresoDetalle As DataTable
    Public Property dtEgreso As DataTable
    Public Property dtProgramacion As DataTable
    Public Property dtNomina As DataTable
    Public Property comprobante As String
    Public Property codigoPuc As Integer
    Public Property idEmpresa As Integer
    Public Property fecha As Date
    Public Property codigoDocumento As Integer
    Public Property nomina As Integer
    Public Property usuario As Integer
    Public Property numCheque As String

    Sub New()
        dtNomina = New DataTable
        dtEgresoDetalle = New DataTable
        dtEgreso = New DataTable
        dtProgramacion = New DataTable
        dtNomina.Columns.Add("Comprobante", Type.GetType("System.String"))
        dtNomina.Columns.Add("ComprobanteA", Type.GetType("System.String"))
        dtNomina.Columns.Add("Nomina", Type.GetType("System.Int32"))
        dtNomina.Columns.Add("Abono", Type.GetType("System.Double"))
        dtNomina.Columns.Add("IdEmpleado", Type.GetType("System.Int32"))
        dtNomina.Columns.Add("FechaDoc", Type.GetType("System.DateTime"))
        dtNomina.Columns.Add("MedioPago", Type.GetType("System.Int32"))
        dtNomina.Columns.Add("NumCheque", Type.GetType("System.String"))
        dtNomina.Columns.Add("Usuario", Type.GetType("System.Int32"))

        dtEgresoDetalle.Columns.Add("comprobante", Type.GetType("System.String"))
        dtEgresoDetalle.Columns.Add("comprobanteA", Type.GetType("System.String"))
        dtEgresoDetalle.Columns.Add("puc", Type.GetType("System.Int32"))
        dtEgresoDetalle.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtEgresoDetalle.Columns.Add("Debito", Type.GetType("System.Double"))
        dtEgresoDetalle.Columns.Add("Credito", Type.GetType("System.Double"))
        dtEgresoDetalle.Columns.Add("Orden", Type.GetType("System.Int32"))

        dtEgreso.Columns.Add("comprobante", Type.GetType("System.String"))
        dtEgreso.Columns.Add("idEmpresa", Type.GetType("System.Int32"))
        dtEgreso.Columns.Add("idProveedor", Type.GetType("System.Int32"))
        dtEgreso.Columns.Add("codigoFactura", Type.GetType("System.String"))
        dtEgreso.Columns.Add("codigoDocumento", Type.GetType("System.Int32"))
        dtEgreso.Columns.Add("fechaRecibo", Type.GetType("System.DateTime"))
        dtEgreso.Columns.Add("fechaPago", Type.GetType("System.DateTime"))
        dtEgreso.Columns.Add("DetalleMov", Type.GetType("System.String"))
        dtEgreso.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub
    Sub llenarDetalle(ByVal comprobante As String,
                      ByVal comprobanteA As String,
                    ByVal codigoPuc As Integer,
                    ByVal cuenta As String,
                    ByVal valorColumna As String,
                    Optional posicionValorColumna As Boolean = False)
        dtEgresoDetalle.Rows.Add()
        dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("comprobante") = comprobante
        dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("comprobanteA") = comprobanteA
        dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("puc") = codigoPuc
        dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("Cuenta") = cuenta
        If posicionValorColumna = False Then
            dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("Debito") = valorColumna
            dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("Credito") = 0
        Else
            dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("Debito") = 0
            dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("Credito") = valorColumna
        End If
        dtEgresoDetalle.Rows(dtEgresoDetalle.Rows.Count - 1).Item("Orden") = dtEgresoDetalle.Rows.Count - 1
    End Sub
    Sub llenarProgramacion(ByVal comprobante As String,
                      ByVal comprobanteA As String,
                    ByVal nomina As Integer,
                    ByVal abono As Double,
                    ByVal idEmpleado As Integer,
                           ByVal fechaDoc As Date,
                           ByVal medioPago As Integer)

        dtNomina.Rows.Add()
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("comprobante") = comprobante
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("comprobanteA") = comprobanteA
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("Nomina") = nomina
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("Abono") = abono
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("IdEmpleado") = idEmpleado
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("FechaDoc") = fechaDoc
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("MedioPago") = medioPago
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("NumCheque") = numCheque
        dtNomina.Rows(dtNomina.Rows.Count - 1).Item("Usuario") = SesionActual.idUsuario
    End Sub
    Public Sub llenarCuentas()
        dtProgramacion.AcceptChanges()
        For indice = 0 To dtProgramacion.Rows.Count - 1
            comprobante = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, Constantes.COMPROBANTE_DE_EGRESO)
            codigoPuc = FuncionesContables.obtenerPucActivo
            dtEgreso.Clear()
            dtEgresoDetalle.Clear()
            dtEgreso.Rows.Add()
            dtEgreso.Rows(0).Item("Comprobante") = comprobante
            dtEgreso.Rows(0).Item("idEmpresa") = idEmpresa
            dtEgreso.Rows(0).Item("codigoDocumento") = codigoDocumento
            dtEgreso.Rows(0).Item("codigoFactura") = comprobante
            dtEgreso.Rows(0).Item("idProveedor") = dtProgramacion.Rows(indice).Item("Id_Empleado")
            dtEgreso.Rows(0).Item("fechaRecibo") = fecha
            dtEgreso.Rows(0).Item("fechaPago") = fecha
            dtEgreso.Rows(0).Item("DetalleMov") = "Pago de Nomina"
            dtEgreso.Rows(0).Item("Usuario") = usuario
            llenarDetalle(comprobante, dtProgramacion.Rows(indice).Item("Comprobante"), codigoPuc, dtProgramacion.Rows(indice).Item("Cuenta Valor"), dtProgramacion.Rows(indice).Item("Subtotal"))
            llenarDetalle(comprobante, dtProgramacion.Rows(indice).Item("Comprobante"), codigoPuc, dtProgramacion.Rows(indice).Item("Cuenta"), dtProgramacion.Rows(indice).Item("Subtotal"), True)

            llenarProgramacion(comprobante, dtProgramacion.Rows(indice).Item("Comprobante"),
                               nomina, dtProgramacion.Rows(indice).Item("Abono"), dtProgramacion.Rows(indice).Item("Id_Empleado"),
                               fecha, dtProgramacion.Rows(indice).Item("Medio Pago"))


            Try
                Using dbCommand As New SqlCommand
                    dbCommand.Connection = FormPrincipal.cnxion
                    dbCommand.CommandType = CommandType.StoredProcedure
                    dbCommand.CommandText = "PROC_COMPROBANTE_EGRESO_NOMINA_CREAR"
                    dbCommand.Parameters.Add(New SqlParameter("@ComprobanteEgreso", SqlDbType.Structured)).Value = dtEgreso
                    dbCommand.Parameters.Add(New SqlParameter("@EgresoDetalle", SqlDbType.Structured)).Value = dtEgresoDetalle
                    dbCommand.ExecuteNonQuery()
                    FuncionesContables.aumentarConsecutivo(SesionActual.idEmpresa, Constantes.COMPROBANTE_DE_EGRESO)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        Next
    End Sub
End Class
