Imports System.Data.SqlClient
Public Class InfeccionIntrahospitalariaDAL
    Public Function crearInfeccionIH(ByVal objInfeccionIH As InfeccionIH, pUSuario As Integer) As String
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_INFECCION_IH_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@N_Registro", SqlDbType.Int)).Value = objInfeccionIH.nRegistro
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_solicitud", SqlDbType.Date)).Value = objInfeccionIH.fechaSolicitud
                dbCommand.Parameters.Add(New SqlParameter("@Medico", SqlDbType.Int)).Value = objInfeccionIH.medico
                dbCommand.Parameters.Add(New SqlParameter("@Motivo", SqlDbType.NVarChar)).Value = objInfeccionIH.motivo
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_evo", SqlDbType.Int)).Value = objInfeccionIH.codigoEvo
                dbCommand.Parameters.Add(New SqlParameter("@Fumador", SqlDbType.Bit)).Value = objInfeccionIH.fumador
                dbCommand.Parameters.Add(New SqlParameter("@Diabetes", SqlDbType.Bit)).Value = objInfeccionIH.diabetes
                dbCommand.Parameters.Add(New SqlParameter("@Medicamentos", SqlDbType.Bit)).Value = objInfeccionIH.medicamentos
                dbCommand.Parameters.Add(New SqlParameter("@Menor1000", SqlDbType.Bit)).Value = objInfeccionIH.menor1000
                dbCommand.Parameters.Add(New SqlParameter("@Obesidad", SqlDbType.Bit)).Value = objInfeccionIH.obesidad
                dbCommand.Parameters.Add(New SqlParameter("@Inmunosupresion", SqlDbType.Bit)).Value = objInfeccionIH.inmunoSupresion
                dbCommand.Parameters.Add(New SqlParameter("@Prematuro", SqlDbType.Bit)).Value = objInfeccionIH.prematuro
                dbCommand.Parameters.Add(New SqlParameter("@Otros", SqlDbType.Bit)).Value = objInfeccionIH.otros
                dbCommand.Parameters.Add(New SqlParameter("@CVC", SqlDbType.Bit)).Value = objInfeccionIH.cvc
                dbCommand.Parameters.Add(New SqlParameter("@Ventilacion", SqlDbType.Bit)).Value = objInfeccionIH.ventilacion
                dbCommand.Parameters.Add(New SqlParameter("@SondaV", SqlDbType.Bit)).Value = objInfeccionIH.sondaV
                dbCommand.Parameters.Add(New SqlParameter("@SondaN", SqlDbType.Bit)).Value = objInfeccionIH.sondaNasogastrica
                dbCommand.Parameters.Add(New SqlParameter("@Aislamiento", SqlDbType.NChar)).Value = objInfeccionIH.aislamiento
                dbCommand.Parameters.Add(New SqlParameter("@FechaCVC", SqlDbType.Date)).Value = objInfeccionIH.fechaCvc
                dbCommand.Parameters.Add(New SqlParameter("@FechaVent", SqlDbType.Date)).Value = objInfeccionIH.fechaVent
                dbCommand.Parameters.Add(New SqlParameter("@FechaSondaV", SqlDbType.Date)).Value = objInfeccionIH.fechaSondaV
                dbCommand.Parameters.Add(New SqlParameter("@FechaSondaN", SqlDbType.Date)).Value = objInfeccionIH.fechaSondaN
                dbCommand.Parameters.Add(New SqlParameter("@FechaAlta", SqlDbType.Date)).Value = objInfeccionIH.fechaAlta
                dbCommand.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objInfeccionIH.observacion
                dbCommand.Parameters.Add(New SqlParameter("@Inicial", SqlDbType.NVarChar)).Value = objInfeccionIH.inicial
                dbCommand.Parameters.Add(New SqlParameter("@Modificacion1", SqlDbType.NVarChar)).Value = objInfeccionIH.modificacion1
                dbCommand.Parameters.Add(New SqlParameter("@Modificacion2", SqlDbType.NVarChar)).Value = objInfeccionIH.modificacion2
                dbCommand.Parameters.Add(New SqlParameter("@Modificacion3", SqlDbType.NVarChar)).Value = objInfeccionIH.modificacion3
                dbCommand.Parameters.Add(New SqlParameter("@Justificacion1", SqlDbType.NVarChar)).Value = objInfeccionIH.justificacion1
                dbCommand.Parameters.Add(New SqlParameter("@Justificacion2", SqlDbType.NVarChar)).Value = objInfeccionIH.justificacion2
                dbCommand.Parameters.Add(New SqlParameter("@Justificacion3", SqlDbType.NVarChar)).Value = objInfeccionIH.justificacion3
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro1", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro1
                dbCommand.Parameters.Add(New SqlParameter("@Muestra1", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra1
                dbCommand.Parameters.Add(New SqlParameter("@Germen1", SqlDbType.NVarChar)).Value = objInfeccionIH.germen1
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro2", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro2
                dbCommand.Parameters.Add(New SqlParameter("@Muestra2", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra2
                dbCommand.Parameters.Add(New SqlParameter("@Germen2", SqlDbType.NVarChar)).Value = objInfeccionIH.germen2
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro3", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro3
                dbCommand.Parameters.Add(New SqlParameter("@Muestra3", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra3
                dbCommand.Parameters.Add(New SqlParameter("@Germen3", SqlDbType.NVarChar)).Value = objInfeccionIH.germen3
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro4", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro4
                dbCommand.Parameters.Add(New SqlParameter("@Muestra4", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra4
                dbCommand.Parameters.Add(New SqlParameter("@Germen4", SqlDbType.NVarChar)).Value = objInfeccionIH.germen4
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro5", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro5
                dbCommand.Parameters.Add(New SqlParameter("@Muestra5", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra5
                dbCommand.Parameters.Add(New SqlParameter("@Germen5", SqlDbType.NVarChar)).Value = objInfeccionIH.germen5
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro6", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro6
                dbCommand.Parameters.Add(New SqlParameter("@Muestra6", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra6
                dbCommand.Parameters.Add(New SqlParameter("@Germen6", SqlDbType.NVarChar)).Value = objInfeccionIH.germen6
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_analisis", SqlDbType.Date)).Value = objInfeccionIH.fechaAnalisis
                dbCommand.Parameters.Add(New SqlParameter("@detalle_infeccion", SqlDbType.Structured)).Value = objInfeccionIH.dtRespuestas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                objInfeccionIH.codigoSolicitud = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objInfeccionIH.codigoSolicitud
    End Function

    Public Sub actualizarInfeccionIH(ByVal objInfeccionIH As InfeccionIH, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_INFECCION_IH_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_Solicitud", SqlDbType.Int)).Value = objInfeccionIH.codigoSolicitud
                dbCommand.Parameters.Add(New SqlParameter("@N_Registro", SqlDbType.Int)).Value = objInfeccionIH.nRegistro
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_solicitud", SqlDbType.Date)).Value = objInfeccionIH.fechaSolicitud
                dbCommand.Parameters.Add(New SqlParameter("@Medico", SqlDbType.Int)).Value = objInfeccionIH.medico
                dbCommand.Parameters.Add(New SqlParameter("@Motivo", SqlDbType.NVarChar)).Value = objInfeccionIH.motivo
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_evo", SqlDbType.Int)).Value = objInfeccionIH.codigoEvo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_analisis", SqlDbType.Date)).Value = objInfeccionIH.fechaAnalisis
                dbCommand.Parameters.Add(New SqlParameter("@Analisis", SqlDbType.NVarChar)).Value = objInfeccionIH.analisis
                dbCommand.Parameters.Add(New SqlParameter("@paquete", SqlDbType.NVarChar)).Value = objInfeccionIH.paquete
                dbCommand.Parameters.Add(New SqlParameter("@infectologo", SqlDbType.Int)).Value = objInfeccionIH.infectologo
                dbCommand.Parameters.Add(New SqlParameter("@neonatologo", SqlDbType.Int)).Value = objInfeccionIH.neonatologo
                dbCommand.Parameters.Add(New SqlParameter("@coordinador_Neonatos", SqlDbType.Int)).Value = objInfeccionIH.coordinadorNeonatos
                dbCommand.Parameters.Add(New SqlParameter("@coordinador_adulto", SqlDbType.Int)).Value = objInfeccionIH.coordinadorAdulto
                dbCommand.Parameters.Add(New SqlParameter("@Auditor_Cuentas", SqlDbType.Int)).Value = objInfeccionIH.auditorCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Auditor_Concu", SqlDbType.Int)).Value = objInfeccionIH.auditorConcu
                dbCommand.Parameters.Add(New SqlParameter("@coordinador_Adminis", SqlDbType.Int)).Value = objInfeccionIH.coordinadorAdminis
                dbCommand.Parameters.Add(New SqlParameter("@Fumador", SqlDbType.Bit)).Value = objInfeccionIH.fumador
                dbCommand.Parameters.Add(New SqlParameter("@Diabetes", SqlDbType.Bit)).Value = objInfeccionIH.diabetes
                dbCommand.Parameters.Add(New SqlParameter("@Medicamentos", SqlDbType.Bit)).Value = objInfeccionIH.medicamentos
                dbCommand.Parameters.Add(New SqlParameter("@Menor1000", SqlDbType.Bit)).Value = objInfeccionIH.menor1000
                dbCommand.Parameters.Add(New SqlParameter("@Obesidad", SqlDbType.Bit)).Value = objInfeccionIH.obesidad
                dbCommand.Parameters.Add(New SqlParameter("@Inmunosupresion", SqlDbType.Bit)).Value = objInfeccionIH.inmunoSupresion
                dbCommand.Parameters.Add(New SqlParameter("@Prematuro", SqlDbType.Bit)).Value = objInfeccionIH.prematuro
                dbCommand.Parameters.Add(New SqlParameter("@Otros", SqlDbType.Bit)).Value = objInfeccionIH.otros
                dbCommand.Parameters.Add(New SqlParameter("@CVC", SqlDbType.Bit)).Value = objInfeccionIH.cvc
                dbCommand.Parameters.Add(New SqlParameter("@Ventilacion", SqlDbType.Bit)).Value = objInfeccionIH.ventilacion
                dbCommand.Parameters.Add(New SqlParameter("@SondaV", SqlDbType.Bit)).Value = objInfeccionIH.sondaV
                dbCommand.Parameters.Add(New SqlParameter("@SondaN", SqlDbType.Bit)).Value = objInfeccionIH.sondaNasogastrica
                dbCommand.Parameters.Add(New SqlParameter("@Aislamiento", SqlDbType.NChar)).Value = objInfeccionIH.aislamiento
                dbCommand.Parameters.Add(New SqlParameter("@FechaCVC", SqlDbType.Date)).Value = objInfeccionIH.fechaCvc
                dbCommand.Parameters.Add(New SqlParameter("@FechaVent", SqlDbType.Date)).Value = objInfeccionIH.fechaVent
                dbCommand.Parameters.Add(New SqlParameter("@FechaSondaV", SqlDbType.Date)).Value = objInfeccionIH.fechaSondaV
                dbCommand.Parameters.Add(New SqlParameter("@FechaSondaN", SqlDbType.Date)).Value = objInfeccionIH.fechaSondaN
                dbCommand.Parameters.Add(New SqlParameter("@FechaAlta", SqlDbType.Date)).Value = objInfeccionIH.fechaAlta
                dbCommand.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objInfeccionIH.observacion
                dbCommand.Parameters.Add(New SqlParameter("@Inicial", SqlDbType.NVarChar)).Value = objInfeccionIH.inicial
                dbCommand.Parameters.Add(New SqlParameter("@Modificacion1", SqlDbType.NVarChar)).Value = objInfeccionIH.modificacion1
                dbCommand.Parameters.Add(New SqlParameter("@Modificacion2", SqlDbType.NVarChar)).Value = objInfeccionIH.modificacion2
                dbCommand.Parameters.Add(New SqlParameter("@Modificacion3", SqlDbType.NVarChar)).Value = objInfeccionIH.modificacion3
                dbCommand.Parameters.Add(New SqlParameter("@Justificacion1", SqlDbType.NVarChar)).Value = objInfeccionIH.justificacion1
                dbCommand.Parameters.Add(New SqlParameter("@Justificacion2", SqlDbType.NVarChar)).Value = objInfeccionIH.justificacion2
                dbCommand.Parameters.Add(New SqlParameter("@Justificacion3", SqlDbType.NVarChar)).Value = objInfeccionIH.justificacion3
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro1", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro1
                dbCommand.Parameters.Add(New SqlParameter("@Muestra1", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra1
                dbCommand.Parameters.Add(New SqlParameter("@Germen1", SqlDbType.NVarChar)).Value = objInfeccionIH.germen1
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro2", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro2
                dbCommand.Parameters.Add(New SqlParameter("@Muestra2", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra2
                dbCommand.Parameters.Add(New SqlParameter("@Germen2", SqlDbType.NVarChar)).Value = objInfeccionIH.germen2
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro3", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro3
                dbCommand.Parameters.Add(New SqlParameter("@Muestra3", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra3
                dbCommand.Parameters.Add(New SqlParameter("@Germen3", SqlDbType.NVarChar)).Value = objInfeccionIH.germen3
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro4", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro4
                dbCommand.Parameters.Add(New SqlParameter("@Muestra4", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra4
                dbCommand.Parameters.Add(New SqlParameter("@Germen4", SqlDbType.NVarChar)).Value = objInfeccionIH.germen4
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro5", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro5
                dbCommand.Parameters.Add(New SqlParameter("@Muestra5", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra5
                dbCommand.Parameters.Add(New SqlParameter("@Germen5", SqlDbType.NVarChar)).Value = objInfeccionIH.germen5
                dbCommand.Parameters.Add(New SqlParameter("@FechaMicro6", SqlDbType.Date)).Value = objInfeccionIH.fechaMicro6
                dbCommand.Parameters.Add(New SqlParameter("@Muestra6", SqlDbType.NVarChar)).Value = objInfeccionIH.muestra6
                dbCommand.Parameters.Add(New SqlParameter("@Germen6", SqlDbType.NVarChar)).Value = objInfeccionIH.germen6
                dbCommand.Parameters.Add(New SqlParameter("@detalle_infeccion", SqlDbType.Structured)).Value = objInfeccionIH.dtRespuestas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
