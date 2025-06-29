public class SolveClass
{
    //This Class will handle the refined wordlist to solve the Letterboxed
    //This runs on the assumption there is always a two word solution
    public static void Solve(string[] wordlist, char[] allsides)
    {
        bool answered = false;
        //My strategy is to sort the wordlist by most unique characters
        var sortedlist = wordlist.OrderByDescending(w => w.Distinct().Count()).ToList();
        //Map the letters to a hashtable 
        var alllettersset = new HashSet<char>(allsides);
        //Loop through the sorted list
        for(int i = 0; i < sortedlist.Count(); i++)
        {
            string wordOne = sortedlist[i];
            //Map the word to hashtable, this will later be combined with another
            var wordOneset = new HashSet<char>(wordOne);

            foreach(string wordTwo in wordlist)
            {
                if(wordOne == wordTwo)
                {
                    continue;
                }

                //Check if the 2nd word begins with the ending letter of the 1st word or ends with the starting letter
                if(wordTwo[0] != wordOne[wordOne.Length - 1] && wordTwo[wordTwo.Length - 1] != wordOne[0])
                {
                    continue;
                }

                //Combine wordone and wordtwo sets
                var combinedset = new HashSet<char>(wordOneset);
                foreach(char letter in wordTwo)
                {
                    combinedset.Add(letter);
                }

                //Check if all letters are used up by comparing sets
                if (combinedset.SetEquals(alllettersset))
                {
                    if (wordOne[wordOne.Length - 1] == wordTwo[0])
                    {
                        Console.WriteLine($"Solution: {wordOne} -> {wordTwo}");
                    }

                    else
                    {
                        Console.WriteLine($"Solution: {wordTwo} -> {wordOne}");
                    }
                    answered = true;
                }
                
            }
        }
        if(answered == true)
        {
            return;
        }
        Console.WriteLine("Solution not found");
       
    }

}
