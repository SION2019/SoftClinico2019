Public Class FormCargosProProceso
    Dim objConf As New ConfiguracionPorProceso
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pclasificar As String
    Private Sub FormCargosProProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "Metodos"
    Sub inicializarForm()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pclasificar = permiso_general & "pp" & "01"
        objConf.cargarProcesos()
        configurarDgv()
    End Sub
    Sub configurarDgv()
        With dgv
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .DataSource = objConf.tablaProcesos
            .ReadOnly = True
        End With
    End Sub
    Sub configurarDgvCargos(ByRef tbl As DataTable)
        With dgvCargos
            .Columns("Código").DataPropertyName = "Código"
            .Columns("Descripción").DataPropertyName = "Descripción"
            .Columns("Clasificar").DataPropertyName = "Clasificar"
            .Columns("Código").ReadOnly = True
            .Columns("Descripción").ReadOnly = True
            .DataSource = tbl
            .ReadOnly = True
        End With
    End Sub
#End Region
#Region "Funciones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#End Region
#Region "Botones"
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        pnlDetalle.Visible = Visible = False
    End Sub
#End Region
#Region "Eventos de DatagridView"
    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim filaActual As Integer = e.RowIndex
        If e.ColumnIndex = dgv.Columns("btnClasificar").Index AndAlso Funciones.filaValida(filaActual) Then
            Dim codigo As Integer = dgv.Rows(filaActual).Cells("Codigo").Value
            Dim nombreTabla As String = objConf.nombrarTabla(codigo)
            objConf.agregarTabla(nombreTabla)
            objConf.cargarCargos(codigo, nombreTabla)
            configurarDgvCargos(objConf.tblopciones.Tables(nombreTabla))
            lblProcedimientoConf.Text = "- " & dgv.Rows(filaActual).Cells("Descripcion").Value
            pnlDetalle.Visible = True
            pnlDetalle.BringToFront()
        End If
    End Sub
    Private Sub dgvCargos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCargos.CellClick
        If e.ColumnIndex = dgvCargos.Columns("Clasificar").Index Then
            If SesionActual.tienePermiso(Pclasificar) Then
                dgvCargos.ReadOnly = False
                dgvCargos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvCargos.ReadOnly = True
                dgvCargos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Else
            dgvCargos.ReadOnly = True
        End If
    End Sub
    Private Sub dgvCargos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCargos.CellContentClick
        Dim filaActual As Integer = e.RowIndex
        If Funciones.filaValida(filaActual) AndAlso e.ColumnIndex = Me.dgvCargos.Columns.Item("Clasificar").Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.dgvCargos.Rows(filaActual).Cells("Clasificar")
            chkCell.Value = Not chkCell.Value

            Dim identificador As Integer = dgv.Rows(dgv.CurrentRow.Index).Cells("Codigo").Value
            Dim cargo As Integer = dgvCargos.Rows(filaActual).Cells("Código").Value
            Dim params As New List(Of String)

            params.Add(identificador)
            params.Add(cargo)
            params.Add(chkCell.Value)

            Try
                General.ejecutarSQL(Consultas.CONFIGURACION_PROCESOS_CARGO_CREAR, params)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
#End Region
End Class