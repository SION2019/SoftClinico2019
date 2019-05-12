Public Class FormPlataformaDocumental
    Dim objPlataformaDoc As PlataformaDoc
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormPlataformaDocumental_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPlataformaDoc = New PlataformaDoc
        Dim ds = New DataSet("ds")

        Dim nombre As String = String.Format("{0}TEMPName.doc", Application.StartupPath)
        General.llenarDataSet(Consultas.PLATAFORMA_DOC_CARGAR, ds)
        objPlataformaDoc.codCont = If(ds.Tables(1).Rows(0).Item(0) Is DBNull.Value, 1, ds.Tables(1).Rows(0).Item(0))
        objPlataformaDoc.codMenu = objPlataformaDoc.codCont
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        objPlataformaDoc.BdIndex = 0
        iniciar_permisos()
    End Sub
    Public Sub CargarPerfiles()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        If objPlataformaDoc.codPerfil <> 0 Then
            params.Add(objPlataformaDoc.codPerfil)
        End If
        General.llenarTabla(Consultas.PLATAFORMADOC_PERFIL_USUARIO_CARGAR, params, objPlataformaDoc.DtPerfil)
        If objPlataformaDoc.DtPerfil.Rows.Count > 0 Then
            For j = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.Items.RemoveAt(0)
            Next
            If objPlataformaDoc.DtPerfil.Rows.Count = 1 Then
                For i = 0 To objPlataformaDoc.DtPerfil.Rows.Count - 1
                    CheckedListBox1.Items.Add(objPlataformaDoc.DtPerfil.Rows(i).Item("Codigo_perfil") & " | " & objPlataformaDoc.DtPerfil.Rows(i).Item("Nombre_perfil"))
                    CheckedListBox1.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To objPlataformaDoc.DtPerfil.Rows.Count - 1
                    CheckedListBox1.Items.Add(objPlataformaDoc.DtPerfil.Rows(i).Item("Codigo_perfil") & " | " & objPlataformaDoc.DtPerfil.Rows(i).Item("Nombre_perfil"))
                Next
            End If
            CheckBox1.Enabled = True
            CheckedListBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            If CheckedListBox1.Items.Count >= 1 Then
                For i = 0 To CheckedListBox1.Items.Count - 1
                    CheckedListBox1.SetItemChecked(i, True)
                Next
            End If

        Else
            If CheckedListBox1.Items.Count >= 1 Then
                For i = 0 To CheckedListBox1.Items.Count - 1
                    CheckedListBox1.SetItemChecked(i, False)
                Next
            End If
        End If
    End Sub

    Private Sub FormPlataformaDocumental_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub tvDocumentos_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvDocumentos.NodeMouseDoubleClick
        If tvDocumentos.SelectedNode.Text = "---seleccione----" Then
            If (e.Node.Parent IsNot Nothing) Then
                ConfigurarPDoc(e.Node.Parent.Index.ToString())
            Else
                ConfigurarPDoc(e.Node.Index.ToString())
            End If
        End If
    End Sub
    Public Sub ConfigurarPDoc(indice As Integer)
        Dim FormConfigurarPDoc = New FormConfigurarPDoc
        If objPlataformaDoc.NodoHijo = 1 Then
            FormConfigurarPDoc.ComboBox1.Enabled = False
            FormConfigurarPDoc.CheckBox1.Enabled = False
        Else
            FormConfigurarPDoc.ComboBox1.Enabled = True
            FormConfigurarPDoc.CheckBox1.Enabled = True
        End If

        Select Case FormConfigurarPDoc.ShowDialog()
            Case Windows.Forms.DialogResult.OK
                objPlataformaDoc.codCont = objPlataformaDoc.codCont + 1
                If FormConfigurarPDoc.CheckBox1.Checked = False Then
                    If FormConfigurarPDoc.TxtUbicacion.Text = "Cargar PDF" Then
                        tvDocumentos.SelectedNode.Text = FormConfigurarPDoc.ComboBox1.Text
                        tvDocumentos.SelectedNode.Name = objPlataformaDoc.codCont
                    Else
                        tvDocumentos.SelectedNode.Text = FormConfigurarPDoc.TxtNomArchivo.Text
                        tvDocumentos.SelectedNode.Name = objPlataformaDoc.codCont
                        tvDocumentos.SelectedNode.ImageIndex = 2
                        tvDocumentos.SelectedNode.SelectedImageIndex = 2
                    End If
                    tvDocumentos.SelectedNode.Tag = FormConfigurarPDoc.TxtUbicacion.Text
                    If objPlataformaDoc.BdIndex = 0 Then
                        tvDocumentos.Nodes.Add("---seleccione----").Tag = ""
                    End If
                    objPlataformaDoc.BdIndex = 0
                Else
                    If FormConfigurarPDoc.TxtUbicacion.Text = "Cargar PDF" Then
                        tvDocumentos.SelectedNode.Text = FormConfigurarPDoc.ComboBox1.Text
                        tvDocumentos.SelectedNode.Name = objPlataformaDoc.codCont
                    Else
                        tvDocumentos.SelectedNode.Text = FormConfigurarPDoc.TxtNomArchivo.Text
                        tvDocumentos.SelectedNode.Name = objPlataformaDoc.codCont
                        tvDocumentos.SelectedNode.ImageIndex = 2
                        tvDocumentos.SelectedNode.SelectedImageIndex = 2
                    End If
                    tvDocumentos.SelectedNode.Tag = FormConfigurarPDoc.TxtUbicacion.Text
                    tvDocumentos.Nodes(indice).Nodes.Add("---seleccione----").Tag = ""
                    objPlataformaDoc.BdIndex = 0
                End If
        End Select

    End Sub

    Private Sub tvDocumentos_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvDocumentos.NodeMouseClick
        If (e.Node.Index.ToString() IsNot Nothing) Then
            objPlataformaDoc.NodoPadre = e.Node.Index.ToString()
            objPlataformaDoc.NodoHijo = e.Node.Level
        End If
        pdfArchivos.LoadFile(e.Node.Tag.ToString)
    End Sub


    Private Sub tvDocumentos_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles tvDocumentos.AfterExpand
        tvDocumentos.SelectedNode.ImageIndex = 1
        tvDocumentos.SelectedNode.SelectedImageIndex = 1
    End Sub

    Private Sub tvDocumentos_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles tvDocumentos.AfterCollapse
        tvDocumentos.SelectedNode.ImageIndex = 0
        tvDocumentos.SelectedNode.SelectedImageIndex = 0
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub tvDocumentos_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles tvDocumentos.BeforeExpand
        tvDocumentos.SelectedNode = tvDocumentos.Nodes(e.Node.Index)
    End Sub

    Private Sub tvDocumentos_BeforeCollapse(sender As Object, e As TreeViewCancelEventArgs) Handles tvDocumentos.BeforeCollapse
        tvDocumentos.SelectedNode = tvDocumentos.Nodes(e.Node.Index)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If ValidarArbol() Then Exit Sub
        LLenarDtdetalle()
        LLenarDtperfil()
        LLenarDtMenu()
        'If ValidarDatos() = True Then Exit Sub
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                PlataformaDocBLL.guardarPlataformaDoc(objPlataformaDoc)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Function ValidarArbol()
        Dim n As TreeNode
        Dim nn As TreeNode
        For Each n In tvDocumentos.Nodes
            For Each nn In n.Nodes
                If nn.Text = "---seleccione----" Then
                    MsgBox("La Categoria : " & n.Text & " no tiene PDFs asociado")
                    Return True
                End If
            Next
        Next
        Return False
    End Function
    Public Sub LLenarDtMenu()
        objPlataformaDoc.DtMenu.Clear()
        objPlataformaDoc.DtMenuManual.Clear()
        objPlataformaDoc.DtPerfilMenu.Clear()
        Dim cod As String
        Dim cod_doc As String
        objPlataformaDoc.codMenu = objPlataformaDoc.codMenu + 1
        For Each row As DataRow In objPlataformaDoc.DtPlatformaDoc.Rows
            If row("Archivo") IsNot DBNull.Value Then
                cod_doc = row("Codigo_Doc").ToString.Split("-")(1)
                cod = If(cod_doc <= 9, "ax010" & cod_doc, "ax01" & cod_doc)
                'llenamos el datatable que inserta en el menu A_MENU el nombre del pdf a ver por perfil
                objPlataformaDoc.DtMenu.Rows.Add()
                objPlataformaDoc.DtMenu.Rows(objPlataformaDoc.DtMenu.Rows.Count - 1).Item("Codigo_Menu") = cod
                objPlataformaDoc.DtMenu.Rows(objPlataformaDoc.DtMenu.Rows.Count - 1).Item("Descripcion_Menu") = row("Nombre").ToString
                objPlataformaDoc.DtMenu.Rows(objPlataformaDoc.DtMenu.Rows.Count - 1).Item("Formulario") = "FormVisorPlataformaDoc"
                objPlataformaDoc.DtMenu.Rows(objPlataformaDoc.DtMenu.Rows.Count - 1).Item("Padre_Menu") = "ax01"
                objPlataformaDoc.DtMenu.Rows(objPlataformaDoc.DtMenu.Rows.Count - 1).Item("Anulado") = False
                'llenamos el datatable que llena la tabla A_MENU_MANUAL
                objPlataformaDoc.DtMenuManual.Rows.Add()
                objPlataformaDoc.DtMenuManual.Rows(objPlataformaDoc.DtMenuManual.Rows.Count - 1).Item("Codigo_Menu") = cod
                objPlataformaDoc.DtMenuManual.Rows(objPlataformaDoc.DtMenuManual.Rows.Count - 1).Item("Archivo") = row("Archivo")
                objPlataformaDoc.DtMenuManual.Rows(objPlataformaDoc.DtMenuManual.Rows.Count - 1).Item("Anulado") = False
                For j = 0 To CheckedListBox1.CheckedItems.Count - 1
                    objPlataformaDoc.DtPerfilMenu.Rows.Add()
                    objPlataformaDoc.DtPerfilMenu.Rows(objPlataformaDoc.DtPerfilMenu.Rows.Count - 1).Item("Codigo_Perfil") = Trim(CheckedListBox1.CheckedItems(j).ToString.Split("|")(0))
                    objPlataformaDoc.DtPerfilMenu.Rows(objPlataformaDoc.DtPerfilMenu.Rows.Count - 1).Item("id_empresa") = SesionActual.idEmpresa
                    objPlataformaDoc.DtPerfilMenu.Rows(objPlataformaDoc.DtPerfilMenu.Rows.Count - 1).Item("Codigo_MENU") = cod
                    objPlataformaDoc.DtPerfilMenu.Rows(objPlataformaDoc.DtPerfilMenu.Rows.Count - 1).Item("Anulado") = False
                Next
                objPlataformaDoc.codMenu = objPlataformaDoc.codMenu + 1
            End If

        Next
    End Sub
    Public Sub LLenarDtdetalle()
        objPlataformaDoc.DtPlatformaDoc.Clear()
        Dim codDoc As String = ""
        Dim Npadre As String = ""
        Dim Nhijo As String = ""
        Dim n As TreeNode
        Dim nn As TreeNode
        Dim cont As Integer = 0
        For Each n In tvDocumentos.Nodes
            If String.IsNullOrEmpty(n.Name) = False Then
                'LLENAMOS DATATABLE PARA EL DETALLE
                objPlataformaDoc.DtPlatformaDoc.Rows.Add()
                If objPlataformaDoc.Dtauxel.Rows.Count > 0 And cont <= objPlataformaDoc.Dtauxel.Rows.Count - 1 Then
                    codDoc = objPlataformaDoc.Dtauxel.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Codigo_Doc").ToString
                    Npadre = objPlataformaDoc.Dtauxel.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("NivelPadre").ToString
                    Nhijo = objPlataformaDoc.Dtauxel.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("NivelHijo").ToString
                Else
                    codDoc = If(codDoc = "", (n.Index & "-" & n.Name).ToString, (codDoc.ToString.Split("-")(0) + 1 & "-" & n.Name))
                    Npadre = If(Npadre = "", n.Index, Npadre + 1)
                    Nhijo = ""
                End If
                cont = cont + 1

                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("NivelPadre") = Npadre
                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("NivelHijo") = Nothing
                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Codigo_Doc") = codDoc
                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Nombre") = n.Text
                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Archivo") = If(n.Tag = "Cargar PDF" Or n.Tag = "",
                                                                                                                       Nothing, File.ReadAllBytes(n.Tag))
                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Usuario_Creacion") = SesionActual.idUsuario
                objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Anulado") = False
                For Each nn In n.Nodes
                    objPlataformaDoc.DtPlatformaDoc.Rows.Add()
                    codDoc = If(codDoc = "", (n.Index & "-" & nn.Name).ToString, (Npadre & "-" & nn.Name))
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("NivelPadre") = Npadre
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("NivelHijo") = If(Nhijo <> "", Nhijo, nn.Index)
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Codigo_Doc") = codDoc
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Nombre") = nn.Text
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Archivo") = If(nn.Tag = "Cargar PDF" Or nn.Tag = "",
                                                                                                                       Nothing, File.ReadAllBytes(nn.Tag))
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Usuario_Creacion") = SesionActual.idUsuario
                    objPlataformaDoc.DtPlatformaDoc.Rows(objPlataformaDoc.DtPlatformaDoc.Rows.Count - 1).Item("Anulado") = False
                    cont = cont + 1
                Next
            End If
        Next
    End Sub
    Public Sub LLenarDtperfil()
        objPlataformaDoc.DtPerfilAux.Clear()
        Dim codDoc As String = ""
        Dim cont As Integer = 0
        For j = 0 To CheckedListBox1.CheckedItems.Count - 1
            'If CheckedListBox1.GetItemChecked(j) = True Then
            Dim n As TreeNode
            For Each n In tvDocumentos.Nodes

                If String.IsNullOrEmpty(n.Name) = False Then
                    'LLENAMOS DATATABLE PARA EL PERFIL
                    objPlataformaDoc.DtPerfilAux.Rows.Add()
                    If objPlataformaDoc.Dtauxel.Rows.Count > 0 And cont <= objPlataformaDoc.Dtauxel.Rows.Count - 1 Then
                        codDoc = objPlataformaDoc.Dtauxel.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Codigo_Doc").ToString
                    Else
                        codDoc = If(codDoc = "", (n.Index & "-" & n.Name).ToString, (codDoc.ToString.Split("-")(0) + 1 & "-" & n.Name))
                    End If
                    cont = cont + 1
                    objPlataformaDoc.DtPerfilAux.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Codigo_Perfil") = Trim(CheckedListBox1.CheckedItems(j).ToString.Split("|")(0))
                    objPlataformaDoc.DtPerfilAux.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Codigo_Doc") = codDoc
                    objPlataformaDoc.DtPerfilAux.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Anulado") = False
                    For Each nn In n.Nodes
                        objPlataformaDoc.DtPerfilAux.Rows.Add()
                        codDoc = If(codDoc = "", (n.Index & "-" & nn.Name).ToString, (codDoc.ToString.Split("-")(0) & "-" & nn.Name))
                        objPlataformaDoc.DtPerfilAux.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Codigo_Perfil") = Trim(CheckedListBox1.CheckedItems(j).ToString.Split("|")(0))
                        objPlataformaDoc.DtPerfilAux.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Codigo_Doc") = codDoc
                        objPlataformaDoc.DtPerfilAux.Rows(objPlataformaDoc.DtPerfilAux.Rows.Count - 1).Item("Anulado") = False
                        cont = cont + 1
                    Next
                End If
            Next
            'End If
        Next
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(objPlataformaDoc.sqlBuscarPDPerfil,
                              params,
                              AddressOf cargarPlataformaDoc,
                              TitulosForm.BUSQUEDA_PERFIL_USUARIO,
                              True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cargarPlataformaDoc(pCodigo As Integer)

        Dim params As New List(Of String)
        params.Add(pCodigo)
        Try
            objPlataformaDoc.codPerfil = pCodigo

            If ConstruirArbolPDF(pCodigo) = True Then
                CargarPerfiles()
                objPlataformaDoc.DtEliminar.Clear()
                General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                tvDocumentos.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Function ConstruirArbolPDF(pcod As Integer)
        Dim Dt As New DataTable
        Dim Nivel As Integer
        Dim indicePadre As Integer
        Dim indiceHijo As Integer
        Dim Cons As Integer
        Dim indAux As String
        Dim archivo As Byte()
        Dim ruta As String
        Dim carbol As Integer = 0
        Dim params As New List(Of String)
        tvDocumentos.Nodes.Clear()
        params.Add(pcod)
        General.llenarTabla(objPlataformaDoc.SqlCargarPlataformaDoc, params, Dt)
        objPlataformaDoc.Dtauxel = Dt.Copy
        If Dt.Rows.Count = 0 Then
            MsgBox("No se Encontraron Datos para este Perfil...", MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End If
        With tvDocumentos
            .BeginUpdate()  ' Evitando la Actualizacion del Control
            For Each Row As DataRow In Dt.Rows

                Nivel = If(Row(1) Is DBNull.Value, 0, 1)
                Cons = Row(2).ToString.Split("-")(1)
                If Nivel = 0 Then
                    indicePadre = carbol 'row(0)
                    carbol = carbol + 1
                    tvDocumentos.Nodes.Add(Row(3)).Tag = ""
                    If Row(4) Is DBNull.Value Then
                        tvDocumentos.Nodes(indicePadre).ImageIndex = 0
                        tvDocumentos.Nodes(indicePadre).SelectedImageIndex = 0
                        tvDocumentos.Nodes(indicePadre).Name = Cons
                    Else
                        tvDocumentos.Nodes(indicePadre).Name = Cons
                        tvDocumentos.Nodes(indicePadre).ImageIndex = 2
                        tvDocumentos.Nodes(indicePadre).SelectedImageIndex = 2
                        archivo = Row(4)
                        ruta = System.IO.Path.GetTempPath & Row(3)
                        IO.File.WriteAllBytes(ruta, archivo)
                        tvDocumentos.Nodes(indicePadre).Tag = ruta
                    End If
                Else
                    indAux = Row(0).ToString.Split(".")(0)
                    indiceHijo = Row(1)
                    If Nivel = 1 Then
                        tvDocumentos.Nodes(indicePadre).Nodes.Add(Row(3))
                        tvDocumentos.Nodes(indicePadre).Nodes(indiceHijo).ImageIndex = 2
                        tvDocumentos.Nodes(indicePadre).Nodes(indiceHijo).SelectedImageIndex = 2
                        archivo = Row(4)
                        ruta = System.IO.Path.GetTempPath & Row(3)
                        IO.File.WriteAllBytes(ruta, archivo)
                        tvDocumentos.Nodes(indicePadre).Nodes(indiceHijo).Name = Cons
                        tvDocumentos.Nodes(indicePadre).Nodes(indiceHijo).Tag = ruta
                    End If
                End If
            Next
            .EndUpdate()        ' Actulizando el Control
            .AllowDrop = True   ' Realizar Drag and Drop
            .ExpandAll()
        End With
        Return True
    End Function

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            'Actualiza en base de datos los valores de tarifa de tripulantes Ambulancia
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            If tvDocumentos.Nodes(tvDocumentos.Nodes.Count - 1).Text <> "---seleccione----" Then
                tvDocumentos.Nodes.Add("---seleccione----").Tag = ""
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub EliminarItemToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EliminarItemToolStripMenuItem.Click
        Dim crow As Integer
        Dim LaPosicion As Integer
        Dim rowdelete = objPlataformaDoc.Dtauxel.Select("Nombre='" & tvDocumentos.SelectedNode.Text & "'")
        LaPosicion = objPlataformaDoc.Dtauxel.Rows.IndexOf(rowdelete(0))
        Dim cod_doc As String = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(2).ToString.Split("-")(1)
        Dim cod As String = If(cod_doc <= 9, "ax010" & cod_doc, "ax01" & cod_doc)
        If Me.bteditar.Enabled = False Then
            crow = objPlataformaDoc.DtEliminar.Rows.Count
            objPlataformaDoc.DtEliminar.Rows.Add()
            objPlataformaDoc.DtEliminar.Rows(crow).Item("NivelPadre") = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(0)
            objPlataformaDoc.DtEliminar.Rows(crow).Item("NivelHijo") = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(1)
            objPlataformaDoc.DtEliminar.Rows(crow).Item("Codigo_Doc") = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(2)
            objPlataformaDoc.DtEliminar.Rows(crow).Item("Nombre") = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(3)
            objPlataformaDoc.DtEliminar.Rows(crow).Item("Archivo") = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(4)
            objPlataformaDoc.DtEliminar.Rows(crow).Item("Usuario_Creacion") = objPlataformaDoc.Dtauxel.Rows(LaPosicion).Item(5)
            objPlataformaDoc.DtEliminar.Rows(crow).Item("Codigo_Perfil") = objPlataformaDoc.codPerfil
            objPlataformaDoc.DtEliminar.Rows(crow).Item("Codigo_menu") = cod
            objPlataformaDoc.Dtauxel.Rows.RemoveAt(LaPosicion)
            tvDocumentos.SelectedNode.Remove()

        End If
    End Sub

    Private Sub AgregarItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarItemToolStripMenuItem.Click
        If Me.bteditar.Enabled = False Then
            Dim _Node As New TreeNode
            _Node.Text = "---seleccione----"
            _Node.ContextMenuStrip = ContextMenuStrip1
            tvDocumentos.Nodes(objPlataformaDoc.NodoPadre).Nodes.Add("---seleccione----").Tag = ""
            objPlataformaDoc.BdIndex = 1
        End If
    End Sub

    Private Sub tvDocumentos_MouseDown(sender As Object, e As MouseEventArgs) Handles tvDocumentos.MouseDown
        If e.Button = MouseButtons.Right And Me.bteditar.Enabled = False Then
            ContextMenuStrip1.Show(tvDocumentos, e.Location)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            Dim ds = New DataSet("ds")
            General.llenarDataSet(Consultas.PLATAFORMA_DOC_CARGAR, ds)
            objPlataformaDoc.codCont = If(ds.Tables(1).Rows(0).Item(0) Is DBNull.Value, 1, ds.Tables(1).Rows(0).Item(0))
            objPlataformaDoc.codMenu = objPlataformaDoc.codCont
            objPlataformaDoc.codPerfil = Nothing
            CargarPerfiles()
            tvDocumentos.Nodes.Add("---seleccione----").Tag = ""
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub iniciar_permisos()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
End Class