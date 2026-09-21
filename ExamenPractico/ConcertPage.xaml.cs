namespace ExamenPractico
{
    public partial class ConcertPage : ContentPage
    {
        public ConcertPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

#if ANDROID
            Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
#endif
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

#if ANDROID
            Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
#endif
        }

        private async void OnCloseClicked(object sender, EventArgs e)
        {
            ConcertVideo.Stop();
            await Navigation.PopModalAsync();
        }
    }
}