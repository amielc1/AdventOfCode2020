using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day4
{

    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; } 
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }

        public bool IsValid()
        {
            var valid =  !string.IsNullOrEmpty(BirthYear) &&
                !string.IsNullOrEmpty(IssueYear) &&
                !string.IsNullOrEmpty(ExpirationYear) && 
                !string.IsNullOrEmpty(Height) &&
                !string.IsNullOrEmpty(HairColor) &&
                !string.IsNullOrEmpty(EyeColor) &&
                !string.IsNullOrEmpty(PassportID);
            //&&  !string.IsNullOrEmpty(CountryID)

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
                switch (key)
                {
                    case "byr":
                        BirthYear = val;
                        break;
                    case "iyr":
                        IssueYear = val;
                        break;
                    case "eyr":
                        ExpirationYear = val;
                        break;
                    case "hgt":
                        Height = val;
                        break;
                    case "hcl":
                        HairColor = val;
                        break;
                    case "ecl":
                        EyeColor = val;
                        break;
                    case "pid":
                        PassportID = val;
                        break;
                    case "cid":
                        CountryID = val;
                        break;
                    default:
                        break;
                }
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
