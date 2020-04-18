using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            int comboCount = int.Parse(Console.ReadLine());
            int inputs = int.Parse(Console.ReadLine());

            var numbers = new List<int>();
            for (int i = 0; i < inputs; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            
            }


            numbers.Sort();
            if(numbers.Count == 2)
            {
                Console.WriteLine(numbers[1] - numbers[0]);
                return;
            }

            List<int> differences = new List<int>();
            for (int i = 0; i < numbers.Count - comboCount; i++)
            {
                differences.Add(TakeDifference(numbers, i, comboCount));
            }

            differences.Sort();
            Console.WriteLine(differences.First());
        }

        private static int TakeDifference(List<int> numbers, int index, int comboCount)
        {
            var difference = numbers[comboCount - 1 + index] - numbers[index];

            return difference;
        }
    }
}
