using System.Collections.Generic;
namespace KataNumerosRomanos
{
    public class NumerosRomanos
    {
        private List<string> _unidades = 
            new List<string>{"I","II","III","IV","V","VI","VII","VIII","IX"};
        private List<string> _decenas =
            new List<string> { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private List<string> _centenas =
            new List<string> { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};

        public string ConvertirNumeroEntero(int numeroAConvertir)
        {
            if (numeroAConvertir == 0) return "";

            int millares = numeroAConvertir / 1000;
            int centenas = numeroAConvertir / 100 - millares * 10;
            int decenas = numeroAConvertir / 10 - millares * 100 - centenas * 10;
            int unidades = numeroAConvertir - millares * 1000 - centenas * 100 - decenas * 10;
            
            string romanoResultado = string.Empty;
            for (int x = 1; x <= millares; x++) romanoResultado += "M";
            if (centenas > 0) romanoResultado += _centenas[centenas - 1];
            if (decenas > 0) romanoResultado += _decenas[decenas - 1];
            if (unidades > 0) romanoResultado += _unidades[unidades - 1];

            return romanoResultado;
        }

        public int ConvertirRomano(string numeroRomano)
        {
            if (numeroRomano == string.Empty) return 0;

            int pos = 0;
            string millares = string.Empty;
            while(pos < numeroRomano.Length && numeroRomano[pos] == 'M')
            {
                millares += numeroRomano[pos];
                pos++;
            }

            string centenas = string.Empty;
            while (pos < numeroRomano.Length && 
                  (numeroRomano[pos] == 'C' || numeroRomano[pos] == 'D' || numeroRomano[pos] == 'M'))
            {
                centenas += numeroRomano[pos];
                pos++;
            }

            string decenas = string.Empty;
            while (pos < numeroRomano.Length &&
                  (numeroRomano[pos] == 'X' || numeroRomano[pos] == 'L' || numeroRomano[pos] == 'C'))
            {
                decenas += numeroRomano[pos];
                pos++;
            }

            string unidades = string.Empty;
            while (pos < numeroRomano.Length)
            {
                unidades += numeroRomano[pos];
                pos++;
            }

            int enteroResultado;

            enteroResultado = _unidades.FindIndex(s => s == unidades) + 1;
            enteroResultado += (_decenas.FindIndex(s => s == decenas) + 1) * 10;
            enteroResultado += (_centenas.FindIndex(s => s == centenas) + 1) * 100;
            enteroResultado += millares.Length * 1000;

            return enteroResultado;
        }
    }
}