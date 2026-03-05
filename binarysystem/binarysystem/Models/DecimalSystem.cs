namespace binarysystem.Models
{
    public class DecimalSystem : Base
    {
        public DecimalSystem(string value)
        {
            value.Guard("0123456789", NumberBase.DECIMAL);
            this.Value = value;
        }
    }
}
