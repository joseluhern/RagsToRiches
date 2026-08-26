namespace RagsToRiches;

public partial class GoodEnding : ContentPage
{
    public GoodEnding(int Money)
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