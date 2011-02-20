using System.Collections.Generic;
using StringCalculator;

namespace StringCalculatorTests
{
    public class StringCalculator
    {
        private IConversorCadenaToNumeros Conversor { get; set; }
        public StringCalculator(IConversorCadenaToNumeros conversor)
        {
            Conversor = conversor;
        }

        public int Add(string cadena)
        {
            if (string.IsNullOrEmpty(cadena)) return 0;
            
            int resultado = 0;
            Conversor.ObtenerNumeros(cadena).ForEach(x => resultado += x);

            return resultado;
        }
    }
}