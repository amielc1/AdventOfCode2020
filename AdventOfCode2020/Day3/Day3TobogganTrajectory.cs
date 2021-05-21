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
        Forest forest;
        public Day3TobogganTrajectory()
        {
            forest = new Forest(forestPath);
        }

        public int Calc(int right, int down)
        {
            int row = 0, col = 0, trees = 0;

            while (row < forest.Rows)// reached the end of the forest 
            {
                if (forest.IsTree(row, col))
                    trees++;

                GoNext(ref row, ref col, right, down);
            }

            return trees;
        }
        public int CalcAll()
        {
            //Right 1, down 1.
            //Right 3, down 1. (This is the slope you already checked.)
            //Right 5, down 1.
            //Right 7, down 1.
            //Right 1, down 2.

            List<Tuple<int, int>> travers = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2)
            };

            var multList = travers.Select(i => Calc(i.Item1, i.Item2));
            var res = multList.Aggregate((x, y) => x * y);
            return res; 
        }

      

        private void GoNext(ref int row, ref int col, int right, int down)
        {
            col += right;
            col %= forest.Cols;
            row += down;
        }

    }
}
