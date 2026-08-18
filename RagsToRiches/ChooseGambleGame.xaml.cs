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

    private async void GoToBlackJack(object? sender, EventArgs e) 
    {
        await DisplayAlertAsync(
            "Coming soon!", "BlackJack will come soon (we hope)....", "okay");
    }

    private async void GoToRoulette(object? sender, EventArgs e)
    {
        await DisplayAlertAsync(
            "Coming soon!", "Roulette will come soon (we hope)....", "okay");
    }
}