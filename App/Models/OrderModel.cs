using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class OrderModel
    {
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
