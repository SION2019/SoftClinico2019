Public Class AjusteInventario
    Inherits Despacho
    Public Property codigoAjustePunto As String
    Public Property dtAjustes As DataTable
    Public Property codigoBodega As Integer
    Public Property fechaAjuste As DateTime
    Public Property usuario As Integer
    Public Property codigoAjuste As String
    Public Property codigoProducto As Integer
    Public Sub guardarAjuste()
        If String.IsNullOrEmpty(codigoAjuste) Then
            codigoAjuste = -1
        End If
        AjusteInventarioDAL.guardarAjuste(Me)
    End Sub
    Public Sub cargarLotesRegistro(ByRef dt As DataTable, ByVal nombreTabla As String, ByVal inidiceFila As Integer)
        agregarTabla(nombreTabla)
        Dim params As New List(Of String)
        params.Add(codigoAjuste)
        params.Add(dtAjustes.Rows(inidiceFila).Item("Codigo"))
        General.llenarTabla(Consultas.AJUSTE_INVENTARIO_LOTES_CARGAR, params, dt)
    End Sub
    Public Sub cargarProductoBodega()
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(codigoAjuste)
        General.llenarTabla(Consultas.AJUSTE_PRODUCTO_BODEGA_CARGAR, params, dtAjustes)
    End Sub
    Sub New()
        tblLotes = New DataSet
        dtAjustes = New DataTable
        dtAjustes.Columns.Add("Codigo", Type.GetType("System.String"))
        dtAjustes.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtAjustes.Columns.Add("Marca", Type.GetType("System.String"))
        dtAjustes.Columns.Add("Stock", Type.GetType("System.String"))
        dtAjustes.Columns.Add("Cantidad ajuste", Type.GetType("System.String"))
        dtAjustes.Columns.Add("Costo ajuste", Type.GetType("System.String"))
        dtAjustes.Columns("Cantidad ajuste").DefaultValue = 0
        dtAjustes.Columns("Costo ajuste").DefaultValue = 0
        dtAjustes.Columns.Add("Lote", Type.GetType("System.String"))
    End Sub
    Sub establecerNuevaTabla(ByVal codigo As Integer, ByVal fila As Integer, ByVal nombreTabla As String)
        If verificarExistenciaTabla(nombreTabla) = False Then
            agregarTabla(nombreTabla)
            agregarcolumnasTabla(nombreTabla)
        End If
    End Sub
    Public Sub cargarLotes(ByVal codigoProducto As Integer, ByVal nombretabla As String)
        If tblLotes.Tables(nombretabla).Rows.Count > 0 Then Exit Sub
        Dim params As New List(Of String)
        params.Add(codigoProducto)
        params.Add(codigoBodega)
        General.llenarTabla(Consultas.AJUSTE_PRODUCTO_LOTES_CARGAR, params, tblLotes.Tables(nombretabla))
    End Sub
    Sub agregarcolumnasTabla(ByVal nombreTabla As String)
        tblLotes.Tables(nombreTabla).Columns.Add("Reg_Lote", Type.GetType("System.String"))
        tblLotes.Tables(nombreTabla).Columns.Add("Numero lote", Type.GetType("System.String"))
        tblLotes.Tables(nombreTabla).Columns.Add("Fecha vence", Type.GetType("System.DateTime"))
        tblLotes.Tables(nombreTabla).Columns.Add("Stock", Type.GetType("System.Int32"))
        tblLotes.Tables(nombreTabla).Columns.Add("Conteo", Type.GetType("System.Int32"))
        tblLotes.Tables(nombreTabla).Columns.Add("Costo", Type.GetType(" System.Double"))
        tblLotes.Tables(nombreTabla).Columns.Add("Cant Ajuste", Type.GetType("System.Int32"), "Conteo-Stock")
        tblLotes.Tables(nombreTabla).Columns.Add("Observacion", Type.GetType("System.String"))
        tblLotes.Tables(nombreTabla).Columns.Add("excepcion", Type.GetType("System.Boolean"))
        tblLotes.Tables(nombreTabla).Columns("excepcion").DefaultValue = False
        tblLotes.Tables(nombreTabla).Columns("Stock").DefaultValue = 0
        tblLotes.Tables(nombreTabla).Columns("Costo").DefaultValue = 0
        tblLotes.Tables(nombreTabla).Columns("Fecha vence").DefaultValue = General.fechaActualServidor()
    End Sub

End Class
