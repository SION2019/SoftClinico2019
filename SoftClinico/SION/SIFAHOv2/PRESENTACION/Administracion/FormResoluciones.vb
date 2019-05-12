
Imports System.Data.SqlClient
Public Class FormResoluciones
    Dim seleccion As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Plinea, Pcualidad, Pgrupo, Pprese, Pviaadmin As String
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Peditar & "'", "").Count > 0 Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            If activar.Checked = True Then
                activar.Enabled = False
            End If

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Textrangoini_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Textrangoini.KeyPress, Textresolucion.KeyPress, Textrangofin.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Public Sub calcularRango()
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.RANGO_RESOLUCION & "'" & Textidempresa.Text & "'", dt)
        If dt.Rows.Count > 0 Then
            Textrangoini.Text = dt.Rows(0).Item("Respuesta")
            Textconseactual.Text = dt.Rows(0).Item("Respuesta")
        End If
    End Sub
    Private Function validarInformacion()
        If (Textresolucion.Text = "") Then
            MsgBox("¡ Por favor digite el numero de la resolucion!", MsgBoxStyle.Information)
            Textresolucion.Focus()
            Return False
        ElseIf (Textrangoini.Text = "") Then
            MsgBox("¡ Por favor digite el consecutivo de inicio de la resolucion!", MsgBoxStyle.Information)
            Textrangoini.Focus()
            Return False
        ElseIf (Textrangofin.Text = "") Then
            MsgBox("¡ Por favor digite el consecutivo final de la resolucion!", MsgBoxStyle.Information)
            Textrangofin.Focus()
            Return False
        ElseIf (Textconseactual.Text = "") Then
            MsgBox("¡ Por favor digite consecutivo actual de la resolucion!", MsgBoxStyle.Information)
            Textconseactual.Focus()
            Return False
        ElseIf Format(CDate(fechainicio.Value), Constantes.FORMATO_FECHA_GEN) >= Format(CDate(fechavence.Value), Constantes.FORMATO_FECHA_GEN) Then
            MsgBox("La fecha de vencimiento no puede ser menor o igual a la fecha de inicio!", MsgBoxStyle.Information)
            fechavence.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarResolucion()
        End If
    End Sub
    Private Sub guardarResolucion()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                Textcodigo.Text = ResolucionBLL.guardarResolucion(Textcodigo.Text, Textidempresa.Text,
                                         Textresolucion.Text, Textprefijo.Text, Textrangoini.Text, Textconseactual.Text, Textrangofin.Text,
                                        fechainicio.Value, fechavence.Value, seleccion)

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)

    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Panular & "'", "").Count > 0 Then
            If activar.Checked = False Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularSinTransaccion(Consultas.ANULAR_RESOLUCION & "'" & CInt(Textcodigo.Text) & "'," & FormPrincipal.usuarioActual)
                    If respuesta = True Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            Else
                MsgBox("No se puede anular una resolucion activa ", MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & PBuscar & "'", "").Count > 0 Then
            General.buscarElemento(Consultas.BUSQUEDA_RESOLUCION,
                                   Nothing,
                                   AddressOf cargarResoluciones,
                                   TitulosForm.BUSQUEDA_RESOLUCION,
                                   False)

            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub form_Resoluciones_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Pnuevo & "'", "").Count > 0 Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            btbuscarempresa.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub activar_CheckedChanged(sender As Object, e As EventArgs) Handles activar.CheckedChanged
        If activar.Checked = True Then
            seleccion = 1
        Else
            seleccion = 0
        End If
    End Sub

    Private Sub Form_Resoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub btbuscarempresa_Click(sender As Object, e As EventArgs) Handles btbuscarempresa.Click
        General.buscarElemento(Consultas.BUSQUEDA_EMPRESA,
                                   Nothing,
                                   AddressOf cargarEmpresa,
                                   TitulosForm.BUSQUEDA_EMPRESA,
                                   False)
    End Sub

    Private Sub cargarEmpresa(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR,
                                              params)

        Textnit.Text = dr.Item(2)
        Textrazonsocial.Text = dr.Item(4)
    End Sub
    Private Sub cargarResoluciones(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CONSULTAR_RESOLUCION,
                                              params)

        Textcodigo.Text = pCodigo
        Textidempresa.Text = dr.Item(0)
        Textnit.Text = dr.Item(1)
        Textrazonsocial.Text = dr.Item(2)
        Textresolucion.Text = dr.Item(3)
        Textprefijo.Text = dr.Item(4)
        Textrangoini.Text = dr.Item(5)
        Textrangofin.Text = dr.Item(6)
        Textconseactual.Text = dr.Item(7)
        fechainicio.Text = dr.Item(8)
        fechavence.Text = dr.Item(9)
        activar.Checked = dr.Item(10)
    End Sub
End Class