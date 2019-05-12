
Public Class Form_Otro_Si
    Dim cmd As New OtroSiBLL
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim busotrosi As Boolean
    Dim vFormPadre As Object
    Public Property objFormContrato As Form_Contrato
    Public Sub iniciarForm(ByRef vFormPadre As Object)
        Me.vFormPadre = vFormPadre
    End Sub
    'Sub New(pContrato As String)

    '    ' Esta llamada es exigida por el diseñador
    '    InitializeComponent()

    '    Textcodigo_contrato.Text = pContrato

    'End Sub
    'Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If btguardar.Enabled = True Then
    '        e.Cancel = True
    '        MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If
    '    If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
    '        Me.Dispose()
    '    Else
    '        e.Cancel = True
    '    End If
    'End Sub
    Private Sub Textvalor_si_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textvalor_si.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub
    Private Sub Form_Otro_Si_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        fecha_ini_si.Enabled = False
        fecha_fin_si.Enabled = False

    End Sub
    Public Sub cargarInformacionContrato(codigo As String, nombre As String)
        Textcodigo_contrato.Text = codigo
        textdescripcion.Text = nombre
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            Textvalor_si.ReadOnly = False
            fecha_ini_si.Enabled = True
            fecha_fin_si.Enabled = True
            vigente.Enabled = True
            Textvalor_si.Focus()
            General.deshabilitarControles(GroupBox4)
            General.deshabilitarBotones(Me.ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If Textvalor_si.Text = "" Then
            MsgBox("Por favor digite un valor", MsgBoxStyle.Exclamation)
        ElseIf fecha_ini_si.Value.ToString >= fecha_fin_si.Value.ToString Then
            MsgBox("La fecha final no debe de ser Igual o menor a la fecha Inicio", MsgBoxStyle.Exclamation)
            fecha_fin_si.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                Dim otrosi1 As New OtroSi

                otrosi1.codigo = Textcodigo.Text
                otrosi1.Codigo_contrato = Textcodigo_contrato.Text
                otrosi1.valor = Textvalor_si.Text
                otrosi1.Fecha_Ini = fecha_ini_si.Value
                otrosi1.Fecha_Final = fecha_fin_si.Value
                otrosi1.vigente = vigente.Checked


                If cmd.Guardarotrosi(otrosi1) = True Then
                    Textcodigo.Text = otrosi1.codigo
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    fecha_ini_si.Enabled = False
                    fecha_fin_si.Enabled = False
                    Textvalor_si.ReadOnly = True
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False

                    vFormPadre.Textvalor_si.Text = Textvalor_si.Text
                    vFormPadre.fecha_ini_si.Value = fecha_ini_si.Value
                    vFormPadre.fecha_fin_si.Value = fecha_fin_si.Value
                    vFormPadre.btotrosi.enabled = False
                    Close()
                End If

            End If
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim listaOcultar = {"0", "1", "6"}
        Exec.buscarConOculrEx(Consultas.BUSQUEDA_OTRO_SI & Textcodigo_contrato.Text,
                              AddressOf cargar,
                              TitulosForm.BUSQUEDA_OTRO_SI,
                              listaOcultar.ToList)
    End Sub
    Sub cargar(pcodigo As String)

        Using dt As New DataTable

            General.llenarTablaYdgv(Consultas.CARGAR_OTRO_SI & pcodigo, dt)

            Dim dw = dt(0)

            Textcodigo.Text = pcodigo
            Textcodigo_contrato.Text = dw(1).ToString()
            textdescripcion.Text = dw(2).ToString()
            Textvalor_si.Text = dw(5).ToString()
            fecha_ini_si.Value = dw(3).ToString()
            fecha_fin_si.Value = dw(4).ToString()
            vigente.Checked = dw(6).ToString()

        End Using

        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False
        busotrosi = False

    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            fecha_ini_si.Enabled = False
            fecha_fin_si.Enabled = False
            Textvalor_si.ReadOnly = True
            Textvalor_si.Clear()
            vigente.Enabled = False
            vigente.Checked = False
            General.deshabilitarBotones(ToolStrip1)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If cmd.otrosiAnular(Textcodigo.Text, SesionActual.idUsuario) = True Then
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.deshabilitarBotones(ToolStrip1)
                    Textvalor_si.Clear()
                    Textcodigo.Clear()
                    fecha_ini_si.Enabled = False
                    fecha_fin_si.Enabled = False
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    Textcodigo.Clear()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class