Imports System.Globalization
Public Class ProgramacionCitaMesesBLL
    Private Shared incrementoPanel, incremento, contador, incrementoX, incrementoSaltoLinea As Integer
    Private Shared objCitaMes As CitaMes
    Private Shared panelCreado As Panel
    Private Shared contenedorPanelX As Integer
    Private Shared contenedorPanel As Integer
    Private Shared contenedorPanelHoraDispo As Integer
    Private Shared tamañoMaximo As Integer
    Private Shared fechaModific As Date
    Private Shared Sub valoresInicialesMes()
        contenedorPanel = 0 '----- posicion inicial
        contenedorPanelHoraDispo = 0 '------- contenedor posicion inicial
        incrementoPanel = 75 '-------- incremento veritical
        incrementoX = 176 '--------- incremento Horizontal
        contenedorPanelX = 0 '-------- contenedor posicion X
        incrementoSaltoLinea = 75 '-------- Salto a la posicion 
        tamañoMaximo = 1232 '-------- tamaño de la fila
    End Sub
    Public Shared Function cargarCitas(panel As Panel,
                                  fecha As Date,
                                  busqueda As String) As List(Of String)
        Dim dtDia As New DataTable
        Dim dtFectivo As DataTable
        Dim params As New List(Of String)
        Try
            valoresInicialesMes()
            dtDia = UtlidadCitaBLL.cargarProgramacionCita(fecha, busqueda, 1)
            dtFectivo = UtlidadCitaBLL.cargarFestivosMes(fecha)

            UtlidadCitaBLL.fechaDia = fecha

            params.Add(dtDia.Select("Estado_Atencion='P'").Count.ToString)
            params.Add(dtDia.Select("Estado_Atencion='C'").Count.ToString)
            params.Add(dtDia.Select("Estado_Atencion='R'").Count.ToString)

            For posicion = 0 To 4 '--- posicion de fila
                cargarPanelMeses(panel, fecha, busqueda, dtFectivo, dtDia)
            Next
            contador = 0
        Catch ex As Exception
            Throw ex
        End Try

        Return params

    End Function
    Private Shared Sub cargarPanelMeses(ByRef panel As Panel,
                                        fecha As Date,
                                        busqueda As String,
                                        dtFectivo As DataTable,
                                        dtDia As DataTable)
        Try

            For fil = 0 To 6
                objCitaMes = New CitaMes

                If contenedorPanelX >= tamañoMaximo Then
                    contenedorPanelHoraDispo = contenedorPanelHoraDispo + incrementoSaltoLinea
                    contenedorPanelX = 0
                End If

                objCitaMes.dia = UtlidadCitaBLL.extraeCalendarioPrimerDia(contador, fecha, fechaModific)

                objCitaMes.nombreFecha = Format(fechaModific, "MMyyyy").ToString
                objCitaMes.fechaActual = Format(fecha, "MMyyyy").ToString

                panelCreado = objCitaMes.crearPanelMes(contenedorPanelHoraDispo,
                                                       contenedorPanelX,
                                                       dtDia.Select("Dia='" & objCitaMes.dia & "'"),
                                                       dtFectivo)
                panel.Controls.Add(panelCreado)

                contenedorPanelX = contenedorPanelX + incrementoX
                contador = contador + 1
            Next

            contenedorPanelHoraDispo = contenedorPanelHoraDispo + incrementoSaltoLinea
            contenedorPanelX = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
