using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a string of integers: ");
            var inputString = Console.ReadLine();

            int[] stringNumbers = inputString.GetNumbers();

            foreach (int number in stringNumbers)
            {
                Console.WriteLine($"\t{number}");
            }

            Console.ReadKey();
        }
    }
}
