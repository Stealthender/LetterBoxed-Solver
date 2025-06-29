public class MainClass
{
    private static int nsides = 4;
    private static int nletters = 12;
    private static int lettersperside = nletters/nsides;

    public static void Main()
    {
        char[] allsides = getInput();
        char[][] sides = splitArray(allsides);
        string[] wordlist = LibraryClass.library(sides, nsides);
        SolveClass.Solve(wordlist, allsides);

    }

    public static char [] getInput() 
    {
        Console.WriteLine("Input sides in format: aaabbbcccddd");
        char[] allsides = Console.ReadLine().ToLower().ToCharArray(); ;
        while(validateInput(allsides) == false)
        {
            return getInput();
        }
        return allsides;

    }

    public static bool validateInput(char[] input) 
    {
        if (input == null || input.Length != nletters)
        {
            Console.WriteLine("Invalid input, enter " + nletters + " letters");
            return false;
        }
        for(int i = 0; i < input.Length; i++)
        {
            if (input[i] < 'a' || input[i] > 'z') //Checks if inputted elements are between a and z (Char.IsLetter allows letters not within the english alphabet)
            {
                Console.WriteLine("Invalid input, no symbols or numbers");
                return false;
            }
        }
        for(int j = 0; j < input.Length; j += lettersperside)
        {
            for(int k = 0; k < lettersperside; k++)
            {
                Console.Write(input[j + k] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Are these the correct sides Y/N");
        string answer = Console.ReadLine().ToUpper();
        while (!answer.Equals("Y") && !answer.Equals("N"))
        {
            answer = Console.ReadLine().ToUpper();
        }
        if (answer.Equals("N"))
        {
            return false;
        }
        return true;
    }

    public static char [][] splitArray(char[] array)
    {
        char[][] splitArr = new char[nsides][];
        for(int i = 0; i < nsides; i++)
        {
            splitArr[i] = new char[lettersperside];
            for (int j = 0; j < lettersperside; j++)
            {
                splitArr[i][j] = array[(i * lettersperside) + j];
            }
        }
        return splitArr;
    }
}
