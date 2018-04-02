using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringExtension
    {
        public static int[] GetNumbers(this string inputString)
        {
            try
            {
                return Array.ConvertAll(inputString.Split(','), int.Parse);
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Wrong format. String should contain integer value separated with coma. Exception:: {ex.Message}");
            }
        }
    }
}
