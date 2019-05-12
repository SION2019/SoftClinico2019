Public Class ProgramacionCitaMedicaBLL
    Public Sub cargarComboVista(combo As ComboBox)
        Dim dtTabla As New DataTable
        dtTabla.Columns.Add("Codigo")
        dtTabla.Columns.Add("Descripcion")
        Dim drFila As DataRow

        drFila = dtTabla.NewRow()

        drFila.Item(0) = 0
        drFila.Item(1) = "Mes"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = 1
        drFila.Item(1) = "Dias"
        dtTabla.Rows.Add(drFila)

        'drFila = dtTabla.NewRow()
        'drFila.Item(0) = 2
        'drFila.Item(1) = "Semana"
        'dtTabla.Rows.Add(drFila)

        combo.DataSource = dtTabla
        combo.DisplayMember = "Descripcion"
        combo.ValueMember = "Codigo"
        combo.SelectedIndex = 0
    End Sub
    Private Sub cargarFestivosMes(fecha As Date,
                                 objProgramCita As ProgramacionCitaMedica)
        Dim params As New List(Of String)
        Dim fechaInicio, fechaFin As Date
        Dim UltimoDia As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)

        Try

            fechaInicio = DateAdd(DateInterval.Day, -fecha.Day, fecha).AddDays(1)
            fechaFin = DateAdd(DateInterval.Day, -fecha.Day, fecha).AddDays(UltimoDia)

            params.Add(Format(fechaInicio, "yyyy-MM-dd hh:mm:ss"))
            params.Add(Format(fechaFin, "yyyy-MM-dd hh:mm:ss"))

            General.llenarTabla(Consultas.HORARIO_LABORAL_FESTIVOS_CARGAR, params, objProgramCita.dtFectivo)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub SiglaDias(dfecha As Date,
                          objProgramCita As ProgramacionCitaMedica,
                          dgvHorarioCita As DataGridView)
        Dim datemp As New Date
        Dim Nombre As String = ""
        Dim busqueda As DataRow()
        Dim ultDiaMes = DateTime.DaysInMonth(dfecha.Year, dfecha.Month)
        Try

            cargarFestivosMes(dfecha, objProgramCita)

            For i = 1 To 31
                dgvHorarioCita.Columns(i).DefaultCellStyle.BackColor = Color.White
                dgvHorarioCita.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                Dim Dia As Integer = Replace(dgvHorarioCita.Columns(i).Name, "Dia", "")
                If Dia > ultDiaMes Then
                    dgvHorarioCita.Columns(i).Visible = False
                Else
                    dgvHorarioCita.Columns(i).Visible = True
                    datemp = Dia.ToString("00") & dfecha.ToString("/MM/yyyy")
                    Nombre = UCase(Strings.Left(Format(datemp, "dddd"), 2))
                    If Nombre = "SÁ" Then
                        Nombre = "SA"
                    Else
                        If Nombre = "DO" Then
                            dgvHorarioCita.EnableHeadersVisualStyles = False
                            dgvHorarioCita.Columns(i).HeaderCell.Style.ForeColor = Color.Red
                            dgvHorarioCita.Columns(i).DefaultCellStyle.BackColor = Control.DefaultBackColor
                        Else
                            busqueda = objProgramCita.dtFectivo.Select("DiaF='" & Dia & "'", "")
                            If busqueda.Count > 0 Then
                                dgvHorarioCita.Columns(i).HeaderCell.Style.ForeColor = Color.Red
                                dgvHorarioCita.Columns(i).DefaultCellStyle.BackColor = Control.DefaultBackColor
                            End If
                        End If
                    End If
                End If

                If objProgramCita.banderaDia = True Then
                    Nombre = Format(datemp, "dddd").ToString
                    dgvHorarioCita.Columns(i).HeaderText = Nombre + vbCrLf + Strings.Right(" " & Dia, 2)
                Else
                    dgvHorarioCita.Columns(i).HeaderText = Nombre + vbCrLf + Strings.Right(" " & Dia, 2)
                End If

            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub diseñoColumna(dgvHorarioCita As DataGridView)
        For columna = 0 To dgvHorarioCita.Columns.Count - 1
            dgvHorarioCita.Columns(columna).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvHorarioCita.Columns(columna).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

    Public Sub cargarModoVista(objProgramCita As ProgramacionCitaMedica,
                               combo As ComboBox, dfecha As DateTime, dgvHorarioCita As DataGridView)
        Dim dia As Integer
        Try
            If Not IsNothing(objProgramCita) Then
                If combo.ValueMember <> String.Empty Then
                    dia = dfecha.Day
                    cargarHorarioCita(dgvHorarioCita, dfecha, objProgramCita)
                    Select Case combo.SelectedValue
                        Case 0
                            vistaMes(objProgramCita, dgvHorarioCita)
                            SiglaDias(dfecha, objProgramCita, dgvHorarioCita)
                        Case 1
                            objProgramCita.banderaDia = True
                            SiglaDias(dfecha, objProgramCita, dgvHorarioCita)
                            vistaDia(dia, objProgramCita, dgvHorarioCita)
                        Case 2
                            objProgramCita.banderaDia = True
                            SiglaDias(dfecha, objProgramCita, dgvHorarioCita)
                            cargarSemanas(dfecha, dgvHorarioCita, objProgramCita)
                    End Select
                End If
                objProgramCita.banderaDia = False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub vistaMes(objProgramCita As ProgramacionCitaMedica,
                         dgvHorarioCita As DataGridView)
        For Columna = 1 To objProgramCita.dtProgramCita.Columns.Count - 1
            dgvHorarioCita.Columns(Columna).Visible = True
        Next
        letraCambio(2, dgvHorarioCita)
    End Sub
    Private Sub vistaDia(dia As Integer,
                         objProgramCita As ProgramacionCitaMedica,
                         dgvHorarioCita As DataGridView)
        Dim valor As String
        For Columna = 1 To objProgramCita.dtProgramCita.Columns.Count - 1
            valor = extraeNumero(dgvHorarioCita.Columns(Columna).HeaderText)
            If dia <> valor Then
                dgvHorarioCita.Columns(Columna).Visible = False
            Else
                dgvHorarioCita.Columns(Columna).Visible = True
            End If
        Next
        letraCambio(7, dgvHorarioCita)
    End Sub

    Public Function extraeNumero(cadena As String) As String
        Dim i As Integer
        Dim SoloNumeros As String = Nothing

        For i = 1 To Len(cadena)

            If Mid$(cadena, i, 1) Like "#" Then _
            SoloNumeros = CLng(SoloNumeros & Mid$(cadena, i, 1))

        Next i

        Return SoloNumeros

    End Function
    Public Sub verificarVistaSelec(indice As Integer,
                                    combo As ComboBox,
                                    dfecha As DateTime,
                                   objProgramCita As ProgramacionCitaMedica,
                                   dgvHorarioCita As DataGridView)
        Try
            Select Case combo.SelectedIndex
                Case 0
                    dfecha = dfecha.AddMonths(indice)
                Case 1
                    dfecha = dfecha.AddDays(indice)
                    objProgramCita.banderaDia = True
                Case 2

            End Select

            cargarModoVista(objProgramCita, combo, dfecha, dgvHorarioCita)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ocultarColumnas(dgvHorarioCita As DataGridView)
        For columna = 0 To dgvHorarioCita.Columns.Count - 1
            dgvHorarioCita.Columns(columna).Visible = False
        Next
    End Sub
    Private Sub cargarSemanas(Fecha As Date,
                              dgvHorarioCita As DataGridView,
                              objProgramCita As ProgramacionCitaMedica)
        ocultarColumnas(dgvHorarioCita)
        mostrarDiasVisibles(dgvHorarioCita, objProgramCita)
        letraCambio(6, dgvHorarioCita)
    End Sub
    Private Sub mostrarDiasVisibles(dgvHorarioCita As DataGridView,
                                    objProgramCita As ProgramacionCitaMedica,
                                    Optional bandera As Boolean = False)
        Dim diasemanasPredeterminado As Integer

        diasemanasPredeterminado = (8 + objProgramCita.contenedor)

        For idDia = objProgramCita.pocisionActual To diasemanasPredeterminado

            dgvHorarioCita.Columns(idDia).Visible = True
            objProgramCita.pocisionActual = idDia
            objProgramCita.contenedor = idDia
        Next
    End Sub
    Public Sub letraCambio(tamaño As Integer, dgvHorarioCita As DataGridView)
        dgvHorarioCita.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, tamaño)
        dgvHorarioCita.Columns("Hora").DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Sub cargarHorarioCita(dgvHorarioCita As DataGridView,
                                 Fecha As DateTime,
                                 objProgramCita As ProgramacionCitaMedica)
        Dim params As New List(Of String)
        params.Add(Fecha.Date)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(objProgramCita.sqlConsultaCargar, params, objProgramCita.dtProgramCita)
        dgvHorarioCita.DataSource = objProgramCita.dtProgramCita
        diseñoColumna(dgvHorarioCita)
        dgvHorarioCita.AutoGenerateColumns = False
        dgvHorarioCita.Columns("Hora").Visible = False
        letraCambio(2, dgvHorarioCita)
    End Sub
    Public Function cargarHorarioCitaDatos(Fecha As Date,
                                 objProgramCita As ProgramacionCitaMedica,
                                 vista As Integer) As DataTable
        Dim params As New List(Of String)
        Dim dtDatos As New DataTable
        params.Add(Fecha.Date)
        params.Add(vista)
        General.llenarTabla(objProgramCita.sqlConsultaDatos, params, dtDatos)
        Return dtDatos
    End Function
    Public Sub cargarHorarioCitaDetalle(dgvHorarioCitaDetalle As DataGridView,
                                        Fecha As Date,
                                        objProgramCita As ProgramacionCitaMedica)

        Dim params As New List(Of String)
        params.Add(Fecha.Date)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(objProgramCita.sqlConsultaCargarDetalle, params, objProgramCita.dtProgramCitaDetalle)
        dgvHorarioCitaDetalle.DataSource = objProgramCita.dtProgramCitaDetalle
        dgvHorarioCitaDetalle.AutoGenerateColumns = False
        diseñoColumna(dgvHorarioCitaDetalle)
        If objProgramCita.dtProgramCitaDetalle.Rows.Count > 0 Then
            dgvHorarioCitaDetalle.Columns("Codigo_Cita").Visible = False
            dgvHorarioCitaDetalle.Columns("dgVerCita").DisplayIndex = 8
        End If
    End Sub
    Public Sub validarColores(dgvHorarioCita As DataGridView,
                           pocision As Integer,
                           columna As Integer,
                           objProgramCita As ProgramacionCitaMedica)

        Dim contener As String
        contener = objProgramCita.dtProgramCita.Rows(pocision).Item(columna)
        If contener.ToString.Contains("|$P$|") Then
            contener = Replace(contener, "$P$|", Nothing)
            dgvHorarioCita.Rows(pocision).Cells(columna).Style.BackColor = Color.LightCoral
            objProgramCita.dtProgramCita.Rows(pocision).Item(columna) = contener
        ElseIf contener.ToString.Contains("|$C$|") Then
            contener = Replace(contener, "$C$|", Nothing)
            dgvHorarioCita.Rows(pocision).Cells(columna).Style.BackColor = Color.LightGray
            objProgramCita.dtProgramCita.Rows(pocision).Item(columna) = contener
        ElseIf contener.ToString.Contains("|$R$|") Then
            contener = Replace(contener, "$R$|", Nothing)
            dgvHorarioCita.Rows(pocision).Cells(columna).Style.BackColor = Color.FromArgb(192, 255, 192)
            objProgramCita.dtProgramCita.Rows(pocision).Item(columna) = contener
        End If

    End Sub
End Class
