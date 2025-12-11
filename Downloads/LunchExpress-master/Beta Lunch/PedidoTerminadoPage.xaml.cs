namespace Beta_Lunch;

public partial class PedidoTerminadoPage : ContentPage
{
    public PedidoTerminadoPage()
    {
        InitializeComponent();
    }

    private async void OnIrEnCaminoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PedidoEnCaminoPage");
    }
}
