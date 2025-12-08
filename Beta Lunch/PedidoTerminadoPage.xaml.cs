namespace Beta_Lunch;

public partial class PedidoTerminadoPage : ContentPage
{
    public PedidoTerminadoPage()
    {
        InitializeComponent();
    }

    private async void OnOkClicked(object sender, EventArgs e)
    {
        // Regresa al menú
        await Navigation.PopToRootAsync();
    }
}
