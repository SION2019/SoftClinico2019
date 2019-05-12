Imports System.Data.SqlClient
Public Class FuncionesContables

    Public Enum estadoCuentaPuc
        invalida = 0
        valida = 1
        existente = 2
    End Enum
    Public Shared Function cargarDocumento(codigo As String) As DocumentoContable
        Dim drDocumento As DataRow
        Dim params As New List(Of String)
        params.Add(codigo)

        drDocumento = General.cargarItem(Consultas.SIGLA_CONTABLE_CARGAR, params)

        Dim objDocumentoContable As New DocumentoContable

        If Not IsNothing(drDocumento) Then
            objDocumentoContable.sigla = codigo
            objDocumentoContable.codigo = drDocumento.Item("Codigo_documento").ToString()
            objDocumentoContable.descripcion = drDocumento.Item("Descripcion_documento").ToString()
        End If

        Return objDocumentoContable
    End Function
    Public Shared Function llenarRetencion(params As List(Of String)) As DataRow
        Dim drCuenta As DataRow
        drCuenta = General.cargarItem(Consultas.RETENCION_IVA_CARGAR, params)
        If Not IsNothing(drCuenta) Then
            Return drCuenta
        End If
        Return Nothing
    End Function
    Public Shared Function Convertir_Numero(ByVal numero As Double) As String
        Dim sValor As String, siValor As Single = Nothing
        Dim num_entero, num_decimal As Single
        Dim NumeroConvertido As String

        sValor = Val(Replace(Format(numero, "General Number"), ",", ".").ToString)
        num_entero = Int(Val(sValor))
        num_decimal = CInt((sValor - num_entero) * 100)
        ' A ESPERAS DE DOLARIZACIOn

        If num_decimal > 0 Then
            NumeroConvertido = Num2Text(Val(sValor)) & " PESOS CON " + Num2Text(num_decimal) + " CENTAVOS MCTE"
        Else
            NumeroConvertido = Num2Text(Val(sValor)) & " PESOS MCTE"
        End If
        Return NumeroConvertido
    End Function
    Public Shared Function validarDatosDgv(dgvcuentas As DataGridView, columna As Integer)
        If (dgvcuentas.RowCount = 1) Then
            MsgBox("No se puede guardar registros en blanco", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            dgvcuentas.Focus()
            Return False
        Else
            For i = 0 To dgvcuentas.Rows.Count - 2
                If dgvcuentas.Rows(i).Cells(columna).Value.ToString = "" Then
                    MsgBox("Debe ingresar una cuenta en la fila " & i + 1 & " ", 48, "Atención")
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    Public Shared Function Num2Text(ByVal value As Double) As String
        value = Int(value)
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON" & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES"
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON" & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Public Shared Function sumaRetencion(ByVal codigoPuc As Integer, ByVal dtContable As DataGridView)
        Try
            Dim dtNuevo, dtnuevasFilas As New DataTable
            dtNuevo = dtContable.DataSource.copy
            dtnuevasFilas = dtNuevo.Clone
            Dim filas As DataRow() = dtNuevo.Select("Codigo <> ''")
            For Each fila As DataRow In filas
                dtnuevasFilas.ImportRow(fila)
            Next

            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = ConsultasContabilidad.SUMA_RETENCION
                dbCommand.Parameters.Add(New SqlParameter("@detalle", SqlDbType.Structured)).Value = dtnuevasFilas
                dbCommand.Parameters.Add(New SqlParameter("@CODIGOPUC", SqlDbType.Int)).Value = codigoPuc
                Return dbCommand.ExecuteScalar()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function verificarConsecutivo(idempresa As Integer, pCodigo As String) As String
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.CONSECUTIVO_CONTABLE & "(" & idempresa & ",'" & pCodigo & "')", dt)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0).ToString()
        End If
        Return Nothing
    End Function
    Public Shared Sub aumentarConsecutivo(ByVal idempresa As Integer, pCodigo As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = Consultas.AUMENTAR_CONSECUTIVO
                dbCommand.Parameters.Add(New SqlParameter("@IDEMPRESA", SqlDbType.Int)).Value = idempresa
                dbCommand.Parameters.Add(New SqlParameter("@CODIGODOCUMENTO", SqlDbType.Int)).Value = pCodigo
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub removerUltimafila(dt As DataTable, datagrid As DataGridView)
        dt.Rows.RemoveAt(datagrid.RowCount - 1)
    End Sub
    Public Shared Function obtenerPucActivo() As Integer
        Dim drPuc As DataRow
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        drPuc = General.cargarItem(Consultas.PUC_ACTIVO, params)
        If drPuc.Item(0) IsNot DBNull.Value Then
            Return drPuc.Item(0).ToString()
        End If
        Return Nothing
    End Function

    Public Shared Sub verificarCuenta(indiceFila As Integer, codigoPuc As Integer, codigoCuenta As Integer, nombreColumnsCodigo As String, nombreColumns As String, dtComprobante As DataTable)
        Dim dtrows As DataRow
        Dim descripcion As String
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add(codigoCuenta)
        dtrows = FuncionesContables.digitarCuenta(params)
        If Not IsNothing(dtrows) Then
            descripcion = dtrows.Item(2)
            If Not String.IsNullOrEmpty(descripcion) AndAlso String.IsNullOrEmpty(dtComprobante.Rows(indiceFila).Item(nombreColumns).ToString) Then
                dtComprobante.Rows(indiceFila).Item(nombreColumns) = descripcion
                dtComprobante.Rows.Add()
            ElseIf Not String.IsNullOrEmpty(descripcion) AndAlso Not String.IsNullOrEmpty(dtComprobante.Rows(indiceFila).Item(nombreColumns).ToString) Then
                dtComprobante.Rows(indiceFila).Item(nombreColumns) = descripcion
            Else
                If MsgBox("Esta cuenta no existe ¿Desea crearla?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Crear") = MsgBoxResult.Yes Then
                    Dim formCuenta As New Form_CuentasPUC
                    formCuenta.ShowDialog()
                Else
                    dtComprobante.Rows(dtComprobante.Rows.Count - 1).Item(nombreColumnsCodigo) = ""
                    dtComprobante.Rows(dtComprobante.Rows.Count - 1).Item(nombreColumns) = ""
                End If
            End If
        Else
            dtComprobante.Rows(dtComprobante.Rows.Count - 1).Item(nombreColumnsCodigo) = ""
            If dtComprobante.Rows.Count > 1 Then
                dtComprobante.Rows.RemoveAt(indiceFila)
            End If
        End If
    End Sub



    Public Shared Function consultarMovimientosComprobante(consulta As String, comprobante As String) As Boolean
        Dim dtComprobante As New DataTable
        Dim params As New List(Of String)
        params.Add(comprobante)
        General.llenarTabla(consulta, params, dtComprobante)
        If dtComprobante.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Public Shared Function digitarCuenta(params As List(Of String)) As DataRow
        Dim drCuenta As DataRow
        drCuenta = General.cargarItem(Consultas.CUENTAS_DETALLE_CARGAR, params)
        If Not IsNothing(drCuenta) Then
            Return drCuenta
        Else
            MsgBox("Esta cuenta no existe", MsgBoxStyle.Exclamation)
        End If
        Return Nothing
    End Function
    Public Shared Function validardgv(dt As DataTable) As Boolean
        If dt.Select("debito =0 and credito=0").Count > 1 Then
            MsgBox("Hay cuentas con valores en cero!!", MsgBoxStyle.Exclamation)
            Return False
            If dt.Rows.Count = 1 Then
                MsgBox("Por favor corrija el movimiento, podria faltar datos!!", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
        Return True
    End Function

    Public Shared Function validarFechaFutura(fecha As DateTimePicker) As Boolean
        If fecha.Value.Date > General.fechaActualServidor Then
            MsgBox("La fecha no puede ser mayor a la actual", MsgBoxStyle.Exclamation)
            fecha.Value = General.fechaActualServidor
            Return False
        End If
        Return True
    End Function
    Public Shared Sub ValidarCreditoDebito(datagrid As DataGridView, NomColumna As String, NomColumnaEvaluar As String)
        If datagrid.RowCount > 0 Then
            If datagrid.Rows(datagrid.CurrentCell.RowIndex).Cells(NomColumnaEvaluar).Value.ToString <> "" Then
                If datagrid.Rows(datagrid.CurrentCell.RowIndex).Cells(NomColumnaEvaluar).Value > 0 Then
                    datagrid.Rows(datagrid.CurrentCell.RowIndex).Cells(NomColumna).ReadOnly = True
                Else
                    datagrid.Rows(datagrid.CurrentCell.RowIndex).Cells(NomColumna).ReadOnly = False
                End If
            End If
        End If
    End Sub
    Public Shared Function verificarFecha(fecha As Date) As Boolean
        Dim dtfecha As New DataTable
        Dim params As New List(Of String)
        params.Add(Format(fecha, Constantes.FORMATO_FECHA_GEN))
        General.llenarTabla(Consultas.FECHA_CERRADA, params, dtfecha)
        If dtfecha.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Shared Function VerificarCuentaTercero(idEmpresa As Integer, idTercero As Integer, consulta As String, dgv As DataGridView) As Boolean
        Dim dtCuenta As New DataTable
        Dim params As New List(Of String)
        params.Add(idTercero)
        params.Add(idEmpresa)
        General.llenarTabla(consulta, params, dtCuenta)
        If dtCuenta.Rows.Count > 0 Then
            For indicedtCuentas = 0 To dgv.Rows.Count - 1
                If dgv.Rows(indicedtCuentas).Cells(1).Value.ToString = dtCuenta.Rows(0).Item("Cuenta").ToString Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    Public Shared Function verificarComprobante(comprobante As String) As Boolean
        Dim dtComprobante As New DataTable
        Dim params As New List(Of String)
        params.Add(comprobante)
        General.llenarTabla(Consultas.COMPROBANTE_ANULADO_VERIFICAR, params, dtComprobante)
        If dtComprobante.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Shared Function getTipoCuentaPUC(ByVal codTipoCuenta As String) As String
        Dim descripcion As String = ""

        Select Case codTipoCuenta
            Case "D"
                descripcion = "DETALLE"
            Case "T"
                descripcion = "TITULO"
        End Select

        Return descripcion
    End Function

    Public Shared Function getClasificacionCuenta(ByVal codTipoCuenta As String) As String
        Dim descripcion As String = ""

        Select Case codTipoCuenta
            Case "B"
                descripcion = "BALANCE"
            Case "O"
                descripcion = "ORDEN"
            Case "R"
                descripcion = "RESULTADO"
        End Select

        Return descripcion
    End Function

    Public Shared Function getNaturalezaCuenta(ByVal codTipoCuenta As String) As String
        Dim descripcion As String = ""

        Select Case codTipoCuenta
            Case "D"
                descripcion = "DEBITO"
            Case "C"
                descripcion = "CREDITO"
        End Select

        Return descripcion
    End Function


    Public Shared Function validarCuentaPuc(codigoPuc As Integer, codigoCuenta As String)
        Dim drPuc As DataRow
        Dim params As New List(Of String)

        Dim consultaPuc As String = Consultas.VALIDAR_CUENTA_PUC & "(" & codigoPuc & ", '" & codigoCuenta & "')"
        drPuc = General.cargarItem(consultaPuc, Nothing)

        If drPuc.Item(0) IsNot DBNull.Value Then
            Return drPuc.Item(0)
        End If

        Return estadoCuentaPuc.invalida
    End Function

End Class
