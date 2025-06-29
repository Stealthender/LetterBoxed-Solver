public class LibraryClass
{
    //This class reduces the wordlists to only valid words, by removing words that contain characters not in the input
    //and removing words with adjacent letters from the same side, this allows the sides to become irrelevant after this class
    public static string[] library(char[][] sides, int nsides)
    {
        List<string> words = new List<string>();
        string word;

        using StreamReader reader = new("C:/Users/zerte/OneDrive/Documents/GitHub/LetterBoxed-Solver/wordlist/wordlist.txt");
        while((word = reader.ReadLine()) != null)
        {
            bool isvalid = isValid(sides, word, nsides);
            if(isvalid == true)
            {
                words.Add(word);
            }
        }
        reader.Close();
        return words.ToArray();
    }
    public static bool isValid(char[][] sides, string word, int nsides)
    {
        int lastside = -1;

        for(int i = 0; i < word.Length; i++)
        {
            char letter = word[i];
            int curside = -1;

            for (int s = 0; s < nsides; s++) //s for side
            {
                if (sides[s].Contains(letter)) //finds which side contains the current letter
                {
                    curside = s;
                    break;
                }
            }

            if(curside == -1) //if no side contains the letter
            {
                return false;
            }

            if (curside == lastside) //Checks if the side of the previous letter is the same as the current letter
            {
                return false;
            }

            lastside = curside;
        }
        return true;
    }
}
