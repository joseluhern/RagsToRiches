namespace RagsToRiches;

public partial class JobOrGambleMenu : ContentPage
{
	public JobOrGambleMenu()
	{
		InitializeComponent();
	}

    private async void GoToGambleMenu(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChooseGambleGame());
    }
}