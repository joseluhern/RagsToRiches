namespace RagsToRiches;

public partial class JobOrGambleMenu : ContentPage
{
	public JobOrGambleMenu()
	{
		InitializeComponent();
	}

    private async void NavigateToJob(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Job());
    }

    private async void NavigateToGambleMenu(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ChooseGambleGame());
    }
}