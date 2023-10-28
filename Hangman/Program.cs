namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_ATTEMPTS = 6;

            List<string> hangmanWords = new List<string>
            {
                "BANANA", "CIRCLE", "DREAMS", "ELEPHANT", "FLOWER", "GUITAR", "HAMMER",
                "ICEBERG", "JACKET", "KANGAROO", "LANTERN", "MUFFIN", "NESTLE",
                "ORANGE", "PENCIL", "QUARTZ", "RIVER", "SPIDER", "TURTLE", "UNICORN",
                "VIOLET", "WINDOW", "XYLOPHONE", "YELLOW", "ZEBRA", "ANIMAL",
                "BOTTLE", "CASTLE", "DESERT", "ENERGY", "FARMER", "GLOBE", "HABITAT",
                "INSECT", "JUNGLE", "KITTEN", "LEAF", "MIRROR", "NOODLE", "OSTRICH",
                "PLANET", "RUSTIC", "SPRING", "TEMPLE", "UMBRELLA", "VOLCANO",
                "WAGON", "XENON", "YARN", "ZIGZAG"
            };

            int randomNumber = new Random().Next(0, hangmanWords.Count);
            string mysteryWord = hangmanWords[randomNumber];
            char[] displayedWord = new char[mysteryWord.Length]; //Initialize the character array "displayedWord"

            bool hasUserWon = false;

            for (int i = 0; i < displayedWord.Length; i++)  // Initialize game state with underscores
            {
                displayedWord[i] = '_';
            }
            int incorrectTries = 0;
            while (incorrectTries < MAX_ATTEMPTS)
            {
                Console.WriteLine("Hangman Game");
                Console.WriteLine("============");
                Console.WriteLine($"Guess the letters to a {mysteryWord.Length} letter word.\n");
                Console.WriteLine(displayedWord);
                Console.WriteLine();

                Console.WriteLine("Enter a letter:");
                char upperKeyChar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.Clear(); //Clear text
                Console.WriteLine($"You entered {upperKeyChar}\n");

                bool isCorrect = false;

                for (int i = 0; i < mysteryWord.Length; i++)
                {
                    if (mysteryWord[i] == upperKeyChar)
                    {
                        isCorrect = true;
                        displayedWord[i] = upperKeyChar;
                    }
                }

                if (isCorrect)
                {
                    Console.WriteLine("Correct! You have " + (MAX_ATTEMPTS - incorrectTries) + " attempts remaining.\n");
                }
                else
                {
                    incorrectTries++;
                    Console.WriteLine("Wrong! You have " + (MAX_ATTEMPTS - incorrectTries) + " attempts remaining.\n");
                }

                if (new string(displayedWord) == mysteryWord)
                {
                    hasUserWon = true;
                    break;  
                }
            }
            if (hasUserWon)
            {
                Console.WriteLine($"Congratulations you guessed the correct word! It was {mysteryWord}\n");
            }
            else
            {
                Console.WriteLine($"You lose. The correct word was {mysteryWord}");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();  // This line will pause the console until a key is pressed
        }
    }
}