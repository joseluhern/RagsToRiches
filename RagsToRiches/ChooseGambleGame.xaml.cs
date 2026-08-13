namespace RagsToRiches;

public partial class ChooseGambleGame : ContentPage
{
	public ChooseGambleGame()
	{
		InitializeComponent();
	}

    private async void GoToJobOrGambleMenu(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new JobOrGambleMenu());
    }

    private async void GoToSlotsGame(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Slots());
    }
}