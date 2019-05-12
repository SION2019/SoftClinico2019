Public Class PemBLL
    Dim objPemDALL As New PemDAL
    Public Shared Function existeDisolvente(ByVal fila As Integer, ByVal nombreColumnaComparada As String, ByVal nombreColumnaActual As String, ByVal tabla As DataTable) As Boolean
        If tabla.Rows(fila).Item(nombreColumnaComparada).ToString = Constantes.CODIGO_NO_VALIDO Then
            tabla.Rows(fila).Item(nombreColumnaActual) = 0
            Return True
        End If
        Return False
    End Function
    Public Shared Function verificarUltimaLineaManual(ByRef tabla As DataTable, ByVal filaActual As Integer, ByRef objPem As Pem) As Boolean
        If Funciones.filaValida(filaActual) AndAlso tabla.Rows(filaActual).Item(0).ToString = "" And objPem.swtManual = True Then
            Return True
        End If
        Return False
    End Function
    Public Shared Function verifcarCantidadesEnCero(ByRef dgv As DataGridView,
                                                    ByVal fila As Integer,
                                                    ByVal nombreColumnaComparada As String,
                                                    ByVal nombreColumnaActual As String,
                                                    Optional nombreColumnaDescripcion As String = "",
                                                    Optional isDisolvente As Boolean = False) As Boolean
        If Not IsDBNull(dgv.Rows(fila).Cells(nombreColumnaComparada).Value) AndAlso dgv.Rows(fila).Cells(nombreColumnaComparada).Value = 0 Then
            If isDisolvente = True Then
                colocarDisolventeDefalut(dgv, fila, nombreColumnaActual, nombreColumnaDescripcion)
            Else
                dgv.Rows(fila).Cells(nombreColumnaActual).Value = 0
            End If
            Return True
        ElseIf IsDBNull(dgv.Rows(fila).Cells(nombreColumnaComparada).Value) Then
            dgv.Rows(fila).Cells(nombreColumnaActual).Value = 0
            Return True
        End If
        Return False
    End Function
    Public Shared Sub colocarDisolventeDefalut(ByRef dgv As DataGridView,
                                               ByVal fila As Integer,
                                               ByVal nombreColumnacodigo As String,
                                               ByVal nombrecolumnaDescripcion As String)
        dgv.Rows(fila).Cells(nombreColumnacodigo).Value = Constantes.CODIGO_NO_VALIDO
        dgv.Rows(fila).Cells(nombrecolumnaDescripcion).Value = Constantes.DISOLVENTE_POR_DEFECTO
    End Sub
    Public Shared Function validarDgvMedicamentos(ByRef objPem As Pem) As Boolean
        If objPem.swtManual = True Then
            If objPem.tablaMedicamentos.Rows.Count > 1 Then
                If objPem.tablaMedicamentos.Select("DosisUnitaria = 0").Count > 1 Then
                    Return False
                End If
            End If
        Else

        End If
        Return True
    End Function
    Public Sub guardarPem(ByRef objPem As Pem,
                          ByVal usuario As Integer,
                          ByVal codigoEP As Integer)
        Try
            objPemDALL.guardarPem(objPem, usuario, codigoEP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularPem(ByRef objPem As Pem,
                         ByVal usuario As Integer)
        Try
            objPemDALL.anular(objPem, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function VeriificarDespachoDePem(ByRef ObjPem As Pem)
        Return objPemDALL.verificarDespachoDePem(ObjPem)
    End Function
End Class