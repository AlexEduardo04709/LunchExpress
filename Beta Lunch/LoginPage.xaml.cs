namespace Beta_Lunch;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void BtnIniciar_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();

        await Shell.Current.GoToAsync("//HomePage");
    }

    private async void BtnIrCrear_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearCuentaPage());
    }
}