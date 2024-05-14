using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios_razor.Pages
{
    public class IgualdadModel : PageModel
    {
        [BindProperty]
        public int a { get; set; }
        [BindProperty]
        public int x { get; set; }
        [BindProperty]
        public int b { get; set; }
        [BindProperty]
        public int y { get; set; }
        [BindProperty]
        public int n { get; set; }
        public double? Resultado { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Resultado = CalcularExpresion(a, x, b, y, n);
        }

        private double CalcularExpresion(int a, int x, int b, int y, int n)
        {
            double resultado = 0;

            for (int k = 0; k <= n; k++)
            {
                resultado += BinomialCoefficient(n, k) * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }

            return resultado;
        }

        private int BinomialCoefficient(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }
            else
            {
                return Factorial(n) / (Factorial(k) * Factorial(n - k));
            }
        }

        private int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
