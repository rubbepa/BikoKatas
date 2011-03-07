using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    class RomanConversor
    {
        private Dictionary<int, string> _simbolosDeUnidades;
        private Dictionary<int, string> _simbolosDeDecenas;
        private Dictionary<int, string> _simbolosDeCentenas;

        public RomanConversor()
        {
            InicializarUnidades();
            InicializarDecenas();
            InicializarCentenas();
        }

        private void InicializarUnidades()
        {
            _simbolosDeUnidades = new Dictionary<int, string>();

            _simbolosDeUnidades.Add(0, "");
            _simbolosDeUnidades.Add(1,"I");
            _simbolosDeUnidades.Add(2, "II");
            _simbolosDeUnidades.Add(3, "III");
            _simbolosDeUnidades.Add(4, "IV");
            _simbolosDeUnidades.Add(5, "V");
            _simbolosDeUnidades.Add(6, "VI");
            _simbolosDeUnidades.Add(7, "VII");
            _simbolosDeUnidades.Add(8, "VIII");
            _simbolosDeUnidades.Add(9, "IX");

           
        }

        private void InicializarDecenas()
        {
            _simbolosDeDecenas = new Dictionary<int, string>();
            _simbolosDeDecenas.Add(1,"X");
            _simbolosDeDecenas.Add(2, "XX");
            _simbolosDeDecenas.Add(3, "XXX");
            _simbolosDeDecenas.Add(4, "XL");
            _simbolosDeDecenas.Add(5, "L");
            _simbolosDeDecenas.Add(6, "LX");
            _simbolosDeDecenas.Add(7, "LXX");
            _simbolosDeDecenas.Add(8, "LXXX");
            _simbolosDeDecenas.Add(9, "XC");
        }

        private void InicializarCentenas()
        {
            _simbolosDeCentenas = new Dictionary<int, string>();
            _simbolosDeCentenas.Add(1, "C");
            _simbolosDeCentenas.Add(2, "CC");
            _simbolosDeCentenas.Add(3, "CCC");
            _simbolosDeCentenas.Add(4, "CD");
            _simbolosDeCentenas.Add(5, "D");
            _simbolosDeCentenas.Add(6, "DC");
            _simbolosDeCentenas.Add(7, "DCC");
            _simbolosDeCentenas.Add(8, "DCCC");
            _simbolosDeCentenas.Add(9, "CM");
        }

        public string ConvertirARomanos(int numero)
        {
            string numeroRomano = string.Empty;

            int centena = numero/100;
            int decena = (numero%100)/10;
            int unidad = numero - decena*10;

            if (centena > 0)
            {
                numeroRomano += _simbolosDeCentenas[centena];
            }
            if (decena > 0)
            {
                numeroRomano += _simbolosDeDecenas[decena];
            }

            if (unidad > 0)
            {
                numeroRomano += _simbolosDeUnidades[unidad];
            }

            return numeroRomano;
        }
    }
}
