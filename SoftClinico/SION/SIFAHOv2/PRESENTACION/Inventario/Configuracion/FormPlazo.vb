Public Class FormPlazo
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public comboPlazo As ComboBox
    Dim objPlazo As Plazo
    Private Sub FormPlazo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        btguardar.Enabled = False
        bteditar.Enabled = False
        btanular.Enabled = False
        btcancelar.Enabled = False
        txtnombre.ReadOnly = True
    End Sub
    Private Sub Form_PlazoClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

#Region "Botonoes"
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                anular()
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de la linea !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtnombre.Text)
                params.Add(txtcodigo.Text)
                If General.getEstadoVF(Consultas.PLAZO_DIA_VERIFICAR, params) Then
                    MsgBox("El dia: " & txtnombre.Text & " ya existe", MsgBoxStyle.Exclamation)
                    txtnombre.Clear()
                Else
                    guardar()
                End If
            End If
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            buscar()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

#End Region
#Region "Metodos"
    Public Sub buscar()
        Dim params As New List(Of String)
        params.Add("")
        General.buscarElemento(Consultas.BUSQUEDA_PLAZOS,
                               params,
                               AddressOf cargarPlazo,
                               TitulosForm.BUSQUEDA_PLAZOS,
                               False, 0, True)

    End Sub
    Public Sub guardar()
        Dim plazoCmd As New PlazoEntregaBLL
        objPlazo = New Plazo
        establecerObjeto(objPlazo)
        Try
            plazoCmd.guardar(objPlazo, SesionActual.idUsuario)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            cargarPlazo(objPlazo.codigo)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub


    Public Sub anular()
        Try
            Dim plazoCmd As New PlazoEntregaBLL
            objPlazo = New Plazo
            establecerObjeto(objPlazo)
            plazoCmd.anular(objPlazo, SesionActual.idUsuario)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub cargarPlazo(ByVal codigo As String)
        objPlazo = New Plazo
        Dim params As New List(Of String)
        params.Add(codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGAR_PLAZOS, params)
        objPlazo.codigo = fila(0)
        objPlazo.nombre = fila(1)
        reflejarObjeto(objPlazo)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Sub reflejarObjeto(ByVal objPlazo As Plazo)
        txtcodigo.Text = objPlazo.codigo
        txtnombre.Text = objPlazo.nombre
    End Sub
    Sub establecerObjeto(ByRef objPlazo As Plazo)
        objPlazo.codigo = txtcodigo.Text
        objPlazo.nombre = txtnombre.Text
    End Sub
#End Region

End Class