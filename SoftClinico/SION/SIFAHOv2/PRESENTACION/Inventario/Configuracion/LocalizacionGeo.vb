Public Class LocalizacionGeo
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Ppais As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SesionActual.tienePermiso(Ppais ) Then
            General.cargarForm(Form_Pais)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        General.cargarForm(Form_Departamento)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        General.cargarForm(Form_Ciudad)
    End Sub

    Private Sub LocalizacionGeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Ppais = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub

    Private Sub LocalizacionGeo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If

    End Sub
End Class