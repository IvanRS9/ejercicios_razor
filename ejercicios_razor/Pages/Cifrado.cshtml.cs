using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace ejercicios_razor.Pages
{
    public class CifradoModel : PageModel
    {
        [BindProperty]
        public string Texto { get; set; }
        [BindProperty]
        public int Desplazamiento { get; set; }
        public string TextoCifrado { get; set; }
        [BindProperty]
        public string TextoCifradoN { get; set; }
        [BindProperty]
        public int DesplazamientoDescifradoN { get; set; }
        public string TextoDescifradoN { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            TextoCifrado = Cifrar(Texto, Desplazamiento);
        }

        private string Cifrar(string texto, int desplazamiento)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    char letra = (char)(c + desplazamiento);
                    if (char.IsUpper(c) && letra > 'Z' || char.IsLower(c) && letra > 'z')
                    {
                        letra = (char)(letra - 26);
                    }
                    sb.Append(letra);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public void OnPostDescifrar()
        {
			TextoDescifradoN = Descifrar(TextoCifradoN, DesplazamientoDescifradoN);
		}

        private string Descifrar(string texto, int desplazamiento)
        {
			StringBuilder sb = new StringBuilder();
			foreach (char c in texto)
            {
				if (char.IsLetter(c))
                {
					char letra = (char)(c - desplazamiento);
					if (char.IsUpper(c) && letra < 'A' || char.IsLower(c) && letra < 'a')
                    {
						letra = (char)(letra + 26);
					}
					sb.Append(letra);
				}
				else
                {
					sb.Append(c);
				}
			}
			return sb.ToString();
		}
    }
}
