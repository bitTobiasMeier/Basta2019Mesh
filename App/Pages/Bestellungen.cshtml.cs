using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace App.Pages
{
    public class BestellungenModel : PageModel
    {       
        private string[] items = { };

        [BindProperty]
        public string[] Items { get => items; set => items = value; }

        public async Task<IActionResult> OnGetAsync()
        {
           
            var svcname = Environment.GetEnvironmentVariable("orderservicename");
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://" + svcname + "/api/order");
                result.EnsureSuccessStatusCode();
                var jsonString = await result.Content.ReadAsStringAsync();
                this.Items = JsonConvert.DeserializeObject<string[]>(jsonString);
                return Page();
            }
        }
    }
}