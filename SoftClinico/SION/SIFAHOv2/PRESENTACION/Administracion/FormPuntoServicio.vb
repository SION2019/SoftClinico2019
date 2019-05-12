Imports System.IO
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class FormPuntoServicio
    Dim id_responsable As Integer
    Dim puntos As New PuntoServicioDAL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pmodulo, PAsignar As String
    Private Sub Punto_Servicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PAsignar = permiso_general & "pp" & "05"
        Pmodulo = permiso_general & "pp" & "06"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        Combopais.SelectedIndex = 0
        General.deshabilitarControles(Me)
        ToolStrip1.Focus()
    End Sub

    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub


    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Pnuevo & "'", "").Count > 0 Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            Combopais.Focus()
            txtCedula.ReadOnly = True
            txtresponsable.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda un punto de servicio y actualiza: 
        'Autor: Resident7
        'fecha_creacion: 05/05/2016
        Try
            If txtnombre.Text = "" Then
                MsgBox("¡ Por favor digite el nombre del punto de servicio !", MsgBoxStyle.Exclamation)
                txtnombre.Focus()
            ElseIf txttelefono.Text = "" Then
                MsgBox("¡ Por favor digite un numero de teléfono !", MsgBoxStyle.Exclamation)
                txttelefono.Focus()
            ElseIf txtdireccion.Text = "" Then
                MsgBox("¡ Por favor digite la dirección de este punto !", MsgBoxStyle.Exclamation)
                txtdireccion.Focus()
            ElseIf (Combopais.Text = "") Then
                MsgBox("¡  Por favor digite el pais donde se encuentra este punto !", MsgBoxStyle.Exclamation)
                Combopais.Focus()
            ElseIf (Combodepartamento.Text = "") Then
                MsgBox("¡  Por favor escoja el departamento donde se encuentra este punto !", MsgBoxStyle.Exclamation)
                Combodepartamento.Focus()
            ElseIf (Combociudad.Text = "") Then
                MsgBox("¡  Por favor escoja la ciudad donde se encuentra este punto !", MsgBoxStyle.Exclamation)
                Combociudad.Focus()
            ElseIf (txtCedula.Text = "") Then
                MsgBox("¡ Por favor seleccione el responsable de este punto de servicio !", MsgBoxStyle.Exclamation)
                txtCedula.Focus()
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    Dim vPuntoServicio As New PuntoServicio

                    vPuntoServicio.codigo = txtcodigo.Text
                    vPuntoServicio.observaciones = observaciones.Text
                    vPuntoServicio.direccion = txtdireccion.Text
                    vPuntoServicio.nombre = txtnombre.Text
                    vPuntoServicio.telefono = txttelefono.Text
                    vPuntoServicio.correspondencia = correspondencia.Text
                    vPuntoServicio.Combopais = Combopais.SelectedValue.ToString.Trim
                    vPuntoServicio.Combodepartamento = Combodepartamento.SelectedValue.ToString.Trim
                    vPuntoServicio.Combociudad = Combociudad.SelectedValue.ToString.Trim
                    vPuntoServicio.id_responsable = id_responsable
                    vPuntoServicio.asignar = asignar.Checked
                    vPuntoServicio.activo = activo.Checked

                    If puntos.guardar(vPuntoServicio) = True Then
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        General.habilitarBotones(ToolStrip1)
                        General.deshabilitarControles(Me)
                        btguardar.Enabled = False '--Guardar--
                        btcancelar.Enabled = False '--Cancelar--
                        btOpcionModulos.Enabled = True
                    End If
                    txtcodigo.Text = vPuntoServicio.codigo
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Peditar & "'", "").Count > 0 Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                txtcodigo.ReadOnly = True
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                btOpcionModulos.Enabled = False
                If FormPrincipal.idEmpresa = 0 And txtcodigo.Text = Constantes.CODIGO_PUNTO_SERVICIO_ADMIN Then
                    asignar.Enabled = False
                End If
                If txtcodigo.Text = Constantes.CODIGO_PUNTO_SERVICIO_ADMIN Then
                    activo.Enabled = False
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub Punto_Servicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub asignar_CheckedChanged(sender As Object, e As EventArgs) Handles asignar.CheckedChanged


    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If txtcodigo.Text = Constantes.CODIGO_PUNTO_SERVICIO_ADMIN Then
                MsgBox(Mensajes.NO_ANULAR_PUNTO_SERVICIO, MsgBoxStyle.Critical)
                Exit Sub
            End If
            If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Panular & "'", "").Count > 0 Then
                'descripcion Anula un registro: 
                'Autor: Resident7
                'fecha_creacion: 05/05/2016
                If MsgBox(Mensajes.ANULAR & ": " & txtnombre.Text.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    If puntos.anular(txtcodigo.Text.Trim) = True Then
                        General.limpiarControles(Me)
                        General.deshabilitarBotones(ToolStrip1)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        btOpcionModulos.Enabled = False
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles btOpcionModulos.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Pmodulo & "'", "").Count > 0 Then
            If txtcodigo.Text <> "" Then
                If btguardar.Enabled = False And asignar.Checked = True Then
                    FormModulosEmpresa.MdiParent = FormPrincipal
                    FormModulosEmpresa.Codigo_punto = txtcodigo.Text
                    FormModulosEmpresa.Show()
                    FormModulosEmpresa.Focus()
                    If FormModulosEmpresa.WindowState = FormWindowState.Minimized Then
                        FormModulosEmpresa.WindowState = FormWindowState.Normal
                    End If
                Else
                    MsgBox(Mensajes.SELECCIONE_PUNTO_ASIGNADO, MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(Mensajes.SELECCIONE_PUNTO_ASIGNADO, MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If


    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & PBuscar & "'", "").Count > 0 Then
            Dim listaOcultar = {"0", "2", "3", "4", "5", "6", "8", "10", "12", "16"}

            Exec.buscarConOculrEx(Consultas.BUSQUEDA_PUNTO_SERVICIO & FormPrincipal.idEmpresa,
                                  AddressOf cargar,
                                  TitulosForm.BUSQUEDA_PUNTO_SERVICIO,
                                  listaOcultar.ToList)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Sub cargar(pcodigo As String)
        Dim vSQL = String.Format(Consultas.CARGAR_PUNTO_SERVICIO, pcodigo, FormPrincipal.idEmpresa)
        Using dt As New DataTable

            General.llenarTablaYdgv(vSQL, dt)

            Dim dw = dt(0)

            txtcodigo.Text = pcodigo
            txtnombre.Text = dw(1).ToString()
            observaciones.Text = dw(2).ToString()
            txtdireccion.Text = dw(3).ToString()
            txttelefono.Text = dw(4).ToString()
            correspondencia.Text = dw(5).ToString()
            Combopais.SelectedValue = dw(6).ToString()
            Combodepartamento.SelectedValue = dw(8).ToString()
            Combociudad.SelectedValue = dw(10).ToString()
            id_responsable = dw(12).ToString()
            txtCedula.Text = dw(16).ToString()
            txtresponsable.Text = dw(13).ToString()
            activo.Checked = dw(14).ToString()
            asignar.Checked = dw(15).ToString()

        End Using

        bteditar.Enabled = True
        btanular.Enabled = True
        btOpcionModulos.Enabled = True

    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub btbuscarrepresentante_Click(sender As Object, e As EventArgs) Handles btbuscarrepresentante.Click
        Dim listaOcultar = {"0", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "21"}

        Exec.buscarConOculrEx(Consultas.BUSQUEDA_TERCERO_PS,
                              AddressOf cargarResentante,
                              TitulosForm.BUSQUEDA_TERCERO,
                              listaOcultar.ToList)

    End Sub

    Sub cargarResentante(pcodigo As String)

        Dim vSQL = String.Format(Consultas.CARGAR_TERCERO_PS, pcodigo)
        Using dt As New DataTable

            General.llenarTablaYdgv(vSQL, dt)

            Dim dw = dt(0)

            id_responsable = pcodigo
            txtCedula.Text = dw("Nit").ToString()
            txtresponsable.Text = dw("Tercero").ToString()

        End Using
    End Sub
End Class