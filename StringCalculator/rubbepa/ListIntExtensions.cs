using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class ListIntExtensions
    {
        public static string ToStringComa(this List<int> numeros)
        {
            string resultado = string.Empty;
            numeros.ForEach(x => resultado += ", " + x);

            if (resultado != string.Empty) return resultado.Substring(2);
            return resultado;
        }

        public static List<int> GetNegativos(this List<int> numeros)
        {
            return numeros.Where(numero => numero < 0).ToList();
        }

        public static bool HayNegativos(this List<int> numeros)
        {
            return GetNegativos(numeros).Count > 0;
        }
    }
}
