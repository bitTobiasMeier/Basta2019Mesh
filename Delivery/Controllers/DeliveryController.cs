using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Delivery.Controllers
{
    [Route("api/[controller]")]
    public class DeliveryController : Controller
    {
        private readonly static string filename = @"c:\app\data\deliveryorders.txt";
        public DeliveryController()
        {
            string dir = Path.GetDirectoryName(filename);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!System.IO.File.Exists(filename))
            {
                System.IO.File.AppendAllText(filename, "Deliverylist" + Environment.NewLine);
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var lines = System.IO.File.ReadAllLines(filename);
            return lines[id];
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Order order)
        {
            var msg = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ": Delivery: " + order.Quantity +" * " + 
                order.Item +" zu " + order.Price;
            System.Diagnostics.Debug.WriteLine(msg);
            System.IO.File.AppendAllText(filename, msg + Environment.NewLine);
                
            
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
