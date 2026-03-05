using System;

namespace events
{

    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock("Amazon", 100);
            stock.OnPriceChanged += Publisher_OnPriceChanged;
            stock.ChangePrice(stock.Price + 10);
            stock.ChangePrice(stock.Price + 1000);
            stock.ChangePrice(stock.Price - 100);
            Console.WriteLine(stock.Price);


        }

        private static void Publisher_OnPriceChanged(Stock stock, decimal oldPrice)
        {
            if(stock.Price > oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Stock price increased from {oldPrice} to {stock.Price}");
            } else if (oldPrice > stock.Price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Stock price decreased from {oldPrice} to {stock.Price}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Stock price is unchanged at {stock.Price}");
            }
        }
    }

    
    public delegate void StockPriceOnChangeHanlder(Stock stock, decimal oldPrice);
    public class Stock
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public event StockPriceOnChangeHanlder OnPriceChanged;
        public Stock(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public void ChangePrice(decimal newPrice)
        {
            decimal oldPrice = this.Price;
            this.Price = newPrice;
            if (OnPriceChanged != null && oldPrice != newPrice) // making sure there is a subscriber
                OnPriceChanged(this, oldPrice);
        }
    }
}