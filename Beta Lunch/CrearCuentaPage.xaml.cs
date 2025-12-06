namespace Beta_Lunch;

public partial class CrearCuentaPage : ContentPage
{
	public CrearCuentaPage()
	{
		InitializeComponent();
	}
    private async void BtnCrear_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Cuenta", "Cuenta creada con éxito", "OK");
        await Navigation.PushAsync(new MenuPage());
    }
}