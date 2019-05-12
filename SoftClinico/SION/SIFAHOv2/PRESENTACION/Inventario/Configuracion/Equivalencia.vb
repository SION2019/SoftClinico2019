Imports System.Data.SqlClient
Public Class Equivalencia
    Public buscar_linea, buscar_equivalencia, buscar_farmaco As Boolean
    Dim objEquivalencia As New EquivalenciaInventario
    Dim sw, sw2 As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim respuesta As Boolean
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Plinea, Pcualidad, Pgrupo, Pprese, Pviaadmin As String
    Private Sub btlinea_Click(sender As Object, e As EventArgs) Handles btOpcionLinea.Click
        If SesionActual.tienePermiso(Plinea ) Then
            General.cargarForm(Lineas)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btOpcionFarmaco.Click
        If SesionActual.tienePermiso(Pgrupo ) Then
            General.cargarForm(Farmacologico)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Equivalencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pcualidad = permiso_general & "pp" & "05"
        Plinea = permiso_general & "pp" & "06"
        Pprese = permiso_general & "pp" & "07"
        Pgrupo = permiso_general & "pp" & "08"
        Pviaadmin = permiso_general & "pp" & "09"
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        btOpcionvia.Enabled = True
        '-----Cargar combos---------
        General.cargarCombo(Consultas.TEMPERATURA_LISTAR, "Siglas", "Código", combotemconse)
        General.cargarCombo(Consultas.RIESGO_LISTAR, "Nombre", "Código", Comboriesgo)
        General.cargarCombo(Consultas.PRESENTACION_LISTAR, "Nombre", "Código", comboprese)
        General.cargarCombo(Consultas.MEDIDA_UNIDAD_LISTAR, "Sigla", "Codigo_unidad", combonum)

        General.cargarCombo(Consultas.CUALIDADES_LISTAR, "Descripcion", "Código", Combocualidad)
        Numerictempmin.Value = 4
        Numeritemmax.Value = 25
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda una EQUIVALENCIA y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 13/05/2016
        If String.IsNullOrEmpty(txtcodigopos.Text) Then
            MsgBox("¡ Por favor digite el codigo POS!", MsgBoxStyle.Exclamation)
            txtcodigopos.Focus()
        ElseIf radiopos.Checked = False And radionopos.Checked = False Then
            MsgBox("¡ Por favor seleccione el medicamento POS o NOPOS !", MsgBoxStyle.Exclamation)
            txtgrupo.Focus()
        ElseIf txtdescripcion.Text = "" Then
            MsgBox("¡ Por favor digite la descripcion !", MsgBoxStyle.Exclamation)
            txtdescripcion.Focus()
        ElseIf comboprese.SelectedIndex <= 0 Then
            MsgBox("¡ Por favor seleccione presentacion !", MsgBoxStyle.Exclamation)
            comboprese.Focus()
        ElseIf combonum.SelectedIndex <= 0 Then
            MsgBox("¡ Por favor seleccione la unidad de medida !", MsgBoxStyle.Exclamation)
            combonum.Focus()
        ElseIf txtlinea.Text = "" Then
            MsgBox("¡ Por favor seleccione la linea !", MsgBoxStyle.Exclamation)
            txtlinea.Focus()
        ElseIf txtgrupo.Text = "" Then
            MsgBox("¡ Por favor seleccione el grupo !", MsgBoxStyle.Exclamation)
            txtgrupo.Focus()
        ElseIf Combocualidad.SelectedIndex <= 0 Then
            MsgBox("¡ Por favor seleccione cualidad !", MsgBoxStyle.Exclamation)
            Combocualidad.Focus()
        ElseIf txtduracion.Text = "" Then
            MsgBox("¡ Por favor digite la duracion minima !", MsgBoxStyle.Exclamation)
            txtduracion.Focus()
        ElseIf txtduracionmax.Text = "" Then
            MsgBox("¡ Por favor digite la duracion maxima !", MsgBoxStyle.Exclamation)
            txtduracionmax.Focus()

        ElseIf combotemconse.SelectedIndex <= 0 Then
            MsgBox("¡ Por favor seleccione la unidad de temperatura !", MsgBoxStyle.Exclamation)
            combotemconse.Focus()
        ElseIf Comboriesgo.SelectedIndex <= 0 Then
            MsgBox("¡ Por favor seleccione riesgo !", MsgBoxStyle.Exclamation)
            Comboriesgo.Focus()

        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim rboption As String
                If radiopos.Checked = True Then
                    rboption = Constantes.CATEGORIA_POS
                Else
                    rboption = Constantes.CATEGORIA_NO_POS
                End If
                If txtosmolalidad.Text = "" Then
                    txtosmolalidad.Text = Constantes.OSMOLALIDAD_POR_DEFECTO
                End If
                Try

                    objEquivalencia.codigopos = txtcodigopos.Text
                    objEquivalencia.descripcion = txtdescripcion.Text
                    objEquivalencia.grupo = txtgrupo.Text
                    objEquivalencia.rboption = rboption
                    objEquivalencia.linea = txtlinea.Text
                    objEquivalencia.comboprese = comboprese.SelectedValue.ToString
                    objEquivalencia.descripcionpro = txtdescripcionpro.Text
                    objEquivalencia.Checkdislvente = Checkdislvente.Checked
                    objEquivalencia.Numconce = CDbl(Numconce.Value.ToString)
                    objEquivalencia.combonum = combonum.SelectedValue
                    objEquivalencia.Checkaplica = Checkaplica.Checked
                    objEquivalencia.Numerictempmin = CDbl(Numerictempmin.Value.ToString)
                    objEquivalencia.Numeritemmax = CDbl(Numeritemmax.Value.ToString)
                    objEquivalencia.combotemconse = combotemconse.SelectedValue
                    objEquivalencia.descripcionATC = txtdescripcionatc.Text
                    objEquivalencia.grupoATC = comboatc.SelectedItem
                    objEquivalencia.duracion = txtduracion.Text
                    objEquivalencia.duracionmax = txtduracionmax.Text
                    objEquivalencia.osmolalidad = CDbl(txtosmolalidad.Text)
                    objEquivalencia.Checkmespecial = Checkmespecial.Checked
                    objEquivalencia.Combocualidad = Combocualidad.SelectedValue
                    objEquivalencia.Checkestirilizacion = Checkestirilizacion.Checked
                    objEquivalencia.usuario = SesionActual.idUsuario
                    objEquivalencia.codigoint = txtcodigoint.Text
                    objEquivalencia.Comboriesgo = Comboriesgo.SelectedValue.ToString

                    objEquivalencia.Checkmezcla = Checkmezcla.Checked
                    objEquivalencia.Checkenfermeria = Checkenfermeria.Checked
                    objEquivalencia.Checkfisio = Checkfisio.Checked
                    objEquivalencia.guardarEquivalencia()
                    txtcodigoint.Text = objEquivalencia.codigoint
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                    btbuscarl.Enabled = False
                    Panel2.Visible = False
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btOpcionPresentacion.Click
        If SesionActual.tienePermiso(Pprese) Then
            General.cargarForm(Presentaciones)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btOpcionvia.Click
        If SesionActual.tienePermiso(Pviaadmin) Then
            General.cargarForm(ViasAdministracion)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscarl_Click(sender As Object, e As EventArgs) Handles btbuscarl.Click
        General.buscarElemento(Consultas.BUSQUEDA_LINEA,
                                Nothing,
                                AddressOf cargarLinea,
                                TitulosForm.BUSQUEDA_LINEA,
                                0)
    End Sub

    Public Sub cargarLinea(pCodigo As String)
        Dim drLinea As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drLinea = General.cargarItem("PROC_LINEAS_CARGAR", params)

        txtlinea.Text = pCodigo
        txtlinea2.Text = drLinea.Item(1).ToString
    End Sub

    Public Sub cargarFarmaco(pCodigo As String)
        Dim drFarmaco As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drFarmaco = General.cargarItem("PROC_GRUPOFARMACOLOGICO_CARGAR", params)

        txtgrupo.Text = pCodigo
        txtgrupo2.Text = drFarmaco.Item(0).ToString

    End Sub

    Public Sub cargarEquivalencia(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)

        General.llenarTabla(Consultas.CARGAR_EQUIVALENCIA, params, dt)
        If dt.Rows.Count > 0 Then
            txtcodigoint.Text = dt.Rows(0).Item("Codigo_Interno").ToString
            txtcodigopos.Text = dt.Rows(0).Item("Codigo_Equi").ToString
            txtdescripcion.Text = dt.Rows(0).Item("Descripcion").ToString
            If dt.Rows(0).Item("Categoria").ToString = Constantes.CATEGORIA_POS Then
                radiopos.Checked = True
            Else
                radionopos.Checked = True
            End If
            arbolmenu.Nodes.Clear()
            objEquivalencia.dsDatos.Reset()
            txtdescripcionpro.Text = dt.Rows(0).Item("Observaciones").ToString
            Checkdislvente.Checked = dt.Rows(0).Item("Disolvente").ToString
            Numconce.Value = dt.Rows(0).Item("Cant_Concen").ToString
            Checkaplica.Checked = dt.Rows(0).Item("Aplica_Disolvente").ToString
            Numerictempmin.Value = dt.Rows(0).Item("Temp_Min").ToString
            Numeritemmax.Value = dt.Rows(0).Item("Temp_Max").ToString
            txtosmolalidad.Text = dt.Rows(0).Item("osmolalidad").ToString
            Checkmespecial.Checked = dt.Rows(0).Item("M_Especial").ToString
            Checkestirilizacion.Checked = dt.Rows(0).Item("esterilizacion").ToString
            Checkenfermeria.Checked = dt.Rows(0).Item("Enfermeria").ToString
            Checkmezcla.Checked = dt.Rows(0).Item("Mezcla").ToString
            Checkfisio.Checked = dt.Rows(0).Item("Fisioterapia").ToString
            txtgrupo2.Text = dt.Rows(0).Item("Grupo Farmaco").ToString
            txtgrupo.Text = dt.Rows(0).Item("Codigo_Grupo").ToString
            txtlinea.Text = dt.Rows(0).Item("Codigo_Linea").ToString
            txtlinea2.Text = dt.Rows(0).Item("Linea").ToString
            comboprese.SelectedValue = dt.Rows(0).Item("Codigo_Presentacion").ToString
            combonum.SelectedValue = dt.Rows(0).Item("Codigo_Unidad").ToString
            combotemconse.SelectedValue = dt.Rows(0).Item("Codigo_Temp_fin").ToString
            txtdescripcionatc.Text = dt.Rows(0).Item("Descripcion ATC").ToString
            If dt.Rows(0).Item("Grupo ATC").ToString = Nothing Then
                comboatc.SelectedIndex = 0
            Else
                comboatc.SelectedItem = dt.Rows(0).Item("Grupo ATC").ToString
            End If
            Combocualidad.SelectedValue = dt.Rows(0).Item("Codigo_Cualidad").ToString
            txtduracion.Text = dt.Rows(0).Item("Duracion_Ini").ToString
            txtduracionmax.Text = dt.Rows(0).Item("Duracion_Fin").ToString
            Comboriesgo.SelectedValue = dt.Rows(0).Item("Codigo_Riesgo").ToString
            objEquivalencia.CreaOpciones(txtcodigoint.Text.Trim, arbolmenu, objEquivalencia.dsDatos)
            bteditar.Enabled = True
            btanular.Enabled = True
            btcancelar.Enabled = False
            btOpcionvia.Enabled = True
            Panel2.Visible = False
            General.llenarTablaYdgv(Consultas.LISTAR_EQUIVALENCIA & txtcodigoint.Text, dgvequivalencia)
            End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If Panel2.Visible = False Then
            crearArbol()
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

    End Sub

    Private Sub crearArbol()
        If arbolmenu.Nodes.Count = 0 Then
            objEquivalencia.CreaOpciones(txtcodigoint.Text.Trim, arbolmenu, objEquivalencia.dsDatos)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtcodigoint.ReadOnly = True
            txtcodigopos.ReadOnly = False
            arbolmenu.Nodes.Clear()
            objEquivalencia.dsDatos.Reset()
            crearArbol()
            txtlinea.ReadOnly = True
            txtlinea2.ReadOnly = True
            txtgrupo.ReadOnly = True
            txtgrupo2.ReadOnly = True
            Numerictempmin.Value = 4
            Numeritemmax.Value = 25
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub radionopos_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub radiopos_CheckedChanged(sender As Object, e As EventArgs) Handles radiopos.CheckedChanged

    End Sub

    Private Sub radionopos_CheckedChanged_1(sender As Object, e As EventArgs) Handles radionopos.CheckedChanged

    End Sub

    Private Sub Numerictempmin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Numerictempmin.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub Numeritemmax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Numeritemmax.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub


    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If arbolmenu.Nodes.Count = 0 Then
                objEquivalencia.CreaOpciones(txtcodigoint.Text.Trim, arbolmenu, objEquivalencia.dsDatos)
            End If
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
            Button4.Enabled = True
            txtlinea.ReadOnly = True
            txtlinea2.ReadOnly = True
            txtgrupo.ReadOnly = True
            dgvequivalencia.ReadOnly = True
            txtcodigopos.ReadOnly = False
            txtgrupo2.ReadOnly = True
            btbuscarl.Enabled = True
            btbuscargrupo.Enabled = True
            btOpcionLinea.Enabled = True
            btOpcionFarmaco.Enabled = True
            btOpcionPresentacion.Enabled = True
            btOpcionCualidad.Enabled = True
            btOpcionvia.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        Panel2.Visible = False
        radionopos.Checked = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 06/05/2016
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                respuesta = General.anularRegistro(Consultas.ANULAR_EQUIVALENCIA & txtcodigoint.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then
                    General.limpiarControles(Me)
                    General.deshabilitarControles(Me)
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    btguardar.Enabled = False
                    btbuscarl.Enabled = False
                    btbuscargrupo.Enabled = False
                    Button4.Enabled = False
                    btbuscar.Enabled = True
                    btOpcionvia.Enabled = True
                End If
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub txtduracion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtduracion.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txtduracionmax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtduracionmax.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txtosmolalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtosmolalidad.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub arbolmenu_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles arbolmenu.AfterCheck
        If e.Node.Checked = True Then
            If objEquivalencia.dsDatos.Tables("Vias_Equi").Select("[Codigo_via]='" + e.Node.Name.ToString + "'").Count = 0 Then
                Dim dr As DataRow = objEquivalencia.dsDatos.Tables("Vias_Equi").NewRow
                dr("Codigo_via") = e.Node.Name
                If txtcodigoint.Text = "" Then
                    dr("Codigo_interno") = CInt(0)
                Else
                    dr("Codigo_interno") = CInt(txtcodigoint.Text)
                End If

                objEquivalencia.dsDatos.Tables("Vias_Equi").Rows.Add(dr)
            End If
        Else
            If objEquivalencia.dsDatos.Tables("Vias_Equi").Select("[Codigo_via]='" + e.Node.Name.ToString + "'").Count > 0 Then

                Dim dr As DataRow() = objEquivalencia.dsDatos.Tables("Vias_Equi").Select("[Codigo_via]='" + e.Node.Name.ToString + "'")
                For Each adr In dr
                    objEquivalencia.dsDatos.Tables("Vias_Equi").Rows.Remove(adr)
                Next
            End If
        End If

        If e.Node.Nodes.Count > 0 Then
            For i As Int32 = 0 To e.Node.Nodes.Count - 1
                If e.Node.Checked = True And sw = False Then
                    sw2 = True
                    e.Node.Nodes.Item(i).Checked = True
                    sw2 = False
                ElseIf e.Node.Checked = False And sw = False Then
                    sw2 = True
                    e.Node.Nodes.Item(i).Checked = False
                    sw2 = False
                End If
            Next
        End If

    End Sub

    Private Sub btnCualidad_Click(sender As Object, e As EventArgs) Handles btOpcionCualidad.Click
        If SesionActual.tienePermiso(Pcualidad ) Then
            General.cargarForm(Cualidades)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Equivalencia_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Panel2.Visible = False
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_EQUIVALENCIA,
                                   Nothing,
                                   AddressOf cargarEquivalencia,
                                   TitulosForm.BUSQUEDA_EQUIVALENCIA,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscargrupo_Click(sender As Object, e As EventArgs) Handles btbuscargrupo.Click
        General.buscarElemento(Consultas.BUSQUEDA_GRUPO,
                               Nothing,
                               AddressOf cargarFarmaco,
                               TitulosForm.BUSQUEDA_GRUPO,
                               False)
    End Sub

End Class