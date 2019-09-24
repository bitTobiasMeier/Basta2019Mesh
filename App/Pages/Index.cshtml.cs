using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Item { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var order = new Order() { Item = this.Item, Price = this.Price, Quantity = this.Quantity };

            System.Diagnostics.Debug.WriteLine("Bestellung: " + order.Item);
            var svcname = Environment.GetEnvironmentVariable("orderservicename");
            using (var client = new HttpClient())
            {
                var result = await client.PostAsJsonAsync("http://" + svcname +"/api/order", order);
                result.EnsureSuccessStatusCode();
                this.Message = "Bestellung wurde ausgeführt";
            }
            return this.Page();
        }
    }
}
