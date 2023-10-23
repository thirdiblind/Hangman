namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_ATTEMPTS = 6;
            const int CHARLENGTH = 1;
            int incorrectTries = 0;

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

            char[] gameState = new char[mysteryWord.Length]; //Initialize the character array "gameState"
            for (int i = 0; i < gameState.Length; i++)  // Initialize game state with underscores
            {
                gameState[i] = '_';
            }
            bool hasUserWon = false;
            while (incorrectTries < MAX_ATTEMPTS)
            {
                {
                    Console.WriteLine("Hangman Game");
                    Console.WriteLine("============");
                    Console.WriteLine($"Guess the letters to a {mysteryWord.Length} letter word.\n");
                    Console.WriteLine(gameState);
                    Console.WriteLine();

                    Console.WriteLine("Enter a letter:");
                    char upperKeyChar = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.Clear(); //Clear text
                    Console.WriteLine($"You entered {upperKeyChar}");
                    Console.WriteLine();

                    bool isCorrect = false;
                    
                    for (int i = 0; i < mysteryWord.Length; i++)
                    {
                        if (mysteryWord[i] == upperKeyChar)
                        {
                            isCorrect = true;
                            gameState[i] = upperKeyChar;
                        }
                    }

                    if (isCorrect == true)
                    {
                        Console.WriteLine("Correct! You have " + (MAX_ATTEMPTS - incorrectTries) + " attempts remaining.");
                        Console.WriteLine();
                    }
                    else
                    {
                        incorrectTries++;
                        Console.WriteLine("Wrong! You have " + (MAX_ATTEMPTS - incorrectTries) + " attempts remaining.");
                        Console.WriteLine();
                    }

                    // Check if the word is completely gameStateed
                    if (new string(gameState) == mysteryWord)
                    {
                        hasUserWon |= true;
                        break;
                    }
                }
            }

            if (hasUserWon == true)
            { 
                Console.WriteLine($"Congratulations you guessed the correct word! It was z{mysteryWord}"); 
                Console.WriteLine();
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