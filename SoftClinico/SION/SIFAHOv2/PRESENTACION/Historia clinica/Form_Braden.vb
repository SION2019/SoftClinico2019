Imports System.Data.SqlClient
Public Class Form_Braden
    Dim cmd As New EscalaBradenBLL
    Dim dtBraden As New DataTable
    Dim respuesta As Boolean
    Dim permiso_general, Peditar, Panular As String
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim modulo As String
    Private Sub Form_Braden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        establecerTabla()
        establecerdgv()
        dgvescala.DataSource = dtBraden
        deshablitar_controles()
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Peditar = permiso_general & "pp" & "01"
        Panular = permiso_general & "pp" & "02"
        Datefecha.Enabled = False

        txtalto.Text = "Alto Riesgo"
        txtmoderado.Text = "Riesgo Moderado"
        txtbajo.Text = "Riesgo Bajo"
        txtsin.Text = "Sin Riesgo"
        txtmenor.Text = "Menor o igual a 12"
        txtentre13.Text = "Entre 13 y 14"
        txtentre15.Text = "Entre 15 y 18"
        txtmayor19.Text = "Mayor o igual a 19"



        dgvescala.Columns(0).Width = 170
        dgvescala.Columns(1).Width = 165
        dgvescala.Columns(2).Width = 165
        dgvescala.Columns(3).Width = 165
        dgvescala.Columns(4).Width = 165
        dgvescala.Columns(5).Width = 50

        calcular()

        dgvescala.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvescala.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvescala.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvescala.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvescala.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvescala.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        btimprimir.Enabled = False
    End Sub

    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub

    Private Sub Form_Braden_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            Dim col1, col2, col3, col4, col5, col6 As New DataColumn
            col1.ColumnName = "PUNTOS"
            col1.DataType = Type.GetType("System.String")
            dtBraden.Columns.Add(col1)

            col2.ColumnName = "1"
            col2.DataType = Type.GetType("System.String")
            dtBraden.Columns.Add(col2)

            col3.ColumnName = "2"
            col3.DataType = Type.GetType("System.String")
            dtBraden.Columns.Add(col3)

            col4.ColumnName = "3"
            col4.DataType = Type.GetType("System.String")
            dtBraden.Columns.Add(col4)

            col5.ColumnName = "4"
            col5.DataType = Type.GetType("System.String")
            dtBraden.Columns.Add(col5)

            col6.ColumnName = "TOTAL"
            col6.DataType = Type.GetType("System.String")
            dtBraden.Columns.Add(col6)
            col1 = Nothing : col2 = Nothing : col3 = Nothing : col4 = Nothing : col5 = Nothing : col6 = Nothing
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub
    Private Sub establecerdgv()
        Try
            dtBraden.Rows.Add()
            dtBraden.Rows(0).Item(0) = "Precepcion Sensorial"
            dtBraden.Rows(0).Item(1) = "Completamente Limitada"
            dtBraden.Rows(0).Item(2) = "Muy Limitada"
            dtBraden.Rows(0).Item(3) = "Levemente Limitada"
            dtBraden.Rows(0).Item(4) = "No Alterada"
            dtBraden.Rows.Add()
            dtBraden.Rows(1).Item(0) = "Humedad"
            dtBraden.Rows(1).Item(1) = "Completamente Humeda"
            dtBraden.Rows(1).Item(2) = "Muy Humeda"
            dtBraden.Rows(1).Item(3) = "Ocasionalmente Humeda"
            dtBraden.Rows(1).Item(4) = "Raramente Humeda"
            dtBraden.Rows.Add()
            dtBraden.Rows(2).Item(0) = "Actividad"
            dtBraden.Rows(2).Item(1) = "En Cama"
            dtBraden.Rows(2).Item(2) = "En Silla"
            dtBraden.Rows(2).Item(3) = "Camina Ocasionalmente"
            dtBraden.Rows(2).Item(4) = "Camina con Freciencia"
            dtBraden.Rows.Add()
            dtBraden.Rows(3).Item(0) = "Movilidad"
            dtBraden.Rows(3).Item(1) = "Completamente Inmovil"
            dtBraden.Rows(3).Item(2) = "Muy Limitada"
            dtBraden.Rows(3).Item(3) = "Ligeramente Limitada"
            dtBraden.Rows(3).Item(4) = "Sin Limitaciones"
            dtBraden.Rows.Add()
            dtBraden.Rows(4).Item(0) = "Nutricion"
            dtBraden.Rows(4).Item(1) = "Muy Pobre"
            dtBraden.Rows(4).Item(2) = "Probablemente Inadecuada"
            dtBraden.Rows(4).Item(3) = "Adecuada"
            dtBraden.Rows(4).Item(4) = "Excelente"
            dtBraden.Rows.Add()
            dtBraden.Rows(5).Item(0) = "Friccion y Deslizamiento"
            dtBraden.Rows(5).Item(1) = "Es un Problema"
            dtBraden.Rows(5).Item(2) = "Es un Problema Potencial"
            dtBraden.Rows(5).Item(3) = "Es un Problema Aparente"

            dgvescala.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For i = 0 To dgvescala.Rows.Count - 1
                dgvescala.Rows(i).Height = 35
            Next
            For i = 0 To dgvescala.Columns.Count - 2
                dgvescala.Columns(i).ReadOnly = True
            Next
            dtBraden.Rows(0).Item(5) = 4
            dtBraden.Rows(1).Item(5) = 4
            dtBraden.Rows(2).Item(5) = 4
            dtBraden.Rows(3).Item(5) = 4
            dtBraden.Rows(4).Item(5) = 4
            dtBraden.Rows(5).Item(5) = 3
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Private Sub calcular()
        Dim total2 As Integer
        total2 = 0
        For i = 0 To dgvescala.RowCount - 1
            total2 = total2 + CInt(dgvescala.Rows(i).Cells(5).Value)
        Next
        total.Text = total2
        If total2 <= 12 Then
            total.BackColor = Color.LightCoral
            obser.Text = Constantes.ALTO_RIESGO

        ElseIf total2 > 12 And total2 < 15 Then
            total.BackColor = Color.Orange
            obser.Text = Constantes.RIESGO_MODERADO

        ElseIf total2 > 14 And total2 < 19 Then
            total.BackColor = Color.PaleGoldenrod
            obser.Text = Constantes.RIESGO_BAJO

        ElseIf total2 > 18 Then
            total.BackColor = Color.MediumAquamarine
            obser.Text = Constantes.SIN_RIESGO
        End If
    End Sub

    Private Sub deshablitar_controles()
        With dgvescala
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
        End With
    End Sub
    Private Sub hablitar_controles()
        With dgvescala
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = False
        End With
    End Sub

    Private Sub dgvescala_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvescala.EditingControlShowing
        If dgvescala.Rows(dgvescala.CurrentRow.Index).Cells(5).Value = Nothing Then
            If dgvescala.CurrentRow.Index = 5 Then
                dgvescala.Rows(dgvescala.CurrentRow.Index).Cells(5).Value = 3
            Else
                dgvescala.Rows(dgvescala.CurrentRow.Index).Cells(5).Value = 4
            End If
            dgvescala.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        If dgvescala.CurrentCell.ColumnIndex = 5 Then
            Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            RemoveHandler dText.KeyPress, AddressOf validar_Keypress
            AddHandler dText.KeyPress, AddressOf validar_Keypress
        End If
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If dgvescala.CurrentCell.ColumnIndex = 5 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If dgvescala.CurrentRow.Index <> 5 Then
                If (caracter = ChrW(Keys.Back)) Or (((caracter = "1") Or (caracter = "2") Or (caracter = "3") Or (caracter = "4")) And String.IsNullOrEmpty(sender.text)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If (caracter = ChrW(Keys.Back)) Or (((caracter = "1") Or (caracter = "2") Or (caracter = "3")) And String.IsNullOrEmpty(sender.text)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvescala_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvescala.CellEndEdit
        For i = 0 To dgvescala.RowCount - 1
            If IsDBNull(dgvescala.Rows(i).Cells(5).Value) Then
                If i = 5 Then
                    dgvescala.Rows(i).Cells(5).Value = 3
                Else
                    dgvescala.Rows(i).Cells(5).Value = 4
                End If
            End If
        Next

        calcular()
    End Sub

    Public Sub cargarDatos()
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.ESCALA_BRADEN_CARGAR & textregistro.Text, dt)
        If dt.Rows.Count > 0 Then
            dgvescala.Rows(0).Cells(5).Value = dt.Rows(0).Item("Sensorial")
            dgvescala.Rows(1).Cells(5).Value = dt.Rows(0).Item("Humedad")
            dgvescala.Rows(2).Cells(5).Value = dt.Rows(0).Item("Actividad")
            dgvescala.Rows(3).Cells(5).Value = dt.Rows(0).Item("Movilidad")
            dgvescala.Rows(4).Cells(5).Value = dt.Rows(0).Item("Nutricion")
            dgvescala.Rows(5).Cells(5).Value = dt.Rows(0).Item("F_deslizamiento")
            Datefecha.Text = dt.Rows(0).Item("Fecha")
            calcular()
            bteditar.Enabled = True
            btguardar.Enabled = False
            btanular.Enabled = True
            btcancelar.Enabled = False
            dgvescala.Columns(5).ReadOnly = True
            dgvescala.Columns(1).DefaultCellStyle.BackColor = Color.Aqua
            dgvescala.Columns(2).DefaultCellStyle.BackColor = Color.Aqua
            dgvescala.Columns(3).DefaultCellStyle.BackColor = Color.Aqua
            dgvescala.Columns(4).DefaultCellStyle.BackColor = Color.Aqua
            Datefecha.Enabled = False
            btimprimir.Enabled = True
        Else
            bteditar.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            dgvescala.Columns(5).ReadOnly = True
            dgvescala.Columns(1).DefaultCellStyle.BackColor = Color.Aqua
            dgvescala.Columns(2).DefaultCellStyle.BackColor = Color.Aqua
            dgvescala.Columns(3).DefaultCellStyle.BackColor = Color.Aqua
            dgvescala.Columns(4).DefaultCellStyle.BackColor = Color.Aqua
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            hablitar_controles()
            btcancelar.Enabled = True
            btguardar.Enabled = True
            bteditar.Enabled = False
            Datefecha.Enabled = True
            btanular.Enabled = False
            btimprimir.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

            If cmd.guardarBraden(textregistro.Text, Datefecha.Text, SesionActual.idUsuario, dgvescala.DataSource) = True Then
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                btguardar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btcancelar.Enabled = False
                btimprimir.Enabled = True
                dgvescala.Columns("TOTAL").ReadOnly = True
                Datefecha.Enabled = False
            End If
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del anexo", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_BRADEN
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & textregistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarBraden()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarBraden()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_BRADEN, textregistro.Text, New rptBraden,
                                    textregistro.Text, "{VISTA_ESCALA_BRADEN.N_Registro} = " & textregistro.Text & "",
                                    ConstantesHC.NOMBRE_PDF_BRADEN, IO.Path.GetTempPath, obser.Text)

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvescala_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvescala.KeyPress

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea Cancelar este registro?", 32 + 1, "Cancelar") = 1 Then

            If Not String.IsNullOrEmpty(total.Text) Then
                cargarDatos()
            Else
                dtBraden.Rows(0).Item(5) = 4
                dtBraden.Rows(1).Item(5) = 4
                dtBraden.Rows(2).Item(5) = 4
                dtBraden.Rows(3).Item(5) = 4
                dtBraden.Rows(4).Item(5) = 4
                dtBraden.Rows(5).Item(5) = 3
                total.Clear()
                obser.Clear()
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btguardar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
            End If
            Datefecha.Enabled = False
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_ESCALA_BRADEN & textregistro.Text & "," & SesionActual.idUsuario)
                If respuesta = True Then
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    deshablitar_controles()
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    btcancelar.Enabled = False
                    btimprimir.Enabled = False
                    obser.Clear()
                    total.Clear()
                    total.BackColor = Color.White
                    dtBraden.Rows(0).Item(5) = 4
                    dtBraden.Rows(1).Item(5) = 4
                    dtBraden.Rows(2).Item(5) = 4
                    dtBraden.Rows(3).Item(5) = 4
                    dtBraden.Rows(4).Item(5) = 4
                    dtBraden.Rows(5).Item(5) = 3
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
End Class