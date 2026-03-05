using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    abstract class Vehicule
    {
        protected string Brand;
        protected string Model;
        protected int Year;

        public Vehicule(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
    class Honda: Vehicule, IDrivable
    {
        public Honda(string brand, string model, int year) : base(brand, model, year)
        {

        }
        public void Drive()
        {
            Console.WriteLine("Driving...");
        }
        public void Stop()
        {
            Console.WriteLine("Stopping...");
        }
    }
    interface IDrivable
    {
        void Drive();
        void Stop();
    }
    interface ILoader
    {
        void Load();
        void Unload();
    }
    class Caterpillar : Vehicule , ILoader, IDrivable
    {

        public Caterpillar(string brand, string model, int year) : base(brand, model, year)
        {

        }

        public void Load()
        {
            Console.WriteLine("Loading...");
        }

        public void Unload()
        {
            Console.WriteLine("Unloading...");
        }
        public void Drive()
        {
            Console.WriteLine("Driving...");
        }
        public void Stop()
        {
            Console.WriteLine("Stopping...");
        }
    }
}