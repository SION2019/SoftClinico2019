Public Class Form_tomar_huella
    Property huella As DPFP.Template
    Dim NuevoDatosHuella2 As DatosHuella.DatosHuella


    Sub New()
        InitializeComponent()

        NuevoDatosHuella2 = New DatosHuella.DatosHuella() With {.MascDedosTomadosGlo = 0,
                                                                .ContadorMascDedosTomadosGlo = 10,
                                                                .EventoExitosoGlo = True}
        NuevoDatosHuella2.ActualizarGlo()
        IntercambiosDatos(False)
        AddHandler NuevoDatosHuella2.DuranteCambiosGlo, AddressOf DuranteCambioDeDatos
    End Sub

    Private Sub DuranteCambioDeDatos()
        IntercambiosDatos(False)
    End Sub

    Public Sub IntercambiosDatos(ByVal leyo As Boolean)
        If (leyo) Then
            NuevoDatosHuella2.MascDedosTomadosGlo = controlleerhuella.EnrolledFingerMask
            NuevoDatosHuella2.ContadorMascDedosTomadosGlo = controlleerhuella.MaxEnrollFingerCount
            NuevoDatosHuella2.ActualizarGlo()
        Else
            controlleerhuella.EnrolledFingerMask = NuevoDatosHuella2.MascDedosTomadosGlo
            controlleerhuella.MaxEnrollFingerCount = NuevoDatosHuella2.ContadorMascDedosTomadosGlo
        End If
    End Sub

    Sub controlleerhuella_OnEnroll(ByVal sender As Object, ByVal dedos As Integer, ByVal plantilla As DPFP.Template, ByRef e As DPFP.Gui.EventHandlerStatus) Handles controlleerhuella.OnEnroll
        If (NuevoDatosHuella2.EventoExitosoGlo) Then
            NuevoDatosHuella2.VectorPlantillasGlo(dedos - 1) = plantilla
            IntercambiosDatos(True)
            ListEvents.Items.Insert(0, String.Format("OnEnroll: finger {0}", dedos))
            huella = plantilla
            MsgBox("Se ha logrado tomar correctamente la huella de su dedo.", 64, "La activacion fue correcta")
            Close()
        Else
            e = DPFP.Gui.EventHandlerStatus.Failure
        End If
    End Sub

    Sub controlleerhuella_OnDelete(ByVal sender As Object, ByVal dedos As Integer, ByRef e As DPFP.Gui.EventHandlerStatus) Handles controlleerhuella.OnDelete
        If (NuevoDatosHuella2.EventoExitosoGlo) Then
            NuevoDatosHuella2.VectorPlantillasGlo(dedos - 1) = Nothing
            IntercambiosDatos(True)
            ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", dedos))
        Else
            e = DPFP.Gui.EventHandlerStatus.Failure
        End If
    End Sub

    Private Sub controlleerhuella_OnCancelEnroll(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnCancelEnroll
        ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub controlleerhuella_OnComplete(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnComplete
        ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub controlleerhuella_OnFingerRemove(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnFingerRemove
        ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub controlleerhuella_OnFingerTouch(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnFingerTouch
        ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub controlleerhuella_OnReaderConnect(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnReaderConnect
        ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub controlleerhuella_OnReaderDisconnect(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnReaderDisconnect
        ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub controlleerhuella_OnSampleQuality(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Handles controlleerhuella.OnSampleQuality
        ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback))
    End Sub

    Private Sub controlleerhuella_OnStartEnroll(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles controlleerhuella.OnStartEnroll
        ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub form_tomar_huella_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListEvents.Items.Clear()
    End Sub

    Private Sub BtSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub
End Class