using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1
{
    internal class Homework
    {

        internal static void Main(string[] strings)
        {
            int[] integer = { };
            var result = integer.FirstOrDefault();

            Console.WriteLine(result); // Output: 0

            string[] str = { };
            var result2 = str.FirstOrDefault();

            Console.WriteLine(result2); // Output:   (null)

            decimal amount = 100000.90m; //m tells the compiler that this number is decimal. d for double. f for float.
            Console.WriteLine(amount.ToString("n0"));
            Console.ReadLine();
        }
    }
}
