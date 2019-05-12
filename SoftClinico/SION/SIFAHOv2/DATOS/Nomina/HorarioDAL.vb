Imports System.Data.SqlClient
Public Class HorarioDAL

    Public Function validarmes(ByVal pHorario As Horario) As Integer
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_HORARIO_VALIDAR_MES"

                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = pHorario.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = pHorario.fecha
                dbCommand.Parameters.Add(New SqlParameter("@Punto", SqlDbType.Int)).Value = pHorario.punto
                dbCommand.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                'dbCommand.Parameters.Add(New SqlParameter("@Area", SqlDbType.Int)).Value = pHorario.area
                'dbCommand.Parameters.Add(New SqlParameter("@Cargo", SqlDbType.Int)).Value = pHorario.cargo

                Return CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function validarMesHorario(ByVal pHorario As HorarioLaboral) As Integer
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_HORARIO_LABORAL_VALIDAR_MES"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = pHorario.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = pHorario.fecha
                dbCommand.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa

                Return CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub guardarHorario(pHorario As HorarioLaboral)

        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_HORARIO_LABORAL_CREAR"
                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = pHorario.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = pHorario.fecha
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                dbCommand.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@tablaTotal", SqlDbType.Structured)).Value = pHorario.dtHorarioTotalAGuardar
                dbCommand.Parameters.Add(New SqlParameter("@tablaDetalle", SqlDbType.Structured)).Value = pHorario.dtHorarioAGuardar
                pHorario.codigo = CType(dbCommand.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardar(pHorario As Horario)

        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_HORARIO_CREAR"

                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = pHorario.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = pHorario.fecha
                dbCommand.Parameters.Add(New SqlParameter("@Punto", SqlDbType.Int)).Value = pHorario.punto
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = pHorario.usuario
                dbCommand.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.Int)).Value = pHorario.empresa
                dbCommand.Parameters.Add(New SqlParameter("@tabla_detalle", SqlDbType.Structured)).Value = pHorario.dtDetalle
                dbCommand.Parameters.Add(New SqlParameter("@tabla_puntos", SqlDbType.Structured)).Value = pHorario.dtPuntoDias
                dbCommand.Parameters.Add(New SqlParameter("@tabla_puntos_eliminar", SqlDbType.Structured)).Value = pHorario.dtEliminarPunto
                pHorario.codigo = CType(dbCommand.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub guardarNovedades(phorario As Horario)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_HORARIO_NOVEDAD_CREAR"
                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = phorario.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = phorario.fechaNovedad
                dbCommand.Parameters.Add(New SqlParameter("@Id_Empleado", SqlDbType.NVarChar)).Value = phorario.Id_Empleado
                dbCommand.Parameters.Add(New SqlParameter("@Punto", SqlDbType.Int)).Value = phorario.punto
                dbCommand.Parameters.Add(New SqlParameter("@ConvencionAnt", SqlDbType.NVarChar)).Value = phorario.ConvencionAnt
                dbCommand.Parameters.Add(New SqlParameter("@ConvencionNue", SqlDbType.NVarChar)).Value = phorario.ConvencionNue
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar)).Value = phorario.usuario
                phorario.codigo = CType(dbCommand.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
