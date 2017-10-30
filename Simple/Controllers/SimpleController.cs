using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Simple.Controllers
{
    public class SimpleController : ApiController
    {
        // GET: api/Simple
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Simple/5
        public string Get(int id)
        {
            return $"value{id}";
        }

        // POST: api/Simple
        public void Post([FromBody]string value)
        {
            Console.WriteLine($"Posted a value of {value}");
        }

        // PUT: api/Simple/5
        public void Put(int id, [FromBody]string value)
        {
            Console.WriteLine($"Put a value of {value} for id {id}");
        }

        // DELETE: api/Simple/5
        public void Delete(int id)
        {
            Console.WriteLine($"Delete id {id}");
        }
    }
}
