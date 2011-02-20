using System.Collections.Generic;

namespace StringCalculator
{
    public interface IConversorCadenaToNumeros
    {
        List<int> ObtenerNumeros(string cadena);
    }
}