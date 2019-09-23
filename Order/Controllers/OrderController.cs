﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderController.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
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
        public async void Post([FromBody]Order order)
        {
            System.Diagnostics.Debug.WriteLine(order.Quantity + "*" + order.Item + " zu " + order.Price);
            using (var client = new HttpClient())
            {
                try {
                    await client.PostAsJsonAsync("http://delivery.basta2019mesh/api/Delivery/", order);
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

    public class Order
    {
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}