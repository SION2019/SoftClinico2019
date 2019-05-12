
Imports System.Data
Imports System.Data.SqlClient
Public Class form_lista_precio_proveedor
    Public Property objListaPrecio As New ListaPrecioProveedorCliente
    Dim perG As New Buscar_Permisos_generales
    Dim objListaPrecioBLL As New ListaPrecioProveedorBLL
    Dim permisoGeneral, pNuevo, pEditar, pAnular, pBuscar As String
    Dim enlace As New BindingSource
#Region "Metodos"
    Public Sub setTipoLista(ByVal pTipolista As Integer, ByVal pIdTercero As Integer, ByVal pNombreTercero As String)
        objListaPrecio.tipoLista = pTipolista
        objListaPrecio.idTercero = pIdTercero
        objListaPrecio.nombreTercero = pNombreTercero
        llenarInformacion()
    End Sub
    Public Sub empalmarObjetoToDiseno()
        txtCodigo.Text = objListaPrecio.codigoLista
        txtNmbre.Text = objListaPrecio.nombreLista
        txtCodigoT.Text = objListaPrecio.idTercero
        txtNombre.Text = objListaPrecio.nombreTercero
    End Sub
    Public Sub empalmarDisenoToObjeto()
        objListaPrecio.codigoLista = txtCodigo.Text
        objListaPrecio.nombreLista = txtNmbre.Text
        objListaPrecio.idTercero = txtCodigoT.Text
        objListaPrecio.nombreTercero = txtNombre.Text
    End Sub
    Sub configurarDgv()

        With dgvproductos
            .DataSource = enlace
            .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Costo").DefaultCellStyle.Format = "C2"
            .Columns("Precio").DefaultCellStyle.Format = "C2"
            If objListaPrecio.tipoLista = Constantes.PROVEEDOR Then
                dgvproductos.Columns("Precio").Visible = False
            Else
                dgvproductos.Columns("Costo").Visible = False
            End If
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub guardarLista()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try

                empalmarDisenoToObjeto()
                objListaPrecio.tblProductos.AcceptChanges()
                objListaPrecio.quitarColumnaBandera()
                objListaPrecioBLL.guardarLista(objListaPrecio)
                llenarInformacion()
                llenardgvs()
                General.deshabilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                textbusqueda1.Enabled = True
                textbusqueda1.ReadOnly = False
                textbusqueda1.ResetText()
                bteditar.Enabled = True
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Sub actualizarLista()
        'If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Try
        '        If objListaPrecioBLL.actualizarLita(codigoLista, txtNmbre.Text, txtCodigoT.Text, TipoLista, tblProductos) Then
        '            General.deshabilitarBotones(ToolStrip1)
        '            llenardgvs()
        '            MsgBox(Mensajes.GUARDADO)
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex)
        '    End Try
        'End If
    End Sub
    Sub inicializarForm()
        General.limpiarControles(Me)
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        empalmarObjetoToDiseno()
        enlace.DataSource = objListaPrecio.tblProductos
        configurarDgv()
        llenardgvs()
        General.posLoadForm(Me, ToolStrip1, Nothing, Nothing)

        If txtCodigo.Text = "" Then
            btnuevo.Enabled = True
        Else
            bteditar.Enabled = True
        End If
        textbusqueda1.Enabled = True
        textbusqueda1.ReadOnly = False
    End Sub
    Sub llenarInformacion()
        verificarExistenciaLista()
    End Sub
    Sub habiliarBusqueda()
        textbusqueda1.Enabled = True
        textbusqueda1.ReadOnly = False
    End Sub
    Sub verificarExistenciaLista()
        Dim params As New List(Of String)
        If objListaPrecioBLL.validarExistencia(objListaPrecio) Then
            empalmarObjetoToDiseno()
            habiliarBusqueda()
        End If
    End Sub
    Public Sub llenardgvs()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        If txtCodigo.Text = "" Then
            General.llenarTabla(Consultas.LISTA_PRECIO_PRODUCTOS_CP_VACIO, params, objListaPrecio.tblProductos)
        Else
            params.Add(SesionActual.idEmpresa)
            params.Add(objListaPrecio.codigoLista)
            General.llenarTabla(Consultas.LISTA_PRECIO_PRODUCTOS_CP, params, objListaPrecio.tblProductos)
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                textbusqueda1.ResetText()
                llenardgvs()
                objListaPrecio.agregarColumnaBandera()
                For indiceColumna = 0 To objListaPrecio.tblProductos.Rows.Count - 1
                    objListaPrecio.tblProductos.Rows(indiceColumna).Item("tipo") = 1
                Next
                enlace.Filter = ""
                If dgvproductos.Columns.Contains("tipo") Then
                    dgvproductos.Columns("tipo").Visible = False
                End If

            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            llenarInformacion()
            llenardgvs()
            enlace.Filter = ""
            General.deshabilitarControles(Me)
            textbusqueda1.Enabled = True
            textbusqueda1.ReadOnly = False
            textbusqueda1.ResetText()
            bteditar.Enabled = True
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() Then
            guardarLista()
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNuevo) Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            habiliarBusqueda()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Funciones"
    Function validarFormulario() As Boolean
        If String.IsNullOrEmpty(txtNmbre.Text) Then
            MsgBox("Debe Colocar el nombre de la lista de precio", MsgBoxStyle.Exclamation)
            txtNmbre.Focus()
            Return False
        ElseIf objListaPrecio.tblProductos.Select("Costo > 0 or precio > 0", "").Count = 0 Then
            MsgBox("Debe colocar el por lo menos un valor en costo o precio", MsgBoxStyle.Exclamation)
            dgvproductos.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        If btguardar.Enabled Then
            Dim filaActual As Integer = dgvproductos.CurrentRow.Index
            If Funciones.filaValida(filaActual) Then
                objListaPrecio.tblProductos.Rows.RemoveAt(filaActual)
            End If
        End If
    End Sub

    Private Sub dgvproductos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvproductos.RowPostPaint
        If dgvproductos.Columns.Contains("tipo") Then
            If dgvproductos.Rows(e.RowIndex).Cells("tipo").Value = 1 Then
                dgvproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            End If

        End If

    End Sub





