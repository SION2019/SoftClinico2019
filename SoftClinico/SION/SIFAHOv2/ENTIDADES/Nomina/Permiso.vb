Public Class Permiso
    Property id_tercero As String
    Property imprimirPermisoXEmpleado As String
    Property Empleado As String
    Property Fecha As DateTime
    Property Codigo As String
    Property Tipo As String
    Property Convencion As String
    Property EsTotal As Boolean
    Property Aplicado As Boolean
    Property Comienzo As DateTime
    Property Fin As DateTime
    Property TiempoTotal As Integer
    Property Anulado As Boolean
    Property Enlistado As Boolean
    Property Editado As Boolean
    Property horario As String
    Property key As String
    Property Observacion As String
    Property HrPermiso As Double
    Property PermisoEspecial As Boolean
    Property EsViejoPE As Boolean
    Public Property fechaInicio As DateTime
    Public Property fechaFin As DateTime
    Public Property dtFestivos As DataTable
    Property _indt As DataTable
    Property _outdt As DataTable
    Property codPE As Integer

    Sub New(diccPermisos As Dictionary(Of String, Permiso))

        _indt = New DataTable

        With _indt.Columns
            .Add("Codigo", Type.GetType("System.String"))
            .Add("Id_empleado", Type.GetType("System.Int32"))
            .Add("Codigo_Horario", Type.GetType("System.String"))
            .Add("Convencion", Type.GetType("System.String"))
            .Add("Fecha_Permiso", Type.GetType("System.DateTime"))
            .Add("Comienzo", Type.GetType("System.DateTime"))
            .Add("Pminutos", Type.GetType("System.Int64"))
            .Add("Tipo_Permiso", Type.GetType("System.Int32"))
            .Add("Es_Total", Type.GetType("System.Boolean"))
            .Add("Aplicado", Type.GetType("System.Boolean"))
            .Add("PermisoEspecial", Type.GetType("System.Boolean"))
            .Add("Anulado", Type.GetType("System.Boolean"))
            .Add("Observacion", Type.GetType("System.String"))
            .Add("Horas_Permiso", Type.GetType("System.Double"))
        End With

        importar_tabla(diccPermisos)

    End Sub

    Sub New()
        '
        dtFestivos = New DataTable
    End Sub

    Sub importar_tabla(diccPermisos As Dictionary(Of String, Permiso))
        For Each kvp As KeyValuePair(Of String, Permiso) In diccPermisos
            If kvp.Value.Codigo Is Nothing OrElse kvp.Value.Editado OrElse kvp.Value.Anulado OrElse (kvp.Value.PermisoEspecial AndAlso kvp.Value.EsViejoPE = False) Then
                Dim dw = _indt.NewRow
                dw.Item("Codigo") = kvp.Value.Codigo
                dw.Item("Id_empleado") = kvp.Value.id_tercero
                dw.Item("Codigo_Horario") = kvp.Value.horario
                If kvp.Value.PermisoEspecial Then
                    dw.Item("PermisoEspecial") = True
                    dw.Item("Comienzo") = Date.Now
                    dw.Item("Pminutos") = kvp.Value.TiempoTotal
                    dw.Item("Fecha_Permiso") = Date.Now
                    dw.Item("Tipo_Permiso") = 1
                    dw.Item("Es_Total") = 0
                Else
                    dw.Item("Convencion") = kvp.Value.Convencion
                    dw.Item("Fecha_Permiso") = kvp.Value.Fecha
                    dw.Item("Comienzo") = kvp.Value.Comienzo
                    dw.Item("Pminutos") = kvp.Value.TiempoTotal
                    dw.Item("Tipo_Permiso") = kvp.Value.Tipo
                    dw.Item("Es_Total") = kvp.Value.EsTotal
                End If
                dw.Item("Observacion") = kvp.Value.Observacion
                dw.Item("Horas_Permiso") = kvp.Value.HrPermiso
                dw.Item("Aplicado") = kvp.Value.Aplicado
                dw.Item("Anulado") = kvp.Value.Anulado
                _indt.Rows.Add(dw)
            End If
        Next kvp
    End Sub

    Sub New(pDwpermiso As DataRow)
        Codigo = pDwpermiso("Codigo").ToString
        id_tercero = pDwpermiso("Id_empleado").ToString
        Empleado = pDwpermiso("Empleado").ToString
        If (pDwpermiso("Tipo_Permiso") = 1) Then
            PermisoEspecial = True
            EsViejoPE = True
            Convencion = pDwpermiso("Convencion").ToString
            Fecha = pDwpermiso("Fecha_Permiso").ToString
            Comienzo = pDwpermiso("Comienzo_Permiso").ToString
            Fin = pDwpermiso("Fin_Permiso").ToString
            Dim meridiano As String = Fin.ToString("tt")
            TiempoTotal = IIf(meridiano = "p. m.", (Fin.ToString("hh") + 12) - Comienzo.ToString("hh"), Fin.ToString("hh") - Comienzo.ToString("hh")) * 60
            Tipo = pDwpermiso("Tipo_Permiso").ToString
            EsTotal = IIf(Comienzo = Fin, True, False)
            Aplicado = pDwpermiso("Aplicado")
        Else
            Convencion = pDwpermiso("Convencion").ToString
            Fecha = pDwpermiso("Fecha_Permiso").ToString
            Comienzo = pDwpermiso("Comienzo_Permiso").ToString
            Fin = pDwpermiso("Fin_Permiso").ToString
            Dim meridiano As String = Fin.ToString("tt")
            TiempoTotal = IIf(meridiano = "p. m.", (Fin.ToString("hh") + 12) - Comienzo.ToString("hh"), Fin.ToString("hh") - Comienzo.ToString("hh")) * 60
            Tipo = pDwpermiso("Tipo_Permiso").ToString
            EsTotal = IIf(Comienzo = Fin, True, False)
            Aplicado = pDwpermiso("Aplicado")
        End If
        Anulado = pDwpermiso("Anulado")
        key = pDwpermiso("key")
        Observacion = If(IsDBNull(pDwpermiso("Observacion")), Nothing, pDwpermiso("Observacion"))
        HrPermiso = If(IsDBNull(pDwpermiso("Horas_Permiso")), Nothing, pDwpermiso("Horas_Permiso"))
    End Sub
    Public Sub cargarFestivosMes()
        Dim params As New List(Of String)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        General.llenarTabla(Consultas.HORARIOFESTIVOS_CARGAR, params, dtFestivos)
    End Sub
End Class
