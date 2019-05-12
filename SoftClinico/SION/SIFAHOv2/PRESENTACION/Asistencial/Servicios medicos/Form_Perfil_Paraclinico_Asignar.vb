Public Class Form_Perfil_Paraclinico_Asignar
    Dim EnlceDta As BindingSource = New BindingSource
    Public Property objPP As ConfiguracionPerfilParaclinico
    Private Sub Form_Perfil_Paraclinico_Asignar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.Text = "SELECCIONAR PERFIL PARACLINICO (" & objPP.Titulo & ")"
        cargarProcedimiento()
    End Sub
    Private Sub cargarProcedimiento()
        Cursor.Current = Cursors.WaitCursor
        objPP.llenarTablaParaclinico()
        validarDgv()
        lbCantidad.Text = "Cantidad de items: " & objPP.dtProcedimiento.Rows.Count
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub validarDgv()
        EnlceDta.DataSource = objPP.dtProcedimiento
        With dgvprocedimientos
            .DataSource = EnlceDta.DataSource
            .Columns("Codigo").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
            .Columns("Seleccionar").ReadOnly = False
            .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
        dgvprocedimientos.AutoGenerateColumns = False
        verificarExistentes()
    End Sub
    Public Sub verificarExistentes()
        Dim filasVisibles As DataRowCollection = objPP.dtProcedimiento.Rows
        Dim filasProHist As DataTable = objPP.dtParaclinicoC
        For indiceFila = 0 To filasVisibles.Count - 1
            If filasProHist.Select("codigo= '" & filasVisibles(indiceFila).Item("codigo") & "'").Count > 0 Then
                filasVisibles(indiceFila).Delete()
            End If
        Next
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        objPP.dtProcedimiento.Clear()
        Me.Close()
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvprocedimientos.EndEdit()
        dgvprocedimientos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        objPP.dtProcedimiento.AcceptChanges()

        If objPP.dtProcedimiento.Select("[Seleccionar] = True").Count = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar algún item !", dgvprocedimientos)
        Else
            Me.Close()
        End If
    End Sub

End Class