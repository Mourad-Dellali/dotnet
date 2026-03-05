using System;

namespace CAProperty
{
    public class Report
    {
        public delegate bool IllegibleSales(Employee emp);
        public void ProcessEmployee(Employee[] employees, string title, IllegibleSales isIllegible)
        {
            Console.WriteLine(title);
            Console.WriteLine("----------------------------");
            foreach (var  emp in employees)
            {
                if (isIllegible(emp))
                {
                    Console.WriteLine($"{emp.Id}| {emp.Name} | {emp.Gender} | {emp.TotalSales}");
                }
            }
            Console.WriteLine("----------------------------");
        }
    }
}
