Public Class formOxigeno
    Dim cmd As New OxigenoConfBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private codigoEquivalnecia, codigoOxigeno As Integer
    Private nombreEquivalencia, nombreOxigeno As String
    Private factor, porcentaje As Double
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Property setCodigoEquivalencia As Integer
        Get
            Return codigoEquivalnecia
        End Get
        Set(value As Integer)
            codigoEquivalnecia = value
        End Set
    End Property

    Public Property setCodigoOxigeno As Integer
        Get
            Return codigoOxigeno
        End Get
        Set(value As Integer)
            codigoOxigeno = value
        End Set
    End Property

    Public Property setNombreEquivalencia As String
        Get
            Return nombreEquivalencia
        End Get
        Set(value As String)
            nombreEquivalencia = value
        End Set
    End Property

    Public Property setNombreOxigeno As String
        Get
            Return nombreOxigeno
        End Get
        Set(value As String)
            nombreOxigeno = value
        End Set
    End Property

    Public Property setFactor As Double
        Get
            Return factor
        End Get
        Set(value As Double)
            factor = value
        End Set
    End Property

    Public Property setPorcentaje As Double
        Get
            Return porcentaje
        End Get
        Set(value As Double)
            porcentaje = value
        End Set
    End Property

    Public Sub asignarControlesEquivalnecia()
        txtcodigoEquivalencia.Text = codigoEquivalnecia
        txtNombreEquivalencia.Text = nombreEquivalencia
    End Sub
    Public Sub asignarControlesOxigeno()
        txtcodigo.Text = codigoOxigeno
        txtnombre.Text = nombreOxigeno
        NumFactor.Value = factor
        NumPorcentaje.Value = porcentaje
    End Sub

    Private Sub FormOxigeno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Me.Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(Me)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If General.anularRegistro(Consultas.ANULAR_OXIGENO & " " & txtcodigo.Text & "," & SesionActual.idUsuario) Then
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
    Private Sub FormOxigeno_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

#Region "Metodos"
    Public Function validarFormulario() As Boolean
        If txtnombre.Text = "" Then
            MsgBox("Debe colocar el nombre del oxigeno", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
            Return False
        ElseIf txtcodigoEquivalencia.Text = "" Then
            MsgBox("Debe escoger la equivalencia para asociarla", MsgBoxStyle.Exclamation)
            txtcodigoEquivalencia.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub guardarOxigeno()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try

                If txtcodigo.Text = "" Then
                    cmd.guardarOxigeno(txtcodigo, txtnombre.Text.ToUpper, NumFactor.Value, NumPorcentaje.Value, txtcodigoEquivalencia.Text)
                Else
                    cmd.actualizarOxigeno(txtcodigo.Text, txtnombre.Text.ToUpper, NumFactor.Value, NumPorcentaje.Value, txtcodigoEquivalencia.Text)
                End If



                General.posGuardarForm(Me, ToolStrip1, btnuevo, bteditar, btbuscar, btanular)

            Catch ex As Exception
                General.manejoErrores(ex)
            End Try

        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() Then
            guardarOxigeno()
        End If
    End Sub
    Private Sub btBuscarEquivalencia_Click(sender As Object, e As EventArgs) Handles btBuscarEquivalencia.Click
        Try
            General.buscarElemento(Consultas.LISTAR_EQUIVALENCIAS, Nothing, AddressOf cargarEquivalencia,
                                                         TitulosForm.BUSQUEDA_EQUIVALENCIA, True, 0, True)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarEquivalencia(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CARGAR_EQUIVALENCIA, params, dtCarga)
        txtcodigoEquivalencia.Text = dtCarga.Rows(0).Item(0)
        txtNombreEquivalencia.Text = dtCarga.Rows(0).Item(2)

    End Sub
    Private Sub cargarOxigeno(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CARGAR_OXIGENO, params, dtCarga)
        txtcodigo.Text = dtCarga.Rows(0).Item(0)
        txtnombre.Text = dtCarga.Rows(0).Item(1)
        txtcodigoEquivalencia.Text = dtCarga.Rows(0).Item(2)
        txtNombreEquivalencia.Text = dtCarga.Rows(0).Item(3)
        NumFactor.Value = dtCarga.Rows(0).Item(4)
        NumPorcentaje.Value = dtCarga.Rows(0).Item(5)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        btanular.Enabled = True
        bteditar.Enabled = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Try
                General.buscarElemento(Consultas.LISTAR_OXIGENO, Nothing, AddressOf cargarOxigeno,
                                                         TitulosForm.BUSQUEDA_OXIGENO, True, 0, True)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
End Class