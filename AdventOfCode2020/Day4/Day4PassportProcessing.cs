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
            if (Value == null) 
                return false;
            if (Value.Length != 4)
                return false;
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
            if (Value == null) 
                return false;
            if (Value.Length != 4)
                return false;
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
    public class ExpirationYear : IValidationRole
    {
        //eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        public string Value { get; set; }
        public string FrendlyName { get { return "eyr"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;
            if (Value == null) 
                return false;
            if (Value.Length != 4)
                return false;
            int value;
            try
            {
                value = Convert.ToInt32(Value);
            }
            catch
            {
                return false;
            }

            var isvalid = value >= 2020 && value <= 2030 ? true : false;
            return isvalid;
        }
    }
    public class Height : IValidationRole
    {
        //hgt(Height) - a number followed by either cm or in:
        public string Value { get; set; }
        public string FrendlyName { get { return "hgt"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;
            if (Value == null) 
                return false;

            var headindex = Value.Contains("in") ? Value.IndexOf("in") : Value.IndexOf("cm");
            if (headindex == -1)
                return false;
            string head = Value.Substring(headindex, 2);
            if (head != "cm" && head != "in")
                return false;

            int value;
            try
            {
                value = Convert.ToInt32(Value.Substring(0, Value.Length - 2));
            }
            catch
            {
                return false;
            }

            bool isvalid = false;
            if (head == "cm")
            {
                //If cm, the number must be at least 150 and at most 193.
                isvalid = value >= 150 && value <= 193 ? true : false;
            }
            else
            {
                //If in, the number must be at least 59 and at most 76.
                isvalid = value >= 59 && value <= 76 ? true : false;
            }
            return isvalid;
        }
    }
    public class HairColor : IValidationRole
    {
        //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        public string Value { get; set; }
        public string FrendlyName { get { return "hcl"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;
            if (Value == null) 
                return false;
            var head = Value[0];
            if (head != '#')
                return false;


            foreach (var item in Value.Substring(1))
            {
                if (!char.IsDigit(item))
                {
                    if (!(item >= 'a' && item <= 'f'))
                        return false;
                }
            }
            return true;
        }
    }
    public class EyeColor : IValidationRole
    {
        //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        public string Value { get; set; }
        public string FrendlyName { get { return "ecl"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;
            if (Value == null) 
                return false;
            string[] colors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var isValidColor = colors.Any(color => color == Value);
            return isValidColor;
        }
    }
    public class PassportID : IValidationRole
    {
        //pid(Passport ID) - a nine-digit number, including leading zeroes.
        public string Value { get; set; }
        public string FrendlyName { get { return "pid"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid()
        {
            if (!IsRequired)
                return true;
            if (Value == null) 
                return false;
            if (Value.Length != 9)
                return false;
            try
            {
                int value;
                var parse = int.TryParse(Value, out value);
                if (!parse)
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
    public class CountryID : IValidationRole
    {
        //cid(Country ID) - ignored, missing or not.
        public string Value { get; set; }
        public string FrendlyName { get { return "cid"; } }
        public bool IsRequired { get { return true; } }
        public bool IsValid() => true;  
    }

    public class Passport
    {
          
        List<IValidationRole> validationRules = new List<IValidationRole>();
        public bool  IsPassportValid { get; private set; }
        public Passport()
        {
            GenerateRulse();
        }
        private void GenerateRulse()
        {
            validationRules.Add(new BirthYearRule());
            validationRules.Add(new IssueYear());
            validationRules.Add(new ExpirationYear());
            validationRules.Add(new Height());
            validationRules.Add(new HairColor());
            validationRules.Add(new EyeColor());
            validationRules.Add(new PassportID());
            validationRules.Add(new CountryID());
        }
        public bool IsValid()
        {
            IsPassportValid = validationRules.All(r => r.IsValid());
            return IsPassportValid;
        }
        public void Parse(string passport)
        {
            var items = passport.Trim().Split(null);
            foreach (var item in items)
            {
                var i = item.Split(':');
                var key = i[0];
                var val = i[1];
                var rule = validationRules.Find(r => r.FrendlyName == key);
                rule.Value = val;

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
            //133
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
