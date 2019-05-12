Imports Microsoft.SqlServer.Server

Public Class EmpleadoCollection
    Inherits List(Of Empleado)
    Implements IEnumerable(Of SqlDataRecord)

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator

        Dim sqlDataRecord As New SqlDataRecord(New SqlMetaData() {
                                                New SqlMetaData("IdEmpresa", SqlDbType.Int),
                                                New SqlMetaData("IdEmpleado", SqlDbType.Int),
                                                New SqlMetaData("iniciales", SqlDbType.NVarChar, 2),
                                                New SqlMetaData("registroMedico", SqlDbType.Int),
                                                New SqlMetaData("IdViaticos", SqlDbType.Int),
                                                New SqlMetaData("tipoempleado", SqlDbType.NVarChar, 1),
                                                New SqlMetaData("fechaExpedicion", SqlDbType.Date),
                                                New SqlMetaData("fechaIngreso", SqlDbType.Date),
                                                New SqlMetaData("fechaRetiro", SqlDbType.Date),
                                                New SqlMetaData("fechaNacimiento", SqlDbType.Date),
                                                New SqlMetaData("codigoCargo", SqlDbType.Int),
                                                New SqlMetaData("codigoGenero", SqlDbType.Int),
                                                New SqlMetaData("codigoPaisExp", SqlDbType.NVarChar, 10),
                                                New SqlMetaData("codigoDepartamentoExp", SqlDbType.NVarChar, 10),
                                                New SqlMetaData("codigoMunicipioExp", SqlDbType.NVarChar, 10),
                                                New SqlMetaData("codigoPaisNac", SqlDbType.NVarChar, 10),
                                                New SqlMetaData("codigoDepartamentoNac", SqlDbType.NVarChar, 10),
                                                New SqlMetaData("codigoMunicipioNac", SqlDbType.NVarChar, 10),
                                                New SqlMetaData("codigoEspecialidad", SqlDbType.Int),
                                                New SqlMetaData("codigoProfesion", SqlDbType.Int),
                                                New SqlMetaData("idEps", SqlDbType.Int),
                                                New SqlMetaData("codigoArp", SqlDbType.Int),
                                                New SqlMetaData("codigoCaja", SqlDbType.Int),
                                                New SqlMetaData("codigoPension", SqlDbType.Int),
                                                New SqlMetaData("tipoRH", SqlDbType.NVarChar, 10)})

        For Each item As Empleado In Me
            sqlDataRecord.SetInt32(0, item.idEmpresa)
            sqlDataRecord.SetInt32(1, item.idEmpleado)
            sqlDataRecord.SetValue(2, item.iniciales)
            sqlDataRecord.SetInt32(3, item.registroMedico)
            sqlDataRecord.SetInt32(4, item.IdViaticos)
            sqlDataRecord.SetValue(5, item.tipoempleado)
            sqlDataRecord.SetDateTime(6, item.fechaExpedicion)
            sqlDataRecord.SetDateTime(7, item.fechaIngreso)
            sqlDataRecord.SetDateTime(8, item.fechaRetiro)
            sqlDataRecord.SetDateTime(9, item.fechaNacimiento)
            sqlDataRecord.SetInt32(10, item.codigoCargo)
            sqlDataRecord.SetInt32(11, item.codigoGenero)
            sqlDataRecord.SetValue(12, item.codigoPaisExp)
            sqlDataRecord.SetValue(13, item.codigoDepartamentoExp)
            sqlDataRecord.SetValue(14, item.codigoMunicipioExp)
            sqlDataRecord.SetValue(15, item.codigoPaisNac)
            sqlDataRecord.SetValue(16, item.codigoDepartamentoNac)
            sqlDataRecord.SetValue(17, item.codigoMunicipioNac)
            sqlDataRecord.SetValue(18, item.codigoEspecialidad)
            sqlDataRecord.SetInt32(19, item.codigoProfesion)
            sqlDataRecord.SetInt32(20, item.idEps)
            sqlDataRecord.SetInt32(21, item.codigoArp)
            sqlDataRecord.SetInt32(22, item.codigoCaja)
            sqlDataRecord.SetInt32(23, item.codigoPension)
            sqlDataRecord.SetValue(24, item.tipoRH)

            Yield sqlDataRecord
        Next
    End Function
End Class


