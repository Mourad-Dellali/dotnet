using binarysystem;
using binarysystem.Models;
using System;

namespace MainBinarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var b= new Binary("11111111");
            var dec= b.To(NumberBase.DECIMAL);
            Console.WriteLine(dec);

        }
    }
}