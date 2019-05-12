Public Class TrasladoPacienteBLL
    Public Shared Function traslado(objTraslado As TrasladoPacienteSede) As TrasladoPacienteSede
        TrasladoPacienteDAL.traslado(objTraslado)
        Return objTraslado
    End Function
    Public Shared Function Overlay(ByVal SourceImage As Bitmap, ByVal OverlayImage As Bitmap) As Bitmap

        'Llama a la version con Color
        Return Overlay(SourceImage, OverlayImage, Color.Black)

    End Function

    Public Shared Function Overlay(ByVal SourceImage As Bitmap, ByVal OverlayImage As Bitmap, ByVal ColorTransparent As Color) As Bitmap
        Dim g As Graphics

        'Obtengo Graphic de la imagen de fondo para poder dibujar sobe ella
        g = Drawing.Graphics.FromImage(SourceImage)

        'Hago trasparente la imagen que vamos a superponer	
        OverlayImage.MakeTransparent(ColorTransparent)

        'Dibujo la imagen sobre el fondo
        g.DrawImage(OverlayImage, 0, 0)

        'Elimino manejador grafico
        g.Dispose()

        'Devuelve la imagen mezclada
        Return SourceImage

    End Function
End Class
