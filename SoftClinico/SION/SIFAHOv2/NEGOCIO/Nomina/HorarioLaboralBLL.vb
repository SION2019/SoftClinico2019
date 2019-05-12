Public Class HorarioLaboralBLL
    Dim cmd As New HorarioDAL
    ReadOnly DlbColumns As String() = {"Turnos_Programados", "Turnos_Realizados", "Horas_Programadas", "Horas_Realizadas"}
    ReadOnly IntColumns As String() = {"Minutos_Programados", "Minutos_Realizados"}

    Sub enlazarTablaInfoHorario(ByRef dtinfohor As DataTable)
        dtinfohor.Columns.Add("Codigo_Horario", Type.GetType("System.String"))
        dtinfohor.Columns.Add("Fecha_Horario", Type.GetType("System.DateTime"))
    End Sub


    Function tipoColumnaDato(nombre As String)
        If DlbColumns.Contains(nombre) Then Return Type.GetType("System.Double")
        If IntColumns.Contains(nombre) Then Return Type.GetType("System.Int64")
        If nombre = "Anulado" Then Return Type.GetType("System.Boolean")
        Return Type.GetType("System.String")
    End Function

    Sub enlazarTablaPnlEmpleado(ByRef dgvPnl As DataGridView, ByRef dtPnl As DataTable, ByRef EnlceDtaPnl As BindingSource)
        dgvPnl.AutoGenerateColumns = False
        EnlceDtaPnl.DataSource = dtPnl
        dgvPnl.DataSource = EnlceDtaPnl.DataSource
        dgvPnl.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPnl.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
    End Sub

    Sub enlazarTablaPunto(ByRef dgvPuntoDia As DataGridView, ByRef dtpuntodia As DataTable, ByRef dtpuntodia_aux As DataTable, ByRef EnlceDtaPuntoDia As BindingSource)
        Dim keys(3) As DataColumn
        Dim col1, col2, col3 As DataColumn
        If dtpuntodia.Columns.Count = 0 Then
            col1 = New DataColumn()
            col1.DataType = System.Type.GetType("System.Int32")
            col1.ColumnName = "id_empleado"

            col2 = New DataColumn()
            col2.DataType = System.Type.GetType("System.Int32")
            col2.ColumnName = "dia"

            col3 = New DataColumn()
            col3.DataType = System.Type.GetType("System.Int32")
            col3.ColumnName = "Codigo_punto"

            dtpuntodia.Columns.Add(col1)
            dtpuntodia.Columns.Add("id_empresa", Type.GetType("System.Int32"))
            dtpuntodia.Columns.Add(col2)
            dtpuntodia.Columns.Add(col3)
            dtpuntodia.Columns.Add("Nombre", Type.GetType("System.String"))
            dtpuntodia.Columns.Add("Dia_Asignado", Type.GetType("System.Boolean"))
            dtpuntodia.PrimaryKey = keys

            dtpuntodia_aux = dtpuntodia.Clone
        End If

        dgvPuntoDia.AutoGenerateColumns = False
        EnlceDtaPuntoDia.DataSource = dtpuntodia
        EnlceDtaPuntoDia.Sort = "Nombre"
        EnlceDtaPuntoDia.Filter = "1=2"
        dgvPuntoDia.DataSource = EnlceDtaPuntoDia.DataSource
        dgvPuntoDia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPuntoDia.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
    End Sub

    Sub enlazarTablaCopia(ByRef dtcopia As DataTable)
        dtcopia.Columns.Clear()
        dtcopia.Columns.Add("id_empleado", Type.GetType("System.String"))
        dtcopia.Columns.Add("Dia", Type.GetType("System.Int32"))
        dtcopia.Columns.Add("Valor", Type.GetType("System.String"))
        dtcopia.Columns.Add("Puntos", Type.GetType("System.String"))
    End Sub

    Sub enlazarTablaPega(ByRef dtpegarpunto As DataTable)
        dtpegarpunto.Columns.Clear()
        dtpegarpunto.Columns.Add("id_empleado", Type.GetType("System.String"))
        dtpegarpunto.Columns.Add("Dia", Type.GetType("System.String"))
        dtpegarpunto.Columns.Add("Punto", Type.GetType("System.String"))
    End Sub

    Sub enlazarDataSet(ByRef ds As DataSet, ByRef dtinfohor As DataTable,
ByRef dthorario As DataTable, ByRef dthorario_del As DataTable, ByRef dtpuntodia As DataTable)

        ds.Tables.Clear()

        dtinfohor.TableName = "Table" : ds.Tables.Add(dtinfohor)
        dthorario.TableName = "Table1" : ds.Tables.Add(dthorario)
        dthorario_del.TableName = "Table2" : ds.Tables.Add(dthorario_del)
        dtpuntodia.TableName = "Table3" : ds.Tables.Add(dtpuntodia)
    End Sub


    Sub llenarTablaPunto(ByRef dtpuntodia As DataTable, ByRef dtpuntodia_aux As DataTable, Terceros As String, CodHorario As String)
        Dim params As New List(Of String)
        params.Add(If(CodHorario = "", -1, CodHorario))
        params.Add(SesionActual.codigoEP)
        params.Add(Constantes.PUNTO_POR_DEFECTO)
        General.llenarTabla(Consultas.HORARIOPUNTOEMPLEADOS_CARGAR, params, dtpuntodia_aux)
        'If dtpuntodia.Rows.Count = 0 Then
        dtpuntodia = dtpuntodia_aux.Copy

        'Else
        '    For Each dw As DataRow In dtpuntodia_aux.Rows
        '        If existeEnDatatable(dw, dtpuntodia) = False Then dtpuntodia.ImportRow(dw)
        '    Next
        'End If
    End Sub

    Function existeEnDatatable(pDw As DataRow, pDt As DataTable) As Boolean
        For Each dw As DataRow In pDt.Rows
            If dw.Item("id_empleado").ToString = pDw.Item("id_empleado").ToString AndAlso
                       dw.Item("dia").ToString = pDw.Item("dia").ToString Then Return True
        Next
        Return False
    End Function

    Public Function validarmes(ByVal pHorario As Horario) As Boolean
        Return If(cmd.validarmes(pHorario) = 1, True, False)
    End Function
    Public Function validarMesHorario(ByVal pHorario As HorarioLaboral) As Boolean
        Return If(cmd.validarMesHorario(pHorario) = 1, True, False)
    End Function

    Public Function guardar(ByVal pHorario As Horario) As Boolean
        cmd.guardar(pHorario)
        Return True
    End Function
    Public Function guardarNovedades(ByVal pHorario As Horario) As Boolean
        cmd.guardarNovedades(pHorario)
        Return True
    End Function

End Class
