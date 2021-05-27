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
        private HashSet<char> charSet;
        public int GroupLen { get { return charSet.Count; } }
        public GroupSet(string word)
        {
            charSet = new HashSet<char>();
            foreach (char chr in word)
            {
                charSet.Add(chr);
            }
        }
    }
    public class Day6CustomCustoms
    {
        public Day6CustomCustoms()
        {
            string path = @"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day6\Day6Input.txt";
            var grouplines = File.ReadAllLines(path).ToList();
            List<GroupSet> groupSetList = new List<GroupSet>();
            StringBuilder word = new StringBuilder();
            foreach (var line in grouplines)
            {
                if (line != string.Empty) 
                {
                    word.Append(line);
                }
                else
                {
                    makeGroup(groupSetList, word);
                }
            }
            makeGroup(groupSetList, word);
            var sum = groupSetList.Sum(g => g.GroupLen);
        }

        private static void makeGroup(List<GroupSet> groupList, StringBuilder word)
        {
            if (word.Length > 0)
            {
                var gSet = new GroupSet(word.ToString());
                groupList.Add(gSet);
                word.Clear();
            }
        }
    }
}
