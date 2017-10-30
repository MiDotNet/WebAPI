using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;

namespace Complex.Controllers
{
    public class ComplexController : ApiController
    {
        private static List<SomeDTO> database = new List<SomeDTO>();

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
        public void Post(SomeDTO value)
        {
            database.Add(value);
        }

        // PUT: api/Complex/5
        public void Put(int id, SomeDTO value)
        {
            var existing = database.SingleOrDefault(x => x.Id == id);
            if (existing != null)
            {
                existing.Name = value.Name;
                existing.MoreInfo = value.MoreInfo;
            }
        }

        // DELETE: api/Complex/5
        public void Delete(int id)
        {
            var existing = database.SingleOrDefault(x => x.Id == id);
            if (existing != null)
            {
                database.Remove(existing);
            }
        }
    }

    public class SomeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<string> MoreInfo { get; set; }
    }
}
