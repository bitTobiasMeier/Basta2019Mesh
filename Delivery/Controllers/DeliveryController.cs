using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Delivery.Controllers
{
    [Route("api/[controller]")]
    public class DeliveryController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 delivery", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value delivery";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Order order)
        {
            var msg = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ": Delivery: " + order.Quantity +" * " + 
                order.Item +" zu " + order.Price;

            System.Diagnostics.Debug.WriteLine(msg);
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
