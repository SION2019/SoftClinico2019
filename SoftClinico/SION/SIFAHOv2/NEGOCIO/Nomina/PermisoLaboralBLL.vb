Public Class PermisoLaboralBLL
    Dim cmd As New PermisoDAL

    Sub enlazarTablaInfoPermiso(ByRef dtinfoper As DataTable)
        dtinfoper.Columns.Add("Codigo", Type.GetType("System.String"))
        dtinfoper.Columns.Add("key", Type.GetType("System.String"))
    End Sub

    Sub enlazarTablaPerDetalle(ByRef dgvPermiso As DataGridView, ByRef colNombrePer As DataGridViewColumn,
ByRef colCargoPer As DataGridViewColumn, ByRef dtPermiso As DataTable, ByRef EnlceDtaPer As BindingSource)

        dtPermiso.Clear()
        'dtPermiso.Columns.Clear()
        Dim nombre As String
        For Each Col As DataGridViewColumn In dgvPermiso.Columns
            nombre = Col.DataPropertyName
            dtPermiso.Columns.Add(nombre, tipoColumnaDato(nombre))
            If Col.Name <> colNombrePer.Name AndAlso Col.Name <> colCargoPer.Name Then Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter : _
            If (Strings.Left(Col.Name, 6) = "colDia") Then Col.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9, FontStyle.Bold)
            Col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dgvPermiso.AutoGenerateColumns = False
        EnlceDtaPer.DataSource = dtPermiso
        EnlceDtaPer.Sort = "Nombre"
        dgvPermiso.DataSource = EnlceDtaPer.DataSource
        dgvPermiso.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPermiso.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Function tipoColumnaDato(nombre As String)
        'If nombre = "Permiso_Especial" Then Return Type.GetType("System.Boolean")
        Return Type.GetType("System.String")
    End Function

    Sub enlazarTablaMesPer(ByRef dtmesper As DataTable)
        dtmesper.Columns.Add("Codigo", Type.GetType("System.String"))
        dtmesper.Columns.Add("Id_empleado", Type.GetType("System.Int32"))
        dtmesper.Columns.Add("Empleado", Type.GetType("System.String"))
        dtmesper.Columns.Add("Convencion", Type.GetType("System.String"))
        dtmesper.Columns.Add("Fecha_Permiso", Type.GetType("System.DateTime"))
        dtmesper.Columns.Add("Comienzo_Permiso", Type.GetType("System.DateTime"))
        dtmesper.Columns.Add("Fin_Permiso", Type.GetType("System.DateTime"))
        'dtmesper.Columns.Add("Pminutos", Type.GetType("System.Int64"))
        dtmesper.Columns.Add("Tipo_Permiso", Type.GetType("System.Int32"))
        'dtmesper.Columns.Add("Es_Total", Type.GetType("System.Boolean"))
        dtmesper.Columns.Add("Aplicado", Type.GetType("System.Boolean"))
        dtmesper.Columns.Add("PermisoEspecial", Type.GetType("System.Boolean"))
        dtmesper.Columns.Add("Anulado", Type.GetType("System.Boolean"))
        dtmesper.Columns.Add("key", Type.GetType("System.String"))
    End Sub

    Sub enlazarDataSet(ByRef ds As DataSet, ByRef dtPermiso As DataTable,
                       ByRef dtinfoper As DataTable, ByRef dtmesper As DataTable, ByRef dtPuntoEP As DataTable)

        ds.Tables.Clear()

        dtPermiso.TableName = "Table" : ds.Tables.Add(dtPermiso)
        dtinfoper.TableName = "Table1" : ds.Tables.Add(dtmesper)
        dtPuntoEP.TableName = "Table2" : ds.Tables.Add(dtPuntoEP)
        'dtmesper.TableName = "Table2" : ds.Tables.Add(dtinfoper)
    End Sub

    Public Function guardar(ByRef pPermiso As Permiso, diccPermisos As Dictionary(Of String, Permiso)) As Boolean
        cmd.guardar(pPermiso)
        If pPermiso._outdt IsNot Nothing AndAlso pPermiso._outdt.Rows.Count <> 0 Then
            For Each dw As DataRow In pPermiso._outdt.Rows
                If dw.Item("Anulado") = True Then
                    diccPermisos.Remove(dw.Item("Key").ToString)
                Else
                    Dim permiso1 As Permiso = Nothing
                    If diccPermisos.TryGetValue(dw.Item("Key").ToString, permiso1) Then
                        permiso1.Codigo = dw.Item("Codigo_Permiso").ToString
                        permiso1.Editado = False
                        If permiso1.PermisoEspecial Then permiso1.EsViejoPE = True
                    End If
                End If
            Next
        Else
            Return False
        End If
        Return True
    End Function

End Class
