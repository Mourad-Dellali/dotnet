using binarysystem.Models;

namespace binarysystem
{
    public static class NumberSystemExtensions
    {
        public static void Guard(this string source, string allowedCharacters, NumberBase numberBase)
        {
            foreach (var ch in allowedCharacters)
            {
                if (!allowedCharacters.Contains(ch))
                {
                    throw new ArgumentException($"Invalid character '{ch}' for base {numberBase}");
                }
            }
        }
        public static string To<T>(this T source, NumberBase numberbase) where T: Base
        {
            NumberBase fromBase;
            switch(source)
            {
                case Binary: fromBase = NumberBase.BINARY; break;
                case DecimalSystem: fromBase = NumberBase.DECIMAL; break;
                case Hexadecimal: fromBase = NumberBase.HEXADECIMAL; break;
                case Octal: fromBase = NumberBase.OCTAL; break;
                default: fromBase = NumberBase.DECIMAL; break;
            }
            return Convert.ToString(Convert.ToInt32(source.Value, (int)fromBase), (int)numberbase);
        }
    }
}