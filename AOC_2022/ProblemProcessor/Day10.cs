using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    class Day10
    {
        
        string display = string.Empty;
        public Day10()
        {
            string text = File.ReadAllText("./Inputs/Day10.txt");
            string[] stringArray = text.Split(Environment.NewLine, StringSplitOptions.None);
            int cycle = 1;
            long x = 1;
            int nextSignalBooster = 20;
            List<long> singnalStrength = new List<long>();
            foreach (string str in stringArray)
            {
                string[] strArray = str.Split(" ");
                display += GetCRT(x, cycle-1);
                if (cycle % 40 == 0)
                    display += "\n";

                if (strArray.Count() == 1)
                {
                    if (cycle == nextSignalBooster)
                    {
                        singnalStrength.Add(x * nextSignalBooster);
                        //x = 1;1
                        nextSignalBooster += 40;

                    }
                }
                else
                {
                    if (cycle == nextSignalBooster || cycle+1 == nextSignalBooster)
                    {
                        singnalStrength.Add(x * nextSignalBooster);
                        //x = 1;
                        nextSignalBooster += 40;
                    }
                    
                    cycle++;

                    display += GetCRT(x, cycle-1);
                    if (cycle % 40 == 0)
                        display += "\n";

                    cycle++;
                    x += Convert.ToInt32(strArray[1]);
                    
                }
               
            }
            long totalSignal = singnalStrength.Sum();
            Console.WriteLine(totalSignal);
            Console.WriteLine(display);

        }

        private string GetCRT(long x, int cycle)
        {
            int y = cycle % 40;
            if (x - 1 == y || x == y || x + 1 == y)
                return "#";
            else
                return ".";
        }
    }
}
