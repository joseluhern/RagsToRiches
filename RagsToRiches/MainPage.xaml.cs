namespace RagsToRiches
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToGambleMenu(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseGambleGame());
        }

        private async void GoToJobOrGambleMenu(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new JobOrGambleMenu());
        }

        
    }
}
