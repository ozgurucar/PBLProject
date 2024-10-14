using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;


Random rnd = new Random();

int gameMode;
double turn = 0;


String letterD = "D";
String letterE = "E";
String letterU = "U";
String colorGreen = ".";
String colorBlue = "_";
String colorRed = " ";
String a1letter = "";
String a1color = "";
String a2letter = "";
String a2color = "";
String a3letter = "";
String a3color = "";
String a4letter = "";
String a4color = "";
String a5letter = "";
String a5color = "";
String a6letter = "";
String a6color = "";
String a7letter = "";
String a7color = "";
String a8letter = "";
String a8color = "";
String a9letter = "";
String a9color = "";
int pointsOfHuman = 20;
int pointsOfComputer = 20;

Console.WriteLine("Enter game mode: ");
Console.WriteLine("1: Easy");
Console.WriteLine("2: Moderate");
Console.WriteLine("3: Hard");
gameMode = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= 9; i++)
{
    int randomLetter = rnd.Next(0, 3);
    int randomColor = rnd.Next(0, 3);
    String letter = "";
    String color = "";
    switch (randomLetter)
    {
        case 0:
            letter = letterD;
            break;
        case 1:
            letter = letterE;
            break;
        case 2:
            letter = letterU;
            break;
    }

    switch (randomColor)
    {
        case 0:
            color = colorRed;
            break;
        case 1:
            color = colorGreen;
            break;
        case 2:
            color = colorBlue;
            break;
    }


    switch (i)
    {
        case 1:
            a1letter = letter;
            a1color = color;
            break;
        case 2:
            a2letter = letter;
            a2color = color;
            break;
        case 3:
            a3color = color;
            a3letter = letter;
            break;
        case 4:
            a4letter = letter;
            a4color = color;
            break;
        case 5:
            a5letter = letter;
            a5color = color;
            break;
        case 6:
            a6letter = letter;
            a6color = color;
            break;
        case 7:
            a7letter = letter;
            a7color = color;
            break;
        case 8:
            a8letter = letter;
            a8color = color;
            break;
        case 9:
            a9letter = letter;
            a9color = color;
            break;
    }
}

