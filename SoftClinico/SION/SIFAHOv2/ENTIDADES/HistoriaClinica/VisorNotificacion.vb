Public Class VisorNotificacion
    Property registro As Integer
    Property fecha As Date
    Property modulo As String
    Property dtNotificacion As New DataTable
    Property idEmpleado As Integer
    Property idEmpresa As Integer
    Property fila As DataRow = Nothing
    Property titulo As String
    Property observacion As String
    Public Property sqlConsultarNotif As String
    Public Property sqlConsultarTarea As String
    Public Property sqlConsultaGuardar As String

    Public Sub consultarIndicaciones(indicacion As Integer)
        dtNotificacion = New DataTable

        Select Case indicacion

            Case Constantes.ID_VISOR_HOJA_RUTA
                sqlConsultarNotif = Consultas.CARGAR_INDICACIONES_HOJA_RUTA
                sqlConsultarTarea = Consultas.CARGAR_TAREAS_PROGRAMADAS_HOJA_RUTA
                sqlConsultaGuardar = Consultas.ACTUALIZAR_ESTADO_HOJA_RUTA
                cargarTareaProgramadaHojaRuta()
                cargarIndicacionMedicaHojaRuta()
                titulo = "VISOR HOJA DE RUTA"
            Case Constantes.ID_VISOR_NOTA_AUD
                sqlConsultarNotif = Consultas.CARGAR_INDICACIONES_NOTA_AUD
                sqlConsultarTarea = Consultas.CARGAR_TAREAS_PROGRAMADAS_NOTA_AUD
                sqlConsultaGuardar = Consultas.ACTUALIZAR_ESTADO_NOTA_AUD
                cargarTareaProgramadaNotaAud()
                titulo = "VISOR NOTA AUDITORIA"
        End Select
    End Sub
    Private Sub cargarTareaProgramadaHojaRuta()
        Dim params As New List(Of String)
        params.Add(CDate(fecha).Date)
        params.Add(registro)
        params.Add(modulo)
        General.llenarTabla(sqlConsultarTarea, params, dtNotificacion)
    End Sub
    Private Sub cargarTareaProgramadaNotaAud()
        Dim params As New List(Of String)
        Dim textoEnriquesido As New RichTextBox
        Dim dtClonado As New DataTable

        params.Add(idEmpleado)
        params.Add(idEmpresa)
        params.Add(registro)
        General.llenarTabla(sqlConsultarTarea, params, dtNotificacion)

        If dtNotificacion.Rows.Count > 0 Then
            dtClonado = dtNotificacion.Clone
            For f = 0 To dtNotificacion.Rows.Count - 1
                textoEnriquesido.Rtf = dtNotificacion.Rows(f).Item("Descripcion")
                dtClonado.Rows.Add()
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Id_Programacion") = dtNotificacion.Rows(f).Item("Id_Programacion")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Descripcion") = textoEnriquesido.Text
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Observacion") = dtNotificacion.Rows(f).Item("Observacion")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Titulo") = dtNotificacion.Rows(f).Item("Titulo")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("id_Empleado") = dtNotificacion.Rows(f).Item("id_Empleado")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Fecha") = dtNotificacion.Rows(f).Item("Fecha")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Autor") = dtNotificacion.Rows(f).Item("Autor")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Responsable") = dtNotificacion.Rows(f).Item("Responsable")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Fecha Realizacion") = dtNotificacion.Rows(f).Item("Fecha Realizacion")
                dtClonado.Rows(dtClonado.Rows.Count - 1).Item("Realizado") = dtNotificacion.Rows(f).Item("Realizado")
            Next
            dtNotificacion.Clear()
            dtNotificacion = dtClonado.Copy

        End If
    End Sub
    Private Sub cargarIndicacionMedicaHojaRuta()
        Dim params As New List(Of String)
        params.Add(CDate(fecha).Date)
        params.Add(modulo)
        params.Add(registro)
        fila = General.cargarItem(sqlConsultarNotif, params)
    End Sub
    Public Sub cargarIndicacionMedicaNotaAud(codigo As Integer)
        Dim params As New List(Of String)
        params.Add(codigo)
        fila = General.cargarItem(sqlConsultarNotif, params)
    End Sub

End Class
