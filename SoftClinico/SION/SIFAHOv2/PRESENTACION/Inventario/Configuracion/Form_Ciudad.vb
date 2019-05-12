Imports System.Data.SqlClient
Public Class Form_Ciudad
    Dim clasemuni As New MunicipioBLL
    Public bmuni As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub Form_Ciudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        If txtcodigo.Text = "" Then
            General.cargarCombo(Consultas.PAIS_BUSCAR, "Nombre", "Código", Combopais)
        End If
        If txtcodigo.Text = "" Then
            General.cargarCombo(Consultas.BUSQUEDA_DEPARTAMENTO, "Departamento", "Código", Combodepartamento)
        End If
        Cargardepartamento()
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
    End Sub



    Public Sub Cargardepartamento()
        Dim dt As New DataTable
        Dim dw As DataRow = dt.NewRow()
        Dim cadena As String
        cadena = ""
        dt.Clear()
        cadena = "EXECUTE PROC_DEPAR_MUNI_BUSCAR @NOMBRE='" & cadena & "'"
        dt.Columns.Add("Descripcion")
        dt.Columns.Add("Codigo_departamento")
        dw.Item(1) = ""
        dw.Item(0) = "-----------Seleccione----------"
        dt.Rows.Add(dw)
        Try

            Using da = New SqlDataAdapter(cadena, FormPrincipal.cnxion)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            general.manejoErrores(ex)
            Exit Sub
        End Try
        Combodepartamento.DataSource = dt
        Combodepartamento.DisplayMember = "Descripcion"
        Combodepartamento.ValueMember = "Codigo_departamento"
        Combodepartamento.SelectedItem = 0
    End Sub

    Private Sub Form_Ciudad_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda una pais y actualiza: 
        'Autor: Lycans
        'fecha_creacion: 04/06/2016

        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre del Municipio !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        ElseIf txtcodigo.Text = "" Then
            MsgBox("¡ Por favor Falta el codigo Municipio !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        ElseIf Combopais.SelectedValue = -1 Then
            MsgBox("¡ Por favor seleccione un pais !", MsgBoxStyle.Exclamation)
            Combopais.Focus()
        ElseIf Combodepartamento.SelectedValue = -1 Then
            MsgBox("¡ Por favor seleccione un departamento !", MsgBoxStyle.Exclamation)
            Combopais.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                If clasemuni.guardar_muni(txtcodigo.Text, txtnombre.Text, Combopais.SelectedValue, Combodepartamento.SelectedValue) = True Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.habilitarBotones(Me.ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False '--Guardar--
                    btcancelar.Enabled = False '--Cancelar--
                End If
            End If
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
            txtcodigo.ReadOnly = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add(Nothing)

            General.buscarItem(Consultas.MUNICIPIOS_BUSCAR,
                                   params,
                                   AddressOf cargarCiudad,
                                   TitulosForm.BUSQUEDA_MUNICIPIOS,
                                   False)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue?.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub

    Public Sub cargarCiudad(pFila As DataRow)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pFila.Item(4))
        params.Add(pFila.Item(2))
        params.Add(pFila.Item(0))

        drFila = General.cargarItem(Consultas.MUNICIPIOS_CARGAR, params)

        txtcodigo.Text = pFila.Item(0).ToString
        txtnombre.Text = drFila.Item(0).ToString
        Combodepartamento.SelectedValue = drFila.Item(1).ToString
        Combopais.SelectedValue = drFila.Item(2).ToString

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btcancelar.Enabled = False
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            txtcodigo.ReadOnly = True
            txtnombre.ReadOnly = False
            General.deshabilitarBotones(ToolStrip1)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guard
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        txtcodigo.ReadOnly = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: Lycans
        'fecha_creacion: 04/06/2016
        If SesionActual.tienePermiso(PBuscar ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                If clasemuni.anular_muni(txtcodigo.Text.ToString, Combopais.SelectedValue, Combodepartamento.SelectedValue) = True Then
                    General.limpiarControles(Me)
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    btanular.Enabled = False
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    btguardar.Enabled = False
                End If
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class