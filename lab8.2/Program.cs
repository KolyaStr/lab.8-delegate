using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._2
{
    public delegate int DelegateArray();
    public delegate int Operation(DelegateArray[] delegateArray);
    class Program
    {
        public static int Random()
        {
            Random random = new Random();
            return random.Next(1, 20);
        }
        static void Main(string[] args)
        {
            DelegateArray[] myArray = new DelegateArray[5];
            Operation operation = delegate (DelegateArray[] delegateArray)
            {
                int sum = 0;
                for (int i = 0; i < delegateArray.Length; i++)
                {
                    delegateArray[i] = Random;
                    sum += delegateArray[i]();
                }
                return sum / delegateArray.Length;
            };
            Console.WriteLine(operation(myArray));
        }
        
    }
}
