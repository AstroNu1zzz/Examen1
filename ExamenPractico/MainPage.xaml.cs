namespace ExamenPractico
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnConciertoClicked(object sender, EventArgs e)
        {
            BackgroundAudio.Pause();
            await Navigation.PushModalAsync(new ConcertPage());
        }

        private async void OnDescargasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DownloadsPage());
        }

        private async void OnFeedbackClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeedbackPage());
        }

        private void OnThemeChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is RadioButton radioButton && e.Value)
            {
                string theme = radioButton.Value.ToString();
                Application.Current.UserAppTheme = theme == "Dark" ? AppTheme.Dark : AppTheme.Light;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BackgroundAudio.Play();
        }
    }
}