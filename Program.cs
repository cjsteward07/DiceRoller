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
    int diceSides;

    Console.WriteLine("-Dice Roller Game-");

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

    int firstRandomRoll = randomGeneratorReturn.Item1;
    int secondRandomRoll = randomGeneratorReturn.Item2;
    int diceTotal = randomGeneratorReturn.Item3;

    Console.WriteLine($"Your first dice roll was {firstRandomRoll}");
    Console.WriteLine($"Your second dice roll was {secondRandomRoll}");
    Console.WriteLine($"The total of your two rolls is: {diceTotal}\n");

    if(diceSides == 6)
    {
        string sixSidesCombo = SixSidedDiceCombo(firstRandomRoll, secondRandomRoll);
        string sixSidesTotal = SixSidedDiceTotal(diceTotal);
        Console.WriteLine(sixSidesCombo);
        Console.WriteLine(diceTotal);
    }
    else if(diceSides == 10)
    {
        string tenSides = TenSidedDice(firstRandomRoll, secondRandomRoll, diceTotal);
        Console.WriteLine(tenSides);
    }

    Console.WriteLine("Would you like to play again? [y]/[n]: ");
    do
    {
        isValidInput = false;

        string menuChoice = Console.ReadLine().ToLower();

        if (menuChoice == "y" || menuChoice == "yes")
        {
            Console.Clear();
            Menu();
        }
        else if (menuChoice == "n" || menuChoice == "no")
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
