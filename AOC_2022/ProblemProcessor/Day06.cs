using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Day06
    {
        public Day06()
        {
            string text = File.ReadAllText($"./Inputs/{this.GetType().Name}.txt");
            char[] charArray = text.ToCharArray();
            int uniqueCharCount = 14;
            for (int i = 0; i < charArray.Length; i++)
            {
                char[] temp = new char[uniqueCharCount];
                for (int j=0; j < uniqueCharCount; j++)
                {
                    temp[j] = charArray[i+j];
                }

                var unique = temp.Distinct();
                if(unique.Count() == uniqueCharCount)
                {
                    int position = i + uniqueCharCount;
                    Console.WriteLine( "First message start at : " + position );
                    break;
                }
            }

            Console.ReadLine();

        }
    }
}
