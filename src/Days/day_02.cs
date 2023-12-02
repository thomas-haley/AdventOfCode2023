

namespace Days
{
    class Day02 : DayClass
    {
        protected int RED_MAX = 12;
        protected int GREEN_MAX = 13;
        protected int BLUE_MAX = 14;
        override public string Solution1(string[] input){
            List<int> possibleGames = new List<int>();
            foreach(string game in input){
                string[] gameData = game.Split(':', ';');
                string gameString = gameData.First().Split(" ").Last();
                gameData = gameData.Skip(1).ToArray();
                bool validRed = true;
                bool validGreen = true;
                bool validBlue = true;
                foreach(string bagPull in gameData){
                    string[] bagData = bagPull.Split(",");
                    foreach(string pull in bagData){
                        string[] colorData = pull.Split(" ");
                        colorData = colorData.Skip(1).ToArray();
                        switch(colorData.Last()){
                            case "red":
                                if(int.Parse(colorData.First()) > RED_MAX){
                                    validRed = false;
                                }
                                break;
                            case "green":
                                if(int.Parse(colorData.First()) > GREEN_MAX){
                                    validGreen = false;
                                }
                                break;
                            case "blue":
                            if(int.Parse(colorData.First()) > BLUE_MAX){
                                    validBlue = false;
                                }
                                break;
                        }
                    }
                }

                if(validRed && validGreen && validBlue){
                    possibleGames.Add(int.Parse(gameString));
                }

            }
            int gameSum = possibleGames.Sum();
            return gameSum.ToString();
        }













        override public string Solution2(string[] input){
            List<int> possibleGames = new List<int>();
            foreach(string game in input){
                string[] gameData = game.Split(':', ';');
                string gameString = gameData.First().Split(" ").Last();
                gameData = gameData.Skip(1).ToArray();
                int maxUsedRed = 0;
                int maxUsedGreen = 0;
                int maxUsedBlue = 0;
                foreach(string bagPull in gameData){
                    string[] bagData = bagPull.Split(",");
                    foreach(string pull in bagData){
                        string[] colorData = pull.Split(" ");
                        colorData = colorData.Skip(1).ToArray();
                        switch(colorData.Last()){
                            case "red":
                                
                                if(int.Parse(colorData.First()) > maxUsedRed){
                                    maxUsedRed = int.Parse(colorData.First());
                                }
                                
                                break;
                            case "green":
                                
                                if(int.Parse(colorData.First()) > maxUsedGreen){
                                    maxUsedGreen = int.Parse(colorData.First());
                                }
                                
                                break;
                            case "blue":

                                if(int.Parse(colorData.First()) > maxUsedBlue){
                                    maxUsedBlue = int.Parse(colorData.First());
                                }
                                
                                break;
                        }
                    }
                }


                possibleGames.Add(maxUsedRed * maxUsedGreen * maxUsedBlue);
                

            }
            int gameSum = possibleGames.Sum();
            return gameSum.ToString();
        }
    }
}