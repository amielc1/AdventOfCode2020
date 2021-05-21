using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day3
{
    public class Forest
    {
        private const char TREE = '#';
        private List<string> forest;
        public int Rows { get { return forest != null ? forest.Count : -1; } }
        public int Cols { get { return forest != null ? forest[0].Length : -1; } }
        public Forest(string path)
        {
            forest = File.ReadAllLines(path).ToList();
        }
        public bool IsTree(int row, int col)
        {
            var cell = forest[row][col];
            return cell == TREE;
        }
    }
    public class Day3TobogganTrajectory
    {

        string forestPath = @"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day3\Day3Input.txt";
     
        public int Clac()
        {
            var forest = new Forest(forestPath);
            int row = 0, col = 0, trees = 0;
            while (row < forest.Rows)// reached the end of the forest 
            {
                if (forest.IsTree(row, col))
                    trees++;

                GoNext(forest.Cols, ref row, ref col);
            }

            return trees; 
        }

        private static void GoNext(int charInRow, ref int row, ref int col)
        {
            col += 3;
            col %= charInRow;
            row += 1;
        }

    }
}
