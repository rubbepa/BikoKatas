using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StringCalculatorLive
{
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;
        private int _resultado = 0;

        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void LaSumaSinSumandosEsCero()
        {
            _resultado = _stringCalculator.Add("");

            Assert.Equal(_resultado, 0);
        }

        [Fact]
        public void LaSumaConUnSoloSumandoEsElSumando()
        {
            _resultado = _stringCalculator.Add("1");

            Assert.Equal(_resultado, 1);
        }

        [Fact]
        public void LaSumaConDosSumandoEsLaSumaDeEllos()
        {
            _resultado = _stringCalculator.Add("1,2");

            Assert.Equal(_resultado, 3);
        }

        [Fact]
        public void Deberia_poder_sumar_mas_de_2_numeros()
        {
            _resultado = _stringCalculator.Add("1,2,3");

            Assert.Equal(_resultado, 6);
        }

        [Fact]
        public void Deberia_poder_separar_con_salto_de_linea()
        {
            _resultado = _stringCalculator.Add("1\n2,3");

            Assert.Equal(_resultado,6);
        }

        [Fact]
        public void SumarNumerosConDelimitadoresPersonalizados()
        {
            _resultado = _stringCalculator.Add("//;\n1;2");
            Assert.Equal(_resultado,3);
        }

        [Fact]
        public void Deberia_no_soportar_un_numero_negativos()
        {
            Exception excepcion = Assert.Throws<Exception>(() => _stringCalculator.Add("-1,2"));
            Assert.Contains("negatives not allowed", excepcion.Message);
            Assert.Contains("-1", excepcion.Message);
        }

        [Fact]
        public void Deberia_no_soportar_varios_numeros_negativos()
        {
            Exception excepcion = Assert.Throws<Exception>(() => _stringCalculator.Add("-1,-2"));
            Assert.Contains("negatives not allowed", excepcion.Message);
            Assert.Contains("-1", excepcion.Message);
            Assert.Contains("-2", excepcion.Message);
        }

        [Fact]
        public void Los_numeros_mayores_que_1000_son_ignorados()
        {
            _resultado = _stringCalculator.Add("1001,2");
            Assert.Equal(_resultado,2);
        }

        [Fact]
        public void El_delimitador_puede_tener_varios_caracteres()
        {
            _resultado = _stringCalculator.Add("//[***]\n1***2***3");
            Assert.Equal(_resultado,6);
        }

        [Fact]
        public void Deberia_devolver_cero_con_nulo()
        {
            Assert.Equal(0, _stringCalculator.Add(null));
        }
    }
}
