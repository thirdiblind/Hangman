namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_ATTEMPTS = 6;
            
            bool gameActive = true;

            while (gameActive)
            {
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

                List<char> lettersGuessed = new List<char>(); //A list to store letters that have been guessed by the user

                int randomNumber = new Random().Next(0, hangmanWords.Count);
                string mysteryWord = hangmanWords[randomNumber];
                char[] displayedWord = new char[mysteryWord.Length]; //Initialize the character array "displayedWord"


                bool hasUserWon = false;

                for (int i = 0; i < displayedWord.Length; i++)  // Initialize displayedWord with underscores
                {
                    displayedWord[i] = '_';
                }

                int incorrectTries = 0;
               

                Console.WriteLine("Hangman Game");
                Console.WriteLine("============");
                Console.WriteLine("Welcome to Hangman! Guess the hidden word one letter at a time. Be careful as too many wrong guesses ends the game!\n");

                while (incorrectTries < MAX_ATTEMPTS)
                {
                    Console.WriteLine($"Guess the letters to a {mysteryWord.Length} letter word.\n");

                    if (incorrectTries > 0)
                    {
                        Console.WriteLine($"Letters guessed so far: {string.Join(", ", lettersGuessed)}");
                    }

                    Console.WriteLine(displayedWord);
                    Console.WriteLine();
                    Console.WriteLine("Enter a letter:");

                    char upperKeyChar = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.Clear(); //Clear text
                    Console.WriteLine($"You entered {upperKeyChar}\n");

                    int triesLeft;
                    triesLeft = (MAX_ATTEMPTS - incorrectTries);


                    if (!lettersGuessed.Contains(upperKeyChar))
                    {
                        lettersGuessed.Add(upperKeyChar);

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
                            Console.WriteLine($"Correct! You have {triesLeft} attempts remaining.\n");
                        }
                        else
                        {
                            incorrectTries++;
                            triesLeft = (MAX_ATTEMPTS - incorrectTries);
                            Console.WriteLine($"Wrong! You have {triesLeft} attempts remaining.\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"You have {triesLeft} attempts remaining. The letter {upperKeyChar} has already been guessed! \n");
                        // No change to incorrectTries
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

                Console.WriteLine("Do you want to play again? (Y/N):");
                char replay = char.ToUpper(Console.ReadKey().KeyChar);

                if (replay == 'N')
                {
                    gameActive = false;
                }

                Console.Clear();
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();  // This line will pause the console until a key is pressed
        }
    }
}