Public Class FormDetalleGlosa
    Dim dtDetalle As DataTable
    Dim indiceFila As Integer
    Dim idEmpleado As String
    Public Sub iniciarForm(dt As DataTable, indice As Integer)
        dtDetalle = dt
        indiceFila = indice
        txtmotivog.Text = dtDetalle.Rows(indiceFila).Item("motivo_Glosa")
        idEmpleado = dtDetalle.Rows(indiceFila).Item("Responsable")
        txtmotivoa.Text = dtDetalle.Rows(indiceFila).Item("motivo_Aceptacion")
        txtdepartamento.Text = dtDetalle.Rows(indiceFila).Item("Departamento")
        If dtDetalle.Rows(indiceFila).Item("Valor glosa aceptada") <> 0 Or dtDetalle.Rows(indiceFila).Item("Valor definitiva") <> 0 Then
            GroupBox2.Visible = True
            GroupBox3.Visible = True
        End If

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If String.IsNullOrEmpty(txtmotivog.Text) Then
                MsgBox("Motivo de glosa se encuentra vacio", MsgBoxStyle.Exclamation)
            Else

                dtDetalle.Rows(indiceFila).Item("motivo_Glosa") = txtmotivog.Text
                dtDetalle.Rows(indiceFila).Item("Responsable") = IIf(String.IsNullOrEmpty(idEmpleado), -1, idEmpleado)
                dtDetalle.Rows(indiceFila).Item("motivo_Aceptacion") = txtmotivoa.Text
                dtDetalle.Rows(indiceFila).Item("Departamento") = txtdepartamento.Text
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormDetalleGlosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarEmpleado(idEmpleado)
    End Sub

    Private Sub cargarEmpleado(pCodigo)
        Dim dtTercero As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasNom.CARGAR_EMPLEADO, params, dtTercero)
        If dtTercero.Rows.Count > 0 Then
            txtcedula.Text = dtTercero.Rows(0).Item("Nit")
            txtresponsable.Text = dtTercero.Rows(0).Item("Tercero")
            idEmpleado = dtTercero.Rows(0).Item("Id_Empleado")
        End If
    End Sub
    Private Sub btbuscarl_Click(sender As Object, e As EventArgs) Handles btbuscarl.Click
        Dim params As New List(Of String)
        params.Add("")

        General.buscarElemento(ConsultasNom.BUSCAR_EMPLEADO,
                               params,
                               AddressOf cargarEmpleado,
                               TitulosForm.BUSQUEDA_TERCERO,
                               False, 0, True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        General.buscarElemento(ConsultasAsis.DEPARTAMENTO_GLOSA_BUSCAR,
                             Nothing,
                             AddressOf cargarDepartamento,
                             TitulosForm.BUSQUEDA_DEPARTAMENTOS_GLOSA,
                             False, 0, True)
    End Sub


    Private Sub cargarDepartamento(pCodigo)
        Dim dtTercero As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasAsis.DEPARTAMENTO_GLOSA_CARGAR, params, dtTercero)
        If dtTercero.Rows.Count > 0 Then
            txtdepartamento.Text = dtTercero.Rows(0).Item("Departamentos")
        End If
    End Sub
End Class