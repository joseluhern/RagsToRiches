using Microsoft.UI.Xaml.Media.Imaging;

namespace RagsToRiches;

public partial class Slots : ContentPage
{
    private static Double Money;
	public Slots()
	{
		InitializeComponent();
	}

    private async void LeverButton(object? sender, EventArgs e)
    {
        play();
    }


    public void play()
    {
        int OneSlotNum = RandomNumGenerator();
        numberToPicture(OneSlotNum, OneSlot);
        int TwoSlotNum = RandomNumGenerator();
        numberToPicture(TwoSlotNum, TwoSlot);
        int ThreeSlotNum = RandomNumGenerator();
        numberToPicture(ThreeSlotNum, ThreeSlot );

        CheckingScore(OneSlotNum, TwoSlotNum, ThreeSlotNum);

    }

    private void numberToPicture(int NumSlot, Image slotImage)
    {
        // What ever number is generated the image is then shown
        switch (NumSlot)
        {
            case 1:
                slotImage.Source = "bar.jpg";
                break;
            case 2:
                slotImage.Source = "bell.jpg";
                break;
            case 3:
                slotImage.Source = "cherry.jpg";
                break;
            case 4:
                slotImage.Source = "diamond.jpg";
                break;
            case 5:
                slotImage.Source = "heart.jpg";
                break;
            case 6:
                slotImage.Source = "hourseshoe.jpg";
                break;
            case 7:
                slotImage.Source = "lemon.jpg";
                break;
            case 8:
                slotImage.Source = "seven.jpg";
                break;
            case 9:
                slotImage.Source = "watermelon.jpg";
                break;
            default:
                slotImage.Source = "blackjack.jpg";
                break;
        }
    }

    private void CheckingScore(int OneSlot, int TwoSlot, int ThreeSlot)
    {
        //Checks to see if they match

        if(OneSlot == TwoSlot && OneSlot == ThreeSlot && TwoSlot == ThreeSlot)
        {
            Console.WriteLine("JACKPOT");
            Money += 500.00;
        } else if(OneSlot == TwoSlot || OneSlot == ThreeSlot || TwoSlot == ThreeSlot)
        {
            Console.WriteLine("SLIGHT BONUS");
            Money += 300.00;
        } else
        {
            Console.WriteLine("WHOMP WHOMP NO SCORE");
            Money -= 400.00;
        }

    }

    private int RandomNumGenerator()
    {
        // Generates a random number
        Random randMan = new Random();
        return randMan.Next(1,9 + 1);
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