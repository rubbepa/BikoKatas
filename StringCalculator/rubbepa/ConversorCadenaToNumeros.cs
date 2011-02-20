using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class ConversorCadenaToNumeros : IConversorCadenaToNumeros
    {
        private static string INICIO_SEPARADOR_PERSONALIZADO = "//";
        private static string INICIO_SEPARADOR_COMPLEJO = "[";
        private static string FIN_SEPARADOR_COMPLEJO = "]";
        private static string FIN_ZONA_SEPARADORES = "\n";

        public List<int> ObtenerNumeros(string cadena)
        {
            List<int> numerosParseados = new List<int>();

            TrocearCadena(cadena).ForEach(
                numeroSinParsear => numerosParseados.Add(int.Parse(numeroSinParsear)));

            return numerosParseados;
        }

        private List<string> TrocearCadena(string cadena)
        {
            List<string> separadores = ObtenerSeparadores(cadena);

            if (HaySeparadoresPersonalizados(cadena))
            {
                cadena = EliminarDeclaracionDeSeparadores(cadena);
            }
            return new List<string>(
                cadena.Split(separadores.ToArray(), StringSplitOptions.RemoveEmptyEntries));
        }

        private List<string> ObtenerSeparadores(string cadena)
        {
            List<string> separadores = new List<string> {",", "\n"};
            if (HaySeparadoresPersonalizados(cadena))
            {
                separadores.AddRange(ObtenerSeparadoresPersonalizados(cadena));
            }
            return separadores;
        }

        private bool HaySeparadoresPersonalizados(string cadena)
        {
            return cadena.StartsWith(INICIO_SEPARADOR_PERSONALIZADO);
        }

        private List<string> ObtenerSeparadoresPersonalizados(string cadena)
        {
            if (HaySeparadorComplejo(cadena))
            {
                return ObtenerSeparadoresComplejos(cadena);
            }
            return ObtenerSeparadorSimple(cadena);
        }

        private bool HaySeparadorComplejo(string cadena)
        {
            return cadena.StartsWith(INICIO_SEPARADOR_PERSONALIZADO + INICIO_SEPARADOR_COMPLEJO);
        }
        
        private List<string> ObtenerSeparadorSimple(string cadena)
        {
            return new List<string> { cadena[2].ToString() };
        }

        private List<string> ObtenerSeparadoresComplejos(string cadena)
        {
            string separadores = cadena.Substring(2, cadena.IndexOf(FIN_ZONA_SEPARADORES) - 2);

            return new List<string>(
                separadores.Split(
                    new[] { INICIO_SEPARADOR_COMPLEJO, FIN_SEPARADOR_COMPLEJO },
                    StringSplitOptions.RemoveEmptyEntries));
        }

        private string EliminarDeclaracionDeSeparadores(string cadena)
        {
             return cadena.Substring(cadena.IndexOf("\n") + 1);
        }
    }
}