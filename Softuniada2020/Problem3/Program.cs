using System;

using System.Linq;

namespace Softuniada2020
{
    class Program
    {
        private static int cardsCount;
        
        static void Main(string[] args)
        {
            cardsCount = int.Parse(Console.ReadLine());

            var deckSplitIndices = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse).ToList();
                

            int[] cardsDeck = new int[cardsCount];
            PopulateCardsDeck(cardsCount, cardsDeck);
            
            foreach (var splitIndex in deckSplitIndices)
            {
                var firstArr = cardsDeck.Take(splitIndex).ToArray();
                var secondArr = cardsDeck.Skip(splitIndex).ToArray();

                cardsDeck = Merge(firstArr, secondArr);
            }

            Console.WriteLine(string.Join(" ", cardsDeck));
        }

        private static int[] Merge(int[] firstArr, int[] secondArr)
        {
            //alternate takes first -> second -> first
            int[] resultArr = new int[cardsCount];

            int firstArrIndex = 0;
            int secondArrIndex = 0;

            bool takeFromFirst = false;

            for (int i = 0; i < cardsCount; i++)
            {
                int result = 0;
                takeFromFirst = !takeFromFirst;

                if (takeFromFirst)
                {
                    result = TryTake(firstArr, firstArrIndex);
                    if (result != -1)
                    {
                        firstArrIndex++;
                    }
                    else
                    {
                        
                        i--;
                        continue;
                    }
                }
                else
                {
                    result = TryTake(secondArr, secondArrIndex);
                    if (result != -1)
                    {
                        secondArrIndex++;

                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }

                resultArr[i] = result;
            }

            return resultArr;
        }

        private static int TryTake(int[] arr, int index)
        {
            if(index < arr.Length)
            {
                return arr[index];
            }

            return -1;
        }

        private static void PopulateCardsDeck(int cardsCount, int[] cardsDeck)
        {
            for (int i = 0; i < cardsCount; i++)
            {
                cardsDeck[i] = i + 1;
            }
        }
    }
}
