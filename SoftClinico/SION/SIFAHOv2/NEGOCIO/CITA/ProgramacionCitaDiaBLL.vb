Public Class ProgramacionCitaDiaBLL
    Private Shared incrementoPanel, incrementoX, incrementoSaltoLinea As Integer
    Private Shared objHoraDisponible As HoraDisponible
    Private Shared objDisponible As CitaDisponible
    Private Shared objHoraTomada As HoraTomada
    Private Shared objTomada As CitaTomada
    Private Shared panelCreado As Panel
    Private Shared contenedorPanelDispon As Integer
    Private Shared contenedorPanelX As Integer
    Private Shared Sub valoresInicialesDia()
        contenedorPanelDispon = Constantes.VALOR_INICIAL
        incrementoPanel = Constantes.VALOR_INCREMENTO
        incrementoX = 190
        contenedorPanelX = 120
        incrementoSaltoLinea = 72
    End Sub
#Region "Citas Asignadas"
    Private Shared Function cargarPanelHoraTomada(ByRef panel As Panel, hora As String) As Integer
        Try
            objHoraTomada = New HoraTomada
            objHoraTomada.color = Color.FromArgb(192, 255, 192)
            objHoraTomada.hora = hora
            panel.Controls.Add(objHoraTomada.crearPanelHoraTomada(contenedorPanelDispon, 30))
        Catch ex As Exception
            Throw ex
        End Try
        Return 100
    End Function
    Private Shared Sub cargarPanelTomada(ByRef panel As Panel,
                                         filas() As DataRow, hora As String)
        Dim pendiente As Integer
        Try
            For fil = 0 To filas.Count
                objTomada = New CitaTomada

                If fil < filas.Count Then
                    objTomada.idCita = filas(fil).Item("codigo_cita")
                    objTomada.cedula = filas(fil).Item("Documento_Paciente")
                    objTomada.nombre = filas(fil).Item("paciente")
                    objTomada.fechaCita = filas(fil).Item("Fecha_cita")
                    objTomada.estado = filas(fil).Item("Estado_Atencion")
                    pendiente = 1
                Else
                    pendiente = Constantes.PENDIENTE
                End If

                objTomada.hora = hora

                If contenedorPanelX >= Constantes.ANCHURA_CITA_DISPONIBLE Then
                    contenedorPanelDispon = contenedorPanelDispon + incrementoSaltoLinea
                    contenedorPanelX = 120
                End If

                panelCreado = objTomada.crearPanel(contenedorPanelX, contenedorPanelDispon, pendiente)
                panel.Controls.Add(panelCreado)

                AddHandler panelCreado.DoubleClick, AddressOf UtlidadCitaBLL.llamarFormularioCita

                contenedorPanelX = contenedorPanelX + incrementoX

            Next
            contenedorPanelX = 120
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#Region "Citas no Asignada"
    Private Shared Sub cargarPanelHoraDisponible(ByRef panel As Panel, hora As String)
        Try
            objHoraDisponible = New HoraDisponible
            objHoraDisponible.color = Control.DefaultBackColor
            objHoraDisponible.hora = hora
            panel.Controls.Add(objHoraDisponible.crearPanelHoraDisponible(contenedorPanelDispon, 8))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Shared Sub cargarPanelDisponible(ByRef panel As Panel, hora As String)
        Try
            objDisponible = New CitaDisponible
            objDisponible.color = Control.DefaultBackColor
            objDisponible.hora = hora
            panelCreado = objDisponible.crearPanelDisponible(contenedorPanelDispon)
            panel.Controls.Add(panelCreado)
            AddHandler panelCreado.DoubleClick, AddressOf UtlidadCitaBLL.llamarFormularioCita
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    Public Shared Function cargarCitas(panel As Panel,
                                  fecha As Date,
                                  busqueda As String) As List(Of String)

        Dim dtCitas As DataTable
        Dim horaCita As String
        Dim extratoHora As String
        Dim params As New List(Of String)

        Try
            dtCitas = UtlidadCitaBLL.cargarProgramacionCita(fecha, busqueda, 0)
            valoresInicialesDia()

            params.Add(dtCitas.Select("Estado_Atencion='P'").Count.ToString)
            params.Add(dtCitas.Select("Estado_Atencion='C'").Count.ToString)
            params.Add(dtCitas.Select("Estado_Atencion='R'").Count.ToString)

            For posicion = 0 To 23

                horaCita = UtlidadCitaBLL.horaDia(posicion)
                extratoHora = horaCita.Remove(2)
                UtlidadCitaBLL.fechaDia = fecha

                If dtCitas.Select("Hora='" + extratoHora & "'").Count > 0 Then
                    citaAsignada(panel, horaCita, dtCitas.Select("Hora='" + extratoHora & "'"))
                Else
                    citasNoAsignadas(panel, horaCita)
                End If

            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return params
    End Function
    Private Shared Sub citasNoAsignadas(panel As Panel, hora As String)
        cargarPanelHoraDisponible(panel, hora)
        cargarPanelDisponible(panel, hora.Remove(2))
        contenedorPanelDispon = contenedorPanelDispon + incrementoPanel
    End Sub
    Private Shared Sub citaAsignada(panel As Panel,
                                    hora As String,
                                    fila() As DataRow)
        cargarPanelHoraTomada(panel, hora)
        cargarPanelTomada(panel, fila, hora.Remove(2))
        contenedorPanelDispon = contenedorPanelDispon + incrementoSaltoLinea
    End Sub

End Class
