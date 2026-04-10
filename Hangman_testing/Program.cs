{
    // variables
    bool isRunning = true;
    string[] dictionary = { "PIZZA", "TACO", "PROBABILITY", "BEAR", "CAPSULE","DETEST","EPISODE","FORLORN","GAS","HILL","INEXPLICABLE","JUKEBOX","KNEAD","LANTERN","MARZIPAN","NOCTURNE","TURN" };

    //Convoluted way to generate a random word and the lines
    Random random = new();
    int index = random.Next(0, dictionary.Length);
    string theWord = dictionary[index];
    string[,] guessedLetters = new string[theWord.Length, 2];
    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z" };


    int incorrectGuesses = 0;
    bool solved;

    //////

    Console.WriteLine("Welcome to Hangman! Guess the word by inputting one letter at a time! Guessed letters will be shown in lowercase.");

    Console.WriteLine("\n");

    for (int i = 0; i < theWord.Length; i++)
    {
        guessedLetters[i, 0] = "_";
        guessedLetters[i, 1] = $"{theWord[i]}";
        Console.Write(guessedLetters[i, 0]);

    }


    // actual game, it gets the index of the guessed letter and checks if it's in the word or not.
    while (isRunning)
    {
        Console.WriteLine("\n");

        // Is it inefficient? Yes. Does it work? Yes. Prints out the hanged man.
        switch (incorrectGuesses)
        {
            case 0:
                Console.Write("    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 1:
                Console.Write("        (        )\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 2:
                Console.Write("         ________    \n        (        )\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 3:
                Console.Write("            +\r\n            |     \r\n            |        \r\n            |      \r\n            |        \r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 4:
                Console.Write("            +--------+\r\n            |     \r\n            |        \r\n            |      \r\n            |        \r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 5:
                Console.Write("            +--------+\r\n            |/     \r\n            |        \r\n            |      \r\n            |        \r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 6:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        \r\n            |      \r\n            |        \r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 7:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        o\r\n            |      \r\n            |        \r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 8:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        o\r\n            |        |\r\n            |        |\r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 9:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        o\r\n            |       \\|\r\n            |        |\r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 10:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        o\r\n            |       \\|/\r\n            |        |\r\n            |       \r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 11:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        o\r\n            |       \\|/\r\n            |        |\r\n            |       /\r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                break;
            case 12:
                Console.Write("            +--------+\r\n            |/       |\r\n            |        o\r\n            |       \\|/\r\n            |        |\r\n            |       / \\\r\n         ________    \r\n        (        )\r\n    ~~~~~~~~~~~~~~~~~~~~~~");
                
                isRunning = false;
                Console.WriteLine("\n Oh no! The man was hanged, better luck next time!");
                break;
        }

        Console.WriteLine("\n");

        // displays the entire english alphabet
        for (int i = 0; i < alphabet.Length; i++)
        {
            Console.Write($"{alphabet[i]} ");
        }

        Console.WriteLine("\n");

        string userInput = Console.ReadLine();

        userInput = userInput.ToUpper();

        int letterCheck = theWord.IndexOf(userInput); // if the guessed letter isn't in theWord, it results in -1

        if (letterCheck != -1)
        {
            guessedLetters[letterCheck, 0] = userInput;

            for (int i = letterCheck; i < theWord.Length; i++)
            {
                int multiLetterCheck = theWord.IndexOf(userInput, i + 1);

                if (multiLetterCheck != -1)
                {
                    guessedLetters[multiLetterCheck, 0] = userInput;
                }

            }

        }
        else
        {
            incorrectGuesses++;
        }

        
        solved = true;

        for (int i = 0; i < guessedLetters.GetLength(0); i++)
        {
            if (guessedLetters[i, 0] != guessedLetters[i, 1])
            {
                solved = false;
            }
        }

        

        for (int i = 0; i < alphabet.Length; i++)
        {
            if (userInput == alphabet[i])
            {
                alphabet[i] = alphabet[i].ToLower();
                break;
            }
        }



        for (int i = 0; i < theWord.Length; i++)
        {
            Console.Write(guessedLetters[i, 0]);
        }
        Console.WriteLine("\n");

        if (solved == true)
        {
            isRunning = false;

            Console.WriteLine("Congratulations! You guessed the word!");
        }
    }
}






  
  
