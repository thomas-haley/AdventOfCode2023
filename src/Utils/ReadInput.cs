namespace Utils{


    public static class ReadInput{

        public static string[] read(string dayNum){
            FileInfo file = new FileInfo($"./input/day_{dayNum}.txt");
            IEnumerable<string> inputText = File.ReadLines(file.FullName);
            string[] output = inputText.ToArray();
            return output;
        }
    }
}