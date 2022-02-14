using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._1
{
    class Program
    {
        delegate int Operation(int a, int b, int c);
        static void Main(string[] args)
        {
            Operation operation = delegate (int a, int b, int c)
            {
                return (a + b + c) / 3;
            };

            Console.WriteLine(operation(2, 2, 3));
        }
    }
}
