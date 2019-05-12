Public Class FormVisorPlataformaDoc
    Dim objPlataformaDoc As New PlataformaDoc
    Private identificador As Integer
    Dim rutaDefinitiva As String
    Dim plataformaDoc As Boolean = True
    Dim pPrincipal As Principal
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub FormVisorPlataformaDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If plataformaDoc Then

                Dim dt As New DataTable
                Dim ruta As String
                Dim archivo As Byte()
                Dim params As New List(Of String)
                params.Add(Tag.codigo)
                General.llenarTabla(objPlataformaDoc.SqlCargarPDFPlataformaDoc, params, dt)
                If dt.Rows.Count > 0 Then
                    For Each Row As DataRow In dt.Rows
                        archivo = Row(1)
                        ruta = System.IO.Path.GetTempPath & Row(2)
                        IO.File.WriteAllBytes(ruta, archivo)
                        pdfArchivos.LoadFile(ruta)
                        Me.Label1.Text = Row(2)
                        Me.WindowState = FormWindowState.Maximized
                    Next
                End If
                btOpcionSabana.Visible = False
            Else
                Me.Label1.Text = "CONSOLIDADO PACIENTE"
                Dim principal As New PrincipalDAL
                If principal.estaAbiertoTipo(Form_Historia_clinica) Or principal.estaAbiertoTipo(FormAtencionLaboratorio) Then
                    Close()
                    If IsNothing(rutaDefinitiva) Then Exit Sub
                    Process.Start(rutaDefinitiva)

                Else
                    pdfArchivos.LoadFile(rutaDefinitiva)
                End If

                Me.WindowState = FormWindowState.Maximized
                Activate()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub obtenerRuta(ByVal getRuta As String)
        rutaDefinitiva = getRuta
    End Sub
    Public Sub consolidado(vPrincipal As Principal)
        pPrincipal = vPrincipal
        plataformaDoc = False
    End Sub
    Public Function getRuta() As String
        Return rutaDefinitiva
    End Function
    Private Sub Abrir_Click(sender As Object, e As EventArgs) Handles Abrir.Click
        If Panel1.Width < 1 Then
            Panel1.Visible = True
            Timer_abrir.Start()
            Timer_cerrar.Stop()
            Timer_rojo.Stop()
            Abrir.Image = Celer.My.Resources.Resources.b
        Else
            Timer_abrir.Stop()
            Timer_cerrar.Start()
            Abrir.Image = Celer.My.Resources.Resources.a
        End If
    End Sub

    Private Sub Timer_abrir_Tick(sender As Object, e As EventArgs) Handles Timer_abrir.Tick
        If Panel1.Width < 400 Then
            Panel1.Width += 10
            Abrir.Location = New System.Drawing.Point((Abrir.Location.X + 10), 317)
        End If
    End Sub

    Private Sub Timer_cerrar_Tick(sender As Object, e As EventArgs) Handles Timer_cerrar.Tick
        If Panel1.Width > 0 Then
            Panel1.Width -= 10
            Abrir.Location = New System.Drawing.Point((Abrir.Location.X - 10), 317)
        End If
    End Sub

    Private Sub Timer_rojo_Tick(sender As Object, e As EventArgs) Handles Timer_rojo.Tick
        If Panel1.Width < 1 Then
            If identificador = 0 Then
                identificador = 1
                Abrir.Image = Celer.My.Resources.Resources.c
            Else
                identificador = 0
                Abrir.Image = Celer.My.Resources.Resources.a
            End If
        End If
    End Sub

    Private Sub btOpcionSabana_Click(sender As Object, e As EventArgs) Handles btOpcionSabana.Click
        pdfArchivos.LoadFile(rutaDefinitiva)
    End Sub

    Private Sub FormVisorPlataformaDoc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not IsNothing(pPrincipal) AndAlso FormPrincipal.cnxion.State = ConnectionState.Open Then
            PrincipalDAL.salidaAuditorExterno(pPrincipal)
        End If
    End Sub
End Class