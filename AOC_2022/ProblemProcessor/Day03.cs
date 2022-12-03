using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Day03
    {
       public Day03()
        {
            string text = File.ReadAllText("./Inputs/Day03.txt");
            string[] stringArray = text.Split("\r\n");
            long totalPriority = 0;
            List<IEnumerable<int>> allItems = new List<IEnumerable<int>>();
            foreach (string str in stringArray)
            {
                IEnumerable<int> concatArray;
                totalPriority += getPriority(str, out concatArray);
                allItems.Add(concatArray);
            }
            Console.WriteLine("Total Priority : " + totalPriority);
            int prioritySum = 0;
            for(int i = 0; i < allItems.Count; i+=3)
            {
               var intersect =  allItems[i].Intersect(allItems[i + 1]).Intersect(allItems[i+2]);
                int groupSum = intersect.FirstOrDefault();
                prioritySum += groupSum;
            }
            Console.WriteLine("Prob 2, total priority sum : " + prioritySum);
            Console.ReadLine();
        }

        private int getPriority(string content, out IEnumerable<int> concat)
        {
            char[] charArray = content.ToCharArray();
            int[] leftArray = new int[charArray.Length/2];
            int[] rightArray = new int[charArray.Length / 2];
            for(int i = 0; i < charArray.Length/2; i++)
            {
                leftArray[i] = charArray[i] > 96 ? charArray[i] - 96 : charArray[i] - 38;

            }
            for(int j=charArray.Length/2; j < charArray.Length; j++)
            {
                rightArray[j-charArray.Length/2] = charArray[j] > 96 ? charArray[j] - 96 : charArray[j] - 38;
            }

            IEnumerable<int> intersact = leftArray.Intersect(rightArray);
            concat = leftArray.Concat(rightArray);

            return intersact.FirstOrDefault();
        }
    }
}
