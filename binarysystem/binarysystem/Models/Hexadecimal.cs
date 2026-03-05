namespace binarysystem.Models
{
    public class Hexadecimal : Base
    {
        public Hexadecimal(string value)
        {
            value.Guard("0123456789ABCDEFabcdef", NumberBase.HEXADECIMAL);
            this.Value = value;
        }
    }
}
