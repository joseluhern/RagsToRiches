namespace RagsToRiches;

public partial class GoodEnding : ContentPage
{
	public GoodEnding()
	{
		InitializeComponent();
	}

    private async void GoToJobOrGambleMenu(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new JobOrGambleMenu());
    }
}