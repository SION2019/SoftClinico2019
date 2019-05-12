Imports System.Data.SqlClient
Public Class Perfiles
    Dim objPerfil As New TerceroPerfil
    Private Sub Perfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        dgvEmpleados.DataSource = objPerfil.dtEmpleados
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.dtPermisos.Select("Codigo_menu='a10301pp01'").Count = 0 Then
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        General.limpiarControles(Me)
        General.habilitarControles(Me)
        txtcodigo.ReadOnly = True
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        If SesionActual.dtPermisos.Select("Codigo_menu='a10301pp04'").Count = 0 Then
            arbolmenu.Enabled = False
        Else
            arbolmenu.Enabled = True
        End If
        objPerfil.codigoPerfil = Constantes.VALOR_PREDETERMINADO
        cargarArbolPUC()

        txtnombre.Focus()
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.dtPermisos.Select("Codigo_menu='a10301pp02'").Count = 0 Then
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.habilitarControles(Me)
            txtcodigo.ReadOnly = True
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            If SesionActual.dtPermisos.Select("Codigo_menu='a10301pp04'").Count = 0 Then
                arbolmenu.Enabled = False
            Else
                arbolmenu.Enabled = True
            End If
            dgvEmpleados.ReadOnly = True
            txtnombre.Focus()
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        arbolmenu.Enabled = False
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If (txtnombre.Text = "") Then
            MsgBox("¡ Por favor digite el nombre del perfil de usuario!", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    objPerfil.codigoPerfil = txtcodigo.Text
                    objPerfil.nombre = txtnombre.Text
                    objPerfil.observacion = observaciones.Text
                    objPerfil.guardarPerfil()
                    txtcodigo.Text = objPerfil.codigoPerfil
                    guardarPermisos()
                    'MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    arbolmenu.Enabled = False
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub guardarPermisos()
        Try
            Using consulta = New SqlCommand()
                consulta.Connection = FormPrincipal.cnxion
                consulta.CommandType = CommandType.StoredProcedure
                consulta.CommandText = "PROC_PERFIL_MODULO_ELIMINAR"
                consulta.Parameters.Add(New SqlParameter("@Codigo_perfil", SqlDbType.Int)).Value = objPerfil.codigoPerfil
                consulta.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                consulta.ExecuteNonQuery()
                consulta.CommandText = "[PROC_PERFIL_MODULO_ASIGNAR]"
                consulta.Parameters.Add(New SqlParameter("@tbl", SqlDbType.Structured)).Value = dsDatos.Tables("Perfil_Menu")
                consulta.ExecuteNonQuery()
                MsgBox("Módulos guardados éxitosamente", MsgBoxStyle.Information)
            End Using

            If objPerfil.codigoPerfil = SesionActual.codigoPerfil Then
                fprincipal.eliminarMenu()
                fprincipal.CreaOpciones(SesionActual.idEmpresa, SesionActual.codigoPerfil)
                FormPrincipal.dtPermisos.Clear()
                FormPrincipal.dtPermisos = fprincipal.cargarOpciones(SesionActual.codigoPerfil, SesionActual.idEmpresa)
                SesionActual.dtPermisos.Clear()
                SesionActual.dtPermisos = fprincipal.cargarOpciones(SesionActual.codigoPerfil, SesionActual.idEmpresa)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.dtPermisos.Select("Codigo_menu='a10301pp03'").Count = 0 Then
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If txtcodigo.Text = 0 Then
            MsgBox("Este perfil no se puede eliminar", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Try

                objPerfil.anularPerfil()
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.limpiarControles(Me)
                General.deshabilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                txtcodigo.Text = Nothing
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                arbolmenu.Enabled = False
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try

        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim param As New List(Of String)
        param.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_PERFIL_USUARIO, param,
                                                  AddressOf cargarPerfiles,
                                                  TitulosForm.BUSQUEDA_PERFIL_USUARIO,
                                                  False, 0, True)

    End Sub

    Public Sub cargarPerfiles(cPerfil As Integer)
        Try
            objPerfil.codigoPerfil = cPerfil
            objPerfil.cargarPerfil()

            txtcodigo.Text = cPerfil
            txtnombre.Text = objPerfil.nombre
            observaciones.Text = objPerfil.observacion
            cargarArbolPUC()
            bteditar.Enabled = True
            btanular.Enabled = True
            arbolmenu.Enabled = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        If txtcodigo.Text <> "" Then
            If SesionActual.dtPermisos.Select("Codigo_menu='a10301pp04'").Count = 0 Then
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            'If txtcodigo.Text <> 0 And txtcodigo.Text <> SesionActual.codigoPerfil Then
            If txtcodigo.Text <> "" Then
                If btguardar.Enabled = False Then
                    Modulos_perfil.Label3.Text = txtnombre.Text
                    Modulos_perfil.Codigo_perfil = txtcodigo.Text
                    General.cargarForm(Modulos_perfil)
                End If
            Else
                MsgBox("Seleccione un perfil de usuario")
            End If
            'Else
            'MsgBox(Mensajes.SINPERMISO & vbCrLf & vbCrLf & Mensajes.PERFIL_IGUAL, 
            'End If
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub Perfiles_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    ''parte exportada de moduolos_perfil

    Dim sw, sw2, sw3 As Boolean
    Dim fprincipal As New PrincipalDAL
    Private dsDatos As DataSet
    Private objModulo_perfil_D As New ModuloPerfilBLL
    Public Sub cargarArbolPUC()
        Dim nodo As TreeNode
        Dim drCuentaPadre As DataRow()

        arbolmenu.Enabled = True
        arbolmenu.Nodes.Clear()
        arbolmenu.ExpandAll()

        Try
            dsDatos = New DataSet
            CreaOpciones(dsDatos)
            objModulo_perfil_D.cargarMenu(SesionActual.codigoEP, dsDatos)
            drCuentaPadre = dsDatos.Tables("Padre").Select()

            'Se recorren las cuentas Padre
            For Each drFila As DataRow In drCuentaPadre
                nodo = New TreeNode
                nodo.Name = drFila("Codigo_Menu").ToString()
                nodo.Text = drFila("Descripcion_Menu").ToString()
                If dsDatos.Tables("Perfil_Menu").Select("[Codigo_Menu]='" + nodo.Name.ToString + "'").Count = 1 Then
                    nodo.Checked = True
                Else
                    nodo.Checked = False
                End If
                arbolmenu.Nodes.Add(nodo)

                'Se recorren las cuentas hijas
                crearSubcuentas(nodo)
            Next

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        dsDatos.Dispose()

    End Sub
    Private Sub crearSubcuentas(ByRef nodoPade As TreeNode)
        Dim expr As String = "Padre_Menu ='" & nodoPade.Name & "'"
        Dim subnodo As TreeNode

        Try
            Dim aDrFilas As DataRow()
            aDrFilas = dsDatos.Tables("Hijas").Select(expr, "Codigo_Menu")

            For Each drFila As DataRow In aDrFilas
                subnodo = New TreeNode
                subnodo.Name = drFila("Codigo_Menu").ToString()
                subnodo.Text = drFila("Descripcion_Menu").ToString()
                If dsDatos.Tables("Perfil_Menu").Select("[Codigo_Menu]='" + subnodo.Name.ToString + "'").Count = 1 Then
                    subnodo.Checked = True
                Else
                    subnodo.Checked = False
                End If
                nodoPade.Nodes.Add(subnodo)
                crearSubcuentas(subnodo)
            Next
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub CreaOpciones(ByRef dsDatos As DataSet)
        Dim cadena As String
        Try
            cadena = "EXEC [PROC_PERFIL_MODULO_CARGAR] " & objPerfil.codigoPerfil & "," & SesionActual.codigoEP & "," & SesionActual.idEmpresa & ""

            Using consulta = New SqlCommand(cadena, FormPrincipal.cnxion)
                Using daAdaptador = New SqlDataAdapter(consulta)
                    daAdaptador.Fill(dsDatos, "Perfil_Menu")
                End Using
            End Using

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub arbolmenu_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbolmenu.AfterCheck
        If e.Node.Checked = True Then
            If dsDatos.Tables("Perfil_Menu").Select("[Codigo_Menu]='" + e.Node.Name.ToString + "'").Count = 0 Then
                Dim dr As DataRow = dsDatos.Tables("Perfil_Menu").NewRow
                dr("Codigo_Menu") = e.Node.Name
                dr("Codigo_Perfil") = objPerfil.codigoPerfil
                dsDatos.Tables("Perfil_Menu").Rows.Add(dr)
            End If

        Else
            If dsDatos.Tables("Perfil_Menu").Select("[Codigo_Menu]='" + e.Node.Name.ToString + "'").Count > 0 Then
                Dim dr As DataRow() = dsDatos.Tables("Perfil_Menu").Select("[Codigo_Menu] like '" + e.Node.Name.ToString + "'")
                For Each adr In dr
                    dsDatos.Tables("Perfil_Menu").Rows.Remove(adr)
                Next
            End If
        End If

        'nodo principal por cada arbol
        If e.Node.Nodes.Count > 0 Then
            If Not IsNothing(e.Node.Parent) AndAlso e.Node.Parent.Checked = False AndAlso e.Node.Checked = True Then
                sw = True
                e.Node.Parent.Checked = True
                sw = False
                For i As Int32 = 0 To e.Node.Nodes.Count - 1
                    If e.Node.Checked = True And sw3 = False Then
                        sw2 = True
                        e.Node.Nodes.Item(i).Checked = True
                        sw2 = False
                    ElseIf e.Node.Checked = False And sw3 = False Then
                        sw2 = True
                        e.Node.Nodes.Item(i).Checked = False
                        sw2 = False
                    End If
                Next
            ElseIf Not IsNothing(e.Node.Parent) AndAlso e.Node.Parent.Checked = True AndAlso e.Node.Checked = False Then
                Dim con As Integer = 0
                For i As Int32 = 0 To e.Node.Parent.Nodes.Count - 1
                    If e.Node.Parent.Nodes.Item(i).Checked = True Then
                        con = con + 1
                    End If
                Next
                If con = 0 Then
                    sw = True
                    e.Node.Parent.Checked = False
                    sw = False
                End If
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
            Else
                For i As Int32 = 0 To e.Node.Nodes.Count - 1
                    If e.Node.Checked = True And sw = False And sw3 = False Then
                        sw2 = True
                        e.Node.Nodes.Item(i).Checked = True
                        sw2 = False
                    ElseIf e.Node.Checked = False And sw = False And sw3 = False Then
                        sw2 = True
                        e.Node.Nodes.Item(i).Checked = False
                        sw2 = False
                    End If
                Next

            End If


        ElseIf e.Node.Nodes.Count = 0 Then
            If IsNothing(e.Node.Parent) Then Exit Sub
            If e.Node.Parent.Checked = False And e.Node.Checked = True Then
                sw3 = True
                e.Node.Parent.Checked = True
                sw3 = False
            ElseIf e.Node.Parent.Checked = True And e.Node.Checked = False Then
                Dim con As Integer = 0
                For i As Int32 = 0 To e.Node.Parent.Nodes.Count - 1
                    If e.Node.Parent.Nodes.Item(i).Checked = True Then
                        con = con + 1
                    End If
                Next
                If con = 0 Then
                    sw3 = True
                    e.Node.Parent.Checked = False
                    sw3 = False
                End If
            End If
        End If

    End Sub
End Class