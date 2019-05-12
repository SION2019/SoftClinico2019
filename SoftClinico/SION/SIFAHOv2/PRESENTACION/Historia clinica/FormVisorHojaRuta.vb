Public Class FormVisorHojaRuta
    Public Property objHistoriaClinica As HistoriaClinica
    Public Property formHistoriaClinica As Form_Historia_clinica
    Private modulo, registro As String
    Public Property indicacion As Integer
    Private Property objVisor As New VisorNotificacion
    Private Sub FormVisorHojaRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(Me)
        objVisor.modulo = objHistoriaClinica.modulo
        objVisor.registro = objHistoriaClinica.nRegistro
        objVisor.idEmpleado = SesionActual.idUsuario
        objVisor.idEmpresa = SesionActual.idEmpresa
        objVisor.consultarIndicaciones(indicacion)
        texthc.Text = formHistoriaClinica.txtRegistro.Text
        textidentificacion.Text = formHistoriaClinica.txtHC.Text
        Textestancia.Text = formHistoriaClinica.txtEstancia.Text
        textnombre.Text = formHistoriaClinica.txtNombre.Text
        If indicacion = Constantes.ID_VISOR_HOJA_RUTA Then
            cargarInformacionPaciente()
            cargarIndicacionMedica()
        End If
        cargarTareaProgramas()
        txtNota.BackColor = Control.DefaultBackColor
        Label1.Text = objVisor.titulo
    End Sub
    Private Sub cargarIndicacionMedica()
        If Not IsNothing(objVisor.fila) Then
            Try
                txtNota.Rtf = objVisor.fila.Item(0)

            Catch ex As Exception
                txtNota.Text = objVisor.fila.Item(0)
            End Try
        Else
            txtNota.Clear()
        End If
    End Sub
    Private Sub cargarTareaProgramas()
        dgvTareaPrograma.DataSource = objVisor.dtNotificacion
        With dgvTareaPrograma
            .ReadOnly = False
            .Columns("id_Programacion").Visible = False
            .Columns("id_Empleado").Visible = False
            .Columns("Descripcion").Visible = False
            .Columns("id_Programacion").ReadOnly = True
            .Columns("Titulo").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
            .Columns("id_Empleado").ReadOnly = True
            .Columns("Autor").ReadOnly = True
            .Columns("Fecha").ReadOnly = True
            .Columns("Fecha Realizacion").ReadOnly = True
            .Columns("Observacion").ReadOnly = False
            .Columns("Visor").Visible = True
            .Columns("Realizado").Width = 70
            .Columns("Observacion").Width = 100
            .Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns("Visor").DisplayIndex = CInt(dgvTareaPrograma.ColumnCount - 1)
        End With
    End Sub
    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs)
        If indicacion = Constantes.ID_VISOR_HOJA_RUTA Then
            objVisor.registro = objHistoriaClinica.nRegistro
            objVisor.consultarIndicaciones(indicacion)
            cargarIndicacionMedica()
            cargarTareaProgramas()
        End If
    End Sub
    Private Sub cargarInformacionPaciente()
        If indicacion = Constantes.ID_VISOR_HOJA_RUTA Then
            texthc.Text = formHistoriaClinica.txtRegistro.Text
            textidentificacion.Text = formHistoriaClinica.txtHC.Text
            Textestancia.Text = formHistoriaClinica.txtEstancia.Text
            textnombre.Text = formHistoriaClinica.txtNombre.Text
        ElseIf indicacion = Constantes.ID_VISOR_NOTA_AUD Then
            Dim params As New List(Of String)
            Dim dFila As DataRow
            params.Add(objVisor.dtNotificacion.Rows(dgvTareaPrograma.CurrentCell.RowIndex).Item("id_programacion"))
            dFila = General.cargarItem("PROC_PACIENTE_CARGAR_NOTA_AUD", params)
            texthc.Text = dFila("Registro")
            textidentificacion.Text = dFila("Documento")
            Textestancia.Text = dFila("Estancia")
            textnombre.Text = dFila("Paciente")
        End If
    End Sub
    Private Sub dgvdiagRem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTareaPrograma.CellDoubleClick
        General.abrirJustificacion(dgvTareaPrograma, objVisor.dtNotificacion, PanelJustificacionR, txtJustificacionR, "Observacion", True)
        If dgvTareaPrograma.Rows(dgvTareaPrograma.CurrentRow.Index).Cells("Realizado").Value = False Then
            txtJustificacionR.ReadOnly = False
        Else
            txtJustificacionR.ReadOnly = True
        End If
    End Sub
    Private Sub txtJustificacionR_Leave(sender As Object, e As EventArgs) Handles txtJustificacionR.Leave
        Try
            If PanelJustificacionR.Visible = True Then
                PanelJustificacionR.Visible = False
                dgvTareaPrograma.Rows(dgvTareaPrograma.CurrentRow.Index).Cells("Observacion").Value = txtJustificacionR.Text
                txtJustificacionR.Clear()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvTareaPrograma_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTareaPrograma.CellClick
        If dgvTareaPrograma.RowCount > 0 Then

            If e.ColumnIndex = 0 Then
                If indicacion = Constantes.ID_VISOR_NOTA_AUD Then
                    objVisor.cargarIndicacionMedicaNotaAud(objVisor.dtNotificacion.Rows(dgvTareaPrograma.CurrentCell.RowIndex).Item("id_programacion"))
                    Cursor = Cursors.WaitCursor
                    cargarIndicacionMedica()
                    Cursor = Cursors.Default
                    grupoLista.Visible = False
                    grupoImagen.Visible = True
                End If
            End If
            If e.ColumnIndex = 10 And dgvTareaPrograma.Rows(dgvTareaPrograma.CurrentCell.RowIndex).Cells("Observacion").Value.ToString = "" Then
                MsgBox("Debe llenar la observacion", MsgBoxStyle.Critical)
                dgvTareaPrograma.Rows(dgvTareaPrograma.CurrentCell.RowIndex).Cells("Realizado").Value = False
                objVisor.dtNotificacion.AcceptChanges()
            Else
                If dgvTareaPrograma.Rows(dgvTareaPrograma.CurrentCell.RowIndex).Cells("Realizado").Value = True Then
                    dgvTareaPrograma.Columns("Observacion").ReadOnly = True
                Else
                    dgvTareaPrograma.Columns("Observacion").ReadOnly = False
                End If
            End If
        End If
    End Sub
    Private Sub FormVisorHojaRuta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Cursor = Cursors.WaitCursor
        guardarRegistro()
        If indicacion = Constantes.ID_VISOR_NOTA_AUD Then
            formHistoriaClinica.verificarColorNotaAud()
        ElseIf indicacion = Constantes.ID_VISOR_HOJA_RUTA Then
            formHistoriaClinica.verificarColorHojaRuta()
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub cargaObjeto()
        objVisor.registro = objHistoriaClinica.nRegistro
    End Sub

    Private Sub txtNota_DoubleClick(sender As Object, e As EventArgs) Handles txtNota.DoubleClick
        grupoImagen.Visible = False
        grupoLista.Visible = True
    End Sub

    Private Sub dgvTareaPrograma_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvTareaPrograma.DataError

    End Sub

    Private Sub guardarRegistro()
        If dgvTareaPrograma.RowCount > 0 Then
            Try
                dgvTareaPrograma.EndEdit()

                cargaObjeto()
                visorHojaRutaBLL.guardarHojaRutaVisor(objVisor)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class