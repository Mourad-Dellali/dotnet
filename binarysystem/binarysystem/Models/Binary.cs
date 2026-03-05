namespace binarysystem.Models
{
    public class Binary : Base
    {
        public Binary(string value)
        {
            value.Guard("01", NumberBase.BINARY); 
            this.Value = value;
        }
    }
}
