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
        ChangeImage();
        Console.WriteLine("Nothing");
        play();
    }


    public void play()
    {
        int OneSlot = RandomNumGenerator();
        numberToPicture(OneSlot);
        int TwoSlot = RandomNumGenerator();
        numberToPicture(TwoSlot);
        int ThreeSlot = RandomNumGenerator();
        numberToPicture(ThreeSlot);

        CheckingScore(OneSlot, TwoSlot, ThreeSlot);

    }

    private void numberToPicture(int NumSlot)
    {
        // What ever number is generated the image is then shown
        switch (NumSlot)
        {
            case 1: 
                Console.WriteLine("Image1");

                break;
            case 2:
                Console.WriteLine("image2");
                break;
            case 3:
                Console.WriteLine("image3");
                break;
            case 4:
                Console.WriteLine("image4");
                break;
            case 5:
                Console.WriteLine("image5");
                break;
            case 6:
                Console.WriteLine("image6");
                break;
            case 7:
                Console.WriteLine("image7");
                break;
            case 8:
                Console.WriteLine("image8");
                break;
            case 9:
                Console.WriteLine("image9");
                break;
            case 10:
                Console.WriteLine("image10");
                break;
            default:
                Console.WriteLine("You broke it");
                break;
        }
    }

    private void ChangeImage()
    {
        OneSlot.Source = ImageSource.FromFile(@"C:\Projects\SchoolProjects\RagsToRiches\RagsToRiches\RagsToRiches\Resources\Images\blackjack.jpg");
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
        return randMan.Next(1,10 + 1);
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