using System;
using System.Collections.Generic;
using StringCalculator;
using System.Linq;

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
           
            List<int> operandos = Conversor.ObtenerNumeros(cadena);

            LanzarErrorSiHayNumerosNegativos(operandos);
            operandos = IgnorarOperandosNoPermitidos(operandos);

            return Sumar(operandos);
        }

        private int Sumar(List<int> operandos)
        {
            int resultado = 0;
            operandos.ForEach(x => resultado += x);
            return resultado;
        }

        private List<int> IgnorarOperandosNoPermitidos(IEnumerable<int> operandos)
        {
            return operandos.Where(operando => operando <= 1000).ToList();
        }
        
        private void LanzarErrorSiHayNumerosNegativos(List<int> numerosParseados)
        {
            if (numerosParseados.HayNegativos())
            {
                throw new Exception(
                    "negatives not allowed: " + numerosParseados.GetNegativos().ToStringComa());
            }
        }
    }
}