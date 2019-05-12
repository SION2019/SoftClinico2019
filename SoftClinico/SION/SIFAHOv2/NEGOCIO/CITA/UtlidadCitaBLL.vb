Public Class UtlidadCitaBLL
    Shared Property objFormCita As FormProgramacionCita
    Shared Property fechaDia As DateTime
    Public Shared Function cargarFestivosMes(fecha As Date) As DataTable
        Dim dt As New DataTable
        Dim params As New List(Of String)
        Dim fechaInicio, fechaFin As Date
        Dim UltimoDia As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)

        Try
            fechaInicio = DateAdd(DateInterval.Day, -fecha.Day, fecha).AddDays(1)
            fechaFin = DateAdd(DateInterval.Day, -fecha.Day, fecha).AddDays(UltimoDia)

            params.Add(Format(fechaInicio, "yyyy-MM-dd hh:mm:ss"))
            params.Add(Format(fechaFin, "yyyy-MM-dd hh:mm:ss"))

            General.llenarTabla(Consultas.HORARIO_LABORAL_FESTIVOS_CARGAR, params, dt)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function
    Public Shared Function cargarProgramacionCita(Fecha As Date,
                                                  busqueda As String,
                                                  vista As Integer) As DataTable
        Dim params As New List(Of String)
        Dim dtable As New DataTable
        Try
            params.Add(Fecha)
            params.Add(vista)
            params.Add(busqueda)
            params.Add(SesionActual.codigoEP)
            General.llenarTabla("[PROC_PROGRAMACION_CITA_CARGAR]", params, dtable)
        Catch ex As Exception
            Throw ex
        End Try
        Return dtable
    End Function

    Public Shared Sub llamarFormularioCita(sender As Object, e As EventArgs)
        Dim idCita As String = Nothing
        Dim formCitaMedica As New FormCitaMedica
        Dim horaExtraida As String = Nothing
        Try

            If objFormCita.comboAreaServicio.SelectedIndex = 0 Then
                horaExtraida = If(sender.tag.ToString.Length = 2, sender.tag, sender.tag.ToString.Remove(2))
                idCita = If(sender.tag.ToString.Length = 2, String.Empty, sender.tag.ToString.Substring(3))
            Else
                idCita = sender.tag
            End If

            If Not String.IsNullOrEmpty(idCita) Then
                formCitaMedica.bandera = True
                formCitaMedica.cargarPaciente(idCita)
            End If

            formCitaMedica.objFormularioProgram = objFormCita
            If objFormCita.comboAreaServicio.SelectedIndex = 0 Then
                formCitaMedica.fechaHora = fechaDia.AddHours(-fechaDia.Hour).AddHours(horaExtraida)
            Else
                formCitaMedica.fechaHora = fechaDia
            End If
            formCitaMedica.Tag = objFormCita.Tag
            formCitaMedica.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Function horaDia(posicion As Integer) As String
        Dim hora As String
        Dim fecha As DateTime = DateTime.Now
        fecha = fecha.AddHours(-fecha.Hour)
        fecha = fecha.AddHours(+posicion)
        hora = Format(fecha, "HH:00:00")
        Return hora
    End Function
    Public Shared Function extraeDiaCalendario(posicion As Integer,
                                              Fecha As Date,
                                              ByRef fechaModific As Date) As String
        Dim dia As String
        Dim primerDiaMesNum, diaSemana As String
        Dim nombreMes As String
        Try
            fechaModific = Fecha
            diaSemana = Weekday(fechaModific) - 1
            fechaModific = fechaModific.AddDays(-diaSemana).AddDays(posicion)
            primerDiaMesNum = Format(fechaModific, "dd")
            nombreMes = UCase(Strings.Left(Format(fechaModific, "MMMM"), 4)).ToLower
            dia = primerDiaMesNum
        Catch ex As Exception
            Throw ex
        End Try
        Return dia & " " & nombreMes
    End Function
    Public Shared Function extraeCalendarioPrimerDia(posicion As Integer,
                                                     Fecha As Date,
                                                     ByRef fechaModific As Date) As String
        Dim dia As String
        Dim primerDiaMesNum, diaSemana As String
        Try
            fechaModific = Fecha
            fechaModific = fechaModific.AddDays(-fechaModific.Day).AddDays(1)
            diaSemana = Weekday(fechaModific) - 1
            fechaModific = fechaModific.AddDays(-diaSemana).AddDays(posicion)
            primerDiaMesNum = Format(fechaModific, "dd")
            dia = primerDiaMesNum
        Catch ex As Exception
            Throw ex
        End Try
        Return dia
    End Function
    Public Shared Function GetReference(ByVal nombreControl As String, panel As Panel) As Control
        For Each controlSuperior As Control In panel.Controls
            If (TypeOf controlSuperior Is Panel) Then
                For Each subControles As Control In controlSuperior.Controls
                    If subControles.Name.ToLower = nombreControl.ToLower Then
                        Return subControles
                    End If
                Next
            End If
        Next
        Return Nothing
    End Function
    Public Shared Sub cargarComboVista(comboAreaServicio As ComboBox)
        Dim dtTabla As New DataTable
        dtTabla.Columns.Add("Codigo")
        dtTabla.Columns.Add("Descripcion")
        Dim drFila As DataRow
        Try

            drFila = dtTabla.NewRow()

            drFila.Item(0) = 0
            drFila.Item(1) = "Dias"
            dtTabla.Rows.Add(drFila)

            drFila = dtTabla.NewRow()
            drFila.Item(0) = 1
            drFila.Item(1) = "Semana"
            dtTabla.Rows.Add(drFila)

            drFila = dtTabla.NewRow()
            drFila.Item(0) = 2
            drFila.Item(1) = "Mes"
            dtTabla.Rows.Add(drFila)

            comboAreaServicio.DataSource = dtTabla
            comboAreaServicio.DisplayMember = "Descripcion"
            comboAreaServicio.ValueMember = "Codigo"
            comboAreaServicio.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Function cargarCombo(ByVal consulta As String,
                                ByVal params As List(Of String),
                                ByVal vlrDisplayMember As String,
                                ByVal vlrValueMember As String,
                                ByVal cbCombo As ComboBox) As Boolean
        Dim dtTabla As New DataTable
        Dim bandera As Boolean
        Try

            dtTabla.Columns.Add(vlrValueMember)
            dtTabla.Columns.Add(vlrDisplayMember)

            Using da = New SqlDataAdapter(consulta & Funciones.getParametros(params), FormPrincipal.cnxion)
                da.Fill(dtTabla)
            End Using

            cbCombo.DataSource = dtTabla
            cbCombo.DisplayMember = vlrDisplayMember
            cbCombo.ValueMember = vlrValueMember

            If cbCombo IsNot Nothing Then
                cbCombo.AutoCompleteMode = AutoCompleteMode.None
                cbCombo.AutoCompleteSource = AutoCompleteSource.None
                cbCombo.DropDownStyle = ComboBoxStyle.DropDownList
            End If

            If dtTabla.Rows.Count > 0 Then
                bandera = True
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        Return bandera

    End Function
End Class
