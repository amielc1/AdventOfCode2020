using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day2
{

    public class PasswordCriteria
    {
        public PasswordCriteria(string criteriaRaw)
        {
            //7-8 h: hhhhhhhbqf
            var raw = criteriaRaw.Split(" ");
            var minMax = raw[0].Split("-");
            Min = int.Parse(minMax[0]);
            Max = int.Parse(minMax[1]);
            Letter = raw[1][0];
            Password = raw[2];
        }
        public int Max { get; set; }
        public int Min { get; set; }
        public char Letter { get; set; }
        public string Password { get; set; }

        public bool IsValidPart2()
        {
            var first = Password[Min - 1] == Letter;
            var second = Password[Max - 1] == Letter;
            return (first && !second) || (second && !first);
        }

        public bool IsValid()
        {
            var accurence = Password.Where(c => c == Letter).Count();
            var isValid = accurence >= Min && accurence <= Max ? true : false;
            return isValid;
        }
    }
    public class Day2_Password_Philosophy
    {
        public int Calc()
        {
            string passPath = @"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day2\Passwords.txt";
            var rawPass = File.ReadAllLines(passPath).ToList();
            //List<string> rawPass = new List<string>() {
            //    "1-3 a: abcde" ,
            //    "1-3 b: cdefg",
            //    "2-9 c: ccccccccc"
            //};
            List<PasswordCriteria> passwordCriteria = new List<PasswordCriteria>();
            rawPass.ForEach(raw =>
            {
                passwordCriteria.Add(new PasswordCriteria(raw));
            });

            var validItems = passwordCriteria.Where(i => i.IsValidPart2()).Count();
            return validItems;
        }
    }
}
