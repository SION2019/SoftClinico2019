Public Class ProgramacionOrdenComprasBLL
    Dim objProgramacionOrdenDAL As New ProgramacionOrdenComprasDAL
    Sub llenarListaProveedoresOrdenes(ByRef pList As ListBox, ByVal pPunto As Integer, ByRef datatable As DataTable,
                                      ByVal vlrValueMember As String, ByVal vlrDisplayMember As String, ByVal cadenallenado As String, params As List(Of String))





        General.llenarTabla(cadenallenado, params, datatable, True)
        pList.DataSource = datatable
        pList.DisplayMember = vlrDisplayMember
        pList.ValueMember = vlrValueMember
        pList.Refresh()
    End Sub
    Sub guardarProgramacionOrdenCompra(ByVal objProgramacionOrdenCompra As ProgramacionOrdenCompras,
                                       ByVal pUsuario As Integer,
                                       ByVal pPunto As Integer)
        Try
            objProgramacionOrdenDAL.guardarProgramacionOrdenCompra(objProgramacionOrdenCompra, pUsuario, pPunto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Function verificarExistenciaProgramacionMesActual()
        Return objProgramacionOrdenDAL.verificarExistenciaProgramacionMesActual()
    End Function
    Function VerificarExistenciaOrdenesRescepcionadas()
        Return objProgramacionOrdenDAL.VerificarExistenciaOrdenesRescepcionadas()
    End Function
    Public Sub anularProgramacionOrdenCompra(ByRef objProgramacionOrden As ProgramacionOrdenCompras,
                                            ByVal usuario As Integer)
        Try
            objProgramacionOrdenDAL.anularProgramacionOrdenCompra(objProgramacionOrden, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
