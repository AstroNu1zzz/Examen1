

namespace ExamenPractico
{
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();

            // Bloquea la selección de fechas futuras
            FeedbackDate.MaximumDate = DateTime.Today;
        }

        private void OnCheckSiChanged(object sender, CheckedChangedEventArgs e)
        {
            // Si marca "Sí", desmarca automáticamente el "No"
            if (e.Value && CheckNo != null)
                CheckNo.IsChecked = false;
        }

        private void OnCheckNoChanged(object sender, CheckedChangedEventArgs e)
        {
            // Si marca "No", desmarca automáticamente el "Sí"
            if (e.Value && CheckSi != null)
                CheckSi.IsChecked = false;
        }

        private void OnSendFeedback(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FeedbackEntry.Text))
            {
                // Limpia el formulario
                FeedbackEntry.Text = string.Empty;
                FeedbackDate.Date = DateTime.Today;
                CheckSi.IsChecked = false;
                CheckNo.IsChecked = false;

                // Muestra el agradecimiento
                ThanksLabel.IsVisible = true;
            }
        }
    }
}
