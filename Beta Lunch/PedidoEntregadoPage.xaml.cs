namespace Beta_Lunch;

public partial class PedidoEntregadoPage : ContentPage
{
    public PedidoEntregadoPage()
    {
        InitializeComponent();
    }

    private async void OnVolverInicioClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//HomePage");
    }
}