using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Day01
    {
        public Day01()
        {
            string text = File.ReadAllText("./Inputs/Day01Prob01.txt");
            Console.WriteLine(text);
            string[] arrayRecord = text.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            long[] totalCalory = new long[arrayRecord.Length];
            for (int i = 0; i < arrayRecord.Length; i++)
            {
                string[] caloryList = arrayRecord[i].Split(new string[] { "\r\n" }, StringSplitOptions.None);
                long elfCalory = 0;
                foreach (string calory in caloryList)
                {
                    elfCalory += Convert.ToInt64(calory);
                }
                totalCalory[i] = elfCalory;
            }
            totalCalory = totalCalory.OrderByDescending(x => x).ToArray();
            Console.WriteLine("Heighest calory elf holding " + totalCalory[0] + " sCalories");
            long topThreeElvesCalory = totalCalory[0] + totalCalory[1] + totalCalory[2];
            Console.WriteLine("Top 3 heighest calory elf holding " + topThreeElvesCalory + " sCalories");
            Console.ReadLine();
        }
    }
}
