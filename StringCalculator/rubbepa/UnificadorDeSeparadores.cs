using System.Collections.Generic;
using System;
using System.Linq;

namespace StringCalculator
{
    public class UnificadorDeSeparadores : IUnificadorDeSeparadores
    {
        private static string INICIO_SEPARADOR_PERSONALIZADO = "//";
        private static string INICIO_SEPARADOR_COMPLEJO = "[";
        private static string FIN_SEPARADOR_COMPLEJO = "]";

        public string UnificarSeparadores(string cadena)
        {
            if (HaySeparadoresPersonalizados(cadena))
            {
                List<string> separadoresPersonalizados = ObtenerSeparadoresPersonalizados(cadena);
                cadena = EliminarDeclaracionSeparadorPersonalizado(cadena);
                cadena = SustituirSeparadores(cadena, separadoresPersonalizados.ToArray());
            }
            cadena = SustituirSeparadores(cadena, "\n");
            return cadena;
        }

        private bool HaySeparadoresPersonalizados(string cadena)
        {
            return ObtenerSeparadoresPersonalizados(cadena) != null;
        }

        private List<string> ObtenerSeparadoresPersonalizados(string cadena)
        {
            if (!cadena.StartsWith(INICIO_SEPARADOR_PERSONALIZADO))
            {
                return null;
            }

            if (HaySeparadorComplejo(cadena))
            {
                return ObtenerSeparadoresComplejos(cadena);
            }
            return ObtenerSeparadorSimple(cadena);
        }

        private List<string> ObtenerSeparadorSimple(string cadena)
        {
            return new List<string> {cadena[2].ToString()};
        }

        private List<string> ObtenerSeparadoresComplejos(string cadena)
        {
            string definicionDeSeparadores = cadena.Substring(3, cadena.IndexOf("\n") - 4);
            return new List<string>(
                definicionDeSeparadores.Split(
                    new[] { FIN_SEPARADOR_COMPLEJO + INICIO_SEPARADOR_COMPLEJO }, 
                    StringSplitOptions.RemoveEmptyEntries));
        }

        private bool HaySeparadorComplejo(string cadena)
        {
            return cadena[2] == INICIO_SEPARADOR_COMPLEJO.ToCharArray()[0];
        }

        private string SustituirSeparadores(string cadena, params string[] separadores)
        {
            string resultado = cadena;
            foreach (string separador in separadores)
            {
                resultado = resultado.Replace(separador, ",");
            }
            return resultado;
        }

        private string EliminarDeclaracionSeparadorPersonalizado(string cadena)
        {
            return cadena.Substring(cadena.IndexOf("\n") + 1);
        }
    }
}
