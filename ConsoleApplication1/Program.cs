using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = "1/n2,3";
            var number = num.IndexOf("2");
            var number1 = num.IndexOf(3);
            Console.WriteLine(number + "," + number1);
            //foreach (char c in num)
            //{
            //    var num1 = 0;
            //    var num2 = 0;
            //    var number = num.IndexOf("2");
            //    var number1 = num.IndexOf("3");
            //    Console.WriteLine(num);
            //    Console.WriteLine(c);
            //}
        }
    }
}
