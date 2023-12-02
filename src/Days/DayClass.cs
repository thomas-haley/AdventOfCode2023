namespace Days 
{
    public abstract class DayClass {
        public string RunSolution(string inputNum, string solutionNum){
            string[] inputData = Utils.ReadInput.read(inputNum);
            string output;
            if(solutionNum == "1"){
                output = Solution1(inputData);
            } else{
                output = Solution2(inputData);
            }
            return output;
        }
        public abstract string Solution1(string[] input);
        public abstract string Solution2(string[] input);
    }
}