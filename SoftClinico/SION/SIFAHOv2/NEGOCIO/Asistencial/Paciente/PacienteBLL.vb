Public Class PacienteBLL
    Public Property msj As New ToolTip
    Public Shared Function guardarPaciente(objPaciente As Paciente)
        PacienteDAL.guardarPaciente(objPaciente)
        Return objPaciente
    End Function
    Public Shared Function calcularEdadPaciente(fechaNacimiento As Date) As String
        'estas lineas de codigo son para calcula la edad del paciente
        'poseidon
        '26/09/2016
        Dim edad As String = Nothing
        Dim dias, meses, años As Integer
        Dim fechaActual As Date = CDate(Funciones.Fecha(23)).Date

        Try
            If fechaNacimiento.Date <= fechaActual.Date Then
                dias = DateDiff(DateInterval.Day, fechaNacimiento, fechaActual)
                meses = DateDiff(DateInterval.Month, fechaNacimiento, fechaActual)
                años = DateDiff(DateInterval.Year, fechaNacimiento, fechaActual)

                If dias <= 30 Then
                    edad = dias & " Dia(s)"
                Else
                    If meses < 12 Then
                        edad = meses & " Meses"
                    Else
                        edad = años & " Año(s)"
                    End If
                End If
            Else
                MsgBox("La fecha de nacimiento, ¡ no puede ser Mayor que la Fecha actual !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox("Formato no valido", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return edad
    End Function
    Public Shared Function verificarDocumentoExistencia(Documento As String) As Boolean
        Dim banderaDocumento As Boolean
        If Not String.IsNullOrEmpty(Documento) Then
            Dim drfila As DataRow
            Dim params As New List(Of String)
            params.Add(Documento)
            drfila = General.cargarItem(Consultas.PACIENTE_VERIFICAR_DOCU & "('" & Documento & "')", Nothing)
            banderaDocumento = drfila.Item(0)
        End If
        Return banderaDocumento
    End Function
End Class