while (turn <= 10)
{
    String toCalculateLetters = "";
    String toCalculateColors = "";
    int points = 0;

    for (int i = 1; i <= 8; i++)
    {
        if (i == 1)
        {
            toCalculateLetters = a1letter + a2letter + a3letter;
            toCalculateColors = a1color + a2color + a3color;
        }
        else if (i == 2)
        {
            toCalculateLetters = a4letter + a5letter + a6letter;
            toCalculateColors = a4color + a5color + a6color;
        }
        else if (i == 3)
        {
            toCalculateLetters = a7letter + a8letter + a9letter;
            toCalculateColors = a7color + a8color + a9color;
        }
        else if (i == 4)
        {
            toCalculateLetters = a1letter + a4letter + a7letter;
            toCalculateColors = a1color + a4color + a7color;
        }
        else if (i == 5)
        {
            toCalculateLetters = a2letter + a5letter + a8letter;
            toCalculateColors = a2color + a5color + a8color;
        }
        else if (i == 6)
        {
            toCalculateLetters = a3letter + a6letter + a9letter;
            toCalculateColors = a3color + a6color + a9color;
        }
        else if (i == 7)
        {
            toCalculateLetters = a1letter + a5letter + a9letter;
            toCalculateColors = a1color + a5color + a9color;
        }

        else if (i == 8)
        {
            toCalculateLetters = a3letter + a5letter + a7letter;
            toCalculateColors = a3color + a5color + a7color;
        }

        int colorCheck = 0;

        if (toCalculateColors == "..." || toCalculateColors == "   " || toCalculateColors == "___")
        {
            colorCheck = 1;
        }
        else if (toCalculateColors == "._ " || toCalculateColors == ". _" || toCalculateColors == "_. " || toCalculateColors == "_ ." || toCalculateColors == " ._" || toCalculateColors == " _.")
        {
            colorCheck = 2;
        }
        else
        {
            colorCheck = 3;
        }



        if (toCalculateLetters == "DEU" || toCalculateLetters == "UED")
        {
            if (colorCheck == 1)
            {
                points += 120;
            }
            else if (colorCheck == 2)
            {
                points += 110;
            }
            else
            {
                points += 100;
            }
        }

        else if (toCalculateLetters == "DUE" || toCalculateLetters == "UDE" || toCalculateLetters == "EUD" || toCalculateLetters == "EDU")
        {
            if (colorCheck == 1)
            {
                points += 90;
            }
            else if (colorCheck == 2)
            {
                points += 80;
            }
            else
            {
                points += 70;
            }
        }

        else if (toCalculateLetters == "DDD" || toCalculateLetters == "EEE" || toCalculateLetters == "UUU")
        {
            if (colorCheck == 1)
            {
                points += 60;
            }
            else if (colorCheck == 2)
            {
                points += 50;
            }
            else
            {
                points += 40;
            }
        }

        else
        {
            if (colorCheck == 1)
            {
                points += 30;
            }
            else if (colorCheck == 2)
            {
                points += 20;
            }
            else
            {
                points += 0;
            }
        }
    }


    if (turn == 0)
    {
        pointsOfHuman += points;
        pointsOfComputer += points;
        Console.WriteLine("------ Initial Board ------");
        Console.WriteLine("");
        Console.WriteLine("    1" + "  2" + "  3");
        Console.WriteLine("  +----------+");
        Console.WriteLine("1 " + "| " + a1letter + a1color + " " + a2letter + a2color + " " + a3letter + a3color + " |");
        Console.WriteLine("2 " + "| " + a4letter + a4color + " " + a5letter + a5color + " " + a6letter + a6color + " |");
        Console.WriteLine("3 " + "| " + a7letter + a7color + " " + a8letter + a8color + " " + a9letter + a9color + " |");
        Console.WriteLine("  +----------+");
        Console.WriteLine("");
        Console.WriteLine("Board Score: " + points);

    }

    else if (turn % 2 == 0) {
        pointsOfComputer -= 10;
        Console.WriteLine("");
        Console.WriteLine("---- Round " + Math.Ceiling(turn / 2) + " ----" + "Turn: Computer");
        Console.WriteLine("");
        Console.WriteLine("    1" + "  2" + "  3");
        Console.WriteLine("  +----------+");
        Console.WriteLine("1 " + "| " + a1letter + a1color + " " + a2letter + a2color + " " + a3letter + a3color + " |   " + "H.Scpre: " + pointsOfHuman);
        Console.WriteLine("2 " + "| " + a4letter + a4color + " " + a5letter + a5color + " " + a6letter + a6color + " |   " + "C.Score: " + pointsOfComputer);
        Console.WriteLine("3 " + "| " + a7letter + a7color + " " + a8letter + a8color + " " + a9letter + a9color + " |");
        Console.WriteLine("  +----------+");
        Console.WriteLine("");
        
        int tryCount = 0;
        if (gameMode == 1)
            tryCount = 25;
        else if (gameMode == 2)
            tryCount = 50;
        else if (gameMode == 3)
            tryCount = 100;
        int maxPoints = 0;

        int maxLocation = -1;
        int maxRow = -1;
        int maxCol = -1;
        String tryLetter = "";
        String tryColor = "";
        String maxLetter = "";
        String maxColor = "";
        

        for (int i = 0; i < tryCount; i++)
        {
            
            int row = rnd.Next(1, 4);
            int col = rnd.Next(1, 4);
            int location = (row - 1) * 3 + col;
            int randomLetter = rnd.Next(0, 3);
            int randomColor = rnd.Next(0, 3);
            int tryPoints = 0;

            String b1letter = a1letter;
            String b1color = a1color;
            String b2letter = a2letter;
            String b2color = a2color;
            String b3letter = a3letter;
            String b3color = a3color;
            String b4letter = a4letter;
            String b4color = a4color;
            String b5letter = a5letter;
            String b5color = a5color;
            String b6letter = a6letter;
            String b6color = a6color;
            String b7letter = a7letter;
            String b7color = a7color;
            String b8letter = a8letter;
            String b8color = a8color;
            String b9letter = a9letter;
            String b9color = a9color;

            if (randomLetter == 0)
            {
                tryLetter = letterD;
            }
            else if (randomLetter == 1)
            {
                tryLetter = letterE;
            }
            else if (randomLetter == 2)
            {
                tryLetter = letterU;
            }

            if (randomColor == 0)
            {
                tryColor = colorRed;
            }
            else if (randomColor == 1)
            {
                tryColor = colorGreen;
            }
            else if (randomColor == 2)
            {
                tryColor = colorBlue;
            }

            if (location == 1)
            {
                b1letter = tryLetter;
                b1color = tryColor;
            }
            else if (location == 2)
            {
                b2letter = tryLetter;
                b2color = tryColor;
            }
            else if (location == 3)
            {
                b3letter = tryLetter;
                b3color = tryColor;
            }
            else if (location == 4)
            {
                b4letter = tryLetter;
                b4color = tryColor;
            }
            else if (location == 5)
            {
                b5letter = tryLetter;
                b5color = tryColor;
            }
            else if (location == 6)
            {
                b6letter = tryLetter;
                b6color = tryColor;
            }
            else if (location == 7)
            {
                b7letter = tryLetter;
                b7color = tryColor;
            }
            else if (location == 8)
            {
                b8letter = tryLetter;
                b8color = tryColor;
            }
            else if (location == 9)
            {
                b9letter = tryLetter;
                b9color = tryColor;
            }

            for (int j = 1; j <= 8; j++)
            {
                if (j == 1)
                {
                    toCalculateLetters = b1letter + b2letter + b3letter;
                    toCalculateColors = b1color + b2color + b3color;
                }
                else if (j == 2)
                {
                    toCalculateLetters = b4letter + b5letter + b6letter;
                    toCalculateColors = b4color + b5color + b6color;
                }
                else if (j == 3)
                {
                    toCalculateLetters = b7letter + b8letter + b9letter;
                    toCalculateColors = b7color + b8color + b9color;
                }
                else if (j == 4)
                {
                    toCalculateLetters = b1letter + b4letter + b7letter;
                    toCalculateColors = b1color + b4color + b7color;
                }
                else if (j == 5)
                {
                    toCalculateLetters = b2letter + b5letter + b8letter;
                    toCalculateColors = b2color + b5color + b8color;
                }
                else if (j == 6)
                {
                    toCalculateLetters = b3letter + b6letter + b9letter;
                    toCalculateColors = b3color + b6color + b9color;
                }
                else if (j == 7)
                {
                    toCalculateLetters = b1letter + b5letter + b9letter;
                    toCalculateColors = b1color + b5color + b9color;
                }

                else if (j == 8)
                {
                    toCalculateLetters = b3letter + b5letter + b7letter;
                    toCalculateColors = b3color + b5color + b7color;
                }

                int colorCheck = 0;

                if (toCalculateColors == "..." || toCalculateColors == "   " || toCalculateColors == "___")
                {
                    colorCheck = 1;
                }
                else if (toCalculateColors == "._ " || toCalculateColors == ". _" || toCalculateColors == "_. " || toCalculateColors == "_ ." || toCalculateColors == " ._" || toCalculateColors == " _.")
                {
                    colorCheck = 2;
                }
                else
                {
                    colorCheck = 3;
                }



                if (toCalculateLetters == "DEU" || toCalculateLetters == "UED")
                {
                    if (colorCheck == 1)
                    {
                        tryPoints += 120;
                    }
                    else if (colorCheck == 2)
                    {
                        tryPoints += 110;
                    }
                    else
                    {
                        tryPoints += 100;
                    }
                }

                else if (toCalculateLetters == "DUE" || toCalculateLetters == "UDE" || toCalculateLetters == "EUD" || toCalculateLetters == "EDU")
                {
                    if (colorCheck == 1)
                    {
                        tryPoints += 90;
                    }
                    else if (colorCheck == 2)
                    {
                        tryPoints += 80;
                    }
                    else
                    {
                        tryPoints += 70;
                    }
                }

                else if (toCalculateLetters == "DDD" || toCalculateLetters == "EEE" || toCalculateLetters == "UUU")
                {
                    if (colorCheck == 1)
                    {
                        tryPoints += 60;
                    }
                    else if (colorCheck == 2)
                    {
                        tryPoints += 50;
                    }
                    else
                    {
                        tryPoints += 40;
                    }
                }

                else
                {
                    if (colorCheck == 1)
                    {
                        tryPoints += 30;
                    }
                    else if (colorCheck == 2)
                    {
                        tryPoints += 20;
                    }
                    else
                    {
                        tryPoints += 0;
                    }
                }
            }
            if (tryPoints > maxPoints)
            {
                maxPoints = tryPoints;
                maxLocation = location;
                maxCol = col;
                maxRow = row;
                maxLetter = tryLetter;
                maxColor = tryColor;
            }

            if (i == tryCount - 1)
            {
                switch (maxLocation)
                {
                    case 1:
                        a1letter = maxLetter;
                        a1color = maxColor;
                        break;
                    case 2:
                        a2letter = maxLetter;
                        a2color = maxColor;
                        break;
                    case 3:
                        a3letter = maxLetter;
                        a3color = maxColor;
                        break;
                    case 4:
                        a4letter = maxLetter;
                        a4color = maxColor;
                        break;
                    case 5:
                        a5letter = maxLetter;
                        a5color = maxColor;
                        break;
                    case 6:
                        a6letter = maxLetter;
                        a6color = maxColor;
                        break;
                    case 7:
                        a7letter = maxLetter;
                        a7color = maxColor;
                        break;
                    case 8:
                        a8letter = maxLetter;
                        a8color = maxColor;
                        break;
                    case 9:
                        a9letter = maxLetter;
                        a9color = maxColor;
                        break;

                }
                 Console.WriteLine("My row: " + maxRow);
            Console.WriteLine("My column: " + maxCol);
            Console.WriteLine("My letter: " + maxLetter);
            Console.WriteLine("My color: " + maxColor);
            pointsOfComputer += maxPoints;
            Console.WriteLine("");
            Console.WriteLine("    1" + "  2" + "  3");
            Console.WriteLine("  +----------+");
            Console.WriteLine("1 " + "| " + a1letter + a1color + " " + a2letter + a2color + " " + a3letter + a3color + " |");
            Console.WriteLine("2 " + "| " + a4letter + a4color + " " + a5letter + a5color + " " + a6letter + a6color + " |");
            Console.WriteLine("3 " + "| " + a7letter + a7color + " " + a8letter + a8color + " " + a9letter + a9color + " |");
            Console.WriteLine("  +----------+");
            Console.WriteLine("");
            Console.WriteLine("Board Score: " + maxPoints);
            }
           
        }
    }

    else
    {
        pointsOfHuman -= 10;
        int humanPlayPoints = 0;
        Console.WriteLine("");
        Console.WriteLine("---- Round " + Math.Ceiling(turn / 2) + " ----" + "Turn: Human");
        Console.WriteLine("");
        Console.WriteLine("    1" + "  2" + "  3");
        Console.WriteLine("  +----------+");
        Console.WriteLine("1 " + "| " + a1letter + a1color + " " + a2letter + a2color + " " + a3letter + a3color + " |   " + "H.Scpre: " + pointsOfHuman);
        Console.WriteLine("2 " + "| " + a4letter + a4color + " " + a5letter + a5color + " " + a6letter + a6color + " |   " + "C.Score: " + pointsOfComputer);
        Console.WriteLine("3 " + "| " + a7letter + a7color + " " + a8letter + a8color + " " + a9letter + a9color + " |");
        Console.WriteLine("  +----------+");
        Console.WriteLine("");

        Console.WriteLine("Enter row: ");
        int row = Convert.ToInt32(Console.ReadLine()!);
        Console.WriteLine("Enter column: ");
        int col = Convert.ToInt32(Console.ReadLine()!);
        Console.WriteLine("Letter: ");
        String letter = Console.ReadLine()!;
        Console.WriteLine("Color: ");
        String color = Console.ReadLine()!;

        int location = (row - 1) * 3 + col;
        
                if (color == "B")
                {
                    color = "_";
                }
                else if (color == "G")
                {
                    color = ".";
                }
                else if (color == "R")
                {
                    color = " ";
                }

                if (location == 1)
                {
            a1letter = letter;
            a1color = color;
        }
                else if (location == 2)
                {
                  a2letter = letter;
            a2color = color;
        }
                else if (location == 3)
                {
                    a3letter = letter;
            a3color = color;
        }
                else if (location == 4)
                {
            a4letter = letter;
            a4color = color;
        }
                else if (location == 5)
                {
                   a5letter = letter;
            a5color = color;
        }
                else if (location == 6)
                {
            a6letter = letter;
            a6color = color; 
        }
                else if (location == 7)
                {
            a7letter = letter;
            a7color = color;
        }
                else if (location == 8)
                {
            a8letter = letter;
            a8color = color;
                }
                else if (location == 9)
                {
            a9letter = letter;
            a9color = color;
                }

        for (int i = 1; i <= 8; i++)
        {
            if (i == 1)
            {
                toCalculateLetters = a1letter + a2letter + a3letter;
                toCalculateColors = a1color + a2color + a3color;
            }
            else if (i == 2)
            {
                toCalculateLetters = a4letter + a5letter + a6letter;
                toCalculateColors = a4color + a5color + a6color;
            }
            else if (i == 3)
            {
                toCalculateLetters = a7letter + a8letter + a9letter;
                toCalculateColors = a7color + a8color + a9color;
            }
            else if (i == 4)
            {
                toCalculateLetters = a1letter + a4letter + a7letter;
                toCalculateColors = a1color + a4color + a7color;
            }
            else if (i == 5)
            {
                toCalculateLetters = a2letter + a5letter + a8letter;
                toCalculateColors = a2color + a5color + a8color;
            }
            else if (i == 6)
            {
                toCalculateLetters = a3letter + a6letter + a9letter;
                toCalculateColors = a3color + a6color + a9color;
            }
            else if (i == 7)
            {
                toCalculateLetters = a1letter + a5letter + a9letter;
                toCalculateColors = a1color + a5color + a9color;
            }

            else if (i == 8)
            {
                toCalculateLetters = a3letter + a5letter + a7letter;
                toCalculateColors = a3color + a5color + a7color;
            }

            int colorCheck = 0;

            if (toCalculateColors == "..." || toCalculateColors == "   " || toCalculateColors == "___")
            {
                colorCheck = 1;
            }
            else if (toCalculateColors == "._ " || toCalculateColors == ". _" || toCalculateColors == "_. " || toCalculateColors == "_ ." || toCalculateColors == " ._" || toCalculateColors == " _.")
            {
                colorCheck = 2;
            }
            else
            {
                colorCheck = 3;
            }



            if (toCalculateLetters == "DEU" || toCalculateLetters == "UED")
            {
                if (colorCheck == 1)
                {
                    humanPlayPoints += 120;
                }
                else if (colorCheck == 2)
                {
                    humanPlayPoints += 110;
                }
                else
                {
                    humanPlayPoints += 100;
                }
            }

            else if (toCalculateLetters == "DUE" || toCalculateLetters == "UDE" || toCalculateLetters == "EUD" || toCalculateLetters == "EDU")
            {
                if (colorCheck == 1)
                {
                    humanPlayPoints += 90;
                }
                else if (colorCheck == 2)
                {
                    humanPlayPoints += 80;
                }
                else
                {
                    humanPlayPoints += 70;
                }
            }

            else if (toCalculateLetters == "DDD" || toCalculateLetters == "EEE" || toCalculateLetters == "UUU")
            {
                if (colorCheck == 1)
                {
                    humanPlayPoints += 60;
                }
                else if (colorCheck == 2)
                {
                    humanPlayPoints += 50;
                }
                else
                {
                    humanPlayPoints += 40;
                }
            }

            else
            {
                if (colorCheck == 1)
                {
                    humanPlayPoints += 30;
                }
                else if (colorCheck == 2)
                {
                    humanPlayPoints += 20;
                }
                else
                {
                    humanPlayPoints += 0;
                }

                
            }
        }
        pointsOfHuman += humanPlayPoints;
        Console.WriteLine("");
        Console.WriteLine("    1" + "  2" + "  3");
        Console.WriteLine("  +----------+");
        Console.WriteLine("1 " + "| " + a1letter + a1color + " " + a2letter + a2color + " " + a3letter + a3color + " |");
        Console.WriteLine("2 " + "| " + a4letter + a4color + " " + a5letter + a5color + " " + a6letter + a6color + " |");
        Console.WriteLine("3 " + "| " + a7letter + a7color + " " + a8letter + a8color + " " + a9letter + a9color + " |");
        Console.WriteLine("  +----------+");
        Console.WriteLine("");
        Console.WriteLine("Board Score: " + humanPlayPoints);
    }
    if(turn == 10)
    {
        Console.WriteLine("Game Over");
        Console.WriteLine("Human Score: " + pointsOfHuman);
        Console.WriteLine("Computer Score: " + pointsOfComputer);
    }
    if (turn != 0)
    {
        for (int k = 0; k < 4; k++)
        {
            int location = rnd.Next(1, 10);
            int randomLetter = rnd.Next(0, 3);
            int randomColor = rnd.Next(0, 3);
            String letter = "";
            String color = "";
            switch (randomLetter)
            {
                case 0:
                    letter = letterD;
                    break;
                case 1:
                    letter = letterE;
                    break;
                case 2:
                    letter = letterU;
                    break;
            }

            switch (randomColor)
            {
                case 0:
                    color = colorRed;
                    break;
                case 1:
                    color = colorGreen;
                    break;
                case 2:
                    color = colorBlue;
                    break;
            }


            switch (location)
            {
                case 1:
                    a1letter = letter;
                    a1color = color;
                    break;
                case 2:
                    a2letter = letter;
                    a2color = color;
                    break;
                case 3:
                    a3color = color;
                    a3letter = letter;
                    break;
                case 4:
                    a4letter = letter;
                    a4color = color;
                    break;
                case 5:
                    a5letter = letter;
                    a5color = color;
                    break;
                case 6:
                    a6letter = letter;
                    a6color = color;
                    break;
                case 7:
                    a7letter = letter;
                    a7color = color;
                    break;
                case 8:
                    a8letter = letter;
                    a8color = color;
                    break;
                case 9:
                    a9letter = letter;
                    a9color = color;
                    break;
            }
        }
    }
    turn++;
}
