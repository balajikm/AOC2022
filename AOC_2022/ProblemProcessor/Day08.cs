namespace AOC_2022.ProblemProcessor
{
    internal class Day08
    {
        public Day08()
        {
            string text = File.ReadAllText($"./Inputs/{this.GetType().Name}.txt");
            var stringArray = text.Split(Environment.NewLine, StringSplitOptions.None);
            var intArray = stringArray.Select(x => x.ToCharArray()).ToArray();
            int rowSize = intArray.Count();
            int columnSize = intArray[0].Count();
            int visibileTrees = 0;
            List<int> scenicScores = new List<int>();
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (i == 0 || j == 0 || i == rowSize - 1 || j == columnSize - 1)
                    {
                        visibileTrees++;
                    }
                    else
                    {
                        int treeHeight;
                        int.TryParse(intArray[i][j].ToString(), out treeHeight);
                        if (IsVisibleFromLeft(treeHeight, intArray, i, j) || IsVisibleFromTop(treeHeight, intArray, i, j)
                            || IsVisibleFromRight(treeHeight, intArray, i, j) || IsVisibleFromBottom(treeHeight, intArray, i, j))
                        {
                            visibileTrees++;
                        }
                        scenicScores.Add(NumberOfTreeVisibileInLeft(treeHeight, intArray, i, j)
                             * NumberOfTreeVisibileInTop(treeHeight, intArray, i, j)
                            * NumberOfTreeVisibileInRight(treeHeight, intArray, i, j)
                            * NumberOfTreeVisibileInBottom(treeHeight, intArray, i, j));
                    }
                }
            }

            Console.WriteLine("Visible trees count from the grid : " + visibileTrees.ToString());
            int highestScenary = scenicScores.Max();
            Console.WriteLine("Highest scenary value is : " + highestScenary);
            Console.ReadLine();
        }

        private bool IsVisibleFromLeft(int treeHeight, char[][] array, int row, int column)
        {
            if (column == 0)
                return true;
            int leftTree;
            int.TryParse(array[row][column - 1].ToString(), out leftTree);
            if (treeHeight > leftTree)
            {
                return IsVisibleFromLeft(treeHeight, array, row, column - 1);
            }
            return false;
        }

        private bool IsVisibleFromTop(int treeHeight, char[][] array, int row, int column)
        {
            if (row == 0)
                return true;

            int topTree;
            int.TryParse(array[row - 1][column].ToString(), out topTree);
            if (treeHeight > topTree)
            {
                return IsVisibleFromTop(treeHeight, array, row - 1, column);
            }
            return false;
        }

        private bool IsVisibleFromRight(int treeHeight, char[][] array, int row, int column)
        {
            if (column == array[0].Count() - 1)
                return true;

            int rightTree;
            int.TryParse(array[row][column + 1].ToString(), out rightTree);
            if (treeHeight > rightTree)
            {
                return IsVisibleFromRight(treeHeight, array, row, column + 1);
            }
            return false;
        }

        private bool IsVisibleFromBottom(int treeHeight, char[][] array, int row, int column)
        {
            if (row == array.Count() - 1)
                return true;

            int bottomTree;
            int.TryParse(array[row + 1][column].ToString(), out bottomTree);
            if (treeHeight > bottomTree)
            {
                return IsVisibleFromBottom(treeHeight, array, row + 1, column);
            }
            return false;
        }

        private int NumberOfTreeVisibileInLeft(int treeHeight, char[][] array, int row, int column)
        {
            int numberOfTreesVisibile = 0;
            for (int i = column - 1; i >= 0; i--)
            {
                int leftTree;
                int.TryParse(array[row][i].ToString(), out leftTree);
                if (leftTree < treeHeight)
                    numberOfTreesVisibile++;
                else
                {
                    numberOfTreesVisibile++;
                    break;
                }
            }
            return numberOfTreesVisibile;
        }

        private int NumberOfTreeVisibileInTop(int treeHeight, char[][] array, int row, int column)
        {
            int numberOfTreesVisibile = 0;
            for (int i = row - 1; i >= 0; i--)
            {
                int topTree;
                int.TryParse(array[i][column].ToString(), out topTree);
                if (topTree < treeHeight)
                    numberOfTreesVisibile++;
                else
                {
                    numberOfTreesVisibile++;
                    break;
                }
            }
            return numberOfTreesVisibile;
        }

        private int NumberOfTreeVisibileInRight(int treeHeight, char[][] array, int row, int column)
        {
            int numberOfTreesVisibile = 0;
            for (int i = column + 1; i < array[0].Count(); i++)
            {
                int rightTree;
                int.TryParse(array[row][i].ToString(), out rightTree);
                if (rightTree < treeHeight)
                    numberOfTreesVisibile++;
                else
                {
                    numberOfTreesVisibile++;
                    break;
                }
            }
            return numberOfTreesVisibile;
        }

        private int NumberOfTreeVisibileInBottom(int treeHeight, char[][] array, int row, int column)
        {
            int numberOfTreesVisibile = 0;
            for (int i = row + 1; i < array[0].Count(); i++)
            {
                int bottomTree;
                int.TryParse(array[i][column].ToString(), out bottomTree);
                if (bottomTree < treeHeight)
                    numberOfTreesVisibile++;
                else
                {
                    numberOfTreesVisibile++;
                    break;
                }
            }
            return numberOfTreesVisibile;
        }
    }
}