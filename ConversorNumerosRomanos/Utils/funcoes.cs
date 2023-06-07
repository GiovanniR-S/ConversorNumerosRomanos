using System.Text;

namespace ConversorNumerosRomanos.Utils
{
    public class funcoes
    {

        public StringBuilder nr = new StringBuilder("");

        public string ConverterRomano(double n)
        {
            int unidades, centenas, dezenas; //criação das variaveis

            centenas = (int)(n / 100);
            dezenas = ((int)n - ((centenas * 100))) / 10;  //calcuar e tirar dezenas do numero
            unidades = (int)n - ((centenas * 100) + (dezenas * 10)); //unidades

            switch (centenas)
            {
                case 1: nr.Append("C"); break;
                case 2: nr.Append("CC"); break;
                case 3: nr.Append("CCC"); break;
                case 4: nr.Append("CD"); break;
                case 5: nr.Append("D"); break;
            }

            switch (dezenas)
            {
                case 1: nr.Append("X"); break;
                case 2: nr.Append("XX"); break;
                case 3: nr.Append("XXX"); break;
                case 4: nr.Append("XL"); break;
                case 5: nr.Append("L"); break;
                case 6: nr.Append("LX"); break;
                case 7: nr.Append("LXX"); break;
                case 8: nr.Append("LXXX"); break;
                case 9: nr.Append("XC"); break;
            }

            switch (unidades)
            {
                case 1: nr.Append("I"); break;
                case 2: nr.Append("II"); break;
                case 3: nr.Append("III"); break;
                case 4: nr.Append("IV"); break;
                case 5: nr.Append("V"); break;
                case 6: nr.Append("VI"); break;
                case 7: nr.Append("VII"); break;
                case 8: nr.Append("VIII"); break;
                case 9: nr.Append("IX"); break;
            }

            return nr.ToString();

        }

        public int ConvertRomainNumberToArabic(string value)
        {
            var romanToArabic = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            var letters = value.ToUpper().ToCharArray();
            var result = 0;
            var keys = romanToArabic.Keys;

            for (int index = 0; index <= letters.Length - 1; index++)
            {
                if (index == letters.Length - 1)
                {
                    result += romanToArabic[letters[index]];
                    return result;
                }

                var current = romanToArabic[letters[index]];

                var nextIndex = index + 1;
                var next = romanToArabic[letters[nextIndex]];

                if (current < next)
                {
                    result -= current;
                }
                if (current >= next)
                {
                    result += current;
                }
            }
            return result;
        }


    }
}
