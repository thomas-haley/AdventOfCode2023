

using System.Text.RegularExpressions;

namespace Days
{
    class Day01 : DayClass
    {
   
        override public string Solution1(string[] input){
            Regex rx = new Regex(@"\d");
            int output = 0;
            foreach(string line in input){
                Console.WriteLine($"Finding match in line: {line}");
                MatchCollection matches = rx.Matches(line);
                string fullNum;
                if(matches.Count >= 2){
                    fullNum = matches.First().Value + matches.Last().Value;    
                } else {
                    fullNum = matches.First().Value + matches.First().Value;    
                }
                
                int num = int.Parse(fullNum); 
                output += num;
            }
            return output.ToString();
        }
        override public string Solution2(string[] input){
            Regex rx = new Regex(@"((?<=o)(ne))|((?<=t)(wo))|((?<=t)(hree))|((?<=f)(our))|((?<=f)(ive))|((?<=s)(ix))|((?<=s)(even))|((?<=e)(ight))|((?<=n)(ine))|\d");
            int output = 0;
            var numMap = new Dictionary<string, string>() 
            {
                {"one", "1"}, 
                {"two", "2"}, 
                {"three", "3"}, 
                {"four", "4"}, 
                {"five", "5"}, 
                {"six", "6"}, 
                {"seven", "7"}, 
                {"eight", "8"}, 
                {"nine", "9"} 
            };

            foreach(string line in input){
                MatchCollection matches = rx.Matches(line);
                string firstMatchNum;
                string lastMatchNum;
                if(matches.Count >= 2){
                    firstMatchNum = matches.First().Value;
                    if(firstMatchNum.Length > 1){
                        firstMatchNum = line[matches.First().Index - 1] + firstMatchNum;
                        firstMatchNum = numMap[firstMatchNum];
                    }

                    lastMatchNum = matches.Last().Value;
                    if(lastMatchNum.Length > 1){
                        lastMatchNum = line[matches.Last().Index - 1] + lastMatchNum;
                        lastMatchNum = numMap[lastMatchNum];
                    }
                } else {
                    firstMatchNum = matches.First().Value;
                    if(firstMatchNum.Length > 1){
                        firstMatchNum = line[matches.First().Index - 1] + firstMatchNum;
                        firstMatchNum = numMap[firstMatchNum];
                    }

                    lastMatchNum = matches.First().Value;
                    if(lastMatchNum.Length > 1){
                        lastMatchNum = line[matches.First().Index - 1] + lastMatchNum;
                        lastMatchNum = numMap[lastMatchNum];
                    }
                } 

                string fullNum = firstMatchNum + lastMatchNum;
                
                int num = int.Parse(fullNum); 
                output += num;
            }
            return output.ToString();
        }
    }
}