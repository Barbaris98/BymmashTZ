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
        public IActionResult Index(int number_D, int number__d, int number_H, int number_Pripysk_d,
            int number_Dopysk_delta)
        {
            const decimal pi = 3.14M;
            const decimal Yd_ves = 0.0000000078M;

            // считаем припуск 
            decimal H_Zagotovki_Nominal = Convert.ToDecimal(number_H + number_Pripysk_d);
            decimal H_Zagotovki_MAX = Convert.ToDecimal(number_H + number_Pripysk_d + number_Dopysk_delta);
            decimal H_Zagotovki_MIN = Convert.ToDecimal(number_H + number_Pripysk_d - number_Dopysk_delta);

            decimal D_Zagotovki_Nominal = Convert.ToDecimal(number_D + number_Pripysk_d);
            decimal D_Zagotovki_MAX = Convert.ToDecimal(number_D + number_Pripysk_d + number_Dopysk_delta);
            decimal D_Zagotovki_MIN = Convert.ToDecimal(number_D + number_Pripysk_d - number_Dopysk_delta);

            decimal d__Zagotovki_Nominal = Convert.ToDecimal(number__d - number_Pripysk_d);
            decimal d__Zagotovki_MAX = Convert.ToDecimal((number__d - number_Pripysk_d) - number_Dopysk_delta);
            decimal d__Zagotovki_MIN = Convert.ToDecimal(number__d + number_Pripysk_d + number_Dopysk_delta);

            decimal Radius_pokovki_Nominal = Convert.ToDecimal(D_Zagotovki_Nominal / 2);
            decimal Radius_pokovki_MAX = Convert.ToDecimal(D_Zagotovki_MAX / 2);
            decimal Radius_pokovki_MIN = Convert.ToDecimal(D_Zagotovki_MIN / 2);

            decimal Radius_OTV_pokovki_Nominal = Convert.ToDecimal(d__Zagotovki_Nominal / 2);
            decimal Radius_OTV_pokovki_MAX = Convert.ToDecimal(d__Zagotovki_MAX / 2);
            decimal Radius_OTV_pokovki_MIN = Convert.ToDecimal(d__Zagotovki_MIN / 2);

            decimal Obem_Zagotovki_Nominal = pi * (Radius_pokovki_Nominal * Radius_pokovki_Nominal) * H_Zagotovki_Nominal;
            decimal Obem_Zagotovki_MAX = pi * (Radius_pokovki_MAX * Radius_pokovki_MAX) * H_Zagotovki_MAX;
            decimal Obem_Zagotovki_MIN = pi * (Radius_pokovki_MIN * Radius_pokovki_MIN) * H_Zagotovki_MIN;

            decimal Obem_OTV_Zagotovki_Nominal = pi * (Radius_OTV_pokovki_Nominal * Radius_OTV_pokovki_Nominal) * H_Zagotovki_Nominal;
            decimal Obem_OTV_Zagotovki_MAX = pi * (Radius_OTV_pokovki_MAX * Radius_OTV_pokovki_MAX) * H_Zagotovki_MAX;
            decimal Obem_OTV_Zagotovki_MIN = pi * (Radius_OTV_pokovki_MIN * Radius_OTV_pokovki_MIN) * H_Zagotovki_MIN;

            decimal Massa_zagotovki_Nominal = Yd_ves * Obem_Zagotovki_Nominal;
            decimal Massa_zagotovki_MAX = Yd_ves * Obem_Zagotovki_MAX;
            decimal Massa_zagotovki_MIN = Yd_ves * Obem_Zagotovki_MIN;

            decimal Massa_OTV_zagotovki_Nominal = Yd_ves * Obem_OTV_Zagotovki_Nominal;
            decimal Massa_OTV_zagotovki_MAX = Yd_ves * Obem_OTV_Zagotovki_MAX;
            decimal Massa_OTV_zagotovki_MIN = Yd_ves * Obem_OTV_Zagotovki_MIN;

            decimal Massa_zagotovki_Obshaya_Nominal = Massa_zagotovki_Nominal - Massa_OTV_zagotovki_Nominal;
            decimal Massa_zagotovki_Obshaya_MAX = Massa_zagotovki_MAX - Massa_OTV_zagotovki_MAX;
            decimal Massa_zagotovki_Obshaya_MIN = Massa_zagotovki_MIN - Massa_OTV_zagotovki_MIN;

            //сферичность
            decimal Sverichnost_Nominal = (0.000000393M * (((D_Zagotovki_Nominal - d__Zagotovki_Nominal) +
                (number_Pripysk_d * 2)) * (pi * Radius_pokovki_Nominal * Radius_pokovki_Nominal))) / 10000;

            decimal Sverichnost_MIN = (0.000000393M * (((D_Zagotovki_MIN - d__Zagotovki_MIN) +
                (number_Pripysk_d * 2)) * (pi * Radius_pokovki_MIN * Radius_pokovki_MIN))) / 10000;

            decimal Sverichnost_MAX = (0.000000393M * (((D_Zagotovki_MAX - d__Zagotovki_MAX) +
                (number_Pripysk_d * 2)) * (pi * Radius_pokovki_MAX * Radius_pokovki_MAX))) / 10000;

            // Масса общая с учёт сверичности

            decimal Massa_zagotovki_Obshaya_Sverich_Nominal = Sverichnost_Nominal + Massa_zagotovki_Obshaya_Nominal;
            decimal Massa_zagotovki_Obshaya_Sverich_MAX = Sverichnost_MAX + Massa_zagotovki_Obshaya_MAX;
            decimal Massa_zagotovki_Obshaya_Sverich_MIN = Sverichnost_MIN + Massa_zagotovki_Obshaya_MIN;

            ViewBag.D_Zagotovki_MIN = D_Zagotovki_MIN;
            ViewBag.D_Zagotovki_Nominal = D_Zagotovki_Nominal;
            ViewBag.D_Zagotovki_MAX = D_Zagotovki_MAX;

            ViewBag.d__Zagotovki_MIN = d__Zagotovki_MIN;
            ViewBag.d__Zagotovki_Nominal = d__Zagotovki_Nominal;
            ViewBag.d__Zagotovki_MAX = d__Zagotovki_MAX;

            ViewBag.Radius_pokovki_MIN = Radius_pokovki_MIN;
            ViewBag.Radius_pokovki_Nominal = Radius_pokovki_Nominal;
            ViewBag.Radius_pokovki_MAX = Radius_pokovki_MAX;

            ViewBag.Radius_OTV_pokovki_MIN = Radius_OTV_pokovki_MIN;
            ViewBag.Radius_OTV_pokovki_Nominal = Radius_OTV_pokovki_Nominal;
            ViewBag.Radius_OTV_pokovki_MAX = Radius_OTV_pokovki_MAX;
           
            ViewBag.H_Zagotovki_MIN = H_Zagotovki_MIN;
            ViewBag.H_Zagotovki_Nominal = H_Zagotovki_Nominal;
            ViewBag.H_Zagotovki_MAX = H_Zagotovki_MAX;
            /////////////////////////////////////////////
            ViewBag.Obem_Zagotovki_MIN = Obem_Zagotovki_MIN;
            ViewBag.Obem_Zagotovki_Nominal = Obem_Zagotovki_Nominal;
            ViewBag.Obem_Zagotovki_MAX = Obem_Zagotovki_MAX;

            ViewBag.Obem_OTV_Zagotovki_MIN = Obem_OTV_Zagotovki_MIN;
            ViewBag.Obem_OTV_Zagotovki_Nominal = Obem_OTV_Zagotovki_Nominal;
            ViewBag.Obem_OTV_Zagotovki_MAX = Obem_OTV_Zagotovki_MAX;


            ViewBag.Massa_zagotovki_MIN = Massa_zagotovki_MIN;
            ViewBag.Massa_zagotovki_Nominal = Massa_zagotovki_Nominal;
            ViewBag.Massa_zagotovki_MAX = Massa_zagotovki_MAX;

            ViewBag.Massa_OTV_zagotovki_MIN = Massa_OTV_zagotovki_MIN;
            ViewBag.Massa_OTV_zagotovki_Nominal = Massa_OTV_zagotovki_Nominal;
            ViewBag.Massa_OTV_zagotovki_MAX = Massa_OTV_zagotovki_MAX;

            ViewBag.Massa_zagotovki_Obshaya_MIN = Massa_zagotovki_Obshaya_MIN;
            ViewBag.Massa_zagotovki_Obshaya_Nominal = Massa_zagotovki_Obshaya_Nominal;
            ViewBag.Massa_zagotovki_Obshaya_MAX = Massa_zagotovki_Obshaya_MAX;

            //
            ViewBag.Sverichnost_Nominal = Sverichnost_Nominal;
            ViewBag.Sverichnost_MIN = Sverichnost_MIN;
            ViewBag.Sverichnost_MAX = Sverichnost_MAX;

            ViewBag.Massa_zagotovki_Obshaya_Sverich_MIN = Massa_zagotovki_Obshaya_Sverich_MIN;
            ViewBag.Massa_zagotovki_Obshaya_Sverich_Nominal = Massa_zagotovki_Obshaya_Sverich_Nominal;
            ViewBag.Massa_zagotovki_Obshaya_Sverich_MAX = Massa_zagotovki_Obshaya_Sverich_MAX;

            return View("Rezult");
            //return Redirect("Home/Rezult");

        }

        [HttpGet]
        public IActionResult Rezult()
        {
            return View();
        }

    }
}
