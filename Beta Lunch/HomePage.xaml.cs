namespace Beta_Lunch;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void GoMenu(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("//MenuPage");

    private async void GoPerfil(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("//PerfilPage");

    private async void GoHistorial(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("//HistorialPage");
}

