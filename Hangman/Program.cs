namespace ConsoleApp
{
    class Program
    {
        public static readonly Random random = new Random();
        static void Main(string[] args)
        {
            const int MAX_ATTEMPTS = 6;
            const char PLACEHOLDER_CHAR = '_';
            const char YES_CHAR = 'Y'; 

            bool hasUserWon = false;
            int incorrectTries = 0;

                 // * * * * * * SECTION 1: Game loop initialization * * * * * *
            bool gameActive = true;

            while (gameActive)
            {
                // * * * * * * SECTION 2: Word list initialization * * * * * *
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

                int randomNumber = random.Next(0, hangmanWords.Count);
                string mysteryWord = hangmanWords[randomNumber];
                char[] displayedWord = new char[mysteryWord.Length]; //Initialize the character array "displayedWord"

                for (int i = 0; i < displayedWord.Length; i++)
                {
                    displayedWord[i] = PLACEHOLDER_CHAR;
                }

                Console.WriteLine("Welcome to Hangman! Guess the hidden word one letter at a time. Be careful as too many wrong guesses ends the game!\n");

                    // * * * * * * SECTION 3: Game setup and operation * * * * * *
                while (incorrectTries < MAX_ATTEMPTS)
                {
                    Console.WriteLine($"Guess the letters to a {mysteryWord.Length} letter word.\n");

                    if (incorrectTries > 0)
                    {
                        Console.WriteLine($"Letters guessed so far: {string.Join(", ", lettersGuessed)}"); //Convert lettersGuessed to string and output list
                    }

                    Console.WriteLine(displayedWord);
                    Console.WriteLine();
                    Console.WriteLine("Enter a letter:");

                    char upperKeyChar = char.ToUpper(Console.ReadKey().KeyChar); //Read user input - character
                    Console.Clear(); //Clear text
                    Console.WriteLine($"You entered {upperKeyChar}\n");

                    int triesLeft = MAX_ATTEMPTS - incorrectTries; //Initialize tries left counter

                    if (lettersGuessed.Contains(upperKeyChar)) //Check and output if letter has already been guessed
                    {
                        Console.WriteLine($"You have {triesLeft} attempts remaining. The letter {upperKeyChar} has already been guessed! \n");
                        continue; //Break out of loop if letter already guessed
                    }

                    lettersGuessed.Add(upperKeyChar); //Add letter to lettersGuessed if first time guessing letter
                    bool isCorrect = false;

                    for (int i = 0; i < mysteryWord.Length; i++) //Search through each char in mysteryWord, saving characters to displayedWord array that match 
                    {
                        if (mysteryWord[i] == upperKeyChar)
                        {
                            isCorrect = true;
                            displayedWord[i] = upperKeyChar;
                        }
                    }

                    if (isCorrect)
                    {
                        Console.WriteLine($"Correct! You have {triesLeft} attempts remaining.\n"); //Display when guess is correct. Show attempts remaining
                    }
                    else
                    {
                        incorrectTries++;
                        Console.WriteLine($"Wrong! You have {triesLeft - 1} attempts remaining.\n"); //Display when guess is wrong. Show attempts remaining
                    }

                    if (new string(displayedWord) == mysteryWord) //Check if displayedWord is equal to mysteryWord and if so, set true 
                    {
                        hasUserWon = true; 
                        break;
                    }
                }

                    // * * * * * * SECTION 4: Game results * * * * * *
                if (hasUserWon)
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {mysteryWord}");
                }
                else
                {
                    Console.WriteLine($"Sorry, you've run out of attempts! The word was: {mysteryWord}");
                }

                    // * * * * * * SECTION 5: Replay prompt * * * * * *
                Console.WriteLine("Do you want to play again? Press Y or y");
                char replay = char.ToUpper(Console.ReadKey().KeyChar);
                gameActive = (replay == YES_CHAR);

                //Clear previous game data for a new round
                incorrectTries = 0;
                hasUserWon = false;
                Console.Clear();
            }

                    // * * * * * * SECTION 6: Exit message * * * * * *
            Console.WriteLine("Thanks for playing! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
