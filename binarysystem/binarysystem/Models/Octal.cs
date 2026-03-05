namespace binarysystem.Models
{
    public class Octal : Base
    {
        public Octal(string value)
        {
            value.Guard("01234567", NumberBase.OCTAL);
            this.Value = value;
        }
    }
}
