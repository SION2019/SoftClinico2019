Imports System.Data.SqlClient
Imports System.IO
Public Class Form_Contrato_laboral
    Dim id_cuenta, id_aux, busminuta1, tempfileurl As String
    Dim respuesta, setcombos As Boolean
    Dim cmd As New ContratoLaboralBLL
    Dim perG As New Buscar_Permisos_generales
    Dim cbcargos As ComboBox
    Dim objContrato As New Contrato
    Dim itemChecked, itemChecked1 As Object
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pterminar, Pempleado, Ptercero, PMinuta As String
    Dim wd As Word.ApplicationClass
    Dim doc As Word.Document
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub ocultarPestañas()
        '----oculta las pestaña--
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        '--------------------------
    End Sub
    Private Sub visiblePestañaNoAprendiz()
        TabPage1.Parent = TabControl1
        If combotipo.SelectedValue = "A" Then
            TabPage5.Parent = TabControl1
        End If
        TabPage4.Parent = TabControl1
        TabPage2.Parent = TabControl1
        TabPage3.Parent = TabControl1
    End Sub
    Private Sub habilitarControles()
        General.deshabilitarControles(Me)
        textsalario.ReadOnly = False
        textAuxTrans.ReadOnly = False
        combotipo.Enabled = True
        dtFechaInic.Enabled = True
        dtFechaClaus.Enabled = True
        btbuscarminuta.Enabled = True
        btbuscartercero.Enabled = True
    End Sub
    Private Sub btbuscartercero_Click(sender As Object, e As EventArgs) Handles btbuscartercero.Click
        General.buscarElemento(Consultas.BUSQUEDA_SIN_CONTRATO_LABORAL_EMP & objContrato.idEmpresa,
                               Nothing,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_CONTRATO_LABORALES,
                               True, Constantes.TAMANO_MEDIANO, True)
    End Sub
    Private Sub cargarTercero(pCodigo As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)

        params.Add(objContrato.idEmpresa)
        params.Add(pCodigo)
        drTercero = General.cargarItem(Consultas.CARGAR_EMPLEADO_SIN_CONTRATO, params)

        objContrato.idEmpleado = pCodigo
        General.limpiarControles(TabControl1)

        Txtabrev.Text = drTercero.Item("Tipo_Ident")
        txtidentificacion.Text = drTercero.Item("Nit")
        txtdv.Text = drTercero.Item("DV")
        txtpnombre.Text = drTercero.Item("nombre")
        txtsnombre.Text = drTercero.Item("snombre")
        txtpapellido.Text = drTercero.Item("Apellido")
        txtsapellido.Text = drTercero.Item("sApellido")
        txttelefono.Text = drTercero.Item("Telefono1")
        txttelefono2.Text = drTercero.Item("telefono2")
        txtwhatsapp.Text = drTercero.Item("whatsapp")
        TxtDireccion.Text = drTercero.Item("Direccion")
        comboperfil.SelectedValue = drTercero.Item("Codigo_perfil").ToString()
        combocargo.SelectedValue = drTercero.Item("Codigo_cargo").ToString()
        ComboSexo.SelectedValue = drTercero.Item("Codigo_genero").ToString()
        Dtfechanac.Value = drTercero.Item("Fecha_nacimiento").ToString()
        dtfechaExp.Value = drTercero.Item("Fecha_expedicion").ToString()

        textsalario.Text = drTercero.Item("Valor_Salario").ToString()

        id_cuenta = If(IsDBNull(drTercero.Item("ID_Cuenta_Bancaria")), 0,
                       drTercero.Item("ID_Cuenta_Bancaria"))
        dtFechaInic.Value = drTercero.Item("Fecha_Comienzo").ToString()
        dtFechaClaus.Value = drTercero.Item("Fecha_Fin").ToString()

        If IsDBNull(drTercero.Item("Foto").ToString()) = True Then
            picturefoto.Image = Nothing
        Else
            Dim bites = drTercero.Item("Foto")
            If (bites IsNot DBNull.Value AndAlso bites.Length > 0) Then
                Dim ms As New MemoryStream(DirectCast(bites, Byte()))
                picturefoto.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            End If
        End If

        Combopais.SelectedValue = If(IsDBNull(drTercero.Item("Codigo_pais_nac").ToString()),
                                         Constantes.VALOR_PREDETERMINADO,
                                         drTercero.Item("Codigo_pais_nac").ToString())
        Combodepartamento.SelectedValue = If(IsDBNull(drTercero.Item("Codigo_departamento_nac").ToString()),
                                         Constantes.VALOR_PREDETERMINADO,
                                         drTercero.Item("Codigo_departamento_nac").ToString())
        Combociudad.SelectedValue = If(IsDBNull(drTercero.Item("Codigo_Municipio_nac").ToString()),
                                         Constantes.VALOR_PREDETERMINADO,
                                         drTercero.Item("Codigo_Municipio_nac").ToString())
        combopaisexp.SelectedValue = drTercero.Item("Codigo_pais_exp").ToString()
        combodptoexp.SelectedValue = drTercero.Item("Codigo_departamento_exp").ToString()
        CombociudadExp.SelectedValue = drTercero.Item("Codigo_Municipio_exp").ToString()
        comboprofesion.SelectedValue = drTercero.Item("Codigo_Profesion").ToString()
        textcuenta.Text = drTercero.Item("Numero_cuenta").ToString()
        textcuentacc.Text = drTercero.Item("CC_Cuenta").ToString()
        comboTcuenta.SelectedValue = drTercero.Item("Codigo_tipo_cuenta").ToString()
        combobanco.SelectedValue = drTercero.Item("Codigo_Banco").ToString()
        comboeps.SelectedValue = drTercero.Item("Id_EPS").ToString()
        comboarp.SelectedValue = drTercero.Item("Codigo_ARP").ToString()
        combocaja.SelectedValue = drTercero.Item("Codigo_Caja").ToString()
        combopension.SelectedValue = drTercero.Item("Codigo_Pension").ToString()
        cbEspecialidad.SelectedValue = drTercero.Item("Codigo_Especialidad").ToString()
        'objContrato.puntosAsignados = objContrato.obtenerPuntosServicioEmpleado(objContrato)

        If combotipo.SelectedValue <> "L" Then
            textsalario.Text = Constantes.VALOR_NO_APLICA
            textAuxTrans.Text = Constantes.VALOR_NO_APLICA
        End If

        'cargarPuntoServicio()
        btbuscarEmpresa.Enabled = True
    End Sub
    'Private Sub cargarPuntoServicio()
    '    listarPuntosAsignados(objContrato.puntosAsignados)
    'End Sub

    Public Sub listarPuntosAsignados(puntos As List(Of PuntoServicio))
        chlistpuntoasignado.ClearSelected()

        For Each punto As PuntoServicio In puntos
            chlistpuntoasignado.Items.Add(punto)
            chlistpuntoasignado.SetItemChecked(chlistpuntoasignado.Items.Count - 1, True)
        Next

        chlistpuntoasignado.DisplayMember = "PuntoNombre"
        chlistpuntoasignado.ValueMember = "Codigo"
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            habilitarControles()
            objContrato.dtPunto.Rows.Add()
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub limpiarcontroles()
        Panel4.BackColor = Color.White
        id_cuenta = ""
        General.limpiarControles(Me)
    End Sub
    Private Function validarGuardar()
        Dim resultado As Boolean

        Return resultado
    End Function
    Private Function validarCampos() As Boolean
        Dim ValOk As Boolean
        If (combotipo.SelectedIndex = 0) Then
            Exec.SavingMsg("¡ Por favor digite el tipo de contrato!", combotipo)
        ElseIf (IsNothing(objContrato.idEmpleado)) Then
            Exec.SavingMsg("¡ Por favor seleccione el empleado!", btbuscartercero)
        ElseIf (textsalario.Enabled And combotipo.SelectedIndex = 1) And
            (Not IsNumeric(textsalario.Text) _
            OrElse (textsalario.Text <= 0)) OrElse (textsalario.Text = "") Then
            TabControl1.SelectedIndex = 0
            Exec.SavingMsg("¡ Por favor digite el salario del empleado!", textsalario)
        ElseIf (textAuxTrans.Enabled And combotipo.SelectedIndex = 1) _
            And (Not IsNumeric(textAuxTrans.Text) _
            OrElse (textAuxTrans.Text < 0)) _
            OrElse (textAuxTrans.Text = "") Then
            TabControl1.SelectedIndex = 0
            Exec.SavingMsg("¡ Por favor digite el Auxilio de Transporte!", textAuxTrans)
        ElseIf (txtCodigoMinuta.Text = "") Then
            TabControl1.SelectedIndex = 1
            Exec.SavingMsg("¡ Por favor digite la minuta del contrato!", textminuta)
        ElseIf (textNit.Text = "") Then
            Exec.SavingMsg("¡ Por favor seleccione la empresa que paga !", btbuscarEmpresa)
        ElseIf objContrato.dtPunto.Rows.Count = 1 Then
            Exec.SavingMsg("¡ Por favor seleccione un punto donde labora !", dgvPuntoContrato)
        ElseIf String.IsNullOrEmpty(txtcodigo.Text) _
            And Funciones.consultarPeriodoContratoActivo(objContrato.idEmpleado, dtFechaInic.Value, dtFechaClaus.Value, objContrato.idEmpresaPagar) = True Then
            Exec.SavingMsg("¡ Existe un contrato Activo en este Periodo, Termine o Elimine el contrato para poder continuar. !", dtFechaInic)
        Else
            ValOk = True
        End If
        Return ValOk
    End Function
    Private Sub cargarObjeto()
        objContrato.codigo = txtcodigo.Text
        objContrato.inicio = dtFechaInic.Value.Date
        objContrato.fin = dtFechaClaus.Value.Date
        'objContrato.codigo_min = CInt(busminuta1)
        objContrato.tipo = combotipo.SelectedValue
        objContrato.salario = CDbl(textsalario.Text)
        objContrato.auxilio = CDbl(textAuxTrans.Text)
        'objContrato.id_cuenta = id_cuenta
        'objContrato.id_aux = CInt((If(IsDBNull(id_aux), Nothing, id_aux)))
        objContrato.diasPrueba = domDiaPrueba.Text
        objContrato.numeroGrupo = txtNumeroGrupo.Text
        objContrato.sena = If(rbSI.Checked = True, True, False)
        objContrato.nitCentro = If(String.IsNullOrEmpty(txtNitCentroF.Text), Nothing, txtNitCentroF.Text)
        objContrato.dvCentro = If(String.IsNullOrEmpty(txtDVCentro.Text), Nothing, txtDVCentro.Text)
        objContrato.centro = txtCentroF.Text
        'objContrato.observacion = If(String.IsNullOrEmpty(txtObservacion.Text), Nothing, txtObservacion.Text)
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validarCampos() = True Then
                cargarObjeto()
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    cmd.guardar_contrato(objContrato)
                    txtcodigo.Text = objContrato.codigo
                    cargarPuntosContrato(txtcodigo.Text)
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    btbuscar.Enabled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cargarEmpleadoContrato(pCodigo As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        drTercero = General.cargarItem(Consultas.CARGAR_EMPLEADO_CONTRATO, params)
        objContrato.codigo = pCodigo

        txtcodigo.Text = pCodigo
        General.limpiarControles(TabControl1)

        objContrato.idEmpleado = drTercero.Item("Id_empleado")
        objContrato.idEmpresaPagar = drTercero.Item("Id_empresa_nomina")
        'objContrato.id_aux = drTercero.Item("ID_Aux_Transporte")
        objContrato.codigoMinuta = drTercero.Item("Codigo_minuta")
        txtCodigoMinuta.Text = objContrato.codigoMinuta
        Txtabrev.Text = drTercero.Item("Tipo_Ident")
        txtidentificacion.Text = drTercero.Item("Nit")
        txtdv.Text = drTercero.Item("DV")
        txtpnombre.Text = drTercero.Item("nombre")
        txtsnombre.Text = drTercero.Item("snombre")
        txtpapellido.Text = drTercero.Item("Apellido")
        txtsapellido.Text = drTercero.Item("sApellido")
        txttelefono.Text = drTercero.Item("Telefono1")
        txttelefono2.Text = drTercero.Item("telefono2")
        txtwhatsapp.Text = drTercero.Item("whatsapp")
        TxtDireccion.Text = drTercero.Item("Direccion")
        comboperfil.SelectedValue = drTercero.Item("Codigo_perfil").ToString()
        combocargo.SelectedValue = drTercero.Item("Codigo_cargo").ToString()
        ComboSexo.SelectedValue = drTercero.Item("Codigo_genero").ToString()
        Dtfechanac.Value = drTercero.Item("Fecha_nacimiento").ToString()
        dtfechaExp.Value = drTercero.Item("Fecha_expedicion").ToString()
        textsalario.Text = drTercero.Item("Valor_Salario").ToString()
        id_cuenta = drTercero.Item("ID_Cuenta_Bancaria").ToString()
        dtFechaInic.Value = drTercero.Item("Fecha_Comienzo").ToString()
        dtFechaClaus.Value = drTercero.Item("Fecha_Fin").ToString()
        textAuxTrans.Text = If(drTercero.Item("valor_auxilio").ToString() = "", 0,
            drTercero.Item("valor_auxilio"))
        If IsDBNull(drTercero.Item("Foto").ToString()) = True Then
            picturefoto.Image = Nothing
        Else
            Dim bites = drTercero.Item("Foto")
            If (bites IsNot DBNull.Value AndAlso bites.Length > 0) Then
                Dim ms As New MemoryStream(DirectCast(bites, Byte()))
                picturefoto.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            End If
        End If
        Combopais.SelectedValue = If(IsDBNull(drTercero.Item("Codigo_pais_nac").ToString()),
                                         Constantes.VALOR_PREDETERMINADO,
                                         drTercero.Item("Codigo_pais_nac").ToString())
        Combodepartamento.SelectedValue = If(IsDBNull(drTercero.Item("Codigo_departamento_nac").ToString()),
                                         Constantes.VALOR_PREDETERMINADO,
                                         drTercero.Item("Codigo_departamento_nac").ToString())
        Combociudad.SelectedValue = If(IsDBNull(drTercero.Item("Codigo_Municipio_nac").ToString()),
                                         Constantes.VALOR_PREDETERMINADO,
                                         drTercero.Item("Codigo_Municipio_nac").ToString())
        combopaisexp.SelectedValue = drTercero.Item("Codigo_pais_exp").ToString()
        combodptoexp.SelectedValue = drTercero.Item("Codigo_departamento_exp").ToString()
        CombociudadExp.SelectedValue = drTercero.Item("Codigo_Municipio_exp").ToString()
        comboprofesion.SelectedValue = drTercero.Item("Codigo_Profesion").ToString()
        textcuenta.Text = drTercero.Item("Numero_cuenta").ToString()
        textcuentacc.Text = drTercero.Item("CC_Cuenta").ToString()
        comboTcuenta.SelectedValue = drTercero.Item("Codigo_tipo_cuenta").ToString()
        combobanco.SelectedValue = drTercero.Item("Codigo_Banco").ToString()
        comboeps.SelectedValue = drTercero.Item("Id_EPS").ToString()
        comboarp.SelectedValue = drTercero.Item("Codigo_ARP").ToString()
        combocaja.SelectedValue = drTercero.Item("Codigo_Caja").ToString()
        combopension.SelectedValue = drTercero.Item("Codigo_Pension").ToString()
        combotipo.SelectedValue = drTercero.Item("Tipo_Contrato").ToString()
        domDiaPrueba.Text = drTercero.Item("Dias_prueba").ToString()

        txtNumeroGrupo.Text = drTercero.Item("Numero_grupo").ToString()
        If drTercero.Item("sena") = True Then
            rbSI.Checked = True
        Else
            rbNO.Checked = True
        End If
        txtNitCentroF.Text = drTercero.Item("Nit").ToString()
        txtDVCentro.Text = drTercero.Item("dv").ToString()
        txtCentroF.Text = drTercero.Item("Formacion").ToString()
        txtObservacion.Text = drTercero.Item("Observacion").ToString()
        cbEspecialidad.SelectedValue = drTercero.Item("Codigo_Especialidad").ToString()

        'objContrato.puntosAsignados = objContrato.obtenerPuntosServicioEmpleado(objContrato)
        'cargarPuntoServicio()
        cargarEmpresa(objContrato.idEmpresaPagar)
        cargarPuntosContrato(pCodigo)
        ocultarPestañas()
        visiblePestañaNoAprendiz()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, bteditar, btanular)
        btbuscar.Enabled = True
        btTerminar.Enabled = True
        btimprimir.Enabled = True

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                habilitarControles()
                General.deshabilitarBotones(ToolStrip1)
                objContrato.dtPunto.Rows.Add()
                btguardar.Enabled = True
                btcancelar.Enabled = True
                btbuscarEmpresa.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btnuevo) = True Then
            btbuscar.Enabled = True
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            'descripcion Anula un registro: 
            'Autor: Resident7
            'fecha_creacion: 05/05/2016

            If MsgBox(Mensajes.ANULAR & ":" & txtcodigoEMP.Text.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_CONTRATO & txtcodigo.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            End If

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub textminutaCargar(pminutas As String)
        objContrato.codigoMinuta = pminutas
        If System.IO.File.Exists(tempfileurl) Then
            'txtDescripcionMinuta.Text = objContrato.cargarMinuta(tempfileurl)
            busminuta1 = objContrato.codigoMinuta
            btbuscartercero.Enabled = False
            llenar_minuta()
            bytes_to_rtf()
        Else
            textminuta.Clear()
            MsgBox("No se puede cargar el contrato porque la minuta, fue eliminada", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarContratoMinuta(pminutas As String)
        Try

            objContrato.codigoMinuta = pminutas
            'txtDescripcionMinuta.Text = objContrato.cargarMinuta(tempfileurl)
            busminuta1 = objContrato.codigoMinuta
            btbuscartercero.Enabled = False
            llenar_minuta()
            bytes_to_rtf()

        Catch ex As Exception
            General.manejoErrores(ex)
        cerrar_doc()
        End Try
    End Sub
    Sub bytes_to_rtf()
        wd = New Word.ApplicationClass
        doc = wd.Documents.Open(tempfileurl + ".docx", False, False, False)
        doc.SaveAs(tempfileurl + ".rtf", Word.WdSaveFormat.wdFormatRTF)
        Call cerrar_doc()
        textminuta.LoadFile(tempfileurl + ".rtf")
    End Sub
    Sub llenar_minuta()
        Dim dtdatoscontratante As New DataTable("DATOS_CONTRATANTE")
        'objContrato.llenarDatosContratante(dtdatoscontratante)
        wd = New Word.ApplicationClass

        doc = wd.Documents.Open(tempfileurl + ".docx", False, False, False)

        Dim dw As DataRow = dtdatoscontratante.Rows(0)
        Dim fConvertirNumeros As New ConvertirNumeros
        Dim fechaFin = dtFechaClaus.Value.AddDays(dtFechaInic.Value.Day)
        Dim duracionMeses As Integer = ((fechaFin.Year - dtFechaInic.Value.Year) * 12) + fechaFin.Month - dtFechaClaus.Value.Month
        Dim nombreEmpleado As String = txtpnombre.Text & " " & txtsnombre.Text & " " & txtpapellido.Text & " " & txtsapellido.Text & " "
        remp("{NUMERO-CONTRATO}", objContrato.codigo)
        remp("{CONTRATISTA}", SesionActual.nombreEmpresa)
        remp("{DIRECCION-CONTRATISTA}", TxtDireccion.Text)
        remp("{IDENTIFICACION-CONTRATISTA}", Val(txtidentificacion.Text).ToString("N0"))
        remp("{TURNO}", Exec.ToDbl(textsalario.Text).ToString("C"))

        remp("{EMPLEADO}", nombreEmpleado)
        remp("{DIRECCION-EMPLEADO}", TxtDireccion.Text)
        remp("{CEDULA}", Val(txtidentificacion.Text).ToString("N0"))
        remp("{CIUDADEXPCC}", CombociudadExp.Text)
        remp("{PAIS-NACIMIENTO}", Combopais.Text)
        remp("{SALARIO}", Exec.ToDbl(textsalario.Text).ToString("C"))

        remp("{TIPO-CONTRATO}", Me.combotipo.Text)
        remp("{FECHA-CONTRATO}", dtFechaInic.Value.ToString("dd MMMM yyyy"))
        remp("{FECHA-TERMINACION}", dtFechaClaus.Value.ToString("dd MMMM yyyy"))
        remp("{FECHA-CONTRATO-INICIO}", String.Format("{0:%d} de {0:MMMM} del {0:yyyy}", dtFechaInic.Value), True)                                          'datetimefechainicio.Value.ToString("dd MMMM yyyy"))
        remp("{FECHA-CONTRATO-FIN}", String.Format("{0:%d} de {0:MMMM} del {0:yyyy}", dtFechaClaus.Value), True)
        remp("{DURACION-MESES-LETRA}", duracionMeses.ToString + " (" + fConvertirNumeros.Num2Text(duracionMeses) + ")", True)

        remp("{FECHA-NACIMIENTO}", Dtfechanac.Value.ToString("dd MMMM yyyy"))
        remp("{CIUDAD-NACIMIENTO}", Combociudad.Text)
        remp("{CARGO}", combocargo.Text)
        remp("{PUNTOS-ASIGANADOS}", getpuntos)
        remp("{PENSION}", combopension.Text)
        remp("{EPS}", comboeps.Text)
        remp("{ARP}", comboarp.Text)

        remp("{Numero_Grupo}", txtNumeroGrupo.Text)
        remp("{Especialidad}", cbEspecialidad.Text)
        remp("{NitFormacion}", txtNitCentroF)
        remp("{DVFormacion}", txtDVCentro.Text)
        remp("{CentroFormacion}", txtCentroF.Text)

        remp("{CONTRATANTE}", nombreEmpleado)
        remp("{IDENTIFICACION-CONTRATANTE}", Val(dw("Nit")).ToString("N0"))
        remp("{DIRECCION-CONTRATANTE}", dw("Direccion"))

        remp("{EMPLEADOR}", dw("Razon_Social"))
        remp("{IDENTIFICACION-EMPLEADOR}", Val(dw("Nit")).ToString("N0"))
        remp("{DIRECCION-EMPLEADOR}", dw("Direccion"))

        remp("{REPRESENTANTE}", dw("Razon_Representante"))
        remp("{IDENTIFICACION-REPRESENTANTE}", Val(dw("Nit_Representante")).ToString("N0") +
        " DE " + dw("Municipio_Representante") + " - " + dw("Departamento_Representante"))

        remp("{CIUDAD_DEPARTAMENTO}", dw("Ciudad") + " " + dw("Departamento"), True)
        remp("{DIAS_LETRAS}", fConvertirNumeros.Num2Text(dtFechaInic.Value.ToString("dd")) +
             " (" + dtFechaInic.Value.ToString("dd") + ")", True)
        remp("{MES_LETRAS}", dtFechaInic.Value.ToString("MMMM"), True)
        remp("{AÑO}", dtFechaInic.Value.ToString("yyyy"))

        rempfirma("{FIRMA}", tempfileurl + ".jpg")
        rempfirma("{FIRMA-REPRESENTANTE}", tempfileurl + ".rep.jpg")

        Try
            doc.Close(True, False, False)
        Catch
        End Try
        Call cerrar_doc()
    End Sub

    Function getpuntos() As String
        Dim pp As String = ""
        For Each i As DataRow In objContrato.dtPunto.Select
            pp += i.Item("Nombre").ToString + ", "
        Next
        Return pp.TrimEnd(" ").TrimEnd(",").ToUpper
    End Function
    Sub remp(ByVal bus As String, ByVal por As Object, Optional ProperCase As Boolean = False)
        If por Is DBNull.Value Then Return
        Try
            With doc.Range.Find
                .Text = bus
                .Replacement.Text = If(ProperCase, StrConv(por, VbStrConv.ProperCase), por.ToString.ToUpper)
                .Wrap = Word.WdFindWrap.wdFindContinue
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            End With
        Catch
        End Try
    End Sub
    Sub rempfirma(ByVal bus As String, ByVal path As String)
        Try
            Dim rango As Word.Range = Me.doc.Range
            With rango.Find
                .Text = bus
                .Execute()
                Dim ob As Object = rango.InlineShapes.AddPicture(path)
                ob.Height = CInt(ob.Height * (150 / ob.Width))
                ob.Width = 150
                .Replacement.Text = ""
                .Execute(Replace:=Word.WdReplace.wdReplaceOne)
            End With
        Catch
        End Try
    End Sub
    Private Sub cerrar_doc()
        Try
            doc.Close(False, False, False)
        Catch
        End Try
        Try
            wd.Quit(False, False, False)
        Catch
        End Try
    End Sub
    Private Sub del_doc()
        Try
            My.Computer.FileSystem.DeleteFile(tempfileurl + ".docx")
        Catch
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(tempfileurl + ".rtf")
        Catch
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(tempfileurl + ".jpg")
        Catch
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(tempfileurl + "rep.jpg")
        Catch
        End Try
    End Sub

    Private Sub textsalario_Leave(sender As Object, e As EventArgs) Handles textsalario.Leave
        Dim textsalario1 As String = textsalario.Text.TrimStart(",").TrimEnd(",")
        If textsalario.Enabled And IsNumeric(textsalario1) Then
            textsalario.Text = textsalario1
        Else
            textsalario.Text = "0,00"
        End If
    End Sub

    Private Sub textsalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textsalario.KeyPress, textAuxTrans.KeyPress
        'si el caracter es Letra
        If Char.IsDigit(e.KeyChar) Then
            'acepta el cracter
            e.Handled = False
            'si es un caracter de control como Enter
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'si es un espacio en blanco
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            If e.KeyChar = "." Then e.KeyChar = ","
            e.Handled = False
            'si es un espacio en blanco
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            ' de lo contario al poner e.handled en True
            'cancelamos la pulsación.
            e.Handled = True
        End If
    End Sub

    Private Sub btTerminar_Click(sender As Object, e As EventArgs) Handles btTerminar.Click
        If SesionActual.tienePermiso(Pterminar) Then
            If MsgBox("¿Desea terminar este contrato " & txtcodigoEMP.Text.ToString & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Terminar") = MsgBoxResult.Yes Then
                If MsgBox("¿Se quitarán el empleado del horario, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Terminar") = MsgBoxResult.Yes Then
                    panelRazon.Visible = True
                    txtRazones.ReadOnly = False
                    btContinuar.Enabled = True
                    btCancelarRazon.Enabled = True
                    panelRazon.BringToFront()
                    panelRazon.Focus()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub btbuscarminuta_Click(sender As Object, e As EventArgs) Handles btbuscarminuta.Click

        If combotipo.SelectedIndex = 0 Then
            MsgBox("Favor seleccionar el tipo de contrato", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(combotipo.SelectedValue)
        General.buscarElemento(Consultas.BUSQUEDA_CNTT_LBRLS_MINUTAS, params,
                               AddressOf cargarMinuta,
                               TitulosForm.BUSQUEDA_CNTT_LBRLS_MINUTAS, True)

    End Sub
    Sub cargarMinuta(pcodigo As String)
        Cursor = Cursors.WaitCursor
        tempfileurl = Path.GetTempPath + DateTime.Now.Ticks.ToString
        txtCodigoMinuta.Text = pcodigo
        cargarContratoMinuta(pcodigo)
        Cursor = Cursors.Default
    End Sub

    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarEmpresa.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(objContrato.idEmpleado)
        params.Add(dtFechaInic.Value)
        params.Add(dtFechaClaus.Value)
        General.buscarElemento(Consultas.BUSQUEDA_EMPRESA_CONTRATO,
                                  params,
                                  AddressOf cargarEmpresa,
                                  TitulosForm.BUSQUEDA_EMPRESA, True, 0, True)
    End Sub
    Private Sub cargarEmpresa(pCodigo As String)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        dFila = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR, params)
        objContrato.idEmpresaPagar = pCodigo
        textNit.Text = dFila("Nit")
        textDV.Text = dFila("DV")
        textEmpresa.Text = dFila("Razon_Social")
        textNit.ReadOnly = True : textDV.ReadOnly = True : textEmpresa.ReadOnly = True
    End Sub
    Private Sub Form_Contrato_laboral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim params As New List(Of String)
        params.Add(Nothing)
        permiso_general = perG.buscarPermisoGeneral(Name)

        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pterminar = permiso_general & "pp" & "05"
        Pempleado = permiso_general & "pp" & "06"
        Ptercero = permiso_general & "pp" & "07"
        PMinuta = permiso_general & "pp" & "08"

        objContrato.idEmpresa = SesionActual.idEmpresa
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True

        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", combopaisexp)
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", ComboSexo)
        General.cargarCombo(Consultas.PROFESION_LISTAR, "Descripción profesión", "Código", comboprofesion)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", combocargo)
        General.cargarCombo(Consultas.BANCO_LISTAR, "Descripción", "Código", combobanco)
        General.cargarCombo(Consultas.CAJA_LISTAR, "Descripción caja", "Código", combocaja)
        General.cargarCombo(Consultas.EPS_LISTAR, params, "Nombre", "Código", comboeps)
        General.cargarCombo(Consultas.PENSION_LISTAR, "Descripción pensión", "Código", combopension)
        General.cargarCombo(Consultas.ARP_LISTAR, "Descripción ARP", "Código", comboarp)
        General.cargarCombo(Consultas.PEFIL_LISTAR & SesionActual.idEmpresa & "", "Nombre perfil", "Código", comboperfil)
        General.cargarCombo(Consultas.TCUENTA_LISTAR, "Descripción", "Código", comboTcuenta)
        General.cargarCombo(Consultas.ESPECIALIDAD_LISTAR, "Descripción", "Código", cbEspecialidad)

        General.deshabilitarControles(Me)
        cargarComboTipoContrato()
        cargarDatatable()

        TabPage5.Parent = Nothing
    End Sub

    Private Sub btContinuar_Click(sender As Object, e As EventArgs) Handles btContinuar.Click
        If txtRazones.Text = String.Empty Then
            Exec.SavingMsg("Favor digitar la razón para terminar el Contrato ", txtRazones)
        Else

            Dim vRazon As String = txtRazones.Text.ToString

            respuesta = General.anularRegistro(Consultas.TERMINAR_CONTRATO & txtcodigo.Text &
                                               ConstantesHC.NOMBRE_PDF_SEPARADOR3 & "'" &
                                                vRazon & "'" &
            ConstantesHC.NOMBRE_PDF_SEPARADOR3 & SesionActual.idUsuario)
            If respuesta = True Then
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                panelRazon.Visible = False
                MsgBox("Contrato terminado con éxito", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub btCancelarRazon_Click(sender As Object, e As EventArgs) Handles btCancelarRazon.Click
        panelRazon.Visible = False
    End Sub
    Private Sub MostrarActivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarActivosToolStripMenuItem.Click
        buscarContrato(Consultas.BUSQUEDA_CONTRATO_LABORAL)
    End Sub
    Private Sub MostrarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarTodosToolStripMenuItem.Click
        buscarContrato(Consultas.BUSQUEDA_TODO_CONTRATO_LABORAL)
    End Sub
    Private Sub buscarContrato(Consulta As String)
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consulta & SesionActual.idEmpresa,
                                   Nothing,
                                   AddressOf cargarEmpleadoContrato,
                                   TitulosForm.BUSQUEDA_CONTRATO_LABORALES,
                                   False,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then
            If Not objContrato.idEmpleado = Nothing Then
                If txtDescripcionMinuta.Text = Nothing Then
                    If Not String.IsNullOrEmpty(txtcodigo.Text) Then
                        textminutaCargar(objContrato.codigoMinuta)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub textsalario_KeyUp(sender As Object, e As KeyEventArgs) Handles textsalario.KeyUp, textAuxTrans.KeyUp
        'Select Case textsalario.Focused
        '    Case True
        '        textsalario.Text = cmd.Puntos(textsalario.Text)
        '        textsalario.Select(textsalario.Text.Length, 0)
        '    Case Else
        '        textAuxTrans.Text = cmd.Puntos(textAuxTrans.Text)
        '        textAuxTrans.Select(textAuxTrans.Text.Length, 0)
        'End Select
    End Sub
    Private Sub dtFechaClaus_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaInic.ValueChanged, dtFechaClaus.ValueChanged
        If btguardar.Enabled = False Then Exit Sub
        domDiaPrueba.Text = cmd.calcularPruebaDias(dtFechaInic.Value, dtFechaClaus.Value)
    End Sub
    Private Sub cargarComboTipoContrato()
        Dim dtTabla As New DataTable
        dtTabla.Columns.Add("Valor")
        dtTabla.Columns.Add("Descripcion")
        Dim drFila As DataRow = dtTabla.NewRow()

        drFila.Item(0) = "-1"
        drFila.Item(1) = " - - - Seleccione - - - "
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "L"
        drFila.Item(1) = "Laboral"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "P"
        drFila.Item(1) = "Prestación de servicio"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "A"
        drFila.Item(1) = "Aprendizaje"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "V"
        drFila.Item(1) = "Voluntario"
        dtTabla.Rows.Add(drFila)

        combotipo.DataSource = dtTabla
        combotipo.DisplayMember = "Descripcion"
        combotipo.ValueMember = "Valor"
        combotipo.SelectedIndex = 0
    End Sub
    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        If Combopais.ValueMember <> String.Empty Then
            If IsNothing(Combopais.SelectedValue) Then Return 
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
            End If
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        If Combodepartamento.ValueMember <> String.Empty Then
            If IsNothing(Combodepartamento.SelectedValue) Then Return
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
        End If
    End Sub

    Private Sub combotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotipo.SelectedIndexChanged
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        ocultarPestañas()
        visiblePestañaNoAprendiz()
        If combotipo.SelectedValue <> "L" Then
            textsalario.ReadOnly = True
            textAuxTrans.ReadOnly = True
            If combotipo.SelectedValue = "A" Then
                General.habilitarControles(TabPage5)
                cbEspecialidad.Enabled = False
                textsalario.ReadOnly = False
                textAuxTrans.ReadOnly = False
            End If
        Else
            textsalario.ReadOnly = False
            textAuxTrans.ReadOnly = False
        End If
    End Sub

    Private Sub txtNitCentroF_TextChanged(sender As Object, e As EventArgs) Handles txtNitCentroF.TextChanged
        Dim DV As New DigitoVerificacion
        Dim n As Integer
        n = DV.CalculaNit(txtNitCentroF.Text)
        txtDVCentro.Text = CType(n, String)
        If txtNitCentroF.Text = Nothing Then
            txtDVCentro.Text = Nothing
        End If
    End Sub

    Private Sub Form_Contrato_laboral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtcodigo.Text <> "" Then
            Try

                TabControl1.SelectedTab = TabPage2
                    If combotipo.SelectedItem.ToString.ToLower = "Nómina" AndAlso (Not IsNumeric(textsalario.Text) _
                        OrElse Not CDbl(textsalario.Text) > 0) AndAlso
                        (MsgBox("El Salario del Contrato No puede ser $ 0 pesos.",
                                MsgBoxStyle.Exclamation, "No es Posible Generar el Contrato") <> 123) Then Return
                Call cerrar_doc()
                If System.IO.File.Exists(tempfileurl) = True Then
                    wd = New Word.ApplicationClass
                    wd.Documents.Open(tempfileurl + ".docx", False, False, True)
                    wd.Visible = True
                    wd.Activate()
                    wd.PrintPreview = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No ha seleccionado ningún contrato.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btOpcionEmpleado_Click(sender As Object, e As EventArgs) Handles btOpcionEmpleado.Click
        If SesionActual.tienePermiso(Pempleado) Then
            Dim form_empleado1 As New Form_empleado()
            General.cargarForm(form_empleado1)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btOpcionTercero_Click(sender As Object, e As EventArgs) Handles btOpcionTercero.Click
        If SesionActual.tienePermiso(Ptercero) Then
            General.cargarForm(FormTercero)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btpuntos_Click(sender As Object, e As EventArgs) Handles btOpcionMinuta.Click
        If SesionActual.tienePermiso(PMinuta) Then
            Dim Form_minutas1 As New Form_minutas
            General.cargarForm(Form_minutas1)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Combopaisexp_SelectedValueChanged(sender As Object, e As EventArgs) Handles combopaisexp.SelectedValueChanged
        If combopaisexp.ValueMember <> String.Empty Then
            If IsNothing(combopaisexp.SelectedValue) Then Return
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & combopaisexp.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", combodptoexp)
        End If
    End Sub
    Private Sub combodptoexp_SelectedValueChanged(sender As Object, e As EventArgs) Handles combodptoexp.SelectedValueChanged
        If combodptoexp.ValueMember <> String.Empty Then
            If IsNothing(combodptoexp.SelectedValue) Then Return
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodptoexp.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", CombociudadExp)
        End If
    End Sub
    Private Sub cargarDatatable()
        With dgvPuntoContrato
            .Columns("codigoPunto").DataPropertyName = "codigo"
            .Columns("descrip").DataPropertyName = "Nombre"
            .Columns("anular").DisplayIndex = 2
            .DataSource = objContrato.dtPunto
        End With
    End Sub
    Private Sub cargarPuntosContrato(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla("PROC_CONTRATO_LABORAL_PUNTO", params, objContrato.dtPunto)
        dgvPuntoContrato.DataSource = objContrato.dtPunto
    End Sub
    Private Sub buscarPuntoServicio()
        General.busquedaItems("[PROC_BUSQUEDA_TODOS_PUNTO]",
                               Nothing,
                               TitulosForm.BUSQUEDA_PUNTO_SERVICIO, dgvPuntoContrato, objContrato.dtPunto, 0, 1, 0)
    End Sub
    Private Sub dgvPuntoContrato_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPuntoContrato.KeyDown
        If btguardar.Enabled = False Then Exit Sub
        If e.KeyCode = Keys.F3 Then
            buscarPuntoServicio()
        End If
    End Sub
    Private Sub dgvPuntoContrato_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuntoContrato.CellDoubleClick
        If btguardar.Enabled = False Then Exit Sub
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(objContrato.dtPunto.Rows(dgvPuntoContrato.CurrentCell.RowIndex).Item("codigo")) Then
                objContrato.dtPunto.Rows.RemoveAt(dgvPuntoContrato.CurrentCell.RowIndex)
            End If
        Else
            buscarPuntoServicio()
        End If
    End Sub
End Class