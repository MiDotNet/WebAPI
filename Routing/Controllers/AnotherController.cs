using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Routing.Controllers
{
    [RoutePrefix("api/Letters")]
    public class AnotherController : ApiController
    {
        [HttpGet]
        [Route("ABC/{count:int:min(1):max(26)}")]
        public IEnumerable<char> ABC(int count)
        {
            return Enumerable.Range(1, count).Select(x => Convert.ToChar(64 + x));
        }
    }
}
