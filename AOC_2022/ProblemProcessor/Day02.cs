using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022.ProblemProcessor
{
    internal class Day02
    {
        public Day02()
        {
            string text = File.ReadAllText("./Inputs/Day02Prob01.txt");
            string[] arrayResult = text.Split("\r\n");
            int[][] convertedPoints = new int[arrayResult.Length][];
            int problem = 2;
            for(int i = 0; i < arrayResult.Length; i++)
            {
                if (problem == 1)
                    convertedPoints[i] = new int[] { getEqualantInt(arrayResult[i].Substring(0, 1)), getEqualantInt(arrayResult[i].Substring(2, 1)) };
                else
                    convertedPoints[i] = getNewStrategyPoints(arrayResult[i]);
            }
            long yourFinalScore = 0;
            for(int i = 0; i < convertedPoints.Length; i++)
            {
                int currentRoundScore = calculateScore(convertedPoints[i]) + convertedPoints[i][1];
                yourFinalScore += currentRoundScore;
            }
            Console.WriteLine("Your score is : " + yourFinalScore);
            Console.ReadLine();
            
        }

        private int[] getNewStrategyPoints(string v)
        {
            int[] point = new int[2];
            point[0] = getEqualantInt(v.Substring(0, 1));
            point[1] = playBasedOnOpponentAction(point[0],v.Substring(2, 1));
            return point;

        }

        private int getEqualantInt(string character)
        {
            if (character == "A" || character == "X")
                return 1;
            else if(character == "B" || character == "Y") 
                return 2;
            else
                return 3;
        }

        private int calculateScore(int[] points)
        {
            int matchResult = decideResult(points);
            if (matchResult == 0)
                return 3;
            else if (points[1] == matchResult)
                return 6;
            else
                return 0;
        }

        private int decideResult(int[] points)
        {
            if (points.Contains(1) && points.Contains(3))
                return 1;
            else if (points.Contains(3) && points.Contains(2))
                return 3;
            else if (points.Contains(2) && points.Contains(1))
                return 2;
            else
                return 0;
        }

        private int playBasedOnOpponentAction(int opponentAction, string yourHint)
        {
            if(yourHint == "X")
            {
                if (opponentAction == 1)
                    return 3;
                else if (opponentAction == 2)
                    return 1;
                else
                    return 2;
            }
            else if(yourHint == "Y")
            {
                return opponentAction;
            }
            else
            {
                if (opponentAction == 3)
                    return 1;
                else if (opponentAction == 2)
                    return 3;
                else
                    return 2;
            }
        }
    }
}
