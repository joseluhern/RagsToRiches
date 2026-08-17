namespace RagsToRiches;

public partial class Slots : ContentPage
{
	public Slots()
	{
		InitializeComponent();
	}

    private async void TheGoodEnding(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new GoodEnding());
    }

    private async void TheBadEnding(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new BadEnding());
    }
}