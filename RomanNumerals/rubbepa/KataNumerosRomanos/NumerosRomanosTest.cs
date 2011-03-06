using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace KataNumerosRomanos
{
    public class NumerosRomanosTest
    {
        private NumerosRomanos _numerosRomanos;

        public NumerosRomanosTest()
        {
            _numerosRomanos = new NumerosRomanos();
        }

        [Fact]
        public void Deberia_poder_convertir_unidades()
        {
            Assert.Equal("I", _numerosRomanos.ConvertirNumeroEntero(1));
            Assert.Equal("II", _numerosRomanos.ConvertirNumeroEntero(2));
            Assert.Equal("III", _numerosRomanos.ConvertirNumeroEntero(3));
            Assert.Equal("IV", _numerosRomanos.ConvertirNumeroEntero(4));
            Assert.Equal("V", _numerosRomanos.ConvertirNumeroEntero(5));
            Assert.Equal("VI", _numerosRomanos.ConvertirNumeroEntero(6));
            Assert.Equal("VII", _numerosRomanos.ConvertirNumeroEntero(7));
            Assert.Equal("VIII", _numerosRomanos.ConvertirNumeroEntero(8));
            Assert.Equal("IX", _numerosRomanos.ConvertirNumeroEntero(9));
        }

        [Fact]
        public void Deberia_poder_convertir_decenas()
        {
            Assert.Equal("X", _numerosRomanos.ConvertirNumeroEntero(10));
            Assert.Equal("XX", _numerosRomanos.ConvertirNumeroEntero(20));
            Assert.Equal("XXX", _numerosRomanos.ConvertirNumeroEntero(30));
            Assert.Equal("XL", _numerosRomanos.ConvertirNumeroEntero(40));
            Assert.Equal("L", _numerosRomanos.ConvertirNumeroEntero(50));
            Assert.Equal("LX", _numerosRomanos.ConvertirNumeroEntero(60));
            Assert.Equal("LXX", _numerosRomanos.ConvertirNumeroEntero(70));
            Assert.Equal("LXXX", _numerosRomanos.ConvertirNumeroEntero(80));
            Assert.Equal("XC", _numerosRomanos.ConvertirNumeroEntero(90));
        }

        [Fact]
        public void Deberia_poder_convertir_centenas()
        {
            Assert.Equal("C", _numerosRomanos.ConvertirNumeroEntero(100));
            Assert.Equal("CC", _numerosRomanos.ConvertirNumeroEntero(200));
            Assert.Equal("CCC", _numerosRomanos.ConvertirNumeroEntero(300));
            Assert.Equal("CD", _numerosRomanos.ConvertirNumeroEntero(400));
            Assert.Equal("D", _numerosRomanos.ConvertirNumeroEntero(500));
            Assert.Equal("DC", _numerosRomanos.ConvertirNumeroEntero(600));
            Assert.Equal("DCC", _numerosRomanos.ConvertirNumeroEntero(700));
            Assert.Equal("DCCC", _numerosRomanos.ConvertirNumeroEntero(800));
            Assert.Equal("CM", _numerosRomanos.ConvertirNumeroEntero(900));
        }

        [Fact]
        public void Deberia_poder_convertir_millares()
        {
            Assert.Equal("M", _numerosRomanos.ConvertirNumeroEntero(1000));
            Assert.Equal("MM", _numerosRomanos.ConvertirNumeroEntero(2000));
            Assert.Equal("MMM", _numerosRomanos.ConvertirNumeroEntero(3000));
            Assert.Equal("MMMMMM", _numerosRomanos.ConvertirNumeroEntero(6000));
        }

        [Fact]
        public void Deberia_convertir_numeros_complejos_de_dos_digitos()
        {
            Assert.Equal("XXV", _numerosRomanos.ConvertirNumeroEntero(25));
            Assert.Equal("LXXXIX", _numerosRomanos.ConvertirNumeroEntero(89));
        }

        [Fact]
        public void Deberia_convertir_numeros_complejos_de_varios_digitos()
        {
            Assert.Equal("CCCXLI", _numerosRomanos.ConvertirNumeroEntero(341));
            Assert.Equal("DCCXXI", _numerosRomanos.ConvertirNumeroEntero(721));
            Assert.Equal("CMXII", _numerosRomanos.ConvertirNumeroEntero(912));
            Assert.Equal("DCCCXI", _numerosRomanos.ConvertirNumeroEntero(811));
            Assert.Equal("MDCXXXII", _numerosRomanos.ConvertirNumeroEntero(1632));
            Assert.Equal("MMC", _numerosRomanos.ConvertirNumeroEntero(2100));
            Assert.Equal("MMMMCMXXX", _numerosRomanos.ConvertirNumeroEntero(4930));
        }

        [Fact]
        public void Deberia_convertir_romano_a_entero()
        {
            Assert.Equal(20, _numerosRomanos.ConvertirRomano("XX"));
            Assert.Equal(4930, _numerosRomanos.ConvertirRomano("MMMMCMXXX"));
            Assert.Equal(811, _numerosRomanos.ConvertirRomano("DCCCXI"));
            Assert.Equal(2000, _numerosRomanos.ConvertirRomano("MM"));
            Assert.Equal(401, _numerosRomanos.ConvertirRomano("CDI"));
            Assert.Equal(25, _numerosRomanos.ConvertirRomano("XXV"));
            Assert.Equal(2, _numerosRomanos.ConvertirRomano("II"));
        }

        [Fact]
        public void Deberia_devolver_cero_con_cadena_vacia()
        {
            Assert.Equal(0, _numerosRomanos.ConvertirRomano(""));
        }

        [Fact]
        public void Deberia_convertir_cero_a_cadena_vacia()
        {
            Assert.Equal("", _numerosRomanos.ConvertirNumeroEntero(0));
        }
    }
}
