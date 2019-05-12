
Public Class Form_INF_Permiso

    Private Sub Form_INF_Permiso_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        dateInicio.Value = Today.AddDays(1 - Today.Day)
        dateFin.Value = dateInicio.Value.AddMonths(1).AddDays(-1)
        cargarCombo()
    End Sub

    Sub cargarCombo()
        Dim sql = Consultas.CARGAR_EMPLEADOS_HOR & SesionActual.idEmpresa & ", null, '" & Format(dateInicio.Value, Constantes.FORMATO_FECHA_GEN) & "'"
        General.cargarCombo(sql, "Nombre", "Id_tercero", comboempleados)
        Dim dw As DataRow = comboempleados.DataSource.NewRow
        dw.Item("Nombre") = " - - - Todos - - - " : dw.Item("Id_tercero") = "-425618"
        comboempleados.DataSource.Rows.InsertAt(dw, 1)
    End Sub

    Private Sub comboempleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboempleados.SelectedIndexChanged
        btvistaprevia.Enabled = comboempleados.SelectedIndex <> 0
    End Sub

    Private Sub btvistaprevia_Click(sender As Object, e As EventArgs) Handles btvistaprevia.Click
        Dim rptPermisoConsolidado1 As New rptPermisoConsolidado()
        rptPermisoConsolidado1.SetParameterValue("@pUsuario", SesionActual.idUsuario)
        rptPermisoConsolidado1.SetParameterValue("@pEmpresa", SesionActual.idEmpresa)
        rptPermisoConsolidado1.SetParameterValue("@pFchInicio", dateInicio.Value.Date)
        rptPermisoConsolidado1.SetParameterValue("@pFchFin", dateFin.Value.Date)
        rptPermisoConsolidado1.SetParameterValue("@pEmpleado", If(comboempleados.SelectedIndex = 1, "", comboempleados.SelectedValue.ToString))
        Dim ext = ""
        Select Case True
            Case rbpdf.Checked : ext = ".pdf"
            Case rbdoc.Checked : ext = ".doc"
            Case rbxls.Checked : ext = ".xls"
        End Select
        Exec.getReport(rptPermisoConsolidado1, Nothing, "PermisoC", ext)
    End Sub
End Class