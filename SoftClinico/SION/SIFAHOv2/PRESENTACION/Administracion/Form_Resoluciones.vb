
Imports System.Data.SqlClient
Public Class Form_Resoluciones
    Dim estadoResolucion As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Plinea, Pcualidad, Pgrupo, Pprese, Pviaadmin As String

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            If activar.Checked = True Then
                activar.Enabled = False
            End If
            Textrazonsocial.ReadOnly = True
            Textnit.ReadOnly = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Textrangoini_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Textrangoini.KeyPress, Textresolucion.KeyPress, Textrangofin.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub Textprefijo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Textprefijo.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub
    Public Sub calcularRango(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.RANGO_RESOLUCION, params, dt)
        If dt.Rows.Count > 0 Then
            Textrangoini.Text = dt.Rows(0).Item("Respuesta")
            Textconseactual.Text = dt.Rows(0).Item("Respuesta")
        End If
    End Sub
    Private Function validarInformacion()

        If (Textnit.Text = "") Then
            MsgBox("¡ Por favor elija una empresa!", MsgBoxStyle.Information)
            btbuscarempresa.Focus()
            Return False
        ElseIf (Textresolucion.Text = "") Then
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
        ElseIf CDate(fechainicio.Value) >= CDate(fechavence.Value) Then
            MsgBox("La fecha de vencimiento no puede ser menor o igual a la fecha de inicio!", MsgBoxStyle.Information)
            fechavence.Focus()
            Return False
        ElseIf CInt(Textrangofin.text) < CInt(Textrangoini.text) Then
            MsgBox("El rango final no puede ser menor al inicial", MsgBoxStyle.Information)
            Textrangofin.Focus()
            Return False
        ElseIf CInt(Textconseactual.text) < CInt(Textrangoini.text) Or CInt(Textconseactual.text) > CInt(Textrangofin.text) Then
            MsgBox("El valor del consecutivo actual debe estar entre el rango inicial y el final", MsgBoxStyle.Information)
            Textconseactual.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarResolucion()
        End If
    End Sub
    Public Function crearResolucion() As Resolucion
        Dim objResolucion As New Resolucion
        objResolucion.codigo = Textcodigo.Text
        objResolucion.idEmpresa = Textidempresa.Text
        objResolucion.resolucion = Textresolucion.Text
        objResolucion.prefijo = Textprefijo.Text
        objResolucion.conseInic = Textrangoini.Text
        objResolucion.conseActual = Textconseactual.Text
        objResolucion.conseFin = Textrangofin.Text
        objResolucion.fechaExpedicion = fechainicio.Value
        objResolucion.fechaVencimiento = fechavence.Value
        objResolucion.vigente = estadoResolucion
        objResolucion.usuario = SesionActual.idUsuario
        Return objResolucion
    End Function
    Private Sub guardarResolucion()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objResolucionBLL As New ResolucionBLL
                Textcodigo.Text = objResolucionBLL.guardarResolucion(crearResolucion())

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub Textrangofin_Leave(sender As Object, e As EventArgs) Handles Textrangofin.Leave
        If Textrangofin.Text <> "" Then
            Dim valorInicio, valorFinal As Integer
            valorInicio = Textrangoini.Text
            valorFinal = Textrangofin.Text
            If valorFinal < valorInicio Then
                MsgBox("El rango final no puede ser menor al inicial", MsgBoxStyle.Information)
                Textrangofin.Focus()
            End If
        End If
    End Sub

    Private Sub Textconseactual_Leave(sender As Object, e As EventArgs) Handles Textconseactual.Leave

        If Textconseactual.Text <> "" Then
            Dim valorInicio, valorFinal, valorActual As Integer
            valorInicio = Textrangoini.Text
            valorFinal = Textrangofin.Text
            valorActual = Textconseactual.Text
            If valorActual < valorInicio Or valorActual > valorFinal Then
                MsgBox("El valor del consecutivo actual debe estar entre el rango inicial y el final", MsgBoxStyle.Information)
                Textconseactual.Focus()
            End If
        End If
    End Sub
    Private Sub fechainicio_ValueChanged(sender As Object, e As EventArgs) Handles fechainicio.ValueChanged
        fechavence.Value = fechainicio.Value.AddYears(2)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim f As New FormEstadisticasCartera
        f.ShowDialog()
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Panular) Then
            If activar.Checked = False Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_RESOLUCION & "'" & CInt(Textcodigo.Text) & "'," & SesionActual.idUsuario)
                    If respuesta = True Then
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            Else
                MsgBox("No se puede anular una resolucion activa ", MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            General.buscarElemento(Consultas.BUSQUEDA_RESOLUCION,
                                   params,
                                   AddressOf cargarResoluciones,
                                   TitulosForm.BUSQUEDA_RESOLUCION,
                                   True,
                                   True,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub form_Resoluciones_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Public Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            btbuscarempresa.Focus()
            Textnit.ReadOnly = True
            Textrazonsocial.ReadOnly = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub activar_CheckedChanged(sender As Object, e As EventArgs) Handles activar.CheckedChanged
        If activar.Checked = True Then
            estadoResolucion = 1
        Else
            estadoResolucion = 0
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
        fechavence.Value = fechainicio.Value.AddYears(2)

    End Sub
    Private Sub btbuscarempresa_Click(sender As Object, e As EventArgs) Handles btbuscarempresa.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.BUSQUEDA_EMPRESA,
                                   params,
                                   AddressOf cargarEmpresa,
                                   TitulosForm.BUSQUEDA_EMPRESA,
                                   True)
    End Sub

    Private Sub cargarEmpresa(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR,
                                              params)
        Textidempresa.Text = dr.Item(0)
        Textnit.Text = dr.Item(2)
        Textrazonsocial.Text = dr.Item(4)
        Textresolucion.Focus()
        calcularRango(pCodigo)
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
        Textconseactual.Text = dr.Item(6)
        Textrangofin.Text = dr.Item(7)
        fechainicio.Text = dr.Item(8)
        fechavence.Text = dr.Item(9)
        activar.Checked = dr.Item(10)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
End Class