using Microsoft.Maui.Controls;
using Windows.Media.Audio;
using Windows.Security.Cryptography.Core;

namespace RagsToRiches;

public partial class Job : ContentPage
{
    private List<List<int>> cardCoords = new List<List<int>> { };
	public Job()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        CardShuffle();
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

    private ImageSource GetCardSource(int row, int col)
    {
        var imageSource = cardsGrid.Children
            .FirstOrDefault(child => Grid.GetRow((BindableObject)child) == row &&
            Grid.GetColumn((BindableObject)child) == col);
        if(imageSource is Image image)
        {
            return image.Source;
        }
        return null!;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var currentCard = sender as ImageButton;

        if(currentCard != null)
        {
            currentCard?.IsVisible = false;
            if(cardCoords.Count < 2)
            {
                cardCoords.Add(new List<int> { Grid.GetRow(currentCard), Grid.GetColumn(currentCard) });

                if (cardCoords.Count == 2)
                {
                    if (GetCardSource(cardCoords[0][0], cardCoords[0][1]) == GetCardSource(cardCoords[1][0], cardCoords[1][1]))
                    {
                        // Cards match
                    }
                    // Make a way for all cards to flip face down again
                    cardCoords.Clear();
                }
            }
        }
    }
}