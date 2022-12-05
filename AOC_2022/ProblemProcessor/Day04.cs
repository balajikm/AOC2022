using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Day04
    {
        //Very bad coding, need to cleanup
        public Day04()
        {
            string text = File.ReadAllText("./Inputs/Day04.txt");
            string[] stringArray = text.Split("\r\n");
            int coinceidingCount = 0;
            int overlapCount = 0;
            for(int i = 0; i < stringArray.Length; i++)
            {
                string pair = stringArray[i];
                string[] singleAssignment = pair.Split(",");
                string firstPair = singleAssignment[0];
                string secondPair = singleAssignment[1];
                string[] firstPairArray = firstPair.Split("-");
                string[] secondPairArray = secondPair.Split("-");
                int firstStart = Convert.ToInt32(firstPairArray[0]);
                int secondStart = Convert.ToInt32(secondPairArray[0]);
                int firstEnd = Convert.ToInt32(firstPairArray[1]);
                int secondEnd = Convert.ToInt32(secondPairArray[1]);
                if ((firstStart >= secondStart && firstEnd <= secondEnd) ||
                    (firstStart <= secondStart && firstEnd >= secondEnd))
                {
                    coinceidingCount++;
                }
                if ((firstStart <= secondStart && firstEnd >= secondStart) ||
                    (secondStart <= firstEnd && secondEnd >= firstEnd) ||
                    (secondStart <= firstStart && secondEnd >= firstStart) ||
                    (firstStart <= secondEnd && firstEnd >= secondStart))
                {
                    overlapCount++;
                }
               
                   
            }
            Console.WriteLine("Full overlap count : " + coinceidingCount);
            Console.WriteLine("Partial Overlap count : " + overlapCount);
            Console.ReadLine();
        }
    }
}
