Public Class Frm_BusquedaGeneral
    Inherits Form_BusquedaGeneral

    Public Property ocultaEsto As List(Of String)

    Public Overrides Sub Form_Busqueda_Load(sender As Object, e As EventArgs)
        MyBase.Form_Busqueda_Load(sender, e)
        Try
            If ocultaEsto IsNot Nothing Then
                For Each ColID In ocultaEsto
                    dgvbusqueda.Columns(If(IsNumeric(ColID), CInt(ColID), ColID.Trim)).Visible = False
                Next
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub




End Class
