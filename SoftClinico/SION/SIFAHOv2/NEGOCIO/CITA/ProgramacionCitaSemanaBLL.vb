Public Class ProgramacionCitaSemanaBLL
    Private Shared incrementoPanel, incremento, incrementoX, incrementoSaltoLinea As Integer
    Private Shared objHora As HoraSemana
    Private Shared objSemana As CitaSemana
    Private Shared panelCreado As Panel
    Private Shared contenedorPanel As Integer
    Private Shared contenedorPanelHoraDispo As Integer
    Private Shared contenedorPanelX As Integer
    Private Shared tamañoMaximo As Integer
    Private Shared fechaModific As Date
    Private Shared Sub valoresInicialesDia()
        contenedorPanel = 0 '----- posicion inicial
        contenedorPanelHoraDispo = 0
        incrementoPanel = 78
        incrementoX = 164
        contenedorPanelX = 71
        incrementoSaltoLinea = 78 '-------- Salto a la posicion 
        tamañoMaximo = 1222 '-------- tamaño de la fila
    End Sub

    Private Shared Sub cargarPanelHoraDisponible(ByRef panel As Panel, hora As String)
        Try
            objHora = New HoraSemana
            objHora.color = Control.DefaultBackColor
            objHora.hora = hora
            panel.Controls.Add(objHora.crearPanelHora(contenedorPanelHoraDispo))
            contenedorPanelHoraDispo = contenedorPanelHoraDispo + incrementoPanel
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Shared Sub cargarPanelSemana(ByRef panel As Panel,
                                         fecha As Date,
                                         busqueda As String,
                                         panelPrincipal As Panel,
                                         posicion As Integer,
                                         dtCita As DataTable)
        Dim label As Label
        Dim dtFila As DataRow()
        Dim dia As String
        Try
            For fil = 0 To 6
                objSemana = New CitaSemana

                dia = UtlidadCitaBLL.extraeDiaCalendario(fil, fecha, fechaModific)

                label = New Label
                label = DirectCast(UtlidadCitaBLL.GetReference("lbD" & fil, panelPrincipal), Label)
                label.Text = dia

                objSemana.nombreHora = UtlidadCitaBLL.horaDia(posicion).ToString.Remove(2)
                objSemana.dia = dia.ToString.Remove(2)

                If contenedorPanelX >= tamañoMaximo Then
                    contenedorPanel = contenedorPanel + incrementoSaltoLinea
                    contenedorPanelX = 71
                End If

                objSemana.nombreFecha = Format(fechaModific, "MMyyyy").ToString
                objSemana.fechaActual = Format(fecha, "MMyyyy").ToString

                dtFila = dtCita.Select("Dia='" & objSemana.dia & "' and HoraCorta='" & objSemana.nombreHora & "'")

                panelCreado = objSemana.crearPanelSemana(contenedorPanelX, contenedorPanel, dtFila)

                panel.Controls.Add(panelCreado)
                contenedorPanelX = contenedorPanelX + incrementoX

            Next
            contenedorPanel = contenedorPanel + incrementoSaltoLinea
            contenedorPanelX = 71
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Function cargarCitas(panel As Panel,
                               ByVal fecha As Date,
                               busqueda As String,
                               panelPrincipal As Panel) As List(Of String)

        Dim horaCita As String
        Dim dtCita As New DataTable
        Dim params As New List(Of String)

        Try
            valoresInicialesDia()
            dtCita = UtlidadCitaBLL.cargarProgramacionCita(fecha, busqueda, 1)
            UtlidadCitaBLL.fechaDia = fecha
            params.Add(dtCita.Select("Estado_Atencion='P'").Count.ToString)
            params.Add(dtCita.Select("Estado_Atencion='C'").Count.ToString)
            params.Add(dtCita.Select("Estado_Atencion='R'").Count.ToString)

            For posicion = 0 To 23
                horaCita = UtlidadCitaBLL.horaDia(posicion)
                cargarPanelHoraDisponible(panel, horaCita)
                cargarPanelSemana(panel, fecha, busqueda, panelPrincipal, posicion, dtCita)
            Next

        Catch ex As Exception
            Throw ex
        End Try
        Return params
    End Function
End Class
