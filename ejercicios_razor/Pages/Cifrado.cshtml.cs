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
			TextoCifrado = CifrarTexto(Texto, Desplazamiento);
		}

		private string CifrarTexto(string texto, int desplazamiento)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in texto)
			{
				switch (c)
				{
					case char letra when char.IsUpper(letra):
						sb.Append((char)(((letra - 'A' + desplazamiento) % 26) + 'A'));
						break;
					case char letra when char.IsLower(letra):
						sb.Append((char)(((letra - 'a' + desplazamiento) % 26) + 'a'));
						break;
					default:
						sb.Append(c);
						break;
				}
			}
			return sb.ToString();
		}

		public void OnPostDescifrar()
		{
			TextoDescifradoN = DescifrarTexto(TextoCifradoN, DesplazamientoDescifradoN);
		}

		private string DescifrarTexto(string texto, int desplazamiento)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in texto)
			{
				switch (c)
				{
					case char letra when char.IsUpper(letra):
						sb.Append((char)(((letra - 'A' - desplazamiento + 26) % 26) + 'A'));
						break;
					case char letra when char.IsLower(letra):
						sb.Append((char)(((letra - 'a' - desplazamiento + 26) % 26) + 'a'));
						break;
					default:
						sb.Append(c);
						break;
				}
			}
			return sb.ToString();
		}
	}
}
