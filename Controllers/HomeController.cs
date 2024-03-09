using Microsoft.AspNetCore.Mvc;

namespace BymmashTZ.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int Index(int number_D, int number_d, int number_H, int number_Pripysk_b,
            int number_Dopysk_delta)
        {
            int H_Zagotovki = number_H + number_Pripysk_b;


            int number3 = number_H + number_Pripysk_b;

            return number3;

        }

    }
}
