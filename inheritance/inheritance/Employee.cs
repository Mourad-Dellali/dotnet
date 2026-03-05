namespace inheritance
{
    public abstract class Employee
    {
        public const int MinimumLoggedHours = 176;
        public const decimal OverTimeRate = 1.25m;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal LoggedHours { get; set; }
        public decimal Wage { get; set; }
        public virtual decimal CalculatePay()
        {
            var additionalHours = ((LoggedHours - MinimumLoggedHours > 0 ) ? LoggedHours - MinimumLoggedHours : 0);
            return (Wage * MinimumLoggedHours) + (additionalHours * Wage * OverTimeRate);
        }
        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name}\nLogged Hours: {LoggedHours}\nWage: {Wage}\nPay: {CalculatePay()}";
        }

    }
    public class Manager : Employee
    {
        public const decimal Allowance = 0.05m;
        public override decimal CalculatePay()
        {
            return base.CalculatePay() + Allowance * base.CalculatePay();
        }
    }   
    public class Sales : Employee
    {
        public const decimal Commission = 0.10m;
        public override decimal CalculatePay()
        {
            return base.CalculatePay() + Commission * base.CalculatePay();
        }
    }
    public class Maintenance : Employee
    {
        public const decimal Bonus = 0.15m;
        public override decimal CalculatePay()
        {
            return base.CalculatePay() + Bonus * base.CalculatePay();
        }
    }
}
