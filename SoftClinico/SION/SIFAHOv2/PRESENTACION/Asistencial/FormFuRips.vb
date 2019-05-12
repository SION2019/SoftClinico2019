Imports System.Threading
Public Class FormFuRips
    Dim objFurips As New FuRips
    Dim hashT As New Hashtable
    Dim reporte As New ftp_reportes
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, modulo, emailEPS As String
    Shared hilo As Thread

    Private Sub FormFuRips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", combodoc)
        General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", Combotipdoc)
        General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", ComboBox3)
        General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", ComboBox4)
        General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", ComboBox5)

        General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", ComboBox10)
        General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", ComboBox11)
        General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", Combodepartamento)
        General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", ComboBox13)
        General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", Combodepratv)
        General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", ComboBox1)

        Hashtable()
        cargarRazonSocial()
        cargarDatosPaciente()
        General.deshabilitarControles(Me)
    End Sub

    Public Sub Hashtable()
        hashT.Add(txtfecharadicacion.Name, ConstanteParametros.FECHA_RADICACION)
        hashT.Add(txtrg.Name, ConstanteParametros.GR)
        hashT.Add(txtradicado.Name, ConstanteParametros.NUMERO_RADICACION)
        hashT.Add(txtrespuestaglosa.Name, ConstanteParametros.RESPUESTA_GLOSA)
        hashT.Add(txtcuentacobro.Name, ConstanteParametros.CUENTRA_COBRO)
        hashT.Add(Radioconductor.Name, ConstanteParametros.CONDUCTOR)
        hashT.Add(Radiopeaton.Name, ConstanteParametros.PEATON)
        hashT.Add(Radioocupante.Name, ConstanteParametros.OCUPANTE)
        hashT.Add(Radiociclista.Name, ConstanteParametros.Ciclista)
        hashT.Add(Checkaccidente.Name, ConstanteParametros.ACCIDENTE)
        hashT.Add(Checksismo.Name, ConstanteParametros.SISMO)
        hashT.Add(Checkmaremoto.Name, ConstanteParametros.MAREMOTO)
        hashT.Add(Checkerupcion.Name, ConstanteParametros.ERUPCION_VOLCANICA)

        hashT.Add(Checkhuracan.Name, ConstanteParametros.HURACAN)
        hashT.Add(Checkinundaciones.Name, ConstanteParametros.INUNDACION)
        hashT.Add(Checkavalancha.Name, ConstanteParametros.AVALANCHA)
        hashT.Add(Checkdelizamiento.Name, ConstanteParametros.DESLIZAMIENTO_TIERRA)
        hashT.Add(Checkincendionatural.Name, ConstanteParametros.INCENDIO_NATURAL)
        hashT.Add(Checkrayo.Name, ConstanteParametros.RAYO)
        hashT.Add(Checkvendaval.Name, ConstanteParametros.VENDAVAL)

        hashT.Add(Checktornado.Name, ConstanteParametros.TORNADO)
        hashT.Add(Checkexplosion.Name, ConstanteParametros.EXPLOSION)
        hashT.Add(Checkmasacre.Name, ConstanteParametros.MASACRE)
        hashT.Add(Checkmina.Name, ConstanteParametros.MINA_ANTIPERSONA)
        hashT.Add(Checkcombate.Name, ConstanteParametros.COMBATE)
        hashT.Add(Checkincendio.Name, ConstanteParametros.INCENDIO)
        hashT.Add(Checkataquesmun.Name, ConstanteParametros.ATAQUE_MUNICIPIO)
        hashT.Add(Txtotro.Name, ConstanteParametros.OTRO)

        hashT.Add(Txtdireccionocurrente.Name, ConstanteParametros.DIRECCION_OCURRENCIA)
        hashT.Add(txtfechaevento.Name, ConstanteParametros.FECHA_EVENTO_ACCIDENTE)
        hashT.Add(Combodepartamento.Name, ConstanteParametros.DEPARTAMENTO)
        hashT.Add(Combomunicipio.Name, ConstanteParametros.MUNICIPIO)
        hashT.Add(txtcoddepar.Name, ConstanteParametros.COD_DEPARTAMENTO)
        hashT.Add(Txtcodmun.Name, ConstanteParametros.COD_MUNICIPIO)
        hashT.Add(Radiou.Name, ConstanteParametros.ZONA)
        hashT.Add(Radior.Name, ConstanteParametros.ZONAR)

        hashT.Add(Checkaseguradora.Name, ConstanteParametros.ASEGURADORA)
        hashT.Add(CheckBox21.Name, ConstanteParametros.NO_ASEGURADORA)
        hashT.Add(CheckBox22.Name, ConstanteParametros.VEHICULO_FANTASMA)
        hashT.Add(CheckBox23.Name, ConstanteParametros.POLIZA)
        hashT.Add(CheckBox24.Name, ConstanteParametros.VEHICULO_FUGA)
        hashT.Add(TextBox27.Name, ConstanteParametros.MARCA)
        hashT.Add(TextBox28.Name, ConstanteParametros.PLACA)

        hashT.Add(CheckBox25.Name, ConstanteParametros.PARTICULAR)
        hashT.Add(CheckBox26.Name, ConstanteParametros.PUBLICO)
        hashT.Add(CheckBox27.Name, ConstanteParametros.OFICIAL)
        hashT.Add(CheckBox28.Name, ConstanteParametros.VEHICULO_EMERGENCIA)
        hashT.Add(CheckBox29.Name, ConstanteParametros.VEHICULO_SERVICIO_DIPLOMATICO)
        hashT.Add(CheckBox30.Name, ConstanteParametros.VEHICULO_TRANSPORTE_MASIVO)
        hashT.Add(CheckBox31.Name, ConstanteParametros.VEHICULO_ESCOLAR)

        hashT.Add(TextBox29.Name, ConstanteParametros.CODIGO_ASEGURADORA)
        hashT.Add(TextBox30.Name, ConstanteParametros.NUMERO_POLIZA)
        hashT.Add(RadioButton9.Name, ConstanteParametros.INTERVENCION_AUTORIDAD)
        hashT.Add(RadioButton10.Name, ConstanteParametros.INTERVENCION_AUTORIDAD_NO)
        hashT.Add(DateTimePicker3.Name, ConstanteParametros.VIGENCIAFECHA)
        hashT.Add(DateTimePicker4.Name, ConstanteParametros.HASTAFEFHA)
        hashT.Add(RadioButton11.Name, ConstanteParametros.COBRO_EXCEDENTE_POLIZA)
        hashT.Add(RadioButton12.Name, ConstanteParametros.COBRO_EXCEDENTE_POLIZA_NO)

        hashT.Add(TextBox32.Name, ConstanteParametros.NOMBRE_PROPIETARIO_VEHICULO)
        hashT.Add(TextBox31.Name, ConstanteParametros.SEGUNDO_NOMBRE_PROPIETARIO_VEHICULO)
        hashT.Add(TextBox34.Name, ConstanteParametros.APELLIDO_PROPIETARIO_VEHICULO)
        hashT.Add(TextBox33.Name, ConstanteParametros.SEGUNDO_APELLIDO_PROPIETARIO_VEHICULO)
        hashT.Add(Combotipdoc.Name, ConstanteParametros.TIPO_DOCUMENTO)
        hashT.Add(TextBox41.Name, ConstanteParametros.NUMERO_DOCUMENTO)
        hashT.Add(TextBox40.Name, ConstanteParametros.DIRECCION_RESIDENCIAL)
        hashT.Add(Combodepratv.Name, ConstanteParametros.DEPARTAMENTO_PROPIETARIO_VEHICULO)
        hashT.Add(TextBox39.Name, ConstanteParametros.CODIGO_DEPARTAMENTO_PROPIETARIO_VEHICULO)
        hashT.Add(TextBox38.Name, ConstanteParametros.TELEFONO_PROPIETARIO_VEHICULO)
        hashT.Add(Combomuniv.Name, ConstanteParametros.MUNICIPIO_PROPIETARIO_VEHICULO)
        hashT.Add(TextBox35.Name, ConstanteParametros.CODIGO_MUNICIPIO_PROPIETARIO_VEHICULO)

        hashT.Add(TextBox50.Name, ConstanteParametros.NOMBRE_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox49.Name, ConstanteParametros.SEGUNDO_NOMBRE_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox52.Name, ConstanteParametros.APELLIDO_CODUCTOR_VEHICULO)
        hashT.Add(TextBox51.Name, ConstanteParametros.SEGUNDO_APELLIDO_CONDUCTOR_VEHICULO)
        hashT.Add(ComboBox3.Name, ConstanteParametros.TIPO_DOC_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox48.Name, ConstanteParametros.NUMERO_DOC_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox47.Name, ConstanteParametros.DIRECCION_RESI_CONDUCTOR_VEHICULO)
        hashT.Add(ComboBox13.Name, ConstanteParametros.DEPARTAMENTO_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox46.Name, ConstanteParametros.CODI_DEP_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox45.Name, ConstanteParametros.TELEFONO_CONDUCTOR_VEHICULO)
        hashT.Add(ComboBox14.Name, ConstanteParametros.MUNICIPIO_CONDUCTOR_VEHICULO)
        hashT.Add(TextBox42.Name, ConstanteParametros.COD_MUN_CONDUCTOR_VEHICULO)

        hashT.Add(DateTimePicker5.Name, ConstanteParametros.FECHA_DATOS_REMISION)
        hashT.Add(TextBox53.Name, ConstanteParametros.PERSONA_REMITIDA_DATOS_REMISION)
        hashT.Add(TextBox54.Name, ConstanteParametros.PERSONA_REMITE_DATOS_REMISION)
        hashT.Add(TextBox55.Name, ConstanteParametros.CARGO_DATOS_REMISION)
        hashT.Add(TextBox56.Name, ConstanteParametros.DIRECCION_IPS_REMITE_DATOS_REMISION)
        hashT.Add(ComboBox10.Name, ConstanteParametros.DEPARTAMENTO_IPS_REMITE_DATOS_REMISION)
        hashT.Add(TextBox59.Name, ConstanteParametros.CODIGO_DEPAR_DATOS_REMISION)
        hashT.Add(TextBox58.Name, ConstanteParametros.TELEFONO_DATOS_REMISION)
        hashT.Add(ComboBox9.Name, ConstanteParametros.MUNICIPIO_IPS_DATOS_REMISION)
        hashT.Add(TextBox61.Name, ConstanteParametros.CODIGO_MUN_DATOS_REMISION)
        hashT.Add(DateTimePicker6.Name, ConstanteParametros.FECHA_ACEPTACION_DATOS_REMISION)

        hashT.Add(TextBox62.Name, ConstanteParametros.PERSONA_REMITIDA_A_DATOS_REMISION)
        hashT.Add(TextBox63.Name, ConstanteParametros.PERSONA_RECIBE_DATOS_REMISION)
        hashT.Add(TextBox64.Name, ConstanteParametros.CARGO_RECIBE_DATOS_REMISION)
        hashT.Add(TextBox65.Name, ConstanteParametros.DIRECCION_IPS_RECIBE_DATOS_REMISION)
        hashT.Add(ComboBox11.Name, ConstanteParametros.DEPARTAMENTO_IPS_RECIBE_DATOS_REMISION)
        hashT.Add(TextBox67.Name, ConstanteParametros.CODIGO_IPS_RECIBE_DATOS_REMISION)
        hashT.Add(TextBox66.Name, ConstanteParametros.TELEFONO_RECIBE_DATOS_REMISION)
        hashT.Add(ComboBox12.Name, ConstanteParametros.MUNICIPIO_IPS_RECIBE_DATOS_REMISION)
        hashT.Add(TextBox69.Name, ConstanteParametros.CODIGO_MUN_IPS_RECIBE_DATOS_REMISION)
        '---------------------------------------------------------------------------------------

        hashT.Add(TextBox71.Name, ConstanteParametros.PLACA_AMPARO_VICTIMA)
        hashT.Add(TextBox73.Name, ConstanteParametros.NOMBRE_AMPARO_VICTIMA)
        hashT.Add(TextBox72.Name, ConstanteParametros.SEGUNDO_NOMBRE_AMPARO_VICTIMA)
        hashT.Add(TextBox75.Name, ConstanteParametros.APELLIDO_AMPARO_VICTIMA)
        hashT.Add(TextBox74.Name, ConstanteParametros.SEGUNDO_APELLIDO_AMPARO_VICTIMA)
        hashT.Add(ComboBox4.Name, ConstanteParametros.TIPO_DOC_AMPARO_VICTIMA)
        hashT.Add(TextBox76.Name, ConstanteParametros.NUMERO_DOC_AMPARO_VICTIMA)
        hashT.Add(TextBox77.Name, ConstanteParametros.TRANSPORTO_DESDE_AMPARO_VICTIMA)
        hashT.Add(TextBox78.Name, ConstanteParametros.TRANSPORTO_HASTA_AMPARO_VICTIMA)
        '------------------------------------------------------------------------

        hashT.Add(CheckBox32.Name, ConstanteParametros.AMBULANCIA_BASICA_AMPARO_VICTIMA)
        hashT.Add(CheckBox33.Name, ConstanteParametros.AMBULANCIA_MEDICA_AMPARO_VICTIMA)
        hashT.Add(RadioButton14.Name, ConstanteParametros.ZONA_AMPARO_VICTIMA)
        hashT.Add(RadioButton13.Name, ConstanteParametros.ZONA_AMPARO_VICTIMA_R)
        hashT.Add(DateTimePicker7.Name, ConstanteParametros.FECHA_INGRESO_ACCIDENTE_EVENTO)
        hashT.Add(TextBox79.Name, ConstanteParametros.CODIGO_DIAG_INGRESO_PRINCIPAL_ACCIDENTE_EVENTO)
        hashT.Add(TextBox80.Name, ConstanteParametros.CODIGO_OTRO_DIAG_INGRESO_ACCIDENTE_EVENTO)
        hashT.Add(TextBox81.Name, ConstanteParametros.CODIGO_OTRO2_DIAG_INGRESO_ACCIDENTE_EVENTO)
        hashT.Add(DateTimePicker10.Name, ConstanteParametros.FECHA_EGRESO_ACCIDENTE_EVENTO)
        hashT.Add(TextBox84.Name, ConstanteParametros.CODIGO_DIAG_PRINCIPAL_EGRESO_ACCIDENTE_EVENTO)
        hashT.Add(TextBox83.Name, ConstanteParametros.CODIGO_OTRO_DIAG_EGRESO_ACCIDENTE_EVENTO)
        hashT.Add(TextBox82.Name, ConstanteParametros.CODIGO_OTRO2_DIAG_EGRESO_ACCIDENTE_EVENTO)
        '---------------------------------------------------------------------

        hashT.Add(TextBox86.Name, ConstanteParametros.NOMBRE_MEDICO_TRATANTE)
        hashT.Add(TextBox85.Name, ConstanteParametros.SEGUNDO_NOMBRE_TRATANTE)
        hashT.Add(TextBox88.Name, ConstanteParametros.APELLIDO_MEDICO_TRATANTE)
        hashT.Add(TextBox87.Name, ConstanteParametros.SEGUNDO_APELLIDO_TRATANTE)
        hashT.Add(ComboBox5.Name, ConstanteParametros.TIPO_DOC_MEDICO_TRATANTE)
        hashT.Add(TextBox89.Name, ConstanteParametros.NUMERO_DOC_MEDICO_TRATANTE)
        hashT.Add(TextBox90.Name, ConstanteParametros.NUMERO_REGISTRO_MEDICO_TRATANTE)
        hashT.Add(CheckBox34.Name, ConstanteParametros.GASTOS_QUIRURGICO_MEDICO_TRATANTE)
        hashT.Add(CheckBox35.Name, ConstanteParametros.GASTOS_TRANSPORTE_MOV_MEDICO_TRATANTE)
        hashT.Add(TextBox91.Name, ConstanteParametros.VALOR_TOTAL_MEDICO_TRATANTE)
        hashT.Add(TextBox92.Name, ConstanteParametros.VALOR_FOSYGA_MEDICO_TRATANTE)

    End Sub


    Public Sub verificarTextbox(textbox As TextBox)
        If Not String.IsNullOrEmpty(textbox.Text) AndAlso hashT.Contains(textbox.Name) Then
            objFurips.dtParametro.Rows.Add(hashT(textbox.Name), textbox.Text)
        End If
    End Sub

    Public Sub cargarTextbox(textbox As TextBox)
        If hashT.Contains(textbox.Name) AndAlso objFurips.dtParametro.Select("codigoparametro='" & hashT(textbox.Name) & "'", "").Count > 0 Then
            For i = 0 To objFurips.dtParametro.Rows.Count - 1
                If hashT(textbox.Name) = objFurips.dtParametro.Rows(i).Item("codigoparametro") Then
                    textbox.Text = objFurips.dtParametro.Rows(i).Item("valor")
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Sub cargarCombobox(combobox As ComboBox)
        If hashT.Contains(combobox.Name) AndAlso objFurips.dtParametro.Select("codigoparametro='" & hashT(combobox.Name) & "'", "").Count > 0 Then
            For i = 0 To objFurips.dtParametro.Rows.Count - 1
                If hashT(combobox.Name) = objFurips.dtParametro.Rows(i).Item("codigoparametro") Then
                    combobox.SelectedValue = objFurips.dtParametro.Rows(i).Item("valor")
                    Exit For
                End If
            Next
        End If
    End Sub


    Public Sub cargarDateTime(datetime As DateTimePicker)
        If hashT.Contains(datetime.Name) AndAlso objFurips.dtParametro.Select("codigoparametro='" & hashT(datetime.Name) & "'", "").Count > 0 Then
            For i = 0 To objFurips.dtParametro.Rows.Count - 1
                If hashT(datetime.Name) = objFurips.dtParametro.Rows(i).Item("codigoparametro") Then
                    datetime.Text = objFurips.dtParametro.Rows(i).Item("valor")
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Sub cargarCheckBox(check As CheckBox)
        If hashT.Contains(check.Name) AndAlso objFurips.dtParametro.Select("codigoparametro='" & hashT(check.Name) & "'", "").Count > 0 Then
            For i = 0 To objFurips.dtParametro.Rows.Count - 1
                If hashT(check.Name) = objFurips.dtParametro.Rows(i).Item("codigoparametro") Then
                    check.Checked = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Sub cargarRadiobutton(radio As RadioButton)
        If hashT.Contains(radio.Name) AndAlso objFurips.dtParametro.Select("codigoparametro='" & hashT(radio.Name) & "'", "").Count > 0 Then
            For i = 0 To objFurips.dtParametro.Rows.Count - 1
                If hashT(radio.Name) = objFurips.dtParametro.Rows(i).Item("codigoparametro") Then
                    radio.Checked = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Sub verificarComboBox(combo As ComboBox)
        If combo.SelectedIndex <> 0 AndAlso hashT.Contains(combo.Name) Then
            objFurips.dtParametro.Rows.Add(hashT(combo.Name), combo.SelectedValue)
        End If
    End Sub

    Public Sub verificarDateTime(datetime As DateTimePicker)
        If hashT.Contains(datetime.Name) Then
            objFurips.dtParametro.Rows.Add(hashT(datetime.Name), datetime.Text)
        End If
    End Sub
    Public Sub verificarCheck(check As CheckBox)
        If check.Checked = True AndAlso hashT.Contains(check.Name) Then
            objFurips.dtParametro.Rows.Add(hashT(check.Name), Nothing)
        End If
    End Sub
    Public Sub verificarRadio(radio As RadioButton)
        If radio.Checked = True AndAlso hashT.Contains(radio.Name) Then
            objFurips.dtParametro.Rows.Add(hashT(radio.Name), Nothing)
        End If
    End Sub

    Public Sub cargarControles(ByRef pFormulario As Object)
        For Each vControl In pFormulario.Controls

            If (TypeOf vControl Is TextBox) Then
                cargarTextbox(vControl)
            ElseIf (TypeOf vControl Is ComboBox) Then
                cargarCombobox(vControl)
            ElseIf (TypeOf vControl Is DateTimePicker) Then
                cargarDateTime(vControl)
            ElseIf (TypeOf vControl Is CheckBox) Then
                cargarCheckBox(vControl)
            ElseIf (TypeOf vControl Is RadioButton) Then
                cargarRadiobutton(vControl)
            Else
                ' mira a ve si es un contenedor
                cargarControles(vControl)
            End If
        Next
    End Sub

    Public Sub Controles(ByRef pFormulario As Object)
        'Dim vFrtRB As Integer = pFormulario.Width + pFormulario.Height

        For Each vControl In pFormulario.Controls

            If (TypeOf vControl Is TextBox) Then
                verificarTextbox(vControl)
            ElseIf (TypeOf vControl Is ComboBox) Then
                verificarComboBox(vControl)
            ElseIf (TypeOf vControl Is DateTimePicker) Then
                verificarDateTime(vControl)
            ElseIf (TypeOf vControl Is CheckBox) Then
                verificarCheck(vControl)
            ElseIf (TypeOf vControl Is RadioButton) Then
                verificarRadio(vControl)
            Else
                ' mira a ve si es un contenedor
                Controles(vControl)
            End If
        Next
    End Sub

    Public Function validarControles()
        'If String.IsNullOrEmpty(txtrg.Text) Then
        '    MsgBox("Por favor debe llenar el campo rg", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 0
        '    txtrg.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(txtrespuestaglosa.Text) Then
        '    MsgBox("Por favor debe llenar el campo respuesta glosa", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 0
        '    txtrespuestaglosa.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(txtcuentacobro.Text) Then
        '    MsgBox("Por favor debe llenar el campo cuenta cobro", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 0
        '    txtcuentacobro.Focus()
        '    Return False
        'ElseIf Radioconductor.Checked = False And Radiopeaton.Checked = False And Radioocupante.Checked = False And Radiociclista.Checked = False Then
        '    MsgBox("Por favor debe seleccionar una de las opciones (conductor, peaton, ocupante, ciclista)", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 0
        '    Radioconductor.Focus()
        '    Return False
        'ElseIf Checkaccidente.Checked = False And Checksismo.Checked = False And Checkmaremoto.Checked = False And
        '       Checkerupcion.Checked = False And Checkhuracan.Checked = False And Checkinundaciones.Checked = False And
        '       Checkavalancha.Checked = False And Checkdelizamiento.Checked = False And Checkincendionatural.Checked = False And
        '       Checkrayo.Checked = False And Checkvendaval.Checked = False And Checktornado.Checked = False And Checkexplosion.Checked = False And
        '       Checkmasacre.Checked = False And Checkmina.Checked = False And Checkcombate.Checked = False And Checkincendio.Checked = False And
        '       Checkataquesmun.Checked = False Then
        '    MsgBox("Por favor debe seleccionar unas de las opciones entre naturales o terrorista", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Checkaccidente.Focus()
        '    Return False
        'ElseIf Checkotro.Checked = True AndAlso String.IsNullOrEmpty(Txtotro.Text) Then
        '    MsgBox("Por favor debe explicar el otro motivo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Txtotro.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(Txtdireccionocurrente.Text) Then
        '    MsgBox("Direccion de la ocurrencia", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Txtdireccionocurrente.Focus()
        '    Return False
        'ElseIf Combodepartamento.SelectedValue < 1 Then
        '    MsgBox("Debe seleccionar el departamento", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Combodepartamento.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(txtcoddepar.Text) Then
        '    MsgBox("Por favor digite el codigo del departamento", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    txtcoddepar.Focus()
        '    Return False
        'ElseIf Combomunicipio.SelectedValue < 1 Then
        '    MsgBox("Debe seleccionar el municipio", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Combomunicipio.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(Txtcodmun.Text) Then
        '    MsgBox("Por favor digite el codigo del municipio", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Txtcodmun.Focus()
        '    Return False
        'ElseIf Radiou.Checked = False And Radior.Checked = False Then
        '    MsgBox("Por favor debe seleccionar la zona", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    Radiou.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(txtdescripcion.Text) Then
        '    MsgBox("Por favor debe llenar el campo descripcion breve del evento", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 1
        '    txtdescripcion.Focus()
        '    Return False
        'ElseIf Checkaseguradora.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And
        '    CheckBox24.Checked = False Then
        '    MsgBox("Por favor debe seleccionar una de las opciones del dato del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    Checkaseguradora.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox27.Text) Then
        '    MsgBox("Por favor digite el campo marca", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox27.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox28.Text) Then
        '    MsgBox("Por favor digite el campo placa", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox28.Focus()
        '    Return False
        'ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And
        '       CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False Then
        '    MsgBox("Por favor debe seleccionar una de las opciones tipo de servicio", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    CheckBox25.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox29.Text) Then
        '    MsgBox("Por favor digite codigo de la aseguradora", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox29.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox30.Text) Then
        '    MsgBox("Por favor digite numero de poliza", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox30.Focus()
        '    Return False
        'ElseIf RadioButton9.Checked = False And RadioButton10.Checked = False Then
        '    MsgBox("Por favor debe seleccionar una opcion en intervencion de autoridad", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    RadioButton9.Focus()
        '    Return False
        'ElseIf RadioButton11.Checked = False And RadioButton12.Checked = False Then
        '    MsgBox("Por favor debe seleccionar una opcion cobro excedente de poliza", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    RadioButton11.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox34.Text) Then
        '    MsgBox("Por favor primer apellido del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox34.Focus()
        '    Return False

        'ElseIf String.IsNullOrEmpty(TextBox32.Text) Then
        '    MsgBox("Por favor primer nombre del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox32.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox31.Text) Then
        '    MsgBox("Por favor segundo nombre del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox31.Focus()
        '    Return False
        'ElseIf Combotipdoc.SelectedValue < 1 Then
        '    MsgBox("Por favor debe seleccionr el tipo de documento", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    Combotipdoc.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox41.Text) Then
        '    MsgBox("Por favor digite el numero de documento", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox41.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox40.Text) Then
        '    MsgBox("Por favor digite direccion de residencia", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox40.Focus()
        '    Return False
        'ElseIf Combodepratv.SelectedValue < 1 Then
        '    MsgBox("Por favor seleccion el departamento del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    Combodepratv.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox39.Text) Then
        '    MsgBox("Por favor digite codigo del departamento del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox39.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox38.Text) Then
        '    MsgBox("Por favor digite el numero de telefono", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox38.Focus()
        '    Return False
        'ElseIf Combomuniv.SelectedValue < 1 Then
        '    MsgBox("Por favor debe seleccionar el municipio del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    Combomuniv.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox35.Text) Then
        '    MsgBox("Por favor digite el codigo del municipio del propietario del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 2
        '    TextBox35.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox52.Text) Then
        '    MsgBox("Por favor digite primer apellido del conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox52.Focus()
        '    Return False

        'ElseIf String.IsNullOrEmpty(TextBox50.Text) Then
        '    MsgBox("Por favor digite primer nombre del conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox50.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox49.Text) Then
        '    MsgBox("Por favor digite segundo nombre del conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox49.Focus()
        '    Return False
        'ElseIf ComboBox3.SelectedValue < 1 Then
        '    MsgBox("Por favor debe seleccionar el tipo de documento conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    ComboBox3.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox48.Text) Then
        '    MsgBox("Por favor digite numero de documento conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox48.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox47.Text) Then
        '    MsgBox("Por favor digite direccion de residencia conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox47.Focus()
        '    Return False
        'ElseIf ComboBox13.SelectedValue < 1 Then
        '    MsgBox("Por favor debe seleccionar el departamento conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    ComboBox13.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox46.Text) Then
        '    MsgBox("Por favor digite codigo departamento conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox46.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox45.Text) Then
        '    MsgBox("Por favor digite el numero de telefono", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox45.Focus()
        '    Return False
        'ElseIf ComboBox14.SelectedValue < 1 Then
        '    MsgBox("Por favor debe seleccionar el municipio conductor del vehiculo", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    ComboBox14.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox42.Text) Then
        '    MsgBox("Por favor digite el codigo del municipio", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 3
        '    TextBox42.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox79.Text) Then
        '    MsgBox("Por favor digite el codigo del diagnostico principal de la victima", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 4
        '    TextBox79.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox88.Text) Then
        '    MsgBox("Por favor digite primer apellido del medico profesional", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 5
        '    TextBox88.Focus()
        '    Return False

        'ElseIf String.IsNullOrEmpty(TextBox86.Text) Then
        '    MsgBox("Por favor digite primer nombre del medico profesional", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 5
        '    TextBox86.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox85.Text) Then
        '    MsgBox("Por favor digite segundo nombre del medico profesional", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 5
        '    TextBox85.Focus()
        '    Return False
        'ElseIf ComboBox5.SelectedValue < 1 Then
        '    MsgBox("Por favor seleccionar el tipo del documento medico profesional", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 5
        '    ComboBox5.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox89.Text) Then
        '    MsgBox("Por favor seleccionar el numero de documento medico profesional", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 5
        '    TextBox89.Focus()
        '    Return False
        'ElseIf String.IsNullOrEmpty(TextBox90.Text) Then
        '    MsgBox("Por favor digite el numero de registro medico profesional", MsgBoxStyle.Exclamation)
        '    TabControl1.SelectedIndex = 5
        '    TextBox90.Focus()
        '    Return False
        'End If
        Return True
    End Function

    Public Sub cargarRazonSocial()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.FURIPS_RAZON_SOCIAL, params, dt)
        If dt.Rows.Count > 0 Then
            txtrazonsocial.Text = dt.Rows(0).Item("Razon_Social")
            txtcodigohabilitacion.Text = dt.Rows(0).Item("Cod_Habilitacion")
            txtnit.Text = dt.Rows(0).Item("Nit")
        End If
    End Sub


    Public Sub pasarRegistro(ByVal registro As Integer, ByVal modulo As String)
        objFurips.registro = registro
        modulo = modulo
    End Sub

    Public Sub cargarDatosPaciente()
        objFurips.cargarDatoPaciente()
        txtapellido1.Text = objFurips.apellido
        txtapellido2.Text = objFurips.segundoApellido
        txtnombre1.Text = objFurips.nombre
        txtnombre2.Text = objFurips.segundoNombre
        combodoc.SelectedValue = objFurips.tipoDocumento
        txtnumerodocumento.Text = objFurips.documento
        If objFurips.genero = 0 Then
            Radiom1.Checked = True
        Else
            Radiof1.Checked = True
        End If
        txtfechanacimiento.Text = objFurips.fechaNacimiento
        txtdireccionresidencia.Text = objFurips.direccion
        ComboBox1.SelectedValue = objFurips.departamento
        txtcod1.Text = objFurips.codigoDepartamento
        txttelefono1.Text = objFurips.telefono
        ComboBox2.SelectedValue = objFurips.municipio
        txtcodm1.Text = objFurips.codigoMunicipio
        txtregistro.Text = objFurips.registro
        emailEPS = objFurips.email
        cargarRegistroPadre()
        cargarRegistroPaciente()
    End Sub

    Public Sub cargarRegistroPadre()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(objFurips.registro)
        General.llenarTabla(Consultas.FURIPS_CARGAR_PADRE, params, dt)
        If dt.Rows.Count > 0 Then
            txtcodigo.Text = dt.Rows(0).Item("CODIGO_FURIPS")
            txtdescripcion.Text = dt.Rows(0).Item("Descripcion_evento")
        End If
    End Sub
    Public Sub cargarRegistroPaciente()
        Dim list As New List(Of String)
        list.Add(objFurips.registro)
        General.llenarTabla(Consultas.FURIPS_REGISTRO_PACIENTE, list, objFurips.dtParametro)
        If objFurips.dtParametro.Rows.Count > 0 Then
            cargarControles(Me)

            If Not String.IsNullOrEmpty(Txtotro.Text) Then
                Checkotro.Checked = True
            End If

            If Not String.IsNullOrEmpty(txtcodigo.Text) Then
                btnuevo.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btimprimir.Enabled = True
                btEnviarCorreos.Enabled = True
            Else
                btnuevo.Enabled = True
                bteditar.Enabled = False
                btanular.Enabled = False
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btimprimir.Enabled = False
            End If
        End If
    End Sub

    Public Sub guardarDatos()
        If validarControles() Then
            Try
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    objFurips.dtParametro.Clear()
                    Controles(Me)
                    objFurips.registro = txtregistro.Text
                    objFurips.descripcion = txtdescripcion.Text
                    If Not String.IsNullOrEmpty(txtcodigo.Text) Then
                        objFurips.codigo = txtcodigo.Text
                    End If
                    objFurips.usuario = SesionActual.idUsuario
                    objFurips.guardarFuRips()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    objFurips.dtParametro.Clear()
                    txtcodigo.Text = objFurips.codigo
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btnuevo.Enabled = False
                    bteditar.Enabled = True
                    btcancelar.Enabled = False
                    btimprimir.Enabled = True
                    btanular.Enabled = True
                    btEnviarCorreos.Enabled = True
                    TabControl1.SelectedIndex = 0
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardarDatos()
    End Sub

    Public Sub deshabilitarCodMunicipio()
        txtcoddepar.ReadOnly = True
        Txtcodmun.ReadOnly = True
        TextBox39.ReadOnly = True
        TextBox35.ReadOnly = True
        TextBox46.ReadOnly = True
        TextBox42.ReadOnly = True
        TextBox59.ReadOnly = True
        TextBox61.ReadOnly = True
        TextBox67.ReadOnly = True
        TextBox69.ReadOnly = True
        Txtotro.ReadOnly = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            btnuevo.Enabled = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btanular.Enabled = False
            btimprimir.Enabled = False
            objFurips.dtParametro.Clear()
            General.habilitarControles(Me)
            GroupBox3.Enabled = False
            GroupBox4.Enabled = False
            GroupBox5.Enabled = True
            deshabilitarCodMunicipio()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Combodepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", Combomunicipio)
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & ComboBox1.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", ComboBox2)
    End Sub

    Private Sub Combodepratv_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepratv.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepratv.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", Combomuniv)
    End Sub

    Private Sub ComboBox13_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox13.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & ComboBox13.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", ComboBox14)
    End Sub

    Private Sub ComboBox10_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & ComboBox10.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", ComboBox9)
    End Sub

    Private Sub ComboBox11_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & ComboBox11.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", ComboBox12)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            bteditar.Enabled = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btnuevo.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            General.habilitarControles(Me)
            objFurips.dtParametro.Clear()
            GroupBox3.Enabled = False
            GroupBox4.Enabled = False
            GroupBox5.Enabled = True
            deshabilitarCodMunicipio()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            If Not String.IsNullOrEmpty(txtcodigo.Text) And btguardar.Enabled = True Then
                btguardar.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                GroupBox3.Enabled = False
                GroupBox4.Enabled = False
                btimprimir.Enabled = True
                General.deshabilitarControles(Me)
            Else
                General.limpiarControles(Me)
                General.deshabilitarControles(Me)
                cargarDatosPaciente()
                bteditar.Enabled = False
                btguardar.Enabled = False
                btnuevo.Enabled = True
                btanular.Enabled = False
                objFurips.dtParametro.Clear()
                btcancelar.Enabled = False
                GroupBox3.Enabled = False
                GroupBox4.Enabled = False
                GroupBox5.Enabled = True
                btimprimir.Enabled = False
            End If
        End If
    End Sub

    'Private Sub txtrg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrg.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub Txtotro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtotro.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub Txtdireccionocurrente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtdireccionocurrente.KeyPress

    'End Sub

    'Private Sub TextBox34_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox34.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox33_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox33.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox32_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox32.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox31_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox31.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox40_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox40.KeyPress

    'End Sub

    'Private Sub TextBox52_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox52.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox51_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox51.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox50_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox50.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox49_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox49.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox47_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox47.KeyPress

    'End Sub

    'Private Sub TextBox53_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox53.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox54_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox54.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox55_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox55.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox56_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox56.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox62_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox62.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox63_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox63.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox64_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox64.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox65_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox65.KeyPress

    'End Sub

    'Private Sub TextBox75_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox75.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox74_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox74.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox73_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox73.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox72_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox72.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub TextBox77_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox77.KeyPress
    '    ValidacionDigitacion.validarAlfabetico(e)
    'End Sub

    'Private Sub txtnumerodocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumerodocumento.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub txtcod1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcod1.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub txttelefono1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono1.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub txtcodm1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodm1.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub Txtcodmun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcodmun.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub txtcoddepar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcoddepar.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox29.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox30_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox30.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox41_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox41.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox39_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox39.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox38_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox38.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox35_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox35.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox48_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox48.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox46_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox46.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox45_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox45.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox42.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox59_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox59.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox58_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox58.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox61_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox61.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox67_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox67.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox66_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox66.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox69_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox69.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox76_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox76.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox89_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox89.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox91_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox91.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    'Private Sub TextBox92_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox92.KeyPress
    '    ValidacionDigitacion.validarSoloNumerosPositivo(e)
    'End Sub

    Private Sub Combomunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combomunicipio.SelectedIndexChanged
        If Combomunicipio.SelectedIndex > 0 Then
            Txtcodmun.Text = Combomunicipio.SelectedValue
        End If
    End Sub

    Private Sub Txtcodmun_TextChanged(sender As Object, e As EventArgs) Handles Txtcodmun.TextChanged
        If Not String.IsNullOrEmpty(Txtcodmun.Text) Then
            Combomunicipio.SelectedValue = Txtcodmun.Text
        End If
    End Sub

    Private Sub Combodepratv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combodepratv.SelectedIndexChanged
        If Combodepratv.SelectedIndex > 0 Then
            TextBox39.Text = Combodepratv.SelectedValue
        End If
    End Sub

    Private Sub TextBox39_TextChanged(sender As Object, e As EventArgs) Handles TextBox39.TextChanged
        If Not String.IsNullOrEmpty(TextBox39.Text) Then
            Combodepratv.SelectedValue = TextBox39.Text
        End If
    End Sub

    Private Sub Combomuniv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combomuniv.SelectedIndexChanged
        If Combomuniv.SelectedIndex > 0 Then
            TextBox35.Text = Combomuniv.SelectedValue
        End If
    End Sub

    Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs) Handles TextBox35.TextChanged
        If Not String.IsNullOrEmpty(TextBox35.Text) Then
            Combomuniv.SelectedValue = TextBox35.Text
        End If
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox13.SelectedIndexChanged
        If ComboBox13.SelectedIndex > 0 Then
            TextBox46.Text = ComboBox13.SelectedValue
        End If
    End Sub

    Private Sub TextBox46_TextChanged(sender As Object, e As EventArgs) Handles TextBox46.TextChanged
        If Not String.IsNullOrEmpty(TextBox46.Text) Then
            ComboBox13.SelectedValue = TextBox46.Text
        End If
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox14.SelectedIndexChanged
        If ComboBox14.SelectedIndex > 0 Then
            TextBox42.Text = ComboBox14.SelectedValue
        End If
    End Sub

    Private Sub TextBox42_TextChanged(sender As Object, e As EventArgs) Handles TextBox42.TextChanged
        If Not String.IsNullOrEmpty(TextBox42.Text) Then
            ComboBox14.SelectedValue = TextBox42.Text
        End If
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        If ComboBox10.SelectedIndex > 0 Then
            TextBox59.Text = ComboBox10.SelectedValue
        End If
    End Sub

    Private Sub TextBox59_TextChanged(sender As Object, e As EventArgs) Handles TextBox59.TextChanged
        If Not String.IsNullOrEmpty(TextBox59.Text) Then
            ComboBox10.SelectedValue = TextBox59.Text
        End If
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.SelectedIndex > 0 Then
            TextBox61.Text = ComboBox9.SelectedValue
        End If
    End Sub

    Private Sub TextBox61_TextChanged(sender As Object, e As EventArgs) Handles TextBox61.TextChanged
        If Not String.IsNullOrEmpty(TextBox61.Text) Then
            ComboBox9.SelectedValue = TextBox61.Text
        End If
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedIndexChanged
        If ComboBox11.SelectedIndex > 0 Then
            TextBox67.Text = ComboBox11.SelectedValue
        End If
    End Sub

    Private Sub TextBox67_TextChanged(sender As Object, e As EventArgs) Handles TextBox67.TextChanged
        If String.IsNullOrEmpty(TextBox67.Text) Then
            ComboBox11.SelectedValue = TextBox67.Text
        End If
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox12.SelectedIndexChanged
        If ComboBox12.SelectedIndex > 0 Then
            TextBox69.Text = ComboBox12.SelectedValue
        End If
    End Sub

    Private Sub TextBox69_TextChanged(sender As Object, e As EventArgs) Handles TextBox69.TextChanged
        If Not String.IsNullOrEmpty(TextBox69.Text) Then
            ComboBox12.SelectedValue = TextBox69.Text
        End If
    End Sub

    Private Sub Combodepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedIndexChanged
        If Combodepartamento.SelectedIndex > 0 Then
            txtcoddepar.Text = Combodepartamento.SelectedValue
        End If
    End Sub

    Private Sub txtcoddepar_TextChanged(sender As Object, e As EventArgs) Handles txtcoddepar.TextChanged
        If String.IsNullOrEmpty(txtcoddepar.Text) Then
            Combodepartamento.SelectedValue = txtcoddepar
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                General.ejecutarSQL(Consultas.FURIPS_ANULAR, params)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                btanular.Enabled = False
                btguardar.Enabled = False
                bteditar.Enabled = False
                btnuevo.Enabled = True
                btimprimir.Enabled = False
                btcancelar.Enabled = False
                objFurips.dtParametro.Clear()
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                cargarRazonSocial()
                cargarDatosPaciente()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btEnviarCorreos.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim correoConfigurado As Correo
            Dim listaCorreos As New List(Of Correo)
            listaCorreos = General.cargarInformacionCorreo("a30206")
            If Not IsNothing(listaCorreos) Then
                correoConfigurado = New Correo
                correoConfigurado = listaCorreos.First()
                iniciarEnvioCorreo(correoConfigurado)
            Else
                MsgBox("Aún no tiene configurado ningún correo para este formulario!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub iniciarEnvioCorreo(ByRef pCorreo As Correo)
        If Not IsNothing(hilo) Then
            If hilo.IsAlive Then
                MsgBox("Ya esta en proceso un envio, debe esperar para volver a enviar un nuevo correo!", MsgBoxStyle.Critical)
            Else
                iniciarHilo(pCorreo)
            End If
        Else
            iniciarHilo(pCorreo)
        End If
    End Sub
    Private Sub iniciarHilo(ByRef pCorreo As Correo)
        Try
            hilo = New System.Threading.Thread(AddressOf enviarCorreo)
            hilo.Start(pCorreo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub enviarCorreo(ByVal correoConfigurado As Correo)
        correoConfigurado.asunto += "No."
        General.ConfigurarCorreo(correoConfigurado,
                                 Constantes.FORMULARIO.FURIPS,
                                 "",
                                 emailEPS)
        Try
            If generarReporte(correoConfigurado) AndAlso Funciones.enviarCorreo(correoConfigurado) Then
                MsgBox("Correo enviado !", MsgBoxStyle.Information)
            Else
                MsgBox("Correo no enviado !", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function generarReporte(ByVal correoConfigurado As Correo) As Boolean
        Dim rprte As New rptFurips
        Dim tbl As New Hashtable
        Dim ruta, area, nombreArchivo As String
        tbl = Nothing
        area = ConstantesHC.NOMBRE_PDF_FURIPS
        nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
        Try
            Funciones.getReporteNoFTP(rprte,
                                      "{VISTA_FURIPS.Codigo_furips} = " & txtcodigo.Text & "",
                                      area,
                                      Constantes.FORMATO_PDF,
                                      tbl,
                                      correoConfigurado.rutaArchivo & "\" & nombreArchivo,
                                      False)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub Checkotro_CheckedChanged(sender As Object, e As EventArgs) Handles Checkotro.CheckedChanged
        If Checkotro.Checked = True Then
            Txtotro.ReadOnly = False
        Else
            Txtotro.ReadOnly = True
            Txtotro.Clear()
        End If
    End Sub

    Private Sub txtradicado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtradicado.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub


    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información atencion laboratorio", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_FURIPS
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarFurips()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarFurips()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_FURIPS, txtcodigo.Text, New rptFurips,
                                    txtcodigo.Text, "{VISTA_FURIPS.Codigo_furips} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_FURIPS, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class