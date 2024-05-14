using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios_razor.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }
        [BindProperty]
        public string Altura { get; set; }
        public double IMC { get; set; }
        public double Op { get; set; }
        public string Clasificacion { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Op = float.Parse(Altura) * float.Parse(Altura);
            IMC = Math.Round(Peso / Op, 2);

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
                Clasificacion = "Sobrepeso";
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
