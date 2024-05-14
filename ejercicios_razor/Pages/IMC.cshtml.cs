using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios_razor.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }
        [BindProperty]
        public double Altura { get; set; }
        public double IMC { get; set; }
        public string Clasificacion { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            IMC = Math.Round(Peso / (Altura * Altura), 2);

            if (IMC < 18)
            {
                Clasificacion = "Peso Bajo";
            }
            else if (IMC < 25)
            {
                Clasificacion = "Peso Normal";
            }
            else if (IMC < 27)
            {
                Clasificacion = "Sobre Peso";
            }
            else if (IMC < 30)
            {
                Clasificacion = "Obesidad grado 1";
            }
            else if (IMC < 40)
            {
                Clasificacion = "Obesidad grado 2";
            }
            else
            {
                Clasificacion = "Obesidad grado 3";
            }
        }

    }
}
