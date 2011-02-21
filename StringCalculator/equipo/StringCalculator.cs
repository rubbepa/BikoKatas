using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLive
{
    public class StringCalculator
    {
        private const char INICIO_DELIMITADOR_COMPLEJO = '[';
        private const char FIN_DELIMITADOR_COMPLEJO = ']';
        private const string INICIO_ZONA_DELIMITADORES = "//";
        private const string FIN_ZONA_DELIMITADORES = "\n";

        public int Add(string sumandos)
        {
            if (string.IsNullOrEmpty(sumandos))
            {
                return 0;
            }

            List<int> listaNumeros = ConvertirCadenaExtraida(sumandos);

            ComprobarQueNoExistenNumerosNegativos(listaNumeros);

            listaNumeros = EliminarNumerosMayoresQue1000(listaNumeros);

            return SumaDeSumandos(listaNumeros);
        }

        private List<int> EliminarNumerosMayoresQue1000(List<int> listaNumeros)
        {
            listaNumeros = listaNumeros.Where(x => x <= 1000).ToList();
            return listaNumeros;
        }

        private void ComprobarQueNoExistenNumerosNegativos(List<int> listaNumeros)
        {
            
            List<int> numerosNegativos = listaNumeros.Where(x => x < 0).ToList();

           
            if (numerosNegativos.Count > 0)
            {
                throw new Exception(
                    "negatives not allowed: " + string.Join(",", numerosNegativos));
            }
        }

        private int SumaDeSumandos(List<int> listaNumeros)
        {
            int resultado = 0;
            foreach (int numero in listaNumeros)
            {
                    resultado = resultado + numero;
            }
            return resultado;
        }

        private List<int> ConvertirCadenaExtraida(string cadenaEnBruto)
        {
            List<string> delimitadores = new List<string>() {",", "\n"};

            if(ExisteDelimitadorPersonalizado(cadenaEnBruto))
            {
                delimitadores.Add(ObtenerDelimitadorPersonalizado(cadenaEnBruto));
                cadenaEnBruto = EliminarSeccionDeDelimitadores(cadenaEnBruto);
            }

            string[] numerosEnBruto = 
                cadenaEnBruto.Split(delimitadores.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            List<int> resultados = new List<int>();

            foreach (string numero in numerosEnBruto)
            {
                resultados.Add(int.Parse(numero));    
            }

            return resultados;
        }

        private string EliminarSeccionDeDelimitadores(string cadenaEnBruto)
        {
            cadenaEnBruto = cadenaEnBruto.Substring(cadenaEnBruto.IndexOf(FIN_ZONA_DELIMITADORES) + 1);
            return cadenaEnBruto;
        }

        private string ObtenerDelimitadorPersonalizado(string cadenaEnBruto)
        {
            if (ExisteDelimitadorPersonalizadoComplejo(cadenaEnBruto))
            {
                return ObtenerDelimitadoresPersonalizadosComplejos(cadenaEnBruto);    
            }
            return ObtenerDelimitadorSimple(cadenaEnBruto);

        }

        private bool ExisteDelimitadorPersonalizadoComplejo(string cadenaEnBruto)
        {
            return cadenaEnBruto.StartsWith(INICIO_ZONA_DELIMITADORES + INICIO_DELIMITADOR_COMPLEJO);
        }

        private string ObtenerDelimitadoresPersonalizadosComplejos(string cadenaEnBruto)
        {
            int inicioDelimitadorComplejo = cadenaEnBruto.IndexOf(INICIO_DELIMITADOR_COMPLEJO) + 1;
            int finDelimitadorComplejo = cadenaEnBruto.IndexOf(FIN_DELIMITADOR_COMPLEJO);

            return cadenaEnBruto.Substring(
                inicioDelimitadorComplejo, 
                finDelimitadorComplejo - inicioDelimitadorComplejo);
        }

        private string ObtenerDelimitadorSimple(string cadenaEnBruto)
        {
            return cadenaEnBruto[2].ToString();
        }

        private bool ExisteDelimitadorPersonalizado(string sumandos)
        {
            return sumandos.StartsWith(INICIO_ZONA_DELIMITADORES);
        }
    }
}
