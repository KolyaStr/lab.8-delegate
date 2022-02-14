using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._3
{
    class Program
    {
        delegate double Operation(double x, double y);
        static void Main(string[] args)
        {
            Operation Add = (x, y) => x + y;
            Operation Sub = (x, y) => x - y;
            Operation Mul = (x, y) => x * y;
            Operation Div = (x, y) =>
            {
                if (y == 0)
                {
                    return 0;
                }
                else
                    return x / y;
                
            };
            
            Console.WriteLine("Введите пример:");
            string str = null;

            int proverka = 0;
            while (proverka == 0)
            {
                string temp = Console.ReadLine().Replace(" ", "");
                if (temp.Any(q => char.IsLetter(q)) || string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("Ошибка ввода!");
                    continue;
                }
                else
                {
                    str = temp.Replace('.', ',');
                    proverka++;
                }
            }

            string[] numbers = str.Split(new char[] { '-', '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actions = str.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            string[] task = new string[numbers.Length + actions.Length];

            int a = 0;
            for (int i = 0, b = 1,c = 0; i < task.Length; i+=2, b+=2, c++)
            {
                task[i] = numbers[c];
                if (a < actions.Length)
                    task[b] = actions[c];
                a++;
            }

            if (task.Length == 1 || task.Length == 2)
            {
                Console.WriteLine("Ошибка ввода!");
            }

            for (int i = 0; i < task.Length; i++)
            {
                Console.Write(task[i] + " ");
            }
            Console.Write($"= ");


            int nulls = 0;
            for (int i = 0; i < task.Length; i++)
            {
                if (task[i] == "/")
                {
                    task[i - 1] = Convert.ToString(Div(Convert.ToDouble(task[i - 1]), Convert.ToDouble(task[i + 1])));
                    task[i] = null;
                    task[i + 1] = null;
                    nulls += 2;
                }
                else if (task[i] == "*")
                {
                    task[i - 1] = Convert.ToString(Mul(Convert.ToDouble(task[i - 1]), Convert.ToDouble(task[i + 1])));
                    task[i] = null;
                    task[i + 1] = null;
                    nulls += 2;
                }
            }

            string[] newTask = new string[task.Length - nulls];

            for (int i = 0, b = 0; i < task.Length; i++)
            {
                if (task[i] != null)
                {
                    newTask[b] = task[i];
                    b++;
                }
            }

            for (int i = 1; i < newTask.Length-1; i++)
            {
                if (newTask[i] == "+")
                {
                    newTask[i + 1] = Convert.ToString(Add(Convert.ToDouble(task[i - 1]), Convert.ToDouble(task[i + 1])));
                    newTask[i] = null;
                    newTask[i - 1] = null;
                }
                else if (newTask[i] == "-")
                {
                    newTask[i + 1] = Convert.ToString(Sub(Convert.ToDouble(task[i - 1]), Convert.ToDouble(task[i + 1])));
                    newTask[i] = null;
                    newTask[i - 1] = null;
                }
            }

            for (int i = 0; i < newTask.Length; i++)
            {
                Console.Write(newTask[i]);
            }
            Console.WriteLine();
        }
    }
}
