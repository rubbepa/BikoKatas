using StringCalculator;
using Xunit;
using System;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        private StringCalculator _calculator;

        public StringCalculatorTests()
        {
            _calculator = 
                new StringCalculator(
                    new ConversorCadenaToNumeros());               
        }

        [Fact]
        public void Cadena_vacia_devuelve_cero()
        {
            Assert.Equal(0, _calculator.Add(""));
        }

        [Fact]
        public void Cadena_uno_devuelve_uno()
        {
            Assert.Equal(1, _calculator.Add("1"));
        }

        [Fact]
        public void Cadena_con_dos_numeros_y_coma_suma_ok()
        {
            Assert.Equal(3, _calculator.Add("1,2"));
            Assert.Equal(5, _calculator.Add("3,2"));
        }

        [Fact]
        public void Cadena_con_numeros_y_saltos_de_linea_suma_ok()
        {
            Assert.Equal(3, _calculator.Add("1\n2"));
        }
   
        [Fact]
        public void Cadena_con_numeros_y_separador_personalizado()
        {
            Assert.Equal(4, _calculator.Add("//;\n1;3"));
        }

        [Fact]
        public void Cadena_con_numeros_negativo_no_permitida()
        {
            Exception excepcionLanzada =
                Assert.Throws<Exception>(
                    () => _calculator.Add("2,-3"));

            Assert.Contains("negatives not allowed", excepcionLanzada.Message);
            Assert.Contains("-3", excepcionLanzada.Message);
        }

        [Fact]
        public void Con_multiples_negativos_lanza_excepcion_con_numeros_en_el_mensaje()
        {
            Exception excepcionLanzada =
                Assert.Throws<Exception>(
                    () => _calculator.Add("-2,-3"));

            Assert.Contains("-3", excepcionLanzada.Message);
            Assert.Contains("-2", excepcionLanzada.Message);
        }

        [Fact]
        public void Deberia_ignorar_numeros_mayores_de_1000()
        {
            Assert.Equal(2, _calculator.Add("2,1001"));
        }

        [Fact]
        public void Deberia_soportar_separador_de_2_caracteres()
        {
            Assert.Equal(5, _calculator.Add("//[$$]\n2$$3"));
        }

        [Fact]
        public void Deberia_soportar_multiples_separadores_de_mas_de_1_caracter()
        {
            Assert.Equal(13, _calculator.Add("//[##][%][@]\n2##2\n1%3@1\n4"));
        }
    }
}
