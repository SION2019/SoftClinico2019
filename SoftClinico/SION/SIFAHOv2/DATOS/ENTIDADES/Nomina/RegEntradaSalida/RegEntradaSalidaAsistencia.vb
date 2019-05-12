Public Class RegEntradaSalidaAsistencia
    Public Property dtRegEntrada As DataTable
    Public Property dtRegEntradaEmpleado As DataTable
    Public Property dtRegConsolidado As DataTable
    Public Property dtSeguimiento As DataTable
    Public Property idEmpresa As Integer
    Public Property codigoEp As Integer
    Public Property idEmpleado As String
    Public Property lbRegistros As New StatusBarPanel()
    Public Property lbBalance As New StatusBarPanel()
    Public Property lbEstado As New StatusBarPanel()
    Public Property lbEntrada As New StatusBarPanel()
    Public Property lbFecha As New StatusBarPanel()
    Public Property fechaActual As Date
    Public Sub New()
        dtRegEntrada = New DataTable
        dtRegEntradaEmpleado = New DataTable
        dtRegConsolidado = New DataTable
        dtSeguimiento = New DataTable

        dtRegEntrada.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        dtRegEntrada.Columns.Add("Dia", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Turno", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Empleado", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Entrada", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Descanso", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Retorno", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Salida", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Perdidas", Type.GetType("System.String"))
        dtRegEntrada.Columns.Add("Punto", Type.GetType("System.String"))

        dtRegEntradaEmpleado.Columns.Add("Dia", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Turno", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Entrada", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Descanso", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Retorno", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Salida", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Perdidas", Type.GetType("System.String"))
        dtRegEntradaEmpleado.Columns.Add("Punto", Type.GetType("System.String"))

        dtRegConsolidado.Columns.Add("Dia", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Nombre", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Cargo", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Horario", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Turnos_Programados", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Turnos_Realizados", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Horas_Realizadas", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Horas_Compensadas", Type.GetType("System.String"))
        dtRegConsolidado.Columns.Add("Horas_Perdidas", Type.GetType("System.String"))

        dtSeguimiento.Columns.Add("Dia", Type.GetType("System.String"))
        dtSeguimiento.Columns.Add("Cargo", Type.GetType("System.String"))
        dtSeguimiento.Columns.Add("Maquina", Type.GetType("System.String"))
        dtSeguimiento.Columns.Add("movimiento", Type.GetType("System.String"))

    End Sub
    Public Sub CargarDatosRegEntradaSalida()
        Dim params As New List(Of String)
        params.Add(codigoEp)
        General.llenarTabla(Consultas.CARGAR_NOMINA_REG_ENTRADA_SALIDA, params, dtRegEntrada)
        lbRegistros.Text = "Total Registro: " & dtRegEntrada.Rows.Count
    End Sub
    Public Sub CargarDatosRegEntradaSalidaEmpleado(fechaInicio As Date, fechaFin As Date)
        Dim params As New List(Of String)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(idEmpleado)
        params.Add(codigoEp)
        General.llenarTabla(Consultas.REG_ENTRADA_SALIDA_EMPLEADO_CARGAR, params, dtRegEntradaEmpleado)
        lbRegistros.Text = "Total Registro: " & dtRegEntradaEmpleado.Rows.Count
    End Sub
    Public Sub CargarDatosRegEntradaSalidaConsolidado(fechaInicio As Date, fechaFin As Date)
        Dim params As New List(Of String)
        params.Add(idEmpresa)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(codigoEp)
        params.Add(If(idEmpleado = String.Empty, Nothing, idEmpleado))
        General.llenarTabla(Consultas.REG_ENTRADA_SALIDA_CONSOLIDADO_CARGAR, params, dtRegConsolidado)
        lbRegistros.Text = "Total Registro: " & dtRegConsolidado.Rows.Count
    End Sub
    Public Sub CargarDatosRegEntradaSalidaSeguimiento(fechaInicio As Date, fechaFin As Date)
        Dim params As New List(Of String)
        params.Add(idEmpresa)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(idEmpleado)
        General.llenarTabla(Consultas.REG_ENTRADA_SALIDA_SEGUIMIENTO_CARGAR, params, dtSeguimiento)
        Dim dtNuevo As New DataTable
        dtNuevo = dtSeguimiento.Clone
        Dim fechaSeleccionada As String
        If dtSeguimiento.Rows.Count > 0 Then
            fechaSeleccionada = dtSeguimiento.Rows(0).Item(0)
            dtNuevo.Rows.Add(dtSeguimiento.Rows(0).Item(0), dtSeguimiento.Rows(0).Item(1), dtSeguimiento.Rows(0).Item(2), dtSeguimiento.Rows(0).Item(3))
            For i = 1 To dtSeguimiento.Rows.Count - 1
                If dtSeguimiento.Rows(i).Item(0) = fechaSeleccionada Then
                    dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(3) += vbCrLf & vbCrLf & dtSeguimiento.Rows(i).Item(3)
                Else
                    dtNuevo.Rows.Add(dtSeguimiento.Rows(i).Item(0), dtSeguimiento.Rows(i).Item(1), dtSeguimiento.Rows(i).Item(2), dtSeguimiento.Rows(i).Item(3))
                    fechaSeleccionada = dtSeguimiento.Rows(i).Item(0)
                End If
            Next
            dtSeguimiento = dtNuevo.Copy()
            lbRegistros.Text = "Total Registro: " & dtNuevo.Rows.Count
        Else
            lbRegistros.Text = "Total Registro: " & dtSeguimiento.Rows.Count
        End If

    End Sub

End Class
