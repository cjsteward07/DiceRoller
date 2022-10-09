(int, int, int) RandomGenerator(int diceSides)
{
    Random random = new Random();
    int firstRandomRoll = random.Next(1, diceSides + 1);
    int secondRandomRoll = random.Next(1, diceSides + 1);
    int diceTotal =  firstRandomRoll + secondRandomRoll;

    return (firstRandomRoll, secondRandomRoll, diceTotal);
}

// string DiceCombination(int firstRandomRoll, int secondRandomRoll, int diceTotal, int diceSides)
// {
//     string rollResults = string.Empty;

//     if (diceTotal == 7 || diceTotal == 11)
//     {
//         rollResults = "Congrats, you've won!";
//         return rollResults;
//     }
//     else if (firstRandomRoll == 1 && secondRandomRoll == 1)
//     {
//         rollResults = "Snake Eyes!";
//         return rollResults;
//     }
//     else if (firstRandomRoll == 6 && secondRandomRoll == 6)
//     {
//         rollResults = "Box Cars";
//         return rollResults;
//     }
//     else if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
//     {
//         rollResults = "Craps!";
//         return rollResults;
//     }
//     else if ((firstRandomRoll == 1 && secondRandomRoll == 2) || (secondRandomRoll == 1 && secondRandomRoll == 2))
//     {
//         rollResults = "Ace Deuce";
//         return rollResults;
//     }

//     string defaultMessage = "Sorry, try again!";
//     return defaultMessage;
// }

string SixSidedDice(int firstRandomRoll, int secondRandomRoll, int diceTotal)
{
    string rollResults = string.Empty;
    string defaultMessage = string.Empty;

    if (diceTotal == 7 || diceTotal == 11)
    {
        rollResults = "Congrats, you've won!";
        return rollResults;
    }
    else if (firstRandomRoll == 1 && secondRandomRoll == 1)
    {
        rollResults = "Craps & Snake Eyes!";
        return rollResults;
    }
    else if (firstRandomRoll == 6 && secondRandomRoll == 6)
    {
        rollResults = "Box Cars";
        return rollResults;
    }
    else if ((firstRandomRoll == 1 && secondRandomRoll == 2) || (firstRandomRoll == 2 && secondRandomRoll == 1))
    {
        rollResults = "Craps & Ace Deuce";
        return rollResults;
    }
    else
    {
        if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
        {
            rollResults = "Craps!";
            return rollResults;
        }
        else
        {
            return defaultMessage;
        }
    }
}

// string CrapsChecker(int diceTotal)
// {
//     string message = string.Empty;
//     if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
//     {
//         message = "Craps!";
//         return message;
//     }
//     else
//     {
//         return message;
//     }
// }

// string FiveSidedDice(int firstRandomRoll, int secondRandomRoll, int diceTotal, int diceSides)
// {
//     string rollResults = string.Empty;

//     if (diceTotal == 7 || diceTotal == 11)
//     {
//         rollResults = "Congrats, you've won!";
//         return rollResults;
//     }
//     else if (firstRandomRoll == 1 && secondRandomRoll == 1)
//     {
//         rollResults = "Snake Eyes!";
//         return rollResults;
//     }
//     else if (firstRandomRoll == 6 && secondRandomRoll == 6)
//     {
//         rollResults = "Box Cars";
//         return rollResults;
//     }
//     else if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
//     {
//         rollResults = "Craps!";
//         return rollResults;
//     }
//     else if ((firstRandomRoll == 1 && secondRandomRoll == 2) || (secondRandomRoll == 1 && secondRandomRoll == 2))
//     {
//         rollResults = "Ace Deuce";
//         return rollResults;
//     }

//     string defaultMessage = "";
//     return defaultMessage;
// }


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
    Console.WriteLine($"The total of your two rolls is: {diceTotal}");

    if(diceSides == 6)
    {
        string sixSides = SixSidedDice(firstRandomRoll, secondRandomRoll, diceTotal);
        Console.WriteLine(sixSides);
    }

    Console.WriteLine("Would you like to play again? [y]/[n]: ");
    string menuChoice = Console.ReadLine().ToLower();
    if (menuChoice == "y" || menuChoice == "yes")
    {
        Menu();
    }
    else if (menuChoice == "n" || menuChoice == "no")
    {
        Environment.Exit(0);
    }
}
// else if (diceSides == 5)
// {
//     string fiveSides = FiveSidedDice(firstRandomRoll, secondRandomRoll, diceTotal, diceSides);
//     Console.WriteLine(fiveSides);
// }
// else if (diceSides == 4)
// {
//     string fourSides = FourSidedDice(firstRandomRoll, secondRandomRoll, diceTotal, diceSides);
//     Console.WriteLine(fourSides);
//  }


Menu();
