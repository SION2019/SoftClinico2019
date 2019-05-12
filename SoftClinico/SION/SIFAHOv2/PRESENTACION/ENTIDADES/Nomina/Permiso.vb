Public Class Permiso


    Property id_tercero As String
    Property Empleado As String
    Property Fecha As DateTime
    Property Codigo As String
    Property Tipo As String
    Property Convencion As String
    Property EsTotal As Boolean
    Property Comienzo As DateTime
    Property Fin As DateTime
    Property TiempoTotal As Integer
    Property Anulado As Boolean
    Property Enlistado As Boolean
    Property Editado As Boolean
    Property horario As String
    Property key As String
    Property PermisoEspecial As Boolean
    Property EsViejoPE As Boolean


    Property _indt As DataTable
    Property _outdt As DataTable

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
        End With

        importar_tabla(diccPermisos)

    End Sub

    Sub New()
        ' 
    End Sub

    Sub importar_tabla(diccPermisos As Dictionary(Of String, Permiso))
        For Each kvp As KeyValuePair(Of String, Permiso) In diccPermisos
            If kvp.Value.Codigo Is Nothing OrElse kvp.Value.Editado OrElse kvp.Value.Anulado OrElse (kvp.Value.PermisoEspecial AndAlso kvp.Value.EsViejoPE = False) Then
                Dim dw = _indt.NewRow
                dw.Item("Codigo") = kvp.Value.Codigo
                dw.Item("Id_empleado") = kvp.Value.id_tercero
                'dw.Item("Codigo_Horario") = kvp.Value.Horario
                If kvp.Value.PermisoEspecial Then
                    dw.Item("PermisoEspecial") = True
                Else
                    dw.Item("Convencion") = kvp.Value.Convencion
                    dw.Item("Fecha_Permiso") = kvp.Value.Fecha
                    dw.Item("Comienzo") = kvp.Value.Comienzo
                    dw.Item("Pminutos") = kvp.Value.TiempoTotal
                    dw.Item("Tipo_Permiso") = kvp.Value.Tipo
                    dw.Item("Es_Total") = kvp.Value.EsTotal
                End If
                'dw.Item("Aplicado") = kvp.Value.Aplicado
                dw.Item("Anulado") = kvp.Value.Anulado
                _indt.Rows.Add(dw)
            End If
        Next kvp
    End Sub

    Sub New(pDwpermiso As DataRow)
        Codigo = pDwpermiso("Codigo").ToString
        id_tercero = pDwpermiso("Id_empleado").ToString
        Empleado = pDwpermiso("Empleado").ToString
        If (IsDBNull(pDwpermiso("PermisoEspecial")) = False AndAlso pDwpermiso("PermisoEspecial")) Then
            PermisoEspecial = True
            EsViejoPE = True
        Else
            Convencion = pDwpermiso("Convencion")
            Fecha = pDwpermiso("Fecha_Permiso")
            Comienzo = pDwpermiso("Comienzo")
            Fin = pDwpermiso("Fin")
            TiempoTotal = pDwpermiso("Pminutos")
            Tipo = pDwpermiso("Tipo_Permiso")
            EsTotal = pDwpermiso("Es_Total")
            ' Aplicado = pDwpermiso("Aplicado")
        End If
        Anulado = pDwpermiso("Anulado")
        key = pDwpermiso("key")
    End Sub

End Class
