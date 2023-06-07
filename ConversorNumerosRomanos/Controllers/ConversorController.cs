using Microsoft.AspNetCore.Mvc;
using ConversorNumerosRomanos.Utils;
using ConversorNumerosRomanos.Entidades;

namespace ConversorNumerosRomanos.Controllers
{
    public class ConversorController : Controller
    {

        public funcoes f = new funcoes();

        public bool conveter = false;

        

        public IActionResult Index()
        {

            return View("Conversor");
        }

        public int CRomainToArabic(string number) {

            var numToArabic = f.ConvertRomainNumberToArabic(number);

            return numToArabic;

        }
        public string CArabicToRomano(double number) {

            var numToRomano = f.ConverterRomano(number);

            return numToRomano;


        }

        public IActionResult Convert ()
        {
            try { 
                conveter = true;

                string romainNumber = "";

                double arabicNumber = 0;

                if(conveter)
                {

                    var romainToArabic = CRomainToArabic(romainNumber);

                    var arabicToRomain = CArabicToRomano(arabicNumber);

                    ViewBag.romainNumber = arabicToRomain;

                    ViewBag.arabicNumber = romainToArabic;

                    ViewBag.conveter = conveter;

                    conveter = false;

            }

                return RedirectToAction(nameof(Index));

            } catch (Exception ex)
            {
                return View("Conversor");
            }
        }

        [HttpPost]
        public ActionResult Create (IFormCollection collection, Conversao conversao) {

            try
            {

                var valor = conversao.VAlor;
                var escolha = collection["romano"].ToString();
                

                if(System.Convert.ToBoolean(escolha))
                {
                    conversao.Resultado = f.ConvertRomainNumberToArabic(valor.ToString()).ToString();                   

                }
                else
                {
                    conversao.Resultado = f.ConverterRomano(double.Parse(valor.ToString())).ToString();
                    
                }

                return View("Conversor", conversao);

            }
            catch (Exception ex)
            {

                return View("Conversor");

            }

        }
    }
}
