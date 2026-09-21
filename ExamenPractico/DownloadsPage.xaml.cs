using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;

namespace ExamenPractico
{
    public partial class DownloadsPage : ContentPage
    {
        public DownloadsPage()
        {
            InitializeComponent();
        }

        private async void OnDownloadTrack(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string fileName)
            {
                try
                {
                    // Lee el archivo desde los recursos de la app
                    using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);

                    // Lanza el gestor de archivos de Android para guardarlo
                    var fileSaverResult = await FileSaver.Default.SaveAsync(fileName, stream, default);

                    if (fileSaverResult.IsSuccessful)
                    {
                        // Muestra notificación nativa flotante de éxito
                        await Toast.Make($"Guardado en: {fileSaverResult.FilePath}").Show();
                    }
                    else
                    {
                        await Toast.Make("Descarga cancelada").Show();
                    }
                }
                catch
                {
                    await DisplayAlert("Error", "No se pudo procesar el archivo.", "OK");
                }
            }
        }
    }
}