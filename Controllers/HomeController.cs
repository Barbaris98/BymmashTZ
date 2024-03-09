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
        public int Index(int number_D, int number__d, int number_H, int number_Pripysk_d,
            int number_Dopysk_delta)
        {
            const decimal pi = 3.14M;
            const decimal Yd_ves = 0.0000000078M;

            decimal H_Zagotovki = Convert.ToDecimal(number_H + number_Pripysk_d);
            decimal D_Zagotovki = Convert.ToDecimal(number_D + number_Pripysk_d);
            decimal d_Zagotovki = Convert.ToDecimal(number__d - number_Pripysk_d);

            decimal Radius_pokovki_Nominal = Convert.ToDecimal(D_Zagotovki/2);
            decimal Radius_pokovki_MAX = Convert.ToDecimal(D_Zagotovki/2 + number_Dopysk_delta);
            decimal Radius_pokovki_MIN = Convert.ToDecimal(D_Zagotovki/2 - number_Dopysk_delta);

            decimal Radius_OTV_pokovki_Nominal = Convert.ToDecimal(d_Zagotovki/2);
            decimal Radius_OTV_pokovki_MAX = Convert.ToDecimal(d_Zagotovki/2 + number_Dopysk_delta);
            decimal Radius_OTV_pokovki_MIN = Convert.ToDecimal(d_Zagotovki/2 - number_Dopysk_delta);

            decimal Obem_Zagotovki_MAX = pi * (Radius_pokovki_MAX * Radius_pokovki_MAX) * H_Zagotovki;
            decimal Obem_Zagotovki_MIN = pi * (Radius_pokovki_MIN * Radius_pokovki_MIN) * H_Zagotovki;

            decimal Obem_OTV_Zagotovki_MAX = pi * (Radius_OTV_pokovki_MAX * Radius_OTV_pokovki_MAX) * H_Zagotovki;
            decimal Obem_OTV_Zagotovki_MIN = pi * (Radius_OTV_pokovki_MIN * Radius_OTV_pokovki_MIN) * H_Zagotovki;

            decimal Massa_zagotovki_MAX = Yd_ves * Obem_Zagotovki_MAX;
            decimal Massa_zagotovki_MIN = Yd_ves * Obem_Zagotovki_MIN;

            decimal Massa_OTV_zagotovki_MAX = Yd_ves * Obem_OTV_Zagotovki_MAX;
            decimal Massa_OTV_zagotovki_MIN = Yd_ves * Obem_OTV_Zagotovki_MIN;

            return number_D;

        }

    }
}
