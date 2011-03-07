using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RomanNumerals
{
    public class RomanConversorTests
    {
        RomanConversor _romanConversor;
        public RomanConversorTests()
        {
            _romanConversor = new RomanConversor();    
        }

        [Fact]
        public void Deberia_poder_convertir_unidades()
        {
            Assert.Equal("I", _romanConversor.ConvertirARomanos(1));
            Assert.Equal("V", _romanConversor.ConvertirARomanos(5));
            Assert.Equal("VII", _romanConversor.ConvertirARomanos(7));
        }

        [Fact]
        public void Deberia_poder_convertir_decenas()
        {
            Assert.Equal("X",_romanConversor.ConvertirARomanos(10));
            Assert.Equal("XX", _romanConversor.ConvertirARomanos(20));
            Assert.Equal("XXX", _romanConversor.ConvertirARomanos(30));
            Assert.Equal("XL", _romanConversor.ConvertirARomanos(40));
            Assert.Equal("L", _romanConversor.ConvertirARomanos(50));
            Assert.Equal("LX", _romanConversor.ConvertirARomanos(60));
        }

        [Fact]
        public void Deberia_poder_convertir_numeros_de_dos_digitos()
        {
            Assert.Equal("XII", _romanConversor.ConvertirARomanos(12));
            Assert.Equal("LXXII", _romanConversor.ConvertirARomanos(72));
            Assert.Equal("XCIX", _romanConversor.ConvertirARomanos(99));
        }

        [Fact]
        public void Deberia_poder_convertir_centenas()
        {
            Assert.Equal("C",_romanConversor.ConvertirARomanos(100));
        }
    }
}
