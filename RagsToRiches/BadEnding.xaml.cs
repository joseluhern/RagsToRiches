namespace RagsToRiches;

public partial class BadEnding : ContentPage
{
	public BadEnding(int Money)
	{
		InitializeComponent();

        MoneyCount.Text = $"Money: ${Money}";
        SemanticScreenReader.Announce(MoneyCount.Text);
    }

    private async void GoToJobOrGambleMenu(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new JobOrGambleMenu());
    }

}