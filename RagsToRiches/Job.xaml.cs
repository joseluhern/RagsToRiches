namespace RagsToRiches;

public partial class Job : ContentPage
{
	public Job()
	{
		InitializeComponent();
	}

    private void OnCardClick(object sender, TappedEventArgs e)
    {

    }

	private void CardShuffle()
	{
		Random rand = new Random();
		List<int> cardValues = [1, 1, 2, 2, 3, 3, 4, 4, 5, 5];
		List<int> randCardValues = cardValues.OrderBy(_ => rand.Next()).ToList();
    }
}