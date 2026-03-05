using System;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager M = new Manager
            {
                Id = 1,
                Name = "John Doe",
                LoggedHours = 200,
                Wage = 15.00m
            };
            Sales sales = new Sales
            {
                Id = 2,
                Name = "Jane Doe",
                LoggedHours = 180,
                Wage = 12.00m
            };
            Maintenance maintenance = new Maintenance
            {
                Id = 3,
                Name = "Jack Doe",
                LoggedHours = 170,
                Wage = 10.00m
            };
            Console.WriteLine(sales);
            Console.WriteLine(maintenance);
            Console.WriteLine(M);
        }

    }
    
}