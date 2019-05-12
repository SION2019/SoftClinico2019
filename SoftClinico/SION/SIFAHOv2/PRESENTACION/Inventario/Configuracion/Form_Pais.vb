Public Class Form_Pais
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim objPais As Pais
    Private Sub Form_Pais_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub Form_Pais_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre del pais !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardar()
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
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            anular()
        End If
    End Sub
#End Region
#Region "Metodos"
    Sub anular()
        Dim paisCmd As New PaisBLL
        objPais = New Pais
        establecerObjeto(objPais)
        Try
            paisCmd.Anular(objPais)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub buscar()
        General.buscarElemento(Consultas.PAIS_LISTAR,
                                 Nothing,
                                 AddressOf cargarPais,
                                 TitulosForm.BUSQUEDA_PAIS,
                                 False, 0, True)

    End Sub
    Sub guardar()
        Dim paisCmd As New PaisBLL
        objPais = New Pais
        establecerObjeto(objPais)
        Try
            paisCmd.guardar(objPais)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            cargarPais(objPais.codigo)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub cargarPais(ByVal codigo As String)
        objPais = New Pais
        Dim params As New List(Of String)
        params.Add(codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.PAIS_CARGAR_DATOS, params)
        objPais.codigo = fila(0)
        objPais.nombre = fila(1)
        reflejarObjeto(objPais)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Sub reflejarObjeto(ByRef objPais As Pais)
        txtcodigo.Text = objPais.codigo
        txtnombre.Text = objPais.nombre
    End Sub
    Sub establecerObjeto(ByRef objPais As Pais)
        objPais.codigo = txtcodigo.Text
        objPais.nombre = txtnombre.Text
    End Sub
#End Region
End Class