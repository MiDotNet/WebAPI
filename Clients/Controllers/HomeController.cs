using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Clients.Models;

namespace Clients.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:9803/api/complex");
            var result = await response.Content.ReadAsAsync<IEnumerable<SomeDTO>>();
            return View(result);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:9803/api/complex/{id}");
            var result = await response.Content.ReadAsAsync<SomeDTO>();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, SomeDTO data)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync($"http://localhost:9803/api/complex/{id}", data);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync($"http://localhost:9803/api/complex/{id}");

            return RedirectToAction("Index");
        }
    }
}