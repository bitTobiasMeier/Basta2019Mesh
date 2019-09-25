using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Order.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderController.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var svcname = Environment.GetEnvironmentVariable("DeliveryServiceName");
                    var response = await client.GetAsync("http://" + svcname + "/api/Delivery/");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<string[]>(jsonString);
                    return obj;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async void Post([FromBody]OrderModel order)
        {
            System.Diagnostics.Debug.WriteLine(order.Quantity + "*" + order.Item + " zu " + order.Price);
            using (var client = new HttpClient())
            {
                try {
                    var svcname = Environment.GetEnvironmentVariable("DeliveryServiceName");
                    await client.PostAsJsonAsync("http://" + svcname + "/api/Delivery/", order);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

 
}
