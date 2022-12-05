using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Day05
    {
        public Day05()
        {
            string text = File.ReadAllText("./Inputs/Day05.txt");
            string[] textArray = text.Split("\r\n");
            List<Stack<char>> containerRack = new List<Stack<char>>();
            containerRack.Add(new Stack<char>(new List<char>() { 'R', 'S', 'L', 'F', 'Q' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'N', 'Z', 'Q', 'G', 'P', 'T' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'S', 'M', 'Q', 'B' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'T', 'G', 'Z', 'J', 'H', 'C', 'B', 'Q' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'P', 'H', 'M', 'B', 'N', 'F', 'S' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'P', 'C', 'Q', 'N', 'S', 'L', 'V', 'G' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'W', 'C', 'F' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'Q', 'H', 'G', 'Z', 'W', 'V', 'P', 'M' }));
            containerRack.Add(new Stack<char>(new List<char>() { 'G', 'Z', 'D', 'L', 'C', 'N', 'R' }));
            if (false)
                UsingCrateMover9000(textArray, containerRack);
            else
                UsingCrateMover9001(textArray, containerRack);
            string lastContainer = string.Empty;
            foreach (var item in containerRack)
            {
                lastContainer += item.Peek().ToString();
            }
            Console.WriteLine("prob1, Last container char series is : " + lastContainer);
            Console.ReadLine();
        }

        private static void UsingCrateMover9000(string[] textArray, List<Stack<char>> containerRack)
        {
            for (int i = 0; i < textArray.Length; i++)
            {
                string[] action = textArray[i].Split(" ");
                int count = Convert.ToInt32(action[1]);
                int from = Convert.ToInt32(action[3]);
                int to = Convert.ToInt32(action[5]);
                for (int j = 0; j < count; j++)
                {
                    containerRack[to - 1].Push(containerRack[from - 1].Pop());
                }

            }
        }

        private static void UsingCrateMover9001(string[] textArray, List<Stack<char>> containerRack)
        {
            for (int i = 0; i < textArray.Length; i++)
            {
                string[] action = textArray[i].Split(" ");
                int count = Convert.ToInt32(action[1]);
                int from = Convert.ToInt32(action[3]);
                int to = Convert.ToInt32(action[5]);
                Stack<char> tempRack = new Stack<char>();
                for (int j = 0; j < count; j++)
                {
                    tempRack.Push(containerRack[from - 1].Pop());
                }
                foreach(char c in tempRack)
                {
                    containerRack[to - 1].Push(c);
                }
                

            }
        }


    }
}
