using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Knot{
        public int x;
        public int y;
    }
    internal class Day09
    {
        
        public Day09()
        {
            string text = File.ReadAllText("./Inputs/Day09.txt");
            string[] stringArray = text.Split(Environment.NewLine, StringSplitOptions.None);
            //Knot head = new Knot() { x = 0, y = 0 };
            //Knot tail = new Knot() { x = 0, y = 0 };
            int knotCount = 10; //2 for prob 1 and 10 for prob 2
            List<Knot> list = new List<Knot>();

            for(int i = 0; i < knotCount; i++)
                list.Add(new Knot() { x = 0, y = 0 });

            HashSet<string> visited = new HashSet<string>();
            Knot head = list[0];
            for (int i = 0; i < stringArray.Length; i++)
            {
                string[] strings = stringArray[i].Split(" ");
                int numberOfSteps = Convert.ToInt32(strings[1]);
                for(int j = 0; j < numberOfSteps; j++)
                {
                    switch (strings[0])
                    {
                        case "R":
                            head.x++;
                            MoveTail(list, visited);
                            break;

                        case "U":
                            head.y++;
                            MoveTail(list, visited);
                            break;

                        case "L":
                            head.x--;
                            MoveTail(list, visited);
                            break;

                        case "D":
                            head.y--;
                            MoveTail(list, visited);
                            break;

                        default:
                            break;
                    }
                }
                
            }

            Console.WriteLine(visited.Count()+1);  

        }

        private void MoveTail(List<Knot> list, HashSet<string> visited)
        {
            for(int i = 1; i < list.Count(); i++)
            {
                Knot h = list[i - 1]; 
                Knot t = list[i];
                if (!(Math.Abs(h.x - t.x) <= 1 && Math.Abs(h.y - t.y) <= 1))
                {
                    if (h.x > t.x)
                        t.x += 1;
                    if (h.x < t.x)
                        t.x -= 1;
                    if (h.y > t.y)
                        t.y += 1;
                    if (h.y < t.y)
                        t.y -= 1;

                    if(i == list.Count() - 1)
                        visited.Add($"{t.x}_{t.y}");
                }
            }  
        }
    }
}