#End Region
#Region "Eventos Dgv"
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvproductos.EndEdit()
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        If e.RowIndex >= 0 Then
            dgvproductos.ReadOnly = False
            Select Case objListaPrecio.tipoLista
                Case Constantes.PROVEEDOR
                    If btguardar.Enabled = True And (dgvproductos.Columns("Precio").Index = e.ColumnIndex Or dgvproductos.Columns("Costo").Index = e.ColumnIndex) Then
                        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                    Else
                        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                    End If
                Case Constantes.CLIENTE
                    If btguardar.Enabled = True And dgvproductos.Columns("Precio").Index = e.ColumnIndex Then
                        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                    Else
                        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                    End If
            End Select
        End If
    End Sub
#End Region
    Private Sub textbusqueda1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textbusqueda1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtCodigo.Text <> "" AndAlso btguardar.Enabled Then

                textbusqueda1.Text = Funciones.validarComillaSimple(textbusqueda1.Text)

                Dim tablaTemp As New DataTable
                Dim filasSeleccionadas As DataRow()
                tablaTemp = objListaPrecio.tblProductos.Clone

                filasSeleccionadas = objListaPrecio.tblProductos.Select("(Costo >= 0 or Precio >= 0) and tipo = 1")

                For Each itemFila As DataRow In filasSeleccionadas
                    tablaTemp.ImportRow(itemFila)
                Next

                Dim listadoItems As String = ""

                For indiceFila = 0 To tablaTemp.Rows.Count - 1
                    If indiceFila > 0 Then
                        listadoItems += "$"
                    End If
                    listadoItems += tablaTemp.Rows(indiceFila).Item("codigo")
                Next


                Dim params As New List(Of String)
                params.Add(listadoItems)
                params.Add(textbusqueda1.Text)
                General.llenarTabla(Consultas.LISTA_PRECIO_PRODUCTOS_CP_FILTRAR_PRODUCTOS, params, objListaPrecio.tblProductos)
                objListaPrecio.tblProductos.Merge(tablaTemp)
                dgvproductos.DataSource = objListaPrecio.tblProductos
            Else



                If textbusqueda1.Text = "" Then
                        enlace.Filter = ""
                        Exit Sub
                    End If

                    enlace.Filter = String.Format("[Descripcion]  Like '%" & Replace(textbusqueda1.Text, "%", "") & "%' or 
                                                   [Codigo]  LIKE '%" & Replace(textbusqueda1.Text, "%", "") & "%' or 
                                                   [Marca]  LIKE '%" & Replace(textbusqueda1.Text, "%", "") & "%'")

            End If
        End If
    End Sub
    Private Sub form_lista_precio_proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub

End Class
