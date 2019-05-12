Public Class FormTarifaTripulacion
    Dim cmd As New CausaExternaBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objTripulacion As Tripulante
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Modulos_perfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Sub comboorigenpais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboorigenpais.SelectedIndexChanged
        If comboorigenpais.ValueMember <> "" Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & comboorigenpais.SelectedValue & "'", "Nombre", "Codigo_Departamento", comboorigendpto)
        End If
    End Sub

    Private Sub comboorigendpto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboorigendpto.SelectedIndexChanged
        If comboorigendpto.ValueMember <> "" Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & comboorigendpto.SelectedValue & "'", "Nombre", "Codigo_Municipio", comboorigenmun)
        End If
    End Sub

    Private Sub combodestinopais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodestinopais.SelectedIndexChanged
        If combodestinopais.ValueMember <> "" Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & combodestinopais.SelectedValue & "'", "Nombre", "Codigo_Departamento", combodestinodpto)
        End If
    End Sub

    Private Sub combodestinodpto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodestinodpto.SelectedIndexChanged
        If combodestinodpto.ValueMember <> "" Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodestinodpto.SelectedValue & "'", "Nombre", "Codigo_Municipio", combodestinomun)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click, textCostoAdminSimple.CausesValidationChanged
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'Guarda en base de datos los valores de tarifa de tripulantes Ambulancia
        If ValidarDatos() = True Then Exit Sub
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            If cargarObjetoTarifaTripulantes() = True Then
                Try
                    TarifaTripulacionBLL.guardarTarifaTripulacion(objTripulacion)
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    txtcodigo.Text = objTripulacion.Codigo_Tarifa_Tripulacion
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.buscarElemento(objTripulacion.sqlBuscarTarifaTripulacion,
                                   Nothing,
                                   AddressOf cargarTarifaTripulacion,
                                   TitulosForm.BUSQUEDA_TARIFA_TRIPULACION,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarTarifaTripulacionResponsable(rCodigo As Integer)
        'Carga la Información del Responsable
        Dim bites() As Byte
        Dim ms As New MemoryStream()
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(rCodigo)
        Try
            dFila = General.cargarItem(objTripulacion.sqlCargarResponsableTarifaTripulacion, params)
            objTripulacion.id_tercero_responsable = rCodigo

            txtCedula.Text = dFila.Item(1)
            txtResponsable.Text = dFila.Item(2)
            'Carga la foto del Responsable 
            If IsDBNull(dFila.Item(3)) = True Then
                foto.Image = Nothing ' Si no tiene foto
            Else
                bites = dFila.Item(3)
                ms = New MemoryStream(bites)
                foto.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            End If

        Catch ex As Exception
            txtCedula.Text = objTripulacion.Usuario
            txtResponsable.Text = ""
            foto.Image = Nothing
            'general.manejoErrores(ex) 
        End Try

    End Sub
    Private Sub cargarTarifaTripulacion(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objTripulacion.sqlCargarTarifaTripulacion, params)
            objTripulacion.Codigo_Tarifa_Tripulacion = pCodigo
            txtcodigo.Text = pCodigo
            comboorigenpais.SelectedValue = dFila.Item(1)
            comboorigendpto.SelectedValue = dFila.Item(2)
            comboorigenmun.SelectedValue = dFila.Item(3)
            combodestinopais.SelectedValue = dFila.Item(4)
            combodestinodpto.SelectedValue = dFila.Item(5)
            combodestinomun.SelectedValue = dFila.Item(6)
            textCostoAdminSimple.Text = FormatCurrency(dFila.Item(7), 2)
            textCostoAdminRedondo.Text = FormatCurrency(dFila.Item(8), 2)
            textCostoMedSimple.Text = FormatCurrency(dFila.Item(13), 2)
            textCostoMedRedondo.Text = FormatCurrency(dFila.Item(14), 2)
            textCostoCondSimple.Text = FormatCurrency(dFila.Item(9), 2)
            textCostoCondRedondo.Text = FormatCurrency(dFila.Item(10), 2)
            textCostoParaSimple.Text = FormatCurrency(dFila.Item(11), 2)
            textCostoParaRedondo.Text = FormatCurrency(dFila.Item(12), 2)
            textCostoFisiSimple.Text = FormatCurrency(dFila.Item(16), 2)
            textCostoFisiRedondo.Text = FormatCurrency(dFila.Item(17), 2)
            textCostoContacto.Text = FormatCurrency(dFila.Item(15), 2)
            textCostoRecNoc.Text = FormatCurrency(dFila.Item(18), 2)
            CbViceversa.Checked = dFila.Item(19)
            objTripulacion.id_tercero_responsable = dFila.Item(20)
            cargarTarifaTripulacionResponsable(dFila.Item(20))
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub FormTarifaTripulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        objTripulacion = New Tripulante
        objTripulacion.Usuario = SesionActual.idUsuario
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        CbViceversa.Checked = True
        'permisos de uso de boton
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", comboorigenpais)
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", combodestinopais)
        General.cargarCombo(Consultas.DPTO_LISTAR & comboorigenpais.SelectedValue.ToString, "Nombre", "Codigo_Departamento", comboorigendpto)
        General.cargarCombo(Consultas.DPTO_LISTAR & combodestinopais.SelectedValue.ToString, "Nombre", "Codigo_Departamento", combodestinodpto)
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & comboorigendpto.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", comboorigenmun)
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodestinodpto.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", combodestinomun)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            Me.txtResponsable.ReadOnly = True
            Me.txtCedula.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cargarObjetos()
        cargarObjetoTarifaTripulantes()
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    objTripulacion.AnularTarifaTripulacion()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Function ValidarDatos() As Boolean
        Dim res As Boolean
        If String.IsNullOrEmpty(textCostoAdminSimple.Text) Then
            MsgBox("El Valor Simple Administrativo esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoAdminRedondo.Text) Then
            MsgBox("El Valor redondo Administrativo esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoMedSimple.Text) Then
            MsgBox("El Valor Simple Medico esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoMedRedondo.Text) Then
            MsgBox("El Valor Redondo Medico esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoCondSimple.Text) Then
            MsgBox("El Valor Simple Conductor esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoCondRedondo.Text) Then
            MsgBox("El Valor Redondo Conductor esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoParaSimple.Text) Then
            MsgBox("El Valor Simple Paramedico esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoParaRedondo.Text) Then
            MsgBox("El Valor Redondo Paramedico esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoFisiSimple.Text) Then
            MsgBox("El Valor Simple Fisioterapeuta esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoFisiRedondo.Text) Then
            MsgBox("El Valor Contacto esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoContacto.Text) Then
            MsgBox("El Valor Contacto esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf String.IsNullOrEmpty(textCostoRecNoc.Text) Then
            MsgBox("El Valor Recargo nocturno esta en Blanco..", MsgBoxStyle.Exclamation)
            res = True
            Return res
        ElseIf comboorigenpais.SelectedValue = -1 Then
            MsgBox("El Pais de Origen esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf comboorigendpto.SelectedValue = -1 Then
            MsgBox("El Departamento de Origen esta en Blanco..", MsgBoxStyle.Exclamation)
            res = True
            Return res
        ElseIf comboorigenmun.SelectedValue = -1 Then
            MsgBox("El Municipio de Origen esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf combodestinopais.SelectedValue = -1 Then
            MsgBox("El Pais de Destino esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf combodestinodpto.SelectedValue = -1 Then
            MsgBox("El Departamento de Destino esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        ElseIf combodestinomun.SelectedValue = -1 Then
            MsgBox("El Municipio de Destino esta en Blanco..", MsgBoxStyle.Exclamation)
            Return True
        Else
            Return False
        End If
    End Function

    'Private Sub textCostoAdminSimple_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles textCostoAdminSimple.Validating
    '    If Not CType(sender, Control).Text.Length > 0 Then

    '        MessageBox.Show("Llene los campos")

    '        CType(sender, Control).Focus()

    '    End If
    'End Sub

    Private Function cargarObjetoTarifaTripulantes() As Boolean
        Dim resp As Boolean = True
        Try
            objTripulacion.Codigo_Tarifa_Tripulacion = txtcodigo.Text
            objTripulacion.Codigo_Pais_Origen = comboorigenpais.SelectedValue
            objTripulacion.Codigo_Dpto_Origen = comboorigendpto.SelectedValue
            objTripulacion.Codigo_Municipio_Origen = comboorigenmun.SelectedValue
            objTripulacion.Codigo_Pais_Destino = combodestinopais.SelectedValue
            objTripulacion.Codigo_Dpto_Destino = combodestinodpto.SelectedValue
            objTripulacion.Codigo_Municipio_Destino = combodestinomun.SelectedValue
            objTripulacion.Valor_Administrativo_S = CDec(textCostoAdminSimple.Text)
            objTripulacion.Valor_Administrativo_R = CDec(textCostoAdminRedondo.Text)
            objTripulacion.Valor_Medico_S = CDec(textCostoMedSimple.Text)
            objTripulacion.Valor_Medico_R = CDec(textCostoMedRedondo.Text)
            objTripulacion.Valor_Conductor_S = CDec(textCostoCondSimple.Text)
            objTripulacion.Valor_Conductor_R = CDec(textCostoCondRedondo.Text)
            objTripulacion.Valor_Paramedico_S = CDec(textCostoParaSimple.Text)
            objTripulacion.Valor_Paramedico_R = CDec(textCostoParaRedondo.Text)
            objTripulacion.Valor_Fisioterapeuta_S = CDec(textCostoFisiSimple.Text)
            objTripulacion.Valor_Fisioterapeuta_R = CDec(textCostoFisiRedondo.Text)
            objTripulacion.Valor_Contacto = CDec(textCostoContacto.Text)
            objTripulacion.Recargo_Nocturno = CDec(textCostoRecNoc.Text)
            objTripulacion.viceversa = CbViceversa.Checked.ToString
        Catch ex As Exception
            General.manejoErrores(ex)
            resp = False
        End Try
        Return resp
    End Function

    Private Sub textCostoAdminSimple_Leave(sender As Object, e As EventArgs) Handles textCostoAdminSimple.Leave,
                                                                                     textCostoAdminRedondo.Leave,
                                                                                     textCostoMedSimple.Leave,
                                                                                     textCostoMedRedondo.Leave,
                                                                                     textCostoCondSimple.Leave,
                                                                                     textCostoCondRedondo.Leave,
                                                                                     textCostoParaSimple.Leave,
                                                                                     textCostoParaRedondo.Leave,
                                                                                     textCostoFisiSimple.Leave,
                                                                                     textCostoFisiRedondo.Leave,
                                                                                     textCostoRecNoc.Leave,
                                                                                     textCostoContacto.Leave
        Try
            If sender.text <> String.Empty Then
                sender.Text = FormatCurrency(sender.Text, 2)
            End If
        Catch ex As Exception
            MsgBox("Datos Incorrecto", MsgBoxStyle.Exclamation)
            sender.text = ""
        End Try

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            'Actualiza en base de datos los valores de tarifa de tripulantes Ambulancia
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            txtCedula.ReadOnly = True
            txtResponsable.ReadOnly = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub textCostoAdminSimple_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textCostoAdminSimple.KeyPress,
                                                                                                textCostoAdminRedondo.KeyPress,
                                                                                                textCostoMedSimple.KeyPress,
                                                                                                textCostoMedRedondo.KeyPress,
                                                                                                textCostoCondSimple.KeyPress,
                                                                                                textCostoCondRedondo.KeyPress,
                                                                                                textCostoParaSimple.KeyPress,
                                                                                                textCostoParaRedondo.KeyPress,
                                                                                                textCostoFisiSimple.KeyPress,
                                                                                                textCostoFisiRedondo.KeyPress,
                                                                                                textCostoRecNoc.KeyPress,
                                                                                                textCostoContacto.KeyPress,
                                                                                                textCostoContacto.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.IsPunctuation(e.KeyChar)
    End Sub
End Class