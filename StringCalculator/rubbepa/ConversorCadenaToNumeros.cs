using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class ConversorCadenaToNumeros : IConversorCadenaToNumeros
    {
        private IUnificadorDeSeparadores _unificador;
        public ConversorCadenaToNumeros(IUnificadorDeSeparadores unificador)
        {
            _unificador = unificador;
        }

        public List<int> ObtenerNumeros(string cadena)
        {
            List<int> numerosParseados = new List<int>();
            foreach (string numeroSinParsear in TrocearCadena(cadena))
            {
                int numeroParseado = int.Parse(numeroSinParsear);
                if (numeroParseado <= 1000)
                {
                    numerosParseados.Add(numeroParseado);
                }
            }
            LanzarErrorSiHayNumerosNegativos(numerosParseados);
            return numerosParseados;
        }

        private void LanzarErrorSiHayNumerosNegativos(List<int> numerosParseados)
        {
            if (numerosParseados.HayNegativos())
            {
                throw new Exception(
                    "negatives not allowed: " + numerosParseados.GetNegativos().ToStringComa());
            }
        }

        private List<string> TrocearCadena(string cadena)
        {
            cadena = _unificador.UnificarSeparadores(cadena);
            return new List<string>(cadena.Split(','));
        }
    }
}
