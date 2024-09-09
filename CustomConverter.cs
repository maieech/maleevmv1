using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class CustomConverter
    {
        public void Convert(string input, out int result) 
        {
            result = System.Convert.ToInt32(input);
        }

        public void Convert(string input, out double result)
        {
            result = System.Convert.ToDouble(input);
        }

        public void Convert(string input, out bool result)
        {
            result = System.Convert.ToBoolean(input);
        }
    }


    class Program
    {
        static void Main()
        {
            CustomConverter converter = new CustomConverter();

            string intString = "123";
            converter.Convert(intString, out int intResult);
            Console.WriteLine($"Converted'{intString}' to double: {intResult}");

            string doubleString = "123.45";
            converter.Convert(doubleString, out double doubleResult);
            Console.WriteLine($"Converted'{doubleString}' to double: {doubleResult}");

            string boolString = "true";
            converter.Convert(boolString, out bool boolResult);
            Console.WriteLine($"Converted'{boolString}' to bool: {boolResult}");
        }
    }
}
