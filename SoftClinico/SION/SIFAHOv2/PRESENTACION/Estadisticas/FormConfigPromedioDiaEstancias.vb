Public Class FormConfigPromedioDiaEstancias
    Dim modulo2 As Object
    Dim moduloHC As String
    Public objDiaFactura As New FacturacionDiaria
    Public Property formfactura As New FormPromedioDiaEstancias
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal strParametro As String)
        Me.New()
        modulo2 = strParametro
    End Sub
    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        LLenarDtConfigDiaFactura()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                ConfigPromedioDiaEstanciaBLL.guardarConfigDiaFatura(objDiaFactura)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                DialogResult = DialogResult.OK
                Close()
            End If
        Catch ex As Exception
            DialogResult = DialogResult.Cancel
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub LLenarDtConfigDiaFactura()
        objDiaFactura.dtConfigDiaFactura.Reset()
        objDiaFactura.dtConfigDiaFactura.Columns.Add("Codigo")
        objDiaFactura.dtConfigDiaFactura.Columns.Add("Descripcion")
        objDiaFactura.dtConfigDiaFactura.Rows.Add("DF01-" & SesionActual.idUsuario, cmbArea.SelectedValue.ToString)
        objDiaFactura.dtConfigDiaFactura.Rows.Add("DF02-" & SesionActual.idUsuario, cmbModulo.SelectedValue.ToString)
        objDiaFactura.dtConfigDiaFactura.Rows.Add("DF03-" & SesionActual.idUsuario, cmbOpcion.SelectedIndex.ToString)
        objDiaFactura.dtConfigDiaFactura.Rows.Add("DF04-" & SesionActual.idUsuario, If(chkResumido.Checked = False, 0, 1))
    End Sub

    Private Sub FormConfigPromedioDiaEstancias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim params As New List(Of String)
        formfactura.objSeguimiento.bandera = False
        params.Add(SesionActual.idUsuario)
        params.Add(SesionActual.codigoEP)
        params.Add(moduloHC)
        General.limpiarControles(Me)
        General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", cmbArea)
        Dim dtNuevo As DataTable
        dtNuevo = cmbArea.DataSource.copy
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        dtNuevo.Rows(0).Item(0) = Constantes.VALOR_PREDETERMINADO + Constantes.VALOR_PREDETERMINADO
        cmbArea.DataSource = dtNuevo

        General.cargarCombo(Consultas.MENU_ATENCION_BUSCAR, "Nombre", "Código", cmbModulo)
        If modulo2 = Constantes.AF Then
            cmbModulo.DataSource.ROWS.Add("ac", "AUDITORIA M.")
            cmbModulo.DataSource.ROWS.Add("ad", "AUDITORIA F.")
            cmbModulo.DataSource.ROWS(0).ITEM(1) = "TODOS"
        ElseIf modulo2 = Constantes.AM Then
            cmbModulo.DataSource.ROWS.Add("ac", "AUDITORIA M.")
            cmbModulo.DataSource.ROWS(0).ITEM(1) = "TODOS"
        Else
            cmbModulo.DataSource.ROWS(0).ITEM(1) = "TODOS"
        End If
        objDiaFactura.cargarConfigDiaFact()
        If objDiaFactura.dtConfigDiaFactura.Rows.Count > 0 Then
            Me.cmbArea.SelectedValue = objDiaFactura.dtConfigDiaFactura.Rows(0).Item(1)
            Me.cmbModulo.SelectedValue = objDiaFactura.dtConfigDiaFactura.Rows(1).Item(1)
            Me.cmbOpcion.SelectedIndex = objDiaFactura.dtConfigDiaFactura.Rows(2).Item(1).Substring(0, 1)
        End If
    End Sub

    Private Sub tsCancelar_Click(sender As Object, e As EventArgs) Handles tsCancelar.Click
        Close()
    End Sub
End Class