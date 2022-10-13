(int, int, int) RandomGenerator(int diceSides)
{
    Random random = new Random();
    int firstRandomRoll = random.Next(1, diceSides + 1);
    int secondRandomRoll = random.Next(1, diceSides + 1);
    int diceTotal =  firstRandomRoll + secondRandomRoll;

    return (firstRandomRoll, secondRandomRoll, diceTotal);
}

string SixSidedDiceCombo(int firstRandomRoll, int secondRandomRoll)
{
    string rollResults = string.Empty;
    string defaultMessage = string.Empty;

    if (firstRandomRoll == 1 && secondRandomRoll == 1)
    {
        rollResults = "Snake Eyes!";
        return rollResults;
    }
    else if (firstRandomRoll == 6 && secondRandomRoll == 6)
    {
        rollResults = "Box Cars";
        return rollResults;
    }
    else if ((firstRandomRoll == 1 && secondRandomRoll == 2) || (firstRandomRoll == 2 && secondRandomRoll == 1))
    {
        rollResults = "Ace Deuce";
        return rollResults;
    }
    else
    {
        return defaultMessage;
    }
}

string SixSidedDiceTotal(int diceTotal)
{
    string rollResults = string.Empty;
    string defaultMessage = string.Empty;

    if (diceTotal == 7 || diceTotal == 11)
    {
        rollResults = "Congrats, you've won!";
        return rollResults;
    }
    else if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
    {
        rollResults = "Craps!";
        return rollResults;
    }
    else
    {
        return defaultMessage;
    }
}

string TenSidedDice(int firstRandomRoll, int secondRandomRoll, int diceTotal)
{
    string rollResults = string.Empty;
    string defaultMessage = string.Empty;

    if (diceTotal == 20)
    {
        rollResults = "Congrats, double tens. You've won!";
        return rollResults;
    }
    else if ((firstRandomRoll == 10 && secondRandomRoll == 5) || (firstRandomRoll == 5 && secondRandomRoll == 10))
    {
        rollResults = "15, my favorite number!";
        return rollResults;
    }
    else
    {
        return defaultMessage;
    }
}

void Menu()
{
    bool isValidInput = false;
    int diceSides = 0;
    int menuChoice;
    int firstRoll;
    int secondRoll;
    int diceTotal = 0;
    int firstRandomRoll = 0;
    int secondRandomRoll = 0;

    do
    {
        Console.WriteLine("Please enter a number from the menu below:");
        Console.WriteLine("1.) Play Game (Random)");
        Console.WriteLine("2.) Dev Mode (User Input)");
        isValidInput = int.TryParse(Console.ReadLine(), out menuChoice);
        if (isValidInput == false)
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
        }
    } while (isValidInput == false);

    switch(menuChoice)
    {
        case 1:
            Console.Clear();
            do
            {
                Console.WriteLine("Please enter the number of sides for the dice");
                isValidInput = int.TryParse(Console.ReadLine(), out diceSides);
                if (isValidInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number: \n");
                }
            } while (isValidInput == false);

            Console.Clear();
            Console.WriteLine($"Press any key to roll the {diceSides} sided dice: ");
            Console.ReadKey();

            var randomGeneratorReturn = RandomGenerator(diceSides);

            firstRandomRoll = randomGeneratorReturn.Item1;
            secondRandomRoll = randomGeneratorReturn.Item2;
            diceTotal = randomGeneratorReturn.Item3;
            break;

        case 2:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Developer Mode Enabled\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SixSidedDiceCombo Method. Requires user input of '6' sides:");
            Console.ResetColor();
            Console.WriteLine("Both rolls = 1: 'Snake Eyes'");
            Console.WriteLine("Both rolls = 6: 'Box Cars'");
            Console.WriteLine("Combination of 1 and 2: 'Ace Deuce'\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SixSidedDiceTotal Method. Requires user input of '6' sides:");
            Console.ResetColor();
            Console.WriteLine("Roll total = 7 or 11: 'Congrats, you've won!'");
            Console.WriteLine("Roll total = 2, 3, or 12: Message from both 'SixSidedDiceCombo' and 'SixSidedDiceTotal' methods\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TenSidedDice Method. Requires user input of '10' sides:");
            Console.ResetColor();
            Console.WriteLine("Roll total = 20: 'Congrats, double tens. You've won!'");
            Console.WriteLine("Roll total = 15: '15, my favorite number!'\n\n");
            Console.ResetColor();

            do 
            {
                Console.WriteLine("Please enter the number of sides for the dice:");
                isValidInput = int.TryParse(Console.ReadLine(), out diceSides);
                if (isValidInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number: \n");
                }
            } while (isValidInput == false);
            do
            {
                Console.WriteLine("Please enter the number for the first roll:");
                isValidInput = int.TryParse(Console.ReadLine(), out firstRoll);
                if (isValidInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number: \n");
                }
            } while (isValidInput == false);
            do
            {
                Console.WriteLine("Please enter the number for the second roll:");
                isValidInput = int.TryParse(Console.ReadLine(), out secondRoll);
                if (isValidInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number: \n");
                }
            } while (isValidInput == false);

            firstRandomRoll = firstRoll;
            secondRandomRoll = secondRoll;
            diceTotal = firstRoll + secondRoll;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid input, please choose a '1' or a '2' from the menu.");
            Menu();
            break;
    }

    Console.WriteLine($"Your first dice roll was {firstRandomRoll}");
    Console.WriteLine($"Your second dice roll was {secondRandomRoll}");
    Console.WriteLine($"The total of your two rolls is: {diceTotal}\n");

    if(diceSides == 6)
    {
        string sixSidesCombo = SixSidedDiceCombo(firstRandomRoll, secondRandomRoll);
        string sixSidesTotal = SixSidedDiceTotal(diceTotal);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(sixSidesCombo);
        Console.WriteLine(sixSidesTotal);
        Console.ResetColor();
    }
    else if(diceSides == 10)
    {
        string tenSides = TenSidedDice(firstRandomRoll, secondRandomRoll, diceTotal);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(tenSides);
        Console.ResetColor();
    }

    Console.WriteLine("Would you like to play again? [y]/[n]: ");
    do
    {
        isValidInput = false;

        string playAgain = Console.ReadLine().ToLower();

        if (playAgain == "y" || playAgain == "yes")
        {
            Console.Clear();
            Menu();
        }
        else if (playAgain == "n" || playAgain == "no")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. Would you like to play again? Please enter either a 'y' or an 'n'.\n");
        }
    } while (isValidInput == false);
}

Menu();
