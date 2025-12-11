using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Beta_Lunch.Models
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 0;
    }

}
