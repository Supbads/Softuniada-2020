using System;
using System.Linq;

namespace Softuniada2020
{
    class Program
    {
        private static int playerRow;
        private static int playerCol;

        private static char playerSteppedOn = '0';

        static void Main(string[] args)
        {
            int[] fieldArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = fieldArgs[0];
            int cols = fieldArgs[1];
            var field = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }

            FindPlayer(rows, cols, field);

            int inputsCount = int.Parse(Console.ReadLine());

            int totalJumps = 0;
            bool hasWon = false;
            for (int i = 0; i < inputsCount; i++)
            {
                var shiftArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int shiftRow = shiftArgs[0];
                int shiftCount = shiftArgs[1];

                // Shift cells
                field[shiftRow] = ShiftRow(field[shiftRow], shiftCount);

                // Try Jump
                var successfulJump = TryJump(field);

                if (successfulJump)
                {
                    totalJumps++;
                }
                
                if (HasWon())
                {
                    hasWon = true;
                    break;
                }

            }

            if (hasWon)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine("Lose");
            }

            Console.WriteLine($"Total Jumps: {totalJumps}");
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", field[i]));
            }
        }

        private static bool TryJump(char[][] field)
        {
            if (field[playerRow - 1][playerCol] == '0')
            {
                return false;
            }

            field[playerRow][playerCol] = playerSteppedOn;
            playerSteppedOn = field[playerRow - 1][playerCol];
            field[playerRow - 1][playerCol] = 'S';
            playerRow--;

            return true;
        }

        private static bool HasWon()
        {
            if (playerRow == 0)
            {
                //Win ?
                return true;
            }

            return false;
        }

        private static char[] ShiftRow(char[] fieldRow, int colsShiftCount)
        {
            // always shift right
            char[] resultCopyRow = new char[fieldRow.Length];
            var normalizedShiftsCount = colsShiftCount % fieldRow.Length;
            for (int col = 0; col < fieldRow.Length; col++)
            {
                
                resultCopyRow[(col + normalizedShiftsCount) % fieldRow.Length] = fieldRow[col];
            }

            return resultCopyRow;
        }

        private static void FindPlayer(int rows, int cols, char[][] field)
        {
            bool playerFound = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i][j] == 'S')
                    {
                        playerRow = i;
                        playerCol = j;

                        playerFound = true;
                        break;
                    }
                }
                if (playerFound)
                {
                    break;
                }
            }
        }
        //beware double rows
    }
}
