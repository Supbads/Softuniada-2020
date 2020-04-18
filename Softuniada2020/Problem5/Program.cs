using System;
using System.Collections.Generic;
using System.Linq;

namespace Softuniada2020
{
    class Program
    {
        private static List<char[]> combinations = new List<char[]>();
        private static int totalCombos = 1;
        static void Main(string[] args)
        {
            char[] map = Console.ReadLine().ToCharArray();

            var currentPath = new char[map.Length];
            //TraversePath(map, currentPath, 0);

            int countUniquePaths = map.Where(x => x == '*').Count();
            if(countUniquePaths > 0)
            {
                var uniquePaths = new char[] { 'L', 'R', 'S' };
                AddUniquePaths(uniquePaths, countUniquePaths);
                Console.WriteLine(combinations.Count);
                VisitCombinations(combinations, map);
            }
            else
            {
                Console.WriteLine(totalCombos);
                Console.WriteLine(string.Join("", map));
            }
        }

        private static void VisitCombinations(List<char[]> combinations, char[] map)
        {
            List<int> multiRoadIndices = new List<int>();
            for (int i = 0; i < map.Length; i++)
            {
                if(map[i] == '*')
                {
                    multiRoadIndices.Add(i);
                }
            }

            foreach (var combination in combinations)
            {
                for (int i = 0; i < combination.Length; i++)
                {
                    map[multiRoadIndices[i]] = combination[i];
                }

                Console.WriteLine(string.Join("", map));
            }
        }

        //private static void TraversePath(char[] map, char[] currentPath, int index)
        //{
        //    if(index == map.Length)
        //    {
        //        Console.WriteLine(string.Join("", currentPath));
        //        return;
        //    }

        //    char currentChar = map[index];
        //    switch (currentChar)
        //    {
        //        case 'L':
        //            currentPath
        //            TraversePath()
        //            break;
        //        case 'L':

        //            break;
        //        case 'L':

        //            break;
        //        default:
        //            break;
        //    }

        //}

        static void AddUniquePaths(char[] set, int k)
        {
            int n = set.Length;
            printAllKLengthRec(set, "", n, k);
        }

        // The main recursive method 
        // to print all possible  
        // strings of length k 
        static void printAllKLengthRec(char[] set,
                                       String prefix,
                                       int n, int k)
        {

            // Base case: k is 0, 
            // print prefix 
            if (k == 0)
            {
                combinations.Add(prefix.ToCharArray());
                return;
            }

            // One by one add all characters  
            // from set and recursively  
            // call for k equals to k-1 
            for (int i = 0; i < n; ++i)
            {

                // Next character of input added 
                String newPrefix = prefix + set[i];

                // k is decreased, because  
                // we have added a new character 
                printAllKLengthRec(set, newPrefix,
                                        n, k - 1);
            }
        }
    }
}
