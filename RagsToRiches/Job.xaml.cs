using Microsoft.Maui.Controls;
using Windows.Media.Audio;

namespace RagsToRiches;

public partial class Job : ContentPage
{
	public Job()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        CardShuffle();
    }

    private void OnCardClick(object sender, TappedEventArgs e)
    {

    }

	private void CardShuffle()
	{
        int cardListIndex = 0;
        List<List<int>> gridLocations = new List<List<int>>
        {
            new List<int> {0,0},
            new List<int> {0,1},
            new List<int> {0,2},
            new List<int> {0,3},
            new List<int> {1,0},
            new List<int> {1,1},
            new List<int> {1,2},
            new List<int> {1,3},
            new List<int> {2,0},
            new List<int> {2,2}
        };
        List<List<int>> randGridLocations = gridLocations.OrderBy(_ => Random.Shared.Next()).ToList();
        foreach (var child in cardsGrid.Children)
        {
            if (child is Image image)
            {
                Grid.SetRow(image, randGridLocations[cardListIndex][0]);
                Grid.SetColumn(image, randGridLocations[cardListIndex][1]);
                if (randGridLocations[cardListIndex][0] == 2)
                {
                    Grid.SetColumnSpan(image, 2);
                }
                cardListIndex++;
            }
        }
    }
}