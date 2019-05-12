Imports System.Data.SqlClient
Public Class Modulos_perfil
    Public Codigo_perfil As String
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
            cadena = "EXEC [PROC_PERFIL_MODULO_CARGAR] " & Codigo_perfil & "," & SesionActual.codigoEP & "," & SesionActual.idEmpresa & ""

            Using consulta = New SqlCommand(cadena, FormPrincipal.cnxion)
                Using daAdaptador = New SqlDataAdapter(consulta)
                    daAdaptador.Fill(dsDatos, "Perfil_Menu")
                End Using
            End Using

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub form_permisos_usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarArbolPUC()
        Beditar_Click(sender, e)
    End Sub

    Private Sub btguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btguardar.Click
        Try

            Using consulta = New SqlCommand()
                consulta.Connection = FormPrincipal.cnxion
                consulta.CommandType = CommandType.StoredProcedure
                consulta.CommandText = "PROC_PERFIL_MODULO_ELIMINAR"
                consulta.Parameters.Add(New SqlParameter("@Codigo_perfil", SqlDbType.Int)).Value = Codigo_perfil
                consulta.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                consulta.ExecuteNonQuery()
                consulta.CommandText = "[PROC_PERFIL_MODULO_ASIGNAR]"
                consulta.Parameters.Add(New SqlParameter("@tbl", SqlDbType.Structured)).Value = dsDatos.Tables("Perfil_Menu")
                consulta.ExecuteNonQuery()

                MsgBox("Módulos guardados éxitosamente", MsgBoxStyle.Information)
                Beditar.Enabled = True
                btguardar.Enabled = False
                btcancelar.Enabled = False
                arbolmenu.Enabled = False
            End Using

            If btguardar.Enabled = False And Codigo_perfil = SesionActual.codigoPerfil Then
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

    Private Sub arbolmenu_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbolmenu.AfterCheck
        If e.Node.Checked = True Then
            If dsDatos.Tables("Perfil_Menu").Select("[Codigo_Menu]='" + e.Node.Name.ToString + "'").Count = 0 Then
                Dim dr As DataRow = dsDatos.Tables("Perfil_Menu").NewRow
                dr("Codigo_Menu") = e.Node.Name
                dr("Codigo_Perfil") = Codigo_perfil
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

    Private Sub Beditar_Click(sender As Object, e As EventArgs) Handles Beditar.Click
        Beditar.Enabled = False
        btguardar.Enabled = True
        btcancelar.Enabled = True
        arbolmenu.Enabled = True
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        Beditar.Enabled = True
        btguardar.Enabled = False
        btcancelar.Enabled = False
        arbolmenu.Enabled = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

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




End Class