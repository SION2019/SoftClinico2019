Imports System.Data.SqlClient
Public Class Form_CPIS
    Dim dtCpis As New DataTable
    Dim permiso_general, Peditar, Panular As String
    Dim perG As New Buscar_Permisos_generales
    Dim respuesta As Boolean
    Dim reporte As New ftp_reportes
    Dim modulo As String
    Private Sub Form_CPIS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        establecerTabla()
        establecerdgv()
        dgvcpis.DataSource = dtCpis

        deshablitar_controles()
        dgvcpis.Columns(4).ReadOnly = True
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Peditar = permiso_general & "pp" & "01"
        Panular = permiso_general & "pp" & "02"
        Datefecha.Enabled = False

        dgvcpis.Columns(0).Width = 200
        dgvcpis.Columns(1).Width = 170
        dgvcpis.Columns(2).Width = 170
        dgvcpis.Columns(3).Width = 170
        dgvcpis.Columns(4).Width = 50

        dgvcpis.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcpis.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcpis.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcpis.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcpis.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvcpis.Columns(1).DefaultCellStyle.BackColor = Color.Aqua
        dgvcpis.Columns(2).DefaultCellStyle.BackColor = Color.Aqua
        dgvcpis.Columns(3).DefaultCellStyle.BackColor = Color.Aqua
        dgvcpis.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 0 To dgvcpis.Rows.Count - 1
            dgvcpis.Rows(i).Height = 35
        Next
        For i = 0 To dgvcpis.Columns.Count - 2
            dgvcpis.Columns(i).ReadOnly = True
        Next

    End Sub
    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub

    Private Sub Form_CPIS_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Sub establecerTabla()

        Try
            Dim col1, col2, col3, col4, col5 As New DataColumn
            col1.ColumnName = "VARIABLES"
            col1.DataType = Type.GetType("System.String")
            dtCpis.Columns.Add(col1)

            col2.ColumnName = "0PUNTOS"
            col2.DataType = Type.GetType("System.String")
            dtCpis.Columns.Add(col2)

            col3.ColumnName = "1PUNTOS"
            col3.DataType = Type.GetType("System.String")
            dtCpis.Columns.Add(col3)

            col4.ColumnName = "2PUNTOS"
            col4.DataType = Type.GetType("System.String")
            dtCpis.Columns.Add(col4)

            col5.ColumnName = "TOTAL"
            col5.DataType = Type.GetType("System.String")
            dtCpis.Columns.Add(col5)
            col1 = Nothing : col2 = Nothing : col3 = Nothing : col4 = Nothing : col5 = Nothing
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub establecerdgv()
        dtCpis.Rows.Add()
        dtCpis.Rows(0).Item(0) = "TEMPERATURA"
        dtCpis.Rows(0).Item(1) = "36.1° - 38.4°"
        dtCpis.Rows(0).Item(2) = "38.5° - 38.9°"
        dtCpis.Rows(0).Item(3) = "< 36° > 39°"
        dtCpis.Rows.Add()

        dtCpis.Rows(1).Item(0) = "LEUCOCITOS"
        dtCpis.Rows(1).Item(1) = "4.000 - 11.000"
        dtCpis.Rows(1).Item(2) = "< 4.000 > 11.000"
        dtCpis.Rows(1).Item(3) = "Formas en cayado > 50%"
        dtCpis.Rows.Add()

        dtCpis.Rows(2).Item(0) = "SECRECIONES TRAQUEALES"
        dtCpis.Rows(2).Item(1) = "AUSENCIA"
        dtCpis.Rows(2).Item(2) = "No purulentas"
        dtCpis.Rows(2).Item(3) = "Purulentas"
        dtCpis.Rows.Add()

        dtCpis.Rows(3).Item(0) = "OXIGENACIÓN (Po2/Fio2)"
        dtCpis.Rows(3).Item(1) = "> 240 con SDRA"
        dtCpis.Rows(3).Item(2) = ""
        dtCpis.Rows(3).Item(3) = "<240 sin SDRA"

        dtCpis.Rows.Add()
        dtCpis.Rows(4).Item(0) = "RADIOLOGIA"
        dtCpis.Rows(4).Item(1) = "Sin infiltrados"
        dtCpis.Rows(4).Item(2) = "Infiltrados difuso"
        dtCpis.Rows(4).Item(3) = "Infiltrados localizado"
        calcular()

        dtCpis.Rows(0).Item(4) = 0
        dtCpis.Rows(1).Item(4) = 0
        dtCpis.Rows(2).Item(4) = 0
        dtCpis.Rows(3).Item(4) = 0
        dtCpis.Rows(4).Item(4) = 0
        For i = 0 To dgvcpis.Rows.Count - 1
            dgvcpis.Rows(i).Height = 35
        Next
        For i = 0 To dgvcpis.Columns.Count - 2
            dgvcpis.Columns(i).ReadOnly = True
        Next
    End Sub

    Private Sub calcular()
        Dim total2 As Integer
        total2 = 0
        For i = 0 To dgvcpis.RowCount - 1
            total2 = total2 + CInt(dgvcpis.Rows(i).Cells(4).Value)
        Next
        total.Text = total2
    End Sub

    Private Sub dgvcpis_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvcpis.EditingControlShowing
        If dgvcpis.Rows(dgvcpis.CurrentRow.Index).Cells(4).Value = Nothing Then
            dgvcpis.Rows(dgvcpis.CurrentRow.Index).Cells(4).Value = 0
            dgvcpis.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        If dgvcpis.CurrentCell.ColumnIndex = 4 Then
            Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            RemoveHandler dText.KeyPress, AddressOf dgvcpis_KeyPress
            AddHandler dText.KeyPress, AddressOf dgvcpis_KeyPress
        End If
    End Sub

    Private Sub dgvcpis_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If dgvcpis.CurrentCell.ColumnIndex = 4 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If dgvcpis.CurrentRow.Index <> 3 Then
                If (caracter = ChrW(Keys.Back)) Or (((caracter = "0") Or (caracter = "1") Or (caracter = "2")) And String.IsNullOrEmpty(sender.text)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If (caracter = ChrW(Keys.Back)) Or (((caracter = "0") Or (caracter = "2")) And String.IsNullOrEmpty(sender.text)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If

        End If
    End Sub

    Private Sub dgvcpis_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcpis.CellEndEdit
        For i = 0 To dgvcpis.RowCount - 1
            If IsDBNull(dgvcpis.Rows(i).Cells(4).Value) Then
                dgvcpis.Rows(i).Cells(4).Value = 0
            End If
        Next
        calcular()
    End Sub

    Private Sub deshablitar_controles()
        With dgvcpis
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True

        End With
    End Sub
    Private Sub hablitar_controles()
        With dgvcpis
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = False
        End With
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If String.IsNullOrEmpty(total.Text) Then
            MsgBox("No puede guardar registro con valores en 0", MsgBoxStyle.Exclamation)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                If CpisBLL.guardarCPIS(textregistro.Text, Datefecha.Text, SesionActual.idUsuario, dgvcpis.DataSource) <> "" Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    btcancelar.Enabled = False
                    btimprimir.Enabled = True
                    Datefecha.Enabled = False
                    dgvcpis.Columns(4).ReadOnly = True
                End If
            End If
        End If
    End Sub

    Public Sub cargarDatos()
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.CPIS_CARGAR & textregistro.Text, dt)
        If dt.Rows.Count > 0 Then
            dgvcpis.Rows(0).Cells(4).Value = dt.Rows(0).Item("Temperatura")
            dgvcpis.Rows(1).Cells(4).Value = dt.Rows(0).Item("leucocitos")
            dgvcpis.Rows(2).Cells(4).Value = dt.Rows(0).Item("s_traqueales")
            dgvcpis.Rows(3).Cells(4).Value = dt.Rows(0).Item("oxigenacion")
            dgvcpis.Rows(4).Cells(4).Value = dt.Rows(0).Item("Radiologia")
            Datefecha.Value = dt.Rows(0).Item("Fecha")
            calcular()
            bteditar.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            dgvcpis.Columns(4).ReadOnly = True
            Datefecha.Enabled = False
        Else
            bteditar.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_CPIS & textregistro.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    deshablitar_controles()
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    btimprimir.Enabled = False
                    btcancelar.Enabled = False
                    total.Clear()
                    dtCpis.Rows(0).Item(4) = 0
                    dtCpis.Rows(1).Item(4) = 0
                    dtCpis.Rows(2).Item(4) = 0
                    dtCpis.Rows(3).Item(4) = 0
                    dtCpis.Rows(4).Item(4) = 0
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del cpis", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_CPIS
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & textregistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarBraden()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarBraden()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_CPIS, textregistro.Text, New rptCPIS,
                                    textregistro.Text, "{VISTA_CPIS.N_Registro} = " & textregistro.Text & "",
                                    ConstantesHC.NOMBRE_PDF_CPIS, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then

            hablitar_controles()
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btimprimir.Enabled = False
            btanular.Enabled = False
            bteditar.Enabled = False
            Datefecha.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea Cancelar este registro?", 32 + 1, "Cancelar") = 1 Then
            bteditar.Enabled = True
            btguardar.Enabled = False
            cargarDatos()
            Datefecha.Enabled = False
            deshablitar_controles()
        End If
    End Sub
End Class