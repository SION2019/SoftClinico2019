Imports System.Data.SqlClient
Imports Celer

Public Class DeduccionDAL
    Public Shared Sub guardar(ByRef objDeduccion As Deduccion)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = ConsultasNom.DEDUCCION_GUARDAR
                comando.Parameters.Add(New SqlParameter("@CODIGO_DEDUCCION", SqlDbType.Int)).Value = objDeduccion.codigo
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@id_empleado", SqlDbType.Int)).Value = objDeduccion.id_empleado
                comando.Parameters.Add(New SqlParameter("@id_empresa_prestadora", SqlDbType.Int)).Value = objDeduccion.id_empresa_prestadora
                comando.Parameters.Add(New SqlParameter("@TIPO_DEDUCCION", SqlDbType.Int)).Value = objDeduccion.tipo
                comando.Parameters.Add(New SqlParameter("@FECHA_DEDUCCION", SqlDbType.Date)).Value = objDeduccion.Fecha_Deduccion
                comando.Parameters.Add(New SqlParameter("@FECHA_COBRO", SqlDbType.Date)).Value = objDeduccion.Fecha_cobro
                comando.Parameters.Add(New SqlParameter("@VALOR_PRESTAMO", SqlDbType.Float)).Value = objDeduccion.Valor
                comando.Parameters.Add(New SqlParameter("@INTERES", SqlDbType.Float)).Value = objDeduccion.tasa_Interes
                comando.Parameters.Add(New SqlParameter("@TIPO_INTERES", SqlDbType.NChar)).Value = objDeduccion.Tipo_Interes
                comando.Parameters.Add(New SqlParameter("@CUOTAS", SqlDbType.Int)).Value = objDeduccion.cuotas
                comando.Parameters.Add(New SqlParameter("@VALOR_REFINANCIADO", SqlDbType.Float)).Value = objDeduccion.Adicional_Refinanciado
                comando.Parameters.Add(New SqlParameter("@CUOTAS_REFINANCIADAS", SqlDbType.Int)).Value = objDeduccion.cuotas_Refinanciadas
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.Parameters.Add(New SqlParameter("@Tabla_Anticipo", SqlDbType.Structured)).Value = objDeduccion.dtAnticipoDeuda
                comando.Parameters.Add(New SqlParameter("@Tabla_Excepcion", SqlDbType.Structured)).Value = objDeduccion.dtExceptuarMes
                objDeduccion.codigo = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Sub calcularMovimientosConAfectacionesNuevo(objDeduccion As Deduccion)
        Try
            ' Create the SelectCommand.
            objDeduccion.dtMovimientos.Clear()
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objDeduccion.sqlCalcularMovimientos
            command.Parameters.Add(New SqlParameter("@ncuotas", SqlDbType.Int)).Value = objDeduccion.cuotas
            command.Parameters.Add(New SqlParameter("@base", SqlDbType.Float)).Value = objDeduccion.Valor
            command.Parameters.Add(New SqlParameter("@fecha_Nomina", SqlDbType.Date)).Value = objDeduccion.Fecha_cobro
            command.Parameters.Add(New SqlParameter("@Prestamo_Fecha", SqlDbType.Date)).Value = objDeduccion.Fecha_Deduccion
            command.Parameters.Add(New SqlParameter("@Interes_inicial", SqlDbType.Float)).Value = objDeduccion.tasa_Interes
            command.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.NVarChar)).Value = objDeduccion.Tipo_Interes
            command.Parameters.Add(New SqlParameter("@tabla_Anticipo", SqlDbType.Structured)).Value = objDeduccion.dtAnticipoDeuda
            command.Parameters.Add(New SqlParameter("@tabla_Excepcion", SqlDbType.Structured)).Value = objDeduccion.dtExceptuarMes

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)

            adapter.Fill(objDeduccion.dtMovimientos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub
    Public Shared Sub calcularMovimientosConAfectaciones(objDeduccion As Deduccion)
        Try
            ' Create the SelectCommand.
            objDeduccion.dtMovimientos.Clear()
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objDeduccion.sqlCargarHistorico
            command.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objDeduccion.codigo
            command.Parameters.Add(New SqlParameter("@tabla_Anticipo", SqlDbType.Structured)).Value = objDeduccion.dtAnticipoDeuda
            command.Parameters.Add(New SqlParameter("@tabla_Excepcion", SqlDbType.Structured)).Value = objDeduccion.dtExceptuarMes

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)

            adapter.Fill(objDeduccion.dtMovimientos)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
