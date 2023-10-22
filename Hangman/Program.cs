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

            char[] Guess = new char[mysteryWord.Length]; //Initialize the character array "Guess"
            for (int i = 0; i < Guess.Length; i++)  // Initialize Guess with underscores
            {
                Guess[i] = '_';
            }

            while (incorrectTries < MAX_ATTEMPTS)
            {
                {
                    Console.WriteLine("Hangman Game");
                    Console.WriteLine("============");
                    Console.WriteLine($"Guess the letters to a {mysteryWord.Length} letter word.\n");
                    Console.WriteLine(Guess);
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
                                Guess[i] = upperKeyChar;
                            }
                        }

                        if (isCorrect == true)
                        {
                            Console.WriteLine("Correct!");
                            Console.WriteLine();
                        }

                        else
                        {
                            incorrectTries++;
                            Console.WriteLine("Wrong! You have " + (MAX_ATTEMPTS - incorrectTries) + " attempts remaining.");
                            Console.WriteLine();
                        }

                        // Check if the word is completely guessed
                        if (new string(Guess) == mysteryWord)
                        {
                            Console.WriteLine($"Congratulations! You've guessed the word. It was {mysteryWord}!");
                            Console.WriteLine();
                            break;
                        }
                }
            }
            if (new string(Guess) != mysteryWord)
            {
                Console.WriteLine($"You lose. The correct word was {mysteryWord}");
            }
                Console.WriteLine("Press any key to exit.");
            Console.ReadKey();  // This line will pause the console until a key is pressed
        }
    }
}