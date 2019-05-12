Imports Celer

Public Class FormPedidoFarmacia
    Dim vFormPadre As Form_Historia_clinica
    Dim permiso_general, Pcargar, Penviar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim objPedidoFarmacia As PedidoFarmacia
    Private Sub FormPedidoFarmacia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPedidoFarmacia = New PedidoFarmacia
        permiso_general = perG.buscarPermisoGeneral(Me.Name, vFormPadre.Tag.modulo)
        Pcargar = permiso_general & "pp" & "01"
        Penviar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btCargar, btbuscar)
        inicializarFomulario()
    End Sub
#Region "Metodos"
    Private Sub inicializarFomulario()
        txtNombrePaciente.Text = vFormPadre.txtNombre.Text
        txtEdad.Text = vFormPadre.txtEdad.Text
        txtHistoriaClinica.Text = vFormPadre.txtHC.Text
        txtSexo.Text = vFormPadre.txtSexo.Text
        txtNregistro.Text = vFormPadre.txtRegistro.Text
        configurardgvMedicamentos()
        configurardgvInfusion()
        configurardgvImpregnacion()
        configurardgvNutricion()
        configurardgvInsumosEnfermeria()
        configurardgvInsumosFisioterapia()
    End Sub
    Function getUltimaOrdenPendiente()
        Dim valor As Boolean = True
        Dim params As New List(Of String)
        Dim fila As DataRow
        Dim filaInsumosEnfermeria As DataRow
        Dim filaInsumosFisioterapia As DataRow
        params.Add(txtNregistro.Text)
        fila = General.cargarItem(Consultas.PEDIDO_FARMACIA_CARGAR_ULTIMA_ORDEN_PENDIENTE, params)
        filaInsumosEnfermeria = General.cargarItem(Consultas.PEDIDO_FARMACIA_CARGAR_ULTIMA_ORDEN_PENDIENTE_INSUMOS_ENFERMERIA, params)
        filaInsumosFisioterapia = General.cargarItem(Consultas.PEDIDO_FARMACIA_CARGAR_ULTIMA_ORDEN_PENDIENTE_INSUMOS_FISIOTERAPIA, params)
        If IsNothing(fila) AndAlso IsNothing(filaInsumosEnfermeria) AndAlso IsNothing(filaInsumosFisioterapia) Then
            MsgBox("No hay orden pendiente!", MsgBoxStyle.Exclamation)
            valor = False
        Else
            objPedidoFarmacia.codigoOrdenEnfermeria = If(IsNothing(filaInsumosEnfermeria), -1, filaInsumosEnfermeria(0))
            objPedidoFarmacia.codigoOrdenFisioterapia = If(IsNothing(filaInsumosFisioterapia), -1, filaInsumosFisioterapia(0))
            objPedidoFarmacia.codigoOrden = If(IsNothing(fila), -1, fila(0))
            txtCodigoOrden.Text = objPedidoFarmacia.codigoOrden
            getDetalleOrden()
        End If
        Return valor
    End Function
    Sub getDetalleOrden()
        getMedicamento()
        tabInfusion.Select()
        getInfusion()
        getMezclas()
        getImpregnacion()
        getNutricion()
        getInsumosEnfermeria()
        getInsumosFisioterapia()
        tabMedicacion.Select()
    End Sub
    Sub getMedicamento()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_CARGAR_MEDICAMENTOS, objPedidoFarmacia.tablaMedicamentos, objPedidoFarmacia.codigoOrden)
    End Sub
    Sub getInfusion()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_CARGAR_INFUSIONES, objPedidoFarmacia.tablaInfusiones, objPedidoFarmacia.codigoOrden)
    End Sub
    Sub getMezclas()
        Dim lectorMezclas As DataRow
        Dim params As New List(Of String)

        For indiceFila = 0 To objPedidoFarmacia.tablaInfusiones.Rows.Count - 1
            lectorMezclas = Nothing
            params.Clear()
            params.Add(objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_Infusion"))
            lectorMezclas = General.cargarItem(Consultas.PEDIDO_FRAMACIA_CARGAR_INFUSIONES_MEZCLAS, params)
            If Not IsNothing(lectorMezclas) Then
                objPedidoFarmacia.agregarTabla(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_Infusion"),
                                                                                       objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Codigo_interno")))
                cargarDetalleGrillas(Consultas.PEDIDO_FRAMACIA_CARGAR_INFUSIONES_MEZCLAS,
                                     objPedidoFarmacia.dtTablaMezclas.Tables(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_infusion"),
                                                                                                                     objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Codigo_interno"))),
                                     objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_infusion"))
                General.IsExistente(dgvInfusion, "Mezcla", indiceFila)
            Else
                General.IsNotExistente(dgvInfusion, "Mezcla", indiceFila)
            End If
        Next
        dgvInfusion.EndEdit()
    End Sub
    Sub getImpregnacion()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_CARGAR_IMPREGNACIONES, objPedidoFarmacia.tablaImpregnaciones, objPedidoFarmacia.codigoOrden)
    End Sub
    Sub getInsumosEnfermeria()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_CARGAR_INSUMOS_ENFERMERIA_DETALLE, objPedidoFarmacia.tablaInsumosEnfermeria, objPedidoFarmacia.codigoOrdenEnfermeria)
    End Sub
    Sub getInsumosFisioterapia()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_CARGAR_INSUMOS_FISIOTERAPIA_DETALLE, objPedidoFarmacia.tablaInsumosFisioterapia, objPedidoFarmacia.codigoOrdenFisioterapia)
    End Sub
    Sub getNutricion()
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(objPedidoFarmacia.codigoOrden)
        fila = General.cargarItem(Consultas.PEDIDO_FARMACIA_CARGAR_NUTRICION, params)
        txtRazón.Text = CDbl(If(IsNothing(fila), 0, fila(1)))
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_CARGAR_NUTRICION_DETALLE, objPedidoFarmacia.tablaNutricion, objPedidoFarmacia.codigoOrden)
        txtVolumenTotal.Text = calcularVolumenTotal()
    End Sub
    Sub cargarDetalleGrillas(ByVal query As String, ByRef tabla As DataTable, ByVal codigoFiltro As Integer)
        Dim params As New List(Of String)
        params.Add(codigoFiltro)
        General.llenarTabla(query, params, tabla)
    End Sub
    Sub cargarPedidoFarmacia(ByVal codigoBuscado As Integer)
        objPedidoFarmacia.codigoPedidoFarmacia = codigoBuscado
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(objPedidoFarmacia.codigoPedidoFarmacia)
        fila = General.cargarItem(Consultas.PEDIDO_FARMACIA_BUSCAR_INDIVIDUAL, params)
        objPedidoFarmacia.codigoOrden = fila(0).ToString
        objPedidoFarmacia.codigoOrdenEnfermeria = fila(1).ToString
        objPedidoFarmacia.codigoOrdenFisioterapia = fila(2).ToString
        objPedidoFarmacia.fechaPedido = fila(3)

        cargarPedidoFarmaciaMedicamentosGuardados()
        cargarPedidoFarmaciaInfusionesGuardados()
        cargarPedidoFarmaciaNutricionGuardados()
        cargarPedidoFarmaciaImpregnacionesGuardados()
        cargarPedidoFarmaciaInsumosEnfermeriaGuardados()
        cargarPedidoFarmaciaInsumosFisioterapiaGuardados()
        empalmarObjeto()
        General.posBuscarForm(Me, ToolStrip1, btCargar, btbuscar, btanular, Nothing)
    End Sub
    Sub empalmarObjeto()
        txtCodigo.Text = objPedidoFarmacia.codigoPedidoFarmacia
        txtCodigoOrden.Text = objPedidoFarmacia.codigoOrden
        dtpFechaPedido.Value = objPedidoFarmacia.fechaPedido
        txtRazón.Text = objPedidoFarmacia.nutRazon
    End Sub
    Sub cargarPedidoFarmaciaMedicamentosGuardados()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_BUSCAR_MEDICAMENTOS, objPedidoFarmacia.tablaMedicamentos, objPedidoFarmacia.codigoPedidoFarmacia)
    End Sub
    Sub cargarPedidoFarmaciaInfusionesGuardados()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_BUSCAR_INFUSIONES, objPedidoFarmacia.tablaInfusiones, objPedidoFarmacia.codigoPedidoFarmacia)
        Dim params As New List(Of String)
        For indiceFila = 0 To objPedidoFarmacia.tablaInfusiones.Rows.Count - 1
            objPedidoFarmacia.agregarTabla(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_infusion"),
                                                                                   objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Codigo_interno")))

            params.Clear()
            params.Add(objPedidoFarmacia.codigoPedidoFarmacia)
            params.Add(objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_infusion"))

            General.llenarTabla(Consultas.PEDIDO_FARMACIA_BUSCAR_INFUSINES_MEZCLAS, params, objPedidoFarmacia.dtTablaMezclas.Tables(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Consecutivo_infusion"),
                                                                                                                                                                            objPedidoFarmacia.tablaInfusiones.Rows(indiceFila).Item("Codigo_interno"))))
        Next
    End Sub
    Sub cargarPedidoFarmaciaImpregnacionesGuardados()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_BUSCAR_IMPREGNACIONES, objPedidoFarmacia.tablaImpregnaciones, objPedidoFarmacia.codigoPedidoFarmacia)
    End Sub
    Sub cargarPedidoFarmaciaNutricionGuardados()
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(objPedidoFarmacia.codigoPedidoFarmacia)
        fila = General.cargarItem(Consultas.PEDIDO_FARMACIA_BUSCAR_NUTRICION, params)
        If Not IsNothing(fila) Then
            objPedidoFarmacia.nutRazon = fila(2)
            cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_BUSCAR_NUTRICION_DETALLE, objPedidoFarmacia.tablaNutricion, objPedidoFarmacia.codigoPedidoFarmacia)
            txtVolumenTotal.Text = calcularVolumenTotal()
        End If

    End Sub
    Sub cargarPedidoFarmaciaInsumosEnfermeriaGuardados()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_BUSCAR_INSUMOS_ENFERMERIA, objPedidoFarmacia.tablaInsumosEnfermeria, objPedidoFarmacia.codigoPedidoFarmacia)
    End Sub
    Sub cargarPedidoFarmaciaInsumosFisioterapiaGuardados()
        cargarDetalleGrillas(Consultas.PEDIDO_FARMACIA_BUSCAR_INSUMOS_FISIOTERAPIA, objPedidoFarmacia.tablaInsumosFisioterapia, objPedidoFarmacia.codigoPedidoFarmacia)
    End Sub

    Sub configurardgvMedicamentos()
        With dgvMedicacion
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Concentracion").ReadOnly = True
            .Columns("Concentracion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Concentracion").DataPropertyName = "Concentracion"
            .Columns("Cant_Dosis").ReadOnly = True
            .Columns("Cant_Dosis").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cant_Dosis").DataPropertyName = "Cant_Dosis"
            .Columns("Frecuencia").ReadOnly = True
            .Columns("Frecuencia").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Frecuencia").DataPropertyName = "Frecuencia"
            .Columns("Hora_Inicial").ReadOnly = True
            .Columns("Hora_Inicial").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Hora_Inicial").DataPropertyName = "Hora_Inicial"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.tablaMedicamentos
        End With
    End Sub
    Sub configurardgvInfusion()
        With dgvInfusion
            .Columns("DescripcionInf").ReadOnly = True
            .Columns("DescripcionInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionInf").DataPropertyName = "Descripcion"
            .Columns("DosisInf").ReadOnly = True
            .Columns("DosisInf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DosisInf").DataPropertyName = "Dosis"
            .Columns("Velocidad").ReadOnly = True
            .Columns("Velocidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Velocidad").DataPropertyName = "Velocidad"
            .Columns("Descripcion_Disolvente").ReadOnly = True
            .Columns("Descripcion_Disolvente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion_Disolvente").DataPropertyName = "Descripcion_Disolvente"
            .Columns("Cantidad_Disolvente").ReadOnly = True
            .Columns("Cantidad_Disolvente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad_Disolvente").DataPropertyName = "Cantidad_Disolvente"
            .Columns("Cantidad_Disolvente").Visible = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.tablaInfusiones
        End With
    End Sub
    Sub configurardgvImpregnacion()
        With dgvImpregnacion
            .Columns("descripcionImp").ReadOnly = True
            .Columns("descripcionImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("descripcionImp").DataPropertyName = "Descripcion"
            .Columns("DosisImp").ReadOnly = True
            .Columns("DosisImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DosisImp").DataPropertyName = "Dosis"
            .Columns("VelocidadImp").ReadOnly = True
            .Columns("VelocidadImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("VelocidadImp").DataPropertyName = "Velocidad"
            .Columns("DisolventeImp").ReadOnly = True
            .Columns("DisolventeImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DisolventeImp").DataPropertyName = "Descripcion_Disolvente"
            .Columns("CantidadDisolventeImp").ReadOnly = True
            .Columns("CantidadDisolventeImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDisolventeImp").DataPropertyName = "Cantidad_Disolvente"
            .Columns("Hora_InicialImp").ReadOnly = True
            .Columns("Hora_InicialImp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Hora_InicialImp").DataPropertyName = "Hora_Inicial"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.tablaImpregnaciones
        End With
    End Sub
    Sub configurardgvNutricion()
        With dgvNutricion
            .Columns("DescripcionNut").ReadOnly = True
            .Columns("DescripcionNut").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionNut").DataPropertyName = "Descripcion"
            .Columns("Requerimiento").ReadOnly = True
            .Columns("Requerimiento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Requerimiento").DataPropertyName = "Requerimiento"
            .Columns("Volumenes").ReadOnly = True
            .Columns("Volumenes").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Volumenes").DataPropertyName = "Volumenes"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.tablaNutricion
        End With
    End Sub
    Sub configurardgvInsumosEnfermeria()
        With dgvInsumosEnfermeria
            .Columns("DescripcionInsEnf").ReadOnly = True
            .Columns("DescripcionInsEnf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionInsEnf").DataPropertyName = "Descripcion"
            .Columns("CantidadEnf").ReadOnly = True
            .Columns("CantidadEnf").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadEnf").DataPropertyName = "Cantidad"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.tablaInsumosEnfermeria
        End With
    End Sub
    Sub configurardgvInsumosFisioterapia()
        With dgvInsumosFisioterapia
            .Columns("DescripcionFisio").ReadOnly = True
            .Columns("DescripcionFisio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionFisio").DataPropertyName = "Descripcion"
            .Columns("CantidadFisio").ReadOnly = True
            .Columns("CantidadFisio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadFisio").DataPropertyName = "Cantidad"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.tablaInsumosFisioterapia
        End With
    End Sub
    Sub configurardgvMezclas(ByVal pNombreTabla As String)
        With dgvMezcla
            .Columns("DescripcionMez").ReadOnly = True
            .Columns("DescripcionMez").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionMez").DataPropertyName = "Descripcion"
            .Columns("DosisMez").ReadOnly = True
            .Columns("DosisMez").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DosisMez").DataPropertyName = "Dosis"
            .Columns("CantidadMez").ReadOnly = True
            .Columns("CantidadMez").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadMez").DataPropertyName = "Cantidad"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objPedidoFarmacia.dtTablaMezclas.Tables(pNombreTabla)
        End With
    End Sub
    Sub visualizacionPanelMezclas()
        If panelMezcla.Visible = True Then
            panelMezcla.Visible = False
        Else
            panelMezcla.Visible = True
            dgvMezcla.Focus()
        End If
    End Sub
    Sub limpiarDespuesAnular()
        objPedidoFarmacia.codigoOrden = Nothing
        objPedidoFarmacia.tablaMedicamentos.Clear()
        objPedidoFarmacia.tablaInfusiones.Clear()
        objPedidoFarmacia.tablaNutricion.Clear()
        objPedidoFarmacia.tablaInsumosEnfermeria.Clear()
        objPedidoFarmacia.tablaInsumosFisioterapia.Clear()
        objPedidoFarmacia.tablaImpregnaciones.Clear()
        objPedidoFarmacia.dtTablaMezclas.Clear()
        empalmarObjeto()
    End Sub
#End Region
#Region "Funciones"
    Function validarEnvio() As Boolean
        If objPedidoFarmacia.tablaMedicamentos.Rows.Count > 0 OrElse
           objPedidoFarmacia.tablaInfusiones.Rows.Count > 0 OrElse
           objPedidoFarmacia.tablaNutricion.Rows.Count > 0 OrElse
           objPedidoFarmacia.tablaImpregnaciones.Rows.Count > 0 OrElse
           objPedidoFarmacia.tablaInsumosEnfermeria.Rows.Count > 0 OrElse
           objPedidoFarmacia.tablaInsumosFisioterapia.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function calcularVolumenTotal() As Double
        Dim valor As Double
        valor = If(IsDBNull(objPedidoFarmacia.tablaNutricion.Compute("Sum(Volumenes)", "")), 0, objPedidoFarmacia.tablaNutricion.Compute("Sum(Volumenes)", ""))
        Return valor
    End Function
#End Region
#Region "Botones"
    Private Sub btCargar_Click(sender As Object, e As EventArgs) Handles btCargar.Click
        If SesionActual.tienePermiso(Pcargar) Then

            If verificarEstadoActualPaciente(txtNregistro.Text, Constantes.ESTADO_ATENCION_INICIADO) Then
                Cursor = Cursors.WaitCursor
                If getUltimaOrdenPendiente() Then
                    txtCodigo.Clear()
                    objPedidoFarmacia.codigoPedidoFarmacia = -1
                    If validarEnvio() Then
                        General.deshabilitarBotones(ToolStrip1)
                        btEnviar.Enabled = True
                        btcancelar.Enabled = True
                    End If
                End If
                Cursor = Cursors.Default
            Else
                MsgBox("El estado del paciente no es atendido", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        objPedidoFarmacia.tablaMedicamentos.Clear()
        objPedidoFarmacia.tablaInfusiones.Clear()
        objPedidoFarmacia.tablaNutricion.Clear()
        objPedidoFarmacia.tablaInsumosEnfermeria.Clear()
        objPedidoFarmacia.tablaInsumosFisioterapia.Clear()
        objPedidoFarmacia.tablaImpregnaciones.Clear()
        objPedidoFarmacia.dtTablaMezclas.Reset()
        General.deshabilitarBotones(ToolStrip1)
        btCargar.Enabled = True
        btbuscar.Enabled = True
        txtCodigo.Clear()
        txtCodigoOrden.Clear()

    End Sub
    Private Sub btEnviar_Click(sender As Object, e As EventArgs) Handles btEnviar.Click
        If SesionActual.tienePermiso(Penviar) Then
            Try
                If PedidoValido() AndAlso MsgBox("Desea enviar el pedido a farmacia", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim objPedidoFarmaciaBLL As New PedidoFarmaciaBLL
                    objPedidoFarmaciaBLL.guardarPedido(objPedidoFarmacia, SesionActual.idUsuario, SesionActual.codigoEP)
                    txtCodigo.Text = objPedidoFarmacia.codigoPedidoFarmacia
                    objPedidoFarmacia.nutVolumenesTotales = txtVolumenTotal.Text
                    objPedidoFarmacia.nutRazon = txtRazón.Text
                    General.posGuardarForm(Me, ToolStrip1, btCargar, btbuscar, btanular, Nothing)
                End If
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Function PedidoValido() As Boolean
        If objPedidoFarmacia.tablaMedicamentos.Select("Hora_Inicial = -1", "").Count > 0 Then
            MsgBox(Mensajes.COLOCAR_HORA_INICIAL, MsgBoxStyle.Exclamation)
            Return False
        ElseIf objPedidoFarmacia.tablaImpregnaciones.Select("Hora_Inicial = -1", "").Count > 0 Then
            MsgBox(Mensajes.COLOCAR_HORA_INICIAL, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(txtNregistro.Text)
            General.buscarElemento(Consultas.PEDIDO_FARMACIA_BUSCAR,
                                       params,
                                       AddressOf cargarPedidoFarmacia,
                                       TitulosForm.BUSQUEDA_PEDIDO_FARMACIA,
                                       False,
                                       Constantes.TAMANO_MEDIANO,
                                        True
                                       )
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            Try
                Dim objPedidoFarmaciaBLL As New PedidoFarmaciaBLL
                If objPedidoFarmaciaBLL.verificarPedidoCargado(objPedidoFarmacia) AndAlso MsgBox("Desea anular el pedido a farmacia", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    objPedidoFarmaciaBLL.anularPedido(objPedidoFarmacia, SesionActual.idUsuario)
                    General.deshabilitarBotones(ToolStrip1)
                    limpiarDespuesAnular()
                    btCargar.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Eventos de Datagridview"
    Private Sub dgvInfusion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfusion.CellClick
        If e.ColumnIndex = dgvInfusion.Columns("QuitarInf").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            If Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.tablaInfusiones, e.RowIndex) Then
                objPedidoFarmacia.quitarTablas(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(e.RowIndex).Item("Consecutivo_infusion"),
                                                                                       objPedidoFarmacia.tablaInfusiones.Rows(e.RowIndex).Item("Codigo_interno")))
            End If
        ElseIf e.ColumnIndex = dgvInfusion.Columns("Mezcla").Index Then
            configurardgvMezclas(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(e.RowIndex).Item("Consecutivo_infusion"),
                                                                         objPedidoFarmacia.tablaInfusiones.Rows(e.RowIndex).Item("Codigo_interno")))
            visualizacionPanelMezclas()
        End If
    End Sub
    Private Sub dgvMedicacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicacion.CellClick
        If e.ColumnIndex = dgvMedicacion.Columns("QuitarMed").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.tablaMedicamentos, e.RowIndex)
        End If
    End Sub
    Private Sub dgvImpregnacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpregnacion.CellClick
        If e.ColumnIndex = dgvImpregnacion.Columns("QuitarImp").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.tablaImpregnaciones, e.RowIndex)
        End If
    End Sub
    Private Sub dgvNutricion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNutricion.CellClick
        If e.ColumnIndex = dgvNutricion.Columns("QuitarNut").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.tablaNutricion, e.RowIndex)
            txtVolumenTotal.Text = calcularVolumenTotal()
        End If
    End Sub
    Private Sub dgvInsumosEnfermeria_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosEnfermeria.CellClick
        If e.ColumnIndex = dgvInsumosEnfermeria.Columns("QuitarEnf").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.tablaInsumosEnfermeria, e.RowIndex)
        End If
    End Sub
    Private Sub dgvInsumosFisioterapia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumosFisioterapia.CellClick
        If e.ColumnIndex = dgvInsumosFisioterapia.Columns("QuitarFisio").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.tablaInsumosFisioterapia, e.RowIndex)
        End If
    End Sub
    Private Sub dgvMezcla_Leave(sender As Object, e As EventArgs) Handles dgvMezcla.Leave
        visualizacionPanelMezclas()
    End Sub
    Private Sub dgvMezcla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMezcla.CellClick
        If e.ColumnIndex = dgvMezcla.Columns("QuitarMez").Index AndAlso Funciones.filaValida(e.RowIndex) AndAlso txtCodigo.Text = "" Then
            Funciones.quitarFilasSinRestriccion(objPedidoFarmacia.dtTablaMezclas.Tables(objPedidoFarmacia.nombrarMezclaInfusion(objPedidoFarmacia.tablaInfusiones.Rows(dgvInfusion.CurrentRow.Index).Item("Consecutivo_infusion"),
                                                                                                                                objPedidoFarmacia.tablaInfusiones.Rows(dgvInfusion.CurrentRow.Index).Item("Codigo_interno"))), dgvInfusion.CurrentRow.Index)
        End If
    End Sub
    Public Sub iniciarDatos(ByRef form_Historia_clinica As Form_Historia_clinica)
        vFormPadre = form_Historia_clinica
    End Sub
    Function verificarEstadoActualPaciente(ByRef nRegistro As Integer,
                                           ByVal codigoEstadonIniciado As Integer) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim pedidofarmaciaBLL As New PedidoFarmaciaBLL
            respuesta = pedidofarmaciaBLL.verificarEstadoActualPaciente(nRegistro, codigoEstadonIniciado)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        Return respuesta
    End Function
#End Region
    Private Sub FormPedidoFarmacia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
End Class