Imports System.Threading
Public Class Contrato
    Property codigo As String
    Property inicio As Date
    Property fin As Date
    Property tipo As String
    Property diasPrueba As String
    Property idEmpresaPagar As Integer
    Property salario As String
    Property auxilio As String
    Property idEmpleado As Integer
    Property idEmpresa As Integer
    Property codigoMinuta As Integer
    Property numeroGrupo As String
    Property sena As Boolean
    Property nitCentro As String
    Property dvCentro As String
    Property centro As String
    Property nombreMinuta As String
    Property tempfileurl As String
    Public Property puntosAsignados As List(Of PuntoServicio)
    Property dtPunto As DataTable
    Property txtMinuta As RichTextBox
    Property bndraImprimir As Boolean
    Property hilo As Thread
    Property nombreEspecilidad As String
    Public Sub New()
        dtPunto = New DataTable
        dtPunto.Columns.Add("Codigo", Type.GetType("System.Int32"))
        dtPunto.Columns.Add("Nombre", Type.GetType("System.String"))
    End Sub
    Public Sub llenarDatosContratante(ByRef dtdatoscontratante As DataTable)
        ContratoLaboralDAL.llenarDatosContratante(dtdatoscontratante)
    End Sub
    Public Sub llenarDatosContratista(ByRef dtdatoscontratista As DataTable)
        ContratoLaboralDAL.llenarDatosContratista(dtdatoscontratista, idEmpleado)
    End Sub
    Public Sub cargarMinuta()
        Dim resultado As DataRow
        Dim params As New List(Of String)
        tempfileurl = Path.GetTempPath + DateTime.Now.Ticks.ToString
        Try
            params.Add(codigoMinuta)
            resultado = General.cargarItem("SP_CONTRATO_MINUTA_CARGAR", params)
            If Not IsNothing(resultado) Then
                nombreMinuta = resultado("Nombre")
                File.WriteAllBytes(tempfileurl + ".docx", resultado("Documento"))
            Else
                nombreMinuta = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function obtenerPuntosServicioEmpleado(ByRef Contrato As Contrato) As List(Of PuntoServicio)
        Dim params As New List(Of String)
        Dim dtEmpresaPunto As New DataTable
        params.Add(Contrato.idEmpleado)
        params.Add(Contrato.idEmpresa)

        General.llenarTabla(Consultas.CARGAR_CONTRATO_PUNTO_S_EMP, params, dtEmpresaPunto)

        Dim empleadoPuntos As New List(Of PuntoServicio)
        For Each fila As DataRow In dtEmpresaPunto.Rows
            Dim punto As New PuntoServicio()

            punto.codigo = Funciones.castFromDbItem(fila.Item("codigo_ep"))
            punto.nombre = Funciones.castFromDbItem(fila.Item("nombre"))
            empleadoPuntos.Add(punto)
        Next

        Return empleadoPuntos
    End Function
End Class
