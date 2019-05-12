Public Class Nomina

    Public Property sqlBuscarNomina As String
    Public Property sqlCargarNomina As String
    Public Property sqlCargarNominaEmpleado As String
    Public Property sqlCargarNominaEmpleadoNueva As String
    Public Property sqlCargarCausacionNominaNueva As String
    Public Property sqlCargarCausacionNomina As String
    Public Property sqlAnularNomina As String
    Public Property sqlAnularNominaCausacion As String
    Public Property sqlCambiarEstadoPago As String
    Public Property sqlFechaNomina As String
    Public Property sqlVerificaTotalNomina As String
    Public Property sqlVerificaTotalNominaMes As String
    Public Property sqlVerificaTotalNominaAnterior As String
    Public Property codigo As String
    Public Property mes As Date
    Public Property codigoEP As Integer
    Public Property opcion As Integer
    Public Property hasta As Date
    Public Property fecha
    Public Property aplicaHuellero As Boolean
    Public Property aplicaParafiscales As Boolean
    Public Property causada As Boolean
    Public Property dtEmpleados As New DataTable
    Public Property dtCausacion As New DataTable
    Public Property dtCausacionDif As New DataTable
    Public Property dsCausacion As New DataSet
    Public Property totalDebito As Double
    Public Property totalCredito As Double
    Public Property diferencia As Double
    Public Property filtro As BindingSource = New BindingSource
    Public Property fechaDoc As Date
    Public Property comprobante As String

    Public Sub New()
        sqlBuscarNomina = ConsultasNom.NOMINA_BUSCAR
        sqlCargarNomina = ConsultasNom.NOMINA_CARGAR
        sqlCargarNominaEmpleado = ConsultasNom.NOMINA_DETALLE_CARGAR
        sqlCargarNominaEmpleadoNueva = ConsultasNom.NOMINA_NUEVA_CARGAR
        sqlCargarCausacionNominaNueva = ConsultasNom.NOMINA_CAUSAR
        sqlAnularNomina = ConsultasNom.NOMINA_ANULAR
        sqlVerificaTotalNomina = ConsultasNom.NOMINA_TOTAL_VERIFICAR
        sqlCargarCausacionNomina = ConsultasNom.NOMINA_CAUSACION_CARGAR
        sqlAnularNominaCausacion = ConsultasNom.NOMINA_CAUSACION_ANULAR
        sqlVerificaTotalNominaMes = ConsultasNom.NOMINA_TOTAL_MES_VERIFICAR
        sqlVerificaTotalNominaAnterior = ConsultasNom.NOMINA_ANTERIOR_MES_VERIFICAR
        sqlCambiarEstadoPago = ConsultasNom.NOMINA_CAMBIAR_PAGO
        dtCausacion.TableName = "Table" : dsCausacion.Tables.Add(dtCausacion)
        dtCausacionDif.TableName = "Table1" : dsCausacion.Tables.Add(dtCausacionDif)
    End Sub


    Public Function anular()
        Try
            Dim params As New List(Of String)
            params.Add(codigo)
            params.Add(SesionActual.idUsuario)
            Return General.getEstadoVF(sqlAnularNomina, params)
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function

    Public Sub cargarDetalle()
        Try
            dtEmpleados.Clear()
            Dim params As New List(Of String)
            params.Add(codigo)
            General.llenarTabla(sqlCargarNominaEmpleado, params, dtEmpleados)
            filtro.DataSource = dtEmpleados
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

    Public Sub cargarCausacionNueva()
        Try
            Dim params As New List(Of String)
            params.Add(codigo)
            params.Add(aplicaParafiscales)
            General.llenarDataSet(sqlCargarCausacionNominaNueva, params, dsCausacion)
            calcularTotalesCausacion()
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Public Sub cargarCausacion()
        Try
            dtCausacion.Clear()
            Dim params As New List(Of String)
            params.Add(comprobante)
            General.llenarTabla(sqlCargarCausacionNomina, params, dtCausacion)
            calcularTotalesCausacion()
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Public Sub calcularTotalesCausacion()
        totalDebito = If(IsDBNull(dtCausacion.Compute("SUM(Débito)", "")), 0, dtCausacion.Compute("SUM(Débito)", ""))
        totalCredito = If(IsDBNull(dtCausacion.Compute("SUM(Crédito)", "")), 0, dtCausacion.Compute("SUM(Crédito)", ""))
        diferencia = totalDebito - totalCredito
    End Sub

    Public Sub cargarDetalleNuevo()
        Try
            dtEmpleados.Clear()
            Dim params As New List(Of String)
            params.Add(Format(mes, Constantes.FORMATO_FECHA_GEN))
            params.Add(Format(hasta, Constantes.FORMATO_FECHA_GEN))
            params.Add(aplicaHuellero)
            params.Add(SesionActual.idEmpresa)
            params.Add(codigoEP)
            params.Add(opcion)
            General.llenarTabla(sqlCargarNominaEmpleadoNueva, params, dtEmpleados)
            filtro.DataSource = dtEmpleados
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

    Public Function verificaNominaTotal()
        Try
            Dim params As New List(Of String)
            params.Add(codigo)
            Return General.getEstadoVF(sqlVerificaTotalNomina, params)
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Function
    Public Function verificaNominaTotalMes()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(codigoEP)
        params.Add(Format(mes, Constantes.FORMATO_FECHA_GEN))
        Return General.getEstadoVF(sqlVerificaTotalNominaMes, params)
    End Function

    Public Sub guardar()
        Try
            dtEmpleados.AcceptChanges()
            For i = 0 To dtEmpleados.Rows.Count - 2
                If Not dtEmpleados.Rows(i).Item("Pago") Then
                    dtEmpleados.Rows(i).Delete()
                End If
            Next
            dtEmpleados.AcceptChanges()
            NominaDAL.guardar(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub guardarCausacion()
        Try
            NominaDAL.guardarCausacion(Me)
            causada = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub anularCausacion()
        Try
            Dim params As New List(Of String)
            params.Add(comprobante)
            params.Add(SesionActual.idUsuario)
            General.ejecutarSQL(sqlAnularNominaCausacion, params)
            comprobante = ""
            fechaDoc = Now
            causada = False
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

    Public Function verificaNominaAnterior() As Boolean
        Try
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            params.Add(Format(mes, Constantes.FORMATO_FECHA_GEN))
            Return General.getEstadoVF(sqlVerificaTotalNominaAnterior, params)
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Function

    Public Sub cambiarPago(vCodigoContrato As Integer, value As Boolean)
        Try
            Dim params As New List(Of String)
            params.Add(codigo)
            params.Add(vCodigoContrato)
            params.Add(value)
            params.Add(SesionActual.idUsuario)
            General.ejecutarSQL(sqlCambiarEstadoPago, params)
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

    End Sub
End Class
