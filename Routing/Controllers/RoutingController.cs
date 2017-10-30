using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Routing.Controllers
{
    public class RoutingController : ApiController
    {
        private static int count = 10;

        [HttpGet]
        public IEnumerable<int> GetNumbers()
        {
            return Enumerable.Range(1, count);
        }

        [HttpPost]
        public void UpdateCount([FromBody]int value)
        {
            count = value;
        }

        [AcceptVerbs("Get", "Post")]
        public IEnumerable<int> UpdateAndGetNumbers([FromBody]int value)
        {
            if (value > 0)
            {
                UpdateCount(value);
            }
            return GetNumbers();
        }

        [HttpGet]
        [Route("api/Routing/GetTen")]
        public IEnumerable<int> BadMethodName()
        {
            return Enumerable.Range(1, 10);
        }
    }
}
