namespace Beta_Lunch;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void BtnIniciar_Clicked(object sender, EventArgs e)
    {
        // Cambia toda la app a AppShell
        Application.Current.MainPage = new AppShell();

        // Navega al menú como página raíz del shell
        await Shell.Current.GoToAsync("//MenuPage");
    }

    private async void BtnIrCrear_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearCuentaPage());
    }
}