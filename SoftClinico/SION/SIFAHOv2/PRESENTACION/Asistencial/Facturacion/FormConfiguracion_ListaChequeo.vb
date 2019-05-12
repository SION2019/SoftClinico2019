Public Class FormConfiguracion_ListaChequeo
    Dim objConfiguracion As New ConfiguracionChequeo
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormConfiguracion_ListaChequeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"

        With dgvExamen
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Código"
            .Columns("Codigo").Width = 90
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").Width = 589
            .Columns("exglobal").ReadOnly = True
            .Columns("exglobal").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("exglobal").DataPropertyName = "Ex Global"
            .Columns("Exepciones").ReadOnly = True
            .Columns("Exepciones").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Exepciones").DataPropertyName = "Exepciones"

        End With
        cargarConfig()
        dgvExamen.Enabled = False
    End Sub

    Private Sub FormConfiguracion_ListaChequeo__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Sub cargarConfig()

        objConfiguracion.cargarConfiguracion()
        dgvExamen.DataSource = objConfiguracion.dtConfiguracion
    End Sub

    Private Sub dgvExamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExamen.CellClick
        If e.ColumnIndex = 3 Then
            If dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("exepciones").RowIndex <> Constantes.ORDEN_MEDICA_LISTA And dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("exepciones").RowIndex <> Constantes.EVOLUCION_MEDICA_LISTA Then
                Dim formProcedimientos As New FormConfiguracionProcedimiento
                formProcedimientos.registros(dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("codigo").Value)
                FormPrincipal.Cursor = Cursors.WaitCursor
                formProcedimientos.ShowDialog()
                formProcedimientos.Focus()
                If formProcedimientos.WindowState = FormWindowState.Minimized Then
                    formProcedimientos.WindowState = FormWindowState.Normal
                End If
                FormPrincipal.Cursor = Cursors.Default
            Else
                If dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("exepciones").RowIndex = Constantes.ORDEN_MEDICA_LISTA Then
                    MsgBox("En estos momentos Orden medica no tiene ninguna función", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("En estos momentos Evolucion medica no tiene ninguna función", MsgBoxStyle.Exclamation)
                End If
            End If
        End If
    End Sub

    Public Sub controlDvg()
        dgvExamen.ReadOnly = False
        dgvExamen.Columns("descripcion").ReadOnly = True
        dgvExamen.Columns("codigo").ReadOnly = True
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            btnuevo.Enabled = False
            btguardar.Enabled = True
            dgvExamen.Enabled = True
            controlDvg()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                dgvExamen.EndEdit()
                objConfiguracion.dtConfiguracion.AcceptChanges()
                dgvExamen.CommitEdit(DataGridViewDataErrorContexts.Commit)
                For i = 0 To dgvExamen.Rows.Count - 1

                    objConfiguracion.codigoChequeo = dgvExamen.Rows(i).Cells("codigo").Value
                    objConfiguracion.exepcion = dgvExamen.Rows(i).Cells("exglobal").Value
                    objConfiguracion.guardarCheck()

                Next

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                cargarConfig()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

End Class

