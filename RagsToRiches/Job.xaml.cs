using Microsoft.Maui.Controls;
using Windows.Media.Audio;
using Windows.Security.Cryptography.Core;

namespace RagsToRiches;

public partial class Job : ContentPage
{
    private List<List<int>> cardCoords = new List<List<int>> { };
    private bool isLoading = false;
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

    private Image GetImageElement(int row, int col)
    {
        var image = cardsGrid.Children
            .OfType<Image>()
            .FirstOrDefault(child => Grid.GetRow((BindableObject)child) == row &&
            Grid.GetColumn((BindableObject)child) == col);
        if(image is Image img)
        {
            return img;
        }
        return null!;
    }

    private ImageButton GetImageButtonElement(int row, int col)
    {
        var imageButton = cardsGrid.Children
            .OfType<ImageButton>()
            .FirstOrDefault(child => Grid.GetRow((BindableObject)child) == row &&
            Grid.GetColumn((BindableObject)child) == col);
        if (imageButton is ImageButton imgBtn)
        {
            return imgBtn;
        }
        return null!;
    }

    private BoxView GetBoxViewElement(int row, int col)
    {
        var boxView = cardsGrid.Children
            .FirstOrDefault(child => Grid.GetRow((BindableObject)child) == row &&
            Grid.GetColumn((BindableObject)child) == col);
        if (boxView is BoxView box)
        {
            return box;
        }
        return null!;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var currentCard = sender as ImageButton;
        if (isLoading) return;

        if(currentCard != null)
        {
            currentCard?.IsVisible = false;
            if(cardCoords.Count < 2)
            {
                cardCoords.Add(new List<int> { Grid.GetRow(currentCard), Grid.GetColumn(currentCard) });

                if (cardCoords.Count == 2)
                {
                    isLoading = true;
                    int imgRow1 = cardCoords[0][0];
                    int imgCol1 = cardCoords[0][1];
                    int imgRow2 = cardCoords[1][0];
                    int imgCol2 = cardCoords[1][1];
                    await Task.Delay(600);
                    if (ImageEqualityCheck(GetImageElement(imgRow1, imgCol1), GetImageElement(imgRow2, imgCol2)))
                    {
                        GetBoxViewElement(imgRow1, imgCol1).IsVisible = false;
                        GetBoxViewElement(imgRow2, imgCol2).IsVisible = false;
                        GetImageElement(imgRow1, imgCol1).IsVisible = false;
                        GetImageElement(imgRow2, imgCol2).IsVisible = false;
                    }
                    else
                    {
                        GetImageButtonElement(imgRow1, imgCol1).IsVisible = true;
                        GetImageButtonElement(imgRow2, imgCol2).IsVisible = true;
                    }
                    cardCoords.Clear();
                    isLoading = false;
                }
            }
        }
    }

    private bool ImageEqualityCheck(Image image1, Image image2)
    {
        string GetPath(ImageSource source) => source switch
        {
            FileImageSource imageSource => imageSource.File,
            _ => string.Empty
        };
        return GetPath(image1.Source) == GetPath(image2.Source);
    }
}