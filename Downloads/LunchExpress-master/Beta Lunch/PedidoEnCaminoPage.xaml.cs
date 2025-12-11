namespace Beta_Lunch;

public partial class PedidoEnCaminoPage : ContentPage
{
    public PedidoEnCaminoPage()
    {
        InitializeComponent();
    }

    private async void OnIrEntregadoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PedidoEntregadoPage");
    }
}