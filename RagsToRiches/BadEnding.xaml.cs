namespace RagsToRiches;

public partial class BadEnding : ContentPage
{
	public BadEnding()
	{
		InitializeComponent();
	}

    private async void GoToJobOrGambleMenu(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new JobOrGambleMenu());
    }

}