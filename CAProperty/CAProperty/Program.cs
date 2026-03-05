
using System.Xml.Schema;

namespace CAProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            var emps = new Employee[]
            {
            // examples
               new Employee {Id= 1, Name="Issam A", Gender= "M", TotalSales= 65000m},
               new Employee {Id= 2, Name="Reep S", Gender = "F", TotalSales=50000m},
               new Employee {Id= 3,Name="Suzan B", Gender = "F",TotalSales = 70000m},
               new Employee {Id= 4,Name="Sara A", Gender="F", TotalSales= 45000m},
               new Employee {Id= 5,Name="Rateb A",Gender ="M", TotalSales= 80000m},
           };

            var report= new Report();
            report.ProcessEmployee(emps, "Employees with sales more than 60000", e => e.TotalSales > 60000 );
            report.ProcessEmployee(emps, "Employees with sales between 30000 and 60000", emp => emp.TotalSales >= 30000m && emp.TotalSales <= 60000m);
        }
    }
}