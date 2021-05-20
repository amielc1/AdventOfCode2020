using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day1
    {

        public int CalcPart1()
        {
            int mult = 0;
            int expense = 2020;
            var inputList = getPuzzleInput(@"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day1Input.txt");
            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < inputList.Count; j++)
                {
                    for (int k = 0; k < inputList.Count; k++)
                    { 
                        var sum = inputList[i] + inputList[j] + inputList[k];
                        if (sum == expense)
                        {
                            mult = inputList[i] * inputList[j] * inputList[k];
                            break;
                        }
                    }
                }
            }

            return mult;
        } 
          

        private List<int> getPuzzleInput(string puzzleInputFile)
        {
            var numbersStr = File.ReadAllLines(puzzleInputFile);
            var numberInt = numbersStr.Select(int.Parse).ToList();
            return numberInt;
        }

    }




}
