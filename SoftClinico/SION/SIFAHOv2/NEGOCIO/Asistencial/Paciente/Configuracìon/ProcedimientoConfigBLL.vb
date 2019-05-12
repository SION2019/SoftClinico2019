Imports System.Data.SqlClient
Public Class ProcedimientoConfigBLL
    Dim cmd As New ProcedimientoConfigDAL
    Public Function guardarProcedimiento(objProcedimiento As ConfiguracionProcedimientoCups)
        cmd.Guardarconfiguracionprocedimientos(objProcedimiento)
        Return objProcedimiento
    End Function

    Public Sub llamarOtrasConfiguraciones(item As ToolStripItemCollection, objprocedimiento As ConfiguracionProcedimientoCups)
        Dim formConfiguraciones As New FormOtraConfiguracion
        Dim titulo As String = Nothing
        If item.Item(0).Pressed = True Then
            titulo = TitulosForm.TITULO_ESTANCIA
            formConfiguraciones.llenarCombo(Constantes.CODIGO_CONFIG_ESTANCIA)
            formConfiguraciones.btOpcionExamens.Visible = False
        ElseIf item.Item(1).Pressed = True Then
            titulo = TitulosForm.TITULO_TRANSFUSION_SANGUINEA
            formConfiguraciones.llenarCombo(Constantes.GRUPO_TRANSFUSION)
            formConfiguraciones.btOpcionExamens.Visible = False
        ElseIf item.Item(2).Pressed = True Then
            titulo = TitulosForm.TITULO_PARACLINICO
            formConfiguraciones.llenarCombo(Constantes.GRUPO_PARACLINICO)
        ElseIf item.Item(3).Pressed Then
            titulo = TitulosForm.TITULO_QUIRURGICO
            formConfiguraciones.llenarCombo(Constantes.CODIGO_CONFIG_BILATERAL)
        End If
        formConfiguraciones.Label1.Text = "CONFIGURACIÓN DE " & titulo
        formConfiguraciones.ShowDialog()
    End Sub
End Class
