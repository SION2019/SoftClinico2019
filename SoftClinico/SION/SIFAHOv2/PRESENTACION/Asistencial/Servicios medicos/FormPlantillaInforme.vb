Public Class FormPlantillaInforme
    Dim objPlantilla As New ConfPlantillaInfo
    Dim vFormPadre1 As Form_Historia_clinica

    Public Sub CargarPlantilla(ByRef vFormPadre As Form_Historia_clinica)
        Dim params As New List(Of String)
        Try
            vFormPadre1 = vFormPadre
            Tag = vFormPadre.Tag
            objPlantilla.Modulo = Tag.modulo
            objPlantilla.codigoProcedimiento = vFormPadre.dgvParaclinico.DataSource.Rows(vFormPadre.dgvParaclinico.CurrentRow.Index).item("Código").ToString
            objPlantilla.codigoAreaServicio = Funciones.consultarCodigoAreaServicio(vFormPadre.txtRegistro.Text)
            params.Add(objPlantilla.codigoProcedimiento)
            params.Add(objPlantilla.codigoAreaServicio)
            If objPlantilla.Modulo = Constantes.AM Or objPlantilla.Modulo = Constantes.AF Then
                General.llenarTabla(Consultas.PLANTILLA_INFO_CARGAR, params, objPlantilla.dtPlantilla)
            End If
            objPlantilla.navegador.DataSource = objPlantilla.dtPlantilla
            objPlantilla.codigoOrden = vFormPadre.txtCodigoOrden.Text
            dgvDiagnostico.DataSource = objPlantilla.navegador
            dgvDiagnostico.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDiagnostico.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            dgvDiagnostico.AutoGenerateColumns = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub FormPlantillaInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgvDiagnostico.Columns("Codigo Plantilla").ReadOnly = False
        Me.dgvDiagnostico.Columns("Codigo Procedimiento").ReadOnly = True
        Me.dgvDiagnostico.Columns("Descripcion").ReadOnly = True
        Me.dgvDiagnostico.Columns("Area").ReadOnly = True
        Me.dgvDiagnostico.Columns("Nombre Area").ReadOnly = True
        Me.dgvDiagnostico.Columns("Nombre Diagnostico").ReadOnly = True
        Me.dgvDiagnostico.Columns("Interpretación").ReadOnly = True
        Me.dgvDiagnostico.Columns("Seleccionar").ReadOnly = False
        Me.dgvDiagnostico.Columns("Codigo Plantilla").Visible = False
        Me.dgvDiagnostico.Columns("Codigo Procedimiento").Width = 75
        Me.dgvDiagnostico.Columns("Descripcion").Width = 300
        Me.dgvDiagnostico.Columns("Area").Width = 30
        Me.dgvDiagnostico.Columns("Nombre Area").Width = 65
        Me.dgvDiagnostico.Columns("Seleccionar").Width = 65
        Me.dgvDiagnostico.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub dgvDiagnostico_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagnostico.CellContentClick
        ' Detecta si se ha seleccionado el header de la grilla
        If e.RowIndex = -1 Then
            Return
        End If
        If dgvDiagnostico.CurrentCell.ColumnIndex = 6 Or dgvDiagnostico.CurrentCell.ColumnIndex = 5 Then
            Me.txtPnlNombre.Text = objPlantilla.dtPlantilla.Rows(dgvDiagnostico.CurrentRow.Index).Item(5)
            Me.txtPnlInterpretacion.Text = objPlantilla.dtPlantilla.Rows(dgvDiagnostico.CurrentRow.Index).Item(6)
            Me.pnlDiagnostico.Visible = True
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.pnlDiagnostico.Visible = False
    End Sub

    Private Sub Label4_MouseHover(sender As Object, e As EventArgs) Handles Label4.MouseHover
        Label4.ForeColor = Color.White
        Label4.BackColor = Color.Red
    End Sub

    Private Sub Label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.Black
        Label4.BackColor = Color.White
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvDiagnostico.EndEdit()
        If Not ValidarGuardar() Then Return
        If String.IsNullOrEmpty(objPlantilla.codigoOrden) Then
            vFormPadre1.dgvParaclinico.Rows(vFormPadre1.dgvParaclinico.CurrentRow.Index).Cells("dgCodigoPara").Tag = Me
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Exit Sub
        Else
            guardarInforme()
        End If
    End Sub
    Public Sub guardarInforme(Optional pSegundoPlano As Boolean = False, Optional pCodigoOrden As Integer = Constantes.VALOR_PREDETERMINADO)
        Try
            If (pSegundoPlano = False _
                    AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes) _
                    OrElse pSegundoPlano = True Then

                If pCodigoOrden > 0 Then
                    objPlantilla.codigoOrden = pCodigoOrden
                End If
                objPlantilla.respuesta = cmbRespuesta.SelectedItem
                objPlantilla.usarioCreacion = SesionActual.idUsuario
                If objPlantilla.Modulo = Constantes.AM Then
                    objPlantilla.guardarRegistroR()
                ElseIf objPlantilla.Modulo = Constantes.AF Then
                    objPlantilla.guardarRegistroRR()
                End If

                If pSegundoPlano = False Then
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Function ValidarGuardar() As Boolean
        Dim resultado As Boolean = False
        dgvDiagnostico.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Dim dt As New DataTable
        objPlantilla.dtPlantilla.AcceptChanges()
        dt = objPlantilla.dtPlantilla.Copy
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("Seleccionar") = False Then
                dt.Rows(i).Delete()
            End If
        Next
        dt.AcceptChanges()
        If dt.Select("Seleccionar=True", "").Count = 0 Then
            Exec.SavingMsg("Por favor seleccione un diagnostico", dgvDiagnostico)
        ElseIf objPlantilla.idEmpleado = 0 Then
            Exec.SavingMsg("Por favor seleccione un Médico", txtMedico)
        Else
            objPlantilla.dtPlantilla = dt.Copy
            resultado = True
        End If
        Return resultado
    End Function

    Private Sub dgvDiagnostico_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvDiagnostico.CurrentCellDirtyStateChanged
        ' Referenciamos el control DataGridViewCheckBoxCell actual 
        ' 
        Dim cb As DataGridViewCheckBoxCell =
            TryCast(Me.dgvDiagnostico.CurrentCell, DataGridViewCheckBoxCell)

        ' Si es Nothing, abandonamos el procedimiento.
        '
        If (cb Is Nothing) Then Return

        For Each row As DataGridViewRow In dgvDiagnostico.Rows

            ' Si es la fila actual, continuamos el bucle
            If (dgvDiagnostico.CurrentRow Is row) Then Continue For

            ' Desmarcamos la celda tipo DataGridViewCheckBoxCell,
            '
            Dim checkBox As DataGridViewCheckBoxCell = DirectCast(row.Cells(7), DataGridViewCheckBoxCell)

            checkBox.Value = False

            ' Confirmammos los cambios efectuados en la celda actual 
            ' 
            If dgvDiagnostico.IsCurrentCellDirty Then dgvDiagnostico.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Next
    End Sub

    Private Sub btBuscarProcedimiento_Click(sender As Object, e As EventArgs) Handles btBuscarProcedimiento.Click
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)

        params.Add(Constantes.LISTA_CARGO_IMAGENOLOGIA)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.PLANTILLA_BUSQUEDA_EMPLEADO, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objPlantilla.idEmpleado = tbl(0)
            txtMedico.Text = tbl(1)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class