using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios_razor.Pages
{
    public class AleatoriosModel : PageModel
    {
        public List<int> Numeros { get; set; }
        public int Suma { get; set; }
        public double Media { get; set; }
        public List<int> NumerosOrdenados { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }

        public void OnGet()
        {
            // Generar números aleatorios
            Random random = new Random();
            Numeros = Enumerable.Range(1, 20).Select(x => random.Next(0, 101)).ToList();

            // Calcular la suma
            Suma = Numeros.Sum();

            // Calcular la media
            Media = Numeros.Average();

            // Ordenar los números
            NumerosOrdenados = Numeros.OrderBy(n => n).ToList();

            // Calcular la moda
            var moda = Numeros.GroupBy(n => n)
                               .OrderByDescending(g => g.Count())
                               .First();
            Moda = moda.Select(n => n).ToList();

            // Calcular la mediana
            int cantidadNumeros = Numeros.Count;
            Mediana = cantidadNumeros % 2 == 0 ?
                      (NumerosOrdenados[cantidadNumeros / 2 - 1] + NumerosOrdenados[cantidadNumeros / 2]) / 2.0 :
                      NumerosOrdenados[cantidadNumeros / 2];
        }
    }
}
