Imports System.Data.SqlClient
Public Class Form_Departamento
    Dim clasedepar As New DepartamentoBLL
    Public bdepar As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Form_Departamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        If txtcodigo.Text = "" Then
            General.cargarCombo(Consultas.PAIS_BUSCAR, "Nombre", "Código", Combopais)
        End If
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
    End Sub

    Private Sub Form_Departamento_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda una pais y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 31/05/2016

        If txtcodigo.Text = "" Then
            MsgBox("¡ Por favor digite el codigo del departamento !", MsgBoxStyle.Exclamation)
            txtcodigo.Focus()
        ElseIf txtnombre.Text = "" Then
            MsgBox("¡ Por favor Falta el nombre departamento !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        ElseIf Combopais.SelectedValue = -1 Then
            MsgBox("¡ Por favor seleccione un pais !", MsgBoxStyle.Exclamation)
            Combopais.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                If clasedepar.guardar_depar(txtcodigo.Text, txtnombre.Text, Combopais.SelectedValue) = True Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                End If
            End If
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
            txtcodigo.ReadOnly = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then

            General.buscarElemento(Consultas.BUSQUEDA_DEPARTAMENTO, Nothing,
                            AddressOf cargarDepartamento,
                            TitulosForm.BUSQUEDA_DEPARTAMENTO,
                            False, 0, True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarDepartamento(pcodigo As Integer)
        Dim dt As New DataTable
        Dim param As New List(Of String)
        param.Add(pcodigo)
        General.llenarTabla(Consultas.BUSQUEDA_DEPARTAMENTO_CARGAR, param, dt)

        txtcodigo.Text = pcodigo
        txtnombre.Text = dt.Rows(0).Item("Departamento")
        Combopais.SelectedValue = dt.Rows(0).Item("Codigo_Pais")

        bteditar.Enabled = True
        btcancelar.Enabled = False
        btanular.Enabled = True
        txtnombre.ReadOnly = True
        txtcodigo.ReadOnly = True
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            txtcodigo.ReadOnly = True
            txtnombre.ReadOnly = False
            General.deshabilitarBotones(ToolStrip1)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 05/05/2016
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                If clasedepar.anular_depar(txtcodigo.Text.ToString, Combopais.SelectedValue) = True Then
                    General.limpiarControles(Me)

                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    btanular.Enabled = False
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    btguardar.Enabled = False
                End If
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub


End Class