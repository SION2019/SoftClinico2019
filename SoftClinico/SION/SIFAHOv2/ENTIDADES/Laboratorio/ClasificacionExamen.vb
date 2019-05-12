Public Class ClasificacionExamen

    Public Property dtExamen As DataTable
    Public Property arbol As New TreeView
    Public Property codigoExamen As String
    Public Property codigoProveedor As Integer
    Public Property busqueda As String
    Public Sub cargarExamen()
        Dim params As New List(Of String)
        params.Add(busqueda)
        General.llenarTabla(Consultas.CLASIFICACION_EXAMEN, params, dtExamen)
    End Sub

    Public Sub guardar()
        ClasificacionExamenDAL.guardarExamen(Me)
    End Sub
    Public Sub cargarArbol()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        General.cargarOpcionesArbol(Consultas.CLASIFICACION_EXAMEN_PROVEEDOR, params, arbol, "Id_Proveedor", "Proveedor")
    End Sub

    Public Sub cargarArbolCheck()
        Dim dt As New DataTable
        General.llenarTabla(Consultas.CALSIFICACION_EXAMEN_DATOS_CARGAR, Nothing, dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                For j = 0 To arbol.Nodes.Count - 1
                    If dt.Rows(i).Item("Id_Proveedor") = arbol.Nodes(j).Name AndAlso dt.Rows(i).Item("Codigo_Procedimiento") = codigoExamen Then
                        arbol.Nodes(j).Checked = True
                    End If
                Next
            Next
        End If
    End Sub

    Sub New()
        dtExamen = New DataTable
        dtExamen.Columns.Add("Código examen", Type.GetType("System.String"))
        dtExamen.Columns.Add("Descripción", Type.GetType("System.String"))
        dtExamen.Columns.Add("Laboratorio", Type.GetType("System.Boolean"))

    End Sub
End Class
