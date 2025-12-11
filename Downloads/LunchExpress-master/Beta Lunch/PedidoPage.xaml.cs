using Beta_Lunch.Models;

namespace Beta_Lunch;

public partial class PedidoPage : ContentPage
{
    private double progressValue = 0;
    private CancellationTokenSource cts;

    public PedidoPage(List<FoodItem> items)
    {
        InitializeComponent();
        IniciarProgreso();
    }

    private async void IniciarProgreso()
    {
        cts = new CancellationTokenSource();

        while (progressValue < 1)
        {
            await Task.Delay(300); // velocidad del progreso

            progressValue += 0.1;
            OrderProgress.Progress = progressValue;

            EstadoLabel.Text = progressValue switch
            {
                < 0.3 => "Preparando tu comida...",
                < 0.6 => "Cocinando...",
                < 0.9 => "Casi está listo...",
                _ => "Pedido listo."
            };
        }

        ContinueButton.IsEnabled = true;
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PedidoTerminadoPage());
    }
}
