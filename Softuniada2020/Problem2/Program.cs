using System;
using System.Linq;
using System.Text;

namespace Softuniada2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var seats = int.Parse(Console.ReadLine());

            //7 => 10  ;  9 => 13 ;  5 => 7
            // 5 => 2  ; 7 => 3  ; 9 => 4
           

            // diagonals count => seats - 3  (check for lower couts)
            int drawnRowsCount = 1;

            char[] previousRow = new string('.', seats).ToCharArray();
            for (int i = 0; i < previousRow.Length; i += 4)
            {
                previousRow[i] = '#';
            }

            Console.WriteLine(string.Join("", previousRow));
            int repetitions = seats + (int)Math.Floor((decimal)seats / 2);
            
            while (drawnRowsCount < repetitions)
            {
                char[] currentRow = new string('.', seats).ToCharArray();
                
                int previousSeatIndex = Array.IndexOf(previousRow, '#', 1);
                AddPounds(currentRow, previousSeatIndex - 1);

                previousRow = currentRow;
                Console.WriteLine(string.Join("", currentRow));
                drawnRowsCount++;
            }

            

        }

        private static void AddPounds(char[] currentROw, int startIndex)
        {
            for (int i = startIndex; i < currentROw.Length; i += 4)
            {
                currentROw[i] = '#';
            }
        }
    }
}
