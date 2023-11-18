using Microsoft.AspNetCore.Mvc;
using System.Net;
using YetGenAkbankJump.Domain.Entities;

namespace YetGenAkbankJump.MVCClient.Controllers
{
    public class CarsController : Controller
    {
        private readonly HttpClient _httpClient;

        public CarsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Cars");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(await response.Content.ReadFromJsonAsync<List<Car>>());
            }

            return NotFound();
        }
    }
}
