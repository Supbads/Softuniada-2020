using System;

namespace Softuniada2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var startSalary = decimal.Parse(Console.ReadLine());
            var monthlyExpenses = decimal.Parse(Console.ReadLine());
            var monthlySalaryIncrement = decimal.Parse(Console.ReadLine());

            var targetCarPrice = decimal.Parse(Console.ReadLine());
            var months = long.Parse(Console.ReadLine());
            
            decimal totalMonthsSalaries = startSalary * months;
            decimal totalBoosts = 0;
            
            for (long i = 1; i < months; i++)
            {

                totalBoosts += i * monthlySalaryIncrement;
            }

            var totalSalaries = totalMonthsSalaries + totalBoosts;
            var totalExpenses = monthlyExpenses * months;
            var savings = totalSalaries - totalExpenses;
            var purchaseLeftovers = savings - targetCarPrice;


            if(purchaseLeftovers >= 0)
            {
                Console.WriteLine("Have a nice ride!");
            }
            else
            {
                Console.WriteLine("Work harder!");
            }

        }
    }
}
