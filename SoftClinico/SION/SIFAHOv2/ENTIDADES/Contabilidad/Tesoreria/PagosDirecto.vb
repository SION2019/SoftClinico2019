Public Class PagosDirecto

    Public Property comprobante As String
    Public Property registroNuevo As Boolean
    Public Property dtComprobante As DataTable
    Public Property diferencia As Double
    Public Property debito As Double
    Public Property credito As Double
    Public Property entrada As String
    Public Property codigoPuc As Integer
    Public Property retencion As Double
    Public Property codigoCuenta As Integer
    Public Property idtercero As Integer
    Public Property mensaje As String
    Public Property dt As New DataTable
    Public Property idempresa As Integer
    Public Property documento As Integer
    Public Property usuario As Integer
    Public Property movimiento As String
    Public Property dt2 As New DataTable
    Public Property fecha As Date
    Public Property fecharec As Date
    Public Property periodoCerrado As Boolean
    Public Property dtCargar As New DataTable


    Public Sub cargarComprobante()
        Dim params As New List(Of String)
        params.Add(comprobante)
        General.llenarTabla(Consultas.COMPROBANTE_EGRESO_DETALLE_CARGAR, params, dtComprobante)
    End Sub



    Public Sub VerificarCodigo(indiceFila As Integer)
        Dim dtrows As DataRow
        Dim descripcion As String
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add(codigoCuenta)
        dtrows = FuncionesContables.digitarCuenta(params)
        If Not IsNothing(dtrows) Then
            descripcion = dtrows.Item(2)
            If Not String.IsNullOrEmpty(descripcion) AndAlso String.IsNullOrEmpty(dtComprobante.Rows(indiceFila).Item("Descripcion").ToString) Then
                dtComprobante.Rows(indiceFila).Item("Descripcion") = descripcion
                dtComprobante.Rows.Add()
            ElseIf Not String.IsNullOrEmpty(descripcion) AndAlso Not String.IsNullOrEmpty(dtComprobante.Rows(indiceFila).Item("Descripcion").ToString) Then
                dtComprobante.Rows(indiceFila).Item("Descripcion") = descripcion
            Else
                If MsgBox("Esta cuenta no existe ¿Desea crearla?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Crear") = MsgBoxResult.Yes Then
                    Dim formCuenta As New Form_CuentasPUC
                    formCuenta.ShowDialog()
                Else
                    dtComprobante.Rows(dtComprobante.Rows.Count - 1).Item("Codigo") = ""
                    dtComprobante.Rows(dtComprobante.Rows.Count - 1).Item("Descripcion") = ""
                End If
            End If
        Else
            dtComprobante.Rows(dtComprobante.Rows.Count - 1).Item("Codigo") = ""
            If dtComprobante.Rows.Count > 1 Then
                dtComprobante.Rows.RemoveAt(indiceFila)
            End If
        End If
    End Sub

    Public Sub VerificarComprobante()

        Dim params As New List(Of String)
        params.Add(comprobante)

        General.llenarTabla(Consultas.COMPROBANTE_ANULADO_VERIFICAR, params, dt)
        If dt.Rows.Count > 0 Then
            mensaje = Mensajes.COMPROBANTE_ANULADO
        End If
    End Sub

    Public Sub guardar()
        For i = 0 To dtComprobante.Rows.Count - 1
            dtComprobante.Rows(i).Item("Orden") = i
        Next
        ComprobanteEgresoDAL.guardarComprobante(Me)
    End Sub
    Public Sub VerificarFecha()

        Dim params As New List(Of String)
        params.Add(fecha)

        General.llenarTabla(Consultas.COMPROBANTE_FECHA_VERIFICAR, params, dt2)
        If dt2.Rows.Count > 0 Then
            periodoCerrado = True
            mensaje = Mensajes.PERIODO_CONTABLE_CERRADO
        Else
            periodoCerrado = False
        End If
    End Sub

    Sub New()
        dtComprobante = New DataTable
        dtComprobante.Columns.Add("Comprobante causacion", Type.GetType("System.String"))
        dtComprobante.Columns.Add("Codigo Factura", Type.GetType("System.String"))
        dtComprobante.Columns.Add("Codigo", Type.GetType("System.String"))
        dtComprobante.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtComprobante.Columns.Add("Debito", Type.GetType("System.Double"))
        dtComprobante.Columns("Debito").DefaultValue = "0,00"
        dtComprobante.Columns.Add("Credito", Type.GetType("System.Double"))
        dtComprobante.Columns("Credito").DefaultValue = "0,00"
        dtComprobante.Columns.Add("Orden", Type.GetType("System.Int32"))
    End Sub

End Class
