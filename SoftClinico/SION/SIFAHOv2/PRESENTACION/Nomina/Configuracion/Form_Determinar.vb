Option Explicit On
Public Class Form_Determinar
    Private Sub Form_Determinar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtCopia, dtCopiaNueva As New DataTable
        dtCopia = comboconvencion.DataSource.COPY
        Dim filas As DataRow()
        dtCopiaNueva = dtCopia.Clone
        filas = dtCopia.Select("Anulado = 'False'")
        For Each row As DataRow In filas
            dtCopiaNueva.ImportRow(row)
        Next
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Codigo_convencion"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Simbolo_Color"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Nombre"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Hora_Entrada"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Hora_Descanso"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Hora_Retorno"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Hora_Salida"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Minutos"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("MinutosDescanso"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Codigo_EP"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Anulado"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Usuario_Creacion"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Fecha_Creacion"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Usuario_Actualizacion"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Fecha_Actualizacion"))
        dtCopiaNueva.Columns.Remove(dtCopiaNueva.Columns("Key"))
        dtCopiaNueva.Rows.InsertAt(dtCopiaNueva.NewRow(), 0)
        dtCopiaNueva.Rows(0).Item(0) = Constantes.VALOR_PREDETERMINADO
        dtCopiaNueva.Rows(0).Item(1) = Constantes.SELECCION
        comboconvencion.DataSource = dtCopiaNueva
        comboconvencion.DisplayMember = "Descripcion"
        comboconvencion.ValueMember = "Simbolo"
        comboconvencion.SelectedIndex = 0
        comboconvencion.Focus()
    End Sub

    Private Sub btaceptar_Click(sender As Object, e As EventArgs) Handles btaceptar.Click
        If comboconvencion.SelectedIndex = 0 Then
            MsgBox(Mensajes.ESCOGER_CONVENCION, 48, "Atencion")
            comboconvencion.Focus()
            Return
        ElseIf MsgBox("Usted se dispone a asignarle al empleado el turno " + comboconvencion.SelectedValue.ToString +
                      " para el dia " + datetimeEntrada.Value.ToString("dddd dd") + ", ¿desea continuar?", 32 + 1, "Guardar Asignacion") <> 1 Then
            Return
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        If MsgBox("El registro de entrada se eliminara permanentemente ¿Esta seguro que desea continuar?", 32 + 1, "Eliminar") = 1 Then
            Me.DialogResult = Windows.Forms.DialogResult.Retry
            Me.Close()
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class