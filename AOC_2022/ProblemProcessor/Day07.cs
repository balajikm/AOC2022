using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{

    internal class Day07
    {
        public Day07()
        {
            string text = File.ReadAllText($"./Inputs/{this.GetType().Name}.txt");
            string[] stringArray = text.Split("\r\n");
            Dictionary<string, long> map = new Dictionary<string, long>();
            Stack<string> currentDirectory = new Stack<string>();
            foreach(string str in stringArray)
            {
                if(str == "$ cd ..")
                {
                    currentDirectory.Pop();
                }
                else if (str.StartsWith("$ cd")){
                    string dirName = str.Split(" ")[2];
                    currentDirectory.Push(string.Join("", currentDirectory) + dirName);
                }
                else if (char.IsNumber(str.ToCharArray()[0]))
                {
                    long size = Convert.ToInt32(str.Split(" ").First());
                    foreach(var dir in currentDirectory)
                    {
                        if (map.ContainsKey(dir))
                            map[dir] = map[dir] + size;
                        else
                            map.Add(dir, size);
                    }
                }
            }
            long totalSize = 0;
            foreach(var size in map.Values)
            {
                if (size <= 100000)
                    totalSize += size;
            }
            Console.WriteLine("Size of selected directories : " + totalSize.ToString());
            const long totalDiskSize = 70000000;
            const long spaceRequired = 30000000;
            long spaceLeft = totalDiskSize - map["/"];
            var sortedMap = map.Values.OrderBy(x => x);
            foreach(var size in sortedMap)
            {
                if(spaceLeft + size >= spaceRequired)
                {
                    Console.WriteLine("Deleting directory size : " + size.ToString());
                    break;
                }
            }

            Console.ReadLine();
            
        }
    }
}
