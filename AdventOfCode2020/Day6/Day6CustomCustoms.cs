using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day6
{
    public class GroupSet
    {
        public List<string> pesronWord = new List<string>();
        public int Sum { get; set; }
        public GroupSet()
        {

        }
    }
    public class Day6CustomCustoms
    {
        public Day6CustomCustoms()
        {
            string path = @"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day6\Day6Input.txt";
            var grouplines = File.ReadAllLines(path).ToList();

            List<GroupSet> groups = new List<GroupSet>();
            GroupSet tempGroup = new GroupSet();
            foreach (var line in grouplines)
            {
                if (line != string.Empty)
                {
                    tempGroup.pesronWord.Add(line);
                }
                else
                {
                    groups.Add(tempGroup);
                    tempGroup = new GroupSet();
                }
            }
            groups.Add(tempGroup);
             
            foreach (var group in groups)
            {
                if (group.pesronWord.Count == 1)
                {
                    group.Sum = group.pesronWord[0].Length;
                    continue;
                }
                foreach (char chr in group.pesronWord[0])
                {
                    bool flag = true;
                    for (int i = 1; i < group.pesronWord.Count; i++)
                    {
                        if (!group.pesronWord[i].Contains(chr))
                            flag = false;
                    }
                    if (flag)
                        group.Sum++;
                }
            }

            var sum = groups.Sum(g => g.Sum);
        }


    }
}
