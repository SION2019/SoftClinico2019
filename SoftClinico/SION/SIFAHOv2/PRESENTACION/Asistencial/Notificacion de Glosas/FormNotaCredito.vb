Public Class FormNotaCredito
    Dim reporte As New ftp_reportes
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, valorLetra As String
    Dim idTercero As Integer
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormNotaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(Me)
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            textfactura.ReadOnly = True
            btbuscarfactura.Enabled = False
            textValorFactura.ReadOnly = True
            textValorNota.ReadOnly = False
            btbuscareps.Enabled = True
            btguardar.Enabled = True
            textcodigoeps.ReadOnly = True
            textNombreEps.ReadOnly = True
            Checkdevolucion.Enabled = True
            Checkradicacion.Enabled = True
            Checkdevolucion.Checked = True
            Checkradicacion.Checked = True
            btcancelar.Enabled = True
            btbuscareps.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If textcodigoeps.Text = "" Then
            MsgBox("¡ Por favor elija una EPS!", MsgBoxStyle.Exclamation,)
            btbuscareps.Focus()
        ElseIf textfactura.Text = "" Then
            MsgBox("¡ Por favor elija una factura!", MsgBoxStyle.Exclamation,)
            textfactura.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardarNotaCredito()
            End If
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            General.buscarElemento(Consultas.NOTA_GLOSA_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_NOTAS_CREDITO,
                                   True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            textValorNota.ReadOnly = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(Txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.NOTA_GLOSA_ANULAR, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub Checkradicacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Checkradicacion.CheckedChanged
        If Checkradicacion.Checked = True Then
            dtFechaRad.Enabled = True
        Else
            dtFechaRad.Enabled = False
        End If
    End Sub

    Private Sub Checkdevolucion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Checkdevolucion.CheckedChanged
        If Checkdevolucion.Checked = True Then
            dtFechaDev.Enabled = True
        Else
            dtFechaDev.Enabled = False
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.NOTA_GLOSA_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            Txtcodigo.Text = pCodigo
            textNombreEps.Text = dt.Rows(0).Item("EPS").ToString()
            textcodigoeps.Text = dt.Rows(0).Item("Nit").ToString()
            textfactura.Text = dt.Rows(0).Item("Codigo_Factura").ToString()
            Textconcepto.Text = dt.Rows(0).Item("Concepto").ToString()
            textValorFactura.Text = CDbl(dt.Rows(0).Item("Valor_Factura").ToString()).ToString("C2")
            textValorNota.Text = CDbl(dt.Rows(0).Item("Valor_Nota").ToString()).ToString("C2")
            If String.IsNullOrEmpty(dt.Rows(0).Item("fecha_Radicacion").ToString()) Then
                dtFechaRad.Value = Date.Now
                Checkradicacion.Checked = False
            Else
                dtFechaRad.Value = dt.Rows(0).Item("fecha_Radicacion").ToString()
                Checkradicacion.Checked = True
            End If
            If String.IsNullOrEmpty(dt.Rows(0).Item("fecha_Devolucion").ToString()) Then
                dtFechaDev.Value = Date.Now
                Checkdevolucion.Checked = False
            Else
                dtFechaDev.Value = dt.Rows(0).Item("fecha_Devolucion").ToString()
                Checkdevolucion.Checked = True
            End If
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False

        End If
    End Sub
    Public Sub guardarNotaCredito()

        Dim objNotaCreditoBll As New NotaCreditoBLL
        Try
            Txtcodigo.Text = objNotaCreditoBll.guardarNotaCredito(crearNotaCredito())
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            btimprimir.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Function crearNotaCredito() As NotaCredito
        Dim valorNota As Double
        Dim objNotaCredito As New NotaCredito
        valorNota = textValorNota.Text
        objNotaCredito.Id_Nota = Txtcodigo.Text
        objNotaCredito.Factura = textfactura.Text
        If Checkradicacion.Checked = False Then
            objNotaCredito.fechaRadicacion = nothing
        Else
            objNotaCredito.fechaRadicacion = dtFechaRad.Value
        End If
        If Checkdevolucion.Checked = False Then
            objNotaCredito.fechaDevolucion = Nothing
        Else
            objNotaCredito.fechaDevolucion = dtFechaDev.Value
        End If
        objNotaCredito.idEmpresa = SesionActual.idEmpresa
        objNotaCredito.concepto = Textconcepto.Text
        Dim Convertir As New ConvertirNumeros
        Convertir.Convertir_Numero(textValorNota.Text)
        objNotaCredito.valorLetra = Convertir.NumeroConvertido
        objNotaCredito.usuarioCreacion = SesionActual.idUsuario
        objNotaCredito.OpcionFechaRadicacion = Checkradicacion.Checked
        objNotaCredito.OpcionFechaDevolucion = Checkdevolucion.Checked
        Return objNotaCredito
    End Function
    Private Sub dtFechaDev_KeyDown(
          sender As Object, e As KeyEventArgs) _
          Handles dtFechaDev.KeyDown
        e.SuppressKeyPress = True
    End Sub
    Private Sub btbuscarfactura_Click(sender As Object, e As EventArgs) Handles btbuscarfactura.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(idTercero)
        General.buscarElemento(Consultas.FACTURA_GLOSA_BUSCAR,
                               params,
                               AddressOf cargarFactura,
                               TitulosForm.BUSQUEDA_FACTURAS,
                               False, 0, True)
    End Sub
    Private Sub cargarFactura(pFatura As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pFatura)
        General.llenarTabla(Consultas.FACTURA_GLOSA_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textfactura.Text = pFatura
            textValorFactura.Text = CDbl(dt.Rows(0).Item("Total_Factura").ToString()).ToString("C2")
            textValorNota.Text = CDbl(dt.Rows(0).Item("Valor_glosa_aceptada").ToString()).ToString("C2")
            dtFechaRad.Value = dt.Rows(0).Item("fecha_doc").ToString()
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    '
    Private Sub btbuscareps_Click(sender As Object, e As EventArgs) Handles btbuscareps.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.NOTIFICACION_GLOSA_BUSCAR_CLIENTES,
                              params,
                              AddressOf cargarEps,
                              TitulosForm.BUSQUEDA_EPS,
                              True, 0, True)
    End Sub
    Public Sub cargarEps(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        idTercero = pCodigo
        General.llenarTabla(Consultas.CONTA_CLIENTE_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textfactura.Clear()
            textcodigoeps.Text = dt.Rows(0).Item("Nit").ToString()
            textNombreEps.Text = dt.Rows(0).Item("CLIENTE").ToString()
            btbuscarfactura.Enabled = True
            btbuscarfactura.Enabled = True

        End If
    End Sub
    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim rptNotaCredito As New rptNotaCredito
        Dim Convertir As New ConvertirNumeros
        Convertir.Convertir_Numero(textValorNota.Text)
        valorLetra = Convertir.NumeroConvertido
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pValorFactura", textValorFactura.Text)
            tbl.Add("@pValorNota", textValorNota.Text)
            tbl.Add("@pValorLetras", valorLetra)
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(rptNotaCredito, "{VISTA_NOTA_GLOSA.Id_Nota} = " & Txtcodigo.Text & "AND {VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa & "", "Nota Glosa", Constantes.FORMATO_PDF, tbl)
            Cursor = Cursors.Default
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class