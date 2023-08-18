// See https://aka.ms/new-console-template for more information


using System.ComponentModel;

namespace lovehangman
{
    class Program
    {
        static string Word;
        static int _wordLength;
        static Random RandomWord;
        static int _turns;
        static char guess;
        static List<char> GuessedLetters = new List<char>(); // 
        static List<char> UsedLetters = new List<char>(); // program to collect used letters
        private static char uransw;//  program to know the players answer 
        static List<string> _wordList = new List<string>() //  words list 
        {
           "cuba","hawaii", "sweden", "pakistan", "london", "finland", "spain", "russia", "usa", "china", "india","denmark",
        };


        static void Main(string[] args)
        {
            RandomWord = new Random();
            Start();
        }

        static void Start()
        {
            _turns = 6;
            Word = _wordList[RandomWord.Next(_wordList.Count() - 1)]; //randomize selection of word
            _wordLength = Word.Length; //getting and storing the length of selected word
            
          
           
            Console.Clear();
            Maindisplay();//goes to game Maindisplay method
        }

        static void Maindisplay()
        {
           
            Console.WriteLine("\n");
            Console.Write("Chances left: ");
          
            Console.Write(_turns);
          
            Console.WriteLine("\n");
            
            string guessingword = "";
            
            for (int i = 0; i < _wordLength; i++)
            {
                if(GuessedLetters.Any()) //checking any letter u try ( not null)
                {
                    if (GuessedLetters.Contains(Word[i])) //see if letter is in  random word
                    {
                        Console.Write(Word[i].ToString() + " "); //prints the letter
                        guessingword += Word[i].ToString();
                        if(guessingword == Word) // if all is guessed
                        {
                            Guessedword();
                            return;
                        }
                    }
                    else
                    {
                        Console.Write("_ "); // prints as line when input is not in the word
                    }
                    
                }
                else
                {
                    Console.Write("_ "); // prints as line when letter is not in the word
                    
                }
            }
            
            Console.WriteLine("\n\n");
            
            Console.Write("Used letter: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write (String.Join(" ",UsedLetters)); //prints out used letter
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.Write("Guess a letter: "); 
            guess = Char.ToLower(Console.ReadKey().KeyChar); //asks for a letter
            ConfirmInput();// confirms user to use input letter or discard
            
            
        }
        
        
        static void CheckGuess(char guess)
        {
            Console.WriteLine("\n");
            bool guessedOne = false;
            for(int i = 0; i < _wordLength; i++)
            {
                if(Word[i] == guess) // if letter is found in selected random word
                {
                    guessedOne = true;
                    GuessedLetters.Add(Word[i]);
                }
                
            }

            if (guessedOne == false) // -1 chance if letter is not found
                --_turns;
            
            if (_turns <= 0) // if chances run out go to fail
                Fail();

            Console.Clear();
            Maindisplay(); // returns to Maindisplay
        }

        
        
        static void ConfirmInput() // confirming user input
        {
            Console.WriteLine("\n");
            
            while (true)
            {
                //Console.WriteLine("Are you sure with your guess?");
                Console.WriteLine("Confirm by pressing \"Enter\"");
                Console.WriteLine("Delete by pressing \"Backspace\"");
            
                if (Console.ReadKey().Key == ConsoleKey.Enter) // use enter to confirm
                {
                    if (!UsedLetters.Contains(guess)) //saves incorrect letters to usedletter list
                    {
                        UsedLetters.Add(guess);
                        CheckGuess(guess);
                        Console.Clear();
                    }
                    if (UsedLetters.Contains(guess)) //asks user to input a different one since character has already been used.
                    {
                        Console.Clear();
                      
                        Console.WriteLine("Letter has been used. Choose a different one.");
                      
                        Maindisplay();
                    }

                    Console.Clear();
                }
                else if (Console.ReadKey().Key == ConsoleKey.Backspace)// use backspace to delete word
               
               {
                    Console.Clear();
                    Maindisplay();
                }

                else
                {
                    
                    Console.WriteLine("Invalid input.");
                }
                
                Console.WriteLine();
            }
        }

        static void Fail() // when failed to guess word
        {
            Console.Clear();
         
            Console.WriteLine("Sorry. You used ur all turns.");
            Console.WriteLine($"The word was: {Word.ToUpper()}");
            PlayAgain(); // asks if to play again
        }
        
        static void Guessedword() // u right guessed word
        {
            Console.Clear();
            
           
            Console.WriteLine("\n");
            Console.WriteLine("Congrats you win..!");
            Console.WriteLine($"{Word.ToUpper()} is the correct word.");
            PlayAgain(); // asks if to play again
        }
        static void PlayAgain() // asks to restart game
        {
            Console.WriteLine("\n");
            UsedLetters = new List<char>(); // resets usedletters
            Console.WriteLine("Would you like to play again? Y/N");
            while (uransw != 'y' || uransw != 'n') // while _answer is not y or n
            {
              
                uransw = char.ToLower(Console.ReadKey(true).KeyChar);
                

                if (uransw == 'y')
                {
                    Console.Clear();
                    GuessedLetters = new List<char>();
                    Start(); //start again
                }
               
                
                if (uransw == 'n')
                {
                    Console.Clear();
                    GuessedLetters = new List<char>();
                        End(); // end game
                   
                }
                
            }
        }
        static void End() 
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine();
          
            
            
            
            Environment.Exit(0);
        }

      
    }
}