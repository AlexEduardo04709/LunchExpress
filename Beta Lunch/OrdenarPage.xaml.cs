using Microsoft.Maui.Controls;
using Beta_Lunch.Models;
using System.Collections.Generic;
using System.Linq;

namespace Beta_Lunch;

public partial class OrdenarPage : ContentPage
{
    private List<FoodItem> seleccionados;

    public OrdenarPage(List<FoodItem> productosSeleccionados)
    {
        InitializeComponent();
        seleccionados = productosSeleccionados;

        MostrarResumen();
    }

    private void MostrarResumen()
    {
        ResumenList.Children.Clear();

        double total = 0;

        foreach (var item in seleccionados)
        {
            double subtotal = item.Price * item.Quantity;
            total += subtotal;

            var frame = new Frame
            {
                CornerRadius = 10,
                Padding = 10,
                BackgroundColor = Colors.LightGray,
                HasShadow = false
            };

            var layout = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = 120 }
                }
            };

            var info = new VerticalStackLayout();
            info.Children.Add(new Label
            {
                Text = item.Name,
                FontSize = 20,
                TextColor = Colors.Black
            });
            info.Children.Add(new Label
            {
                Text = $"{item.Quantity} × ${item.Price}",
                TextColor = Colors.Black
            });

            var subtotalLabel = new Label
            {
                Text = $"${subtotal:F2}",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Colors.Black
            };

            layout.Add(info, 0, 0);
            layout.Add(subtotalLabel, 1, 0);

            frame.Content = layout;
            ResumenList.Children.Add(frame);
        }

        TotalLabel.Text = $"Total: ${total:F2}";
    }

    private async void OnFinishClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Pedido realizado", "Tu pedido está listo.", "OK");

        // ?? Aquí cambias para regresar al menú en vez del login
        await Navigation.PopToRootAsync(); // Si el menú es la primera pantalla

        // Si el menú NO es la primera pantalla:
        // await Navigation.PushAsync(new MenuPage());
    }
}
