namespace Beta_Lunch;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
        LoadImages();
    }

    private void LoadImages()
    {
        // Lista de imágenes (comidas)
        var imageList = new List<string>
        {
            "dotnet_bot.jpg", "dotnet_bot.jpg", "dotnet_bot.jpg",
            "dotnet_bot.jpg", "dotnet_bot.jpg", "dotnet_bot.jpg",
            "dotnet_bot.jpg", "dotnet_bot.jpg", "dotnet_bot.jpg",
            "dotnet_bot.jpg"
        };

        int row = 0;
        int col = 0;

        foreach (var img in imageList)
        {
            var imageButton = new ImageButton
            {
                Source = img,
                HeightRequest = 120,
                WidthRequest = 120,
                BackgroundColor = Colors.Transparent,
                Aspect = Aspect.AspectFill,
                CornerRadius = 10
            };

            imageButton.Clicked += (s, e) =>
            {
                DisplayAlert("Comida seleccionada", $"Seleccionaste: {img}", "OK");
            };

            FoodGrid.Add(imageButton, col, row);

            col++;
            if (col > 1)
            {
                col = 0;
                row++;
            }
        }
    }
}