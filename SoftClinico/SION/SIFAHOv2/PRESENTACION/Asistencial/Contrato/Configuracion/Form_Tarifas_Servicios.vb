Imports System.Data.SqlClient
Public Class Form_Tarifas_Servicios
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim Combotarifaimag, Combotarifalab, combotarifaproce As ComboBox
    Dim fecha As DateTime
    Private Sub Form_Tarifas_Servicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(Me)
        fecha = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        General.cargarCombo(Consultas.TIPO_CODIGO_REFERENCIA_BUSCAR, "Nombre", "Código", Combocodref)
        Radiomas.Checked = True
        textaño.Value = fecha.Year
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            General.deshabilitarControles(Me)
            Textcodigo.ReadOnly = True
            textdescripcion.ReadOnly = True
            Combocodref.Enabled = True
            Combocodref.Focus()

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub validarDescripcionTarifa()
        If Combocodref.SelectedValue > 0 And Radiomas.Checked = True Then
            textdescripcion.Text = Combocodref.Text.ToString & " " & Radiomas.Text & " " & textporcentaje.Text & "%"
        ElseIf Combocodref.SelectedValue > 0 And Radiomenos.Checked = True Then
            textdescripcion.Text = Combocodref.Text & " " & Radiomenos.Text & " " & textporcentaje.Text & "%"
        ElseIf Combocodref.SelectedValue > 0 And Radiomas.Checked = True Then
            textdescripcion.Text = Combocodref.Text & " " & Radiomas.Text & " " & textporcentaje.Text & "%"
        ElseIf Combocodref.SelectedValue > 0 And Radiomenos.Checked = True Then
            textdescripcion.Text = Combocodref.Text & " " & Radiomenos.Text & " " & textporcentaje.Text & "%"
        ElseIf Combocodref.SelectedValue > 0 And Rbpleno.Checked = True Then
            textdescripcion.Text = Combocodref.Text & " " & Rbpleno.Text
        ElseIf Combocodref.SelectedValue > 0 = True And Rbpleno.Checked = True Then
            textdescripcion.Text = Combocodref.Text & " " & Rbpleno.Text
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If Combocodref.SelectedIndex < 1 Then
            MsgBox("¡ Por favor elija un código de referencia!", MsgBoxStyle.Information,)
            Combocodref.Focus()
        ElseIf Rbpleno.Checked = False And textporcentaje.Text = "" Then
            MsgBox("¡ Por favor digite el valor porcentaje!", MsgBoxStyle.Information,)
            textporcentaje.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardarTarifaDeServicios()
            End If
        End If
    End Sub
    Public Sub guardarTarifaDeServicios()

        Dim objTarifaDeServiciosBll As New TarifaServicioBLL
        Try
            Textcodigo.Text = objTarifaDeServiciosBll.guardarTarifa(crearTarifaDeServicios())
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Function crearTarifaDeServicios() As TarifaDeServicios
        Dim salario As Double
        salario = textsalario.Text
        Dim objTarifaDeServicios As New TarifaDeServicios
        validarDescripcionTarifa()
        objTarifaDeServicios.codigoHa = Textcodigo.Text
        objTarifaDeServicios.descripcion = textdescripcion.Text
        objTarifaDeServicios.codigoTipoCodigo = Combocodref.SelectedValue
        objTarifaDeServicios.codigoEp = SesionActual.codigoEP
        objTarifaDeServicios.año = textaño.Value.ToString()
        objTarifaDeServicios.salario = textsalario.Text
        objTarifaDeServicios.porcentaje = textporcentaje.Text
        objTarifaDeServicios.usuarioCreacion = SesionActual.idUsuario
        Return objTarifaDeServicios
    End Function
    Private Sub cargarValores()
        If Combocodref.SelectedIndex = 1 Then
            textsalario.Text = Constantes.SALARIO_MINIMO_2001
            textsalario.ReadOnly = True
            textporcentaje.Focus()
            Rbpleno.Enabled = True
            Radiomas.Checked = True
            Radiomenos.Enabled = True
            Radiomas.Enabled = True
            textaño.Value = Constantes.AÑO_TARIFA_ISS
            textaño.Enabled = False
        Else
            textsalario.ReadOnly = False
            textsalario.Text = Constantes.SALARIO_MINIMO_ACTUAL
            Rbpleno.Enabled = True
            Radiomenos.Enabled = True
            Radiomas.Enabled = True
            textaño.Value = fecha.Year
            textaño.Enabled = True
        End If
        If Rbpleno.Checked = True Then
            textporcentaje.ReadOnly = True
            textporcentaje.Clear()
        Else
            textporcentaje.ReadOnly = False
        End If
    End Sub
    Private Sub Combocodref_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combocodref.SelectedIndexChanged
        If btguardar.Enabled = True Then
            cargarValores()
        End If
    End Sub
    Private Sub Rbpleno_CheckedChanged(sender As Object, e As EventArgs) Handles Rbpleno.CheckedChanged
        If Rbpleno.Checked = True Then
            textporcentaje.ReadOnly = True
            textporcentaje.Clear()
        End If
    End Sub
    Private Sub textporcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textporcentaje.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub
    Private Sub Radiomas_CheckedChanged(sender As Object, e As EventArgs) Handles Radiomas.CheckedChanged
        If Radiomas.Checked = True Then
            textporcentaje.ReadOnly = False
        End If
    End Sub

    Private Sub Radiomenos_CheckedChanged(sender As Object, e As EventArgs) Handles Radiomenos.CheckedChanged
        If Radiomenos.Checked = True Then
            textporcentaje.ReadOnly = False
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            textdescripcion.ReadOnly = True
            Textcodigo.ReadOnly = True
            cargarValores()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
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

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consultas.TARIFA_SERVICIO_LISTAR, Nothing, AddressOf cargarTarifa,
                                                        TitulosForm.BUSQUEDA_TARIFAS, True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarTarifa(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CARGA_TARIFA_SERVICIO, params, dtCarga)
        Textcodigo.Text = dtCarga.Rows(0).Item(0).ToString
        textdescripcion.Text = dtCarga.Rows(0).Item(1).ToString
        Combocodref.SelectedValue = dtCarga.Rows(0).Item(2).ToString
        If textdescripcion.Text.Contains("+") Then
            Radiomas.Checked = True
        ElseIf textdescripcion.Text.Contains("-") Then
            Radiomenos.Checked = True
        Else
            Rbpleno.Checked = True
            End If
            textaño.Text = dtCarga.Rows(0).Item(3)
        textsalario.Text = CDbl(dtCarga.Rows(0).Item(4).ToString).ToString("C2")
        textporcentaje.Text = dtCarga.Rows(0).Item(5).ToString
        bteditar.Enabled = True
        btanular.Enabled = True
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_TARIFA_SERVIVIO & "'" & CInt(Textcodigo.Text) & "'," & SesionActual.idUsuario)
                If respuesta = True Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                End If
            End If
        End If
    End Sub
End Class