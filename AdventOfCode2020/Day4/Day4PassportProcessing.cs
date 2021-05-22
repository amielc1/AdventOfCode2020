using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day4
{
    public interface IValidationRole
    {
        public bool IsRequired { get; }
        public string FrendlyName { get; }
        public string Value { get; set; }
        bool IsValid();
    }

    public class BirthYearRule : IValidationRole
    {
        //byr (Birth Year) - four digits; at least 1920 and at most 2002.
        public string Value { get; set; }
        public string FrendlyName { get { return "byr"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;

            int value;
            try
            {
                value = Convert.ToInt32(Value);
            }
            catch
            {
                return false; 
            }
    
            var isvalid = value >= 1920 && value <= 2005 ? true : false;
            return isvalid;
        }
    }
    public class IssueYear : IValidationRole
    {
        //iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        public string Value { get; set; }
        public string FrendlyName { get { return "iyr"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;

            int value;
            try
            {
                value = Convert.ToInt32(Value);
            }
            catch
            {
                return false;
            }

            var isvalid = value >= 2010 && value <= 2020 ? true : false;
            return isvalid;
        }
    }
    public class Passport
    { 
        //eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        //hgt(Height) - a number followed by either cm or in:
        //If cm, the number must be at least 150 and at most 193.
        //If in, the number must be at least 59 and at most 76.
        //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        //pid(Passport ID) - a nine-digit number, including leading zeroes.
        //cid(Country ID) - ignored, missing or not.

     List<IValidationRole> validationRules = new List<IValidationRole>();
        
        private void GenerateRulse()
        {
            validationRules.Add(new BirthYearRule());
        }
        public bool IsValid()
        {
            var valid = validationRules.All(r => r.IsValid());
            return valid;
        }
        public void Parse(string passport)
        {
            var items = passport.Trim().Split(null);
            foreach (var item in items)
            {
                var i = item.Split(':');
                var key = i[0];
                var val = i[1];
                var rule = validationRules.Find(r => r.FrendlyName == key).Value = val;
            }
        }
    }
    public class Day4PassportProcessing
    {
        string path = @"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day4\Day4Input.txt";
        public Day4PassportProcessing()
        {
            var passports = File.ReadAllLines(path).ToList();
            List<Passport> passportsList = new List<Passport>();
            StringBuilder passportRow = new StringBuilder();
            foreach (var item in passports)
            {
                if (item != string.Empty)//passport lines chunck
                {
                    passportRow.Append(item + " ");
                }
                else
                {
                    parseStringPassport(passportsList, passportRow);
                }
            }
            parseStringPassport(passportsList, passportRow);// for the finel chunck

            var validPassports = passportsList.Where(pass => pass.IsValid()).Count();
        }

        private static void parseStringPassport(List<Passport> passportsList, StringBuilder passportRow)
        {
            if (passportRow.Length > 0)
            {
                var pass = new Passport();
                pass.Parse(passportRow.ToString());
                passportsList.Add(pass);
                passportRow.Clear();
            }
        }
    }
}
