Public Class Form_Comidas
    Public buscarComidas As Boolean
    Dim cmd As New Comidas_D
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PConfiguracion As String
    Dim objComida As New Comida
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Comidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Me.Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PConfiguracion = permiso_general & "pp" & "05"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
#Region "Botones"
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_COMIDA, params)
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormularios() Then
            objComida.SetGetCodigoComida = txtcodigo.Text
            objComida.SetGetNombreComida = txtnombre.Text.ToUpper
            objComida.SetGetCosto = NumCosto.Value
            objComida.SetGetPuntoComida = SesionActual.codigoEP
            guardarComida()
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
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
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.LISTAR_COMIDA, params,
                                   AddressOf cargarComida,
                                   TitulosForm.BUSQUEDA_COMIDA,
                                   False, 0, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btOpcionConfiguracionHorario_Click(sender As Object, e As EventArgs) Handles btOpcionConfiguracionHorario.Click
        If SesionActual.tienePermiso(PConfiguracion ) Then
            Dim configuracion As New Form_comidas_horas
            General.cargarForm(configuracion)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarComida(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_COMIDA_CARGAR, params, dt)
        txtcodigo.Text = pCodigo
        txtnombre.Text = dt.Rows(0).Item("Descripcion")
        NumCosto.Value = dt.Rows(0).Item("Costo")
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
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

#End Region
#Region "Metodos"
    Function validarFormularios() As Boolean
        If txtnombre.Text = "" Then
            MsgBox("Debe eligir el nombre de la comida", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
            Return False
            'cambio realizado por resident7 23/08/2017 se pueden colocar comidas sin costo.
            'ElseIf NumCosto.Value = 0 Then
            '    MsgBox("Debe colocar el costo de la comida", MsgBoxStyle.Exclamation)
            '    NumCosto.Focus()
            '    Return False
        End If
        Return True
    End Function
    Sub guardarComida()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                If txtcodigo.Text = "" Then
                    cmd.guardarComida(objComida)
                    txtcodigo.Text = objComida.SetGetCodigoComida
                Else
                    cmd.actualizarComida(objComida)
                End If

                General.posGuardarForm(Me, ToolStrip1, btnuevo, bteditar, btbuscar, btanular)

            Catch ex As Exception
                General.manejoErrores(ex)
            End Try

        End If
    End Sub
    Public Sub establecerValoresBuscados(ByVal codigo As Integer)
        Dim tblTemp As New DataTable
        General.llenarTablaYdgv(Consultas.COMIDA_INDIVIFUAL & " " & codigo, tblTemp)
        objComida.SetGetCodigoComida = tblTemp.Rows(0).Item(0)
        objComida.SetGetNombreComida = tblTemp.Rows(0).Item(1)
        objComida.SetGetCosto = tblTemp.Rows(0).Item(2)
        enlazarDatosControles()
    End Sub
    Sub enlazarDatosControles()
        txtcodigo.Text = objComida.SetGetCodigoComida
        txtnombre.Text = objComida.SetGetNombreComida
        NumCosto.Value = objComida.SetGetCosto
    End Sub
#End Region
End Class