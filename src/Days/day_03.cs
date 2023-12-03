

using System.IO;
using System.Text.RegularExpressions;

namespace Days
{
    class Day03 : DayClass
    {

        override public string Solution1(string[] input){
           
            List<List<Dictionary<string, string>>> schemData = buildSchemData(input);
            int runningSum = 0;
            //Loop over lines in schemData matches to find non number symbols
            for(int i = 0; i < schemData.Count; i++){
                List<Dictionary<string, string>> lineMatches = schemData[i];
            
            // foreach(List<Dictionary<string, string>> lineMatches in schemData){
                //Loop over individual matches in lineMatches to find non number symbols
                for(int j = 0; j < lineMatches.Count; j++){
                    Dictionary<string, string> match = lineMatches[j];
                
                // foreach(Dictionary<string, string> match in lineMatches){
                    bool validNum = Int32.TryParse(match["value"], out Int32 testInt);
                    //If valid number continue because we are looking for symbols
                    if(validNum){
                        continue;
                    }

                    int matchX = int.Parse(match["startX"]);
                    List<int> rowAboveSearch = new List<int>{matchX - 1, matchX, matchX + 1};
                    List<int> sameRowSearch = new List<int>{matchX - 1, matchX + 1};
                    List<int> rowBelowSearch = new List<int>{matchX - 1, matchX, matchX + 1};

                    List<int>? uRes = null;
                    List<int>? mRes = null;
                    List<int>? dRes = null;
                    List<dynamic> matchRes;
                    if(match["line"] != "0"){
                        matchRes = findLineMatch(schemData[int.Parse(match["line"]) - 1], int.Parse(match["line"]) - 1, rowAboveSearch);
                        schemData[int.Parse(match["line"]) - 1] = matchRes[0];
                        uRes = matchRes[1];
                    }

                    matchRes = findLineMatch(schemData[int.Parse(match["line"])], int.Parse(match["line"]), sameRowSearch);
                    //Update line matches to remove any added numbers
                    if(matchRes[0].Count != schemData[int.Parse(match["line"])].Count){
                        schemData[int.Parse(match["line"])] = matchRes[0];
                        lineMatches = matchRes[0];
                        //Decrement j by the number of matches removed by updating line data
                        j -= matchRes[1].Count;
                    }
                    mRes = matchRes[1];

                    //If on not last line
                    if(int.Parse(match["line"]) + 1 < schemData.Count){
                        if(match["line"] == "1" && match["startX"] == "35" && match["value"] == "%"){
                            Console.WriteLine("here2");
                        }
                        matchRes = findLineMatch(schemData[int.Parse(match["line"]) + 1], int.Parse(match["line"]) + 1, rowBelowSearch);
                        Console.WriteLine("here");
                        //Update line matches to remove any added numbers
                        schemData[int.Parse(match["line"]) + 1] = matchRes[0];
                        dRes = matchRes[1];
                    }


                    //Add each of the number matches to runningSum
                    if(uRes != null){
                        foreach(int res in uRes){
                            runningSum += res;
                        }
                    }

                    foreach(int res in mRes){
                        runningSum += res;
                    }
                

                    if(dRes != null){
                        foreach(int res in dRes){
                            runningSum += res;
                        }
                    }
                // }
                }
            // }
            }


            return runningSum.ToString();
        }

        private List<List<Dictionary<string, string>>> buildSchemData(string[] input){
             //Regex to find digits and characters except for period
            Regex rx = new Regex(@"([^\w.]|\d{1,})");
            List<List<Dictionary<string, string>>> schemData = new List<List<Dictionary<string, string>>>();
            int lineNum = 0;
            foreach(string line in input){
                List<Dictionary<string, string>> lineData = new List<Dictionary<string, string>>();
                MatchCollection matches = rx.Matches(line);
                foreach(Match match in matches){
                    lineData.Add(new Dictionary<string, string>(){
                        {"line", lineNum.ToString()},
                        {"value", match.Value},
                        {"startX", match.Index.ToString()},
                        {"endX", (match.Index + match.Length - 1).ToString()}
                    });
                }
                schemData.Add(lineData);
                lineNum++;
            }
            return schemData;
        }

        private List<dynamic> findLineMatch(List<Dictionary<string, string>> lineMatches, int lineNum, List<int> searchIndex){

            List<int> lineRes = new List<int>();
            foreach(int idxSearch in searchIndex){
                
                for(int i = 0; i < lineMatches.Count; i++){
                    int parseStart = int.Parse(lineMatches[i]["startX"]);
                    int parseEnd = int.Parse(lineMatches[i]["endX"]);
                    if(idxSearch >= parseStart && idxSearch <= parseEnd && Int32.TryParse(lineMatches[i]["value"], out int voidInt)){
                        lineRes.Add(int.Parse(lineMatches[i]["value"]));
                        lineMatches.Remove(lineMatches[i]);
                        i = lineMatches.Count;
                    }
                }
            }

            return new List<dynamic>(){lineMatches, lineRes};
        }
        

        override public string Solution2(string[] input){
            return "";
        }
    }
}