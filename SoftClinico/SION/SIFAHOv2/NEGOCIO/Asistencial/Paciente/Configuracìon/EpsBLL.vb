Imports System.Data.SqlClient
Public Class EpsBLL
    Dim cmd As New EpsDAL
    Public Function guardar_eps(ByVal codigo As String, ByVal descripcion As String, ByVal codigo_eps As String, comboFormato As Integer, estancia As Integer, dtConfiguracion As DataTable, codigoGrupo As Integer) As Boolean
        Dim codigo_ent As String = ""
        Try

            codigo_ent = cmd.guardar_eps(codigo, descripcion, codigo_eps, comboFormato, estancia, dtConfiguracion, codigoGrupo)
            If codigo_ent = "" Then
                Return False
            Else
                form_eps.txtcodigo.Text = codigo_ent
                Return True
            End If
            codigo_ent = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function anular_eps(ByVal codigo As String) As Boolean
        Try
            If cmd.anular_eps(codigo) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function cargarComboFormato() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Nombre")
        dt.Rows.Add()
        dt.Rows(0).Item("Codigo") = Constantes.COD_REPORTE_NOPOS_GENERAL
        dt.Rows(0).Item("Nombre") = Constantes.REPORTE_NOPOS_GENERAL
        dt.Rows.Add()
        dt.Rows(1).Item("Codigo") = Constantes.COD_REPORTE_NOPOS_AMBUQ
        dt.Rows(1).Item("Nombre") = Constantes.REPORTE_NOPOS_AMBUQ
        dt.Rows.Add()
        dt.Rows(2).Item("Codigo") = Constantes.COD_REPORTE_NOPOS_CAJACOPI
        dt.Rows(2).Item("Nombre") = Constantes.REPORTE_NOPOS_CAJACOPI
        dt.Rows.Add()
        dt.Rows(3).Item("Codigo") = Constantes.COD_REPORTE_NOPOS_COMPARTA
        dt.Rows(3).Item("Nombre") = Constantes.REPORTE_NOPOS_COMPARTA
        dt.Rows.Add()
        dt.Rows(4).Item("Codigo") = Constantes.COD_REPORTE_NOPOS_COOMEVA
        dt.Rows(4).Item("Nombre") = Constantes.REPORTE_NOPOS_COOMEVA

        Return dt

    End Function
End Class