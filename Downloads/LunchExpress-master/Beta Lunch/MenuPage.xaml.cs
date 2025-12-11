using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Beta_Lunch.Models;

namespace Beta_Lunch;

public partial class MenuPage : ContentPage
{
    private List<FoodItem> productos;

    public MenuPage()
    {
        InitializeComponent();
        CargarProductos();
        MostrarProductos();
    }

    private void CargarProductos()
    {
        productos = new List<FoodItem>
        {
            new FoodItem { Name = "Sandwich", Price = 28, Image = "sandwich.png" },
            new FoodItem { Name = "Hamburguesa", Price = 45, Image = "hamburguesa.png" },
            new FoodItem { Name = "Quesadillas", Price = 30, Image = "quesadillas.png" },
            new FoodItem { Name = "Doritos", Price = 18, Image = "doritos.png" },
            new FoodItem { Name = "Coca-Cola", Price = 20, Image = "coca.png" },
            new FoodItem { Name = "Churrumais", Price = 15, Image = "churrumais.png" },
            new FoodItem { Name = "Agua", Price = 16, Image = "agua.png" },
            new FoodItem { Name = "Galletas Emperador", Price = 17, Image = "galletas_emperador.png" },
            new FoodItem { Name = "Arizona", Price = 25, Image = "arizona.png" }
        };
    }

    private void MostrarProductos()
    {
        FoodList.Children.Clear();

        foreach (var item in productos)
        {
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
                    new ColumnDefinition { Width = 140 }
                }
            };

            // Info
            var info = new VerticalStackLayout
            {
                Spacing = 4
            };

            info.Children.Add(new Label { Text = item.Name, FontSize = 20, TextColor = Colors.Black });
            info.Children.Add(new Label { Text = $"${item.Price:F2}", FontSize = 14, TextColor = Colors.Black });

            // Cantidad
            var minusBtn = new Button { Text = "-", WidthRequest = 40, HeightRequest = 40 };
            var plusBtn = new Button { Text = "+", WidthRequest = 40, HeightRequest = 40 };

            var qtyLabel = new Label
            {
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BindingContext = item,
                TextColor = Colors.Black
            };

            qtyLabel.SetBinding(Label.TextProperty, nameof(FoodItem.Quantity));

            minusBtn.Clicked += (s, e) => { CambiarCantidad(item, -1); };
            plusBtn.Clicked += (s, e) => { CambiarCantidad(item, +1); };

            var qtyLayout = new HorizontalStackLayout
            {
                Spacing = 8,
                Children = { minusBtn, qtyLabel, plusBtn },
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            layout.Add(info, 0, 0);
            layout.Add(qtyLayout, 1, 0);

            frame.Content = layout;
            FoodList.Children.Add(frame);
        }
    }

    private void CambiarCantidad(FoodItem item, int delta)
    {
        item.Quantity += delta;
        if (item.Quantity < 0)
            item.Quantity = 0;

        MostrarProductos(); // refrescar UI
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        var seleccionados = productos.Where(x => x.Quantity > 0).ToList();

        if (seleccionados.Count == 0)
        {
            await DisplayAlert("Sin selección", "Selecciona algún producto.", "OK");
            return;
        }

        await Navigation.PushAsync(new OrdenarPage(seleccionados));
    }
}
