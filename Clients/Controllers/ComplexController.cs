using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clients.Models;

namespace Clients.Controllers
{
    public class ComplexController : ApiController
    {
        private static List<SomeDTO> database = new List<SomeDTO>() { new SomeDTO() {Id = 1, Name = "First", MoreInfo = new List<string>() {"Testing"} },
                                                                      new SomeDTO() {Id = 2, Name = "Second", MoreInfo = new List<string>() {"Testing", "Again"} }};

        // GET: api/Complex
        public IEnumerable<SomeDTO> Get()
        {
            return database;
        }

        // GET: api/Complex/5
        public SomeDTO Get(int id)
        {
            return database.SingleOrDefault(x => x.Id == id);
        }

        // POST: api/Complex
        public HttpResponseMessage Post(SomeDTO value)
        {
            if (database.Any(x => x.Id == value.Id))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The provided Id is already in use.");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            database.Add(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Complex/5
        public IHttpActionResult Put(int id, SomeDTO value)
        {
            var existing = database.SingleOrDefault(x => x.Id == id);
            if (existing != null)
            {
                existing.Name = value.Name;
                existing.MoreInfo = value.MoreInfo;
            }

            return Ok();
        }

        // DELETE: api/Complex/5
        public IHttpActionResult Delete(int id)
        {
            var existing = database.SingleOrDefault(x => x.Id == id);
            if (existing != null)
            {
                database.Remove(existing);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
